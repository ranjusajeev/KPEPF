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

public partial class Contents_TransferEntryCurr : System.Web.UI.Page
{
    public int Trntype = 0;
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    public int chalanAgId;
    int corrType = 0;

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    TEDAO teDAO;
    ChalanPDEAG chlAG;
    ChalanPDEAGDAO ChalAGDao;
    Chalan chl;
    ChalanDAO chDao;
    Missing ms;
    MissingDAO msDao;
    balancetrans bl;
    BalancetransDAO blDAO;
    BalanTrPDE blPDE;
    BalanceTransPDEDao blPDEDao;
    AnnInt ann;
    AnnIntDAO annD;

    CorrectionEntry cor;
    CorrectionEntryDao cord;
    ScheduleDAO schDao;
    ///
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["numChalanId"] != null)
            {
                fillcmbNwChl();
                FillChalanTxts();
            }
            if (Convert.ToDouble(Session["numChalanIdEdit"]) == 5)
            {
                ViewGrid();
                ShowCRPlus();
                ShowWithoutDocs();
                ShowBalanceTransCr();

                SetCtrls();
                lblTot.Text = "Credit Plus  " + Session["dblAmtCrPlus"].ToString();

            }

            else
            {
                InitialSettings();
            }
        }

        //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            btnOkWithouDocs.Enabled = true;
            btnwithdocs.Enabled = true;
            btnOkbal.Enabled = true;
            txtCntWthout.Enabled = true;
            //txtCnt.Enabled = true;
            txtCntBT.Enabled = true;
            lnkChal.Enabled = true;

        }
        else
        {
            SetCtrlsDisable();
            btnOkWithouDocs.Enabled = false;
            btnwithdocs.Enabled = false;
            btnOkbal.Enabled = false;
            txtCntWthout.Enabled = false;
            // txtCnt.Enabled = false;
            txtCntBT.Enabled = false;
            lnkChal.Enabled = false;
        }
    }
    private void SetCtrlsEnable()
    {
        SetWithDocsGridEnable();
        gdvCPWO.Enabled = true;
        gdvBT.Enabled = true;
        txtAnnIntAmt.Enabled = true;
        txtTENo.Enabled = true;
        txtAnnIntRem.Enabled = true;
        btnNewChal.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        SetWithDocsGridDisable();
        gdvCPWO.Enabled = false;
        gdvBT.Enabled = false;
        txtAnnIntAmt.Enabled = false;
        txtTENo.Enabled = false;
        txtAnnIntRem.Enabled = false;
        btnNewChal.Enabled = false;
    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPW.Rows[i];
            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = true;
            gdvrow.Cells[0].Enabled = true;
        }
    }
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPW.Rows[i];
            ImageButton btndeleteCrplus = (ImageButton)gdvrow.FindControl("btndeleteCrplus");
            btndeleteCrplus.Enabled = false;

            gdvrow.Cells[0].Enabled = false;
        }
    }

    private void ViewGrid()
    {
        SetGridDefault();
        SetGridDefaultBT();
        SetGridDefaultWOD();
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
        ar.Add("TENo");
        ar.Add("dtChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("chvRemarks");
        gblobj.SetGridDefault(gdvCPW, ar);
    }
    private void SetGridDefaultBT()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar2 = new ArrayList();
        ar2.Add("SlNo");
        gblobj.SetGridDefault(gdvBT, ar2);
    }
    private void SetGridDefaultWOD()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar1 = new ArrayList();
        ar1.Add("SlNo");
        ar1.Add("chvTEId");
        ar1.Add("intChalNo");
        ar1.Add("dtmChalDt");
        ar1.Add("fltAmt");
        ar1.Add("chvDetails");
        ar1.Add("intId");
        ar1.Add("intTERelMonthWiseId");
        gblobj.SetGridDefault(gdvCPWO, ar1);
    }
    private void InitialSettings()
    {
        Session["flgPageBack"] = 5;
        //lblTot.Text = "Credit Plus";
        ViewGrid();
        ShowCRPlus();
        ShowWithoutDocs();
        ShowBalanceTransCr();
        SetCtrls();
        FillAnnInt();
        FillHeadLbls();
    }
    private void SetlnkAnnInt()
    {
        if (Convert.ToInt16(Session["intMonthAGCurr"]) == 13)
        {
            lnkAnnInt.Visible = true;
        }
        else
        {
            lnkAnnInt.Visible = false;
        }
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

        lblTot.Text = Session["dblAmtCrPlusCurr"].ToString();
        //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        if (Convert.ToInt16(Session["intMonthAGCurr"]) == 13)
        {
            lnkAnnInt.Visible = true;
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        }
        else
        {
            lnkAnnInt.Visible = false;
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
        }
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    public void ShowCRPlus()
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        gendao = new GeneralDAO();
        chDao = new ChalanDAO();

        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["IntAGId"]));
        arr.Add(4);
        dscrplus = chDao.FillCrPlus(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            // txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCPW.DataSource = dscrplus;
            gdvCPW.DataBind();

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

                ////Dist/////
                DropDownList ddlDistAss = (DropDownList)gdv.FindControl("ddlDist");
                DataSet dsdist = new DataSet();
                dsdist = teDAO.GetDist();
                gblobj.FillCombo(ddlDistAss, dsdist, 1);
                ddlDistAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[6].ToString();
                ////Dist/////

                ////DT/////
                DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
                ArrayList arDist = new ArrayList();
                DataSet dstreas = new DataSet();
                arDist.Add(Convert.ToInt16(ddlDistAss.SelectedValue));
                dstreas = gendao.GetTreasury(arDist);
                gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);
                ddlTreCPWOAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();
                ////DT/////

                ////Lb/////
                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                DataSet dslb = new DataSet();
                //dslb = gendao.GetLBGp(arDist);
                dslb = gendao.GetLBDistwise(arDist);
                
                gblobj.FillCombo(ddlLBAss, dslb, 1);
                ddlLBAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();
                ////Lb/////

                CheckBox chkUnpostCPW = (CheckBox)gdv.FindControl("chlUnpostCPW");
                if (Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[14]) == 2)
                {
                    chkUnpostCPW.Checked = true;
                }
                else
                {
                    chkUnpostCPW.Checked = false;
                }

                ////Reason/////
                DropDownList ddlreason = (DropDownList)gdv.FindControl("ddlreason");
                DataSet dsM = new DataSet();
                ArrayList arrIn = new ArrayList();
                arrIn.Add(1);
                dsM = gendao.GetMisClassRsn(arrIn);
                gblobj.FillCombo(ddlreason, dsM, 1);
                ddlreason.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();
                ////Reason/////

                TextBox txtRsnCPWAss = (TextBox)gdv.FindControl("txtRemarks");
                txtRsnCPWAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

                Label lblintIdWthAss = (Label)gdv.FindControl("lblintIdWth");
                lblintIdWthAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[10].ToString();

                //////////////////////////////
                //Label lblteNoO = (Label)gdv.FindControl("lblteNoO");
                //lblteNoO.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();

                //Label lblchNoO = (Label)gdv.FindControl("lblchNoO");
                //lblchNoO.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                //Label lblchDtO = (Label)gdv.FindControl("lblchDtO");
                //lblchDtO.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();

                //Label lblchAmtO = (Label)gdv.FindControl("lblchAmtO");
                //lblchAmtO.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();

                //Label lbltreO = (Label)gdv.FindControl("lbltreO");
                //lbltreO.Text = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                //Label lbllbO = (Label)gdv.FindControl("lbllbO");
                //lbllbO.Text = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();

                //Label lblunPO = (Label)gdv.FindControl("lblunPO");
                //lblunPO.Text = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();

                //Label lblMd = (Label)gdv.FindControl("lblMd");
                //lblMd.Text = dscrplus.Tables[0].Rows[i].ItemArray[10].ToString();
                /////////////////////////////
                if (Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[14]) == 2 && Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[15]) == 8)
                {
                    //gdvCPW.Columns[7].e
                    gdv.Cells[17].Enabled = false;
                }

                //Label lblYearId = (Label)gdv.FindControl("lblYearId");
                //lblYearId.Text = dscrplus.Tables[0].Rows[i].ItemArray[16].ToString();
                //Label lblMnth = (Label)gdv.FindControl("lblMnth");
                //lblMnth.Text = dscrplus.Tables[0].Rows[i].ItemArray[17].ToString();
                //Label lblDay = (Label)gdv.FindControl("lblDay");
                //lblDay.Text = dscrplus.Tables[0].Rows[i].ItemArray[18].ToString();

            }
            //gblobj.SetFooterTotalsTempField(gdvCPW, 8, "txtChlAmtCPW", 1);
            gblobj.SetFooterTotals(gdvCPW, 7);
            if (Convert.ToDouble(gdvCPW.FooterRow.Cells[7].Text) > 0)
            {
                lblAmtWCP.Text = gdvCPW.FooterRow.Cells[7].Text.ToString();
                //ArrayList ar = new ArrayList();
                //DataSet dsS = new DataSet();
                //ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                //ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                //dsS = ChalAGDao.GetScheduleTotal(ar);
                //if (dsS.Tables[0].Rows.Count > 0)
                //{
                //    //lblAmtSch.Text = dsS.Tables[0].Rows[0].ItemArray[2].ToString();
                //}
            }
            else
            {
                lblAmtWCP.Text = "0";
            }

        }
        else
        {
            lblAmtWCP.Text = "0";
            //fillGridcombos(gdvCPW);
        }
        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }

    public void ShowWithoutDocs()
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        gendao = new GeneralDAO();
        msDao = new MissingDAO();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        SetGridDefaultWOD();
        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        arr.Add(1);
        ds = msDao.FillCrWithoutDocs(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntWthout.Text = ds.Tables[0].Rows.Count.ToString();
            gdvCPWO.DataSource = ds;
            gdvCPWO.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCPWO.Rows[i];
                TextBox txtTeNoCMAss = (TextBox)gdv.FindControl("txtteCPWO");
                txtTeNoCMAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtChNCMAss = (TextBox)gdv.FindControl("txtChlnCPWO");
                txtChNCMAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtChDtCMAss = (TextBox)gdv.FindControl("txtChlnDateCPWO");
                txtChDtCMAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();


                TextBox txtAmtCMAss = (TextBox)gdv.FindControl("txtAmtCPWO");
                txtAmtCMAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();


                ////Treas////////
                DropDownList ddlSubTrCMAss = (DropDownList)gdv.FindControl("ddlTreasuryCPWO");
                DataSet dstreas = new DataSet();
                dstreas = teDAO.GetTreasury();
                gblobj.FillCombo(ddlSubTrCMAss, dstreas, 1);
                ddlSubTrCMAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                ////Treas////////

                ////Lb////////
                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                ArrayList arlb = new ArrayList();
                ArrayList arL = new ArrayList();
                DataSet dsTId = new DataSet();
                DataSet dslb = new DataSet();
                arlb.Add(Convert.ToInt16(ddlSubTrCMAss.SelectedValue));
                dsTId = gendao.GetDistIdfromTreasId(arlb);

                if (dsTId.Tables[0].Rows.Count > 0)
                {
                    Session["IntDistIdTECurr"] = Convert.ToInt16(dsTId.Tables[0].Rows[0].ItemArray[0].ToString());
                    arL.Add(Convert.ToInt32(Session["IntDistIdTECurr"]));
                    dslb = gendao.GetLBDistwise(arL);
                    gblobj.FillCombo(ddlLBAss, dslb, 1);
                    ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                }

                //gblobj.FillCombo(ddlLBAss, dslb, 1);
                //ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                ////Lb////////

                TextBox txtremCMAss = (TextBox)gdv.FindControl("txtRemCPWO");
                txtremCMAss.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString();


                Label lblintIdWthtAss = (Label)gdv.FindControl("lblintIdWtht");
                lblintIdWthtAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
            }
            gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
            if (Convert.ToDouble(gdvCPWO.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWOCP.Text = gdvCPWO.FooterRow.Cells[4].Text.ToString();
            }
            else
            {
                lblAmtWOCP.Text = "0";
            }
        }

        else
        {
            //fillGridcomboswithoutDocs(gdvCPWO);
            lblAmtWOCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
    }
    public void ShowBalanceTransCr()
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        blPDEDao = new BalanceTransPDEDao();

        //DataTable dtBTdoc = gblobj.SetInitialRow(gdvBT);
        //ViewState["BT"] = dtBTdoc;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        ds = blDAO.FillBalancetransCr(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntBT.Text = ds.Tables[0].Rows.Count.ToString();
            gdvBT.DataSource = ds;
            gdvBT.DataBind();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvBT.Rows[i];
                TextBox txtTeNoCPBTAss = (TextBox)gdv.FindControl("txtTeNoCPBT");
                txtTeNoCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtFrmAcCPBTAss = (TextBox)gdv.FindControl("txtFrmAcCPBT");
                txtFrmAcCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtToaccCPBTAss = (TextBox)gdv.FindControl("txtToaccCPBT");
                txtToaccCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                ArrayList arr1 = new ArrayList();
                DataSet dsname = new DataSet();
                arr1.Add(txtToaccCPBTAss.Text);

                dsname = blPDEDao.FillName(arr1);
                if (dsname.Tables[0].Rows.Count > 0)
                {
                    TextBox txttoNameass = (TextBox)gdv.FindControl("txttoName");
                    txttoNameass.Text = dsname.Tables[0].Rows[0].ItemArray[0].ToString();

                    Label lblintAccnoass = (Label)gdv.FindControl("lblAccNo");
                    lblintAccnoass.Text = dsname.Tables[0].Rows[0].ItemArray[1].ToString();

                    txtToaccCPBTAss.Text = dsname.Tables[0].Rows[0].ItemArray[4].ToString();
                }

                TextBox txtAmtCPBTass = (TextBox)gdv.FindControl("txtAmtCPBT");
                txtAmtCPBTass.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtRmkCPBTAss = (TextBox)gdv.FindControl("txtRmkCPBT");
                txtRmkCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                //Label lblAccNo = (Label)gdv.FindControl("lblAccNo");
                //lblAccNo.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                Label lblAccNoNew = (Label)gdv.FindControl("lblAccNoNew");
                lblAccNoNew.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                Label lblAmtOld = (Label)gdv.FindControl("lblAmtOld");
                lblAmtOld.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblintIdbalAss = (Label)gdv.FindControl("lblintIdbal");
                lblintIdbalAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
            }
            gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);

        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
        if (Convert.ToDouble(gdvBT.FooterRow.Cells[6].Text) > 0)
        {
            lblAmtBTCP.Text = gdvBT.FooterRow.Cells[6].Text.ToString();
        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        gdvBT.Columns[10].Visible = false;
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
            //FillLbDtWiseWithdocs(Convert.ToInt16(Session["intDist"]), ddlLBAss);  GetLBGp
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
        DataSet dslb = new DataSet();
        dslb = gendao.GetLBDistwise(ar);
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
    protected void ddlLB_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        DropDownList ddlLB = (DropDownList)gvr.FindControl("ddlLB");
        Label lblMd = (Label)gvr.FindControl("lblMd");
        Label lbllbO = (Label)gvr.FindControl("lbllbO");
        if (Convert.ToInt16(lbllbO.Text) != Convert.ToInt16(ddlLB.SelectedValue))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void btnwithdocs_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        ShowCRPlus();
        lblAmtWCP.Text = Convert.ToString(gdvCPW.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        btnwithdocs.Enabled = false;
    }
    public void SaveWithDocsCollect(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        chl = new Chalan();
        chDao = new ChalanDAO();

        GridViewRow gdvrw = gdvCPWO.Rows[j];
        DropDownList ddlTreasuryCPWO = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        TextBox txtChNoCPWAss = (TextBox)gdvrw.FindControl("txtChlnCPWO");
        TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtAmtCPWO");
        TextBox txtRemarksAss = (TextBox)gdvrw.FindControl("txtRemCPWO");
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
        TextBox txtTeCPWAss = (TextBox)gdvrw.FindControl("txtteCPWO");
        Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWtht");

        ArrayList ardt = new ArrayList();
        ardt.Add(txtChlnDtCPWAss.Text.ToString());

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();

        //if (lblintIdWthAss.Text == "")
        //{
        chl.NumChalanId = 0;
        //}
        //else
        //{
        //    chl.NumChalanId = Convert.ToInt32(lblintIdWthAss.Text);
        //}
        chl.IntTreasuryId = Convert.ToInt32(ddlTreasuryCPWO.SelectedValue);
        chl.IntLBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        chl.IntChalanNo = Convert.ToInt32(txtChNoCPWAss.Text);
        chl.DtChalanDate = txtChlnDtCPWAss.Text.ToString();
        chl.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
        chl.YearId = genDAO.gFunFindYearIdFromDate(ardt);
        chl.MonthId = Convert.ToDateTime(txtChlnDtCPWAss.Text).Month;
        chl.PerYearId = Convert.ToInt16(Session["intYearAGCurr"]);
        chl.PerMonthId = Convert.ToInt16(Session["intMonthAGCurr"]);
        chl.ChvRemarks = txtRemarksAss.Text;
        chl.IntUserId = Convert.ToInt32(Session["intUserId"]);
        chl.FlgUnposted = 1;
        chl.IntUnPostedRsn = 0;
        chl.IntSlNo = FindSlNo();
        chl.FlgSource = 2;
        chl.IntDay = Convert.ToDateTime(txtChlnDtCPWAss.Text).Day;
        chl.IntSthapnaBillID = 0;
        chl.FlgAmtMismatch = 2;
        chl.FlgChalanType = 4;
        if (txtTeCPWAss.Text == "" || txtTeCPWAss.Text == null)
        {
            chl.tENo = 0;
        }
        else
        {
            chl.tENo = Convert.ToInt32(txtTeCPWAss.Text);
        }
        chl.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
        ds = chDao.CreateChalan(chl);
    }
    public void SaveWithDocs()
    {
        genDAO = new KPEPFGeneralDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        chl = new Chalan();
        chDao = new ChalanDAO();
        Session["intCCYearId"] = gendao.GetCCYearId();
        if (Convert.ToDouble(txtChalAmt.Text) > 0)
        {
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChalDt.Text.ToString());

            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();

            if (CheckMandatory(ddlsubTreas, ddlLBNew, txtChalAmt, txtChalNo, txtTeN) == true)
            {
                if (txtchnId.Text == "")
                {
                    chl.NumChalanId = 0;
                }
                else
                {
                    chl.NumChalanId = Convert.ToInt32(txtchnId.Text);
                }
                chl.IntTreasuryId = Convert.ToInt32(ddlsubTreas.SelectedValue);
                chl.IntLBId = Convert.ToInt32(ddlLBNew.SelectedValue);
                chl.IntChalanNo = Convert.ToInt32(txtChalNo.Text);
                chl.DtChalanDate = txtChalDt.Text.ToString();
                chl.FltChalanAmt = Convert.ToDecimal(txtChalAmt.Text);
                chl.YearId = genDAO.gFunFindYearIdFromDate(ardt);
                chl.MonthId = Convert.ToDateTime(txtChalDt.Text).Month;
                chl.PerYearId = genDAO.gFunFindYearIdFromDate(ardt);
                chl.PerMonthId = Convert.ToDateTime(txtChalDt.Text).Month;
                chl.ChvRemarks = txtRm.Text;
                chl.IntUserId = Convert.ToInt32(Session["intUserId"]);

                if (chkUpN.Checked == true)
                {
                    chl.FlgUnposted = 2;
                }
                else
                {
                    chl.FlgUnposted = 1;
                }

                if (ddlRsnN.SelectedIndex > 0)
                {
                    chl.IntUnPostedRsn = Convert.ToInt32(ddlRsnN.SelectedValue);
                }
                else
                {
                    chl.IntUnPostedRsn = 0;
                }
                chl.IntSlNo = FindSlNo();
                chl.FlgSource = 2;
                chl.IntDay = Convert.ToDateTime(txtChalDt.Text).Day;
                chl.IntSthapnaBillID = 0;
                chl.FlgAmtMismatch = 2;
                chl.FlgChalanType = 4;
                if (txtTeN.Text == "" || txtTeN.Text == null)
                {
                    chl.tENo = 0;
                }
                else
                {
                    chl.tENo = Convert.ToInt32(txtTeN.Text);
                }
                chl.IntTreasuryDAGID = Convert.ToInt32(Session["IntAGId"]);
                ds = chDao.CreateChalan(chl);


                ////////////// Correction  ////////////////
                if (Convert.ToInt16(lblEditId.Text) > 0)
                {
                    int yr1 = Convert.ToInt16(lblYearId.Text);
                    int mth1 = Convert.ToInt16(lblMnth.Text);
                    int intDy1 = Convert.ToInt16(lblDy.Text);

                    int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                    int mth2 = Convert.ToDateTime(txtChalDt.Text).Month;
                    int intDy2 = Convert.ToDateTime(txtChalDt.Text).Day;

                    SaveCorrectionEntryChal(Convert.ToInt32(txtchnId.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, intDy1, yr2, mth2, intDy2);
                    ////////////// Correction  ////////////////
                }
                gblobj.MsgBoxOk("Saved!", this);
                Mdlchl.Hide();
            }
            else
            {
                gblobj.MsgBoxOk("Enter all details!", this);
                Mdlchl.Show();
            }
        }

        else
        {
            gblobj.MsgBoxOk("No data", this);
        }
        //Mdlchl.Hide();
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
            //double dblCalcAmt = gblobj.CalculateAmtToCalc(yr, amt);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            //double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
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

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    private void SaveCorrectionEntryChal1(int chalId, int intEditMode, int yr, int mth, int inyDy)
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
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr, amt);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr;
            cor.IntMonthID = mth;
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

    private Boolean CheckMandatory(DropDownList ddltreas, DropDownList ddlLb, TextBox txt, TextBox txtNo, TextBox txtTe)
    {
        gblobj = new clsGlobalMethods();

        Boolean flg = true;
        if (ddltreas.SelectedValue == "0" || ddltreas.SelectedValue == "" || ddlLb.SelectedValue == "0" || ddlLb.SelectedValue == "" || txt.Text.ToString() == "" || txt.Text.ToString() == "0" || txtNo.Text.ToString() == "" || txtNo.Text.ToString() == "0" || txtTe.Text.ToString() == "" || txtTe.Text.ToString() == "0")
        {
            //gblobj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void SaveChalan(int j, int intchalaAGId)
    {
        genDAO = new KPEPFGeneralDAO();
        chlAG = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();

        GridViewRow gdvrw = gdvCPW.Rows[j];
        TextBox txtChalIdAss = (TextBox)gdvrw.FindControl("txtChalId");
        if (txtChalIdAss.Text == "")
        {
            chlAG.ChalanId = 0;
        }
        else
        {
            chlAG.ChalanId = Convert.ToInt32(txtChalIdAss.Text);
        }
        DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntTreasID = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
        }
        else
        {
            chlAG.IntTreasID = 0;
        }
        //chlAG.IntChalanNo = Convert.ToInt32(gdvrw.Cells[2].Text.ToString());
        chlAG.IntChalanNo = 0;
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        if (txtChlnDtCPWAss.Text == "")
        {
            chlAG.DtmChalanDt = "";
        }
        else
        {
            chlAG.DtmChalanDt = txtChlnDtCPWAss.Text.ToString();

            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDtCPWAss.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);

            // ms.IntRelYearId = yrId;

            TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            RelYearIdAss.Text = yrId.ToString();
            chlAG.IntYearID = yrId;
        }
        TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
        if (txtChlAmtCPWAss.Text == "")
        {
            chlAG.FltChalanAmt = 0;
        }
        else
        {
            chlAG.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
        }
        chlAG.IntModeOfChgID = 2;
        chlAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        chlAG.IntChalanAGID = intchalaAGId;
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            chlAG.IntLBID = 0;
        }
        DataSet dschl = new DataSet();

        dschl = ChalAGDao.SaveChalandetailsAG(chlAG);

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
    protected void btnOkWithouDocs_Click(object sender, EventArgs e)
    {
        SaveWithoutDocs();  // Mandatory check and SaveChalan is included in this fn.
        lblAmtWOCP.Text = Convert.ToString(gdvCPWO.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        ShowWithoutDocs();
        ShowCRPlus();
       
    }
    public void SaveWithoutDocs()
    {
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();

        // int cnt = 0;
        if (Convert.ToDouble(gdvCPWO.FooterRow.Cells[4].Text) > 0)
        {
            for (int i = 0; i < gdvCPWO.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvCPWO.Rows[i];
                DataSet ds = new DataSet();
                //if (MandatoryFlds(i) == true)
                //{
                Label lblintIdWthtAss = (Label)gdvrw.FindControl("lblintIdWtht");

                if (lblintIdWthtAss.Text == "")
                {
                    ms.IntId = 0;
                }
                else
                {
                    ms.IntId = Convert.ToInt32(lblintIdWthtAss.Text.ToString());
                }
                ms.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);

                TextBox txtteCPWOAss = (TextBox)gdvrw.FindControl("txtteCPWO");
                if (txtteCPWOAss.Text == "")
                {
                    ms.ChvTEId = "";
                }
                else
                {
                    ms.ChvTEId = txtteCPWOAss.Text;
                }

                ms.FlgType = 1;

                TextBox txtChlnCPWOAss = (TextBox)gdvrw.FindControl("txtChlnCPWO");
                if (txtChlnCPWOAss.Text == "")
                {
                    ms.ChvChalanBillNo = "";
                }
                else
                {
                    ms.ChvChalanBillNo = txtChlnCPWOAss.Text.ToString();
                }

                TextBox txtChlnDateCPWOass = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
                if (txtChlnDateCPWOass.Text == "")
                {
                    ms.DtmChalanBilllDt = "";
                }
                else
                {
                    ms.DtmChalanBilllDt = txtChlnDateCPWOass.Text.ToString();
                }

                TextBox txtAmtCPWOAss = (TextBox)gdvrw.FindControl("txtAmtCPWO");
                if (txtAmtCPWOAss.Text == "")
                {
                    ms.FltAmt = 0;
                }
                else
                {
                    ms.FltAmt = Convert.ToDecimal(txtAmtCPWOAss.Text);
                }

                CheckBox chkCollect = (CheckBox)gdvrw.FindControl("chkCollect");
                if (chkCollect.Checked == true)
                {
                    ms.FlgMissing = 2;
                    if (MandatoryFlds(i) == true)
                    {
                        SaveWithDocsCollect(i);
                    }
                    else
                    {
                        ms.FlgMissing = 1;
                        gblobj.MsgBoxOk("Enter all details!", this);
                    }
                }
                else
                {
                    ms.FlgMissing = 1;
                }
                ms.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
                ms.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);

                DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
                if (ddlLBAss.SelectedIndex > 0)
                {
                    ms.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
                }
                else
                {
                    ms.IntLBID = 0;
                }

                DropDownList ddlTreasuryCPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
                if (ddlTreasuryCPWOAss.SelectedIndex > 0)
                {
                    ms.IntTreasID = Convert.ToInt32(ddlTreasuryCPWOAss.SelectedValue);
                }
                else
                {
                    ms.IntTreasID = 0;
                }

                TextBox txtRemCPWOAss = (TextBox)gdvrw.FindControl("txtRemCPWO");
                if (txtRemCPWOAss.Text == "")
                {
                    ms.ChvRemarks = "";
                }
                else
                {
                    ms.ChvRemarks = txtRemCPWOAss.Text.ToString();
                }

                ds = msDao.CreateCreditMissing(ms);
                gblobj.MsgBoxOk("Saved successfully", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("No data", this);
        }
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg = true;
        GridViewRow gdv = gdvCPWO.Rows[i];
        TextBox txtChNCMAss = (TextBox)gdv.FindControl("txtChlnCPWO");
        TextBox txtChDtCMAss = (TextBox)gdv.FindControl("txtChlnDateCPWO");
        DropDownList ddlSubTrCMAss = (DropDownList)gdv.FindControl("ddlTreasuryCPWO");
        DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
        TextBox txtAmtCMAss = (TextBox)gdv.FindControl("txtAmtCPWO");
        TextBox txtteCPWO = (TextBox)gdv.FindControl("txtteCPWO");
        
        //if (txtChDtCMAss.Text == null || txtChDtCMAss.Text == "" || txtChDtCMAss.Text == "01/01/1900" || txtChNCMAss.Text == null || txtChNCMAss.Text == "" || txtChNCMAss.Text == "9999")
        if (txtChDtCMAss.Text == null || txtChDtCMAss.Text == "" || txtChDtCMAss.Text == "01/01/1900" || txtChNCMAss.Text == null || txtChNCMAss.Text == "" || Convert.ToInt32(txtChNCMAss.Text) == 0 || txtteCPWO.Text == null || txtteCPWO.Text == "")
        {
            flg = false;
        }
        else if (txtAmtCMAss.Text == null || txtAmtCMAss.Text == "")
        {
            flg = false;
        }
        //else if (Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
        //{
        //    flg = false;
        //}
        else if (ddlLBAss.SelectedIndex != -1)
        {
            if (Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
            {
                flg = false;
            }
        }
        else if (ddlLBAss.SelectedIndex == -1)
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlSubTrCMAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void btnOkbal_Click(object sender, EventArgs e)
    {
        SaveBalanceCr();
        lblAmtBTCP.Text = gdvBT.FooterRow.Cells[6].Text.ToString();
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        ShowBalanceTransCr();
        btnOkbal.Enabled = false;
    }
    public void SaveBalanceCr()
    {
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        bl = new balancetrans();
        blDAO = new BalancetransDAO();
        gendao = new GeneralDAO();
        if (Convert.ToDouble(gdvBT.FooterRow.Cells[6].Text) > 0)
        {
            Session["intCCYearId"] = gendao.GetCCYearId();
            for (int i = 0; i < gdvBT.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvBT.Rows[i];
                DataSet ds = new DataSet();
                Label lblintIdbalAss = (Label)gdvrw.FindControl("lblintIdbal");
                if (lblintIdbalAss.Text == "")
                {
                    bl.IntID = 0;
                }
                else
                {
                    bl.IntID = Convert.ToInt32(lblintIdbalAss.Text.ToString());
                }
                bl.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
                TextBox txtTeNoCPBTAss = (TextBox)gdvrw.FindControl("txtTeNoCPBT");
                if (txtTeNoCPBTAss.Text == "")
                {
                    bl.ChvTEId = "";
                }
                else
                {
                    bl.ChvTEId = txtTeNoCPBTAss.Text;
                }
                TextBox txtAmtCPBTAss = (TextBox)gdvrw.FindControl("txtAmtCPBT");
                if (txtAmtCPBTAss.Text == "")
                {
                    bl.FltAmt = 0;
                }
                else
                {
                    bl.FltAmt = Convert.ToDecimal(txtAmtCPBTAss.Text);
                }
                TextBox txtFrmAcCPBTAss = (TextBox)gdvrw.FindControl("txtFrmAcCPBT");
                if (txtFrmAcCPBTAss.Text == "")
                {
                    bl.ChvFrmAccNo = "";
                }
                else
                {
                    bl.ChvFrmAccNo = txtFrmAcCPBTAss.Text.ToString();
                }
                Label lblintAccnoAss = (Label)gdvrw.FindControl("lblAccNo");
                if (lblintAccnoAss.Text == "" || lblintAccnoAss.Text == "0")
                {
                    bl.IntToAccNo = 0;
                }
                else
                {
                    bl.IntToAccNo = Convert.ToInt32(lblintAccnoAss.Text);
                }
                TextBox txtRmkCPBTAss = (TextBox)gdvrw.FindControl("txtRmkCPBT");
                if (txtRmkCPBTAss.Text == "")
                {
                    bl.ChvRemarks = "";
                }
                else
                {
                    bl.ChvRemarks = txtRmkCPBTAss.Text.ToString();
                }
                bl.IntModeChg = 1;
                bl.IntYearId = Convert.ToInt32(Session["intYearAGCurr"]);
                bl.IntMonthId = Convert.ToInt32(Session["intMonthAGCurr"]);

                //////////////saveCorrectionEntryBT//////////////////////

                Label lblintAccno = (Label)gdvrw.FindControl("lblAccNo");
                TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");
                Label lbloldAcc = (Label)gdvrw.FindControl("lblAccNoNew");
                Label lbloldAmt = (Label)gdvrw.FindControl("lblAmtOld");

                int amtO = Convert.ToInt32(lbloldAmt.Text);
                int amtN = Convert.ToInt32(txtAmtCPBT.Text);
                int accO = Convert.ToInt32(lbloldAcc.Text);
                int accN = Convert.ToInt32(lblintAccno.Text);
                if (lFunEditMode(Convert.ToInt32(lblintIdbalAss.Text), Convert.ToDouble(txtAmtCPBT.Text), Convert.ToInt32(lblintAccno.Text)) == false)
                {
                    saveCorrectionEntryBT(Convert.ToInt32(lblintIdbalAss.Text), amtO, amtN, accO, accN, 0);
                }
                //////////////saveCorrectionEntryBT//////////////////////

                ds = blDAO.CreateBalanceTransCr(bl);
          
            }
            gblobj.MsgBoxOk("Saved successfully", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data", this);
        }
    }
    private Boolean lFunEditMode(Int32 intBtID, double amt, Int32 acc)
    {
        blDAO = new BalancetransDAO();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intBtID);
        ar.Add(amt);
        ar.Add(acc);
        ds = blDAO.getEditStatus(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public void lSubSaveBalTransfer(int j)
    {
        gblobj = new clsGlobalMethods();
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();

        GridViewRow gdvrw = gdvBT.Rows[j];


        TextBox txtintIdAss = (TextBox)gdvrw.FindControl("txtintId");
        if (txtintIdAss.Text == "")
        {
            blPDE.IntIDPDE = 0;
        }
        else
        {
            blPDE.IntIDPDE = Convert.ToInt32(txtintIdAss.Text);

        }
        TextBox txtRelMnthIDbalAss = (TextBox)gdvrw.FindControl("txtRelMnthIDbal");
        if (txtRelMnthIDbalAss.Text == "")
        {
            blPDE.IntRelMonthWiseId = 0;
        }
        else
        {
            blPDE.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthIDbalAss.Text);

        }
        TextBox txtTeNoCPBTAss = (TextBox)gdvrw.FindControl("txtTeNoCPBT");
        if (txtTeNoCPBTAss.Text == "")
        {
            blPDE.ChvTEIdPDE = "";
        }
        else
        {
            blPDE.ChvTEIdPDE = txtTeNoCPBTAss.Text.ToString();

        }
        TextBox txtFrmAcCPBTAss = (TextBox)gdvrw.FindControl("txtFrmAcCPBT");
        if (txtTeNoCPBTAss.Text == "")
        {
            blPDE.ChvFrmAccNoPDE = "";
        }
        else
        {
            blPDE.ChvFrmAccNoPDE = txtFrmAcCPBTAss.Text.ToString();

        }
        TextBox txtintAccnoAs = (TextBox)gdvrw.FindControl("txtintAccno");
        if (txtintAccnoAs.Text == "")
        {
            blPDE.IntToAccNoPDE = 0;
        }
        else
        {
            blPDE.IntToAccNoPDE = Convert.ToInt32(txtintAccnoAs.Text);

        }
        blPDE.ChvToAccNoPDE = "";
        blPDE.IntFrmAccNoPDE = 0;
        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");
        if (txtAmtCPBT.Text == "")
        {
            blPDE.FltAmtPDE = 0;
        }
        else
        {
            blPDE.FltAmtPDE = Convert.ToDecimal(txtAmtCPBT.Text);
        }
        TextBox txtRmkCPBT = (TextBox)gdvrw.FindControl("txtRmkCPBT");
        if (txtRmkCPBT.Text == "")
        {
            blPDE.ChvRemarksPDE = "";
        }
        else
        {
            blPDE.ChvRemarksPDE = txtRmkCPBT.Text.ToString();

        }

        DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatus");

        if (ddlStatusAss.SelectedIndex > 0)
        {
            blPDE.IntModeChgPDE = Convert.ToInt32(ddlStatusAss.SelectedValue);
        }
        else
        {
            blPDE.IntModeChgPDE = 2;
        }

        blPDE.IntFlag = 5;
        DataSet ds = new DataSet();
        ds = blPDEDao.CreateBalanceTransCr(blPDE);
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    protected void Btnwithout_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        if (ViewState["Withoutdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withoutdoc"];
            int count = gdvCPWO.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtteCPWO");
            arrIN.Add("txtChlnCPWO");
            arrIN.Add("txtChlnDateCPWO");
            arrIN.Add("txtAmtCPWO");
            arrIN.Add("ddlTreasuryCPWO");
            arrIN.Add("ddlLB");
            arrIN.Add("txtRemCPWO");
            //  arrIN.Add("ddlStusCPW");
            arrIN.Add("txtintId");
            arrIN.Add("Btnwithout");
            arrIN.Add("RelMnth");
            arrIN.Add(" RelYearId");
            dt = gblobj.AddNewRowToGrid(dt, gdvCPWO, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvCPWO.Rows[count].FindControl("ddlTreasuryCPWO");

            DropDownList drpnewLB = (DropDownList)gdvCPWO.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            //}
            //fillGridcomboswithoutDocs(gdvCPWO);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvCPWO.Rows[i].FindControl("ddlTreasuryCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();

                DropDownList drpLB = (DropDownList)gdvCPWO.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
            }
        }
    }
    protected void txtChlnDateCPWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPWO.Rows[index];
        TextBox txtChlnDateCPWO = (TextBox)gvr.FindControl("txtChlnDateCPWO");
        if (gblobj.isValidDate(txtChlnDateCPWO, this) == true)
        {
            string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
            if (gblobj.CheckChalanDateAg(txtChlnDateCPWO, dt) == false)
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtChlnDateCPWO.Text = "";
        }

        //gblobj = new clsGlobalMethods();
        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvCPWO.Rows[index];
        //TextBox txtChlnDateCPWO = (TextBox)gvr.FindControl("txtChlnDateCPWO");
        //if (gblobj.isValidDate(txtChlnDateCPWO, this) == true)
        //{
        //    if (gblobj.CheckDateInBetween(txtChlnDateCPWO, gblobj.GenerateStartDate("2001-02", 4)) == true)
        //    {
        //    }
        //    else
        //    {
        //        gblobj.MsgBoxOk("Invalid Date", this);
        //    }
        //}
        //else
        //{
        //    gblobj.MsgBoxOk("Invalid Date", this);
        //    txtChlnDateCPWO.Text = "";
        //}
    }
    protected void txtChlnDtCPW_TextChanged(object sender, EventArgs e)
    {

        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtChlnDtCPW");

        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDate2(dt2, dt1) == true)
            {
                if (gblobj.CheckDate2(dt1, dt3) == true)
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(txtDt.Text.ToString());
                    Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);

                    ///////////////
                    Label lblchDtO = (Label)gvr.FindControl("lblchDtO");
                    Label lblMd = (Label)gvr.FindControl("lblMd");
                    if (lblchDtO.Text.ToString() != "0")
                    {
                        if (Convert.ToDouble(lblchDtO.Text) != Convert.ToDouble(txtDt.Text))
                        {
                            lblMd.Text = "1";
                        }
                        else
                        {
                            lblMd.Text = "0";
                        }
                    }
                    ////////////////////
                }
                else
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                    txtDt.Text = "";
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtDt.Text = "";
            }
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
    protected void txtToaccCPBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blPDEDao = new BalanceTransPDEDao();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBT.Rows[index];
        TextBox txtToaccCPBTAss = (TextBox)gdvrw.FindControl("txtToaccCPBT");
        TextBox txttoNameass = (TextBox)gdvrw.FindControl("txttoName");
        Label lblintAccnoass = (Label)gdvrw.FindControl("lblAccNo");
        //Label lblAccNoNew = (Label)gdvrw.FindControl("lblAccNoNew");
        if (gblobj.CheckNumericOnly(txtToaccCPBTAss.Text.ToString(), this) == true)
        {
            ArrayList arr = new ArrayList();
            DataSet dsname = new DataSet();
            arr.Add(txtToaccCPBTAss.Text);

            dsname = blPDEDao.FillName(arr);
            if (dsname.Tables[0].Rows.Count > 0)
            {
                txttoNameass.Enabled = false;
                txttoNameass.Text = dsname.Tables[0].Rows[0].ItemArray[0].ToString();
                lblintAccnoass.Text = dsname.Tables[0].Rows[0].ItemArray[1].ToString();
                txtToaccCPBTAss.Text = dsname.Tables[0].Rows[0].ItemArray[4].ToString();
            }
            else
            {
                txttoNameass.Text = "";
                lblintAccnoass.Text = "0";
                txtToaccCPBTAss.Text = "0";
                gblobj.MsgBoxOk("Account number doesnot exists", this);
            }
        }

    }
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvCPWO);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvCPWO);
            DataSet ds = new DataSet();
            gdvCPWO.DataSource = dtgdRow;
            gdvCPWO.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvCPWO, ds);
        }
    }
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        // myControls.Add(new DropDownList());

        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());

        myControls.Add(new Label());
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");

        arrControlid.Add("txtteCPWO");
        arrControlid.Add("txtChlnCPWO");
        arrControlid.Add("txtChlnDateCPWO");
        arrControlid.Add("txtAmtCPWO");
        arrControlid.Add("ddlTreasuryCPWO");
        arrControlid.Add("ddlLB");
        arrControlid.Add("txtRemCPWO");
        arrControlid.Add("lblintIdWtht");

        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();


        arrControlid.Add("chvTEId");
        arrControlid.Add("intChalNo");
        arrControlid.Add("dtmChalDt");
        arrControlid.Add("fltAmt");
        arrControlid.Add("intTreasID");
        arrControlid.Add("intLBID");

        arrControlid.Add("chvDetails");

        arrControlid.Add("intId");
        return arrControlid;
    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/AGStatements.aspx";
    //}
    protected void btnDelete_Click(object sender, ImageClickEventArgs i)
    {
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();
        chDao = new ChalanDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;

        GridViewRow gdvrw = gdvCPWO.Rows[rowIndex];
        Label lblintIdWthtAss = (Label)gdvrw.FindControl("lblintIdWtht");
        ArrayList arrin = new ArrayList();
        if (lblintIdWthtAss.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintIdWthtAss.Text));
            arrin.Add(1);
            msDao.DeleteCrWithoutDocs(arrin);
            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("TransferEntryCurr.aspx-Transfer Entry_Credit Plus(Without Supporting Documents)- btnDelete_Click-event-DeleteCrWithoutDocs");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdWthtAss.Text));
            chDao.Processtracking(procin);

            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowWithoutDocs();
        FillHeadLbls();
    }
    private void deleteUnsavedDbMinus()
    {
        gblobj = new clsGlobalMethods();

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvCPWO);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvCPWO.DataSource = dtgdRow;
            gdvCPWO.DataBind();
            ds.Tables.Add(dtgdRow);
            // fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            ShowWithoutDocs();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {

        //fillGridcomboswithoutDocs(gdvCPWO);
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    DropDownList ddlTreasuryCPWOAss = (DropDownList)gdRow.FindControl("ddlTreasuryCPWO");
                    DropDownList ddlLBAss = (DropDownList)gdRow.FindControl("ddlLB");

                    ddlTreasuryCPWOAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[4].ToString();
                    ddlLBAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[5].ToString();

                }
            }
        }
    }

    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
       
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
    protected void txtAmtCPBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
    }
    protected void txtChlAmtCPW_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);


        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        TextBox txtChlAmtCPW = (TextBox)gvr.FindControl("txtChlAmtCPW");
        Label lblchAmtO = (Label)gvr.FindControl("lblchAmtO");
        Label lblMd = (Label)gvr.FindControl("lblMd");
        if (Convert.ToDouble(lblchAmtO.Text) != Convert.ToDouble(txtChlAmtCPW.Text))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void txtAmtCPWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
    }
    protected void ddlTreasuryCPWO_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPWO.Rows[index];
        DropDownList ddlTreasuryCPWO = (DropDownList)gvr.FindControl("ddlTreasuryCPWO");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");

        if (Convert.ToInt16(ddlTreasuryCPWO.SelectedValue) > 0)
        {
            Session["IntTreIdTECurr"] = Convert.ToInt16(ddlTreasuryCPWO.SelectedValue);
            FillLbDtWise(Convert.ToInt16(Session["IntTreIdTECurr"]), ddlLBAss);
        }
        else
        {
            Session["IntTreIdTECurr"] = 0;
        }

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
            dsL = gendao.GetLBDistwise(arL);
            gblobj.FillCombo(ddlLBAss, dsL, 1);
        }
    }
    protected void txtCntBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();

        if (txtCntBT.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            //arDdl.Add("ddlTreCPWO");
            //arDdl.Add("ddlDist");
            //arDdl.Add("ddlLB");
            //arDdl.Add("ddlStatus");
            //arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();

            //DataSet dstreas = new DataSet();
            //dstreas = teDAO.GetTreasury();
            //arDdlDs.Add(dstreas);

            //DataSet dsdist = new DataSet();
            //dsdist = teDAO.GetDist();
            //arDdlDs.Add(dsdist);

            //DataSet dslb = new DataSet();
            //dslb = teDAO.GetLB();
            //arDdlDs.Add(dslb);

            //DataSet dsstatus = new DataSet();
            //dsstatus = teDAO.GetStatus();
            //arDdlDs.Add(dsstatus);

            //DataSet dsM = new DataSet();
            //ArrayList arrIn = new ArrayList();
            //arrIn.Add(1);
            //dsM = gendao.GetMisClassRsn(arrIn);
            //arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrColsBT(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsbt = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            dsbt = blDAO.FillBalancetransCrRowCnt(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            //arHp.Add("numChalanId");
            //arHp.Add("flgApproval");
            //arHp.Add("flgPrevYear");
            //arHp.Add("intGroupId");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsbt, Convert.ToInt16(txtCntBT.Text), gdvBT, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvBT, 1);
        }
    }
    private void SetArrColsBT(ArrayList arCols)
    {
        arCols.Add("txtTeNoCPBT");
        arCols.Add("txtFrmAcCPBT");
        arCols.Add("txtName");
        arCols.Add("txtToaccCPBT");
        arCols.Add("txttoName");
        arCols.Add("txtAmtCPBT");
        arCols.Add("txtRmkCPBT");
        arCols.Add("lblAccNo");
        arCols.Add("ddlStatus");
        arCols.Add("lblintIdbal");
        arCols.Add("txtRelMnthIDbal");

        arCols.Add("lblAccNoNew");
        arCols.Add("lblAmtOld");
    }
    private void DelFromSched(Int64 dblChalId, string dtChal)
    {
        schDao = new ScheduleDAO();
        genDAO = new KPEPFGeneralDAO();
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(dblChalId);
        ds = schDao.CheckScheduleExist(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int32 NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[12].ToString());
                //amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                double fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[7].ToString());
                double fltAmtAfr = 0;
                double amt = fltAmtAfr - fltAmtBfr;
                double schID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[14].ToString());

                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(dtChal);

                int intMth = dt.Month;
                int intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(dtChal.ToString());
                int intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                if (Convert.ToInt16(Session["intYearAGCurr"]) < Convert.ToInt16(Session["intCCYearId"]))
                {
                  //  SaveCorrectionEntry(NumEmpID, dblChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), schID, 8, fltAmtBfr, fltAmtAfr, 1);
                }
                ArrayList ars = new ArrayList();
                ars.Add(schID);
                schDao.UpdScheduleTR104Mode(ars);
            }
        }
    }
    protected void btnDeleteCrplus_Click(object sender, ImageClickEventArgs e)
    {
        chDao = new ChalanDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        //Session["intCCYearId"] = gendao.GetCCYearId();

        GridViewRow gdvrw = gdvCPW.Rows[rowIndex];
        Label lblintIdWthAss = (Label)gdvrw.FindControl("lblintIdWth");
        TextBox txtChlnDtCPW = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        CorrectionEntryForDel(Convert.ToInt32(lblintIdWthAss.Text), txtChlnDtCPW.Text.ToString()); //Corr Entry
        ArrayList arrin = new ArrayList();
        if (lblintIdWthAss.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintIdWthAss.Text));
            try
            {
                chDao.Chalandelete(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
            DelFromSched(Convert.ToInt64(lblintIdWthAss.Text), txtChlnDtCPW.Text.ToString());
            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("TransferEntryCurr.aspx-Transfer Entry_Credit Plus(Chalan Entry) -btnDeleteCrplus_Click-event-update chalan and shedule mode of change to 4 (numChalanID is the ID param)");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdWthAss.Text));
            chDao.Processtracking(procin);   
            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowCRPlus();
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
    protected void btndeleteBal_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();
        chDao = new ChalanDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBT.Rows[rowIndex];
        Label lblintIdbalAss = (Label)gdvrw.FindControl("lblintIdbal");

        //////////////saveCorrectionEntryBT//////////////////////
        Label lblintAccno = (Label)gdvrw.FindControl("lblAccNo");
        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");
        Label lbloldAcc = (Label)gdvrw.FindControl("lblAccNoNew");
        Label lbloldAmt = (Label)gdvrw.FindControl("lblAmtOld");

        int amtO = Convert.ToInt32(lbloldAmt.Text);
        int amtN = Convert.ToInt32(txtAmtCPBT.Text);
        int accO = Convert.ToInt32(lbloldAcc.Text);
        int accN = Convert.ToInt32(lblintAccno.Text);
        saveCorrectionEntryBT(Convert.ToInt32(lblintIdbalAss.Text), amtO, amtN, accO, accN, 1);
        ////////////////////


        ArrayList arrin = new ArrayList();
        if (lblintIdbalAss.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintIdbalAss.Text));
            blDAO.DeleteBalancetransCr(arrin);
            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("TransferEntryCurr.aspx-Transfer Entry_Credit Plus(Balance Transfer)- btndeleteBal_Click-event-UPDATE AGBalanceTransferCr SET intModeChg = 4");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintIdbalAss.Text));
            chDao.Processtracking(procin);  

            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowBalanceTransCr();
        FillHeadLbls();

    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 12;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 13;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 10;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 11;
            }
        }
    }
    private void saveCorrectionEntryBT(float schedId, double amtO, double amtN, Int32 accO, Int32 accN, int intDel)
    {
        genDAO = new KPEPFGeneralDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();
        int yr;
        int mth;
        int intDy;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        yr = Convert.ToInt16(Session["intYearAGCurr"]);
        mth = Convert.ToInt16(Session["intMonthAGCurr"]);
        intDy = 1;

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 10)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    cor.IntAccNo = accO;
                    amtCalc = -amtN;
                    cor.FltAmountBefore = amtO;
                    cor.FltAmountAfter = 0;
                }
                else
                {
                    cor.IntAccNo = accN;
                    amtCalc = amtN;
                    cor.FltAmountBefore = 0;
                    cor.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                cor.IntYearID = yr;
                cor.IntMonthID = mth;
                cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                cor.FltCalcAmount = dblAmtAdjusted;
                cor.FlgCorrected = 1;      //Just added not incorporated in CCard
                cor.IntChalanId = schedId;
                cor.IntSchedId = schedId;
                cor.FlgType = 1;           //Remittance
                cor.FltRoundingAmt = 0;
                cor.IntCorrectionType = corrType;
                cor.IntChalanType = 4;
                cor.IntTblTp = 2;
                cord.CreateCorrEntryCalcTblTp(cor);
            }
        }
        else
        {
            if (corrType == 13)
            {
                amtCalc = amtN;
                cor.FltAmountBefore = 0;
                cor.FltAmountAfter = amtN;
            }
            else if (corrType == 12)
            {
                amtCalc = -amtN;
                cor.FltAmountBefore = amtN;
                cor.FltAmountAfter = 0;
            }
            else
            {
                amtCalc = amtN - amtO;
                cor.FltAmountBefore = amtO;
                cor.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            cor.IntAccNo = accN;
            cor.IntYearID = yr;
            cor.IntMonthID = mth;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltCalcAmount = dblAmtAdjusted;
            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = schedId;
            cor.IntSchedId = schedId;
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = corrType;
            cor.IntChalanType = 4;
            cor.IntTblTp = 2;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    protected void chlUnpostCPW_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvCPW.Rows[index];

        CheckBox chkUnpostCPW = (CheckBox)gdvr.FindControl("chlUnpostCPW");
        DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlreason");
        if (chkUnpostCPW.Checked == true)
        {
            ddlReason.Enabled = true;
        }
        else
        {
            ddlReason.Enabled = false;
        }
    }
    protected void txtCntWthout_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        msDao = new MissingDAO();

        if (txtCntWthout.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdlwtht = new ArrayList();
            arDdlwtht.Add("ddlTreasuryCPWO");

            arDdlwtht.Add("ddlLB");

            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDswt = new ArrayList();

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDswt.Add(dstreas);


            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDswt.Add(dslb);

            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arColswt = new ArrayList();
            SetArrColsWt(arColswt);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();

            arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            arr.Add(1);
            ds = msDao.FillCrWithoutDocsBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHpwt = new ArrayList();
            arHpwt.Add("SlNo");

            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(ds, Convert.ToInt16(txtCntWthout.Text), gdvCPWO, arDdlwtht, arColswt, arDdlDswt, arHpwt);
            gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCPWO, 1);
        }
        btnOkWithouDocs.Enabled = true;
    }
    private void SetArrColsWt(ArrayList arColswt)
    {
        arColswt.Add("txtteCPWO");
        arColswt.Add("txtChlnCPWO");
        arColswt.Add("txtChlnDateCPWO");
        arColswt.Add("txtAmtCPWO");
        arColswt.Add("ddlTreasuryCPWO");
        arColswt.Add("ddlLB");
        arColswt.Add("txtRemCPWO");
        arColswt.Add("lblintIdWtht");
    }
    protected void txttoName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtTeCPW_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvCPW.Rows[index];
        TextBox txtTeCPW = (TextBox)gdr.FindControl("txtTeCPW");
        Label lblteNoO = (Label)gdr.FindControl("lblteNoO");
        Label lblMd = (Label)gdr.FindControl("lblMd");

        if (Convert.ToDouble(lblteNoO.Text) != Convert.ToDouble(txtTeCPW.Text))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void txtchno_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdr = gdvCPW.Rows[index];
        TextBox txtchno = (TextBox)gdr.FindControl("txtchno");
        Label lblchNoO = (Label)gdr.FindControl("lblchNoO");
        Label lblMd = (Label)gdr.FindControl("lblMd");

        if (Convert.ToDouble(lblchNoO.Text) != Convert.ToDouble(txtchno.Text))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void ddlTreCPWO_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        DropDownList ddlTreCPWO = (DropDownList)gvr.FindControl("ddlTreCPWO");
        Label lblMd = (Label)gvr.FindControl("lblMd");
        Label lbltreO = (Label)gvr.FindControl("lbltreO");
        if (Convert.ToInt16(lbltreO.Text) != Convert.ToInt16(ddlTreCPWO.SelectedValue))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    protected void ddlreason_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        DropDownList ddlreason = (DropDownList)gvr.FindControl("ddlreason");
        Label lblMd = (Label)gvr.FindControl("lblMd");
        Label lblunPO = (Label)gvr.FindControl("lblunPO");
        if (Convert.ToInt16(lblunPO.Text) != Convert.ToInt16(ddlreason.SelectedValue))
        {
            lblMd.Text = "1";
        }
        else
        {
            lblMd.Text = "0";
        }
    }
    //protected void btnBack_Click(object sender, EventArgs e)
    //{

    //}
    protected void lnkAnnInt_Click(object sender, EventArgs e)
    {
        clearAnnInt();
        FillAnnInt();
        mdlConfirm.Show();
    }
    private void clearAnnInt()
    {
        txtAnnIntAmt.Text = "0";
        txtTENo.Text = "0";
        txtAnnIntRem.Text = "0";

    }
    private void FillAnnInt()
    {
        annD = new AnnIntDAO();
        ArrayList ar = new ArrayList();
        DataSet dsAnn = new DataSet();
        ar.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        dsAnn = annD.GetAnnInt(ar);
        if (dsAnn.Tables[0].Rows.Count > 0)
        {
            txtAnnIntAmt.Text = dsAnn.Tables[0].Rows[0].ItemArray[3].ToString();
            txtTENo.Text = dsAnn.Tables[0].Rows[0].ItemArray[5].ToString();
            txtAnnIntRem.Text = dsAnn.Tables[0].Rows[0].ItemArray[4].ToString();
        }
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        ann = new AnnInt();
        annD = new AnnIntDAO();
        ann.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
        ann.IntYearId = Convert.ToInt16(Session["intYearAGCurr"]);
        //ann.FltAmount = Convert.ToInt64(txtAnnIntAmt.Text);
        ann.FltAmount = Convert.ToDouble(txtAnnIntAmt.Text);
        ann.Rem = txtAnnIntRem.Text.ToString();
        ann.TENo = Convert.ToInt64(txtTENo.Text);
        annD.CreateAnnInt(ann);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        gblobj.MsgBoxOk("Saved!", this);
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        mdlConfirm.Hide();
    }
    protected void btnCan1_Click(object sender, EventArgs e)
    {
        Mdlchl.Hide();
    }
    protected void btnNewWth_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        ShowCRPlus();
        lblAmtWCP.Text = Convert.ToString(gdvCPW.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        btnwithdocs.Enabled = false;
        //gblobj.MsgBoxOk("Saved!!! ", this);
    }
    private void FillChalanTxts()
    {
        //gblobj  = new clsGlobalMethods();
        //chalPDao = new ChalanPDEAGDAO();

        chDao = new ChalanDAO();
        Mdlchl.Show();
        Session["intChalanId"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
        fillcmbNwChl();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Session["intChalanId"] != null)
        {
            arr.Add(Session["intChalanId"]);
            arr.Add(4);
            ds = chDao.FillCrPlusNw(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblchDtO.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtTeN.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtChalNo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtChalDt.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtChalAmt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                ddlLBNew.SelectedValue = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                ddlsubTreas.SelectedValue = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtchnId.Text = Convert.ToInt32(Session["intChalanId"]).ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[14].ToString()) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.SelectedValue = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                    ddlRsnN.Enabled = false;
                    ddlRsnN.SelectedValue = "0";
                }
                ddldis.SelectedValue = ds.Tables[0].Rows[0].ItemArray[6].ToString();

                lblYearId.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                lblMnth.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
                lblDy.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            }
            else
            {

            }
        }
        else
        {
            Session["intChalanId"] = 0;
            //ddlsubd.Enabled = true;
        }
    }
    public void fillcmbNwChl()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        chDao = new ChalanDAO();
        ArrayList arDdl = new ArrayList();

        arDdl.Add("ddldis");
        arDdl.Add("ddlsubTreas");
        arDdl.Add("ddlLBNew");
        //arDdl.Add("ddlStatus");
        arDdl.Add("ddlRsnN");
        //Store Ddls in an array//////////

        //Store Ds to fill Ddls in an array//////////
        ArrayList arDdlDs = new ArrayList();


        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        gblobj.FillCombo(ddldis, dsdist, 1);

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        gblobj.FillCombo(ddlsubTreas, dstreas, 1);

        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        gblobj.FillCombo(ddlLBNew, dslb, 1);

        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn);
        gblobj.FillCombo(ddlRsnN, dsM, 1);

    }

    protected void txtChalDt_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();

        string dt1 = txtChalDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        DateTime dtm = new DateTime();

        if (gblobj.isValidDate(txtChalDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtChalDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["intMonthAGCurr"]), Convert.ToInt16(Session["intYearAGCurr"]));
                if (gblobj.CheckChalanDateAg(txtChalDt, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    if (Convert.ToInt16(lblYearId.Text) > 0)
                    {
                        dtm = Convert.ToDateTime(txtChalDt.Text);
                        ardt.Add(txtChalDt.Text);
                        int yrnw = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                        int mthnw = dtm.Month;
                        int dynw = dtm.Day;
                        if (yrnw < Convert.ToInt16(lblYearId.Text))
                        {
                            lblEditId.Text = "1";
                        }
                        else if (yrnw > Convert.ToInt16(lblYearId.Text))
                        {
                            lblEditId.Text = "2";
                        }
                        else
                        {
                            if (genDAO.getMonthIdCalYear(mthnw) < genDAO.getMonthIdCalYear(Convert.ToInt16(lblMnth.Text)))
                            {
                                lblEditId.Text = "1";
                            }
                            else if (genDAO.getMonthIdCalYear(mthnw) > genDAO.getMonthIdCalYear(Convert.ToInt16(lblMnth.Text)))
                            {
                                lblEditId.Text = "2";
                            }
                            else
                            {
                                if (dynw <= 4 && Convert.ToInt16(lblDy.Text) > 4)
                                {
                                    lblEditId.Text = "1";
                                }
                                else
                                {
                                    if (dynw > 4 && Convert.ToInt16(lblDy.Text) <= 4)
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
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
        }
        Mdlchl.Show();
    }
    protected void ddldis_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddldis.SelectedValue) > 0)
        {
            Session["intDist"] = Convert.ToInt16(ddldis.SelectedValue);
            //FillLbDtWiseWithdocs(Convert.ToInt16(Session["intDist"]), ddlLBAss);  GetLBGp
            FillLbDtWiseWithdocs(Convert.ToInt16(Session["intDist"]), ddlLBNew);
            FillTreasDtWise(Convert.ToInt16(Session["intDist"]), ddlsubTreas);
        }
        else
        {
            Session["intDist"] = 0;
        }
        Mdlchl.Show();
    }
    protected void chkUpN_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUpN.Checked == true)
        {
            ddlRsnN.Enabled = true;
        }
        else
        {
            ddlRsnN.Enabled = false;
        }
        Mdlchl.Show();
    }
    protected void ddlRsnN_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mdlchl.Show();
    }
    protected void ddlsubTreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubTreas.SelectedIndex > 0)
        {
            Session["intSTreasDetId"] = Convert.ToInt32(ddlsubTreas.SelectedValue);
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {

    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        //SetChalanLBDefault();
        //FillCmbLbDt();
        //FillCmb4NewChalan();
        //FillComboRsn();
        fillcmbNwChl();
        Mdlchl.Show();

    }
    protected void txtChalAmt_TextChanged(object sender, EventArgs e)
    {

    }
    public void clearnewchalan()
    {
        txtTeN.Text = "0";
        txtchnId.Text = "0";
        txtChalNo.Text = "0";
        txtChalDt.Text = "";
        txtChalAmt.Text = "0";
        ddlLBNew.SelectedValue = "0";
        ddlsubTreas.SelectedValue = "0";
        Session["numchalanId"] = "0";
        //lblOl.Text = "0";
        //lblNw.Text = "0";
        //chkShow.Checked = false;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
}