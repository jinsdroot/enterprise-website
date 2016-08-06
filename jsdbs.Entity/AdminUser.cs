using System;
using System.Collections.Generic;
using System.Text;
using DevNet.Common.Entity;             //���������
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


		#region====�����ơ��ֶ����ơ������ֶΡ��Զ��������ֶ�����====
		/// <summary>
		///  �� Tb_AdminUser ���ݱ�����
		/// </summary>
		public const string AdminUser_TableName = "TB_ADMINUSER";

		/// <summary>
		///  �� Tb_AdminUser �����ֶμ���
		/// </summary>
		public readonly static string[] PrimaryKeyField = new string[] {"ID"};

		/// <summary>
		///  �� Tb_AdminUser �Զ��������ֶ�����
		/// </summary>
        public const string AutoIncrement = "ID";

		/// <summary>
		/// ID �ֶ�����
		/// </summary>
		public const string ID_FieldName = "ID";
		/// <summary>
		/// ��½�˺� �ֶ�����
		/// </summary>
		public const string Account_FieldName = "Account";
		/// <summary>
		/// ���� �ֶ�����
		/// </summary>
        public const string PassWord_FieldName = "LoginPassWord";
		/// <summary>
		/// ���� �ֶ�����
		/// </summary>
		public const string TrueName_FieldName = "TrueName";
		/// <summary>
		/// �Ƿ����� �ֶ�����
		/// </summary>
		public const string IsLock_FieldName = "IsLock";
		/// <summary>
		/// ��½���� �ֶ�����
		/// </summary>
		public const string LoginCounts_FieldName = "LoginCounts";
		/// <summary>
		/// ����½ʱ�� �ֶ�����
		/// </summary>
		public const string LastLoginDate_FieldName = "LastLoginDate";
		/// <summary>
		/// ��½IP �ֶ�����
		/// </summary>
		public const string LoginIP_FieldName = "LoginIP";

		public const string AddDate_FieldName = "AddDate";
		#endregion


		#region====�ֶ�����====

		public DateTime AddDate
		{
			get { return Convert.ToDateTime(GetProperty(AddDate_FieldName)); }
			set { SetProperty(AddDate_FieldName, value); }
		}

			/// <summary>
		/// ID ��
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
		/// ��½�˺� ��
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
		/// ���� ��
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
		/// ���� ��
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
		/// �Ƿ����� ��
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
		/// ��½���� ��
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
		/// ����½ʱ�� ��
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
		/// ��½IP ��
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


		#region====���ϵ����====


		#endregion
	}
}
