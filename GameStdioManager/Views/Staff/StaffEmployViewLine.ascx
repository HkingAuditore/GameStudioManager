<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffEmployViewLine.ascx.cs" Inherits="GameStdioManager.Views.Staff.StaffEmployViewLine" %>
<div class="row" style="padding-top: 1%; padding-bottom: 1%;border-bottom: 2px solid rgba(112, 112, 112, 0.12)">
    <div class="col-lg-1">
        <asp:Label ID="L_StaffNumber" runat="server" Text="编号"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffName" runat="server" Text="名字"></asp:Label>

    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffSalary" runat="server" Text="薪水" Visible="True"></asp:Label>
    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffRank" runat="server" Text="职称" Visible="True"></asp:Label>


    </div>

    <div class="col-lg-1">
        <asp:Label ID="L_StaffOccupation" runat="server" Text="职业" Visible="True"></asp:Label>
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
        <asp:ImageButton ID="B_Employ" runat="server" Height="22px" ImageUrl="~/Resource/UI/Game/Development/Confirm.png" Width="22px" OnClick="B_Employ_OnClick_OnClick"/>
    </div>

</div>