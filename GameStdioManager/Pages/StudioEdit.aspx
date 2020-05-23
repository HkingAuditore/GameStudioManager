<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StudioPage.master" AutoEventWireup="true" CodeBehind="StudioEdit.aspx.cs" Inherits="GameStdioManager.Pages.StudioEdit" %>

<%@ Register Src="~/Views/Editors/StudioEditor.ascx" TagPrefix="uc1" TagName="StudioEditor" %>



<asp:Content ID="Content1" ContentPlaceHolderID="StudioContentPlaceHolder" runat="server">

    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">

            <div class="row">
                <div class="col-lg-12">
                    <uc1:StudioEditor runat="server" ID="StudioEditor" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
