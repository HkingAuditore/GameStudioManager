<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesViewLine.ascx.cs" Inherits="GameStdioManager.Views.Game.GameSales.SalesViewLine" %>
<%@ Register Src="~/Views/Game/GameSales/Developer.ascx" TagPrefix="uc1" TagName="Developer" %>


<div class="row" style="padding-top: 1%; padding-bottom: 1%;border-bottom: 2px solid rgba(112, 112, 112, 0.12)">
    <div class="col-lg-1">
        <asp:Label ID="C_GameNumber" runat="server" Text="编号"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameName" runat="server" Text="名字"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GamePrice" runat="server" Text="售价" Visible="True"></asp:Label>
        <asp:TextBox ID="T_GamePrice" runat="server" Visible="False"></asp:TextBox>
        <asp:ImageButton ID="B_PriceSetting" runat="server" OnClick="B_PriceSetting_OnClick" Height="22px" ImageUrl="~/Resource/UI/Game/Sales/Setting.png" Width="22px" />

    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameSales" runat="server" Text="销量"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameFun" runat="server" Text="趣味性"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameArt" runat="server" Text="美术"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameMusic" runat="server" Text="音乐"></asp:Label>
    </div>
    <div class="col-lg-5">
        <div class="row">
            <div runat="server" ID="C_Developers">
            
            </div>
        </div>

        <div class="row">
            <div runat="server" ID="P_EditDeveloper" Visible="False" >
                <div class="col-lg-1">
                    <asp:DropDownList ID="D_Deverloper" runat="server" DataSourceID="GameStudioSimulator" DataTextField="StaffName" DataValueField="StaffNumber"></asp:DropDownList>
                    <asp:SqlDataSource ID="GameStudioSimulator" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT
                                                                                                                                                    	StaffInfo.StaffNumber,
                                                                                                                                                    	StaffInfo.StaffName 
                                                                                                                                                    FROM
                                                                                                                                                    	StaffInfo 
                                                                                                                                                    WHERE
                                                                                                                                                    	((
                                                                                                                                                    		SELECT COUNT
                                                                                                                                                    			( 1 ) AS num 
                                                                                                                                                    		FROM
                                                                                                                                                    			DeveloperRelation 
                                                                                                                                                    		WHERE
                                                                                                                                                    			((
                                                                                                                                                    					StaffInfo.StaffNumber = DeveloperRelation.DeveloperStaffNumber 
                                                                                                                                                    					) 
                                                                                                                                                    			AND ( DeveloperRelation.DeveloperGameNumber = @ThisGame )) 
                                                                                                                                                    			) = 0 
                                                                                                                                                    	) 
                                                                                                                                                    	AND (
                                                                                                                                                    	StaffInfo.StaffStudio = @StaffStudio)">
                        <SelectParameters>

                            <asp:Parameter Name="ThisGame" Type="String" runat="server" />
                            <asp:SessionParameter DefaultValue="0" Name="StaffStudio" SessionField="PlayerStudioNumber" Type="String" />

                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-lg-1">
                    <asp:ImageButton ID="B_ConfirmButton" runat="server" OnClick="B_ConfirmButton_OnClick" Height="30px" ImageUrl="~/Resource/UI/Game/Development/Confirm.png" Width="30px" />
                    <asp:ImageButton ID="B_CancelButton" runat="server"   OnClick="B_CancelButton_OnClick" Height="30px" ImageUrl="~/Resource/UI/Game/Development/Close.png" Width="30px" />
                </div>
            </div>

        </div>
        <div class="row">
            <div runat="server" ID="P_AddDeveloper" Visible="True">
                <div class="col-lg-1">
                    <asp:ImageButton ID="B_AddDeveloper" runat="server" OnClick="B_AddDeveloper_OnClick" Height="30px" ImageUrl="~/Resource/UI/Game/Development/Add.png" Width="30px" />
                </div>
            </div>
        </div>
    </div>
</div>