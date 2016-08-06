using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using System.Data;

namespace jsbestop.DAL
{
    public class DALNewsDetail : DALExt<NewsDetail, SearchNewsDetail>
    {
        public override List<NewsDetail> GetList(SearchNewsDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<NewsDetail> GetList(SearchNewsDetail condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.NewsTypeID > 0)
                Script.Where(NewsDetail.NewsTypeID_FieldName, condition.NewsTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsDetail.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<NewsDetail> list = Script.GetList<NewsDetail>();
            return list;
        }

        public override List<NewsDetail> GetPageList(SearchNewsDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<NewsDetail> GetPageList(SearchNewsDetail condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (condition.NewsTypeID > 0)
                Script.Where(NewsDetail.NewsTypeID_FieldName, condition.NewsTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsDetail.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            List<NewsDetail> lists = Script.GetList<NewsDetail>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchNewsDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchNewsDetail condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchNewsDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchNewsDetail condition)
        {
            throw new System.NotImplementedException();
        }
        //得到上一条数据
        public NewsDetail GetListOn(int ID)
        {
            Script.SelectTop(1).ALL().From().Where().AddSqlText("and ID <" + ID);
            Script.AddOrderBy().OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            DataSet ds = Script.GetDataSet();
            NewsDetail model = new NewsDetail();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NewsTitle = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        //得到下一条数据
        public NewsDetail GetListNext(int ID)
        {

            Script.SelectTop(1).ALL().From().Where().AddSqlText("and ID >" + ID);
            Script.AddOrderBy().OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
            DataSet ds = Script.GetDataSet();
            NewsDetail model = new NewsDetail();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NewsTitle = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        //得到前1条数据
        public List<NewsDetail> GetTopList(SearchNewsDetail condition)
        {
            Script.SelectTop(3).ALL().From().Where();
            if (condition.NewsTypeID > 0)
                Script.Where(NewsDetail.NewsTypeID_FieldName, condition.NewsTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsDetail.AutoSort_FieldName + " desc ," + NewsDetail.AddTime_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);

            List<NewsDetail> lists = Script.GetList<NewsDetail>();
            return lists;
        }
        public int GetMaxID()
        {
            Script.SelectTop(1).ALL().From().Where().AddOrderBy().OrderBy(NewsDetail.AutoSort_FieldName + " desc ," + NewsDetail.AddTime_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<NewsDetail> list = Script.GetList<NewsDetail>();
            return list.First().ID;
        }

        //得到第二条以后N条数据数据
        public List<NewsDetail> GetOtherList(SearchNewsDetail condition)
        {
            Script.SelectTop(4).ALL().From().Where().AddSqlText("and ID not in (select top 1 ID from TB_NewsDetail where NewsTypeID=9 order by AutoSort desc, AddTime desc , id desc)");
            if (condition.NewsTypeID > 0)
                Script.Where(NewsDetail.NewsTypeID_FieldName, condition.NewsTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsDetail.AutoSort_FieldName + " desc ," + NewsDetail.AddTime_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(NewsDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<NewsDetail> lists = Script.GetList<NewsDetail>();
            return lists;
        }
    }
}
