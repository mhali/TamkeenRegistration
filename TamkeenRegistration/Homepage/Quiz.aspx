<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="TamkeenRegistration.Homepage.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
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
                    <td colspan="2">
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="24px" forecolor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Image ID="imgPhoto" runat="server" Style="max-height: 500px; max-width: 500px; height: auto; width: auto;"></asp:Image>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"  Width="500" Height="300" Enabled="false"  Font-Size="20px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br/>
                        <br/>
                    </td>
                </tr>
                <tr>
                <td  colspan="2">
                    <iframe id="frmVideo" width="400" height="200" src='' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen runat="server"></iframe>
                </td>
            </tr>
                <tr>
                    <td>
                        <br/>
                        <br/>
                    </td>
                </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Add your answer" OnClick="btnSubmit_Click" />
                </td>
                <td>
                    <asp:Button ID="btnPastQuizzes" runat="server" Text="View Past Quizzes" OnClick="btnPastQuizzes_Click" />
                </td>
            </tr>
            <br />
            <br />
            </table>

        </div>

    </form>
</body>
</html>
