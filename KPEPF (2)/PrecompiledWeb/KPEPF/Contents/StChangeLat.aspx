<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_StChangeLat, App_Web_rihpu3hj" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>

        <table style="WIDTH: 100%">
            <tbody>
  <tr><td colspan="2"align="center">
      <asp:RadioButtonList ID="rdCat" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdCat_SelectedIndexChanged" >
        <asp:ListItem Value="1" Selected="True">Add Treasury</asp:ListItem>
          <asp:ListItem Value="2">Treasury Mapping</asp:ListItem>
        
          <asp:ListItem Value="3">Add GO</asp:ListItem>
          <asp:ListItem Value="4">Localbody</asp:ListItem>
    </asp:RadioButtonList>
</td></tr>
 <tr><td>
  <asp:Panel ID="pnlMapp" runat="server" Visible="false" Width="900px"><table style="WIDTH: 100%">
 <tr >  <td  class="TdMnHead" colspan="4">&nbsp;<asp:Label ID="lblHead" class="MnHead" runat="server" Text="Treasury mapping" Width="800px"></asp:Label> </td> </tr>
 <tr > <td align="center" style="width: 800px" colspan="4"> <asp:Label ID="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:DropDownList ID="ddlDT" runat="server" Width="184px" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>   
</tr> 
 <tr > <td colspan="4" align="center" >       
    <asp:RadioButtonList ID="rdChecked" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdChecked_SelectedIndexChanged" >
        <asp:ListItem Value="1" Selected="True">Show All</asp:ListItem>
        <asp:ListItem Value="2">Mapped</asp:ListItem>
        <asp:ListItem Value="3">Not Mapped</asp:ListItem>
    </asp:RadioButtonList>
        </td>  </tr>                       
  <tr><TD vAlign=top  align="center" colspan="2">
        <asp:GridView ID="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True">
            <RowStyle BackColor="#EFF3FB"></RowStyle>
            <Columns>
                <asp:HyperLinkField DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="intTreasuryId,SlNo" DataNavigateUrlFormatString="~/Contents/StChangeLat.aspx?intTreasuryId={0}&amp;SlNo={1}" DataTextField="chvTreasuryName" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>
                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="300px"></ItemStyle>
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:CheckBox id="chkAppT" runat="server"  __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>  
        <asp:TemplateField HeaderText="TId" Visible="false" >
        <ItemTemplate>
            <asp:Label ID="lblTId" runat="server" Text='<%# Bind("intTreasuryId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>        
            </Columns>
            <FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>
            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
            <EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        </asp:GridView> </TD><TD  vAlign=top><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="451px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server"  __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="LocalBody"></asp:BoundField>
    <asp:TemplateField HeaderText="LBId" Visible="False">

        <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%# Bind("intId") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>  
<tr>
    <td colspan="2" align="center">
        <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="65px" Text="Save"></asp:Button>
        <asp:Button id="btnDelT" onclick="btnDelT_Click" runat="server" onclientclick="return DeleteItem()" Width="65px" Text="Delete"></asp:Button>
    </td>
</tr>
 </table>   </asp:Panel> 
 </td> </tr> 
<tr><td>
<asp:Panel ID="pnlTAdd" runat="server" Width="900px" Visible="true"><table>
                <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label1" class="MnHead" runat="server" Text="Treasury Add" Width="800px"></asp:Label>
                    </td>
                </tr>
   <tr >
                    <td align="left" style="width: 389px"  >
                         <asp:Label ID="Label2" runat="server" Text="District Treasury" CssClass="p1" Width="130px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlDTA" runat="server" Width="150px" OnSelectedIndexChanged="ddlDTA_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label3" runat="server" Text="Treasury Type" CssClass="p1" Width="130px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlTTypeA" runat="server" Width="150px" ></asp:DropDownList></td>
                </tr>  
    <tr >
                    <td align="left"   >
                         <asp:Label ID="Label5" runat="server" Text="Treasury Name" CssClass="p1" Width="130px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtTNameA" runat="server" Width="150px" MaxLength="150" ></asp:TextBox>
                        <asp:TextBox ID="txtId" runat="server" Width="10px" Visible="False" >0</asp:TextBox>
                    </td>
    <td align="left"  >
                         <asp:Label ID="Label6" runat="server" Text="Treasury Code" CssClass="p1" Width="130px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtCodeA" runat="server" Width="150px" MaxLength="10" ></asp:TextBox></td>
                </tr>  
    
    <tr>
    <td colspan="2" align="center">
         <asp:Button id="btnNewT" onclick="btnNewT_Click" runat="server" Width="65px" Text="New"></asp:Button>
        <asp:Button id="btnSaveA" onclick="btnSaveA_Click" runat="server" Width="65px" Text="Add"></asp:Button>
        <%--<asp:Button id="btnDelTr" onclick="btnDelTr_Click" runat="server" Width="65px" Text="Delete" onclientclick="return DeleteItem()"></asp:Button>--%>
    </td>
