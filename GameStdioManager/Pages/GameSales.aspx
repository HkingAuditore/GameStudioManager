<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GamePage.master" AutoEventWireup="true" CodeBehind="GameSales.aspx.cs" Inherits="GameStdioManager.Pages.GameSales" %>

<%@ Register Src="~/Views/Game/GameSales/SalesView.ascx" TagPrefix="uc1" TagName="SalesView" %>


<asp:Content ID="GameContent" ContentPlaceHolderID="GameContentPlaceHolder" runat="server">

    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
    <div class="col-lg-12">

        <div class="row">
            <div class="col-lg-12">
                <uc1:SalesView runat="server" id="SalesView" />
            </div>
            </div>
        </div>
    </div>
</asp:Content>