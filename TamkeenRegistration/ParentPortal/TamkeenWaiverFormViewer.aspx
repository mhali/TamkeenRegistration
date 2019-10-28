<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TamkeenWaiverFormViewer.aspx.cs" Inherits="TamkeenRegistration.Registration.WaiverForms" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Waivers" runat="server">
    <div>
    
        <asp:Label ID="LabelTamkeenerId" runat="server" Text=""></asp:Label>
        <img ID="imgBarCode" runat="server" src="data:image/gif;base64,<YOUR BASE64 DATA>" />
    
    </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="750px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px" AsyncRendering="False">
            <LocalReport ReportPath="ParentPortal\TamkeenWaivers.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSetForWaiver" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="750px" style="margin-right: 0px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px" AsyncRendering="False">
            <LocalReport ReportPath="ParentPortal\UWWaiver.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSetForWaiver" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TamkeenRegistration.ParentPortal.DataSetWaiverFormTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="LabelTamkeenerId" Name="TamkeenerID" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TamkeenRegistration.ParentPortal.DataSetWaiverFormTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="LabelTamkeenerId" Name="TamkeenerID" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        <rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" Height="750px" Width="1000px">
            <LocalReport ReportPath="ParentPortal\ScoutingForm.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSetForWaiver" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TamkeenRegistration.ParentPortal.DataSetWaiverFormTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="LabelTamkeenerId" Name="TamkeenerID" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
