using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using iBank_Investor.DataAccess;
using System.Data;

namespace iBank_Investor.Test
{
     [TestFixture]
    class PortfolioTest
    {
         [TestCase("AJ9902", 4)]
         [TestCase("NOTTHERE", 0)]
         public void GetPortfolioDataTest(String userid, int rowcount)
         {
             DataTable dt = iBank_Investor.DataAccess.Portfolio.getPortfolioData(userid, "C:/Enterprise Agility/iBank_Investor/DatabaseXML/UserStocks.xml", "C:/Enterprise Agility/iBank_Investor/DatabaseXML/CurrentStock.xml");
             Assert.AreEqual(dt.Columns.Count, 10);
             Assert.AreEqual(dt.Rows.Count, rowcount);
             
         }


    }
}
