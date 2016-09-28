<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trading.aspx.cs" Inherits="iBank_Investor.Trading"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; position: relative">
        <div style="width: 100%; height: 100px">
            <div style="width: 70%; float: left">
                <font face="verdana" color="#659EC7" size="4"><b>New Order Form</b></font>
                <hr />
                <div>
                    <table style="width: 100%">
                        <tr>
                            <td class="style2">
                                <b>Exchange:</b>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="exchangeDropDown" runat="server">
                                    <asp:ListItem Text="NYSE" Value="NYSE">NYSE</asp:ListItem>
                                    <asp:ListItem Text="NSX" Value="NSX">NSX</asp:ListItem>
                                    <asp:ListItem Text="ISE" Value="ISE">ISE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <b>Ticker:</b>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="tickerTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td class="style2" align="right">
                                <b>Buy/Sell :</b>
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="actionDropDown" runat="server">
                                    <asp:ListItem Text="Buy" Value="Buy">Buy</asp:ListItem>
                                    <asp:ListItem Text="Sell" Value="Sell">Sell</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <b>Order Quantity</b>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="orderQty" runat="server"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <b>
                                    <asp:Label ID="Label1" runat="server" Text="Available Quantity" Visible="false"></asp:Label></b>
                            </td>
                            <td>
                                <asp:TextBox ID="availableQty" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width:100%;padding-top:10px;padding-left:150px">
                    <asp:Button ID="orderButton" runat="server" Text="Place Order" 
                        onclick="orderButton_Click" />
                </div>
                <div style="width:100%;padding-top:20px;padding-left:8px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="orderButton" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <div id="msgResult" runat="server" style="padding-top: 15px; padding-left:15px; background: while; height: 30px;width:70%;
                                border-color: black; border: 2px solid; border-radius: 25px;">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 25%; float: left; padding-left: 10px">
                <font face="verdana" color="#659EC7" size="4"><b>Ticker Quote</b></font>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Ticker"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="SearchTickerTextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="TickerButton1" runat="server" Text="Search" OnClick="TickerButton1_Click" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TickerButton1" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <div id="displayTicker" runat="server" style="padding: 15px; background: while; height: 150px;
                                border-color: black; border: 2px solid; border-radius: 25px;">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
        .style2
        {
            width: 93px;
        }
        .style3
        {
            width: 115px;
        }
        .style4
        {
            width: 175px;
        }
    </style>
</asp:Content>
