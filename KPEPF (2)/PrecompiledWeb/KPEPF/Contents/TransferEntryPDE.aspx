<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_TransferEntryPDE, App_Web_q2bqv01f" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <contenttemplate>

<TABLE style="WIDTH: 100%">
<TBODY>
<TR>
<TD class="TdMnHead" colSpan=2>
<asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Credit Plus"></asp:Label>
 </TD>
 </TR>
 <TR >
 <TD align="left" >
 <asp:Label id="lblYear" runat="server" Text="..." CssClass="p4" ></asp:Label> &nbsp;&nbsp;&nbsp; 
 <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>
<%--<asp:Panel id="pnlMain" runat="server">--%>
  
 <TABLE border="0"  style="float:right;">
 <TBODY>
 <TR>
 <TD align=left>
 <asp:Label id="lbl11" runat="server" Text="Credit Plus " CssClass="p1">
 </asp:Label>
 </TD>

         <td align="right">
             <asp:Label ID="lblTot" runat="server" CssClass="p4" Text="..."></asp:Label>
         </td>

     <tr>
         <td align="right">
             <asp:Label ID="lblTotET" runat="server" CssClass="p1" Text="Credit Plus Entered "></asp:Label>
             &nbsp;&nbsp;&nbsp; </td>
         <td align="right">
             <asp:Label ID="lblTotE" runat="server" CssClass="p4" Text="..."> </asp:Label>
         </td>
     </tr>
     <tr>
         <td  style="HEIGHT: 18px">
             <asp:Label ID="lbl12" runat="server" CssClass="p1" Text="  Balance "></asp:Label>
             &nbsp;&nbsp;&nbsp; </td>
         <td align="right">
             <asp:Label ID="lblBal" runat="server" CssClass="p4" Text="..."></asp:Label>
         </td>
     </tr>
 </TR>
  </TBODY>
  </TABLE>
<%--  </asp:Panel> --%>
 </TD>


 </TR><TR><TD style="HEIGHT: 19px" align=left colSpan=2><asp:LinkButton id="lnkAnnInt" onclick="lnkAnnInt_Click" runat="server" Font-Bold="True" Font-Size="12pt" Visible="false">Annual Interest</asp:LinkButton> </TD></TR>

<TR><TD colSpan=2><asp:Label id="lblCntwthout" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCntWthout" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntWthout_TextChanged" AutoPostBack="True" MaxLength="2"></asp:TextBox>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> 

    </TD></TR><TR><TD colSpan="8"><asp:GridView id="gdvCPWO" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No"><ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>

<HeaderStyle CssClass="cssHeadGridEng" Width="25px"></HeaderStyle>

<ItemStyle Width="25px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteCPWO" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="65px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChlnCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="55px" CssClass="txtNumeric" MaxLength="4" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateCPWO" runat="server" Width="79px" CssClass="datePicker"  MaxLength="10" OnTextChanged="txtChlnDateCPWO_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" CssClass="txtNumeric" MaxLength="5"  AutoPostBack="True" OnTextChanged="txtAmtCPWO_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryCPWO" runat="server" Width="132px" OnSelectedIndexChanged="ddlTreasuryCPWO_SelectedIndexChanged1" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="129px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemCPWO" runat="server" Width="124px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server" Width="38px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRem"    runat="server" visible="false" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server" ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthWiseID" Visible="False"><ItemTemplate>
<asp:Label id="lblRelMnthwseId" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="txtChalanAGId" Visible="False"><ItemTemplate>
<asp:Label id="lblintIdWtht" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD style="HEIGHT: 19px" align=center colSpan=2><asp:Button id="btnOkWithouDocs" onclick="btnOkWithouDocs_Click" runat="server" Width="57px" Text="Save" Height="19px"></asp:Button></TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; 
    <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCnt_TextChanged" AutoPostBack="True" MaxLength="3"></asp:TextBox> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:CheckBox ID="chkShow" runat="server" CssClass="p1" AutoPostBack="True" Text="Show Grid" OnCheckedChanged="chkShow_CheckedChanged"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl2" runat="server" Text="Chalan Entry" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWCP" runat="server" CssClass="p4">0</asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Schedule Entered    " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtSch" runat="server" CssClass="p4"></asp:Label> 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     </TD></TR><TR>
    <TD style="width: 100%"><asp:Label id="lblPgNo" runat="server" CssClass="p4" Visible="False"></asp:Label> 
        
        <%--<DIV style="OVERFLOW-X: auto; WIDTH: 900px">--%><asp:GridView id="gdvCPW" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" PageSize="30" OnPageIndexChanging="gdvEmpDist_PageIndexChanging" AllowPaging="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
    <ItemStyle Width="10px" />
    </asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="10" __designer:wfdid="w24"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtchno" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="4" __designer:wfdid="w20"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDtCPW" runat="server" AutoPostBack="True" MaxLength="10" CssClass="datePicker" OnTextChanged="txtChlnDtCPW_TextChanged" Width="68px"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amt"><ItemTemplate>
<asp:TextBox id="txtChlAmtCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtChlAmtCPW_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="65px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreCPWO" runat="server" Width="65px">
            </asp:DropDownList> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlLB" runat="server" Width="85px" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chkUnpostCPW" runat="server" Width="20px" OnCheckedChanged="chkUnpostCPW_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate><ItemStyle Width="22px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="60px" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="65px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" Text="Schedule" HeaderText="Schedule">
