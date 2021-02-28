<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColorConverter.aspx.cs" Inherits="Assign04.ColorConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Cache-control" content="no-cache" />
    <title>Assign04 - Color Converter</title>
    <style>
        #red-row {
            background-color: red;
        }
        #green-row {
            background-color: green;
        }
        #blue-row {
            background-color: blue;
        }
        td {
            text-align: center;
        }
        #header-image {
            height: 200px;
            width: 100%;
        }
        body {
            background: linear-gradient(to right, orange , yellow, green, cyan, blue, violet);
        }
        #form1 {
            color: #fff;
        }
        #form-bg {
            background-color: rgba(0,0,0,.4);
            border-radius: 5px;
            padding: 15px;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="form-bg">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width:1500px;" border="0">
                        <tr>
                            <td colspan="14" style="text-align: left;"><h1>Color Values</h1></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="8"><div style="text-align:center;">Binary Digits</div></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>Decimal Value </td>
                            <td>Hex Value </td>
                            <td><div style="text-align:center;">Color</div></td>
                        </tr>
                        <!-- Red -->
                        <tr>
                            <td id="red-row"></td>
                            <td>
                                <asp:DropDownList ID="red8" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red7" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red6" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red5" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red4" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red3" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red2" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="red1" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>=</td>
                            <td><asp:TextBox ID="rDecText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                            <td><asp:TextBox ID="rHexText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                        </tr>
                        <!-- Red -->
                        <!-- Green -->
                        <tr>
                            <td id="green-row"></td>
                            <td>
                                <asp:DropDownList ID="green8" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green7" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green6" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green5" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green4" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green3" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green2" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="green1" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>=</td>
                            <td><asp:TextBox ID="gDecText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                            <td><asp:TextBox ID="gHexText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                            <asp:TableCell rowspan="2" ID="bgColor" runat="server" BackColor="Black" Width="200" BorderStyle="Solid" BorderWidth="3" BorderColor="Black"></asp:TableCell>
                        </tr>
                        <!-- Green -->
                        <!-- Blue -->
                        <tr>
                            <td id="blue-row"></td>
                            <td>
                                <asp:DropDownList ID="blue8" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue7" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue6" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue5" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue4" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue3" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue2" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="blue1" OnSelectedIndexChanged="ValueChanged" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="0" text="0" />
                                    <asp:ListItem value="1" text="1" />
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>=</td>
                            <td><asp:TextBox ID="bDecText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                            <td><asp:TextBox ID="bHexText" Width="100" runat="server" Text="00"></asp:TextBox></td>
                        </tr>
                        <!-- Blue -->
                        <tr>
                            <td></td>
                        </tr>
                        <!-- Bitwise Operation -->
                        <tr>
                            <td colspan="9"><h1 style="text-align: right;">Bitwise Operation:</h1></td>
                            <td colspan="3" style="text-align:center; vertical-align:bottom;">
                                <asp:DropDownList ID="bit1" OnSelectedIndexChanged="CalculateBitwiseValue" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="--" text="--" />
                                    <asp:ListItem value="R" text="R" />
                                    <asp:ListItem value="G" text="G" />
                                    <asp:ListItem value="B" text="B" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="bit2" OnSelectedIndexChanged="CalculateBitwiseValue" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="--" text="--" />
                                    <asp:ListItem value="&" text="&" />
                                    <asp:ListItem value="|" text="|" />
                                    <asp:ListItem value="^" text="^" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="bit3" OnSelectedIndexChanged="CalculateBitwiseValue" AutoPostBack="true" runat="server">
                                    <asp:ListItem value="--" text="--" />
                                    <asp:ListItem value="R" text="R" />
                                    <asp:ListItem value="G" text="G" />
                                    <asp:ListItem value="B" text="B" />
                                </asp:DropDownList>
                            </td>
                            <td style="vertical-align:bottom; text-align: center;">
                                <asp:Label ID="bitEqual" runat="server" Text="="></asp:Label> 
                            </td>
                            <td style="vertical-align:bottom;">
                                <asp:TextBox ID="bitwiseResult" Width="100" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
