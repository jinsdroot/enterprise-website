using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{

    [Serializable]
    public class ComBannerType : EntityBase, IEntity
    {
        public ComBannerType()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ComBannerTypeName_FieldName, string.Empty);
            AddProperty(IsFlag_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = ComBannerType_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string ComBannerType_TableName = "TB_ComBannerType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string ComBannerTypeName_FieldName = "ComBannerTypeName";

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
        public string ComBannerTypeName
        {
            get
            {
                return Convert.ToString(GetProperty(ComBannerTypeName_FieldName));
            }
            set
            {
                SetProperty(ComBannerTypeName_FieldName, value);
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
