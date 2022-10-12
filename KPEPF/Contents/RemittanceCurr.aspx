<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RemittanceCurr.aspx.cs" Inherits="Contents_RemittanceCurr" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="align: left"><asp:Label id="YearVal" runat="server" Text="Year" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label2Val" runat="server" Text="Month" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label4Val" runat="server" Text="District Treasury" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="lblAmtBk" runat="server" CssClass="p4" text="Amt"></asp:Label></TD></TR><TR><TD class="TdLine" colSpan=4></TD></TR><TR><TD>&nbsp;</TD></TR><TR align=left><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="txtInt" runat="server" CssClass="p4"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="txtAmt" runat="server" CssClass="p4" text="Amount"></asp:Label>&nbsp;&nbsp;</TD></TR></TBODY><CAPTION>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</CAPTION><TBODY><TR><TD class="TdLine" colSpan=4></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt">New Acc. Transaction</asp:LinkButton> </TD><TD style="HEIGHT: 18px" align=center colSpan=2>&nbsp;<asp:Label id="lblSTDet" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  



    <asp:RadioButtonList ID="rdChecked" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdChecked_SelectedIndexChanged" >
        <asp:ListItem Value="1">Show All</asp:ListItem>
        <asp:ListItem Value="2">Checked</asp:ListItem>
        <asp:ListItem Value="3">Not Checked</asp:ListItem>
    </asp:RadioButtonList>
        </TD></TR><TR><TD vAlign=top colSpan="2"><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle> 
<Columns>
<asp:HyperLinkField DataNavigateUrlFields="intTreasEntriesID" DataNavigateUrlFormatString="~/Contents/RemittanceCurr.aspx?intTreasEntriesID={0}" DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
<asp:BoundField DataField="dtmAccDate" HeaderText="Acc. Date">
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>
<asp:BoundField DataField="dtmTrnDate" HeaderText="Trn Date"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intTreasEntriesID,SlNo" DataNavigateUrlFormatString="~/Contents/RemittanceCurr.aspx?intTreasEntriesID={0}&amp;SlNo={1}" DataTextField="chvTreasuryName" HeaderText="Sub Treasury">
<ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="Transparent"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="TreasEntrisId" Visible="False"><ItemTemplate>
                        <asp:Label ID="lblSTDetId" runat="server" Text="Label" visible="false"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TreasuryId" Visible="False"><ItemTemplate>
                        <asp:Label ID="lblTreasId" runat="server" Text="Label"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
                        <asp:Label ID="lblEditMode" runat="server" Text="Label"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAmt" Visible="False"><ItemTemplate>
                        <asp:Label ID="lblOldAmt" runat="server" Text="Label"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="WIDTH: 864px" vAlign=top colSpan="2"><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="485px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server"  __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Sub Treasury"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" Visible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,fltChalanAmt,flgChalanType" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;fltChalanAmt={1}&amp;flgChalanType={2}" DataTextField="dtChalanDate" HeaderText="Chalan details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<%--    <asp:BoundField DataField="fltSchedAmt" HeaderText="Sch, Amt">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>--%>
<asp:TemplateField HeaderText="Sch. Amt." Visible="False"><ItemTemplate>
<asp:Label id="lblSchedAmtn" runat="server"  ></asp:Label>
</ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
</asp:TemplateField>

<asp:TemplateField HeaderText="ChalanID" Visible="False"><ItemTemplate>
<asp:Label id="lblChalIdC" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanTp" Visible="False"><ItemTemplate>
<asp:Label id="lblChalTp" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 908px" colSpan=8><%--    <AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" CancelControlID="" OkControlID="btnCan" TargetControlID="btnCan" PopupControlID="pnlChalNew" BackgroundCssClass="ModalPopUpBG">
    </AjaxExt:ModalPopupExtender>--%><AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" BackgroundCssClass="ModalPopUpBG" PopupControlID="pnlChalNew" TargetControlID="btnCan" OkControlID="btnCan" CancelControlID="">
            </AjaxExt:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlChalNew" runat="server" Width="300px" BackColor="LightGray"><DIV><TABLE><TBODY><TR align=center><TD style="HEIGHT: 16px" class="p1" align=center colSpan=2>New Chalan</TD></TR><TR><TD><asp:Label id="lblSTDetIdn" runat="server" Text="0" Visible="False"></asp:Label><asp:Label id="lblSlNo" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD><asp:Label id="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblSd" runat="server" Text="Accounting Date" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtAccDt" runat="server" CssClass="datePicker" OnTextChanged="txtAccDt_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label2" runat="server" Text="Transaction Date" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtTrnDt" runat="server" CssClass="datePicker" OnTextChanged="txtTrnDt_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label3" runat="server" Text="Sub. Treasury" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:DropDownList id="ddlsubd" runat="server" Width="150px" OnSelectedIndexChanged="ddlsubd_SelectedIndexChanged"> </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="Label6" class="p1" runat="server" Text="Amount"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:TextBox id="txtAccAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="7">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=center width="90%" colSpan=2><asp:Button id="btnNewChal" onclick="btnNewChal_Click" runat="server" Width="55px" Text="Save" CssClass="cssCoonfirmButton"></asp:Button> <asp:Button id="btnDel"  onclick="btnDel_Click" runat="server" Width="55px" Text="Delete" onclientclick="return DeleteItem()"></asp:Button> <asp:Button id="btnCan" onclick="btnCan_Click" runat="server" Width="55px" Text="Cancel"></asp:Button> </TD></TR><TR><TD style="WIDTH: 4px; HEIGHT: 21px" align=left><asp:Label id="lblNw" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 158px; HEIGHT: 21px"><asp:Label id="lblOl" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR></TBODY></TABLE></DIV></asp:Panel> </TD></TR><TR><TD align=left><%--<asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Remittance" Height="23px"></asp:LinkButton>
--%><asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="53px" Text="Back " Height="19px"></asp:Button> </TD><TD style="WIDTH: 855px" align=left colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="65px" Text="Save" Enabled="False"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

