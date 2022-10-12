using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Contents_aa : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numTrnID"]);
            gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
            Session["intTrnType"] = Convert.ToInt16(Request.QueryString["intTrnTypeID"]);
            Session["NumEmpId"] = Convert.ToInt16(Request.QueryString["numEmpId"]);
            if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 7)
            {
                Response.Redirect("SubnChange.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 5)
            {
                Response.Redirect("MembershipNomonation.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 2)
            {
                Response.Redirect("TA.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 3)
            {
                Response.Redirect("TA.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 31)
            {
                Response.Redirect("TA.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 4)
            {
                Response.Redirect("NRA.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 41)
            {
                Response.Redirect("NRA.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 6)
            {
                Response.Redirect("NomChg.aspx");
            }
            else if (Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 8)
            {
                Response.Redirect("TaNraConversion.aspx");
            }
        }
    }

}
