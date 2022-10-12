<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="NomineePDE.aspx.cs" Inherits="Contents_NomineePDE" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Membership</title>
    <script src="../JS/jquery-1.8.3.js"></script>
    <script src="../JS/jquery-ui-1.9.2.custom.js"></script>
    <link href="../themes/jquery-ui-1.9.2.custom.css" rel="stylesheet" type="text/css"/>
    <link href="../themes/styleL.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server" language="javascript" onkeypress="javascript:isNumberKey();">
    <div>--%>
    <asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Nomination-PDE"></asp:Label></TD></TR><TR><TD style="WIDTH: 866px" vAlign=top><TABLE style="MARGIN-RIGHT: 2px"><TBODY><TR><TD align=center colSpan=2><asp:GridView id="gdvMemReqList" runat="server" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvMemReqList_SelectedIndexChanged" CellSpacing="5" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="intSlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intPF_No,numMembershipReqID,flgApproval" DataNavigateUrlFormatString="NomineePDE.aspx?intPF_No={0}&amp;numMembershipReqID={1}&amp;flgApproval={2}" DataTextField="chvPF_No" HeaderText="Acc No.">
<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD><asp:Label id="lblAccNo" class="p1" runat="server" Text="Account No:"></asp:Label></TD><TD><asp:TextBox id="txtAcc" oncopy="return false" oncut="return false" tabIndex=2 onpaste="return false" runat="server" Width="200px" ReadOnly="True" AutoPostBack="True" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblEmp" class="p1" runat="server" Text="Name & address of Applicant"></asp:Label></TD><TD><asp:TextBox id="txtEmpName" tabIndex=2 runat="server" Width="200px" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left"><asp:Label id="lblEmp1" class="p1" runat="server" Text="Address"></asp:Label></TD><TD style="HEIGHT: 24px; TEXT-ALIGN: left"><asp:Button id="btnAddress" tabIndex=1 onclick="btnAddress_Click" runat="server" Width="155px" Text="Address" CssClass="buttonn"></asp:Button> &nbsp;&nbsp;&nbsp;</TD></TR><TR><TD>&nbsp;</TD><TD align=left><asp:Label id="lblAdd" class="p1" runat="server" Text="..."></asp:Label> </TD></TR><TR align=center><TD style="HEIGHT: 15px" colSpan=2><TABLE width="100%" border=2><asp:Panel id="pnlAddressM" runat="server" Visible="false"><TBODY /><TR /><TD colspan="4" />&nbsp; <TABLE class="maintable" width="70%" border=0><TBODY><TR><TD style="HEIGHT: 17px; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=4><asp:Label id="lblAddr" class="p2" runat="server" Text="Address of the Applicant">
</asp:Label> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblwardNo" class="p1" runat="server" Text="WardNo">
            </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtWardNo" tabIndex=3 onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="5">
            </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblDoorNo1" class="p1" runat="server" Text="DoorNo">
            </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtDoorNo1" tabIndex=4 runat="server" MaxLength="25">
            </asp:TextBox> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblBldg" class="p1" runat="server" Text="BuildingName">
             </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtBldgNm" tabIndex=5 runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblRANo" class="p1" runat="server" Text="ResidanceAssociationNo">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtRANo" tabIndex=6 runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblSt" class="p1" runat="server" Text="LocalPlace">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtLocalPlace" tabIndex=7 runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblMP" class="p1" runat="server" Text="MainPlace">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtMainPlace" tabIndex=8 runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblStreetNam" class="p1" runat="server" Text="StreetName">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtStreet" tabIndex=9 runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblDist" class="p1" runat="server" Text="District">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:DropDownList id="ddlDist" tabIndex=10 runat="server" Width="159px" ForeColor="Navy" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblPin" class="p1" runat="server" Text="Pincode">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtPincode" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblPost" class="p1" runat="server" Text="PostOffice">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><%-- <asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
                </asp:TextBox> --%><asp:DropDownList id="ddlpost" tabIndex=11 runat="server" Width="159px" ForeColor="Navy">
                </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 50px; HEIGHT: 26px"><asp:Label id="lblstate" class="p1" runat="server" Text="State">
                </asp:Label> </TD><TD style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox id="txtstate" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD></TR><TR><TD><asp:Button id="btnAddClose" onclick="btnAddClose_Click" runat="server" Text="Ok">
        </asp:Button> </TD></TR></TBODY><%--<tr><td>
                                                <uc2:Address ID="Address1" runat="server" Visible="true"  /></td></tr>--%></TABLE></asp:Panel><TBODY></TBODY></TABLE></TD></TR><TR><TD><asp:Label id="lblDes" class="p1" runat="server" Text="Designation"></asp:Label></TD><TD><asp:DropDownList id="ddlDesig" tabIndex=2 runat="server" Width="200px"></asp:DropDownList></TD></TR><TR><TD><asp:Label id="lblGender" class="p1" runat="server" Text="Gender"></asp:Label></TD><TD><asp:RadioButtonList id="rdGender" tabIndex=3 runat="server" OnSelectedIndexChanged="rdGender_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Value="1">Male</asp:ListItem>
