<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffEmployView.ascx.cs" Inherits="GameStdioManager.Views.Staff.StaffEmployView" %>
<%@ Register Src="~/Views/Staff/StaffEmployViewLine.ascx" TagPrefix="uc1" TagName="StaffEmployViewLine" %>


<div class="row" style="padding-bottom: 1%; margin-bottom: 1%;border-bottom: 2px solid rgba(45, 45, 45, 0.64)">
    <div class="col-lg-1">
        编号
    </div>
    <div class="col-lg-1">
        名字
    </div>
    <div class="col-lg-1">
        意向薪水
    </div>
    <div class="col-lg-1">
        意向职称
    </div>
    <div class="col-lg-1">
        职业
    </div>
    <div class="col-lg-1">
        体力
    </div>
    <div class="col-lg-1">
        智力
    </div>
    <div class="col-lg-1">
        忠诚
    </div>
    <div class="col-lg-1">
        性格
    </div>



</div>
<asp:UpdatePanel ID="UP_UpdatePanel" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div runat="server" id="GamesView">
        </div>
    </ContentTemplate>

</asp:UpdatePanel>