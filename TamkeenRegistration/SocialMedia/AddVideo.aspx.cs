using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.SocialMedia
{
    public partial class AddVideo : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
                FillSuggestedVideoGridView();
            }

        }

        void FillSuggestedVideoGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetSuggestedVideos", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvVideo.DataSource = dtbl;
            gvVideo.DataBind();
        }

        protected void DeleteVideo_OnClick(object sender, EventArgs e)
        {
            int VideoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            
            SqlCommand sqlCmd = new SqlCommand("DeleteVideo", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@VideoId", VideoID);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            
            sqlCon.Close();

            FillSuggestedVideoGridView();
        }

        protected void btnVideo_Clear_Click(object sender, EventArgs e)
        {
            ClearVideo();
        }

        private void ClearVideo()
        {
            txtVideoId.Text = "";
            txtVideoUrl.Text = "";
            txtCaption.Text = "";
        }

        protected void btnVideo_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddOrUpdateVideo", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@VideoId", txtVideoId.Text == "" ? 0 : Convert.ToInt32(txtVideoId.Text));
            sqlCmd.Parameters.AddWithValue("@VideoUrl", txtVideoUrl.Text.Trim().Replace("m.", "www.").Replace("app=desktop", "").Replace("feature=youtu.be", "").Replace("&", "").Replace("watch?v=", "embed/"));
            sqlCmd.Parameters.AddWithValue("@Caption", txtCaption.Text.Trim());


            int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            ClearVideo();
            sqlCon.Close();
            FillSuggestedVideoGridView();

            //if (noOfRecordsAffected > 0)
            //    lblFSuccessMessage.Text = "Saved Successfully";
            //else
            //    lblFErrorMessage.Text = "Unable to save";

        }

        protected void EditVideo_OnClick(object sender, EventArgs e)
        {
            int VideoID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            LoadVideoById(VideoID);
        }

        private void LoadVideoById(int VideoId)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetVideoById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@VideoID", VideoId);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count == 0)
            {
                return;
            }

            txtVideoId.Text = dtbl.Rows[0]["VideoId"].ToString();
            txtVideoUrl.Text = dtbl.Rows[0]["VideoUrl"].ToString();
            txtCaption.Text = dtbl.Rows[0]["Caption"].ToString();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVideo.PageIndex = e.NewPageIndex;
            this.FillSuggestedVideoGridView();
        }

    }
}