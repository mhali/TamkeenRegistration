using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TamkeenRegistration.SocialMedia
{
    public partial class SocialMediaDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

        }

        protected void EventSummaries_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('EventSummaries.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void SuggestedVideo_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('AddVideo.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void AddQuiz_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('AddQuiz.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void Agenda_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Agenda.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void Award_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Award.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void Quote_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('AddQuote.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

    }
}