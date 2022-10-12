<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RecLvl1.aspx.cs" Inherits="Contents_RecLvl1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Annual acoounts statement (KPEPF)"></asp:Label> </TD></TR><TR align=center><TD style="align: center"><asp:Panel id="pnl" runat="server" Width="800px" BorderStyle="Solid" BorderColor="#C0C0FF"><TABLE><TBODY><TR align=left><TD style="align: left"><asp:Label id="Year" runat="server"  Text="Year" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlYear" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD><TD><asp:Label id="Debit" runat="server"  Text="Debit" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtDt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR align=left><TD style="align: left"><asp:Label id="lbl1" runat="server"  Text="Opening Balance" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtOb" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric"></asp:TextBox></TD><TD style="align: left"><asp:Label id="lbl3" runat="server"  Text="Interest" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtInt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR align=left><TD style="align: left"><asp:Label id="lbl2" runat="server"  Text="Credit" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtCr" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric"></asp:TextBox></TD><TD style="align: left"><asp:Label id="lbl4" runat="server"  Text="Closing Balance" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtCb" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD align=center colSpan=4>
    <asp:Button id="btnPfo" onclick="btnPfo_Click" runat="server" Width="66px" Text="Update PFO"></asp:Button>
    <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="66px" Text="New"></asp:Button> <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="68px" Text="Save"></asp:Button><asp:TextBox id="txtYr" runat="server" Width="50px"></asp:TextBox> </TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR align=center><TD colSpan=4><asp:GridView id="gdvRecM" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:HyperLinkField HeaderText="Year" DataTextField="chvYear" DataNavigateUrlFormatString="~/Contents/RecLvl1.aspx?intYearId={0}&amp;intSource{1}" DataNavigateUrlFields="intYearId,intSource">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltOB" HeaderText="Opening Balance">
<ItemStyle Width="45px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCr" HeaderText="Credit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltDt" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltInterest" HeaderText="Interest">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCB" HeaderText="Closing Balance">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=4><asp:GridView id="gdvRecMPFO" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="Year" DataField="chvYear"></asp:BoundField>
<asp:BoundField DataField="fltOB" HeaderText="Opening Balance">
<ItemStyle Width="45px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCr" HeaderText="Credit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltDt" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltInterest" HeaderText="Interest">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCB" HeaderText="Closing Balance">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
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

