<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchEmp.aspx.cs" Inherits="Contents_SearchEmp" %>--%>
<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="SearchEmp.aspx.cs" Inherits="Contents_SearchEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Search an Employee"></asp:Label></TD></TR><TR><TD style="WIDTH: 1118px; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=2><asp:RadioButtonList id="rdView" runat="server" ForeColor="Navy" OnSelectedIndexChanged="rdView_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" Font-Names="Verdana" Font-Size="10pt">
                    <asp:ListItem Selected="True">Account Number</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                </asp:RadioButtonList> </TD></TR><TR align=center><TD><asp:Label id="a" runat="server" ForeColor="Blue" Text="Account Number" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:TextBox id="txtValue" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="161px" MaxLength="5" CssClass="txtNumeric"></asp:TextBox> <asp:Button id="btnFind" onclick="btnFind_Click" runat="server" Width="49px" Text="Find"></asp:Button></TD></TR><TR align=center><TD><asp:Label id="b" runat="server" ForeColor="Blue" Text="Name of Employee" Font-Names="Verdana" Font-Size="10pt" Visible="False"></asp:Label> <asp:TextBox id="txtValue1" runat="server" MaxLength="20" Visible="false"></asp:TextBox> <asp:Button id="btnFind1" onclick="btnFind1_Click" runat="server" Width="50px" Text="Find" Visible="false"></asp:Button></TD></TR>
                
                <TR align=center><TD vAlign=top colSpan=2><asp:GridView id="gdvSearch" runat="server"  ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Height="70px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Account Number">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="85px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ControlStyle Width="111px"></ControlStyle>

<HeaderStyle HorizontalAlign="Center" Width="222px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="222px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DistJoin" HeaderText="Joining District ">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvLBNameJoin" HeaderText="Joining Localbody" Visible="False"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="Current District"></asp:BoundField>
<asp:BoundField DataField="chvLBNameEnglish" HeaderText="Current Localbody"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="BfrStatus" HeaderText="Joining Period"></asp:BoundField>
<asp:BoundField DataField="fltOB" HeaderText="Opening Balance"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--<script language="javascript" type="text/javascript">
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
--%>    	</asp:Content>