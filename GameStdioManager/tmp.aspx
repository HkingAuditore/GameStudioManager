<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tmp.aspx.cs" Inherits="GameStdioManager.tmp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        <div style="background-image: url('images/4.jpg'); color: #FFFFFF;">
        &nbsp;&nbsp; 用户名<asp:TextBox ID="Username" runat="server" OnTextChanged="Name_TextChanged" AutoPostBack="True"></asp:TextBox>
            <asp:Label ID="check1" runat="server" Text="Label" Visible="False"></asp:Label>
            只能为字母<br />
            <br />
&nbsp;&nbsp; 密码<asp:TextBox ID="Password" runat="server" OnTextChanged="Password_TextChanged" AutoPostBack="True" TextMode="Password"></asp:TextBox>
            <asp:Label ID="check2" runat="server" Text="Label" Visible="False"></asp:Label>
            6-18位<br />
            <br />
            确认密码<asp:TextBox ID="Passconfirm" runat="server" OnTextChanged="Passconfirm_TextChanged" AutoPostBack="True" TextMode="Password"></asp:TextBox>
            <asp:Label ID="check3" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            电话号码<asp:TextBox ID="Phone" runat="server" OnTextChanged="Phone_TextChanged" AutoPostBack="True"></asp:TextBox>
            <asp:Label ID="check4" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            性别&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="Gender_Male" runat="server" GroupName="Gender" OnCheckedChanged="RadioButton1_CheckedChanged" Text="男" Checked="True" />
&nbsp;
            <asp:RadioButton ID="Gender_Female" runat="server" GroupName="Gender" Text="女" />
            <asp:Label ID="check5" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            爱好 
            <asp:CheckBox ID="Hobby_sing" runat="server" Text="唱" />
&nbsp;
            <asp:CheckBox ID="Hobby_Dance" runat="server" Text="跳" />
&nbsp;
            <asp:CheckBox ID="Hobby_rap" runat="server" Text="rap" />
            <asp:Label ID="check6" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            学院&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="Semester" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>请选择学院</asp:ListItem>
                <asp:ListItem>管理学院</asp:ListItem>
                <asp:ListItem>理学院</asp:ListItem>
                <asp:ListItem>外国语学院</asp:ListItem>
                <asp:ListItem>材料学院</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="check7" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            头像&nbsp; <asp:FileUpload ID="Head" runat="server" Width="154px" />
            <br />
            <br />
            <asp:Button ID="Regist" runat="server" Text="注册" OnClick="Regist_Click" />
            <asp:TextBox ID="Score" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
