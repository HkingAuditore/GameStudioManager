<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameEditor.ascx.cs" Inherits="GameStdioManager.Views.Editors.GameEditor" %>

<div class="container-fluid">
    <div class="row">
        <div class="col-lg-12">
            编号：<asp:TextBox ID="GameNumber" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            名字：<asp:TextBox ID="GameName" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            价格：<asp:TextBox ID="GamePrice" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            销量：<asp:TextBox ID="GameSales" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            工作室：<asp:TextBox ID="GameStudio" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12" id="Genres" runat="server">
            游戏类型：<asp:CheckBox ID="SIM" runat="server" Text="SIM" />&nbsp
            <asp:CheckBox ID="ACT" runat="server" Text="ACT" />&nbsp
            <asp:CheckBox ID="SLG" runat="server" Text="SLG" />&nbsp
            <asp:CheckBox ID="RPG" runat="server" Text="RPG" />&nbsp
            <asp:CheckBox ID="AVG" runat="server" Text="AVG" />&nbsp
            <asp:CheckBox ID="SPG" runat="server" Text="SPG" />&nbsp
            <asp:CheckBox ID="STG" runat="server" Text="STG" />&nbsp
            <asp:CheckBox ID="RTS" runat="server" Text="RTS" />&nbsp
            <asp:CheckBox ID="GAL" runat="server" Text="GAL" />&nbsp
        </div>
        <div class="col-lg-12">
            游戏趣味性：<asp:TextBox ID="GameFun" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            游戏美术效果：<asp:TextBox ID="GameArt" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            游戏音乐效果：<asp:TextBox ID="GameMusic" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Button ID="Confirm" runat="server" Text="确认" OnClick="Confirm_OnClick" />
            <asp:Button ID="ReadFromSQL" runat="server" Text="读取" OnClick="ReadFromSQL_OnClick" />
            <asp:Button ID="Update" runat="server" Text="更新数据" OnClick="Update_OnClick" />
            <asp:Button ID="Reset" runat="server" Text="重置数据" OnClick="Reset_OnClick" />
        </div>
    </div>
</div>