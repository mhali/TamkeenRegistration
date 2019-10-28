<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuiz.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.AddQuiz" %>

<!DOCTYPE html>
<style type="text/css">
.maxWidthGrid
{
    max-width: 300px;
    overflow: hidden;
}
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="AddQuiz" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Quiz id:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtQuizId" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Quiz Title:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Video Url:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtVideoUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Description:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="25" width="500"></asp:TextBox>
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
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Quiz picture: " Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Image ID="imgPhoto" runat="server" style="max-height:500px;max-width:500px;height:auto;width:auto;"></asp:Image>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnVideo_Save_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnVideo_Clear_Click" />
        <br />
        <br />
        <asp:GridView ID="gvQuiz" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" OnRowDataBound="OnRowDataBound" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
            <Columns>
                <asp:BoundField DataField="QuizId" HeaderText="QuizId" />
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="EditQuiz_OnClick">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("QuizId") %>' OnClick="DeleteQuiz_OnClick">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    
    </div>
    </form>
</body>
</html>
