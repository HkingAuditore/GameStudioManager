<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopedViewLine.ascx.cs" Inherits="GameStdioManager.Views.Game.DevelopedInfo.DevelopedViewLine" %>
<%@ Register Src="~/Views/Game/DevelopedInfo/Developer.ascx" TagPrefix="uc1" TagName="Developer" %>


<div class="row" style="padding-top: 1%; padding-bottom: 1%;border-bottom: 2px solid rgba(112, 112, 112, 0.12)">
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
        <asp:Label ID="C_GameProcess" runat="server" Text="完成日期"></asp:Label>
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
        <div class="row">
            <div runat="server" ID="C_Developers">
            
            </div>
        </div>
    </div>
</div>