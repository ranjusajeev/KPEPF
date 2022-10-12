<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="AdvanceProc.aspx.cs" Inherits="Contents_AdvanceProc" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<table style="width: 100%">

<tr>
<%--<td colspan="4" style="WIDTH: 116px; COLOR: black; BACKGROUND-COLOR: #ccd0e6" align="center" height="26" ;><asp:Label id="lblHead" class="Head1" runat="server" Text="Sanction Order"></asp:Label></td>--%>
<td  colspan="4" class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" CssClass="MnHead" Text="Sanction Order"></asp:Label>
            </td>
</tr>
<tr><td align="center" colspan="2">
<asp:RadioButtonList id="rdPrcess" runat="Server" ForeColor="RoyalBlue" Font-Size="10pt" Font-Names="Verdana" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True"  Enabled="true">
<asp:ListItem Selected="True">TA <=75000 &nbsp &nbsp </asp:ListItem>
<asp:ListItem>TA >75000 & <=200000 &nbsp &nbsp</asp:ListItem>
<asp:ListItem>TA >200000 &nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA <=200000&nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA >200000 &nbsp &nbsp </asp:ListItem>
</asp:RadioButtonList>
</td></tr>
<%--<tr>

<td style="width: 51px" align="center"><asp:Label ID="lblLBName" class="p1" runat="server" Text="Local Body" Font-Size="Small" Width="116px" ></asp:Label></td>
<td><asp:DropDownList ID="ddlLBName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLBName_SelectedIndexChanged"></asp:DropDownList></td>
</tr>--%>
<tr>
<td colspan="4" align="center" style="width: 1027px">
<asp:Panel ID="pnlSanction" runat="server" Visible="true">
<asp:GridView ID="gvSanction" runat="server" ForeColor="#333333" Width="792px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" HorizontalAlign="Center">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="Sl. No." />
<asp:BoundField  HeaderText="  Date of Request  " DataField="dtmDateOfRequest">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Account No." DataField="chvPF_No">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Employee Name" DataField="chvName">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="File No." DataField="chvFileNo">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkAll" runat="server" Text="Check All" OnCheckedChanged="chkAll_CheckedChanged" Checked="True" AutoPostBack="True"  />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkApp" runat="server" Checked="True" />
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
</asp:GridView>
</asp:Panel>
<asp:Panel ID="pnlBill" runat="server" Visible="true">
<asp:GridView ID="gvBill" runat="server" ForeColor="#333333" Width="792px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="Sl. No." />
<asp:BoundField  HeaderText="Date of Request" DataField="dtmDateOfRequest">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Account No." DataField="chvPF_No">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Employee Name" DataField="chvName">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="File No." DataField="chvFileNo">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkAll" runat="server" Text="Check All" OnCheckedChanged="chkAll_CheckedChanged" Checked="True" AutoPostBack="True" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkApp" runat="server" Checked="True" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
</asp:GridView>
</asp:Panel>
<asp:Panel ID="pnlAcquttance" runat="server" Visible="true">
<asp:GridView ID="gvAcqutt" runat="server" ForeColor="#333333" Width="792px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" UseAccessibleHeader="False">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="Sl. No." />
<asp:BoundField  HeaderText="Date of Request" DataField="dtmDateOfRequest">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Account No." DataField="chvPF_No">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="Employee Name" DataField="chvName">
    <ItemStyle Width="55px" HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField  HeaderText="File No." DataField="chvFileNo">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkAll" runat="server" Text="Check All" OnCheckedChanged="chkAll_CheckedChanged" Checked="True" AutoPostBack="True" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkApp" runat="server" Checked="True" />
</ItemTemplate>
</asp:TemplateField>
    
    <asp:TemplateField HeaderText="Date of Withdrawal">
        <ItemTemplate>
            <asp:TextBox ID="txtDtW" runat="server" CssClass="datePicker"  MaxLength="10" OnTextChanged="txtDtW_TextChanged" AutoPostBack="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Bill No.">
        <ItemTemplate>
            <asp:TextBox ID="txtRem" runat="server" MaxLength="20"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="  BillId  " Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblBillId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Center" Width="55px" />
    </asp:TemplateField>
</Columns>
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
</asp:GridView>
</asp:Panel>
</td>
</tr>
<tr><td align="center" colspan="2" style="height: 10px">
<asp:Button ID="btnGenerate" Width="100px" runat="server" Text="Generate" Font-Bold="True" Font-Names="Verdana" ForeColor="Blue" OnClick="btnGenerate_Click" />
<asp:Button ID="btnPrint" Width="100px" runat="server" Text="Print" Font-Bold="True" Font-Names="Verdana" ForeColor="Blue" OnClick="btnPrint_Click" />

</td></tr>

</table>
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
<script language="javascript" type="text/javascript">
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

