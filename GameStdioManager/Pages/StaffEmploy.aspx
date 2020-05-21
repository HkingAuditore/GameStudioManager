<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StaffPage.master" AutoEventWireup="true" CodeBehind="StaffEmploy.aspx.cs" Inherits="GameStdioManager.Pages.StaffEmploy" %>

<%@ Register Src="~/Views/Editors/StaffEditor.ascx" TagPrefix="uc1" TagName="StaffEditor" %>


<asp:Content ID="StaffContent" ContentPlaceHolderID="StaffContentPlaceHolder" runat="server">
    
    <div class="container-fluid" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="row">
            <div class="col-lg-12">
                <uc1:StaffEditor runat="server" ID="StaffEditor" />
            </div>
        </div>
    </div>
</asp:Content>