</tr>  
     <tr >
<TD  vAlign=top align="center" colspan="4" ><asp:GridView id="gdvTAdd" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="600px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="SlNo"></asp:BoundField>
  <%--  <asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" />--%>
    <asp:HyperLinkField DataNavigateUrlFields="intTreasuryId,SlNo" DataNavigateUrlFormatString="~/Contents/StChangeLat.aspx?intTreasuryIdA={0}&amp;SlNo={1}" DataTextField="chvTreasuryName" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="300px"></ItemStyle>
                </asp:HyperLinkField>
    <asp:BoundField HeaderText="T Type" DataField="chvTreasuryType" />



</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </td><td>&nbsp;<caption>
             &nbsp;</TD>
         </caption>
    </tr>  

     </table> </asp:Panel>
    </td></tr>
<tr><td>

    <asp:Panel ID="pnlGo" runat="server" Width="900px" Visible="false"><table>
                <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label7" class="MnHead" runat="server" Text="GO Add" ></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox id="chkShowAll" class="p1" runat="server" OnCheckedChanged="chkShowAll_CheckedChanged" AutoPostBack="True" Text="Show All" ></asp:CheckBox> 
                    </td>
                </tr>
        <tr >
                    <td align="left" >
                         <asp:Label ID="Label8" runat="server" Text="GO No." CssClass="p1" Width="120px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtGo" runat="server" Width="150px" MaxLength="150" ></asp:TextBox></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label9" runat="server" Text="Date of Order" CssClass="p1" Width="250px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox id="txtOrderDate" runat="server"  CssClass="datePicker" Width="150px"></asp:TextBox></td>
                </tr>  

         <tr >
                    <td align="left" style="width: 389px"  >
                         <asp:Label ID="Label10" runat="server" Text="Date of Effect" CssClass="p1" Width="120px"></asp:Label> 
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtEffectDate" runat="server"  CssClass="datePicker" Width="150px"></asp:TextBox><asp:Label ID="txtGoId" runat="server" Width="10px" Visible="False" Text="0" ></asp:Label></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label11" runat="server" Text="Due Date for Withdrawal" CssClass="p1" Width="250px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox id="txtWith" runat="server"  CssClass="datePicker" Width="150px"></asp:TextBox></td>
                </tr>  
            <tr>
    <td colspan="2" align="center">
        <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="65px" Text="New"></asp:Button>
        <asp:Button id="btnGOAdd" onclick="btnGOAdd_Click" runat="server" Width="65px" Text="Add"></asp:Button>
         <asp:Button id="btnDelGo" onclick="btnDelGo_Click" runat="server" Width="65px" Text="Delete" onclientclick="return DeleteItem()"></asp:Button>
    </td>
</tr>  
        <tr><td colspan="2" align="center">

            <asp:GridView id="gdvGo" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="650px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="SlNo"></asp:BoundField>
    <asp:HyperLinkField DataNavigateUrlFields="intOrderId" DataNavigateUrlFormatString="~/Contents/StChangeLat.aspx?intOrderId={0}" DataTextField="chvOrderNo" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="200px"></ItemStyle>
                </asp:HyperLinkField>
    <asp:BoundField HeaderText="Date of Order" DataField="dtmDateOfOrder" />

    <asp:BoundField DataField="DateOfEffect" HeaderText="Date of Effect" />
    <asp:BoundField DataField="DueDateForWith" HeaderText="DueDate for Withdrawal" />
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

            </td></tr>

        </table> </asp:Panel>

    </td></tr>

