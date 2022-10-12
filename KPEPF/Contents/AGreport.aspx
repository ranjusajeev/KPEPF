<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="AGreport.aspx.cs" Inherits="Contents_AGreport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" runat="server" Text="Report To AG" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR align=center colSpan="2"><TD><asp:RadioButtonList id="rdbType" runat="server" CssClass="p1" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbType_SelectedIndexChanged"><asp:ListItem Selected="True">Remittance</asp:ListItem>
<asp:ListItem>Withdrawal</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR align=center><TD><asp:Label id="lblYear" runat="server" Text="Year" CssClass="p1"> </asp:Label>&nbsp; <asp:DropDownList id="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblMonth" runat="server" Text="Month" CssClass="p1"></asp:Label> &nbsp; <asp:DropDownList id="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
        </asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 90%" align=center colSpan=2>
           
             <DIV style="OVERFLOW-X: auto; WIDTH: 900px"> 
            <asp:GridView id="gdvReport" Width="1200px" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Width="22px" Text="Label" __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Dist. Treasury">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Treasury" HeaderText="Sub Treaasury" Visible="False">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BookedAmount" HeaderText="Booked Amt.">
<ItemStyle HorizontalAlign="Right" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmReceiptDate" HeaderText="Chalan Details">
<ItemStyle HorizontalAlign="Left" Width="170px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Remitted By"><ItemTemplate>
<asp:DropDownList id="ddlRemBy" runat="server" Width="90px" __designer:wfdid="w2">
        </asp:DropDownList> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="12px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="In Favour of"><ItemTemplate>
<asp:TextBox id="txtInFvr" runat="server" Width="100px" __designer:wfdid="w3" MaxLength="200"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="GPF Ac/no"><ItemTemplate>
<asp:TextBox id="txtGPFac" runat="server" Width="100px" __designer:wfdid="w6" MaxLength="200"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Correct H/AC"><ItemTemplate>
<asp:TextBox id="txtCrtHAc" runat="server" Width="100px" __designer:wfdid="w5" MaxLength="15"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="From month of"><ItemTemplate>
        <asp:DropDownList id="ddlFrmMnth" runat="server" Width="79px">
        </asp:DropDownList>   
    
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Unposted" HeaderText="Wrongly booked under KPEPF">
<ItemStyle HorizontalAlign="Right" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="MainId" Visible="False"><ItemTemplate>
<asp:Label id="lblMainId" runat="server" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Source" Visible="False"><ItemTemplate>
<asp:Label id="lblSource" runat="server" Text="Label" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV> </TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnSaveRT" onclick="btnSaveRT_Click" runat="server" Width="96px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> <asp:Button id="btnPrntRt" onclick="btnPrntRt_Click" runat="server" Width="94px" ForeColor="Navy" Text="Print" Font-Size="Small" Height="20px"></asp:Button>&nbsp; </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

