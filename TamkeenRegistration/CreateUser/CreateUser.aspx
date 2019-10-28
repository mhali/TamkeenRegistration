<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="TamkeenRegistration.CreateUser.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="CreateUserForm" runat="server">
    <div style="font-family:Arial">
        <table >
            <tr>
                <td>
                    <img src="../logo no text.png" height="100" width="100"/>
                </td>
                <td>
                    <asp:label ID="lblTitle" runat="server"  Text="TAMKEEN" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                <b>New User Registration </b>
                </td>
            </tr>
        </table>
    <table style="border: 1px solid black">
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Please select account type:"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="lstAccountType" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="lstAccountType_SelectedIndexChanged">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="M">Family Account</asp:ListItem>
                    <asp:ListItem Value="F">Tamkeener Account</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>

        <br />

            <table border="1" id="tblfamilyPassCode" Visible="false" runat="server">
                <tr style="background-color:chartreuse;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="lblId" runat="server" Text="FamilyID " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyLookupId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr  style="background-color:chartreuse;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="Label32" runat="server" Text="Passcode " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyPassCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnQuickLookup" runat="server" Text="LookUp" OnClick="btnQuickLookup_Click" />
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblLookUpSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblLookUpErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
               </table>
            <br />
            <br /> 
            <table id="tbleFamily" border="1" visible="false" runat="server">
<%--                <tr style="background-color:aqua;border: 1px solid #C1C1C1;" >
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Family Id: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyId" runat="server" Enabled="false" ></asp:TextBox>
                    </td>
                </tr>--%>
                <tr style="background-color:aqua;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Registered Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyName" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>


        <table id="accountDetails" Visible="false" runat="server">
            <tr>
            <td>
                Choose Your User Name:
            </td>    
            <td>
                <asp:TextBox ID="txtUserName" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername" 
                runat="server" ErrorMessage="User Name required" Text="*"
                ControlToValidate="txtUserName" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>    
        </tr>
        <tr>
            <td>
                Password:
            </td>    
            <td>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" 
                runat="server" ErrorMessage="Password required" Text="*"
                ControlToValidate="txtPassword" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>    
        </tr>
        <tr>
            <td>
                Confirm Password:
            </td>    
            <td>
                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" 
                runat="server" ErrorMessage="Confirm Password required" Text="*"
                ControlToValidate="txtConfirmPassword" ForeColor="Red" 
                Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server" 
                ErrorMessage="Password and Confirm Password must match"
                ControlToValidate="txtConfirmPassword" ForeColor="Red" 
                ControlToCompare="txtPassword" Display="Dynamic"
                Type="String" Operator="Equal" Text="*">
                </asp:CompareValidator>
            </td>    
        </tr>
        <tr>
            <td>
                Email:
            </td>    
            <td>
                <asp:TextBox ID="txtEmail" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" 
                runat="server" ErrorMessage="Email required" Text="*"
                ControlToValidate="txtEmail" ForeColor="Red"
                Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" 
                runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtEmail"
                ForeColor="Red" Display="Dynamic" Text="*"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </td>    
        </tr>
        <tr>
            <td>
                   
            </td>    
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" onclick="btnRegister_Click"/>
            </td>    
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red">
                </asp:Label>
            </td>    
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
            </td>    
        </tr>
    </table>
    </div>    
    </form>
</body>
</html>
