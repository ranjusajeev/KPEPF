<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_MembershipNomonation, App_Web_sldhjcan" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD align=center><TABLE cellSpacing=0 cellPadding=0 width="61%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Membership"></asp:Label></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD vAlign=top><TABLE style="MARGIN-RIGHT: 2px" cellSpacing=0 cellPadding=0 width="70%" border=0><TBODY><TR><TD style="WIDTH: 40%; TEXT-ALIGN: left"><asp:Label id="Inward" class="p1" runat="server" Text="Inward No."></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtInwNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" ForeColor="Black" OnTextChanged="txtInwNo_TextChanged" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric"></asp:TextBox><asp:Label id="FileNo" class="p2" runat="server"></asp:Label></TD></TR><TR><TD style="HEIGHT: 20px; TEXT-ALIGN: left"><asp:Label id="AppDate" class="p1" runat="server" Text="Application Date"></asp:Label></TD><TD style="HEIGHT: 20px; TEXT-ALIGN: left"><asp:TextBox id="txtAppDate" tabIndex=1 runat="server" ForeColor="Black" OnTextChanged="txtAppDate_TextChanged" AutoPostBack="True" MaxLength="10" CssClass="datePicker"></asp:TextBox></TD></TR><%--                        <tr>
                            <td colspan="2"><asp:Label runat="server" Text="Details of the Applicant" ID="lblApp" class="p2"></asp:Label></td>
                        </tr>--%><%--                        <tr>
                            <td ><asp:Label runat="server" Text="Account No:" ID="lblAccNo" class="p1"></asp:Label></td>
                            <td ><asp:TextBox runat="server" Width="200px" TabIndex="2" ID="txtAcc" ReadOnly="True" AutoPostBack="True" ></asp:TextBox></td>
                        </tr>
--%><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblEmp" class="p1" runat="server" Text="Name of Applicant"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtEmpName" tabIndex=2 runat="server" Width="200px" ForeColor="Black"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left"><asp:Label id="lblEmp1" class="p1" runat="server" Text="Address"></asp:Label></TD><TD style="HEIGHT: 24px; TEXT-ALIGN: left"><asp:Button id="btnAddress" tabIndex=3 onclick="btnAddress_Click" runat="server" Width="155px" Text="Address" CssClass="buttonn"></asp:Button> &nbsp;&nbsp;&nbsp;</TD></TR><TR><TD>&nbsp;</TD><TD align=left><asp:Label id="lblAdd" class="p4" runat="server" Text="..."></asp:Label> </TD></TR><TR align=center><TD colSpan=2><TABLE width="100%" border=2><asp:Panel id="pnlAddressM" runat="server" Visible="false"  Width="80%"><TBODY /><TR /><TD colspan="4" />&nbsp; <TABLE class="maintable" width="70%" border=0><TBODY><TR><TD style="HEIGHT: 17px; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=4><asp:Label id="lblAddr" class="p2" runat="server" Text="Address of the Applicant">
</asp:Label> </TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblwardNo" class="p1" runat="server" Text="WardNo">
            </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtWardNo" tabIndex=3 onkeypress="return  isNumberKey(event)" runat="server" MaxLength="5" CssClass="txtNumeric">
            </asp:TextBox> </TD> &nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblDoorNo1" class="p1" runat="server" Text="DoorNo">
            </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtDoorNo1" tabIndex=4 runat="server" MaxLength="25">
            </asp:TextBox> </TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblBldg" class="p1" runat="server" Text="BuildingName">
             </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtBldgNm" tabIndex=5 runat="server" MaxLength="25">
                </asp:TextBox> </TD>&nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblRANo" class="p1" runat="server" Text="ResidanceAssociationNo">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtRANo" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblSt" class="p1" runat="server" Text="LocalPlace">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtLocalPlace" runat="server" MaxLength="25">
                </asp:TextBox> </TD>&nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblMP" class="p1" runat="server" Text="MainPlace">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtMainPlace" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblStreetNam" class="p1" runat="server" Text="StreetName">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtStreet" runat="server" MaxLength="25">
                </asp:TextBox> </TD>&nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblDist" class="p1" runat="server" Text="District">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:DropDownList id="ddlDist" runat="server" Width="159px" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                </asp:DropDownList></TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblPin" class="p1" runat="server" Text="Pincode">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtPincode" runat="server" Enabled="false" ReadOnly="true">
                </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblPost" class="p1" runat="server" Text="PostOffice">
                </asp:Label> </TD>&nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 250px; HEIGHT: 26px"><asp:DropDownList id="ddlpost" runat="server" Width="159px" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="ddlpost_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR align=left><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblstate" class="p1" runat="server" Text="State">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtstate" runat="server" Text="..." Enabled="False" ReadOnly="True">
                </asp:TextBox> </TD></TR><TR align="center"><TD colspan="4"><asp:Button id="btnAddClose" onclick="btnAddClose_Click" runat="server" Width="43px" ForeColor="Navy" Text="Ok" Height="20px">
        </asp:Button> </TD></TR></TBODY></TABLE></asp:Panel><TBODY></TBODY></TABLE></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblDes" class="p1" runat="server" Text="Designation"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="ddlDesig" tabIndex=5 runat="server" Width="200px"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblGender" class="p1" runat="server" Text="Gender"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:RadioButtonList id="rdGender" tabIndex=6 runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdGender_SelectedIndexChanged"><asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
