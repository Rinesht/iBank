<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iBank_Investor.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 122px;
            height: 93px;
        }
        .style4
        {
            width: 14%;
        }
        .style5
        {
            width: 35%;
        }
        .style6
        {
            width: 496px;
            height: 76px;
        }
        .style9
        {
            width: 18%;
        }
        .style10
        {
            width: 110px;
        }
        .style11
        {
            width: 12%;
        }
        .style12
        {
            width: 196px;
            height: 164px;
        }
        .style13
        {
            width: 194px;
            height: 162px;
        }
        .style14
        {
            width: 16%;
        }
        .style15
        {
            width: 802px;
            height: 129px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <table>
    
    <tr>
    <td class="style4">
        <img class="style3" src="Images/image1.jpg" /></td>
        <td class="style5">
            <img class="style6" src="Images/name2.JPG" /></td>
        <td class="style14">&nbsp;</td>
            <td  valign="bottom" class="style10"><asp:Label ID="Label1" runat="server" Text="Label" font-bold="true"></asp:Label></td>
            </tr>
         </table>
         <hr />
         <table>
            
      <tr>
    <td class="style11">
        <asp:Login ID="Login1" runat="server" Height="170px" 
        onauthenticate="Login1_Authenticate" TitleText="Customer Login Page ALI1" Width="379px" 
            BackColor="#B3CBFF" UserNameLabelText="User ID :">
        <LabelStyle Font-Bold="True" Font-Names="Calibri" />
        <LoginButtonStyle Font-Bold="True" />
        <TitleTextStyle Font-Bold="True" Font-Names="Engravers MT" Font-Size="Large" />
    </asp:Login></td>
    <td class="style9">&nbsp;</td>
   <td class="style9"> 
       <img class="style12" src="Images/imagesCAM9KF7G.jpg" /></td>
       <td><img class="style13" 
           src="Images/imagesCAHR3VEG.jpg" /></td>
    </tr>
    </table>
        </div>
    </form>
      
    <script type="text/javascript">

        function show() {
            var Digital = new Date()
            var hours = Digital.getHours()
            var minutes = Digital.getMinutes()
            var seconds = Digital.getSeconds()
            var day = Digital.getDay();
            var date = Digital.getDate();
            var mon = Digital.getMonth();
            var year = Digital.getFullYear();

            var dn = "AM"
            if (hours > 12) {
                dn = "PM"
                hours = hours - 12
            }
            if (hours == 0)
                hours = 12
            if (minutes <= 9)
                minutes = "0" + minutes
            if (seconds <= 9)
                seconds = "0" + seconds

            var txtDay = "Sunday";
            if (day == 1)
                txtDay = "Monday"
            if (day == 2)
                txtDay = "Tuesday"
            if (day == 3)
                txtDay = "Wednesday"
            if (day == 4)
                txtDay = "Thursday"
            if (day == 5)
                txtDay = "Friday"
            if (day == 6)
                txtDay = "Saturday"
            if (day == 7)
                txtDay = "Sunday"

            document.getElementById("Label1").innerHTML = txtDay+", "+ (mon+1) + "-"+date+"-"+year +"   " + hours + ":" + minutes + ":" + seconds + " " + dn
            setTimeout("show()", 1000)
        }
        show()

</script>
<hr />
    <p>
        <img class="style15" src="Images/tradetips.JPG" /></p>

    </body>
</html>
