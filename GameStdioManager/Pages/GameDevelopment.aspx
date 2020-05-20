<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GamePage.master" AutoEventWireup="true" CodeBehind="GameDevelopment.aspx.cs" Inherits="GameStdioManager.Pages.GameDevelopment" %>

<%@ Register Src="~/Views/Game/Develop/DevelopView.ascx" TagPrefix="uc1" TagName="DevelopView" %>

<asp:Content ID="GameContent" ContentPlaceHolderID="GameContentPlaceHolder" runat="server">
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:DevelopView runat="server" ID="DevelopView" />
        </ContentTemplate>
    </asp:UpdatePanel>
        <div class="row" runat="server">
            <div class="col-lg-1" runat="server" ID="AddButtonPanel" Visible="True">
                <asp:ImageButton ID="AddGame" runat="server" OnClick="AddGame_OnClick" ImageUrl="~/Resource/UI/Game/Development/Add.png"/>
            </div>
            <div runat="server" ID="AddGamePanel" Visible="False">
                <div class="col-lg-2">
                    编号<asp:TextBox ID="T_GameNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-2">
                    名称 <asp:TextBox ID="T_GameName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-2">
                    限期时间(小时)<asp:TextBox ID="T_GameDDL" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-2">
                    <asp:ImageButton ID="ConfirmDevelop"  ImageUrl="~/Resource/UI/Game/Development/Add.png" runat="server" OnClick="ConfirmDevelop_OnClick"/>
                </div>

                <div class="col-lg-2">
                    <asp:ImageButton ID="CancelDevelop"  ImageUrl="~/Resource/UI/Game/Development/Close.png" runat="server" OnClick="CancelDevelop_OnClick"/>
                </div>

            </div>
        </div>

    </div>
</asp:Content>

