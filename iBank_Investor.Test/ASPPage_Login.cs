using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using iBank_Investor.DataAccess;
using System.Data;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;

namespace iBank_Investor.Test
{
    [TestFixture]
    class ASPPage_Login : NUnit.Extensions.Asp.WebFormTester
    {
        private TextBoxTester username;
        private TextBoxTester password;
        private ButtonTester loginbutton;

       
       
         
        [SetUp]
        protected void SetUp()
        {
            
            Browser.GetPage("http://localhost:2092/Login.aspx");
            username = new TextBoxTester("Login1_UserName");
            password = new TextBoxTester("Login1_Password");
            loginbutton = new ButtonTester("Login1_LoginButton");


            

             
            
        }

        [Test]
        public void TestLayout()
        {

        }

    }

}
