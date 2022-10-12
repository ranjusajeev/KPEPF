<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ClosureDetNew, App_Web_rihpu3hj" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
 <ContentTemplate>
<TABLE style="BACKGROUND: white" width="100%" border=0><TBODY><TR><TD style="HEIGHT: 20px" class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Closure Details"></asp:Label> </TD></TR><TR><TD colSpan=3>&nbsp;</TD></TR><TR align=center><TD style="WIDTH: 260px" align=left><asp:Label id="lblYear" class="p1" runat="server" Text="District"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDist" runat="server" Width="181px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="lblCnt" class="p4" runat="server" Text="..."></asp:Label> </TD><TD align=left><asp:Label id="lblMonth" class="p1" runat="server" Text="Month_Year"></asp:Label></TD><TD align=left><asp:TextBox id="txtMthYear" runat="server" OnTextChanged="txtMthYear_TextChanged" width="181px" MaxLength="10" AutoPostBack="True" CssClass="datePicker"></asp:TextBox>&nbsp; </TD></TR><TR align=center><TD style="WIDTH: 260px" align=left><asp:Label id="lblBank" runat="server" text="Account No." CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged" width="176px" MaxLength="6" CssClass="txtNumeric"></asp:TextBox> </TD><TD align=left><asp:Label id="lblChlNo" runat="server" text="Order No. _Date" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 34px" align=left>
    <asp:TextBox id="txtOrderNo" runat="server" MaxLength="25" Width="181px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 260px" align=left><asp:Label id="lblChlAmt" runat="server" text="Name" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtName" runat="server" Width="173px" Text="..." ReadOnly="True"></asp:TextBox> </TD><TD align=left><asp:Label id="lblChldt" runat="server" text="Amount" CssClass="p1"></asp:Label> </TD><TD align=left><asp:TextBox id="txtAmount" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" Width="181px" onpaste="return false" runat="server" MaxLength="7" CssClass="txtNumeric"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 260px" align=left>
    <asp:Label id="lblTCTp" runat="server" text="Type" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTC" runat="server" Width="181px" AutoPostBack="True"><asp:ListItem Value="0">&lt;Select an Item&gt;</asp:ListItem>
<asp:ListItem Value="1">To GPF</asp:ListItem>
<asp:ListItem Value="2">To Other PF</asp:ListItem>
<asp:ListItem Value="3">From BT(AG)</asp:ListItem>
        <asp:ListItem Value="4">Closure</asp:ListItem>
</asp:DropDownList> </TD><TD align=left><asp:Label id="lblRem" runat="server" text="Remarks" CssClass="p1"></asp:Label> </TD><TD align=left><asp:TextBox id="txtRem" runat="server" MaxLength="50" Width="181px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 260px"><asp:Label id="lblYear44" class="p1" runat="server" Text="Part Payment"></asp:Label></TD><TD><asp:CheckBox id="chkP" runat="server" CssClass="p1"></asp:CheckBox> </TD><TD colSpan=2></TD></TR>
    
    <TR><TD style="WIDTH: 260px"><asp:Label id="Label2" class="p1" runat="server" Text="Retired/Relieved on"></asp:Label></TD><TD><asp:TextBox id="txtRet" runat="server" OnTextChanged="txtRet_TextChanged" width="181px" MaxLength="10" AutoPostBack="True" CssClass="datePicker"></asp:TextBox>&nbsp;</TD>
        <TD align=left><asp:Label id="Label3" runat="server" text="Interest Upto" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 34px" align=left>
    <asp:TextBox id="txtInt" runat="server" OnTextChanged="txtInt_TextChanged" width="181px" MaxLength="10" AutoPostBack="True" CssClass="datePicker" ></asp:TextBox> </TD>

    </TR>

    <TR align=center><TD style="HEIGHT: 24px" colSpan=4><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="50px" Text="New"></asp:Button>&nbsp;&nbsp;&nbsp; <asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="50px" Text="Save"></asp:Button>&nbsp;&nbsp;&nbsp; <asp:Button id="btnDel" onclick="btnDel_Click" onclientclick="return DeleteItem()" runat="server" Width="50px" Text="Delete"></asp:Button> </TD></TR>
    
    

     <TR><TD style="width:400px; height: 45px;"  align="center" colSpan="2">
         <asp:RadioButtonList id="rdCategory" runat="server" OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1"><asp:ListItem Value="3" Selected="True">TC &nbsp;&nbsp;&nbsp;</asp:ListItem>
<asp:ListItem Value="1">Closed  &nbsp;&nbsp;&nbsp;</asp:ListItem>
<asp:ListItem Value="2&nbsp;&nbsp;">Partially Closed &nbsp;&nbsp;</asp:ListItem>
</asp:RadioButtonList></TD>
<TD style="width:400px; height: 45px;"  align="left" colSpan="2">
       <asp:Label id="lbld" runat="server" Text="District" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:DropDownList id="ddlDistP" runat="server" Width="100px" OnSelectedIndexChanged="ddlDistP_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;
      <asp:Label id="Label1" runat="server" Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlyrP" runat="server" Width="100px" OnSelectedIndexChanged="ddlyrP_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
     
        <asp:Button id="btnPrint" onclick="btnPrint_Click" runat="server" Width="50px" Text="Search" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller" ForeColor="Blue" Height="20px"></asp:Button>
        </TD></TR>


    <TR><TD style="WIDTH: 343px" align=center colSpan=4><asp:Label id="lblSearch" runat="server" text="Search" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="txtSearch" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" MaxLength="5" CssClass="txtNumeric"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="50px" Text="Search" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller" ForeColor="Blue" Height="20px"></asp:Button> </TD></TR><TR><TD align=center colSpan=8><asp:GridView id="gdvChalan" runat="server" Width="890px" ForeColor="#333333" OnSelectedIndexChanged="gdvChalan_SelectedIndexChanged" ShowFooter="True" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="SlNo" Visible="False"><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>

<ItemStyle Width="5px"></ItemStyle>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="intId,intSubSlNo" DataNavigateUrlFormatString="~/Contents/ClosureDet.aspx?intClosureId={0}&amp;intSubSlNo={1}" DataTextField="AccNo" HeaderText="Account No.">
<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District" Visible="False"></asp:BoundField>
<asp:BoundField DataField="MonthYear" HeaderText="Year">
<ItemStyle HorizontalAlign="Left"  Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvOrderNoDate" HeaderText="Order No. _Date">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmount" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"  Width="80px"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="chvStatus" HeaderText="Status" />
<asp:BoundField DataField="chvRemarks" HeaderText="Remarks">
<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>
   
   <%-- <tr><td colspan="8">
        <asp:GridView id="gdvRep" runat="server" Width="890px" ForeColor="#333333" OnSelectedIndexChanged="gdvChalan_SelectedIndexChanged" ShowFooter="True" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="SlNo"><ItemTemplate>
<asp:Label id="lblSlNo1" runat="server" Text="Label"></asp:Label>
</ItemTemplate>

<ItemStyle Width="5px"></ItemStyle>
</asp:TemplateField>
    <asp:BoundField DataField="chvPF_No" HeaderText="Account No." >
        <ItemStyle Width="100px" />
    </asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District" Visible="False"></asp:BoundField>
<asp:BoundField DataField="dtmMonthYear" HeaderText="Year">
<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvOrderNoDate" HeaderText="Order No. _Date">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmount" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvRemarks" HeaderText="Remarks">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        </td></tr>--%>
             </TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

