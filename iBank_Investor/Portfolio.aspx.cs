using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iBank_Investor.DataAccess;
using System.Data;

namespace iBank_Investor
{
    public partial class Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["AccountNo"] != null)
                {
                    Accountlabel.Text = Session["AccountNo"].ToString();
                }
                else
                {
                    Accountlabel.Text = "";
                }

                GridView1.AutoGenerateColumns = false;

                DataTable dt = DataAccess.Portfolio.getPortfolioData(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserStocks.xml"), HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["UserStock"] = dt;
            }
            

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton buyClickButton = (LinkButton)e.Row.Cells[9].Controls[0];
                buyClickButton.Text = "Buy";
                LinkButton sellClickButton = (LinkButton)e.Row.Cells[10].Controls[0];
                sellClickButton.Text = "Sell";

                string buySingle = ClientScript.GetPostBackClientHyperlink(buyClickButton, "");
                string sellSingle = ClientScript.GetPostBackClientHyperlink(sellClickButton, "");
                // Add events to each editable cell

                e.Row.Cells[9].Attributes["onclick"] = buySingle.Insert(buySingle.Length - 2, "9"); ;
                // Add a cursor style to the cells
                e.Row.Cells[10].Attributes["style"] += "cursor:pointer;cursor:hand;";

                e.Row.Cells[9].Attributes["onclick"] = sellSingle.Insert(sellSingle.Length - 2, "10"); ;
                // Add a cursor style to the cells
                e.Row.Cells[10].Attributes["style"] += "cursor:pointer;cursor:hand;";                
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Buy")
            {
                                int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                                Response.Redirect("Trading.aspx?action=buy&id=" + selectedRowIndex);
                
                
            }
            if (e.CommandName.ToString() == "Sell")
            {
                int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("Trading.aspx?action=sell&id=" + selectedRowIndex);


            }
        }

        protected void gridRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.Portfolio.getPortfolioData(Session["UserID"].ToString(), HttpContext.Current.Server.MapPath("~/DatabaseXML/UserStocks.xml"), HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Session["UserStock"] = dt;
        }
    }




}