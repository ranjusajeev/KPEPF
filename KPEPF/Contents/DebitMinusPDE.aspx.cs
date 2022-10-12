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
public partial class Contents_DebitMinusPDE : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    TE tranEntry = new TE();
    TEDAO trnsdao = new TEDAO();
    Missing ms= new Missing();
    MissingDAO msDao = new MissingDAO();
    WithdrawalPDEAGDAO pdeAGDAO = new WithdrawalPDEAGDAO();
    DebitMinusPDEAG db = new DebitMinusPDEAG();
    DebitMinusPDEAGDAO dbDAO = new DebitMinusPDEAGDAO();
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    public double DbAmtEntrd;
    int msg = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ViewGrid();
            lblTot.Text = Session["DBMinus"].ToString();
            fillGridcombos(gdvDM);
            ShowGrid();
            SetEnable();
            FillHeadLbls();
        }
    }
    private void FillHeadLbls()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearAG"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["IntMonthAG"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        lblTot.Text = Session["DbMinus"].ToString();
        lblTotE.Text = DbAmtEntrd.ToString();
            //gdvDM.FooterRow.Cells[4].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private void SetEnable()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2)
        {
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
    }
    private void SetCtrlsEnable()
    {
        gdvDM.Enabled = true;
        btnSave.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        gdvDM.Enabled = false;
        btnSave.Enabled = false;
    }
    private void ViewGrid()
    {
        SetGridDefaultDM();
    }
    private void SetGridDefaultDM()
    {
        ArrayList ar1 = new ArrayList();
        ar1.Add("SlNo");
        ar1.Add("chvTEId");
        ar1.Add("intVchrNo");
        ar1.Add("dtmVchrDate");
        ar1.Add("fltAmount");
        ar1.Add("chvAccNo");
        ar1.Add("intDTreasId");
        ar1.Add("chvRemarks");
        ar1.Add("intModeChg");
        ar1.Add("intId");
        //ar1.Add("intRelMonthWiseId");
      
        gblobj.SetGridDefault(gdvDM, ar1);
        fillGridcombos(gdvDM);
    }
    public void fillGridcombos(GridView gdv)
    {

        DataSet dstreas = new DataSet();
        dstreas = trnsdao.GetTreasury();

        DataSet dsstatus = new DataSet();
        dsstatus = pdeAGDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTrDMAss = (DropDownList)grdVwRow.FindControl("ddlTrDM");
            gblobj.FillCombo(ddlTrDMAss, dstreas, 1);

            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatusDM");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lSubSaveTERelMonthWiseForDbMinus();
        //ShowGrid();
        FillHeadLbls();
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvDM.Rows[i];
        TextBox txtChNCM = (TextBox)gdv.FindControl("txtVnDM");
        TextBox txtChDtCM = (TextBox)gdv.FindControl("txtVdtDM");
        TextBox txtAmtCM = (TextBox)gdv.FindControl("txtAmtDM");
        TextBox txtTeNoCM = (TextBox)gdv.FindControl("txtTeNoDM");

        if (txtChDtCM.Text == null || txtChDtCM.Text == "" || txtChNCM.Text == null || txtChNCM.Text == "" || txtTeNoCM.Text == null || txtTeNoCM.Text == "")
        {
            flg = false;
        }
        else if (txtAmtCM.Text == null || txtAmtCM.Text == "")
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    public void lSubSaveTERelMonthWiseForDbMinus()
    {
        int cnt = 0;
        for (int i = 0; i < gdvDM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvDM.Rows[i];
            DataSet ds = new DataSet();
            ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
            TextBox txtVdtDM = (TextBox)gdvrw.FindControl("txtVdtDM");
            if (MandatoryFlds(i) == true)
            {
                if (txtVdtDM.Text == "")
                {
                    ms.DtmChalanBilllDt = "";
                }
                else
                {
                    ms.DtmChalanBilllDt = txtVdtDM.Text.ToString();
                    DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
                    mnthId = billDate.Month;

                    ArrayList ardt = new ArrayList();
                    ardt.Add(txtVdtDM.Text.ToString());
                    yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
                    ms.IntRelMonthId = mnthId;
                    ms.IntRelYearId = yrId;
                }
                TextBox txtAmtDM = (TextBox)gdvrw.FindControl("txtAmtDM");
                if (txtAmtDM.Text == "")
                {
                    ms.FltAmtPDE = 0;
                }
                else
                {
                    ms.FltAmtPDE = Convert.ToDecimal(txtAmtDM.Text);
                }

                ms.IntTrnType = 4;
                DropDownList ddlTrDM = (DropDownList)gdvrw.FindControl("ddlTrDM");
                if (ddlTrDM.SelectedIndex > 0)
                {
                    ms.IntTreaId = Convert.ToInt32(ddlTrDM.SelectedValue);
                }
                else
                {
                    ms.IntTreaId = 0;
                }
                DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatusDM");
                if (ddlStatusAss.SelectedIndex > 0)
                {
                    ms.IntModeChg = Convert.ToInt32(ddlStatusAss.SelectedValue);
                }
                else
                {
                    ms.IntModeChg = 2;
                }
                TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrw.FindControl("txtRelMnthWiseIddb");
                if (txtRelMnthWiseIdWAss.Text == "")
                {
                    ms.IntRelMonthWiseId = 0;
                }
                else
                {
                    ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdWAss.Text);
                }
                TextBox txtTeNoDM = (TextBox)gdvrw.FindControl("txtTeNoDM");
                if (txtTeNoDM.Text == "")
                {
                    ms.ChvTEIdPDE = "";
                }
                else
                {
                    ms.ChvTEIdPDE = txtTeNoDM.Text.ToString();
                }
                ds = msDao.TERelMonthWiseUpd(ms);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                    TextBox txtRelMnthWised = (TextBox)gdvrw.FindControl("txtRelMnthWiseIddb");
                    txtRelMnthWised.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    RelMnthID = ms.IntRelMonthWiseId;
                }
                string txtin;
                txtin = gdvDM.DataKeys[gdvrw.RowIndex].Values[0].ToString();
                if (txtin == "")
                {
                    db.IntId = 0;
                }
                else
                {
                    db.IntId = Convert.ToInt32(txtin);
                }
                TextBox txtRelMnthWiseIddb = (TextBox)gdvrw.FindControl("txtRelMnthWiseIddb");
                if (txtRelMnthWiseIddb.Text == "")
                {
                    db.IntRelMonthWiseId = 0;
                }
                else
                {
                    db.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIddb.Text);
                }
                if (txtTeNoDM.Text == "")
                {
                    db.ChvTEId = "";
                }
                else
                {
                    db.ChvTEId = txtTeNoDM.Text.ToString();
                }
                if (txtVdtDM.Text == "")
                {
                    db.DtmVchrDate = "";
                }
                else
                {
                    db.DtmVchrDate = txtVdtDM.Text.ToString();
                    ArrayList ardt = new ArrayList();
                    ardt.Add(txtVdtDM.Text.ToString());
                    yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
                }
                TextBox txtVnDM = (TextBox)gdvrw.FindControl("txtVnDM");
                if (txtVnDM.Text == "")
                {
                    db.IntVchrNo = 0;
                }
                else
                {
                    db.IntVchrNo = Convert.ToInt32(txtVnDM.Text);
                }
                TextBox txtAcCM = (TextBox)gdvrw.FindControl("txtaccno");
                if (txtAcCM.Text == "")
                {
                    db.ChvAccNo = "";
                }
                else
                {
                    db.ChvAccNo = txtAcCM.Text.ToString();
                }
                db.ChvName = "";
                if (txtAmtDM.Text == "")
                {
                    db.FltAmount = 0;
                }
                else
                {
                    db.FltAmount = Convert.ToDecimal(txtAmtDM.Text);
                }
                TextBox txtremDM = (TextBox)gdvrw.FindControl("txtremDM");
                if (txtremDM.Text == "")
                {
                    db.ChvRemarks = "";
                }
                else
                {
                    db.ChvRemarks = txtremDM.Text.ToString();
                }
                db.FlgUnPosted = 0;
                db.IntUnPostdReason = 0;
                DropDownList ddlStatusDM = (DropDownList)gdvrw.FindControl("ddlStatusDM");
                if (ddlStatusDM.SelectedIndex > 0)
                {
                    db.IntModeChg = Convert.ToInt32(ddlStatusDM.SelectedValue);
                }
                else
                {
                    db.IntModeChg = 2;
                }
                lFunFindBillWsId(i);
                TextBox txtBillID = (TextBox)gdvrw.FindControl("txtBillID");
                if (txtBillID.Text == "")
                {
                    db.IntBillWsId = 0;
                }
                else
                {
                    db.IntBillWsId = Convert.ToInt32(txtBillID.Text);
                }
                db.IntDistId = 0;
                if (ddlTrDM.SelectedIndex > 0)
                {
                    db.IntDTreasId = Convert.ToInt32(ddlTrDM.SelectedValue);
                }
                else
                {
                    db.IntDTreasId = 0;
                }
                DataSet dsDbMinus = new DataSet();
                dsDbMinus = dbDAO.CreateDebitMinus(db);
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
            ShowGrid();
        }
    }
    private void lSubSaveDbMinus(int j )
    {

    }
    private void lFunFindBillWsId(int k)
    {
        GridViewRow gdvrw = gdvDM.Rows[k];
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        TextBox txtVdtDM = (TextBox)gdvrw.FindControl("txtVdtDM");
        if (txtVdtDM.Text == "")
        {
            db.DtmVchrDate = "";
        }
        else
        {
            db.DtmVchrDate = txtVdtDM.Text.ToString();

        }

        TextBox txtVnDM = (TextBox)gdvrw.FindControl("txtVnDM");
        if (txtVnDM.Text == "")
        {
            db.IntVchrNo = 0;
        }
        else
        {
            db.IntVchrNo = Convert.ToInt32(txtVnDM.Text);

        }

        DropDownList ddlTrDM = (DropDownList)gdvrw.FindControl("ddlTrDM");

        if (ddlTrDM.SelectedIndex > 0)
        {
           db.IntDTreasId  = Convert.ToInt32(ddlTrDM.SelectedValue);
        }
        else
        {
            db.IntDTreasId = 0;
        }
        ds = dbDAO.FindBillwiseId(db);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TextBox txtBillID = (TextBox)gdvrw.FindControl("txtBillID");
            txtBillID.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
       

    }

    //public void SaveDebitMinus()
    //{
    //    for (int i = 0; i < gdvDM.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrw = gdvDM.Rows[i];
    //        DataSet ds = new DataSet();


    //        tranEntry.IntId = gblobj.IntId;
    //        tranEntry.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);

    //        //DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
    //        //chl.IntTreasuryId = Convert.ToInt32(ddlTreCPWOass.SelectedValue);

    //        //DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
    //        //chl.IntLBId = Convert.ToInt32(ddlLBAss.SelectedValue);




    //        TextBox txtTeNoDMAss = (TextBox)gdvrw.FindControl("txtTeNoDM");
    //        if (txtTeNoDMAss.Text == "")
    //        {
    //            tranEntry.ChvTEId = "";
    //        }
    //        else
    //        {
    //            tranEntry.ChvTEId = txtTeNoDMAss.Text;
    //        }


    //        tranEntry.FlgType = 2;

    //        TextBox txtVdtDMAss = (TextBox)gdvrw.FindControl("txtVdtDM");
    //        if (txtVdtDMAss.Text == "")
    //        {
    //            tranEntry.DtmChalBillDate = "";
    //        }
    //        else
    //        {
    //            tranEntry.DtmChalBillDate = txtVdtDMAss.Text.ToString();
    //        }




    //        TextBox txtVnDMAss = (TextBox)gdvrw.FindControl("txtVnDM");
    //        if (txtVnDMAss.Text == "")
    //        {
    //            tranEntry.IntChalBillNo = 0;
    //        }
    //        else
    //        {
    //            tranEntry.IntChalBillNo = Convert.ToInt32(txtVnDMAss.Text.ToString());
    //        }



    //        TextBox txtAmtDMAss = (TextBox)gdvrw.FindControl("txtAmtDM");
    //        if (txtAmtDMAss.Text == "")
    //        {
    //            tranEntry.FltAmount = 0;
    //        }
    //        else
    //        {
    //            tranEntry.FltAmount = Convert.ToDecimal(txtAmtDMAss.Text);
    //        }


    //        TextBox txtaccnoAss = (TextBox)gdvrw.FindControl("txtaccno");
    //        if (txtaccnoAss.Text == "")
    //        {
    //            tranEntry.ChvAccNoAndName = "";
    //        }
    //        else
    //        {

    //            tranEntry.ChvAccNoAndName = txtaccnoAss.Text.ToString();
    //        }

    //        TextBox txtremDMAss = (TextBox)gdvrw.FindControl("txtremDM");
    //        if (txtremDMAss.Text == "")
    //        {
    //            tranEntry.ChvRemarks = "";
    //        }
    //        else
    //        {

    //            tranEntry.ChvRemarks = txtremDMAss.Text.ToString();
    //        }



    //        tranEntry.IntModeChg = 1;

    //        DropDownList ddlTrDMAss = (DropDownList)gdvrw.FindControl("ddlTrDM");
    //        if (ddlTrDMAss.SelectedIndex > 0)
    //        {
    //            tranEntry.IntDTreasId = Convert.ToInt32(ddlTrDMAss.SelectedValue);
    //        }
    //        else
    //        {
    //            tranEntry.IntDTreasId = 0;
    //        }
    //        tranEntry.PerYearId = gblobj.IntYear;
    //        tranEntry.PerMnthId = gblobj.IntMonth;

    //        ds = trnsdao.CreateCreditMinus(tranEntry);
    //        if (ds.Tables[0].Rows.Count >= 1)
    //        {
    //            //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
    //            gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
    //        }
    //    }
    //    gblobj.MsgBoxOk("Saved successfully", this);
    //}
    private void ShowGrid()
    {
        //DataTable dtrMinus = gblobj.SetInitialRow(gdvDM);
        //ViewState["DtMs"] = dtrMinus;


        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        dscrplus = trnsdao.FillDbMinusPDE(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            gdvDM.DataSource = dscrplus;
            gdvDM.DataBind();

            //dtrMinus = gblobj.SetGridTableRows(gdvDM, dscrplus.Tables[0].Rows.Count);
            //ViewState["CrMs"] = dtrMinus;


            fillGridcombos(gdvDM);
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDM.Rows[i];
                //TextBox txtTeNoDMAss = (TextBox)gdv.FindControl("txtTeNoDM");
                //txtTeNoDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                //TextBox txtVnDMAss = (TextBox)gdv.FindControl("txtVnDM");
                //txtVnDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                //TextBox txtVdtDMAss = (TextBox)gdv.FindControl("txtVdtDM");
                //txtVdtDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();



                DropDownList ddlTrDMAss = (DropDownList)gdv.FindControl("ddlTrDM");
                ddlTrDMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();

                DropDownList ddlStatusDMAss = (DropDownList)gdv.FindControl("ddlStatusDM");
                ddlStatusDMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[11].ToString();


                //TextBox txtAmtDMAss = (TextBox)gdv.FindControl("txtAmtDM");
                //txtAmtDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[7].ToString();

                //TextBox txtaccnoAss = (TextBox)gdv.FindControl("txtaccno");
                //txtaccnoAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();

                //TextBox txtremDMAss = (TextBox)gdv.FindControl("txtremDM");
                //txtremDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

                TextBox txtRelMnthWiseIddb = (TextBox)gdv.FindControl("txtRelMnthWiseIddb");
                txtRelMnthWiseIddb.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();

                //TextBox txtintId = (TextBox)gdv.FindControl("txtintId");
                
                //txtintId.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvDM, 4, "txtAmtDM", 1);
            if (Convert.ToDouble(gdvDM.FooterRow.Cells[4].Text) > 0)
            {
                DbAmtEntrd = Convert.ToDouble(gdvDM.FooterRow.Cells[4].Text.ToString());
            }
            else
            {
                DbAmtEntrd = 0;
            }
        }
        else
        {
            SetGridDefaultDM();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGstatementsPDE.aspx");
    }
    //protected void BtnAddDM_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["CrMs"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["CrMs"];
    //        int count = gdvDM.Rows.Count;

    //        ArrayList arrIN = new ArrayList();
    //        arrIN.Add("txtTeNoDM");
    //        arrIN.Add("txtVnDM");
    //        arrIN.Add("txtVdtDM");
    //        arrIN.Add("txtAmtDM");
    //        arrIN.Add("txtaccno");
    //        arrIN.Add("ddlTrDM");
    //        arrIN.Add("txtremDM");
    //        arrIN.Add("ddlStatusDM");
    //        arrIN.Add("txtintId");
    //        arrIN.Add("BtnAddDM");
    //        dt = gblobj.AddNewRowToGrid(dt, gdvDM, arrIN);
    //        ViewState["SpecTable"] = dt;

    //        fillGridcombos(gdvDM);
    //        for (int i = 0; i < dt.Rows.Count - 1; i++)
    //        {
    //            DropDownList drptr = (DropDownList)gdvDM.Rows[i].FindControl("ddlTrDM");
    //            drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();

    //        }
    //    }
    //}

    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvDM);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvDM);
            DataSet ds = new DataSet();
            gdvDM.DataSource = dtgdRow;
            gdvDM.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvDM, ds);
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
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
       
        //myControls.Add(new TextBox());
        
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        arrControlid.Add("txtintId");
        arrControlid.Add("txtTeNoDM");
        arrControlid.Add("txtVnDM");
        arrControlid.Add("txtVdtDM");
        arrControlid.Add("txtAmtDM");
        arrControlid.Add("txtaccno");
        arrControlid.Add("ddlTrDM");
        arrControlid.Add("txtremDM");
        arrControlid.Add("ddlStatusDM");
       
        //arrControlid.Add("txtRelMnthWiseIddb");
     return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
        // arrControlid.Add("SlNo");
        arrControlid.Add("intId");
        arrControlid.Add("chvTEId");
        arrControlid.Add("intVchrNo");
        arrControlid.Add("dtmVchrDate");
        arrControlid.Add("fltAmount");
        arrControlid.Add("chvAccNo");
        arrControlid.Add("intDTreasId");
        arrControlid.Add("chvRemarks");
        arrControlid.Add("intModeChg");
      
        //arrControlid.Add("intRelMonthWiseId");
    
        return arrControlid;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    }
    protected void ddlStatusDM_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gdvDM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs i)
    {
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        //int rowIndex = Convert.ToInt32(e.RowIndex);
      //  TextBox txtintId = (TextBox)gdvDM.Rows[rowIndex].FindControl("txtintId");
        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        dscrplus = trnsdao.FillDbMinusPDE(arr);
        //if (dscrplus.Tables[0].Rows.Count > 0)
        //{
        //    gdvDM.DataSource = dscrplus;
        //    gdvDM.DataBind();
        //}
        GridViewRow gdvrw = gdvDM.Rows[rowIndex]; 
        //TextBox txtintId = (TextBox)gdvrw.FindControl("txtintId");



        if (rowIndex < Convert.ToInt32(dscrplus.Tables[0].Rows.Count))
        {
            string txtin;
            txtin = gdvDM.DataKeys[gdvrw.RowIndex].Values[0].ToString();

            if (txtin != "")
            {

                ArrayList arrin = new ArrayList();

                arrin.Add(Convert.ToInt32(txtin));
                try
                {
                    dbDAO.UpdDebitMinusModeofChnge(arrin);
                    deleteUnsavedDbMinus();

                }
                catch (Exception ex)
                {
                    Session["ERROR"] = ex.ToString();
                    Response.Redirect("Error.aspx");
                }
            }
        }
        ShowGrid();
        gblobj.MsgBoxOk("Row Deleted   !", this);
      
        FillHeadLbls();
        //}
        //else
        //{
        //}
    }
    private void deleteUnsavedDbMinus()
    {
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvDM);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvDM.DataSource = dtgdRow;
            gdvDM.DataBind();
            ds.Tables.Add(dtgdRow);
            // fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            ShowGrid();
        }
    }
    //protected void gdvDM_RowDataBound(object sender,GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
    //        l.Attributes.Add("onclick", "javascript:return " +
    //        "confirm('Are you sure you want to delete this record " +
    //        DataBinder.Eval(e.Row.DataItem, "intId") + "')");
    //    }
    //}
    //protected void gdvDM_RowCommand(object sender,GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Delete")
    //    {
    //        // get the categoryID of the clicked row
    //        int intid1 = Convert.ToInt32(e.CommandArgument);
    //        // Delete the record 
    //        ArrayList arrin = new ArrayList();
    //        arrin.Add(intid1);
    //        try
    //        {
    //            dbDAO.UpdDebitMinusModeofChnge(arrin);
    //           // deleteUnsavedDbMinus();

    //        }
    //        catch (Exception ex)
    //        {
    //            Session["ERROR"] = ex.ToString();
    //            Response.Redirect("Error.aspx");
    //        }
    //        // Implement this on your own :) 
    //    }
    //}
    //protected void gdvDM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
       
    //}
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
        fillGridcombos(gdvDM);
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    DropDownList ddlSubTrCMAss = (DropDownList)gdRow.FindControl("ddlTrDM");
                    DropDownList ddlStatusCMAss = (DropDownList)gdRow.FindControl("ddlStatusDM");

                    ddlSubTrCMAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[6].ToString();
                  //  ddlStatusCMAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[7].ToString();


                }
            }
        }
    }

    protected void txtVdtDM_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDM.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtVdtDM");

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
   
}
