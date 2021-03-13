<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blackjack.aspx.cs" Inherits="Project1.Blackjack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Blackjack</title>
	<link rel="stylesheet" href="styles.css"/>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel id="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div>
					Status: <asp:Label ID="GameStatusMessage" runat="server"></asp:Label>
				</div>
				<div>
					Bank: $<asp:Label id="BankAmount" runat="server"></asp:Label>
				</div>
				<div>Dealer's Current Hand: <asp:Label ID="DealerHand" runat="server">0</asp:Label></div>
				<div>Your Current Hand: <asp:Label ID="PlayerHand" runat="server">0</asp:Label></div>
				<asp:Textbox ID="BetAmount" placeholder="Bet Amount" runat="server"></asp:Textbox>
				<div id="NumPad">
					<asp:Button id="Button0" class="NumberButton" runat="server" text="0" OnClick="NumPadClicked"/>
					<asp:Button id="Button1" class="NumberButton" runat="server" text="1" OnClick="NumPadClicked"/>
					<asp:Button id="Button2" class="NumberButton" runat="server" text="2" OnClick="NumPadClicked"/>
					<asp:Button id="Button3" class="NumberButton" runat="server" text="3" OnClick="NumPadClicked"/>
					<asp:Button id="Button4" class="NumberButton" runat="server" text="4" OnClick="NumPadClicked"/>
					<asp:Button id="Button5" class="NumberButton" runat="server" text="5" OnClick="NumPadClicked"/>
					<asp:Button id="Button6" class="NumberButton" runat="server" text="6" OnClick="NumPadClicked"/>
					<asp:Button id="Button7" class="NumberButton" runat="server" text="7" OnClick="NumPadClicked"/>
					<asp:Button id="Button8" class="NumberButton" runat="server" text="8" OnClick="NumPadClicked"/>
					<asp:Button id="Button9" class="NumberButton" runat="server" text="9" OnClick="NumPadClicked"/>
				</div>
				<div>
					<asp:Button id="AddBet" runat="server" text="+"/>
					<asp:Button id="SubtractBet" runat="server" text="-"/>
				</div>
				<div>
					<asp:Button id="AllInButton" runat="server" text="All In" OnClick="AllInBet"/>
					<asp:Button ID="ClearBetButton" runat="server" text="Clear Bet" OnClick="ClearBet"/>
					<asp:Button id="DealButton" runat="server" text="Deal" OnClick="Deal"/>
				</div>
				<div>
					<asp:Button id="HitButton" runat="server" text="Hit" OnClick="Hit"/>
					<asp:Button id="StandButton" runat="server" text="Stand" OnClick="Stand"/>
					<asp:Button id="DoubleButton" runat="server" text="Double" OnClick="Double"/>
					<asp:Button id="QuitButton" runat="server" text="Quit"/>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</form>
</body>
</html>
