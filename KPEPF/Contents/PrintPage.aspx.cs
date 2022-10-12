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

public partial class Contents_PrintPage : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    KPEPFGeneralDAO genK = new KPEPFGeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    static int intDistId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));

            InitialSettings();
        }
    }
    private void InitialSettings()
    {
        Session["flgCons"] = 1;
        if (Convert.ToInt16(Session["intTrnType"]) == 10)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = true;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Sanction Order";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 11)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = true;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Bill";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 15)
        {
            
            txtEmpId.Visible = false;
            pnlChal.Visible = true;
            FillYearAndMonth();
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Chalan";
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 25)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = true;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Chalan";
            lblHead.Text = "ABCD Statement";
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 26)
        {
            Session["empRptType"] = 2;
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            pnlEmpE.Visible = true ;
            DataSet dsd = new DataSet();
            dsd = gen.GetDistrict();
            gblObj.FillCombo(ddlDist, dsd, 1);
            ddlDist.Enabled = false;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Employee Account";
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 27)       //Suspense acc
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = true;
            FillDistAndYear();
            lblHead.Text = "Suspense Account";
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 28)       //Other PF
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = true;
            FillDistAndYear();
            lblHead.Text = "Other PF Account";
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 29)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = true ;
            FillYearAndMonthAppStat();
            Session["intTrnTpAppR"] = 1;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Approval Status_Treasury/AG";
            rdAppListCons.Visible = true;
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 30)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = true;
            FillYearAndMonthAppStat();
            ddlMonthA.Enabled = false;
            rdTrnA.Enabled = false;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Approval Status_AG";
            rdAppListCons.Visible = false;
            ddlYearA.Enabled = true;
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = true;
            gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = false;
            pnlSuspOtherPF.Visible = false;
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 55)
        {
            pnlChal.Visible = false;
            txtEmpId.Visible = false;
            //gblObj.IntYearABCD1 = 0;
            pnlAppStat.Visible = true;

            Label11.Visible = false;
            Label21.Visible=false;
            ddlYearA.Visible = false;
            ddlMonthA.Visible = false;

            //Session["intTrnTpAppR"] = 1;
            pnlSuspOtherPF.Visible = false;
            lblHead.Text = "Rejection List";
            Session["intTrnTpAppR"] = 1;
        }
    }
    private void FillYearAndMonth()
    {
        DataSet dsY = new DataSet();
        dsY = genK.GetYearOnLine();
        gblObj.FillCombo(ddlYear, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonth, dsM, 1);

        DataSet dsD = new DataSet();
        dsD = gen.GetDistrict();
        gblObj.FillCombo(ddlDistrict, dsD, 1);
    }
    private void FillYearAndMonthAppStat()
    {
        DataSet dsY = new DataSet();
        dsY = gen.GetYearRem();
        gblObj.FillCombo(ddlYearA, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonthA, dsM, 1);
    }
    private void FillDistAndYear()
    {
        DataSet dsYs = new DataSet();
        dsYs = gen.GetYearRem();
        gblObj.FillCombo(ddlYearS, dsYs, 1);

        DataSet dsMs = new DataSet();
        dsMs = gen.GetDistrict();
        gblObj.FillCombo(ddlDistS, dsMs, 1);
    }
    private void FillGridAg()
    {
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdAppR"]));
        gdvSerHis.Visible = true;
        gdvSerHis.Columns[0].Visible = false;
        gdvSerHis.Columns[2].Visible = false;
        dsC = gen.getRejListAg(ar);
        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvSerHis.DataSource = dsC;
            gdvSerHis.DataBind();
        }
        else
        {
            SetGridDefault51();
        }
    }
    private void FillGrid()
    {
        DataSet dsC = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intTrnTpAppR"]));

        dsC = gen.getRejList(ar);

        if (dsC.Tables[0].Rows.Count > 0)
        {
            gdvSerHis.DataSource = dsC;
            gdvSerHis.DataBind();
            gdvSerHis.Visible = true;
        }
        else
        {
            SetGridDefault51();
        }

        //DataSet dsC = new DataSet();
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt32(Session["intTrnTpAppR"]));

        //dsC = gen.getRejList(ar);

        //if (dsC.Tables[0].Rows.Count > 0)
        //{
        //    gdvSerHis.DataSource = dsC;
        //    gdvSerHis.DataBind();
        //    gdvSerHis.Visible = true;
        //}
        //else
        //{
        //    SetGridDefault51();
        //}
    }
    private void SetGridDefault51()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvYear");
        ar.Add("chvMonth");
        ar.Add("chvEngDistName");

        gblObj.SetGridDefault(gdvSerHis, ar);
    }
    //private void SetGridDefaultT()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SlNo");
    //    ar.Add("chvYear");
    //    ar.Add("chvMonth");
    //    ar.Add("chvEngDistName");
    //    ar.Add("chvTreasuryName");
    //    gblObj.SetGridDefault(gdvRejList, ar);
    //}
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //if (Convert.ToInt16(Session["flgCons"]) == 1)
        //{
        //    FillGrid();
        //}
        //else
        //{
            if (Convert.ToInt16(Session["intTrnType"]) == 10)
            {
                if (Convert.ToInt32(Session["intAccNoCorr"]) > 0)
                {
                    FindSerTrnIdForSanOrder();
                    Response.Redirect("Reportviewer.aspx?ReportID=1");
                }
                else
                {
                    gblObj.MsgBoxOk("Enter Account No.!", this);
                }
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 11)
            {
                FindSerTrnIdForBill();
                Response.Redirect("Reportviewer.aspx?ReportID=2");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 15)
            {
                //FindSerTrnIdForChalan();
                Session["NumChalanID"] = Convert.ToInt64(ddlChalan.SelectedValue);
                Response.Redirect("Reportviewer.aspx?ReportID=3");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 25)
            {
                FinddetailsforABCDRpt();
                if (gblObj.IntYearABCD > 0)
                {
                    Response.Redirect("Reportviewer.aspx?ReportID=4");
                }
                else
                {
                    gblObj.MsgBoxOk("No previous Credit card!", this);
                }
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 26)
            {
                if (rdTrn.Items[1].Selected == true)
                {
                    Session["empRptType"] = 0;      //Live
                }
                else if (rdTrn.Items[2].Selected == true)
                {
                    Session["empRptType"] = 1;      //Closed
                }
                else if (rdTrn.Items[3].Selected == true)
                {
                    Session["empRptType"] = 3;      //With OB
                }
                else if (rdTrn.Items[4].Selected == true)
                {
                    Session["empRptType"] = 4;      //Without OB
                }
                else if (rdTrn.Items[0].Selected == true)
                {
                    Session["empRptType"] = 5;      //Without OB
                }
                Response.Redirect("Reportviewer.aspx?ReportID=26");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 27)      //suspnse acc
            {
                Response.Redirect("Reportviewer.aspx?ReportID=27");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 28)      //OPF acc
            {
                Response.Redirect("Reportviewer.aspx?ReportID=28");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 29)
            {
                if (Convert.ToInt16(Session["flgCons"]) == 1)
                {
                    FillGrid();
                }
                else
                {
                    Response.Redirect("Reportviewer.aspx?ReportID=29");
                }
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 30)
            {
                //Response.Redirect("Reportviewer.aspx?ReportID=30");
                FillGridAg();
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 31)
            {
                Response.Redirect("Reportviewer.aspx?ReportID=31");
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 55)      //Rejection List
            {
                Response.Redirect("Reportviewer.aspx?ReportID=55");
            }
        //}
    }
    private void FindSerTrnIdForSanOrder()
    {
        DataSet dsSerTrn2 = new DataSet();
        ArrayList ArrIn2 = new ArrayList();
        ArrIn2.Add(txtEmpId.Text.ToString());
        dsSerTrn2 = gen.GetServiceTrnIdFromFileNo2(ArrIn2);

        if (dsSerTrn2.Tables[0].Rows.Count > 0)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(dsSerTrn2.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            Session["NumServiceTrnID"] = 0;
            gblObj.MsgBoxOk("No such order exists!", this);
        }
    }
    private void FinddetailsforABCDRpt()
    {
        Session["NumEmpId"] = Convert.ToDouble(txtEmpId.Text.ToString());
        DataSet dsSerTrn2 = new DataSet();
        ArrayList ArrIn2 = new ArrayList();
        ArrIn2.Add(txtEmpId.Text.ToString());
        dsSerTrn2 = gen.GetMxIdFromTB_Yeardetail4ABCDRpt(ArrIn2);

        if (Convert.ToInt32(dsSerTrn2.Tables[0].Rows[0].ItemArray[0]) > 0)
        {
            gblObj.IntYearABCD1 = Convert.ToInt32(dsSerTrn2.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            gblObj.IntYearABCD1 = 0;
            gblObj.MsgBoxOk("No previous Credit card!", this);
        }
        DataSet dsyr = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(gblObj.IntYearABCD1);
        dsyr = gen.Getyr4ABCDRpt(arr);
        if (dsyr.Tables[0].Rows.Count > 0)
        {
            gblObj.IntYearABCD = Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            gblObj.IntYearABCD = 0;
            gblObj.MsgBoxOk("No previous Credit card!", this);
        }
    }
    //private void FindSerTrnIdForChalan()
    //{
    //    DataSet dsChal = new DataSet();
    //    ArrayList ArrInC = new ArrayList();
    //    ArrInC.Add(Convert.ToInt16(ddlYear.SelectedValue));
    //    ArrInC.Add(Convert.ToInt16(ddlMonth.SelectedValue));
    //    ArrInC.Add(Convert.ToInt16(ddlTreas.SelectedValue));
    //    dsChal = gen.GetChalanIdFromChalanTRN(ArrInC);

    //    if (dsChal.Tables[0].Rows.Count > 0)
    //    {
    //        gblObj.NumChalanID = Convert.ToInt64(dsChal.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    else
    //    {
    //        gblObj.NumChalanID = 0;
    //        gblObj.MsgBoxOk("No such Chalan exists!", this);
    //    }
    //}
    private void FindSerTrnIdForBill()
    {
        DataSet dsbill = new DataSet();
        ArrayList ArrInb = new ArrayList();
        ArrInb.Add(txtEmpId.Text.ToString());
        dsbill = gen.GetBillIdFromBill(ArrInb);

        if (dsbill.Tables[0].Rows.Count > 0)
        {
            gblObj.NumBillID = Convert.ToInt64(dsbill.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            gblObj.NumBillID = 0;
            gblObj.MsgBoxOk("No such Bill exists!", this);
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistrict.SelectedValue) > 0)
        {
            intDistId = Convert.ToInt16(ddlDistrict.SelectedValue);
            FillTreas();
        }
    }
    private void FillTreas()
    {
        DataSet dsT = new DataSet();
        ArrayList arT = new ArrayList();
        arT.Add(Convert.ToInt32(intDistId));
        dsT = gen.GetTreasury(arT);
        gblObj.FillCombo(ddlTreas, dsT, 1);
    }
    protected void ddlChalan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetChalansFrmChalan
        DataSet dsChal = new DataSet();
        ArrayList ArrInC = new ArrayList();
        ArrInC.Add(Convert.ToInt16(ddlYear.SelectedValue));
        ArrInC.Add(Convert.ToInt16(ddlMonth.SelectedValue));
        ArrInC.Add(Convert.ToInt16(ddlTreas.SelectedValue));
        dsChal = gen.GetChalansFrmChalan(ArrInC);
        gblObj.FillCombo(ddlChalan, dsChal, 1);
        //if (dsChal.Tables[0].Rows.Count > 0)
        //{
        //    gblObj.NumChalanID = Convert.ToInt64(dsChal.Tables[0].Rows[0].ItemArray[0]);
        //}
        //else
        //{
        //    gblObj.NumChalanID = 0;
        //    gblObj.MsgBoxOk("No such Chalan exists!", this);
        //}
    }
    protected void rdTrn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrn.Items[0].Selected == true)
        {
            ddlDist.Enabled = false;
        }
        else
        {
            ddlDist.Enabled = true;
        }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        {
            Session["intDistEmp1"] = Convert.ToInt16(ddlDist.SelectedValue);
        }
        else
        {
            Session["intDistEmp1"] = 0;
        }
    }
    protected void ddlYearA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYearA.SelectedValue) > 0)
        {
            Session["intYearIdAppR"] = Convert.ToInt16(ddlYearA.SelectedItem.Value);
        }
        else
        {
            Session["intYearIdAppR"] = 0;
        }
    }
    protected void ddlMonthA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonthA.SelectedValue) > 0)
        {
            Session["intMonthIdAppR"] = Convert.ToInt16(ddlMonthA.SelectedItem.Value);
        }
        else
        {
            Session["intMonthIdAppR"] = 0;
        }
    }
    protected void rdTrnA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrnA.Items[0].Selected == true)
        {
            Session["intTrnTpAppR"] = 1;
        }
        else
        {
            Session["intTrnTpAppR"] = 2;
        }

    }
    protected void ddlDistS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistS.SelectedValue) > 0)
        {
            Session["intDistOPF"] = Convert.ToInt16(ddlDistS.SelectedItem.Value);
        }
        else
        {
            Session["intDistOPF"] = 0;
        }
    }
    protected void ddlYearS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYearS.SelectedValue) > 0)
        {
            Session["intYearOPF"] = Convert.ToInt16(ddlYearS.SelectedItem.Value);
        }
        else
        {
            Session["intYearOPF"] = 0;
        }
    }
    protected void txtEmpId_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(txtEmpId.Text) > 0)
        {
            Session["intAccNoCorr"] = Convert.ToInt16(txtEmpId.Text);
        }
        else
        {
            gblObj.MsgBoxOk("Enter Account No.!", this);
        }
    }
    protected void rdAppListCons_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdAppListCons.Items[0].Selected == true)
        {
            Session["flgCons"] = 1;
            ddlYearA.Enabled = false;
            ddlMonthA.Enabled = false;
        }
        else
        {
            Session["flgCons"] = 2;
            ddlYearA.Enabled = true;
            ddlMonthA.Enabled = true;
            SetGridDefault51();
        }
    }
}
