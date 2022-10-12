<%@ page language="C#" autoeventwireup="true" inherits="Contents_AppForms, App_Web_d0bqo0ey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>APPLICATION FORMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
    <tr align="center">
    <td colspan="2" align="center" style="height: 34px"> 
    <asp:Label ID="lblAppForms" runat="server" Text="Application Forms" Width="729px" BackColor="Gainsboro" Font-Bold="True" ForeColor="Blue" Font-Names="Verdana" Font-Size="12pt"></asp:Label>
    </td>
    </tr>
    <tr></tr>
    <tr></tr>
    <tr>
    <%--<td colspan="2" align="center">
    <asp:Label ID="lblForm" runat="server" Text="Application Forms" Font-Bold="True" Font-Names="Verdana" Font-Size="12pt" ForeColor="DodgerBlue"></asp:Label>
    </td>--%>
    <td align="center" style="height: 24px">
    <asp:DropDownList ID="ddlAppForm" runat="server" OnSelectedIndexChanged="ddlAppForm_SelectedIndexChanged" Width="207px" AutoPostBack="True" TabIndex="1" ForeColor="Blue"></asp:DropDownList>
    </td>
    </tr>
    </table>
    </div>
    <div id="APP" runat="server">
    <iframe id="iframeApp" runat="server" frameborder="1" scrolling="auto" width="100%"></iframe>
    </div>
    </form>
</body>

<script language="javascript" type="text/javascript">
$(document).ready(function()
{
$(".datePicker").datepicker 
          ({
            numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});

function numericcheck()
    {
        if(document.activeElement.className == "txtNumeric")
        {
            if(((window.event.keyCode)<48 ) || ((window.event.keyCode)>57))
            {
                window.event.keyCode=0;
            }
        }
        if(document.activeElement.className == "txtNumericFloat")
        {
            if((((window.event.keyCode)<48 ) || ((window.event.keyCode)>57)) && ((window.event.keyCode)!=46))
            {
                window.event.keyCode=0;
            }
        }
    }

function ficheroCargado()
{
    fichero = "VerFichero.aspx?NOMBRE_FICHERO=" + fichero;
    document.getElementById('iframeMain' ).src=fichero;
}
function iframeMain_onclick() {

}
function hello()
{
    alert("OK");
}
</script>
</html>
