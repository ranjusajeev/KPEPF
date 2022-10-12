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
using KPEPFClassLibrary;

public partial class RemitanceConsolidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAccountingTrn();
        }
    }
    private void GetAccountingTrn()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt16(Session["intYearIdRemi"]));
    }
}
