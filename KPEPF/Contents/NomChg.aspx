<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="NomChg.aspx.cs" Inherits="Contents_NomChg" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD align=center><TABLE border=1 width=70% cellpadding=0 cellspacing=0><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Nominee Change"></asp:Label><%--<asp:TextBox id="txtMEMReqID" runat="server" text="0" Visible="False" OnTextChanged="txtMEMReqID_TextChanged"></asp:TextBox>--%></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD vAlign=top><TABLE style="MARGIN-RIGHT: 2px" border=0><TBODY><TR><TD align=center colSpan=2><asp:GridView id="gdvMemReqList" runat="server" Width="50%" ForeColor="#333333" Font-Size="10pt" CellSpacing="5" OnSelectedIndexChanged="gdvMemReqList_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="intSlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField HeaderText="Acc No." DataTextField="chvPF_No" DataNavigateUrlFormatString="NomChg.aspx?intPF_No={0}&amp;numMembershipReqID={1}&amp;flgApproval={2}&amp;intTrnTypeID={3}" DataNavigateUrlFields="intPF_No,numMembershipReqID,flgApproval,intTrnTypeID">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="250px"></HeaderStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 40%; TEXT-ALIGN: left"><asp:Label id="lblAccNo" class="p1" runat="server" Text="Account No:"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtAcc" oncopy="return false" oncut="return false" tabIndex=2 onpaste="return false" runat="server" Width="200px" AutoPostBack="True" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblEmp" class="p1" runat="server" Text="Name:"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtEmpName" tabIndex=2 runat="server" Width="200px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Inward" class="p1" runat="server" Text="Inward No"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtInwNo" oncopy="return false" oncut="return false" tabIndex=1 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtInwNo_TextChanged"></asp:TextBox><asp:Label id="FileNo" class="p2" runat="server"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="AppDate" class="p1" runat="server" Text="Application Date"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtAppDate" runat="server" Width="200px" CssClass="datePicker" OnTextChanged="txtAppDate_TextChanged"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 26px; TEXT-ALIGN: left"><asp:Label id="lblcnt" class="p1" runat="server" Text="No of Nominees"></asp:Label></TD><TD style="HEIGHT: 26px; TEXT-ALIGN: left"><asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" AutoPostBack="True" MaxLength="1" OnTextChanged="txtCnt_TextChanged"></asp:TextBox></TD></TR><TR><TD colSpan=3><asp:GridView id="gvNominee" runat="server" Width="100%" ForeColor="#333333" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" OnRowDeleting="OnRowDeleting" OnRowEditing="gvNominee_RowEditing" OnRowCreated="gvNominee_RowCreated" DataKeyNames="numEmpId,intNomineeSlNo">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtNomineName" runat="server" Width="128px" MaxLength="25"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnNomineAddress" onclick="btnNomineAddress_Click" runat="server" Font-Bold="True" Text="...." ValidationGroup="2"></asp:Button> <%--<asp:CheckBox ID="chkDo" runat="server" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged"/>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddNomineRelationship" runat="server">
                                                </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age">
<ControlStyle Width="50px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineAge" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" runat="server" Width="40px" CssClass="txtNumeric" MaxLength="2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Share(%)">
<ControlStyle Width="80px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineShare" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" runat="server" Width="48px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="3" OnTextChanged="txtNomineShare_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Contigency"><ItemTemplate>
<%--<asp:TextBox id="txtNomineStatus" runat="server"></asp:TextBox>--%><asp:DropDownList id="ddlStatus" runat="server" Width="152px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="NomId"><ItemTemplate>
                                                <asp:Label ID="lblNomId" runat="server" Text="0"></asp:Label>
                                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtNameRep" runat="server" Width="120px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnAddRep" onclick="btnAddRep_Click" runat="server" Text="..." Width="24px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddlRelRep" runat="server" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age"><ItemTemplate>
