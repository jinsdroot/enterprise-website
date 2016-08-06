using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
   [Serializable]
    public class ProductPicture : EntityBase, IEntity
    {
       public ProductPicture()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ProDetailID_FieldName, 0);
            AddProperty(ProPicAddress_FieldName, string.Empty);
            AddProperty(ProPicSmallAddress_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            base.TableName = ProductPicture_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
       public const string ProductPicture_TableName = "TB_ProductPicture";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string ProDetailID_FieldName = "ProDetailID";

        public const string ProPicAddress_FieldName = "ProPicAddress";

        public const string ProPicSmallAddress_FieldName = "ProPicSmallAddress";

        public const string Remarks_FieldName = "Remarks";

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
        public int ProDetailID
        {
            get
            {
                return Convert.ToInt32(GetProperty(ProDetailID_FieldName));
            }
            set
            {
                SetProperty(ProDetailID_FieldName, value);
            }
        }
        public string ProPicAddress
        {
            get
            {
                return Convert.ToString(GetProperty(ProPicAddress_FieldName));
            }
            set
            {
                SetProperty(ProPicAddress_FieldName, value);
            }
        }
        public string ProPicSmallAddress
        {
            get
            {
                return Convert.ToString(GetProperty(ProPicSmallAddress_FieldName));
            }
            set
            {
                SetProperty(ProPicSmallAddress_FieldName, value);
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
        #endregion
    }
}
