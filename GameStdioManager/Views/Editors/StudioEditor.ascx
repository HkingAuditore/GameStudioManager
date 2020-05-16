<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudioEditor.ascx.cs" Inherits="GameStdioManager.Views.Editors.StudioEditor" %>

<div class="container-fluid">
    <div class="row">
        <div class="col-lg-12">
            编号：<asp:TextBox ID="StudioNumber" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            名字：<asp:TextBox ID="StudioName" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
          财产：<asp:TextBox ID="StudioProperty" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
           声誉：<asp:TextBox ID="StudioReputation" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Button ID="Confirm" runat="server" Text="确认" OnClick="Confirm_OnClick" />
            <asp:Button ID="ReadFromSQL" runat="server" Text="读取" OnClick="ReadFromSQL_OnClick" />
            <asp:Button ID="Update" runat="server" Text="更新数据" OnClick="Update_OnClick"/>
            <asp:Button ID="Reset" runat="server" Text="重置数据" OnClick="Reset_OnClick"/>
        </div>


    </div>
</div>

