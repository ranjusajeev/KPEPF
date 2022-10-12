<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RemStatus.aspx.cs" Inherits="Contents_RemStatus" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
      <ContentTemplate>
<TABLE width=900 border=0><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Status Report"></asp:Label></TD></TR><TR><TD>&nbsp;</TD></TR>
    <TR><TD align="center" colSpan=2><asp:RadioButtonList id="rdSelection" runat="server" ForeColor="Navy" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdSelection_SelectedIndexChanged" CssClass="p1" AutoPostBack="True" Font-Names="Verdana" Font-Size="10pt"><asp:ListItem Selected="True">Month wise </asp:ListItem>
<asp:ListItem>LB wise</asp:ListItem>
</asp:RadioButtonList></TD></TR>
                                         <tr><td> <asp:Panel ID="pnl1" runat="server" BorderColor="Red" BorderStyle="Solid">
    
   <table> <TR style="width:900px"><TD align="center" colSpan=2><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" CssClass="p1" AutoPostBack="True" Font-Names="Verdana" Font-Size="10pt"><asp:ListItem Selected="True">Remitted </asp:ListItem>
<asp:ListItem>Pending</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center><asp:Label id="Label21" runat="server" Text="Year" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYear" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label22" runat="server" Text="Month" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlMonth" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label23" runat="server" Text="District" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlDist" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblCnt" class="p4" runat="server" Text="..."></asp:Label></TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvCorr" runat="server" Width="800px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
&nbsp;<asp:Label id="lblSlNo" runat="server" Text="" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intChalanId,ChalType" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk2Curr.aspx?intChalanId={0}&amp;ChalType={1}" DataTextField="intChalanNo" HeaderText="Chalan Details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="intChalanId" HeaderText="intChalanId" />
    <asp:BoundField DataField="chvApproval" HeaderText="Status" />
    <asp:BoundField DataField="flgApproval" HeaderText="App Flag" />
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvCorrNot" runat="server" Width="800px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
&nbsp;<asp:Label id="lblSlNo" runat="server" Text="" __designer:wfdid="w2"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left" Width="400px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount" Visible="False">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></table>
    </asp:Panel> </td></tr>
                             <tr><td>
                                 <asp:Panel ID="pnl2" runat="server" BorderColor="Red" BorderStyle="Solid">
                                     <table><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
                                         <TR><TD align=center><asp:Label id="Label1" runat="server" Text="Year" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYearLb" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlYearLb_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label2" runat="server" Text="District" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlDistLb" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlDistLb_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                             &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label3" runat="server" Text="Lb" Cssclass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlLbLb" tabIndex=11 runat="server" Width="145px" OnSelectedIndexChanged="ddlLbLb_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                             </TD></TR>
                                         <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
                                         <tr><td>

                                         <asp:GridView id="gdvLbwise" runat="server" Width="800px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
&nbsp;<asp:Label id="lblSlNo2" runat="server" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" Visible="False">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intChalanId,ChalType" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk2Curr.aspx?intChalanId={0}&amp;ChalType={1}" DataTextField="intChalanNo" HeaderText="Chalan Details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="intChalanId" HeaderText="intChalanId" />
    <asp:BoundField DataField="chvApproval" HeaderText="Status" />
    <asp:BoundField DataField="flgApproval" HeaderText="App Flag" />
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
                                                </td></tr></table>
                                 </asp:Panel>
                             </td></tr>
                          </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
