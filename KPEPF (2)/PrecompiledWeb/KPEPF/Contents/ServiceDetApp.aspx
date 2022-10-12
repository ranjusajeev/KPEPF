<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ServiceDetApp, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD style="HEIGHT: 20px" class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Service Details Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 401px; HEIGHT: 81px"><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"> </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlDist" runat="server" Width="216px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR align=center><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal" Font-Names="Verdana" Font-Size="10pt"><asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD style="WIDTH: 176px" align=center colSpan=2><asp:GridView id="gdvchRem" runat="server" Width="100%" ForeColor="#333333" OnSelectedIndexChanged="gdvchRem_SelectedIndexChanged" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No.">
<HeaderStyle Width="30px"></HeaderStyle>

<ItemStyle Width="10px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intId" DataNavigateUrlFormatString="~/Contents/ServicedetApp.aspx?intId={0}" DataTextField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="150px"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField HeaderText="LBId" Visible="False"><ItemTemplate>
<asp:Label id="lblId" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Verify" OnCheckedChanged="Allchk_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" OnCheckedChanged="chkV_CheckedChanged" Height="19px" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Return"><ItemTemplate>
            <asp:CheckBox ID="chkRej" runat="server" AutoPostBack="True" Height="19px" OnCheckedChanged="chkV_CheckedChanged"
                Width="15px" />
        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD width=200></TD></TR><TR><TD align=center><asp:Button id="btnLBSave" onclick="btnLBSave_Click" runat="server" Width="50px" Text="Ok"></asp:Button> </TD></TR><TR><TD style="WIDTH: 700px" align=center><asp:GridView id="gdvlist" runat="server" ForeColor="#333333" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<%--<asp:BoundField DataField="intSlNo" HeaderText="Sl No."></asp:BoundField>--%>
<asp:TemplateField HeaderText="Sl No." Visible="true"><ItemTemplate>
<asp:Label id="lblSlNo" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="numEmpId" HeaderText="AccountNumber">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmDateOfBirth" HeaderText="Date of Birth">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DojName" HeaderText="Date of Joining">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DoRName" HeaderText="Date of Retirement">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>

</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
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
        	</script>
--%></asp:Content>

