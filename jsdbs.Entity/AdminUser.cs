using System;
using System.Collections.Generic;
using System.Text;
using DevNet.Common.Entity;             //请添加引用
using Cnkj.Utility;

namespace jsbestop.Entity
{	
	[Serializable]
	public class AdminUser : EntityBase, IEntity
	{
		public AdminUser()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(Account_FieldName, string.Empty);
            AddProperty(PassWord_FieldName, string.Empty);
            AddProperty(TrueName_FieldName, string.Empty);
            AddProperty(IsLock_FieldName, false);
            AddProperty(LoginCounts_FieldName, 0);
            AddProperty(LastLoginDate_FieldName, DateTime.Now);
            AddProperty(LoginIP_FieldName, string.Empty);
            AddProperty(AddDate_FieldName, DateTime.Now);
			base.TableName = AdminUser_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}


		#region====表名称、字段名称、主键字段、自动增长型字段名称====
		/// <summary>
		///  表 Tb_AdminUser 数据表名称
		/// </summary>
		public const string AdminUser_TableName = "TB_ADMINUSER";

		/// <summary>
		///  表 Tb_AdminUser 主键字段集合
		/// </summary>
		public readonly static string[] PrimaryKeyField = new string[] {"ID"};

		/// <summary>
		///  表 Tb_AdminUser 自动增长型字段名称
		/// </summary>
        public const string AutoIncrement = "ID";

		/// <summary>
		/// ID 字段名称
		/// </summary>
		public const string ID_FieldName = "ID";
		/// <summary>
		/// 登陆账号 字段名称
		/// </summary>
		public const string Account_FieldName = "Account";
		/// <summary>
		/// 密码 字段名称
		/// </summary>
        public const string PassWord_FieldName = "LoginPassWord";
		/// <summary>
		/// 姓名 字段名称
		/// </summary>
		public const string TrueName_FieldName = "TrueName";
		/// <summary>
		/// 是否锁定 字段名称
		/// </summary>
		public const string IsLock_FieldName = "IsLock";
		/// <summary>
		/// 登陆次数 字段名称
		/// </summary>
		public const string LoginCounts_FieldName = "LoginCounts";
		/// <summary>
		/// 最后登陆时间 字段名称
		/// </summary>
		public const string LastLoginDate_FieldName = "LastLoginDate";
		/// <summary>
		/// 登陆IP 字段名称
		/// </summary>
		public const string LoginIP_FieldName = "LoginIP";

		public const string AddDate_FieldName = "AddDate";
		#endregion


		#region====字段属性====

		public DateTime AddDate
		{
			get { return Convert.ToDateTime(GetProperty(AddDate_FieldName)); }
			set { SetProperty(AddDate_FieldName, value); }
		}

			/// <summary>
		/// ID 列
		/// </summary>
		public int ID
		{
			get
			{
				return Convert.ToInt32(GetProperty(ID_FieldName));
			}
			set
			{
				 SetProperty(ID_FieldName, value);
			}
		}
		/// <summary>
		/// 登陆账号 列
		/// </summary>
		public string Account
		{
			get
			{
				return Convert.ToString(GetProperty(Account_FieldName));
			}
			set
			{
				 SetProperty(Account_FieldName, value);
			}
		}
		/// <summary>
		/// 密码 列
		/// </summary>
		public string PassWord
		{
			get
			{
				return Convert.ToString(GetProperty(PassWord_FieldName));
			}
			set
			{
				 SetProperty(PassWord_FieldName, value);
			}
		}
		/// <summary>
		/// 姓名 列
		/// </summary>
		public string TrueName
		{
			get
			{
				return Convert.ToString(GetProperty(TrueName_FieldName));
			}
			set
			{
				 SetProperty(TrueName_FieldName, value);
			}
		}
		/// <summary>
		/// 是否锁定 列
		/// </summary>
		public bool IsLock
		{
			get
			{
				return Convert.ToBoolean(GetProperty(IsLock_FieldName));
			}
			set
			{
				 SetProperty(IsLock_FieldName, value);
			}
		}
		/// <summary>
		/// 登陆次数 列
		/// </summary>
		public int LoginCounts
		{
			get
			{
				return Convert.ToInt32(GetProperty(LoginCounts_FieldName));
			}
			set
			{
				 SetProperty(LoginCounts_FieldName, value);
			}
		}
		/// <summary>
		/// 最后登陆时间 列
		/// </summary>
		public DateTime LastLoginDate
		{
			get
			{
				return Convert.ToDateTime(GetProperty(LastLoginDate_FieldName));
			}
			set
			{
				 SetProperty(LastLoginDate_FieldName, value);
			}
		}
		/// <summary>
		/// 登陆IP 列
		/// </summary>
		public string LoginIP
		{
			get
			{
				return Convert.ToString(GetProperty(LoginIP_FieldName));
			}
			set
			{
				 SetProperty(LoginIP_FieldName, value);
			}
		}
		#endregion


		#region====表关系属性====


		#endregion
	}
}
