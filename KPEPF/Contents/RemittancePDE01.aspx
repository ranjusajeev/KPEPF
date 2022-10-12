<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RemittancePDE01.aspx.cs" Inherits="Contents_RemittancePDE01" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=8><asp:Label id="lblHead" runat="server" Text="Remittance PDE " CssClass="MnHead"></asp:Label> </TD></TR><%--<TR><TD align=center colSpan=2><asp:Label id="lblType" runat="server" Text="..." CssClass="MnHead" Visible="False"></asp:Label> </TD></TR>--%>
    
    <%--<TR align=center style="WIDTH: 90%"><TD style="HEIGHT: 38px"><asp:Label id="Label2" runat="server" Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp; <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 38px"><asp:Label id="Label3" runat="server" Text="Month" CssClass="p1"> </asp:Label>&nbsp;&nbsp;<asp:DropDownList id="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList></TD>

        &nbsp;&nbsp;
        <td style="HEIGHT: 38px">
            <asp:Label ID="Label1" runat="server" CssClass="p1" Text="District"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
            </asp:DropDownList>
        </td>

    </TR>--%>
 
    <TR align="center" style="WIDTH: 850px">
        <TD ><asp:Label id="Label2" runat="server" Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp; <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD>
        <TD style="HEIGHT: 38px"><asp:Label id="Label3" runat="server" Text="Month" CssClass="p1"> </asp:Label>&nbsp;&nbsp;<asp:DropDownList id="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList></TD> 
        <td style="HEIGHT: 38px"> <asp:Label ID="Label1" runat="server" CssClass="p1" Text="District"></asp:Label> &nbsp;&nbsp;<asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px"></asp:DropDownList>
        </td>
       <TD align=center ><asp:Label id="lblStatus" runat="server" CssClass="p4" text="..."></asp:Label> </TD>
    </TR>
       
    <%--<TR><TD align=center colSpan=4><asp:Label id="lblStatus" runat="server" CssClass="p4" text="..."></asp:Label> </TD></TR>--%>
    <TR><td></td><TD align="left"><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt" Enabled="False">New Chalan</asp:LinkButton> </TD><TD colspan="2"><asp:CheckBox id="chkShow" runat="server" Text="Show Grid" CssClass="p1" AutoPostBack="True" OnCheckedChanged="chkShow_CheckedChanged"></asp:CheckBox> <%--<asp:CheckBox ID="chkShow1" CssClass="p1"  runat="server" AutoPostBack="True" OnCheckedChanged="chkShow1_CheckedChanged" Text="Show Grid" />--%></TD></TR><TR><TD align=center colSpan=8><asp:GridView id="gdvRem01" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:HyperLinkField DataNavigateUrlFields="intChalanId,intSchMainId" DataNavigateUrlFormatString="~/Contents/RemittancePDE01.aspx?intChalanId={0}&amp;intSchMainId={1}" DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="350px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Chalan Details" DataTextField="ChalDet" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgPrevYear={1}&amp;intGroupId={2}&amp;flgApproval={3}" DataNavigateUrlFields="intChalanId,flgPrevYear,intGroupId,flgApproval">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amount">
