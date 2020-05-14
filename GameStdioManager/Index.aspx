<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GameStdioManager.Index" %>

<%@ Register Src="~/Views/Inserter.ascx" TagPrefix="uc1" TagName="Inserter" %>

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
        <uc1:Inserter runat="server" ID="Inserter" />
    </form>
</body>
</html>