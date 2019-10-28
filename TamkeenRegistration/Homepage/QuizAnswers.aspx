<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizAnswers.aspx.cs" Inherits="TamkeenRegistration.Homepage.QuizAnswers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="QuizAnswers" runat="server">
    <div>
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
                        <asp:label ID="lblTitle" runat="server" ForeColor="Red"  font-size="24px" Text="Quiz Answers" Font-Bold="true"/>
                    </td>
                </tr>
            </table>
            <br />
            <br />

        <asp:GridView ID="gvQuizAnswers" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" >
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Name (visible to admins)" visible="false"/>
                <asp:BoundField DataField="DisplayName" HeaderText="Name" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
