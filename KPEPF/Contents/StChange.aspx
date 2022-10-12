<%@ Page Language="C#"  MasterPageFile="~/Contents/MasterPage.master"  AutoEventWireup="true" CodeFile="StChange.aspx.cs" Inherits="Contents_StChange" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>

        <table style="WIDTH: 100%">
            <tbody> <tr><td>
                <asp:Panel ID="pnlMapp" runat="server"><table style="WIDTH: 100%">
                    <tr >
                    <td style="WIDTH: 90%" class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="lblHead" class="MnHead" runat="server" Text="Treasury mapping" ></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td align="center" style="width: 90%" >
                         <asp:Label ID="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlDT" runat="server" Width="184px" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                
</tr> <tr >
         <td colspan="2" align="center" >       
    <asp:RadioButtonList ID="rdChecked" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdChecked_SelectedIndexChanged" >
        <asp:ListItem Value="1">Mapped</asp:ListItem>
        <asp:ListItem Value="2" Selected="True">Show All</asp:ListItem>
    </asp:RadioButtonList>
        </td>      </tr>        
                    
                
          <tr>
<TD vAlign=top style="width: 90%" align="left">
        <asp:GridView ID="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True">
            <RowStyle BackColor="#EFF3FB"></RowStyle>
            <Columns>
                <asp:HyperLinkField DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>

                <asp:HyperLinkField DataNavigateUrlFields="intTreasuryId,SlNo" DataNavigateUrlFormatString="~/Contents/StChange.aspx?intTreasuryId={0}&amp;SlNo={1}" DataTextField="chvTreasuryName" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="300px"></ItemStyle>
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:CheckBox id="chkAppT" runat="server"  __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
             
        <asp:TemplateField HeaderText="TId">

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
        </asp:GridView> </TD><TD style="WIDTH: 864px" vAlign=top><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="451px">
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
        <asp:Button id="btnDelT" onclick="btnDelT_Click" runat="server" Width="65px" Text="Delete"></asp:Button>
    </td>
</tr>
                </table>   </asp:Panel> </td>      </tr> 



<tr><td>

    <asp:Panel ID="pnlUpd" runat="server" Width="90%"><table>
                <tr >
                    <td  class="TdMnHead" colspan="4">&nbsp;<asp:Label ID="Label12" class="MnHead" runat="server" Text="Chalan_Treasury Update" ></asp:Label>
                    </td>
                </tr>
   <tr >
                    <td align="left" style="width: 25%"  >
                         <asp:Label ID="Label13" runat="server" Text="District" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>  <td align="left" style="width: 100px"  >  <asp:DropDownList ID="ddlDistUpd" runat="server" Width="184px" OnSelectedIndexChanged="ddlDistUpd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                
                     <td align="left" style="width: 25%"  > 
                         <asp:CheckBox id="chkAll" runat="server" Text="All" CssClass="p1" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="Label14" runat="server" Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   </td>  <td align="left" style="width: 100px"  >          <asp:DropDownList ID="ddlYearUpd" runat="server" Width="184px" Enabled="False" ></asp:DropDownList></td>
                </tr>  
    <tr >
                    <td align="left" style="width: 25%; height: 22px;"  >
                         <asp:Label ID="Label15" runat="server" Text="Localbody" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          </td>    <td align="left" style="width: 25%; height: 22px;"  >              <asp:DropDownList ID="ddlLbUpd" runat="server" Width="184px" ></asp:DropDownList>
                        <asp:TextBox ID="TextBox2" runat="server" Width="10px" Visible="False" >0</asp:TextBox>
                    </td>
    <td align="left" style="width: 25%; height: 22px;"  >
                         <asp:Label ID="Label16" runat="server" Text="Month" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           </td>        <td align="left" style="width: 25%; height: 22px;"  >          <asp:DropDownList ID="ddlMonthUpd" runat="server" Width="184px" ></asp:DropDownList></td>
                </tr>  
      <tr >
                   <td align="left" style="width: 25%"  >
                         <asp:Label ID="Label17" runat="server" Text="Treasury" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>   <td align="left" style="width: 25%"  >             <asp:DropDownList ID="ddlTreasUpd" runat="server" Width="184px" ></asp:DropDownList>
                        
                    </td>
   <td align="left" style="width: 25%"  >
                          <asp:Button id="btnUpdC" onclick="btnUpdC_Click" runat="server" Width="120px" Text="Update"></asp:Button></td>
                </tr>  
   
    

     </table> </asp:Panel>

    </td></tr>
