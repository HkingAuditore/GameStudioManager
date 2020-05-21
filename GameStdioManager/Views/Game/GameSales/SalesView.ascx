<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesView.ascx.cs" Inherits="GameStdioManager.Views.Game.GameSales.SalesView" %>
<%@ Register Src="~/Views/Game/GameSales/SalesViewLine.ascx" TagPrefix="uc1" TagName="SalesViewLine" %>

<div class="row" style="padding-bottom: 1%; margin-bottom: 1%;border-bottom: 2px solid rgba(45, 45, 45, 0.64)">
    <div class="col-lg-1">
        编号
    </div>
    <div class="col-lg-1">
        游戏名
    </div>
    <div class="col-lg-1">
        售价
    </div>
    <div class="col-lg-1">
        销量
    </div>
    <div class="col-lg-1">
        趣味性
    </div>
    <div class="col-lg-1">
        美术
    </div>
    <div class="col-lg-1">
        音乐
    </div>

    <div class="col-lg-4">
        运营人员
    </div>

</div>
<asp:UpdatePanel ID="UP_UpdatePanel" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div runat="server" id="GamesView">
        </div>
    </ContentTemplate>

</asp:UpdatePanel>