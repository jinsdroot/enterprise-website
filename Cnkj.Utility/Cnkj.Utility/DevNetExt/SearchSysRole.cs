namespace Cnkj.Utility
{
	/// <summary>
	/// ϵͳ��ɫ��ѯ��
	/// </summary>
    public class SearchSysRole
    {
        string roleName = string.Empty;
        int roleState = 0;//1������2���� 0����
        private int isInnerRole = 2;//�Ƿ����ý�ɫ
    	private int owner = 1;
		
		/// <summary>
		/// ��ɫ������̨ϵͳ�����̨ϵͳ�� 1ϵͳ��̨ 2�û���̨��
		/// </summary>
    	public int Owner
    	{
    		get { return owner; }
    		set { owner = value; }
    	}

    	/// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        /// <summary>
        /// 1������2���� 0����
        /// </summary>
        public int RoleState
        {
            get { return roleState; }
            set { roleState = value; }
        }
        /// <summary>
        /// �Ƿ����ý�ɫ0�� 1�� 2���С�������
        /// </summary>
        public int IsInnerRole
        {
            get { return isInnerRole; }
            set { isInnerRole = value; }
        }

		private string _ownerCode = "-1";
		/// <summary>
		/// ��ɫ������
		/// </summary>
		public string OwnerCode
		{
			get { return _ownerCode; }
			set { _ownerCode = value; }
		}

    }
}