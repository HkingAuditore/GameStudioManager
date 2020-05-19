<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GameStdioManager.Index" %>

<%@ Register Src="~/Views/Editors/StaffEditor.ascx" TagPrefix="uc1" TagName="StaffEditor" %>
<%@ Register TagPrefix="uc1" Namespace="GameStdioManager.Views" Assembly="GameStdioManager" %>
<%@ Register Src="~/Views/Editors/StudioEditor.ascx" TagPrefix="uc1" TagName="StudioEditor" %>
<%@ Register Src="~/Views/Editors/GameEditor.ascx" TagPrefix="uc1" TagName="GameEditor" %>
<%@ Register Src="~/Views/Game/Develop/DevelopView.ascx" TagPrefix="uc1" TagName="DevelopView" %>
<%@ Register Src="~/Views/Game/Develop/DevelopViewLine.ascx" TagPrefix="uc1" TagName="DevelopViewLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="ie=edge" http-equiv="X-UA-Compatible" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="ie=edge" http-equiv="X-UA-Compatible" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.intellisense.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery-3.3.1.slim.js"></script>
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/jquery.validate-vsdoc.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.min.js"></script>
    <script src="Scripts/modernizr-2.8.3.js"></script>

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
                    
                    <uc1:DevelopView runat="server" ID="DevelopView" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- <div class="container-fluid"> --%>
        <%--     <div class="row"> --%>
        <%--         <div class="col-lg-12" style="margin-top: 2%"> --%>
        <%--             <uc1:StaffEditor runat="server" ID="StaffEditor" /> --%>
        <%--         </div> --%>
        <%--     </div> --%>
        <%--     <div class="row"> --%>
        <%--         <div class="col-lg-12" style="margin-top: 2%"> --%>
        <%--             <uc1:StudioEditor runat="server" ID="StudioEditor" /> --%>
        <%--         </div> --%>
        <%--     </div> --%>
        <%--     <div class="row" style="margin-top: 2%"> --%>
        <%--         <div class="col-lg-12"> --%>
        <%--             <uc1:GameEditor runat="server" ID="GameEditor" /> --%>
        <%--         </div> --%>
        <%--     </div> --%>
        <%-- </div> --%>

    </form>
</body>
</html>