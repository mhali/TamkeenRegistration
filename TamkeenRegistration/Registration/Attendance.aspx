<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="TamkeenRegistration.Registration.Attendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="AttendanceForm" runat="server">
    <div style="float: left; width: 600px">
        <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>
        <asp:TextBox ID="txtAttendanceDate" type="date" runat="server" OnTextChanged="txtAttendanceDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                <br />
        <br />
            <asp:Label ID="lblAttendane" runat="server" Text="Attendance...."></asp:Label>
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="false">
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
            <asp:GridView ID="gvStats" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                    <asp:BoundField DataField="HeadCount" HeaderText="HeadCount" />
                </Columns>
            </asp:GridView>
        <br />
        <br />
    </div>
   <div style="float: left; width: 100px">&nbsp     </div>
   <div style="float: left; width: 400px">
            <asp:Label ID="lblAbsence" runat="server" Text="Absence...."></asp:Label>
        <asp:GridView ID="gvTamkeenerAbsence" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
       </Columns>
    </asp:GridView>
   </div>
    </form>
</body>
</html>
