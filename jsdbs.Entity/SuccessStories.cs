using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class SuccessStories:EntityBase,IEntity
    {
        public SuccessStories()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(SSType_FieldName, 0);
            AddProperty(SSName_FieldName, string.Empty);
            AddProperty(SSContent_FieldName, string.Empty);
            AddProperty(SSPic_FieldName, string.Empty);
            AddProperty(SSLink_FieldName, string.Empty);
            AddProperty(AddTime_FieldName, DateTime.Now);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(AutoSort_FieldName, 0);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = SuccessStories_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string SuccessStories_TableName = "TB_SuccessStories";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string SSType_FieldName = "SSType";

        public const string SSName_FieldName = "SSName";

        public const string SSContent_FieldName = "SSContent";

        public const string SSPic_FieldName = "SSPic";
        public const string AutoSort_FieldName = "AutoSort";
        public const string SSLink_FieldName = "SSLink";

        public const string AddTime_FieldName = "AddTime";

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
        public int SSType
        {
            get
            {
                return Convert.ToInt32(GetProperty(SSType_FieldName));
            }
            set
            {
                SetProperty(SSType_FieldName, value);
            }
        }
        public string SSName
        {
            get
            {
                return Convert.ToString(GetProperty(SSName_FieldName));
            }
            set
            {
                SetProperty(SSName_FieldName, value);
            }
        }
        public string SSContent
        {
            get
            {
                return Convert.ToString(GetProperty(SSContent_FieldName));
            }
            set
            {
                SetProperty(SSContent_FieldName, value);
            }
        }
        public string SSPic
        {
            get
            {
                return Convert.ToString(GetProperty(SSPic_FieldName));
            }
            set
            {
                SetProperty(SSPic_FieldName, value);
            }
        }
        public string SSLink
        {
            get
            {
                return Convert.ToString(GetProperty(SSLink_FieldName));
            }
            set
            {
                SetProperty(SSLink_FieldName, value);
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
