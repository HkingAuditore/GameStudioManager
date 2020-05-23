<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffViewLine.ascx.cs" Inherits="GameStdioManager.Views.Staff.StaffViewLine" %>

<div class="row" style="padding-top: 1%; padding-bottom: 1%;border-bottom: 2px solid rgba(112, 112, 112, 0.12)">
    <div class="col-lg-1">
        <asp:Label ID="L_StaffNumber" runat="server" Text="编号"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffName" runat="server" Text="名字"></asp:Label>
        <asp:Label ID="LF_StaffCurStrength" runat="server" Text="当前体力值" Visible="True"></asp:Label>

    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffSalary" runat="server" Text="薪水" Visible="True"></asp:Label>
        <asp:TextBox ID="T_StaffSalary" runat="server" Visible="False"></asp:TextBox>
        <asp:ImageButton ID="B_StaffSalarySetting" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" OnClick="Setting_OnClick"/>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffRank" runat="server" Text="职称" Visible="True"></asp:Label>
        <asp:DropDownList ID="D_StaffRank" runat="server" Visible="False">
            <asp:ListItem Value="0">实习生</asp:ListItem>
            <asp:ListItem Value="1">初级</asp:ListItem>
            <asp:ListItem Value="2">中级</asp:ListItem>
            <asp:ListItem Value="3">高级</asp:ListItem>
            <asp:ListItem Value="4">资深</asp:ListItem>
            <asp:ListItem Value="5">专家</asp:ListItem>
            <asp:ListItem Value="6">行业领袖</asp:ListItem>
        </asp:DropDownList>

        <asp:ImageButton ID="B_StaffRankSetting" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" OnClick="Setting_OnClick"/>

    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffOccupation" runat="server" Text="职业" Visible="True"></asp:Label>
        <asp:DropDownList ID="D_StaffOccupation" runat="server" Visible="False">
            <asp:ListItem Value="0">制作人</asp:ListItem>
            <asp:ListItem Value="1">策划</asp:ListItem>
            <asp:ListItem Value="2">美术</asp:ListItem>
            <asp:ListItem Value="3">程序</asp:ListItem>
            <asp:ListItem Value="4">音乐</asp:ListItem>
        </asp:DropDownList>
        <asp:ImageButton ID="B_StaffOccupationSetting" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" OnClick="Setting_OnClick"/>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffStrength" runat="server" Text="体力"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffIntelligence" runat="server" Text="智力"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffLoyalty" runat="server" Text="忠诚"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="L_StaffTemperament" runat="server" Text="性格"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_TimeToWork" runat="server" Text="上班时间" Visible="True"></asp:Label>
        <asp:TextBox ID="T_TimeToWork" runat="server" Visible="False"></asp:TextBox>

        <asp:ImageButton ID="B_TimeToWorkSetting" runat="server" Height="22px" OnClick="Setting_OnClick" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" />

    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_TimeToQuit" runat="server" Text="下班时间" Visible="True"></asp:Label>
        <asp:TextBox ID="T_TimeToQuit" runat="server" Visible="False"></asp:TextBox>

        <asp:ImageButton ID="B_TimeToQuitSetting" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" OnClick="Setting_OnClick"/>

    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_WeekdaysLength" runat="server" Text="工作日长度" Visible="True"></asp:Label>
        <asp:TextBox ID="T_WeekdaysLength" runat="server" Visible="False"></asp:TextBox>
        <asp:ImageButton ID="B_WeekdaysLengthSetting" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" OnClick="Setting_OnClick" />

    </div>

</div>