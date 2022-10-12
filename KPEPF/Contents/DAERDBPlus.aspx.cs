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

public partial class Contents_DAERDBPlus : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    Missing ms;
    TEDAO teDAO;
    WithdrawalPDEAG withAG;
    WithdrawalPDEAGDAO PDEAgDao;
    BalanTrPDE blPDE;
    BalanceTransPDEDao blPDEDao;
    WithdrawalPDEDAO wthpd;
    WithdrawalBDao wthbd;

    CorrectionEntry cor = new CorrectionEntry();
    CorrectionEntryDao cord = new CorrectionEntryDao();

    public int yrId;
    public int RelMnthID;
    static int intDy = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToDouble(Session["numChalanIdEdit"]) > 0)
            {
                ViewGrid();
                SetCtrls();
                //fillGridcombos(gdvDPWith);
                ShowDBPlus();
                SetCtrls();
                FillHeadLbls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void ViewGrid()
    {
        SetGridDefault(gdvDPWith);
    }
    private void InitialSettings()
    {
        Session["flgPageBack"] = 7;
        ViewGrid();

        fillGridcombos(gdvDPWith);
        ShowDBPlus();
        SetCtrls();

        FillHeadLbls();
    }
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();
        if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
        {
            lblHead.Text = "DAER_Debit";
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
        {
            lblHead.Text = "OAO_Debit";
        }
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearAG"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["IntMonthAG"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        //lblTot.Text = Session["dblAmtDaerCr"].ToString();
        if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
        {
            lblTot.Text = Session["dblAmtDaerMns"].ToString();
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
        {
            lblTot.Text = Session["dblAmtOAOMns"].ToString();
        }

        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    public void fillGridcombos(GridView gdv)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        PDEAgDao = new WithdrawalPDEAGDAO();

        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreasDBplusAss = (DropDownList)grdVwRow.FindControl("ddlTreasDBplus");
            gblobj.FillCombo(ddlTreasDBplusAss, dstreas, 1);
        }
        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlDistDbplusAss = (DropDownList)grdVwRow.FindControl("ddlDist");
            gblobj.FillCombo(ddlDistDbplusAss, dsdist, 1);
        }
        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);
        }
        DataSet dsdr = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(2);
        dsdr = PDEAgDao.GetDrawnBy(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddldrawn = (DropDownList)grdVwRow.FindControl("ddldrawn");
            gblobj.FillCombo(ddldrawn, dsdr, 1);
        }
        DataSet dsM = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        arrIn1.Add(2);
        dsM = gendao.GetMisClassRsn(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlreasonAs = (DropDownList)grdVwRow.FindControl("ddlreason");
            gblobj.FillCombo(ddlreasonAs, dsM, 1);
        }
    }
    private void SetGridDefault(GridView gdv)
    {
        gblobj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intVoucherNo");
        ar.Add("intVoucherID");
        // ar.Add("flgPrevYear");
        //  ar.Add("flgApproval");
        //ar.Add("Dist");
        //ar.Add("Localbody");
        //ar.Add("Unposted");
        //ar.Add("Reason");
        //ar.Add("Status");
        //ar.Add("Add");
        gblobj.SetGridDefault(gdv, ar);
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2 || Convert.ToInt16(Session["flgAppAg"]) == 0)
        {
            SetCtrlsEnable();
            //btnwithdocs.Enabled = true;
            txtCnt.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            //btnwithdocs.Enabled = false;
            txtCnt.Enabled = false;
        }
        if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
        {
            lblHead.Text = "DAER_Debit";
            lbl11.Text = "DAER Plus ";
            lblTotET.Text = "DAER Entered";
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
        {
            lblHead.Text = "OAO_Debit";
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
    private void SetWithDocsGridDisable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = true;
            txtTeDPAss.Enabled = false;

            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = true;
            txtBillNoWDAss.Enabled = false;


            TextBox txtBilldateDBplusAss = (TextBox)gdvrow.FindControl("txtBilldateDBplus");
            txtBilldateDBplusAss.ReadOnly = true;
            txtBilldateDBplusAss.Enabled = false;

            DropDownList ddldrawnAss = (DropDownList)gdvrow.FindControl("ddldrawn");
            ddldrawnAss.Enabled = false;


            TextBox txtAmtDbPlusAss = (TextBox)gdvrow.FindControl("txtAmtDbPlus");
            txtAmtDbPlusAss.ReadOnly = true;
            txtAmtDbPlusAss.Enabled = false;

            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrow.FindControl("ddlTreasDBplus");
            ddlTreasDBplusAss.Enabled = false;

            CheckBox chkUnpostDPWAss = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chkUnpostDPWAss.Enabled = false;

            //TextBox txtReasonDBPlusAss = (TextBox)gdvrow.FindControl("txtReasonDBPlus");
            //txtReasonDBPlusAss.ReadOnly = true;
            //txtReasonDBPlusAss.Enabled = false;

            DropDownList ddlRsnN = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlRsnN.Enabled = false;

            //Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
            //lblintIdAss.ReadOnly = true;
            //lblintIdAss.Enabled = false;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = false;


            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = true;
            txtRelMnthWiseIdWAss.Enabled = false;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = true;
            //RelMnthAss.Enabled = false;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = true;
            //RelYearIdAss.Enabled = false;

            ImageButton btndeleteWth = (ImageButton)gdvrow.FindControl("btndelete");
            btndeleteWth.Enabled = false;
        }
    }
    private void SetWithDocsGridEnable()
    {
        for (int i = 0; i < gdvDPWith.Rows.Count; i++)
        {

            GridViewRow gdvrow = gdvDPWith.Rows[i];
            TextBox txtTeDPAss = (TextBox)gdvrow.FindControl("txtTeDP");
            txtTeDPAss.ReadOnly = false;
            txtTeDPAss.Enabled = true;

            TextBox txtBillNoWDAss = (TextBox)gdvrow.FindControl("txtBillNoWD");
            txtBillNoWDAss.ReadOnly = false;
            txtBillNoWDAss.Enabled = true;


            TextBox txtBilldateDBplusAss = (TextBox)gdvrow.FindControl("txtBilldateDBplus");
            txtBilldateDBplusAss.ReadOnly = false;
            txtBilldateDBplusAss.Enabled = true;

            DropDownList ddldrawnAss = (DropDownList)gdvrow.FindControl("ddldrawn");
            ddldrawnAss.Enabled = true;


            TextBox txtAmtDbPlusAss = (TextBox)gdvrow.FindControl("txtAmtDbPlus");
            txtAmtDbPlusAss.ReadOnly = false;
            txtAmtDbPlusAss.Enabled = true;

            DropDownList ddlTreasDBplusAss = (DropDownList)gdvrow.FindControl("ddlTreasDBplus");
            ddlTreasDBplusAss.Enabled = true;

            CheckBox chkUnpostDPWAss = (CheckBox)gdvrow.FindControl("chlUnpostDPW");
            chkUnpostDPWAss.Enabled = true;

            //TextBox txtReasonDBPlusAss = (TextBox)gdvrow.FindControl("txtReasonDBPlus");
            //txtReasonDBPlusAss.ReadOnly = false;
            //txtReasonDBPlusAss.Enabled = true;

            DropDownList ddlRsnN = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlRsnN.Enabled = true;
            //Label lblintIdAss = (Label)gdvrow.FindControl("lblintId");
            //lblintIdAss.ReadOnly = false;
            //lblintIdAss.Enabled = true;

            //Button BtnwithDtAss = (Button)gdvrow.FindControl("BtnwithDt");
            //BtnwithDtAss.Enabled = true;


            TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrow.FindControl("txtRelMnthWiseIdW");
            txtRelMnthWiseIdWAss.ReadOnly = false;
            txtRelMnthWiseIdWAss.Enabled = true;


            //TextBox RelMnthAss = (TextBox)gdvrow.FindControl("RelMnth");
            //RelMnthAss.ReadOnly = false;
            //RelMnthAss.Enabled = true;

            //TextBox RelYearIdAss = (TextBox)gdvrow.FindControl("RelYearId");
            //RelYearIdAss.ReadOnly = false;
            //RelYearIdAss.Enabled = true;

            ImageButton btndeleteWth = (ImageButton)gdvrow.FindControl("btndelete");
            btndeleteWth.Enabled = true;
        }
    }
    public void ShowDBPlus()
    {
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();

        Session["flgPageBack"] = 7;
        DataSet dsdbplus = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
        {
            arr.Add(50);
        }
        else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
        {
            arr.Add(60);
        }
        dsdbplus = PDEAgDao.FillDBPlusPDE(arr);
        if (dsdbplus.Tables[0].Rows.Count > 0)
        {
            gdvDPWith.DataSource = dsdbplus;
            gdvDPWith.DataBind();
            fillGridcombos(gdvDPWith);
            txtCnt.Text = dsdbplus.Tables[0].Rows.Count.ToString();
            for (int i = 0; i < dsdbplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDPWith.Rows[i];

                TextBox txtTeDPAss = (TextBox)gdv.FindControl("txtTeDP");
                txtTeDPAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
                txtBillNoDBPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
                txtBilldateDBplusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
                txtAmtDbPlusAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[5].ToString();

                DropDownList ddlTreasDBplusAss = (DropDownList)gdv.FindControl("ddlTreasDBplus");
                ddlTreasDBplusAss.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[1].ToString();

                CheckBox chkUpN = (CheckBox)gdv.FindControl("chlUnpostDPW");
                DropDownList ddlRsnN = (DropDownList)gdv.FindControl("ddlreason");

                if (Convert.ToInt32(dsdbplus.Tables[0].Rows[i].ItemArray[6].ToString()) == 2)
                {
                    chkUpN.Checked = true;
                    ddlRsnN.Enabled = true;
                    ddlRsnN.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[7].ToString();
                }
                else
                {
                    chkUpN.Checked = false;
                    ddlRsnN.Enabled = false;
                    ddlRsnN.SelectedValue = "0";
                }
                Label lblintIdAss = (Label)gdv.FindControl("lblintId");
                lblintIdAss.Text = dsdbplus.Tables[0].Rows[i].ItemArray[10].ToString();

                DropDownList ddldrawn = (DropDownList)gdv.FindControl("ddldrawn");
                ddldrawn.SelectedValue = dsdbplus.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblYearId = (Label)gdv.FindControl("lblYearId");
                lblYearId.Text = dsdbplus.Tables[0].Rows[i].ItemArray[13].ToString();

                Label lblMnth = (Label)gdv.FindControl("lblMnth");
                lblMnth.Text = dsdbplus.Tables[0].Rows[i].ItemArray[14].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
            if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
            {
                lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();
            }
            else
            {
                lblAmtWCP.Text = "0";
            }
        }
        else
        {
            SetGridDefault(gdvDPWith);
            fillGridcombos(gdvDPWith);
            lblAmtWCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
    }
    protected void btnSaveDBPlus_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        //ShowDBPlus();
        // lblAmtWOCP.Text = Convert.ToString(gdvCPWO.FooterRow.Cells[4].Text);
        lblAmtWCP.Text = Convert.ToString(gdvDPWith.FooterRow.Cells[5].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWCP.Text));
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

    }

    public void SaveWithDocs()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();

        int mnthId;
        int cnt = 0;
        if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
        {
            for (int i = 0; i < gdvDPWith.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvDPWith.Rows[i];
                if (MandatoryFldsWithDocs(i) == true)
                {
                    DataSet ds = new DataSet();
                    ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
                    TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
                    if (txtBilldateDBplus.Text == "")
                    {
                        ms.DtmChalanBilllDt = "";
                    }
                    else
                    {
                        ms.DtmChalanBilllDt = txtBilldateDBplus.Text.ToString();
                        DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
                        mnthId = billDate.Month;

                        ArrayList ardt = new ArrayList();
                        ardt.Add(txtBilldateDBplus.Text.ToString());
                        yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);

                        ms.IntRelMonthId = mnthId;
                        ms.IntRelYearId = yrId;
                    }
                    TextBox txtAmtDbPlus = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
                    if (txtAmtDbPlus.Text == "")
                    {
                        ms.FltAmtPDE = 0;
                    }
                    else
                    {
                        ms.FltAmtPDE = Convert.ToDecimal(txtAmtDbPlus.Text);
                    }

                    //ms.IntTrnType = 2;
                    DropDownList ddlTreasDBplus = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
                    if (ddlTreasDBplus.SelectedIndex > 0)
                    {
                        ms.IntTreaId = Convert.ToInt32(ddlTreasDBplus.SelectedValue);
                    }
                    else
                    {
                        ms.IntTreaId = 0;
                    }
                    ms.IntModeChg = 2;
                    TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrw.FindControl("txtRelMnthWiseIdW");
                    DataSet dsBal = new DataSet();
                    blPDE.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
                    blPDE.IntRelYearId = Convert.ToInt16(Convert.ToInt32(Session["IntYearAG"]));
                    blPDE.IntRelMonthId = Convert.ToInt16(Convert.ToInt32(Session["IntMonthAG"]));
                    blPDE.FltAmtPDE = 0;

                    if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
                    {

                        blPDE.IntTrnType = 50;
                    }
                    else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
                    {
                        blPDE.IntTrnType = 60;
                    }

                    blPDE.IntTreasId = 0;
                    blPDE.IntModeChgPDE = 2;

                    if (txtRelMnthWiseIdWAss.Text == "")
                    {
                        blPDE.IntRelMonthWiseId = 0;
                    }
                    else
                    {
                        blPDE.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdWAss.Text.ToString());
                    }
                    blPDE.IntLBId = 0;
                    blPDE.ChvTEIdPDE = "";
                    dsBal = blPDEDao.CreateBalanceTransRel(blPDE);
                    if (dsBal.Tables[0].Rows.Count > 0)
                    {
                        ms.IntRelMonthWiseId = Convert.ToInt32(dsBal.Tables[0].Rows[0].ItemArray[0]);
                    }
                    TextBox txtTeDPW = (TextBox)gdvrw.FindControl("txtTeDP");
                    if (txtTeDPW.Text == "")
                    {
                        ms.ChvTEIdPDE = "";
                    }
                    else
                    {
                        ms.ChvTEIdPDE = txtTeDPW.Text.ToString();
                    }

                    RelMnthID = ms.IntRelMonthWiseId;
                    SaveWithAG(i);
                }
                else
                {
                    cnt = cnt + 1;
                }
            }
        }
        if (cnt > 0)
        {
            gblobj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            gblobj.MsgBoxOk("Saved successfully", this);
            ShowDBPlus();
        }

    }
    private void SaveWithAG(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        withAG = new WithdrawalPDEAG();
        PDEAgDao = new WithdrawalPDEAGDAO();
        ArrayList ardt = new ArrayList();

        int yrId;
        GridViewRow gdvrw = gdvDPWith.Rows[j];
        Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (lblintIdAss.Text == "")
        {
            withAG.IntVoucherID = 0;
        }
        else
        {
            withAG.IntVoucherID = Convert.ToInt32(lblintIdAss.Text);
        }
        withAG.IntRelMonthWsID = RelMnthID;
        TextBox txtTeDP = (TextBox)gdvrw.FindControl("txtTeDP");
        if (txtTeDP.Text == "")
        {
            withAG.ChvTENo = "";
        }
        else
        {
            withAG.ChvTENo = txtTeDP.Text.ToString();
        }
        TextBox txtBillNoDBPlusAss = (TextBox)gdvrw.FindControl("txtBillNoWD");
        if (txtBillNoDBPlusAss.Text == "")
        {
            withAG.IntVoucherNo = 0;
        }
        else
        {
            withAG.IntVoucherNo = Convert.ToInt32(txtBillNoDBPlusAss.Text);
        }

        DropDownList ddlTreasDBplus = (DropDownList)gdvrw.FindControl("ddlTreasDBplus");
        if (ddlTreasDBplus.SelectedIndex > 0)
        {
            withAG.IntDTreaID = Convert.ToInt32(ddlTreasDBplus.SelectedValue);
        }
        else
        {
            withAG.IntDTreaID = 0;
        }
        TextBox txtBilldateDBplus = (TextBox)gdvrw.FindControl("txtBilldateDBplus");
        if (txtBilldateDBplus.Text == "")
        {
            withAG.DtmVoucherDt = "";
        }
        else
        {
            withAG.DtmVoucherDt = txtBilldateDBplus.Text.ToString();
            ardt.Add(txtBilldateDBplus.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
            //Label RelYearIdAss = (Label)gdvrw.FindControl("lblYearId");
            //RelYearIdAss.Text = yrId.ToString();
            withAG.IntYearID = yrId;
        }
        TextBox txtAmtDbPlus = (TextBox)gdvrw.FindControl("txtAmtDbPlus");
        if (txtAmtDbPlus.Text == "")
        {
            withAG.FltAmount = 0;
        }
        else
        {
            withAG.FltAmount = Convert.ToDecimal(txtAmtDbPlus.Text);
        }
        withAG.IntModeOfChgId = 2;
        withAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        CheckBox chkUnpostDPW = (CheckBox)gdvrw.FindControl("chlUnpostDPW");
        DropDownList ddlRsnN = (DropDownList)gdvrw.FindControl("ddlreason");
        if (chkUnpostDPW.Checked == true)
        {
            ddlRsnN.Enabled = true;
            withAG.FlgUnPosted = 2;
            withAG.IntReasonID = Convert.ToInt32(ddlRsnN.SelectedValue);
        }
        else
        {
            ddlRsnN.Enabled = false;
            withAG.FlgUnPosted = 1;
            withAG.IntReasonID = 0;
        }

        DropDownList ddldrawn = (DropDownList)gdvrw.FindControl("ddldrawn");
        if (ddldrawn.SelectedIndex > 0)
        {
            withAG.IntDrawnBy = Convert.ToInt32(ddldrawn.SelectedValue);
        }
        else
        {
            withAG.IntDrawnBy = 0;
        }
        Label lblintId = (Label)gdvrw.FindControl("lblintId");
        DataSet ds = new DataSet();
        ds = PDEAgDao.SaveVoucherAG(withAG);
        if (ds.Tables[0].Rows.Count >= 1)
        {           
            lblintId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");

        ////////////// Correction  ////////////////
        if (Convert.ToInt16(lblEditId.Text) > 0)
        {
            Label oldYear = (Label)gdvrw.FindControl("lblYearId");
            Label oldMnth = (Label)gdvrw.FindControl("lblMnth");

            int yr1 = Convert.ToInt16(oldYear.Text);
            int mth1 = Convert.ToInt16(oldMnth.Text);
            int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
            int mth2 = Convert.ToDateTime(txtBilldateDBplus.Text).Month;
            SaveCorrectionEntryChal(Convert.ToInt32(lblintId.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, yr2, mth2);
        }
        ////////////// Correction  ////////////////
    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int yr2, int mth2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        dsChal = PDEAgDao.withPDEForCorrectionEntry(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpdLat(yr1, yr2, Convert.ToInt16(Session["intCCYearId"]), mth1, mth2, 1, 1, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr2;
            cor.IntMonthID = mth2;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = -dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
            cor.FlgType = 2;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    } 
    private Boolean MandatoryFldsWithDocs(int i)
    {
        Boolean flg;
        flg = true;
        GridViewRow gdv = gdvDPWith.Rows[i];
        TextBox txtBillNoDBPlusAss = (TextBox)gdv.FindControl("txtBillNoWD");
        TextBox txtBilldateDBplusAss = (TextBox)gdv.FindControl("txtBilldateDBplus");
        TextBox txtAmtDbPlusAss = (TextBox)gdv.FindControl("txtAmtDbPlus");
        if (txtBilldateDBplusAss.Text == null || txtBilldateDBplusAss.Text == "" || Convert.ToInt32(txtBillNoDBPlusAss.Text) >= 9999)
        {
            flg = false;
        }
        if (txtAmtDbPlusAss.Text == null || txtAmtDbPlusAss.Text == "")
        {
            flg = false;
        }
        return flg;
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        PDEAgDao = new WithdrawalPDEAGDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddldrawn");
            arDdl.Add("ddlTreasDBplus");
            arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();


            DataSet dsdr = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(2);
            dsdr = PDEAgDao.GetDrawnBy(arrIn);
            arDdlDs.Add(dsdr);

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDs.Add(dstreas);

            ArrayList arrIn1 = new ArrayList();
            DataSet dsM = new DataSet();
            arrIn1.Add(2);
            dsM = gendao.GetMisClassRsn(arrIn1);
            arDdlDs.Add(dsM);

            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsdbplus = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            if (Convert.ToInt32(Session["trnTypeAG"]) == 50)
            {

                arr.Add(50);
            }
            else if (Convert.ToInt32(Session["trnTypeAG"]) == 60)
            {
                arr.Add(60);
            }
            dsdbplus = PDEAgDao.FillDBPlusPDEAddrw(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("intVoucherID");
            arHp.Add("intVoucherNo");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dsdbplus, Convert.ToInt16(txtCnt.Text), gdvDPWith, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDPWith, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeDP");

        arCols.Add("txtBilldateDBplus");
        arCols.Add("ddldrawn");
        arCols.Add("txtAmtDbPlus");
        arCols.Add("ddlTreasDBplus");
        arCols.Add("chlUnpostDPW");
        arCols.Add("ddlreason");
        arCols.Add("txtBillNoWD");
        arCols.Add("lblintId");

        arCols.Add("lblMnth");
        arCols.Add("lblYearId");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    }
    protected void txtBilldateDBplus_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ardt = new ArrayList();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDPWith.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtBilldateDBplus");

        DateTime dtm = new DateTime();
        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");

        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtDt, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));
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
            txtDt.Text = "";
        }
    }
    protected void txtAmtDbPlus_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();

        gblobj.SetFooterTotalsTempField(gdvDPWith, 5, "txtAmtDbPlus", 1);
        if (Convert.ToDouble(gdvDPWith.FooterRow.Cells[5].Text) > 0)
        {
            lblAmtWCP.Text = gdvDPWith.FooterRow.Cells[5].Text.ToString();

        }
        else
        {
            lblAmtWCP.Text = "0";
        }
        FillHeadLbls();

    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        PDEAgDao = new WithdrawalPDEAGDAO();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label txtintId = (Label)gdvDPWith.Rows[rowIndex].FindControl("lblintId");
        TextBox txtBillDt = (TextBox)gdvDPWith.Rows[rowIndex].FindControl("txtBilldateDBplus");

        CorrectionEntryForDel(Convert.ToInt32(txtintId.Text)); //Corr Entry

        ArrayList arrin = new ArrayList();
        arrin.Add(Convert.ToInt32(txtintId.Text));
        try
        {
            PDEAgDao.DeleteVoucher(arrin);
        }
        catch (Exception ex)
        {
            Session["ERROR"] = ex.ToString();
            Response.Redirect("Error.aspx");
        }
        DelFromWithEmp(txtintId, txtBillDt);
        ShowDBPlus();
        gblobj.MsgBoxOk("Row Deleted   !", this);

        FillHeadLbls();

    }
    private void DelFromWithEmp(Label txtBillId, TextBox txtBillDt)
    {
        genDAO = new KPEPFGeneralDAO();
        wthpd = new WithdrawalPDEDAO();
        wthbd = new WithdrawalBDao();

        int intMth = 0;
        int intYrId = 0;
        double amt;
        int chlId;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt32(txtBillId.Text));
        ds = wthbd.GetWithEmpDet(ar);
        cntEmp = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                //amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                fltAmtAfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[4].ToString());
                chlId = Convert.ToInt32(txtBillId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(txtBillDt.Text.ToString());

                intMth = dt.Month;
                intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(txtBillDt.Text.ToString());
                intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
               // SaveCorrectionEntry(NumEmpID, chlId, intYrId, intMth, 1, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 1);
                //schedPdeDao.DelTR104PDEMode(ar);
                //AP_Withdrawal_U1
                ArrayList are = new ArrayList();
                are.Add(Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2]));
                wthpd.UpdateWithdrawalMode(are);
                wthpd.UpdateVoucherMode(are);
            }
        }


    }
    private void CorrectionEntryForDel(float numChalId)
    {
        PDEAgDao = new WithdrawalPDEAGDAO();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        float NumID;
        double fltAmtBfr;
        double fltAmtAfr;
        int intYrId;
        int intMth;

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ds = PDEAgDao.withPDEForCorrectionEntry(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtBfr - fltAmtAfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                intYrId = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[3].ToString());
                intMth = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[4].ToString());

                SaveCorrectionEntry(Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]), numChalId, intYrId, intMth, 1, Convert.ToDouble(amt), NumID, 9, fltAmtBfr, fltAmtAfr, 4);
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
        cor.FlgType = 2;           //Remittance
        cor.FltRoundingAmt = 0;
        cor.IntCorrectionType = intCorrTp; //Edit Chal Date
        cor.IntChalanType = ChalType;
        cor.IntTblTp = 1;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    protected void chkUnpostDPW_CheckedChanged(object sender, EventArgs e)
    {
        int rowIndex1 = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        CheckBox chkUnpostDPW = (CheckBox)gdvDPWith.Rows[rowIndex1].FindControl("chlUnpostDPW");
        DropDownList ddlRsnN = (DropDownList)gdvDPWith.Rows[rowIndex1].FindControl("ddlreason");
        if (chkUnpostDPW.Checked == true)
        {
            ddlRsnN.Enabled = true;
        }

        else
        {
            ddlRsnN.SelectedIndex = 0;
            ddlRsnN.Enabled = false;
        }
    }
}