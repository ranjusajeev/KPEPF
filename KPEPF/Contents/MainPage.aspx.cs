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

public partial class Contents_MainPage : System.Web.UI.Page
{
    //EmployeeDAO empl = new EmployeeDAO();
    //clsGlobalMethods gbl = new clsGlobalMethods();
    //GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        //FillConsolidation();
        //FillInboxCnt();

    }
    private void FillInboxCnt()
    {
        //DataSet dsI = new DataSet();
        //ArrayList arr = new ArrayList();
        //arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        //arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //arr.Add(Convert.ToInt32(Session["intUserId"]));
        //dsI = gen.FindCount(arr);
        //gdvCnt.DataSource = dsI;
        //gdvCnt.DataBind();
        //for (int i = 0; i < gdvCnt.Rows.Count; i++)
        //{
        //    GridViewRow gdv = gdvCnt.Rows[i];
        //    if (Convert.ToInt16(dsI.Tables[0].Rows[i].ItemArray[3]) > 0)
        //    {
        //        gdv.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //gbl.SetFooterTotals(gdvCnt, 2);
    }
    private void FillConsolidation()
    {
        //DataSet dsEmp = new DataSet();
        //dsEmp = empl.GetEmployee();
        //gdvEmp.DataSource = dsEmp;
        //gdvEmp.DataBind();
        //gbl.SetFooterTotals(gdvEmp, 2);
        //gbl.SetFooterTotals(gdvEmp, 3);
        //gbl.SetFooterTotals(gdvEmp, 4);

        
    }

}
