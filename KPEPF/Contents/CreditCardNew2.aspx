<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCardNew2.aspx.cs" Inherits="Contents_CreditCardNew2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <table  width="100%" border="0">
    <tbody>

    <tr>
    <td align="center" style="height: 22px" >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="lblAccNo"  runat="server" Text="..." Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue" Width="107px"></asp:Label>
        
    </td>
    <td align="left" style="height: 22px">
        <asp:TextBox ID="tctAccNo" runat="server" oncut="return false" oncopy="return false" onpaste="return false" Visible="false" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True"  Width="77px"></asp:TextBox>
        <asp:Label ID="lblName"  runat="server" Text="..." Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
        
</tr>
         <TR><TD style="WIDTH: 1027px" align=center colSpan=3>
             <asp:Label ID="Label21" runat="server" Text="Annual Statement -" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue" Visible="False"></asp:Label>
             <asp:Label ID="lblyrann" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue" Visible="False"></asp:Label>
</td>
    </tr>
        <TR><TD style="WIDTH: 1027px" align=center colSpan=3><asp:GridView id="gdvAnnStmnt" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId,PerYearId,PerMonthId,intDistID,PDEYear" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;PerYearId={4}&amp;PerMonthId={5}&amp;intDistID={6}&amp;PDEYear={7}" DataTextField="ChalanDet" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>--%>
    <asp:BoundField DataField="ChalanDet" HeaderText="Chalan">  
<ItemStyle HorizontalAlign="left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="fltSubnAmt" HeaderText="Subn.  Amount  ">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRePaymentAmt" HeaderText="Ref. Amount ">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPFAmt" HeaderText="Arr. PF">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearDA" HeaderText="Arr. DA">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPay" HeaderText="Arr. Pay">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltTotal" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAllottedAmt" HeaderText="Withdrawal">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>
     <TR><TD style="WIDTH: 1027px" align=left colSpan=3>  <asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button></TD></TR>
     </tbody>
    </table>
</asp:Content>

