using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace TamkeenRegistration.SocialMedia
{
    public partial class AddQuiz : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        static Byte[] Photo;

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
                FillQuizGridView();
            }
        }

        void FillQuizGridView()
        {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetQuizzes", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                gvQuiz.DataSource = dtbl;
                gvQuiz.DataBind();
        }

        protected void DeleteQuiz_OnClick(object sender, EventArgs e)
        {
            int QuizId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("DeleteQuiz", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@QuizId", QuizId);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();

            sqlCon.Close();

            FillQuizGridView();
        }

        protected void btnVideo_Clear_Click(object sender, EventArgs e)
        {
            ClearQuiz();
        }

        private void ClearQuiz()
        {
            txtQuizId.Text = "";
            txtVideoUrl.Text = "";
            txtDesc.Text = "";
            txtTitle.Text = "";
            imgPhoto.ImageUrl = "";
            Photo = null;
        }

        protected void btnVideo_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddOrUpdateQuiz", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@QuizId", txtQuizId.Text == "" ? 0 : Convert.ToInt32(txtQuizId.Text));
            sqlCmd.Parameters.AddWithValue("@VideoUrl", txtVideoUrl.Text.Trim().Replace("m.","www.").Replace("app=desktop", "").Replace("feature=youtu.be", "").Replace("&", "").Replace("watch?v=", "embed/"));
            sqlCmd.Parameters.AddWithValue("@Description", txtDesc.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());

            //Byte[] Photo = UploadPhotoFromFile();
            sqlCmd.Parameters.AddWithValue("@Photo", Photo);


            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            ClearQuiz();
            sqlCon.Close();
            FillQuizGridView();

            //if (noOfRecordsAffected > 0)
            //    lblFSuccessMessage.Text = "Saved Successfully";
            //else
            //    lblFErrorMessage.Text = "Unable to save";

        }

        protected void EditQuiz_OnClick(object sender, EventArgs e)
        {
            int QuizID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            LoadQuizById(QuizID);
        }

        private void LoadQuizById(int QuizId)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetQuizById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@QuizID", QuizId);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count == 0)
            {
                return;
            }

            txtQuizId.Text = dtbl.Rows[0]["QuizId"].ToString();
            txtVideoUrl.Text = dtbl.Rows[0]["VideoUrl"].ToString();
            txtDesc.Text = dtbl.Rows[0]["Description"].ToString();
            txtTitle.Text = dtbl.Rows[0]["title"].ToString();
            if (dtbl.Rows[0]["Photo"].ToString() != "")
            {
                Photo = (byte[])dtbl.Rows[0]["Photo"];
                string strBase64 = Convert.ToBase64String(Photo);
                imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;
            }
            else
            {
                imgPhoto.ImageUrl = "";
            }

        }


        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            //try
            //{
                Photo = UploadPhotoFromFile();
                string strBase64 = Convert.ToBase64String(Photo);
                imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;

                //if (sqlCon.State == ConnectionState.Closed)
                //    sqlCon.Open();
                //SqlCommand sqlCmd = new SqlCommand("UpdateTamkeenerPhoto", sqlCon);
                //sqlCmd.CommandType = CommandType.StoredProcedure;
                //sqlCmd.Parameters.AddWithValue("@TamkeenerID", txtTamkeenerId.Text == "" ? 0 : Convert.ToInt32(txtTamkeenerId.Text));
                //sqlCmd.Parameters.AddWithValue("@Photo", Photo);

                //sqlCmd.ExecuteNonQuery();
                //sqlCon.Close();


            //    if (sqlCmd.ExecuteNonQuery() > 0)
            //        lblTSuccessMessage.Text = "Image uploaded Successfully";
            //    else
            //        lblTSuccessMessage.Text = "Error uploading image";

            //    sqlCon.Close();
            //}

            //catch (Exception)
            //{
            //    lblTErrorMessage.Text = "Unable to load photo!";
            //}
        }

        byte[] UploadPhotoFromFile()
        {
            HttpPostedFile postedFile = QuizUpload.PostedFile;
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (dr["Photo"].ToString() == "")
                {
                    (e.Row.FindControl("Image1") as Image).ImageUrl = "";
                }
                else
                { 
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Photo"]);
                    (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                }
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvQuiz.PageIndex = e.NewPageIndex;
            this.FillQuizGridView();
        }
    }
}