using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevNet.Common.Entity;
using Cnkj.Utility;

namespace jsbestop.Entity
{
    [Serializable]
    public class ComBanner : EntityBase, IEntity
    {
        public ComBanner()
		{
            AddProperty(ID_FieldName, 0);
            AddProperty(BannerPic_FieldName, string.Empty);
            AddProperty(ComBannerTypeID_FieldName, 0);
            AddProperty(BannerTitle_FieldName, string.Empty);
            AddProperty(BannerLink_FieldName, string.Empty);
            AddProperty(AutoSort_FieldName, 0);
			base.TableName =  ComBanner_TableName;
			base.AutoIncrements = AutoIncrement;
			base.PrimaryKeyFields = PrimaryKeyField;
		}
        public const string ComBanner_TableName = "TB_ComBanner";
        public readonly static string[] PrimaryKeyField = new string[] { "ID" };
        public const string AutoIncrement = "ID";
        public const string ID_FieldName = "ID";
        public const string BannerPic_FieldName = "BannerPic";
        public const string BannerTitle_FieldName = "BannerTitle";
        public const string ComBannerTypeID_FieldName = "ComBannerTypeID";
        public const string BannerLink_FieldName = "BannerLink";
        public const string AutoSort_FieldName = "AutoSort";
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
        public int ComBannerTypeID
        {
            get
            {
                return Convert.ToInt32(GetProperty(ComBannerTypeID_FieldName));
            }
            set
            {
                SetProperty(ComBannerTypeID_FieldName, value);
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
        public string BannerPic
        {
            get
            {
                return Convert.ToString(GetProperty(BannerPic_FieldName));
            }
            set
            {
                SetProperty(BannerPic_FieldName, value);
            }
        }
        public string BannerTitle
        {
            get
            {
                return Convert.ToString(GetProperty(BannerTitle_FieldName));
            }
            set
            {
                SetProperty(BannerTitle_FieldName, value);
            }
        }
        public string BannerLink
        {
            get
            {
                return Convert.ToString(GetProperty(BannerLink_FieldName));
            }
            set
            {
                SetProperty(BannerLink_FieldName, value);
            }
        }
    }
}
