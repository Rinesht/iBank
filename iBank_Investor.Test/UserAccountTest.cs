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
    class UserAccountTest
    {
         [TestCase("AJ9902", "Passw0rd", "Positive")]
         [TestCase("NOTTHERE", "NoPASSWORD", "Negative")]
         [TestCase("AJ9902", "WRONGPASSWORD", "Negative")]
         public void LoginAccessTest(String userid, String password, String testType)
         {
             Boolean isAccess = iBank_Investor.DataAccess.UserAccount.isLoginAccess(userid, password, "C:/Enterprise Agility/iBank_Investor/DatabaseXML/Login.xml", true);
             if (testType.Equals("Positive"))
             {
                 Assert.AreEqual(isAccess, true);
             }
             else
             {
                 Assert.AreEqual(isAccess, false);
             }           
            

         }

         [TestCase("AJ9902", "Positive")]
         [TestCase("NOUSER", "Negative")]
         [TestCase("AJ9902", "Exception")]
         public void GetBalanceTest(String userid, String testType)
         {

             float bal = iBank_Investor.DataAccess.UserAccount.getBalance(userid, "C:/Enterprise Agility/iBank_Investor/DatabaseXML/UserAccount.xml");
             if (testType.Equals("Positive"))
             {
                 
                 Assert.Greater(bal, 0.0f);
             }
             else if(testType.Equals("Negative"))
             {
                 Assert.AreEqual(bal, 0.0f);
             }
             else if (testType.Equals("Exception"))
             {
                 bal = iBank_Investor.DataAccess.UserAccount.getBalance(userid, "C:/Enterprise Agility/iBank_Investor/DatabaseXML/UserAccountError.xml");
                 Assert.AreEqual(bal, 0.0f);
             }
         }
    }
}
