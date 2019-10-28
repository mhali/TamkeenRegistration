<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenYourHeart.aspx.cs" Inherits="TamkeenRegistration.Homepage.OpenYourHeart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table >
                <tr>
                    <td>
                        <asp:hyperlink id="HomeLink1" runat="server" NavigateUrl="~/Homepage/Tamkeen.aspx">
                            <asp:image id="img" runat="server" src="../logo no text.png" height="100" width="100"/>
                        </asp:hyperlink>
                    </td>
                    <td>
                        <asp:hyperlink id="HomeLink2" runat="server" NavigateUrl="~/Homepage/Tamkeen.aspx">
                            <asp:label id="lblHome" runat="server" text="TAMKEEN"/>
                        </asp:hyperlink>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:label ID="lblTitle" runat="server" ForeColor="Red"  font-size="24px" Text="Open Your Heart" Font-Bold="true"/>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:label ID="Label1" runat="server" ForeColor="Green" Font-Bold="true" Text="YOU CAN SEND THE MESSSAGE ANONYMOUSLY BY LEAVING THE NAME AND EMAIL FIELDS BLANK" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:label ID="Label2" runat="server" Font-Bold="true" Text="Name(optional)" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtName" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label ID="Label3" runat="server" Font-Bold="true" Text="Email(optional)" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label ID="Label4" runat="server" Font-Bold="true" Text="Message" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" Rows="25" width="500"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
