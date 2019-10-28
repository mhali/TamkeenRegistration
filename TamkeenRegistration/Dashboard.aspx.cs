using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TamkeenRegistration
{
    public partial class Dashboard : System.Web.UI.Page
    {
        //SharedUtilities sharedUtilities = new SharedUtilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasAnyAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }
        }

        protected void RegistrationDashboard_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Registration/RegistrationDashboard.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void BudgetDashboard_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Budget/BudgetDashboard.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void SocialMedia_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('SocialMedia/SocialMediaDashboard.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void TaskManagement_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('TaskManagement/TaskManagement.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
    }
}