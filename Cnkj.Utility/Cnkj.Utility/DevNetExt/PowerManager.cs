using System;
using System.Collections.Generic;
using DevNet.Common;
using DevNet.Common.Logger;
using DevNet.Permission.Entity;

namespace Cnkj.Utility
{
	/// <summary>
	/// Ȩ�޹���������DevNet��Ȩ�޹�����
	/// </summary>
	public class PowerManager : DevNet.Permission.PermissionManager
	{
		/// <summary>
		/// ��ȡ��ɫ�б�
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="pagination"></param>
		/// <param name="sortFieldName"></param>
		/// <param name="sortEnum"></param>
		/// <returns></returns>
		public virtual List<SysRole> GetRoleList(SearchSysRole condition, Pagination pagination, string sortFieldName, ScriptQuery.SortEnum sortEnum)
		{
			try
			{
				Script.TableName = SysRole.SysRole_TableName;
				Script.Select().ALL().From().Where();
				if (!string.IsNullOrEmpty(condition.RoleName))
					Script.Like(SysRole.RoleName_FieldName, condition.RoleName);
				if (condition.RoleState > 0)
					Script.Where(SysRole.RoleState_FieldName, condition.RoleState);
				if (condition.IsInnerRole != 2)
					Script.Where(SysRole.IsInnerRole_FieldName, condition.IsInnerRole);

				Script.Where(SysRole.Owner_FieldName, condition.Owner);
				if (!string.IsNullOrEmpty(condition.OwnerCode))
				{
					Script.Where(SysRole.OwnerCode_FieldName, condition.OwnerCode);
				}


				Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);

				Script.PageIndex = pagination.PageIndex;
				Script.PageSize = pagination.PageSize;
				Script.PrimaryKey = SysRole.RoleID_FieldName;//sql2000��ҳ��ѯʱ��ָ�������ֶ�����
				List<SysRole> lists = Script.GetList<SysRole>();
				pagination.RecordCount = Script.RecordCount;
				return lists;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				return new List<SysRole>();
			}
		}

		/// <summary>
		/// ��ȡ��ɫ�б�
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="pagination"></param>
		/// <returns></returns>
		public virtual List<SysRole> GetRoleList(SearchSysRole condition, DevNet.Common.Pagination pagination)
		{
			return GetRoleList(condition, pagination, SysRole.RoleID_FieldName, ScriptQuery.SortEnum.ASC);
		}

		/// <summary>
		/// ��ȡ����Ա��ɫ��ӵ�е�Ȩ�޲˵��б�
		/// </summary>
		/// <param name="parentID">��Ȩ��ID</param>
		/// <param name="roleID"></param>
		/// <param name="isShow">�Ƿ���ʾ��Ȩ��2ȫ��</param>
		/// <param name="owner">Ȩ��������̨ϵͳ�����̨ϵͳ��1ϵͳ��̨  2�û���̨�ȣ�</param>
		/// <returns></returns>
		public virtual List<Permission> GetPermissionByRoleID(int parentID, int roleID, int isShow, int owner)
		{
			try
			{
				Script.TableName = Permission.Permission_TableName;
				Script.Select().ALL().From().Where().AddAnd().Select(Permission.PermissionID_FieldName).AddIn().
					AddLeftParentheses().Select().Select(SysRolePermission.PermissionID_FieldName).From(
						SysRolePermission.SysRolePermission_TableName).Where().Where(SysRolePermission.RoleID_FieldName,
																				 roleID).
					AddRightParentheses().Where(Permission.PerParentID_FieldName, parentID);
				if (isShow != 2)
					Script.Where(Permission.IsShow_FieldName, isShow);
				Script.Where(Permission.Owner_FieldName, owner);

				Script.AddOrderBy().OrderBy(Permission.DisplayIndex_FieldName, ScriptQuery.SortEnum.ASC);

				return Script.GetList<Permission>();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				return new List<Permission>();
			}
		}

