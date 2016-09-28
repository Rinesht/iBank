<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="iBank_Investor.Portfolio"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%;position:relative">
        
    <div style="width:100%;float:left">
        <font face="verdana" color="#659EC7" size="4"><b>Portfolio Tracker</b></font>
        <hr />
        <table style="width:100%">
            <tr>
                <td style="text-align:left">
                    <b>Account No. :</b><asp:Label ID="Accountlabel" runat="server" Text="Label"></asp:Label>
                </td>
                <td> </td>
                <td style="text-align:right">
                    <b>Export :</b> <asp:LinkButton ID="LinkButtonExcel" runat="server">Excel (Summary)</asp:LinkButton> |
                    <asp:LinkButton ID="LinkButtonCSV" runat="server">CSV (Summary)</asp:LinkButton> 
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="gridRefresh" runat="server" Text="Refresh" 
                        onclick="gridRefresh_Click" />
                </td>
            </tr>
        </table> 
        <hr />
    </div>

    <div style="width:100%;float:left; padding-top:10px;background-color:">
        <asp:GridView ID="GridView1" runat="server" GridLines="Both" CellPadding="10" Font-Size="10" AllowSorting="true" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
		<rowstyle backcolor="White"  />

        <alternatingrowstyle backcolor="#EBF4FA" />
            <Columns>
                <asp:BoundField HeaderText="Ticker" DataField="Symbol">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Average Cost Price" DataField="AvgCostPrice">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Current Market price" DataField="CurrentMarketPrice">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="%Change over prev. close" DataField="Change">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Value at Cost" DataField="ValueAtCost">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Value at Market price" DataField="ValueAtMarket">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Realized Profit/Loss" DataField="Realized">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Unrealized Profit/Loss" DataField="Unrealized">
                <HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium"/>
                </asp:BoundField>
               
                <asp:buttonfield HeaderText="Action-Buy" commandname="Buy" visible="true"><HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium" /></asp:buttonfield>
                <asp:buttonfield HeaderText="Action-Sell" commandname="Sell" visible="true"><HeaderStyle BackColor="#79BAEC" BorderStyle="Solid" Font-Bold="True" 
                    Font-Names="Calibri" ForeColor="White" BorderColor="Black" Font-Size="Medium" /></asp:buttonfield>
            </Columns>

        </asp:GridView>

    </div>
       
        
    
    </div>
</asp:Content>
