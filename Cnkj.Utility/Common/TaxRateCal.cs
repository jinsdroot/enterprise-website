using System;
using System.Collections.Generic;
 
using System.Text;

namespace Common
{
    /// <summary>
    /// 税率计算类
    /// </summary>
    public class TaxRateCal
    {
        decimal salePrice = 0;
        decimal number = 0;
        //decimal taxPercent = 0;
        decimal noTaxPrice = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salePrice">含税单价</param>
        /// <param name="number">订购数量</param>
        /// <param name="taxPercent">税率（17）</param>
        public TaxRateCal(decimal salePrice, decimal number, decimal taxPercent)
        {
            this.salePrice = salePrice;
            this.number = number;
            //this.taxPercent = taxPercent;
            noTaxPrice = salePrice / (1 + taxPercent / 100);
        }
        //不含税额【含税单价/（1+税率/100）=不含税单价，不含税单价×数量=不含税额，含税单价×数量=总金额，总金额-不含数额=税额】 列

        /// <summary>
        /// 不含税价
        /// </summary>
        /// <returns></returns>
        public decimal NoTaxPrice
        {
            get { return noTaxPrice; }
        }

        /// <summary>
        /// 不含税额
        /// </summary>
        /// <returns></returns>
        public decimal Money
        {
            get { return Math.Round(noTaxPrice*number, 2); }
        }

        /// <summary>
        /// 税额
        /// </summary>
        /// <returns></returns>
        public decimal TaxMoney
        {
            get { return TotalMoney - Money; }
        }

        /// <summary>
        /// 含税总金额
        /// </summary>
        /// <returns></returns>
        public decimal TotalMoney
        {
            get { return Math.Round(salePrice*number, 2); }
        }
    }
}