		/// <summary>
		/// ɾ������Ա��ɫ,����ɾ����ɫȨ�ޱ�����ӵ�е�Ȩ�ޡ������жϹ���Ա���Ƿ���ʹ�øý�ɫ��
		/// </summary>
		/// <param name="roleID">��ɫ���</param>
		/// <param name="ownerCode">��ɫ�����߱��</param>
		/// <param name="owner">��ɫ������̨ϵͳ�����̨ϵͳ��1ϵͳ��̨  2�û���̨�ȣ�</param>
		public override void DeleteSysRole(int roleID, string ownerCode, int owner)
		{
			base.DBCon.BeginTrans();
            try
            {
                ////�������жϹ���Ա���Ƿ���ʹ�øý�ɫ�����
                //if (Convert.ToInt32(Script.Select().Count("0").From("admin").Where("roleid", roleID).GetScalar()) > 0)
                //    throw new DevNetException("�ù���Ա��ɫ����ʹ���У��޷�ɾ����");

                Script.Delete().From(SysRolePermission.SysRolePermission_TableName).Where(
                    new string[]
                        {
                            SysRolePermission.RoleID_FieldName, SysRolePermission.OwnerCode_FieldName,
                            SysRolePermission.Owner_FieldName
                        }, new object[] {roleID, ownerCode, owner})
                    .ExecuteNonQuery();
                base.DeleteSysRole(roleID, ownerCode, owner);

                DBCon.CommitTrans();
            }
            catch (DevNetException ex)
            {
                DBCon.RollBackTrans();
                throw ex;
            }
            catch (Exception ex)
            {
                DBCon.RollBackTrans();
                Log.Error(ex.Message, ex);
                throw new DevNetException((int)DevNetExceptionEnum.CatchException, ex.Message, ex.Source);
            }
		}

		/// <summary>
		/// �жϽ�ɫ�Ƿ��ڹ������ݱ���ʹ��
		/// </summary>
		/// <param name="managerTableName">����ϵͳ������</param>
		/// <param name="roleFieldName">����ϵͳ���н�ɫ�ֶ�����</param>
		/// <param name="roleID">��ɫ���</param>
		/// <returns></returns>
		public virtual bool IsUsedSysRole(string managerTableName, string roleFieldName, int roleID)
		{
			if (Convert.ToInt32(Script.Select().Count("0").From(managerTableName).Where(roleFieldName, roleID).GetScalar()) > 0)
				//throw new DevNetException("�ù���Ա��ɫ����ʹ���У��޷�ɾ����");
				return true;
			return false;
		}

		/// <summary>
		/// ����Ȩ��ID��ȡ���ڵ���ָ�����ڵ�Ȩ�޵���
		/// </summary>
		/// <param name="perID">Ȩ��ID</param>
		/// <param name="rootID">ָ�����ڵ�ID</param>
		/// <param name="owner">Ȩ��������̨ϵͳ�����̨ϵͳ��1ϵͳ��̨  2�û���̨�ȣ�</param>
		/// <param name="isShow">�Ƿ���ʾ 2 ȫ����ʾ</param>
		/// <returns></returns>
		public Permission GetRootPerIDByPerID(int perID, int rootID, int owner, int isShow)
		{
			try
			{
				Script.TableName = Permission.Permission_TableName;
				Script.Select().ALL().From().Where(new string[] { Permission.PermissionID_FieldName, Permission.Owner_FieldName },
												   new object[] { perID, owner });
				if (isShow != 2)
					Script.Where(Permission.IsShow_FieldName, isShow);

				List<Permission> lists = Script.GetList<Permission>();

				Permission per = lists.Count > 0 ? lists[0] : null;
				if (per == null)
					return null;

				if (per.PerParentID == rootID)
					return per;

				return GetRootPerIDByPerID(per.PerParentID, rootID, owner, isShow);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				return null;
			}
		}

		/// <summary>
		/// ����Ȩ�޲˵�ID��ȡȨ��
		/// </summary>
		/// <param name="perID"></param>
		/// <returns></returns>
		public Permission GetSinglePermissinByID(int perID)
		{
			try
			{
				return base.GetSinglePermission(perID);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				return null;
			}
		}

		/// <summary>
		/// ��ȡϵͳ��ɫʵ��
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public SysRole GetSingleSysRole(int roleID)
		{
			try
			{
				Script.TableName = SysRole.SysRole_TableName;

				return Script.GetSingle<SysRole>(SysRole.RoleID_FieldName, roleID, ScriptQuery.CompareEnum.Equal);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				return null;
			}
		}

		/// <summary>
		/// ɾ��ϵͳ��ɫ,����ɾ����ɫȨ�ޱ�����ӵ�е�Ȩ�ޡ������жϹ���Ա���Ƿ���ʹ�øý�ɫ��
		/// </summary>
		/// <param name="roleID"></param>
		public void DeleteSysRole(int roleID)
		{
			DBCon.BeginTrans();
			try
			{
				Script.TableName = SysRole.SysRole_TableName;
				Script.Delete().From(SysRolePermission.SysRolePermission_TableName).Where(
					SysRolePermission.RoleID_FieldName, roleID).ExecuteNonQuery();

				Script.Delete().From().Where(SysRole.RoleID_FieldName, roleID).ExecuteNonQuery();
				DBCon.CommitTrans();
			}
			catch (DevNetException)
			{
				DBCon.RollBackTrans();
				throw;
			}
			catch (Exception ex)
			{
				DBCon.RollBackTrans();
				Log.Error(ex.Message, ex);
				throw new DevNetException((int)DevNetExceptionEnum.CatchException, ex.Message, ex.Source);
			}
		}


	}
}