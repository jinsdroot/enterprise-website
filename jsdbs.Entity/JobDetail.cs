using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class JobDetail : EntityBase, IEntity
    {

        public JobDetail()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(JobTypeID_FieldName, 0);
            AddProperty(JobName_FieldName, string.Empty);
            AddProperty(JobContent_FieldName, string.Empty);
            AddProperty(JobNumber_FieldName, string.Empty);
            AddProperty(JobTreatment_FieldName, string.Empty);
            AddProperty(Candidatesway_FieldName, string.Empty);
            AddProperty(JobEndDate_FieldName, DateTime.Now);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            base.TableName = JobDetail_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}
        #region====表名称、字段名称、主键字段、自动增长型字段名称====

          public const string JobDetail_TableName = "Tb_JobDetail";

          public readonly static string[] PrimaryKeyField = new string[] { "ID" };

          public const string AutoIncrement = "ID";

          public const string ID_FieldName = "ID";

          public const string JobTypeID_FieldName = "JobTypeID";

          public const string JobName_FieldName = "JobName";

          public const string JobContent_FieldName = "JobContent";

          public const string JobNumber_FieldName = "JobNumber";

          public const string JobTreatment_FieldName = "JobTreatment";

          public const string Candidatesway_FieldName = "Candidatesway";

          public const string JobEndDate_FieldName = "JobEndDate";

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
          public int JobTypeID
          {
              get
              {
                  return Convert.ToInt32(GetProperty(JobTypeID_FieldName));
              }
              set
              {
                  SetProperty(JobTypeID_FieldName, value);
              }
          }
          public string JobName
          {
              get
              {
                  return Convert.ToString(GetProperty(JobName_FieldName));
              }
              set
              {
                  SetProperty(JobName_FieldName, value);
              }
          }
          public string JobContent
          {
              get
              {
                  return Convert.ToString(GetProperty(JobContent_FieldName));
              }
              set
              {
                  SetProperty(JobContent_FieldName, value);
              }
          }
          public string JobNumber
          {
              get
              {
                  return Convert.ToString(GetProperty(JobNumber_FieldName));
              }
              set
              {
                  SetProperty(JobNumber_FieldName, value);
              }
          }
          public string JobTreatment
          {
              get
              {
                  return Convert.ToString(GetProperty(JobTreatment_FieldName));
              }
              set
              {
                  SetProperty(JobTreatment_FieldName, value);
              }
          }
          public string Candidatesway
          {
              get
              {
                  return Convert.ToString(GetProperty(Candidatesway_FieldName));
              }
              set
              {
                  SetProperty(Candidatesway_FieldName, value);
              }
          }
          public DateTime JobEndDate
          {
              get
              {
                  return Convert.ToDateTime(GetProperty(JobEndDate_FieldName));
              }
              set
              {
                  SetProperty(JobEndDate_FieldName, value);
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

        #region=====表关系属性，可以手动将实体类作为该实体的属性====


        #endregion
    }
  }
