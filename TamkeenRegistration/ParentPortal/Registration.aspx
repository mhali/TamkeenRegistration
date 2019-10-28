<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TamkeenRegistration.ParentPortal.TamkeenRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="float: left; width: 400px">
            <table >
                <tr>
                    <td>
                        <img src="../logo no text.png" height="100" width="100"/>
                    </td>
                    <td>
                        <asp:label ID="lblTitle" runat="server"  Text="TAMKEEN Parent Portal" />
                    </td>
                </tr>
            </table>
<%--            <table border="1">
                <tr style="background-color:chartreuse;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="FamilyID " Enabled="false"></asp:Label>
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
                        <asp:TextBox ID="txtPassCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnQuickLookup" runat="server" Text="LookUp" OnClick="btnQuickLookup_Click" />
                    </td>

                </tr>
            </table>--%>
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
                <tr style="background-color:aqua;border: 1px solid #C1C1C1;" >
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Family Id: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyId" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color:aqua;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Family Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyName" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color:aqua;border: 1px solid #C1C1C1;">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Contact Parent"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtContactParent" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div style="float: left; width: 100px">&nbsp     </div>
        <div ID="divGuardian" visible="false" style="float: left; width: 400px" runat="server" >
            <asp:GridView ID="gvGuardian" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;" >
                <Columns>
                    <asp:BoundField DataField="Guardian_Id" HeaderText="Guardian ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Guardian_ID") %>' OnClick="GuardianLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSetContact" runat="server" CommandArgument='<%# Eval("Guardian_ID") %>' OnClick="GuardianSetContact_OnClick">Set as contact</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnGClear" runat="server" Text="Add New Parent/Guardian" OnClick="btnGuardian_Clear_Click" />
            <br />
            <br />

            <table border="1" >
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Guardian Id: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGuardianId" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Middle Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGMiddleName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Phone1:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGPhone1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Phone2:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGPhone2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Street"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGStreet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="City"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="State:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGState" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Zip Code:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGZipCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="lstGGender" runat="server">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="Date of Birth:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGDOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Employer:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGEmployer" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Occupation:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGOccupation" runat="server"></asp:TextBox>
                    </td>
                </tr>
<%--                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="UserName"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="RelationshipToYouth:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropdownlistRelationshipToYouth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropdownlistRelationshipToYouth_TextChanged">
                            <asp:ListItem Value="1">Parent</asp:ListItem>
                            <asp:ListItem Value="2">Guardian</asp:ListItem>
                            <asp:ListItem Value="3">Grand Parent</asp:ListItem>
                            <asp:ListItem Value="4">Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label24" runat="server" Text="Other"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtOtherRelationship" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnGSave" runat="server" Text="Save" OnClick="btnGuardian_Save_Click" />
                        <asp:Button ID="btnGDelete" runat="server" Text="Delete" OnClick="btnGuardian_Delete_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblGSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblGErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

            </table>
            <br />

        </div>
        <div style="float: left; width: 100px">&nbsp     </div>
        <div ID="divTamkeener" runat="server"  style="float: left; width: 400px" visible="false">
            <asp:GridView ID="gvTamkeener" runat="server" AutoGenerateColumns="false" style="background-color:aqua;border: 1px solid #C1C1C1;">
                <Columns>
                    <asp:BoundField DataField="Tamkeener_Id" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerLnk_OnClick">View Info</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkWaiver" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerWaiver_OnClick">Generate Waiver Forms</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
