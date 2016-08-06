using System;
using System.Collections.Generic;
 
using System.Text;

namespace Common
{
    /// <summary>
    /// 日期时间帮助类
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// 返回当前系统日期的标准格式 yyyy-MM-dd
        /// </summary>
        public static string GetShortDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

		/// <summary>
		/// 返回当前系统日期的标准格式 yyyy-MM-dd
		/// </summary>
		public static string GetShortDate(object obj)
		{
			return StringPlus.ConverTValue<DateTime>(obj, DateTime.Now, Convert.ToDateTime).ToString("yyyy-MM-dd");
		}

        /// <summary>
        /// 返回当前系统时间标准时间格式字符串HH:mm:ss
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 返回当前系统时间标准长时间格式字符串yyyy-MM-dd HH:mm:ss
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回相对于当前时间的相对天数  yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="relativeday">增加天数</param>
        /// <returns></returns>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式  yyyy-MM-dd HH:mm:ss:fffffff
        /// </summary>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 当前时间增加分钟
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string AddMinutesTime(int minutes)
        {
            string newtime = (DateTime.Now).AddMinutes(minutes).ToString();
            return newtime;

        }


        /// <summary>返回本年有多少天</summary>
        /// <param name="iYear">年份</param>
        /// <returns>本年的天数</returns>
        public static int GetDaysByYear(int iYear)
        {
            int cnt = 0;
            if (IsRuYear(iYear))
            {
                //闰年多 1 天 即：2 月为 29 天
                cnt = 366;

            }
            else
            {
                //--非闰年少1天 即：2 月为 28 天
                cnt = 365;
            }
            return cnt;
        }


        /// <summary>本年有多少天</summary>
        /// <param name="dt">日期</param>
        /// <returns>本天在当年的天数</returns>
        public static int GetDaysByYear(DateTime dt)
        {
            int n;

            //取得传入参数的年份部分，用来判断是否是闰年

            n = dt.Year;
            if (IsRuYear(n))
            {
                //闰年多 1 天 即：2 月为 29 天
                return 366;
            }
            else
            {
                //--非闰年少1天 即：2 月为 28 天
                return 365;
            }

        }


        /// <summary>本月有多少天</summary>
        /// <param name="iYear">年</param>
        /// <param name="Month">月</param>
        /// <returns>天数</returns>
        public static int GetDaysByMonth(int iYear, int Month)
        {
            int days = 0;
            switch (Month)
            {
                case 1:
                    days = 31;
                    break;
                case 2:
                    if (IsRuYear(iYear))
                    {
                        //闰年多 1 天 即：2 月为 29 天
                        days = 29;
                    }
                    else
                    {
                        //--非闰年少1天 即：2 月为 28 天
                        days = 28;
                    }

                    break;
                case 3:
                    days = 31;
                    break;
                case 4:
                    days = 30;
                    break;
                case 5:
                    days = 31;
                    break;
                case 6:
                    days = 30;
                    break;
                case 7:
                    days = 31;
                    break;
                case 8:
                    days = 31;
                    break;
                case 9:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }

            return days;


        }


        /// <summary>本月有多少天</summary>
        /// <param name="dt">日期</param>
        /// <returns>天数</returns>
        public static int GetDaysByMonth(DateTime dt)
        {
            //--------------------------------//
            //--从dt中取得当前的年，月信息  --//
            //--------------------------------//
            int year, month, days = 0;
            year = dt.Year;
            month = dt.Month;

            //--利用年月信息，得到当前月的天数信息。
            switch (month)
            {
                case 1:
                    days = 31;
                    break;
                case 2:
                    if (IsRuYear(year))
                    {
                        //闰年多 1 天 即：2 月为 29 天
                        days = 29;
                    }
                    else
                    {
                        //--非闰年少1天 即：2 月为 28 天
                        days = 28;
                    }

                    break;
                case 3:
                    days = 31;
                    break;
                case 4:
                    days = 30;
                    break;
                case 5:
                    days = 31;
                    break;
                case 6:
                    days = 30;
                    break;
                case 7:
                    days = 31;
                    break;
                case 8:
                    days = 31;
                    break;
                case 9:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }

            return days;

        }


