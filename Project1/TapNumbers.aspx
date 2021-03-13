<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TapNumbers.aspx.cs" Inherits="Project1.TapNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tap Numbers</title>
	<link rel="stylesheet" href="tapnumbers.css" />
	<script src="Sound.js" defer></script>
</head>
<body>
	<audio id="BackgroundMusic" autoplay controls loop">
		<source src="BGM.wav"/>
	</audio>
	<audio id="ButtonSound">
		<source src="ButtonPress.wav" />
	</audio>
	<div id="container">
		<form id="form1" runat="server">
			<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
				<ContentTemplate>
					<div class="Panel">
						<asp:Label ID="Message" runat="server"></asp:Label>
					</div>
					<div class="Panel">
						<asp:Button ID="StartGameButton" class="MenuButton" runat="server" Text="Start Game"  OnClick="StartGame"/>
						<asp:Button ID="QuitGameButton" class="MenuButton" runat="server" Text="Quit Game"  OnClick="QuitGame"/>
					</div>
					<div class="Panel">
						Timer: 
						<div class="InnerPanel">
							<asp:Label ID="TimerLabel" runat="server" Text="10"></asp:Label>
						</div>
						<div>
							<asp:Button ID="IncreaseTimeButton" class="MenuButton" runat="server" Text="Increase Time By 30"  OnClick="IncreaseTimer"/>
							<asp:Button ID="DecreaseTimeButton" class="MenuButton" runat="server" Text="Decrease Time By 30" OnClick="DecreaseTimer"/>
						</div>
						<asp:Timer ID="Timer1" runat="server" Interval="900" OnTick="Count_Down"></asp:Timer>
					</div>
					<div class="Panel">
						Score: 
						<div class="InnerPanel">
							<asp:Label ID="ScoreLabel" runat="server" Text="0"></asp:Label>
						</div>
					</div>
					<div class="Panel">
						Press the following number: 
						<div class="InnerPanel">
							<asp:Label ID="KeyLabel" CssClass="KeyLabel" runat="server"></asp:Label>
						</div>
					</div>
					<div id="NumPad" class="Panel">
						<asp:Button ID="Button0" class="NumberButton" runat="server" text="0" OnClick="NumPadClicked"/>
						<asp:Button ID="Button1" class="NumberButton" runat="server" text="1" OnClick="NumPadClicked"/>
						<asp:Button ID="Button2" class="NumberButton" runat="server" text="2" OnClick="NumPadClicked"/>
						<asp:Button ID="Button3" class="NumberButton" runat="server" text="3" OnClick="NumPadClicked"/>
						<asp:Button ID="Button4" class="NumberButton" runat="server" text="4" OnClick="NumPadClicked"/>
						<asp:Button ID="Button5" class="NumberButton" runat="server" text="5" OnClick="NumPadClicked"/>
						<asp:Button ID="Button6" class="NumberButton" runat="server" text="6" OnClick="NumPadClicked"/>
						<asp:Button ID="Button7" class="NumberButton" runat="server" text="7" OnClick="NumPadClicked"/>
						<asp:Button ID="Button8" class="NumberButton" runat="server" text="8" OnClick="NumPadClicked"/>
						<asp:Button ID="Button9" class="NumberButton" runat="server" text="9" OnClick="NumPadClicked"/>
					</div>
				</ContentTemplate>
			</asp:UpdatePanel>
		</form>
	</div>
</body>
</html>
