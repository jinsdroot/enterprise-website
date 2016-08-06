using System;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Text;
using System.Data;
using System.Drawing;

namespace Common
{
	/// <summary>
    /// RandomCode 的摘要说明。
	/// </summary>
	public static class RandomCode
	{		
			
		#region
        
       static Color[] ColorConsts = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.SkyBlue };
       
       static string[] FontConsts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体", "Comic Sans MS" };

		/// <summary>
		/// 从字符串里随机得到，规定个数的字符串.
		/// </summary>
		/// <param name="allChar">以,隔开的字符串</param>
		/// <param name="CodeCount"></param>
		/// <returns></returns>
		public static string GetRandomCode(string allChar,int CodeCount) 
		{
		    string[] allCharArray = allChar.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries); 
			string RandomCode = ""; 
			int temp = -1; 
			Random rand = new Random(); 
			for (int i=0;i<CodeCount;i++) 
			{ 
				if (temp != -1) 
				{ 
					rand = new Random(temp*i*((int) DateTime.Now.Ticks)); 
				} 

				int t = rand.Next(allCharArray.Length-1); 

				while (temp == t) 
				{ 
					t = rand.Next(allCharArray.Length-1); 
				} 
		
				temp = t; 
				RandomCode += allCharArray[t]; 
			} 
			return RandomCode; 
		}

      /// <summary>
      /// 回发验证码图片 [随机字体随机颜色]
      /// </summary>
      /// <param name="context"></param>
      /// <param name="width"></param>
      /// <param name="height"></param>
      /// <param name="chkStr"></param>
        public static void ResopnseColorImage(System.Web.HttpContext context,int width,int height,string chkStr)
        {
            Bitmap newMap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(newMap);
            g.Clear(Color.LightCyan);
           
            Random random = new Random();
            int i;
            for (i = 0; i < 120; i++)//25
            {

                int x = random.Next(newMap.Width);
                int y = random.Next(newMap.Height);
                g.DrawPie(new Pen(Color.LightGray), x, y, 6, 6, 1, 1);
            }

            //输出不同字体和颜色的验证码字符
            for (i = 0; i < chkStr.Length; i++)
            {
                int cindex = random.Next(8);
                int findex = random.Next(6);
                int fs = random.Next(2);
                Font fs_font = new System.Drawing.Font(FontConsts[findex], 12,
                                                       fs == 0 ? System.Drawing.FontStyle.Bold : FontStyle.Italic|FontStyle.Bold);
                
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                string tmpstr = chkStr.Substring(i, 1);
                
                //Brush b = new System.Drawing.SolidBrush(ColorConsts[cindex]);
                System.Drawing.Drawing2D.LinearGradientBrush b = new LinearGradientBrush(new RectangleF((i * (StringPlus.GetStrByteLength(tmpstr) > 1 ? 20 : 13)), 0, width/2, height), ColorConsts[cindex], ColorConsts[ii], 1.5F, true);

                g.DrawString(tmpstr, fs_font, b, (i * (StringPlus.GetStrByteLength(tmpstr) > 1 ? 22 : 13)), 0);// 
            }

            //画一个边框
            g.DrawRectangle(new Pen(Color.LightGray), 0, 0, newMap.Width - 1, newMap.Height - 1);
            //输出到浏览器
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            newMap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);//ms
            //context.Response.ClearContent();
            //context.Response.ContentType = "image/Jpeg";
            //context.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            newMap.Dispose();
           
        }

        /// <summary>
        /// 回发验证码图片 [斜体粗体渐变颜色]
        /// </summary>
        /// <param name="context"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="chkStr"></param>
        public static void ResponseImage(System.Web.HttpContext context, int width, int height, string chkStr)
        {
            Bitmap newMap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(newMap);
            g.Clear(Color.White);
            Random random = new Random();
            int i;
            for (i = 0; i < 25; i++)
            {
                int x1 = random.Next(newMap.Width);
                int x2 = random.Next(newMap.Width);
                int y1 = random.Next(newMap.Height);
                int y2 = random.Next(newMap.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            FontStyle sf = FontStyle.Italic | FontStyle.Bold;

            Font textFont = new Font("GB2312", 12, sf, GraphicsUnit.Point);
            Rectangle r = new Rectangle(0, 0, width, height + 4);

            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(r, Color.Blue, Color.DarkRed, 1.5F, true);
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, newMap.Width - 1, newMap.Height - 1);
            StringFormat strFrm = new StringFormat();
            //strFrm.Alignment = StringAlignment.Center;
            strFrm.LineAlignment = StringAlignment.Center;
            strFrm.FormatFlags = StringFormatFlags.LineLimit;
            strFrm.FormatFlags = StringFormatFlags.NoWrap;
            SizeF sizef = g.MeasureString(chkStr, textFont);
            r.X = (r.Width - Convert.ToInt32(sizef.Width)) / 2;
            r.Height -= 4;

            g.DrawString(chkStr, textFont, brush, r, strFrm);

            newMap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            newMap.Dispose();
        }
		#endregion
	}
}
