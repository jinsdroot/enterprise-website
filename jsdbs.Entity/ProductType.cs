using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
    [Serializable]
    public class ProductType:EntityBase,IEntity
    {
        public ProductType()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ProductTypeName_FieldName, string.Empty);
            AddProperty(IsFlag_FieldName, 0);
            AddProperty(AutoSort_FieldName, 0);
            AddProperty(ProductTypePic_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            AddProperty(IsHaveSecondTpye_FieldName, 0);
            base.TableName = ProductType_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string ProductType_TableName = "TB_ProductType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string ProductTypeName_FieldName = "ProductTypeName";

        public const string IsFlag_FieldName = "IsFlag";

        public const string AutoSort_FieldName = "AutoSort";

        public const string Remarks_FieldName = "Remarks";
        public const string ProductTypePic_FieldName = "ProductTypePic";
        public const string IsEnglish_FieldName = "IsEnglish";

        public const string IsHaveSecondTpye_FieldName = "IsHaveSecondTpye";
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
        public string ProductTypeName
        {
            get
            {
                return Convert.ToString(GetProperty(ProductTypeName_FieldName));
            }
            set
            {
                SetProperty(ProductTypeName_FieldName, value);
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
        public string ProductTypePic
        {
            get
            {
                return Convert.ToString(GetProperty(ProductTypePic_FieldName));
            }
            set
            {
                SetProperty(ProductTypePic_FieldName, value);
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
        public int IsHaveSecondTpye
        {
            get
            {
                return Convert.ToInt32(GetProperty(IsHaveSecondTpye_FieldName));
            }
            set
            {
                SetProperty(IsHaveSecondTpye_FieldName, value);
            }
        }
        #endregion
    }
}
