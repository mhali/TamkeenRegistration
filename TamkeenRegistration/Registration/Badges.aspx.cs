using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.IO;

namespace TamkeenRegistration.Registration
{
    public partial class Badges : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("TamkeenerView", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                gvTamkeener.DataSource = dtbl;
                gvTamkeener.DataBind();
            }

        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            if (gvTamkeener.Visible == false)
            {
                gvTamkeener.Visible = true;
                btnGetSelected.Text = "Get selected records";
                gvSelected.Visible = false;
                return;
            }

            gvTamkeener.Visible = false;
            gvSelected.Visible = true;
            btnGetSelected.Text = "Back to all TAMKEENERS";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Tamkeener_ID"), new DataColumn("FirstName"), new DataColumn("LastName") });
            foreach (GridViewRow row in gvTamkeener.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string Tamkeener_ID = row.Cells[1].Text;
                        string FirstName = row.Cells[2].Text;
                        string LastName = row.Cells[3].Text;
                        BadgeDisplay(FirstName, LastName, Tamkeener_ID);
                        dt.Rows.Add(Tamkeener_ID,FirstName,LastName);
                    }
                }
            }
            gvSelected.DataSource = dt;
            gvSelected.DataBind();
        }

        protected void BadgeDisplay(string FirstName, string LastName, string Tamkeener_ID)
        {
            Bitmap badge = CreateBadge(Tamkeener_ID, FirstName+ " " + LastName);
            MemoryStream ms = new MemoryStream();

            string outputFileName = Server.MapPath("~/badges/")+Tamkeener_ID + ".png";
            using (ms)
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    badge.Save(ms, ImageFormat.Png);
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        private Bitmap CreateBadge(string TamkeenerId, string Name)
        {
            int margin = 10;
            Bitmap badge = new Bitmap(Server.MapPath("~/logo.png"));
            Bitmap logoImage = new Bitmap(badge);
            int logoWidth = badge.Width;
            int logoHeight = badge.Height;
            Font threeOfNine = new Font("Free 3 of 9", 60, FontStyle.Regular, GraphicsUnit.Point);
            Font timesNewRoman = new Font("TimesNewRoman", 20, FontStyle.Regular, GraphicsUnit.Point);
            Graphics graphics = Graphics.FromImage(badge);
            SizeF badgeSize = new SizeF();
            badgeSize.Width = 2* margin+ logoWidth + graphics.MeasureString("*" + TamkeenerId + "*", threeOfNine).Width*2;
            badgeSize.Height = 2 * margin + graphics.MeasureString("*" + TamkeenerId + "*", threeOfNine).Height+ graphics.MeasureString(TamkeenerId, timesNewRoman).Height
                + graphics.MeasureString(Name, timesNewRoman).Height;
            badge = new Bitmap(badge, badgeSize.ToSize());
            graphics = Graphics.FromImage(badge);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            graphics.DrawImage(logoImage, new Rectangle(margin, margin, logoWidth, logoHeight));
            graphics.DrawString(TamkeenerId, timesNewRoman, new SolidBrush(Color.Black), margin+logoWidth, margin+0);
            graphics.DrawString("*" + TamkeenerId + "*", threeOfNine, new SolidBrush(Color.Black), margin+logoWidth, margin+graphics.MeasureString(TamkeenerId, timesNewRoman).Height);
            graphics.DrawString(Name, timesNewRoman, new SolidBrush(Color.Black), margin+logoWidth, margin+graphics.MeasureString(TamkeenerId, timesNewRoman).Height+ graphics.MeasureString("*" + TamkeenerId + "*", threeOfNine).Height);
            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();
            return badge;
        }
    }
}