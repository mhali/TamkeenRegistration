<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetDashboard.aspx.cs" Inherits="TamkeenRegistration.Budget.BudgetDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="BudgetDashboardForm" runat="server">
    <div>
        <asp:Button ID="btnBudget" runat="server" OnClick="Budget_Click" Text="Budget" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnEvents" runat="server" OnClick="Event_Click" Text="Manage Events" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnUnarchiveEvents" runat="server" OnClick="UnarchiveEvent_Click" Text="Unarchive Events" Height="117px" Width="449px"/>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
