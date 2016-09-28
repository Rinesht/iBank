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
    public class CommonTest
    {
        [TestCase]
        public void ReadXMLTest()
        {
            DataSet ds = iBank_Investor.DataAccess.Common.ReadXml("C:/Enterprise Agility/iBank_Investor/DatabaseXML/Login.xml");
            /*This is Test Assert */
            Assert.AreEqual(1, ds.Tables.Count);
            Assert.Greater(ds.Tables[0].Rows.Count, 0);
            Assert.AreEqual(ds.Tables[0].Columns.Count, 4);
        }

        

    }
}
