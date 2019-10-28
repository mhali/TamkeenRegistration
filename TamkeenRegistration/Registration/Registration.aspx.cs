using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;

namespace TamkeenRegistration
{
    public partial class TamkeenRegistrationForm : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            lblLookUpSuccessMessage.Text = lblLookUpErrorMessage.Text = "";
            lblFSuccessMessage.Text = lblFErrorMessage.Text = "";
            lblGSuccessMessage.Text = lblGErrorMessage.Text = "";
            lblTSuccessMessage.Text = lblTErrorMessage.Text = "";
            if (!IsPostBack)
            {
                btnFDelete.Enabled = false;
                FillFamilyGridView();
            }

            txtQuicklookup.Focus();
        }

        protected void btnQuickLookup_Click(object sender, EventArgs e)
        {
            if (txtQuicklookup.Text == "")
                return;

            int Tamkeener_ID = Convert.ToInt32(txtQuicklookup.Text);
            int Family_ID = LoadTamkeenerInfo(Tamkeener_ID);
            if (Family_ID == 0)
            {
                lblLookUpErrorMessage.Text = "TAMKEENER info not found";
                return;
            }
            
            int Guardian_ID = LoadFamilyInfo(Family_ID);
            if (Guardian_ID == 0)
            {
                lblLookUpErrorMessage.Text = "Guardian info not found";
                return;
            }
            
            LoadGuardianInfo(Guardian_ID);

            lblLookUpSuccessMessage.Text = "TAMKEENER info loaded successfully";

            txtQuicklookup.Focus();
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtQuicklookup.Text == "")
                return;

            int Tamkeener_ID = Convert.ToInt32(txtQuicklookup.Text);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CheckInTamkeener", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0)
                {
                    lblLookUpSuccessMessage.Text = "Checked In Successfully!";
                }
                else
                {
                    throw new Exception(); 
                }
            }

            catch (Exception)
            {
                lblLookUpErrorMessage.Text = "Unable to check in TAMKEENER";
            }

            sqlCon.Close();
            txtQuicklookup.Text = "";
            txtQuicklookup.Focus();
        }

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] Photo = UploadPhotoFromFile();
                string strBase64 = Convert.ToBase64String(Photo);
                imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("UpdateTamkeenerPhoto", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TamkeenerID", txtTamkeenerId.Text == "" ? 0 : Convert.ToInt32(txtTamkeenerId.Text));
                sqlCmd.Parameters.AddWithValue("@Photo", Photo);

                if (sqlCmd.ExecuteNonQuery() > 0)
                    lblTSuccessMessage.Text = "Image uploaded Successfully";
                else
                    lblTSuccessMessage.Text = "Error uploading image";

                sqlCon.Close();
            }

            catch (Exception)
            {
                lblTErrorMessage.Text = "Unable to load photo!";
            }
        }

        byte[] UploadPhotoFromFile()
        {
            HttpPostedFile postedFile = TamkeenUploadPhoto.PostedFile;
            if (postedFile != null)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    return binaryReader.ReadBytes((int)stream.Length);
                }
            }

            return null;
        }

        //Fill grid views
        void FillFamilyGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("FamilyViewAll",sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvFamily.DataSource = dtbl;
            gvFamily.DataBind();        
        }

        void FillGuardianGridView()
        {
            if (txtFamilyId.Text == "")
                return;

            int Family_ID = Convert.ToInt32(txtFamilyId.Text);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GuardianViewByFamilyID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FamilyID", Family_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvGuardian.DataSource = dtbl;
            gvGuardian.DataBind();

            List<string> GuardianList = new List<string>();
            foreach (DataRow x in dtbl.Rows)
            {
                GuardianList.Add(x["Guardian_ID"].ToString());
            }
            DropdownlistMainGuardian.DataSource = GuardianList;
            DropdownlistMainGuardian.DataBind();

        }

        void FillTamkeenerGridView()
        {
            if (txtFamilyId.Text == "")
                return;
            int Family_ID = Convert.ToInt32(txtFamilyId.Text);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TamkeenerViewByFamilyID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FamilyID", Family_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTamkeener.DataSource = dtbl;
            gvTamkeener.DataBind();
        }

        //loadings
        protected void FamilyLnk_OnClick(object sender, EventArgs e)
        {
            int Family_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            txtQuicklookup.Text = "";
            ClearGuardian();
            ClearTamkeener();
            LoadFamilyInfo(Family_ID);
        }

        int LoadFamilyInfo(int Family_ID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("FamilyViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FamilyID", Family_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            txtFamilyId.Text = dtbl.Rows[0]["Family_ID"].ToString();
            txtFamilyName.Text = dtbl.Rows[0]["FamilyName"].ToString();
            txtNotes.Text = dtbl.Rows[0]["FamilyNotes"].ToString();
            txtLastLogin.Text = dtbl.Rows[0]["LastParentAccess"].ToString();
            txtUserName.Text = dtbl.Rows[0]["UserName"].ToString();
            txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtPassCode.Text = dtbl.Rows[0]["PassCode"].ToString();

            btnFSave.Text = "Update";
            btnFDelete.Enabled = true;
            FillGuardianGridView();
            if (dtbl.Rows[0]["MainGuardian"].ToString() != "")
            {
                DropdownlistMainGuardian.SelectedValue = dtbl.Rows[0]["MainGuardian"].ToString();
            }
            FillTamkeenerGridView();
            return dtbl.Rows[0]["MainGuardian"].ToString()==""? 0: int.Parse(dtbl.Rows[0]["MainGuardian"].ToString());
        }

        protected void GuardianLnk_OnClick(object sender, EventArgs e)
        {
            int Guardian_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            LoadGuardianInfo(Guardian_ID);
        }

        void LoadGuardianInfo(int Guardian_ID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GuardianViewByGuardianID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@GuardianID", Guardian_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            txtGuardianId.Text = dtbl.Rows[0]["Guardian_ID"].ToString();
            txtGFirstName.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtGMiddleName.Text = dtbl.Rows[0]["MiddleName"].ToString();
            txtGLastName.Text = dtbl.Rows[0]["LastName"].ToString();
            txtGEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtGPhone1.Text = dtbl.Rows[0]["Phone1"].ToString();
            txtGPhone2.Text = dtbl.Rows[0]["Phone2"].ToString();
            txtGStreet.Text = dtbl.Rows[0]["Street"].ToString();
            txtGCity.Text = dtbl.Rows[0]["City"].ToString();
            txtGState.Text = dtbl.Rows[0]["State"].ToString();
            txtGZipCode.Text = dtbl.Rows[0]["ZipCode"].ToString();
            lstGGender.SelectedValue = dtbl.Rows[0]["Gender"].ToString();
            txtGDOB.Text = dtbl.Rows[0]["DOB"].ToString()==""?"":DateTime.Parse(dtbl.Rows[0]["DOB"].ToString()).ToShortDateString();
            txtGEmployer.Text = dtbl.Rows[0]["Employer"].ToString();
            txtGOccupation.Text = dtbl.Rows[0]["Occupation"].ToString();
            txtGUserName.Text = dtbl.Rows[0]["WebsiteUserName"].ToString();
            DropdownlistRelationshipToYouth.SelectedValue = dtbl.Rows[0]["RelationshipToYouth"].ToString();
            txtOtherRelationship.Text = dtbl.Rows[0]["RelationshipToYouthOther"].ToString();

            btnGSave.Text = "Update";
            btnGDelete.Enabled = true;
        }

        protected void TamkeenerLnk_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int Family_ID = LoadTamkeenerInfo(Tamkeener_ID);
        }

        int LoadTamkeenerInfo(int Tamkeener_ID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TamkeenerViewByTamkeenerID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count == 0)
            {
                return 0;
            }

            txtQuicklookup.Text = txtTamkeenerId.Text = dtbl.Rows[0]["Tamkeener_ID"].ToString();
            txtTFirstName.Text = dtbl.Rows[0]["FirstName"].ToString();
            txtTMiddleName.Text = dtbl.Rows[0]["MiddleName"].ToString();
            txtTLastName.Text = dtbl.Rows[0]["LastName"].ToString();
            txtTEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtTPhone1.Text = dtbl.Rows[0]["Phone1"].ToString();
            txtTPhone2.Text = dtbl.Rows[0]["Phone2"].ToString();
            txtTStreet.Text = dtbl.Rows[0]["Street"].ToString();
            txtTCity.Text = dtbl.Rows[0]["City"].ToString();
            txtTState.Text = dtbl.Rows[0]["State"].ToString();
            txtTZipCode.Text = dtbl.Rows[0]["ZipCode"].ToString();
            lstTGender.SelectedValue = dtbl.Rows[0]["Gender"].ToString();
            txtTDOB.Text = dtbl.Rows[0]["DOB"].ToString()==""?"":DateTime.Parse(dtbl.Rows[0]["DOB"].ToString()).ToShortDateString();
            txtTSchoolName.Text = dtbl.Rows[0]["SchoolName"].ToString();
            txtTSchoolGrade.Text = dtbl.Rows[0]["SchoolGrade"].ToString();
            txtTUserName.Text = dtbl.Rows[0]["UserName"].ToString();
            txtTPassCode.Text = dtbl.Rows[0]["PassCode"].ToString();
            txtTLastAccess.Text = dtbl.Rows[0]["LastAccess"].ToString();
            if (dtbl.Rows[0]["EthnicBackground"].ToString() != "") DropdownlistEthnicBackground.SelectedValue = dtbl.Rows[0]["EthnicBackground"].ToString();
            txtOtherEthnicBackground.Text = dtbl.Rows[0]["EthnicBackgroundOther"].ToString();
            lblTamkeenWaiverLastUploaded.Text = dtbl.Rows[0]["TamkeenWaiverTimestamp"].ToString() == "" ? "" : DateTime.Parse(dtbl.Rows[0]["TamkeenWaiverTimestamp"].ToString()).ToShortDateString();
            lblUWWaiverLastUploaded.Text = dtbl.Rows[0]["UWWaiverTimestamp"].ToString() == "" ? "" : DateTime.Parse(dtbl.Rows[0]["UWWaiverTimestamp"].ToString()).ToShortDateString();
            lblScoutFormLastUploaded.Text = dtbl.Rows[0]["ScoutFormTimestamp"].ToString() == "" ? "" : DateTime.Parse(dtbl.Rows[0]["ScoutFormTimestamp"].ToString()).ToShortDateString();
            txtLastScoutRegistration.Text = dtbl.Rows[0]["LastScoutRenewDate"].ToString() == "" ? "" : DateTime.Parse(dtbl.Rows[0]["LastScoutRenewDate"].ToString()).ToShortDateString();

            if (dtbl.Rows[0]["Photo"].ToString() != "")
            {
                string strBase64 = Convert.ToBase64String((byte[])dtbl.Rows[0]["Photo"]);
                imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;
            }
            else
            {
                imgPhoto.ImageUrl = "";
            }

            if (dtbl.Rows[0]["LastCheckedIn"].ToString() != "")
            {
                DateTime LastCheckedIn = DateTime.Parse(dtbl.Rows[0]["LastCheckedIn"].ToString());
                if (LastCheckedIn.ToShortDateString() == DateTime.Today.ToShortDateString())
                {
                    txtLastChekedIn.Text = "Today" + dtbl.Rows[0]["LastCheckedIn"].ToString();
                    txtLastChekedIn.ForeColor = System.Drawing.Color.FromName("Green");
                }
            }

            txtLastChekedIn.Text = dtbl.Rows[0]["LastCheckedIn"].ToString();

            if (File.Exists(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_TamkeenWaiver.pdf"))
            {
                
                linkToTamkeenWaiver.NavigateUrl = "../Waiver Forms/" + txtTamkeenerId.Text + "_TamkeenWaiver.pdf";
            }
            else
            {
                linkToTamkeenWaiver.NavigateUrl = string.Empty;
            }

            if (File.Exists(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_UWWaiver.pdf"))
            {
                linkToUWWaiver.NavigateUrl = "../Waiver Forms/" + txtTamkeenerId.Text + "_UWWaiver.pdf";
            }
            else
            {
                linkToUWWaiver.NavigateUrl = string.Empty;
            }

            if (File.Exists(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_ScoutForm.pdf"))
            {
                linkToScoutForm.NavigateUrl = "../Waiver Forms/" + txtTamkeenerId.Text + "_ScoutForm.pdf";
            }
            else
            {
                linkToScoutForm.NavigateUrl = string.Empty;
            }

            btnTSave.Text = "Update";
            btnTDelete.Enabled = true;

            return int.Parse(dtbl.Rows[0]["Family_ID"].ToString());
        }

        //deletes
        protected void btnFamily_Delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("FamilyDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@FamilyID", Convert.ToInt32(txtFamilyId.Text));
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearFamily();
            FillFamilyGridView();

            if (noOfAffectedRows > 0)
                lblFSuccessMessage.Text = "Deleted Successfully";
            else
                lblFErrorMessage.Text = "Unable to delete";
        }
    
        protected void btnGuardian_Delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("GuardianDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@GuardianID", Convert.ToInt32(txtGuardianId.Text));
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearGuardian();
            FillGuardianGridView();
            if (noOfAffectedRows > 0)
                lblGSuccessMessage.Text = "Deleted Successfully";
            else
                lblGErrorMessage.Text = "Unable to delete";
        }

        protected void btnTamkeener_Delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TamkeenerDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Convert.ToInt32(txtTamkeenerId.Text));
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearTamkeener();
            FillTamkeenerGridView();
            if (noOfAffectedRows > 0)
                lblTSuccessMessage.Text = "Deleted Successfully";
            else
                lblTErrorMessage.Text = "Unable to delete";
        }

        //dropdown lists
        protected void DropdownlistRelationshipToYouth_TextChanged(object sender, EventArgs e)
        {
            if (DropdownlistRelationshipToYouth.SelectedValue == "4")
            {
                txtOtherRelationship.Enabled = true;
            }
            else
            {
                txtOtherRelationship.Enabled = false;
            }
        }

        protected void DropdownlistEthnicBackground_TextChanged(object sender, EventArgs e)
        {
            if (DropdownlistRelationshipToYouth.SelectedValue == "8")
            {
                txtOtherRelationship.Enabled = true;
            }
            else
            {
                txtOtherRelationship.Enabled = false;
            }
        }

        //Tamkeener specific links (waivers, attendance)
        protected void TamkeenerWaiver_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Write("<script>");
            Response.Write("window.open('../ParentPortal/TamkeenWaiverFormViewer.aspx?TamkeenerId=" + Tamkeener_ID.ToString() + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void TamkeenerAttendance_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Write("<script>");
            Response.Write("window.open('TamkeenerAttendance.aspx?TamkeenerId=" + Tamkeener_ID.ToString() + "&target=_blank')");
            Response.Write("</script>");

        }


        protected void TamkeenerArchive_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TamkeenerArchiveByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearTamkeener();
            FillTamkeenerGridView();
            if (noOfAffectedRows > 0)
                lblTSuccessMessage.Text = "Archived Successfully";
            else
                lblTErrorMessage.Text = "Unable to archive";

        }
        //Upload waiver forms
        protected void btnUploadTamkeenWaiver_Click(object sender, EventArgs e)
        {
            if (FileUploadTamkeenWaiver.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadTamkeenWaiver.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    if (fileExtension != ".pdf")
                    {
                        throw new Exception("Only .pdf files accepted");
                    }
                    FileUploadTamkeenWaiver.SaveAs(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_TamkeenWaiver" + fileExtension);
                    lblTSuccessMessage.Text = "Upload status: File uploaded!";

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateTamkeenWaiverTimestamp", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@TamkeenerID", Convert.ToInt32(txtTamkeenerId.Text));
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();

                }
                catch (Exception ex)
                {
                    lblTErrorMessage.Text = "Upload error: " + ex.Message;
                }

                LoadTamkeenerInfo(Convert.ToInt32(txtTamkeenerId.Text));
            }
        }


        protected void btnUploadUWWaiver_Click(object sender, EventArgs e)
        {
            if (FileUploadUWWaiver.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadUWWaiver.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    if (fileExtension != ".pdf")
                    {
                        throw new Exception("Only .pdf files accepted");
                    }

                    FileUploadUWWaiver.SaveAs(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_UWWaiver" + fileExtension);
                    lblTSuccessMessage.Text = "Upload status: File uploaded!";

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateUWWaiverTimestamp", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@TamkeenerID", Convert.ToInt32(txtTamkeenerId.Text));
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();

                }
                catch (Exception ex)
                {
                    lblTErrorMessage.Text = "Upload error: " + ex.Message;
                }

                LoadTamkeenerInfo(Convert.ToInt32(txtTamkeenerId.Text));
            }
        }

        protected void btnUploadScoutForm_Click(object sender, EventArgs e)
        {
            if (FileUploadScoutForm.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadScoutForm.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    if (fileExtension != ".pdf")
                    {
                        throw new Exception("Only .pdf files accepted");
                    }

                    FileUploadScoutForm.SaveAs(Server.MapPath("~/Waiver Forms/") + txtTamkeenerId.Text + "_ScoutForm" + fileExtension);
                    lblTSuccessMessage.Text = "Upload status: File uploaded!";

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateScoutFormTimestamp", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@TamkeenerID", Convert.ToInt32(txtTamkeenerId.Text));
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();

                }
                catch (Exception ex)
                {
                    lblTErrorMessage.Text = "Upload error: " + ex.Message;
                }

                LoadTamkeenerInfo(Convert.ToInt32(txtTamkeenerId.Text));
            }
        }

        // Copy guardian address's to tamkeener's address
        protected void btnCopyAddr_Click(object sender, EventArgs e)
        {
            txtTStreet.Text = txtGStreet.Text;
            txtTCity.Text = txtGCity.Text;
            txtTState.Text = txtGState.Text;
            txtTZipCode.Text = txtGZipCode.Text;

        }

        //Save
        protected void btnFamily_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("FamilyCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@FamilyId", txtFamilyId.Text == "" ? 0 : Convert.ToInt32(txtFamilyId.Text));
            sqlCmd.Parameters.AddWithValue("@FamilyName", txtFamilyName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@MainGuardian", DropdownlistMainGuardian.SelectedValue == "" ? (int?)null : Convert.ToInt32(DropdownlistMainGuardian.SelectedValue));


            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            ClearFamily();
            sqlCon.Close();
            FillFamilyGridView();

            if (noOfRecordsAffected > 0)
                lblFSuccessMessage.Text = "Saved Successfully";
            else
                lblFErrorMessage.Text = "Unable to save";

        }

        protected void btnGuardian_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("GuardianCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@GuardianID", txtGuardianId.Text == "" ? 0 : Convert.ToInt32(txtGuardianId.Text));
            sqlCmd.Parameters.AddWithValue("@RelationshipToYouth", Convert.ToInt32(DropdownlistRelationshipToYouth.SelectedValue));
            sqlCmd.Parameters.AddWithValue("@RelationshipToYouthOther", txtOtherRelationship.Text);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtGFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@MiddleName", txtGMiddleName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtGLastName.Text);
            sqlCmd.Parameters.AddWithValue("@Email", txtGEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Phone1", txtGPhone1.Text == "" ? (decimal?)null : Convert.ToDecimal(txtGPhone1.Text));
            sqlCmd.Parameters.AddWithValue("@Phone2", txtGPhone2.Text == "" ? (decimal?)null : Convert.ToDecimal(txtGPhone2.Text));
            sqlCmd.Parameters.AddWithValue("@Street", txtGStreet.Text);
            sqlCmd.Parameters.AddWithValue("@City", txtGCity.Text);
            sqlCmd.Parameters.AddWithValue("@ZipCode", txtGZipCode.Text == "" ? (decimal?)null : Convert.ToDecimal(txtGZipCode.Text));
            sqlCmd.Parameters.AddWithValue("@Gender", lstGGender.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@DOB", txtGDOB.Text);
            sqlCmd.Parameters.AddWithValue("@Employer", txtGEmployer.Text);
            sqlCmd.Parameters.AddWithValue("@Occupation", txtGOccupation.Text);
            sqlCmd.Parameters.AddWithValue("@WebsiteUsername", txtGUserName.Text);
            sqlCmd.Parameters.AddWithValue("@FamilyID", txtFamilyId.Text == "" ? 0 : Convert.ToInt32(txtFamilyId.Text));

            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();

            ClearGuardian();
            sqlCon.Close();
            FillGuardianGridView();

            if (noOfRecordsAffected > 0)
                lblGSuccessMessage.Text = "Saved Successfully";
            else
                lblGErrorMessage.Text = "Unable to save";
        }

        protected void btnTamkeener_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TamkeenerCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", txtTamkeenerId.Text == "" ? 0 : Convert.ToInt32(txtTamkeenerId.Text));
            sqlCmd.Parameters.AddWithValue("@EthnicBackground", Convert.ToInt32(DropdownlistEthnicBackground.SelectedValue));
            sqlCmd.Parameters.AddWithValue("@EthnicBackgroundOther", txtOtherEthnicBackground.Text);
            sqlCmd.Parameters.AddWithValue("@FirstName", txtTFirstName.Text);
            sqlCmd.Parameters.AddWithValue("@MiddleName", txtTMiddleName.Text);
            sqlCmd.Parameters.AddWithValue("@LastName", txtTLastName.Text);
            sqlCmd.Parameters.AddWithValue("@Email", txtTEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Phone1", txtTPhone1.Text == "" ? (decimal?)null : Convert.ToDecimal(txtTPhone1.Text));
            sqlCmd.Parameters.AddWithValue("@Phone2", txtTPhone2.Text == "" ? (decimal?)null : Convert.ToDecimal(txtTPhone2.Text));
            sqlCmd.Parameters.AddWithValue("@Street", txtTStreet.Text);
            sqlCmd.Parameters.AddWithValue("@City", txtTCity.Text);
            sqlCmd.Parameters.AddWithValue("@ZipCode", txtTZipCode.Text == "" ? (decimal?)null : Convert.ToDecimal(txtTZipCode.Text));
            sqlCmd.Parameters.AddWithValue("@Gender", lstTGender.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@DOB", txtTDOB.Text);
            sqlCmd.Parameters.AddWithValue("@SchoolName", txtTSchoolName.Text);
            sqlCmd.Parameters.AddWithValue("@SchoolGrade", txtTSchoolGrade.Text == "" ? (decimal?)null : Convert.ToDecimal(txtTSchoolGrade.Text));
            sqlCmd.Parameters.AddWithValue("@WebsiteUsername", txtTUserName.Text);
            sqlCmd.Parameters.AddWithValue("@FamilyID", txtFamilyId.Text == "" ? 0 : Convert.ToInt32(txtFamilyId.Text));
            sqlCmd.Parameters.AddWithValue("@LastScoutRenewDate", txtLastScoutRegistration.Text);

            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();

            ClearTamkeener();
            sqlCon.Close();
            FillTamkeenerGridView();

            if (noOfRecordsAffected > 0)
                lblTSuccessMessage.Text = "Saved Successfully";
            else
                lblTErrorMessage.Text = "Unable to save";
        }

        // Clear info
        protected void btnGeneratePassCode_Click(object sender, EventArgs e)
        {
            if (txtFamilyId.Text == "")
                return;

            int passCode = (new Random((int)DateTime.Now.Ticks)).Next(9999);
            txtPassCode.Text = passCode.ToString() ;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateFamilyPasscode", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@FamilyId", txtFamilyId.Text == "" ? 0 : Convert.ToInt32(txtFamilyId.Text));
            sqlCmd.Parameters.AddWithValue("@PassCode", passCode);

            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            //ClearFamily();
            sqlCon.Close();
            //FillFamilyGridView();

            if (noOfRecordsAffected > 0)
                lblFSuccessMessage.Text = "Saved Successfully";
            else
                lblFErrorMessage.Text = "Unable to save";

        }

        protected void btnEmailPassCode_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("tamkeen.moderator@gmail.com", "Kimo4050");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("tamkeen.moderator@gmail.com");
            msg.To.Add(new MailAddress(txtEmail.Text));
            msg.To.Add(new MailAddress("tamkeen.moderator@gmail.com"));

            msg.Subject = "TAMKEEN Password Reset Passcode";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body>Dear TAMKEEN Family,<br/> This email includes the account creation and/or password reset Passcode for the parent portal of TAMKEEN. Through Patent Portal, parents can edit their Tamkeeners' info, sign required forms and track their activities in TAMKEEN. Please visit http://tamkeen.us/tamkeen/CreateUser/CreateUser.aspx to reset your password. Please choose a Family Account Type. You will need to enter the following info" + "<br/> Family ID:" + txtFamilyId.Text + "<br/>PassCode:" + txtPassCode.Text + "<br/><br/> Once you create your username and password, please logon to www.tamkeen.us. Then, click on your family name on the top right corner of the page to be transferred to the parent portal. Then, you can add the parent info and register your youths in the Tamkeen program.<br/> <br/>" + "</body>");

            try
            {
                client.Send(msg);
                //lblMsg.Text = "Your message has been successfully sent.";
            }
            catch (Exception ex)
            {
                //lblMsg.ForeColor = Color.Red;
                //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            }
        }

        protected void btnFamily_Clear_Click(object sender, EventArgs e)
        {
            ClearFamily();
        }


        protected void btnGuardian_Clear_Click(object sender, EventArgs e)
        {
            ClearGuardian();
        }

        protected void btnTamkeener_Clear_Click(object sender, EventArgs e)
        {
            ClearTamkeener();
        }


        public void ClearFamily()
        {
            txtFamilyId.Text = txtFamilyName.Text = txtNotes.Text = txtPassCode.Text = txtLastLogin.Text = txtEmail.Text = txtUserName.Text = "";
            lblFSuccessMessage.Text = lblFErrorMessage.Text = "";
            DropdownlistMainGuardian.Items.Clear();
            DropdownlistMainGuardian.DataSource = null;
            DropdownlistMainGuardian.DataBind();
            btnFSave.Text = "Save";
            btnFDelete.Enabled = false;

            ClearGuardian();
            gvGuardian.DataSource = null;
            gvGuardian.DataBind();
        }

        public void ClearGuardian()
        {
            lblGSuccessMessage.Text = lblGErrorMessage.Text = "";
            txtGuardianId.Text = "";
            txtGFirstName.Text = "";
            txtGMiddleName.Text = "";
            txtGLastName.Text = "";
            txtGEmail.Text = "";
            txtGPhone1.Text = "";
            txtGPhone2.Text = "";
            txtGStreet.Text = "";
            txtGCity.Text = "";
            txtGState.Text = "";
            txtGZipCode.Text = "";
            lstGGender.SelectedIndex = 0;
            txtGDOB.Text = "";
            txtGEmployer.Text = "";
            txtGOccupation.Text = "";
            txtGUserName.Text = "";
            DropdownlistRelationshipToYouth.SelectedIndex = 0;
            txtOtherRelationship.Text = "";
            btnGSave.Text = "Save";
            btnGDelete.Enabled = false;
        }

        public void ClearTamkeener()
        {
            lblTSuccessMessage.Text = lblTErrorMessage.Text = "";
            txtTamkeenerId.Text = "";
            txtTFirstName.Text = "";
            txtTMiddleName.Text = "";
            txtTLastName.Text = "";
            txtTEmail.Text = "";
            txtTPhone1.Text = "";
            txtTPhone2.Text = "";
            txtTStreet.Text = "";
            txtTCity.Text = "";
            txtTState.Text = "";
            txtTZipCode.Text = "";
            lstTGender.SelectedIndex = 0;
            txtTDOB.Text = "";
            txtTSchoolName.Text = "";
            txtTSchoolGrade.Text = "";
            txtTUserName.Text = "";
            txtTLastAccess.Text = "";
            txtTPassCode.Text = "";
            DropdownlistEthnicBackground.SelectedIndex = 0;
            txtOtherEthnicBackground.Text = "";
            imgPhoto.ImageUrl = "";
            lblTamkeenWaiverLastUploaded.Text = "";
            lblUWWaiverLastUploaded.Text = "";
            lblScoutFormLastUploaded.Text = "";
            txtLastChekedIn.Text = "";
            txtLastScoutRegistration.Text = "";
            txtLastChekedIn.ForeColor = System.Drawing.Color.FromName("Black");
            btnTSave.Text = "Save";
            btnTDelete.Enabled = false;
        }


        protected void btnGenerateTPassCode_Click(object sender, EventArgs e)
        {
            if (txtTamkeenerId.Text == "")
                return;

            int passCode = (new Random((int)DateTime.Now.Ticks)).Next(9999);
            txtTPassCode.Text = passCode.ToString();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateTamkeenerPasscode", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerId", txtTamkeenerId.Text == "" ? 0 : Convert.ToInt32(txtTamkeenerId.Text));
            sqlCmd.Parameters.AddWithValue("@PassCode", passCode);

            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            //ClearFamily();
            sqlCon.Close();
            //FillFamilyGridView();

            if (noOfRecordsAffected > 0)
                lblFSuccessMessage.Text = "Saved Successfully";
            else
                lblFErrorMessage.Text = "Unable to save";

        }

        protected void btnEmailTPassCode_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("tamkeen.moderator@gmail.com", "Kimo4050");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("tamkeen.moderator@gmail.com");
            msg.To.Add(new MailAddress(txtTEmail.Text));
            msg.To.Add(new MailAddress("tamkeen.moderator@gmail.com"));

            msg.Subject = "TAMKEEN Password Reset Passcode";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body>Dear TAMKEENER,<br/> This email includes the account creation and/or password reset Passcode for the TAMKEENER portal of TAMKEEN. Please visit http://tamkeen.us/tamkeen/CreateUser/CreateUser.aspx to reset your password. You will need to enter the following info" + "<br/> Tamkeener ID:" + txtTamkeenerId.Text + "<br/>PassCode:" + txtTPassCode.Text + "<br/><br/> " + "</body>");

            try
            {
                client.Send(msg);
                //lblMsg.Text = "Your message has been successfully sent.";
            }
            catch (Exception ex)
            {
                //lblMsg.ForeColor = Color.Red;
                //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            }
        }



    }
}