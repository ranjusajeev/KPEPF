<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="AnnualLedgerRpt.aspx.cs" Inherits="Contents_AnnualLedgerRpt" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE ><TBODY><TR><TD class="TdMnHead" style="width:900px">&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Annual Report_KPEPF" ></asp:Label> </TD></TR>
<tr><td>&nbsp;</td></tr>
<TR align="center"><TD><asp:Label id="Year" runat="server"  Text="Year" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYear" runat="server"  OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList></TD></TR>
                         <tr ><td align="center" colspan="2">
    <asp:Label ID="lblShow1" runat="server"  Width="999px"></asp:Label>
    </td></tr>
                           <tr style="width:999px"><td align="center" colspan="2">
    <asp:Label ID="lblShow2" runat="server"  Width="999px"></asp:Label>
    </td></tr>
                           <tr style="width:999px"><td align="center" colspan="2">
    <asp:Label ID="lblShow3" runat="server"  Width="999px"></asp:Label>
    </td></tr>
                           <tr style="width:999px"><td align="center" colspan="2">
    <asp:Label ID="lblShow4" runat="server"  Width="999px"></asp:Label>
    </td></tr>
                           <tr style="width:999px"><td align="center" colspan="2">
    <asp:Label ID="lblShow5" runat="server"  Width="999px"></asp:Label>
                           <tr style="width:999px"><td align="center" colspan="2">
    <asp:Label ID="lblShow6" runat="server"  Width="999px"></asp:Label>
    </td></tr>
    </td></tr>
                        </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>       
</asp:Content>

