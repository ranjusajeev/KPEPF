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

public partial class Contents_OpeningBalance : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    GeneralDAO gen;
    OB ob;
    OBDao obd;
    Employee emp;
    EmployeeDAO empDao;
    CorrectionEntry corr;
    CorrectionEntryDao corrDao;
    KPEPFGeneralDAO genDAO;
    int corrType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["intAccNo"]) > 0)
            {
                Session["intAccNoOb"] = Convert.ToInt32(Request.QueryString["intAccNo"]);
                Session["flgClosed"] = Convert.ToInt32(Request.QueryString["flgClosed"]);
                Session["flgMoC"] = Convert.ToInt32(Request.QueryString["flgMoC"]);
                InitialSettings();
                FillObDetSingle(Convert.ToInt32(Session["intAccNoOb"]));
                btnDel.Enabled = true;
                txtAccNo.ReadOnly = true;
                //lblCnt.Text = Session["lblCnt"].ToString();
            }
            else
            {
                InitialSettings();
                txtAccNo.ReadOnly = true;
                ddlDist.Enabled = true;
                txtOb.ReadOnly = true;
                Session["flgMoC"] = 0;
            }
        }
    }
    //private void FillTxts()
    //{
    //    ob = new OB();
    //    obd = new OBDao();

    //    ob.IntAccNo = Convert.ToInt16(Session["intAccNoOb"]);
    //    DataSet dsO1 = new DataSet();
    //    dsO1 = obd.GetObSingle(ob);
    //    if (dsO1.Tables[0].Rows.Count > 0)
    //    {
    //        ddlDist.SelectedValue = dsO1.Tables[0].Rows[0].ItemArray[5].ToString();
    //        Session["intDistOb"] = Convert.ToInt16(dsO1.Tables[0].Rows[0].ItemArray[5].ToString());
    //        txtAccNo.Text = dsO1.Tables[0].Rows[0].ItemArray[1].ToString();
    //        txtOb.Text = dsO1.Tables[0].Rows[0].ItemArray[3].ToString();
    //        lblAccNo.Text = dsO1.Tables[0].Rows[0].ItemArray[0].ToString();
    //        lblName.Text = dsO1.Tables[0].Rows[0].ItemArray[2].ToString();
    //        hdnOb.Text  = dsO1.Tables[0].Rows[0].ItemArray[3].ToString();
    //        Session["OldAmt"] =Convert.ToDouble(dsO1.Tables[0].Rows[0].ItemArray[3].ToString());
    //    }

    //    SetTxtsEnable();
    //}
    private void SetTxtsEnable()
    {
        txtAccNo.ReadOnly = false;
        ddlDist.Enabled = true;
        txtOb.ReadOnly = false;
        btnSave.Enabled = true;
    }
    private void SetTxtsDisable()
    {
        txtAccNo.ReadOnly = true;
        ddlDist.Enabled = false;
        txtOb.ReadOnly = true;
        btnSave.Enabled = false;
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
        hdnOb.Text  = "0";
        SetGridDefault();
        //Session["OldAmt"] = 0;
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("intAccNo");
        ar.Add("chvName");
        ar.Add("fltCB00_01");
        ar.Add("ClosureStat");
        ar.Add("flgClosed");
        ar.Add("flgMoC");
        ar.Add("dtmDate");
        gblObj.SetGridDefault(gdvRecM, ar);
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        {
            Session["intDistOb"] = Convert.ToInt16(ddlDist.SelectedValue);
        }
        else
        {
            Session["intDistOb"] = 0;
        }
        SetGridDefault();
        chkShow.Checked = false;
    }
    private void FillObDet()
    {
        ob = new OB();
        obd = new OBDao();

        ob.IntDistId = Convert.ToInt16(Session["intDistOb"]);
        DataSet dsO = new DataSet();
        dsO = obd.GetOb(ob);
        if (dsO.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsO;
            gdvRecM.DataBind();
        }
        for (int i = 0; i < gdvRecM.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvRecM.Rows[i];
            Label lblClosed = (Label)gdvrow.FindControl("lblClosed");
            lblClosed.Text = dsO.Tables[0].Rows[i].ItemArray[7].ToString();
            if (Convert.ToInt16(lblClosed.Text) == 1)
            {
                gdvrow.Enabled = false;
            }
            else
            {
                gdvrow.Enabled = true;
            }
        }
        lblCnt.Text = dsO.Tables[0].Rows.Count.ToString();
        Session["lblCnt"] = Convert.ToInt16(dsO.Tables[0].Rows.Count);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        ob = new OB();
        obd = new OBDao();

        ob.IntAccNo = Convert.ToInt16(Session["intAccNoOb"]);
        ob.FltAmount = Convert.ToInt64(txtOb.Text);
        ob.IntDistId = Convert.ToInt16(Session["intDistOb"]);
        ob.IntUserId = Convert.ToInt64(Session["intUserId"]);
        ob.IntMoC = Convert.ToInt16(Session["flgMoC"]);
        obd.SaveOb(ob);
        saveCorrectionEntry(ob.IntAccNo, 0);
        FillObDetSingle(Convert.ToInt32(Session["intAccNoOb"]));
        gblObj.MsgBoxOk("Updated!", this);
    }
    private Boolean ModifiedOb(int flgMoC, float fltAmount)
    {

        Boolean flg;
        if (flgMoC == 2)
        {
            flg = true;
        }
        else if (Convert.ToDouble(Session["OldAmt"]) != fltAmount)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 14;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 6;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 7;
            }
        }
    }
    private void saveCorrectionEntry(float schedId, int intDel)
    {
        gen = new GeneralDAO();
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        ArrayList ardt = new ArrayList();

        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gen.GetCCYearId() + 1;

        yr = 37;
        mth = 4;
        intDy = 1;

        amtO = Convert.ToDouble(hdnOb.Text);
        amtN = Convert.ToDouble(txtOb.Text);
        accO = Convert.ToInt32(hdnAcc.Text);
        accN = accO;

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 6)
        {
            amtCalc = amtN;
            corr.FltAmountBefore = 0;
            corr.FltAmountAfter = amtN;
            hdnAcc.Text = schedId.ToString();
        }
        else if (corrType == 14)
        {
            amtCalc = -amtN;
            corr.FltAmountBefore = amtN;
            corr.FltAmountAfter = 0;
        }
        else
        {
            amtCalc = amtN - amtO;
            corr.FltAmountBefore = amtO;
            corr.FltAmountAfter = amtN;
        }
        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
        ///// Save to CorrEntry/////////
        corr.IntAccNo = Convert.ToInt32(hdnAcc.Text);
        corr.IntYearID = yr;
        corr.IntMonthID = mth;
        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        corr.FltCalcAmount = dblAmtAdjusted;
        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
        corr.IntChalanId = schedId;
        corr.IntSchedId = schedId;
        corr.FlgType = 3;           //Remittance
        corr.FltRoundingAmt = 0;
        corr.IntCorrectionType = corrType;
        corr.IntChalanType = 2;
        corr.IntTblTp = 1;
        corrDao.CreateCorrEntryCalcTblTp(corr);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        txtSearch.ReadOnly = false;
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.CheckNumericOnly(txtAccNo.Text.ToString(), this) == true)
        {
            if (Convert.ToInt32(txtAccNo.Text) > 0)
            {
                Session["intAccNoOb"] = Convert.ToInt32(txtAccNo.Text);
                if (FillNameAccNo() == false)
                {
                    if (Convert.ToInt16(Session["flgExists"]) != 0)
                    {
                        gblObj.MsgBoxOk("Account No. doesn't exists.", this);
                    }

                    if (Convert.ToInt16(Session["flgDist"]) != 0)
                    {
                        gblObj.MsgBoxOk("Not belongs to this District.", this);
                    }

                    if (Convert.ToInt16(Session["flgBfr"]) != 1)
                    {
                        gblObj.MsgBoxOk("Do not have an OB as on 04/2001.", this);
                    }
                    SetTxtsDisable();
                }
                else
                {
                    FillObDetSingle(Convert.ToInt32(Session["intAccNoOb"]));
                    SetTxtsEnable();
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter Numeric Value", this);
            txtAccNo.Text = "";
            txtAccNo.Text = "";
        }
    }
    private Boolean FillNameAccNo()
    {
        emp = new Employee();
        empDao = new EmployeeDAO();

        Boolean flg = true;
        DataSet dsN = new DataSet();
        emp = new Employee();
        emp.NumEmpID = Convert.ToInt32(Session["intAccNoOb"]);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            Session["flgExists"] = 0;   // exists
            if (Convert.ToInt16(dsN.Tables[0].Rows[0].ItemArray[4]) == Convert.ToInt16(Session["intDistOb"]))
            {
                Session["flgDist"] = 0;  //belongs to dist
                lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
                lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
                //flg = true;
                Session["flgClosed"] = Convert.ToInt16(dsN.Tables[0].Rows[0].ItemArray[2]);
                if (Convert.ToInt16(dsN.Tables[0].Rows[0].ItemArray[10]) == 0)
                {
                    flg = true;
                    Session["flgBfr"] = 1;  //before 2001
                }
                else
                {
                    flg = false;
                    Session["flgBfr"] = 2;  //Not before 2001
                }
            }
            else
            {
                Session["flgDist"] = 1;  //Not belongs to dist
                flg = false;
                Session["flgBfr"] = 0;      //Not belongs to dist
            }
        }
        else
        {
            Session["flgExists"] = 1;  //Not exists
            flg = false;
        }
        return flg;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearCtrls();
        SetGridDefault();
        //Session["flgMoC"] = 2;
        //Session["intDistOb"] = 0;

        //txtAccNo.Text = "";
        //txtOb.Text = "";
        //lblAccNo.Text = "";
        //lblName.Text = "";
        //Session["intAccNoOb"] = 0;
        //ddlDist.SelectedValue = "0";
        //txtAccNo.ReadOnly = false;
        //ddlDist.Enabled = true;
        //txtOb.ReadOnly = false;
        //SetGridDefault();
    }
    private void ClearCtrls()
    {
        Session["flgMoC"] = 2;
        Session["intDistOb"] = 0;
        txtAccNo.Text = "";
        txtOb.Text = "";
        lblAccNo.Text = "";
        lblName.Text = "";
        Session["intAccNoOb"] = 0;
        ddlDist.SelectedValue = "0";
        txtAccNo.ReadOnly = false;
        ddlDist.Enabled = true;
        txtOb.ReadOnly = false;       
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtSearch.Text) > 0)
        {
            Session["intAccNoOb"] = Convert.ToInt32(txtSearch.Text);
            FillObDetSingle(Convert.ToInt32(Session["intAccNoOb"]));
            ClearCtrls();
            btnDel.Enabled = true;
            chkShow.Checked = false;
        }
    }
    private void FillObDetSingle(Int32 intAccNo)
    {
        gblObj = new clsGlobalMethods();
        ob = new OB();
        obd = new OBDao();

        ob.IntAccNo = intAccNo;
        DataSet dsOs = new DataSet();
        dsOs = obd.GetObSingle(ob);
        if (dsOs.Tables[0].Rows.Count > 0)
        {
            gdvRecM.DataSource = dsOs;
            gdvRecM.DataBind();
            txtAccNo.Text = dsOs.Tables[0].Rows[0].ItemArray[0].ToString();
            txtOb.Text = dsOs.Tables[0].Rows[0].ItemArray[3].ToString();
            ddlDist.SelectedValue = dsOs.Tables[0].Rows[0].ItemArray[5].ToString();
            hdnAcc.Text = dsOs.Tables[0].Rows[0].ItemArray[1].ToString();

            Session["intDistOb"] = Convert.ToInt16(dsOs.Tables[0].Rows[0].ItemArray[5].ToString());
            lblAccNo.Text = dsOs.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsOs.Tables[0].Rows[0].ItemArray[2].ToString();
            hdnOb.Text = dsOs.Tables[0].Rows[0].ItemArray[3].ToString();
        }
        else
        {
            gblObj.MsgBoxOk("Not added!", this);
            SetGridDefault();
        }
        SetTxtsEnable();
    }

    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (chkShow.Checked == true)
        {
            if (Convert.ToInt16(Session["intDistOb"]) > 0)
            {
                FillObDet();
            }
            else
            {
                gblObj.MsgBoxOk("Select District!!!", this);
            }
        }
        else
        {
            SetGridDefault();
        }
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        ob = new OB();
        obd = new OBDao();
        ob.IntAccNo = Convert.ToInt16(Session["intAccNoOb"]);
        obd.DelOb(ob);
        gblObj.MsgBoxOk("Deleted", this);
        saveCorrectionEntry(ob.IntAccNo, 1);
        ClearCtrls();
    }
}
