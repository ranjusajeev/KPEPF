<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_SthapanaIntegration, App_Web_m1ijyhfm" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" runat="server" class="MnHead" Text="Sthapana_Integration"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 22px">&nbsp;<asp:Label id="Label3" runat="server" Text="Correction type" Visible="False"></asp:Label> </TD><TD style="HEIGHT: 22px"><asp:DropDownList id="ddlCorrType" runat="server" OnSelectedIndexChanged="ddlCorrType_SelectedIndexChanged" Enabled="False" AutoPostBack="True" Visible="False"><asp:ListItem Value="0">...</asp:ListItem>
<asp:ListItem Value="1">AccNo</asp:ListItem>
<asp:ListItem Value="2">Name</asp:ListItem>
</asp:DropDownList> </TD></TR><TR align=center><TD><asp:GridView id="gdvEmp" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" BackColor="White" AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Vertical" CellSpacing="5">
<FooterStyle BackColor="#CCCCCC"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="AccountNo.">
<ItemStyle Width="85px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ControlStyle Width="200px"></ControlStyle>

<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>

<FooterStyle Width="200px"></FooterStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Sthapana Id"><ItemTemplate>
<asp:TextBox id="txtSthapId" runat="server" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" Width="60px" __designer:wfdid="w3"></asp:TextBox>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EmpId"><EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numEmpId") %>'></asp:TextBox>
                
</EditItemTemplate>
<ItemTemplate>
                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("numEmpId") %>'></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Select">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                    <asp:CheckBox ID="chkSel" runat="server"  AutoPostBack="True" Width="50px" />
                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD><asp:GridView id="gdvSearch" runat="server" Width="287px" ForeColor="Black" Height="70px" BackColor="White" AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCreated="gdvSearch_RowCreated" Visible="False">
<FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNoP" runat="server" Width="78px" AutoPostBack="True" __designer:wfdid="w4" OnTextChanged="txtAccNoP_TextChanged" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                    &nbsp;
                    <asp:Label ID="txtNameP" runat="server" Text="" Width="139px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccountNo."><ItemTemplate>
                    &nbsp;<asp:Label ID="lblAccNoS" runat="server" Text="" Width="66px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                    <asp:Label ID="lblNameS" runat="server" Text="" Width="133px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sthapana Id"><ItemTemplate>
<asp:TextBox id="txtIdS" runat="server" Width="49px" __designer:wfdid="w5" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click">Click</asp:LinkButton>
                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>
</asp:GridView> </TD><TD><asp:GridView id="gdvSearchName" runat="server" Width="287px" ForeColor="Black" Height="70px" BackColor="White" AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCreated="gdvSearch_RowCreated" Visible="False">
<FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
                    <asp:TextBox ID="txtAccNoP" runat="server" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" AutoPostBack="True" Width="78px" OnTextChanged="txtAccNoP_TextChanged"></asp:TextBox>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                    &nbsp;
                    <asp:Label ID="txtNameP" runat="server" Text="" Width="139px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccountNo."><ItemTemplate>
                    &nbsp;<asp:Label ID="lblAccNoS" runat="server" Text="" Width="66px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
                    <asp:Label ID="lblNameS" runat="server" Text="" Width="133px"></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sthapana Id"><ItemTemplate>
                    <asp:TextBox ID="txtIdS" runat="server" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" Width="49px"></asp:TextBox>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click">Click</asp:LinkButton>
                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=3><asp:Button id="btnUpd" onclick="btnUpd_Click" runat="server" Width="89px" Text="Update"></asp:Button> </TD></TR></TBODY></TABLE>
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
//                yearRange: "-10:+0",
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

