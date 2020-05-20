<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GamePage.master" AutoEventWireup="true" CodeBehind="GameDevelopment.aspx.cs" Inherits="GameStdioManager.Pages.GameDevelopment" %>

<%@ Register Src="~/Views/Game/Develop/DevelopView.ascx" TagPrefix="uc1" TagName="DevelopView" %>

<asp:Content ID="GameContent" ContentPlaceHolderID="GameContentPlaceHolder" runat="server">
    <uc1:DevelopView runat="server" ID="DevelopView" />
</asp:Content>

