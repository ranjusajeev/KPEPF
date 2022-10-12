<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="Localbody.aspx.cs" Inherits="Contents_Localbody" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead">&nbsp; <asp:Label id="lblHead" class="MnHead" runat="server" Text="Localbody"></asp:Label> </TD></TR><TR><TD align=center><asp:Panel id="pnlLb" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD>&nbsp;</TD></TR>
    
  
    
    <TR align=center><TD><asp:Label id="Year" runat="server" ForeColor="#0000C0" Text="District" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
 </asp:DropDownList></TD><TD><asp:Label id="Year1" runat="server" ForeColor="#0000C0" Text="LB Type" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlLBType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLBType_SelectedIndexChanged">
 </asp:DropDownList></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvLb" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
   
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ReadOnly="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvLBCode" HeaderText="LB Code">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
    
<asp:BoundField DataField="chvTreasuryNameD" HeaderText="Dist. Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
   
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Panel id="pnlT" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR align=center><TD><asp:Label id="Year2" runat="server" ForeColor="#0000C0" Text="District" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDistT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistT_SelectedIndexChanged">
 </asp:DropDownList></TD><TD><asp:Label id="Year11" runat="server" ForeColor="#0000C0" Text="Treasury Type" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTType_SelectedIndexChanged">
 </asp:DropDownList></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvT" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<%--<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>--%>
    <asp:HyperLinkField DataNavigateUrlFields="intTreasuryId" DataNavigateUrlFormatString="~/Contents/Localbody.aspx?intTreasuryId={0}" DataTextField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle Width="150px"></ItemStyle>
</asp:HyperLinkField>

<asp:BoundField DataField="chvTreasuryName" HeaderText="Dist. Treasury">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center colSpan=2 valign="top"><asp:GridView id="gdvTLb" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="intId" HeaderText="LB Id">
<ItemStyle HorizontalAlign="Left" Width="70px"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Panel id="pnlLBAdd" runat="server"><TABLE style="WIDTH: 100%" ><TBODY>
    
    <tr align="center"><td colspan="4">  <asp:RadioButtonList ID="rdLBSearch" runat="server" CssClass="p1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdLBSearch_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Selected="True" Value="1">Search</asp:ListItem>
        <asp:ListItem Value="2">Add</asp:ListItem>
        <asp:ListItem Value="4">Update</asp:ListItem>
        <asp:ListItem Value="3">Delete</asp:ListItem>
        </asp:RadioButtonList>             </td></tr>
    
    <TR style="WIDTH: 900px"><TD align=left><asp:Label id="lbl31" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="ddlDistLBAdd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD><TD style="TEXT-ALIGN: left"><asp:Label id="lbl32" runat="server" Text="Localbody Type" CssClass="p1"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="ddlLBTypeLBAdd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLBTypeLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD></TR><TR ><TD align=left><asp:Label id="lbl44" runat="server" Text="Localbody Name" CssClass="p1"></asp:Label></TD><TD style="TEXT-ALIGN: left"> <asp:TextBox id="txtLBName" runat="server" MaxLength="50"></asp:TextBox>
    <asp:Button id="btnSear" onclick="btnSear_Click" runat="server" Width="77px" Text="Search"></asp:Button>

                                   </TD><TD style="TEXT-ALIGN: left"><asp:Label id="Label15" runat="server" Text="Treasury" CssClass="p1"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="ddlTLBAdd" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="ddlTLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD><TD>&nbsp;</TD></TR><TR ><TD align=center colSpan=2><asp:Button id="btnLBAdd" onclick="btnLBAdd_Click"  runat="server" Width="50px" Text="Add" Enabled="False"></asp:Button>

     <asp:Button id="btnLBDel" onclick="btnLBDel_Click" OnClientClick="DeleteItem()" runat="server" Width="50px" Text="Delete"></asp:Button>
     <asp:TextBox id="txtLBIdn" runat="server" MaxLength="50"></asp:TextBox>
      </TD><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvLBAdd" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intDistID" HeaderText="Dist">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
     <asp:BoundField DataField="intId" HeaderText="LB Id" />
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ReadOnly="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="intLBTypeID" HeaderText="LB Type" />
    <asp:BoundField DataField="intDTreasuryId" HeaderText="DT Id" />
