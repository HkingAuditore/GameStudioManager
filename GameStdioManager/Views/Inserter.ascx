<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inserter.ascx.cs" Inherits="GameStdioManager.Views.Inserter" %>
<div class="container-fluid">
    <div class="row">
        <div class="col-lg-12">
            编号：<asp:TextBox ID="StaffNumber" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            名字：<asp:TextBox ID="StaffName" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            性别：
                男<asp:RadioButton ID="Male" runat="server" GroupName="Gender" />
                女<asp:RadioButton ID="Female" runat="server" GroupName="Gender" />
        </div>
        <div class="col-lg-12">
            薪水：<asp:TextBox ID="StaffSalary" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            职称：<asp:DropDownList ID="StaffRank" runat="server">
                <asp:ListItem Value="0">实习生</asp:ListItem>
                <asp:ListItem Value="1">初级</asp:ListItem>
                <asp:ListItem Value="2">中级</asp:ListItem>
                <asp:ListItem Value="3">高级</asp:ListItem>
                <asp:ListItem Value="4">资深</asp:ListItem>
                <asp:ListItem Value="5">专家</asp:ListItem>
                <asp:ListItem Value="6">行业领袖</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-12">
            职务：<asp:DropDownList ID="StaffOccupation" runat="server">
                <asp:ListItem Value="0">制作人</asp:ListItem>
                <asp:ListItem Value="1">策划</asp:ListItem>
                <asp:ListItem Value="2">美术</asp:ListItem>
                <asp:ListItem Value="3">程序</asp:ListItem>
                <asp:ListItem Value="4">音乐</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-12">
            体力：<asp:TextBox ID="StaffStrength" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            智力：<asp:TextBox ID="StaffIntelligence" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            忠诚：<asp:TextBox ID="StaffLoyalty" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            财产：<asp:TextBox ID="StaffProperty" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            上班时间：<asp:TextBox ID="TimeToWork" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            下班时间：<asp:TextBox ID="TimeToQuit" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            一周工作日长度：<asp:TextBox ID="WeekdaysLength" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12" ID="Temperament" runat="server">
            性格：
            友善<asp:CheckBox ID="Friendly" runat="server" GroupName="Tenmperament" />
            无主见<asp:CheckBox ID="Indecisive" runat="server" GroupName="Tenmperament" />
            有天赋<asp:CheckBox ID="Gifted" runat="server" GroupName="Tenmperament" />
            坏心肠<asp:CheckBox ID="Malevolent" runat="server" GroupName="Tenmperament" />
            领袖气质<asp:CheckBox ID="Charisma" runat="server" GroupName="Tenmperament" />
        </div>
        <div class="col-lg-12">
            所属公司：<asp:TextBox ID="StaffStudio" runat="server"></asp:TextBox>

        </div>
        <div class="col-lg-12">
            <asp:Button ID="Confirm" runat="server" Text="确认" OnClick="Confirm_OnClick" />
            <asp:Button ID="ReadFromSQL" runat="server" Text="读取" OnClick="ReadFromSQL_OnClick" />
            <asp:Button ID="Update" runat="server" Text="更新数据" OnClick="Update_OnClick"/>
            <asp:Button ID="Reset" runat="server" Text="重置数据" OnClick="Reset_OnClick"/>
        </div>


    </div>
</div>
     
 
             


