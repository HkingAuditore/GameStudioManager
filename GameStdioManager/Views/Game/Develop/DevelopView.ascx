<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopView.ascx.cs" Inherits="GameStdioManager.Views.Game.Develop.DevelopView" %>
<%@ Register Src="~/Views/Game/Develop/DevelopViewLine.ascx" TagPrefix="uc1" TagName="DevelopViewLine" %>

<div class="container-fluid" style="border: lightslategray">
    <div class="row">
        <div class="col-lg-1">
            编号
        </div>
        <div class="col-lg-1">
            游戏名
        </div>
        <div class="col-lg-1">
            开发日期
        </div>
        <div class="col-lg-1">
            截止日期
        </div>
        <div class="col-lg-1">
            趣味性
        </div>
        <div class="col-lg-1">
            美术
        </div>
        <div class="col-lg-1">
            音乐
        </div>
        <div class="col-lg-5">
            开发人员
        </div>
    </div>

    <div runat="server" id="GamesView">
    </div>
    
    <%-- <div class="row" runat="server"> --%>
    <%--     <div class="col-lg-1" runat="server" ID="AddButtonPanel" Visible="True"> --%>
    <%--         <asp:ImageButton ID="AddGame" runat="server" OnClick="AddGame_OnClick" ImageUrl="~/Resource/UI/Game/Development/Add.png"/> --%>
    <%--     </div> --%>
    <%--     <div runat="server" ID="AddGamePanel" Visible="False"> --%>
    <%--         <div class="col-lg-2"> --%>
    <%--             编号<asp:TextBox ID="T_GameNumber" runat="server" CssClass="form-control"></asp:TextBox> --%>
    <%--         </div> --%>
    <%-- --%>
    <%--         <div class="col-lg-2"> --%>
    <%--             名称 <asp:TextBox ID="T_GameName" runat="server" CssClass="form-control"></asp:TextBox> --%>
    <%--         </div> --%>
    <%-- --%>
    <%--         <div class="col-lg-2"> --%>
    <%--             限期时间(小时)<asp:TextBox ID="T_GameDDL" runat="server" CssClass="form-control"></asp:TextBox> --%>
    <%--         </div> --%>
    <%-- --%>
    <%--         <div class="col-lg-2"> --%>
    <%--             <asp:ImageButton ID="ConfirmDevelop"  ImageUrl="~/Resource/UI/Game/Development/Add.png" runat="server" OnClick="ConfirmDevelop_OnClick"/> --%>
    <%--         </div> --%>
    <%-- --%>
    <%--         <div class="col-lg-2"> --%>
    <%--             <asp:ImageButton ID="CancelDevelop"  ImageUrl="~/Resource/UI/Game/Development/Close.png" runat="server" OnClick="CancelDevelop_OnClick"/> --%>
    <%--         </div> --%>
    <%-- --%>
    <%--     </div> --%>
    <%-- </div> --%>
</div>