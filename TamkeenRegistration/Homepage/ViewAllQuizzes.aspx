<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllQuizzes.aspx.cs" Inherits="TamkeenRegistration.Homepage.ViewAllQuizzes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvQuiz" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" OnRowDataBound="OnRowDataBound">
            <Columns>
                <asp:BoundField DataField="QuizId" HeaderText="QuizId" visible="false"/>
                <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" />
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="VideoUrl" HeaderText="VideoUrl" />
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
<%--                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="EditQuiz_OnClick">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="DeleteQuiz_OnClick">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