<asp:ListItem Value="2">Female</asp:ListItem>
</asp:RadioButtonList> <asp:Label id="lblGenderSec" runat="server"></asp:Label> </TD></TR><TR><TD><asp:Label id="lblDOB" class="p1" runat="server" Text="Date of Birth"></asp:Label></TD><TD><asp:TextBox id="txtDOB" tabIndex=4 runat="server" Width="200px" CssClass="datePicker"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblDOJ" class="p1" runat="server" Text="Date of Commencement of Continuous Service"></asp:Label></TD><TD><asp:TextBox id="txtDOJ" tabIndex=5 runat="server" Width="200px" CssClass="datePicker"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblBP" class="p1" runat="server" Text="Basic Pay"></asp:Label></TD><TD><asp:TextBox id="txtBP" oncopy="return false" oncut="return false" tabIndex=6 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" CssClass="txtNumeric" MaxLength="6"></asp:TextBox></TD></TR><TR><TD><asp:Label id="lblSub" class="p1" runat="server" Text="Subscription"></asp:Label></TD><TD><asp:TextBox id="txtSub" oncopy="return false" oncut="return false" tabIndex=7 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="200px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtSub_TextChanged"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 22px"><asp:Label id="lblFund" class="p1" runat="server" Text="Other Fund"></asp:Label><asp:CheckBox id="chkFund" runat="server" AutoPostBack="True" OnCheckedChanged="chkFund_CheckedChanged"></asp:CheckBox></TD><TD style="HEIGHT: 22px"><asp:DropDownList id="ddlFund" tabIndex=8 runat="server" Width="200px"></asp:DropDownList>&nbsp; </TD></TR><TR><TD><asp:Label id="lblMarr" class="p1" runat="server" Text="Married"></asp:Label></TD><TD style="WIDTH: 50px"><asp:CheckBox id="chkMarried" tabIndex=9 runat="server" Width="109px" AutoPostBack="True" OnCheckedChanged="chkMarried_CheckedChanged"></asp:CheckBox> <asp:Label id="LblMarrSec" class="p1" runat="server"></asp:Label> </TD></TR><TR><TD><asp:Label id="lblMarr1" class="p1" runat="server" Text="Aadhar"></asp:Label></TD><TD style="WIDTH: 50px"><asp:TextBox id="txtAadhar" oncopy="return false" oncut="return false" tabIndex=10 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="109px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="12" OnTextChanged="txtAadhar_TextChanged"></asp:TextBox> </TD></TR><TR><TD><asp:Label id="lblMarr2" class="p1" runat="server" Text="Mobile No."></asp:Label></TD><TD style="WIDTH: 50px"><asp:TextBox id="txtPhone" oncopy="return false" oncut="return false" tabIndex=11 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="109px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="10" OnTextChanged="txtPhone_TextChanged"></asp:TextBox> </TD></TR><TR><TD><asp:Label id="lblMarr3" class="p1" runat="server" Text="Bank"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlBank" tabIndex=12 runat="server" Width="222px" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD><asp:Label id="lblMarr40" class="p1" runat="server" Text="District"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlDistBank" tabIndex=13 runat="server" Width="225px" OnSelectedIndexChanged="ddlDistBank_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD><asp:Label id="lblMarr4" class="p1" runat="server" Text="Branch"></asp:Label></TD><TD style="WIDTH: 50px"><asp:DropDownList id="ddlBranch" tabIndex=14 runat="server" Width="225px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD><asp:Label id="lblMarr5" class="p1" runat="server" Text="Bank Account No."></asp:Label></TD><TD style="WIDTH: 50px"><asp:TextBox id="txtBankAccNo" tabIndex=15 runat="server" Width="219px" AutoPostBack="True" MaxLength="20"></asp:TextBox> </TD></TR><TR><TD><asp:Label id="lblSubdt" class="p1" runat="server" Text="Subscription Start Date"></asp:Label></TD><TD><asp:TextBox id="txtSubDate" tabIndex=20 runat="server" Width="200px" CssClass="datePicker"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 26px"><asp:Label id="lblcnt" class="p1" runat="server" Text="No of Nominees"></asp:Label></TD><TD style="HEIGHT: 26px"><asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" tabIndex=16 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="50px" AutoPostBack="True" MaxLength="1" OnTextChanged="txtCnt_TextChanged"></asp:TextBox></TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="lblHeadS1" class="Head1" runat="server" Text="Nominee"></asp:Label></TD></TR><TR><TD colSpan=3><asp:GridView id="gvNominee" tabIndex=17 runat="server" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnRowCreated="gvNominee_RowCreated" OnRowEditing="gvNominee_RowEditing">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle Width="20px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtNomineName" runat="server" Width="114px" MaxLength="25" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnNomineAddress" onclick="btnNomineAddress_Click" runat="server" Font-Bold="True" Text="...." __designer:wfdid="w2" ValidationGroup="2"></asp:Button> <%--<asp:CheckBox ID="chkDo" runat="server" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged"/>--%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddNomineRelationship" runat="server" Width="70px" __designer:wfdid="w3"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age">
<ControlStyle Width="50px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineAge" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="40px" CssClass="txtNumeric" MaxLength="2" __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Share(%)">
<ControlStyle Width="80px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineShare" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="48px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="3" OnTextChanged="txtNomineShare_TextChanged" __designer:wfdid="w5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Contigency"><ItemTemplate>
<%--<asp:TextBox id="txtNomineStatus" runat="server"></asp:TextBox>--%><asp:DropDownList id="ddlStatus" runat="server" Width="126px" __designer:wfdid="w6"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="NomId"><ItemTemplate>
                                                <asp:Label ID="lblNomId" runat="server" Text="0"></asp:Label>
                                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtNameRep" runat="server" Width="111px" __designer:wfdid="w7"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><ItemTemplate>
