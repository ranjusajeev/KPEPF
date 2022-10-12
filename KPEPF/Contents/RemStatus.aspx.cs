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

public partial class Contents_RemStatus : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
    ChalanDAO chD = new ChalanDAO();
    EmployeeDAO empd = new EmployeeDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intType"] = 1;
            if (Convert.ToInt16(Session["intSelection"]) == 0)
            {
                Session["intSelection"] = 1;
            }
            FillCmbs();
            SetCtrls();
            SetGridDefault();
            //SetGridDefault2();
            pnl2.Visible = false;
            pnl1.Visible = true;
            SetIdCols();
            Session["flgPageBackChalView"] = 2;
            if (Convert.ToInt64(Session["intChalanId"]) > 0)
            {
                //string  f = Session["intSelection"].ToString();
                //string g = Session["intYearIdRStatLb"].ToString();
                FillBack();
                SetCtrls();
            }
        }
    }
    private void SetIdCols()
    {
        if (Convert.ToInt32(Session["intUserId"]) == 0)
        {
            gdvCorr.Columns[4].Visible = false;
            gdvCorr.Columns[6].Visible = false;
        }
        else
        {
            gdvCorr.Columns[4].Visible = true;
            gdvCorr.Columns[6].Visible = true;
        }
    }
    private void SetCtrls()
    {
        //Session["intTrnType"] = Convert.ToInt16(Request.QueryString["k"]);
        if (Convert.ToInt16(Session["intSelection"]) == 1)
        {
            if (Convert.ToInt16(Session["intType"]) == 1)
            {
                //ddlYear.Enabled = true;
                //ddlMonth.Enabled = true;
                gdvCorr.Visible = true;
                gdvCorrNot.Visible = false;
                //SetDdpOption();
            }
            else
            {
                //ddlYear.Enabled = false;
                //ddlMonth.Enabled = false;
                gdvCorr.Visible = false;
                gdvCorrNot.Visible = true;
            }
        }
        else
        {
            pnl1.Visible = false;
            pnl2.Visible = true ;
        }
    }
    private void FillBack()
    {
        ////Session["intType"] = 1;
        //ddlYear.SelectedValue = Session["intYearIdRStat"].ToString();
        //ddlMonth.SelectedValue = Session["intMonthIdRStat"].ToString();
        //ddlDist.SelectedValue = Session["intDistIdRStat"].ToString();
        //FillGrid(Convert.ToInt16(Session["intType"]));
        //gdvCorr.Visible = true;
        //gdvCorrNot.Visible = false;

        //string f = Session["intSelection"].ToString();
        //string g = Session["intYearIdRStatLb"].ToString();
        if (Convert.ToInt16(Session["intSelection"]) == 1)
        {
            ddlYear.SelectedValue = Session["intYearIdRStat"].ToString();
            ddlMonth.SelectedValue = Session["intMonthIdRStat"].ToString();
            ddlDist.SelectedValue = Session["intDistIdRStat"].ToString();
            FillGrid(Convert.ToInt16(Session["intType"]));
            gdvCorr.Visible = true;
            gdvCorrNot.Visible = false;
            rdSelection.Items[0].Selected = true;
        }
        else
        {
            FillCmbs2();
            FillLBCmb(Convert.ToInt16(Session["intDistIdRStatLb"]));
            ddlYearLb.SelectedValue = Session["intYearIdRStatLb"].ToString();
            ddlDistLb.SelectedValue = Session["intDistIdRStatLb"].ToString();
            ddlLbLb.SelectedValue = Session["intLbLb"].ToString();
            FillGrid2();
            rdSelection.Items[1].Selected = true;
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("intChalanNo");
        ar.Add("intChalanId");
        ar.Add("fltChalanAmt");
        ar.Add("ChalType");
        ar.Add("chvApproval");
        ar.Add("flgApproval");
        gblObj.SetGridDefault(gdvCorr, ar);
        gdvCorr.Enabled = false;
        ArrayList ar1 = new ArrayList();
        //ar1.Add("SlNo");
        ar1.Add("chvEngLBName");
        
        gblObj.SetGridDefault(gdvCorrNot, ar1);

        gdvCorr.Visible = true;
        gdvCorrNot.Visible = false;

        Session["intTrnType"] = 1;
    }
    private void SetGridDefault2()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("intChalanNo");
        ar.Add("intChalanId");
        ar.Add("fltChalanAmt");
        ar.Add("ChalType");
        ar.Add("chvApproval");
        ar.Add("flgApproval");
        gblObj.SetGridDefault(gdvLbwise, ar);
    }
    private void FillCmbs()
    {
        DataSet ds = new DataSet();
        ds = kgen.GetYearOnLine();
        gblObj.FillCombo(ddlYear, ds, 1);

        DataSet ds1 = new DataSet();
        ds1 = gen.GetMonth();
        gblObj.FillCombo(ddlMonth, ds1, 1);

        DataSet ds2 = new DataSet();
        ds2 = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, ds2, 1);
    }
    private void FillCmbs2()
    {
        DataSet ds = new DataSet();
        ds = kgen.GetYearOnLine();
        gblObj.FillCombo(ddlYearLb, ds, 1);

        DataSet ds2 = new DataSet();
        ds2 = gen.GetDistrict();
        gblObj.FillCombo(ddlDistLb, ds2, 1);
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        //{
        //    Session["intDistIdRStat"] = int.Parse(ddlDist.SelectedValue.ToString());
        //    FillGrid(Convert.ToInt16(Session["intTrnType"]));
        //}
        //else
        //{
        //    Session["intDistIdRStat"] = 0;
        //    SetGridDefault();
        //}


        if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        {
            Session["intDistIdRStat"] = int.Parse(ddlDist.SelectedValue.ToString());
            //if (Convert.ToInt16(Session["intTrnType"]) == 1)
            //{
                FillGrid(Convert.ToInt16(Session["intType"]));
            //}
            //else
            //{
            //    FillGridSerDet(Convert.ToInt16(Session["intType"]));
            //}
        }
        else
        {
            Session["intDistIdRStat"] = 0;
            SetGridDefault();
        }
    }
    //private void FillGridSerDet(int typ)
    //{
    //    SetGridDefault();
    //    DataSet ds = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    if (Convert.ToInt16(Session["intDistIdRStat"]) > 0)
    //    {
    //        ar.Add(Convert.ToInt16(Session["intDistIdRStat"]));
    //        ar.Add(typ);
    //        //if (typ == 1)
    //        //{
    //            ds = empd.GetServiceDetRpt(ar);

    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                gdvCorrNot.Enabled = true;
    //                lblCnt.Text = ds.Tables[0].Rows.Count.ToString();
    //                gdvCorrNot.DataSource = ds;
    //                gdvCorrNot.DataBind();
    //                for (int i = 0; i < gdvCorrNot.Rows.Count; i++)
    //                {
    //                    GridViewRow grdVwRow = gdvCorrNot.Rows[i];
    //                    Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo");
    //                    lblSlNo.Text = Convert.ToString(i + 1);
    //                }
    //            }
    //            else
    //            {
    //                gdvCorrNot.Enabled = false;
    //            }
    //        //}
    //        //else
    //        //{
    //        //    ds = chD.ChalanStatusNotEntered(ar);

    //        //    if (ds.Tables[0].Rows.Count > 0)
    //        //    {
    //        //        gdvCorrNot.Enabled = true;
    //        //        lblCnt.Text = ds.Tables[0].Rows.Count.ToString();
    //        //        gdvCorrNot.DataSource = ds;
    //        //        gdvCorrNot.DataBind();
    //        //        for (int i = 0; i < gdvCorrNot.Rows.Count; i++)
    //        //        {
    //        //            GridViewRow grdVwRow = gdvCorrNot.Rows[i];
    //        //            Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo");
    //        //            lblSlNo.Text = Convert.ToString(i + 1);
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        gdvCorrNot.Enabled = false;
    //        //    }
    //        //}
    //    }
    //}

    private void FillGrid(int typ)
    {
        SetGridDefault();
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(Session["intYearIdRStat"]) > 0 && Convert.ToInt16(Session["intMonthIdRStat"]) > 0 && Convert.ToInt16(Session["intDistIdRStat"]) > 0)
        {
            ar.Add(Convert.ToInt16(Session["intYearIdRStat"]));
            ar.Add(Convert.ToInt16(Session["intMonthIdRStat"]));
            ar.Add(Convert.ToInt16(Session["intDistIdRStat"]));
            if (typ == 1)
            {
                gdvCorr.Visible = true;
                gdvCorrNot.Visible = false;
                
                ds = chD.ChalanStatus(ar);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdvCorr.Enabled = true;
                    lblCnt.Text = ds.Tables[0].Rows.Count.ToString();
                    gdvCorr.DataSource = ds;
                    gdvCorr.DataBind();
                    for (int i = 0; i < gdvCorr.Rows.Count; i++)
                    {
                        GridViewRow grdVwRow = gdvCorr.Rows[i];
                        Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo");
                        lblSlNo.Text = Convert.ToString(i + 1);
                        grdVwRow.Cells[5].ToolTip = ds.Tables[0].Rows[i].ItemArray[8].ToString();

                    }
                    gblObj.SetFooterTotals(gdvCorr, 3);
                    if (Convert.ToInt16(Session["intUserTypeId"]) == 40)
                    {
                        gdvCorr.Columns[4].Visible = true;
                        gdvCorr.Columns[6].Visible = true;
                    }
                    else
                    {
                        gdvCorr.Columns[4].Visible = false;
                        gdvCorr.Columns[6].Visible = false;
                    }
                }
                else
                {
                    gdvCorr.Enabled = false;
                }
            }
            else
            {
                gdvCorr.Visible = false;
                gdvCorrNot.Visible = true;
                
                ds = chD.ChalanStatusNotEntered(ar);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdvCorrNot.Enabled = true;
                    lblCnt.Text = ds.Tables[0].Rows.Count.ToString();
                    gdvCorrNot.DataSource = ds;
                    gdvCorrNot.DataBind();
                    for (int i = 0; i < gdvCorrNot.Rows.Count; i++)
                    {
                        GridViewRow grdVwRow = gdvCorrNot.Rows[i];
                        Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo");
                        lblSlNo.Text = Convert.ToString(i + 1);
                    }
                }
                else
                {
                    gdvCorrNot.Enabled = false;
                }
            }
        }
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdApp.Items[0].Selected == true)
        {
            Session["intType"] = 1;
            gdvCorr.Visible = true;
            gdvCorrNot.Visible = false;
        }
        else
        {
            Session["intType"] = 2;
            gdvCorr.Visible = false;
            gdvCorrNot.Visible = true;
        }
        
        if (Convert.ToInt16(Session["intYearIdRStat"]) > 0)
        {
            ddlYear.SelectedValue = Session["intYearIdRStat"].ToString();
        }
        if (Convert.ToInt16(Session["intMonthIdRStat"]) > 0)
        {
            ddlMonth.SelectedValue = Session["intMonthIdRStat"].ToString();
        }

        if (Convert.ToInt16(Session["intDistIdRStat"]) > 0)
        {
            ddlDist.SelectedValue = Session["intDistIdRStat"].ToString();
        }
        FillGrid(Convert.ToInt16(Session["intType"]));

        //ddlYear.SelectedValue = "0";
        //ddlMonth.SelectedValue = "0";
        //ddlDist.SelectedValue = "0";



        //if (rdApp.Items[0].Selected == true)
        //{
        //    if (Convert.ToInt16(Session["intTrnType"]) == 1)
        //    {
        //        Session["intType"] = 1;
        //        gdvCorr.Visible = true;
        //        gdvCorrNot.Visible = false;
        //    }
        //    else
        //    {
        //        Session["intType"] = 1;
        //        gdvCorr.Visible = false;
        //        gdvCorrNot.Visible = true;
        //    }
        //}
        //else
        //{
        //    Session["intType"] = 2;
        //    gdvCorr.Visible = false;
        //    gdvCorrNot.Visible = true;
        //}

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearIdRStat"] = int.Parse(ddlYear.SelectedValue.ToString());
            FillGrid(Convert.ToInt16(Session["intType"]));
        }
        else
        {
            Session["intYearIdRStat"] = 0;
            SetGridDefault();
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["intMonthIdRStat"] = int.Parse(ddlMonth.SelectedValue.ToString());
            FillGrid(Convert.ToInt16(Session["intType"]));
        }
        else
        {
            Session["intMonthIdRStat"] = 0;
            SetGridDefault();
        }
    }
    protected void rdSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdSelection.Items[0].Selected == true)
        {
            Session["intSelection"] = 1;
            pnl1.Visible = true;
            pnl2.Visible = false;
            //FillCmbs();
        }
        else
        {
            Session["intSelection"] = 2;
            pnl2.Visible = true;
            pnl1.Visible = false;
            SetGridDefault2();
            FillCmbs2();
        }
    }
    protected void ddlYearLb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYearLb.SelectedValue) > 0)
        {
            Session["intYearIdRStatLb"] = int.Parse(ddlYearLb.SelectedValue.ToString());
        }
        else
        {
            Session["intYearIdRStatLb"] = 0;
            SetGridDefault2();
        }
    }
    protected void ddlDistLb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistLb.SelectedValue) > 0)
        {
            Session["intDistIdRStatLb"] = int.Parse(ddlDistLb.SelectedValue.ToString());
            FillLBCmb(Convert.ToInt16(Session["intDistIdRStatLb"]));
        }
        else
        {
            Session["intDistIdRStatLb"] = 0;
        }
    }
    private void FillLBCmb(int dist)
    {
        ArrayList ar = new ArrayList();
        DataSet dsl = new DataSet();
        ar.Add(dist);
        dsl = gen.GetLBGp(ar);
        gblObj.FillCombo(ddlLbLb, dsl, 1);

    }
    private void FillGrid2()
    {
        SetGridDefault();
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(Session["intYearIdRStatLb"]) > 0 && Convert.ToInt16(Session["intLbLb"]) > 0)
        {
            ar.Add(Convert.ToInt16(Session["intYearIdRStatLb"]));
            ar.Add(Convert.ToInt16(Session["intLbLb"]));

            ds = chD.ChalanStatusLb(ar);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvLbwise.DataSource = ds;
                gdvLbwise.DataBind();
                for (int i = 0; i < gdvLbwise.Rows.Count; i++)
                {
                    GridViewRow grdVwRow = gdvLbwise.Rows[i];
                    Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo2");
                    lblSlNo.Text = Convert.ToString(i + 1);
                    grdVwRow.Cells[5].ToolTip = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                }
            }
        }
    }
    protected void ddlLbLb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlLbLb.SelectedValue) > 0)
        {
            Session["intLbLb"] = int.Parse(ddlLbLb.SelectedValue.ToString());
            FillGrid2();
        }
        else
        {
            Session["intLbLb"] = 0;
        }
    }
}