<tr><td>

    <asp:Panel ID="pnlLb" runat="server" Width="900px" Visible="false"><table>
        <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label18" class="MnHead" runat="server" Text="Localbody" ></asp:Label>
                       
                    </td>
                </tr>

                <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label12" runat="server" Text="Search by District" CssClass="p1" ></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList id="ddlDistLb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistLb_SelectedIndexChanged" ToolTip="District" Width="140px">
 </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList id="ddlLbTLb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLbTLb_SelectedIndexChanged" ToolTip="LB Type" Width="140px">
 </asp:DropDownList>  &nbsp;&nbsp;&nbsp;<asp:Label ID="Label180" runat="server" Text="Search by Name" CssClass="p1" ></asp:Label> <asp:TextBox id="txtLBName" runat="server" MaxLength="50" ></asp:TextBox>
    <asp:Button id="btnSearchLb" onclick="btnSearchLb_Click" runat="server" Width="77px" Text="Search" Height="20px"></asp:Button>
                    </td>
                </tr>

         <tr >
  <td align="left" style="height: 25px"  >
 <asp:Label ID="Label20" runat="server" Text="District" CssClass="p1" Width="120px" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:DropDownList id="ddlDistLbAdd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistLbAdd_SelectedIndexChanged"  Width="150px" Enabled="False" style="height: 20px">
 </asp:DropDownList></td>
 <td  align="left" style="height: 25px" > <asp:Label ID="Label21" runat="server" Text="LB Type" CssClass="p1" Width="250px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:DropDownList id="ddlLbTLbAdd" runat="server" Width="150px" Enabled="False" >
 </asp:DropDownList></td>
  </tr>  
<tr >
                    <td align="left" style="width: 389px; height: 25px;"  >
                         <asp:Label ID="Label15" runat="server" Text="Block" CssClass="p1" Width="120px"></asp:Label> 
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList id="ddlBlockLBAdd" runat="server"  Width="150px">
 </asp:DropDownList><asp:Label ID="Label16" runat="server" Width="10px" Visible="False" Text="0" ></asp:Label></td>
                
                    <td  align="left" style="height: 25px"  >
                         <asp:Label ID="Label17" runat="server" Text="Sub Treasury" CssClass="p1" Width="250px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:DropDownList id="ddlSTLBAdd" runat="server" Width="150px"> </asp:DropDownList></td>
                </tr>  
        <tr >
  <td align="left" >
 <asp:Label ID="Label13" runat="server" Text="LB Name" CssClass="p1" Width="120px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="txtNameLb" runat="server" Width="150px" MaxLength="150" ></asp:TextBox></td>
 <td  align="left"  > <asp:Label ID="Label14" runat="server" Text="LB Code" CssClass="p1" Width="250px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox id="txtLBCode" runat="server" Width="150px"></asp:TextBox></td>
  </tr>  

  <tr >
  <td align="left" style="width: 389px; height: 25px;"  >
  <asp:Label ID="Label19" runat="server" Text="Status" CssClass="p1" Width="120px"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:DropDownList id="ddlStatusLB" runat="server"   Width="150px">
 </asp:DropDownList><asp:Label ID="Label22" runat="server" Width="10px" Visible="False" Text="0" ></asp:Label></td>
   
                </tr>         
            <tr>
    <td colspan="2" align="center">
        <asp:Button id="btnLbNew" onclick="btnLbNew_Click" runat="server" Width="65px" Text="New"></asp:Button>
        <asp:Button id="btnLbAdd" onclick="btnLbAdd_Click" runat="server" Width="65px" Text="Add"></asp:Button>
    </td>
</tr>  
        <tr><td colspan="2" align="center">

            <asp:GridView id="gdvLbAdd" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intDistID" HeaderText="Dist">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
     <asp:BoundField DataField="intId" HeaderText="LB Id" />
<%--<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ReadOnly="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>--%>
<asp:HyperLinkField DataNavigateUrlFields="intId,intDistID,intLBTypeID" DataNavigateUrlFormatString="~/Contents/StChangeLat.aspx?intId={0}&amp;intDistID={1}&amp;intLBTypeID={2}" DataTextField="chvEngLBName" HeaderText="Localbody">
 <ControlStyle ForeColor="DarkTurquoise"></ControlStyle> <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="200px"></ItemStyle> </asp:HyperLinkField>

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
</asp:GridView>

            </td></tr>

        </table> </asp:Panel>

    </td></tr>
            </tbody>   </table>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             </TD></tr>
                     
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>