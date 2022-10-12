<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="MonthlySubnEntryN.aspx.cs" Inherits="Contents_MonthlySubnEntryN" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel id="UpdatePanel1" runat="server">
 <ContentTemplate>
<TABLE style="BACKGROUND: white" width="100%" border=0><TBODY><TR><TD style="HEIGHT: 20px" class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Monthly Subscription"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 14px" colSpan=3>&nbsp;</TD></TR><TR align=center><TD><asp:Label id="lblYear" class="p1" runat="server" Text="Year"></asp:Label> <asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD><asp:Label id="lblMonth" class="p1" runat="server" Text="Month"></asp:Label> <asp:DropDownList id="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:Label id="lblStatus" class="p1" runat="server"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="HEIGHT: 24px" class="TdSbHead" colSpan=4><asp:Label id="lblDet" class="Head1" runat="server" Text="Chalan Details"></asp:Label> </TD></TR><TR align=center><TD colSpan=4><asp:Panel id="pnlChal1" runat="server" Width="70%" Visible="true"><TABLE style="WIDTH: 92%"><TBODY><TR align=center><TD style="WIDTH: 128px; HEIGHT: 34px" align=left><asp:Label id="lblBank" runat="server" CssClass="p1" text="Treasury"></asp:Label></TD><TD style="WIDTH: 143px; HEIGHT: 34px" align=left><asp:Label id="lblTreas" runat="server" Width="100px" CssClass="p1" Font-Names="Verdana" Font-Size="10pt" text="..." BorderColor="#404040"></asp:Label> </TD><TD style="HEIGHT: 34px" align=left><asp:Label id="lblChlNo" runat="server" Width="102px" CssClass="p1" text="Chalan No."></asp:Label></TD><TD style="HEIGHT: 34px" align=left><asp:TextBox id="txtChlNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="4" width="130px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 128px" align=left><asp:Label id="lblChlAmt" runat="server" CssClass="p1" text="Chalan Amount"></asp:Label></TD><TD align=left><asp:TextBox id="txtChlAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6" text="0" width="94px"></asp:TextBox> </TD><TD style="WIDTH: 143px" align=left><asp:Label id="lblChldt" runat="server" CssClass="p1" text="Chalan Date"></asp:Label> </TD><TD align=left><asp:TextBox id="txtChlDt" runat="server" Width="129px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtChlDt_TextChanged" MaxLength="10"></asp:TextBox> </TD></TR><TR align=center><TD colSpan=4><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="50px" Text="New"></asp:Button>&nbsp;&nbsp;&nbsp; <asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="50px" Text="Add"></asp:Button> </TD></TR><TR><TD align=center colSpan=8><asp:GridView id="gdvChalan" runat="server" Width="700px" ForeColor="#333333" ShowFooter="True" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval" DataNavigateUrlFormatString="~/Contents/MonthlySubnEntry.aspx?numChalanId={0}&amp;flgApproval={1}" DataTextField="intChalanNo" HeaderText="Chalan No."></asp:HyperLinkField>
<asp:BoundField DataField="dtChalanDate" HeaderText="Chalan Date">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Chalan Id" Visible="False"><ItemTemplate>
<asp:Label id="lblChalId" runat="server" Text="Label" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvApproval" HeaderText="Status"></asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="HEIGHT: 24px" class="TdSbHead" colSpan=4><asp:Label id="Label1s" class="Head1" runat="server" Text="Schedule Details"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 22px" colSpan=3><asp:Label id="lblCntText" class="p1" runat="server" Text="No. of Rows"></asp:Label> <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="78px" Text="1" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtCnt_TextChanged" MaxLength="2"></asp:TextBox> <asp:Label id="txtHddn" runat="server" Width="78px" Text="0" Visible="False"></asp:Label>
<asp:Label id="lblMisMatch" runat="server" Width="78px" Text="" Visible="False" CssClass="p4"></asp:Label>
</TD></TR><TR><TD style="WIDTH: 100%" colSpan=4><asp:GridView id="gdvMonthlySubn" runat="server" Width="100%" ForeColor="#333333" ShowFooter="True" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Acc.  No."><ItemTemplate>
<asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="76px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtAccNo_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="180px" CssClass="p1"></asp:Label> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subsc ription"><ItemTemplate>
<asp:TextBox id="txtSubn" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="60px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtSubn_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repay ment"><ItemTemplate>
<asp:TextBox id="txtRep" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="60px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtRep_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear PF"><ItemTemplate>
<asp:TextBox id="txtArr1" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="60px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtArr1_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear DA"><ItemTemplate>
<asp:TextBox id="txtArr2" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="60px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtArr2_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear Pay"><ItemTemplate>
<asp:TextBox id="txtArr3" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="60px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtArr3_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total"><ItemTemplate>
            <asp:Label ID="lblTot" runat="server"   Width="52px"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Govt.Order"><ItemTemplate>
<asp:DropDownList id="ddlGo" runat="server" width="70px" Enabled="False"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUp" runat="server" Width="44px" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlUpRsn" runat="server" Width="70px"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRem" runat="server" Width="70px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
<asp:Label id="lblEmpId" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="SchedID" Visible="False"><ItemTemplate>
<asp:Label id="lblSched" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="HEIGHT: 24px" align=center colSpan=4><asp:Button id="btnFinal" onclick="btnFinal_Click" runat="server" Width="96px" Text="Save" OnClientClick="return ConfirmMsg();"></asp:Button> <asp:Button id="btnPrint" onclick="btnPrint_Click" runat="server" Width="96px" Text="Print" Visible="False" Enabled="false "></asp:Button> </TD></TR><TR><TD style="HEIGHT: 33px" colSpan=4><asp:LinkButton id="btnSec" onclick="btnSec_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Visible="False" PostBackUrl="~/Contents/InboxMonthlyTrn.aspx" Height="23px"></asp:LinkButton> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
<%--    &nbsp;--%>

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
	<script type = "text/javascript" language="javascript">
        function ConfirmMsg() 
        {
            if(document.getElementById('<%=txtChlAmt.ClientID%>').value!=document.getElementById('<%=txtHddn.ClientID%>').value)
            {
                if(confirm("amount mismatch! Do you want to Save?")==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }  
            }
//            alert(document.getElementById('<%=txtHddn.ClientID%>').value);
            
            
//            alert("d");              
//            if(ctl00_contentPholder_txtChlAmt.value!=ctl00_contentPholder_txtHddn.value)
//            
//            {
//                
//                if(confirm("amount mismatch! Do you want to Save?")==true)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }  
//            }          
        }
    </script>
</asp:Content>

