using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iBank_Investor.DataAccess;
using System.Data;
using System.IO;

namespace iBank_Investor
{
    public partial class Accounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           // if (!IsPostBack)
            //{
                float userBal = UserAccount.getBalance(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
                balanceLabel.Text = userBal.ToString("c2");
                string url = getWebServiceURL("accountdetails");
                url = url + "/" + Session["UserID"].ToString() + ".xml";
                RestClient rs = new RestClient(url, HttpVerb.GET);
                string stat = "";
                string accno = "";
                string resp = rs.MakeRequest(ref stat);

                if (stat != "200")
                {
                    Response.Redirect("ErrorAccounts.aspx");
                }
                else
                {

                    DataSet ds = new DataSet();
                    ds.ReadXml(new StringReader(resp));
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            accno = ds.Tables[0].Rows[0]["accountno"].ToString();
                        }
                    }
                }

                string[] accnums = accno.Split('|');
                DropDownList1.DataSource = accnums;
                DropDownList1.DataBind();
          //  }


        }

        protected void transferButton_Click(object sender, EventArgs e)
        {
            String msg = "";
            string statusCode = "";
            msg =  "<font face=\"verdana\" color=\"#F62217\" size=\"2\">In Progress</font>";
            txnResult.InnerHtml = msg;
            msg = "";
            try
            {
                float userBal = UserAccount.getBalance(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
                bool totransact = true;

                string url = getWebServiceURL("transactiondetails");
                string strtxtype = "credit";
                if (txnType.SelectedItem.Text == "From")
                {
                    strtxtype = "debit";
                }
                else
                {
                    strtxtype = "credit";
                    if (userBal < float.Parse(mvAmtTxtBox.Text))
                    {
                        totransact = false;
                    }
                }


                if (totransact)
                {
                    string xmpost = "<com.sample.iBank.rest.Resttransaction><userid>" + Session["UserID"].ToString() + "</userid><accountno>" + DropDownList1.SelectedValue + "</accountno>" + "<amt>" + mvAmtTxtBox.Text + "</amt><txnType>" + strtxtype + "</txnType></com.sample.iBank.rest.Resttransaction>";
                    RestClient rs = new RestClient(url, HttpVerb.POST, xmpost);
                    
                    String resp = rs.MakeRequest(ref statusCode);

                    if ((statusCode == "200" || statusCode == "201") && (resp == ""))
                    {
                        if (strtxtype == "credit")
                        {
                            userBal = userBal - float.Parse(mvAmtTxtBox.Text);
                        }
                        else
                        {
                            userBal = userBal + float.Parse(mvAmtTxtBox.Text);
                        }

                        UserAccount.updateBalance(Session["UserID"].ToString(), userBal);
                        msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Transaction is successful</font>";
                    }
                    else
                    {
                        if (statusCode == "452")
                        {
                            msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Transaction failed - Not enough funds</font>";
                        }
                        else
                        {
                            msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Transaction failed </font>";   
                        }
                    }
                }
                else
                {
                    msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Not enough balance in trading account to transfer</font>";
                }
                


                
            }
            catch (Exception ex)
            {
                msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Transaction failed : Incorrect Amount "+ex.StackTrace.ToString()+"</font>";
            }

            txnResult.InnerHtml = msg;
            float userBal2 = UserAccount.getBalance(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
            balanceLabel.Text = userBal2.ToString("c2");
            if (statusCode != "200")
            {
                Response.Redirect("ErrorAccounts.aspx");
            }
            

        }

        private string getWebServiceURL(string opr)
        {
            string wsurl = "";

            DataSet ds = Common.ReadXml(HttpContext.Current.Server.MapPath("~/DatabaseXML/Webservice.xml"));
            try
            {
                wsurl =  ds.Tables[0].Rows[0][opr].ToString();
            }
            catch(Exception ex)
            {}

            

            return wsurl;
        }
    }
}