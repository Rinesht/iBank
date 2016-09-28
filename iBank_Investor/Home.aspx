<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="iBank_Investor.Home"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div style="position:relative; width:100%">
    <div style="height: 50px;width:65%;position:relative;float:left ">
        <div style="width: 100%;  padding: 5px">
            <img src="Images/buySell.JPG" style="width: 700px; height: 100px" />
        </div>
        <div style="width:30%;float:left"">
        <font face="verdana" color="#659EC7" size="4"><b>New to investing?</b></font>
        <p style="margin:0em"><font face="verdana" color="black" size="2"><b>Learn how to invest in Stock Market and other investment vehicles</b></font></p>
        
        <ul style="line-height:120%; margin-left: 0;padding-left: 10px;">
            
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Investing! What's that?</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Why have derivatives?</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Practice trading! - No Risk, No Obligation</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">What is a Mutual Fund</font></a></li>
        </ul>
       
        </div>
         <div style="width:30%;float:left; padding-left:15px"">
        <font face="verdana" color="#659EC7" size="4"><b>About iBank Investor Account</b></font>
        <p style="margin:0em"><font face="verdana" color="black" size="2"><b>A unique account that integrates Equity, Mutual Funds and Deposits</b></font></p>
        
        <ul style="line-height:120%; margin-left: 0;padding-left: 10px;">
            
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">About the Account</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Product & Services</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Basics of Trading & Investing</font></a></li>
               <li ><a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2">Awards & Accolades</font></a></li>
        </ul>
       
        </div>
    </div>
    <div style="height: 50px;width:35%;float:right; position:relative; padding-top:20px ">
        <div style="width: 20%;  float:left">
            <img src="Images/poll.JPG" style="width: 70px; height: 70px" />
        </div>
        <div style="width: 80%;  float:left; display:inline">
        <font face="verdana" color="Black" size="3"><b>Quick Poll </b></font>
           <p style="margin-top: 2px; "> <a href="#" style="text-decoration:none;"><font face="verdana" color="#659EC7" size="2"><b>How are you reacting to the current market? </b></font></a></p>
           <p style="margin-top: 1px; ">
           
           <font face="verdana" color="Black" size="2">
               <asp:RadioButtonList ID="RadioButtonList1" runat="server">
               <asp:ListItem>I think, It is a great time to buy equity. </asp:ListItem>
               <asp:ListItem>I much rather wait than invest now in equity  </asp:ListItem>
               <asp:ListItem>I think, it is time to sell and buy later  </asp:ListItem>
               <asp:ListItem>I am not sure, what I should be doing. </asp:ListItem>
               </asp:RadioButtonList>
           </font>
           </p>
        </div>
    </div>
    </div>
</asp:Content>
