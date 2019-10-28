<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Award.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.Award" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Award" runat="server">
    <div>

        <table>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Award Title:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Tamkeener Name:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="reason:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Date:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Gender:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList id="GenderList" AutoPostBack="True"   runat="server">
                          <%--<asp:ListItem Selected="True" Value="Both"> Both</asp:ListItem>--%>
                          <asp:ListItem Selected="True" Value="Boys"> Boys</asp:ListItem>
                          <asp:ListItem Value="Girls"> Girls </asp:ListItem>
               </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Add Picture" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:FileUpload ID="QuizUpload" runat="server"></asp:FileUpload>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload" OnClick="btnUploadPhoto_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                     <asp:Label ID="lblPicPath" runat="server" Text="" Enabled="false" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Tamkeener picture: " Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Image ID="imgPhoto" runat="server" style="max-height:150px;max-width:1500px;height:auto;width:auto;"></asp:Image>
                </td>
            </tr>
        </table>
        <%--<asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnActivity_Save_Click" />--%>
        <%--<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnActivity_Clear_Click" />--%>
        <br />
        <br />
<%--        <asp:Label ID="Label4" runat="server" Text="Date of Activities: " Enabled="false" ></asp:Label>
        <br />
        <asp:TextBox ID="txtDateOfActivitiy" runat="server"></asp:TextBox>
        <br />--%>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
        <br />
        <br />
        <asp:Image ID="imgPic" runat="server"></asp:Image>    

    
    </div>
    </form>
</body>
</html>
