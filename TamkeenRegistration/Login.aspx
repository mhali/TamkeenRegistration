<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TamkeenRegistration.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="LoginForm" runat="server">
        <div>
            <table style="border: 1px solid black">
                <tr>
                    <td colspan="2">
                        <b>Login</b>
                    </td>
                </tr>
                <tr>
                    <td>User Name
                    </td>
                    <td>:<asp:TextBox ID="txtUserName" runat="server">
                    </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password
                    </td>
                    <td>:<asp:TextBox ID="txtPassword" TextMode="Password" runat="server">
                    </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkBoxRememberMe" runat="server" Text="Remember me" visible="false"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblLoginError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <a href="CreateUser/CreateUser.aspx">Click here to register</a> if you do not have a user name and password.
        </div>
    </form>
</body>
</html>
