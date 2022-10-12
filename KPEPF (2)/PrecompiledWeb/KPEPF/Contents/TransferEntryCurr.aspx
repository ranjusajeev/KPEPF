<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_TransferEntryCurr, App_Web_1la5evxf" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Credit Plus"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD><TD align=right>
    
    <asp:Panel id="pnlMain" runat="server" Width="300px">   
    <TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Credit Plus " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Credit Plus Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY>
    </TABLE></asp:Panel> 
                                                                                                                                                                                                                                                                                                                                                                                                                               </TD></TR><TR><TD align=left colSpan=2><asp:LinkButton id="lnkAnnInt" onclick="lnkAnnInt_Click" runat="server" Font-Bold="True" Font-Size="12pt" Visible="false">Annual Interest</asp:LinkButton> </TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="MnHead"></asp:Label> <asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:Label id="lblCntwthout" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCntWthout" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntWthout_TextChanged" AutoPostBack="True" MaxLength="2"></asp:TextBox> </TD></TR><TR><TD colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvCPWO" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" Width="100%" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No"><ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>

<HeaderStyle CssClass="cssHeadGridEng" Width="15px"></HeaderStyle>

<ItemStyle Width="15px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteCPWO" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="65px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChlnCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="84px" CssClass="txtNumeric"  MaxLength="9" Height="17px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateCPWO" runat="server" Width="79px"  MaxLength="10" CssClass="datePicker" OnTextChanged="txtChlnDateCPWO_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" CssClass="txtNumeric" OnTextChanged="txtAmtCPWO_TextChanged" AutoPostBack="True" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryCPWO" runat="server" Width="132px" AutoPostBack="True" OnSelectedIndexChanged="ddlTreasuryCPWO_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="129px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemCPWO" runat="server" Width="100px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server" Width="38px" OnCheckedChanged="chkCollect_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intID" Visible="False"><ItemTemplate>
<asp:Label id="lblintIdWtht" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click" runat="server" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthWiseID" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseId"   runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="txtChalanAGId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtChalanAGId"   runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnOkWithouDocs" onclick="btnOkWithouDocs_Click" runat="server" Width="57px" Text="Save" Height="19px"></asp:Button></TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl2" runat="server" Text="Chalan Entry" CssClass="MnHead"></asp:Label> <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Schedule Entered    " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtSch" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><%--<TD style="HEIGHT: 22px" colSpan=2>
<asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;
<asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntRow_TextChanged" AutoPostBack="True" MaxLength="2"></asp:TextBox>

 </TD>--%><TD align="left"><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt">New Chalan</asp:LinkButton> </TD></TR><TR><TD colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvCPW" runat="server" Width="900px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId" DataNavigateUrlFormatString="~/Contents/TransferEntryCurr.aspx?numChalanId={0} " DataTextField="SlNo" HeaderText="Sl No">
    <ItemStyle Width="10px" />
    </asp:HyperLinkField>
<asp:BoundField DataField="TENo" HeaderText="TE No"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO" Visible="False"><ItemTemplate>
<asp:TextBox id="txtTeCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="10" AutoPostBack="True" OnTextChanged="txtTeCPW_TextChanged" __designer:wfdid="w7"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:BoundField DataField="intChalanNo" HeaderText="Chalan No">
    <ItemStyle Width="58px" />
    </asp:BoundField>
<asp:TemplateField HeaderText="Chalan No" Visible="False"><ItemTemplate>
<asp:TextBox id="txtchno" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="9" AutoPostBack="True" OnTextChanged="txtchno_TextChanged" __designer:wfdid="w2"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:BoundField DataField="dtChalanDate" HeaderText="Chalan Dt"></asp:BoundField>
<asp:TemplateField HeaderText="Chalan Dt." Visible="False"><ItemTemplate>
<asp:TextBox id="txtChlnDtCPW" runat="server" Width="68px" MaxLength="10" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChlnDtCPW_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amt"></asp:BoundField>
<asp:TemplateField HeaderText="Chalan Amt" Visible="False"><ItemTemplate>
<asp:TextBox id="txtChlAmtCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtChlAmtCPW_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="85px" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" __designer:wfdid="w4" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreCPWO" runat="server" Width="95px" AutoPostBack="True" OnSelectedIndexChanged="ddlTreCPWO_SelectedIndexChanged" __designer:wfdid="w5" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlLB" runat="server" Width="85px" AutoPostBack="True" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged" __designer:wfdid="w6" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chlUnpostCPW" runat="server" Width="33px" AutoPostBack="True" OnCheckedChanged="chlUnpostCPW_CheckedChanged" __designer:wfdid="w9" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
    <ItemStyle Width="35px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="75px" AutoPostBack="True" OnSelectedIndexChanged="ddlreason_SelectedIndexChanged" __designer:wfdid="w8" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>--%>
