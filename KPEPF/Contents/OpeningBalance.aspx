<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="OpeningBalance.aspx.cs" Inherits="Contents_OpeningBalance" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan="6">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Opening Balance"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD>&nbsp;&nbsp;&nbsp;</TD><TD></TD><TD style="align: left"><asp:Label id="Year" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlDist" runat="server" Width="150px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="lblCnt" runat="server" Text="..." CssClass="p4"></asp:Label></TD><TD></TD></TR><TR><TD>&nbsp;&nbsp;&nbsp;</TD><TD></TD><TD style="align: left"><asp:Label id="lbl1" runat="server" Text="Account No." CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return isNumberKey(event)" onpaste="return false" runat="server" Width="150px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged" MaxLength="5"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Label id="lblAccNo" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblName" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD>&nbsp;&nbsp;&nbsp;</TD><TD></TD><TD style="align: left"><asp:Label id="lbl2" runat="server" Text="Opening Balance" CssClass="p1"></asp:Label></TD><TD style="align: left">
    <asp:TextBox id="txtOb" runat="server" Width="150px" oncopy="return false" oncut="return false"  onkeypress="return isNumberKey(event)" onpaste="return false"   CssClass="txtNumeric" MaxLength="7" ></asp:TextBox></TD><TD style="align: left">

<%--<asp:HiddenField id="hdnOb" runat="server"></asp:HiddenField>--%>
<asp:Label id="hdnOb"  runat="server" Text="0" Visible="False"></asp:Label> 
<asp:Label id="hdnAcc"  runat="server" Text="0" Visible="False"></asp:Label> 
</TD></TR>

 <TR align=center><TD style="align: left" colSpan="6"><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="50" Text="New"></asp:Button><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="50" Text="Save"></asp:Button> 
     <asp:Button id="btnDel" onclick="btnDel_Click" onclientclick="return DeleteItem()" runat="server" Width="50" Text="Delete" Enabled="False"></asp:Button>
     <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="50" Text="Search"></asp:Button> <asp:TextBox id="txtSearch" runat="server" Width="129px" CssClass="txtNumeric" AutoPostBack="True" oncopy="return false" oncut="return false"  onkeypress="return isNumberKey(event)" onpaste="return false"   OnTextChanged="txtSearch_TextChanged" MaxLength="5" ReadOnly="True"></asp:TextBox> 
<asp:CheckBox ID="chkShow" CssClass="p1"  runat="server" AutoPostBack="True" OnCheckedChanged="chkShow_CheckedChanged" Text="Show All" />
</TD></TR>
    
    <TR align=center><TD align=center colSpan="6"><asp:GridView id="gdvRecM" runat="server" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True" Font-Size="10pt" Font-Names="Verdana">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle Width="50px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Acc No." DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/OpeningBalance.aspx?intAccNo={0}&amp;flgClosed={1}&amp;flgMoC={2}" DataNavigateUrlFields="intAccNo,flgClosed,flgMoC"></asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCB00_01" HeaderText="Opening Balance">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmDate" HeaderText="Date of Entry"></asp:BoundField>
<asp:BoundField DataField="ClosureStat" HeaderText="Status">
<ItemStyle Width="90px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="closed" Visible="False"><ItemTemplate>
<asp:Label id="lblClosed" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 

<%--<script language="javascript" type="text/javascript">
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
--%></asp:Content>

