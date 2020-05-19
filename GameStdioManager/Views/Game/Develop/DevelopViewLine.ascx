<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopViewLine.ascx.cs" Inherits="GameStdioManager.Views.Game.Develop.DevelopViewLine" %>
<%@ Register Src="~/Views/Game/Develop/Developer.ascx" TagPrefix="uc1" TagName="Developer" %>

<div class="row">
    <div class="col-lg-1">
        <asp:Label ID="C_GameNumber" runat="server" Text="编号"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameName" runat="server" Text="名字"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameStartDevelopTime" runat="server" Text="开发日期"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameFinishDevelopTime" runat="server" Text="截止日期"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameFun" runat="server" Text="趣味性"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameArt" runat="server" Text="美术"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameMusic" runat="server" Text="音乐"></asp:Label>
    </div>
    <div class="col-lg-5">
        <div runat="server" ID="C_Developers">
            
        </div>
    </div>
</div>