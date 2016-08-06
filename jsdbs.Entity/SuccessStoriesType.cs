using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
    [Serializable]
    public class SuccessStoriesType:EntityBase,IEntity
    {
        public SuccessStoriesType()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(SSTypeName_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            AddProperty(AutoSort_FieldName, 0);
            base.TableName = SuccessStoriesType_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string SuccessStoriesType_TableName = "TB_SuccessStoriesType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";
        public const string AutoSort_FieldName = "AutoSort";
        public const string ID_FieldName = "ID";

        public const string SSTypeName_FieldName = "SSTypeName";

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
        public string SSTypeName
        {
            get
            {
                return Convert.ToString(GetProperty(SSTypeName_FieldName));
            }
            set
            {
                SetProperty(SSTypeName_FieldName, value);
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