<tr><td>
<asp:Panel ID="pnlTAdd" runat="server" Width="90%"><table>
                <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label1" class="MnHead" runat="server" Text="Treasury Add" ></asp:Label>
                    </td>
                </tr>
   <tr >
                    <td align="left" style="width: 389px"  >
                         <asp:Label ID="Label2" runat="server" Text="District Treasury" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlDTA" runat="server" Width="184px" OnSelectedIndexChanged="ddlDTA_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label3" runat="server" Text="Treasury Type" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlTTypeA" runat="server" Width="184px" ></asp:DropDownList></td>
                </tr>  
    <tr >
                    <td align="left"   >
                         <asp:Label ID="Label5" runat="server" Text="Treasury Name" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtTNameA" runat="server" Width="184px" MaxLength="150" ></asp:TextBox>
                        <asp:TextBox ID="txtId" runat="server" Width="10px" Visible="False" >0</asp:TextBox>
                    </td>
    <td align="left"  >
                         <asp:Label ID="Label6" runat="server" Text="Treasury Code" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtCodeA" runat="server" Width="184px" MaxLength="10" ></asp:TextBox></td>
                </tr>  
    
    <tr>
    <td colspan="2" align="center">
        <asp:Button id="btnSaveA" onclick="btnSaveA_Click" runat="server" Width="65px" Text="Add"></asp:Button>
    </td>
</tr>  
     <tr >
<TD  vAlign=top  ><asp:GridView id="gdvTAdd" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="400px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="SlNo"></asp:BoundField>
   <%-- <asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" />--%>
    <asp:HyperLinkField DataNavigateUrlFields="intTreasuryId,SlNo" DataNavigateUrlFormatString="~/Contents/StChange.aspx?intTreasuryIdA={0}&amp;SlNo={1}" DataTextField="chvTreasuryName" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="300px"></ItemStyle>
                </asp:HyperLinkField>
    <asp:BoundField HeaderText="T Type" />



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
<asp:BoundField HeaderText="Sl No"></asp:BoundField>
    <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" />



</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 
         <caption>
             &nbsp;</TD>
         </caption>
    </tr>  

     </table> </asp:Panel>
    </td></tr>
<tr><td>

    <asp:Panel ID="pnlGo" runat="server" Width="90%"><table>
                <tr >
                    <td  class="TdMnHead" colspan="2">&nbsp;<asp:Label ID="Label7" class="MnHead" runat="server" Text="GO Add" ></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox id="chkShowAll" class="p1" runat="server" OnCheckedChanged="chkShowAll_CheckedChanged" AutoPostBack="True" Text="Show All" ></asp:CheckBox> 
                    </td>
                </tr>
        <tr >
                    <td align="left" style="width: 389px"  >
                         <asp:Label ID="Label8" runat="server" Text="GO No." CssClass="p1" Width="150px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtGo" runat="server" Width="184px" MaxLength="150" ></asp:TextBox></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label9" runat="server" Text="Date of Order" CssClass="p1" Width="150px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox id="txtOrderDate" runat="server"  CssClass="datePicker"></asp:TextBox></td>
                </tr>  

         <tr >
                    <td align="left" style="width: 389px"  >
                         <asp:Label ID="Label10" runat="server" Text="Date of Effect" CssClass="p1" Width="150px"></asp:Label> 
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtEffectDate" runat="server"  CssClass="datePicker"></asp:TextBox><asp:Label ID="txtGoId" runat="server" Width="10px" Visible="False" Text="0" ></asp:Label></td>
                
                    <td  align="left"  >
                         <asp:Label ID="Label11" runat="server" Text="Due Date for Withdrawal" CssClass="p1" Width="150px"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox id="txtWith" runat="server"  CssClass="datePicker"></asp:TextBox></td>
                </tr>  
            <tr>
    <td colspan="2" align="center">
        <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="65px" Text="New"></asp:Button>
        <asp:Button id="btnGOAdd" onclick="btnGOAdd_Click" runat="server" Width="65px" Text="Add"></asp:Button>
    </td>
</tr>  
        <tr><td colspan="2">

            <asp:GridView id="gdvGo" runat="server" ForeColor="#333333" Font-Size="10pt" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" GridLines="None" ShowFooter="True" Width="800px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="SlNo"></asp:BoundField>
    <asp:HyperLinkField DataNavigateUrlFields="intOrderId" DataNavigateUrlFormatString="~/Contents/StChange.aspx?intOrderId={0}" DataTextField="chvOrderNo" HeaderText="Sub Treasury">
                    <ControlStyle ForeColor="DarkTurquoise"></ControlStyle>

                    <ItemStyle HorizontalAlign="Left" ForeColor="Transparent" Width="300px"></ItemStyle>
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
            </tbody>   </table>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             </TD></tr>

                 
               


                

        



               
           
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>