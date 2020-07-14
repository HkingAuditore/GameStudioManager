<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameStdioManager.Pages.Register" %>

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

    <script type="text/javascript" src="../Scripts/JQuery.js"></script>
    <script type="text/javascript" src="../Scripts/modernizr-2.8.3.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.bundle.js"></script>

    <title>注册</title>
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
<%--     <script type="text/javascript"> --%>
<%--          --%>
<%--     function setContainer(text) { --%>
<%--         document.getElementById("container").innerHTML += ('<br/>' + text); --%>
<%--     } --%>
<%-- --%>
<%--         $(function () { --%>
<%--             $("#Confirm").click(function() { --%>
<%--                 $.ajax({ --%>
<%--                     type: 'Post', --%>
<%--                     url: 'Login.aspx/GetResult', --%>
<%--                     dataType: "json", --%>
<%--                     contentType: "application/json;charset=utf-8", --%>
<%--                     success: function(data) { --%>
<%--                         $(".modal-body").text(data.d); --%>
<%--                         $("#PropAlert").modal('show'); --%>
<%--                     }, --%>
<%--                     error: function() { --%>
<%--                          --%>
<%--                         'ERROR!'); --%>
<%--                     } --%>
<%--                 }); --%>
<%-- --%>
<%--             }); --%>
<%--         }); --%>
<%--     </script> --%>


</head>


<body style="" runat="server">
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
            <div class="offset-lg-3 col-lg-2 offset-md-3 col-md-1 offset-sm-2 col-sm-1" style="position: fixed">
                <div class="triangle-front" style="position: absolute; padding: 200%; z-index: 3; margin-left: 280%">
                </div>
                <div class="triangle-behind" style="position: absolute; padding: 200%; z-index: 1; margin-left: 230%; margin-top: -50%;">
                </div>

                <div class="rg-panel" style="position: absolute; width: 150%; height: 28em; z-index: 4; margin-left: 230%; margin-top: 40%;">
                    <form id="form1" runat="server">

                        <div class="container-fluid" style="margin-top: 12%; margin-left: 9%">
                            <div class="row">
                                <div class="col-lg-4" style="font-size: 3em">
                                    注册
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
                            <div class="row" style="margin-top: 6%; margin-left: -13%;">
                                <div class="col-lg-3" style="font-size: 1.5em; text-align: right">
                                    公司名称
                                </div>
                                <div class="col-lg-6" style="font-size: 1.5em;">
                                    <asp:TextBox ID="C_CompanyName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 3%; margin-left: -13%;">
                                <div class="col-lg-3" style="font-size: 1.5em; text-align: right" >
                                    密码
                                </div>
                                <div class="col-lg-6" style="font-size: 1.5em;">
                                    <asp:TextBox ID="C_Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="margin-top: 8%;">
                                <div class="offset-lg-3 col-lg-4" style="font-size: 1.8em; text-align: right">
                                    <asp:Button ID="Confirm" runat="server"  Text="确认" CssClass="btn btn-primary btn-lg" OnClick="Confirm_OnClick" />
                                </div>
                                <div class="col-lg-4" style="font-size: 1.8em;">
                                    <asp:Button ID="Login" runat="server" Text="转到登录" CssClass="btn btn-success btn-lg" OnClick="Login_OnClick"  />
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
<div class="modal fade" id="PropAlert" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalCenterTitle">提示</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                这是一个提示
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" onclick="$('#PropAlert').modal('hide')">好的</button>
            </div>
        </div>
    </div>
</div>
</body>
</html>
