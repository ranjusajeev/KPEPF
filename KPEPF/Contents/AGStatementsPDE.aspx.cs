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
public partial class Contents_AGStatementsPDE : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    AOApproval aoapp = new AOApproval();
    AOApprovalDAO aoappDAO = new AOApprovalDAO();
    AGDAO agDAO = new AGDAO();
    //public static int intYearID = 0;
    //public static int intMntId = 0;
    //public static double crTraAmt = 0;
    //public static double crAGAmt = 0;
    //public static double drTraAmt = 0;
    //public static double drAGAmt = 0;
    //public static double NetCR = 0;
    //public static double NetDR = 0;
    //public static double TECrPlus = 0;
    //public static double TEDrPlus = 0;
    //public static double TECrMinus = 0;
    //public static double TEDrMinus = 0;
    //public static double DDRCR = 0;
    //public static double DDRDR = 0;
    //public static int intAmtMismatchCr = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Convert.ToInt32(Session["flgPageBackFrmTE"]) == 1) 
            //if (Convert.ToDouble(Session["dblAmtCrPlus"]) > 0 || Convert.ToDouble(Session["dblAmtDtPlus"]) > 0 || Convert.ToDouble(Session["dblAmtCrMinus"]) > 0 || Convert.ToDouble(Session["dblAmtDtMinus"]) > 0 || Convert.ToDouble(Session["dblAmtDaerPlus"]) > 0)
            if (Convert.ToDouble(Session["dblAmtCrPlus"]) > 0 || Convert.ToDouble(Session["dblAmtDtPlus"]) > 0 || Convert.ToDouble(Session["dblAmtCrMinus"]) > 0 || Convert.ToDouble(Session["dblAmtDtMinus"]) > 0 || Convert.ToDouble(Session["dblAmtDaerPlus"]) > 0
                || Convert.ToDouble(Session["dblAmtDaerMns"]) > 0 || Convert.ToDouble(Session["dblAmtOAOPlus"]) > 0 || Convert.ToDouble(Session["dblAmtOAOMns"]) > 0)
            {
                FillCombo();
                ddlYear.SelectedValue = Session["IntYearAG"].ToString();
                ddlMnth.SelectedValue = Session["IntMonthAG"].ToString();
                FillAGGrid();
                FillTE();
                SetCtrls();
            }
            else
            {
                InitialSettings();
            }
        }
    }
    private void SetCtrls()
    {
        ArrayList arr = new ArrayList();
        DataSet dsA = new DataSet();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        dsA = agDAO.GetAppStatus(arr);
        if (dsA.Tables[0].Rows.Count > 0)
        {
            Session["flgAppAg"] = Convert.ToInt16(dsA.Tables[0].Rows[0].ItemArray[0]);
        }
        if (Convert.ToInt16(Session["flgAppAg"]) == 2)
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

        txtdaero.Enabled = true;
        lblDaerDbo.Enabled = true;

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

        txtdaero.Enabled = false;
        lblDaerDbo.Enabled = false;

        btnSave.Enabled = false;
        //btnClose.Enabled = false;

    }
    private void InitialSettings()
    {
        Session["flgPageBackFrmTE"] = 1;
        FillCombo();
        SetGridDefault();
        pnlStmt.Visible = true;
        TEDetails.Visible = true;
        Session["flgChalanEditFrmTreasOrAg"] = 2;
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("DTresuryId");
        ar.Add("chvTreasuryName");
        ar.Add("Credit Amount");
        ar.Add("Debit Amount");
        ar.Add("Remark");
        ar.Add("intDTreasuryID");

        gblobj.SetGridDefault(gdvAgStmt, ar);
    }
    private void FillCombo()
    {
        DataSet ds = new DataSet();
        ds = gendao.GetYear();
        gblobj.FillCombo(ddlYear, ds, 1);

        DataSet ds1 = new DataSet();
        ds1 = gendao.GetMonthSup();
        gblobj.FillCombo(ddlMnth, ds1, 1);
    }
    private void FillTE()         //For Fill Transfer Entry Grid
    {
        DataSet ds1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(8);
        ds1 = agDAO.FillTEAmtPDE(arr);         //Fill Existing Data
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Session["GintTEMonthWiseId"] = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[4]);

            txtcrplus.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            txtCrminus.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["CrMinus"] = txtCrminus.Text;
            TxtDbplus.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            txtDbminus.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            Session["DBMinus"] = txtDbminus.Text;
            txtdaer.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            txtdaerDb.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            txtdaero.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
            lblDaerDbo.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            //lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text)+ Convert.ToDouble(txtdaer.Text));
            //lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text)+ Convert.ToDouble(txtdaerDb.Text));
        }
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));

    }
    protected void gdvAgStmt_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblobj.MergeCells(gdvAgStmt, gvr, 6, 2, 3, 4, 5, "Credit_Amount", "Debit_Amount", e);

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //    GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.Text = "SL No";
        //    HeaderCell.RowSpan = 2;
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    TableCell HeaderCell1 = new TableCell();
        //    HeaderCell1.Text = "Treasury";
        //    HeaderCell1.RowSpan = 2;
        //    HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell1);
        //    TableCell HeaderCell2 = new TableCell();
        //    HeaderCell2.Text = "Credit Amount";
        //    HeaderCell2.ColumnSpan = 2;
        //    HeaderCell2.RowSpan = 2;
        //    HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell2);
        //    TableCell HeaderCell3 = new TableCell();
        //    HeaderCell3.Text = "Debit Amount";
        //    HeaderCell3.RowSpan = 2;
        //    HeaderCell3.ColumnSpan = 2;
        //    HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell3);
        //    TableCell HeaderCell4 = new TableCell();
        //    HeaderCell4.Text = "Remark";
        //    HeaderCell4.RowSpan = 2;
        //    HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell4);
        //    gdvAgStmt.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //    gdvAgStmt.Controls[0].Controls.AddAt(1, HeaderGridRow1);
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DiplayTotalAG();   //Find Total from AG Stmt Grid
        SaveAGEntries();
        SaveAGEntriesDt();
        SaveTEEntries();
        gblobj.MsgBoxOk("Save Successfully", this);
        //Fill det
        //lblNetCr.Text = 0.ToString();
        //lblNetDr.Text = 0.ToString();
        FillAGGrid();
        FillTE();
        FindTEMonthWiseID();
        SetCtrls();
        //Fill det
    }
    private void SaveAGEntries()
    {

        for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
        {
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            ArrayList aryr = new ArrayList();
            aryr.Add(Convert.ToInt16(Session["IntYearAG"]));
            DataSet dsyr = new DataSet();
            dsyr = genDAO.GetPDEYrId(aryr);
            if (dsyr.Tables[0].Rows.Count >= 0)
            {
                arr.Add(dsyr.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            GridViewRow gdv = gdvAgStmt.Rows[i];

            int treasuryID = Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString());

            arr.Add(treasuryID);

            TextBox txtAGCredit = (TextBox)gdv.FindControl("txtAGCredit");
            if (txtAGCredit.Text == "")
            {
                txtAGCredit.Text = 0.ToString();
                arr.Add(0);
            }
            else
            {
                arr.Add(Convert.ToInt64(txtAGCredit.Text.ToString()));
            }

            TextBox txtRem = (TextBox)gdv.FindControl("txtRem");
            if (txtRem.Text == "")
            {
                txtRem.Text = 0.ToString();
                arr.Add("");
            }
            else
            {
                arr.Add(txtRem.Text.ToString());
            }

            TextBox txtmismatch = (TextBox)gdv.FindControl("txtmismatch");
            if (txtmismatch.Text == "")
            {
                txtmismatch.Text = 0.ToString();
                arr.Add(0);
            }
            else
            {
                arr.Add(Convert.ToInt32(txtmismatch.Text.ToString()));
            }

            TextBox txtDTreasuryDetId = (TextBox)gdv.FindControl("txtDTreasuryDetId");
            if (txtDTreasuryDetId.Text == "")
            {
                txtDTreasuryDetId.Text = 0.ToString();
                arr.Add(0);
            }
            else
            {
                arr.Add(Convert.ToInt32(txtDTreasuryDetId.Text.ToString()));
            }

            ds = agDAO.SaveAGEntryPDE(arr);

        }
    }
    private void SaveAGEntriesDt()
    {

        for (int i = 0; i < gdvAgStmt.Rows.Count; i++)
        {
            ArrayList arrIn = new ArrayList();

            ArrayList aryr = new ArrayList();
            aryr.Add(Convert.ToInt16(Session["IntYearAG"]));
            DataSet dsyr = new DataSet();
            dsyr = genDAO.GetPDEYrId(aryr);
            if (dsyr.Tables[0].Rows.Count >= 0)
            {
                arrIn.Add(dsyr.Tables[0].Rows[0].ItemArray[0].ToString());
            }
           
            arrIn.Add(Convert.ToInt16(Session["IntMonthAG"]));
            GridViewRow gdv = gdvAgStmt.Rows[i];

            int treasuryID = Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString());

            arrIn.Add(treasuryID);
            arrIn.Add(2);

            TextBox txtAGDebit = (TextBox)gdv.FindControl("txtAGDebit");
            if (txtAGDebit.Text == "")
            {
                txtAGDebit.Text = 0.ToString();
                arrIn.Add(0);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(txtAGDebit.Text.ToString()));
            }
            arrIn.Add(6);


            DataSet ds = new DataSet();

            ds = agDAO.SaveAGEntryPDEDt(arrIn);

        }
    }
    private void SaveTEEntries()
    {
        ArrayList arrIn = new ArrayList();
        ArrayList aryr = new ArrayList();
        aryr.Add(Convert.ToInt16(Session["IntYearAG"]));
        DataSet dsyr = new DataSet();
        dsyr = genDAO.GetPDEYrId(aryr);
        if (dsyr.Tables[0].Rows.Count >= 0)
        {
            arrIn.Add(dsyr.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        arrIn.Add(Convert.ToInt16(Session["IntMonthAG"]));
        if (txtcrplus.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtcrplus.Text));   //@fltTECrPlus
        }
        else
        {
            arrIn.Add(0);
        }
        if (txtCrminus.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtCrminus.Text));   //@fltTECrMinus
        }
        else
        {
            arrIn.Add(0);
        }
        if (TxtDbplus.Text != "")
        {
            arrIn.Add(Convert.ToDouble(TxtDbplus.Text));   //@fltTEDrPlus
        }
        else
        {
            arrIn.Add(0);
        }
        if (txtDbminus.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtDbminus.Text));   //@fltTEDrMinus
        }
        else
        {
            arrIn.Add(0);
        }
        if (txtdaer.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtdaer.Text));   //@fltDDRPlus
        }
        else
        {
            arrIn.Add(0);
        }
        if (txtdaerDb.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtdaerDb.Text));   //@fltDDRMinus
        }
        else
        {
            arrIn.Add(0);
        }
        if (txtdaero.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtdaero.Text));   //@fltOAOPlus
        }
        else
        {
            arrIn.Add(0);
        }
        if (lblDaerDbo.Text != "")
        {
            arrIn.Add(Convert.ToDouble(lblDaerDbo.Text));   //@fltOAOMinus
        }
        else
        {
            arrIn.Add(0);
        }
        DataSet dste = new DataSet();
        dste = agDAO.SaveTEMonthWise(arrIn);
        if (dste.Tables[0].Rows.Count >= 1)
        {
            Session["GintTEMonthWiseId"] = dste.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        gblobj.MsgBoxOk("Saved Successfully !!!!", this);
        //DataSet dsAGIs = new DataSet();
        //ArrayList arr = new ArrayList();
        //arr.Add(intYearID);
        //arr.Add(intMntId);
        //dsAGIs = agDAO.GetAGId(arr);
        //if (dsAGIs.Tables[0].Rows.Count > 0)
        //{
        //    Session["IntAGId"] = Convert.ToInt32(dsAGIs.Tables[0].Rows[0].ItemArray[0].ToString());
        //}
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlMnth.SelectedIndex > 0)
        if (ddlYear.SelectedIndex > 0)
        {
            Session["IntYearAG"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["IntYearAG"] = 0;
        }
        ddlMnth.SelectedValue = "0";
        ClearControls();
        pnlStmt.Visible = true;
        TEDetails.Visible = true;
    }
    protected void ddlMnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMnth.SelectedIndex) > 0)
        {
            Session["IntMonthAG"] = Convert.ToInt16(ddlMnth.SelectedValue);
        }
        else
        {
            Session["IntMonthAG"] = 0;
        }
        lblNetCr.Text = 0.ToString();
        lblNetDr.Text = 0.ToString();
        FillAGGrid();
        FillTE();
        FindTEMonthWiseID();
        //DiplayTotalAG();
        SetCtrls();
    }
    private void FindTEMonthWiseID()
    {
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
        pnlStmt.Visible = true;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        ds = agDAO.GetTreasuryDPDE(arr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAgStmt.DataSource = ds;
            gdvAgStmt.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvAgStmt.Rows[i];
                TextBox txtRem = (TextBox)gvr.FindControl("txtRem");
                txtRem.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            }
            FillTreasuryCrAmt(ds);
            FillAGCrAmt(ds);
            FillTreasuryDbAmt(ds);
            FillAgDbAmt(ds);
            //FillAGAmt(ds);
            TEDetails.Visible = true;

        }
        else
        {
            gblobj.MsgBoxOk("No data required", this);
        }
        //gblobj.SetFooterTotals(gdvAgStmt, 3);
        //gblobj.SetFooterTotals(gdvAgStmt, 4);
        //gblobj.SetFooterTotals(gdvAgStmt, 5);
        //gblobj.SetFooterTotals(gdvAgStmt, 6);

        gblobj.SetFooterTotalsTempField(gdvAgStmt, 2, "txtTreasuryCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 4, "txtTreasryDebit", 1);
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
        //gblobj.SetFooterTotals(gdvAgStmt, 4);
        //gblobj.SetFooterTotals(gdvAgStmt, 5);
        //gblobj.SetFooterTotals(gdvAgStmt, 6);

        //GetTotalTreasuryCr();
        //GetTotalAGCr();
        //GetTotalTrDr();
        //GetTotalAGDr();


    }
    private void FillTreasuryCrAmt(DataSet ds)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(1);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtTreasuryCreditass = (TextBox)gdv.FindControl("txtTreasuryCredit");
                txtTreasuryCreditass.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

                TextBox txtmismatch = (TextBox)gdv.FindControl("txtmismatch");
                txtmismatch.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[2].ToString();

                //TextBox txtAGCreditAss = (TextBox)gdv.FindControl("txtAGCredit");
                //txtAGCreditAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();
                
            }
            //    GetTotalTreasuryCr();
        }

    }
    private void FillAGCrAmt(DataSet ds)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(2);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtAGCreditAss = (TextBox)gdv.FindControl("txtAGCredit");
                txtAGCreditAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[1].ToString();
                TextBox txtmismatch = (TextBox)gdv.FindControl("txtmismatch");
                txtmismatch.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[2].ToString();


            }
        }

    }
    private void FillTreasuryDbAmt(DataSet ds)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(Convert.ToInt16(gdvAgStmt.DataKeys[i]["intDTreasuryID"].ToString()));
            dsTreasCr = agDAO.GetTreasuryDtAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAgStmt.Rows[i];
                TextBox txtTreasryDebitAss = (TextBox)gdv.FindControl("txtTreasryDebit");
                txtTreasryDebitAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

                //TextBox txtAGDebitAss = (TextBox)gdv.FindControl("txtAGDebit");
                //txtAGDebitAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }

    }
    private void FillAgDbAmt(DataSet ds)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
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

    protected void txtAGCredit_TextChanged(object sender, EventArgs e)
    {
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 3, "txtAGCredit", 1);
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
    }
    protected void txtAGDebit_TextChanged(object sender, EventArgs e)
    {
        gblobj.SetFooterTotalsTempField(gdvAgStmt, 5, "txtAGDebit", 1);
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text));
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text));
    }
    //protected void txtCredit_TextChanged(object sender, EventArgs e)
    //{
    //    //FindNetAmt();   
    //}
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
    //        txtCrminus.Text = 0.ToString();
    //    }
    //    if (TxtDbplus.Text == "")
    //    {
    //        TxtDbplus.Text = 0.ToString();
    //    }
    //    if (txtDbminus.Text == "")
    //    {
    //        txtDbminus.Text = 0.ToString();
    //    }

    //    NetCR = crAGAmt + Convert.ToDouble(txtcrplus.Text.ToString()) - Convert.ToDouble(txtCrminus.Text.ToString()) + Convert.ToDouble(txtdaer.Text.ToString());
    //    NetDR = drAGAmt + Convert.ToDouble(TxtDbplus.Text.ToString()) - Convert.ToDouble(txtDbminus.Text.ToString()) + Convert.ToDouble(txtdaerDb.Text.ToString());
    //    lblNetCr.Text = NetCR.ToString();
    //    lblNetDr.Text = NetDR.ToString();
    //}
    //protected void txtDebit_TextChanged(object sender, EventArgs e)
    //{
    //    //FindNetAmt();
    //}
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
    //        Label lblTrCrAmt = (Label)gdvAgStmt.FooterRow.FindControl("lblTrCrAmt");
    //        if (lblTrCrAmt == null)
    //        {

    //            lblTrCrAmt.Text = crTraAmt.ToString();
    //        }
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
    //        Label lblAGCrAmt = (Label)gdvAgStmt.FooterRow.FindControl("lblAGCrAmt");
    //        if (lblAGCrAmt != null)
    //        {

    //            lblAGCrAmt.Text = crAGAmt.ToString();
    //        }
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
    //    Label lblAGDrAmt = (Label)gdvAgStmt.FooterRow.FindControl("lblAGDrAmt");
    //    if (lblAGDrAmt != null)
    //    {

    //        lblAGDrAmt.Text = drAGAmt.ToString();
    //    }
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
    //    if (lblTrdrAmt != null)
    //    {
    //        lblTrdrAmt.Text = drAGAmt.ToString();
    //    }
    //}
    private void DiplayTotalAG()
    {
        //GetTotalTreasuryCr();
        //GetTotalTrDr();
        //GetTotalAGDr();     //For total Debit Amount in AGStmt Grid
        //GetTotalAGCr();     //For total Credit Amount in AGStmt Grid
        // FindNetAmt();       //Finding Net Debit And Credit Amount
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
        if (txtcrplus.Text != "" && txtcrplus.Text != "0")
        {
            Session["dblAmtCrPlus"] = Convert.ToDouble(txtcrplus.Text);
            Response.Redirect("TransferEntryPDE.aspx");
            //Server.Transfer("TransferEntryPDE.aspx");
        }
        else
        {
            Session["dblAmtCrPlus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
            //"~/Contents/AGstatements.aspx";
        }
    }
    protected void lnkDBPlus_Click(object sender, EventArgs e)
    {
        if (TxtDbplus.Text != "" && TxtDbplus.Text != "0")
        {
            Session["dblAmtDtPlus"] = Convert.ToDouble(TxtDbplus.Text);
            Response.Redirect("DebitPlusPDE.aspx");
        }
        else
        {
            Session["dblAmtDtPlus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
            //"~/Contents/AGstatements.aspx";
        }
    }
    protected void lnCrMinus_Click(object sender, EventArgs e)
    {
        if (txtCrminus.Text != "" && txtCrminus.Text != "0")
        {
            Session["dblAmtCrMinus"] = Convert.ToDouble(txtCrminus.Text);
            Response.Redirect("CreditMinusPDE.aspx");
        }
        else
        {
            Session["dblAmtCrMinus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
            //"~/Contents/AGstatements.aspx";
        }
    }
    protected void lnkDbMinus_Click(object sender, EventArgs e)
    {
        if (txtDbminus.Text != "" && txtDbminus.Text != "0")
        {
            Session["dblAmtDtMinus"] = Convert.ToDouble(txtDbminus.Text);
            Response.Redirect("DebitMinusPDE.aspx");
        }
        else
        {
            Session["dblAmtDtMinus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
            //"~/Contents/AGstatements.aspx";
        }
    }
    public void ClearControls()
    {
        txtcrplus.Text = "0";
        txtCrminus.Text = "0";
        txtDbminus.Text = "0";
        TxtDbplus.Text = "0";
        txtdaer.Text = "0";
        txtdaerDb.Text = "0";

    }
    protected void txtcrplus_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);
    }
    protected void TxtDbplus_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);
    }
    protected void gdvAgStmt_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{

    //}
    protected void gdvAgStmt_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void txtCrminus_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);

    }
    protected void txtdaer_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);

    }
    protected void txtDbminus_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);

    }
    protected void txtdaerDb_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);

    }
    protected void lnkDaerPlus_Click(object sender, EventArgs e)
    {
        if (txtdaer.Text != "" && txtdaer.Text != "0")
        {
            Session["dblAmtDaerPlus"] = Convert.ToDouble(txtdaer.Text);
            Session["trnTypeAG"] = 30;
            Response.Redirect("DaerPde.aspx");
        }
        else
        {
            Session["dblAmtDaerPlus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lnkDaerMns_Click(object sender, EventArgs e)
    {       
            if (txtdaerDb.Text != "" && txtdaerDb.Text != "0")
            {
                Session["dblAmtDaerMns"] = Convert.ToDouble(txtdaerDb.Text);
                Session["trnTypeAG"] = 50;
                Response.Redirect("DAERDBPlus.aspx");

            }
            else
            {
                Session["dblAmtDaerMns"] = 0;
                gblobj.MsgBoxOk("No data!", this);
            }
    }
    protected void txtdaero_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);
    }
    protected void txtdaerDbo_TextChanged(object sender, EventArgs e)
    {
        lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtCrminus.Text) + Convert.ToDouble(txtdaer.Text)) + Convert.ToDouble(txtdaero.Text);
        lblNetDr.Text = Convert.ToString(Convert.ToDouble(gdvAgStmt.FooterRow.Cells[5].Text) + Convert.ToDouble(TxtDbplus.Text) - Convert.ToDouble(txtDbminus.Text) + Convert.ToDouble(txtdaerDb.Text)) + Convert.ToDouble(lblDaerDbo.Text);
    }
    protected void lnkDaerPluso_Click(object sender, EventArgs e)
    {
        if (txtdaero.Text != "" && txtdaero.Text != "0")
        {
            Session["dblAmtOAOPlus"] = Convert.ToDouble(txtdaero.Text);
            Session["trnTypeAG"] = 40;
            Response.Redirect("DaerPde.aspx");

        }
        else
        {
            Session["dblAmtOAOPlus"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
    protected void lnkDaerMnso_Click(object sender, EventArgs e)
    {
        if (lblDaerDbo.Text != "" && lblDaerDbo.Text != "0")
        {
            Session["dblAmtOAOMns"] = Convert.ToDouble(lblDaerDbo.Text);
            Session["trnTypeAG"] = 60;
            Response.Redirect("DAERDBPlus.aspx");

        }
        else
        {
            Session["dblAmtOAOMns"] = 0;
            gblobj.MsgBoxOk("No data!", this);
        }
    }
}
