using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TamkeenRegistration.Budget
{
    public partial class BudgetDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasBudgetAdminRights(Session) && !SharedUtilities.HasSubBudgetAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

        }

        protected void Budget_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('Budget.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
        protected void Event_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('ManageEvents.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }

        protected void UnarchiveEvent_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('UnarchiveEvents.aspx?" + "&target=_blank')");
            Response.Write("</script>");

        }
    }
}