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

public partial class Contents_DebitMinusCurr : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    TE tranEntry = new TE();
    TEDAO trnsdao = new TEDAO();
    Missing ms = new Missing();
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
            lblTot.Text = Session["dblAmtDtMinusCurr"].ToString();
            fillGridcombos(gdvDM);
            ShowGrid();
            SetCtrls();
            FillHeadLbls();
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

        lblTot.Text = Session["dblAmtDtMinusCurr"].ToString();
        lblTotE.Text = DbAmtEntrd.ToString();
            //gdvDM.FooterRow.Cells[4].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0)
        {
            SetCtrlsEnable();
            txtCnt.ReadOnly = false;
            btnSave.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
            txtCnt.ReadOnly = true;
            btnSave.Enabled = false;
        }
    }
    private void SetCtrlsEnable()
    {
        gdvDM.Enabled = true;
    }
    private void SetCtrlsDisable()
    {
        gdvDM.Enabled = false;
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
        if (MandatoryCheck() == true)
        {
            SaveDebitMinus();
        }
        else
        {
            gblobj.MsgBoxOk("Enter all details.", this);
        }
        ShowGrid();
        lblTot.Text = Session["dblAmtDtMinusCurr"].ToString();
        lblTotE.Text = DbAmtEntrd.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private Boolean MandatoryCheck()
    {
        Boolean flg = true;
        for (int i = 0; i < gdvDM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvDM.Rows[i];
            TextBox txtTeNoDM = (TextBox)gdvrw.FindControl("txtTeNoDM");
            TextBox txtAmtDM = (TextBox)gdvrw.FindControl("txtAmtDM");

            if (txtTeNoDM.Text.ToString() == "" || txtTeNoDM.Text.ToString() == "0" || txtAmtDM.Text.ToString() == "" || txtAmtDM.Text.ToString() == "0")
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

    public void SaveDebitMinus()
    {
        for (int i = 0; i < gdvDM.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvDM.Rows[i];
            DataSet ds = new DataSet();

            Label lblintIdAss = (Label)gdvrw.FindControl("lblintId");
            if (lblintIdAss.Text == "")
            {
                tranEntry.IntId = 0;
            }
            else
            {
                tranEntry.IntId = Convert.ToInt32(lblintIdAss.Text.ToString());
            }
            tranEntry.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
            TextBox txtTeNoDMAss = (TextBox)gdvrw.FindControl("txtTeNoDM");
            if (txtTeNoDMAss.Text == "")
            {
                tranEntry.ChvTEId = "";
            }
            else
            {
                tranEntry.ChvTEId = txtTeNoDMAss.Text;
            }
            tranEntry.FlgType = 2;
            TextBox txtVdtDMAss = (TextBox)gdvrw.FindControl("txtVdtDM");
            if (txtVdtDMAss.Text == "")
            {
                tranEntry.DtmChalBillDate = "";
            }
            else
            {
                tranEntry.DtmChalBillDate = txtVdtDMAss.Text.ToString();
            }
            TextBox txtVnDMAss = (TextBox)gdvrw.FindControl("txtVnDM");
            if (txtVnDMAss.Text == "")
            {
                tranEntry.IntChalBillNo = 0;
            }
            else
            {
                tranEntry.IntChalBillNo = Convert.ToInt32(txtVnDMAss.Text.ToString());
            }
            TextBox txtAmtDMAss = (TextBox)gdvrw.FindControl("txtAmtDM");
            if (txtAmtDMAss.Text == "")
            {
                tranEntry.FltAmount = 0;
            }
            else
            {
                tranEntry.FltAmount = Convert.ToDecimal(txtAmtDMAss.Text);
            }
            TextBox txtaccnoAss = (TextBox)gdvrw.FindControl("txtaccno");
            if (txtaccnoAss.Text == "")
            {
                tranEntry.ChvAccNoAndName = "";
            }
            else
            {
                tranEntry.ChvAccNoAndName = txtaccnoAss.Text.ToString();
            }
            TextBox txtremDMAss = (TextBox)gdvrw.FindControl("txtremDM");
            if (txtremDMAss.Text == "")
            {
                tranEntry.ChvRemarks = "";
            }
            else
            {
                tranEntry.ChvRemarks = txtremDMAss.Text.ToString();
            }
            tranEntry.IntModeChg =1;
            DropDownList ddlTrDMAss = (DropDownList)gdvrw.FindControl("ddlTrDM");
            if (ddlTrDMAss.SelectedIndex > 0)
            {
                tranEntry.IntDTreasId = Convert.ToInt32(ddlTrDMAss.SelectedValue);
            }
            else
            {
                tranEntry.IntDTreasId = 0;
            }
            tranEntry.PerYearId = Convert.ToInt32(Session["intYearAGCurr"]);
            tranEntry.PerMnthId = Convert.ToInt32(Session["intMonthAGCurr"]);
            ds = trnsdao.CreateCreditMinus(tranEntry);
        }
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void ShowGrid()
    {
        SetGridDefaultDM();
        DataSet dscrplus = new DataSet();
        SetGridDefaultDM();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["intYearAGCurr"]));
        arr.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
        arr.Add(2);
        dscrplus = trnsdao.FillCrMinus(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvDM.DataSource = dscrplus;
            gdvDM.DataBind();

            fillGridcombos(gdvDM);
            for (int i = 0; i < dscrplus.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvDM.Rows[i];
                TextBox txtTeNoDMAss = (TextBox)gdv.FindControl("txtTeNoDM");
                txtTeNoDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtVnDMAss = (TextBox)gdv.FindControl("txtVnDM");
                txtVnDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtVdtDMAss = (TextBox)gdv.FindControl("txtVdtDM");
                txtVdtDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[1].ToString();

                DropDownList ddlTrDMAss = (DropDownList)gdv.FindControl("ddlTrDM");
                ddlTrDMAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[6].ToString();

                TextBox txtAmtDMAss = (TextBox)gdv.FindControl("txtAmtDM");
                txtAmtDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtaccnoAss = (TextBox)gdv.FindControl("txtaccno");
                txtaccnoAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtremDMAss = (TextBox)gdv.FindControl("txtremDM");
                txtremDMAss.Text = dscrplus.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblintId = (Label)gdv.FindControl("lblintId");
                lblintId.Text = dscrplus.Tables[0].Rows[i].ItemArray[8].ToString();

            }
            gblobj.SetFooterTotalsTempField(gdvDM, 4, "txtAmtDM", 1);
            //lblTotE.Text = gdvDM.FooterRow.Cells[4].Text.ToString();
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
   
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/AGStatements.aspx";
    }
    protected void ddlStatusDM_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gdvDM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void txtCntRow_TextChanged(object sender, EventArgs e)
    {
        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlTrDM");
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
            arr.Add(2);
            dscrplus = trnsdao.FillCrMinus4AddRw(arr);
            ////Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            //ArrayList arHp = new ArrayList();
            //arHp.Add("SlNo");
            //arHp.Add("numChalanId");
            //arHp.Add("flgApproval");
            //arHp.Add("flgPrevYear");
            //arHp.Add("intGroupId");
            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvDM, arDdl, arCols, arDdlDs);
        }
        else
        {
            gblobj.SetRowsCnt(gdvDM, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeNoDM");
        arCols.Add("txtVnDM");
        arCols.Add("txtVdtDM");
        arCols.Add("txtAmtDM");
        arCols.Add("ddlTrDM");
        arCols.Add("txtaccno");
        arCols.Add("txtremDM");
        //arCols.Add("ddlStatusCM");
        arCols.Add("lblintId");
        //arCols.Add("txtchalanId");
        //arCols.Add("txtChalanAGId");
    }
    protected void txtVdtDM_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDM.Rows[index];
        TextBox txtVdtDM = (TextBox)gvr.FindControl("txtVdtDM");
        if (gblobj.isValidDate(txtVdtDM, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtVdtDM, "01/04/2001") == false)
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtVdtDM.Text = "";
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtVdtDM.Text = "";
        }

        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvDM.Rows[index];
        //TextBox txtDt = (TextBox)gvr.FindControl("txtVdtDM");

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
    protected void txtAmtDM_TextChanged(object sender, EventArgs e)
    {
        gblobj.SetFooterTotalsTempField(gdvDM, 4, "txtAmtDM", 1);

        lblTot.Text = Session["dblAmtDtMinusCurr"].ToString();
        lblTotE.Text = DbAmtEntrd.ToString();
            //gdvDM.FooterRow.Cells[4].Text.ToString(); 
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));

    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblintId = (Label)gdvDM.Rows[rowIndex].FindControl("lblintId");

        if (lblintId.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(lblintId.Text));
            trnsdao.DelCrMinus(arrin);
        }
        ShowGrid();
        lblTot.Text = Session["dblAmtDtMinusCurr"].ToString();
        lblTotE.Text = DbAmtEntrd.ToString();
            //gdvDM.FooterRow.Cells[4].Text.ToString();
        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        //Build April2022
        ChalanDAO chDao = new ChalanDAO();
        ArrayList procin = new ArrayList();
        procin.Add("DebitMinusCurr.aspx-btnDelete_Click-DelCrMinus");
        procin.Add(Session["intUserId"]);
        procin.Add(Convert.ToInt64(lblintId.Text));
        chDao.Processtracking(procin);   
        gblobj.MsgBoxOk("Row Deleted   !", this);
    }
}

