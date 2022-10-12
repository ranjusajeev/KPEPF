<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ConsolidatRpt.aspx.cs" Inherits="Contents_ConsolidatRpt" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
 <ContentTemplate>
<TABLE style="BACKGROUND: white" width="85%" border=0><TBODY><TR><TD class="TdMnHead" align=center colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawal Details"></asp:Label> </TD></TR><TR><TD></TD></TR><TR><TD colSpan=2 align="center"><asp:RadioButtonList id="rdCategory" runat="server" RepeatDirection="Horizontal" CssClass="p1" OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True">TA </asp:ListItem>
<asp:ListItem>NRA </asp:ListItem>
<asp:ListItem>Closure </asp:ListItem>
<asp:ListItem>To GPF </asp:ListItem>
<asp:ListItem>To KPEPF </asp:ListItem>
    <asp:ListItem>Acc. Details </asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD></TD></TR><TR><TD align=center><asp:Label id="lblyr" class="p1" runat="server" Text="Year"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYear" runat="server" Width="181px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD align=center><asp:Label id="lblm" class="p1" runat="server" Text="Month"></asp:Label><asp:DropDownList id="ddlMonth" runat="server" Width="181px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
    <caption>
        &nbsp;&nbsp;&nbsp;
    </caption>
    </TR><TR><TD align=center><asp:Label id="lblAmt" class="p4" runat="server" Text="..."></asp:Label></TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvChalan" runat="server" Width="300px" ForeColor="#333333" Visible="False" CellSpacing="5" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No.">
<ItemStyle HorizontalAlign="Left" Width="10px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Cnt" HeaderText="Count">
<ItemStyle Width="20px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ttlAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 

<asp:GridView id="gdvClosure" runat="server" Width="300px" ForeColor="#333333" Visible="False" CellSpacing="5" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<ItemStyle HorizontalAlign="Left" Width="10px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cnt" HeaderText="Count">
<ItemStyle Width="20px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

<asp:GridView id="gdvAcc" runat="server" Width="300px" ForeColor="#333333" Visible="False" CellSpacing="5" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year">
    <ControlStyle Width="100px" />
<ItemStyle HorizontalAlign="Left" Width="40px"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="Count">

       <ItemTemplate>
            <asp:Label ID="lblCnt" runat="server" Text="0"></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="20px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total">

        <ItemTemplate>
            <asp:Label ID="lblAmt" runat="server" Text="0"></asp:Label>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="50px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="YrID" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblYr" runat="server" Text="0"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
                                                                                                                    </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
