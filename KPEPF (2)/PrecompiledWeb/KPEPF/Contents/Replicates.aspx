<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Replicates, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <%--<asp:UpdatePanel ID="updatepanel" runat= "server">--%>
<%--    <ContentTemplate>--%>
<table style="width: 100%">

<tr>
<%--<td colspan="4" style="WIDTH: 116px; COLOR: black; BACKGROUND-COLOR: #ccd0e6" align="center" height="26" ;><asp:Label id="lblHead" class="Head1" runat="server" Text="Sanction Order"></asp:Label></td>--%>
<td  colspan="4" class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" class="MnHead" Text="Replication"></asp:Label>
            </td>
</tr>
<tr>
    
    <td align="center" colspan="4">
        <asp:DropDownList runat="server" Width="159px" TabIndex="11" ID="ddlSer" OnSelectedIndexChanged="ddlSer_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="0">...</asp:ListItem>
            <asp:ListItem Value="1">Chalan</asp:ListItem>
            <asp:ListItem Value="2">Schedule</asp:ListItem>
            <asp:ListItem Value="3">Correction Entry</asp:ListItem>
            <asp:ListItem Value="4">Employee_Mst</asp:ListItem>
            <asp:ListItem Value="5">L_EmployeeDetTrn</asp:ListItem>
            <asp:ListItem Value="6">L_EmployeeDet_App</asp:ListItem>
            <asp:ListItem Value="7">TB_LocalBody_MST</asp:ListItem>
            <asp:ListItem Value="8">Approval</asp:ListItem>
            <asp:ListItem Value="9">Withdrawals</asp:ListItem>
            <asp:ListItem Value="10">Bill</asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:CheckBox ID="chkFilter" runat="server" AutoPostBack="True" CssClass="p1" OnCheckedChanged="chkFilter_CheckedChanged" Text="Filter" />
        <asp:Button ID="btnPort" runat="server" OnClick="btnPort_Click" Text="Port" Width="58px" />
        <asp:Button ID="btnText" runat="server" OnClick="btnText_Click" Text="TextFile" /></td>
        
    </tr>
    
    
    <tr>
    <td>
        <asp:DropDownList id="ddlYear" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Visible="False" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList id="ddlMonth" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" Visible="False" ></asp:DropDownList>
    </td>
    </tr>
            <tr>
           <td colspan="2"> <asp:DropDownList runat="server" Width="159px" TabIndex="11" ID="ddlCol" OnSelectedIndexChanged="ddlCol_SelectedIndexChanged" AutoPostBack="True" Visible="False"></asp:DropDownList>&nbsp;
            <asp:Textbox ID="txtVal" runat="server" Text="0" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue" Visible="False" OnTextChanged="txtVal_TextChanged"></asp:Textbox>
               <asp:Button ID="btnVal" runat="server" OnClick="btnFind_Click" Text="Find" Visible="False" Width="50px" />
           </td>
        </tr>
        <tr><td align="center" colspan="2" >
            <asp:Panel ID="pnlSch" runat="server">
               <asp:Label ID="lblNo" runat="server" Text="No" CssClass="p1" Visible="False"></asp:Label> <asp:TextBox ID="txtNo" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Date" CssClass="p1" Visible="False"></asp:Label> <asp:TextBox ID="txtDt" runat="server" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="ddlDtr" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Button" Visible="False" />
            </asp:Panel>
        </td></tr>

    <tr><td align="left" colspan="2" style="height: 10px">
         <asp:Panel ID="pnl1" runat="server" ScrollBars="Horizontal" Width="900px" Visible="False">
        <asp:Label ID="lblShow" runat="server" CssClass="p1" Text="Label"></asp:Label></asp:Panel>&nbsp;</td></tr>
    <tr><td align="left" colspan="2" style="height: 10px">
        <asp:Panel ID="pnl2" runat="server" ScrollBars="Horizontal" Width="900px" Visible="False">
        <asp:Label ID="lblShow2" runat="server" CssClass="p1" Text="Label"></asp:Label></asp:Panel>&nbsp;</td></tr>

    <tr><td align="left" colspan="2" style="height: 10px">
         <asp:Panel ID="pnl3" runat="server" ScrollBars="Horizontal" Width="900px" Visible="False">
        <asp:Label ID="lblShow3" runat="server" CssClass="p1" Text="Label"></asp:Label></asp:Panel>&nbsp;</td></tr>
    <tr>
        <td>

            <asp:Panel ID="pnlAdd" runat="server" Width="90%"><table>
                
   <tr >
                    <td align="left" style="width: 700px"  >
                         <asp:Label ID="Label4" runat="server" Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlYear2" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear2_SelectedIndexChanged" ></asp:DropDownList>
                

                         <asp:Label ID="Label5" runat="server" Text="Month" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlMonth2" runat="server" Width="100px" OnSelectedIndexChanged="ddlMonth2_SelectedIndexChanged" AutoPostBack="True" style="height: 20px" ></asp:DropDownList></td>
                </tr>  
    
    <tr>
    <td colspan="2" align="right">
        <asp:Label ID="lblTot2" runat="server" Text="..." CssClass="p4"></asp:Label> 
        <asp:Button id="btnSaveA" onclick="btnSaveA_Click" runat="server" Width="65px" Text="Add"></asp:Button>
    </td>
</tr>  
     <tr >
<TD  vAlign=top  ><asp:GridView id="gdvAdd" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="550px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="slno"></asp:BoundField>
  
    <%--<asp:BoundField HeaderText="Bill No" DataField="chvBillNo" />--%>

    <asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" />

    <asp:HyperLinkField DataNavigateUrlFields="numBillId,fltBillAmount" DataNavigateUrlFormatString="~/Contents/Replicates.aspx?numBillId={0}&amp;fltAmt={1}" DataTextField="chvBillNo" HeaderText="Bill No">
<ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="Transparent"></ItemStyle>
</asp:HyperLinkField>

    <asp:BoundField DataField="dtmBill" HeaderText="Bill Date" />
    <asp:BoundField DataField="fltBillAmount" HeaderText="Amount" />
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </td><td><asp:GridView id="gdvLBA" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="327px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Acc No" DataField="chvPF_No"></asp:BoundField>
    <asp:BoundField DataField="amt" HeaderText="Amount" />
    <asp:BoundField DataField="modeChg" HeaderText="Status" />
    <asp:TemplateField HeaderText="Select"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" Checked="False" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
    <%--<asp:TemplateField HeaderText="ID">
        <asp:Label id="lblId2" runat="server" Text="0"></asp:Label>
    </asp:TemplateField>--%>
    <asp:TemplateField HeaderText="ID"><ItemTemplate>
 <asp:Label id="lblId2" runat="server" Text="0"></asp:Label>
</ItemTemplate>

</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 

    </tr>  

     </table> </asp:Panel>
        </td>
    </tr>
</table>

<%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
