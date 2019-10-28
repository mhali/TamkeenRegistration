<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="TamkeenRegistration.Homepage.SuggestedVideos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
            <div>
        <%--<iframe width="400" height="200" src="https://www.youtube.com/embed/GclvKrV_fAE" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
        <%--<iframe width="400" height="200" src="https://www.youtube.com/embed/dqEvZCXHPxM" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
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
                        <asp:label ID="lblTitle" runat="server" ForeColor="Red"  font-size="24px" Text="Suggested Videos" Font-Bold="true"/>
                    </td>
                </tr>
            </table>
            <br />
            <br />
         <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="False" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                <Columns>
                    <asp:BoundField DataField="VideoUrl" HeaderText="VideoUrl" visible="false"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                           <iframe width="400" height="200" src='<%# Eval("VideoUrl") %>' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Caption" HeaderText="Caption">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
                </div>
    </form>
</body>
</html>
