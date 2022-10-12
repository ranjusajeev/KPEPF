<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InboxMembership.aspx.cs" Inherits="Contents_InboxMembership" Title="KASPF" %>
--%>
<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="InboxMembership.aspx.cs" Inherits="Contents_InboxMembership" %>
<%--<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
<%--<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>--%>
<%--</head>
<body>
  

<%--<table style="BACKGROUND-COLOR: #ccd0e6; color: black;" width="100%" border="0">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR align="center"><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Inbox-Membership"></asp:Label></TD></TR><TR><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" Font-Size="10pt" Font-Names="Verdana" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True">For Approval</asp:ListItem>
<asp:ListItem>Rejected by</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR align="center"><TD  align=center><asp:Panel id="pnlAo" runat="server" Width="100%"><asp:Label id="Label1" runat="server" ForeColor="#0000C0" Text="District" Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=4 runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; &nbsp; &nbsp; <asp:Label id="Label2" runat="server" ForeColor="#0000C0" Text="Localbody" Font-Size="10pt" Font-Names="Verdana" Visible="False"></asp:Label> <asp:DropDownList id="ddlLb" tabIndex=4 runat="server" Width="150px" AutoPostBack="True" Visible="False"></asp:DropDownList> </asp:Panel> </TD></TR><TR align="center"><TD style="WIDTH: 100%" align=center><asp:GridView id="gdvInboxMembership" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Employee Name"><ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("chvEmployeeName") %>' NavigateUrl='<%# Eval("numTrnID", "~/Contents/Membership.aspx?MemReqID={0}") %>'></asp:HyperLink>
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="chvDesignation" HeaderText="Designation">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmRequest" HeaderText="Date of Request">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody          ">
<ControlStyle Width="85px"></ControlStyle>

<ItemStyle HorizontalAlign="Left" Width="85px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intNominees" HeaderText="No. of nominees">
<ItemStyle Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="numTrnID" HeaderText="MemRqId" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="Select all"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" Checked="True" AutoPostBack="True" Text="Select all" OnCheckedChanged="Allchk_CheckedChanged" />
        
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" Checked="True" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="numTrnId" Visible="False"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
<asp:Label id="lblEmpId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="False" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
<asp:TextBox id="txtRsn" runat="server" Width="115px" ReadOnly="True" MaxLength="50" ForeColor="Black"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvInboxMembershipPDE" runat="server"  ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numTrnID,numEmpId" DataNavigateUrlFormatString="~/Contents/NomineePDE.aspx?MemReqID={0}&amp;numEmpId={1}" DataTextField="chvEmployeeName" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvDesignation" HeaderText="Designation">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmRequest" HeaderText="Date of Request"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody      ">
<ControlStyle Width="85px"></ControlStyle>

<ItemStyle HorizontalAlign="Left" Width="85px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intNominees" HeaderText="No. of nominees">
<ItemStyle Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="numTrnID" HeaderText="MemRqId" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="Select all"><HeaderTemplate>
<asp:CheckBox id="AllchkPDE" runat="server" Text="Select all" AutoPostBack="True" Checked="True" OnCheckedChanged="AllchkPDE_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" Checked="True"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="numTrnId" Visible="False"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
<asp:Label id="lblEmpId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="False" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
<asp:TextBox id="txtRsn" runat="server" Width="115px" ReadOnly="True" MaxLength="50" ForeColor="Black"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvInboxNomChg" runat="server"  ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numTrnID,numEmpId" DataNavigateUrlFormatString="~/Contents/NomChg.aspx?MemReqID={0}&amp;numEmpId={1}" DataTextField="chvEmployeeName" HeaderText="Employee Name"></asp:HyperLinkField>
<asp:BoundField DataField="chvDesignation" HeaderText="Designation"></asp:BoundField>
<asp:BoundField DataField="dtmRequest" HeaderText="Date of Request"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody              ">
<ControlStyle Width="85px"></ControlStyle>

<ItemStyle Width="85px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intNominees" HeaderText="No. of nominees" Visible="False">
<ItemStyle Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="numTrnID" HeaderText="MemRqId" Visible="False"></asp:BoundField>
<asp:BoundField DataField="intNominees" HeaderText="No. of Nominees"></asp:BoundField>
<asp:TemplateField HeaderText="Select all"><HeaderTemplate>
<asp:CheckBox id="AllchkPDE" runat="server" Text="Select all" AutoPostBack="True" Checked="True" OnCheckedChanged="AllchkPDE_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="numTrnId" Visible="False"><ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
<asp:Label id="lblEmpId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="False" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
<asp:TextBox id="txtRsn" runat="server" Width="115px" ReadOnly="True" MaxLength="50" ForeColor="Black"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center><asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%" align="center"><TD style="WIDTH: 599px" align=right><asp:RadioButtonList id="rlist" runat="server" Width="371px" ForeColor="Navy" Height="27px" Font-Size="Small" RepeatDirection="Horizontal" OnSelectedIndexChanged="rlist_SelectedIndexChanged" AutoPostBack="True" Visible="False"><asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList></TD><TD align="center"><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="52px" ForeColor="Navy" Text="OK" Font-Size="Small"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>


