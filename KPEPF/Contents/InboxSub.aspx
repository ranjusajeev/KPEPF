<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="InboxSub.aspx.cs" Inherits="Contents_InboxSub" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Inbox-Sub. Change"></asp:Label> </TD></TR><TR><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" Font-Names="Verdana" Font-Size="10pt">
                    <asp:ListItem Selected="True">For Approval</asp:ListItem>
                    <asp:ListItem>Rejected by</asp:ListItem>
                </asp:RadioButtonList> </TD></TR><TR><TD style="WIDTH: 100%" align=center><asp:Panel id="pnlInbxTA" runat="server">&nbsp;<asp:GridView id="gdvInboxSc" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numWithRequestID,flgApproval" DataNavigateUrlFormatString="~/Contents/SubnChange.aspx?TAReqID={0}&amp;flgApproval={1}" DataTextField="chvPF_No" HeaderText="Account No">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="numTrnId" Visible="False"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Select" AutoPostBack="True" />
        
</HeaderTemplate>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True"/>
        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TrnType" Visible="False"><ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Suggest for Returne"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
            <asp:TextBox ID="txtRsn" runat="server" MaxLength="50" Width="115px" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
<EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            
</EmptyDataTemplate>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp;&nbsp; </asp:Panel></TD></TR><TR><TD style="WIDTH: 983px; HEIGHT: 70px" align=center><asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD style="WIDTH: 599px" align=right></TD><TD align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="42px" ForeColor="Navy" Text="OK" Font-Size="Small" Height="28px"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
    	</asp:Content>


