<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="AoApprovalAG.aspx.cs" Inherits="Contents_AoApprovalAG" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" runat="server" class="MnHead" Text="AO Approval (AG Data)" ></asp:Label> </TD></TR><TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY><TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label2" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD style="WIDTH: 103px"><asp:DropDownList id="ddlYear" tabIndex=4 runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intMonthId" DataNavigateUrlFormatString="~/Contents/AoApprovalNewAGLnk1.aspx?intMonthId={0}" DataTextField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" Checked="True" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Month" Visible="False"><ItemTemplate>
<asp:Label id="lblMonth" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align="center"><TD colSpan=4><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Height="28px" Font-Size="Small"></asp:Button> </TD></TR></TBODY></TABLE><%--  </asp:Panel>--%></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

