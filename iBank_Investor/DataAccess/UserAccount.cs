using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;

namespace iBank_Investor.DataAccess
{
    public class UserAccount
    {

        public static Boolean isLoginAccess(String userID, String password, String loginpath, Boolean isTest=false)
        {
            Boolean isAccess = false;
            DataSet ds = Common.ReadXml(loginpath);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["UserID"].ToString().Equals(userID.ToString()) &&  dr["Password"].ToString().Equals(password.ToString()))
                        {
                            isAccess = true;
                            if (!isTest)
                            {
                                HttpContext.Current.Session.Add("UserName", dr["UserName"].ToString());
                                HttpContext.Current.Session.Add("AccountNo", dr["Account"].ToString());
                                HttpContext.Current.Session.Add("UserID", dr["UserID"].ToString());
                            }
                            break;
                        }
                    }
                }
            }

            return isAccess;
        }


        public static float getBalance(String userID, string accountpath)
        {
            float bal = 0;
            DataSet ds = Common.ReadXml(accountpath);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["UserID"].ToString().Equals(userID.ToString()))
                        {
                            try
                            {
                                bal = float.Parse(dr["Balance"].ToString());
                            }
                            catch (Exception e)
                            {
                            }
                            break;
                        }
                    }
                }
            }

            return bal;
        }

        public static void updateBalance(String userID, float bal)
        {
            
            

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
            XmlNodeList xmlnode = doc.GetElementsByTagName("Account");
            

            for (int i = 0; i < xmlnode.Count; i++)
            {
                String usrid = xmlnode[i].Attributes["UserID"].InnerText.ToString();
                if (usrid.Equals(userID))
                {
                    xmlnode[i]["Balance"].InnerText = bal.ToString("0.00");
                    break;
                }
                
                
            }

            doc.Save(HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
            

           
        }

    }
}