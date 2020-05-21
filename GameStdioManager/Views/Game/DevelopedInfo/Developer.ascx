<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Developer.ascx.cs" Inherits="GameStdioManager.Views.Game.DevelopedInfo.Developer" %>
<div style="border-radius: 10px;border: 2px solid lightslategray; padding: 10px;width: 30%">
    <div>
        <div runat="server" Visible="True" ID="DefaultLabel">
            <asp:Label ID="DeveloperName" runat="server" Text="DeveloperName" Font-Size="Larger"></asp:Label>
            <asp:Label ID="DeveloperOccupation" runat="server" Text="DeveloperOccupation" Font-Size="Small"></asp:Label>
        </div>
    </div>
</div>