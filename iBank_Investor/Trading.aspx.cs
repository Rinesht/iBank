using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iBank_Investor.DataAccess;
using iBank_Investor.DataObject;

namespace iBank_Investor
{
    public partial class Trading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null && Request.QueryString["id"] != null && Session["UserStock"] != null)
                {
                    DataTable uDS = (DataTable)Session["UserStock"];
                    String ticker = "";
                    String availQty = "";
                    if (Request.QueryString["id"] != "")
                    {
                        try
                        {
                            int index = int.Parse(Request.QueryString["id"]);
                            ticker = uDS.Rows[index]["Symbol"].ToString();
                            availQty = uDS.Rows[index]["Quantity"].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (Request.QueryString["action"].ToString() == "buy")
                    {
                        actionDropDown.SelectedItem.Text = "Buy";
                        tickerTextBox.Text = ticker;
                        Label1.Visible = false;
                        availableQty.Visible = false;
                    }
                    if (Request.QueryString["action"].ToString() == "sell")
                    {
                        actionDropDown.SelectedItem.Text = "Sell";
                        tickerTextBox.Text = ticker;
                        availableQty.Text = availQty;
                        Label1.Visible = true;
                        availableQty.Visible = true;
                    }

                    displayTicker.InnerHtml = getTickerQuoteHTML(ticker);

                }
            }
        }


        private String getTickerQuoteHTML(String tck)
        {
            String msg = "";

            Dictionary<String, CurrentStock> dict = Common.getCurrentStocks(HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
            if (dict.ContainsKey(tck))
            {
                CurrentStock cs = dict[tck];
                String tickerName = cs.Symbol;
                String cPrice = cs.Price.ToString("c2");
                float diffPrice = (cs.Price - cs.PrevClose);
                String diff = (diffPrice * 100 / cs.PrevClose).ToString("0.00") + "%";
                String img = "";
                String fontcolor = "";
                if (diffPrice < 0)
                {
                    img = "<img style=\"width:15px; height:15px\" src=\"Images/down.JPG\" />";
                    fontcolor = "#F62217";
                }
                else
                {
                    img = "<img style=\"width:15px; height:15px\" src=\"Images/up.JPG\" />";
                    fontcolor = "#348017";
                }

                msg = msg + "<font face=\"verdana\" color=\"#659EC7\" size=\"6\"><b>" + tickerName + "</b></font>";
                msg = msg + "<p><font face=\"verdana\" color=\"Black\" size=\"3\">" + cs.Name + "</font></p>";
                msg = msg + "<table><tr><td><font face=\"verdana\" color=\"#659EC7\" size=\"2\"><b>Market Price :&nbsp;</b>" + cPrice + "</font></td></tr>";
                msg = msg + "<tr><td><b>Change :&nbsp;</b><font face=\"verdana\" color=\"" + fontcolor + "\" size=\"2\">" + diff + "</font>&nbsp;" + img + "</td></tr></table>";

            }

            return msg;
        }

        protected void TickerButton1_Click(object sender, EventArgs e)
        {
            displayTicker.InnerHtml = getTickerQuoteHTML(SearchTickerTextBox1.Text.ToString());
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            Boolean isQtyCorrect = true;
            String msg = "";
            int orderQtyVal = 0;
            try
            {
                orderQtyVal = int.Parse(orderQty.Text);
                if (orderQtyVal <= 0)
                {
                    throw (new Exception());
                }
            }
            catch (Exception ex)
            {
                msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Incorrect quantity.</font>";
                isQtyCorrect = false;
            }

            if (isQtyCorrect)
            {
                Dictionary<String, CurrentStock> dict = Common.getCurrentStocks(HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
                CurrentStock cs = null;
                
            if (dict.ContainsKey(tickerTextBox.Text.ToString()))
            {
                cs = dict[tickerTextBox.Text.ToString()];
                float userBal = UserAccount.getBalance(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserAccount.xml"));
                float reqdAmt = orderQtyVal * cs.Price;

                if (actionDropDown.SelectedItem.Text.Equals("Buy"))
                {
                    if (reqdAmt > userBal)
                    {
                        msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Sufficient balance is not available to buy the stock of required quantity</font>";
                    }
                    else
                    {
                        userBal = userBal - reqdAmt;

                        DataTable dt = DataAccess.Portfolio.getPortfolioData(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserStocks.xml"), HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
                        Boolean isStockAvailable = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Symbol"].ToString().Equals(tickerTextBox.Text.ToString()))
                            {
                                isStockAvailable = true;
                                float totQty = float.Parse(dr["Quantity"].ToString()) + orderQtyVal;

                                float avgPrice = (((float.Parse(dr["AvgCostPrice"].ToString()) * float.Parse(dr["Quantity"].ToString())) + (cs.Price * orderQtyVal))) / (totQty);
                                dr["Quantity"] = totQty.ToString("0.00");
                                dr["AvgCostPrice"] = avgPrice.ToString("0.00");
                            }
                        }
                        if (!isStockAvailable)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Symbol"] = tickerTextBox.Text.ToString();
                            dr["Quantity"] = orderQtyVal.ToString("0.00");
                            dr["AvgCostPrice"] = cs.Price.ToString("0.00");
                            dr["CurrentMarketPrice"] = (cs.Price).ToString("c2");
                            dr["Change"] = "0";                           
                            dr["ValueAtCost"] = reqdAmt.ToString("0.00");                            
                            dr["ValueAtMarket"] = reqdAmt.ToString("0.00");
                            dr["Realized"] = "0";
                            dr["Unrealized"] = "0";
                            dr["Action"] = "Buy | Sell";
                            dt.Rows.Add(dr);
                        }
                        DataAccess.Portfolio.updatePortfolio(dt, Session["UserID"].ToString());
                        UserAccount.updateBalance(Session["UserID"].ToString(), userBal);
                        msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Order executed successfully</font>";
                    }
                }
                if (actionDropDown.SelectedItem.Text.Equals("Sell"))
                {
                    Boolean toProcess = true;

                    DataTable dt = DataAccess.Portfolio.getPortfolioData(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserStocks.xml"), HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
                    Boolean isStockAvailable = false;
                    float totQty = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Symbol"].ToString().Equals(tickerTextBox.Text.ToString()))
                        {
                            isStockAvailable = true;
                            totQty = float.Parse(dr["Quantity"].ToString()) - orderQtyVal;                           
                            dr["Quantity"] = totQty.ToString("0.00");
                            float realiz = (cs.Price * orderQtyVal)  - (float.Parse(dr["AvgCostPrice"].ToString()) * orderQtyVal);
                            dr["Realized"] = (float.Parse( dr["Realized"].ToString())+realiz).ToString("0.00"); 
                        }
                    }


                    if (!isStockAvailable)
                    {
                        msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Stock not available in your account</font>";
                        toProcess = false;                       
                    }

                    if (totQty < 0)
                    {
                        msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Sufficient stocks are not available in your account</font>";
                        toProcess = false; 
                    }

                    if (toProcess)
                    {
                        userBal = userBal + reqdAmt;
                        DataAccess.Portfolio.updatePortfolio(dt, Session["UserID"].ToString());
                        UserAccount.updateBalance(Session["UserID"].ToString(), userBal);
                        msg = msg + "<font face=\"verdana\" color=\"#348017\" size=\"2\">Order executed successfully</font>";
                    }                  


                }

            }
            else
            {
                msg = msg + "<font face=\"verdana\" color=\"#F62217\" size=\"2\">Ticker not available!</font>";
            }
               
                

            }
            msgResult.InnerHtml = msg;
        }

    }
}