<%@ page language="C#" autoeventwireup="true" inherits="Reports_Reports, App_Web_d0bqo0ey" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../Style.css" type="text/css" rel="stylesheet"/>
    <title>Reports</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmReports" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" DisplayGroupTree="False" HasSearchButton="False" HasToggleGroupTreeButton="False" />
       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer>--%>
        <asp:Label ID=lblCopy runat=server Text="No of Copies" CssClass=p1></asp:Label>
        <asp:TextBox ID=txtNoCopy runat=server width=50px>1</asp:TextBox>
        <asp:Label ID=Label1 runat=server Text="No of Pages" CssClass=p1></asp:Label>
        <asp:TextBox ID=txtNoPages runat=server width=50px >1</asp:TextBox>
        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print"  OnClick="btnPrint_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Back"  OnClick="btnCancel_Click" />
    </div>
    </form>
</body>
</html>
