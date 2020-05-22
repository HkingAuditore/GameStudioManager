<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GamePage.master" AutoEventWireup="true" CodeBehind="GameDevelopedInfo.aspx.cs" Inherits="GameStdioManager.Pages.GameDevelopedInfo" %>


<%@ Register TagPrefix="uc1" Namespace="GameStdioManager.Views.Game.DevelopedInfo" Assembly="GameStdioManager" %>
<%@ Register Src="~/Views/Game/DevelopedInfo/DevelopedView.ascx" TagPrefix="uc1" TagName="DevelopedView" %>

<asp:Content ID="GameContent" ContentPlaceHolderID="GameContentPlaceHolder" runat="server">

    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">

                <div class="row">
                    <div class="col-lg-12">

                    <uc1:DevelopedView runat="server" ID="DevelopedView" />
                </div>
                </div>
            </div>
        </div>

    </div>
    </div>
</asp:Content>