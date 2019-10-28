using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.IO;

namespace TamkeenRegistration.Registration
{
    public partial class WaiverForms: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SharedUtilities.HasRegistrationAdminRights(Session) && !SharedUtilities.HasParentRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            //if (Session["AccountType"] == null)
            //{
            //    Session["User"] = Request.Cookies["User"].Value;
            //    Session["AccountType"] = Request.Cookies["AccountType"].Value;
            //    Session["Family_ID"] = Request.Cookies["Family_ID"].Value;
            //    Session["IsAdmin"] = Request.Cookies["IsAdmin"].Value;
            //}

            //if (Session["AccountType"].ToString() != "Family" && Session["AccountType"].ToString() != "Admin")
            //{
            //    throw new Exception("Non family or admin type account");
            //}

            LabelTamkeenerId.Text= Request.QueryString["TamkeenerId"];
            Bitmap barCode = CreateBarcode("*"+LabelTamkeenerId.Text+"*");
            MemoryStream ms = new MemoryStream();
            barCode.Save(ms, ImageFormat.Gif);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgBarCode.Src = "data:image/gif;base64," + base64Data;
            barCode.Dispose();
        }

        private Bitmap CreateBarcode(string Data)
        {
            Bitmap barCode = new Bitmap(1, 1);
            Font threeOfNine = new Font("Free 3 of 9", 60, FontStyle.Regular, GraphicsUnit.Point);
            Graphics graphics = Graphics.FromImage(barCode);
            SizeF dataSize = graphics.MeasureString(Data, threeOfNine);
            barCode = new Bitmap(barCode, dataSize.ToSize());
            graphics = Graphics.FromImage(barCode);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            graphics.DrawString(Data, threeOfNine, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();
            return barCode;
        }
    }

}