<asp:BoundField DataField="chvRemarks" HeaderText="Remarks" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" Text="Schedule" HeaderText="Schedule">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>--%>

<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataTextField="intChalanNo"  HeaderText="Schedule">
<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:HyperLinkField>


<asp:TemplateField HeaderText="ChalID" Visible="False"><ItemTemplate>
<asp:Label id="lblintIdWth" runat="server" ></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteCrplus" onclick="btnDeleteCrplus_Click" runat="server" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

    <FooterStyle BackColor="White" />

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Width="56px" Text="OK" Visible="False" Height="20px" Font-Underline="True"></asp:Button> </TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="MnHead"></asp:Label><asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCapBT" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCntBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntBT_TextChanged" AutoPostBack="True">
</asp:TextBox> </TD></TR><TR><TD align=center colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvBT" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCPBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="100px" HorizontalAlign="Left" />
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFrmAcCPBT" runat="server" Width="98px" MaxLength="10" AutoPostBack="True" OnTextChanged="txtFrmAcCPBT_TextChanged"></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="100px" HorizontalAlign="Left" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" Visible="False"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="71px" ></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Account"><ItemTemplate>
<asp:TextBox id="txtToaccCPBT"
 oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" OnTextChanged="txtToaccCPBT_TextChanged" AutoPostBack="True" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="100px" HorizontalAlign="Left" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txttoName" runat="server" Enabled="False" ReadOnly="True" Width="190px"></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="192px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" OnTextChanged="txtAmtCPBT_TextChanged" AutoPostBack="True" MaxLength="8"></asp:TextBox> 
</ItemTemplate>  <ItemStyle Width="78px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRmkCPBT" runat="server"  Width="160px" MaxLength="50" ></asp:TextBox> 
</ItemTemplate>  <ItemStyle Width="162px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteBal" onclick="btndeleteBal_Click" runat="server" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
         <asp:DropDownList ID="ddlStatus" runat="server"  Width="71px">
         </asp:DropDownList> 
       
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<%--<asp:TextBox id="txtintId" runat="server" Width="71px" Visible="False"></asp:TextBox> --%>
<asp:Label id="lblintIdbal" runat="server" Text="0"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intRelMonthWiseId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthIDbal" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNoOld" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNoNew" runat="server">0</asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="AmtOld" Visible="False"><ItemTemplate>
<asp:Label id="lblAmtOld" runat="server">0</asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>

</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR>
    
<TR><TD style="WIDTH: 908px; HEIGHT: 10px"><AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" CancelControlID="" OkControlID="btnCan" TargetControlID="btnCan" PopupControlID="pnlChalNew" BackgroundCssClass="ModalPopUpBG" >
            </AjaxExt:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlChalNew" runat="server" Width="300px" BackColor="LightGray" ><DIV><TABLE><TBODY><TR align="center"><TD style="HEIGHT: 18px" class="p1" align="center" colSpan=2>annual Interest</TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%">
            
            <asp:Label id="lblchlId" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtchlnId"  runat="server"  Visible="False"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label6" class="p1" runat="server" Text="Amount"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtAnnIntAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="12">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label4" class="p1" runat="server" Text="TE No."></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtTENo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label5" class="p1" runat="server" Text="Remarks"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtAnnIntRem"  runat="server" MaxLength="50"></asp:TextBox> </TD></TR>



<TR><TD align=center width="90%" colSpan=2><asp:Button id="btnNewChal" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" runat="server" Width="55px" Text="Save"></asp:Button> 

