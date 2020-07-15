<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StaffPage.master" AutoEventWireup="true" CodeBehind="StaffEmploy.aspx.cs" Inherits="GameStdioManager.Pages.StaffEmploy" %>

<%@ Register Src="~/Views/Staff/StaffEmployView.ascx" TagPrefix="uc1" TagName="StaffEmployView" %>



<asp:Content ID="StaffContent" ContentPlaceHolderID="StaffContentPlaceHolder" runat="server">

    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">
            <uc1:StaffEmployView runat="server" ID="StaffEmployView" />
        </div>
    </div>
</asp:Content>