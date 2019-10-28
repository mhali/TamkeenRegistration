using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace TamkeenRegistration.Budget
{
    public partial class BudgetForm : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);


            if (!SharedUtilities.HasBudgetAdminRights(Session))
            {
                if (SharedUtilities.HasSubBudgetAdminRights(Session))
                {
                    btnTransAddCashBoy.Enabled = false;
                    btnTransAddCashGirl.Enabled = false;
                    btnUploadBank.Enabled = false;
                    btnUploadPayPal.Enabled = false;
                    btnTransClear.Enabled = false;
                    btnTransUpdate.Enabled = false;
                    btnTransDelete.Enabled = false;
                }
                else
                {
                    throw new Exception("Non admin type account");
                }
            }

            lblTransSuccessMessage.Text = lblTransErrorMessage.Text = "";
            lblBIDSuccessMessage.Text = lblBIDErrorMessage.Text = "";
            lblReceiptSuccessMessage.Text = lblReceiptErrorMessage.Text = "";

            if (!IsPostBack)
            {
                btnTransAddCashBoy.Visible = true;
                btnTransAddCashGirl.Visible = true;
                btnTransUpdate.Visible = false;
                btnTransDelete.Visible = false;

                lblBudgetSuccessMessage.Text = lblBudgetErrorMessage.Text = "";
                txtFromDate.Text = txtToDate.Text = "";
                FillAccountsGridView();
                FillSummariesGridView();
            }
        }

        protected void btnUploadBank_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = fileUploadBank.PostedFile;
            if (postedFile != null)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".csv")
                {
                    Stream stream = postedFile.InputStream;
                    StreamReader textReader = new StreamReader(stream);
                    while (!textReader.EndOfStream)
                    {
                        string line = textReader.ReadLine();
                        line = line.Replace("\"", "");
                        string[] lineItems = line.Split(new char[] { ',' });
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("AddWelssFargoLine", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@TransactionDate", Convert.ToDateTime(lineItems[0]));
                        sqlCmd.Parameters.AddWithValue("@Gross", lineItems[1]);
                        sqlCmd.Parameters.AddWithValue("@Notes", lineItems[4]);
                        if (sqlCmd.ExecuteNonQuery() > 0)
                        {
                            lblBudgetSuccessMessage.Text = "Uploaded Successfully";
                            FillAccountsGridView();
                            FillSummariesGridView();

                        }                        
                        else
                            lblBudgetErrorMessage.Text = "Error Uploading";
                    }
                }
                else
                {
                    lblBudgetErrorMessage.Text = "File must be a CSV file";
                }
            }
        }


        protected void btnUploadPayPal_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = fileUploadPayPal.PostedFile;
            if (postedFile != null)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".csv")
                {
                    Stream stream = postedFile.InputStream;
                    StreamReader textReader = new StreamReader(stream);
                    textReader.ReadLine();//skip headers
                    while (!textReader.EndOfStream)
                    {
                        string lineRaw = textReader.ReadLine();
                        string line = "";

                        bool isFirstQuote = false;
                        foreach (char c in lineRaw)
                        {
                            if (c == '"')
                            {
                                isFirstQuote = !isFirstQuote;
                                continue;
                            }
                            if (c == ',')
                            {
                                if (isFirstQuote)
                                {
                                    continue;
                                }
                            }

                            line += c;
                        }

                        //line = line.Replace("\"", "");
                        string[] lineItems = line.Split(new char[] { ',' });
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("AddPayPalLine", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@TransactionDate", Convert.ToDateTime(lineItems[0]));
                        sqlCmd.Parameters.AddWithValue("@TransactionDescription", lineItems[3]);
                        sqlCmd.Parameters.AddWithValue("@Gross", lineItems[7]);
                        sqlCmd.Parameters.AddWithValue("@Fee", lineItems[8]);
                        sqlCmd.Parameters.AddWithValue("@Net", lineItems[9]);
                        sqlCmd.Parameters.AddWithValue("@TransactionType", lineItems[4]);
                        sqlCmd.Parameters.AddWithValue("@TransactionStatus", lineItems[5]);
                        sqlCmd.Parameters.AddWithValue("@TransactionID", lineItems[12]);
                        sqlCmd.Parameters.AddWithValue("@Email1", lineItems[10]);
                        sqlCmd.Parameters.AddWithValue("@Email2", lineItems[11]);
                        if (sqlCmd.ExecuteNonQuery() > 0)
                        {
                            lblBudgetSuccessMessage.Text = "Uploaded Successfully";
                            FillAccountsGridView();
                            FillSummariesGridView();
                        }
                        else
                            lblBudgetErrorMessage.Text = "Error Uploading";
                    }
                }
                else
                {
                    lblBudgetErrorMessage.Text = "File must be a CSV file";
                }
            }
        }

        void FillAccountsGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAccountSummary", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvAccounts.DataSource = dtbl;
            gvAccounts.DataBind();
        }

        void FillSummariesGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllMoneyInHand", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvSummaries.DataSource = dtbl;
            gvSummaries.DataBind();
        }

        void FillReceiptGridView()
        {
            if (txtTrasSeqNo.Text == "")
                return;
            int TransactionSeqNo = Convert.ToInt32(txtTrasSeqNo.Text);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetItemReceipts", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TransactionSeqNo", TransactionSeqNo);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvReceipts.DataSource = dtbl;
            gvReceipts.DataBind();
        }

        void FillItemDetailGridView()
        {
            if (txtTrasSeqNo.Text == "")
                return;
            int TransactionSeqNo = Convert.ToInt32(txtTrasSeqNo.Text);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetBudgetItemDetails", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TransactionSeqNo", TransactionSeqNo);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvItemDetails.DataSource = dtbl;
            gvItemDetails.DataBind();
        }

        void ClearReceipts()
        {
            lblReceiptSuccessMessage.Text = lblReceiptErrorMessage.Text = "";

            gvReceipts.DataSource = null;
            gvReceipts.DataBind();
        }

        void ClearItemDetails()
        {
            gvItemDetails.DataSource = null;
            gvItemDetails.DataBind();
        }
        void FillTransactionsGridView(int AccountID, string FromDate, string ToDate)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetTransactions", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AccountID", AccountID);
            sqlDa.SelectCommand.Parameters.AddWithValue("@FromDate", FromDate == "" ? null : FromDate);
            sqlDa.SelectCommand.Parameters.AddWithValue("@ToDate", ToDate == "" ? null : ToDate);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTransactions.DataSource = dtbl;
            gvTransactions.DataBind();
        }

        protected void AccountLnk_OnClick(object sender, EventArgs e)
        {
            ClearTransaction();
            int AccountID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string FromDate = txtFromDate.Text;
            string ToDate = txtToDate.Text;
            FillTransactionsGridView(AccountID, FromDate, ToDate);
        }

        protected void TransactionLnk_OnClick(object sender, EventArgs e)
        {
            int SeqNo = Convert.ToInt32((sender as LinkButton).CommandArgument);
            imgReceipt.ImageUrl = "";
            ClearReciptImage.Visible = false;
            LoadTransaction(SeqNo);
        }
        void ClearTransaction()
        {
            lblTransSuccessMessage.Text = lblTransErrorMessage.Text = "";

            txtTrasSeqNo.Text = "";
            txtTransDate.Text = "";
            txtTransDesc.Text = "";
            txtTransGross.Text = txtGrossAmount.Text = "";
            txtTransFees.Text = "";
            transtxtNet.Text = "";
            txtTransType.Text = "";
            txtTransStatus.Text = "";
            txtTransID.Text = "";
            txtTransFromEmail.Text = "";
            txtTransToEmail.Text = "";
            txtTransNotes.Text = "";
            ClearReceipts();
            ClearDetails();
        }

        void LoadTransaction(int SeqNo)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetOneTransaction", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TransSeqNo", SeqNo);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            txtTrasSeqNo.Text = dtbl.Rows[0]["TransactionSeqNo"].ToString();
            txtTransDate.Text = DateTime.Parse(dtbl.Rows[0]["TransactionDate"].ToString()).ToShortDateString();//.ToString();
            txtTransDesc.Text = dtbl.Rows[0]["TransactionDescription"].ToString();
            txtTransGross.Text = txtGrossAmount.Text = dtbl.Rows[0]["Gross"].ToString();
            txtPercentage.Text = "100";
            txtTransFees.Text = dtbl.Rows[0]["Fee"].ToString();
            transtxtNet.Text = dtbl.Rows[0]["Net"].ToString();
            txtTransType.Text = dtbl.Rows[0]["TransactionType"].ToString();
            txtTransStatus.Text = dtbl.Rows[0]["TransactionStatus"].ToString();
            txtTransID.Text = dtbl.Rows[0]["TransactionID"].ToString();
            txtTransFromEmail.Text = dtbl.Rows[0]["Email1"].ToString();
            txtTransToEmail.Text = dtbl.Rows[0]["Email2"].ToString();
            txtTransNotes.Text = dtbl.Rows[0]["Notes"].ToString();
            FillReceiptGridView();
            FillItemDetailGridView();


            FillDropDownLists();

            btnTransAddCashBoy.Visible = false;
            btnTransAddCashGirl.Visible = false;
            btnTransUpdate.Visible = true;
            btnTransDelete.Visible = true;

        }

        void FillDropDownLists()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllActivityTypes", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            lstActivityType.DataSource = dtbl;
            lstActivityType.DataValueField = "ActivityID";
            lstActivityType.DataTextField = "ActivityName";
            lstActivityType.DataBind();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            sqlDa = new SqlDataAdapter("GetNonArchivedEvents", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            lstEvent.DataSource = dtbl;
            lstEvent.DataValueField = "EventID";
            lstEvent.DataTextField = "EventName";
            lstEvent.DataBind();
        }

        void ClearDetails()
        {
            lblBIDSuccessMessage.Text = lblBIDErrorMessage.Text = "";
            lstEvent.DataSource = null;
            lstEvent.DataBind();
            lstActivityType.DataSource = null;
            lstActivityType.DataBind();
            txtPercentage.Text = "100";
            ClearItemDetails();
        }

        protected void btnTransUpdate_Click(object sender, EventArgs e)
        {
            if (txtTrasSeqNo.Text == "")
                return;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateOneTransaction", sqlCon);
            int SeqNo = Convert.ToInt32(txtTrasSeqNo.Text);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TransSeqNo", SeqNo);
            sqlCmd.Parameters.AddWithValue("@TransactionDate", txtTransDate.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionDescription", txtTransDesc.Text);
            sqlCmd.Parameters.AddWithValue("@Gross", txtTransGross.Text);
            sqlCmd.Parameters.AddWithValue("@Fee", txtTransFees.Text);
            sqlCmd.Parameters.AddWithValue("@Net", transtxtNet.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionType", txtTransType.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionStatus", txtTransStatus.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionID", txtTransID.Text);
            sqlCmd.Parameters.AddWithValue("@Email1", txtTransFromEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Email2", txtTransToEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Notes", txtTransNotes.Text);
            int noOfAffectedRecord = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            LoadTransaction(SeqNo);
            FillAccountsGridView();
            FillSummariesGridView();

            if (noOfAffectedRecord > 0)
            {
                lblTransSuccessMessage.Text = "Transaction updated Successfully";
            }
            else
            {
                lblTransErrorMessage.Text = "Failed to update transaction";
            }


        }

        protected void btnTransDelete_Click(object sender, EventArgs e)
        {
            if (txtTrasSeqNo.Text == "")
                return;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DeleteOneTransaction", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TransSeqNo", Convert.ToInt32(txtTrasSeqNo.Text));
            int noOfAffectedRecord = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearTransaction();
            gvTransactions.DataSource = null;
            gvTransactions.DataBind();
            FillAccountsGridView();
            FillSummariesGridView();

            if (noOfAffectedRecord > 0)
            {
                lblTransSuccessMessage.Text = "Transaction Deleted Successfully";
            }
            else
            {
                lblTransErrorMessage.Text = "Failed to Delete transaction";
            }

        }

        protected void btnTransClear_Click(object sender, EventArgs e)
        {
            ClearTransaction();
            btnTransAddCashBoy.Visible = true;
            btnTransAddCashGirl.Visible = true;
            btnTransUpdate.Visible = false;
            btnTransDelete.Visible = false;
        }

        protected void btnTransAddCash(int @AccountID)
        {
            if (txtTrasSeqNo.Text != "")
                return;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddOneTransaction", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@AccountID", @AccountID);
            sqlCmd.Parameters.AddWithValue("@TransactionDate", txtTransDate.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionDescription", txtTransDesc.Text);
            sqlCmd.Parameters.AddWithValue("@Gross", txtTransGross.Text);
            sqlCmd.Parameters.AddWithValue("@Fee", txtTransFees.Text);
            sqlCmd.Parameters.AddWithValue("@Net", transtxtNet.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionType", txtTransType.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionStatus", txtTransStatus.Text);
            sqlCmd.Parameters.AddWithValue("@TransactionID", txtTransID.Text);
            sqlCmd.Parameters.AddWithValue("@Email1", txtTransFromEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Email2", txtTransToEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Notes", txtTransNotes.Text);

            int noOfAffectedRecord = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearTransaction();
            FillAccountsGridView();
            FillSummariesGridView();

            if (noOfAffectedRecord > 0)
            {
                lblTransSuccessMessage.Text = "Transaction Added Successfully";
            }
            else
            {
                lblTransErrorMessage.Text = "Failed to add transaction";
            }
        }

        protected void btnTransAddBoyCash_Click(object sender, EventArgs e)
        {
            btnTransAddCash(3);
            FillTransactionsGridView(3, txtFromDate.Text, txtToDate.Text);
        }

        protected void btnTransAddGirlCash_Click(object sender, EventArgs e)
        {
            btnTransAddCash(4);
            FillTransactionsGridView(4, txtFromDate.Text, txtToDate.Text);
        }


        protected void ReceiptViewLnk_OnClick(object sender, EventArgs e)
        {
            int ReceiptNo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetOneReceipt", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
             if (dtbl.Rows[0]["Photo"].ToString() != "")
            {
                string strBase64 = Convert.ToBase64String((byte[])dtbl.Rows[0]["Photo"]);
                imgReceipt.ImageUrl = "data:Image/png;base64," + strBase64;
                ClearReciptImage.Visible = true;
            }
            else
            {
                imgReceipt.ImageUrl = "";
            }

        }
        protected void ReceiptDeleteLnk_OnClick(object sender, EventArgs e)
        {
            int ReceiptNo = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DeleteReceipt", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
            FillReceiptGridView();
            imgReceipt.ImageUrl = "";

            if (noOfAffectedRecords > 0)
                lblReceiptSuccessMessage.Text = "Receipt deleted Successfully";
            else
                lblReceiptSuccessMessage.Text = "Unable to delete receipt";
        }

        protected void DetailDeleteLnk_OnClick(object sender, EventArgs e)
        {
            int udgetItemDetailSeqNo = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DeleteItemDetail", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BudgetItemDetailSeqNo", udgetItemDetailSeqNo);
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
            FillItemDetailGridView();

            if (noOfAffectedRecords > 0)
                lblBIDSuccessMessage.Text = "Budget item deleted Successfully";
            else
                lblBIDErrorMessage.Text = "Unable to delete budget item";

        }

        protected void btnClearReceipt_Click(object sender, EventArgs e)
        {
            imgReceipt.ImageUrl = "";
            ClearReciptImage.Visible = false;
        }

        protected void btnUploadReceipt_Click(object sender, EventArgs e)
        {
            if (txtTrasSeqNo.Text == "")
                return;
            Byte[] Photo = UploadPhotoFromFile();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddOrUpdateReceipts", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ReceiptNo", 0);
            sqlCmd.Parameters.AddWithValue("@TransactionSeqNo", Convert.ToInt32(txtTrasSeqNo.Text));
            sqlCmd.Parameters.AddWithValue("@Photo", Photo);
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            FillReceiptGridView();

            if (noOfAffectedRecords > 0)
                lblReceiptSuccessMessage.Text = "Receipt uploaded Successfully";
            else
                lblReceiptSuccessMessage.Text = "Unable to upload receipt";

        }

        byte[] UploadPhotoFromFile()
        {
            HttpPostedFile postedFile = uploadReceipt.PostedFile;
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

        protected void txtPercentage_TextChanged(object sender, EventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalDigits = 2;
            double partialGross = Convert.ToDouble(txtTransGross.Text) * Convert.ToDouble(txtPercentage.Text) / 100.00;
            txtGrossAmount.Text = Convert.ToDecimal(partialGross, provider).ToString();
        }

        protected void txtGrossAmount_TextChanged(object sender, EventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalDigits = 2;
            double percentage =  Convert.ToDouble(txtGrossAmount.Text) * 100.00/ Convert.ToDouble(txtTransGross.Text);
            txtPercentage.Text = Convert.ToDecimal(percentage, provider).ToString();
        }

        protected void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddItemDetail", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TransactionSeqNo", Convert.ToInt32(txtTrasSeqNo.Text));
            sqlCmd.Parameters.AddWithValue("@Gross", Convert.ToDouble(txtTransGross.Text)*Convert.ToDouble(txtPercentage.Text)/100.00);
            sqlCmd.Parameters.AddWithValue("@Fee", Convert.ToDouble(txtTransFees.Text) * Convert.ToDouble(txtPercentage.Text) / 100.00);
            sqlCmd.Parameters.AddWithValue("@Net", Convert.ToDouble(transtxtNet.Text) * Convert.ToDouble(txtPercentage.Text) / 100.00);
            sqlCmd.Parameters.AddWithValue("@BranchID", lstBudgetBranch.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@ActivityID", lstActivityType.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@EventID", lstEvent.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", txtParticipantID.Text==""? (int?)null : Convert.ToInt32(txtParticipantID.Text));
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
            FillItemDetailGridView();

            if (noOfAffectedRecords > 0)
                lblBIDSuccessMessage.Text = "Budget item added Successfully";
            else
                lblBIDErrorMessage.Text = "Unable to add budget item";
        }
    }
}