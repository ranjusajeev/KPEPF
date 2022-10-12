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
public partial class Contents_CreditMinusPDE : System.Web.UI.Page
{

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    TEDAO trnsdao;
    WithdrawalPDEAGDAO pdeAGDAO;
    //CreditMinusAG cr;
    CreditMinusAG cr = new CreditMinusAG();
    CreditMinusAGDAO crDao;
    Missing ms;
    MissingDAO msDao;

    public int mnthId;
    public int yrId;
    public int RelMnthID;
    public double crAmtEntrd;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            ViewGrid();
            lblTot.Text = Session["CrMinus"].ToString();
            fillGridcombos(gdvCM);
            ShowGrid();
            SetEnable();
            FillHeadLbls();
        }
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
    private void FillHeadLbls()
    {
        gendao = new GeneralDAO();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearAG"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["IntMonthAG"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        lblTot.Text = Session["CrMinus"].ToString();
        lblTotE.Text = crAmtEntrd.ToString();
            //gdvCM.FooterRow.Cells[5].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private void SetCtrlsEnable()
    {
        //PnlCM.Enabled = true;
        gdvCM.Enabled = true;
        btnSaveCM.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        //PnlCM.Enabled = false;
        gdvCM.Enabled = false;
        btnSaveCM.Enabled = false;
    }
    private void ViewGrid()
    {
        SetGridDefaultCM();
        
      //  FillFooterTotals();
       
       // gblobj.SetRowsCnt(gdvCM, 1);

    }
    private void SetGridDefaultCM()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar1 = new ArrayList();

        ar1.Add("SlNo");
        ar1.Add("chvTEId");
        ar1.Add("intChalNo");
        ar1.Add("dtmChalDate");
        ar1.Add("fltAmount");
        ar1.Add("intTreasId");
        ar1.Add("chvAccNo");
        ar1.Add("chvName");
        ar1.Add("chvRemarks");
        ar1.Add("intModeChg");
        ar1.Add("intId");
        ar1.Add("intRelMonthWiseId");
        gblobj.SetGridDefault(gdvCM, ar1);
        fillGridcombos(gdvCM);
       
    }
    private void FillFooterTotals()
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvCM, 5, "txtAmtCM", 1);
    }
    public void fillGridcombos(GridView gdv)
    {
        trnsdao = new TEDAO();
        gblobj = new clsGlobalMethods();
        pdeAGDAO = new WithdrawalPDEAGDAO();

        DataSet dstreas = new DataSet();
        dstreas = trnsdao.GetTreasury();

        DataSet dsstatus = new DataSet();
        dsstatus = pdeAGDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlSubTrCMAss = (DropDownList)grdVwRow.FindControl("ddlSubTrCM");
            gblobj.FillCombo(ddlSubTrCMAss, dstreas, 1);

            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatusCM");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);


        }
    }
    public void ShowGrid()
    {
        gblobj = new clsGlobalMethods();
        trnsdao = new TEDAO();
        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        dscrplus = trnsdao.FillCrMinusPDE(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCntWO.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCM.DataSource = dscrplus;
            gdvCM.DataBind();
            fillGridcombos(gdvCM);
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCM.Rows[i];
                DropDownList ddlSubTrCMAss = (DropDownList)gdv.FindControl("ddlSubTrCM");
                ddlSubTrCMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[13].ToString();

                DropDownList ddlStatusCMAss = (DropDownList)gdv.FindControl("ddlStatusCM");
                ddlStatusCMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[15].ToString();
                Label txtintId = (Label)gdv.FindControl("lblintId");
                txtintId.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvCM, 5, "txtAmtCM", 1);
            if (Convert.ToDouble(gdvCM.FooterRow.Cells[5].Text) > 0)
            {
                crAmtEntrd = Convert.ToDouble(gdvCM.FooterRow.Cells[5].Text.ToString());
            }
            else
            {
                crAmtEntrd = 0;
            }
        }
        else
        {
            SetGridDefaultCM();
        }

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        lSubSaveTERelMonthWiseForCrMinus();
        FillHeadLbls();
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvCM.Rows[i];
        TextBox txtChNCM = (TextBox)gdv.FindControl("txtChNCM");
        TextBox txtChDtCM = (TextBox)gdv.FindControl("txtChDtCM");
        TextBox txtAmtCM = (TextBox)gdv.FindControl("txtAmtCM");
        TextBox txtTeNoCM = (TextBox)gdv.FindControl("txtTeNoCM");

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
    public void lSubSaveTERelMonthWiseForCrMinus()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();
        int cnt = 0;
        for (int i = 0; i < gdvCM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvCM.Rows[i];
            DataSet ds = new DataSet();
            ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
            TextBox txtChDtCM = (TextBox)gdvrw.FindControl("txtChDtCM");
            if (MandatoryFlds(i) == true)
            {
                if (txtChDtCM.Text == "")
                {
                    ms.DtmChalanBilllDt = "";
                }
                else
                {
                    ms.DtmChalanBilllDt = txtChDtCM.Text.ToString();
                    DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
                    mnthId = billDate.Month;

                    ArrayList ardt = new ArrayList();
                    ardt.Add(txtChDtCM.Text.ToString());
                    yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
                    ms.IntRelMonthId = mnthId;
                    ms.IntRelYearId = yrId;
                }

                TextBox txtAmtCM = (TextBox)gdvrw.FindControl("txtAmtCM");
                if (txtAmtCM.Text == "")
                {
                    ms.FltAmtPDE = 0;
                }
                else
                {
                    ms.FltAmtPDE = Convert.ToDecimal(txtAmtCM.Text);
                }
                ms.IntTrnType = 2;

                DropDownList ddlSubTrCM = (DropDownList)gdvrw.FindControl("ddlSubTrCM");
                if (ddlSubTrCM.SelectedIndex > 0)
                {
                    ms.IntTreaId = Convert.ToInt32(ddlSubTrCM.SelectedValue);
                }
                else
                {
                    ms.IntTreaId = 0;
                }
                DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatusCM");

                if (ddlStatusAss.SelectedIndex > 0)
                {
                    ms.IntModeChg = Convert.ToInt32(ddlStatusAss.SelectedValue);
                }
                else
                {
                    ms.IntModeChg = 2;
                }

                TextBox txtRelMnthWiseIdWAss = (TextBox)gdvrw.FindControl("RelMnth");
                if (txtRelMnthWiseIdWAss.Text == "")
                {
                    ms.IntRelMonthWiseId = 0;
                }
                else
                {
                    ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdWAss.Text);
                }

                TextBox txtTeNoCM = (TextBox)gdvrw.FindControl("txtTeNoCM");
                if (txtTeNoCM.Text == "")
                {
                    ms.ChvTEIdPDE = "";
                }
                else
                {
                    ms.ChvTEIdPDE = txtTeNoCM.Text.ToString();
                }

                ds = msDao.TERelMonthWiseUpd(ms);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

                    TextBox txtRelMnthWise = (TextBox)gdvrw.FindControl("RelMnth");
                    txtRelMnthWise.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                    RelMnthID = ms.IntRelMonthWiseId;
                }
                lSubSaveCrMinus(i);
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

    private void lSubFillChalanId(int k)
    {
        //cr = new CreditMinusAG();
        crDao = new CreditMinusAGDAO();
        GridViewRow gdvrw = gdvCM.Rows[k];
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        TextBox txtChNCM = (TextBox)gdvrw.FindControl("txtChNCM");
        if (txtChNCM.Text == "")
        {
            cr.IntChalNo = 0;
        }
        else
        {
            cr.IntChalNo = Convert.ToInt32(txtChNCM.Text);

        }
        TextBox txtChDtCM = (TextBox)gdvrw.FindControl("txtChDtCM");
        if (txtChDtCM.Text == "")
        {
            cr.DtmChalDate = "";
        }
        else
        {
            cr.DtmChalDate = txtChDtCM.Text.ToString();

        }
        DropDownList ddlSubTrCM = (DropDownList)gdvrw.FindControl("ddlSubTrCM");

        if (ddlSubTrCM.SelectedIndex > 0)
        {
            cr.IntTreasId = Convert.ToInt32(ddlSubTrCM.SelectedValue);
        }
        else
        {
            cr.IntTreasId = 0;
        }
        ds = crDao.FillChalanId(cr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TextBox txtchalanId = (TextBox)gdvrw.FindControl("txtchalanId");
            txtchalanId .Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            ds = crDao.FillChalanIdfrmAG(cr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox txtChalanAGId = (TextBox)gdvrw.FindControl("txtChalanAGId");
                txtChalanAGId .Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
    }
    private void lSubSaveCrMinus(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        //cr = new CreditMinusAG();
        crDao = new CreditMinusAGDAO();

        GridViewRow gdvrw = gdvCM.Rows[j];
        Label txtintId = (Label)gdvrw.FindControl("lblintId");
        if (txtintId.Text == "")
        {
            cr.IntId = 0;
        }
        else
        {
            cr.IntId = Convert.ToInt32(txtintId.Text);

        }
        TextBox txtRelMnthWiseId = (TextBox)gdvrw.FindControl("RelMnth");
        if (txtRelMnthWiseId.Text == "")
        {
            cr.IntRelMonthWiseId = 0;
        }
        else
        {
            cr.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseId.Text);

        }
        TextBox txtTeNoCM = (TextBox)gdvrw.FindControl("txtTeNoCM");
        if (txtTeNoCM.Text == "")
        {
            cr.ChvTEId = "";
        }
        else
        {
            cr.ChvTEId = txtTeNoCM.Text.ToString();

        }
        TextBox txtChDtCM = (TextBox)gdvrw.FindControl("txtChDtCM");
        if (txtChDtCM.Text == "")
        {
            cr.DtmChalDate = "";
        }
        else
        {
            cr.DtmChalDate = txtChDtCM.Text.ToString();

            ArrayList ardt = new ArrayList();
            ardt.Add(txtChDtCM.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
        }

        TextBox txtChNCM = (TextBox)gdvrw.FindControl("txtChNCM");
        if (txtChNCM.Text == "")
        {
            cr.IntChalNo = 0;
        }
        else
        {
            cr.IntChalNo = Convert.ToInt32(txtChNCM.Text);

        }

        TextBox txtAcCM = (TextBox)gdvrw.FindControl("txtAcCM");
        if (txtAcCM.Text == "")
        {
            cr.ChvAccNo = "";
            
        }
        else
        {
            cr.ChvAccNo = txtAcCM.Text.ToString();
        }

        TextBox txtName = (TextBox)gdvrw.FindControl("txtName");
        if (txtName.Text == "")
        {
            cr.ChvName = "";
        }
        else
        {
            cr.ChvName = txtName.Text.ToString();
        }

        TextBox txtAmtCM = (TextBox)gdvrw.FindControl("txtAmtCM");
        if (txtAmtCM.Text == "")
        {
            cr.FltAmount = 0;
        }
        else
        {
            cr.FltAmount = Convert.ToDecimal(txtAmtCM.Text);
        }

        TextBox txtremCM = (TextBox)gdvrw.FindControl("txtremCM");
        if (txtremCM.Text == "")
        {
            cr.ChvRemarks = "";
        }
        else
        {
            cr.ChvRemarks = txtremCM.Text.ToString();
        }
        DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatusCM");

        if (ddlStatusAss.SelectedIndex > 0)
        {
            cr.IntModeChg = Convert.ToInt32(ddlStatusAss.SelectedValue);
        }
        else
        {
            cr.IntModeChg = 2;
        }
        lSubFillChalanId(j);

        TextBox txtchalanId = (TextBox)gdvrw.FindControl("txtchalanId");
        if (txtchalanId.Text == "")
        {
            cr.IntChalanId  = 0;
        }
        else
        {
            cr.IntChalanId = Convert.ToInt32(txtchalanId.Text);

        }
        TextBox txtChalanAGId = (TextBox)gdvrw.FindControl("txtChalanAGId");
        if (txtChalanAGId.Text == "")
        {
            cr.IntChalanAGID  = 0;
        }
        else
        {
            cr.IntChalanAGID = Convert.ToInt32(txtChalanAGId.Text);

        }

        DropDownList ddlSubTrCM = (DropDownList)gdvrw.FindControl("ddlSubTrCM");

        if (ddlSubTrCM.SelectedIndex > 0)
        {
            cr.IntTreasId = Convert.ToInt32(ddlSubTrCM.SelectedValue);
        }
        else
        {
            cr.IntTreasId = 0;
        }

        DataSet dsCrMinus = new DataSet();
        dsCrMinus = crDao.CreateCreditMinus(cr);

    }
    protected void txtAcCM_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnBackCM_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGstatementsPDE.aspx");
    }
 
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvCM);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvCM);
            DataSet ds = new DataSet();
            gdvCM.DataSource = dtgdRow;
            gdvCM.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvCM, ds);
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
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
       // myControls.Add(new ImageButton());
        myControls.Add(new TextBox());
        //myControls.Add(new TextBox());
        //myControls.Add(new TextBox());
        //myControls.Add(new TextBox());
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("txtTeNoCM");
        arrControlid.Add("txtChNCM");
        arrControlid.Add("txtChDtCM");
        arrControlid.Add("txtAmtCM");
        arrControlid.Add("ddlSubTrCM");
        arrControlid.Add("txtAcCM");
        arrControlid.Add("txtName");
        arrControlid.Add("txtremCM");
        arrControlid.Add("ddlStatusCM");
        arrControlid.Add("txtintId");
       // arrControlid.Add("btnAddFloorNew");
        //arrControlid.Add("RelMnthCr");
        //arrControlid.Add("RelYearIdCr");
        arrControlid.Add("RelMnth");
        //arrControlid.Add("txtchalanId");
        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
       // arrControlid.Add("SlNo");
        arrControlid.Add("chvTEId");
        arrControlid.Add("intChalNo");
        arrControlid.Add("dtmChalDate");
        arrControlid.Add("fltAmount");
        arrControlid.Add("intTreasId");
        arrControlid.Add("chvAccNo");
        arrControlid.Add("chvName");
        arrControlid.Add("chvRemarks");
        arrControlid.Add("intModeChg");
        arrControlid.Add("intId");
        //arrControlid.Add("intMonthId");
        //arrControlid.Add("intYearId");
        arrControlid.Add("intRelMonthWiseId");
        //arrControlid.Add("intChalanId");
        return arrControlid;
    }
 
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    }
    protected void gdFloorAreaDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvCM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void btnDeleteCr_Click(object sender, ImageClickEventArgs i)
    {
        gblobj = new clsGlobalMethods();
        crDao = new CreditMinusAGDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        //  int rowIndex = Convert.ToInt32(e.RowIndex);
        Label  txtintId = (Label)gdvCM.Rows[rowIndex].FindControl("lblintId");
        if (txtintId.Text !="")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(txtintId.Text));
            try
            {
                crDao.UpdCreditMinusModeofChnge(arrin);
              //  deleteUnsavedCrMinus();

            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
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
    private void deleteUnsavedCrMinus()
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvCM);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvCM.DataSource = dtgdRow;
            gdvCM.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            ShowGrid();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
        fillGridcombos(gdvCM);
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {
               
               if (ds.Tables[0].Rows.Count > 0)
                {
                   ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    DropDownList ddlSubTrCMAss = (DropDownList)gdRow.FindControl("ddlSubTrCM");
                    DropDownList ddlStatusCMAss = (DropDownList)gdRow.FindControl("ddlStatusCM");
                    
                    ddlSubTrCMAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][4].ToString();
                    ddlStatusCMAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][8].ToString();
                   
                    
                }
            }
       }
    }

    protected void txtChDtCM_TextChanged(object sender, EventArgs e)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();

        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCM.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtChDtCM");

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
    protected void txtCntWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        trnsdao = new TEDAO();
        if (txtCntWO.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlSubTrCM");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();
            DataSet dstreas = new DataSet();
            dstreas = trnsdao.GetTreasury(); 
           // dstreas = gendao.GetDisTreasuryWithOutDistId();  
            arDdlDs.Add(dstreas);
            ////Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrColsWO(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dscrplus = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            dscrplus = trnsdao.FillCrMinusPDEForCnt(arr);
           
            // dsdbplusBT = PDEAgDao.FillDBPlusPDEAddrw(arr);

            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("chvTEId");
            arHp.Add("intChalNo");
            arHp.Add("dtmChalDate");
            
            arHp.Add("fltAmount");
            arHp.Add("chvAccNo");
            arHp.Add("chvName");

            arHp.Add("chvRemarks");
            arHp.Add("intId");
            arHp.Add("intRelMonthWiseId");
            

            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(dscrplus, Convert.ToInt16(txtCntWO.Text), gdvCM, arDdl, arCols, arDdlDs, arHp);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCM, 1);
        }
    }
    private void SetArrColsWO(ArrayList arCols)
    {
        arCols.Add("txtTeNoCM");
        arCols.Add("txtChNCM");
        arCols.Add("txtChDtCM");
        arCols.Add("txtAmtCM");
        arCols.Add("ddlSubTrCM");
        arCols.Add("txtAcCM");
        arCols.Add("txtName");
        arCols.Add("txtremCM");
        arCols.Add("lblintId");
        //arCols.Add("btndeleteCr");
        arCols.Add("RelMnth");
        arCols.Add("txtchalanId");
    }
}
