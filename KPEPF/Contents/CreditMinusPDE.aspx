<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="CreditMinusPDE.aspx.cs" Inherits="Contents_CreditMinusPDE" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" runat="server" Text="Transfer Entry_Credit Minus" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD align=left colSpan=1><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align="right"><asp:Panel id="pnlMain" runat="server" Width="250px"><TABLE><TBODY><TR><TD style="HEIGHT: 16px" align=left><asp:Label id="lbl11" runat="server" Text="Credit Minus" CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="HEIGHT: 16px" align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Credit Minus  Entered " CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR>
    
      <TR><TD colSpan=2><asp:Label id="Label51" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCntWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" OnTextChanged="txtCntWO_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR>
    
    
    <TR><TD colSpan=2><asp:GridView id="gdvCM" runat="server" Width="100%" ForeColor="#333333" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True" OnRowDeleting="gdvCM_RowDeleting" Font-Size="10pt" Font-Names="Verdana">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No"><ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>

<HeaderStyle CssClass="cssHeadGridEng" Width="25px"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCM" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="78px" text='<%#Eval("chvTEId") %>' __designer:wfdid="w12" ></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChNCM" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" CssClass="txtNumeric" text='<%#Eval("intChalNo") %>' __designer:wfdid="w11" MaxLength="4"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtChDtCM" runat="server" Width="68px" CssClass="datePicker" text='<%#Eval("dtmChalDate") %>' __designer:wfdid="w5" AutoPostBack="True" MaxLength="10" OnTextChanged="txtChDtCM_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCM" runat="server" Width="68px" text='<%#Eval("fltAmount") %>' __designer:wfdid="w8" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  CssClass="txtNumeric"  MaxLength="7"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sub Treasury"><ItemTemplate>
<asp:DropDownList id="ddlSubTrCM" runat="server" Width="200px" >
            </asp:DropDownList> 
</ItemTemplate><ItemStyle Width="80px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc No"><ItemTemplate>
<asp:TextBox id="txtAcCM"  text='<%#Eval("chvAccNo") %>' runat="server" Width="68px" OnTextChanged="txtAcCM_TextChanged" MaxLength="50" ></asp:TextBox> 
</ItemTemplate><ItemStyle Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtName"  text='<%#Eval("chvName") %>' runat="server" Width="158px" OnTextChanged="txtAcCM_TextChanged" MaxLength="50"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="160px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
<asp:TextBox id="txtremCM"  text='<%#Eval("chvRemarks") %>' runat="server"  Width="71px"  MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatusCM" runat="server" Width="71px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" text='<%#Eval("intId") %>' runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add" Visible="False"><ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteCr" onclick="btnDeleteCr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="relMnthWiseId" Visible="False"><ItemTemplate>
<asp:TextBox id="RelMnth" text='<%#Eval("intRelMonthWiseId") %>' runat="server" Width="71px" __designer:wfdid="w28"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtchalanId" runat="server" Width="71px" __designer:wfdid="w30"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanAGId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtChalanAGId" runat="server"  Width="71px" ></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align="center" colspan="2">

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton>--%> 
<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="20px" OnClick="btnBack_Click" ></asp:Button>


&nbsp;&nbsp;&nbsp;<asp:Button id="btnSaveCM" onclick="btnOK_Click" runat="server" Width="73px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
 <script language=javascript type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 
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


