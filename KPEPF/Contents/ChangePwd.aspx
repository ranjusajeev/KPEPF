<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Contents_ChangePwd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<table style="width: 100%">

<tr>

<td align="center" colspan="3" style="background-color: #ccd0e6;" >
                <asp:Label ID="lblHead" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                    ForeColor="Navy" Text="Change Password"></asp:Label>
            </td>
</tr>
<tr><td style="width: 1053px">
    <asp:Panel ID="pnlChange" runat="server" Width="75%" Visible="true"> 
    <table width="100%">
        <tr>
        <td align="left">
            <asp:Label ID="Label1" runat="server" Text="District" Width="52px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlDist"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label2" runat="server" Text="Institution Type" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlInstType"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstType_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label3" runat="server" Text="Institution" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlInst"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
         <tr>
        <td align="left">
            <asp:Label ID="Label4" runat="server" Text="User Type" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlUserType"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label5" runat="server" Text="Full Name" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtFullName"  tabIndex="4" runat="server"   MaxLength="50" Width="238px"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label6" runat="server" Text="Designation" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlDesig"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDesig_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label7" runat="server" Text="User Name" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtUser"  tabIndex="4" runat="server"   MaxLength="50" Width="238px"  ></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
        <td align="left">
            <asp:Label ID="Label8" runat="server" Text="Old Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtOldPwd"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label9" runat="server" Text="New Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtNewPwd"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
        <td align="left" style="height: 22px">
            <asp:Label ID="Label10" runat="server" Text="Confirm Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right" style="height: 22px">
            <asp:TextBox id="txtConPwd"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
            
        </tr>
        <tr><td colspan="2" align ="right">
            <asp:Button ID="btnOk" runat="server" Text="Update" OnClick="btnOk_Click" Width="112px" />
        </td></tr>
    </table>
    </asp:Panel>
    
    
    
    <asp:Panel ID="pnlDisableUser" runat="server" Width="75%" Visible="false"> 
    <table width="100%">
        <tr>
        <td align="left">
            <asp:Label ID="Label11" runat="server" Text="District" Width="52px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlDist1"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDist1_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label12" runat="server" Text="Institution Type" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlInstType1"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstType1_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label13" runat="server" Text="Institution" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlInst1"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInst1_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
         <tr>
        <td align="left">
            <asp:Label ID="Label14" runat="server" Text="User Type" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="ddlUserType1"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserType1_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label15" runat="server" Text="Full Name" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtFullName1"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" ReadOnly="True"  ></asp:TextBox>
            </td>
        </tr>
        
<%--        <tr>
        <td align="left">
            <asp:Label ID="Label16" runat="server" Text="Designation" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:DropDownList id="DropDownList5"  tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDesig_SelectedIndexChanged" Width="244px" ></asp:DropDownList>
            </td>
        </tr>--%>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label17" runat="server" Text="User Name" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="txtUser1"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" ReadOnly="True"  ></asp:TextBox>
            </td>
        </tr>
        
        
       <%-- <tr>
        <td align="left">
            <asp:Label ID="Label18" runat="server" Text="Old Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="TextBox3"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
        <td align="left">
            <asp:Label ID="Label19" runat="server" Text="New Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right">
            <asp:TextBox id="TextBox4"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
        <td align="left" style="height: 22px">
            <asp:Label ID="Label20" runat="server" Text="Confirm Password" Width="133px" Font-Names="Verdana" Font-Size="10pt" ForeColor="#0000C0"></asp:Label> 
            </td>
            
        <td align="right" style="height: 22px">
            <asp:TextBox id="TextBox5"  tabIndex="4" runat="server"   MaxLength="50" Width="238px" TextMode="Password"  ></asp:TextBox>
            </td>
            
        </tr>--%>
        <tr><td colspan="2" align ="right">
            <asp:Button ID="btnOk1" runat="server" Text="Disable" OnClick="btnOk1_Click" Width="112px" />
        </td></tr>
    </table>
    </asp:Panel>
    
    
</td></tr>
</table>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

