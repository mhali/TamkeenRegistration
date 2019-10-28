using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.Homepage
{
    public partial class Tamkeen : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {            
                //subFrame.Src = "DefaultSubframe.aspx";
                try
                {
                    if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        SharedUtilities.LoadFromCookies(Session, Request);
                        //if (Session["AccountType"] == null)
                        //{
                        //    Session["User"] = Request.Cookies["User"].Value;
                        //    Session["AccountType"] = Request.Cookies["AccountType"].Value;
                        //    Session["ID"] = Request.Cookies["ID"].Value;
                        //    Session["IsAdmin"] = Request.Cookies["IsAdmin"].Value;
                        //    Session["IsSocialMediaAdmin"] = Response.Cookies["IsSocialMediaAdmin"].Value;
                        //    Session["IsRegistrationAdmin"] = Response.Cookies["IsRegistrationAdmin"].Value;
                        //    Session["IsBudgetAdmin"] = Response.Cookies["IsBudgetAdmin"].Value;
                        //    Session["NickName"] = Response.Cookies["NickName"].Value;
                        //}

                        //btnSignUp.BackColor = System.Drawing.Color.Green;
                        btnSignUp.Font.Bold = true;
                        btnSignUp.Text = "Sign Out";

                        lblNickName.Visible = true;
                        lblNickName.Text = "Hi " + (Session["NickName"] == null ? "Tamkeener" : Session["NickName"].ToString());
                        lblNickName.ForeColor = System.Drawing.Color.Red;
                        lblNickName.Font.Bold = true;
                        lblNickName.Font.Italic = true;
                    }
                    else
                    {
                        //btnSignUp.BackColor = System.Drawing.Color.Red;
                        btnSignUp.Font.Bold = true;
                        btnSignUp.Text = "SIGN IN";
                        lblNickName.Text = "";
                        lblNickName.Visible = false;
                    }

                    LoadVLastTwoideo();

                }

                catch (Exception ex)
                {
                }
            }
        }

        private void LoadVLastTwoideo()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetLastTwoVideos", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count != 2)
            {
                return;
            }

            suggestedVideo1.Src = dtbl.Rows[0]["VideoUrl"].ToString();
            lblsuggestedVideo1.Text = dtbl.Rows[0]["Caption"].ToString();
            suggestedVideo2.Src = dtbl.Rows[1]["VideoUrl"].ToString();
            lblsuggestedVideo2.Text = dtbl.Rows[1]["Caption"].ToString();

        }


        protected void login_Click(object sender, EventArgs e)
        {
         //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Hello" + "')", true);
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (btnSignUp.Text == "Sign Out")
            {
                FormsAuthentication.SignOut();

                btnSignUp.BackColor = System.Drawing.Color.Red;
                btnSignUp.Font.Bold = true;
                btnSignUp.Text = "SIGN IN";
                lblNickName.Text = "";
                lblNickName.Visible = false;

                Response.Write("<script>");
                Response.Write("window.location.href='tamkeen.aspx'");
                Response.Write("</script>");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("window.location.href='../Login.aspx'");
                Response.Write("</script>");

            }
        }

        protected void lblNickName_Click(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (SharedUtilities.HasAnyAdminRights(Session))
            {
                Response.Redirect("~/Dashboard.aspx");
            }
            else if (SharedUtilities.HasParentRights(Session))
            {
                Response.Redirect("~/ParentPortal/Registration.aspx");
            }
        }



        //private void LoadVLastTwoideo()
        //{
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlDa = new SqlDataAdapter("GetLastTwoVideos", sqlCon);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    sqlCon.Close();
        //    if (dtbl.Rows.Count != 2)
        //    {
        //        return;
        //    }

        //    suggestedVideo1.Src = dtbl.Rows[0]["VideoUrl"].ToString();
        //    lblsuggestedVideo1.Text= dtbl.Rows[0]["Caption"].ToString();
        //    suggestedVideo2.Src = dtbl.Rows[1]["VideoUrl"].ToString();
        //    lblsuggestedVideo2.Text = dtbl.Rows[1]["Caption"].ToString();

        //}
        //protected void autoResize()
        //{
        //    int newheight;
        //    int newwidth;

        //    //if (document.getElementById(subFrame)) {
        //    newheight = document.getElementById(subFrame).contentWindow.document.body.scrollHeight;
        //    newwidth = document.getElementById(subFrame).contentWindow.document.body.scrollWidth;
        //    //}

        //    document.getElementById(id).height = (newheight) + "px";
        //    document.getElementById(id).width = (newwidth) + "px";
        //}

    }
}