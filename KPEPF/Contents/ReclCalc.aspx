<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ReclCalc.aspx.cs" Inherits="Contents_ReclCalc" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
    <TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation_Calculation" ></asp:Label> </TD></TR>
    
        <tr align="center">
            <td>
                 <asp:Button id="btnRefreshCr" onclick="btnRefreshCr_Click" runat="server" Width="100px" ForeColor="Navy" Text="Refresh" Height="28px" Font-Size="Small"></asp:Button>
          <asp:DropDownList id="ddlYear" runat="server" Width="80px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" style="height: 20px"></asp:DropDownList>

          <asp:Button id="btnCrT" onclick="btnCrT_Click" runat="server" Width="100px" ForeColor="Navy" Text="Credit" Height="28px" Font-Size="Small"></asp:Button>

            &nbsp;

          <asp:Button id="btnDtT" onclick="btnDtT_Click" runat="server" Width="100px" ForeColor="Navy" Text="Debit" Height="28px" Font-Size="Small"></asp:Button>
        </td>
            </tr>
        <%--<TR><TD align=center style="height: 30px" ><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="170px" ForeColor="Navy" Text="Recl3PDE" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        <asp:Button id="btnLat" onclick="btnLat_Click" runat="server" Width="170px" ForeColor="Navy" Text="ReclDTWiseCurrent" Height="28px" Font-Size="Small" Visible="False"></asp:Button> 
        </TD></TR>
    <TR><TD align=center style="height: 30px" ><asp:Button id="btnOk1" onclick="btnOK1_Click" runat="server" Width="170px" ForeColor="Navy" Text="ReclMthWisePDE Cr" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        <asp:Button id="btnCurrMthCr" onclick="btnCurrMthCr_Click" runat="server" Width="170px" ForeColor="Navy" Text="ReclMthWiseCurrent Cr" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        </TD></TR>--%>
    
    <%--<TR><TD align=center style="height: 30px" ><asp:Button id="btnOk2" onclick="btnOK2_Click" runat="server" Width="170px" ForeColor="Navy" Text="ReclMthWisePDE Dt" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        <asp:Button id="btnCurrMthDt" onclick="btnCurrMthDt_Click" runat="server" Width="170px" ForeColor="Navy" Text="ReclMthWiseCurrent Cr" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        </TD></TR>--%>

    <%--<tr>
        <td>
          <asp:Button id="btnRefreshCr" onclick="btnRefreshCr_Click" runat="server" Width="100px" ForeColor="Navy" Text="Refresh Cr" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        </td>
             <td>
          <asp:Button id="btnRefreshDt" onclick="btnRefreshDt_Click" runat="server" Width="100px" ForeColor="Navy" Text="Refresh Dt" Height="28px" Font-Size="Small" Visible="False"></asp:Button>
        </td>

         <td>
          <asp:DropDownList id="ddlYear" runat="server" Width="80px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" style="height: 20px"></asp:DropDownList>
        </td>


        <td>
          <asp:Button id="btnCrT" onclick="btnCrT_Click" runat="server" Width="100px" ForeColor="Navy" Text="Credit" Height="28px" Font-Size="Small"></asp:Button>
        </td>
        <td>
            &nbsp;</td>

        <td>
          <asp:Button id="btnDtT" onclick="btnDtT_Click" runat="server" Width="100px" ForeColor="Navy" Text="Debit" Height="28px" Font-Size="Small"></asp:Button>
        </td>
        <td>
            &nbsp;</td>
    </tr>--%>
    </TBODY></TABLE> 
    </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>

