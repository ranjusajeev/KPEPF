<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditCardNew, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<table  width="100%" border="0">
    <tbody>
         <tr>
        <td  colspan="2" class="TdMnHead" ><asp:Label id="lblHead"  runat="server" Text="Credit Card" class="MnHead"></asp:Label><%--<asp:TextBox id="txtMEMReqID" runat="server" text="0" Visible="False" OnTextChanged="txtMEMReqID_TextChanged"></asp:TextBox>--%></td>
    </tr>
    <tr>
    <td align="center" style="height: 22px" >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="lblAccNo"  runat="server" Text="..." Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue" Width="107px"></asp:Label>
        
    </td>
    <td align="left" style="height: 22px">
        <asp:TextBox ID="tctAccNo" runat="server" oncut="return false" oncopy="return false" onpaste="return false" Visible="false" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="tctAccNo_TextChanged" Width="77px"></asp:TextBox>
        <asp:Label ID="lblName"  runat="server" Text="..." Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
        

    <tr>
    <td align="center" >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Year" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList runat="server" Width="159px" TabIndex="11" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;
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
</asp:Content>

