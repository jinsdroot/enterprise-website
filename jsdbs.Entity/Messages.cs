using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;
namespace jsbestop.Entity
{
     [Serializable]
    public class Messages : EntityBase, IEntity
    {
         public Messages()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(MesTitle_FieldName, string.Empty);
            AddProperty(MesContent_FieldName, string.Empty);
            AddProperty(MesName_FieldName, string.Empty);
            AddProperty(MesCompany_FieldName, string.Empty);
            AddProperty(MesQQ_FieldName, string.Empty);
            AddProperty(MesTelphone_FieldName, string.Empty);
            AddProperty(MesEmail_FieldName, string.Empty);
            AddProperty(MesAddress_FieldName, string.Empty);
            AddProperty(MesDate_FieldName, DateTime.Now);
            AddProperty(IsReply_FieldName, 0);
            AddProperty(RePlyDate_FieldName, DateTime.Now);
            AddProperty(ReplyName_FieldName, string.Empty);
            AddProperty(ReplyContent_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = Messages_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}
          #region====表名称、字段名称、主键字段、自动增长型字段名称====
         public const string Messages_TableName = "Tb_Messages";

          public readonly static string[] PrimaryKeyField = new string[] { "ID" };

          public const string AutoIncrement = "ID";

          public const string ID_FieldName = "ID";

          public const string MesTitle_FieldName = "MesTitle";

          public const string MesContent_FieldName = "MesContent";

          public const string MesName_FieldName = "MesName";

          public const string MesCompany_FieldName = "MesCompany";

          public const string MesQQ_FieldName = "MesQQ";

          public const string MesTelphone_FieldName = "MesTelphone";

          public const string MesEmail_FieldName = "MesEmail";

          public const string MesAddress_FieldName = "MesAddress";

          public const string MesDate_FieldName = "MesDate";

          public const string IsReply_FieldName = "IsReply";

          public const string RePlyDate_FieldName = "RePlyDate";

          public const string ReplyName_FieldName = "ReplyName";

          public const string ReplyContent_FieldName = "ReplyContent";

          public const string Remarks_FieldName = "Remarks";

          public const string IsEnglish_FieldName = "IsEnglish";

          #endregion

          #region====字段属性====

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
          public string MesTitle
          {
              get
              {
                  return Convert.ToString(GetProperty(MesTitle_FieldName));
              }
              set
              {
                  SetProperty(MesTitle_FieldName, value);
              }
          }
          public string MesContent
          {
              get
              {
                  return Convert.ToString(GetProperty(MesContent_FieldName));
              }
              set
              {
                  SetProperty(MesContent_FieldName, value);
              }
          }
          public string MesName
          {
              get
              {
                  return Convert.ToString(GetProperty(MesName_FieldName));
              }
              set
              {
                  SetProperty(MesName_FieldName, value);
              }
          }
          public string MesCompany
          {
              get
              {
                  return Convert.ToString(GetProperty(MesCompany_FieldName));
              }
              set
              {
                  SetProperty(MesCompany_FieldName, value);
              }
          }
          public string MesQQ
          {
              get
              {
                  return Convert.ToString(GetProperty(MesQQ_FieldName));
              }
              set
              {
                  SetProperty(MesQQ_FieldName, value);
              }
          }
          public string MesTelphone
          {
              get
              {
                  return Convert.ToString(GetProperty(MesTelphone_FieldName));
              }
              set
              {
                  SetProperty(MesTelphone_FieldName, value);
              }
          }
          public string MesEmail
          {
              get
              {
                  return Convert.ToString(GetProperty(MesEmail_FieldName));
              }
              set
              {
                  SetProperty(MesEmail_FieldName, value);
              }
          }
          public string MesAddress
          {
              get
              {
                  return Convert.ToString(GetProperty(MesAddress_FieldName));
              }
              set
              {
                  SetProperty(MesAddress_FieldName, value);
              }
          }
          public DateTime MesDate
          {
              get
              {
                  return Convert.ToDateTime(GetProperty(MesDate_FieldName));
              }
              set
              {
                  SetProperty(MesDate_FieldName, value);
              }
          }
          public int IsReply
          {
              get
              {
                  return Convert.ToInt32(GetProperty(IsReply_FieldName));
              }
              set
              {
                  SetProperty(IsReply_FieldName, value);
              }
          }
          public DateTime RePlyDate
          {
              get
              {
                  return Convert.ToDateTime(GetProperty(RePlyDate_FieldName));
              }
              set
              {
                  SetProperty(RePlyDate_FieldName, value);
              }
          }

          public string ReplyName
          {
              get
              {
                  return Convert.ToString(GetProperty(ReplyName_FieldName));
              }
              set
              {
                  SetProperty(ReplyName_FieldName, value);
              }
          }
          public string ReplyContent
          {
              get
              {
                  return Convert.ToString(GetProperty(ReplyContent_FieldName));
              }
              set
              {
                  SetProperty(ReplyContent_FieldName, value);
              }
          }
          public string Remarks
          {
              get
              {
                  return Convert.ToString(GetProperty(Remarks_FieldName));
              }
              set
              {
                  SetProperty(Remarks_FieldName, value);
              }
          }
          public int IsEnglish
          {
              get
              {
                  return Convert.ToInt32(GetProperty(IsEnglish_FieldName));
              }
              set
              {
                  SetProperty(IsEnglish_FieldName, value);
              }
          }
          #endregion

        #region=====表关系属性，可以手动将实体类作为该实体的属性====


        #endregion
    }
  }
