<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Sthapana, App_Web_sldhjcan" %>
<%@ Register Src="MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
      <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY></TBODY></TABLE><TABLE width="100%" border=0><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Sthapana Integration"></asp:Label></TD></TR></TBODY></TABLE><TABLE class="maintable" width="100%" border=0><TBODY><TR><TD align=center><asp:Label id="Label1" runat="server" Width="110px" Text="Search options" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="HEIGHT: 77px" align=center><TABLE><TBODY><TR><TD>&nbsp;<asp:Label id="Label2" runat="server" Text="No of employees:"></asp:Label></TD><TD><asp:Textbox id="txtCntEmp" runat="server" OnTextChanged="txtCntEmp_TextChanged" AutoPostBack="True"></asp:Textbox></TD><TD><asp:Label id="lblPndng" runat="server"></asp:Label></TD></TR><TR><TD>&nbsp;<asp:Label id="Label3" runat="server" Text="Correction type"></asp:Label> </TD><TD><asp:DropDownList id="ddlCorrType" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlCorrType_SelectedIndexChanged">
                                    <asp:ListItem Value="0">...</asp:ListItem>
                                    <asp:ListItem Value="1">AccNo</asp:ListItem>
                                    <asp:ListItem Value="2">Name</asp:ListItem>
            </asp:DropDownList> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE class="maintable" width="100%" border=0><TBODY><TR width="45%"><TD style="HEIGHT: 412px" vAlign=top align=right><asp:GridView id="gdvEmp" runat="server" ForeColor="Black" BackColor="White" GridLines="Vertical" CellPadding="3" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Sl.No." DataField="SlNo" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="chvPF_No" HeaderText="AccountNo.">
            <ItemStyle HorizontalAlign="Left" Width="85px" />
            <HeaderStyle HorizontalAlign="Center" />
            </asp:Boundfield>
            <asp:BoundField DataField="chvName" HeaderText="Name">
            <HeaderStyle HorizontalAlign="Center" Width="150px" />
            <ItemStyle HorizontalAlign="Left" Width="150px" />
                <ControlStyle Width="200px" />
                <FooterStyle Width="200px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Sthapana Id">
                <ItemTemplate>
                    <asp:TextBox ID="txtSthapId" runat="server" Width="60px"></asp:TextBox>&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EmpId" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numEmpId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("numEmpId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BorderColor="Green" BorderStyle="Solid" BorderWidth="1px" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView> <asp:Button id="btnUpd" onclick="btnUpd_Click" runat="server" Text="Update"></asp:Button> </TD><TD style="HEIGHT: 412px" vAlign=middle width="55%"><TABLE width="100%" border=0><%--<tr>
                                <td >
                                <asp:RadioButtonList ID="optSearch" runat="server"  OnSelectedIndexChanged="optSearch_SelectedIndexChanged"
        RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Selected="True" Value="1">Acc No.</asp:ListItem>
        <asp:ListItem Value="2">Name</asp:ListItem>
    </asp:RadioButtonList> <asp:TextBox ID="txtValue" runat="server"  CssClass="txtNumeric" MaxLength="5"></asp:TextBox>&nbsp;
                                <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click"  Text="Find"  /> 
                                </td>
                                <td> </td>
                                <td>  </td>
                            </tr> --%><TBODY><TR valign="top"><TD style="HEIGHT: 198px" ><asp:GridView id="gdvSearch" runat="server" Width="287px" Height="70px" ForeColor="Black" BackColor="White" GridLines="Vertical" CellPadding="3" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" AutoGenerateColumns="False" OnRowCreated="gdvSearch_RowCreated">
        <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="Acc No.">
                <ItemTemplate>
                    <asp:TextBox ID="txtAccNoP" runat="server" MaxLength="5" AutoPostBack="True" Width="78px" OnTextChanged="txtAccNoP_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    &nbsp;
                    <asp:Label ID="txtNameP" runat="server" Text="" Width="139px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AccountNo.">
                <ItemTemplate>
                    &nbsp;<asp:Label ID="lblAccNoS" runat="server" Text="" Width="66px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblNameS" runat="server" Text="" Width="133px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sthapana Id">
                <ItemTemplate>
                    <asp:TextBox ID="txtIdS" runat="server" MaxLength="3" Width="49px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Add">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click">Click</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                             <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView> </TD><TD style="HEIGHT: 198px"><asp:GridView id="gdvSearchName" runat="server" Width="287px" Height="70px" ForeColor="Black" BackColor="White" GridLines="Vertical" CellPadding="3" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" AutoGenerateColumns="False" OnRowCreated="gdvSearchName_RowCreated" Visible="False">
        <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtNameP2" runat="server" MaxLength="15" AutoPostBack="True" Width="133px" OnTextChanged="txtNameP2_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AccountNo.">
                <ItemTemplate>
                    &nbsp;
                    <asp:Label ID="lblAccNoP2" runat="server" Text="" Width="73px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    &nbsp;<asp:Label ID="lblNameS2" runat="server" Text="" Width="126px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acc No.">
                <ItemTemplate>
                    <asp:Label ID="lblAccNoS2" runat="server" Text="" Width="84px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sthapana Id">
                <ItemTemplate>
                    <asp:TextBox ID="txtIdS2" runat="server" MaxLength="3" Width="49px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Add">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAdd2" runat="server" OnClick="lnkAdd2_Click">Click</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                             <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView> </TD></TR><TR><TD><uc2:MsgBox id="MsgBox1" runat="server" Visible="false"></uc2:MsgBox> </TD></TR></TBODY></TABLE></TD></TR><TR><TD align=right></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>
