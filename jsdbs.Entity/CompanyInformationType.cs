using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
    [Serializable]
    public class CompanyInformationType : EntityBase, IEntity
    {
        public CompanyInformationType()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(CompanyInformationName_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = CompanyInformationType_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string CompanyInformationType_TableName = "TB_CompanyInformationType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string CompanyInformationName_FieldName = "CompanyInformationName";

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
        public string CompanyInformationName
        {
            get
            {
                return Convert.ToString(GetProperty(CompanyInformationName_FieldName));
            }
            set
            {
                SetProperty(CompanyInformationName_FieldName, value);
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
