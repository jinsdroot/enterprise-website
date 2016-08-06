using System;

namespace Cnkj.Utility
{
    /// <summary>
    /// ��ѯ�������ֻ࣬�����˿�ʼʱ��ͽ���ʱ��
    /// </summary>
    public class SearchBaseInfo
    {
        private DateTime m_dtEnd = new DateTime(9999, 12, 31);
        private DateTime m_dtStart = new DateTime(1900, 1, 1);

        /// <summary>
        /// ���û��ȡ��ʼ����
        /// </summary>
        public DateTime StartDate
        {
            get { return m_dtStart; }
            set
            {
                if (!Validate(value, m_dtEnd))
                {
                    throw new Exception("��ʼ���ڲ������ڽ�������");
                }
                m_dtStart = value;
            }
        }

        /// <summary>
        /// ���û��ȡ��������
        /// </summary>
        public DateTime EndDate
        {
            get { return m_dtEnd; }
            set
            {
                if (!Validate(m_dtStart, value))
                {
                    throw new Exception("�������ڲ������ڿ�ʼ����");
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
		/// �����ַ��� ID ASC
		/// </summary>
    	public string SortStr
    	{
    		get { return _sortStr; }
    		set { _sortStr = value; }
    	}

		private string _stationCode = "-1";
		/// <summary>
		/// ������վ
		/// </summary>
		public string StationCode
		{
			get { return _stationCode; }
			set { _stationCode = value; }
		}
    }
}