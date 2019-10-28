using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TamkeenRegistration.Registration
{
    public partial class RegistrationDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

        }
        protected void Registration_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Registration.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void Checkout_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('AddDriver.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void Attendance_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Attendance.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void Badges_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Badges.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void Unarchive_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('TamkeenerUnarchive.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void ParentPortal_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('../ParentPortal/Registration.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
    }


}