<ItemStyle HorizontalAlign="Right"  Width="90px"></ItemStyle> 
</asp:BoundField>
<asp:BoundField DataField="fltTotalSum" HeaderText="Schedule Amount">
<ItemStyle HorizontalAlign="Right" Width="90px"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="charType" HeaderText="From">
<ItemStyle HorizontalAlign="Right"  Width="90px"></ItemStyle>
</asp:BoundField>

    <asp:TemplateField HeaderText="SchMnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblSchMn" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 908px" colSpan=8><AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" CancelControlID="" OkControlID="btnCan" TargetControlID="btnCan" PopupControlID="pnlChalNew" BackgroundCssClass="ModalPopUpBG">
            </AjaxExt:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlChalNew" runat="server" Width="300px" BackColor="LightGray"><DIV><TABLE><TBODY><TR align="center"><TD style="HEIGHT: 18px" class="p1" align="center" colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Chalan</TD></TR><TR><TD><asp:Label id="lblchlId" runat="server" Text="id." Visible="False"></asp:Label> <asp:TextBox id="txtchlnId" runat="server" Visible="False" Enabled="False">0</asp:TextBox> </TD>
            
            <TD style="WIDTH: 158px"><asp:Label id="lblgrpId" runat="server" Text="id." Visible="False"></asp:Label> </TD>
      <TD><asp:TextBox id="txtGrpId" runat="server" Width="2px" Visible="False" BorderStyle="None">0</asp:TextBox> </TD>
      <TD><asp:Label id="lblSchMainId" runat="server" Text="id." Visible="False"></asp:Label> </TD>
      <TD><asp:TextBox id="txtSchMainId" runat="server" Width="2px" Visible="False" BorderStyle="None">0</asp:TextBox> 
      </TD>
            
            
            <TD style="WIDTH: 152px"><asp:Label id="lbleditmde" runat="server" Text="id." Visible="False"></asp:Label> <asp:Label id="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD><asp:Label id="Year" runat="server" Text="Year." Visible="False"></asp:Label> <asp:Label id="lblYr" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD><asp:Label id="Monthd" runat="server" Text="Month." Visible="False"></asp:Label> <asp:Label id="lblMonth" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD><asp:Label id="dy" runat="server" Text="Day." Visible="False"></asp:Label> <asp:Label id="lblDy" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label6" class="p1" runat="server" Text="No."></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:TextBox id="txtChalNo" MaxLength="4" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric"  Width="150px">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label4" class="p1" runat="server" Text="Date"></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:TextBox id="txtChalDt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChalDt_TextChanged"  Width="150px">
</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label5" class="p1" runat="server" Text="Amount"></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:TextBox id="txtChalAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="7"  Width="150px"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblStreas" runat="server" Text="SubTreasury" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:DropDownList id="ddlsubTreas" runat="server"  Width="150px"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Labe3" runat="server" Text="Localbody" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:DropDownList id="ddlLBNew" runat="server" Width="150px"></asp:DropDownList> </TD></TR>

                <TR>
    
    <TD style="HEIGHT: 21px" align=left width="90%">
         <asp:Label id="LblFrm" class="p1" runat="server" Text="FromWhom"></asp:Label>
    </TD>
    <TD style="WIDTH: 104px; HEIGHT: 21px">
        <asp:DropDownList id="ddlFrm" runat="server"  Width="150px">
</asp:DropDownList> 

    </TD>

</TR>


<TR><TD style="HEIGHT: 21px" align=left width="90%">
<asp:Label id="Label8" class="p1" runat="server" Text="Unposted"></asp:Label> </TD>
<TD style="WIDTH: 152px; HEIGHT: 21px">
<asp:CheckBox id="chkUpN" runat="server" AutoPostBack="True" OnCheckedChanged="chkUpN_CheckedChanged" Checked="false">
</asp:CheckBox> </TD>
</TR>
<TR><TD style="HEIGHT: 21px" align=left width="90%">
<asp:Label id="Label9" class="p1" runat="server" Text="Reason"></asp:Label> </TD>
<TD style="WIDTH: 152px; HEIGHT: 21px"><asp:DropDownList id="ddlRsnN" runat="server" Enabled="False"  Width="150px">
</asp:DropDownList> </TD>
</TR>

 <tr>
    <td align="center" colspan="2" style="HEIGHT: 21px" width="300px">
        <asp:Button ID="btnNewChal" runat="server" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" Text="Save" Width="50px" />
        <asp:Button ID="btnDel" runat="server" onclick="btnDel_Click" Text="Delete" Width="50px" />
        <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" Width="50px" />
    </td>
</tr>

<%--<TR><TD style="HEIGHT: 21px" align=center width="90%" colSpan=2><asp:Button id="btnNewChal" onclick="btnNewChal_Click" runat="server" Width="55px" Text="Save" CssClass="cssCoonfirmButton"></asp:Button> <asp:Button id="btnDel" onclick="btnDel_Click" runat="server" Width="55px" Text="Delete"></asp:Button> <asp:Button id="btnCan" onclick="btnCan_Click" runat="server" Width="55px" Text="Cancel"></asp:Button> </TD></TR>--%>
<TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblNw" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 152px; HEIGHT: 21px"><asp:Label id="lblOl" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR></TBODY></TABLE></DIV></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel></asp:Content>

