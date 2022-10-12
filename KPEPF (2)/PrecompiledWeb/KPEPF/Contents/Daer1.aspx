<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Daer1, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="DAER_Credit"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="DAER Plus " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="HEIGHT: 18px" align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="DAER Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 18px" class="TdMnHead" colSpan=2><asp:Label id="lbl2" runat="server" Text="Chalan Entry" CssClass="MnHead"></asp:Label> <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Schedule Entered    " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtSch" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" AutoPostBack="True" OnTextChanged="txtCntRow_TextChanged"></asp:TextBox> </TD></TR><TR><TD colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvCPW" runat="server" Width="1200px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="71px" CssClass="txtNumeric" MaxLength="6"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtchno" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="9" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDtCPW" runat="server" Width="71px" MaxLength="10" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChlnDtCPW_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amt"><ItemTemplate>
<asp:TextBox id="txtChlAmtCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" OnTextChanged="txtChlAmtCPW_TextChanged" AutoPostBack="True" MaxLength="5"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="District"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate>    <ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreCPWO" runat="server" Width="145px">
            </asp:DropDownList> 
</ItemTemplate>  <ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlLB" runat="server" Width="145px" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chlUnpostCPW" runat="server" Width="25px"></asp:CheckBox> 
</ItemTemplate> <ItemStyle Width="30px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="70px"></asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" Text="Schedule" HeaderText="Schedule">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>--%>

    <asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataTextField="intChalanNo" HeaderText="Schedule">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>

<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="Add Row" Height="20px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalID" Visible="False"><ItemTemplate>
<%--<asp:TextBox id="txtChalId" runat="server" Width="71px" __designer:wfdid="w6"></asp:TextBox> --%>
<asp:Label id="lblintIdWth" runat="server" ></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteCrplus" onclick="btnDeleteCrplus_Click" runat="server" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate> 

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>

  <asp:TemplateField HeaderText="lblEditId" Visible="False" ><ItemTemplate>
<asp:Label id="lblEditId" runat="server" Text="0" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
   
    <asp:TemplateField HeaderText="YearId" Visible="False" ><ItemTemplate>
<asp:Label id="lblYearId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="MonthId" Visible="False" ><ItemTemplate>
<asp:Label id="lblMnth" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Day" Visible="False" ><ItemTemplate>
<asp:Label id="lblDay" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=2>
    <asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>
    <asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Width="56px" Text="Save" Font-Underline="True" Height="20px"></asp:Button> </TD></TR>
  <%--  <TR><TD colSpan=2><asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>

</TD></TR>--%>
     </TBODY></TABLE>
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
   function DeleteItem() 
        {
           if (confirm("Are you sure you want to delete ...?")) 
            {
                return true;
            }
            return false;
        }
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args)
        {
            if (args.get_error() != undefined)
            {
                args.set_errorHandled(true);
            }
        }
	</script>
--%></asp:Content>


