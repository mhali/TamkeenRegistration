<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDriver.aspx.cs" Inherits="TamkeenRegistration.Registration.AddDriver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="AddDriver" runat="server">
        <div style="float: left; width: 500px">
            <table>
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
                <tr>
                    <asp:Label ID="lblDriverList" runat="server" Text="Drivers List" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDriverName" runat="server" Text="Driver Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDriverName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDriverPhone" runat="server" Text="Driver Phone"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDriverPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnFSave" runat="server" Text="Add" OnClick="btnDriver_Save_Click" UseSubmitBehavior="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDriver_Delete_Click" UseSubmitBehavior="false" />
                        <asp:Button ID="btnFClear" runat="server" Text="Clear" OnClick="btnDriver_Clear_Click" UseSubmitBehavior="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvDriver" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DriverName" HeaderText="Driver Name" />
                    <asp:BoundField DataField="Phone" HeaderText="Driver Phone" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkViewDriver" runat="server" CommandArgument='<%# string.Concat(Eval("DriverName"),";",Eval("Phone")) %>' OnClick="DriverLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Tamkeeners Per Driver" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <asp:GridView ID="gvTamkeenerPerDriver" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="SequenceNo" HeaderText="#" />
                    <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="LastCheckedIn" HeaderText="CheckIn Time" />
                    <asp:BoundField DataField="CurrentDriver" HeaderText="Driver" />
                </Columns>
            </asp:GridView>

        </div>

        <div style="float: left; width: 100px">
        </div>

        <div style="float: left; width: 400px">
            <table>
                <tr>
                    <asp:Label ID="lblCheckedInTamkeeners" runat="server" Text="Checked In Tamkeener List" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCheckOut" runat="server" Text="Fast Checkout by Barcode"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCheckOut" runat="server" OnTextChanged="txtCheckOut_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSetDriver" runat="server" Text="Fast Set Driver by Barcode"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtSetDriver" runat="server" OnTextChanged="txtSetDriver_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="gvCheckedInTamkeener" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="LastCheckedIn" HeaderText="CheckIn Time" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="CheckOutTamkeener" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="CheckOutTamkeener_OnClick">CheckOut</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CurrentDriver" HeaderText="Driver" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="SetDriver" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="SetDriver_OnClick">Set Driver</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <asp:Label ID="lblCheckedoutTamkeeners" runat="server" Text="Checked OutTamkeener List" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <asp:GridView ID="gvCheckedOutTamkeener" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="LastCheckedIn" HeaderText="CheckIn Time" />
                    <asp:BoundField DataField="LastCheckedOut" HeaderText="CheckOut Time" />
                    <asp:BoundField DataField="CurrentDriver" HeaderText="Driver" />
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
