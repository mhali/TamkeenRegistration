<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEvents.aspx.cs" Inherits="TamkeenRegistration.Budget.ManageEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left; width: 600px">
        <table>
            <tr>
                    <td>
                        <asp:Label ID="lblEventId" runat="server" Text="Event Id: " ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEventId" runat="server" Enabled="false"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td>
                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date: " ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEventDate"  runat="server" ></asp:TextBox>
                    </td>
            </tr>
            <tr>
                    <td>
                        <asp:Label ID="lblEventName" runat="server" Text="Event Name: " ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEventName" runat="server" ></asp:TextBox>
                    </td>
            </tr>
               <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnEventSave" runat="server" Text="Save" OnClick="btnEvent_Save_Click" />
                        <asp:Button ID="btnEventDelete" runat="server" Text="Delete" OnClick="btnEvent_Delete_Click" />
                        <asp:Button ID="btnEventClear" runat="server" Text="Clear" OnClick="btnEvent_Clear_Click" />
                    </td>
                </tr>
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
        </table>
            <asp:GridView ID="gvEvent" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="EventID" HeaderText="Event ID" />
                    <asp:BoundField DataField="EventDate" HeaderText="Event Date" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                    <asp:BoundField DataField="Gross" HeaderText="Gross" />
                    <asp:BoundField DataField="Fee" HeaderText="Fee" />
                    <asp:BoundField DataField="Net" HeaderText="Net" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEventView" runat="server" CommandArgument='<%# Eval("EventID") %>' OnClick="EventLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkArchive" runat="server" CommandArgument='<%# Eval("EventID") %>' OnClick="EventArchive_OnClick">Archive</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>    

    </div>
    <div style="float: left; width: 100px">&nbsp     </div>
   <div style="float: left; width: 500px">
           <asp:GridView ID="gvEventDetail" runat="server" AutoGenerateColumns="false">
                <Columns>
                     <asp:BoundField DataField="TransactionSeqNo" HeaderText="Seq No" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Date"  DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="TransactionDescription" HeaderText="Desc" />
                   <asp:BoundField DataField="Gross" HeaderText="Gross" />
                    <asp:BoundField DataField="Fee" HeaderText="Fee"/>
                    <asp:BoundField DataField="Net" HeaderText="Net" />
                    <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                    <asp:BoundField DataField="ActivityName" HeaderText="Activity Type" />
                    <asp:BoundField DataField="Tamkeener_ID" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                </Columns>
            </asp:GridView>    

   </div>

    </form>
</body>
</html>
