<%@ page language="C#" autoeventwireup="true" inherits="Contents_amsg, App_Web_ypdhnn_y" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<%--      <asp:Button ID="btnConfirm" runat="server" OnClick = "OnConfirm" Text = "Raise Confirm" OnClientClick = "Confirm()"/>--%>    
        <asp:Label ID="Label1" runat="server" CssClass="p1" Text="Label" Width="145px"></asp:Label>
      <asp:Button ID="btnConfirm" runat="server"  Text = "Raise Confirm" OnClick="btnConfirm_Click" />&nbsp;

</form>
</body>
</html>
