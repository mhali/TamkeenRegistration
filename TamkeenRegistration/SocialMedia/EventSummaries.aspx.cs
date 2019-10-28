using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;


namespace TamkeenRegistration.SocialMedia
{
    public partial class EventSummaries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            lblPicSuccessMessage.Text = lblPicErrorMessage.Text = "";
        }


        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {
            try
            {
                imgPic.ImageUrl = "";
                imgPic.Dispose();
                UploadPhotoFromFile();
            }

            catch (Exception ex)
            {
                lblPicErrorMessage.Text = "Unable to load picture";
            }
        }

        void UploadPhotoFromFile()
        {
            HttpPostedFile postedFile = uploadPicture.PostedFile;
            if (postedFile != null)
            {
                int summaryWidth = 4032/4;
                int summaryHeight = 3036/4;
                Bitmap originalImage = new Bitmap(postedFile.InputStream);
                int originalWidth = originalImage.Width;
                int originalHeight = originalImage.Height;

                int resizedWidth;
                int resizedHeight;
                double wRatio = (double)originalWidth / summaryWidth;
                double hRatio = (double)originalHeight / summaryHeight;
                if (wRatio > hRatio)
                {
                    resizedWidth = summaryWidth;
                    resizedHeight = Convert.ToInt32(originalHeight / wRatio);
                }
                else
                {
                    resizedHeight = summaryHeight;
                    resizedWidth = Convert.ToInt32(originalWidth / hRatio);
                }


                Bitmap resizedImage = ResizeImage(originalImage, resizedWidth, resizedHeight);
                Bitmap logo = ResizeImage(new Bitmap(Server.MapPath("~/logo no text.png")),100,100);

                Bitmap summaryImage = new Bitmap(summaryWidth, summaryHeight);
                Graphics graphics = Graphics.FromImage(summaryImage);
                graphics.Clear(Color.LightBlue);
                graphics.DrawImage(resizedImage, new Rectangle(Math.Max((summaryWidth- resizedWidth)/2,0), Math.Max((summaryHeight - resizedHeight) / 2,0), resizedWidth, resizedHeight));

                int margin = 10;
                int logoWidth = logo.Width;
                int logoHeight = logo.Height;

                Pen snowPen = new Pen(Color.Green, 2);
                SolidBrush greenBrush = new SolidBrush(Color.Green);
                Point p1 = new Point(margin + logoWidth/2, summaryHeight - margin -logoHeight + 15);
                Point p2 = new Point(p1.X+200, p1.Y);
                Point p3 = new Point(p2.X+30, p1.Y+30);
                Point p4 = new Point(p1.X, p3.Y);
                Point[] pointArrayGreenPolygon = { p1, p2, p3, p4 };
                graphics.FillPolygon(greenBrush, pointArrayGreenPolygon);

                Point p5 = new Point(0, p3.Y);
                Point p6 = new Point(summaryWidth, p5.Y);
                Point p7 = new Point(summaryWidth, p6.Y+30);
                Point p8 = new Point(0, p7.Y);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                Point[] pointArrayBlackPolygon = { p5, p6, p7, p8 };
                graphics.FillPolygon(blackBrush, pointArrayBlackPolygon);

                graphics.DrawImage(logo, new Rectangle(margin, summaryHeight-margin-logoHeight, logoWidth, logoHeight));

                Font timesNewRoman = new Font("TimesNewRoman", 20, FontStyle.Regular, GraphicsUnit.Point);
                graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                graphics.DrawString(txtTime.Text, timesNewRoman, new SolidBrush(Color.Black), p1.X + logoWidth / 2, p1.Y);
                graphics.DrawString(txtCaption.Text, timesNewRoman, new SolidBrush(Color.White), p1.X + logoWidth / 2, p6.Y);
                graphics.DrawString(txtWhere.Text, timesNewRoman, new SolidBrush(Color.Yellow), summaryWidth - 350, p6.Y);

                MemoryStream ms = new MemoryStream();
                summaryImage.Save(ms, ImageFormat.Png);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgPic.ImageUrl = "data:image/png;base64," + base64Data;


                originalImage.Dispose();
                resizedImage.Dispose();
                summaryImage.Dispose();
            }           
        }

        private Bitmap ResizeImage(Bitmap img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }

    }
}