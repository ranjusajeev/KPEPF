<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CardGen, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
 <asp:Panel id="pnlBulkNew" runat="server" Visible="false" width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=3>&nbsp;</TD></TR><TR align=center><TD style="WIDTH: 100%" align=center colSpan=4>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnlPart" runat="server" Visible="true" BorderColor="#FFC0C0" BorderStyle="Solid" BorderWidth="1px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="Label1" class="MnHead" runat="server" Text="Partial Card Generation">
</asp:Label> </TD></TR><TR><TD></TD></TR><TR><TD style="HEIGHT: 22px" align=left><asp:Label id="Label2" runat="server" Width="166px" Text="Account No." CssClass="p1"></asp:Label> <asp:TextBox id="txtAccNoP" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="120px" CssClass="txtNumeric" OnTextChanged="txtAccNoP_TextChanged" MaxLength="5" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Label id="lblAccP" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblNameP" runat="server" Text="..." CssClass="p4" BackColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblDistP" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="Label32" runat="server" Width="164px" Text="Date of Retirement" CssClass="p1"></asp:Label> 
        <asp:TextBox id="txtDtR" tabIndex=4 runat="server" Width="121px" CssClass="datePicker1" OnTextChanged="txtDtR_TextChanged" MaxLength="10" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp; <asp:Button id="btnSaveDor" onclick="btnSaveDor_Click" runat="server" Width="84px" ForeColor="Blue" Font-Bold="True" Text="Save" Font-Names="Verdana" Font-Size="10pt" Enabled="True" Height="24px"></asp:Button> </TD></TR><TR><TD align=left><asp:Label id="Label112" runat="server" Width="168px" Text="Date of Closing" CssClass="p1"></asp:Label> <asp:TextBox id="txtDtClose" tabIndex=5 runat="server" Width="120px" CssClass="datePicker2" OnTextChanged="txtDtClose_TextChanged" MaxLength="10" AutoPostBack="True" Enabled="False"></asp:TextBox>&nbsp; <asp:Button id="btnGenP" onclick="btnGenP_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Generate" Font-Names="Verdana" Font-Size="10pt" Enabled="False" Height="21px"></asp:Button> <asp:Button id="btnCardP" onclick="btnCardP_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Credit Card" Font-Names="Verdana" Font-Size="10pt" Enabled="False"></asp:Button> <asp:Button id="btnLedgerP" onclick="btnLedgerP_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Ledger" Font-Names="Verdana" Font-Size="10pt" Enabled="False"></asp:Button> <asp:Button id="btnCorrP" onclick="btnCorrP_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Corr Report" Font-Names="Verdana" Font-Size="10pt" Enabled="False"></asp:Button> </TD></TR><TR><TD style="WIDTH: 472px">&nbsp;</TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCorr" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Year"><ItemTemplate>
<asp:TextBox id="txtYr" runat="server" Width="69px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chal Dt"><ItemTemplate>
<asp:TextBox id="txtchlDt" runat="server" Width="65px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAm" runat="server" Width="55px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Rt"><ItemTemplate>
<asp:TextBox id="txtRt" runat="server" Width="50px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Calc"><ItemTemplate>
<asp:TextBox id="txtcal" runat="server" Width="50px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intAmount"><ItemTemplate>
<asp:TextBox id="txtintamt" runat="server" Width="60px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total"><ItemTemplate>
<asp:TextBox id="txttotl" runat="server" Width="60px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MnthId"><ItemTemplate>
<asp:TextBox id="txtmnthId" runat="server" Width="58px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="BalMnth"><ItemTemplate>
<asp:TextBox id="txtbalmnth" runat="server" Width="53px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="YearId"><ItemTemplate>
<asp:TextBox id="txtyrId" runat="server" Width="57px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:TextBox id="txttype" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="HEIGHT: 14px"></TD></TR><TR><TD align=right><asp:Panel id="pnlCons" runat="server" Width="300px" Visible="False" BorderColor="#8080FF" BorderStyle="Solid"><TABLE><TBODY><TR><TD align=left><asp:Label id="Label3" runat="server" Text="OB" CssClass="p1"></asp:Label></TD><TD><asp:TextBox id="txtOb" runat="server" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Label4" runat="server" Text="Remittance" CssClass="p1"></asp:Label></TD><TD><asp:TextBox id="txtRem" runat="server" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Label6" runat="server" Text="Interest" CssClass="p1"></asp:Label></TD><TD><asp:TextBox id="txtInt" runat="server" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Label7" runat="server" Text="Total" CssClass="p1"></asp:Label></TD><TD><asp:TextBox id="txtTot" runat="server" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Label8" runat="server" Text="Withdrawals" CssClass="p1"></asp:Label></TD><TD><asp:TextBox id="txtWith" runat="server" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD  align=left><asp:Label id="Label9" runat="server" Text="CB" CssClass="p1"></asp:Label></TD><TD ><asp:TextBox id="txtCb" runat="server" ReadOnly="True"></asp:TextBox></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 215px" colSpan=2><DIV id="PDE" runat="server"><IFRAME id="iframePDE" frameBorder="1" width="100%" scrolling=auto runat="server"></IFRAME></DIV></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
    </asp:UpdatePanel>
<script language="javascript" type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
        $(".datePicker1").datepicker
                  ({
                      numberOfMonths: 1,
                      dateFormat: "dd/mm/yy",
                      changeMonth: true,
                      changeYear: true,
                      yearRange: "-56:+0",
                  });
        //    $( ".datePicker1" ).datepicker( "option", "showAnim", "explode");
    });
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
        $(".datePicker2").datepicker
                  ({
                      numberOfMonths: 1,
                      dateFormat: "dd/mm/yy",
                      changeMonth: true,
                      changeYear: true,
                      yearRange: "-56:+0",
                  });
        //  $( ".datePicker2" ).datepicker( "option", "showAnim", "explode");
    });
    /*Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()
    
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
       */
	</script>
</asp:Content>
