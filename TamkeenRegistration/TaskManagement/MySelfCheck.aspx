<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySelfCheck.aspx.cs" Inherits="TamkeenRegistration.TaskManagement.MySelfCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblWeek" runat="server"></asp:Label>

                   <asp:GridView ID="gvSelfEvaluation" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DimensionName" HeaderText="Dimension" />
                    <asp:BoundField DataField="SelfEvaluation" HeaderText="Self Evaluation" visible="false"/>


                <asp:TemplateField HeaderText="Self Evaluation">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="lstDone" runat="server" DataValueField=" ">
                            <asp:ListItem Value=" "> </asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Leader Evaluation">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="lstDone" runat="server" DataValueField=" ">
                            <asp:ListItem Value=" "> </asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate> 
                </asp:TemplateField>


<%--                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("DivisionID") %>' OnClick="DivisionLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>




    </div>
    </form>
</body>
</html>
