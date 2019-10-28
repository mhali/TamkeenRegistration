<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TamkeenerAttendance.aspx.cs" Inherits="TamkeenRegistration.Registration.TamkeenerAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="TamkeenerAttendance" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="TamkeenerID"></asp:Label>
        <asp:Label ID="lblTamkeenerID" runat="server" Text=" "></asp:Label>
        <asp:Label ID="lblTamkeenerFName" runat="server" Text=" "></asp:Label>
        <asp:Label ID="lblTamkeenerLName" runat="server" Text=" "></asp:Label>
        <asp:GridView ID="gvTamkeenerAttendance" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="CheckInS" HeaderText="CheckIn" />
            <asp:BoundField DataField="CheckOuts" HeaderText="CheckOut" />
        </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Financial Transactions"></asp:Label>
        <br />
        <asp:GridView ID="gvTamkeenerEvents" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID"/>
            <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate"/>
            <asp:BoundField DataField="EventID" HeaderText="EventID"/>
            <asp:BoundField DataField="EventDate" HeaderText="EventDate"/>
            <asp:BoundField DataField="EventName" HeaderText="EventName"/>
            <asp:BoundField DataField="Gross" HeaderText="Gross"/>
            <asp:BoundField DataField="Fee" HeaderText="Fees"/>
            <asp:BoundField DataField="Net" HeaderText="Net"/>
            <asp:BoundField DataField="Notes" HeaderText="Notes"/>
        </Columns>
        </asp:GridView>
   </div>
   </form>
</body>
</html>
