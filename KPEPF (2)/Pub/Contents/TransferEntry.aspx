<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_TransferEntry, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" runat="server" class="MnHead" Text="Transfer Entry" ></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 14px" align=center colSpan=2><asp:Panel id="pnlCrPlus" runat="server" Width="100%" Height="50px" Font-Size="12px" GroupingText="Credit Plus" HorizontalAlign="Center"><TR /><TD style="HEIGHT: 39px" align="center" /><asp:Panel id="pnlWithoutCP" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Without Document"><asp:Label id="lblAmtWOCP" runat="server" Text=""></asp:Label> <asp:GridView id="gdvCPWO" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" OnSelectedIndexChanged="gdvInboxNra_SelectedIndexChanged" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteCPWO" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChlnCPWO" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateCPWO" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPWO" runat="server" Width="115px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryCPWO" runat="server">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="LB">
        <ItemTemplate>
            <asp:DropDownList id="ddlLB" runat="server">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemCPWO" runat="server" Width="115px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="IntId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="Btnwithout" onclick="Btnwithout_Click" runat="server" Width="54px" Text="Add Row"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <TR /><TD align="center" /><asp:Button id="btnOkWithouDocs" onclick="btnOkWithouDocs_Click" runat="server" Text="OK"></asp:Button> </asp:Panel><TR /><TD /> <%-- <asp:Panel ID="pnlCPW" runat="server" Width="100%">--%><asp:Label id="lblAmtWCP" runat="server" Text=""></asp:Label> <TR /><TD /><asp:Panel id="pnlWithCP" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="With Document"><asp:GridView id="gdvCPW" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnSelectedIndexChanged="gdvCPW_SelectedIndexChanged" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeCPW" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
           <asp:TextBox ID="txtChNoCPW" runat="server"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
            <asp:TextBox ID="txtChlnDtCPW" runat="server"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amt"><ItemTemplate>
            <asp:TextBox ID="txtChlAmtCPW" runat="server"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
            <asp:DropDownList ID="ddlTreCPWO" runat="server">
            </asp:DropDownList>       
            
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist"><ItemTemplate>
         &nbsp;<asp:DropDownList ID="ddlDist" runat="server" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
         &nbsp;<asp:DropDownList ID="ddlLB" runat="server" OnSelectedIndexChanged="ddlLB_SelectedIndexChanged">
         </asp:DropDownList>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
        <asp:CheckBox ID="chkUnpostCPW" runat="server" />
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
            <asp:TextBox ID="txtRsnCPW" runat="server"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
         <asp:DropDownList ID="ddlStusCPW" runat="server">
         </asp:DropDownList> 
            
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
                         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Row" Width="54px" />
                     
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="InactiveCaptionText" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <TD align="center" /><asp:Button id="btnwithdocs" onclick="btnwithdocs_Click" runat="server" Text="OK"></asp:Button> </asp:Panel> &nbsp;<TR /><TD /> <asp:Panel id="pnlBTCP" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Balance Transfer"><asp:Label id="lblAmtBTCP" runat="server" Text=""></asp:Label> <asp:GridView id="gdvBT" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCPBT" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFrmAcCPBT" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Account"><ItemTemplate>
<asp:TextBox id="txtToaccCPBT" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCPBT" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRmkCPBT" runat="server" Width="115px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStutCPBT" runat="server">
        </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
                         <asp:Button ID="BtnBT" runat="server" OnClick="BtnBT_Click" Text="Add Row" Width="54px" />
                     
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:Button id="btnOkbal" onclick="btnOkbal_Click" runat="server" Text="OK"></asp:Button> </asp:Panel> &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <TR /><TD style="WIDTH: 983px; HEIGHT: 70px" align="center" /></asp:Panel> <asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD style="HEIGHT: 57px" align=center colSpan=2><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Button id="btnBckCP" onclick="btnBckCP_Click" runat="server" Width="100px" ForeColor="Navy" Text="Back" Height="28px" Font-Size="Small"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="btnSaveCP" onclick="btnOK_Click" runat="server" Width="96px" ForeColor="Navy" Text="Save" Height="28px" Font-Size="Small"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="btnSchCP" onclick="btnOK_Click" runat="server" Width="96px" ForeColor="Navy" Text="Schedule" Height="28px" Font-Size="Small"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="btnClsCP" onclick="btnClsCP_Click" runat="server" Width="94px" ForeColor="Navy" Text="Close" Height="28px" Font-Size="Small"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="btnPrintCP" onclick="btnOK_Click" runat="server" Width="94px" ForeColor="Navy" Text="Print" Height="28px" Font-Size="Small"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

