using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using iBank_Investor.DataObject;
using System.Xml;

namespace iBank_Investor.DataAccess
{
    public class Portfolio
    {
        public static DataTable getPortfolioData(String userID, String path, String currentStockPath)
        {
            DataTable resultDT = new DataTable();
            resultDT.Columns.Add("Symbol");
            resultDT.Columns.Add("Quantity");
            resultDT.Columns.Add("AvgCostPrice");
            resultDT.Columns.Add("CurrentMarketPrice");
            resultDT.Columns.Add("Change");
            resultDT.Columns.Add("ValueAtCost");
            resultDT.Columns.Add("ValueAtMarket");
            resultDT.Columns.Add("Realized");
            resultDT.Columns.Add("Unrealized");
            resultDT.Columns.Add("Action");

           
            DataSet userDS = Common.ReadXml(path);            
            Dictionary<String, CurrentStock> currentDict = Common.getCurrentStocks(currentStockPath);

            DataRow[] result = null;

            if (userDS.Tables.Count > 0)
            {
                if (userDS.Tables[0].Rows.Count > 0)
                {
                    result = userDS.Tables[0].Select("UserID='"+userID.Trim()+"'");
                }
            }

            if (result != null)
            {
                foreach (DataRow dr in result)
                {
                    try
                    {
                        DataRow resDR = resultDT.NewRow();
                        resDR["Symbol"] = dr["Symbol"].ToString();
                        resDR["Quantity"] = dr["Units"].ToString();
                        resDR["AvgCostPrice"] = dr["CostPricePerUnit"].ToString();
                        CurrentStock cs = (CurrentStock)currentDict[dr["Symbol"].ToString()];
                        resDR["CurrentMarketPrice"] = (cs.Price).ToString("c2");
                        resDR["Change"] = (((cs.Price - cs.PrevClose) * 100) / cs.PrevClose).ToString("000.00");
                        float valatCost = float.Parse(dr["Units"].ToString()) * float.Parse(dr["CostPricePerUnit"].ToString());
                        resDR["ValueAtCost"] = valatCost.ToString("c2");
                        float valatMarket = float.Parse(dr["Units"].ToString()) * cs.Price;
                        resDR["ValueAtMarket"] = valatMarket.ToString("c2");
                        resDR["Realized"] = dr["Realized"].ToString();
                        resDR["Unrealized"] = (valatMarket - valatCost).ToString("c2");
                        resDR["Action"] = "Buy | Sell";
                        resultDT.Rows.Add(resDR);
                    }
                    catch (Exception ex)
                    {
                    }
                   
                }
            }
            

            return resultDT;
        }

        public static void updatePortfolio(DataTable usrDt, String usrid)
        {
            String path = HttpContext.Current.Server.MapPath("~/DatabaseXML/UserStocks.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList xmlnode = doc.GetElementsByTagName("Stock");
            Boolean isAllDelete = true;
            while (isAllDelete)
            {
                isAllDelete = false;
                for (int i = 0; i < xmlnode.Count; i++)
                {

                    String userid = xmlnode[i].Attributes["UserID"].InnerText.ToString();
                    if (userid.Equals(usrid))
                    {
                        xmlnode[i].ParentNode.RemoveChild(xmlnode[i]);
                        isAllDelete = true;
                    }
                }
            }


            

            foreach (DataRow dr in usrDt.Rows)
            {
                XmlElement newStockentry = doc.CreateElement("Stock");
                XmlAttribute newuserattr = doc.CreateAttribute("UserID");
                newuserattr.Value = usrid;
                newStockentry.SetAttributeNode(newuserattr);
                XmlElement el1 = doc.CreateElement("Symbol");
                el1.InnerText = dr["Symbol"].ToString();
                newStockentry.AppendChild(el1);
                XmlElement el2 = doc.CreateElement("Units");
                el2.InnerText = dr["Quantity"].ToString();
                newStockentry.AppendChild(el2);
                XmlElement el3 = doc.CreateElement("CostPricePerUnit");
                el3.InnerText = dr["AvgCostPrice"].ToString();
                newStockentry.AppendChild(el3);
                XmlElement el4 = doc.CreateElement("Realized");
                el4.InnerText = dr["Realized"].ToString();
                newStockentry.AppendChild(el4);
                doc.DocumentElement.InsertAfter(newStockentry,doc.DocumentElement.LastChild);
            }

            doc.Save(path);
        }
    }
}