<asp:BoundField DataField="chvTreasuryNameD" HeaderText="Dist. Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
     <asp:BoundField DataField="intTreasuryId" HeaderText="Treas Id" />
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center></TD></TR>

    <tr><td colspan="3">
        <asp:Panel id="pnlUpd" runat="server" Enabled="False">
        <asp:TextBox ID="txtUpdId" runat="server" Width="91px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtUpdId_TextChanged" ></asp:TextBox>
        <asp:Label id="lblName" runat="server"  CssClass="p1" >...</asp:Label>
         <asp:TextBox ID="txtUpdName" runat="server" Width="157px" ></asp:TextBox>
        <asp:Button id="btnUpd" onclick="btnUpd_Click" runat="server" Width="77px" Text="Update"></asp:Button>
            </asp:Panel>     
        </td></tr>
                                                                                                                                                     </TBODY></TABLE></asp:Panel> 

     </TD></TR>
    <tr><td>

         <asp:Panel id="pnlQry" runat="server" Width="900px" BorderStyle="Solid" BorderColor="Red" >
       <TABLE style= "width:900px">
           <TR align="center">
               <TD  colspan="2" style="width: 894px"><asp:Label id="Label1" runat="server" Text="Result" CssClass="p1" ></asp:Label>
                   </TD></TR>
           <TR >
               <TD align="center" style="width: 894px"><asp:Label id="Label2" runat="server" Text="Query" CssClass="p1"></asp:Label>
                  
               <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Height="74px" Width="509px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button id="btnQry" onclick="btnQry_Click" runat="server" Width="77px" Text="Get Result"></asp:Button>
                   <asp:Button id="btnUpdT" onclick="btnUpdT_Click" runat="server" Width="77px" Text="Get Result" Enabled="False"></asp:Button>
                   
                   </TD>
              
           </TR>
           <tr><td style="width: 894px">

               <asp:Panel ID="pnl1" runat="server" BorderStyle="Solid" BorderColor="#CC0066" ScrollBars="Horizontal" Width="880px">
              <asp:Label ID="lblShow" runat="server" CssClass="p1" Text="..."></asp:Label>
               </asp:Panel>

               </td></tr>
       </TABLE>
                   </asp:Panel>

        <asp:Panel id="pnlSp" runat="server" Width="900px" BorderStyle="Solid" BorderColor="Green" >
       <TABLE style= "width:900px">
           <TR align="center">
               <TD  colspan="2"><asp:Label id="Label3" runat="server" Text="SP" CssClass="p1" ></asp:Label>
                   </TD></TR>
           <TR >
               <TD align="center"><asp:Label id="Label4" runat="server" Text="SP Name" CssClass="p1"></asp:Label>
                  
               <asp:TextBox ID="txtSp" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button id="btnSp" onclick="btnSp_Click" runat="server" Width="77px" Text="Get SP"></asp:Button>
                   </TD>
              
           </TR>
           <tr align="center" ><td>

               <asp:TextBox ID="txtShow" runat="server" TextMode="MultiLine" Height="170px" Width="852px" BorderColor="#009900" BorderStyle="Solid"></asp:TextBox>
               </td></tr>
       </TABLE>
                   </asp:Panel>



        <asp:Panel id="pnlSpParam" runat="server" Width="900px" BorderStyle="Solid" BorderColor="Violet"  >
       <TABLE style= "width:900px">
           <TR align="center">
               <TD  colspan="2"><asp:Label id="Label5" runat="server" Text="SP with Parameter" CssClass="p1" ></asp:Label>
                   </TD></TR>
           <TR >
               <TD align="center"><asp:Label id="Label6" runat="server" Text="SP Name" CssClass="p1"></asp:Label>
                  
               <asp:TextBox ID="txtParam" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button id="btnParam" onclick="btnParam_Click" runat="server" Width="77px" Text="Get Result"></asp:Button>
                   </TD>
              
           </TR>
           <tr align="center" ><td>

               <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderColor="#CC0066" ScrollBars="Horizontal" Width="880px">
              <asp:Label ID="lblShow3" runat="server" CssClass="p1" Text="..."></asp:Label>
               </asp:Panel>
               </td></tr>
       </TABLE>
                   </asp:Panel>



        </td></tr>
   </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
    <script language="javascript" type="text/javascript">
       
        function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                args.set_errorHandled(true);
            }
        }
	</script>
</asp:Content>

