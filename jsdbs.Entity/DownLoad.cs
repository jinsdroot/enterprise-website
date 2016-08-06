using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;


namespace jsbestop.Entity
{
      [Serializable]
    public class DownLoad : EntityBase, IEntity
    {
          public DownLoad()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(DLName_FieldName, string.Empty);
            AddProperty(DLAddress_FieldName, string.Empty);
            AddProperty(DLSort_FieldName, string.Empty);
            AddProperty(DLAddTime_FieldName, DateTime.Now);
            AddProperty(DLAddName_FieldName, string.Empty);
            AddProperty(DLContent_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = DownLoad_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}
          #region====表名称、字段名称、主键字段、自动增长型字段名称====
          public const string DownLoad_TableName = "Tb_DownLoad";

          public readonly static string[] PrimaryKeyField = new string[] { "ID" };

          public const string AutoIncrement = "ID";

          public const string ID_FieldName = "ID";

          public const string DLName_FieldName = "DLName";

          public const string DLAddress_FieldName = "DLAddress";

          public const string DLSort_FieldName = "DLSort";

          public const string DLAddTime_FieldName = "DLAddTime";

          public const string DLAddName_FieldName = "DLAddName";

          public const string DLContent_FieldName = "DLContent";

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
          public string DLName
          {
              get
              {
                  return Convert.ToString(GetProperty(DLName_FieldName));
              }
              set
              {
                  SetProperty(DLName_FieldName, value);
              }
          }
          public string DLAddress
          {
              get
              {
                  return Convert.ToString(GetProperty(DLAddress_FieldName));
              }
              set
              {
                  SetProperty(DLAddress_FieldName, value);
              }
          }
          public string DLSort
          {
              get
              {
                  return Convert.ToString(GetProperty(DLSort_FieldName));
              }
              set
              {
                  SetProperty(DLSort_FieldName, value);
              }
          }
          public DateTime DLAddTime
          {
              get
              {
                  return Convert.ToDateTime(GetProperty(DLAddTime_FieldName));
              }
              set
              {
                  SetProperty(DLAddTime_FieldName, value);
              }
          }
          public string DLAddName
          {
              get
              {
                  return Convert.ToString(GetProperty(DLAddName_FieldName));
              }
              set
              {
                  SetProperty(DLAddName_FieldName, value);
              }
          }
          public string DLContent
          {
              get
              {
                  return Convert.ToString(GetProperty(DLContent_FieldName));
              }
              set
              {
                  SetProperty(DLContent_FieldName, value);
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