<asp:Button id="btnCan" onclick="btnCan_Click" runat="server" Width="55px" Text="Cancel"></asp:Button>
</TD></TR><TR><TD align=left width="90%"><asp:Label id="lblNw" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:Label id="lblOl" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR>
</TBODY></TABLE></DIV></asp:Panel> </TD></TR>
    
    <TR><TD align="center" colSpan="2">
        <asp:Button id="btnBack" runat="server" Width="53px" Text="Back " Height="19px" PostBackUrl="~/Contents/AGstatements.aspx" OnClick="btnBack_Click"></asp:Button>
        <asp:Button id="btnOkbal" onclick="btnOkbal_Click" runat="server" Width="53px" Text="Save" Height="19px"></asp:Button></TD></TR><TR><TD style="WIDTH: 908px" colSpan=8><AjaxExt:ModalPopupExtender id="Mdlchl" runat="server" CancelControlID="" OkControlID="btnCan1" TargetControlID="btnCan1" PopupControlID="pnlwthNew" BackgroundCssClass="ModalPopUpBG"></AjaxExt:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlwthNew" runat="server" Width="350px" BackColor="LightGray"><DIV><TABLE><TBODY><TR align="center"><td></td><TD style="HEIGHT: 16px" class="p1" align="center" colSpan="2"> New Chalan</TD></TR><TR><TD><asp:Label id="lblchlIdTBchl" runat="server" Text="id." Visible="False"></asp:Label> <asp:TextBox id="txtchlIdTBchl" runat="server" Width="2px" Visible="False" BorderStyle="None">0</asp:TextBox> <asp:Label id="lblchId" runat="server" Text="id." Visible="False"></asp:Label> <asp:TextBox id="txtchnId" runat="server" Width="48px" BorderStyle="None" Visible="false"></asp:TextBox> </TD><TD style="WIDTH: 158px"><asp:Label id="lblgrpId" runat="server" Text="id." Visible="False"></asp:Label> </TD><TD><asp:TextBox id="txtGrpId" runat="server" Width="2px" Visible="False" BorderStyle="None">0</asp:TextBox> </TD><TD><asp:Label id="lblSchMainId" runat="server" Text="id." Visible="False"></asp:Label> </TD><TD><asp:TextBox id="txtSchMainId" runat="server" Width="2px" Visible="False" BorderStyle="None">0</asp:TextBox> </TD></TR><TR><TD><asp:Label id="lbleditmde" runat="server" Text="id." Visible="False"></asp:Label> </TD><TD><asp:Label id="lblMd" runat="server" Text="0" Visible="false"></asp:Label> </TD><TD><asp:Label id="Year1" runat="server" Text="Year." Visible="False"></asp:Label> </TD><TD><asp:Label id="lblchDtO" runat="server" Text="0" Visible="false"></asp:Label> </TD><TD><asp:Label id="Monthd" runat="server" Text="Month." Visible="False"></asp:Label> </TD><TD style="WIDTH: 7px"><%--<asp:Label id="lblMnth" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD><asp:Label id="dy" runat="server" Text="Day." Visible="False"></asp:Label>--%> </TD><TD> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblSd" runat="server" Text="TENo" Width="130px" CssClass="p1" ></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtTeN" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric" MaxLength="7">
                            </asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Lbl6" class="p1" runat="server" Width="130px"  Text="Chalan No."></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtChalNo"  Width="200px" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="9">0</asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label1" class="p1" Width="130px" runat="server" Text="Chalan Date"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtChalDt" Width="200px" runat="server" CssClass="datePicker" OnTextChanged="txtChalDt_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Lbl5" class="p1" runat="server" Width="130px" Text="Chalan Amount"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtChalAmt" Width="200px" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtChalAmt_TextChanged" MaxLength="7">0</asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblDis" runat="server" Width="130px" Text="District" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:DropDownList id="ddldis" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddldis_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblStreas" runat="server" Width="130px" Text="Treasury" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:DropDownList id="ddlsubTreas" runat="server" Width="200px" OnSelectedIndexChanged="ddlsubTreas_SelectedIndexChanged">
                            </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Labe3" runat="server" Width="130px" Text="Localbody" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:DropDownList id="ddlLBNew" runat="server" Width="200px">
    </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label8" class="p1" runat="server" Width="130px" Text="Unposted"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:CheckBox id="chkUpN" runat="server" AutoPostBack="True" OnCheckedChanged="chkUpN_CheckedChanged">
       </asp:CheckBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label9" class="p1" runat="server" Width="130px" Text="Reason"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:DropDownList id="ddlRsnN" runat="server" Width="200px" OnSelectedIndexChanged="ddlRsnN_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblRemrks" runat="server" Width="130px" Text="Remarks" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtRm" runat="server" MaxLength="100" Width="200px">
                            </asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=center width="90%" colSpan=2><asp:Button id="btnNewwth" onclick="btnNewWth_Click" runat="server" Width="55px" Text="Save" CssClass="cssCoonfirmButton"></asp:Button>&nbsp; <asp:Button id="btnCan1" onclick="btnCan1_Click" runat="server" Width="55px" Text="Cancel"></asp:Button> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblNwwth" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:Label id="lblOlwth" runat="server" Text="0" Visible="False"></asp:Label>
                                 <asp:Label id="lblEditId" runat="server" Text="0" Visible="False"></asp:Label>

                                <asp:Label id="lblYearId" runat="server" Text="0" Visible="False"></asp:Label> 
                                <asp:Label id="lblMnth" runat="server" Text="0" Visible="False"></asp:Label>
                               <asp:Label id="lblDy" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             </TD></TR></TBODY></TABLE></DIV></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

