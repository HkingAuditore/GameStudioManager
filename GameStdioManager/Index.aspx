<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GameStdioManager.Index" %>

<%@ Register Src="~/Views/StaffEditor.ascx" TagPrefix="uc1" TagName="StaffEditor" %>
<%@ Register TagPrefix="uc1" Namespace="GameStdioManager.Views" Assembly="GameStdioManager" %>
<%@ Register Src="~/Views/StudioEditor.ascx" TagPrefix="uc1" TagName="StudioEditor" %>


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
        <uc1:StaffEditor runat="server" ID="StaffEditor" />
        <uc1:StudioEditor runat="server" id="StudioEditor" />
    </form>
</body>
</html>