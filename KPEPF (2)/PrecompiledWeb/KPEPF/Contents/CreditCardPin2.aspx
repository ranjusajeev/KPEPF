<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditCardPin2, App_Web_rihpu3hj" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
   
<table width=40%>
<tr><td Class="TdMnHead" > 
    <asp:Label ID="Label1"  CssClass="MnHead" runat="server" Text="Credit Card"></asp:Label> </td></tr>
    <tr align="center"><td>
    
    <asp:Panel id="pnl" runat="server" Width="97%"  BorderStyle="Solid" BorderColor="RoyalBlue" >
    <table >
<tr><td><asp:Label ID="Label2" CssClass="p1" runat="server" Text="Account No"></asp:Label></td><td><asp:TextBox ID="txtUser" runat="server" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" Width="150px" Text="" MaxLength="5" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtUser_TextChanged"></asp:TextBox>
<asp:Label ID="lblClosed" CssClass="p4" runat="server" Text="..."></asp:Label>
</td></tr>
<tr><td><asp:Label CssClass="p1" ID="Label3" runat="server" Text="Pin"></asp:Label></td><td> <asp:TextBox ID="txtPin" runat="server" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" Width="150px" Text="" MaxLength="5" CssClass="txtNumeric" ToolTip="Use 123 as Pin"></asp:TextBox></td></tr>
<tr align="center"><td style="text-align: right" colspan="2"><asp:Button ID="btnLogin" runat="server" Text="Credit Card" OnClick="btnLogin_Click" Width="84px" />
    <asp:Button ID="btnLogin2" runat="server" Text="Annual Statement" OnClick="btnLogin2_Click" Width="111px" />
    </td></tr>
 <tr> <TD><font color="red"><MARQUEE direction=left>For availing Credit Card, U may use a temp. PIN as <B>123</B> till it is substituted with the numeric part of DOB</MARQUEE></TD> </tr>
     </table>
        
     </asp:Panel>
      <asp:Panel id="pnlCardCons" runat="server" Width="97%"  BorderStyle="Solid" BorderColor="RoyalBlue" Visible="false" >
    <table >
<tr><td>

    <asp:GridView id="gdvCardCons" runat="server" Width="500px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="slno" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cnt" HeaderText="Count">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dt" HeaderText="Date of Process">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

</td></tr>

     </table>
        
     </asp:Panel>
     </td></tr>
   <%-- <tr> <TD><font color="red"><MARQUEE direction=left>For availing Credit Card, U may use a temp. PIN as <B>123</B> till it is substituted with the numeric part of DOB</MARQUEE></TD> </tr>--%>
</table>

</ContentTemplate>

    </asp:UpdatePanel>
    
    
</asp:Content>