        /// <summary>返回当前日期的星期名称</summary>
        /// <param name="dt">日期</param>
        /// <returns>星期名称</returns>
        public static string GetWeekNameByDay(DateTime dt)
        {
            string sdt, week = "";

            sdt = dt.DayOfWeek.ToString();
            switch (sdt)
            {
                case "Mondy":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;

            }
            return week;
        }


        /// <summary>返回当前日期的星期编号</summary>
        /// <param name="dt">日期</param>
        /// <returns>星期数字编号</returns>
        public static string GetWeekNumberOfDay(DateTime dt)
        {
            string sdt, week = "";

           sdt = dt.DayOfWeek.ToString();
            switch (sdt)
            {
                case "Monday":
                    week = "1";
                    break;
                case "Tuesday":
                    week = "2";
                    break;
                case "Wednesday":
                    week = "3";
                    break;
                case "Thursday":
                    week = "4";
                    break;
                case "Friday":
                    week = "5";
                    break;
                case "Saturday":
                    week = "6";
                    break;
                case "Sunday":
                    week = "7";
                    break;

            }

            return week;


        }


       /// <summary>
        /// 返回两个日期之间相差的天数
       /// </summary>
       /// <param name="dtfrm"></param>
       /// <param name="dtto"></param>
       /// <returns></returns>
        public static int DiffDays(DateTime dtfrm, DateTime dtto)
        {
            TimeSpan time = dtto.Subtract(dtfrm);
            return time.Days;
        }


        /// <summary>判断当前日期所属的年份是否是闰年</summary>
        /// <param name="dt">日期</param>
        /// <returns>是闰年：True ，不是闰年：False</returns>
        public static bool IsRuYear(DateTime dt)
        {
            //形式参数为日期类型 
            //例如：2003-12-12
            int n;
            n = dt.Year;

            if ((n % 400 == 0) || (n % 4 == 0 && n % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>判断当前年份是否是闰年</summary>
        /// <param name="iYear">年份</param>
        /// <returns>是闰年：True ，不是闰年：False</returns>
        public static bool IsRuYear(int iYear)
        {
            //形式参数为年份
            //例如：2003
            int n;
            n = iYear;

            if ((n % 400 == 0) || (n % 4 == 0 && n % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 将输入的字符串转化为日期。如果字符串的格式非法，则返回当前日期。
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>日期对象</returns>
        public static DateTime ConvertStringToDate(string strInput)
        {
            DateTime oDateTime;

            try
            {
                oDateTime = DateTime.Parse(strInput);
            }
            catch (Exception)
            {
                oDateTime = DateTime.Today;
            }

            return oDateTime;
        }


        /// <summary>
        /// 将日期对象转化为格式字符串
        /// </summary>
        /// <param name="dateTime">日期对象</param>
        /// <param name="strFormat">
        /// 格式：
        ///        "SHORTDATE"===短日期
        ///        "LONGDATE"==长日期
        ///        其它====自定义格式
        /// </param>
        /// <returns>日期字符串</returns>
        public static string ConvertDateToString(DateTime dateTime, string strFormat)
        {
            string strDate = "";

            try
            {
                switch (strFormat.ToUpper())
                {
                    case "SHORTDATE":
                        strDate = dateTime.ToShortDateString();
                        break;
                    case "LONGDATE":
                        strDate = dateTime.ToLongDateString();
                        break;
                    default:
                        strDate = dateTime.ToString(strFormat);
                        break;
                }
            }
            catch (Exception)
            {
                strDate = dateTime.ToShortDateString();
            }

            return strDate;
        }

        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回时间差
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        #endregion
    }
}
