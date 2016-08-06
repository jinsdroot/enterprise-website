using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
     [Serializable]
   public class ProductSecondType : EntityBase, IEntity
    {
         public ProductSecondType()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ProductTypeID_FieldName, 0);
            AddProperty(ProductSecondTypeName_FieldName, string.Empty);
            AddProperty(IsFlag_FieldName, 0);
            AddProperty(AutoSort_FieldName, 0);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = ProductSecondType_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }
         #region====表名称、字段名称、主键字段、自动增长型字段名称====
         public const string ProductSecondType_TableName = "TB_ProductSecondType";

         public readonly static string[] PrimaryKeyField = new string[] { "ID" };

         public const string AutoIncrement = "ID";

         public const string ID_FieldName = "ID";

         public const string ProductTypeID_FieldName = "ProductTypeID";

         public const string ProductSecondTypeName_FieldName = "ProductSecondTypeName";

         public const string IsFlag_FieldName = "IsFlag";

         public const string AutoSort_FieldName = "AutoSort";

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
         public int ProductTypeID
         {
             get
             {
                 return Convert.ToInt32(GetProperty(ProductTypeID_FieldName));
             }
             set
             {
                 SetProperty(ProductTypeID_FieldName, value);
             }
         }
         public string ProductSecondTypeName
         {
             get
             {
                 return Convert.ToString(GetProperty(ProductSecondTypeName_FieldName));
             }
             set
             {
                 SetProperty(ProductSecondTypeName_FieldName, value);
             }
         }
         public int IsFlag
         {
             get
             {
                 return Convert.ToInt32(GetProperty(IsFlag_FieldName));
             }
             set
             {
                 SetProperty(IsFlag_FieldName, value);
             }
         }
         public int AutoSort
         {
             get
             {
                 return Convert.ToInt32(GetProperty(AutoSort_FieldName));
             }
             set
             {
                 SetProperty(AutoSort_FieldName, value);
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
    }
 }
