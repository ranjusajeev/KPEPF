
<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_View, App_Web_vxnq-4wi" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server" >
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<table border=0 width=100%>
<tr><td colspan="4" class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="View a file"></asp:Label></TD></TR>

<tr>
            <td align="center" style="background-color: #ccd0e6; width: 1118px;" >
                <asp:RadioButtonList ID="rdView" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    Font-Size="10pt" ForeColor="Navy" 
                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdView_SelectedIndexChanged" Enabled="False" Visible="False" >
                    <asp:ListItem Selected="True">File No.</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                </asp:RadioButtonList>
                
<%--                <asp:RadioButtonList ID="rdPrint" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    Font-Size="10pt" ForeColor="Navy" 
                    RepeatDirection="Horizontal" Visible="false" OnSelectedIndexChanged="rdPrint_SelectedIndexChanged" >
                    <asp:ListItem Selected="True">File No.</asp:ListItem>
                    <asp:ListItem>Sanction Order No.</asp:ListItem>
                </asp:RadioButtonList>--%>
                
                <asp:Label id="lbl6" runat="server" CssClass="p3" Text="File No." ></asp:Label>
                <asp:TextBox id="txtFile" runat="server" MaxLength="20" ></asp:TextBox>
                <asp:TextBox id="txtEmpId" runat="server" MaxLength="20"  Visible="false"></asp:TextBox>
                <asp:TextBox id="txtEmpName" runat="server" MaxLength="20" Visible="false"></asp:TextBox>
                <asp:Button id="btnFind" onclick="btnFind_Click" runat="server" Text="Find" Font-Names="Verdana" ForeColor="#0000C0" Width="75px"></asp:Button>&nbsp;
            </td>
        </tr>
    <tr>
        <td style="width: 1300px" align="center">
        <asp:GridView id="gdvFile" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<Columns>
                
                <asp:HyperLinkField DataNavigateUrlFields="intTrnTypeID,numTrnID,flgApproval,numEmpId" DataNavigateUrlFormatString="aa.aspx?intTrnTypeID={0}&amp;numTrnID={1}&amp;flgApproval={2}&amp;numEmpId={3}"
                DataTextField="chvTrnType" HeaderText="Transaction type" />
            <asp:BoundField DataField="AccNo" HeaderText="AccountNo">
            <HeaderStyle HorizontalAlign="Center"/>
            <ItemStyle HorizontalAlign="Left" Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="chvName" HeaderText="Name">
            <HeaderStyle HorizontalAlign="Center"/>
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="chvStatus" HeaderText="Status ">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
<%--            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="."></asp:Label>
            </EmptyDataTemplate>--%>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>


<asp:GridView id="gdvEmp" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<Columns>
            <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
            <asp:BoundField DataField="chvPF_No" HeaderText="AccountNo">
            <HeaderStyle HorizontalAlign="Center"/>
            <ItemStyle HorizontalAlign="Left" Width="85px" />
            </asp:BoundField>
            <asp:BoundField DataField="chvName" HeaderText="Name">
            <HeaderStyle HorizontalAlign="Center"/>
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="chvEngDistName" HeaderText="Joining District ">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="chvLBNameEnglish" HeaderText="Joining Localbody" />
            <asp:BoundField HeaderText="Current District" />
            <asp:BoundField HeaderText="Current Localbody" />
        </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="."></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>
          </td>
    </tr>
    
</table>
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
                yearRange: "-30:+0",
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
   function ReportDet()
    {
        var strlink;
        strlink="../Contents/Reports.aspx?rptName=TASanctionOrder.rpt&noParams=0";
        window.open(strlink,"TASanctionOrder","status=no,toolbar=no,menubar=no,scrollbars=yes,fullscreen=no,left=0,top=0,height=555,width=796,resizable=yes");
    }


	</script>
    	</asp:Content>
