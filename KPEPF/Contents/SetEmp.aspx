
<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="SetEmp.aspx.cs" Inherits="Contents_SetEmp" %>
<%@ Register Src="MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
      <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=2 height=26 ;><asp:Label id="lblHead" class="MnHead" runat="server" Text="Employee Mapping"></asp:Label></TD></TR></TBODY></TABLE><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD style="WIDTH: 1118px; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=2><asp:RadioButtonList id="optSearch" runat="server" ForeColor="Navy" OnSelectedIndexChanged="optSearch_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" Font-Names="Verdana" Font-Size="10pt">
                    <asp:ListItem Selected="True">Account Number</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                </asp:RadioButtonList> </TD></TR><TR><TD align=center><TABLE><TBODY><TR><TD ><asp:TextBox id="txtValue" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" BorderColor="#8080FF" BorderStyle="Groove" BorderWidth="2px" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtValue_TextChanged"></asp:TextBox></TD><TD><asp:Button id="btnFind" onclick="btnFind_Click" runat="server" Width="40px" Text="Find"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD colSpan=2><asp:Label id="lbl1" runat="server" ForeColor="Navy" Text="Search Results" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD><TD colSpan=2><asp:Label id="lbl2" runat="server" ForeColor="Navy" Text="Existing List of Employees" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD></TR><TR width="45%"><TD vAlign=top align=right>
                <asp:GridView id="gdvSearch" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" CellPadding="2" GridLines="None" AllowPaging="True" OnPageIndexChanging="gdvSearch_PageIndexChanging" Height="70px"  >
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Height="10px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="AccountNo.">
<ItemStyle Width="85px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvLBNameEnglish" HeaderText="Institution">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:ButtonField ImageUrl="~/Images/arrow.gif" HeaderText="sel" Text="Button" DataTextField="numEmpId" ButtonType="Image" DataTextFormatString="SetEmp.aspx" Visible="False"></asp:ButtonField>
<asp:TemplateField HeaderText="Select">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                    <asp:CheckBox ID="chkSel" runat="server" OnCheckedChanged="chkSel_CheckedChanged" AutoPostBack="True" Width="50px" />
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OrderNo. &amp; Date">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                    <asp:TextBox ID="txtOrdrNo" runat="server" MaxLength="20" Width="100px" />
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numEmpId") %>'></asp:TextBox>
                
</EditItemTemplate>
<ItemTemplate>
                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("numEmpId") %>'></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="LB Id"><EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("intCurrentPostingLBId") %>'></asp:TextBox>
                
</EditItemTemplate>
<ItemTemplate>
                    <asp:Label ID="lblLBId" runat="server" Text='<%# Bind("intCurrentPostingLBId") %>'></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD width="8%"><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="30px" Font-Bold="True" Text=">" Visible="true"></asp:Button> </TD><TD vAlign=middle width="55%"><TABLE width="100%" border=0><TBODY><TR><TD vAlign=top><asp:GridView id="gdvEmp" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" CellPadding="2" GridLines="None">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="Sl.No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="AccountNo.">
<ItemStyle Width="85px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select"><HeaderTemplate>
<asp:CheckBox id="Hchk" runat="server" Width="50px" Text="All" AutoPostBack="True" OnCheckedChanged="Hchk_CheckedChanged" Checked="True"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkEmp" runat="server" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numEmpId") %>'></asp:TextBox>
                
</EditItemTemplate>
<ItemTemplate>
                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("numEmpId") %>' Width="121px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Flag"><ItemTemplate>
<asp:Label id="lblFlg" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE><asp:Button id="btnUpd" onclick="btnUpd_Click" runat="server" Text="Update" width="50"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>
