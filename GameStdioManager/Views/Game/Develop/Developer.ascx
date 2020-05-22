<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Developer.ascx.cs" Inherits="GameStdioManager.Views.Game.Develop.Developer" %>

<div class="row">
    <div class="col-lg-12">
        <div style="border-radius: 10px; border: 2px solid lightslategray; padding: 2%; padding-right: 15%; width: 110%">
            <div class="row">
                <div class="col-lg-12">
                    <div runat="server" Visible="True" ID="DefaultLabel">
                        <div class="row">
                            <div class="col-lg-10">
                                <asp:Label ID="DeveloperName" runat="server" Text="DeveloperName" Font-Size="Larger"></asp:Label>


                                <asp:Label ID="DeveloperOccupation" runat="server" Text="DeveloperOccupation" Font-Size="Small"></asp:Label>
                            </div>
                            <div class="col-lg-1">

                                <asp:ImageButton ID="B_RemoveDeveloper" runat="server" Height="30px" ImageUrl="~/Resource/UI/Game/Development/Delete.png" Width="30px" OnClick="B_RemoveDeveloper_OnClick"/>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12">
                            <div runat="server" Visible="False" ID="EditLabel">
                                <asp:DropDownList ID="D_Staffs" runat="server"></asp:DropDownList>
                                <asp:ImageButton ID="B_Confirm" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>