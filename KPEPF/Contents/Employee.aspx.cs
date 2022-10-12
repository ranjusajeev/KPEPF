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

public partial class Contents_Employee : System.Web.UI.Page
{
    EmployeeDAO empl = new EmployeeDAO();
    clsGlobalMethods gbl = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillConsolidation();
        }
    }
    protected void rbtDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtDist.Items[1].Selected == true)
        {
            if (rbtDist.Items[1].Selected == true)
            {
                DataSet ds = new DataSet();
                ds = gen.GetDistrict();
                gbl.FillCombo(ddlDistrict, ds, 1);
                pnlEmp.Visible = true;
                FillEmpDist();
            }
            
            pnlEmp.Visible = true;
            pnlEmpDist.Visible = true;
            pnlEmpGrid.Visible = false;
            lblCnt.Visible = true;
        }
        else
        {
            pnlEmpGrid.Visible = true;
            pnlEmpDist.Visible = false;
            FillConsolidation();
            lblCnt.Visible = false;
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtDist.Items[1].Selected == true)
        {
            pnlEmp.Visible = true;
            FillEmpDist();
        }
    }
    private void FillConsolidation()
    {
        DataSet dsEmp = new DataSet();
        dsEmp = empl.GetEmployee();
        pnlEmp.Visible = false;
        gdvEmp.DataSource = dsEmp;
        gdvEmp.DataBind();
        gbl.SetFooterTotals(gdvEmp, 2);
        gbl.SetFooterTotals(gdvEmp, 3);
        gbl.SetFooterTotals(gdvEmp, 4);
    }
    private void FillEmpDist()
    {
        DataSet dsEmpDt = new DataSet();
        ArrayList arryIn = new ArrayList();
        arryIn.Add(ddlDistrict.SelectedValue);
        dsEmpDt = empl.GetEmployeeDist(arryIn);
        gdvEmpDist.DataSource = dsEmpDt;
        gdvEmpDist.DataBind();
        lblCnt.Text = dsEmpDt.Tables[0].Rows.Count.ToString();
    }
    protected void gdvEmpDist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvEmpDist.PageIndex = e.NewPageIndex;
        FillEmpDist();
        lblPgNo.Visible = true;
        lblPgNo.Text = gdvEmpDist.PageIndex+1 + " of " + gdvEmpDist.PageCount;
    }
}
