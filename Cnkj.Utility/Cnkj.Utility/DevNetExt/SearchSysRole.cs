namespace Cnkj.Utility
{
	/// <summary>
	/// 系统角色查询类
	/// </summary>
    public class SearchSysRole
    {
        string roleName = string.Empty;
        int roleState = 0;//1正常，2禁用 0所有
        private int isInnerRole = 2;//是否内置角色
    	private int owner = 1;
		
		/// <summary>
		/// 角色所属后台系统（多后台系统： 1系统后台 2用户后台）
		/// </summary>
    	public int Owner
    	{
    		get { return owner; }
    		set { owner = value; }
    	}

    	/// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        /// <summary>
        /// 1正常，2禁用 0所有
        /// </summary>
        public int RoleState
        {
            get { return roleState; }
            set { roleState = value; }
        }
        /// <summary>
        /// 是否内置角色0否 1是 2所有【保留】
        /// </summary>
        public int IsInnerRole
        {
            get { return isInnerRole; }
            set { isInnerRole = value; }
        }

		private string _ownerCode = "-1";
		/// <summary>
		/// 角色所有者
		/// </summary>
		public string OwnerCode
		{
			get { return _ownerCode; }
			set { _ownerCode = value; }
		}

    }
}