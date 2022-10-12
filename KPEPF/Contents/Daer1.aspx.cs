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
using System.Collections.Generic;
using KPEPFClassLibrary;

public partial class Contents_Daer1 : System.Web.UI.Page
{

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    TEDAO teDAO;
    ChalanPDEAGDAO ChalAGDao;
    Chalan chl;
    ChalanDAO chDao;
    ScheduleDAO schDao;
    CorrectionEntry cor;
    CorrectionEntryDao cord;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToDouble(Session["numChalanIdEdit"]) > 0)
            {
                ViewGrid();
                ShowCRPlus();
                SetCtrls();
                if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
                {
                    lblTot.Text = "Credit Plus  " + Session["dblAmtDaerCr"].ToString();
                }
                else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
                {
                    lblTot.Text = "Credit Plus  " + Session["dblAmtOAOCr"].ToString();
                }
                lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            btnwithdocs.Enabled = true;
            txtCnt.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            btnwithdocs.Enabled = false;
            txtCnt.Enabled = false;
        }
        if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
        {
            lblHead.Text = "DAER_Credit";
            lbl11.Text = "DAER Plus ";
            lblTotET.Text = "DAER Entered";
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
        {
            lblHead.Text = "OAO_Credit";
            lbl11.Text = "OAO Plus ";
            lblTotET.Text = "OAO Entered";
        }

    }
    private void SetCtrlsEnable()
    {
        SetWithDocsGridEnable();

    }
    private void SetCtrlsDisable()
    {
        SetWithDocsGridDisable();
        //gdvCPW.Enabled = false;

    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = false;
            txtTeCPWAss.Enabled = true;

            TextBox txtchnoAss = (TextBox)gdvrow.FindControl("txtchno");
            txtchnoAss.ReadOnly = false;
            txtchnoAss.Enabled = true;


            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = false;
            txtChlnDtCPWAss.Enabled = true;


            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = false;
            txtChlAmtCPWAss.Enabled = true;


            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = true;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = true;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = true;


            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chlUnpostCPW");
            chkUnpostCPWAss.Enabled = true;

            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = true;

            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = true;


            TextBox txtRemarksAss = (TextBox)gdvrow.FindControl("txtRemarks");
            txtRemarksAss.ReadOnly = false;
            txtRemarksAss.Enabled = true;

            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = true;

            //DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            //ddlStatusAss.Enabled = true;

            //Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
            //lblintIdAss.ReadOnly = false;
            //lblintIdAss.Enabled = true;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = true;


            //TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            //txtChlAmtCPWAss.ReadOnly = false;
            //txtChlAmtCPWAss.Enabled = true;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = false;
            //RelMnthAss.Enabled = true;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = false;
            //RelYearIdAss.Enabled = true;

        }
    }
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = true;
            txtTeCPWAss.Enabled = false;

            TextBox txtchnoAss = (TextBox)gdvrow.FindControl("txtchno");
            txtchnoAss.ReadOnly = true;
            txtchnoAss.Enabled = false;


            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = true;
            txtChlnDtCPWAss.Enabled = false;


            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = true;
            txtChlAmtCPWAss.Enabled = false;


            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = false;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = false;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = false;


            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chlUnpostCPW");
            chkUnpostCPWAss.Enabled = false;

            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = false;

            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = false;


            TextBox txtRemarksAss = (TextBox)gdvrow.FindControl("txtRemarks");
            txtRemarksAss.ReadOnly = true;
            txtRemarksAss.Enabled = false;

            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = false;



        }
    }
    private void ViewGrid()
    {
        //gblobj.SetRowsCnt(gdvBT, 1);
        //gblobj.SetRowsCnt(gdvCPW, 1);
        //gblobj.SetRowsCnt(gdvCPWO, 1);
        //gblobj.SetBlankRow(gdvBT);
        SetGridDefault();

        //SetGridDefaultWOD();
        //gblobj.SetBlankRow(gdvCPWO);
    }
    private void SetGridDefault()
    {
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intChalanNo");
        ar.Add("numChalanId");
        ar.Add("intGroupId");
        ar.Add("flgPrevYear");
        ar.Add("flgApproval");
        gblobj.SetGridDefault(gdvCPW, ar);
    }

    public void fillGridcombos(GridView gdv)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);

        }
        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlDistAss = (DropDownList)grdVwRow.FindControl("ddlDist");
            gblobj.FillCombo(ddlDistAss, dsdist, 1);

        }
        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {

            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);

        }


        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);


        }
        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlreasonAs = (DropDownList)grdVwRow.FindControl("ddlreason");
            gblobj.FillCombo(ddlreasonAs, dsM, 1);


        }

    }

    public void fillGridcomboswithoutDocs(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreasuryCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);

        }

        //DataSet dslb = new DataSet();
        //dslb = teDAO.GetLB();
        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{
        //    GridViewRow grdVwRow = gdv.Rows[i];
        //    DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
        //    gblobj.FillCombo(ddlLBAss, dslb, 1);

        //}
        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);
        }
    }
    public void fillCombo()
    {
        //    ArrayList ArrIn = new ArrayList();
        //    ArrIn.Add(1);
        //    DataSet ds = new DataSet();
        //    ds = teDAO.GetTrntype(ArrIn);
        //    gblobj.FillCombo(ddlTrnType, ds, 1);
    }
    private void InitialSettings()
    {
        Session["flgPageBack"] = 7;
        //lblTot.Text = "Credit Plus";
        ViewGrid();

        fillGridcombos(gdvCPW);
        //fillGridcomboswithoutDocs(gdvCPWO);

        ShowCRPlus();
        SetCtrls();

        FillHeadLbls();
    }
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        //lblTot.Text = Session["dblAmtDaerCr"].ToString();
        if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
        {
            lblTot.Text = Session["dblAmtDaerCr"].ToString();
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
        {
            lblTot.Text = Session["dblAmtOAOCr"].ToString();
        }
        //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) );
        //lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    public void ShowCRPlus()
    {
        gblobj = new clsGlobalMethods();
        ChalAGDao = new ChalanPDEAGDAO();
        chDao = new ChalanDAO();
        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt64(Session["IntAGId"]));
        if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
        {
            arr.Add(6);
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
        {
            arr.Add(7);
        }
        dscrplus = chDao.FillCrPlus(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCPW.DataSource = dscrplus;
            gdvCPW.DataBind();
            fillGridcombos(gdvCPW);
            int count = gdvCPW.Rows.Count;
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCPW.Rows[i];
                TextBox txtTeCPWAss = (TextBox)gdv.FindControl("txtTeCPW");
                txtTeCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtChNoCPWAss = (TextBox)gdv.FindControl("txtchno");
                txtChNoCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtChlnDtCPWAss = (TextBox)gdv.FindControl("txtChlnDtCPW");
                txtChlnDtCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtChlAmtCPWAss = (TextBox)gdv.FindControl("txtChlAmtCPW");
                txtChlAmtCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();

                DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
                ddlTreCPWOAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                DropDownList ddlDistAss = (DropDownList)gdv.FindControl("ddlDist");
                ddlDistAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[6].ToString();

                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                ddlLBAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtRsnCPWAss = (TextBox)gdv.FindControl("txtRemarks");
                txtRsnCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

                Label lblintIdWthAss = (Label)gdv.FindControl("lblintIdWth");
                lblintIdWthAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[10].ToString();

                CheckBox chlUnpostCPW = (CheckBox)gdv.FindControl("chlUnpostCPW");
                if (Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[14]) == 2)
                {
                    chlUnpostCPW.Checked = true;
                    DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");
                    ddlreasonAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();
                }
                else
                {
                    chlUnpostCPW.Checked = false;
                }

                Label lblYearId = (Label)gdv.FindControl("lblYearId");
                lblYearId.Text = dscrplus.Tables[0].Rows[i].ItemArray[16].ToString();
                Label lblMnth = (Label)gdv.FindControl("lblMnth");
                lblMnth.Text = dscrplus.Tables[0].Rows[i].ItemArray[17].ToString();
                Label lblDay = (Label)gdv.FindControl("lblDay");
                lblDay.Text = dscrplus.Tables[0].Rows[i].ItemArray[18].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
            if (Convert.ToDouble(gdvCPW.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWCP.Text = gdvCPW.FooterRow.Cells[4].Text.ToString();
                ArrayList ar = new ArrayList();
                DataSet dsS = new DataSet();
                ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                dsS = ChalAGDao.GetScheduleTotal(ar);
                if (dsS.Tables[0].Rows.Count > 0)
                {
                    //lblAmtSch.Text = dsS.Tables[0].Rows[0].ItemArray[2].ToString();
                }
            }
            else
            {
                lblAmtWCP.Text = "0";
            }

        }
        else
        {
            lblAmtWCP.Text = "0";
            fillGridcombos(gdvCPW);
            SetGridDefault();
        }
        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    public void Savechalan()
    {
        //DataSet ds = new DataSet();
        //ArrayList ar = new ArrayList();
        //chal.PerMonthId = Convert.ToInt32(ddlTreCPW.SelectedValue);

    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        DropDownList ddlDistAss = (DropDownList)gvr.FindControl("ddlDist");
        DropDownList ddlTreasuryCPWO = (DropDownList)gvr.FindControl("ddlTreCPWO");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");

        if (Convert.ToInt16(ddlDistAss.SelectedValue) > 0)
        {
            Session["intDist"] = Convert.ToInt16(ddlDistAss.SelectedValue);
            FillLbDtWiseWithdocs(Convert.ToInt16(Session["intDist"]), ddlLBAss);
            FillTreasDtWise(Convert.ToInt16(Session["intDist"]), ddlTreasuryCPWO);
        }
        else
        {
            Session["intDist"] = 0;
        }

    }


    private void FillLbDtWiseWithdocs(int LBID, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intDist"]));
        //ar.Add(5);
        DataSet dslb = new DataSet();
        //dslb = gendao.GetLB(ar);
        dslb = gendao.GetLBGp(ar);
        
        gblobj.FillCombo(ddlLBAss, dslb, 1);
    }
    private void FillTreasDtWise(int TresId, DropDownList ddlTreasuryCPWO)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList art = new ArrayList();
        art.Add(Convert.ToInt16(Session["intDist"]));
        DataSet dst = new DataSet();
        dst = gendao.GetTreasury(art);
        gblobj.FillCombo(ddlTreasuryCPWO, dst, 1);

    }
    private int FindSlNo()
    {
        int slno = 1;
        return slno;
    }
    public void fillLB()
    {

    }
    protected void ddlLB_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnwithdocs_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        // lblAmtWOCP.Text = Convert.ToString(gdvCPWO.FooterRow.Cells[4].Text);
        lblAmtWCP.Text = Convert.ToString(gdvCPW.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

    }
    public void SaveWithDocs()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        chl = new Chalan();
        chDao = new ChalanDAO();
        int cnt = 0;
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvCPW.Rows[i];
            DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
            DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
            TextBox txtChNoCPWAss = (TextBox)gdvrw.FindControl("txtchno");
            TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
            TextBox txtRemarksAss = (TextBox)gdvrw.FindControl("txtRemarks");
            CheckBox chkUnpostCPW = (CheckBox)gdvrw.FindControl("chlUnpostCPW");
            DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
            TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
            TextBox txtTeCPWAss = (TextBox)gdvrw.FindControl("txtTeCPW");
            Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWth");

            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDtCPWAss.Text.ToString());

            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            if (MandatoryFldsWithDocs(i) == true)
            {
                if (lblintIdWthAss.Text == "")
                {
                    chl.NumChalanId = 0;
                }
                else
                {
                    chl.NumChalanId = Convert.ToInt32(lblintIdWthAss.Text);
                }
                chl.IntTreasuryId = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
                chl.IntLBId = Convert.ToInt32(ddlLBAss.SelectedValue);
                chl.IntChalanNo = Convert.ToInt32(txtChNoCPWAss.Text);
                chl.DtChalanDate = txtChlnDtCPWAss.Text.ToString();
                chl.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
                chl.YearId = genDAO.gFunFindYearIdFromDate(ardt);
                chl.MonthId = Convert.ToDateTime(txtChlnDtCPWAss.Text).Month;
                chl.PerYearId = Convert.ToInt32(Session["intYearAGCurr"]);
                chl.PerMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);
                chl.ChvRemarks = txtRemarksAss.Text;
                chl.IntUserId = Convert.ToInt32(Session["intUserId"]);
                if (chkUnpostCPW.Checked == true)
                {
                    chl.FlgUnposted = 2;
                }
                else
                {
                    chl.FlgUnposted = 1;
                }
                if (ddlreasonAss.SelectedIndex > 0)
                {
                    chl.IntUnPostedRsn = Convert.ToInt32(ddlreasonAss.SelectedValue);
                }
                else
                {
                    chl.IntUnPostedRsn = 0;
                }
                chl.IntSlNo = FindSlNo();
                chl.FlgSource = 2;
                chl.IntDay = Convert.ToDateTime(txtChlnDtCPWAss.Text).Day;
                chl.IntSthapnaBillID = 0;
                chl.FlgAmtMismatch = 2;
                if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
                {
                    chl.FlgChalanType = 6;
                }
                else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
                {
                    chl.FlgChalanType = 7;
                }
                chl.tENo = Convert.ToInt16(txtTeCPWAss.Text);
                chl.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
                ds = chDao.CreateChalan(chl);

                Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
                ////////////// Correction  ////////////////
                if (Convert.ToInt16(lblEditId.Text) > 0)
                {
                    Label oldYear = (Label)gdvrw.FindControl("lblYearId");
                    Label oldMnth = (Label)gdvrw.FindControl("lblMnth");
                    Label oldDay = (Label)gdvrw.FindControl("lblDay");

                    int yr1 = Convert.ToInt16(oldYear.Text);
                    int mth1 = Convert.ToInt16(oldMnth.Text);
                    int intDy1 = Convert.ToInt16(oldDay.Text);

                    int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                    int mth2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Month;
                    int intDy2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Day;

                    SaveCorrectionEntryChal(Convert.ToInt32(lblintIdWthAss.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, intDy1, yr2, mth2, intDy2);
                }

            }
            else
            {
                cnt = cnt + 1;
            }
        }
        if (cnt > 0)
        {
            gblobj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            gblobj.MsgBoxOk("Saved successfully", this);
            ShowCRPlus();
        }       
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int inyDy1, int yr2, int mth2, int inyDy2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        schDao = new ScheduleDAO();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        dsChal = schDao.CheckScheduleExist(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[12]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[7]);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpdLat(yr1, yr2, Convert.ToInt16(Session["intCCYearId"]), mth1, mth2, inyDy1, inyDy2, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr2;
            cor.IntMonthID = mth2;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[7]);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[14]);
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            cor.IntChalanType = 4;
            cor.IntTblTp = 2;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    private Boolean CheckMandatory(DropDownList ddltreas, DropDownList ddlLb, TextBox txt)
    {
        gblobj = new clsGlobalMethods();

        Boolean flg = true;
        if (ddltreas.SelectedValue == "0" || ddltreas.SelectedValue == "" || ddlLb.SelectedValue == "0" || ddlLb.SelectedValue == "" || txt.Text.ToString() == "" || txt.Text.ToString() == "0")
        {
            gblobj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private Boolean MandatoryFldsWithDocs(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvCPW.Rows[i];
        TextBox txtChNoCPWAss = (TextBox)gdv.FindControl("txtchno");
        TextBox txtChlnDtCPWAss = (TextBox)gdv.FindControl("txtChlnDtCPW");
        TextBox txtChlAmtCPWAss = (TextBox)gdv.FindControl("txtChlAmtCPW");
        DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
        DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
        TextBox txtTeCPW = (TextBox)gdv.FindControl("txtTeCPW");

        if (txtChlnDtCPWAss.Text == null || txtChlnDtCPWAss.Text == "" || txtChNoCPWAss.Text == null || txtChNoCPWAss.Text == "" || txtTeCPW.Text == null || txtTeCPW.Text == "")
        {
            flg = false;
        }
        else if (txtChlAmtCPWAss.Text == null || txtChlAmtCPWAss.Text == "")
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlTreCPWOAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        if (ViewState["Withdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withdoc"];
            int count = gdvCPW.Rows.Count;
            //DropDownList drp1 = (DropDownList)gdvCPW.Rows[count - 1].Cells[5].FindControl("ddlTreCPWO");
            //DropDownList drp2 = (DropDownList)gdvCPW.Rows[count - 1].Cells[6].FindControl("ddlDist");
            //DropDownList drp3 = (DropDownList)gdvCPW.Rows[count - 1].Cells[7].FindControl("ddlLB");
            //if (drp1.SelectedIndex == 0)
            //{
            //   // ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Data');", true);
            //    objClass.setFocus(drp1, this);
            //}
            //else
            //{
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtTeCPW");
            arrIN.Add("txtChNoCPW");
            arrIN.Add("txtChlnDtCPW");
            arrIN.Add("txtChlAmtCPW");
            arrIN.Add("ddlTreCPWO");
            arrIN.Add("ddlDist");
            arrIN.Add("ddlLB");
            arrIN.Add("chlUnpostCPW");
            arrIN.Add("ddlStusCPW");
            arrIN.Add("Button1");
            dt = gblobj.AddNewRowToGrid(dt, gdvCPW, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvCPW.Rows[count].FindControl("ddlTreCPWO");
            DropDownList drpnewDist = (DropDownList)gdvCPW.Rows[count].FindControl("ddlDist");
            DropDownList drpnewLB = (DropDownList)gdvCPW.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            //}
            fillGridcombos(gdvCPW);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvCPW.Rows[i].FindControl("ddlTreCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();
                DropDownList drpDist = (DropDownList)gdvCPW.Rows[i].FindControl("ddlDist");
                drpDist.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
                DropDownList drpLB = (DropDownList)gdvCPW.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[7].ToString();
            }
        }
    }
    protected void gdvCPW_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBckCP_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGstatementsPDE.aspx");
    }
    protected void btnClsCP_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");
    }
    protected void txtChlnDtCPW_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtChlnDtCPW");

        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label oldDay = (Label)gvr.FindControl("lblDay");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");
        DateTime dtm;
        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
                if (gblobj.CheckChalanDateAg(txtDt, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    if (Convert.ToInt16(oldYear.Text) > 0)
                    {
                        dtm = Convert.ToDateTime(txtDt.Text);
                        ardt.Add(txtDt.Text);
                        int yrnw = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                        int mthnw = dtm.Month;
                        int dynw = dtm.Day;
                        if (yrnw < Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "1";
                        }
                        else if (yrnw > Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "2";
                        }
                        else
                        {
                            if (genDAO.getMonthIdCalYear(mthnw) < genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "1";
                            }
                            else if (genDAO.getMonthIdCalYear(mthnw) > genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "2";
                            }
                            else
                            {
                                if (dynw <= 4 && Convert.ToInt16(oldDay.Text) > 4)
                                {
                                    lblEditId.Text = "1";
                                }
                                else
                                {
                                    if (dynw > 4 && Convert.ToInt16(oldDay.Text) <= 4)
                                    {
                                        lblEditId.Text = "2";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lblEditId.Text = "0";
                    }
                }

            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
            //if (gblobj.CheckDate2(dt2, dt1) == true)
            //{
            //    if (gblobj.CheckDate2(dt1, dt3) == true)
            //    {
            //        ArrayList ar = new ArrayList();
            //        ar.Add(txtDt.Text.ToString());
            //        Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);
            //    }
            //    else
            //    {
            //        gblobj.MsgBoxOk("Invalid Date", this);
            //        txtDt.Text = "";
            //    }
            //}
            //else
            //{
            //    gblobj.MsgBoxOk("Invalid Date", this);
            //    txtDt.Text = "";
            //}
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtDt.Text = "";
        }
    }
    protected void txtFrmAcCPBT_TextChanged(object sender, EventArgs e)
    {

    }

    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        // myControls.Add(new DropDownList());
        myControls.Add(new Label());

        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("lblintIdWtht");

        arrControlid.Add("txtChlnCPWO");
        arrControlid.Add("txtChlnDateCPWO");
        arrControlid.Add("txtAmtCPWO");
        arrControlid.Add("ddlTreasuryCPWO");
        arrControlid.Add("ddlLB");
        arrControlid.Add("txtRemCPWO");
        arrControlid.Add("txtteCPWO");

        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();

        arrControlid.Add("intId");

        arrControlid.Add("intChalNo");
        arrControlid.Add("dtmChalDt");
        arrControlid.Add("fltAmt");
        arrControlid.Add("intTreasID");
        arrControlid.Add("intLBID");

        arrControlid.Add("chvDetails");
        arrControlid.Add("chvTEId");

        return arrControlid;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatements.aspx";
    }
    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        chDao = new ChalanDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlTreCPWO");
            arDdl.Add("ddlDist");
            arDdl.Add("ddlLB");
            arDdl.Add("ddlStatus");
            arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDs.Add(dstreas);

            DataSet dsdist = new DataSet();
            dsdist = teDAO.GetDist();
            arDdlDs.Add(dsdist);

            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDs.Add(dslb);

            DataSet dsstatus = new DataSet();
            dsstatus = teDAO.GetStatus();
            arDdlDs.Add(dsstatus);

            DataSet dsM = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(1);
            dsM = gendao.GetMisClassRsn(arrIn);
            arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dscrplus = new DataSet();
            ArrayList arr = new ArrayList();
            //if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
            //{
            //    arr.Add(6);
            //}
            //else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
            //{
            //    arr.Add(7);
            //}
            //arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            //arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));

            arr.Add(Convert.ToInt32(Session["IntAGId"]));
            if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
            {
                arr.Add(6);
            }
            else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
            {
                arr.Add(7);
            }
            dscrplus = chDao.FillCrPlusBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("numChalanId");
            arHp.Add("flgApproval");
            arHp.Add("flgPrevYear");
            arHp.Add("intGroupId");
            arHp.Add("intChalanNo");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCPW, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeCPW");
        arCols.Add("txtchno");
        arCols.Add("txtChlnDtCPW");
        arCols.Add("txtChlAmtCPW");
        arCols.Add("ddlDist");
        arCols.Add("ddlTreCPWO");
        arCols.Add("ddlLB");
        arCols.Add("chlUnpostCPW");
        arCols.Add("ddlreason");
        arCols.Add("ddlStatus");
        arCols.Add("txtRemarks");
        arCols.Add("lblintIdWth");
    }
    protected void chkCollect_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void txtChlAmtCPW_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    private void FillLbDtWise(int TresId, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();

        ArrayList arL = new ArrayList();
        DataSet dsL = new DataSet();

        ar.Add(TresId);
        ds = gendao.GetDistIdfromTreasId(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["IntDistIdTECurr"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            arL.Add(Convert.ToInt32(Session["IntDistIdTECurr"]));
            dsL = gendao.GetLBGp(arL);
            gblobj.FillCombo(ddlLBAss, dsL, 1);
        }
    }


    protected void btnDeleteCrplus_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        chDao = new ChalanDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvCPW.Rows[rowIndex];
        Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWth");
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        ArrayList arrin = new ArrayList();

        arrin.Add(Convert.ToInt32(lblintIdWthAss.Text));
        CorrectionEntryForDel(Convert.ToInt32(lblintIdWthAss.Text), txtChlnDtCPWAss.Text.ToString()); //Corr Entry
        try
        {
            chDao.Chalandelete(arrin);
        }
        catch (Exception ex)
        {
            Session["ERROR"] = ex.ToString();
            Response.Redirect("Error.aspx");
        }
        ShowCRPlus();

        //Build April2022        
        ArrayList procin = new ArrayList();
        procin.Add("Daer1.aspx-btnDeleteCrplus_Click-event-update chalan  (numChalanID is the ID param)");
        procin.Add(Session["intUserId"]);
        procin.Add(Convert.ToInt64(lblintIdWthAss.Text));
        chDao.Processtracking(procin);   
        gblobj.MsgBoxOk("Row Deleted   !", this);
        FillHeadLbls();
    }
    private void CorrectionEntryForDel(float numChalId, string chalDt)
    {
        schDao = new ScheduleDAO();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = schDao.CheckScheduleExist(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[12]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[7].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[7].ToString());
                fltAmtAfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[14].ToString());
                // chlId = Convert.ToInt32(txtchlnId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(chalDt);

                int intMth = dt.Month;
                int intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(chalDt);
                int intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 4);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }
    private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
        ///// Save to CorrEntry/////////
        cor.IntAccNo = intAccNo;
        cor.IntYearID = yr;
        cor.IntMonthID = mth;
        cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        cor.FltAmountBefore = fltAmtBfr;
        cor.FltAmountAfter = fltAmtAfr;
        cor.FltCalcAmount = dblAmtAdjusted;
        cor.FlgCorrected = 1;      //Just added not incorporated in CCard
        cor.IntChalanId = chalId;
        cor.IntSchedId = intSchedId;
        cor.FlgType = 1;           //Remittance
        cor.FltRoundingAmt = 0;
        cor.IntCorrectionType = intCorrTp; //Edit Chal Date
        cor.IntChalanType = ChalType;
        cor.IntTblTp = 2;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
}