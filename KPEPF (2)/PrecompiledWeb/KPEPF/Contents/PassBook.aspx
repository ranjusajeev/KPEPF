<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_PassBook, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=3><asp:Label id="lblHead" runat="server" class="MnHead" Text="PROVIDENT FUND PASS BOOK" ></asp:Label> </TD></TR><TR><TD style="WIDTH: 683px" vAlign=top><TABLE style="MARGIN-RIGHT: 2px"><TBODY><TR><TD align=left colSpan=2><asp:Panel id="pnlSecdetails" runat="server"><asp:GridView id="gdvInboxSec" runat="server" ForeColor="#333333" Font-Size="10pt" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvInboxSec_SelectedIndexChanged" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numEmpId,intYearId" DataNavigateUrlFormatString="~/Contents/PassBook.aspx?numEmpId={0}&amp;intYearId={1}" DataTextField="numEmpId" HeaderText="Acc No.">
<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> </TD></TR><TR><TD style="WIDTH: 683px; HEIGHT: 64px" align=left><asp:Panel style="WIDTH: 683px" id="pnlDetails" runat="server" Visible="False"><TABLE style="WIDTH: 282px"><TBODY><TR><TD style="WIDTH: 75px" align=left><asp:Label id="Label1" runat="server" ForeColor="#0000C0" Text="Year" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=left><asp:DropDownList id="ddlyear" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"></asp:DropDownList> &nbsp; &nbsp; &nbsp; </TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 22px"><asp:Label id="Label2" runat="server" ForeColor="#0000C0" Text="Account No." Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD style="HEIGHT: 22px"><asp:TextBox id="txtaccno" oncopy="return false" oncut="return false" onpaste="return false" runat="server" AutoPostBack="True" OnTextChanged="txtaccno_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 86px; HEIGHT: 22px"><asp:Label id="lblAcc" runat="server" Width="62px"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 683px" align=right><asp:Panel id="pnlpassbook" runat="server"><asp:GridView id="gdvInboxTA" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvInboxTA_SelectedIndexChanged" CellSpacing="5">
<Columns>
<asp:BoundField HeaderText="Month" DataField="chvMonth" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
    <asp:TemplateField HeaderText="Date of encashment">
        <ItemTemplate>
            <asp:TextBox ID="txtdate" runat="server"  CssClass="datePicker" AutoPostBack="True"></asp:TextBox>&nbsp;
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Treasury" HeaderStyle-HorizontalAlign="Center">
        
        <ItemTemplate>
            <asp:DropDownList ID="ddlTreas" runat="server" AutoPostBack="True">
            </asp:DropDownList>&nbsp;
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Chalan No." HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            &nbsp;<asp:TextBox ID="txtchalanNo" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Chalan Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            &nbsp;<asp:TextBox ID="txtchalandate" runat="server" CssClass="datePicker" AutoPostBack="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Monthly subscription" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtsub" runat="server" MaxLength="50" Width="115px"  oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotMntnSbn" runat="server" MaxLength="50" Width="115px" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Refund of advance" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtrfamt" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotLoanRp" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Arrear Amount" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtarrAmt" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotArrPf" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Arrear GO" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:DropDownList ID="ddlGO" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="GO Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtGodate" runat="server" CssClass="datePicker" AutoPostBack="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total " HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txttotal" runat="server" AutoPostBack="True" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotRem" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Withdrawal Amount" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtwithdrawal" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotWith1" runat="server" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric"></asp:TextBox>
        </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField Visible="False" HeaderText="MonthId"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblMonthId" runat="server" Text='<%# Bind("intId") %>' BorderStyle="Solid" BorderColor="#C00000"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Withdrawal type" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Withdrawal Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtwithdate" runat="server" AutoPostBack="True" CssClass="datePicker"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="No. of instalments" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtinstNo" runat="server" AutoPostBack="True" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Amount of instalment" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtinstAmt" runat="server" AutoPostBack="True" oncut="return false" oncopy="return false" onpaste="return false"   onkeypress="return  isNumberKey(event)"  CssClass="txtNumeric" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:TextBox ID="txtrem" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView></asp:Panel> <TABLE><TBODY><TR><TD style="HEIGHT: 38px" align=right><asp:RadioButtonList id="rlist" runat="server" Width="325px" ForeColor="Navy" Font-Size="Small" Visible="False" AutoPostBack="True" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
        <asp:ListItem>Returned for Modification</asp:ListItem>
    </asp:RadioButtonList> </TD><TD style="HEIGHT: 38px" align=right><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
<script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>

</asp:Content>

