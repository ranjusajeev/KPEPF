
<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Contents_View" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server" >
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="View a file"></asp:Label></TD></TR><TR><TD align=center>&nbsp;<asp:Label id="lbl6" runat="server" Text="File No." CssClass="p3"></asp:Label> <asp:TextBox id="txtFile" runat="server" MaxLength="20"></asp:TextBox> <asp:TextBox id="txtEmpId" runat="server" Visible="false" MaxLength="20"></asp:TextBox> <asp:TextBox id="txtEmpName" runat="server" Visible="false" MaxLength="20"></asp:TextBox> <asp:Button id="btnFind" onclick="btnFind_Click" runat="server" Width="75px" ForeColor="#0000C0" Text="Find" Font-Names="Verdana"></asp:Button>&nbsp; </TD></TR><TR><TD></TD></TR><TR><TD style="WIDTH: 1300px" align=center><asp:GridView id="gdvFile" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
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
</asp:GridView> <asp:GridView id="gdvEmp" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
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
--%>    	</asp:Content>
