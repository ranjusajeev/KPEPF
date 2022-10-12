<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ServiceDet, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 700px"><TBODY><TR><TD style="WIDTH: 489px; HEIGHT: 20px" class="TdMnHead" align=center><asp:Label id="lblHead" runat="server" Text="Service Details" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD style="WIDTH: 489px" align=center><asp:GridView id="gdvMemReqList" runat="server" ForeColor="#333333" Font-Size="10pt" CellSpacing="5" OnSelectedIndexChanged="gdvMemReqList_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="intPF_No" DataNavigateUrlFormatString="ServiceDet.aspx?intPF_No={0}" DataTextField="chvPF_No" HeaderText="Acc No.">
<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Entered"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="HEIGHT: 24px" align=center><asp:Button id="btnverify" runat="server" Width="64px" Text="Ok" Visible="False" ></asp:Button> </TD></TR></TBODY></TABLE><asp:Panel id="pnldt" runat="server" Width="80%" BorderStyle="Double" BorderColor="LightSteelBlue"><TABLE style="WIDTH: 700px"><TBODY><TR><TD><asp:Label id="lblAccNo" class="p1" runat="server" Text="Account No:"></asp:Label></TD><TD><asp:TextBox id="txtAcc" oncopy="return false" oncut="return false" tabIndex=2 onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric" AutoPostBack="True" ReadOnly="True" Enabled="False"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 16px; TEXT-ALIGN: left"><asp:Label id="lblEmp" class="p1" runat="server" Text="Name of Applicant"></asp:Label> </TD><TD style="HEIGHT: 16px; TEXT-ALIGN: left"><asp:Label id="lblEmp1" tabIndex=2 runat="server" Width="200px" CssClass="p1"></asp:Label></TD></TR><TR><TD><asp:Label id="lblDOB" class="p1" runat="server" Text="Date of Birth"></asp:Label></TD><TD><asp:TextBox id="txtDOB" tabIndex=4 runat="server"  Width="200px" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtDOB_TextChanged" MaxLength="10"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 22px"><asp:Label id="lblDOJ" class="p1" runat="server" Text="Date of Commencement of Continuous Service"></asp:Label></TD><TD style="HEIGHT: 22px"><asp:TextBox id="txtDOJ" tabIndex=5 runat="server" Width="200px" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtDOJ_TextChanged" MaxLength="10"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblDOR2" class="p1" runat="server" Text="Contingent Employee"></asp:Label></TD><TD><asp:CheckBox id="chkCont" runat="server"></asp:CheckBox></TD></TR><TR><TD><asp:Label id="lblDOR" class="p1" runat="server" Text="Date of Retirement"></asp:Label></TD><TD align=left><asp:Label id="lblDOR1" tabIndex=5 runat="server" Width="200px" CssClass="p1"></asp:Label></TD></TR><TR colSpan="2"><TD style="HEIGHT: 24px" align=right>&nbsp;</TD><TD style="HEIGHT: 24px" align=left><asp:Button id="btnAddClose" onclick="btnAddClose_Click" runat="server" Width="65px" Text="Ok">
        </asp:Button> </TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

