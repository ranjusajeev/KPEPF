
<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_InboxService, App_Web_1la5evxf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Inbox-TA"></asp:Label> </TD></TR><TR><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" Font-Size="10pt" Font-Names="Verdana" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged">
                    <asp:ListItem Selected="True">For Approval</asp:ListItem>
                    <asp:ListItem>Rejected by</asp:ListItem>
                </asp:RadioButtonList> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="WIDTH: 950px" align=center colSpan=2><asp:RadioButtonList id="rdAmtTp" runat="server" ForeColor="RoyalBlue" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdAmtTp_SelectedIndexChanged" Enabled="true">
<asp:ListItem Selected="True">Amount <=75000 &nbsp &nbsp </asp:ListItem>
<asp:ListItem>Amount >75000 & <=200000 &nbsp &nbsp</asp:ListItem>
<asp:ListItem>Amount >200000 &nbsp &nbsp </asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD></TD></TR><TR><TD style="WIDTH: 1500px" align=center><asp:Panel id="pnlAo" runat="server" Width="100%"><asp:Label id="Label1" runat="server" ForeColor="#0000C0" Text="District" Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> &nbsp; &nbsp; &nbsp; <asp:Label id="Label2" runat="server" ForeColor="#0000C0" Text="Localbody" Font-Size="10pt" Font-Names="Verdana" Visible="False"></asp:Label> <asp:DropDownList id="ddlLb" tabIndex=4 runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlLb_SelectedIndexChanged" Visible="False"></asp:DropDownList> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 100%" align=center><asp:Panel id="pnlInbxTA" runat="server"><asp:GridView id="gdvInboxTA" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" OnSelectedIndexChanged="gdvInboxTA_SelectedIndexChanged" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/TA.aspx?TAReqID={0}" DataNavigateUrlFields="numWithRequestID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="numTrnId"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Select" AutoPostBack="True" />
        
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" />
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="TrnType"><ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
            <asp:TextBox ID="txtRsn" runat="server" MaxLength="50" Width="115px" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>
<EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            
</EmptyDataTemplate>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvInboxSc" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
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
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"/>
        
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
</asp:GridView> <asp:GridView id="gdvInboxNra" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" OnSelectedIndexChanged="gdvInboxNra_SelectedIndexChanged" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numWithRequestID" DataNavigateUrlFormatString="~/Contents/NRA.aspx?TAReqID={0}" DataTextField="chvPF_No" HeaderText="Account No">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="numTrnId" Visible="False"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        
</HeaderTemplate>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"/>
        
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
<asp:TemplateField HeaderText="Returned"><ItemTemplate>
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
</asp:GridView> <asp:GridView id="gdvInboxTaC" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/TaNraConversion.aspx?TAReqID={0}" DataNavigateUrlFields="numWithRequestID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="numTrnId"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"/>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="TrnType"><ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
            <asp:TextBox ID="txtRsn" runat="server" MaxLength="50" Width="115px" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>
<EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            
</EmptyDataTemplate>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvInboxClosure" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/Closure.aspx?TAReqID={0}" DataNavigateUrlFields="numWithRequestID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmtAdmissible" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="numTrnId"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        
</HeaderTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" />
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="TrnType"><ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
            <asp:TextBox ID="txtRsn" runat="server" MaxLength="50" Width="115px" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>
<EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            
</EmptyDataTemplate>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel></TD></TR><TR><TD style="WIDTH: 983px; HEIGHT: 70px" align=center><asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD style="WIDTH: 599px" align=right><asp:RadioButtonList id="rlist" runat="server" Width="325px" ForeColor="Navy" Font-Size="Small" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rlist_SelectedIndexChanged" Visible="False"><asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList></TD><TD align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="42px" ForeColor="Navy" Text="OK" Height="28px" Font-Size="Small"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
    	</asp:Content>
