<%@ page language="C#" autoeventwireup="true" inherits="Contents_About, App_Web_d0bqo0ey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 379px; height: 286px; background-color: #e9f8de;">
            <tr>
                <td style="width: 115px; height: 228px">
                    <asp:Panel ID="Panel1" runat="server" Height="277px" Style="z-index: 100; left: 16px;
                        position: absolute; top: 18px" Width="366px">
                        <table style="width: 361px; height: 175px">
                            <tr>
                                <td style="width: 103px; height: 61px; background-color: #e9f8de;">
                                    <asp:Panel ID="Panel2" runat="server" BackColor="#9AAD42" Height="51px" Style="z-index: 100;
                                        left: 3px; position: absolute; top: 10px" Width="353px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Large"
                                            Height="36px" Style="z-index: 100; left: 116px; position: absolute; top: 9px"
                                            Text="K P E P F " Width="134px" ForeColor="DarkGreen"></asp:Label>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 103px; height: 65px; background-color: #e9f8de;">
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Names="Arial" Font-Size="Small"
                                        ForeColor="DarkGreen" Height="46px" Style="z-index: 100; left: 50px; position: absolute;
                                        top: 78px" Text="Content Owned, Maintained and Updated By: Grama Panchayats,DDPs and Directorate of Panchayats"
                                        Width="306px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 103px; height: 87px; background-color: #e9f8de;">
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="66px" ImageUrl="~/images/ikmemblem.gif"
                                        Width="45px" />
                                    <asp:Label ID="Label3" runat="server" Font-Italic="True" ForeColor="DarkGreen" Height="85px"
                                        Style="z-index: 100; left: 52px; position: absolute; top: 141px" Text="Software Design, Development and Hosting Services By: Information Kerala Mission. Network Services by State e-Governance Data Center"
                                        Width="305px" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 103px; height: 1px; background-color: #e9f8de;" align="right">
                                    <asp:Button ID="Button1" runat="server" Text="Close" style="z-index: 100; left: 305px; position: absolute; top: 223px" OnClientclick="javascript:window.close();" OnClick="Button1_Click1" BackColor="#E9F8DE" ForeColor="DarkGreen" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

