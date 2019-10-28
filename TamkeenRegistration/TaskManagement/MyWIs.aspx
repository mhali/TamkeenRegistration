<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWIs.aspx.cs" Inherits="TamkeenRegistration.TaskManagement.MyWIs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--            <asp:GridView ID="gvDivision" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DivisionID" HeaderText="Division Id" visible="false"/>
                    <asp:BoundField DataField="DivisionName" HeaderText="Division:" />
                    <asp:BoundField DataField="BoysAdminName" HeaderText="Boys Admin" />
                    <asp:BoundField DataField="GirlsAdminName" HeaderText="Girls Admin" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("DivisionID") %>' OnClick="DivisionLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <br />
        <br />
            <asp:GridView ID="gvCommitment" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CommitmentID" HeaderText="Commitment Id" visible="false"/>
                    <asp:BoundField DataField="DivisionID" HeaderText="Division Id" visible="false"/>
                    <asp:BoundField DataField="CommitmentName" HeaderText="Commitment:" />
                    <asp:BoundField DataField="BoysAdminName" HeaderText="Boys Admin" />
                    <asp:BoundField DataField="GirlsAdminName" HeaderText="Girls Admin" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("CommitmentID") %>' OnClick="CommitmentLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <br />
        <br />
    
            <asp:GridView ID="gvTask" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TaskID" HeaderText="Task Id" visible="false"/>
                    <asp:BoundField DataField="CommitmentID" HeaderText="Commitment Id" visible="false"/>
                    <asp:BoundField DataField="TaskName" HeaderText="Task:" />
                    <asp:BoundField DataField="BoysAdminName" HeaderText="Boys Admin" />
                    <asp:TemplateField HeaderText="Boys WIs">
                        <ItemTemplate>
                            <asp:LinkButton  ID="BoyslnkView" runat="server" CommandArgument='<%# Eval("TaskID") %>' OnClick="BoysTaskLnk_OnClick" >View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="GirlsAdminName" HeaderText="Girls Admin" />
                    <asp:TemplateField HeaderText="Girls WIs">
                        <ItemTemplate>
                            <asp:LinkButton ID="GirlslnkView" runat="server" CommandArgument='<%# Eval("TaskID") %>' OnClick="GirlsTaskLnk_OnClick" >View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Info" HeaderText="Additional Info" />
                </Columns>
            </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblMessage" Font-Size="X-Large" runat="server"></asp:Label>
        <asp:Label ID="lblCurrentTaskId" Font-Size="X-Large" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCurrentGender" Font-Size="X-Large" runat="server" Visible="false"></asp:Label>--%>
        <br />
        <br />
            <asp:GridView ID="gvWi" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DivisionName" HeaderText="Division"/>
                    <asp:BoundField DataField="CommitmentName" HeaderText="Commitment"/>
                    <asp:BoundField DataField="TaskName" HeaderText="Task"/>
                    <asp:BoundField DataField="WiID" HeaderText="WI Id" visible="false"/>
                    <asp:BoundField DataField="TaskId" HeaderText="Task Id" visible="false"/>
                    <asp:BoundField DataField="WiName" HeaderText="WI:" ItemStyle-Width="100px"/>
                    <asp:BoundField DataField="WiDesc" HeaderText="Description" ItemStyle-Width="200px"/>
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="DeadLine" HeaderText="Deadline" />
                    <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                    <asp:BoundField DataField="LastUpdated" HeaderText="Last updated" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" visible="false"/>
<%--                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="WilnkView" runat="server" CommandArgument='<%# Eval("WiID") %>' OnClick="WiLnk_OnClick" >View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="WilnkClose" runat="server" CommandArgument='<%# Eval("WiID") %>' OnClick="WiClose_OnClick" >Close</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
          <%--<asp:Button ID="btnAddNew" runat="server" Text="Add New Work Item" OnClick="btnAddNewWI_Click" visible="false"/>--%>
        <br />
        <br />
        </div>
<%--        <div id="WiDiv" runat="server">
        <table>
            <tr>
                <td colspan="2">
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWiId" runat="server" Text="Work Item Id:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtWiId" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTaskId" runat="server" Text="Task Id:" Enabled="false" Visible="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtTaskId" runat="server" Enabled="false" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWiName" runat="server" Text="Work Item Name:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtWiName" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWiDesc" runat="server" Text="Description:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Status" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DropdownlistStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDeadline" runat="server" Text="Deadline:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDeadline" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDateCreated" runat="server" Text="Date Created:" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDateCreated" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDateUpdated" runat="server" Text="Last Updated" Enabled="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDateUpadted" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGender" runat="server" Text="Gender" Enabled="false" Visible="false"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtGender" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSaveWI_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>--%>
    </form>
</body>
</html>
