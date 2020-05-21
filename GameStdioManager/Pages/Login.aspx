<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameStdioManager.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-grid.css" rel="stylesheet" />
    <link href="../Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-reboot.css" rel="stylesheet" />
    <link href="../Content/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.intellisense.js"></script>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.slim.js"></script>
    <script src="../Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="../Scripts/jquery.validate-vsdoc.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <script src="../Scripts/modernizr-2.8.3.js"></script>
    <title>登录</title>
    <style type="text/css">
        .auto-style1 {
            width: 1920px;
            height: 1080px;
        }

        .triangle-front {
            transform: rotate(30deg);
            background: rgb(75, 123, 164);
        }

        .triangle-behind {
            transform: rotate(30deg);
            background: rgb(67, 98, 125);
        }

        .rg-panel {
            background: rgba(240, 248, 255, 1);
            border-radius: 50px;
            box-shadow: 10px 10px 20px rgba(38, 44, 57, 0.5);
            /* backdrop-filter: blur(8px); */
        }
    </style>
</head>
<body style="">
    <div class="container-fluid">
        <div class="row" style="background: rgb(122, 185, 209); padding-bottom: 6%;">
            <div class="col-lg-12">
                <div ></div>
            </div>
        </div>

        <div class="row" style="padding-bottom: 5%">
            <div class="col-lg-4 col-md-5">
                <img src="../Resource/UI/Gamedev.gif" style="margin-left: 9%; margin-top: 8%; width: 150%; z-index: -1" />
            </div>
            <div class="col-lg-offset-3 col-lg-2 col-md-offset-3 col-md-1 col-sm-offset-2 col-sm-1" style="position: fixed">
                <div class="triangle-front" style="position: absolute; padding: 200%; z-index: 3; margin-left: 280%">
                </div>
                <div class="triangle-behind" style="position: absolute; padding: 200%; z-index: 1; margin-left: 230%; margin-top: -50%;">
                </div>

                <div class="rg-panel" style="position: absolute; width: 140%; height: 28em; z-index: 4; margin-left: 230%; margin-top: 60%;">
                    <form id="form1" runat="server">
                        <div class="container-fluid" style="margin-top: 12%; margin-left: 9%">
                            <div class="row">
                                <div class="col-lg-4" style="font-size: 3em">
                                    登录
                                </div>
                            </div>
                            <div class="row" style="margin-top: 6%; margin-left: -13%;">
                                <div class="col-lg-3" style="font-size: 1.5em; text-align: right">
                                    账号
                                </div>
                                <div class="col-lg-6" style="font-size: 1.5em;">
                                    <asp:TextBox ID="C_PlayerNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 3%; margin-left: -13%;">
                                <div class="col-lg-3" style="font-size: 1.5em; text-align: right">
                                    密码
                                </div>
                                <div class="col-lg-6" style="font-size: 1.5em;">
                                    <asp:TextBox ID="C_Password" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="margin-top: 8%;">
                                <div class="offset-lg-3 col-lg-4" style="font-size: 1.8em; text-align: right">
                                    <asp:Button ID="Confirm" runat="server" Text="确认" CssClass="btn btn-primary btn-lg" OnClick="Confirm_OnClick" />
                                </div>
                                <div class="col-lg-4" style="font-size: 1.8em;">
                                    <asp:Button ID="Register" runat="server" Text="注册" CssClass="btn btn-success btn-lg" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>

        <div class="row">
            <div style="background: rgb(122, 185, 209); padding: 100%; position: fixed; z-index: 10">
            </div>
        </div>
    </div>
</body>
</html>