<asp:Button id="btnAddRep" onclick="btnAddRep_Click" runat="server" Text="..." Width="24px"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddlRelRep" runat="server" AutoPostBack="True" __designer:wfdid="w8"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age"><ItemTemplate>
<asp:TextBox id="txtAgeRep" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="33px" CssClass="txtNumeric" MaxLength="2" __designer:wfdid="w9"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=right colSpan=3><asp:Button id="btnSaveNominee" onclick="btnSaveNominee_Click" runat="server" Text="Ok" Visible="False"></asp:Button> </TD></TR><TR><TD colSpan=3><TABLE width="100%"><TBODY><TR><TD colSpan=4><%--<%--<asp:Panel id="pnlAddress" runat="server" Width="50%" Visible="false" BorderColor="Blue" BorderStyle="Outset"><TABLE width="100%"><TBODY><TR><TD style="HEIGHT: 178px" align=center colSpan=4><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD align=center colSpan=4><asp:CheckBox id="chkDo" class="p2" runat="server" Width="293px" ForeColor="#C00000" Text="Same as Address of employee" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged">
                </asp:CheckBox> </TD><%--<td align="center" colspan="4" style="height: 21px"><asp:Label id="lblAddrNom" class="p2" runat="server" ForeColor="#C00000"></asp:Label></td>--%><%--</TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblwardNoNom" runat="server" ForeColor="Navy" Text="Ward No.">
                </asp:Label> </TD><TD><asp:TextBox id="txtWardNoNom" onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="5">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblDoorNo1Nom" runat="server" ForeColor="Navy" Text="Door No.">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtDoorNo1Nom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblBldgNom" runat="server" ForeColor="Navy" Text="Building Name" MaxLength="25">
                </asp:Label> </TD><TD><asp:TextBox id="txtBldgNmNom" runat="server">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblRANoNom" runat="server" ForeColor="Navy" Text="Residanceassociation No">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtRANoNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStNom" runat="server" ForeColor="Navy" Text="Local Place">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtLocalPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblMPNom" runat="server" ForeColor="Navy" Text="Main Place">
                </asp:Label> </TD><TD><asp:TextBox id="txtMainPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStreetNamNom" runat="server" ForeColor="Navy" Text="StreetName">
                </asp:Label> </TD><TD><asp:TextBox id="txtStreetNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD align=left><asp:Label id="lblDistNom" runat="server" ForeColor="Navy" Text="District">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:DropDownList id="ddlDistNom" runat="server" Width="159px" ForeColor="Navy" OnSelectedIndexChanged="ddlDistNom_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPinNom" runat="server" ForeColor="Navy" Text="Pincode">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 22px"><asp:TextBox id="txtPincodeNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPostNom" runat="server" ForeColor="Navy" Text="Post office">
                </asp:Label> </TD><TD style="HEIGHT: 22px"><%-- <asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
                </asp:TextBox> --%><%-- <asp:DropDownList id="ddlpostNom" runat="server" Width="159px" ForeColor="Navy">
                </asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblstateNom" runat="server" ForeColor="Navy" Text="State">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtstateNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD></TR><TR align=right><TD colSpan=4><asp:Button id="btnAddressOK" onclick="btnAddressOK_Click" runat="server" ForeColor="Navy" Text="Ok">
                </asp:Button>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY>
                </TABLE>
                </asp:Panel>--%><asp:Panel id="pnlAddress" runat="server" Width="50%" Visible="false" BorderColor="Blue" BorderStyle="Outset"><TABLE width="100%"><TBODY><TR><TD style="HEIGHT: 178px" align=center colSpan=4><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD align=center colSpan=4><asp:CheckBox id="chkDo" class="p2" runat="server" Width="293px" ForeColor="#C00000" Text="Same as Address of employee" AutoPostBack="True" OnCheckedChanged="chkDo_CheckedChanged">
                </asp:CheckBox> </TD><%--<td align="center" colspan="4" style="height: 21px"><asp:Label id="lblAddrNom" class="p2" runat="server" ForeColor="#C00000"></asp:Label></td>--%></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblwardNoNom" runat="server" ForeColor="Navy" Text="Ward No.">
                </asp:Label> </TD><TD><asp:TextBox id="txtWardNoNom" onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="5">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblDoorNo1Nom" runat="server" ForeColor="Navy" Text="Door No.">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtDoorNo1Nom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 28px; TEXT-ALIGN: left"><asp:Label id="lblBldgNom" runat="server" ForeColor="Navy" Text="Building Name" MaxLength="25">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 28px"><asp:TextBox id="txtBldgNmNom" runat="server">
                </asp:TextBox> </TD><TD style="HEIGHT: 28px; TEXT-ALIGN: left"><asp:Label id="lblRANoNom" runat="server" ForeColor="Navy" Text="Residanceassociation No">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 28px"><asp:TextBox id="txtRANoNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStNom" runat="server" ForeColor="Navy" Text="Local Place">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtLocalPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="lblMPNom" runat="server" ForeColor="Navy" Text="Main Place">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtMainPlaceNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblStreetNamNom" runat="server" ForeColor="Navy" Text="StreetName">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtStreetNom" runat="server" MaxLength="25">
                </asp:TextBox> </TD><TD align=left><asp:Label id="lblDistNom" runat="server" ForeColor="Navy" Text="District">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:DropDownList id="ddlDistNom" runat="server" Width="159px" ForeColor="Navy" OnSelectedIndexChanged="ddlDistNom_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPinNom" runat="server" ForeColor="Navy" Text="Pincode">
                </asp:Label> </TD><TD style="WIDTH: 160px; HEIGHT: 22px"><asp:TextBox id="txtPincodeNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD><TD style="HEIGHT: 22px; TEXT-ALIGN: left"><asp:Label id="lblPostNom" runat="server" ForeColor="Navy" Text="Post office">
                </asp:Label> </TD><TD style="HEIGHT: 22px"><%-- <asp:TextBox id="txtPostofficeNom" runat="server" MaxLength="25">
                </asp:TextBox> --%><asp:DropDownList id="ddlpostNom" runat="server" Width="159px" ForeColor="Navy">
                </asp:DropDownList> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="lblstateNom" runat="server" ForeColor="Navy" Text="State">
                </asp:Label> </TD><TD style="WIDTH: 160px"><asp:TextBox id="txtstateNom" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="6">
                </asp:TextBox> </TD></TR><TR align=right><TD colSpan=4><asp:Button id="btnAddressOK" onclick="btnAddressOK_Click" runat="server" ForeColor="Navy" Text="Ok">
                </asp:Button>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="lblWit" class="Head1" runat="server" Text="Witness"></asp:Label> </TD></TR><TR align=center><TD style="WIDTH: 494px" colSpan=4><asp:GridView id="gvWitness" tabIndex=18 runat="server" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="2">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtWitnessName" runat="server" Width="193px" MaxLength="25" __designer:wfdid="w11"></asp:TextBox> 
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
</asp:GridView> </TD></TR><TR><TD align=center><asp:Button id="btnFinal" tabIndex=19 onclick="btnFinal_Click" runat="server" Width="56px" Text="Save"></asp:Button> </TD></TR><TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Visible="False" PostBackUrl="~/Contents/InboxMembership.aspx" Height="23px"></asp:LinkButton></TD></TR><asp:Label id="lblConfirm" class="p2" runat="server"></asp:Label></TBODY></TABLE>&nbsp; </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
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
   
	</script>
	</asp:Content>
