using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iBank_Investor.DataAccess;

namespace iBank_Investor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = UserAccount.isLoginAccess(Login1.UserName, Login1.Password, HttpContext.Current.Server.MapPath("~/DatabaseXML/Login.xml"));
            if (e.Authenticated == true)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}