<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TamkeenRegistration.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <asp:Button ID="btnRegistrationDashboard" runat="server" OnClick="RegistrationDashboard_Click" Text="Registration Dashboard" Height="117px" Width="449px"/>
        <br />
        <br />
        <asp:Button ID="btnBudgetDashboard" runat="server" OnClick="BudgetDashboard_Click" Text="Budget Dashbaord" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnSocialMedia" runat="server" OnClick="SocialMedia_Click" Text="Social Media" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnTaskManagement" runat="server" OnClick="TaskManagement_Click" Text="Task Management" Height="117px" Width="449px"/>
       <br />
        <br />
    </div>
    </form>
</body>
</html>
