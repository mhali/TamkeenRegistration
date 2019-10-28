<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnswerQuiz.aspx.cs" Inherits="TamkeenRegistration.TamkeenerPortal.AnswerQuiz" %>

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
        <table>
        <tr>
            <td>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:label ID="Label2" runat="server" ForeColor="Red"  font-size="24px" Text="The Weekly Quiz" Font-Bold="true"/>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Please add/edit your answer in the box below." Enabled="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr >
            <td colspan="2">
                <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Rows="25" Width="500" AutoPostBack="true" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="chkMentionName" runat="server" AutoPostBack="True" Text="I agree to mention my name" TextAlign="Right" OnCheckedChanged="chkMentionName_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspa2>
                <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnFSave_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="" Enabled="false" ForeColor="Green"></asp:Label>
            </td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
