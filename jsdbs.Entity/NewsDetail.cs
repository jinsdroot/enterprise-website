using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class NewsDetail:EntityBase,IEntity
    {
        public NewsDetail()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(NewsTypeID_FieldName, 0);
            AddProperty(NewsTitle_FieldName, string.Empty);
            AddProperty(NewsContent_FieldName, string.Empty);
            AddProperty(AddTime_FieldName, DateTime.Now);
            AddProperty(AddName_FieldName, string.Empty);
            AddProperty(IsFlag_FieldName, true);
            AddProperty(AutoSort_FieldName, 0);
            AddProperty(ClickTimes_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = NewsDetail_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string NewsDetail_TableName = "TB_NewsDetail";

        public readonly static string[] PrimaryKeyField = new string[] { "ID"};

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string NewsTypeID_FieldName = "NewsTypeID";

        public const string NewsTitle_FieldName = "NewsTitle";

        public const string NewsContent_FieldName = "NewsContent";

        public const string AddTime_FieldName = "AddTime";

        public const string AddName_FieldName = "AddName";

        public const string IsFlag_FieldName = "IsFlag";

        public const string AutoSort_FieldName = "AutoSort";

        public const string ClickTimes_FieldName = "ClickTimes";

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
        public int NewsTypeID
        {
            get
            {
                return Convert.ToInt32(GetProperty(NewsTypeID_FieldName));
            }
            set
            {
                SetProperty(NewsTypeID_FieldName, value);
            }
        }
        public string NewsTitle
        {
            get
            {
                return Convert.ToString(GetProperty(NewsTitle_FieldName));
            }
            set
            {
                SetProperty(NewsTitle_FieldName, value);
            }
        }
        public string NewsContent
        {
            get
            {
                return Convert.ToString(GetProperty(NewsContent_FieldName));
            }
            set
            {
                SetProperty(NewsContent_FieldName, value);
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

        public string AddName
        {
            get
            {
                return Convert.ToString(GetProperty(AddName_FieldName));
            }
            set
            {
                SetProperty(AddName_FieldName, value);
            }
        }

        public bool IsFlag
        {
            get
            {
                return Convert.ToBoolean(GetProperty(IsFlag_FieldName));
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


        public string ClickTimes
        {
            get
            {
                return Convert.ToString(GetProperty(ClickTimes_FieldName));
            }
            set
            {
                SetProperty(ClickTimes_FieldName, value);
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
