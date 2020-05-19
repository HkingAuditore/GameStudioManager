<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GameStdioManager.Index" %>

<%@ Register Src="~/Views/Editors/StaffEditor.ascx" TagPrefix="uc1" TagName="StaffEditor" %>
<%@ Register TagPrefix="uc1" Namespace="GameStdioManager.Views" Assembly="GameStdioManager" %>
<%@ Register Src="~/Views/Editors/StudioEditor.ascx" TagPrefix="uc1" TagName="StudioEditor" %>
<%@ Register Src="~/Views/Editors/GameEditor.ascx" TagPrefix="uc1" TagName="GameEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#FF6666" />
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12" style="margin-top: 2%">
                    <uc1:StaffEditor runat="server" ID="StaffEditor" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="margin-top: 2%">
                    <uc1:StudioEditor runat="server" ID="StudioEditor" />
                </div>
            </div>
            <div class="row" style="margin-top: 2%">
                <div class="col-lg-12">
                    <uc1:GameEditor runat="server" ID="GameEditor" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>