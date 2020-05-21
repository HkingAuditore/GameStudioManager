<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Developer.ascx.cs" Inherits="GameStdioManager.Views.Game.Develop.Developer" %>

<div style="border-radius: 10px;border: 2px solid lightslategray; padding: 10px;width: 30%">
    <div>
        <div runat="server" Visible="True" ID="DefaultLabel">
            <asp:Label ID="DeveloperName" runat="server" Text="DeveloperName" Font-Size="Larger"></asp:Label>
            <asp:Label ID="DeveloperOccupation" runat="server" Text="DeveloperOccupation" Font-Size="Small"></asp:Label>
            <asp:ImageButton ID="B_RemoveDeveloper" runat="server" Height="30px" ImageUrl="~/Resource/UI/Game/Development/Delete.png" Width="30px" OnClick="B_RemoveDeveloper_OnClick"/>
        </div>
        <div runat="server" Visible="False" ID="EditLabel">
            <asp:DropDownList ID="D_Staffs" runat="server"></asp:DropDownList>
            <asp:ImageButton ID="B_Confirm" runat="server" />
        </div>
    </div>
</div>