<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCardParti.aspx.cs" Inherits="Contents_CreditCardParti" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
        <table width="100%"> 
            <tbody>
                <tr>
                        <td class="TdMnHead" colspan="3">
                            <asp:Label ID="Label29" runat="server" Text="Statement of CreditCard Particulars" class="MnHead"></asp:Label>
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px; height: 25px">
                            <asp:Label ID="Label13" runat="server" Text="Employee Name" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 25px;">
                        <asp:Label ID="Label15" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                            <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                        <td style="height: 22px; width: 427px;">
                            <asp:Label ID="Label14" runat="server" Text="Current Office" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 22px;">
                        <asp:Label ID="Label16" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="height: 25px; width: 328px;">
                            <asp:TextBox ID="txtOffice" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label1" runat="server" Text="Balance Credited as per Credit Card " class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label17" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtBal" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">    
                                <asp:Label ID="Label2" runat="server" Text="Subscription and refund after last credit" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label18" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtSubRef" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label3" runat="server" Text="Total" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label19" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label4" runat="server" Text="Arrear D A not Admissible" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label20" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtArrearDA" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px; height: 22px">
                                <asp:Label ID="Label5" runat="server" Text="Temporary Advance after credit card" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 22px;">
                        <asp:Label ID="Label21" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtTA" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label6" runat="server" Text="Net Balance" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label22" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtBalance" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label7" runat="server" Text="Eligibility of T A" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label23" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtEligi" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px; height: 22px">
                                <asp:Label ID="Label8" runat="server" Text="Required loan" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 22px;">
                        <asp:Label ID="Label24" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtRequLoan" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="height: 22px; width: 427px;">
                                <asp:Label ID="Label9" runat="server" Text="Sanctioned Loan" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 22px;">
                        <asp:Label ID="Label25" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="height: 25px; width: 328px;">
                                <asp:TextBox ID="txtSanction" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px">
                                <asp:Label ID="Label10" runat="server" Text="Consolidated Amount" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px">
                        <asp:Label ID="Label26" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtConsol" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px; height: 22px">
                                <asp:Label ID="Label11" runat="server" Text="Recovered at" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 22px;">
                        <asp:Label ID="Label27" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtRecover" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                        <td style="width: 427px; height: 25px">
                                <asp:Label ID="Label12" runat="server" Text="Installments" class="p1"></asp:Label>
                        </td>
                    <td style="width: 60px; height: 25px;">
                        <asp:Label ID="Label28" runat="server" Text=":" class="p1"></asp:Label></td>
                        <td style="width: 328px; height: 25px">
                                <asp:TextBox ID="txtInstal" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>  
                        </td>
                </tr>
                <tr>
                <td colspan="2" align="right" >
                    <asp:Button ID="btnPrint" runat="server" Text="Print"  style="width:50px;" OnClick="btnPrint_Click" />
                </td>
                </tr>
                <tr>
                    <td style="width: 427px; height: 25px">
                    </td>
                    <td style="width: 60px; height: 25px">
                    </td>
                    <td style="width: 328px; height: 25px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 427px; height: 25px">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Verdana"
                            Font-Size="10pt" NavigateUrl="TA.aspx">Back</asp:HyperLink></td>
                    <td style="width: 60px; height: 25px">
                    </td>
                    <td style="width: 328px; height: 25px">
                    </td>
                </tr>
            </tbody>        
        </table>
</asp:Content>

