<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="iBank_Investor.Accounts" MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="transferButton" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
    <div style="width: 100%; position: relative">
         
        <div style="width: 70%; height: 20px; float:left; padding-top:10px; padding-left:10px;">
            <font face="verdana" color="#659EC7" size="2"><b>Current Balance :</b></font> <asp:Label ID="balanceLabel" runat="server" Text=""></asp:Label>
                <hr />
        </div>
        <div style="width: 70%; float:left; padding-top:30px; padding-left:10px;">
            <font face="verdana" color="#659EC7" size="4"><b>Fund Transfer </b></font>
                <hr />
        </div>
        <div style="width: 70%; height: 100px; float:left; padding-top:10px; padding-left:10px;">
            <table>
                <tr>
                    <td>I would like to move $:</td><td><asp:TextBox ID="mvAmtTxtBox" runat="server"></asp:TextBox></td>
                    <td>
                    <asp:radiobuttonlist id="txnType" runat="server" Width="87px">
                        <asp:ListItem >To </asp:ListItem>  
                        <asp:ListItem>From</asp:ListItem>  
                    
                    </asp:radiobuttonlist>
                    </td>
                </tr>
                <tr>
                    <td>iBank Account Number:</td><td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        
                    </asp:DropDownList>
                    </td><td></td>                    
                </tr>
                
            </table>
            <div style="width:70%;padding-left:150px;padding-top:20px">
                <asp:Button ID="transferButton" runat="server" Text="Transfer" 
                    onclick="transferButton_Click" />
            </div>
        </div>
         <div style="width:70%;padding-top:40px;padding-left:10px; float:left;">
                   
                            <div id="txnResult" runat="server" style="padding-top: 15px; padding-left:15px; background: while; height: 30px;width:70%;
                                border-color: black; border: 2px solid; border-radius: 25px;">
                            </div>
                       
                </div>
    </div>
     </ContentTemplate>
                    </asp:UpdatePanel>
</asp:Content>
