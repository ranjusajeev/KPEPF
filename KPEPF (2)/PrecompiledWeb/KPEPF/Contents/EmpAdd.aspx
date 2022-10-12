<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_EmpAdd, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 600px" class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Employee_New"></asp:Label> </TD></TR><TR><TD style="WIDTH: 600px" align=center><asp:Panel id="pnlEntry" runat="server" Width="603px" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ccd0e6"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="District" runat="server" Text="District" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlDist" runat="server" Width="184px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="LblPr" runat="server" Text="..." Cssclass="p3"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="Lbl" runat="server" Text="Account No." Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtAccNo" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged" MaxLength="5" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Lbl2" runat="server" Text="Name" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtName" runat="server" Width="184px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lbl3" runat="server" Text="Current District" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlDistCurr" runat="server" Width="184px" OnSelectedIndexChanged="ddlDistCurr_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lbl4" runat="server" Text=" Current Institution" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlLb" runat="server" Width="184px">
</asp:DropDownList> </TD></TR>
    
    
        <TR><TD style="WIDTH: 209px" align=left><asp:Label id="Label1" class="p1" runat="server" Text="Date of entry in Service"></asp:Label> </TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtDes" tabIndex=5 runat="server" Width="184px" AutoPostBack="True"  MaxLength="10" CssClass="datePicker" OnTextChanged="txtDes_TextChanged"></asp:TextBox> </TD></TR>
    <TR><TD style="WIDTH: 209px" align=left><asp:Label id="lbladm" class="p1" runat="server" Text="Admitted On"></asp:Label> </TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtAdn" tabIndex=5 runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtAdn_TextChanged" MaxLength="10" CssClass="datePicker"></asp:TextBox> </TD></TR>
    <TR><TD style="WIDTH: 209px" align=left><asp:Label id="lblwef" class="p1" runat="server" Text="W.E.F"></asp:Label> </TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtwef" tabIndex=5 runat="server" Width="184px" AutoPostBack="True"  MaxLength="10" CssClass="datePicker" OnTextChanged="txtwef_TextChanged"></asp:TextBox> </TD></TR>

    <TR><TD style="WIDTH: 209px" align="center" colspan="2"><asp:Label id="Label2" class="p1" runat="server" Text="Nominee Details"></asp:Label> </TD></TR>
    <tr><td style="WIDTH: 500px" align="center" colspan="2">
        <asp:GridView id="gvNominee" runat="server" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" Width="600px" >
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<%--<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle Width="20px"></ItemStyle>
</asp:BoundField>--%>
    <asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
  <%#Container.DataItemIndex+1 %> 
</ItemTemplate>
        <ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtNomineName" runat="server" AutoPostBack="True" Width="120px" text='<%#Eval("chvNomineeName") %>' MaxLength="25" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddlRel" runat="server" Width="120px" __designer:wfdid="w3"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age">
<ControlStyle Width="50px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineAge" oncopy="return false" oncut="return false" text='<%#Eval("intAge") %>' onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="40px" CssClass="txtNumeric" MaxLength="2" __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Share(%)">
<ControlStyle Width="80px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineShare" oncopy="return false" oncut="return false" text='<%#Eval("fltShare") %>' onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="48px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="3" __designer:wfdid="w5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="NomId"><ItemTemplate>
  <asp:Label ID="lblNomId" runat="server" text="0"></asp:Label>
                                            
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Add">
<ItemTemplate><asp:ImageButton id="btnAddRow" onclick="btnAddRow_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>

<%--<asp:TemplateField HeaderText="Delete">
<ItemTemplate><asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>--%>

