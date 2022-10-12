
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

public partial class Contents_ChalBillSearch : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    ChalanDAO chalDao = new ChalanDAO();
    BillPDE blpde = new BillPDE();
    BillPDEDao blPdeD = new BillPDEDao();
    KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
    //static int intLBId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["flgPageBack"] = 1;
            if (Convert.ToInt16(Session["flgFilterMode"]) > 0)
            {
                FillBack();
            }
            else
            {
                //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
                //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
                //{
                //    gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
                //}
                gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
                InitialSettings();
            }
        }
    }
    private void SetGridsVisible()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 32)           //Chalan
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
            {
                //int y = Convert.ToInt16(Session["IntYearSearchChal"]);
                gdvInboxMembership.Visible = true;
                gdvInboxMembershipCurr.Visible = false;
                gdvBill.Visible = false;
                gdvBillCurr.Visible = false;
            }
            else
            {
                gdvInboxMembership.Visible = false;
                gdvInboxMembershipCurr.Visible = true;
                gdvBill.Visible = false;
                gdvBillCurr.Visible = false;
            }
        }
        else                            //Bill
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
            {
                gdvInboxMembership.Visible = false;
                gdvInboxMembershipCurr.Visible = false;
                gdvBill.Visible = true;
                gdvBillCurr.Visible = false;
            }
            else
            {
                gdvInboxMembership.Visible = false;
                gdvInboxMembershipCurr.Visible = false;
                gdvBill.Visible = false;
                gdvBillCurr.Visible = true;
            }
        }
    }
    private void FillBack()
    {
        DataSet dsyr = new DataSet();
        ArrayList arr = new ArrayList();
        int a = Convert.ToInt16(Session["IntYearSearchChal"]);
        int b = Convert.ToInt16(Session["flgPrevYear"]);
        if (Convert.ToInt16(Session["IntYearSearchChal"]) >= 24 && Convert.ToInt16(Session["flgPrevYear"]) == 3)
        {
            arr.Add(Convert.ToInt32(Session["IntYearSearchChal"]));
            dsyr = gen.Getyr4ABCDRpt(arr);
            if (dsyr.Tables[0].Rows.Count > 0)
            {
                Session["IntYearSearchChal"] = Convert.ToInt32(dsyr.Tables[0].Rows[0].ItemArray[0]);
            }
        }
        else
        {

        }
        SetRdSelection();
        SetRdCategory();
        SetGridsVisible();

        if (Convert.ToInt16(Session["flgFilterMode"]) == 1)
        {
            if (Convert.ToInt64(Session["numChalanIdEdit"]) > 0 || Convert.ToInt64(Session["numChalanIdOnline"]) > 0)  //Session["numChalanIdOnline"]
            {
                if (Session["StrChalDt"] != null)
                {
                    txtDt.Text = Session["StrChalDt"].ToString();
                }
                else
                {

                }
                if (Session["IntChalNo"] != null)
                {
                    txtNo.Text = Session["IntChalNo"].ToString();
                }
                else
                {

                }
                if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
                //if (Convert.ToInt16(Session["intYearSearchChalToFill"]) < 50)
                {
                    //int y = Convert.ToInt16(Session["IntYearSearchChal"]);
                    FillGrid(1, gdvInboxMembership);
                }
                else
                {
                    FillGrid(1, gdvInboxMembershipCurr);
                }
            }
        }
        else if (Convert.ToInt16(Session["flgFilterMode"]) == 2)
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
            {
                if (Convert.ToInt64(Session["numChalanIdEdit"]) > 0)
                {
                    FillDdls(1);
                    ddlYear.SelectedValue = Session["IntYearSearchChal"].ToString();
                    ddlMonth.SelectedValue = Session["IntMonthSearchChal"].ToString();
                    ddlDistrict.SelectedValue = Session["IntDistSearchChal"].ToString();
                    FillLb();
                    ddlLb.SelectedValue = Convert.ToInt32(Session["intLBIDSearchChal"]).ToString();
                    FillGrid(2, gdvInboxMembership);
                }
            }
            else
            {
                if (Convert.ToInt64(Session["numChalanIdOnline"]) > 0)
                {
                    FillDdls(1);
                    ddlYear.SelectedValue = Session["IntYearSearchChal"].ToString();
                    ddlMonth.SelectedValue = Session["IntMonthSearchChal"].ToString();
                    ddlDistrict.SelectedValue = Session["IntDistSearchChal"].ToString();
                    FillLb();
                    ddlLb.SelectedValue = Convert.ToInt32(Session["intLBIDSearchChal"]).ToString();
                    FillGrid(2, gdvInboxMembershipCurr);
                }
            }
        }
        else if (Convert.ToInt16(Session["flgFilterMode"]) == 3)
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
            {
                if (Convert.ToInt64(Session["numChalanIdEdit"]) > 0)
                //if (Convert.ToInt64(Session["numChalanIdOnline"]) > 0)
                {
                    FillDdls(1);
                    ddlYearT.SelectedValue = Session["IntYearSearchChal"].ToString();
                    ddlMonthT.SelectedValue = Session["IntMonthSearchChal"].ToString();
                    ddlDistrictT.SelectedValue = Session["IntDistSearchChal"].ToString();
                    FillTreas();
                    ddlTreas.SelectedValue = Convert.ToInt32(Session["intTreasuryIDSearchChal"]).ToString();
                    FillGrid(3, gdvInboxMembership);
                }
            }
            else
            {
                if (Convert.ToInt64(Session["numChalanIdOnline"]) > 0)
                {
                    FillDdls(1);
                    ddlYearT.SelectedValue = Session["IntYearSearchChal"].ToString();
                    ddlMonthT.SelectedValue = Session["IntMonthSearchChal"].ToString();
                    ddlDistrictT.SelectedValue = Session["IntDistSearchChal"].ToString();
                    FillTreas();
                    ddlTreas.SelectedValue = Convert.ToInt32(Session["intTreasuryIDSearchChal"]).ToString();
                    FillGrid(3, gdvInboxMembershipCurr);
                }
            }
        }
    }
    private void SetRdSelection()
    {
        if (Convert.ToInt16(Session["flgFilterMode"]) == 1)
        {
            rdCategory.Items[0].Selected = true;
            rdCategory.Items[1].Selected = false;
            rdCategory.Items[2].Selected = false;
        }
        else if (Convert.ToInt16(Session["flgFilterMode"]) == 2)
        {
            rdCategory.Items[1].Selected = true;
            rdCategory.Items[0].Selected = false;
            rdCategory.Items[2].Selected = false;
        }
        else
        {
            rdCategory.Items[2].Selected = true;
            rdCategory.Items[0].Selected = false;
            rdCategory.Items[1].Selected = false;
        }
    }
    private void InitialSettings()
    {
        //if (Convert.ToInt16(Session["intTrnType"]) == 32)
        //{
        //    rdCategory.Items[0].Selected = true;
        //    Session["flgFilterMode"] = 1;
        //    pnlNo.Visible = true;
        //    pnlLb.Visible = false;
        //    pnlTreas.Visible = false;
        //    FillDdls(1);
        //}
        //else
        //{                                           //Bill
        //    rdCategory.Items[0].Selected = true;
        //    Session["flgFilterMode"] = 1;
        //    pnlNo.Visible = true;
        //    pnlLb.Visible = false;
        //    pnlTreas.Visible = false;
        //    FillDdls(1);

        //    rdCategory.Items[1].Enabled = false;
        //}

        gdvBill.Visible = false;
        gdvInboxMembershipCurr.Visible = false;
        gdvBillCurr.Visible = false;
        rdCategory.Items[0].Selected = true;
        Session["flgFilterMode"] = 1;
        pnlNo.Visible = true;
        pnlLb.Visible = false;
        pnlTreas.Visible = false;
        gdvInboxMembership.Visible = true;
        SetGridDefault(gdvInboxMembership);
        FillDdls(1);
        if (Convert.ToInt16(Session["intTrnType"]) == 32)
        {
            lblHead.Text = "View Chalan";
        }
        else
        {                                           //Bill
            lblHead.Text = "View Bill";
            rdCategory.Items[1].Enabled = false;
        }
    }
    private void FillDdls(int type)
    {
        DataSet dsY = new DataSet();
        dsY = gen.GetYearRem();
        //gblObj.FillCombo(ddlYear, dsY, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        //gblObj.FillCombo(ddlMonth, dsM, 1);

        DataSet dsD = new DataSet();
        dsD = gen.GetDistrict();
        //gblObj.FillCombo(ddlDistrict, dsD, 1);
        if (type == 1)
        {
            gblObj.FillCombo(ddlYear, dsY, 1);
            gblObj.FillCombo(ddlMonth, dsM, 1);
            gblObj.FillCombo(ddlDistrict, dsD, 1);
        }
        else
        {
            gblObj.FillCombo(ddlYearT, dsY, 1);
            gblObj.FillCombo(ddlMonthT, dsM, 1);
            gblObj.FillCombo(ddlDistrictT, dsD, 1);
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["IntYearSearchChal"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["IntYearSearchChal"] = 0;
        }
        //SetGridDefault();
        //FillGrid(1);
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["IntMonthSearchChal"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        else
        {
            Session["IntMonthSearchChal"] = 0;
        }
        //SetGridDefault();
        //FillGrid(1);
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistrict.SelectedValue) > 0)
        {
            //Session["IntDistSearchChal"] = Convert.ToInt16(ddlDistrict.SelectedValue);
            Session["IntDistSearchChal"] = Convert.ToInt16(ddlDistrict.SelectedValue);
            FillLb();
        }
        else
        {
            Session["IntDistSearchChal"] = 0;
        }
        SetGridDefault(gdvInboxMembership);
    }
    private void FillLb()
    {
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(Convert.ToInt16(Session["IntDistSearchChal"]));
        dsL = gen.GetLBGp(arL);
        gblObj.FillCombo(ddlLb, dsL, 1);
    }
    private void FillTreas()
    {
        DataSet dsT = new DataSet();
        ArrayList arT = new ArrayList();
        arT.Add(Convert.ToInt16(Session["IntDistSearchChal"]));
        if (Convert.ToInt16(Session["intTrnType"]) == 32)
        {
            dsT = gen.GetTreasury(arT);
        }
        else
        {
            dsT = gen.GetDisTreasury(arT);
        }
        gblObj.FillCombo(ddlTreas, dsT, 1);
    }
    protected void ddlTreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlTreas.SelectedValue) > 0)
        {
            Session["intTreasuryIDSearchChal"] = Convert.ToInt16(ddlTreas.SelectedValue);
        }
        else
        {
            Session["intTreasuryIDSearchChal"] = 0;
        }
        //FillGrid(2);
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 32)
        {
            if (MandatoryFilled(Convert.ToInt16(Session["flgFilterMode"])) == true)
            {
                if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
                {
                    FillGrid(Convert.ToInt16(Session["flgFilterMode"]), gdvInboxMembership);
                    gdvBill.Visible = false;
                    gdvInboxMembershipCurr.Visible = false;
                    gdvBillCurr.Visible = false;
                    gdvInboxMembership.Visible = true;
                }
                else
                {
                    FillGrid(Convert.ToInt16(Session["flgFilterMode"]), gdvInboxMembershipCurr);
                    gdvBill.Visible = false;
                    gdvInboxMembershipCurr.Visible = true;
                    gdvBillCurr.Visible = false;
                    gdvInboxMembership.Visible = false;
                }
            }
            else
            {
                gblObj.MsgBoxOk("Select data!", this);
            }
        }
        else
        {
            if (MandatoryFilled(Convert.ToInt16(Session["flgFilterMode"])) == true)
            {
                if (Convert.ToInt16(Session["IntYearSearchChal"]) < 50)
                {
                    FillGridBill(Convert.ToInt16(Session["flgFilterMode"]), gdvBill);
                    gdvBill.Visible = true;
                    gdvInboxMembershipCurr.Visible = false;
                    gdvBillCurr.Visible = false;
                    gdvInboxMembership.Visible = false;
                }
                else
                {
                    FillGridBill(Convert.ToInt16(Session["flgFilterMode"]), gdvBillCurr);
                    gdvBill.Visible = false;
                    gdvInboxMembershipCurr.Visible = false;
                    gdvBillCurr.Visible = true;
                    gdvInboxMembership.Visible = false;
                }
            }
            else
            {
                gblObj.MsgBoxOk("Select data!", this);
            }
        }
    }
    private Boolean MandatoryFilled(int flgSelection)
    {
        Boolean flgSel = false;
        if (flgSelection == 1)
        {
            if (txtDt.Text == null || txtDt.Text == "" || txtNo.Text == null || txtNo.Text == "")
            {
                flgSel = false;
            }
            else if ((txtDt.Text == null && txtDt.Text == "") && (txtNo.Text != null || txtNo.Text == ""))
            {
                flgSel = true;
            }
            //else if ((txtDt.Text != null || txtDt.Text != "") && (txtNo.Text == null || txtNo.Text == ""))
            //{
            //    flgSel = true;
            //}
            else //if ((txtDt.Text != null || txtDt.Text != "") && (txtNo.Text != null || txtNo.Text != ""))
            {
                flgSel = true;
            }
        }
        else if (flgSelection == 2)
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) > 0 && Convert.ToInt16(Session["IntMonthSearchChal"]) > 0 && Convert.ToInt16(Session["intLBIdSearchChal"]) > 0)
            {
                flgSel = true;
            }
        }
        else if (flgSelection == 3)
        {
            if (Convert.ToInt16(Session["IntYearSearchChal"]) > 0 && Convert.ToInt16(Session["IntMonthSearchChal"]) > 0 && Convert.ToInt16(Session["intTreasuryIDSearchChal"]) > 0)
            {
                flgSel = true;
            }
        }
        return flgSel;
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetRdCategory();
        SetGridDefault(gdvInboxMembership);
        SetGridDefault(gdvInboxMembershipCurr);
        SetGridDefaultBill(gdvBill);
        SetGridDefaultBill(gdvBillCurr);
    }
    private void SetGridDefault(GridView gdv)
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("chvName");
        ar.Add("chvEngDistName");
        ar.Add("numChalanId");
        ar.Add("flgApproval");
        ar.Add("flgPrevYear");
        ar.Add("intGroupId");
        ar.Add("PerYearId");
        ar.Add("PerMonthId");
        ar.Add("intDistID");
        ar.Add("PDEYear");
        ar.Add("chvApproval");
        gblObj.SetGridDefault(gdv, ar);
        gdv.Enabled = false;
    }
    private void SetGridDefaultBill(GridView gdv)
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("BillDet");
        ar.Add("fltNetAmt");
        ar.Add("chvTreasuryName");

        ar.Add("intBillWiseId");
        ar.Add("flgApproval");


        gblObj.SetGridDefault(gdv, ar);
        gdv.Enabled = false;
    }
    private void SetTxtsDefault()
    {
        txtDt.Text = "";
        txtNo.Text = "";
        Session["StrChalDt"] = "";
        Session["IntChalNo"] = 0;
    }
    private void SetRdCategory()
    {
        if (rdCategory.Items[0].Selected == true)
        {
            //Session["flgFilterMode"] = 1;
            Session["flgFilterMode"] = 1;
            pnlNo.Visible = true;
            pnlLb.Visible = false;
            pnlTreas.Visible = false;
            txtDt.Text = "";
            txtNo.Text = "";
            //gdvInboxMembership.HeaderRow.Cells[3].Text = "Localbody";
            //FillDdls(3);
        }
        else if (rdCategory.Items[1].Selected == true)
        {
            //Session["flgFilterMode"] = 2;
            Session["flgFilterMode"] = 2;
            pnlNo.Visible = false;
            pnlLb.Visible = true;
            pnlTreas.Visible = false;
            //gdvInboxMembership.HeaderRow.Cells[3].Text = "Treasury";
            FillDdls(1);
        }
        else if (rdCategory.Items[2].Selected == true)
        {
            //Session["flgFilterMode"] = 3;
            Session["flgFilterMode"] = 3;
            pnlNo.Visible = false;
            pnlLb.Visible = false;
            pnlTreas.Visible = true;
            //gdvInboxMembership.HeaderRow.Cells[3].Text = "Localbody";
            FillDdls(2);
        }
    }
    protected void ddlLb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlLb.SelectedValue) > 0)
        {
            Session["intLBIDSearchChal"] = Convert.ToInt16(ddlLb.SelectedValue);
        }
        else
        {
            Session["intLBIDSearchChal"] = 0;
        }
        //FillGrid(2);
    }
    private void FillGridBill(int type, GridView gdv)
    {

        DataSet ds = new DataSet();
        string hdrInst = "";
        if (type == 3)      //Treasury
        {
            if (Convert.ToInt16(ddlYearT.SelectedValue) > 0 && Convert.ToInt16(ddlMonthT.SelectedValue) > 0 && Convert.ToInt16(ddlDistrictT.SelectedValue) > 0 && Convert.ToInt16(ddlTreas.SelectedValue) > 0)
            {
                //ar.Add(Convert.ToInt16(ddlYearT.SelectedValue));
                //ar.Add(Convert.ToInt16(ddlMonthT.SelectedValue));
                //ar.Add(Convert.ToInt16(ddlTreas.SelectedValue));
                //hdrInst = "Treasury";

                blpde.IntYearId = Convert.ToInt16(ddlYearT.SelectedValue);
                blpde.IntMonthId = Convert.ToInt16(ddlMonthT.SelectedValue);
                blpde.IntDTreasuryId = Convert.ToInt16(ddlTreas.SelectedValue);
                hdrInst = "Treasury";
                ds = blPdeD.GetBillPdeDet2(blpde);
            }

        }

        else if (type == 1)     //Chal No and Date
        {
            if (txtDt.Text != "" || txtDt.Text != null || Convert.ToInt16(txtNo.Text) != 0 || txtNo.Text != null)
            {
                AssignValsForRtnBack();
                int flg = 0;
                if ((txtDt.Text == null || txtDt.Text.Trim() == "") && Convert.ToInt16(txtNo.Text) > 0)
                {
                    //flg = 1;
                    //ar.Add(Convert.ToInt16(txtNo.Text));
                    //ar.Add(0);
                    blpde.IntBillNo = Convert.ToInt16(txtNo.Text);
                    blpde.DtmBill = "0";
                    blpde.IntSearchType = 1;
                    ds = blPdeD.GetBillPdeDet2(blpde);
                }
                else if ((txtNo.Text == null || txtNo.Text.Trim() == "") && txtDt.Text.ToString() != "")
                {
                    //flg = 2;
                    //ar.Add(0);
                    //ar.Add(txtDt.Text.ToString());
                    blpde.IntBillNo = 0;
                    blpde.DtmBill = txtDt.Text.ToString();
                    blpde.IntSearchType = 2;
                    ds = blPdeD.GetBillPdeDet2(blpde);
                }
                else if (txtDt.Text != "" && txtNo.Text != "")
                {
                    //flg = 3;
                    //ar.Add(Convert.ToInt16(txtNo.Text));
                    //ar.Add(txtDt.Text.ToString());
                    blpde.IntBillNo = Convert.ToInt16(txtNo.Text);
                    blpde.DtmBill = txtDt.Text.ToString();
                    blpde.IntSearchType = 3;
                    ds = blPdeD.GetBillPdeDet1(blpde);
                }
            }
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdv.DataSource = ds;
            gdv.DataBind();
            gblObj.SetFooterTotals(gdv, 2);

            gdv.HeaderRow.Cells[3].Text = hdrInst;
            gdv.Enabled = true;
        }
        else
        {
            SetGridDefaultBill(gdvBillCurr);
        }

    }

    private void FillGrid(int type, GridView gdv)
    {

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        string hdrInst = "";
        if (type == 3)      //Treasury
        {
            if (Convert.ToInt16(ddlYearT.SelectedValue) > 0 && Convert.ToInt16(ddlMonthT.SelectedValue) > 0 && Convert.ToInt16(ddlDistrictT.SelectedValue) > 0 && Convert.ToInt16(ddlTreas.SelectedValue) > 0)
            {
                ar.Add(Convert.ToInt16(ddlYearT.SelectedValue));
                ar.Add(Convert.ToInt16(ddlMonthT.SelectedValue));
                ar.Add(Convert.ToInt16(ddlTreas.SelectedValue));
                hdrInst = "Treasury";
            }
        }
        else if (type == 2)     //LB
        {
            if (Convert.ToInt16(ddlYear.SelectedValue) > 0 && Convert.ToInt16(ddlMonth.SelectedValue) > 0 && Convert.ToInt16(ddlDistrict.SelectedValue) > 0 && Convert.ToInt16(ddlLb.SelectedValue) > 0)
            {
                ar.Add(Convert.ToInt16(ddlYear.SelectedValue));
                ar.Add(Convert.ToInt16(ddlMonth.SelectedValue));
                ar.Add(Convert.ToInt16(ddlLb.SelectedValue));
                //ds = chalDao.GetChalanSearch(ar, 2);
                hdrInst = "Localbody";
            }
        }
        else if (type == 1)     //Chal No and Date
        {
            if (txtDt.Text != "" || txtDt.Text != null || Convert.ToInt32(txtNo.Text) != 0 || txtNo.Text != null)
            {
                AssignValsForRtnBack();
                int flg = 0;
                if ((txtDt.Text == null || txtDt.Text.Trim() == "") && Convert.ToInt32(txtNo.Text) > 0)
                {
                    flg = 1;
                    ar.Add(Convert.ToInt16(txtNo.Text));
                    ar.Add(0);
                }
                else if ((txtNo.Text == null || txtNo.Text.Trim() == "") && txtDt.Text.ToString() != "")
                {
                    flg = 2;
                    ar.Add(0);
                    ar.Add(txtDt.Text.ToString());
                }
                else if (txtDt.Text != "" && txtNo.Text != "")
                {
                    flg = 3;
                    ar.Add(Convert.ToInt32(txtNo.Text));
                    ar.Add(txtDt.Text.ToString());
                }
                //ar.Add(Convert.ToInt16(txtNo.Text));
                //ar.Add(txtDt.Text.ToString());
                ar.Add(flg);
                hdrInst = "Localbody";
            }
        }
        ds = chalDao.GetChalanSearch(ar, Convert.ToInt16(Session["flgFilterMode"]));
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdv.DataSource = ds;
            gdv.DataBind();
            gblObj.SetFooterTotals(gdv, 2);

            gdv.HeaderRow.Cells[3].Text = hdrInst;
            gdv.Enabled = true;

            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                Label lblYearAss = (Label)gvr.FindControl("lblYear");
                Label lblMonthAss = (Label)gvr.FindControl("lblMonth");
                Label lblDistAss = (Label)gvr.FindControl("lblDist");
                Label txtNumTrnId = (Label)gvr.FindControl("txtNumTrnId");

                lblYearAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                lblMonthAss.Text = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                lblDistAss.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                txtNumTrnId.Text = Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[0]).ToString();
                if (ds.Tables[0].Rows[i].ItemArray[13].ToString() == "AG")
                {
                    gdv.Rows[i].Cells[11].ToolTip = FindTEDet(Convert.ToInt64(txtNumTrnId.Text), Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[9]));
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("No data!", this);
            SetGridDefault(gdv);
        }

    }
    private string FindTEDet(Int64 numChalId, Int16 intYr)
    {

        string str = "";
        DataSet dsC = new DataSet();
        ArrayList arC = new ArrayList();
        arC.Add(numChalId);
        arC.Add(intYr);
        dsC = chalDao.FindChalanTEDet(arC);
        if (dsC.Tables[0].Rows.Count > 0)
        {
            str = dsC.Tables[0].Rows[0].ItemArray[0].ToString() + dsC.Tables[0].Rows[0].ItemArray[1].ToString();
        }

        return str;
    }
    private void AssignValsForRtnBack()
    {
        if (txtDt.Text != "" && txtDt.Text != null)
        {
            Session["StrChalDt"] = txtDt.Text.ToString();
        }
        else
        {
            Session["StrChalDt"] = null;
        }
        if (txtNo.Text != "" && txtNo.Text != null)
        {
            Session["IntChalNo"] = Convert.ToInt32(txtNo.Text.ToString());
        }
        else
        {
            Session["IntChalNo"] = null;
        }
    }
    protected void ddlDistrictT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistrictT.SelectedValue) > 0)
        {
            Session["IntDistSearchChal"] = Convert.ToInt16(ddlDistrictT.SelectedValue);
            FillTreas();
        }
        else
        {
            Session["IntDistSearchChal"] = 0;
        }
    }
    protected void ddlYearT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYearT.SelectedValue) > 0)
        {
            Session["IntYearSearchChal"] = Convert.ToInt16(ddlYearT.SelectedValue);
        }
        else
        {
            Session["IntYearSearchChal"] = 0;
        }
        SetGridDefault(gdvInboxMembership);
    }
    protected void ddlMonthT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonthT.SelectedValue) > 0)
        {
            Session["IntMonthSearchChal"] = Convert.ToInt16(ddlMonthT.SelectedValue);
        }
        else
        {
            Session["IntMonthSearchChal"] = 0;
        }
        SetGridDefault(gdvInboxMembership);
    }
    protected void txtDt_TextChanged(object sender, EventArgs e)
    {
        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        if (gblObj.isValidDate(txtDt, this) == true)
        {
            if (gblObj.CheckDate2(dt2, dt1) == true)
            {
                if (gblObj.CheckDate2(dt1, dt3) == true)
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(txtDt.Text.ToString());
                    Session["IntYearSearchChal"] = kgen.FindYearIdFromDate(ar);
                }
                else
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtDt.Text = "";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtDt.Text = "";
        }

    }
}
