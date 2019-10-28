using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using System.Data;
using System.Net;
using System.Text;

namespace TamkeenRegistration.SocialMedia
{
    public partial class Agenda : System.Web.UI.Page
    {
        static Byte[] Photo;
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasSocialMediaAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
                dt = new DataTable();
                dt.Columns.Add("Sequence", Type.GetType("System.Int32"));
                dt.Columns.Add("Title", Type.GetType("System.String"));
                dt.Columns.Add("Location", Type.GetType("System.String"));
                dt.Columns.Add("Time", Type.GetType("System.String"));
                dt.Columns.Add("Pic", Type.GetType("System.String"));
                dt.Columns.Add("PicPath", Type.GetType("System.String"));
                dt.Columns.Add("Gender", Type.GetType("System.String"));
                Session["AgendaDataSet"] = dt;
                gvActivity.DataSource = dt;
                gvActivity.DataBind();
            }
            else
            {
                dt = (DataTable)Session["AgendaDataSet"];
            }
  
        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {

        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int numberOfActivities = dt.Rows.Count;
            int originalWidth = 200+600;
            int originalHeight = 210+150* numberOfActivities;
            //int widthMargin = 50;
            //int heightMargin = 20;
            Bitmap originalImage = new Bitmap(originalWidth, originalHeight);



            Graphics graphics = Graphics.FromImage(originalImage);
            graphics.Clear(Color.MediumAquamarine);

            Bitmap badge = new Bitmap(Server.MapPath("~/agenda master header.png"));
//            graphics.DrawImage(badge, 25, 25, 75, 75);
            graphics.DrawImage(badge, 0, 0, originalWidth, 120);

            badge = new Bitmap(Server.MapPath("~/agenda background.png"));
            graphics.DrawImage(badge, 0, 120, originalWidth, originalHeight-100);

            badge = new Bitmap(Server.MapPath("~/agenda footer.png"));
            graphics.DrawImage(badge, 0, originalHeight - 50, originalWidth, originalHeight);



            Font timesNewRoman = new Font("TimesNewRoman", 38, FontStyle.Bold, GraphicsUnit.Point);
            //graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            //graphics.DrawString("TAMKEEN Youth Program", timesNewRoman, new SolidBrush(Color.Black), 130, 30);
            timesNewRoman = new Font("TimesNewRoman", 36, FontStyle.Bold, GraphicsUnit.Point);
            graphics.DrawString(txtDateOfActivitiy.Text, timesNewRoman, new SolidBrush(Color.White), 430, 60);
            Pen blackPen = new Pen(Color.Black, 4);
           // graphics.DrawLine(blackPen,50,150,750,150);

            timesNewRoman = new Font("TimesNewRoman", 18, FontStyle.Bold, GraphicsUnit.Point);
            graphics.FillEllipse(new SolidBrush(Color.LightGreen), 50, originalHeight - 30, 20, 20);
            graphics.DrawString("Everyone", timesNewRoman, new SolidBrush(Color.White), 75, originalHeight - 30);
            graphics.FillEllipse(new SolidBrush(Color.LightBlue), 250, originalHeight - 30, 20, 20);
            graphics.DrawString("Boys", timesNewRoman, new SolidBrush(Color.White), 275, originalHeight - 30);
            graphics.FillEllipse(new SolidBrush(Color.Pink), 450, originalHeight - 30, 20, 20);
            graphics.DrawString("Girls", timesNewRoman, new SolidBrush(Color.White), 475, originalHeight - 30);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Bitmap activity = MakeOneActivity(dt.Rows[i]["Title"].ToString(), dt.Rows[i]["Time"].ToString(), dt.Rows[i]["Location"].ToString(), dt.Rows[i]["Gender"].ToString().ToLower(), dt.Rows[i]["PicPath"].ToString());
                graphics.DrawImage(activity, 100+ 0, 140+i * 150);  // 100 for logo
            }

