using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;

namespace jsbestop.Entity
{
    [Serializable]
    public class Contact : EntityBase, IEntity
    {
        public Contact()
        {
            AddProperty(ID_FieldName, 0);
            AddProperty(ConCompany_FieldName, string.Empty);
            AddProperty(Address_FieldName, string.Empty);
            AddProperty(Phone_FieldName, string.Empty);
            AddProperty(Tel_FieldName, string.Empty);
            AddProperty(Fax_FieldName, string.Empty);
            AddProperty(Email_FieldName, string.Empty);
            AddProperty(Website_FieldName, string.Empty);
            AddProperty(ConName_FieldName, string.Empty);
            AddProperty(Remarks_FieldName, string.Empty);
            AddProperty(PhoneTel_FieldName, string.Empty);
            AddProperty(PhoneSms_FieldName, string.Empty);
            AddProperty(IsEnglish_FieldName, 0);
            AddProperty(HotPhone_FieldName, string.Empty);
            AddProperty(BaiDuCount_FieldName, string.Empty);
            base.TableName = Contact_TableName;
            base.AutoIncrements = AutoIncrement;
            base.PrimaryKeyFields = PrimaryKeyField;
        }

        #region====表名称、字段名称、主键字段、自动增长型字段名称====
        public const string Contact_TableName = "Tb_Contact";

        public readonly static string[] PrimaryKeyField = new string[] { "ID" };

        public const string AutoIncrement = "ID";

        public const string ID_FieldName = "ID";

        public const string ConCompany_FieldName = "ConCompany";

        public const string Address_FieldName = "ConAddress";

        public const string Phone_FieldName = "ConPhone";

        public const string Tel_FieldName = "ConTel";

        public const string Fax_FieldName = "ConFax";

        public const string Email_FieldName = "ConEmail";

        public const string Website_FieldName = "ConWebsite";

        public const string ConName_FieldName = "ConName";

        public const string Remarks_FieldName = "Remarks";

        public const string IsEnglish_FieldName = "IsEnglish";

        public const string HotPhone_FieldName = "HotPhone";

        public const string PhoneTel_FieldName = "PhoneTel";

        public const string PhoneSms_FieldName = "PhoneSms";

        public const string BaiDuCount_FieldName = "BaiDuCount";
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
        public string BaiDuCount
        {
            get
            {
                return Convert.ToString(GetProperty(BaiDuCount_FieldName));
            }
            set
            {
                SetProperty(BaiDuCount_FieldName, value);
            }
        }
        public string ConCompany
        {
            get
            {
                return Convert.ToString(GetProperty(ConCompany_FieldName));
            }
            set
            {
                SetProperty(ConCompany_FieldName, value);
            }
        }
        public string ConAddress
        {
            get
            {
                return Convert.ToString(GetProperty(Address_FieldName));
            }
            set
            {
                SetProperty(Address_FieldName, value);
            }
        }
        public string ConPhone
        {
            get
            {
                return Convert.ToString(GetProperty(Phone_FieldName));
            }
            set
            {
                SetProperty(Phone_FieldName, value);
            }
        }
        public string ConTel
        {
            get
            {
                return Convert.ToString(GetProperty(Tel_FieldName));
            }
            set
            {
                SetProperty(Tel_FieldName, value);
            }
        }
        public string ConFax
        {
            get
            {
                return Convert.ToString(GetProperty(Fax_FieldName));
            }
            set
            {
                SetProperty(Fax_FieldName, value);
            }
        }
        public string ConEmail
        {
            get
            {
                return Convert.ToString(GetProperty(Email_FieldName));
            }
            set
            {
                SetProperty(Email_FieldName, value);
            }
        }
        public string ConWebsite
        {
            get
            {
                return Convert.ToString(GetProperty(Website_FieldName));
            }
            set
            {
                SetProperty(Website_FieldName, value);
            }
        }
        public string ConName
        {
            get
            {
                return Convert.ToString(GetProperty(ConName_FieldName));
            }
            set
            {
                SetProperty(ConName_FieldName, value);
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
        public string HotPhone
        {
            get
            {
                return Convert.ToString(GetProperty(HotPhone_FieldName));
            }
            set
            {
                SetProperty(HotPhone_FieldName, value);
            }
        }
        public string PhoneTel
        {
            get
            {
                return Convert.ToString(GetProperty(PhoneTel_FieldName));
            }
            set
            {
                SetProperty(PhoneTel_FieldName, value);
            }
        }
        public string PhoneSms
        {
            get
            {
                return Convert.ToString(GetProperty(PhoneSms_FieldName));
            }
            set
            {
                SetProperty(PhoneSms_FieldName, value);
            }
        }
        #endregion

        #region=====表关系属性，可以手动将实体类作为该实体的属性====


        #endregion
    }
}
