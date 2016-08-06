using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class ProductDetail : EntityBase, IEntity
    {
        public ProductDetail()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ProTypeID_FieldName, 0);
            AddProperty(ProSecondTypeID_FieldName, 0);
            AddProperty(ProductName_FieldName, string.Empty);
            AddProperty(ProductEngName_FieldName, string.Empty);
            AddProperty(ProductPic_FieldName, string.Empty);
            AddProperty(ProductContent_FieldName, string.Empty);
            AddProperty(AddTime_FieldName, DateTime.Now);
            AddProperty(IsFlag_FieldName, string.Empty);
            AddProperty(AutoSort_FieldName, 0);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = ProductDetaill_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string ProductDetaill_TableName = "TB_ProductDetail";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string ProTypeID_FieldName = "ProTypeID";

        public const string ProSecondTypeID_FieldName = "ProSecondTypeID";

        public const string ProductName_FieldName = "ProductName";

        public const string ProductEngName_FieldName = "ProductEngName";

        public const string ProductPic_FieldName = "ProductPic";

        public const string ProductContent_FieldName = "ProductContent";

        public const string AddTime_FieldName = "AddTime";

        public const string IsFlag_FieldName = "IsFlag";

        public const string AutoSort_FieldName = "AutoSort";

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
        public int ProTypeID
        {
            get
            {
                return Convert.ToInt32(GetProperty(ProTypeID_FieldName));
            }
            set
            {
                SetProperty(ProTypeID_FieldName, value);
            }
        }
        public int ProSecondTypeID
        {
            get
            {
                return Convert.ToInt32(GetProperty(ProSecondTypeID_FieldName));
            }
            set
            {
                SetProperty(ProSecondTypeID_FieldName, value);
            }
        }
        public string ProductName
        {
            get
            {
                return Convert.ToString(GetProperty(ProductName_FieldName));
            }
            set
            {
                SetProperty(ProductName_FieldName, value);
            }
        }

        public string ProductEngName
        {
            get
            {
                return Convert.ToString(GetProperty(ProductEngName_FieldName));
            }
            set
            {
                SetProperty(ProductEngName_FieldName, value);
            }
        }
        public string ProductPic
        {
            get
            {
                return Convert.ToString(GetProperty(ProductPic_FieldName));
            }
            set
            {
                SetProperty(ProductPic_FieldName, value);
            }
        }
        public string ProductContent
        {
            get
            {
                return Convert.ToString(GetProperty(ProductContent_FieldName));
            }
            set
            {
                SetProperty(ProductContent_FieldName, value);
            }
        }
        public DateTime AddTime
        {
            get
            {
                return Convert.ToDateTime(GetProperty(AddTime_FieldName));
            }
            set
            {
                SetProperty(AddTime_FieldName, value);
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
    }
}
