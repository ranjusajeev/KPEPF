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

public partial class Contents_AG : System.Web.UI.Page
{
    //KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    //GeneralDAO gendao = new GeneralDAO();
    //clsGlobalMethods gblobj = new clsGlobalMethods();
    //AOApproval aoapp = new AOApproval();
    //AOApprovalDAO aoappDAO = new AOApprovalDAO();
    //AGDAO agDAO = new AGDAO();

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    //AOApproval aoapp;
    //AOApprovalDAO aoappDAO;
    AGDAO agDAO;

    public static int intYearID=0 ;
    public static int intMntId=0 ;
    public static double crTraAmt = 0;
    public static double crAGAmt = 0;
    public static double drTraAmt = 0;
    public static double drAGAmt = 0;
    public static double NetCR = 0;
    public static double NetDR = 0;
    public static double TECrPlus = 0;
    public static double TEDrPlus = 0;
    public static double TECrMinus = 0;
    public static double TEDrMinus = 0;
    public static double DDRCR = 0;
    public static double DDRDR = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
       // gblobj = new clsGlobalMethods();
        
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["flgPageBackFrmAG"]) == 1)
            {
                // int yrid = gblobj.IntYear;
                FillCombo();
                ddlYear.SelectedValue = Session["intYearAGCurr"].ToString();
                ddlMnth.SelectedValue = Session["intMonthAGCurr"].ToString();
                FillAGGrid();
                SetCtrls();
                FillTE();
                chkShow.Checked = true;
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetCtrls()
    {
        agDAO = new AGDAO();

        ArrayList arr = new ArrayList();
        DataSet dsA = new DataSet();
        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAGCurr"]));
        dsA = agDAO.GetAppStatusCurr(arr);
        if (dsA.Tables[0].Rows.Count > 0)
        {
            Session["flgAppAgCurr"] = Convert.ToInt16(dsA.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            Session["flgAppAgCurr"] = 0;
        }
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            lblStat.Text = "Rejected";
        }
        else
        {
            SetCtrlsDisable();
            lblStat.Text = "Approved";
        }
    }
    private void SetCtrlsEnable()
    {
        pnlStmt.Enabled = true;
        // TEDetails.Enabled = true;

        txtcrplus.Enabled = true;
        txtCrminus.Enabled = true;

        TxtDbplus.Enabled = true;
        txtDbminus.Enabled = true;

        txtdaer.Enabled = true;
        txtdaerDb.Enabled = true;

        txtoao.Enabled = true;
        txtoaoDb.Enabled = true;

        btnSave.Enabled = true;
        //btnClose.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        pnlStmt.Enabled = false;
        //TEDetails.Enabled = false;
        txtcrplus.Enabled = false;
        txtCrminus.Enabled = false;

        TxtDbplus.Enabled = false;
        txtDbminus.Enabled = false;

        txtdaer.Enabled = false;
        txtdaerDb.Enabled = false;

        txtoao.Enabled = false;
        txtoaoDb.Enabled = false;

        btnSave.Enabled = false;
        //btnClose.Enabled = false;
    }
    private void InitialSettings()
    {
        Session["flgPageBackFrmAG"] = 1;
        FillCombo();
        ClearTxts();
        FillFooterTotals();
        SetGridDefault();
        Session["flgChalanEditFrmTreasOrAg"] = 2;
        //TEDetails .Visible = false;
    }
    private void SetGridDefault()
    {
        gblobj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("DTresuryId");
        ar.Add("intDTreasuryID");
        ar.Add("chvTreasuryName");
        ar.Add("fltAmountTreasuryCr"); 
        ar.Add("fltAmountTreasuryDt");

        ar.Add("fltAmountAGDt");
        ar.Add("fltAmountAGCr");
        ar.Add("chvRemarks");
        gblobj.SetGridDefault(gdvAgStmt, ar);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 2, "txtTreasuryCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 4, "txtTreasryDebit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
    }
    private void Setgridenable()
    {
        for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
        {
            GridViewRow gvr = gdvAgStmt.Rows[i];
            TextBox txtAGCredit = (TextBox)gvr.FindControl("txtAGCredit");
            TextBox txtAGDebit = (TextBox)gvr.FindControl("txtAGDebit");
            TextBox txtTreasuryCredit = (TextBox)gvr.FindControl("txtTreasuryCredit");
            TextBox txtTreasryDebit = (TextBox)gvr.FindControl("txtTreasryDebit");
            txtAGCredit.Enabled = true  ;
            txtAGDebit.Enabled = true;
            txtTreasuryCredit.Enabled = true;
            txtTreasryDebit.Enabled = true;
        }
}
    //private void SetGridDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("SL No");
    //    ar.Add("DTresuryId");
    //    ar.Add("Treasury");
    //    ar.Add("Credit Amount");
    //    ar.Add("Debit Amount");
    //    ar.Add("Remark");
    //    gblobj.SetGridDefault(gdvAgStmt, ar);
    //}
    private void FillCombo()
    {
        genDAO = new KPEPFGeneralDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        //agDAO = new AGDAO();

        DataSet ds = new DataSet();
        //ds = agDAO.GetYear();
        ds = genDAO.GetYearOnLine();
        gblobj.FillCombo(ddlYear, ds, 1);

        DataSet ds1 = new DataSet();
        ds1 = gendao.GetMonthSup();
        gblobj.FillCombo(ddlMnth, ds1, 1);
    }
    private void FillTE()         //For Fill Transfer Entry Grid
    {
        agDAO = new AGDAO();
        
        ClearTxts();
        DataSet ds1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        ds1 = agDAO.FillTEAmt(arr);         //Fill Existing Data
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Session["IntAGId"] = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0]);
            
            txtcrplus.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
            txtCrminus.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            TxtDbplus.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            txtDbminus.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            txtdaer.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
            txtdaerDb.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();

            txtoao.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
            txtoaoDb.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();

            //lblNetCr.Text=ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            //lblNetDr.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            Session["flgAppAgCurr"] = Convert.ToInt16(ds1.Tables[0].Rows[0].ItemArray[15]);
            if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
            {
                SetCtrlsEnable();
            }
            else
            {
                SetCtrlsDisable();
            }
       }
       //SetLnkBtn();
       lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
       lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));

    }
    private void SetLnkBtn()
    {
        if (Convert.ToDouble(txtcrplus.Text) > 0)
        {
            lnkCrplus.Enabled = true;
        }
        else
        {
            lnkCrplus.Enabled = false;
        }
        if (Convert.ToDouble(TxtDbplus.Text) > 0)
        {
            lnkDBPlus.Enabled = true;
        }
        else
        {
            lnkDBPlus.Enabled = false;
        }
        if (Convert.ToInt32(txtCrminus.Text) > 0)
        {
            lnCrMinus.Enabled  = true;
        }
        else
        {
            lnCrMinus.Enabled = false;
        }
        if (Convert.ToInt32(txtDbminus.Text) > 0)
        {
            lnkDbMinus.Enabled = true;
        }
        else
        {
            lnkDbMinus.Enabled = false;
        }
        if (Convert.ToInt32(txtdaer.Text) > 0)
        {
            lnDaerCr.Enabled = true;
        }
        else
        {
            lnDaerCr.Enabled = false;
        }
        if (Convert.ToInt32(txtdaerDb.Text) > 0)
        {
            lndaerdt.Enabled = true;
        }
        else
        {
            lndaerdt.Enabled = false;
        }
        if (Convert.ToInt32(txtoao.Text) > 0)
        {
            lnOAOCr.Enabled = true;
        }
        else
        {
            lnOAOCr.Enabled = false;
        }
        if (Convert.ToInt32(txtoaoDb.Text) > 0)
        {
            lnoaodt.Enabled = true;
        }
        else
        {
            lnoaodt.Enabled = false;
        }
      
    }
    private void ClearTxts()
    {
        txtcrplus.Text = "0";
        TxtDbplus.Text = "0";
        txtCrminus.Text = "0";
        txtDbminus.Text = "0";
        txtdaer.Text = "0";
        txtdaerDb.Text = "0";
        lblNetCr.Text = "0";
        lblNetDr.Text = "0";

        txtoao.Text = "0";
        txtoaoDb.Text = "0";
    }
    protected void gdvAgStmt_RowCreated(object sender, GridViewRowEventArgs e)
    {
        gblobj = new clsGlobalMethods();

        GridViewRow gvr = e.Row;
        gblobj.MergeCells(gdvAgStmt, gvr, 6, 2, 3, 4, 5, "Credit_Amount", "Debit_Amount", e);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        //DiplayTotalAG();   //Find Total from AG Stmt Grid
        if (Convert.ToInt32(Session["intYearAGCurr"]) > 0 && Convert.ToInt32(Session["intMonthAGCurr"]) > 0)
        {
            SaveAGEntries();
            SaveTEEntries();
            SetLnkBtn();
            gblobj.MsgBoxOk("Save Successfully", this);
        }
        else
        {
            gblobj.MsgBoxOk("Select details!!!", this);
        }
    }
    private void SaveAGEntries()
    {
        agDAO = new AGDAO();

        SaveAgCredit();
        for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32( Session["intYearAGCurr"]));
            arrIn.Add(Convert.ToInt32(Session["intMonthAGCurr"] ));
            GridViewRow gdv = gdvAgStmt.Rows[i];
            int treasuryID = Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString());
            arrIn.Add(treasuryID);
            TextBox txtAGCredit = (TextBox)gdv.FindControl("txtAGCredit");
            if (txtAGCredit.Text == "")
            {
                txtAGCredit.Text = 0.ToString();
            }
            arrIn.Add(Convert.ToInt64(txtAGCredit.Text.ToString()));
            arrIn.Add(1);
            arrIn.Add(Convert.ToInt32(Session["intUserId"]).ToString());
            TextBox txtRem1 = (TextBox)gdv.FindControl("txtRem");
            arrIn.Add(txtRem1.Text.ToString());
            int r = agDAO.SaveAGEntry(arrIn);


            ArrayList arrIn1 = new ArrayList();
            arrIn1.Add(Convert.ToInt32(Session["intYearAGCurr"]));
            arrIn1.Add(Convert.ToInt32(Session["intMonthAGCurr"]));
            GridViewRow gdv1 = gdvAgStmt.Rows[i];
            int treasuryID1 =Convert.ToInt32(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString());
            arrIn1.Add(treasuryID1);
            TextBox txtAGDebit = (TextBox)gdv1.FindControl("txtAGDebit");
            if (txtAGDebit.Text == "")
            {
                txtAGDebit.Text = 0.ToString();
            }
            arrIn1.Add(Convert.ToInt64(txtAGDebit.Text.ToString()));
            arrIn1.Add (2);
            
            arrIn1.Add(Convert.ToInt32(Session["intUserId"]).ToString());

            TextBox txtRem = (TextBox)gdv1.FindControl("txtRem");
            arrIn1.Add(txtRem.Text.ToString());

            int r1 = agDAO.SaveAGEntry(arrIn1);
        }
    }
    public void SaveAgCredit()
    {

    }
    private void SaveTEEntries()
    {
        //GetTotalAGCr();
        //GetTotalAGDr();
        //FindNetAmt();

        gblobj = new clsGlobalMethods();
        agDAO = new AGDAO();

        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arrIn.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        arrIn.Add(crAGAmt);   //@fltCreditAmount grid ttl
        arrIn.Add(drAGAmt);   //@fltDebitAmount
        arrIn.Add(Convert.ToInt64(lblNetCr.Text));   //@fltNetCreditAmount
        arrIn.Add(Convert.ToInt64(lblNetDr.Text));   //@fltNetDebitAmount
        arrIn.Add(Convert.ToDouble(txtcrplus.Text));   //@fltTECrPlus
        arrIn.Add(Convert.ToDouble(txtCrminus.Text));   //@fltTECrMinus
        arrIn.Add(Convert.ToDouble(TxtDbplus.Text));   //@fltTEDrPlus
        arrIn.Add(Convert.ToDouble(txtDbminus.Text));   //@fltTEDrMinus
        arrIn.Add(Convert.ToDouble(txtdaer.Text));   //@fltDDRPlus
        arrIn.Add(Convert.ToDouble(txtdaerDb.Text));   //@fltDDRMinus
        arrIn.Add(0);   //@fltAnnInterest

        arrIn.Add(Convert.ToDouble(txtoao.Text));   //OAOPlus
        arrIn.Add(Convert.ToDouble(txtoaoDb.Text));   //@OAOMinus

        arrIn.Add(Convert.ToInt32( Session["intUserId"].ToString()));   //@intUserId
      //  arrIn.Add(DateTime.Now);   //@dtmEntry
        arrIn.Add(0);   //@flgApproval
        arrIn.Add("");   //@dtmApproval
        arrIn.Add("");   //@chvRemarks
        agDAO.SaveAGTEEntry(arrIn);
        gblobj.MsgBoxOk("Saved Successfully !!!!",this);
        DataSet dsAGIs = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt32(Session["intMonthAGCurr"]));
        dsAGIs = agDAO.GetAGId(arr);
        if (dsAGIs.Tables[0].Rows.Count > 0)
        {
            Session["IntAGId"] = Convert.ToInt32(dsAGIs.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["intYearAGCurr"] = Convert.ToInt16(ddlYear.SelectedValue);
        //pnlStmt.Visible = false;
        //TEDetails.Visible = false;

        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearAGCurr"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearAGCurr"] = 0;
        }
        pnlStmt.Visible = true;
        TEDetails.Visible = true;
    }
    protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMnth.SelectedIndex > 0)
        {
            Session["intMonthAGCurr"] = Convert.ToInt16(ddlMnth.SelectedValue);
        }
        else
        {
            Session["intMonthAGCurr"] = 0;
        }
        //FillAGGrid();
        SetGridDefault();
        chkShow.Checked = false;
        FillTE();
        FindTEMonthWiseID();
        SetCtrls();

        //FindNetAmt();


        //FillAGGrid();
        //FillTE();
        //FindTEMonthWiseID();
        //DiplayTotalAG();
        //SetCtrls();
    }
    private void FindTEMonthWiseID()
    {
        //gblobj = new clsGlobalMethods();
        agDAO = new AGDAO();

        DataSet dsmnth = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        dsmnth = agDAO.GetTEMonthwiseId(arr);
        if (dsmnth.Tables[0].Rows.Count > 0)
        {
            //gblobj.GintTEMonthWiseId =
            Session["GintTEMonthWiseId"] = Convert.ToInt32(dsmnth.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            Session["GintTEMonthWiseId"] = 0;
        }
    }
    private void FillAGGrid()
    {
        gblobj = new clsGlobalMethods();
        agDAO = new AGDAO();

        SetGridDefault();
        pnlStmt.Visible = true;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        ds = agDAO.GetTreasuryD(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAgStmt.DataSource = ds;
            gdvAgStmt.DataBind();
            Setgridenable();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvAgStmt.Rows[i];
                TextBox txtTreasuryCredit = (TextBox)gvr.FindControl("txtTreasuryCredit");
                TextBox txtAGCredit = (TextBox)gvr.FindControl("txtAGCredit");
                TextBox txtTreasryDebit = (TextBox)gvr.FindControl("txtTreasryDebit");
                TextBox txtAGDebit = (TextBox)gvr.FindControl("txtAGDebit");
                if (txtTreasuryCredit.Text != "" && txtTreasuryCredit.Text != "0" && txtAGCredit.Text != "" && txtAGCredit.Text != "0")
                {
                    if (Convert.ToDouble(txtTreasuryCredit.Text) != Convert.ToDouble(txtAGCredit.Text))
                    {
                        txtTreasuryCredit.ForeColor = System.Drawing.Color.Red;
                        txtAGCredit.ForeColor = System.Drawing.Color.Red;
                        txtTreasuryCredit.Font.Bold = true;
                        txtAGCredit.Font.Bold = true;

                    }
                    else
                    {
                        txtTreasuryCredit.ForeColor = System.Drawing.Color.Black;
                        txtTreasuryCredit.Font.Bold = false;
                        txtAGCredit.ForeColor = System.Drawing.Color.Black;
                        txtAGCredit.Font.Bold = false;

                    }
                }
                if (txtTreasryDebit.Text != "" && txtTreasryDebit.Text != "0" && txtAGDebit.Text != "" && txtAGDebit.Text != "0")
                {
                    if (Convert.ToDouble(txtTreasryDebit.Text) != Convert.ToDouble(txtAGDebit.Text))
                    {
                        txtTreasryDebit.ForeColor = System.Drawing.Color.Red;
                        txtAGDebit.ForeColor = System.Drawing.Color.Red;
                        txtTreasryDebit.Font.Bold = true;
                        txtAGDebit.Font.Bold = true;
                    }
                    else
                    {
                        txtTreasryDebit.ForeColor = System.Drawing.Color.Black;
                        txtTreasryDebit.Font.Bold = false;
                        txtAGDebit.ForeColor = System.Drawing.Color.Black;
                        txtAGDebit.Font.Bold = false;
                    }
                }
            }
            //FillTreasuryCrAmt(ds);
            //FillAGCrAmt(ds);
            //FillTreasuryDbAmt(ds);
            //FillAgDbAmt(ds);
            //FillAGAmt(ds);
            TEDetails.Visible = true;
        }
        else
        {
            gblobj.MsgBoxOk("No data required", this);
        }
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 2, "txtTreasuryCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 4, "txtTreasryDebit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
        //GetTotalTreasuryCr();
        //GetTotalAGCr();
        //GetTotalTrDr();
        //GetTotalAGDr();
    }
    private void FillTreasuryCrAmt(DataSet ds)
    {
        agDAO = new AGDAO();

        DataSet  dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            arr.Add(1);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtTreasuryCreditass = (TextBox)gdv.FindControl("txtTreasuryCredit");
                txtTreasuryCreditass.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

            }
        }

    }
    private void FillAGCrAmt(DataSet ds)
    {
        agDAO = new AGDAO();
        
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(intYearID);
            arr.Add(intMntId);
            arr.Add(2);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtAGCreditAss = (TextBox)gdv.FindControl("txtAGCredit");
                txtAGCreditAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[1].ToString();

            }
        }

    }
    private void FillTreasuryDbAmt(DataSet ds)
    {
        agDAO = new AGDAO();
        
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(intYearID);
            arr.Add(intMntId);
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            dsTreasCr = agDAO.GetTreasuryDtAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtTreasryDebitAss = (TextBox)gdv.FindControl("txtTreasryDebit");
                txtTreasryDebitAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

            }
        }

    }
    private void FillAgDbAmt(DataSet ds)
    {
        agDAO = new AGDAO();
        
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(intYearID);
            arr.Add(intMntId);
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            dsTreasCr = agDAO.GetAGDtAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtAGDebitAss = (TextBox)gdv.FindControl("txtAGDebit");
                txtAGDebitAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

            }
        }

    }
    //private void FillAGAmt(DataSet ds)
    //{
       
    //}

    protected void btnTranfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("TransferEntry.aspx");
    }
    protected void txtCredit_TextChanged(object sender, EventArgs e)
    {
        //FindNetAmt();   
    }
    //private void FindNetAmt()
    //{
    //    int j = 0;
    //    if (txtdaer.Text == "")
    //    {
    //        DDRDR = 0;
    //        txtdaer.Text = 0.ToString();
    //    }
    //    else
    //    {
    //        DDRDR = Convert.ToDouble(txtdaer.Text);
    //    }
    //    if (txtdaerDb.Text == "")
    //    {
    //        DDRDR = 0;
    //        txtdaerDb.Text = 0.ToString();
    //    }
    //    if (txtcrplus.Text == "")
    //    {
    //        txtcrplus.Text = 0.ToString();
    //    }
       

    //    if (txtCrminus.Text == "")
    //    {
    //        txtCrminus.Text  = 0.ToString();
    //    }
    //    if (TxtDbplus.Text == "")
    //    {
    //        TxtDbplus.Text = 0.ToString();
    //    }
    //    if (txtDbminus.Text == "")
    //    {
    //        txtDbminus.Text = 0.ToString();
    //    }

    //    //NetCR = crAGAmt + Convert.ToDouble(txtcrplus.Text.ToString()) - Convert.ToDouble(txtCrminus.Text.ToString()) + Convert.ToDouble(txtdaer.Text.ToString());
    //    //NetDR = drAGAmt + Convert.ToDouble(TxtDbplus.Text.ToString()) - Convert.ToDouble(txtDbminus.Text.ToString()) + Convert.ToDouble(txtdaerDb.Text.ToString());
    //    //lblNetCr.Text = NetCR.ToString();
    //    //lblNetDr.Text = NetDR.ToString();
    //    lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text));
    //    lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text));
   
    //}
    protected void txtDebit_TextChanged(object sender, EventArgs e)
    {
        //FindNetAmt();
    }
    //private void GetTotalTreasuryCr()
    //{
    //    int j = 0;
        
    //    for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvAgStmt.Rows[i];
    //        TextBox txtTreasuryCredit = (TextBox)gdv.FindControl("txtTreasuryCredit");
    //        if (txtTreasuryCredit.Text == "")
    //        {
    //            txtTreasuryCredit.Text = j.ToString();
    //        }
    //        crTraAmt = crTraAmt + Convert.ToInt32(txtTreasuryCredit.Text);
    //        TextBox txtTottrCr = (TextBox)gdvAgStmt.FooterRow.FindControl("txtTottrCr");

    //        txtTottrCr.Text = Convert.ToString(crTraAmt);
    //    }
      
    //}
    //private void GetTotalAGCr()
    //{
    //    int j = 0;
    //    for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvAgStmt.Rows[i];
    //        TextBox txtAGCredit = (TextBox)gdv.FindControl("txtAGCredit");
    //        if (txtAGCredit.Text == "")
    //        {
    //            txtAGCredit.Text = j.ToString();
    //        }
    //        crAGAmt = crAGAmt + Convert.ToInt64(txtAGCredit.Text);
    //        Label lblCredit = (Label)gdvAgStmt.FooterRow.FindControl("lblAGCrAmt");
    //        lblCredit.Text = crAGAmt.ToString();
    //    }
        
    //}
    //private void GetTotalAGDr()
    //{
    //    int j = 0;
    //    for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvAgStmt.Rows[i];
    //        TextBox txtAGDebit = (TextBox)gdv.FindControl("txtAGDebit");
    //        if (txtAGDebit.Text == "")
    //        {
    //            txtAGDebit.Text = j.ToString();
    //        }
    //        drAGAmt = drAGAmt + Convert.ToInt64(txtAGDebit.Text);
    //    }
    //    Label lblDebit = (Label)gdvAgStmt.FooterRow.FindControl("lblAGDrAmt");
    //    lblDebit.Text = drAGAmt.ToString();
    //}
    //private void GetTotalTrDr()
    //{
    //    int j = 0;
    //    for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvAgStmt.Rows[i];
    //        TextBox txtTreasryDebit = (TextBox)gdv.FindControl("txtTreasryDebit");
    //        if (txtTreasryDebit.Text == "")
    //        {
    //            txtTreasryDebit.Text = j.ToString();
    //        }
    //        drTraAmt = drTraAmt + Convert.ToInt32(txtTreasryDebit.Text);
    //    }
    //    Label lblTrdrAmt = (Label)gdvAgStmt.FooterRow.FindControl("lblTrdrAmt");
    //    lblTrdrAmt.Text = drAGAmt.ToString();
    //}
    private void DiplayTotalAG()
    {
        //GetTotalAGDr();     //For total Debit Amount in AGStmt Grid
        //GetTotalAGCr();     //For total Credit Amount in AGStmt Grid
        //FindNetAmt();       //Finding Net Debit And Credit Amount
    }
    //protected void chkDAER_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkDAER.Checked == true)
    //    {
    //        gdvTE.Rows[2].Visible = true;
    //    }
    //    else
    //    {
    //        gdvTE.Rows[2].Visible = false;
    //    }
    //}
    protected void gdvTE_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkCrplus_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtcrplus.Text != "" && txtcrplus.Text != "0")
        {
            Session["dblAmtCrPlusCurr"] = Convert.ToDouble(txtcrplus.Text);
            Response.Redirect("TransferEntryCurr.aspx");
        }
        else
        {
             //Response.Redirect("AGstatements.aspx");
            Session["dblAmtCrPlusCurr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }

    }
    protected void lnkDBPlus_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (TxtDbplus.Text != "" && TxtDbplus.Text != "0")
        {
            Session["dblAmtDtPlusCurr"] = Convert.ToDouble(TxtDbplus.Text);
            Response.Redirect("DebitPlusCurr.aspx");
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtDtPlusCurr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lnCrMinus_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtCrminus.Text != "" && txtCrminus.Text != "0")
        {
            Session["dblAmtCrMinusCurr"] = Convert.ToDouble(txtCrminus.Text);
            Response.Redirect("CreditMinusCurr.aspx");
            //"~/Contents/TransferEntry.aspx";
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtCrMinusCurr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lnkDbMinus_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtDbminus.Text != "" && txtDbminus.Text != "0")
        {
            Session["dblAmtDtMinusCurr"] = Convert.ToDouble(txtDbminus.Text);
            Response.Redirect("DebitMinusCurr.aspx");
            //"~/Contents/TransferEntry.aspx";
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtDtMinusCurr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    public void ClearControls()
    {

    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {

    }
    protected void txtcrplus_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void TxtDbplus_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtCrminus_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtdaer_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtDbminus_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtdaerDb_TextChanged(object sender, EventArgs e)
    {
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtAGCredit_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    protected void txtAGDebit_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
        //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));
    }
    private void FillFooterTotals()
    {
        gblobj = new clsGlobalMethods();
        
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 2, "txtTreasuryCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 4, "txtTreasryDebit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
    }
    protected void lnDaerCr_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtdaer.Text != "" && txtdaer.Text != "0")
        {
            Session["dblAmtDaerCr"] = Convert.ToDouble(txtdaer.Text);
            Session["trnTypeAG"] = 10;
            Response.Redirect("Daer1.aspx");
            //"~/Contents/TransferEntry.aspx";
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtDaerCr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lndaerdt_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtdaerDb.Text != "" && txtdaerDb.Text != "0")
        {
            Session["dblAmtDAERDt"] = Convert.ToDouble(txtdaerDb.Text);
            Session["flgOAODt"] = 1;
            Response.Redirect("DAERDt.aspx");
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtDAERDt"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lnOAOCr_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtoao.Text != "" && txtoao.Text != "0") 
        {
            Session["dblAmtOAOCr"] = Convert.ToDouble(txtoao.Text); 
            Session["trnTypeAG"] = 20;
            Response.Redirect("Daer1.aspx");
            //"~/Contents/TransferEntry.aspx";
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtOAOCr"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }

    }
    protected void txtoao_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtoaoDb_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lnoaodt_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        
        FillTE();
        if (txtoaoDb.Text != "" && txtoaoDb.Text != "0")
        {
            Session["dblAmtOAODt"] = Convert.ToDouble(txtoaoDb.Text);
            Session["flgOAODt"] = 2;
            Response.Redirect("DAERDt.aspx");
        }
        else
        {
            //Response.Redirect("AGstatements.aspx");
            Session["dblAmtOAODt"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {
            FillAGGrid();
        }
        else
        {
            SetGridDefault();
        }
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text) + Convert.ToDouble(txtoao.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text) + Convert.ToDouble(txtoaoDb.Text));

    }
}