<asp:ListItem Value="2">Female</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblDOB" class="p1" runat="server" Text="Date of Birth"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtDOB" tabIndex=7 runat="server" Width="200px" ForeColor="Black" MaxLength="10" CssClass="datePicker"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblDOJ" class="p1" runat="server" Text="Date of Commencement of Continuous Service"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtDOJ" tabIndex=8 runat="server" Width="200px" ForeColor="Black" MaxLength="10" CssClass="datePicker"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblBP" class="p1" runat="server" Text="Basic Pay"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtBP" oncopy="return false" oncut="return false" tabIndex=9 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" ForeColor="Black" MaxLength="6" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblSub" class="p1" runat="server" Text="Subscription"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtSub" oncopy="return false" oncut="return false" tabIndex=10 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" ForeColor="Black" OnTextChanged="txtSub_TextChanged" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblFund" class="p1" runat="server" Text="Other Fund (If any)"></asp:Label><asp:CheckBox id="chkFund" runat="server" AutoPostBack="True" OnCheckedChanged="chkFund_CheckedChanged"></asp:CheckBox></TD><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:DropDownList id="ddlFund" tabIndex=17 runat="server" Width="200px" Enabled="False"></asp:DropDownList> <asp:Label id="lblotherfund" runat="server"></asp:Label> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr" class="p1" runat="server" Text="Married"></asp:Label></TD><TD style="WIDTH: 50px"><asp:CheckBox id="chkMarried" tabIndex=11 runat="server" Width="109px" AutoPostBack="True" OnCheckedChanged="chkMarried_CheckedChanged"></asp:CheckBox> </TD></TR><TR><TD style="HEIGHT: 47px; TEXT-ALIGN: left"><asp:Label id="lblPension" class="p1" runat="server" Text="Pensionable"></asp:Label></TD><TD style="HEIGHT: 47px; TEXT-ALIGN: left"><asp:RadioButtonList id="rdPension" tabIndex=19 runat="server" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
<asp:ListItem Value="2">No</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr1" class="p1" runat="server" Text="Aadhar"></asp:Label></TD><TD style="WIDTH: 50px"><asp:TextBox id="txtAadhar" oncopy="return false" oncut="return false" tabIndex=12 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="109px" ForeColor="Black" OnTextChanged="txtAadhar_TextChanged" AutoPostBack="True" MaxLength="12" CssClass="txtNumeric"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblMarr2" class="p1" runat="server" Text="Mobile No."></asp:Label></TD><TD style="WIDTH: 50px; HEIGHT: 22px"><asp:TextBox id="txtPhone" oncopy="return false" oncut="return false" tabIndex=13 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="109px" ForeColor="Black" OnTextChanged="txtPhone_TextChanged" AutoPostBack="True" MaxLength="10" CssClass="txtNumeric"></asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr3" class="p1" runat="server" Text="Bank"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlBank" tabIndex=14 runat="server" Width="222px" AutoPostBack="True" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr40" class="p1" runat="server" Text="District"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlDistBank" tabIndex=15 runat="server" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistBank_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr4" class="p1" runat="server" Text="Branch"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlBranch" tabIndex=16 runat="server" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblMarr5" class="p1" runat="server" Text="Bank Account No."></asp:Label></TD><TD style="WIDTH: 50px"><asp:TextBox id="txtBankAccNo" tabIndex=17 runat="server" Width="219px" ForeColor="Black" AutoPostBack="True" MaxLength="20"></asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblSubdt" class="p1" runat="server" Text="Subcription Start Date"></asp:Label></TD><TD style="TEXT-ALIGN: left"><asp:TextBox id="txtSubDate" tabIndex=20 runat="server" Width="219px" ForeColor="Black" CssClass="datePicker"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 26px; TEXT-ALIGN: left"><asp:Label id="lblcnt" class="p1" runat="server" Text="No. of Nominees"></asp:Label></TD><TD style="HEIGHT: 26px; TEXT-ALIGN: left"><asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" tabIndex=18 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="50px" ForeColor="Black" OnTextChanged="txtCnt_TextChanged" AutoPostBack="True" MaxLength="1"></asp:TextBox></TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="lblHeadS1" class="Head1" runat="server" Text="Nominee"></asp:Label></TD></TR><TR><TD colSpan=3><asp:GridView id="gvNominee" tabIndex=19 runat="server" ForeColor="#333333" OnSelectedIndexChanged="gvNominee_SelectedIndexChanged" Font-Size="10pt" Font-Names="Verdana" OnRowEditing="gvNominee_RowEditing" OnRowCreated="gvNominee_RowCreated" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtNomineName" runat="server" Width="96px" MaxLength="25"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnNomineAddress" onclick="btnNomineAddress_Click" runat="server" Font-Bold="True" Text="...." ValidationGroup="2"></asp:Button> <%--<asp:CheckBox ID="chkDo" runat="server" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged"/>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddNomineRelationship" runat="server" Width="58px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age">
<ControlStyle Width="50px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineAge" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="22px" CssClass="txtNumeric" MaxLength="2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Share(%)">
<ControlStyle Width="80px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineShare" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="28px" CssClass="txtNumeric" MaxLength="3" AutoPostBack="True" OnTextChanged="txtNomineShare_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Contigency"><ItemTemplate>
<%--<asp:TextBox id="txtNomineStatus" runat="server"></asp:TextBox>--%><asp:DropDownList id="ddlStatus" runat="server" Width="90px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="NomId"><ItemTemplate>
                                                <asp:Label ID="lblNomId" runat="server" Text="0"></asp:Label>
                                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtNameRep" runat="server" Width="96px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnAddRep" onclick="btnAddRep_Click" runat="server" Text="..." Width="24px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddlRelRep" runat="server" Width="66px" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age"><ItemTemplate>
