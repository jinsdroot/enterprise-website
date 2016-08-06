using System;
using System.Drawing;
using Common;
namespace jsbestop.Web
{
    public partial class ValidateCode : System.Web.UI.Page
    {
         private int width = 52;
    	private int height = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
        	width = URLHelper.GetRequestQuery<int>("w", width, Convert.ToInt32);
        	height = URLHelper.GetRequestQuery("h", height, Convert.ToInt32);
            //string checkCode = CreateRandomCode(4);
        	string checkCode = RandomCode.GetRandomCode(StringPlus.NumberConst, 4);
			Session["CheckCode"] = checkCode; //checkCode;
			RandomCode.ResopnseColorImage(Context, width, height, checkCode);
        	//CreateImage(checkCode);
        }

//		private string CreateRandomCode(int codeCount)
//		{
//			string allChar = "0,1,2,3,4,5,6,7,8,9";
//			string[] allCharArray = allChar.Split(',');
//			string randomCode = "";
//			int temp = -1;
//
//			Random rand = new Random();
//			for (int i = 0; i < codeCount; i++)
//			{
//				if (temp != -1)
//				{
//					rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
//				}
//				int t = rand.Next(9);
//				if (temp == t)
//				{
//					return CreateRandomCode(codeCount);
//				}
//				temp = t;
//				randomCode += allCharArray[t];
//			}
//			return randomCode;
//		}
//
//		private void CreateImage(string checkCode)
//		{
//
//			int iwidth = (int)(checkCode.Length * 20);
//			System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 40);
//			Graphics g = Graphics.FromImage(image);
//			g.Clear(Color.LightCyan);
			//定义颜色
//			Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.SkyBlue };
			//定义字体 
//			string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体", "Comic Sans MS" };
//			Random rand = new Random();
			//随机输出噪点
//			for (int i = 0; i < 150; i++)
//			{
//				int x = rand.Next(image.Width);
//				int y = rand.Next(image.Height);
//				g.DrawPie(new Pen(Color.LightGray, 0), x, y, 6, 6, 1, 1);
//			}
//
			//输出不同字体和颜色的验证码字符
//			for (int i = 0; i < checkCode.Length; i++)
//			{
//				int cindex = rand.Next(7);
//				int findex = rand.Next(6);
//				Font fs_font = new System.Drawing.Font(font[i], 22, System.Drawing.FontStyle.Bold);
//				Brush b = new System.Drawing.SolidBrush(c[cindex]);
//				int ii = 4;
//				if ((i + 1) % 2 == 0)
//				{
//					ii = 2;
//				}
//				g.DrawString(checkCode.Substring(i, 1), fs_font, b, (i == 0 ? 2 : 5) + (i * 17), ii);
//			}
//
			//画一个边框
//			g.DrawRectangle(new Pen(Color.Red, 0), 100, 0, image.Width - 1, image.Height - 1);
			//输出到浏览器
//			System.IO.MemoryStream ms = new System.IO.MemoryStream();
//			image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
//			Response.ClearContent();
//			Response.ContentType = "image/Jpeg";
//			Response.BinaryWrite(ms.ToArray());
//			g.Dispose();
//			image.Dispose();
//
			//int iwidth = (int)(checkCode.Length * 11.5);
			//Bitmap image = new Bitmap(iwidth, 18);
			//Graphics g = Graphics.FromImage(image);
			//Font f = new Font("Lucida Handwriting", 10, FontStyle.Bold);
			//Brush b = new SolidBrush(Color.Red);
			//g.Clear(Color.White);
			//g.DrawString(checkCode, f, b, 1, 0);
			//g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
			//Random rand = new Random();
//
			//for (int i = 0; i < 10; i++)
			//{
			//    int red, green, blue;
			//    red = rand.Next(0, 255);
			//    green = rand.Next(0, 255);
			//    blue = rand.Next(0, 255);
			//    Pen blackPen = new Pen(Color.FromArgb(red, green, blue), 0);
			//    int y = rand.Next(image.Height);
			//    int x = rand.Next(image.Width);
			//    g.DrawEllipse(blackPen, x, y, 1, 1);
			//}
//
			//MemoryStream ms = new MemoryStream();
			//image.Save(ms, ImageFormat.Jpeg);
			//Response.ClearContent();
			//Response.ContentType = "image/Gif";
			//Response.BinaryWrite(ms.ToArray());
			//g.Dispose();
			//image.Dispose();
//		}
    }
    
}