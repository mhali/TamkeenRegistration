using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace TamkeenRegistration.SocialMedia
{
    public partial class Award : System.Web.UI.Page
    {
        static Byte[] Photo;

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
            }
            else
            {
            }

        }


        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            Photo = UploadPhotoFromFile();
            string strBase64 = Convert.ToBase64String(Photo);
            lblPicPath.Text = strBase64;
            imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;

        }

        byte[] UploadPhotoFromFile()
        {
            HttpPostedFile postedFile = QuizUpload.PostedFile;
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

        public System.Drawing.Image stringToImage(string inputString)
        {
            //byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

            return image;
        }

        public static System.Drawing.Image CropToCircle(System.Drawing.Image srcImage, Color backGround)
        {
            Bitmap bitmap = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            System.Drawing.Image dstImage = bitmap;
            Graphics g = Graphics.FromImage(dstImage);
            using (Brush br = new SolidBrush(backGround))
            {
                g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            g.SetClip(path);
            g.DrawImage(srcImage, 0, 0);

            return dstImage;
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int originalWidth = 800;
            int originalHeight = 600;
            Bitmap originalImage = new Bitmap(originalWidth, originalHeight);
            Color bkColor;

            Graphics graphics = Graphics.FromImage(originalImage);
            if (GenderList.SelectedItem.Value == "Boys")
            {
                bkColor = Color.MediumAquamarine;
            }
            else
            {
                bkColor = Color.LightPink;
            }
            graphics.Clear(bkColor);

            Bitmap badge = new Bitmap(Server.MapPath("~/TamkeenAward.png"));
            //            graphics.DrawImage(badge, 25, 25, 75, 75);
            graphics.DrawImage(badge, 0, 0, originalWidth, originalHeight);


            if (!String.IsNullOrEmpty(lblPicPath.Text))
            {

                System.Drawing.Image tamkeenerPhoto = CropToCircle(stringToImage(lblPicPath.Text), bkColor);
                graphics.DrawImage(tamkeenerPhoto, originalWidth / 2 - 100 + 35, originalHeight / 2 - 200 + 35, 200 - 70, 200 - 70);
            }
            else
            {
                if (GenderList.SelectedItem.Value == "Boys")
                {
                    badge = new Bitmap(Server.MapPath("~/boy.png"));
                }
                else
                {
                    badge = new Bitmap(Server.MapPath("~/girl.png"));
                }
                graphics.DrawImage(badge, originalWidth / 2 - 100+40, originalHeight / 2 - 200+40, 200-80, 200-80);

            }


            badge = new Bitmap(Server.MapPath("~/ring.png"));
            graphics.DrawImage(badge, originalWidth / 2 - 100, originalHeight / 2 - 200, 200, 200);

            badge = new Bitmap(Server.MapPath("~/ribbon.png"));
            graphics.DrawImage(badge, originalWidth / 2 - 300, originalHeight / 2 - 50, 600, 150);

            //badge = new Bitmap(Server.MapPath("~/flowerframe.png"));
            //graphics.DrawImage(badge, originalWidth / 3 - 100, originalHeight / 2 - 10, 50, 100);

            //badge = new Bitmap(Server.MapPath("~/agenda footer.png"));
            //graphics.DrawImage(badge, 0, originalHeight - 50, originalWidth, originalHeight);



            Font timesNewRoman = new Font("TimesNewRoman", 38, FontStyle.Bold, GraphicsUnit.Point);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(txtName.Text.ToUpper(), timesNewRoman, new SolidBrush(Color.Black), originalWidth / 2, 70, sf);


            timesNewRoman = new Font("Algerian", 24, FontStyle.Bold, GraphicsUnit.Point);
            sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(txtTitle.Text.ToUpper(), timesNewRoman, new SolidBrush(Color.Purple), originalWidth / 2, originalHeight / 2, sf);


            timesNewRoman = new Font("TimesNewRoman", 16, FontStyle.Bold, GraphicsUnit.Point);
            sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(txtDate.Text, timesNewRoman, new SolidBrush(Color.Black), originalWidth / 2, originalHeight / 2 + 50, sf);

            timesNewRoman = new Font("Algerian", 16, FontStyle.Bold, GraphicsUnit.Point);
            sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString("TAMKEEN", timesNewRoman, new SolidBrush(Color.Black),110,500, sf);

            timesNewRoman = new Font("TimesNewRoman", 16, FontStyle.Bold, GraphicsUnit.Point);
            sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(txtreason.Text, timesNewRoman, new SolidBrush(Color.Black), originalWidth / 2, originalHeight / 2 + 120, sf);
            //timesNewRoman = new Font("TimesNewRoman", 36, FontStyle.Bold, GraphicsUnit.Point);
            //graphics.DrawString(txtDateOfActivitiy.Text, timesNewRoman, new SolidBrush(Color.White), 430, 60);
            //Pen blackPen = new Pen(Color.Black, 4);
            //// graphics.DrawLine(blackPen,50,150,750,150);

            //timesNewRoman = new Font("TimesNewRoman", 18, FontStyle.Bold, GraphicsUnit.Point);
            //graphics.FillEllipse(new SolidBrush(Color.LightGreen), 50, originalHeight - 30, 20, 20);
            //graphics.DrawString("Everyone", timesNewRoman, new SolidBrush(Color.White), 75, originalHeight - 30);
            //graphics.FillEllipse(new SolidBrush(Color.LightBlue), 250, originalHeight - 30, 20, 20);
            //graphics.DrawString("Boys", timesNewRoman, new SolidBrush(Color.White), 275, originalHeight - 30);
            //graphics.FillEllipse(new SolidBrush(Color.Pink), 450, originalHeight - 30, 20, 20);
            //graphics.DrawString("Girls", timesNewRoman, new SolidBrush(Color.White), 475, originalHeight - 30);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Bitmap activity = MakeOneActivity(dt.Rows[i]["Title"].ToString(), dt.Rows[i]["Time"].ToString(), dt.Rows[i]["Location"].ToString(), dt.Rows[i]["Gender"].ToString().ToLower(), dt.Rows[i]["PicPath"].ToString());
            //    graphics.DrawImage(activity, 100 + 0, 140 + i * 150);  // 100 for logo
            //}

            MemoryStream ms = new MemoryStream();
            originalImage.Save(ms, ImageFormat.Png);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgPic.ImageUrl = "data:image/png;base64," + base64Data;

        }



    }
}