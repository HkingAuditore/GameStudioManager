<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopView.ascx.cs" Inherits="GameStdioManager.Views.Game.Develop.DevelopView" %>
<%@ Register Src="~/Views/Game/Develop/DevelopViewLine.ascx" TagPrefix="uc1" TagName="DevelopViewLine" %>

<div class="container-fluid" style="border: lightslategray">
    <div class="row">
        <div class="col-lg-1">
            编号
        </div>
        <div class="col-lg-1">
            游戏名
        </div>
        <div class="col-lg-1">
            开发日期
        </div>
        <div class="col-lg-1">
            截止日期
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
        <div class="col-lg-5">
            开发人员
        </div>
    </div>

    <div runat="server" id="GamesView">
    </div>
</div>