<%--                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAttendance" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerAttendance_OnClick">Attendance</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btntClear" runat="server" Text="Add New Tamkeener" OnClick="btnTamkeener_Clear_Click" />
            <br />
            <br />
            <table id="tbleTamkeenerInfo" border="1" Visible="false" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="New Photo URL: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:FileUpload ID="TamkeenUploadPhoto" runat="server"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload" OnClick="btnUploadPhoto_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Tamkeener Photo: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Image ID="imgPhoto" runat="server" Height="150px" Width="150px"></asp:Image>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4T" runat="server" Text="Tamkeener Id: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTamkeenerId" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label30" runat="server" Text="Last CheckedIn in Tamkeen: " Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastChekedIn" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5T" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6T" runat="server" Text="Middle Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTMiddleName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9T" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10T" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11T" runat="server" Text="Phone1:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTPhone1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12T" runat="server" Text="Phone2:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTPhone2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="Same household address?"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnCopyAddr" runat="server" Text="Copy Address" OnClick="btnCopyAddr_Click" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13T" runat="server" Text="Street"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTStreet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14T" runat="server" Text="City"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15T" runat="server" Text="State:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTState" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16T" runat="server" Text="Zip Code:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTZipCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17T" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="lstTGender" runat="server">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18T" runat="server" Text="Date of Birth:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTDOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19T" runat="server" Text="School Name:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTSchoolName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20T" runat="server" Text="SchoolGrade:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTSchoolGrade" runat="server"></asp:TextBox>
                    </td>
                </tr>
<%--                <tr>
                    <td>
                        <asp:Label ID="Label21T" runat="server" Text="UserName"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label23T" runat="server" Text="EthnicBackground:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropdownlistEthnicBackground" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropdownlistEthnicBackground_TextChanged">
                            <asp:ListItem Value="1">Black/African American</asp:ListItem>
                            <asp:ListItem Value="2">Native American</asp:ListItem>
                            <asp:ListItem Value="3">Alaska Native</asp:ListItem>
                            <asp:ListItem Value="4">Asian</asp:ListItem>
                            <asp:ListItem Value="5">Caucasian/White</asp:ListItem>
                            <asp:ListItem Value="6">Hispanic/Latino</asp:ListItem>
                            <asp:ListItem Value="7">Pacific Islander</asp:ListItem>
                            <asp:ListItem Value="8">Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label24T" runat="server" Text="Other"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtOtherEthnicBackground" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
<%--                <tr>
                    <td>
                        <asp:Label ID="Label31" runat="server" Text="Last Scout Registration: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastScoutRegistration" runat="server" Text="Last Scout Renew: "></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnTSave" runat="server" Text="Save" OnClick="btnTamkeener_Save_Click" />
                        <asp:Button ID="btnTDelete" runat="server" Text="Delete" OnClick="btnTamkeener_Delete_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table id="tbleWaivers" border="1" Visible="false" runat="server">
                <tr>
                    <td>
                        <asp:HyperLink ID="linkToTamkeenWaiver" runat="server" Target="_blank"> View tamkeen waiver</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="Last Uploaded: " Enabled="false"></asp:Label>
                        <asp:Label ID="lblTamkeenWaiverLastUploaded" runat="server" Text="" Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadTamkeenWaiver" runat="server"></asp:FileUpload>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnUploadTamkeenWaiver" runat="server" Text="Upload Tamkeen Waiver" OnClick="btnUploadTamkeenWaiver_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="linkToUWWaiver" runat="server" Target="_blank"> View UW waiver</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="Last Uploaded: " Enabled="false"></asp:Label>
                        <asp:Label ID="lblUWWaiverLastUploaded" runat="server" Text="" Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadUWWaiver" runat="server"></asp:FileUpload>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnUploadUWWaiver" runat="server" Text="Upload UW Waiver" OnClick="btnUploadUWWaiver_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="linkToScoutForm" runat="server" Target="_blank"> View Scout Form</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label28" runat="server" Text="Last Uploaded: " Enabled="false"></asp:Label>
                        <asp:Label ID="lblScoutFormLastUploaded" runat="server" Text="" Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadScoutForm" runat="server"></asp:FileUpload>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnUploadScoutForm" runat="server" Text="Upload Scout Form" OnClick="btnUploadScoutForm_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblTSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblTErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
