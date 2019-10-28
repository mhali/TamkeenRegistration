<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Badges.aspx.cs" Inherits="TamkeenRegistration.Registration.Badges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="badges" runat="server">
    <div>
        <asp:GridView ID="gvTamkeener" runat="server" AutoGenerateColumns="false">
        <Columns>
         <asp:TemplateField>
           <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

            <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        </Columns>
        </asp:GridView>
        <br />
            <asp:Button ID="btnGetSelected" runat="server" Text="Get selected records" OnClick="GetSelectedRecords" />
        <br />
        <asp:GridView ID="gvSelected" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            AutoGenerateColumns="false" style="margin-left:10%;">
            <Columns>
                <asp:imagefield dataimageurlfield="Tamkeener_ID"
                    dataimageurlformatstring="~\Badges\{0}.png"
                    alternatetext="missing badge"
                    nulldisplaytext="missing badge"
                    headertext="TAMKEENER IDs"  
                    readonly="true"/>
            </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
