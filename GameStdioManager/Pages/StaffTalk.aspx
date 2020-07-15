<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StaffPage.master" AutoEventWireup="true" CodeBehind="StaffTalk.aspx.cs" Inherits="GameStdioManager.Pages.StaffTalk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StaffContentPlaceHolder" runat="server">
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-2">
                    员工【<asp:Label ID="L_StaffName" runat="server" Text="请选择要对话的员工"></asp:Label>】
                </div>
                <div class="col-lg-1">
                    <asp:DropDownList ID="D_Staff" runat="server" DataSourceID="GameStudioSimulator" DataTextField="StaffName" DataValueField="StaffNumber" OnSelectedIndexChanged="D_Staff_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="GameStudioSimulator" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT
                                                                                                                                                    	StaffInfo.StaffNumber,
                                                                                                                                                    	StaffInfo.StaffName 
                                                                                                                                                    FROM
                                                                                                                                                    	StaffInfo 
                                                                                                                                                    WHERE
                                                                                                                                                    	StaffInfo.StaffStudio = @StaffStudio">
                        <SelectParameters>


                            <asp:SessionParameter DefaultValue="0" Name="StaffStudio" SessionField="PlayerStudioNumber" Type="String"/>

                        </SelectParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="L_StaffTalkContent" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </div>
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">
        </div>
        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="L_StaffHP" runat="server" Text="体力值："></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="L_StaffIntelligence" runat="server" Text="智力值："></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="L_StaffTalkLoyalty" runat="server" Text="忠诚度："></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">



                <div class="col-lg-1">
                    <asp:Button ID="B_Reward" runat="server" Text="奖励" OnClick="B_Reward_OnClick" CssClass="btn btn-primary"/>
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="B_Penalize" runat="server" Text="惩罚" OnClick="B_Penalize_OnClick" CssClass="btn btn-primary"/>
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="B_Promote" runat="server" Text="升职" OnClick="B_Promote_OnClick" CssClass="btn btn-primary"/>
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="B_Demote" runat="server" Text="降职" OnClick="B_Demote_OnClick" CssClass="btn btn-primary"/>
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="B_Fire" runat="server" Text="辞退" OnClick="B_Fire_OnClick" CssClass="btn btn-primary"/>
                </div>


    </div>

</asp:Content>