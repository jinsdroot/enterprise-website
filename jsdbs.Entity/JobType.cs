using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;
namespace jsbestop.Entity
{
    [Serializable]
    public class JobType : EntityBase, IEntity
    {
        public JobType()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(JobTypeName_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = JobType_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		} 
        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string JobType_TableName = "TB_JobType";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string JobTypeName_FieldName = "JobTypeName";

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
        public string JobTypeName
        {
            get
            {
                return Convert.ToString(GetProperty(JobTypeName_FieldName));
            }
            set
            {
                SetProperty(JobTypeName_FieldName, value);
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

