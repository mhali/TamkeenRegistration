<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationDashboard.aspx.cs" Inherits="TamkeenRegistration.Registration.RegistrationDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegistrationDashboardForm" runat="server">
    <div>
    
    </div>
        <asp:Button ID="btnRegistration" runat="server" OnClick="Registration_Click" Text="Registration" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnCheckOut" runat="server" OnClick="Checkout_Click" Text="Carpooling/Checkout" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnAttendance" runat="server" OnClick="Attendance_Click" Text="Attendance" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnBadges" runat="server" OnClick="Badges_Click" Text="Badges" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnUnarchive" runat="server" OnClick="Unarchive_Click" Text="Unarchive Tamkeeners" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnParentPortal" runat="server" OnClick="ParentPortal_Click" Text="Parent Portal" Height="117px" Width="449px"/>

    </form>
</body>
</html>
