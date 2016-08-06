using System;
using System.Collections.Generic;
using DevNet.Common;
using DevNet.Common.Logger;
using DevNet.Permission.Entity;

namespace Cnkj.Utility
{
	/// <summary>
	/// 权限管理，派生自DevNet的权限管理类
	/// </summary>
	public class PowerManager : DevNet.Permission.PermissionManager
	{
		/// <summary>
		/// 获取角色列表
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
				Script.PrimaryKey = SysRole.RoleID_FieldName;//sql2000分页查询时请指定主键字段名称
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
		/// 获取角色列表
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="pagination"></param>
		/// <returns></returns>
		public virtual List<SysRole> GetRoleList(SearchSysRole condition, DevNet.Common.Pagination pagination)
		{
			return GetRoleList(condition, pagination, SysRole.RoleID_FieldName, ScriptQuery.SortEnum.ASC);
		}

		/// <summary>
		/// 获取管理员角色所拥有的权限菜单列表
		/// </summary>
		/// <param name="parentID">父权限ID</param>
		/// <param name="roleID"></param>
		/// <param name="isShow">是否显示的权限2全部</param>
		/// <param name="owner">权限所属后台系统（多后台系统：1系统后台  2用户后台等）</param>
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
		/// 删除管理员角色,将先删除角色权限表中所拥有的权限【请先判断管理员表是否已使用该角色】
		/// </summary>
		/// <param name="roleID">角色编号</param>
		/// <param name="ownerCode">角色所有者编号</param>
		/// <param name="owner">角色所属后台系统（多后台系统：1系统后台  2用户后台等）</param>
		public override void DeleteSysRole(int roleID, string ownerCode, int owner)
		{
			base.DBCon.BeginTrans();
            try
            {
                ////这里先判断管理员表是否已使用该角色待完成
                //if (Convert.ToInt32(Script.Select().Count("0").From("admin").Where("roleid", roleID).GetScalar()) > 0)
                //    throw new DevNetException("该管理员角色正在使用中，无法删除！");

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
		/// 判断角色是否在管理数据表中使用
		/// </summary>
		/// <param name="managerTableName">管理系统表名称</param>
		/// <param name="roleFieldName">管理系统表中角色字段名称</param>
		/// <param name="roleID">角色编号</param>
		/// <returns></returns>
		public virtual bool IsUsedSysRole(string managerTableName, string roleFieldName, int roleID)
		{
			if (Convert.ToInt32(Script.Select().Count("0").From(managerTableName).Where(roleFieldName, roleID).GetScalar()) > 0)
				//throw new DevNetException("该管理员角色正在使用中，无法删除！");
				return true;
			return false;
		}

		/// <summary>
		/// 根据权限ID获取父节点是指定根节点权限的行
		/// </summary>
		/// <param name="perID">权限ID</param>
		/// <param name="rootID">指定根节点ID</param>
		/// <param name="owner">权限所属后台系统（多后台系统：1系统后台  2用户后台等）</param>
		/// <param name="isShow">是否显示 2 全部显示</param>
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
		/// 根据权限菜单ID获取权限
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
		/// 获取系统角色实体
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
		/// 删除系统角色,将先删除角色权限表中所拥有的权限【请先判断管理员表是否已使用该角色】
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