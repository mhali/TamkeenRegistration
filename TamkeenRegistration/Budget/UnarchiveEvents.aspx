<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnarchiveEvents.aspx.cs" Inherits="TamkeenRegistration.Budget.UnarchiveEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="UnarchiveEventForm" runat="server">
    <div>
         <asp:Label ID="lblArchivedEvents" runat="server" Text="Archived Event List:"></asp:Label>
            <asp:GridView ID="gvArchivedEvent" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="EventID" HeaderText="Event ID" />
                    <asp:BoundField DataField="EventDate" HeaderText="Event Date" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                    <asp:BoundField DataField="Gross" HeaderText="Gross" />
                    <asp:BoundField DataField="Fee" HeaderText="Fee" />
                    <asp:BoundField DataField="Net" HeaderText="Net" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUnarchive" runat="server" CommandArgument='<%# Eval("EventID") %>' OnClick="EventUnarchive_OnClick">Unarchive</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>    
    
    </div>
    </form>
</body>
</html>
