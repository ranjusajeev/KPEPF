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

public partial class Contents_AGreport : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    ChalanDAO chd = new ChalanDAO();
    WithdrawalPDEAGDAO wthd = new WithdrawalPDEAGDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettigs();
        }

    }
    private void Initialsettigs()
    {
        FillCombo();
        SetGridDefault();
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();

        ar.Add("chvTreasuryName");
        ar.Add("Treasury");
        ar.Add("BookedAmount");
        ar.Add("Unposted");
        ar.Add("dtmReceiptDate");
        //ar.Add("fltAmountTreasuryDt");

        //ar.Add("fltAmountAGDt");
        //ar.Add("fltAmountAGCr");
        gblobj.SetGridDefault(gdvReport, ar);
    }
    private void FillCombo()
    {
        DataSet ds = new DataSet();
        ds = genDAO.GetYearOnLineNdPDE();
        gblobj.FillCombo(ddlYear, ds, 1);

        DataSet ds1 = new DataSet();
        ds1 = gendao.GetMonth();
        gblobj.FillCombo(ddlMonth, ds1, 1);
    }
    private void Initialsettings()
    {
        FillCombo();
    }
    protected void btnSaveRT_Click(object sender, EventArgs e)
    {
        //SaveTb_ToAg
        
        for (int i = 0; i < gdvReport.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();

            GridViewRow gvr = gdvReport.Rows[i];
            Label lblSlNoAss = (Label)gvr.FindControl("lblSlNo");
            Label lblMainIdAss = (Label)gvr.FindControl("lblMainId");
            Label lblSourceAss = (Label)gvr.FindControl("lblSource");

            TextBox txtInFvrAss = (TextBox)gvr.FindControl("txtInFvr");
            TextBox txtGPFacAss = (TextBox)gvr.FindControl("txtGPFac");
            TextBox txtCrtHAcAss = (TextBox)gvr.FindControl("txtCrtHAc");

            DropDownList ddlFrmMnthAss = (DropDownList)gvr.FindControl("ddlFrmMnth");
            DropDownList ddlRemByAss = (DropDownList)gvr.FindControl("ddlRemBy");

            ar.Add(Convert.ToDouble(lblMainIdAss.Text));
            ar.Add(Convert.ToString(txtInFvrAss.Text));
            ar.Add(Convert.ToString(txtGPFacAss.Text));
            ar.Add(Convert.ToString(txtCrtHAcAss.Text));
            ar.Add(Convert.ToInt16(ddlFrmMnthAss.SelectedValue));
            if (rdbType.Items[0].Selected == true)
            {
                ar.Add(1);
            }
            else
            {
                ar.Add(2);
            }
            ar.Add(1);
            ar.Add(Convert.ToDouble(lblSourceAss.Text));
            ar.Add(Convert.ToInt16(ddlRemByAss.SelectedValue));
            chd.SaveTb_ToAg(ar);
        }
        gblobj.MsgBoxOk("Saved ", this);
        btnSaveRT.Enabled = false;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearAGRpt"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSaveRT.Enabled = true;
        if (ddlMonth.SelectedIndex > 0)
        {
            Session["intMonthAGRpt"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        if (Convert.ToInt16(Session["intYearAGRpt"]) > 0 && Convert.ToInt16(Session["intMonthAGRpt"]) > 0)
        {
            FillGrid();
        }
    }
    private void FillGrid()
    {
        SetGridDefault();
        
        DataSet dsAgR = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearAGRpt"]));
        ar.Add(Convert.ToInt16(Session["intMonthAGRpt"]));
        if (Convert.ToInt16(Session["intYearAGRpt"]) <= 49)
        {
            if (rdbType.Items[1].Selected == true)
            {
                dsAgR = wthd.GetAGRptW(ar, 1);
            }
            else
            {
                dsAgR = chd.GetAGRpt(ar,1);
            }
        }
        else
        {
            if (rdbType.Items[1].Selected == true)
            {
                dsAgR = wthd.GetAGRptW(ar, 2);
            }
            else
            {
                dsAgR = chd.GetAGRpt(ar,2);
            }
        }
        //if (rdbType.Items[1].Selected == true)
        //{
        //    dsAgR = wthd.GetAGRptW(ar);
        //}
        //else
        //{
        //    dsAgR = chd.GetAGRpt(ar);
        //}

        if (dsAgR.Tables[0].Rows.Count > 0)
        {
            gdvReport.DataSource = dsAgR;
            gdvReport.DataBind();
            FillDdls();
            for (int i = 0; i < gdvReport.Rows.Count; i++)
            {
                GridViewRow gvr = gdvReport.Rows[i];
                Label lblSlNoAss = (Label)gvr.FindControl("lblSlNo");
                lblSlNoAss.Text = Convert.ToString(i + 1);

                Label lblMainIdAss = (Label)gvr.FindControl("lblMainId");
                lblMainIdAss.Text = dsAgR.Tables[0].Rows[i].ItemArray[6].ToString();

                Label lblSourceAss = (Label)gvr.FindControl("lblSource");
                lblSourceAss.Text = dsAgR.Tables[0].Rows[i].ItemArray[7].ToString();

                TextBox txtInFvrAss = (TextBox)gvr.FindControl("txtInFvr");
                txtInFvrAss.Text = dsAgR.Tables[0].Rows[i].ItemArray[10].ToString();

                TextBox txtGPFacAss = (TextBox)gvr.FindControl("txtGPFac");
                txtGPFacAss.Text = dsAgR.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtCrtHAcAss = (TextBox)gvr.FindControl("txtCrtHAc");
                txtCrtHAcAss.Text = dsAgR.Tables[0].Rows[i].ItemArray[11].ToString();

                DropDownList ddlRemByAss = (DropDownList)gvr.FindControl("ddlRemBy");
                ddlRemByAss.SelectedValue = dsAgR.Tables[0].Rows[i].ItemArray[13].ToString();

                DropDownList ddlFrmMnthAss = (DropDownList)gvr.FindControl("ddlFrmMnth");
                ddlFrmMnthAss.SelectedValue = dsAgR.Tables[0].Rows[i].ItemArray[12].ToString();

                //gdvReport.Rows[i].Cells[1].ToolTip = dsAgR.Tables[0].Rows[i].ItemArray[16].ToString();
                if (Convert.ToInt16(dsAgR.Tables[0].Rows[i].ItemArray[7]) == 2)
                {
                    gdvReport.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }
            gblobj.SetFooterTotals(gdvReport, 3);
            gblobj.SetFooterTotals(gdvReport, 10);
        }
        else
        {
            SetGridDefault();
        }
    }
    private void FillDdls()
    {
        DataSet dsRemtdBy = new DataSet();
        ArrayList ar = new ArrayList();
        if (rdbType.Items[0].Selected == true)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        dsRemtdBy = wthd.GetDrawnBy(ar);

        DataSet dsMth = new DataSet();
        dsMth = genDAO.GetMonth();

        for (int i = 0; i < gdvReport.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvReport.Rows[i];
            DropDownList ddlFrmMnthAss = (DropDownList)gdvrow.FindControl("ddlFrmMnth");
            gblobj.FillCombo(ddlFrmMnthAss, dsMth, 1);

            DropDownList ddlRemByAss = (DropDownList)gdvrow.FindControl("ddlRemBy");
            gblobj.FillCombo(ddlRemByAss, dsRemtdBy, 1);
           
        }
    }

    protected void btnPrntRt_Click(object sender, EventArgs e)
    {
        if (rdbType.Items[0].Selected == true)
        {
            Session["numAgRpt1"] = Convert.ToInt16(Session["intYearAGRpt"]);
            Session["numAgRpt2"] = Convert.ToInt16(Session["intMonthAGRpt"]);
            Response.Redirect("Reportviewer.aspx?ReportID=10");
        }
        else
        {
            Session["numAgRpt1"] = Convert.ToInt16(Session["intYearAGRpt"]);
            Session["numAgRpt2"] = Convert.ToInt16(Session["intMonthAGRpt"]);
            Response.Redirect("Reportviewer.aspx?ReportID=11");
        }
    }
    protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

}
