<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditCard1, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
      <ContentTemplate>
  <table  width="100%" border="0">
    <tbody>
         <tr>
        <td  colspan="2" class="TdMnHead"><asp:Label id="lblHead"  runat="server" Text="Credit Card" class="MnHead"></asp:Label><%--<asp:TextBox id="txtMEMReqID" runat="server" text="0" Visible="False" OnTextChanged="txtMEMReqID_TextChanged"></asp:TextBox>--%></td>
    </tr>
    <tr>
    <td align="left" >
        <asp:Label ID="Label1" runat="server" Text="Account No." Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
    <td align="left">
        <asp:TextBox ID="tctAccNo" runat="server" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return isNumberKey(event)" onpaste="return false" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="tctAccNo_TextChanged"></asp:TextBox>
    </td>
        
    </tr>
    <tr>
    <td  >
        <asp:Label ID="Label2" runat="server" Text="Year" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList runat="server" Width="159px" TabIndex="11" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
     
    </td>
        
    </tr>
    <tr>
    <td  colspan="2" style="height: 215px" >
    <div id="PDE" runat="server">
    <iframe id="iframePDE" runat="server" frameborder="1" scrolling="auto" width="100%"></iframe>
    </div>

    </td>
    </tr>
    </tbody>
    </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    <script language=javascript type="text/javascript">
 function isNumberKey(evt)
    {
        if(document.activeElement.className == "txtNumeric"||document.activeElement.className == "txtBoxNumericPhone")
        {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 48 || charCode > 57) && charCode != 8)
             return false;
             else
             return true;
        }
        if(document.activeElement.className == "txtNumericFloat")
        {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode != 46 && (charCode < 48 || charCode > 57))
             return false;
             else
             return true;
        }
    }
   
	</script>
</asp:Content>

