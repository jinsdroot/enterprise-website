using System;
using System.Web.UI.WebControls;
using Common;

namespace Cnkj.Utility
{
    /// <summary>
    /// GridView排序帮助
    /// </summary>
    public class GridViewTool
    {
        private static readonly string ASCSymbol = " <img src=" + URLHelper.VirtualRoot + "/images/AscOn.gif border=0> ";

        private static readonly string DESCSymbol = " <img src=" + URLHelper.VirtualRoot +
                                                    "/images/DescOn.gif border=0> ";

        /// <summary>
        /// 排序获取排序字符串，并设置图标返回结果格式【fieldname ，ASC】
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetSortExpress(GridView gridView, GridViewSortEventArgs e)
        {
            string ret = "";
            foreach (DataControlField oCol in gridView.Columns)
            {
                if (e.SortExpression.Equals(oCol.SortExpression, StringComparison.CurrentCultureIgnoreCase))
                {
                    oCol.HeaderText = oCol.HeaderText.Replace(ASCSymbol, "").Replace(DESCSymbol, "");
                    //((BoundField)oCol).HtmlEncode = false;
                    if (oCol is BoundField)
                    {
                        ((BoundField) oCol).HtmlEncode = false;
                    }
                    if (e.SortExpression.IndexOf(" ,ASC") > 1)
                    {
                        oCol.SortExpression = e.SortExpression.Replace(" ,ASC", " ,DESC");
                        oCol.HeaderText = oCol.HeaderText + DESCSymbol;
                        //oCol.HeaderImageUrl = DESCSymbol;
                        ret = oCol.SortExpression;
                    }
                    else if (e.SortExpression.IndexOf(" ,DESC") > 1)
                    {
                        oCol.SortExpression = e.SortExpression.Replace(" ,DESC", " ,ASC");
                        oCol.HeaderText += ASCSymbol;
                        ret = oCol.SortExpression;
                    }
                    else
                    {
                        oCol.SortExpression = e.SortExpression + " ,ASC";
                        oCol.HeaderText = oCol.HeaderText + ASCSymbol;
                        //oCol.HeaderImageUrl = ASCSymbol;
                        ret = oCol.SortExpression;
                    }
                }
                else
                {
                    oCol.HeaderText = oCol.HeaderText.Replace(ASCSymbol, "").Replace(DESCSymbol, "");
                    oCol.SortExpression = oCol.SortExpression.Replace(" ,DESC", "").Replace(" ,ASC", "");
                }
            }
            return ret;
        }

        /// <summary>
        /// 清除列头上的排序图标
        /// </summary>
        /// <param name="dv"></param>
        public static void ClearColSortIcon(GridView dv)
        {
            foreach (DataControlField col in dv.Columns)
            {
                col.HeaderText = col.HeaderText.Replace(ASCSymbol, "").Replace(DESCSymbol, "");
            }
        }
    }
}