<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RecReports.aspx.cs" Inherits="Contents_RecReports" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="BORDER-LEFT-COLOR: #3399ff; BORDER-BOTTOM-COLOR: #3399ff; BORDER-TOP-STYLE: solid; BORDER-TOP-COLOR: #3399ff; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-RIGHT-COLOR: #3399ff; BORDER-BOTTOM-STYLE: solid" width="100%"><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Reconciliation Reports"></asp:Label></TD></TR><TR><TD style="HEIGHT: 38px" align=center><asp:RadioButtonList id="rdRpt" runat="server" CssClass="p1" OnSelectedIndexChanged="rdRpt_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Chalan_T</asp:ListItem>
<asp:ListItem Value="2">Chalan_A</asp:ListItem>
<asp:ListItem Value="3">Chalan_T_Cor</asp:ListItem>
<asp:ListItem Value="4">Chalan_A_Cor</asp:ListItem>
<asp:ListItem Value="5">Bill_T</asp:ListItem>
<asp:ListItem Value="6">Bill_A</asp:ListItem>
<asp:ListItem Value="7">Bill_T_Cor</asp:ListItem>
<asp:ListItem Value="8">Bill_A_Cor</asp:ListItem>
<asp:ListItem Value="9">OB Corr.</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD></TD></TR><TR><TD style="WIDTH: 950px; HEIGHT: 70px" align=left><asp:Panel id="pnl1" runat="server" Width="900px" BorderColor="White"><TABLE width="100%"><TBODY><TR><TD><asp:Label id="Label1" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn1" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn1" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD>&nbsp;</TD><TD><asp:Label id="Label4" runat="server" Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrictn1" tabIndex=6 runat="server" Width="100px" OnSelectedIndexChanged="ddlDistrictn1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label3" runat="server" Width="80px" Text="Treasury" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlTreasn1" tabIndex=6 runat="server" Width="100px" OnSelectedIndexChanged="ddlTreasn1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD><asp:RadioButtonList id="rdCategory" runat="server" CssClass="p1" OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Bfr 4</asp:ListItem>
<asp:ListItem Value="2">Aftr 4</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 4px">&nbsp;</TD><TD style="WIDTH: 4px">&nbsp; </TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl2" runat="server" Width="900px" BorderColor="White" Visible="False" BackColor="White"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 38px"><asp:Label id="Label5ar" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn2" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Label62" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn2" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"><asp:RadioButtonList id="rdCategoryA" runat="server" CssClass="p1" OnSelectedIndexChanged="rdCategoryA_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Bfr 4</asp:ListItem>
<asp:ListItem Value="2">Aftr 4</asp:ListItem>
</asp:RadioButtonList></TD><TD style="HEIGHT: 38px"></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl3" runat="server" Width="900px" BorderColor="White" Visible="False"><TABLE width="100%"><TBODY><TR><TD><asp:Label id="Label13" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn3" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label23" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn3" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD>&nbsp;</TD><TD><asp:Label id="Label43" runat="server" Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrictn3" tabIndex=6 runat="server" Width="100px" OnSelectedIndexChanged="ddlDistrictn3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label33" runat="server" Width="80px" Text="Treasury" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlTreasn3" tabIndex=6 runat="server" Width="100px" OnSelectedIndexChanged="ddlTreasn3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"><asp:RadioButtonList id="rdCategory3" runat="server" CssClass="p1" AutoPostBack="True" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">Bfr 4</asp:ListItem>
<asp:ListItem Value="2">Aftr 4</asp:ListItem>
</asp:RadioButtonList></TD><TD></TD><TD style="WIDTH: 4px">&nbsp;</TD><TD>&nbsp; </TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl4" runat="server" Width="900px" BorderColor="White" Visible="False"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 22px"><asp:Label id="Label5w" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn4" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn4_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 22px"><asp:Label id="Label64" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn4" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn4_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl5" runat="server" Width="900px" BorderColor="White" Visible="False"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 38px"><asp:Label id="Label5cc" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn5" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn5_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Label65" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn5" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn5_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"><asp:Label id="Labe5cc" runat="server" Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrictn5" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlDistrictn5_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Labelcc" runat="server" Text="Treasury" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlTreasn5" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlTreasn5_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl6" runat="server" Width="900px" BorderColor="White" Visible="False" BackColor="White"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 38px"><asp:Label id="Label5arc" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn6" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn6_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Label62a" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn6" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn6_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"></TD><TD style="HEIGHT: 38px"></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl7" runat="server" Width="900px" BorderColor="White" Visible="False"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 38px"><asp:Label id="Label5cc7" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn7" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn7_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Label67" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn7" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn7_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"><asp:Label id="Labe5cc7" runat="server" Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrictn7" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlDistrictn7_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Labelcc7" runat="server" Text="Treasury" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlTreasn7" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlTreasn7_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnl8" runat="server" Width="900px" BorderColor="White" Visible="False" BackColor="White"><TABLE width="100%"><TBODY><TR align=center><TD style="HEIGHT: 38px"><asp:Label id="Label5arc8" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYearn8" tabIndex=4 runat="server" Width="80px" OnSelectedIndexChanged="ddlYearn8_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD style="HEIGHT: 38px"><asp:Label id="Label62a8" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonthn8" tabIndex=5 runat="server" Width="80px" OnSelectedIndexChanged="ddlMonthn8_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 38px"></TD><TD style="HEIGHT: 38px"></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Button id="btnShow" onclick="btnShow_Click" runat="server" Width="72px" Text="Print"></asp:Button> </TD></TR><TR><TD align=center><asp:Label id="lblShow" runat="server" Text="..."></asp:Label> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
