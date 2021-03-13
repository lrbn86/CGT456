﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TapNumbers.aspx.cs" Inherits="Project1.TapNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tap Numbers</title>
	<link rel="stylesheet" href="tapnumbers.css" />
</head>
<body>
	<div id="container">
		<form id="form1" runat="server">
			<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
				<ContentTemplate>
					<div id="Introduction" class="Panel" runat="server">
						<p>Welcome to Tap Numbers. The game objective is to tap number that corresponds to the number in the white box.</p>
						<p>Begin first by setting a time limit. The time limit will be locked in when you start the game.</p>
						<p>Each incorrect number tapped will deduct the timer by 30. When the time is up, the game is over.</p>
						<p>You may quit the game at any time. The timer and score will reset.</p>
					</div>
					<div class="Panel">
						<div>
							Game Message: <asp:Label ID="Message" runat="server">Click 'Start Game' to begin playing.</asp:Label>
						</div>
					</div>
					<div class="Panel">
						Score: <asp:Label ID="ScoreLabel" runat="server" Text="0"></asp:Label>
					</div>
					<div class="Panel">
						Timer: <asp:Label ID="TimerLabel" runat="server" Text="10"></asp:Label>
						<div>
							<asp:Button ID="IncreaseTimeButton" CssClass="MenuButton" runat="server" Text="+30"  OnClick="IncreaseTimer"/>
							<asp:Button ID="DecreaseTimeButton" CssClass="MenuButton" runat="server" Text="-30" OnClick="DecreaseTimer"/>
						</div>
						<asp:Timer ID="Timer1" runat="server" Interval="900" OnTick="Count_Down"></asp:Timer>
					</div>
					<div id="KeyPanel"> 
						<div class="InnerPanel">
							<asp:Label ID="KeyLabel" CssClass="KeyLabel" runat="server"></asp:Label>
						</div>
					</div>
					<div id="NumPad" class="Panel">
						<asp:Button ID="Button0" CssClass="NumberButton" runat="server" text="0" OnClick="NumPadClicked"/>
						<asp:Button ID="Button1" CssClass="NumberButton" runat="server" text="1" OnClick="NumPadClicked"/>
						<asp:Button ID="Button2" CssClass="NumberButton" runat="server" text="2" OnClick="NumPadClicked"/>
						<asp:Button ID="Button3" CssClass="NumberButton" runat="server" text="3" OnClick="NumPadClicked"/>
						<asp:Button ID="Button4" CssClass="NumberButton" runat="server" text="4" OnClick="NumPadClicked"/>
						<asp:Button ID="Button5" CssClass="NumberButton" runat="server" text="5" OnClick="NumPadClicked"/>
						<asp:Button ID="Button6" CssClass="NumberButton" runat="server" text="6" OnClick="NumPadClicked"/>
						<asp:Button ID="Button7" CssClass="NumberButton" runat="server" text="7" OnClick="NumPadClicked"/>
						<asp:Button ID="Button8" CssClass="NumberButton" runat="server" text="8" OnClick="NumPadClicked"/>
						<asp:Button ID="Button9" CssClass="NumberButton" runat="server" text="9" OnClick="NumPadClicked"/>
					</div>
					<div class="Panel">
						<asp:Button ID="StartGameButton" CssClass="MenuButton" runat="server" Text="Start Game"  OnClick="StartGame"/>
						<asp:Button ID="QuitGameButton" CssClass="MenuButton" runat="server" Text="Quit Game"  OnClick="QuitGame"/>
					</div>
				</ContentTemplate>
			</asp:UpdatePanel>
		</form>
	</div>
</body>
</html>
