<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ServiceHistoryEntry, App_Web_zy0s82tr" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
<ContentTemplate>
<TABLE><TBODY><TR><TD><asp:Panel id="pnlService" runat="server" Visible="false"><TABLE><TBODY><TR><TD class="TdMnHead" colSpan=3><asp:Label id="Label8" class="MnHead" runat="server" Text="Basic Service History"></asp:Label> </TD><TD style="WIDTH: 866px; COLOR: black; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=1></TD></TR><TR><TD><asp:Label id="Label9" runat="server" Width="125px" ForeColor="#0000C0" Text="Name Of Employee" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD><asp:Label id="Label10" runat="server" Text=":" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD><asp:Label id="lblName" runat="server" ForeColor="#0000C0" Text="" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD></TD></TR><TR><TD style="HEIGHT: 16px"><asp:Label id="Label11" runat="server" ForeColor="#0000C0" Text="Current Designation" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD style="HEIGHT: 16px"><asp:Label id="Label12" runat="server" Text=":" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD style="HEIGHT: 16px"><asp:Label id="Label13" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD style="HEIGHT: 16px"></TD></TR><TR><TD><asp:Label id="Label14" runat="server" ForeColor="#0000C0" Text="PF Number" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD><asp:Label id="Label15" runat="server" Text=":" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD><asp:Label id="lblNo" runat="server" ForeColor="#0000C0" Text="" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD></TD></TR><TR><TD><asp:Label id="Label16" runat="server" ForeColor="#0000C0" Text="Current Localbody" Font-Size="10pt" Font-Names="Verdana"></asp:Label>&nbsp; </TD><TD><asp:Label id="Label17" runat="server" Text=":" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD><asp:Label id="lblLB" runat="server" ForeColor="#0000C0" Text="" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvService" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumn="false" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="District"><ItemTemplate>
<asp:DropDownList id="ddldist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LB Type"><ItemTemplate>
<asp:DropDownList id="ddlLBType" runat="server" OnSelectedIndexChanged="ddlLBType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LB Name"><ItemTemplate>
<asp:DropDownList id="ddlLBName" runat="server" AutoPostBack="True" width="150"></asp:DropDownList> <asp:TextBox id="txtLBName" runat="server" Visible="false"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Date"><ItemTemplate>
<asp:TextBox id="txtFrom" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtFrom_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Date"><ItemTemplate>
<asp:TextBox id="txtTo" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtTo_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Designation"><ItemTemplate>
<asp:DropDownList id="ddlDesig" runat="server" AutoPostBack="true"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remark"><ItemTemplate>
<asp:TextBox id="txtRemark" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AddRow">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Width="32px" BackColor="LightSteelBlue" ForeColor="Black" Font-Bold="False" Text="Add" Height="23px" Font-Size="10pt" Font-Names="Verdana"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DeleteRow">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:Button id="btnDel" onclick="Button3_Click" runat="server" Width="51px" ForeColor="Black" Font-Bold="False" Text="Delete" Height="23px" Font-Size="10pt" Font-Names="Verdana" BackColor="LightSteelBlue"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD colSpan=1></TD></TR><TR><TD style="HEIGHT: 24px" align=center colSpan=4><asp:Button id="Button2" onclick="btnSave1_Click" runat="server" Width="74px" Text="Save" Font-Size="10pt" Font-Names="Verdana"></asp:Button> </TD></TR><%--<tr>
        <td align="left" colspan="3" style="height: 24px">
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="10pt"
                NavigateUrl="TA.aspx">Back</asp:HyperLink></td>
        <td align="right" colspan="1" style="height: 24px">
        </td>
    </tr>--%></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 427px; HEIGHT: 25px"><asp:HyperLink id="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana" NavigateUrl="TA.aspx">Back</asp:HyperLink></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
//Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+0",
      });
//              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});

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