<asp:TextBox id="txtAgeRep" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="32px" CssClass="txtNumeric" MaxLength="2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=right colSpan=3><asp:Button id="btnSaveNominee" onclick="btnSaveNominee_Click" runat="server" Text="Ok" Visible="False"></asp:Button> </TD></TR><TR><TD colSpan=3><TABLE width="100%"><TBODY><TR><TD colSpan=4><asp:Panel id="pnlAddress" runat="server" Width="80%" Visible="false" BorderStyle="Outset" BorderColor="Blue"><TABLE width="100%"><TBODY><TR><TD style="HEIGHT: 178px" align=center colSpan=4><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD align=center colSpan=4><asp:CheckBox id="chkDo" class="p2" runat="server" Width="293px" ForeColor="#C00000" Text="Same as Address of employee" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged">
                </asp:CheckBox> </TD><%--<td align="center" colspan="4" style="height: 21px"><asp:Label id="lblAddrNom" class="p2" runat="server" ForeColor="#C00000"></asp:Label></td>--%></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblwardNoNom" runat="server" Text="Ward No." CssClass="p1">
                </asp:Label> </TD><TD><asp:TextBox id="txtWardNoNom" onkeypress="return  isNumberKey(event)" runat="server" ForeColor="Black" MaxLength="5" CssClass="txtNumeric"></asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblDoorNo1Nom" runat="server" Text="Door No." CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtDoorNo1Nom" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 28px; TEXT-ALIGN: left"><asp:Label id="lblBldgNom" runat="server" Text="Building Name" MaxLength="25" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 28px"><asp:TextBox id="txtBldgNmNom" runat="server" ForeColor="Black"></asp:TextBox> </TD><TD style="HEIGHT: 28px; TEXT-ALIGN: left"><asp:Label id="lblRANoNom" runat="server" Text="Residance Association No" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 28px"><asp:TextBox id="txtRANoNom" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStNom" runat="server" Text="Local Place" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtLocalPlaceNom" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblMPNom" runat="server" Text="Main Place" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtMainPlaceNom" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStreetNamNom" runat="server" Text="Street Name" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtStreetNom" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox> </TD><TD align=left><asp:Label id="lblDistNom" runat="server" Text="District" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:DropDownList id="ddlDistNom" runat="server" Width="159px" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="ddlDistNom_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPinNom" runat="server" Text="Pincode" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 22px"><asp:TextBox id="txtPincodeNom" runat="server" ForeColor="Black" Enabled="false" ReadOnly="true"></asp:TextBox> </TD><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPostNom" runat="server" Text="Post office" CssClass="p1">
                </asp:Label> </TD><TD style="HEIGHT: 22px"><%-- <asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
                </asp:TextBox> --%><asp:DropDownList id="ddlpostNom" runat="server" Width="159px" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="ddlpostNom_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblstateNom" runat="server" Text="State" CssClass="p1">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 22px"><asp:TextBox id="txtstateNom" runat="server" Text="..." Enabled="False" Readonly="True"></asp:TextBox> </TD></TR><TR align="center" ><TD colSpan=4><asp:Button id="btnAddressOK" onclick="btnAddressOK_Click" runat="server" Width="43px" ForeColor="Navy" Text="Ok" Height="20px"></asp:Button>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="lblWit" class="Head1" runat="server" Text="Witness"></asp:Label> </TD></TR><TR align=center><TD style="TEXT-ALIGN: center" align=center colSpan=4><asp:GridView id="gvWitness" tabIndex=20 runat="server" ForeColor="#333333" OnSelectedIndexChanged="gvWitness_SelectedIndexChanged" CellSpacing="2" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                                                        &nbsp;<asp:TextBox ID="txtWitnessName" runat="server" MaxLength="25" Width="213px"></asp:TextBox>
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
                                                        <asp:Button ID="btnWitnessAddress" runat="server" Font-Bold="True" OnClick="btnWitnessAddress_Click"
                                                                        Text="...." />
                                                    
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center><asp:Button id="btnFinal" onclick="btnFinal_Click" runat="server" Width="64px" Text="Save"></asp:Button> </TD></TR><TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Visible="False" Height="23px" PostBackUrl="~/Contents/InboxMembership.aspx"></asp:LinkButton></TD></TR><asp:Label id="lblConfirm" class="p2" runat="server"></asp:Label></TBODY></TABLE>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
  <%--  </div>
    </form>
</body>
</html>--%>
<script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>
<script language="javascript" type="text/javascript">
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
   
	</script>
	</asp:Content>
