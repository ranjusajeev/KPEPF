<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MsgBox.ascx.cs" Inherits="Contents_MsgBox" %>
<table>
<%--<asp:Panel ID="pnlMsgBox" runat="server" BackColor="Aqua">--%>
<tr style="background-color:gray"><td colspan="2" align="center"><asp:Label runat="server" ID="lblMsgCtrl" class="p3" ForeColor="White" Font-Bold="true"></asp:Label></td></tr>
<tr align="center"><td>
<asp:Panel ID="Panel1" runat="server" BorderColor="DarkBlue" BorderStyle="Solid"
    Height="82px" Width="300px"  CssClass="p2" >
    <table>
    
    <tr align=center><td> <asp:Label ID="lblMsg" runat="server" CssClass="p2"></asp:Label></td></tr>
    <tr align=center><td>
    <asp:Panel ID="pnlSingle" runat="server" Visible="true">
    <tr align=center><td><asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" /></td></tr>
    </asp:Panel></td></tr>
    
    <tr align="center"><td>
   <asp:Panel ID="pnlYesNo" runat="server" Visible="False">
    <tr align=center><td>
    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
    </td>
    <td><asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" /></td>
    </tr>
    </asp:Panel>
    
    <asp:Panel ID="pnlOkCancel" runat="server" Visible="false">
    <tr align=center><td>
    <asp:Button ID="btnOk1" runat="server" Text="Ok" OnClick="btnOk1_Click" />
    </td>
    <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
    </tr>
    </asp:Panel></td></tr>
    
    </table></asp:Panel>    
</td></tr></table>