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
using System.Data.SqlClient;
using KPEPFClassLibrary;

public partial class Contents_ClosureDetNew : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO gen;
    GeneralDAO gend;
    closurePDEDao clsrD;
    ClosurePDE clsr;
    Employee emp;
    EmployeeDAO empD;
    public int empstatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt64(Request.QueryString["intClosureId"]) > 0)
            {
                Session["intClosureId"] = Convert.ToInt32(Request.QueryString["intClosureId"]);
                fillDdls();
                FillTexts();
                FillGrid(Convert.ToInt16(Session["flgtp"]));
                if (Convert.ToInt16(Session["flgtp"]) == 1)
                {
                    ddlDistP.SelectedValue = Session["intDistP"].ToString();
                    ddlyrP.SelectedValue = Session["intyrP"].ToString(); //flgTp
                    rdCategory.Items[Convert.ToInt16(Session["flgtp"])].Selected = true;

                }
                else
                {
                    txtSearch.Text = Session["inaccno"].ToString();
                }
            }
            else
            {
                InitialSettings();
            }
        }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDist.SelectedIndex > 0)
        {
            Session["intDistC"] = Convert.ToInt16(ddlDist.SelectedValue);
            //FillGrid(Convert.ToInt16(Session["intDistC"]), 0, 0);
        }
        else
        {
            Session["intDistC"] = 0;
        }
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        gend = new GeneralDAO();
        SetGridDefault();
        fillDdls();
        Session["flgTp"] = 3;
        //DataSet dsY = new DataSet();
        //dsY = gen.GetDistrict();
        //gblObj.FillCombo(ddlDist, dsY, 1);
        //gblObj.FillCombo(ddlDistP, dsY, 1);

        //DataSet dsYr = new DataSet();
        //dsYr = gend.GetYearRem();
        //gblObj.FillCombo(ddlyrP, dsYr, 1);

        //Session["sort"] = 1;
        //Session["filter"] = 1;
    }
    private void fillDdls()
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        gend = new GeneralDAO();

        DataSet dsY = new DataSet();
        dsY = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, dsY, 1);
        gblObj.FillCombo(ddlDistP, dsY, 1);

        DataSet dsYr = new DataSet();
        dsYr = gend.GetYearRem();
        gblObj.FillCombo(ddlyrP, dsYr, 1);

        Session["sort"] = 1;
        Session["filter"] = 1;
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        ArrayList arc = new ArrayList();
        arc.Add("SlNo");
        arc.Add("AccNo");
        arc.Add("chvName");
        arc.Add("chvEngDistName");
        arc.Add("MonthYear");
        arc.Add("chvOrderNoDate");
        arc.Add("fltAmount");
        arc.Add("chvRemarks");
        arc.Add("intId");
        arc.Add("intSubSlNo");
        arc.Add("chvStatus");
        gblObj.SetGridDefault(gdvChalan, arc);
    }
    //private void SetGridDefaultP()
    //{
    //    gblObj = new clsGlobalMethods();
    //    ArrayList arc = new ArrayList();
    //    arc.Add("intAccNo");
    //    arc.Add("chvName");
    //    arc.Add("chvEngDistName");
    //    arc.Add("dtmMonthYear");
    //    arc.Add("chvOrderNoDate");
    //    arc.Add("fltAmount");
    //    arc.Add("chvRemarks");
    //    arc.Add("chvPF_No");
    //    gblObj.SetGridDefault(gdvRep, arc);
    //}
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        DataSet dsName = new DataSet();
        emp.NumEmpID = Convert.ToDouble(txtAccNo.Text.ToString());
        dsName = empD.GetEmployeeDetails(emp, 1);
        if (dsName.Tables[0].Rows.Count > 0)
        {
            txtAccNo.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
            txtName.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["inaccno"] = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
        }
        else
        {
            gblObj.MsgBoxOk("Doesn't exist!", this);
            txtAccNo.Text = "";
            txtName.Text = "";
        }
        if (txtAccNo.Text != "")
        {
            lSubCheckAccNoDistWise();
        }
    }
    public void lSubCheckAccNoDistWise()
    {
        gblObj = new clsGlobalMethods();
        clsrD = new closurePDEDao();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        if (Convert.ToInt32(ddlDist.SelectedValue) > 0)
        {
            arr.Add(ddlDist.SelectedValue);
            arr.Add(Convert.ToInt32(Session["inaccno"]));
            ds = clsrD.CheckAccNoDistWise(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) == 0)
                {
                    SetCtrlsDisable();
                    gblObj.MsgBoxOk("This Account Number does not belongs to this District", this);
                }
                else
                {
                    lSubCheckDupWithPartPayment();
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Select district", this);
        }

    }
    public void lSubCheckDupWithPartPayment()
    {
        gblObj = new clsGlobalMethods();
        clsrD = new closurePDEDao();
        DataSet dss = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["inaccno"]));
        dss = clsrD.CheckDupWithPartPayment(arr);
        if (dss.Tables[0].Rows.Count > 0)
        {
            empstatus = Convert.ToInt32(dss.Tables[0].Rows[0].ItemArray[0]);
            if (empstatus == 2 || empstatus == 0)
            {
                gblObj.MsgBoxOk("Already closed ", this);
                SetCtrlsDisable();
            }
            else
            {
                txtAccNo.Text = dss.Tables[0].Rows[0].ItemArray[2].ToString();
                txtName.Text = dss.Tables[0].Rows[0].ItemArray[1].ToString();
            }
        }
    }

    private void SetCtrlsDisable()
    {
        ddlTC.Enabled = false;
        txtMthYear.ReadOnly = true;
        txtOrderNo.ReadOnly = true;
        txtAmount.ReadOnly = true;
        txtRem.ReadOnly = true;
        btnAdd.Enabled = false;
    }
    private void SetCtrlsEnable()
    {
        ddlTC.Enabled = true;
        txtMthYear.ReadOnly = false;
        txtOrderNo.ReadOnly = false;
        txtAmount.ReadOnly = false;
        txtRem.ReadOnly = false;
        btnAdd.Enabled = true;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ddlDist.SelectedValue = "0";
        txtAccNo.Text = "";
        txtName.Text = "";
        txtMthYear.Text = "";
        txtOrderNo.Text = "";
        txtAmount.Text = "";
        txtRem.Text = "";
        ddlTC.SelectedValue = "0";
        Session["intClosureId"] = 0;
        txtSearch.Text = "";
        SetGridDefault();
        SetCtrlsEnable();
        txtRet.Text = "";
        txtInt.Text = "";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (CheckMandatory(ddlDist, txtAccNo, txtName, txtMthYear, txtOrderNo, txtAmount, ddlTC) == true)
        {
            SaveClosure();
            ClearCtrls();
            UpdateEmpMaster(Convert.ToInt32(Session["inaccno"])); //Build April 2022 06/05/22

            gblObj.MsgBoxOk("Saved successfully!", this);
            FillTexts();
        }
    }
    private void FillTexts()
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        clsrD = new closurePDEDao();
        DataSet dsClos = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intClosureId"]));
        dsClos = clsrD.FillClosureDetInd(ar);
        if (dsClos.Tables[0].Rows.Count > 0)
        {
            //DataSet dsY = new DataSet();
            //dsY = gen.GetDistrict();
            //gblObj.FillCombo(ddlDist, dsY, 1);
            ddlDist.SelectedValue = dsClos.Tables[0].Rows[0].ItemArray[10].ToString();
            txtMthYear.Text = dsClos.Tables[0].Rows[0].ItemArray[4].ToString();
            txtAccNo.Text = dsClos.Tables[0].Rows[0].ItemArray[1].ToString();
            Session["intAccNoC"] = dsClos.Tables[0].Rows[0].ItemArray[8].ToString();
            txtOrderNo.Text = dsClos.Tables[0].Rows[0].ItemArray[5].ToString();
            txtName.Text = dsClos.Tables[0].Rows[0].ItemArray[2].ToString();
            ddlTC.SelectedValue = dsClos.Tables[0].Rows[0].ItemArray[16].ToString();
            txtRem.Text = dsClos.Tables[0].Rows[0].ItemArray[14].ToString();
            txtAmount.Text = dsClos.Tables[0].Rows[0].ItemArray[6].ToString();
            Session["intClosureId"] = dsClos.Tables[0].Rows[0].ItemArray[7].ToString();
            //txtSearch.Text  = dsClos.Tables[0].Rows[0].ItemArray[8].ToString();

            txtRet.Text = dsClos.Tables[0].Rows[0].ItemArray[17].ToString();
            txtInt.Text = dsClos.Tables[0].Rows[0].ItemArray[18].ToString();

        }
    }
    private Boolean CheckMandatory(DropDownList ddlDist, TextBox txtAccNo, TextBox txtName, TextBox txtMthYear, TextBox txtOrderNo, TextBox txtAmount, DropDownList ddlTC)
    {
        gblObj = new clsGlobalMethods();
        Boolean flg = true;

        if (ddlDist.SelectedValue == "0" || (txtAccNo.Text) == "" || Convert.ToString(txtName.Text) == "" ||
            Convert.ToString(txtMthYear.Text) == "" || Convert.ToString(txtOrderNo.Text) == "" || Convert.ToDouble(txtAmount.Text) == 0 || ddlTC.SelectedValue == "0")
        {
            gblObj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private int lFunFindSubSlNo()
    {
        clsrD = new closurePDEDao();
        int subslno;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["intAccNoC"]));
        ds = clsrD.FindSubSlno(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if ((Convert.ToInt16(Session["intClosureId"])) == 0)
            {
                subslno = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) + 1;
            }
            else
            {
                subslno = Convert.ToInt32(Request.QueryString["intSubSlNo"]);
            }
        }
        else
        {
            subslno = 1;
        }
        return subslno;
    }
    private int lFunFindPartPayment()
    {
        int partpymnt = 0;
        if (chkP.Checked == true)
        {
            partpymnt = 1;
        }
        else
        {
            if (empstatus == 1)
            {
                partpymnt = 2;
            }
            else if (empstatus == 3)
            {
                partpymnt = 0;
            }
        }
        return partpymnt;
    }

    public void SaveClosure()
    {
        gblObj = new clsGlobalMethods();
        gen = new KPEPFGeneralDAO();
        clsrD = new closurePDEDao();
        clsr = new ClosurePDE();

        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        clsr.IntDistId = Convert.ToInt32(ddlDist.SelectedValue);
        clsr.IntAccNo = Convert.ToInt32(Session["inaccno"]); //Build April 2022 06/05/22
        ArrayList ardt = new ArrayList();
        //ardt.Add("01/" + txtMthYear.Text.ToString());
        ardt.Add(txtMthYear.Text.ToString());
        clsr.IntYearId = gen.gFunFindPDEYearIdFromDate(ardt);
        clsr.ChvOrderNoDate = txtOrderNo.Text;
        //clsr.DtmMonthYear = "01/" + txtMthYear.Text.ToString();
        clsr.DtmMonthYear = txtMthYear.Text.ToString();
        clsr.FltAmount = Convert.ToDouble(txtAmount.Text);
        clsr.IntSubSlNo = lFunFindSubSlNo();
        clsr.FlgPartPayment = lFunFindPartPayment();
        clsr.IntId = Convert.ToInt16(Session["intClosureId"]);
        clsr.ChvSubSlNo = "";
        clsr.ChvRemarks = txtRem.Text;
        clsr.IntTCType = Convert.ToInt32(ddlTC.SelectedValue);

        clsr.DtmRetired = txtRet.Text.ToString();
        clsr.DtmInerest = txtInt.Text.ToString();

        ds = clsrD.CreateClosureDetails(clsr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intClosureId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        gblObj.MsgBoxOk("Saved!", this);
    }
    private void ClearCtrls()
    {
        ddlDist.SelectedValue = "0";
        txtMthYear.Text = "";
        txtAccNo.Text = "";
        txtOrderNo.Text = "";
        txtName.Text = "";
        ddlTC.SelectedValue = "0";
        txtRem.Text = "";
        txtAmount.Text = "0";
    }
    private void UpdateEmpMaster(int acc)
    {
        clsrD = new closurePDEDao();
        clsr = new ClosurePDE();

        DataSet dsemp = new DataSet();
        ArrayList arr = new ArrayList();
        clsr.IntAccNo = acc;
        dsemp = clsrD.lSubUpdEmp_MST(clsr);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        clsrD = new closurePDEDao();
        if (txtAccNo.Text != "" && txtAccNo.Text != null)
        {
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt16(Session["intClosureId"]));
            clsrD.DelClosureDetails(ar);
            gblObj.MsgBoxOk("Deleted!", this);
            FillGrid(Convert.ToInt16(Session["flgtp"]));
            ClearCtrls();
        }
        else
        {
            gblObj.MsgBoxOk("Select Acc. No.!", this);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        Session["flgtp"] = 2;
        if (txtSearch.Text != null && txtSearch.Text != "")
        {
            Session["inaccno"] = Convert.ToInt32(txtSearch.Text);
            FillGrid(2);
        }
        else
        {
            gblObj.MsgBoxOk("Enter Account No.", this);
        }
    }
    private void FillGrid(int tp)
    {
        gblObj = new clsGlobalMethods();
        clsrD = new closurePDEDao();
        SetGridDefault();

        DataSet dsChal = new DataSet();
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(Session["flgtp"]) == 1)
        {
            ar.Add(Convert.ToInt16(Session["flgTp"]));
            ar.Add(Convert.ToInt16(Session["intDistP"]));
            ar.Add(Convert.ToInt16(Session["intyrP"]));
            dsChal = clsrD.ClosureDetPrint(ar);

        }
        else
        {
            ar.Add(Convert.ToInt32(Session["inaccno"]));
            dsChal = clsrD.FillClosureDetAcc(ar);
        }
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            lblCnt.Text = dsChal.Tables[0].Rows.Count.ToString();
            gdvChalan.DataSource = dsChal;
            gdvChalan.DataBind();
            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvChalan.Rows[i];

                Label lblSlNo = (Label)gdv.FindControl("lblSlNo");
                lblSlNo.Text = Convert.ToString(i + 1);
            }
            gblObj.SetFooterTotals(gdvChalan, 6);
        }
        else
        {
            gblObj.MsgBoxOk("No such Employee!", this);
            SetGridDefault();
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        Session["flgtp"] = 1;
        if (Convert.ToInt16(Session["flgTp"]) > 0 && Convert.ToInt16(Session["intDistP"]) > 0 && Convert.ToInt16(Session["intyrP"]) > 0)
        {
            //fillRepGrid();
            FillGrid(1);
        }
        else
        {
            gblObj.MsgBoxOk("Select all details!", this);
        }
    }
    protected void gdvChalan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtMthYear_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtMthYear, this) == true)
        {
            if (gblObj.CheckDate2(txtMthYear.Text.ToString(), DateTime.Now.ToString()) == false)
            {
                gblObj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtMthYear.Text = "";
        }

        //gblObj = new clsGlobalMethods();
        //string Mnth = "";
        //string yr = "";
        //string dt;
        //int ln;
        //if (Convert.ToInt16(txtMthYear.Text.Length) == 7)
        //{

        //    dt = txtMthYear.Text;
        //    Mnth = dt.Substring(0, 2);
        //    yr = dt.Substring(3);
        //    ln = yr.Length;
        //    if (Convert.ToInt32(Mnth) > 12 || Convert.ToInt32(Mnth) <= 0)
        //    {
        //        gblObj.MsgBoxOk("Invalid Month", this);
        //    }
        //    if (Convert.ToInt32(yr) < 4)
        //    {
        //        gblObj.MsgBoxOk("Invalid year", this);
        //    }

        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Invalid year", this);
        //}
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdCategory.Items[0].Selected == true)
        {
            Session["flgTp"] = 3;
        }
        else if (rdCategory.Items[1].Selected == true)
        {
            Session["flgTp"] = 1;
        }
        else
        {
            Session["flgTp"] = 2;
        }

    }
    //private void fillRepGrid()
    //{
    //    clsrD = new closurePDEDao();
    //    gblObj = new clsGlobalMethods();
    //    ArrayList ar = new ArrayList();
    //    DataSet dsr = new DataSet();
    //    SetGridDefaultP();
    //    ar.Add(Convert.ToInt16(Session["flgTp"]));
    //    ar.Add(Convert.ToInt16(Session["intDistP"]));
    //    ar.Add(Convert.ToInt16(Session["intyrP"]));
    //    dsr = clsrD.ClosureDetPrint(ar);
    //    if (dsr.Tables[0].Rows.Count > 0)
    //    {
    //        lblCnt.Text = dsr.Tables[0].Rows.Count.ToString();
    //        gdvRep.DataSource = dsr;
    //        gdvRep.DataBind();
    //    }
    //    for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
    //    {
    //        GridViewRow gdv = gdvRep.Rows[i];

    //        Label lblSlNo = (Label)gdv.FindControl("lblSlNo1");
    //        lblSlNo.Text = Convert.ToString(i + 1);
    //    }
    //    gblObj.SetFooterTotals(gdvRep, 6);
    //}
    protected void ddlDistP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistP.SelectedIndex > 0)
        {
            Session["intDistP"] = Convert.ToInt16(ddlDistP.SelectedValue);

        }
        else
        {
            Session["intDistP"] = 0;
        }
    }
    protected void ddlyrP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyrP.SelectedIndex > 0)
        {
            Session["intyrP"] = Convert.ToInt16(ddlyrP.SelectedValue);

        }
        else
        {
            Session["intyrP"] = 0;
        }
    }
    protected void txtRet_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtRet, this) == true)
        {
            if (gblObj.CheckDate2(txtRet.Text.ToString(), DateTime.Now.ToString()) == false)
            //if (checkDateInt(txtRet.Text.ToString(), txtInt.Text.ToString()) == false)
            {
                gblObj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtRet.Text = "";
        }
    }
    protected void txtInt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtInt, this) == true)
        {
            //if (gblObj.CheckDate2(txtInt.Text.ToString(), DateTime.Now.ToString()) == false)
            //{
            //    gblObj.MsgBoxOk("Invalid Date", this);
            //}
            // commented on 05102021 
           // if (checkDateInt(txtRet.Text.ToString(), txtInt.Text.ToString()) == false) // Validation removed as per the direction from AO,KPEPF
           // {
             //   gblObj.MsgBoxOk("Invalid Date", this);
            //}
            //16072021
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtInt.Text = "";
        }
    }
    private Boolean checkDateInt(string dt1, string dt2)
    {
        Boolean flg = true;
        DateTime dt3;
        dt3 = Convert.ToDateTime(dt1).AddMonths(6);
        if (dt3 > Convert.ToDateTime(dt2) && Convert.ToDateTime(dt2) > Convert.ToDateTime(dt1))
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
}
