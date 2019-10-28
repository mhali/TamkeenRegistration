<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PastQuizzes.aspx.cs" Inherits="TamkeenRegistration.Homepage.PastQuizzes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="PastQuizzes" runat="server">
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
                        <asp:label ID="lblTitle" runat="server" ForeColor="Red"  font-size="24px" Text="Past Quizzes" Font-Bold="true"/>
                    </td>
                </tr>
            </table>
            <br />
            <br />

        <table id="tblDetails" runat="server" visible="false">
<%--            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Quiz id:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtQuizId" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="lblQuizTitle" runat="server" Text="Quiz Title:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtTitle" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUrl" runat="server" Text="Video Url:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtVideoUrl" runat="server" Enabled="false" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDesc" runat="server" Text="Description:" Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="25" width="500" Enabled="false" ></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Add Picture" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:FileUpload ID="QuizUpload" runat="server"></asp:FileUpload>
                </td>
            </tr>--%>
<%--            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload" OnClick="btnUploadPhoto_Click" />
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Quiz picture: " Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Image ID="imgPhoto" runat="server" style="max-height:500px;max-width:500px;height:auto;width:auto;"></asp:Image>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Quiz Video: " Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                   <iframe id="QuizVideo" runat="server" width="400" height="200" src="" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                </td>
            </tr>
        </table>
<%--        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnVideo_Save_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnVideo_Clear_Click" />--%>
        <br />
        <br />
        <asp:GridView ID="gvQuiz" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" OnRowDataBound="OnRowDataBound" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
            <Columns>
                <asp:BoundField DataField="QuizId" HeaderText="QuizId" visible="false"/>
                <asp:BoundField DataField="Timestamp" HeaderText="Date" ItemStyle-Wrap="false"/>
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="VideoUrl" HeaderText="VideoUrl" visible="false"/>
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="maxWidthGrid"/>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server"  style="max-height:250px;max-width:250px;height:auto;width:auto;"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Video">
                    <ItemTemplate>
                        <iframe width="400" height="200" src='<%# Eval("VideoUrl") %>' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="ViewQuiz_OnClick">View Quiz</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="ViewQuizAnswers_OnClick">View Answers</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
