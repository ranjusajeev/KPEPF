<%@ control language="C#" autoeventwireup="true" inherits="Contents_Address, App_Web_ypdhnn_y" %>
<link href="../themes/styleL.css" rel="stylesheet" type="text/css"/>
<table >
<tr>

<td style="HEIGHT: 17px; width=500px; background-color: #ccd0e6;" align="center" colspan="4"><asp:Label runat="server" Text="Address of the Applicant" ID="lblAddr" class="p2"></asp:Label></td>

</tr>
<tr>
    <td style="width:40px; height: 26px;"><asp:Label runat="server" language="javascript"  Text="WardNo" ID="lblwardNo" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px; height: 26px;"><asp:TextBox runat="server" CssClass="txtNumeric" onkeypress="javascript:numericcheck();" TabIndex="3" ID="txtWardNo" Width="201px"></asp:TextBox></td>
    <td style="width:40px; height: 26px;"><asp:Label runat="server" Text="DoorNo" ID="lblDoorNo1" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px; height: 26px;"><asp:TextBox runat="server"  TabIndex="4" ID="txtDoorNo1" Width="201px"></asp:TextBox></td>
</tr>
<tr>
    <td style="width:40px"><asp:Label runat="server" Text="BuildingName" ID="lblBldg" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px"><asp:TextBox runat="server" TabIndex="5" ID="txtBldgNm" Width="201px"></asp:TextBox></td>
    <td style="width:40px; height: 26px;"><asp:Label runat="server" Text="LocalPlace" ID="lblSt" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px"><asp:TextBox runat="server" TabIndex="6" ID="txtLocalPlace"  Width="201px"></asp:TextBox></td>
</tr>
<tr>
    <td style="width:40px"><asp:Label runat="server" Text="MainPlace" ID="lblMP" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px"><asp:TextBox runat="server" TabIndex="7" ID="txtMainPlace" Width="201px"></asp:TextBox></td>
    <td style="width:40px; height: 26px;"><asp:Label runat="server" Text="Pincode"  ID="lblPin" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px"><asp:TextBox runat="server" TabIndex="8" CssClass="txtNumeric" ID="txtPincode" Width="201px"></asp:TextBox></td>
</tr>
<tr>
    <td style="width:40px"><asp:Label runat="server" Text="Postoffice" ID="lblPost" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px; HEIGHT: 26px"><asp:TextBox runat="server" TabIndex="10" ID="txtPostoffice" Width="201px"></asp:TextBox></td>
    <td style="width:40px; height: 26px;"><asp:Label runat="server" Text="District" ID="lblDist" class="p1"></asp:Label></td>
    <td style="WIDTH: 250px; HEIGHT: 26px"><asp:DropDownList runat="server" Width="208px" TabIndex="11" ID="ddlDist"></asp:DropDownList></td>
    <td><asp:Button ID="btnAddClose" runat="server" Text="Ok" OnClick="btnAddClose_Click" /></td>
</tr>
</table>

<script language="javascript" type="text/javascript">

function numericcheck()
    {
        if(document.activeElement.className == "txtNumeric")
        {
            if(((window.event.keyCode)<48 ) || ((window.event.keyCode)>57))
            {
                window.event.keyCode=0;
            }
        }
        if(document.activeElement.className == "txtNumericFloat")
        {
            if((((window.event.keyCode)<48 ) || ((window.event.keyCode)>57)) && ((window.event.keyCode)!=46))
            {
                window.event.keyCode=0;
            }
        }
    }
    
	</script>