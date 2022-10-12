<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ReclCalc, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
    <TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation_Calculation" ></asp:Label> </TD></TR>
    <TR><TD align=center ><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Recl3New" Height="28px" Font-Size="Small"></asp:Button> </TD></TR>
    <TR><TD align=center ><asp:Button id="btnOk1" onclick="btnOK1_Click" runat="server" Width="70px" ForeColor="Navy" Text="Recl3 Cr" Height="28px" Font-Size="Small"></asp:Button> </TD></TR>
    
    <TR><TD align=center ><asp:Button id="btnOk2" onclick="btnOK2_Click" runat="server" Width="70px" ForeColor="Navy" Text="Recl3 Dt" Height="28px" Font-Size="Small"></asp:Button> </TD></TR>
    
    </TBODY></TABLE> 
    </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>

