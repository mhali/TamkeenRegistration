<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuote.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.AddQuote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Pic No:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNo" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="x1 (0-100):" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtX1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="x2  (0-100):" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtX2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Y1 (0-100):" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtY1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Y2 (0-100):" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtY2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Transparency (0-100):" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtTransparency" runat="server" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Background?" Enabled="false"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox id="chckBackground" Checked="false" runat="server"/>
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
                <td></td>
                <td>
                     <asp:Label ID="lblPicPath" runat="server" Text="Pic File Path: " Enabled="false" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Activity picture: " Enabled="false" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Image ID="imgPhoto" runat="server" style="max-height:150px;max-width:1500px;height:auto;width:auto;"></asp:Image>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnActivity_Save_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnActivity_Clear_Click" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Quote: " Enabled="false" ></asp:Label>
        <br />
        <asp:TextBox ID="txtQuote" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Quoted From: " Enabled="false" ></asp:Label>
        <br />
        <asp:TextBox ID="txtQuotedFrom" runat="server" Width="300"></asp:TextBox>
        <br />
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
        <br />
        <br />
        <asp:GridView ID="gvActivity" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" ShowHeader="true" >
            <Columns>
                <asp:BoundField DataField="Sequence" HeaderText="Sequence" />
                <asp:BoundField DataField="X1" HeaderText="X1" />
                <asp:BoundField DataField="X2" HeaderText="X2" />
                <asp:BoundField DataField="Y1" HeaderText="Y1" />
                <asp:BoundField DataField="Y2" HeaderText="Y2" />
                <asp:BoundField DataField="IsBackground" HeaderText="IsBackground" />
                <asp:BoundField DataField="Transparency" HeaderText="Transparency" />
                <asp:BoundField DataField="Pic" HeaderText="Pic" visible ="false"/>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="ImageIcon" runat="server"  ImageUrl='<%# Eval("Pic") %>' style="max-height:250px;max-width:250px;height:auto;width:auto;"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Sequence") %>' OnClick="EditActivity_OnClick">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Sequence") %>' OnClick="DeleteActivity_OnClick">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

            <asp:Image ID="imgPic" runat="server"></asp:Image>    
    
    </div>
    </form>
</body>
</html>
