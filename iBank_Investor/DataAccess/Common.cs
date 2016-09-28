using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using iBank_Investor.DataObject;
using System.Xml;

namespace iBank_Investor.DataAccess
{
    public class Common
    {
        public static DataSet ReadXml(string xmlpath)
        {
            DataSet dsXml = new DataSet();
            dsXml.Clear();
            dsXml.ReadXml(xmlpath);
            return dsXml;
        }

        public static Dictionary<String, CurrentStock> getCurrentStocks(String path)
        {
            Dictionary<String, CurrentStock> dict = new Dictionary<String, CurrentStock>();

            DataSet ds = ReadXml(path);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        try
                        {
                            CurrentStock cs = new CurrentStock();
                            cs.Symbol = dr["Symbol"].ToString();
                            cs.Price = float.Parse(dr["Price"].ToString());
                            cs.PrevClose = float.Parse(dr["PrevClose"].ToString());
                            cs.AvailableQty = float.Parse(dr["AvailableQuantity"].ToString());
                            cs.Name = dr["Name"].ToString();
                            dict.Add(cs.Symbol, cs);
                        }
                        catch (Exception ex)
                        {
                        }
                       
                        
                    }
                }
            }

            return dict;    
        }

        public static void updateStock(String path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList xmlnode = doc.GetElementsByTagName("Stock");
            Random rnd = new Random();
            
            for (int i = 0; i < xmlnode.Count; i++)
            {
                XmlNode anode = xmlnode[i].SelectSingleNode("Stock");
                String curPrice = xmlnode[i]["Price"].InnerText;
                float val = rnd.Next(-20, 100);
                float adjPrice = float.Parse(curPrice) + (val/100);
                if (adjPrice < 2)
                {
                    adjPrice = float.Parse(xmlnode[i]["PrevClose"].InnerText.ToString()) - 1;
                }
                xmlnode[i]["Price"].InnerText = adjPrice.ToString("0.00");
            }

            doc.Save(path);

        }
    }
}