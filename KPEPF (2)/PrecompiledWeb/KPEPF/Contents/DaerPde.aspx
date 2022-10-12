<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DaerPde, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY>
<TR><TD class="TdMnHead" colSpan=2>
<asp:Label id="lblHead" class="MnHead" runat="server" Text="DAER_Credit"></asp:Label>
 </TD>
 </TR>
 <TR>
 <TD align=left>
 <asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; 
 <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4" Font-Size="10pt" Font-Names="Verdana"></asp:Label>
  </TD>
  <TD style="WIDTH: 723px" align=right>
  <asp:Panel id="pnlMain" runat="server">
  <TABLE>
  <TBODY>
  <TR>
  <TD align=left>
  <asp:Label id="lbl11" runat="server" Text="DAER Plus " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;
  </TD>
  <TD  align=right>
  <asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label>
  </TD>
  </TR>
  <TR>
  <TD align=left>
  <asp:Label id="lblTotET" runat="server" Text="DAER Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;
  </TD>
  <TD  align=right>
  <asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label>
  </TD>
  </TR>
  <TR>
  <TD align=left>
  <asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;
  </TD>
  <TD align=right>
  <asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label>
  </TD>
  </TR>
  </TBODY>
  </TABLE>
  </asp:Panel> 
  </TD>
  </TR>
  <TR>
  <TD align=center colSpan=2></TD>
  </TR>
  <TR>
  <TD style="HEIGHT: 18px" class="TdMnHead" colSpan=2>
  <asp:Label id="lbl2" runat="server" Text="Chalan Entry" CssClass="MnHead"></asp:Label> 
  <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label id="lbl23" runat="server" Text="Schedule Entered    " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
  <asp:Label id="lblAmtSch" runat="server" CssClass="p4"></asp:Label> 
  </TD>
  </TR>
  <TR>
  <TD colSpan=2>
  <asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;
  <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" AutoPostBack="True" OnTextChanged="txtCntRow_TextChanged"></asp:TextBox> 
  </TD>
  </TR>
  <TR>
  <TD colSpan=2>
  <div style="OVERFLOW-X: auto; WIDTH: 900px">
  <asp:GridView id="gdvCPW" runat="server" Width="1200px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="No.">
    <HeaderStyle Width="30px" />
    </asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="78px" CssClass="txtNumeric" MaxLength="6" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtchno" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="4" Width="78px"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDtCPW" runat="server" Width="78px" MaxLength="10" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChlnDtCPW_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amt"><ItemTemplate>
<asp:TextBox id="txtChlAmtCPW" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="78px" CssClass="txtNumeric" OnTextChanged="txtChlAmtCPW_TextChanged" AutoPostBack="True" MaxLength="6"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="District"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate><ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreCPWO" runat="server" Width="145px">
            </asp:DropDownList> 
</ItemTemplate>
    <ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlLB" runat="server" Width="145px" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged">
         </asp:DropDownList> 
</ItemTemplate>
    <ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chkUnpostCPW" runat="server" Width="38px" OnCheckedChanged="chkUnpostCPW_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate><ItemStyle Width="40px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="105px"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="110px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px">
         </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="intChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" Text="Schedule" HeaderText="Schedule">
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

    <asp:TemplateField HeaderText="RelMthId" Visible="False"><ItemTemplate>
<asp:Label id="lblRelMthId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="SchMnId" Visible="False"><ItemTemplate>
<asp:Label id="lblSchMnId" runat="server" Text="0" __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="GrpId" Visible="False"><ItemTemplate>
<asp:Label id="lblGrpId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="IntChalanId" Visible="False"><ItemTemplate>
<asp:Label id="txtintChalId" runat="server" Text="0" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="lblEditId" Visible="False"><ItemTemplate>
<asp:Label id="lblEditId" runat="server" Text="0" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="lblDy" Visible="False"><ItemTemplate>
<asp:Label id="lblDy" runat="server" Text="0" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    
    <asp:TemplateField HeaderText="YearId" Visible="False"><ItemTemplate>
<asp:Label id="lblYearId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="MonthId" Visible="False"><ItemTemplate>
<asp:Label id="lblMnth" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Day" Visible="False"><ItemTemplate>
<asp:Label id="lblDay" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <BR /></DIV></TD></TR>
  <TR><TD align=center colSpan=2>
      <asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="53px" Text="Back " Height="19px"></asp:Button>
      <asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Width="56px" Text="Save" Font-Underline="True" Height="20px"></asp:Button>
      
      </TD></TR>
 <%-- <TR><TD colSpan=2><asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="53px" Text="Back " Height="19px"></asp:Button> </TD></TR>--%>

                           </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

