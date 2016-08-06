using System;

namespace Cnkj.Utility
{
    /// <summary>
    /// 查询条件基类，只包含了开始时间和结束时间
    /// </summary>
    public class SearchBaseInfo
    {
        private DateTime m_dtEnd = new DateTime(9999, 12, 31);
        private DateTime m_dtStart = new DateTime(1900, 1, 1);

        /// <summary>
        /// 设置或获取开始日期
        /// </summary>
        public DateTime StartDate
        {
            get { return m_dtStart; }
            set
            {
                if (!Validate(value, m_dtEnd))
                {
                    throw new Exception("开始日期不能晚于结束日期");
                }
                m_dtStart = value;
            }
        }

        /// <summary>
        /// 设置或获取结束日期
        /// </summary>
        public DateTime EndDate
        {
            get { return m_dtEnd; }
            set
            {
                if (!Validate(m_dtStart, value))
                {
                    throw new Exception("结束日期不能早于开始日期");
                }
                m_dtEnd = value;
            }
        }

        protected bool Validate(DateTime start, DateTime end)
        {
            return end >= start;
        }

		string _sortStr = string.Empty;

		/// <summary>
		/// 排序字符串 ID ASC
		/// </summary>
    	public string SortStr
    	{
    		get { return _sortStr; }
    		set { _sortStr = value; }
    	}

		private string _stationCode = "-1";
		/// <summary>
		/// 所属分站
		/// </summary>
		public string StationCode
		{
			get { return _stationCode; }
			set { _stationCode = value; }
		}
    }
}