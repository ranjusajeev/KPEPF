<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ABCD, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<table style="width: 100%">

<tr>

<td  colspan="3" class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" CssClass="MnHead" Text="ABCD Form D"></asp:Label>
            </td>
</tr>
<tr><td align="left" style="width: 683px; height: 64px;">
        <asp:Panel ID="pnlDetails" runat="server" style="width: 683px;" ><table style="width: 282px"><tr><td align="left" style="width: 75px" >
            <asp:Label ID="Label8" runat="server" Text="Year" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0" CssClass="p1"></asp:Label> </td><td align="left">
            <asp:DropDownList id="ddlyear"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"  ></asp:DropDownList>
            &nbsp; &nbsp; &nbsp; </td></tr><tr><td style="width: 75px; height: 22px">
            <asp:Label ID="Label9" runat="server" Text="Account No." Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0" CssClass="p1"></asp:Label></td><td style="height: 22px">
           <asp:TextBox ID="txtaccno" runat="server" OnTextChanged="txtaccno_TextChanged" AutoPostBack="True"></asp:TextBox></td><td style="width: 86px; height: 22px">
           <asp:Label ID="lblAcc" runat="server" Width="62px" ></asp:Label></td>  </tr></table>
        </asp:Panel>
</td> </tr> 
<tr><td align="left" style="height: 36px"  >
    <asp:Label ID="Label5" runat="server" Text="  1.Total amount at credit as per last credit card for the year " class="p1" ></asp:Label>
   </td> <td style="height: 36px; width: 160px;"><asp:TextBox id="txtttlCR"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtttlCR_TextChanged" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr><td align="left" style="height: 22px"  >
    <asp:Label ID="Label1" runat="server" Text="  2.Total amount credited to P.F.a/c.after last credit card(Total of A & B above)" class="p1" ></asp:Label>
   </td> <td style="width: 160px"><asp:TextBox id="txtttlAB"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr><td align="left" style="height: 22px"  >
    <asp:Label ID="Label2" runat="server" Text="  3.Grand Total (Items 1+2 above)" class="p1" ></asp:Label>
   </td> <td style="width: 160px"><asp:TextBox id="txtttl12"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr><td align="left" style="height: 22px"  >
    <asp:Label ID="Label3" runat="server" Text="  4. Total amount of advance drawn after the issuance of the last credit card(vide details furnished under C above)" class="p1" ></asp:Label>
   </td> <td style="width: 160px"><asp:TextBox id="txtttlwith"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr><td align="left" style="height: 32px"  >
    <asp:Label ID="Label4" runat="server" Text="  5. Total amount od D.A arrears and Pay Revision arrears if any not due for withdrawal as per existing Government Orders" class="p1" ></asp:Label>
   </td> 
</tr>
<tr><td align="left" style="height: 32px"  >
  <asp:GridView id="gdvArrear" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnSelectedIndexChanged="gdvArrear_SelectedIndexChanged"  >
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
    <asp:TemplateField HeaderText="Month">
        <ItemTemplate>
            <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Arrear GO">
        <ItemTemplate>
            <asp:DropDownList ID="ddlGO" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="GO Date">
        <ItemTemplate>
            <asp:TextBox ID="txtGodate" runat="server" CssClass="datePicker" AutoPostBack="True"></asp:TextBox>
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Arrear Amount">
        <ItemTemplate>
            <asp:TextBox ID="txtarrAmt" runat="server" OnTextChanged="txtarrAmt_TextChanged" AutoPostBack="True"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtTotArrPf" runat="server"></asp:TextBox>
        </FooterTemplate>
        <HeaderStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Add"><ItemTemplate>
    <asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="Add Row"></asp:Button> 
    </ItemTemplate>
</asp:TemplateField>
</Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>
</td>
<td style="width: 160px"><asp:TextBox id="txtArDAttl"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>
</tr>
<tr><td align="left" style="height: 22px"  >
    <asp:Label ID="Label6" runat="server" Text="  6. Grand total (Items 4 + 5 above)" class="p1" ></asp:Label>
   </td> <td style="width: 160px"><asp:TextBox id="txtgrndttl"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr><td align="left" style="height: 22px"  >
    <asp:Label ID="Label7" runat="server" Text=" 7. Net balance at credit of the subscriber (3-6) on the date of application" class="p1" ></asp:Label>
   </td> <td style="width: 160px"><asp:TextBox id="txtnetBal"  tabIndex="4" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  MaxLength="5" AutoPostBack="True" CssClass="txtNumeric" ></asp:TextBox>&nbsp; &nbsp; &nbsp;
</td>

</tr>
<tr>

<td align="center" colspan="3" style=" width: 1027px; height: 7px;" >
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="90px" />
    <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click" Width="71px" /></td>
</tr>
<tr>
                    <td style="width: 427px; height: 25px">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Verdana"
                            Font-Size="10pt" NavigateUrl="TA.aspx">Back</asp:HyperLink></td>
                    <td style="width: 160px; height: 25px">

</tr>
</table> 
</asp:Content>