</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Size="Small" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        </td></tr>
    <TR><TD align=center colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 600px" align=center><asp:Panel id="pnlEntryU" runat="server" Width="600px" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ccd0e6"><TABLE width="100%">
    
    
    <TBODY>
        <TR><TD align=left><asp:Label id="LblU" runat="server" Text="Account No." Cssclass="p1"></asp:Label></TD>
            <TD align=left><asp:TextBox id="txtAccNoU" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtAccNoU_TextChanged" MaxLength="5" CssClass="txtNumeric"></asp:TextBox></TD>

        </TR>
        <TR>
            <TD align=left><asp:Label id="District1" runat="server" Text="District" Cssclass="p1"></asp:Label></TD>
            <TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlDistU" runat="server" Width="184px" OnSelectedIndexChanged="ddlDistU_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="LblPrU" runat="server" Text="..." Cssclass="p3"></asp:Label> </TD>
             </TR>
        
        <TR><TD align=left><asp:Label id="Lbl2U" runat="server" Text="Name" Cssclass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtNameU" runat="server" Width="184px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lblU3" runat="server" Text="Current District" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlDistCurrU" runat="server" Width="184px" OnSelectedIndexChanged="ddlDistCurrU_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lbl4U" runat="server" Text=" Current  Institution" Cssclass="p1"></asp:Label></TD><TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlLbU" runat="server" Width="184px" ></asp:DropDownList> </TD></TR>
        
        <TR><TD style="WIDTH: 209px" align=left><asp:Label id="Label3" class="p1" runat="server" Text="Date of entry in Service"></asp:Label> </TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtDesU" tabIndex=5 runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtDesU_TextChanged" MaxLength="10" CssClass="datePicker"></asp:TextBox> </TD></TR>
        <TR><TD style="WIDTH: 209px" align=left><asp:Label id="lbladmU" class="p1" runat="server" Text="Admitted On"></asp:Label> </TD><TD style="WIDTH: 209px" align=left><asp:TextBox id="txtAdnU" tabIndex=5 runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtAdnU_TextChanged" MaxLength="10" CssClass="datePicker"></asp:TextBox> </TD></TR>
        <TR><TD style="WIDTH: 209px; height: 22px;" align=left><asp:Label id="lblwefU" class="p1" runat="server" Text="W.E.F"></asp:Label> </TD><TD style="WIDTH: 209px; height: 22px;" align=left>
        <asp:TextBox id="txtwefU" tabIndex=5 runat="server" Width="184px" MaxLength="10" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtwefU_TextChanged"></asp:TextBox> </TD></TR>
        

        <TR><TD style="WIDTH: 209px" align="center" colspan="2"><asp:Label id="Label4" class="p1" runat="server" Text="Nominee Details"></asp:Label> </TD></TR>
    <tr><td style="WIDTH: 500px" align="center" colspan="2">
        <asp:GridView id="gvNomineeU" runat="server" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" Width="600px" >
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<%--<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle Width="20px"></ItemStyle>
</asp:BoundField>--%>
      <asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
  <%#Container.DataItemIndex+1 %> 
</ItemTemplate>
        <ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:TextBox id="txtNomineName" runat="server" Width="120px" text='<%#Eval("chvNomineeName") %>' MaxLength="25" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Relationship"><ItemTemplate>
<asp:DropDownList id="ddlRel" runat="server" Width="120px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Age">
<ControlStyle Width="50px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineAge" oncopy="return false" text='<%#Eval("intAge") %>' oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="40px" CssClass="txtNumeric" MaxLength="2" __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Share(%)">
<ControlStyle Width="80px"></ControlStyle>
<ItemTemplate>
<asp:TextBox id="txtNomineShare" oncopy="return false" oncut="return false" text='<%#Eval("fltShare") %>' onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="48px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="3" __designer:wfdid="w5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NomId" Visible="False"><ItemTemplate>
 <%-- <asp:Label ID="lblNomId" runat="server" text="0"></asp:Label>--%>
       <asp:Label ID="lblNomId" runat="server" text='<%#Eval("numNomineeID") %>'></asp:Label>                                 
</ItemTemplate>
</asp:TemplateField>
    
<asp:TemplateField HeaderText="Add">
<ItemTemplate><asp:ImageButton id="btnAddRowU" onclick="btnAddRowU_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Delete">
<ItemTemplate><asp:ImageButton id="btndeleteU" onclick="btnDeleteU_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Size="Small" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        </td></tr>

        <TR><TD align=center colSpan=2>
    <asp:Button id="btnSaveU" onclick="btnSaveU_Click" runat="server" Width="50px" Text="Update"></asp:Button> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>