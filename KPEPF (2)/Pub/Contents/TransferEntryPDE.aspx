<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_TransferEntryPDE, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Credit Plus"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD><TD align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Credit Plus " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Credit Plus Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD colSpan=2><asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCPWO" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True"><Columns>
<asp:TemplateField HeaderText="Sl.No">
<ItemStyle Width="25px"></ItemStyle>

<HeaderStyle Width="25px" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteCPWO" runat="server" Width="65px" text='<%#Eval("chvTEId") %>' __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChlnCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="55px" CssClass="txtNumeric" text='<%#Eval("intChalNo") %>' __designer:wfdid="w2" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateCPWO" runat="server" Width="79px" CssClass="datePicker" __designer:wfdid="w2" text='<%#Eval("dtmChalDt") %>' OnTextChanged="txtChlnDateCPWO_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" CssClass="txtNumeric" __designer:wfdid="w3" text='<%#Eval("fltAmt") %>' MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryCPWO" runat="server" Width="132px" __designer:wfdid="w5"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="129px" __designer:wfdid="w6"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemCPWO" runat="server" Width="124px" text='<%#Eval("chvDetails") %>' __designer:wfdid="w7" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server" Width="38px" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px" __designer:wfdid="w9">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtintId"   text='<%#Eval("intId") %>'  runat="server" visible="false" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server" ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelMnthWiseID"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseId"   runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="txtChalanAGId"><ItemTemplate>
<asp:TextBox id="txtChalanAGId"   runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnOkWithouDocs" onclick="btnOkWithouDocs_Click" runat="server" Width="57px" Text="OK" Height="19px"></asp:Button></TD></TR><TR><TD colSpan=2><asp:Label id="lbl2" runat="server" Text="Chalan Entry" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Schedule Entered    " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtSch" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCPW" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeCPW" runat="server" Width="71px" __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtchno" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDtCPW" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amt"><ItemTemplate>
<asp:TextBox id="txtChlAmtCPW" runat="server" Width="71px" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="71px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreCPWO" runat="server" Width="71px">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlLB" runat="server" Width="71px" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un posted"><ItemTemplate>
<asp:CheckBox id="chkUnpostCPW" runat="server" Width="22px" __designer:wfdid="w3"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField HeaderText="Schedule" DataTextField="intChalanNo" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField Visible="False" HeaderText="Add"><ItemTemplate>
<asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="Add Row" Height="20px" __designer:wfdid="w5"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelmtnhWiseId"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIdW" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="ChalanAGId"><ItemTemplate>
<asp:TextBox id="txtChalanAGId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelMnth"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelYear"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="ChalID"><ItemTemplate>
<asp:TextBox id="txtChalId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Width="56px" Text="OK" Height="20px"></asp:Button> </TD></TR><TR><TD colSpan=2><asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="p1"></asp:Label><asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvBT" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCPBT" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFrmAcCPBT" runat="server" Width="71px" AutoPostBack="True" OnTextChanged="txtFrmAcCPBT_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" Visible="False"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Account"><ItemTemplate>
<asp:TextBox id="txtToaccCPBT" runat="server" Width="71px" AutoPostBack="True" OnTextChanged="txtToaccCPBT_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txttoName" runat="server" Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPBT" runat="server" Width="71px" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRmkCPBT" runat="server"  Width="71px" MaxLength="50" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintAccno" runat="server" Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
         <asp:DropDownList ID="ddlStatus" runat="server"  Width="71px">
         </asp:DropDownList> 
            
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server"  Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:Button id="BtnBT" onclick="BtnBT_Click" runat="server" Width="54px" Text="Add Row" Height="19px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intRelMonthWiseId" Visible="False"><ItemTemplate>
            <asp:TextBox ID="txtRelMnthIDbal" runat="server" Width="71px"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnOkbal" onclick="btnOkbal_Click" runat="server" Width="53px" Text="OK" Height="19px"></asp:Button></TD></TR><TR><TD colSpan=2><asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements"></asp:LinkButton> </TD></TR></TBODY></TABLE>
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
	  <script type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 </script>

</asp:Content>