            MemoryStream ms = new MemoryStream();
            originalImage.Save(ms, ImageFormat.Png);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgPic.ImageUrl = "data:image/png;base64," + base64Data;

        }

        private Bitmap MakeOneActivity(string activity, string time, string Location, string Gender, string Pic)
        {
            int originalWidth = 600;
            int originalHeight = 150;
            int widthMargin = 50;
            int heightMargin = 20;
            Bitmap originalImage = new Bitmap(originalWidth, originalHeight);

            Graphics graphics = Graphics.FromImage(originalImage);
            //if (Gender == "both")
            //{
            //    graphics.Clear(Color.Yellow);
            //}
            //else if (Gender == "boys")
            //{
            //    graphics.Clear(Color.Blue);
            //}
            //else
            //{
            //    graphics.Clear(Color.Pink);
            //}


            //            Pen snowPen = new Pen(Color.Green, 2);
            SolidBrush lightGray = new SolidBrush(Color.LightGray);
            Point p1 = new Point(widthMargin, heightMargin);
            Point p2 = new Point(originalWidth - widthMargin, heightMargin);
            Point p3 = new Point(originalWidth - widthMargin, heightMargin + (originalHeight-2* heightMargin) / 2);
            Point p4 = new Point(widthMargin, heightMargin + (originalHeight - 2 * heightMargin) / 2);
            Point[] pointArrayLightGreyPolygon = { p1, p2, p3, p4 };
            graphics.FillPolygon(lightGray, pointArrayLightGreyPolygon);

            Font timesNewRoman = new Font("TimesNewRoman", 36, FontStyle.Regular, GraphicsUnit.Point);
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            graphics.DrawString(activity, timesNewRoman, new SolidBrush(Color.Black), widthMargin + 60, heightMargin);

            SolidBrush darkGray = new SolidBrush(Color.DarkGray);
            p1 = new Point(widthMargin, heightMargin + (originalHeight - 2 * heightMargin) / 2);
            p2 = new Point(originalWidth - widthMargin, heightMargin + (originalHeight - 2 * heightMargin) / 2);
            p3 = new Point(originalWidth - widthMargin, originalHeight - heightMargin);
            p4 = new Point(widthMargin, originalHeight - heightMargin);
            Point[] pointArrayDarkGreyPolygon = { p1, p2, p3, p4 };
            graphics.FillPolygon(darkGray, pointArrayDarkGreyPolygon);
            timesNewRoman = new Font("TimesNewRoman", 18, FontStyle.Italic, GraphicsUnit.Point);
            graphics.DrawString(Location, timesNewRoman, new SolidBrush(Color.White), widthMargin + 80, heightMargin + 70);
            timesNewRoman = new Font("TimesNewRoman", 18, FontStyle.Bold, GraphicsUnit.Point);
            graphics.DrawString(time, timesNewRoman, new SolidBrush(Color.Yellow), widthMargin + 330, heightMargin + 70);

            //System.Drawing.Image icon = new Bitmap(Server.MapPath("~/logo.png"));
            System.Drawing.Image icon = stringToImage(Pic);

            Bitmap badge = new Bitmap(Server.MapPath("~/LocationThumbnail.png"));
            graphics.DrawImage(badge, widthMargin + 60, heightMargin + 70, 30, 30);

            badge = new Bitmap(Server.MapPath("~/ClockThumbnail.png"));
            graphics.DrawImage(badge, widthMargin + 300, heightMargin + 70, 30, 30);

            //MemoryStream ms = new MemoryStream(Pic);
            //System.Drawing.Image icon = System.Drawing.Image.FromStream((new StreamReader(Pic)));
            //Bitmap icon = new Bitmap(Pic);
            //byte[] imageData = DownloadData(Url); //DownloadData function from here
            //MemoryStream stream = new MemoryStream(imageData);
            //Image img = Image.FromStream(stream);
            //stream.Close();


            //System.Drawing.Image icon = stringToImage(Pic);



            Pen blackPen = new Pen(Color.Black, 2);
            Color genderColor;
            if (Gender == "both")
            {
                genderColor = Color.LightGreen;
            }
            else if (Gender == "boys")
            {
                genderColor = Color.LightBlue;
            }
            else
            {
                genderColor = Color.Pink;
            }

            graphics.FillEllipse(new SolidBrush(genderColor), new Rectangle(0, heightMargin, originalHeight - 2 * heightMargin, originalHeight - 2 * heightMargin));
            graphics.DrawEllipse(blackPen, new Rectangle(0, heightMargin, originalHeight - 2 * heightMargin, originalHeight - 2 * heightMargin));
            graphics.DrawImage(icon, new Rectangle(25, 35, 65, 80));

            return originalImage;

            //MemoryStream ms = new MemoryStream();
            //originalImage.Save(ms, ImageFormat.Png);
            //var base64Data = Convert.ToBase64String(ms.ToArray());
            //imgPic.ImageUrl = "data:image/png;base64," + base64Data;
            //originalImage.Dispose();

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

        protected void btnActivity_Save_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();

            if (String.IsNullOrEmpty(txtNo.Text))
            {
                newRow["Sequence"] = dt.Rows.Count + 1;
                newRow["Title"] = txtTitle.Text;
                newRow["Location"] = txtLocation.Text;
                newRow["Time"] = txtTime.Text;
                newRow["Gender"] = GenderList.SelectedItem.Value;
                newRow["Pic"] = imgPhoto.ImageUrl;
                newRow["PicPath"] = lblPicPath.Text;
                dt.Rows.Add(newRow);
            }
            else
            {
                int index = Convert.ToInt32(txtNo.Text) - 1;
                dt.Rows[index]["Sequence"] = Convert.ToInt32(txtNo.Text);
                dt.Rows[index]["Title"] = txtTitle.Text;
                dt.Rows[index]["Location"] = txtLocation.Text;
                dt.Rows[index]["Time"] = txtTime.Text;
                dt.Rows[index]["Gender"] = GenderList.SelectedItem.Value;
                dt.Rows[index]["Pic"] = imgPhoto.ImageUrl;
                dt.Rows[index]["PicPath"] = lblPicPath.Text;

            }

            Session["AgendaDataSet"] = dt;


            gvActivity.DataSource = dt;
            gvActivity.DataBind();

            ClearBoxes();

        }

        protected void Selection_Change(Object sender, EventArgs e)
        {

            // Set the background color for days in the Calendar control
            // based on the value selected by the user from the 
            // DropDownList control.
            //Calendar1.DayStyle.BackColor =
                //System.Drawing.Color.FromName(ColorList.SelectedItem.Value);

        }
        protected void btnActivity_Clear_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void ClearBoxes()
        {
            txtNo.Text = "";
            txtTitle.Text = "";
            txtLocation.Text = "";
            txtTime.Text = "";
            imgPhoto.ImageUrl = "";
        }

        protected void DeleteActivity_OnClick(object sender, EventArgs e)
        {
            int Sequence = Convert.ToInt32((sender as LinkButton).CommandArgument);
            for (int i = Sequence; i < dt.Rows.Count;i++)
            {
                dt.Rows[i]["Sequence"] = i;
            }
            dt.Rows.RemoveAt(Sequence - 1);

            gvActivity.DataSource = dt;
            gvActivity.DataBind();
        }

        protected void EditActivity_OnClick(object sender, EventArgs e)
        {
            int Sequence = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int index = Sequence - 1;
            txtNo.Text = dt.Rows[index]["Sequence"].ToString();
            txtTitle.Text = dt.Rows[index]["Title"].ToString();
            txtLocation.Text = dt.Rows[index]["Location"].ToString();
            txtTime.Text = dt.Rows[index]["Time"].ToString();
            GenderList.SelectedValue = dt.Rows[index]["Gender"].ToString();
            imgPhoto.ImageUrl = dt.Rows[index]["Pic"].ToString();
            lblPicPath.Text = dt.Rows[index]["PicPath"].ToString();
        }

    }
}