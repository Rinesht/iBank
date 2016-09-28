using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iBank_Investor.DataAccess;


namespace iBank_Investor
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public static Int64 DowIntial = 16606;
        public static Int64 nasdaqInitial = 4500;


        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                String str = Session["UserName"].ToString();
                if ( str == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else {
                    Label2.Text = Session["UserName"].ToString();
                }

                
            }
            
        }

        private void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                String str = Session["UserName"].ToString();
                if (str == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label2.Text = Session["UserName"].ToString();
                }


            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int val = rnd.Next(-100, 100);
            int val2 = rnd.Next(-30, 30);
            String imgStrDow = "";
            String imgStrNasdaq = "";
            if (val < 0)
            {

                imgStrDow = "<img style=\"width:15px; height:15px\" src=\"Images/down.JPG\" />";
            }
            else
            {
                imgStrDow = "<img style=\"width:15px; height:15px\" src=\"Images/up.JPG\" />";
            }
            if (val2 < 0)
            {

                imgStrNasdaq = "<img style=\"width:15px; height:15px\" src=\"Images/down.JPG\" />";
            }
            else
            {
                imgStrNasdaq = "<img style=\"width:15px; height:15px\" src=\"Images/up.JPG\" />";
            }
            DowIntial = DowIntial + val;
            nasdaqInitial = nasdaqInitial + val2;
            marketID.InnerHtml = "<b> DOW</b>: " + (DowIntial ).ToString() + "&nbsp;" + imgStrDow + "&nbsp;&nbsp;&nbsp;<b>NASDAQ</b>:" + (nasdaqInitial ).ToString() + "&nbsp;" + imgStrNasdaq;

            Common.updateStock(HttpContext.Current.Server.MapPath("~/DatabaseXML/CurrentStock.xml"));

        }

        
    }
}
