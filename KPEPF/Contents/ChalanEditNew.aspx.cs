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

public partial class Contents_ChalanEditNew : System.Web.UI.Page
{
    //KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    //GeneralDAO gendao = new GeneralDAO();
    //clsGlobalMethods gblObj = new clsGlobalMethods();
    //ChalanDAO chaldao = new ChalanDAO();
    //Chalan chal = new Chalan();
    //Schedule sch = new Schedule();
    //ScheduleDAO schDao = new ScheduleDAO();
    //Employee emp = new Employee();
    //EmployeeDAO empD = new EmployeeDAO();
    //CorrectionEntry corr = new CorrectionEntry();
    //CorrectionEntryDao corrDao = new CorrectionEntryDao();

    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblObj;
    ChalanDAO chaldao;
    Chalan chal;
    Schedule sch;
    ScheduleDAO schDao;
    Employee emp;
    EmployeeDAO empD;
    CorrectionEntry corr;
    CorrectionEntryDao corrDao;

    static int intCurRw = 0;
    static int intCurRwChal = 0;
    static int intCurRwSched = 0;
    static int intMth = 0;
    static int intDy = 0;
    //static int intYrId = 0;
    //static int intChalId = 0;
    //static double fltAmtBfr = 0;
    //static double fltAmtAfr = 0;
    static int corrType = 0; 
    //static int intMaxRecNo = 0;
    static int intCnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
        }
    }
    private void Initialsettings()
    {
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)   //Search  Session["numChalanIdEdit"]
        {
            btnBack.Text = "Back to Search";
            Session["IntYearSearchChal"] = Convert.ToDouble(Request.QueryString["PDEYear"]);
            //Session["IntYearSearchChal"] = Convert.ToDouble(Request.QueryString["PerYearId"]);
            Session["intMonthSearchChal"] = Convert.ToDouble(Request.QueryString["PerMonthId"]);
            Session["intDistSearchChal"] = Convert.ToDouble(Request.QueryString["intDistID"]);
            //Session["intYearSearchChalToFill"] = Convert.ToDouble(Request.QueryString["PerYearId"]);

            Session["numChalanIdOnline"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
            Session["flgPrevYear"] = Convert.ToDouble(Request.QueryString["flgPrevYear"]);
            Session["flgApproval"] = Convert.ToDouble(Request.QueryString["flgApproval"]);
            Session["intGroupId"] = Convert.ToDouble(Request.QueryString["intGroupId"]);
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2 || Convert.ToInt16(Session["flgPageBack"]) == 4)      //Remittance page
        {
            if (Request.QueryString["numChalanId"] != "")
            {
                Session["numChalanIdOnline"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
                Session["flgChalanTypeOnline"] = Convert.ToDouble(Request.QueryString["flgChalanType"]);
                Session["flgApproval"] = Convert.ToDouble(Session["flgAppTOnline"]);
                btnBack.Text = "Back to Chalan Entry";
                if (Convert.ToDouble(Session["numChalanIdOnline"]) == 0)
                {
                    Session["Sessionclear"] = 1;
                    Response.Redirect("Remittance.aspx");
                }
            }
            else
            {
                Session["Sessionclear"] = 1;
                Response.Redirect("Remittance.aspx");
            }
        }//Session["flgPageBack"]
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)      //Ann Stamnt page
        {
            Session["numChalanIdOnline"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
            //Session["flgChalanTypeOnline"] = Convert.ToDouble(Request.QueryString["flgChalanType"]);
            Session["PerMonthId"] = Convert.ToDouble(Request.QueryString["PerMonthId"]);
            Session["intDistID"] = Convert.ToDouble(Request.QueryString["intDistID"]);
            Session["flgApproval"] = Convert.ToDouble(Request.QueryString["flgApproval"]);
            btnBack.Text = "Back to Ann. Statement ";
            if (Convert.ToDouble(Session["NumEmpIdAnnStmnt"]) == 0)
            {
                Response.Redirect("AnnStatement.aspx");
            }
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5)      //AG Stmnt
        {
            if ((Request.QueryString["numChalanId"] == "") || (Request.QueryString["numChalanId"] == "0"))
            {
                Response.Redirect("TransferEntryCurr.aspx");
            }
            else
            {
                Session["numChalanIdOnline"] = Convert.ToDouble(Request.QueryString["numChalanId"]);

                //Session["flgChalanTypeOnline"] = Convert.ToDouble(Request.QueryString["flgChalanType"]);
                // Session["flgApproval"] = Convert.ToDouble(Session["flgAppTOnline"]);
                btnBack.Text = "Back to Transfer Entry";
            }
            //if (Convert.ToDouble(Session["numChalanIdOnline"]) == 0)
            //{
            //    Response.Redirect("TransferEntryCurr.aspx");
            //}
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 7)      //AG Stmnt
        {
            if (Request.QueryString["numChalanId"] == "" || Request.QueryString["numChalanId"] == "0")
            {
                Response.Redirect("Daer1.aspx");
            }
            else
            {
                Session["numChalanIdOnline"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
                if (Convert.ToInt32(Session["trnTypeAG"]) == 10)
                {
                    btnBack.Text = "Back to DAER";
                }
                else if (Convert.ToInt32(Session["trnTypeAG"]) == 20)
                {
                    btnBack.Text = "Back to OAO";
                }

            }
            //if (Convert.ToDouble(Session["numChalanIdOnline"]) == 0)
            //{
            //    Response.Redirect("TransferEntryCurr.aspx");
            //}
        }
        //Session["numChalanIdEdit"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
        //Session["flgPrevYear"] = Convert.ToDouble(Request.QueryString["flgPrevYear"]);
        //Session["flgApproval"] = Convert.ToDouble(Request.QueryString["flgApproval"]);
        //Session["intGroupId"] = Convert.ToDouble(Request.QueryString["intGroupId"]);
        if (Convert.ToInt32(Session["flgChalanTypeOnline"]) != 4)
        {
            FillGrid();
            FillGridSched();
            SetGrids();
            SetLbls();
            SetCtrls();
        }
        else
        {
            if (Convert.ToInt16(Session["flgPageBack"]) == 2)      //Rem14-15
            {
                Session["Sessionclear"] = 1;
                Response.Redirect("Remittance.aspx");
            }
            else
            {
                Response.Redirect("RemittanceCurr.aspx");
            }
        }
        Session["SessionClear"] = 1;
    }
    private void SetLbls()
    {
        gendao = new GeneralDAO();

        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ArrayList ard = new ArrayList();
        ArrayList ardt = new ArrayList();

        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            ar.Add(Convert.ToInt16(Session["intYearSearchChalToFill"]));
            arm.Add(Convert.ToInt16(Session["intMonthSearchChal"]));
            ard.Add(Convert.ToInt16(Session["intDistSearchChal"]));
            ardt.Add(Convert.ToInt16(Request.QueryString["IntTreIdRemi"]));

        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2 || Convert.ToInt16(Session["flgPageBack"]) == 4)
        {
            ar.Add(Convert.ToInt16(Session["IntYearIdRemi"]));
            //arm.Add(Convert.ToInt16(Request.QueryString["IntMonthIdRemi"]));
            arm.Add(Convert.ToInt16(Session["IntMonthIdRemi"]));
            //ard.Add(Convert.ToInt16(Request.QueryString["IntDistRemi"]));
            //ardt.Add(Convert.ToInt16(Request.QueryString["IntTreIdRemi"]));
            ard.Add(Convert.ToInt16(Session["IntDistRemi"]));
            ardt.Add(Convert.ToInt16(Session["IntTreIdRemi"]));


        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
        {
            ar.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
            //arm.Add(Convert.ToInt16(Request.QueryString["IntMonthIdRemi"]));
            arm.Add(Convert.ToInt16(Session["PerMonthId"]));
            ard.Add(Convert.ToInt16(Session["intDistID"]));
            ardt.Add(1111);
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)      //AG Stmnt
        {
            ar.Add(Convert.ToInt16(Session["intYearAGCurr"]));
            //arm.Add(Convert.ToInt16(Request.QueryString["IntMonthIdRemi"]));
            arm.Add(Convert.ToInt16(Session["intMonthAGCurr"]));
            ard.Add(Convert.ToInt16(Session["intDistID"]));
            ardt.Add(1111);
        }
        lblYear.Text = gendao.GetYearFromId(ar);
        lblMonth.Text = gendao.GetMonthFromId(arm);
        if (Convert.ToInt16(Session["flgPageBack"]) != 5)
        {
            lblDist.Text = gendao.GetDistrictFromId(ard);
            lblDistt.Text = gendao.GetDisTreasuryFromId(ardt);
        }
        //if (Convert.ToInt16(Session["flgAppTOnline"]) == 1)  //flgApproval
        //if (Convert.ToInt16(Session["flgApproval"]) == 1)
        //{
        //    SetGridsDisable();
        //}
        //else
        //{
        //    SetGridsEnable();
        //}
    }
    private void SetCtrls()
    {
        //if (Convert.ToInt16(Session["flgAppWith"]) == 2 || Convert.ToInt16(Session["flgAppWith"]) == 0)  
        if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)
        {
            if (Convert.ToInt16(Session["flgAppAgCurr"]) == 2 || Convert.ToInt16(Session["flgAppAgCurr"]) == 0 || Convert.ToInt16(Session["flgAppAgCurr"]) == 10)
            {
                SetGridsEnable();
            }
            else
            {
                SetGridsDisable();
            }
        }
        else
        {
            if (Convert.ToInt16(Session["flgApproval"]) == 2 || Convert.ToInt16(Session["flgApproval"]) == 0 || Convert.ToInt16(Session["flgApproval"]) == 10)
            {
                SetGridsEnable();
            }
            else
            {
                SetGridsDisable();
            }
        }
    }
    private void SetGridsDisable()
    {
        btnOK.Enabled = false;
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gdv = gdvAOApprov.Rows[i];
            TextBox txtNoAss = (TextBox)gdv.FindControl("txtNo");
            TextBox txtdateAss = (TextBox)gdv.FindControl("txtdate");
            TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
            CheckBox chkAppAss = (CheckBox)gdv.FindControl("chkApp");
            //DropDownList ddlReasonAss = (DropDownList)gdv.FindControl("ddlReason");

            txtdateAss.ReadOnly = true;
            txtNoAss.ReadOnly = true;
            txtAmtAss.ReadOnly = true;
            chkAppAss.Enabled = false;
            //ddlReasonAss.Enabled = false;

        }

        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gdv = gdvAOApprovSched.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
            CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
            TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
            TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
            TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
            TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
            TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
            DropDownList ddlGo = (DropDownList)gdv.FindControl("ddlGo");
            ImageButton btndeleteCrAss = (ImageButton)gdv.FindControl("btndeleteCr");
            DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
            DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");

            txtAccNoAss.ReadOnly = true;
            chkUnIdentAss.Enabled = false;
            txtSubnAss.ReadOnly = true;
            txtRepAss.ReadOnly = true;
            txtPfAss.ReadOnly = true;
            txtDaAss.ReadOnly = true;
            txtPayAss.ReadOnly = true;
            ddlGo.Enabled = false;
            btndeleteCrAss.Enabled = false;
            ddlFm.Enabled = false;
            ddlTm.Enabled = false;
        }
        txtCnt.Enabled = false;
    }
    private void SetGridsEnable()
    {
        btnOK.Enabled = true;
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gdv = gdvAOApprov.Rows[i];
            TextBox txtNoAss = (TextBox)gdv.FindControl("txtNo");
            TextBox txtdateAss = (TextBox)gdv.FindControl("txtdate");
            TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
            CheckBox chkAppAss = (CheckBox)gdv.FindControl("chkApp");
            //DropDownList ddlReasonAss = (DropDownList)gdv.FindControl("ddlReason");


            txtdateAss.ReadOnly = false;
            txtNoAss.ReadOnly = false;
            txtAmtAss.ReadOnly = false;
            chkAppAss.Enabled = true;
            //ddlReasonAss.Enabled = true ;

        }
        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gdv = gdvAOApprovSched.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
            CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
            TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
            TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
            TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
            TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
            TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
            DropDownList ddlGo = (DropDownList)gdv.FindControl("ddlGo");
            ImageButton btndeleteCrAss = (ImageButton)gdv.FindControl("btndeleteCr");
            DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
            DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");

            txtAccNoAss.ReadOnly = false;
            chkUnIdentAss.Enabled = true;
            txtSubnAss.ReadOnly = false;
            txtRepAss.ReadOnly = false;
            txtPfAss.ReadOnly = false;
            txtDaAss.ReadOnly = false;
            txtPayAss.ReadOnly = false;
            ddlGo.Enabled = true;
            btndeleteCrAss.Enabled = true;
            ddlFm.Enabled = true;
            ddlFm.Enabled = true;
        }
        txtCnt.Enabled = true;
    }
    //private void fillschedule(int chID)
    //{
    //    pnlSch.Visible = true;
    //    DataSet ds1 = new DataSet();
    //    ArrayList arr1 = new ArrayList();
    //    arr1.Add(chID);
    //    ds1 = schDao.CheckScheduleExist(arr1);
    //    if (ds1.Tables[0].Rows.Count > 0)
    //    {
    //        gdvschedule.DataSource = ds1;
    //        gdvschedule.DataBind();
    //        for (int i = 0; i < gdvschedule.Rows.Count; i++)
    //        {
    //            GridViewRow grdVwRow = gdvschedule.Rows[i];
    //            DropDownList ddlgoass = (DropDownList)grdVwRow.FindControl("ddlGo");
    //            ddlgoass.SelectedValue = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
    //        }
    //        gdvschedule.FooterRow.Cells[1].Text = "Total";
    //        gdvschedule.FooterRow.Cells[3].Text = gblObj.FindGridTotal(gdvschedule, 3).ToString();
    //        gdvschedule.FooterRow.Cells[4].Text = gblObj.FindGridTotal(gdvschedule, 4).ToString();
    //        gdvschedule.FooterRow.Cells[5].Text = gblObj.FindGridTotal(gdvschedule, 5).ToString();
    //        gdvschedule.FooterRow.Cells[6].Text = gblObj.FindGridTotal(gdvschedule, 6).ToString();
    //        gdvschedule.FooterRow.Cells[7].Text = gblObj.FindGridTotal(gdvschedule, 7).ToString();
    //    }
    //}
    private void FillGridSched()
    {
        chal = new Chalan();
        schDao = new ScheduleDAO();

        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();

        chal.NumChalanId = Convert.ToInt64(Session["numChalanIdOnline"]);
        ar.Add(chal.NumChalanId);
        dsSched = schDao.CheckScheduleExist(ar);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdvAOApprovSched.DataSource = dsSched;
            gdvAOApprovSched.DataBind();

            for (int i = 0; i < dsSched.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvAOApprovSched.Rows[i];
                Label lblSlNoAss = (Label)gdv.FindControl("lblSlNo");
                lblSlNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

                FillGridCmb(gdv, "ddlGO");
                FillGridCmbM(gdv, "ddlFm", "ddlTm");

                TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
                txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[0].ToString();

                Label lblNameAss = (Label)gdv.FindControl("lblName");
                lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

                CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
                if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[9]) == 1)
                {
                    chkUnIdentAss.Checked = true;
                }
                else
                {
                    chkUnIdentAss.Checked = false;
                }
                TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
                txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();
                TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
                txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();
                TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
                txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[4].ToString();
                TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
                txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[5].ToString();
                TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
                txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
                Label lblTotalAss = (Label)gdv.FindControl("lblTotal");
                lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();



                //Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
                //lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

                Label lblSchedAss = (Label)gdv.FindControl("lblSched");
                lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[14].ToString();

                Label lblAccNoAss = (Label)gdv.FindControl("lblAccNo");
                lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

                Label lblNewAccAss = (Label)gdv.FindControl("lblNewAcc");
                lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

                Label lblNewTotAss = (Label)gdv.FindControl("lblNewTot");
                lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();

                //Label lblEditModeSAss = (Label)gdv.FindControl("lblEditModeS");
                //lblEditModeSAss.Text = "0";

                //Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
                //lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

                Label lblOTotAss = (Label)gdv.FindControl("lblOTot");
                lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblOAccAss = (Label)gdv.FindControl("lblOAcc");
                lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[12].ToString();

                //intMaxRecNo = Convert.ToInt16(lblRecNoAss.Text.ToString());

                DropDownList ddlGoAss = (DropDownList)gdv.FindControl("ddlGo");
                ddlGoAss.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

                DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");
                ddlFm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[17].ToString();

                DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
                ddlTm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[18].ToString();
            }
            txtCnt.Text = dsSched.Tables[0].Rows.Count.ToString();
            FillFooterTotals();
        }
        else
        {
            SetGridDefaultSched();
        }
    }
    private void FillFooterTotals()
    {
        gblObj = new clsGlobalMethods();

        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 4, "txtSubn", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 5, "txtRep", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 6, "txtPf", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 7, "txtDa", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 9, "txtPay", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 12, "lblTotal", 2);
    }
    //private void FillChalanLb()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add(Session["IntYearIdRemi"]);
    //    ar.Add(Session["IntMonthIdRemi"]);
    //    ar.Add(Session["IntTreIdRemi"]);
    //    DataSet ds2 = new DataSet();
    //    ds2 = chDao.ChalanRemittance(ar);
    //    if (ds2.Tables[0].Rows.Count > 0)
    //    {
    //        gdvchRem.DataSource = ds2;
    //        gdvchRem.DataBind();
    //        for (int i = 0; i < gdvchRem.Rows.Count; i++)
    //        {
    //            if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6].ToString()) > 0)
    //            {
    //                GridViewRow grdVwRow = gdvchRem.Rows[i];
    //                TextBox TxtChNo = (TextBox)grdVwRow.FindControl("txtChNo");
    //                LinkButton hlChAmount = (LinkButton)grdVwRow.FindControl("hlChAmount");
    //                CheckBox chkApp = (CheckBox)grdVwRow.FindControl("chkApp");
    //                DropDownList ddlReason = (DropDownList)grdVwRow.FindControl("ddlReason");
    //                if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6]) == 2)
    //                {
    //                    chkApp.Checked = true;
    //                    ddlReason.SelectedValue = ds2.Tables[0].Rows[i].ItemArray[7].ToString();
    //                }
    //                else
    //                {
    //                    chkApp.Checked = false;
    //                }
    //            }
    //        }
    //        gblObj.SetFooterTotals(gdvchRem, 3);
    //        fillgridCombo();
    //    }
    //    else
    //    {
    //        SetGridDefault();
    //    }
    //}
    private void FillGrid()
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        chaldao = new ChalanDAO();

        DataSet dsChal = new DataSet();
        ArrayList ar = new ArrayList();

        DataSet dsM = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        arrIn1.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn1);

        ar.Add(Convert.ToDouble(Session["numChalanIdOnline"]));
        dsChal = chaldao.ChalanRemittanceOnline(ar);
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsChal;
            gdvAOApprov.DataBind();

            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                //TextBox txtdateAss = (TextBox)gdv.FindControl("txtdate");
                //txtdateAss.Text = dsChal.Tables[0].Rows[i].ItemArray[12].ToString();

                //TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
                //txtAmtAss.Text = dsChal.Tables[0].Rows[i].ItemArray[4].ToString();

                Label lblChalIdAss = (Label)gdv.FindControl("lblChalId");
                lblChalIdAss.Text = dsChal.Tables[0].Rows[i].ItemArray[0].ToString();

                //Label lblMonthAss = (Label)gdv.FindControl("lblMonth");
                //lblMonthAss.Text = dsChal.Tables[0].Rows[i].ItemArray[11].ToString();

                Label lblYrAss = (Label)gdv.FindControl("lblYr");
                lblYrAss.Text = dsChal.Tables[0].Rows[i].ItemArray[9].ToString();
                Session["intYrId"] = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[9].ToString());

                Label lblMonthAss = (Label)gdv.FindControl("lblMonthId");
                lblMonthAss.Text = dsChal.Tables[0].Rows[i].ItemArray[10].ToString();
                intMth = Convert.ToInt16(lblMonthAss.Text);

                Label lblDayAss = (Label)gdv.FindControl("lblDay");
                lblDayAss.Text = dsChal.Tables[0].Rows[i].ItemArray[13].ToString();
                intDy = Convert.ToInt16(lblDayAss.Text);

                Label lblEditModeAss = (Label)gdv.FindControl("lblEditMode");
                lblEditModeAss.Text = "0";

                CheckBox chkAppAss = (CheckBox)gdv.FindControl("chkApp");
                DropDownList ddlReasonAss = (DropDownList)gdv.FindControl("ddlReason");
                gblObj.FillCombo(ddlReasonAss, dsM, 1);

                if (Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[6]) == 2)
                {
                    chkAppAss.Checked = true;
                    ddlReasonAss.SelectedValue = dsChal.Tables[0].Rows[i].ItemArray[7].ToString();
                    ddlReasonAss.Enabled = true;
                }
                else
                {
                    chkAppAss.Checked = false;
                    ddlReasonAss.Enabled = false;
                }

                lblType.Text = dsChal.Tables[0].Rows[i].ItemArray[14].ToString();
                Session["intSrc"] = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[8].ToString());
                if (Convert.ToInt16(Session["intSrc"]) == 4)
                {
                    lblType.Text = lblType.Text.ToString() + "  _  " + FindTEDet(Convert.ToInt64(Session["numChalanIdOnline"]), Convert.ToInt16(Session["intYrId"]));
                }
            }
            gblObj.SetFooterTotalsTempField(gdvAOApprov, 5, "txtAmt", 1);
            //gblObj.SetGridGrey(gdvAOApprov);
        }
        else
        {
            SetGridDefault();
        }
    }
    private string FindTEDet(Int64 numChalId, Int16 intYr)
    {
        chaldao = new ChalanDAO();
        string str = "";
        DataSet dsC = new DataSet();
        ArrayList arC = new ArrayList();
        arC.Add(numChalId);
        arC.Add(intYr);
        dsC = chaldao.FindChalanTEDet(arC);
        if (dsC.Tables[0].Rows.Count > 0)
        {
            str = dsC.Tables[0].Rows[0].ItemArray[0].ToString() + dsC.Tables[0].Rows[0].ItemArray[1].ToString();
        }

        return str;
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        //ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("chvTreasuryName");
        ar.Add("intChalanNo");

        ar.Add("ChalanDate");
        ar.Add("fltChalanAmt");
        ar.Add("flgUnposted");
        ar.Add("intUnPostedRsn");
        gblObj.SetGridDefault(gdvAOApprov, ar);
        gblObj.SetGridGrey(gdvAOApprov);
    }
    private void SetGridDefaultSched()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("ChalDet");

        ar.Add("fltChalanAmt");
        ar.Add("fltTotalSum");
        ar.Add("intChalanId");
        ar.Add("intDistID");

        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("fltSubnAmt");
        ar.Add("fltRePaymentAmt");
        ar.Add("fltArearPFAmt");
        ar.Add("fltArearDA");
        ar.Add("fltArearPay");
        ar.Add("TotRem");
        ar.Add("numScheduleID");
        ar.Add("numEmpId");
        ar.Add("intFm");
        ar.Add("intTm");
        gblObj.SetGridDefault(gdvAOApprovSched, ar);
    }
    private void SetGrids()
    {
        if (Convert.ToInt16(Session["flgApproval"]) == 2 || Convert.ToInt16(Session["flgApproval"]) == 0 || Convert.ToInt16(Session["flgApproval"]) == 10)
        {
            SetGridsEditable();
        }
        else
        {
            SetGridsNonEditable();
        }
    }
    private void SetGridsEditable()
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvAOApprov.Rows[i];
            TextBox txtdateAss = (TextBox)gdvrow.FindControl("txtdate");
            txtdateAss.ReadOnly = false;
            txtdateAss.Enabled = true;
            TextBox txtNoAss = (TextBox)gdvrow.FindControl("txtNo");
            txtNoAss.ReadOnly = false;
            txtNoAss.Enabled = true;
            //TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            //txtAmtAss.ReadOnly = false;
            //txtAmtAss.Enabled = true;
        }

        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvAOApprovSched.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdvrowS.FindControl("txtAccNo");
            txtAccNoAss.ReadOnly = false;
            txtAccNoAss.Enabled = true;

            TextBox txtSubnAss = (TextBox)gdvrowS.FindControl("txtSubn");
            txtSubnAss.ReadOnly = false;
            txtSubnAss.Enabled = true;

            TextBox txtRepAss = (TextBox)gdvrowS.FindControl("txtRep");
            txtRepAss.ReadOnly = false;
            txtRepAss.Enabled = true;

            TextBox txtPfAss = (TextBox)gdvrowS.FindControl("txtPf");
            txtPfAss.ReadOnly = false;
            txtPfAss.Enabled = true;

            TextBox txtDaAss = (TextBox)gdvrowS.FindControl("txtDa");
            txtDaAss.ReadOnly = false;
            txtDaAss.Enabled = true;

            TextBox txtPayAss = (TextBox)gdvrowS.FindControl("txtPay");
            txtPayAss.ReadOnly = false;
            txtPayAss.Enabled = true;

            CheckBox chkUnIdentAss = (CheckBox)gdvrowS.FindControl("chkUnIdent");
            chkUnIdentAss.Enabled = true;

            DropDownList ddlGo = (DropDownList)gdvrowS.FindControl("ddlGo");
            ddlGo.Enabled = true;

            ImageButton btndeleteCrAss = (ImageButton)gdvrowS.FindControl("btndeleteCr");
            btndeleteCrAss.Enabled = true;


            DropDownList ddlFm = (DropDownList)gdvrowS.FindControl("ddlFm");
            ddlFm.Enabled = true;
            DropDownList ddlTm = (DropDownList)gdvrowS.FindControl("ddlTm");
            ddlTm.Enabled = true;


        }
        txtCnt.Enabled = true;
    }
    private void SetGridsNonEditable()
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvAOApprov.Rows[i];
            TextBox txtdateAss = (TextBox)gdvrow.FindControl("txtdate");
            txtdateAss.ReadOnly = true;
            txtdateAss.Enabled = false;

            TextBox txtNoAss = (TextBox)gdvrow.FindControl("txtNo");
            txtNoAss.ReadOnly = true;
            txtNoAss.Enabled = false;

            TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
            txtAmtAss.ReadOnly = true;
            txtAmtAss.Enabled = false;
        }

        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvAOApprovSched.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdvrowS.FindControl("txtAccNo");
            txtAccNoAss.ReadOnly = true;
            txtAccNoAss.Enabled = false;

            TextBox txtSubnAss = (TextBox)gdvrowS.FindControl("txtSubn");
            txtSubnAss.ReadOnly = true;
            txtSubnAss.Enabled = false;

            TextBox txtRepAss = (TextBox)gdvrowS.FindControl("txtRep");
            txtRepAss.ReadOnly = true;
            txtRepAss.Enabled = false;

            TextBox txtPfAss = (TextBox)gdvrowS.FindControl("txtPf");
            txtPfAss.ReadOnly = true;
            txtPfAss.Enabled = false;

            TextBox txtDaAss = (TextBox)gdvrowS.FindControl("txtDa");
            txtDaAss.ReadOnly = true;
            txtDaAss.Enabled = false;

            TextBox txtPayAss = (TextBox)gdvrowS.FindControl("txtPay");
            txtPayAss.ReadOnly = true;
            txtPayAss.Enabled = false;

            CheckBox chkUnIdentAss = (CheckBox)gdvrowS.FindControl("chkUnIdent");
            chkUnIdentAss.Enabled = false;

            DropDownList ddlGo = (DropDownList)gdvrowS.FindControl("ddlGo");
            ddlGo.Enabled = false;

            ImageButton btndeleteCrAss = (ImageButton)gdvrowS.FindControl("btndeleteCr");
            btndeleteCrAss.Enabled = false;

            DropDownList ddlFm = (DropDownList)gdvrowS.FindControl("ddlFm");
            ddlFm.Enabled = false;
            DropDownList ddlTm = (DropDownList)gdvrowS.FindControl("ddlTm");
            ddlTm.Enabled = false;
        }
        txtCnt.Enabled = false;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        intCnt = intCnt + 1;
        Session["intCCYearId"] = gendao.GetCCYearId();
        //if (intCnt == 1)
        //{
            UpdateChalan();
            SaveSchedule();
        //}
        gblObj.MsgBoxOk("Saved Successfully  !", this);
        FillGrid();
        FillGridSched();
    }
    private void UpdateChalan()
    {
        gblObj = new clsGlobalMethods();
        chaldao = new ChalanDAO();
        chal = new Chalan();
        gendao = new GeneralDAO();
        Session["intCCYearId"] = gendao.GetCCYearId();
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gvrow = gdvAOApprov.Rows[i];
            TextBox txtNoAss = (TextBox)gvrow.FindControl("txtNo");
            TextBox txtdateAss = (TextBox)gvrow.FindControl("txtdate");
            TextBox txtAmtAss = (TextBox)gvrow.FindControl("txtAmt");
            Label lblEditMode = (Label)gvrow.FindControl("lblEditMode");
            Label lblYrAss = (Label)gvrow.FindControl("lblYr");
            if (ValidateFields(i) == true)
            {
                chal.NumChalanId = Convert.ToInt64(Session["numChalanIdOnline"]);//ChalanID;

                chal.DtChalanDate = txtdateAss.Text.ToString();
                chal.FltChalanAmt = Convert.ToDecimal(txtAmtAss.Text);
                chaldao.UpdateChalanAmt(chal);
            }
            else
            {
                gblObj.MsgBoxOk("Enter all details", this);
                break;
            }
            //int a = Convert.ToInt16(Session["IntYearIdRemi"]);
            //if (Convert.ToInt16(Session["IntYearIdRemi"]) == 0)
            //{
                Session["IntEntryYear"] = Convert.ToInt16(lblYrAss.Text);
            //}
        }
    }
    //private void SaveCorrectionEntryChal(float chalId, int intEditMode, int yr, int mth, int inyDy)
    //{

    //    gendao = new GeneralDAO();
    //    gblObj = new clsGlobalMethods();
    //    chaldao = new ChalanDAO();
    //    CorrectionEntry corr = new CorrectionEntry();
    //    CorrectionEntryDao corrDao = new CorrectionEntryDao();

    //    int cntEmp = 0;
    //    ArrayList ar = new ArrayList();
    //    DataSet dsChal = new DataSet();
    //    ar.Add(chalId);
    //    dsChal = chaldao.FindCntEmpInChalanCurr(ar);
    //    cntEmp = dsChal.Tables[0].Rows.Count;
    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    for (int i = 0; i <= cntEmp - 1; i++)
    //    {
    //        int accNo = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[0]);
    //        double amt = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, dblCalcAmt);
    //        ///// Save to CorrEntry/////////
    //        corr.IntAccNo = accNo;
    //        corr.IntYearID = yr;
    //        corr.IntMonthID = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[3]);
    //        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //        corr.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);
    //        if (intEditMode == 1)
    //        {
    //            corr.FltAmountAfter = Math.Round(corr.FltAmountBefore + dblCalcAmt);
    //            corr.FltCalcAmount = dblAmtAdjusted;
    //        }
    //        else
    //        {
    //            corr.FltAmountAfter = Math.Round(corr.FltAmountBefore - dblCalcAmt);
    //            corr.FltCalcAmount = -dblAmtAdjusted;
    //        }
    //        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //        corr.IntChalanId = chalId;
    //        corr.IntSchedId = Convert.ToInt64(dsChal.Tables[0].Rows[i].ItemArray[2]);
    //        corr.FlgType = 1;           //Remittance
    //        corr.FltRoundingAmt = 0;
    //        corr.IntCorrectionType = 1; //Edit Chal Date
    //        //corr.StrFrmChalDt = System.DBNull.Value.ToString();
    //        //corr.StrToChalDt = System.DBNull.Value.ToString();
    //        if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //        {
    //            corr.IntChalanType = 1;
    //        }
    //        else
    //        {
    //            corr.IntChalanType = 2;
    //        }
    //        corrDao.CreateCorrEntry(corr);
    //        ///// Save to CorrEntry/////////
    //    }
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}

    //private void UpdateChalan()
    //{
    //    gblObj = new clsGlobalMethods();
    //    chaldao = new ChalanDAO();
    //    chal = new Chalan();

    //    for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
    //    {
    //        GridViewRow gvrow = gdvAOApprov.Rows[i];
    //        TextBox txtNoAss = (TextBox)gvrow.FindControl("txtNo");
    //        TextBox txtdateAss = (TextBox)gvrow.FindControl("txtdate");
    //        TextBox txtAmtAss = (TextBox)gvrow.FindControl("txtAmt");
    //        if (ValidateFields(i) == true)
    //        {
    //            chal.NumChalanId = Convert.ToInt64(Session["numChalanIdOnline"]);//ChalanID;
    //            chal.DtChalanDate = txtdateAss.Text.ToString();
    //            chal.FltChalanAmt = Convert.ToDecimal(txtAmtAss.Text);
    //            chaldao.UpdateChalanAmt(chal);
    //        }
    //        else
    //        {
    //            gblObj.MsgBoxOk("Enter all details", this);
    //            break;
    //        }
    //    }
    //}
    private Boolean ValidateFields(int i)
    {
        bool Valid;
        Valid = true;
        GridViewRow gvrow = gdvAOApprov.Rows[i];

        TextBox txtNoAss = (TextBox)gvrow.FindControl("txtNo");
        TextBox txtdateAss = (TextBox)gvrow.FindControl("txtdate");
        TextBox txtAmtAss = (TextBox)gvrow.FindControl("txtAmt");
        if (txtNoAss.Text.ToString() != "" && txtNoAss.Text.ToString() != "0" && txtdateAss.Text.ToString() != "" && txtdateAss.Text.ToString() != "0" && txtAmtAss.Text.ToString() != "" && txtAmtAss.Text.ToString() != "0")
        {
            Valid = true;
        }
        else
        {
            Valid = false;
        }
        return Valid;
    }
    private int FindSlNo(double accno)
    {
        schDao = new ScheduleDAO();

        int slno = 1;
        DataSet dsSched = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["numChalanIdOnline"]));
        arr.Add(accno);
        dsSched = schDao.FindSlnofrmScheduleTR104(arr);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            slno = Convert.ToInt16(dsSched.Tables[0].Rows[0].ItemArray[0]);
        }
        return slno;
    }
    public bool ValidateFieldsSch(int i)
    {
        bool Valid;
        Valid = true;
        GridViewRow gvrow = gdvAOApprovSched.Rows[i];
        Label lblTotalAss = (Label)gvrow.FindControl("lblTotal");
        Label lblNewAccAss = (Label)gvrow.FindControl("lblNewAcc");
        if (lblNewAccAss.Text.ToString() != "" && lblNewAccAss.Text.ToString() != "0" && lblTotalAss.Text.ToString() != "" && lblTotalAss.Text.ToString() != "0")
        {
            Valid = true;
        }
        else
        {
            Valid = false;
        }
        return Valid;
    }
    private double FindSchedId()
    {
        double dblId = 0;
        schDao = new ScheduleDAO();
        DataSet ds = new DataSet();
        ds = schDao.GetMaxScheduleId();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dblId = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        return dblId;
    }
    private void SaveSchedule()
    {
        gblObj = new clsGlobalMethods();
        sch = new Schedule();
        schDao = new ScheduleDAO();
        gendao = new GeneralDAO();
        Session["intCCYearId"] = gendao.GetCCYearId();

        ////////////////////////cHALAN yEAR///////////////
        //GridViewRow gvr = gdvAOApprov.Rows[0];
        //Label lblYr = (Label)gvr.FindControl("lblYr");
        //int yr = Convert.ToInt16(lblYr.Text);
        ////////////////////////cHALAN yEAR///////////////


        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gvrow = gdvAOApprovSched.Rows[i];

            TextBox txtSubnAss = (TextBox)gvrow.FindControl("txtSubn");
            TextBox txtRepAss = (TextBox)gvrow.FindControl("txtRep");
            TextBox txtPfAss = (TextBox)gvrow.FindControl("txtPf");
            TextBox txtDaAss = (TextBox)gvrow.FindControl("txtDa");
            TextBox txtPayAss = (TextBox)gvrow.FindControl("txtPay");
            Label lblTotalAss = (Label)gvrow.FindControl("lblTotal");
            //Label lblSchedMainAss = (Label)gvrow.FindControl("lblSchedMain");
            Label lblSchedAss = (Label)gvrow.FindControl("lblSched");
            //TextBox txtAccNoAss = (TextBox)gvrow.FindControl("txtAccNo");
            //Label lblNameAss = (Label)gvrow.FindControl("lblName");
            Label lblNewAccAss = (Label)gvrow.FindControl("lblNewAcc");
            CheckBox chkUnIdentAss = (CheckBox)gvrow.FindControl("chkUnIdent");
            DropDownList ddlGoAss = (DropDownList)gvrow.FindControl("ddlGo");
            DropDownList ddlFm = (DropDownList)gvrow.FindControl("ddlFm");
            DropDownList ddlTm = (DropDownList)gvrow.FindControl("ddlTm");
            //Label lblSlNoAss = (Label)gvrow.FindControl("lblSlNo");
            //Label lblTotalAssNew = (Label)gvrow.FindControl("lblNewTot");
            Label lblEditModeSAss = (Label)gvrow.FindControl("lblEditModeS");
            //Label lblOAcc = (Label)gvrow.FindControl("lblOAcc");
            //Label lblOTot = (Label)gvrow.FindControl("lblOTot");

            if (ValidateFieldsSch(i) == true)
            {
                if (Convert.ToInt16(lblEditModeSAss.Text) >= 1)
                {
                    sch.NumChalanID = Convert.ToInt64(Session["numChalanIdOnline"]);
                    sch.NumEmpID = Convert.ToDouble(lblNewAccAss.Text);
                    sch.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
                    sch.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
                    sch.FltArearPay = Convert.ToDouble(txtPayAss.Text);
                    sch.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
                    sch.FltArearDA = Convert.ToDouble(txtDaAss.Text);
                    sch.FltTotal = Convert.ToDouble(lblTotalAss.Text);
                    if (ddlGoAss.SelectedValue == "")
                    {
                        sch.IntGOId = 0;
                    }
                    else
                    {
                        sch.IntGOId = Convert.ToInt16(ddlGoAss.SelectedValue);
                    }
                    if (ddlFm.SelectedValue == "")
                    {
                        sch.IntFm = 0;
                    }
                    else
                    {
                        sch.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
                    }
                    if (ddlTm.SelectedValue == "")
                    {
                        sch.IntTm = 0;
                    }
                    else
                    {
                        sch.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
                    }
                    sch.IntNoOfInst = 0;
                    sch.FlgUnPosted = 0;
                    sch.IntUnPostedRsn = 0;
                    sch.IntModeChange = 2;
                    sch.ChvRem = "";
                    sch.IntSlNo = Convert.ToInt16(i + 1);
                    if (lblSchedAss.Text == "")
                    {
                        sch.NumScheduleID = 0;
                    }
                    else
                    {
                        sch.NumScheduleID = Convert.ToInt64(lblSchedAss.Text);
                    }
                    if (chkUnIdentAss.Checked == true)
                    {
                        sch.FlgUnIdentifiedEmp = 1;
                    }
                    else
                    {
                        sch.FlgUnIdentifiedEmp = 0;
                    }
                    schDao.SaveSchedule(sch);
                    int a = Convert.ToInt16(Session["IntYearIdRemi"]);
                    int c = Convert.ToInt16(Session["IntEntryYear"]);
                    int b = Convert.ToInt16(Session["intCCYearId"]);
                    //if (Convert.ToInt16(Session["IntYearIdRemi"]) <= Convert.ToInt16(Session["intCCYearId"]))
                    if (Convert.ToInt16(Session["IntEntryYear"]) <= Convert.ToInt16(Session["intCCYearId"]))
                    {
                        saveCorrectionEntry(i, Convert.ToInt64(lblSchedAss.Text), 0);
                    }
                }
            }
        }
    }
 
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvAOApprov.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            DropDownList ddlReasonAss = (DropDownList)gvRw.FindControl("ddlReason");
            if (chkAppAss.Checked == true)
            {
                ddlReasonAss.Enabled = true;
            }
            else
            {
                ddlReasonAss.Enabled = false;
            }
        }
    }
    //protected void Allchk_CheckedChanged(object sender, EventArgs e)
    //{

    //}

    //private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    //{
    //    int cntEmp = 0;
    //    ArrayList ar = new ArrayList();
    //    DataSet dsChal = new DataSet();
    //    ar.Add(chalId);
    //    dsChal = chalPDao.FindCntEmpInChalan(ar);
    //    cntEmp = dsChal.Tables[0].Rows.Count;
    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    for (int i = 0; i <= cntEmp - 1; i++)
    //    {
    //        int accNo = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[0]);
    //        double amt = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //        double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, dblCalcAmt);
    //        ///// Save to CorrEntry/////////
    //        corr.IntAccNo = accNo;
    //        corr.IntYearID = yr;
    //        corr.IntMonthID = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[3]);
    //        corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //        corr.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
    //        //corr.FltAmountAfter = Math.Round(dblAmtAdjusted);
    //        if (intEditMode == 1)
    //        {
    //            corr.FltAmountAfter = Math.Round(corr.FltAmountBefore + dblCalcAmt);
    //            corr.FltCalcAmount = dblAmtAdjusted;
    //        }
    //        else
    //        {
    //            corr.FltAmountAfter = Math.Round(corr.FltAmountBefore - dblCalcAmt);
    //            corr.FltCalcAmount = -dblAmtAdjusted;
    //        }
    //        corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //        corr.IntChalanId = chalId;
    //        corr.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
    //        corr.FlgType = 1;           //Remittance
    //        corr.FltRoundingAmt = 0;
    //        corr.IntCorrectionType = 1; //Edit Chal Date
    //        //corr.StrFrmChalDt = System.DBNull.Value.ToString();
    //        //corr.StrToChalDt = System.DBNull.Value.ToString();
    //        corr.IntChalanType = 1;

    //        corrDao.CreateCorrEntry(corr);
    //        ///// Save to CorrEntry/////////
    //    }

    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBf, double fltAmtAfr, int ChngType)
    //{
    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //    //double dblCalcAmt = amt;
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = intAccNo;
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    //if (ChngType == 1)
    //    //{
    //    //    corr.FltAmountBefore = 0;
    //    //}
    //    //else
    //    //{
    //    corr.FltAmountBefore = fltAmtBfr;
    //    //}
    //    corr.FltAmountAfter = fltAmtAfr;
    //    corr.FltCalcAmount = dblAmtAdjusted;
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = chalId;
    //    corr.IntSchedId = intSchedId;
    //    corr.FlgType = 1;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    corr.IntChalanType = 1;
    //    corrDao.CreateCorrEntry(corr);
    //    ///// Save to CorrEntry/////////
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvAOApprovSched.Rows[intCurRw];
        Label lblAccNoAss = (Label)gdr.FindControl("lblAccNo");
        TextBox txtAccNoAss = (TextBox)gdr.FindControl("txtAccNo");
        Label lblNameAss = (Label)gdr.FindControl("lblName");
        Label lblNewAccAss = (Label)gdr.FindControl("lblNewAcc");
        Label lblEditModeSAss = (Label)gdr.FindControl("lblEditModeS");

        if (gblObj.CheckNumericOnly(txtAccNoAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtAccNoAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                lblNameAss.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblNewAccAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtAccNoAss.Text = "";
                lblNameAss.Text = "";
                gblObj.MsgBoxOk("Doesn't exist!", this);
            }
            if (Convert.ToInt32(lblAccNoAss.Text) != Convert.ToInt32(lblNewAccAss.Text))
            {
                lblEditModeSAss.Text = "1";
            }
            else
            {
                lblEditModeSAss.Text = "0";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter Numeric Value", this);
            txtAccNoAss.Text = "";
            lblNameAss.Text = "";
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        //gblObj = new clsGlobalMethods();

        //intCurRwChal = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //ArrayList ar = new ArrayList();
        //GridViewRow gvr = gdvAOApprov.Rows[intCurRwChal];
        //Label lblYrAss = (Label)gvr.FindControl("lblYr");
        //Label lblMonthAss = (Label)gvr.FindControl("lblMonthId");
        //Label lblDayAss = (Label)gvr.FindControl("lblDay");
        //Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");

        //TextBox txtdateAss = (TextBox)gvr.FindControl("txtdate");
        //if (gblObj.isValidDate(txtdateAss, this) == true)
        //{
        //    if (gblObj.CheckChalanDate(txtdateAss, Convert.ToInt16(lblYrAss.Text.ToString()), Convert.ToInt16(lblMonthAss.Text.ToString())) == false)
        //    {
        //        gblObj.MsgBoxOk("Invalid date", this);
        //        txtdateAss.Text = "";
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Invalid date", this);
        //    txtdateAss.Text = "";
        //}

        gblObj = new clsGlobalMethods();

        intCurRwChal = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        ArrayList ar = new ArrayList();
        GridViewRow gvr = gdvAOApprov.Rows[intCurRwChal];
        Label lblYrAss = (Label)gvr.FindControl("lblYr");
        Label lblMonthAss = (Label)gvr.FindControl("lblMonthId");
        Label lblDayAss = (Label)gvr.FindControl("lblDay");
        Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");

        TextBox txtdateAss = (TextBox)gvr.FindControl("txtdate");
        DateTime dtm = new DateTime();
        if (gblObj.isValidDate(txtdateAss, this) == true)
        {
            if (gblObj.CheckChalanDate(txtdateAss, Convert.ToInt16(lblYrAss.Text.ToString()), Convert.ToInt16(lblMonthAss.Text.ToString())) == false)
            {
                gblObj.MsgBoxOk("Invalid date", this);
                txtdateAss.Text = "";
            }
            else
            {
                dtm = Convert.ToDateTime(txtdateAss.Text);
                int monthId = dtm.Month;
                if (dtm.Day <= 4 && Convert.ToInt16(lblDayAss.Text) > 4)
                {
                    lblEditModeAss.Text = "1";
                }
                else if (dtm.Day > 4 && Convert.ToInt16(lblDayAss.Text) <= 4)
                {
                    lblEditModeAss.Text = "2";
                }
                else
                {
                    lblEditModeAss.Text = "0";
                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid date", this);
            txtdateAss.Text = "";
        }

    }
    protected void txtSubn_TextChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvAOApprovSched);
        FillFooterTotals();
    }
    protected void txtRep_TextChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvAOApprovSched);
        FillFooterTotals();
    }
    protected void txtPf_TextChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvAOApprovSched);
        FillFooterTotals();
    }
    protected void txtDa_TextChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvAOApprovSched);
        FillFooterTotals();
    }
    protected void txtPay_TextChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        CalcNewTotal(intCurRwSched, gdvAOApprovSched);
        FillFooterTotals();
    }
    private void CalcNewTotal(int intCurRwSched, GridView gdv)
    {
        GridViewRow gvr = gdv.Rows[intCurRwSched];
        TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
        TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
        TextBox txtPfAss = (TextBox)gvr.FindControl("txtPf");
        TextBox txtDaAss = (TextBox)gvr.FindControl("txtDa");
        TextBox txtPayAss = (TextBox)gvr.FindControl("txtPay");

        Label lblTotAss = (Label)gvr.FindControl("lblTotal");
        Label lblNewTotAss = (Label)gvr.FindControl("lblNewTot");
        lblNewTotAss.Text = Convert.ToString(Convert.ToDouble(txtSubnAss.Text) + Convert.ToDouble(txtRepAss.Text) + Convert.ToDouble(txtPfAss.Text) + Convert.ToDouble(txtDaAss.Text) + Convert.ToDouble(txtPayAss.Text));

        Label lblEditModeSAss = (Label)gvr.FindControl("lblEditModeS");
        if (Convert.ToDouble(lblTotAss.Text) != Convert.ToDouble(lblNewTotAss.Text))
        {
            lblEditModeSAss.Text = "1";
        }
        else
        {
            lblEditModeSAss.Text = "0";
        }
        if (txtSubnAss.Text == "")
        {
            txtSubnAss.Text = 0.ToString();
        }
        if (txtRepAss.Text == "")
        {
            txtRepAss.Text = 0.ToString();
        }
        if (txtPfAss.Text == "")
        {
            txtPfAss.Text = 0.ToString();
        }
        if (txtDaAss.Text == "")
        {
            txtDaAss.Text = 0.ToString();
        }
        if (txtPayAss.Text == "")
        {
            txtPayAss.Text = 0.ToString();
        }
        lblTotAss.Text = Convert.ToString(Convert.ToDouble(txtSubnAss.Text) + Convert.ToDouble(txtRepAss.Text) + Convert.ToDouble(txtPfAss.Text) + Convert.ToDouble(txtDaAss.Text) + Convert.ToDouble(txtPayAss.Text));
        lblNewTotAss.Text = Convert.ToString(Convert.ToDouble(txtSubnAss.Text) + Convert.ToDouble(txtRepAss.Text) + Convert.ToDouble(txtPfAss.Text) + Convert.ToDouble(txtDaAss.Text) + Convert.ToDouble(txtPayAss.Text));

    }


    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["flgPageBack"]) == 1)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
    //    {
    //        Session["Sessionclear"] = 1;
    //        btnBack.PostBackUrl = "~/Contents/Remittance.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/AnnStatement.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/RemittanceCurr.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 5)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/TransferEntryCurr.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 7)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/Daer1.aspx";
    //    }
    //}
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gdvAOApprovSched);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gdvAOApprovSched);
            DataSet ds = new DataSet();
            gdvAOApprovSched.DataSource = dtgdRow;
            gdvAOApprovSched.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvAOApprovSched, ds);
        }
    }
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        // myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new Label());
        myControls.Add(new CheckBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new Label());
        myControls.Add(new Label());
        myControls.Add(new Label());

        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("txtAccNo");
        arrControlid.Add("lblName");
        arrControlid.Add("chkUnIdent");
        arrControlid.Add("txtSubn");
        arrControlid.Add("txtRep");
        arrControlid.Add("txtPf");
        arrControlid.Add("txtDa");
        arrControlid.Add("txtPay");
        arrControlid.Add("lblTotal");
        arrControlid.Add("lblSched");
        arrControlid.Add("lblNewAcc");

        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
        // arrControlid.Add("SlNo");
        arrControlid.Add("chvPF_No");
        arrControlid.Add("chvName");
        arrControlid.Add("UnPosted");
        arrControlid.Add("fltSubnAmt");
        arrControlid.Add("fltRePaymentAmt");
        arrControlid.Add("fltArearPFAmt");
        arrControlid.Add("fltArearDA");
        arrControlid.Add("fltArearPay");
        arrControlid.Add("TotRem");
        arrControlid.Add("numScheduleID");
        arrControlid.Add("numEmpId");

        return arrControlid;
    }

    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/AGStatementsPDE.aspx";
    //}
    protected void gdFloorAreaDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvCM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    private string FindChalDt()
    {
        GridViewRow gvr = gdvAOApprov.Rows[0];
        TextBox txtdate = (TextBox)gvr.FindControl("txtdate");
        Label lblChalId = (Label)gvr.FindControl("lblChalId");
        string strDt = txtdate.Text.ToString();
        Session["numChalId"] = Convert.ToDouble(lblChalId.Text);
        return strDt;
    }
    protected void btnDeleteCr_Click(object sender, ImageClickEventArgs i)
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        schDao = new ScheduleDAO();

        //// Find Chalan year //////
        GridViewRow gvr = gdvAOApprov.Rows[0];
        Label lblYr = (Label)gvr.FindControl("lblYr");
        int yr = Convert.ToInt16(lblYr.Text);
        //// Find Chalan year //////
        Session["intCCYearId"] = gendao.GetCCYearId();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblSchedAss = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblSched");
        Label lblOAcc = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblOAcc");
        Label lblTotal = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblTotal");

        if (lblSchedAss.Text != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt64(lblSchedAss.Text));
            string strDt = FindChalDt();
            if (yr <= Convert.ToInt16(Session["intCCYearId"]))
            {
                saveCorrectionEntry(rowIndex, Convert.ToInt64(lblSchedAss.Text), 1);
            }
            schDao.UpdScheduleTR104Mode(arrin);
            deleteUnsavedScheduleTR104();
        }
        FillGridSched();
        gblObj.MsgBoxOk("Row Deleted   !", this);

    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 5;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 4;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 2;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 3;
            }
        }
    }
    private void saveCorrectionEntry(int rw, float schedId, int intDel)
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        genDAO = new KPEPFGeneralDAO();
        ArrayList ardt = new ArrayList();
        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        string chaldt = FindChalDt();
        //yr = Convert.ToInt16(Session["IntYearIdRemi"]);
        ardt.Add(chaldt);
        yr = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
        mth = Convert.ToDateTime(chaldt).Month;
        intDy = Convert.ToDateTime(chaldt).Day;

        GridViewRow gvrow = gdvAOApprovSched.Rows[rw];
        Label lblOTot = (Label)gvrow.FindControl("lblOTot");
        Label lblNewTot = (Label)gvrow.FindControl("lblNewTot");
        Label lblOAcc = (Label)gvrow.FindControl("lblOAcc");
        Label lblNewAcc = (Label)gvrow.FindControl("lblNewAcc");
        Label lblSched = (Label)gvrow.FindControl("lblSched");

        amtO = Convert.ToDouble(lblOTot.Text);
        amtN = Convert.ToDouble(lblNewTot.Text);
        accO = Convert.ToInt32(lblOAcc.Text);
        accN = Convert.ToInt32(lblNewAcc.Text);

        findCorrType(amtO, amtN, accO, accN, intDel);
        //findCorrAmt(amtO, amtN);
        if (corrType == 2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    corr.IntAccNo = Convert.ToInt32(lblOAcc.Text);
                    amtCalc = -amtN;
                    corr.FltAmountBefore = amtO;
                    corr.FltAmountAfter = 0;
                }
                else
                {
                    corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
                    amtCalc = amtN;
                    corr.FltAmountBefore = 0;
                    corr.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                corr.IntYearID = yr;
                corr.IntMonthID = mth;
                corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                corr.FltCalcAmount = dblAmtAdjusted;
                corr.FlgCorrected = 1;      //Just added not incorporated in CCard
                corr.IntChalanId = Convert.ToInt64(Session["numChalanIdOnline"]);
                corr.IntSchedId = schedId;
                corr.FlgType = 1;           //Remittance
                corr.FltRoundingAmt = 0;
                corr.IntCorrectionType = corrType;
                if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)
                {
                    corr.IntChalanType = 4;
                }
                else
                {
                    corr.IntChalanType = 2;
                }
                corr.IntTblTp = 2;
                corrDao.CreateCorrEntryCalcTblTp(corr);
            }
        }
        else
        {
            if (corrType == 4)
            {
                amtCalc = amtN;
                corr.FltAmountBefore = 0;
                corr.FltAmountAfter = amtN;
            }
            else if (corrType == 5)
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
            corr.IntAccNo = Convert.ToInt32(lblNewAcc.Text);
            corr.IntYearID = yr;
            corr.IntMonthID = mth;
            corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            corr.FltCalcAmount = dblAmtAdjusted;
            corr.FlgCorrected = 1;      //Just added not incorporated in CCard
            corr.IntChalanId = Convert.ToInt64(Session["numChalanIdOnline"]);
            corr.IntSchedId = schedId;
            corr.FlgType = 1;           //Remittance
            corr.FltRoundingAmt = 0;
            corr.IntCorrectionType = corrType;
            //int d = Convert.ToInt16(Session["flgPageBack"]);
            if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)
            {
                corr.IntChalanType = 4;
            }
            else
            {
                corr.IntChalanType = 2;
            }
            corr.IntTblTp = 2;
            corrDao.CreateCorrEntryCalcTblTp(corr);
        }
    }
    //private void SaveCorrectionEntry(int intAccNo, Int64 chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBf, double fltAmtAfr, int ChngType)
    //{
    //    GeneralDAO gendao = new GeneralDAO();
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    CorrectionEntry corr = new CorrectionEntry();
    //    CorrectionEntryDao corrDao = new CorrectionEntryDao();

    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //    //double dblCalcAmt = amt;
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = intAccNo;
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    corr.FltAmountBefore = fltAmtBf;
    //    corr.FltAmountAfter = fltAmtAfr;
    //    if (ChngType == 1)
    //    {
    //        corr.FltCalcAmount = dblAmtAdjusted;
    //    }
    //    else
    //    {
    //        corr.FltCalcAmount = -dblAmtAdjusted;
    //    }
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = chalId;
    //    corr.IntSchedId = intSchedId;
    //    corr.FlgType = 1;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //    {
    //        corr.IntChalanType = 1;
    //    }
    //    else
    //    {
    //        corr.IntChalanType = 2;
    //    }
    //    DataSet ds = new DataSet();
    //    ds = corrDao.CreateCorrEntry(corr);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        Session["intCorrectionId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
    //    }

    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 2)
    //    {
    //        ArrayList arrupd = new ArrayList();

    //        arrupd.Add(Convert.ToInt32(Session["intCorrectionId"]));
    //        arrupd.Add(2);
    //        corrDao.UpdCorrectionEntryTableType(arrupd);
    //    }
    //    ///// Save to CorrEntry/////////
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}
    //private void SaveCorrectionEntry(int intAccNo, Int64 chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBf, double fltAmtAfr, int ChngType)
    //{
    //    GeneralDAO gendao = new GeneralDAO();
    //    clsGlobalMethods gblObj = new clsGlobalMethods();
    //    CorrectionEntry corr = new CorrectionEntry();
    //    CorrectionEntryDao corrDao = new CorrectionEntryDao();

    //    Session["intCCYearId"] = gendao.GetCCYearId();
    //    //double dblCalcAmt = gblObj.CalculateAmtToCalc(yr, amt);
    //    //double dblCalcAmt = amt;
    //    double dblAmtAdjusted = gblObj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
    //    ///// Save to CorrEntry/////////
    //    corr.IntAccNo = intAccNo;
    //    corr.IntYearID = yr;
    //    corr.IntMonthID = mth;
    //    corr.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
    //    corr.FltAmountBefore = fltAmtBf;
    //    corr.FltAmountAfter = fltAmtAfr;
    //    if (ChngType == 1)
    //    {
    //        corr.FltCalcAmount = dblAmtAdjusted;
    //    }
    //    else
    //    {
    //        corr.FltCalcAmount = -dblAmtAdjusted;
    //    }
    //    corr.FlgCorrected = 1;      //Just added not incorporated in CCard
    //    corr.IntChalanId = chalId;
    //    corr.IntSchedId = intSchedId;
    //    corr.FlgType = 1;           //Remittance
    //    corr.FltRoundingAmt = 0;
    //    corr.IntCorrectionType = intCorrTp; //Edit Chal Date
    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //    {
    //        corr.IntChalanType = 1;
    //    }
    //    else
    //    {
    //        corr.IntChalanType = 2;
    //    }
    //    corrDao.CreateCorrEntry(corr);
    //    ///// Save to CorrEntry/////////
    //    //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    //}

    private void deleteUnsavedScheduleTR104()
    {
        gblObj = new clsGlobalMethods();

        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblObj.deleteRows(myControls, arrControlid, arrDT, gdvAOApprovSched);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvAOApprovSched.DataSource = dtgdRow;
            gdvAOApprovSched.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvAOApprovSched, ds);
        }
        else
        {
            FillGridSched();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {

        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    CheckBox chkUnIdentAss = (CheckBox)gdRow.FindControl("chkUnIdent");
                    if ((ds.Tables[0].Rows[gdRow.RowIndex][2].ToString()) != "")
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][2]) == true)
                        {
                            chkUnIdentAss.Checked = true;
                        }
                        else
                        {
                            chkUnIdentAss.Checked = false;
                        }
                    }


                }
            }
        }
    }
    //protected void btnchln_Click(object sender, ImageClickEventArgs e)
    //{

    //    List<Control> myControls = createchalancontrol();
    //    ArrayList arrControlid = createchalancontrolId();
    //    ArrayList arrDT = getchalancontrol();
    //    bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gdvAOApprov);
    //    if (chkLastRow)
    //    {
    //        DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gdvAOApprov);
    //        DataSet ds = new DataSet();
    //        gdvAOApprov.DataSource = dtgdRow;
    //        gdvAOApprov.DataBind();
    //        ds.Tables.Add(dtgdRow);
    //        fillDropDownchalan(gdvAOApprov, ds);
    //    }
    //}
    //private List<Control> createchalancontrol()
    //{
    //    List<Control> myControls = new List<Control>();
    //    // myControls.Add(new DropDownList());
    //    myControls.Add(new BoundField() );
    //    myControls.Add(new BoundField());
    //    myControls.Add(new BoundField());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new TextBox());
    //    myControls.Add(new CheckBox());
    //    myControls.Add(new DropDownList());

    //    return myControls;
    //}
    //private ArrayList createchalancontrolId()
    //{
    //    ArrayList arrControlid = new ArrayList();
    //    //  arrControlid.Add("ddFloorArea");    
    //    arrControlid.Add("DataField");
    //    arrControlid.Add("DataField");
    //    arrControlid.Add("DataField");
    //    arrControlid.Add("txtdate");
    //    arrControlid.Add("txtAmt");
    //    arrControlid.Add("chkApp");
    //    arrControlid.Add("ddlReason");


    //    return arrControlid;
    //}
    //private ArrayList getchalancontrol()
    //{
    //    ArrayList arrControlid = new ArrayList();
    //    // arrControlid.Add("SlNo");
    //    arrControlid.Add("ChalanDate");
    //    arrControlid.Add("fltChalanAmt");
    //    arrControlid.Add("flgUnposted");
    //    arrControlid.Add("ChalanDate");
    //    arrControlid.Add("fltChalanAmt");
    //    arrControlid.Add("flgUnposted");
    //    arrControlid.Add("intUnPostedRsn");


    //    return arrControlid;
    //}
    //private void fillDropDownchalan(GridView gdView, DataSet ds)
    //{

    //    foreach (GridViewRow gdRow in gdView.Rows)
    //    {
    //        if (ds.Tables.Count > 0)
    //        {

    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ArrayList arrin = new ArrayList();
    //                arrin.Add(Session["intLBID"].ToString());

    //                DropDownList ddlReasonAss = (DropDownList)gdRow.FindControl("ddlReason");
    //                ddlReasonAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][4].ToString();


    //                CheckBox chkAppAss = (CheckBox)gdRow.FindControl("chkApp");
    //                if ((ds.Tables[0].Rows[gdRow.RowIndex][6]) != "")
    //                {
    //                    if (Convert.ToBoolean(ds.Tables[0].Rows[gdRow.RowIndex][2]) == true)
    //                    {
    //                        chkAppAss.Checked = true;
    //                    }
    //                    else
    //                    {
    //                        chkAppAss.Checked = false;
    //                    }
    //                }


    //            }
    //        }
    //    }
    //}
    //protected void btndeleteCh_Click(object sender, ImageClickEventArgs i)
    //{
    //    int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
    //    //  int rowIndex = Convert.ToInt32(e.RowIndex);
    //    TextBox lblChalIdAss = (TextBox)gdvAOApprov.Rows[rowIndex].FindControl("lblChalId");
    //    if (lblChalIdAss.Text != "")
    //    {
    //        ArrayList arrin = new ArrayList();
    //        arrin.Add(Convert.ToInt32(lblChalIdAss.Text));
    //        try
    //        {
    //            chaldao.UpdateChalanMode(arrin);
    //            deleteUnsavedchalan();

    //        }
    //        catch (Exception ex)
    //        {
    //            Session["ERROR"] = ex.ToString();
    //            Response.Redirect("Error.aspx");
    //        }
    //    }
    //    FillGrid();
    //    gblObj.MsgBoxOk("Row Deleted   !", this);

    //   // FillHeadLbls();
    //    //}
    //    //else
    //    //{
    //    //}
    //}
    //private void deleteUnsavedchalan()
    //{
    //    List<Control> myControls = creategdFloorControl();
    //    ArrayList arrControlid = creategdFloorControlId();
    //    ArrayList arrDT = getDataTablegdFloor();
    //    DataTable dtgdRow = gblObj.deleteRows(myControls, arrControlid, arrDT, gdvAOApprov);
    //    if (dtgdRow.Rows.Count > 0)
    //    {
    //        DataSet ds = new DataSet();
    //        gdvAOApprov.DataSource = dtgdRow;
    //        gdvAOApprov.DataBind();
    //        ds.Tables.Add(dtgdRow);
    //        fillDropDownGridExistsFloor(gdvAOApprov, ds);
    //    }
    //    else
    //    {
    //        FillGrid();
    //    }
    //}
    //private void FillGO()
    //{
    //    DataSet ds1 = genDAO.GetGO();

    //    for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gdvAOApprovSched.Rows[i];
    //        DropDownList ddlGo = (DropDownList)gdvrow.FindControl("ddlGo");
    //        gblObj.FillCombo(ddlGo, ds1, 1);       
    //    }
    //}
    //protected void txtCnt_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtCnt.Text.Trim() != "") 
    //    {
    //        DataSet dsSched = new DataSet();
    //        ArrayList arS = new ArrayList();
    //        arS.Add(Convert.ToInt64(Session["numChalanIdOnline"]));
    //        dsSched = schDao.CheckScheduleExist(arS);
    //        if (dsSched.Tables[0].Rows.Count > 0 && dsSched.Tables[0].Rows.Count <= Convert.ToInt16(txtCnt.Text.ToString()))
    //        {
    //            gblObj.SetRowsCnt(gdvAOApprovSched, Convert.ToInt16(txtCnt.Text.ToString()));
    //            for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
    //            {
    //                GridViewRow gdv = gdvAOApprovSched.Rows[i];
    //                DropDownList ddlGo = (DropDownList)gdv.FindControl("ddlGo");

    //                DataSet ds1 = genDAO.GetGO();
    //                gblObj.FillCombo(ddlGo, ds1, 1);

    //                if (i < dsSched.Tables[0].Rows.Count)
    //                {
    //                    Label lblSlNoAss = (Label)gdv.FindControl("lblSlNo");
    //                    lblSlNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();

    //                    TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
    //                    txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

    //                    Label lblNameAss = (Label)gdv.FindControl("lblName");
    //                    lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

    //                    CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
    //                    if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[13]) == 1)
    //                    {
    //                        chkUnIdentAss.Checked = true;
    //                    }
    //                    else
    //                    {
    //                        chkUnIdentAss.Checked = false;
    //                    }
    //                    TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
    //                    txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();
    //                    TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
    //                    txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[4].ToString();
    //                    TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
    //                    txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[5].ToString();
    //                    TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
    //                    txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
    //                    TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
    //                    txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();
    //                    Label lblTotalAss = (Label)gdv.FindControl("lblTotal");
    //                    lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

    //                    //Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
    //                    //lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

    //                    Label lblSchedAss = (Label)gdv.FindControl("lblSched");
    //                    lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

    //                    Label lblAccNoAss = (Label)gdv.FindControl("lblAccNo");
    //                    lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

    //                    Label lblNewAccAss = (Label)gdv.FindControl("lblNewAcc");
    //                    lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[17].ToString();

    //                    Label lblNewTotAss = (Label)gdv.FindControl("lblNewTot");
    //                    lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

    //                    Label lblEditModeSAss = (Label)gdv.FindControl("lblEditModeS");
    //                    lblEditModeSAss.Text = "0";

    //                    //Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
    //                    //lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

    //                    Label lblOTotAss = (Label)gdv.FindControl("lblOTot");
    //                    lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

    //                    Label lblOAccAss = (Label)gdv.FindControl("lblOAcc");
    //                    lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();
    //                }
    //                else
    //                {
    //                    //ddlGo.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[10].ToString();
    //                }
    //            }
    //        }
    //        gblObj.FillGridSlNo(gdvAOApprovSched);
    //    }
    //    else
    //    {
    //        gblObj.SetRowsCnt(gdvAOApprovSched, 1);
    //        //SetNomGridDisable();
    //    }
    //}
    private void SetGridRowsWithData(DataSet ds, int cnt, GridView gdv)
    {
        gblObj = new clsGlobalMethods();

        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count <= cnt)
        {
            gblObj.SetRowsCnt(gdv, Convert.ToInt16(txtCnt.Text.ToString()));
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                FillGridCmb(gvr, "ddlGO");
                if (i < ds.Tables[0].Rows.Count)
                {
                    FillGridHavingData(gvr, ds, i);
                }
            }
            gblObj.FillGridSlNo(gdv);
            FillFooterTotals();
        }
        else
        {
            FillGridSched();
        }
    }
    protected void FillGridHavingData(GridViewRow gvr, DataSet dsSched, int i)
    {
        Label lblSlNoAss = (Label)gvr.FindControl("lblSlNo");
        lblSlNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();

        TextBox txtAccNoAss = (TextBox)gvr.FindControl("txtAccNo");
        txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

        Label lblNameAss = (Label)gvr.FindControl("lblName");
        lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

        CheckBox chkUnIdentAss = (CheckBox)gvr.FindControl("chkUnIdent");
        if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[13]) == 1)
        {
            chkUnIdentAss.Checked = true;
        }
        else
        {
            chkUnIdentAss.Checked = false;
        }
        TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
        txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();
        TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
        txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[4].ToString();
        TextBox txtPfAss = (TextBox)gvr.FindControl("txtPf");
        txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[5].ToString();
        TextBox txtDaAss = (TextBox)gvr.FindControl("txtDa");
        txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
        TextBox txtPayAss = (TextBox)gvr.FindControl("txtPay");
        txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();
        Label lblTotalAss = (Label)gvr.FindControl("lblTotal");
        lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        //Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
        //lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

        Label lblSchedAss = (Label)gvr.FindControl("lblSched");
        lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

        Label lblAccNoAss = (Label)gvr.FindControl("lblAccNo");
        lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

        Label lblNewAccAss = (Label)gvr.FindControl("lblNewAcc");
        lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[17].ToString();

        Label lblNewTotAss = (Label)gvr.FindControl("lblNewTot");
        lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        Label lblEditModeSAss = (Label)gvr.FindControl("lblEditModeS");
        lblEditModeSAss.Text = "0";

        //Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
        //lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

        Label lblOTotAss = (Label)gvr.FindControl("lblOTot");
        lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        Label lblOAccAss = (Label)gvr.FindControl("lblOAcc");
        lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();
    }
    protected void FillGridCmb(GridViewRow gvr, string ddl)
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();

        DropDownList ddlGo = (DropDownList)gvr.FindControl(ddl);
        DataSet ds1 = genDAO.GetGO();
        gblObj.FillCombo(ddlGo, ds1, 1);

    }
    protected void FillGridCmbM(GridViewRow gvr, string ddl1, string ddl2)
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();

        DropDownList ddlm1 = (DropDownList)gvr.FindControl(ddl1);
        DataSet ds1 = genDAO.GetMonth();
        gblObj.FillCombo(ddlm1, ds1, 1);

        DropDownList ddlm2 = (DropDownList)gvr.FindControl(ddl2);
        DataSet ds2 = genDAO.GetMonth();
        gblObj.FillCombo(ddlm2, ds1, 1);
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        //if (txtCnt.Text.Trim() != "")
        //{
        //    DataSet dsSched = new DataSet();
        //    ArrayList arS = new ArrayList();
        //    ArrayList arCols = new ArrayList();
        //    ArrayList arDdl = new ArrayList();
        //    arDdl.Add("ddlGo");
        //    SetArrCols(arCols);
        //    arS.Add(Convert.ToInt64(Session["numChalanIdOnline"]));
        //    dsSched = schDao.CheckScheduleExistNew(arS);
        //    gblObj.SetGridRowsWithData(dsSched, Convert.ToInt16(txtCnt.Text), gdvAOApprovSched, arDdl, arCols);
        //}
        //else
        //{
        //    gblObj.SetRowsCnt(gdvAOApprovSched, 1);
        //}

        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();
        schDao = new ScheduleDAO();

        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlGo");
            arDdl.Add("ddlFm");
            arDdl.Add("ddlTm");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            DataSet dsGO = new DataSet();
            dsGO = genDAO.GetGO();
            ArrayList arDdlDs = new ArrayList();
            arDdlDs.Add(dsGO);

            DataSet dsFm = new DataSet();
            dsFm = genDAO.GetMonth();
            arDdlDs.Add(dsFm);

            DataSet dsTm = new DataSet();
            dsTm = genDAO.GetMonth();
            arDdlDs.Add(dsTm);
            ////Store Ds to fill Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsSched = new DataSet();
            ArrayList arS = new ArrayList();
            arS.Add(Convert.ToInt64(Session["numChalanIdOnline"]));
            dsSched = schDao.CheckScheduleExistNew(arS);
            ////Ds to fill Grid//////////

            gblObj.SetGridRowsWithData(dsSched, Convert.ToInt16(txtCnt.Text), gdvAOApprovSched, arDdl, arCols, arDdlDs);
            FillFooterTotals();
        }
        else
        {
            gblObj.SetRowsCnt(gdvAOApprovSched, 1);
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("lblSlNo");
        arCols.Add("txtAccNo");
        arCols.Add("lblName");
        arCols.Add("chkUnIdent");
        arCols.Add("txtSubn");
        arCols.Add("txtRep");
        arCols.Add("txtPf");
        arCols.Add("txtDa");
        arCols.Add("ddlGo");
        arCols.Add("txtPay");
        arCols.Add("ddlFm");
        arCols.Add("ddlTm");
        arCols.Add("lblTotal");
        arCols.Add("lblSchedMain");
        arCols.Add("lblSched");
        arCols.Add("lblAccNo");
        arCols.Add("lblNewAcc");
        arCols.Add("lblNewTot");
        arCols.Add("lblEditModeS");
        arCols.Add("lblRecNo");
        arCols.Add("lblOTot");
        arCols.Add("lblOAcc");


        //TemplateField tmp = new TemplateField();
        //string dd = tmp.ItemTemplate.GetHashCode();

        //foreach (GridViewRow row in gdvAOApprovSched.Rows)
        //{
        //TextBox  textbox = row.FindControl("TextBox") as TextBox;
        //string  a = textbox.Text;
        //string a = gdvAOApprovSched.DataKeys[1].Value.ToString();
    }
    //}
    protected void gdvAOApprovSched_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //string colId = gdvAOApprovSched.DataKeys[e.Row.RowIndex].Values[0].ToString();
        //    //string colB = gdvAOApprovSched.DataKeys[e.Row.RowIndex].Values[1].ToString();
        //    //string colH = gdvAOApprovSched.DataKeys[e.Row.RowIndex].Values[2].ToString();

        //}
        //foreach (Control in gdvAOApprovSched.Controls)
        //{

        //}
    }
    protected void gdvAOApprovSched_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    // Retrieve the LinkButton control from the first column.
        //    Control addButton = (Control)e.Row.Cells[1].NamingContainer;
        //    string s = addButton.ID.ToString();
        //    // Set the LinkButton's CommandArgument property with the
        //    // row's index.
        //    //addButton.CommandArgument = e.Row.RowIndex.ToString();
        //}
    }
    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        intCurRwSched = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvAOApprov.Rows[intCurRwSched];
        TextBox txtAmtAss = (TextBox)gvr.FindControl("txtAmt");
        if (txtAmtAss.Text == "")
        {
            txtAmtAss.Text = 0.ToString();
        }
        gblObj.SetFooterTotalsTempField(gdvAOApprov, 5, "txtAmt", 1);


    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        {
            Session["Sessionclear"] = 1;
            btnBack.PostBackUrl = "~/Contents/Remittance.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
        {
            btnBack.PostBackUrl = "~/Contents/AnnStatementLat.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
        {
            btnBack.PostBackUrl = "~/Contents/RemittanceCurr.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5)
        {
            btnBack.PostBackUrl = "~/Contents/TransferEntryCurr.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 7)
        {
            btnBack.PostBackUrl = "~/Contents/Daer1.aspx";
        }
    }
}

