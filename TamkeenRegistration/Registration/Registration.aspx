<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TamkeenRegistration.TamkeenRegistrationForm" %>

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
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="Quick lookup: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtQuicklookup" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnQuickLookup" runat="server" Text="LookUp" OnClick="btnQuickLookup_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCheckIn" runat="server" Text="Check In" OnClick="btnCheckIn_Click" />
                    </td>
                    <td></td>
                </tr>
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
                <tr>
                    <td colspan="3">
                        <hr style="border: 0px; border-top: 2px dashed black; width: 350px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Family Id: " Enabled="false"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyId" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Family Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Notes"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label32" runat="server" Text="Email" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmail" runat="server" enabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label34" runat="server" Text="Username" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUserName" runat="server" enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label33" runat="server" Text="Last parent access" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtLastLogin" runat="server" enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGeneratePassCode" runat="server" Text="Generate Passcode" OnClick="btnGeneratePassCode_Click" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtPassCode" runat="server" enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnEmailPassCode" runat="server" Text="Email Passcode" OnClick="btnEmailPassCode_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label22" runat="server" Text="Main Guardian ID"></asp:Label>
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:DropDownList ID="DropdownlistMainGuardian" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnFamily_Save_Click" />
                        <asp:Button ID="btnFDelete" runat="server" Text="Delete" OnClick="btnFamily_Delete_Click" />
                        <asp:Button ID="btnFClear" runat="server" Text="Clear" OnClick="btnFamily_Clear_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblFSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblFErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

            </table>
            <br />
            <asp:GridView ID="gvFamily" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Family_Id" HeaderText="Family ID" />
                    <asp:BoundField DataField="FamilyName" HeaderText="Family Name" />
                    <asp:BoundField DataField="FamilyNotes" HeaderText="Notes" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Family_ID") %>' OnClick="FamilyLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="float: left; width: 100px">&nbsp     </div>
        <div style="float: left; width: 400px">
            <asp:GridView ID="gvGuardian" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Guardian_Id" HeaderText="Guardian ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Guardian_ID") %>' OnClick="GuardianLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr style="border: 0px; border-top: 2px dashed black; width: 350px;" />
            <table>
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
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="UserName"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
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
                        <asp:Button ID="btnGClear" runat="server" Text="Clear" OnClick="btnGuardian_Clear_Click" />
                    </td>
                </tr>
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
        <div style="float: left; width: 400px">
            <asp:GridView ID="gvTamkeener" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Tamkeener_Id" HeaderText="Tamkeener ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkWaiver" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerWaiver_OnClick">Waiver</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAttendance" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerAttendance_OnClick">Attendance</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkArchive" runat="server" CommandArgument='<%# Eval("Tamkeener_ID") %>' OnClick="TamkeenerArchive_OnClick">Archive</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr style="border: 0px; border-top: 2px dashed black; width: 350px;" />
            <table>
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
                        <asp:Label ID="Label30" runat="server" Text="LastCheckedIn: " Enabled="false"></asp:Label>
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
                        <asp:Label ID="Label27" runat="server" Text="Same household address"></asp:Label>
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
                <tr>
                    <td>
                        <asp:Label ID="Label21T" runat="server" Text="UserName"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTUserName" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Generate Passcode" OnClick="btnGenerateTPassCode_Click" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtTPassCode" runat="server" enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Email Passcode" OnClick="btnEmailTPassCode_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label35" runat="server" Text="Last Access"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTLastAccess" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
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
                <tr>
                    <td>
                        <asp:Label ID="Label31" runat="server" Text="Last Scout Registration: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastScoutRegistration" runat="server" Text="Last Scout Renew: "></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnTSave" runat="server" Text="Save" OnClick="btnTamkeener_Save_Click" />
                        <asp:Button ID="btnTDelete" runat="server" Text="Delete" OnClick="btnTamkeener_Delete_Click" />
                        <asp:Button ID="btntClear" runat="server" Text="Clear" OnClick="btnTamkeener_Clear_Click" />
                    </td>
                </tr>
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
