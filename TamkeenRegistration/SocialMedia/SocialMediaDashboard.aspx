<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocialMediaDashboard.aspx.cs" Inherits="TamkeenRegistration.SocialMedia.SocialMediaDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEventSummaries" runat="server" OnClick="EventSummaries_Click" Text="Event Sumaries" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnSuggestedVideos" runat="server" OnClick="SuggestedVideo_Click" Text="Suggested Videos" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnAddQuiz" runat="server" OnClick="AddQuiz_Click" Text="Add Quiz" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnAgenda" runat="server" OnClick="Agenda_Click" Text="Agenda" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnAward" runat="server" OnClick="Award_Click" Text="Award" Height="117px" Width="449px"/>
       <br />
        <br />
        <asp:Button ID="btnQuote" runat="server" OnClick="Quote_Click" Text="Quote" Height="117px" Width="449px"/>
       <br />
        <br />
    </div>
    </form>
</body>
</html>
