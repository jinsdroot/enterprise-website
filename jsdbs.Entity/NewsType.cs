using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
    [Serializable]
    public class NewsType:EntityBase,IEntity
    {
        public NewsType()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(NewsTypeName_FieldName, string.Empty);
            AddProperty(IsFlag_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = NewsType_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string NewsType_TableName = "TB_NewsType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string NewsTypeName_FieldName = "NewsTypeName";

        public const string IsFlag_FieldName = "IsFlag";

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
        public string NewsTypeName
        {
            get
            {
                return Convert.ToString(GetProperty(NewsTypeName_FieldName));
            }
            set
            {
                SetProperty(NewsTypeName_FieldName, value);
            }
        }
        public string IsFlag
        {
            get
            {
                return Convert.ToString(GetProperty(IsFlag_FieldName));
            }
            set
            {
                SetProperty(IsFlag_FieldName, value);
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
