<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVideo.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.AddVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="AddVideo" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Video id:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtVideoId" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Video Url:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtVideoUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Caption:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnVideo_Save_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnVideo_Clear_Click" />
        <br />
        <br />
        <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
            <Columns>
                <asp:BoundField DataField="VideoId" HeaderText="VideoId" />
                <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" />
                <asp:BoundField DataField="VideoUrl" HeaderText="VideoUrl" />
                <asp:BoundField DataField="Caption" HeaderText="Caption" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <iframe width="400" height="200" src='<%# Eval("VideoUrl") %>' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("VideoId") %>' OnClick="EditVideo_OnClick">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("VideoId") %>' OnClick="DeleteVideo_OnClick">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
