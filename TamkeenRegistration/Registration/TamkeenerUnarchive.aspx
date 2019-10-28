<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TamkeenerUnarchive.aspx.cs" Inherits="TamkeenRegistration.Registration.TamkeenerUnarchive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="TamkeenerUnarchiveForm" runat="server">
    <div>
         <asp:Label ID="lblArchivedTamkeeners" runat="server" Text="Archived Tamkeener List:"></asp:Label>
        <asp:GridView ID="gvTamkeener" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID"/>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUnArchive" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerUnArchive_OnClick">Unarchive</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
