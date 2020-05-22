<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StaffPage.master" AutoEventWireup="true" CodeBehind="StaffEdit.aspx.cs" Inherits="GameStdioManager.Pages.StaffEdit" %>

<%@ Register Src="~/Views/Staff/StaffView.ascx" TagPrefix="uc1" TagName="StaffView" %>




<asp:Content ID="StaffContent" ContentPlaceHolderID="StaffContentPlaceHolder" runat="server">
    
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
    <div class="col-lg-12">

        <div class="row">
            <div class="col-lg-12">
                <uc1:StaffView runat="server" ID="StaffView" />
            </div>
        </div>
        </div>
    </div>
</asp:Content>
