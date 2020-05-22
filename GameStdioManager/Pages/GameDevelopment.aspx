<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GamePage.master" AutoEventWireup="true" CodeBehind="GameDevelopment.aspx.cs" Inherits="GameStdioManager.Pages.GameDevelopment" %>

<%@ Register Src="~/Views/Game/Develop/DevelopView.ascx" TagPrefix="uc1" TagName="DevelopView" %>

<asp:Content ID="GameContent" ContentPlaceHolderID="GameContentPlaceHolder" runat="server">
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
    <div class="col-lg-12">

        <div class="row">
            <div class="col-lg-12">

                <uc1:DevelopView runat="server" ID="DevelopView"/>

            </div>
        </div>
        

        <div class="row" runat="server">
            <div class="col-lg-12" runat="server" ID="AddButtonPanel" Visible="True">
                <asp:ImageButton ID="AddGame" runat="server" OnClick="AddGame_OnClick" ImageUrl="~/Resource/UI/Game/Development/Add.png"/>
            </div>
        </div>


        <div class="row" runat="server">

            <div class="col-lg-12" runat="server" ID="AddGamePanel" Visible="False">
                <div class="row" runat="server">

                    <div class="col-lg-1">
                        编号<asp:TextBox ID="T_GameNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-lg-1">
                        名称 <asp:TextBox ID="T_GameName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-lg-1">
                        限期时间(小时)<asp:TextBox ID="T_GameDDL" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-lg-1">
                        制作人<asp:DropDownList ID="D_Producer" runat="server" DataSourceID="GameStudioSimulator" DataTextField="StaffName" DataValueField="StaffNumber"></asp:DropDownList>
                        <asp:SqlDataSource ID="GameStudioSimulator" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT [StaffNumber], [StaffName] FROM [StaffInfo] WHERE (([StaffOccupation] = @StaffOccupation) AND ([StaffStudio] = @StaffStudio))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="StaffOccupation" Type="Int32"/>
                                <asp:SessionParameter DefaultValue="0" Name="StaffStudio" SessionField="PlayerStudioNumber" Type="String"/>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>

                    <div class="col-lg-1">
                        <asp:ImageButton ID="ConfirmDevelop" ImageUrl="~/Resource/UI/Game/Development/Add.png" runat="server" OnClick="ConfirmDevelop_OnClick"/>
                    </div>

                    <div class="col-lg-1">
                        <asp:ImageButton ID="CancelDevelop" ImageUrl="~/Resource/UI/Game/Development/Close.png" runat="server" OnClick="CancelDevelop_OnClick"/>
                    </div>

                </div>
            </div>
            </div>
        </div>

    </div>
</asp:Content>