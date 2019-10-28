<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Budget.aspx.cs" Inherits="TamkeenRegistration.Budget.BudgetForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Budget" runat="server" width="2500px">
   <div style="width: 1800px;">
    <div style="float: left; width: 600px">
            <table>
                <tr>
                   <td colspan="2">
                        <asp:FileUpload ID="fileUploadBank" runat="server"></asp:FileUpload>
                    </td>
                    <td>
                        <asp:Button ID="btnUploadBank" runat="server" Text="Upload Bank CSV file" OnClick="btnUploadBank_Click" />
                    </td>
               </tr>
                <tr>
                    <td>
                    <br />
                    <br />
                        </td>
                 </tr>              
                <tr>
                   <td colspan="2">
                        <asp:FileUpload ID="fileUploadPayPal" runat="server"></asp:FileUpload>
                    </td>
                    <td>
                        <asp:Button ID="btnUploadPayPal" runat="server" Text="Upload PayPal CSV file" OnClick="btnUploadPayPal_Click" />
                    </td>
               </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblBudgetSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblBudgetErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    <br />
                    <br />
                        </td>
                 </tr>
              </table>
            <asp:GridView ID="gvSummaries" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                </Columns>
           </asp:GridView>
        <br />
        <br />
            <asp:GridView ID="gvAccounts" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="AccountID" HeaderText="AccountID" Visible="false"/>
                    <asp:BoundField DataField="AccountName" HeaderText="AccountName" />
                    <asp:BoundField DataField="Gross" HeaderText="Gross" />
                    <asp:BoundField DataField="Fee" HeaderText="Fees" />
                   <asp:BoundField DataField="Net" HeaderText="Net" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAccountView" runat="server" CommandArgument='<%# Eval("AccountID") %>' OnClick="AccountLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        <br />
        <br />
        <table>
            <tr>
                <td>
                     <asp:Label ID="lblFromDate" runat="server" Text="From Date: " ></asp:Label>
                    <asp:TextBox ID="txtFromDate" type="date" runat="server"></asp:TextBox>
                </td>
               <td>
                     <asp:Label ID="lblToDate" runat="server" Text="To Date: " ></asp:Label>
                    <asp:TextBox ID="txtToDate" type="date" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
            <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TransactionSeqNo" HeaderText="Seq No" Visible="false"/>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Date"  DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="TransactionDescription" HeaderText="Desc" />
                    <asp:BoundField DataField="Gross" HeaderText="Gross" />
                    <asp:BoundField DataField="Fee" HeaderText="Fees" />
                    <asp:BoundField DataField="Net" HeaderText="Net" />
                   <asp:BoundField DataField="TransactionType" HeaderText="Type"  Visible="false"/>
                   <asp:BoundField DataField="TransactionStatus" HeaderText="Status"  Visible="false"/>
                   <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
                   <asp:BoundField DataField="Email1" HeaderText="From Email"  Visible="false"/>
                   <asp:BoundField DataField="Email2" HeaderText="To EMail"  Visible="false"/>
                   <asp:BoundField DataField="Notes" HeaderText="Notes"  Visible="false"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkTransactionView" runat="server" CommandArgument='<%# Eval("TransactionSeqNo") %>' OnClick="TransactionLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>
         <div style="float: left; width: 100px">&nbsp     </div>
        <div style="float: left; width: 400px">
            <table>
                 <tr>
                    <td>
                        <asp:Label ID="lblSeqNo" runat="server" Text="Transaction Seq No"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTrasSeqNo" runat="server"  Enabled="false"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td>
                        <asp:Label ID="lblTransDate" runat="server" Text="Transaction Date"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransDate"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDesc" runat="server" Text="Transaction Desc"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransDesc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGross" runat="server" Text="Gross"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransGross" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFees" runat="server" Text="Fees"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransFees"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNet" runat="server" Text="Net"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="transtxtNet"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransType"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransStatus" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTransID" runat="server" Text="Transaction ID"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFromEmail" runat="server" Text="From Email"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransFromEmail"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblToEmail" runat="server" Text="To Email"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransToEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTransNotes"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnTransClear" runat="server" Text="Clear" OnClick="btnTransClear_Click" />                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnTransUpdate" runat="server" Text="Update" OnClick="btnTransUpdate_Click" />
                        <asp:Button ID="btnTransDelete" runat="server" Text="Delete" OnClick="btnTransDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnTransAddCashBoy" runat="server" Text="Add to Boy Cash" OnClick="btnTransAddBoyCash_Click" />
                        <asp:Button ID="btnTransAddCashGirl" runat="server" Text="Add to Girl Cash" OnClick="btnTransAddGirlCash_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblTransSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblTransErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr style="border: 0px; border-top: 2px dashed black; width: 350px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblReceipts" runat="server" Text="Receipts" ></asp:Label>
                    </td>
                </tr>
            </table>
                <asp:GridView ID="gvReceipts" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="ReceiptNo" HeaderText="ReceiptNo" />
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkReceiptView" runat="server" CommandArgument='<%# Eval("ReceiptNo") %>' OnClick="ReceiptViewLnk_OnClick">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkReceiptDelete" runat="server" CommandArgument='<%# Eval("ReceiptNo") %>' OnClick="ReceiptDeleteLnk_OnClick">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblReceipt" runat="server" Text="Receipt: " ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:FileUpload ID="uploadReceipt" runat="server"></asp:FileUpload>
                    </td>
                     <td>
                        <asp:Button ID="btnUploadReceipt" runat="server" Text="Upload" OnClick="btnUploadReceipt_Click" />
                    </td>
                    </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblReceiptSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblReceiptErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
               </tr>
            </table>
                        <asp:Image ID="imgReceipt" runat="server"></asp:Image>
                        <asp:Button ID="ClearReciptImage" runat="server" Text="Clear Receipt Image" OnClick="btnClearReceipt_Click" Visible="false"/>
       </div>
          <div style="float: left; width: 100px">&nbsp    </div>
        <div style="float: left; width: 400px">
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblTransMapping" runat="server" Text="Transaction to Event Mapping" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPercentage" runat="server" Text="Percentage: " ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPercentage" Text="100" runat="server" AutoPostBack="true"  OnTextChanged="txtPercentage_TextChanged" ></asp:TextBox>
                    </td>

                                        <td>
                        <asp:Label ID="lblPartialAMount" runat="server" Text="Partial Amount: "    ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrossAmount" Text="100" runat="server" AutoPostBack="true"  OnTextChanged="txtGrossAmount_TextChanged"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBranch" runat="server" Text="Branch:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="lstBudgetBranch" runat="server">
                            <asp:ListItem Value="1">General Budget</asp:ListItem>
                            <asp:ListItem Value="2">Boys Budget</asp:ListItem>
                            <asp:ListItem Value="3">Girls Budget</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEvent" runat="server" Text="Event:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="lstEvent" runat="server">
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTamkeenerId" runat="server" Text="TamkeenerID: "    ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtParticipantID" runat="server" ></asp:TextBox>
                    </td>
                </tr>
 
                <tr>
                    <td>
                        <asp:Label ID="lblActivityType" runat="server" Text="Activity Type:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="lstActivityType" runat="server">
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                          <asp:Button ID="btnAddDetails" runat="server" Text="Add Budget Item Detail" OnClick="btnAddDetail_Click" />   
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblBIDSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblBIDErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                  <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
               <asp:GridView ID="gvItemDetails" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="TransactionSeqNo" HeaderText="TransactionSeqNo" visible="false"/>
                    <asp:BoundField DataField="BudgetItemDetailSeqNo" HeaderText="BudgetItemDetailSeqNo" visible="false"/>
                     <asp:BoundField DataField="Gross" HeaderText="Gross" />
                     <asp:BoundField DataField="EventID" HeaderText="Event ID" />
                     <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                     <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                     <asp:BoundField DataField="ActivityName" HeaderText="Activity Type" />
                     <asp:BoundField DataField="Tamkeener_ID" HeaderText="Participant ID" />
                     <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                     <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkReceiptDelete" runat="server" CommandArgument='<%# Eval("BudgetItemDetailSeqNo") %>' OnClick="DetailDeleteLnk_OnClick">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
       </div>
    </form>
</body>
</html>
