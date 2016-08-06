using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class CompanyInformationDetails: EntityBase, IEntity
    {
        public CompanyInformationDetails()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(CompanyInformationTypeID_FieldName, 0);
            AddProperty(CompanyInformationDetail_FieldName, string.Empty);
            AddProperty(AddName_FieldName, string.Empty);
            AddProperty(AddTime_FieldName, DateTime.Now);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = CompanyInformationDetail_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string CompanyInformationDetail_TableName = "TB_CompanyInformationDetail";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string CompanyInformationTypeID_FieldName = "CompanyInformationTypeID";

        public const string CompanyInformationDetail_FieldName = "CompanyInformationDetail";

        public const string AddName_FieldName = "AddName";

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
        public int CompanyInformationTypeID
        {
            get
            {
                return Convert.ToInt32(GetProperty(CompanyInformationTypeID_FieldName));
            }
            set
            {
                SetProperty(CompanyInformationTypeID_FieldName, value);
            }
        }
        public string CompanyInformationDetail
        {
            get
            {
                return Convert.ToString(GetProperty(CompanyInformationDetail_FieldName));
            }
            set
            {
                SetProperty(CompanyInformationDetail_FieldName, value);
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