<ItemStyle HorizontalAlign="Left" Width="30px"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="Add Row" Height="20px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthWiseID" Visible="False"><ItemTemplate>
<asp:Label id="lblRelMnthwseIdWith" runat="server" Text="0"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="txtChalanAGId" Visible="False"><ItemTemplate>
<asp:Label id="lblChalanAGIdWith" runat="server" Text="0"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="RelMnth" Visible="False"><ItemTemplate>
<asp:Label id="lblMnth" runat="server" Width="71px"  Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelYear" Visible="False"><ItemTemplate>
<asp:Label id="lblYearId" runat="server" Width="71px"  Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<%--<asp:TemplateField HeaderText="RelMnth" Visible="False"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"  Text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelYear" Visible="False"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"  Text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>
<%--    <asp:TemplateField HeaderText="RelDay" Visible="False"><ItemTemplate>
<asp:TextBox id="RelDay" runat="server" Width="71px"  Text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>
    <asp:TemplateField HeaderText="RelDay" Visible="False"><ItemTemplate>
<asp:Label id="lblDay" runat="server" Width="71px"  Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalID" Visible="False"><ItemTemplate>
<%--<asp:TextBox id="txtChalId" runat="server" Width="71px"></asp:TextBox> --%><asp:Label id="lblChalIdWith" runat="server" __designer:wfdid="w21"  Text="0"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteWth" onclick="btnDeleteWth_Click" runat="server" __designer:wfdid="w7" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="SchMainId" Visible="False"><ItemTemplate>
<asp:Label id="lblSchMnId" runat="server" __designer:wfdid="w21">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="GrpId" Visible="False"><ItemTemplate>
<asp:Label id="lblGrpId" runat="server" __designer:wfdid="w21">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="EditId" Visible="False"><ItemTemplate>
<asp:Label id="lblEditId" runat="server" __designer:wfdid="w21">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Day" Visible="False"><ItemTemplate>
<asp:Label id="lblDy" runat="server" __designer:wfdid="w21">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <%--</DIV>--%></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Width="56px" Text="Save" Height="20px"></asp:Button> </TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCapBT" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCntBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntBT_TextChanged" AutoPostBack="True">
</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvBT" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False" CellSpacing="2" OnRowDataBound="gdvBT_RowDataBound" >
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCPBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" MaxLength="10" __designer:wfdid="w17"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFrmAcCPBT" runat="server" Width="98px" OnTextChanged="txtFrmAcCPBT_TextChanged" AutoPostBack="True" MaxLength="10" __designer:wfdid="w10"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" Visible="False"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="105px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Account"><ItemTemplate>
<asp:TextBox id="txtToaccCPBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" OnTextChanged="txtToaccCPBT_TextChanged" AutoPostBack="True" MaxLength="5" __designer:wfdid="w11"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txttoName" runat="server" Width="190px" MaxLength="35" __designer:wfdid="w12" ReadOnly="True"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="192px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" MaxLength="6" OnTextChanged="txtAmtCPBT_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRmkCPBT" runat="server"  Width="165px" MaxLength="50" ></asp:TextBox> 
</ItemTemplate><ItemStyle Width="167px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblintAccno" runat="server" Width="71px" __designer:wfdid="w13"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px" __designer:wfdid="w14">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Width="71px" Text = "0" Visible="true" ></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:Button id="BtnBT" onclick="BtnBT_Click" runat="server" Width="54px" Text="Add Row" Height="19px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthWiseID" Visible="False"><ItemTemplate>
<asp:Label id="lblRelMnthwseIdBal" runat="server" __designer:wfdid="w16"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteBal" onclick="btndeleteBal_Click" runat="server" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>


<asp:TemplateField HeaderText="oldAmt" Visible="False"><ItemTemplate>
<asp:Label id="lbloldAmt" runat="server" Text = "0" __designer:wfdid="w16"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="oldAcc" Visible="False"><ItemTemplate>
<asp:Label id="lbloldAcc" runat="server" Text = "0" __designer:wfdid="w16"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="editMode" Visible="False"><ItemTemplate>
<asp:Label id="lbleditMode" runat="server" Text = "0" __designer:wfdid="w16"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="HEIGHT: 19px" align=center colSpan=2>
    <TR><TD colSpan="2" align="center"><asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="53px" Text="Back " Height="19px" PostBackUrl="~/Contents/AGStatementsPDE.aspx"></asp:Button> 
    <asp:Button id="btnOkbal" onclick="btnOkbal_Click" runat="server" Width="53px" Text="Save" Height="19px"></asp:Button></TD></TR><TR><TD style="WIDTH: 594px"><AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" BackgroundCssClass="ModalPopUpBG" PopupControlID="pnlChalNew" TargetControlID="btnCan" OkControlID="btnCan" CancelControlID="">
            </AjaxExt:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlChalNew" runat="server" Width="300px" BackColor="LightGray"><DIV><TABLE><TBODY><TR align="center"><TD style="HEIGHT: 18px" class="p1" align="center" colSpan=2>annual Interest</TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblchlId" runat="server" Text="id." Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtchlnId"  runat="server"  Visible="False">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label6" class="p1" runat="server" Text="Amount"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtAnnIntAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="10">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label4" class="p1" runat="server" Text="TE No."></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtTENo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="4"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label5" class="p1" runat="server" Text="Remarks"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtAnnIntRem"  runat="server" MaxLength="50"></asp:TextBox> </TD></TR>



<TR><TD style="HEIGHT: 21px" align=center width="90%" colSpan=2><asp:Button id="btnNewChal" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" runat="server" Width="55px" Text="Save"></asp:Button> 

<asp:Button id="btnCan" onclick="btnCan_Click" runat="server" Width="55px" Text="Cancel"></asp:Button>
</TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblNw" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:Label id="lblOl" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR>
</TBODY></TABLE></DIV></asp:Panel> </TD></TR></TBODY></TABLE>
</contenttemplate>
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
--%>
</asp:Content>
