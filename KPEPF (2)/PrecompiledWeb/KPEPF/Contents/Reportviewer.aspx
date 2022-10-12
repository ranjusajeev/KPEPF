<%@ page language="C#" autoeventwireup="true" inherits="Pages_Reportviewer, App_Web_d0bqo0ey" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reports Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td><a href='MainPage.aspx'>Back</a></td></tr>
        <tr><td><CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" CssClass="reportbody" Width="100%" HyperlinkTarget="" OnUnload="CRViewer_Unload" /></td></tr>
        </table>
        </div>
    </form>
</body>
</html>
