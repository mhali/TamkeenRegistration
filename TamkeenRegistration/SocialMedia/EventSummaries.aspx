<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventSummaries.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.EventSummaries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EventSummariesForm" runat="server">
    <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPic" runat="server" Text="Picture: " ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:FileUpload ID="uploadPicture" runat="server"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCaption" runat="server" Text="Caption"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblWhere" runat="server" Text="Where"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtWhere" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   <td>
                        <asp:Button ID="btnUploadPicture" runat="server" Text="Upload" OnClick="btnUploadPicture_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblPicSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblPicErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
               </tr>
            </table>
            <asp:Image ID="imgPic" runat="server"></asp:Image>
    
    </div>
    </form>
</body>
</html>
