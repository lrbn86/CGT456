<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Assign02.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #container {
            background-color: #ccffff; width: 800px; height: 600px;
        }
        #Label1 {
            position: absolute;
            top: 95px;
            left: 360px;
        }
        #Label2 {
            position: absolute;
            top: 145px;
            left: 340px;
        }
        #lblfName {
            position: absolute;
            top: 205px;
            left: 240px;
        }
        #lbllName {
            position: absolute;
            top: 245px;
            left: 240px;
        }
        #lblcity {
            position: absolute;
            top: 290px;
            left: 280px;
        }
        #lblzip {
            position: absolute;
            top: 365px;
            left: 280px;
            height: 19px;
            width: 30px;
        }
        #fName {
            position: absolute;
            top: 205px;
            left: 320px;
        }
        #lName {
            position: absolute;
            top: 245px;
            left: 320px;
        }
        #city {
            position: absolute;
            top: 290px;
            left: 320px;
        }
        #zip {
            position: absolute;
            top: 365px;
            left: 320px;
        }
        #lblstate {
            position: absolute;
            top: 325px;
            left: 275px;
        }
        #state {
            position: absolute;
            top: 325px;
            left: 320px;
        }
        #Button1 {
            position: absolute;
            top: 430px;
            left: 380px;
        }
        #myName {
            position: absolute;
            top: 40px;
            left: 620px;
            width: 150px;
        }
        #results {
            position: absolute;
            top: 170px;
            left: 210px;
            height: 310px;
            width: 405px;
            background-color: #fff;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <asp:Label ID="Label1" runat="server" Text="Assign02" Font-Bold="True" Font-Size="30px"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="IDE Usage and Intro" Font-Bold="True"></asp:Label>

            <asp:Label ID="lblfName" runat="server" Text="First Name: "></asp:Label>
            <asp:Label ID="lbllName" runat="server" Text="Last Name: "></asp:Label>
            <asp:Label ID="lblcity" runat="server" Text="City: "></asp:Label>
            <asp:Label ID="lblzip" runat="server" Text="Zip: "></asp:Label>

            <asp:TextBox ID="fName" runat="server" Width="195px"></asp:TextBox>
            <asp:TextBox ID="lName" runat="server" Width="195px"></asp:TextBox>
            <asp:TextBox ID="city" runat="server" Width="195px"></asp:TextBox>
            <asp:TextBox ID="zip" runat="server" Width="195px"></asp:TextBox>

            <asp:Label ID="lblstate" runat="server" Text="State: "></asp:Label>
            <asp:DropDownList ID="state" runat="server">
                <asp:ListItem Value="--" Text="None - not in U.S."></asp:ListItem>
                <asp:ListItem Value="AL" Text="Alabama"></asp:ListItem>
                <asp:ListItem Value="AK" Text="Alaska"></asp:ListItem>
                <asp:ListItem Value="AS" Text="American Samoa"></asp:ListItem>
                <asp:ListItem Value="AZ" Text="Arizona"></asp:ListItem>
                <asp:ListItem Value="AR" Text="Arkansas"></asp:ListItem>
                <asp:ListItem Value="CA" Text="California"></asp:ListItem>
                <asp:ListItem Value="CO" Text="Colorado"></asp:ListItem>
                <asp:ListItem Value="CT" Text="Connecticut"></asp:ListItem>
                <asp:ListItem Value="DE" Text="Delaware"></asp:ListItem>
                <asp:ListItem Value="DC" Text="District of Columbia"></asp:ListItem>
                <asp:ListItem Value="FM" Text="Federated States of Micronesia"></asp:ListItem>
                <asp:ListItem Value="FL" Text="Florida"></asp:ListItem>
                <asp:ListItem Value="GA" Text="Georgia"></asp:ListItem>
                <asp:ListItem Value="GU" Text="Guam"></asp:ListItem>
                <asp:ListItem Value="HI" Text="Hawaii"></asp:ListItem>
                <asp:ListItem Value="ID" Text="Idaho"></asp:ListItem>
                <asp:ListItem Value="IL" Text="Illinios"></asp:ListItem>
                <asp:ListItem Value="IN" Text="Indiana"></asp:ListItem>
                <asp:ListItem Value="IA" Text="Iowa"></asp:ListItem>
                <asp:ListItem Value="KS" Text="Kansas"></asp:ListItem>
                <asp:ListItem Value="KY" Text="Kentucky"></asp:ListItem>
                <asp:ListItem Value="LA" Text="Louisiana"></asp:ListItem>
                <asp:ListItem Value="ME" Text="Maine"></asp:ListItem>
                <asp:ListItem Value="MH" Text="Marshall Islands"></asp:ListItem>
                <asp:ListItem Value="MD" Text="Maryland"></asp:ListItem>
                <asp:ListItem Value="MA" Text="Massachusetts"></asp:ListItem>
                <asp:ListItem Value="MI" Text="Michigan"></asp:ListItem>
                <asp:ListItem Value="MN" Text="Minnesota"></asp:ListItem>
                <asp:ListItem Value="MS" Text="Mississippi"></asp:ListItem>
                <asp:ListItem Value="MO" Text="Missouri"></asp:ListItem>
                <asp:ListItem Value="MT" Text="Montana"></asp:ListItem>
                <asp:ListItem Value="NE" Text="Nebraska"></asp:ListItem>
                <asp:ListItem Value="NV" Text="Nevada"></asp:ListItem>
                <asp:ListItem Value="NH" Text="New Hampshire"></asp:ListItem>
                <asp:ListItem Value="NJ" Text="New Jersey"></asp:ListItem>
                <asp:ListItem Value="NM" Text="New Mexico"></asp:ListItem>
                <asp:ListItem Value="NY" Text="New York"></asp:ListItem>
                <asp:ListItem Value="NC" Text="North Carolina"></asp:ListItem>
                <asp:ListItem Value="ND" Text="North Dakota"></asp:ListItem>
                <asp:ListItem Value="MP" Text="Northern Mariana Islands"></asp:ListItem>
                <asp:ListItem Value="OH" Text="Okio"></asp:ListItem>
                <asp:ListItem Value="OK" Text="Oklahoma"></asp:ListItem>
                <asp:ListItem Value="OR" Text="Oregon"></asp:ListItem>
                <asp:ListItem Value="PW" Text="Palau"></asp:ListItem>
                <asp:ListItem Value="PA" Text="Pennsulvania"></asp:ListItem>
                <asp:ListItem Value="PR" Text="Puerto Rico"></asp:ListItem>
                <asp:ListItem Value="RI" Text="Rhode Island"></asp:ListItem>
                <asp:ListItem Value="SC" Text="South Carolina"></asp:ListItem>
                <asp:ListItem Value="SD" Text="South Dakota"></asp:ListItem>
                <asp:ListItem Value="TN" Text="Tennessee"></asp:ListItem>
                <asp:ListItem Value="TX" Text="Texas"></asp:ListItem>
                <asp:ListItem Value="UT" Text="Utah"></asp:ListItem>
                <asp:ListItem Value="VT" Text="Vermont"></asp:ListItem>
                <asp:ListItem Value="VI" Text="Virgin Islands"></asp:ListItem>
                <asp:ListItem Value="VA" Text="Virginia"></asp:ListItem>
                <asp:ListItem Value="WA" Text="Washington"></asp:ListItem>
                <asp:ListItem Value="WV" Text="West Virginia"></asp:ListItem>
                <asp:ListItem Value="WI" Text="Wisconsin"></asp:ListItem>
                <asp:ListItem Value="WY" Text="Wyoming"></asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

            <asp:Label ID="myName" runat="server" Text="Label"></asp:Label>

            <asp:Label ID="results" runat="server" Text="Label"></asp:Label>

            <asp:HyperLink ID="HyperLink1" NavigateUrl="table.aspx" runat="server">Click here to go to table.aspx</asp:HyperLink>
        </div>
    </form>
</body>
</html>