<asp:TextBox id="txtAgeRep" oncut="return false" oncopy="return false" onpaste="return false" runat="server" Width="40px" MaxLength="2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UpdId"><ItemTemplate>
<asp:TextBox id="txtUpdId" runat="server" Width="10px" MaxLength="1" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="True" HeaderText="Delete"></asp:CommandField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=right colSpan=3><asp:Button id="btnSaveNominee" onclick="btnSaveNominee_Click" runat="server" Text="Ok" Visible="false"></asp:Button> </TD></TR><TR><TD colSpan=3><TABLE width="100%"><TBODY><TR><TD colSpan=4>

<%--
<asp:Panel id="pnlAddress" runat="server" Width="50%" Visible="false" BorderStyle="Outset" BorderColor="Blue">
<TABLE width="100%">
<TBODY>
<TR>
<TD colSpan=4>
<TABLE class="maintable" width="100%" border=0>
<TBODY><TR>
<TD align=center colSpan=4>
<asp:CheckBox id="chkDo" class="p2" runat="server" Width="266px" ForeColor="#C00000" Text="Same as Address of employee" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged">
</asp:CheckBox>
</TD><%--<td align="center" colspan="4" style="height: 21px"><asp:Label id="lblAddrNom" class="p2" runat="server" ForeColor="#C00000"></asp:Label></td>--%>
<%--</TR>
<TR>
<TD style="WIDTH: 76px; TEXT-ALIGN: left">
<asp:Label id="lblwardNoNom" runat="server" ForeColor="Navy" Text="Ward No">
</asp:Label>
</TD>
<TD>
<asp:TextBox id="txtWardNoNom" onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="5">
</asp:TextBox> 
</TD>
<TD style="TEXT-ALIGN: left">
<asp:Label id="lblDoorNo1Nom" runat="server" ForeColor="Navy" Text="Door No">
</asp:Label>
 </TD>
 <TD>
 <asp:TextBox id="txtDoorNo1Nom" runat="server" MaxLength="25">
 </asp:TextBox>
 </TD>
 </TR>
 <TR>
 <TD style="WIDTH: 76px">
 <asp:Label id="lblBldgNom" runat="server" ForeColor="Navy" Text="Building Name" MaxLength="25">
 </asp:Label>
 </TD>
 <TD>
 <asp:TextBox id="txtBldgNmNom" runat="server">
 </asp:TextBox> </TD><TD style="TEXT-ALIGN: left">
 <asp:Label id="lblStNom" runat="server" ForeColor="Navy" Text="Local Place">
 </asp:Label> 
 </TD>
 <TD>
 <asp:TextBox id="txtLocalPlaceNom" runat="server" MaxLength="25">
 </asp:TextBox> </TD></TR><TR><TD style="WIDTH: 76px; HEIGHT: 28px; TEXT-ALIGN: left">
 <asp:Label id="lblMPNom" runat="server" ForeColor="Navy" Text="Main Place"></asp:Label> </TD>
 <TD><asp:TextBox id="txtMainPlaceNom" runat="server" MaxLength="25"></asp:TextBox>
  </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblPinNom" runat="server" ForeColor="Navy" Text="Pincode">
  </asp:Label> </TD><TD>
  <asp:TextBox id="txtPincodeNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
  </asp:TextBox>
   </TD></TR><TR><TD style="WIDTH: 76px; TEXT-ALIGN: left">
   <asp:Label id="lblPostNom" runat="server" ForeColor="Navy" Text="Post office"></asp:Label>
    </TD><TD><asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
    </asp:TextBox>
     </TD><TD align=left><asp:Label id="lblDistNom" runat="server" ForeColor="Navy" Text="District"></asp:Label> 
     </TD><TD><asp:DropDownList id="ddlDistNom" runat="server" Width="159px" ForeColor="Navy">
     
   
    </asp:DropDownList> </TD></TR><TR align=right><TD colSpan=4>
    <asp:Button id="btnAddressOK" onclick="btnAddressOK_Click" runat="server" ForeColor="Navy" Text="Ok">
    </asp:Button>&nbsp; </TD>
    </TR></TBODY></TABLE></TD></TR>
    </TBODY></TABLE>
    
    </asp:Panel> --%>--%>
    <asp:Panel id="pnlAddress" runat="server" Width="50%" Visible="false" BorderColor="Blue" BorderStyle="Outset"><TABLE width="100%"><TBODY><TR><TD style="HEIGHT: 178px" align=center colSpan=4><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD align=center colSpan=4><asp:CheckBox id="chkDo" class="p2" runat="server" Width="293px" ForeColor="#C00000" Text="Same as Address of employee" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged">
                </asp:CheckBox> </TD><%--<td align="center" colspan="4" style="height: 21px"><asp:Label id="lblAddrNom" class="p2" runat="server" ForeColor="#C00000"></asp:Label></td>--%></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblwardNoNom" runat="server" ForeColor="Navy" Text="Ward No.">
                </asp:Label> </TD><TD><asp:TextBox id="txtWardNoNom" onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtWardNoNom_TextChanged">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblDoorNo1Nom" runat="server" ForeColor="Navy" Text="Door No.">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtDoorNo1Nom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left; height: 28px;"><asp:Label id="lblBldgNom" runat="server" ForeColor="Navy" Text="Building Name" MaxLength="25">
                </asp:Label> </TD><TD style="WIDTH: 160px; height: 28px;"><asp:TextBox id="txtBldgNmNom" runat="server">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left; height: 28px;"><asp:Label id="lblRANoNom" runat="server" ForeColor="Navy" Text="Residanceassociation No">
                </asp:Label> </TD><TD style="WIDTH: 160px; height: 28px;"><asp:TextBox id="txtRANoNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStNom" runat="server" ForeColor="Navy" Text="Local Place">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtLocalPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblMPNom" runat="server" ForeColor="Navy" Text="Main Place">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtMainPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStreetNamNom" runat="server" ForeColor="Navy" Text="StreetName">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtStreetNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD align=left><asp:Label id="lblDistNom" runat="server" ForeColor="Navy" Text="District">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:DropDownList id="ddlDistNom" runat="server" Width="159px" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="ddlDistNom_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left; height: 22px;"><asp:Label id="lblPinNom" runat="server" ForeColor="Navy" Text="Pincode">
                </asp:Label> </TD><TD style="WIDTH: 160px; height: 22px;"><asp:TextBox id="txtPincodeNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left; height: 22px;"><asp:Label id="lblPostNom" runat="server" ForeColor="Navy" Text="Post office">
                </asp:Label> </TD><TD style="height: 22px"><%-- <asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
                </asp:TextBox> --%><asp:DropDownList id="ddlpostNom" runat="server" Width="159px" ForeColor="Navy">
                </asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblstateNom" runat="server" ForeColor="Navy" Text="State">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtstateNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD></TR><TR align=right><TD colSpan=4><asp:Button id="btnAddressOK" onclick="btnAddressOK_Click" runat="server" ForeColor="Navy" Text="Ok">
                </asp:Button>&nbsp; 
                </TD></TR></TBODY>
                </TABLE></TD></TR>
                </TBODY></TABLE>
                </asp:Panel>
    </TD></TR>
    <TR>
    <TD align=center>
    <asp:Button id="btnFinal" onclick="btnFinal_Click" runat="server" Width="72px" Text="Save"></asp:Button>
     </TD></TR><TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Height="23px" Visible="False" PostBackUrl="~/Contents/InboxMembership.aspx"></asp:LinkButton></TD></TR><asp:Label id="lblConfirm" class="p2" runat="server"></asp:Label></TBODY></TABLE>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

<script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>
<script language=javascript type="text/javascript">
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
        if(document.activeElement.className == "txtNumericFloat")
        {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode != 46 && (charCode < 48 || charCode > 57))
             return false;
             else
             return true;
        }
    }
    function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
   
	
</asp:Content>

