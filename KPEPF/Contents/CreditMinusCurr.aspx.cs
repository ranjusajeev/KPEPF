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


public partial class Contents_CreditMinusCurr : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    TE tranEntry = new TE();
    TEDAO trnsdao = new TEDAO();
    WithdrawalPDEAG pdeAG = new WithdrawalPDEAG();
    WithdrawalPDEAGDAO pdeAGDAO = new WithdrawalPDEAGDAO();
    CreditMinusAG cr = new CreditMinusAG();
    CreditMinusAGDAO crDao = new CreditMinusAGDAO();
    Missing ms = new Missing();
    MissingDAO msDao = new MissingDAO();
    ChalanDAO chDao;
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    public double crAmtEntrd;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ViewGrid();
            lblTot.Text = Session["dblAmtCrMinusCurr"].ToString();
            fillGridcombos(gdvCM);
            ShowGrid();
            SetEnable();
            FillHeadLbls();
        }
    }
    private void SetEnable()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            txtCnt.ReadOnly = false;
            btnSaveCM.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            txtCnt.ReadOnly = true;
            btnSaveCM.Enabled = false;
        }
    }
    private void FillHeadLbls()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        lblYear.Text = gendao.GetYearFromId(ar);

        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        lblMonth.Text = gendao.GetMonthFromId(ar1);

        lblTot.Text = Session["dblAmtCrMinusCurr"].ToString();
        lblTotE.Text = crAmtEntrd.ToString();
            //gdvCM.FooterRow.Cells[4].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private void SetCtrlsEnable()
    {
        //PnlCM.Enabled = true;
        gdvCM.Enabled = true;

    }
    private void SetCtrlsDisable()
    {
        //PnlCM.Enabled = false;
        gdvCM.Enabled = false;
    }
    private void ViewGrid()
    {
        SetGridDefaultCM();
        // gblobj.SetRowsCnt(gdvCM, 1);

    }
    private void SetGridDefaultCM()
    {
        ArrayList ar1 = new ArrayList();

        ar1.Add("SlNo");
        ar1.Add("chvTEId");
        ar1.Add("intChalBillNo");
        ar1.Add("dtmChalBillDate");
        ar1.Add("fltAmount");
        ar1.Add("intDTreasId");
        ar1.Add("chvAccNoAndName");
       
        ar1.Add("chvRemarks");
      
        ar1.Add("intId");
       
        gblobj.SetGridDefault(gdvCM, ar1);
        fillGridcombos(gdvCM);
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
            DropDownList ddlSubTrCMAss = (DropDownList)grdVwRow.FindControl("ddlSubTrCM");
            gblobj.FillCombo(ddlSubTrCMAss, dstreas, 1);

            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatusCM");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);


        }
    }
    public void ShowGrid()
    {
        SetGridDefaultCM();
        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();
      
        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        arr.Add(1);
        dscrplus = trnsdao.FillCrMinus(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCM.DataSource = dscrplus;
            gdvCM.DataBind();          

            fillGridcombos(gdvCM);
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCM.Rows[i];
                TextBox txtTeNoCMAss = (TextBox)gdv.FindControl("txtTeNoCM");
                txtTeNoCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtChNCMAss = (TextBox)gdv.FindControl("txtChNCM");
                txtChNCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtChDtCMAss = (TextBox)gdv.FindControl("txtChDtCM");
                txtChDtCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();



                DropDownList ddlSubTrCMAss = (DropDownList)gdv.FindControl("ddlSubTrCM");
                ddlSubTrCMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[6].ToString();


                TextBox txtAmtCMAss = (TextBox)gdv.FindControl("txtAmtCM");
                txtAmtCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAcCMAss = (TextBox)gdv.FindControl("txtAcCM");
                txtAcCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtremCMAss = (TextBox)gdv.FindControl("txtremCM");
                txtremCMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();


                Label lblintId = (Label)gdv.FindControl("lblintId");
                lblintId.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvCM, 4, "txtAmtCM", 1);
           // lblTotE.Text = gdvCM.FooterRow.Cells[4].Text.ToString();
            if (Convert.ToDouble(gdvCM.FooterRow.Cells[4].Text) > 0)
            {
                crAmtEntrd = Convert.ToDouble(gdvCM.FooterRow.Cells[4].Text.ToString());
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
        if (MandatoryCheck() == true)
        {
            SaveCreditMinus();
        }
        else
        {
            gblobj.MsgBoxOk("Enter all details.", this);
        }
        ShowGrid();
    }
    private Boolean MandatoryCheck()
    {
        Boolean flg = true;
        for (int i = 0; i < gdvCM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvCM.Rows[i];
            TextBox txtTeNoCM = (TextBox)gdvrw.FindControl("txtTeNoCM");
            TextBox txtAmtCM = (TextBox)gdvrw.FindControl("txtAmtCM");

            if (txtTeNoCM.Text.ToString() == "" || txtTeNoCM.Text.ToString() == "0" || txtAmtCM.Text.ToString() == "" || txtAmtCM.Text.ToString() == "0")
            {
                flg = false;
                break;
            }
            else
            {
                flg = true;
            }
        }
        return flg;
    }
    public void SaveCreditMinus()
    {
        for (int i = 0; i < gdvCM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvCM.Rows[i];
            DataSet ds = new DataSet();

            Label lblintId = (Label)gdvrw.FindControl("lblintId");
            //tranEntry.IntId = gblobj.IntId;


            if (lblintId.Text == "")
            {
                tranEntry.IntId = 0;
            }
            else
            {
                tranEntry.IntId = Convert.ToInt32(lblintId.Text.ToString());
            }


            //gblobj.IntId;
            //  tranEntry.IntId = Convert.ToInt32((gdvCM.DataKeys[i].Values[0].ToString()));

            tranEntry.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);

            //DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
            //chl.IntTreasuryId = Convert.ToInt32(ddlTreCPWOass.SelectedValue);

            //DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
            //chl.IntLBId = Convert.ToInt32(ddlLBAss.SelectedValue);




            TextBox txtTeNoCMAss = (TextBox)gdvrw.FindControl("txtTeNoCM");
            if (txtTeNoCMAss.Text == "")
            {
                tranEntry.ChvTEId = "";
            }
            else
            {
                tranEntry.ChvTEId = txtTeNoCMAss.Text;
            }


            tranEntry.FlgType = 1;

            TextBox txtChDtCMass = (TextBox)gdvrw.FindControl("txtChDtCM");
            if (txtChDtCMass.Text == "")
            {
                tranEntry.DtmChalBillDate = "";
            }
            else
            {
                tranEntry.DtmChalBillDate = txtChDtCMass.Text.ToString();
            }




            TextBox txtChNCMAss = (TextBox)gdvrw.FindControl("txtChNCM");
            if (txtChNCMAss.Text == "")
            {
                tranEntry.IntChalBillNo = 0;
            }
            else
            {
                tranEntry.IntChalBillNo = Convert.ToInt32(txtChNCMAss.Text.ToString());
            }



            TextBox txtAmtCMAss = (TextBox)gdvrw.FindControl("txtAmtCM");
            if (txtAmtCMAss.Text == "")
            {
                tranEntry.FltAmount = 0;
            }
            else
            {
                tranEntry.FltAmount = Convert.ToDecimal(txtAmtCMAss.Text);
            }


            TextBox txtAcCMAss = (TextBox)gdvrw.FindControl("txtAcCM");
            if (txtAcCMAss.Text == "")
            {
                tranEntry.ChvAccNoAndName = "";
            }
            else
            {

                tranEntry.ChvAccNoAndName = txtAcCMAss.Text.ToString();
            }

            TextBox txtremCMAss = (TextBox)gdvrw.FindControl("txtremCM");
            if (txtremCMAss.Text == "")
            {
                tranEntry.ChvRemarks = "";
            }
            else
            {

                tranEntry.ChvRemarks = txtremCMAss.Text.ToString();
            }



            tranEntry.IntModeChg = 1;

            DropDownList ddlSubTrCMAss = (DropDownList)gdvrw.FindControl("ddlSubTrCM");
            if (ddlSubTrCMAss.SelectedIndex > 0)
            {
                tranEntry.IntDTreasId = Convert.ToInt32(ddlSubTrCMAss.SelectedValue);
            }
            else
            {
                tranEntry.IntDTreasId = 0;
            }
            tranEntry.PerYearId = Convert.ToInt32( Session["intYearAGCurr"]);
            tranEntry.PerMnthId = Convert.ToInt32(Session["intMonthAGCurr"]);

            ds = trnsdao.CreateCreditMinus(tranEntry);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                // gblobj.IntId  = Convert.ToInt32 (ds.Tables[0].Rows[0].ItemArray[0]);
            }
        }
        gblobj.MsgBoxOk("Saved successfully", this);
    }
   
    
    private void lSubFillChalanId(int k)
    {
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
            txtchalanId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            ds = crDao.FillChalanIdfrmAG(cr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox txtChalanAGId = (TextBox)gdvrw.FindControl("txtChalanAGId");
                txtChalanAGId.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
    }
    private void lSubSaveCrMinus(int j)
    {
        //for (int i = 0; i < gdvCPW.Rows.Count; i++)
        //{
        GridViewRow gdvrw = gdvCM.Rows[j];
        TextBox lblintId = (TextBox)gdvrw.FindControl("lblintId");
        if (lblintId.Text == "")
        {
            cr.IntId = 0;
        }
        else
        {
            cr.IntId = Convert.ToInt32(lblintId.Text);

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

            // ms.IntRelYearId = yrId;

            //TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            //RelYearIdAss.Text = yrId.ToString();
            //
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
            cr.IntChalanId = 0;
        }
        else
        {
            cr.IntChalanId = Convert.ToInt32(txtchalanId.Text);

        }
        TextBox txtChalanAGId = (TextBox)gdvrw.FindControl("txtChalanAGId");
        if (txtChalanAGId.Text == "")
        {
            cr.IntChalanAGID = 0;
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
  
    //protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    //{

    //    List<Control> myControls = creategdFloorControl();
    //    ArrayList arrControlid = creategdFloorControlId();
    //    ArrayList arrDT = getDataTablegdFloor();
    //    bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvCM);
    //    if (chkLastRow)
    //    {
    //        DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvCM);
    //        DataSet ds = new DataSet();
    //        gdvCM.DataSource = dtgdRow;
    //        gdvCM.DataBind();
    //        ds.Tables.Add(dtgdRow);
    //        fillDropDownGridExistsFloor(gdvCM, ds);
    //    }
    //}
    //private List<Control> creategdFloorControl()
    //{
    //    List<Control> myControls = new List<Control>();
    //    // myControls.Add(new DropDownList());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new DropDownList());     
      
    //    myControls.Add(new TextBox());     
    //    myControls.Add(new TextBox());
    //    // myControls.Add(new ImageButton());
       
    //    //myControls.Add(new TextBox());
    //    //myControls.Add(new TextBox());
    //    //myControls.Add(new TextBox());
    //    return myControls;
    //}
    //private ArrayList creategdFloorControlId()
    //{
    //    ArrayList arrControlid = new ArrayList();
    //    //  arrControlid.Add("ddFloorArea");
    //    arrControlid.Add("txtTeNoCM");
    //    arrControlid.Add("txtChNCM");
    //    arrControlid.Add("txtChDtCM");
    //    arrControlid.Add("txtAmtCM");
    //    arrControlid.Add("txtAcCM");
    //    arrControlid.Add("ddlSubTrCM");
      
       
    //    arrControlid.Add("txtremCM");
      
    //    arrControlid.Add("lblintId");
    //    // arrControlid.Add("btnAddFloorNew");
    //    //arrControlid.Add("RelMnthCr");
    //    //arrControlid.Add("RelYearIdCr");
       
    //    return arrControlid;
    //}
    //private ArrayList getDataTablegdFloor()
    //{
    //    ArrayList arrControlid = new ArrayList();
    //    // arrControlid.Add("SlNo");
    //    arrControlid.Add("chvTEId");
    //    arrControlid.Add("intChalBillNo");
    //    arrControlid.Add("dtmChalBillDate");
    //    arrControlid.Add("fltAmount");
        
    //    arrControlid.Add("chvAccNoAndName");
    //    arrControlid.Add("intTreasId");
    //    arrControlid.Add("chvRemarks");
       
    //    arrControlid.Add("intId");
    //    //arrControlid.Add("intMonthId");
    //    //arrControlid.Add("intYearId");
    
    //    //arrControlid.Add("intChalanId");
    //    return arrControlid;
    //}

    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatements.aspx";
    }
    protected void gdFloorAreaDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvCM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    //protected void btnDeleteCr_Click(object sender, ImageClickEventArgs i)
    //{
    //    int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
    //    //  int rowIndex = Convert.ToInt32(e.RowIndex);
    //    TextBox lblintId = (TextBox)gdvCM.Rows[rowIndex].FindControl("lblintId");
    //    if (lblintId.Text != "")
    //    {
    //        ArrayList arrin = new ArrayList();
    //        arrin.Add(Convert.ToInt32(lblintId.Text));
    //        try
    //        {
    //            crDao.UpdCreditMinusModeofChnge(arrin);
    //            deleteUnsavedCrMinus();

    //        }
    //        catch (Exception ex)
    //        {
    //            Session["ERROR"] = ex.ToString();
    //            Response.Redirect("Error.aspx");
    //        }
    //    }
    //    ShowGrid();
    //    gblobj.MsgBoxOk("Row Deleted   !", this);

    //    FillHeadLbls();
    //    //}
    //    //else
    //    //{
    //    //}
    //}
    //private void deleteUnsavedCrMinus()
    //{
    //    List<Control> myControls = creategdFloorControl();
    //    ArrayList arrControlid = creategdFloorControlId();
    //    ArrayList arrDT = getDataTablegdFloor();
    //    DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvCM);
    //    if (dtgdRow.Rows.Count > 0)
    //    {
    //        DataSet ds = new DataSet();
    //        gdvCM.DataSource = dtgdRow;
    //        gdvCM.DataBind();
    //        ds.Tables.Add(dtgdRow);
    //        fillDropDownGridExistsFloor(gdvCM, ds);
    //    }
    //    else
    //    {
    //        ShowGrid();
    //    }
    //}
    //private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    //{
    //    fillGridcombos(gdvCM);
    //    foreach (GridViewRow gdRow in gdView.Rows)
    //    {
    //        if (ds.Tables.Count > 0)
    //        {

    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ArrayList arrin = new ArrayList();
    //                arrin.Add(Session["intLBID"].ToString());
    //                DropDownList ddlSubTrCMAss = (DropDownList)gdRow.FindControl("ddlSubTrCM");
                   

    //                ddlSubTrCMAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][8].ToString();
                    


    //            }
    //        }
    //    }
    //}

    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
         if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////


            
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlSubTrCM");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            DataSet dstreas = new DataSet();
            dstreas = trnsdao.GetTreasury();
            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dstreas);
            ////Store Temp in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
             DataSet dscrplus = new DataSet();
             ArrayList arr = new ArrayList();
          
             arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
             arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
             arr.Add(1);
             dscrplus = trnsdao.FillCrMinus4AddRw(arr);
            ////Ds to fill Grid//////////

             gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCM, arDdl, arCols, arDdlDs);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCM, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeNoCM");
        arCols.Add("txtChNCM");
        arCols.Add("txtChDtCM");
        arCols.Add("txtAmtCM");
        arCols.Add("ddlSubTrCM");
        arCols.Add("txtAcCM");
        arCols.Add("txtremCM");
        //arCols.Add("ddlStatusCM");
        arCols.Add("lblintId");
        //arCols.Add("txtchalanId");
        //arCols.Add("txtChalanAGId");

    }

    protected void txtChDtCM_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCM.Rows[index];
        TextBox txtChDtCM = (TextBox)gvr.FindControl("txtChDtCM");
        if (gblobj.isValidDate(txtChDtCM, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtChDtCM,"01/04/2001") == false)
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtChDtCM.Text = "";
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtChDtCM.Text = "";
        }

        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvCM.Rows[index];
        //TextBox txtDt = (TextBox)gvr.FindControl("txtChDtCM");

        //string dt1 = txtDt.Text.ToString();
        //string dt2 = "01/04/2001";
        //string dt3 = DateTime.Now.ToString();
        //if (gblobj.isValidDate(txtDt, this) == true)
        //{
        //    if (gblobj.CheckDate2(dt2, dt1) == true)
        //    {
        //        if (gblobj.CheckDate2(dt1, dt3) == true)
        //        {
        //            ArrayList ar = new ArrayList();
        //            ar.Add(txtDt.Text.ToString());
        //            Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);
        //        }
        //        else
        //        {
        //            gblobj.MsgBoxOk("Invalid Date", this);
        //            txtDt.Text = "";
        //        }
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
    protected void txtAmtCM_TextChanged(object sender, EventArgs e)
    {
        gblobj.SetFooterTotalsTempField(gdvCM, 4, "txtAmtCM", 1);
        lblTotE.Text = gdvCM.FooterRow.Cells[4].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        chDao = new ChalanDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblintId = (Label)gdvCM.Rows[rowIndex].FindControl("lblintId");

        if (lblintId.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblintId.Text));
            trnsdao.DelCrMinus(arrin);

            //Build April2022
            ArrayList procin = new ArrayList();
            procin.Add("CreditMinusCurr.aspx-Transfer Entry_Credit Minus- btnDelete_Click-event");
            procin.Add(Session["intUserId"]);
            procin.Add(Convert.ToInt64(lblintId.Text));
            chDao.Processtracking(procin);
        }
        ShowGrid();
        lblTot.Text = Session["dblAmtCrMinusCurr"].ToString();
        lblTotE.Text = crAmtEntrd.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

        gblobj.MsgBoxOk("Row Deleted   !", this);
    }
}