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

public partial class Contents_ChalanEdit : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblObj;
    AORecorrection aoRecorr;
    AORecorrectionDAO aoRecorrDAO;
    ChalanDAO chaldao;
    //ChalanPDE chalPde;
    //ChalanPDEDao chalPDao;

    Employee emp;
    EmployeeDAO empD;
    CorrectionEntry corr;
    CorrectionEntryDao corrDao;

    SchedulePDE schedPde;
    SchedulePDEDao schedPdeDao;


    //static int intCurRw = 0;
    //static int intCurRwChal = 0;
    static int intCurRwSched = 0;
    //static int intMth = 0;
    //static int intDy = 0;
    //static int intYrId = 0;
    //static int intChalId = 0;
    double fltAmtBfr = 0;
    double fltAmtAfr = 0;
    int corrType = 0;
    //static int intCorrType = 0;
    static int intMaxRecNo = 0;
    static int intCnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
        }
    }
    protected void FillGridCmbGo(GridViewRow gvr, string ddl)
    {
        genDAO = new KPEPFGeneralDAO();
        gblObj = new clsGlobalMethods();

        DropDownList ddlGo = (DropDownList)gvr.FindControl(ddl);
        DataSet ds1 = genDAO.GetGO();
        gblObj.FillCombo(ddlGo, ds1, 1);

    }
    private void Initialsettings()
    {
        
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            btnBack.Text = "Back to Search";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        {
            btnBack.Text = "Back to Ann. Statement";
            if (Request.QueryString["intGroupId"] == null || Request.QueryString["intGroupId"] == "")
            {
                Response.Redirect("AnnStatementLat.aspx");
            }
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
        {
            btnBack.Text = "Back to Treasury Data";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
        {
            btnBack.Text = "Back to Remittance PDE";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5)      //AG Stmnt
        {
            btnBack.Text = "Back to TransferEntry";
            if (Convert.ToDouble(Request.QueryString["numChalanId"]) == 0)
            {
                Response.Redirect("TransferEntryPDE.aspx");
            }
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 6)      //Card Generation
        {
            btnBack.Text = "Back to Card Generation";
            if (Convert.ToDouble(Request.QueryString["numChalanId"]) == 0)
            {
                Response.Redirect("CardGen.aspx");
            }
        }
        if (Request.QueryString["numChalanId"] == null || Request.QueryString["numChalanId"] == "")
        {
            Response.Redirect("RemittancePDE.aspx");
        }
        else
        {

            //Session["numChalanIdEdit"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
            //Session["flgPrevYear"] = Convert.ToDouble(Request.QueryString["flgPrevYear"]);
            //Session["flgApproval"] = Convert.ToDouble(Request.QueryString["flgApproval"]);
            //Session["intGroupId"] =  Convert.ToDouble(Request.QueryString["intGroupId"]);
            //FillGrid();
            //FillGridSched();
            //SetGrids();
            //SetLbls();

            Session["numChalanIdEdit"] = Convert.ToDouble(Request.QueryString["numChalanId"]);
            Session["flgPrevYear"] = Convert.ToDouble(Request.QueryString["flgPrevYear"]);
            int r = Convert.ToInt16(Request.QueryString["flgPrevYear"]);
            Session["flgApproval"] = Convert.ToDouble(Request.QueryString["flgApproval"]);
            Session["intGroupId"] = Convert.ToDouble(Request.QueryString["intGroupId"]);
            if (Convert.ToDouble(Request.QueryString["intGroupId"]) != 1)
            {
                FillGrid();
                FillGridSched();
                SetGrids();
                SetLbls();
            }
            else
            {
                Response.Redirect("ChalanEditAg.aspx");
            }
        }
    }
    private void SetLbls()
    {
        gendao = new GeneralDAO();
        
        ArrayList ar = new ArrayList();
        ArrayList arm = new ArrayList();
        ArrayList ard = new ArrayList();

        ArrayList arTE = new ArrayList();
        DataSet dsTe = new DataSet();
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            ar.Add(Convert.ToInt16(Session["IntYearSearchChal"]));
            //ar.Add(Convert.ToInt16(Session["intYearSearchChalToFill"]));
            arm.Add(Convert.ToInt16(Session["intMonthSearchChal"]));
            ard.Add(Convert.ToInt16(Session["intDistSearchChal"]));
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        {
            ar.Add(Convert.ToInt16(Session["intYearAnnStmnt"]));
            arm.Add(Convert.ToInt16(Request.QueryString["intMonthID"]));
            ard.Add(Convert.ToInt16(Request.QueryString["intDistID"]));
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
        {
            ar.Add(Convert.ToInt16(Session["IntYearRem1"]));
            arm.Add(Convert.ToInt16(Session["IntMonthRem1"]));
            ard.Add(Convert.ToInt16(Session["IntDistRem1"]));
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
        {
            ar.Add(Convert.ToInt16(Session["intYearIdRem01"]));
            arm.Add(Convert.ToInt16(Session["intMonthIdRem01"]));
            ard.Add(Convert.ToInt16(Session["intDistIdRem01"]));
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5)
        {
            ar.Add(Convert.ToInt16(Session["IntYearAG"]));
            arm.Add(Convert.ToInt16(Session["IntMonthAG"]));
            ard.Add(Convert.ToInt16(0));
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 6)
        {
            ar.Add(0);
            arm.Add(0);
            ard.Add(0);
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 7)
        {
            ar.Add(Convert.ToInt16(Session["IntYearAG"]));
            arm.Add(Convert.ToInt16(Session["IntMonthAG"]));
            ard.Add(0);
        }
        lblYear.Text = gendao.GetYearFromId(ar);
        lblMonth.Text = gendao.GetMonthFromId(arm);
        lblDist.Text = gendao.GetDistrictFromId(ard);

        arTE.Add(Convert.ToInt32(Session["numChalanIdEdit"]));
        dsTe = gendao.GetTENo(arTE);
        if (dsTe.Tables[0].Rows.Count > 0)
        {
            lblType.Text = dsTe.Tables[0].Rows[0].ItemArray[0].ToString() + '-' + dsTe.Tables[0].Rows[0].ItemArray[1].ToString();
            
        }
    }
    private void FillGridSched()
    {
        aoRecorr = new AORecorrection();
        aoRecorrDAO = new AORecorrectionDAO();

        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();
        
        aoRecorr.NumChalanId = Convert.ToDouble(Session["numChalanIdEdit"]);
        aoRecorr.FlgYearPrev = Convert.ToInt16(Session["flgPrevYear"]);
        dsSched = aoRecorrDAO.SelectApprovalPDELnk3(aoRecorr);
        if (dsSched.Tables[0].Rows.Count > 0)
        {
            gdvAOApprovSched.DataSource = dsSched;
            gdvAOApprovSched.DataBind();
            txtCnt.Text = Convert.ToString(dsSched.Tables[0].Rows.Count);

            for (int i = 0; i < dsSched.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvAOApprovSched.Rows[i];
                Label lblSlNoAss = (Label)gdv.FindControl("lblSlNo");
                lblSlNoAss.Text = (i+1).ToString();

                TextBox txtAccNoAss = (TextBox)gdv.FindControl("txtAccNo");
                txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

                Label lblNameAss = (Label)gdv.FindControl("lblName");
                lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();

                CheckBox chkUnIdentAss = (CheckBox)gdv.FindControl("chkUnIdent");
                if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[18]) == 1)
                {
                    chkUnIdentAss.Checked = true;
                }
                else
                {
                    chkUnIdentAss.Checked = false;
                }
                TextBox txtSubnAss = (TextBox)gdv.FindControl("txtSubn");
                txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
                TextBox txtRepAss = (TextBox)gdv.FindControl("txtRep");
                txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();
                TextBox txtPfAss = (TextBox)gdv.FindControl("txtPf");
                txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();
                TextBox txtDaAss = (TextBox)gdv.FindControl("txtDa");
                txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[9].ToString();
                TextBox txtPayAss = (TextBox)gdv.FindControl("txtPay");
                txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[10].ToString();
                Label lblTotalAss = (Label)gdv.FindControl("lblTotal");
                lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();
                
                
                Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
                lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();
               
                Label lblSchedAss = (Label)gdv.FindControl("lblSched");
                lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[14].ToString();

                Label lblAccNoAss = (Label)gdv.FindControl("lblAccNo");
                lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblNewAccAss = (Label)gdv.FindControl("lblNewAcc");
                lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblNewTotAss = (Label)gdv.FindControl("lblNewTot");
                lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();

                Label lblEditModeSAss = (Label)gdv.FindControl("lblEditModeS");
                lblEditModeSAss.Text = "0";

                Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
                lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

                Label lblOTotAss = (Label)gdv.FindControl("lblOTot");
                lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();

                Label lblOAccAss = (Label)gdv.FindControl("lblOAcc");
                lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

                intMaxRecNo = Convert.ToInt16(lblRecNoAss.Text.ToString());

                Label lblSlNoNew = (Label)gdv.FindControl("lblSlNoNew");
                lblSlNoNew.Text = dsSched.Tables[0].Rows[i].ItemArray[23].ToString();

                FillGridCmbGo(gdv, "ddlGo");
                DropDownList ddlGoAss = (DropDownList)gdv.FindControl("ddlGo");
                ddlGoAss.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[24].ToString();

                FillGridCmbM(gdv, "ddlFm", "ddlTm");
                DropDownList ddlFm = (DropDownList)gdv.FindControl("ddlFm");
                ddlFm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[25].ToString();
                DropDownList ddlTm = (DropDownList)gdv.FindControl("ddlTm");
                ddlTm.SelectedValue = dsSched.Tables[0].Rows[i].ItemArray[26].ToString();

                Label lblFMO = (Label)gdv.FindControl("lblFMO");              
                Label lblTMO = (Label)gdv.FindControl("lblTMO");              
                lblFMO.Text = dsSched.Tables[0].Rows[i].ItemArray[25].ToString();
                lblTMO.Text = dsSched.Tables[0].Rows[i].ItemArray[26].ToString();

            }
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 4, "txtSubn",1);
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 5,"txtRep",1);
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 6, "txtPf",1);
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 7, "txtDa",1);
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 8, "txtPay",1);
            //gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 9, "lblTotal",2);
            FillFooterTotals();
        }
        else
        {
            SetGridDefaultSched();
        }
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
    private void FillFooterTotals()
    {
        gblObj = new clsGlobalMethods();

        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 4, "txtSubn", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 5, "txtRep", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 6, "txtPf", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 7, "txtDa", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 8, "txtPay", 1);
        gblObj.SetFooterTotalsTempField(gdvAOApprovSched, 12, "lblTotal", 2);
    }
    private void FillGrid()
    {
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        chaldao = new ChalanDAO();

        DataSet dsChal = new DataSet();
        ArrayList ar=new ArrayList();
        
        DataSet dsM = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        arrIn1.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn1);

        ar.Add(Convert.ToDouble(Session["numChalanIdEdit"]));
        ar.Add(Convert.ToDouble(Session["flgPrevYear"]));
        ar.Add(Convert.ToDouble(Session["intGroupId"]));
        dsChal = chaldao.GetChalanFrmChalIdNew(ar);
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsChal;
            gdvAOApprov.DataBind();

            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                TextBox txtdateAss = (TextBox)gdv.FindControl("txtdate");
                txtdateAss.Text = dsChal.Tables[0].Rows[i].ItemArray[4].ToString();
                Session["chalDate"] = txtdateAss.Text;

                TextBox txtAmtAss = (TextBox)gdv.FindControl("txtAmt");
                txtAmtAss.Text = dsChal.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblChalIdAss = (Label)gdv.FindControl("lblChalId");
                lblChalIdAss.Text = dsChal.Tables[0].Rows[i].ItemArray[6].ToString();
                //intChalId = Convert.ToInt32(lblChalIdAss.Text.ToString());

                //Label lblMonthAss = (Label)gdv.FindControl("lblMonth");
                //lblMonthAss.Text = dsChal.Tables[0].Rows[i].ItemArray[11].ToString();

                Label lblYrAss = (Label)gdv.FindControl("lblYr");
                lblYrAss.Text = dsChal.Tables[0].Rows[i].ItemArray[10].ToString();
                //intYrId = Convert.ToInt16(lblYrAss.Text);


                Label lblMonthAss = (Label)gdv.FindControl("lblMonth");
                lblMonthAss.Text = dsChal.Tables[0].Rows[i].ItemArray[11].ToString();
                //intMth = Convert.ToInt16(lblMonthAss.Text);

                Label lblDayAss = (Label)gdv.FindControl("lblDay");
                lblDayAss.Text = dsChal.Tables[0].Rows[i].ItemArray[12].ToString();
                //intDy = Convert.ToInt16(lblDayAss.Text);

                Label lblEditModeAss = (Label)gdv.FindControl("lblEditMode");
                lblEditModeAss.Text = "0";

                CheckBox chkAppAss = (CheckBox)gdv.FindControl("chkApp");
                Label lblUnPAss = (Label)gdv.FindControl("lblUnP");

                if (Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[13]) == 2)
                {
                    chkAppAss.Checked = true;
                    lblUnPAss.Text = "1";
                }
                else
                {
                    chkAppAss.Checked = false;
                    lblUnPAss.Text = "2";
                }

                DropDownList ddlReasonAss = (DropDownList)gdv.FindControl("ddlReason");
                gblObj.FillCombo(ddlReasonAss, dsM, 1);
                ddlReasonAss.SelectedValue = dsChal.Tables[0].Rows[i].ItemArray[14].ToString();
                Session["intSchMainId"] = dsChal.Tables[0].Rows[i].ItemArray[17].ToString();
                //if (dsChal.Tables[0].Rows[i].ItemArray[18] != null || dsChal.Tables[0].Rows[i].ItemArray[18] != "")
                //{
                    Session["cnt"] = Convert.ToInt16(dsChal.Tables[0].Rows[i].ItemArray[18]);
                //}
            }
            gblObj.SetFooterTotalsTempField(gdvAOApprov, 5, "txtAmt", 1);
        }
        else
        {
            SetGridDefault();
        }
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("chvTreasuryName");
        ar.Add("intChalanNo");

        //ar.Add("fltChalanAmt");
        //ar.Add("fltTotalSum");
        //ar.Add("intChalanId");
        //ar.Add("intDistID");
        gblObj.SetGridDefault(gdvAOApprov, ar);
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
        gblObj.SetGridDefault(gdvAOApprovSched, ar);


    }
    private void SetGrids()
    {
        if (Convert.ToInt16(Session["flgApproval"]) == 2)
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
        btnOK.Enabled = true;
        txtCnt.ReadOnly = false;
        //for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvAOApprov.Rows[i];
        //    TextBox txtdateAss = (TextBox)gdvrow.FindControl("txtdate");
        //    txtdateAss.ReadOnly = false;
        //    txtdateAss.Enabled = true;
        //    //TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
        //    //txtAmtAss.ReadOnly = false;
        //    //txtAmtAss.Enabled = true;

        //    CheckBox chkAppAss = (CheckBox)gdvrow.FindControl("chkApp");
        //    chkAppAss.Enabled = true;
        //    DropDownList ddlReasonAss = (DropDownList)gdvrow.FindControl("ddlReason");
        //    ddlReasonAss.Enabled = true;
        //}

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

            ImageButton imgdel = (ImageButton)gdvrowS.FindControl("btndelete");
            imgdel.Enabled = true;

            DropDownList ddlTm = (DropDownList)gdvrowS.FindControl("ddlTm");
            DropDownList ddlFm = (DropDownList)gdvrowS.FindControl("ddlFm");
            DropDownList ddlGo = (DropDownList)gdvrowS.FindControl("ddlGo");

            ddlFm.Enabled = true;
            ddlTm.Enabled = true;
            ddlGo.Enabled = true;
        }
    }
    private void SetGridsNonEditable()
    {
        btnOK.Enabled = false ;
        txtCnt.ReadOnly = true;
        //for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvAOApprov.Rows[i];
        //    TextBox txtdateAss = (TextBox)gdvrow.FindControl("txtdate");
        //    txtdateAss.ReadOnly = true;
        //    txtdateAss.Enabled = false;
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");
        //    txtAmtAss.ReadOnly = true;
        //    txtAmtAss.Enabled = false;
        //    CheckBox chkAppAss = (CheckBox)gdvrow.FindControl("chkApp");
        //    chkAppAss.Enabled = false;
        //    DropDownList ddlReasonAss = (DropDownList)gdvrow.FindControl("ddlReason");
        //    ddlReasonAss.Enabled = false;

        //}

        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
        {
            GridViewRow gdvrowS = gdvAOApprovSched.Rows[i];
            TextBox txtAccNoAss = (TextBox)gdvrowS.FindControl("txtAccNo");
            txtAccNoAss.ReadOnly = true ;
            txtAccNoAss.Enabled = false ;

            TextBox txtSubnAss = (TextBox)gdvrowS.FindControl("txtSubn");
            txtSubnAss.ReadOnly = true ;
            txtSubnAss.Enabled = false ;

            TextBox txtRepAss = (TextBox)gdvrowS.FindControl("txtRep");
            txtRepAss.ReadOnly = true ;
            txtRepAss.Enabled = false ;

            TextBox txtPfAss = (TextBox)gdvrowS.FindControl("txtPf");
            txtPfAss.ReadOnly = true ;
            txtPfAss.Enabled = false ;

            TextBox txtDaAss = (TextBox)gdvrowS.FindControl("txtDa");
            txtDaAss.ReadOnly = true ;
            txtDaAss.Enabled = false ;

            TextBox txtPayAss = (TextBox)gdvrowS.FindControl("txtPay");
            txtPayAss.ReadOnly = true;
            txtPayAss.Enabled = false ;

            CheckBox chkUnIdentAss = (CheckBox)gdvrowS.FindControl("chkUnIdent");
            chkUnIdentAss.Enabled = false;

            ImageButton imgdel = (ImageButton)gdvrowS.FindControl("btndelete");
            imgdel.Enabled = false;

            DropDownList ddlTm = (DropDownList)gdvrowS.FindControl("ddlTm");
            DropDownList ddlFm = (DropDownList)gdvrowS.FindControl("ddlFm");
            DropDownList ddlGo = (DropDownList)gdvrowS.FindControl("ddlGo");

            ddlFm.Enabled = false;
            ddlTm.Enabled = false;
            ddlGo.Enabled = false;
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        intCnt = intCnt + 1;
        //if (intCnt == 1)
        //{
            UpdateSchedule();
        //}
        FillGrid();
        FillGridSched();
        gblObj.MsgBoxOk("Updated!", this);
    }
    //private void AddSchedMain()
    //{
    //    schedPdeDao = new SchedulePDEDao();

    //    DataSet ds = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(0);      //Sched MainId
    //    ar.Add(1250);     //LB Id
    //    ar.Add(Convert.ToInt32(Session["intGroupId"]));     //Group Id
    //    ar.Add(Convert.ToInt64(Session["intUserId"]));     //User Id
    //    ds = schedPdeDao.ScheduleMainSave(ar);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        Session["intSchMainId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //}
    private void UpdateSchedule()
    {
        gblObj = new clsGlobalMethods();
        schedPde = new SchedulePDE();
        schedPdeDao = new SchedulePDEDao();
        float schedId = 0;
        if (Convert.ToDouble(gdvAOApprov.FooterRow.Cells[5].Text) > 0)
        {
            for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
            {
                GridViewRow gvrow = gdvAOApprovSched.Rows[i];
                Label lblEditModeSAss = (Label)gvrow.FindControl("lblEditModeS");

                Label lblRecNoAss = (Label)gvrow.FindControl("lblRecNo");
                TextBox txtSubnAss = (TextBox)gvrow.FindControl("txtSubn");
                TextBox txtRepAss = (TextBox)gvrow.FindControl("txtRep");
                TextBox txtPfAss = (TextBox)gvrow.FindControl("txtPf");
                TextBox txtDaAss = (TextBox)gvrow.FindControl("txtDa");
                TextBox txtPayAss = (TextBox)gvrow.FindControl("txtPay");
                Label lblTotalAss = (Label)gvrow.FindControl("lblTotal");
                Label lblSchedMainAss = (Label)gvrow.FindControl("lblSchedMain");
                Label lblSchedAss = (Label)gvrow.FindControl("lblSched");
                Label lblAccNoAss = (Label)gvrow.FindControl("lblAccNo");
                Label lblOAccAss = (Label)gvrow.FindControl("lblOAcc");
                Label lblNewAccAss = (Label)gvrow.FindControl("lblNewAcc");
                Label lblYrAss = (Label)gvrow.FindControl("lblYr");
                Label lblOTotAss = (Label)gvrow.FindControl("lblOTot");
                CheckBox chkUnIdent = (CheckBox)gvrow.FindControl("chkUnIdent");

                Label lblSlNoNew = (Label)gvrow.FindControl("lblSlNoNew");
                Label lblSlNo = (Label)gvrow.FindControl("lblSlNo");

                DropDownList ddlGo = (DropDownList)gvrow.FindControl("ddlGo");
                DropDownList ddlFm = (DropDownList)gvrow.FindControl("ddlFm");
                DropDownList ddlTm = (DropDownList)gvrow.FindControl("ddlTm");

                if (Convert.ToDouble(lblTotalAss.Text) > 0)
                {
                    if (Convert.ToInt16(lblEditModeSAss.Text) >= 1)
                    {
                        schedPde.NumID = Convert.ToDouble(lblSchedAss.Text.ToString());
                        schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
                        schedPde.NumEmpID = Convert.ToInt32(lblNewAccAss.Text);
                        schedPde.ChvName = "";
                        schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
                        schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
                        schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
                        schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
                        schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
                        schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
                        if (ddlGo.SelectedValue == "")
                        {
                            schedPde.ChvGOId = 0;
                        }
                        else
                        {
                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
                        }
                        schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
                        //schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
                        if (chkUnIdent.Checked == true)
                        {
                            schedPde.FlgUnIdentifiedEmp = 1;
                        }
                        else
                        {
                            schedPde.FlgUnIdentifiedEmp = 0;
                        }
                        schedPde.IntModeChange = 3;
                        schedPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
                        schedPde.FlgUnPosted = 0;
                        schedPde.IntUnPostedRsn = 0;
                        schedPde.ChvRem = "";
                        //schedPde.IntChalanId = intChalId;
                        schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
                        schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
                        if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
                        {
                            schedPde.ChvGOId = 0;
                        }
                        else
                        {
                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
                        }
                        if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
                        {
                            schedPde.IntFm = 0;
                        }
                        else
                        {
                            schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
                        }
                        if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
                        {
                            schedPde.IntTm = 0;
                        }
                        else
                        {
                            schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
                        }
                        schedId = schedPdeDao.SaveSchedulePdeCorr(schedPde);

                        //findCorrType(Convert.ToDouble(lblOTotAss.Text), Convert.ToDouble(lblTotalAss.Text), Convert.ToInt16(lblOAccAss.Text), Convert.ToInt16(lblNewAccAss.Text));
                        saveCorrectionEntry(i, schedId,0);
                    }
                }
                else
                {
                    gblObj.MsgBoxOk("Enter amount!", this);
                }
            }
        }
    }
    private void saveCorrectionEntry(int rw, float schedId,int intDel)
    {
        genDAO = new KPEPFGeneralDAO();
        ArrayList ardt = new ArrayList();
        gendao = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        corr = new CorrectionEntry();
        corrDao = new CorrectionEntryDao();
        //gFunFindPDEYearIdFromDate
        int yr;
        int mth;
        int intDy;
        Double amtO = 0;
        Double amtN = 0;
        int accO = 0;
        int accN = 0;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        ardt.Add(Session["chalDate"]);
        yr = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
        //yr = Convert.ToInt16(Session["IntYearRem1"]);
        mth = Convert.ToDateTime(Session["chalDate"]).Month;
        intDy = Convert.ToDateTime(Session["chalDate"]).Day; 

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
            for (int j = 0; j < 2;j++) 
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
                corr.IntChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
                corr.IntSchedId = Convert.ToInt32(lblSched.Text);
                corr.FlgType = 1;           //Remittance
                corr.FltRoundingAmt = 0;
                corr.IntCorrectionType = corrType;
                //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
                if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)
                {
                    corr.IntChalanType = 4;
                }
                else
                {
                    corr.IntChalanType = 2;
                }
                corr.IntTblTp = 1;
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
            corr.IntChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
            corr.IntSchedId = schedId;
            corr.FlgType = 1;           //Remittance
            corr.FltRoundingAmt = 0;
            corr.IntCorrectionType = corrType;
            //if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
            if (Convert.ToInt16(Session["flgPageBack"]) == 5 || Convert.ToInt16(Session["flgPageBack"]) == 7)
            {
                corr.IntChalanType = 4;
            }
            else
            {
                corr.IntChalanType = 2;
            }
            corr.IntTblTp = 1;
            corrDao.CreateCorrEntryCalcTblTp(corr);
        }
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
    //private void UpdateSchedule()
    //{
    //    gblObj = new clsGlobalMethods();
    //    schedPde = new SchedulePDE();
    //    schedPdeDao = new SchedulePDEDao();

    //    if (Convert.ToDouble(gdvAOApprov.FooterRow.Cells[5].Text) > 0)
    //    {
    //        for (int i = 0; i < gdvAOApprovSched.Rows.Count; i++)
    //        {
    //            GridViewRow gvrow = gdvAOApprovSched.Rows[i];
    //            Label lblEditModeSAss = (Label)gvrow.FindControl("lblEditModeS");

    //            Label lblRecNoAss = (Label)gvrow.FindControl("lblRecNo");
    //            TextBox txtSubnAss = (TextBox)gvrow.FindControl("txtSubn");
    //            TextBox txtRepAss = (TextBox)gvrow.FindControl("txtRep");
    //            TextBox txtPfAss = (TextBox)gvrow.FindControl("txtPf");
    //            TextBox txtDaAss = (TextBox)gvrow.FindControl("txtDa");
    //            TextBox txtPayAss = (TextBox)gvrow.FindControl("txtPay");
    //            Label lblTotalAss = (Label)gvrow.FindControl("lblTotal");
    //            Label lblSchedMainAss = (Label)gvrow.FindControl("lblSchedMain");
    //            Label lblSchedAss = (Label)gvrow.FindControl("lblSched");
    //            Label lblAccNoAss = (Label)gvrow.FindControl("lblAccNo");
    //            Label lblOAccAss = (Label)gvrow.FindControl("lblOAcc");
    //            Label lblNewAccAss = (Label)gvrow.FindControl("lblNewAcc");
    //            Label lblYrAss = (Label)gvrow.FindControl("lblYr");
    //            Label lblOTotAss = (Label)gvrow.FindControl("lblOTot");
    //            CheckBox chkUnIdent = (CheckBox)gvrow.FindControl("chkUnIdent");

    //            Label lblSlNoNew = (Label)gvrow.FindControl("lblSlNoNew");
    //            Label lblSlNo = (Label)gvrow.FindControl("lblSlNo");

    //            DropDownList ddlGo = (DropDownList)gvrow.FindControl("ddlGo");
    //            DropDownList ddlFm = (DropDownList)gvrow.FindControl("ddlFm");
    //            DropDownList ddlTm = (DropDownList)gvrow.FindControl("ddlTm");

    //            if (Convert.ToDouble(lblTotalAss.Text) > 0)
    //            {
    //                if (Convert.ToInt16(lblEditModeSAss.Text) >= 1)
    //                {
    //                    //Find intCorrType////////
    //                    if (Convert.ToInt32(lblOAccAss.Text.ToString()) == 0)
    //                    {
    //                        fltAmtBfr = 0;
    //                        fltAmtAfr = Convert.ToDouble(lblOTotAss.Text);

    //                        schedPde.NumID = Convert.ToDouble(lblSchedAss.Text.ToString());
    //                        schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
    //                        schedPde.NumEmpID = Convert.ToInt32(lblNewAccAss.Text);
    //                        schedPde.ChvName = "";
    //                        schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
    //                        schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
    //                        schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
    //                        schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
    //                        schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
    //                        schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
                           
    //                        schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
    //                        if (chkUnIdent.Checked == true)
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 1;
    //                        }
    //                        else
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 0;
    //                        }
    //                        schedPde.IntModeChange = 3;
    //                        schedPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                        schedPde.FlgUnPosted = 0;
    //                        schedPde.IntUnPostedRsn = 0;
    //                        schedPde.ChvRem = "";
    //                        //schedPde.IntChalanId = intChalId;
    //                        schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
    //                        //Convert.ToDouble(Session["numChalanIdEdit"])
    //                        schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
    //                        //schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedItem);
    //                        if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
    //                        {
    //                            schedPde.ChvGOId = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                        }
    //                        if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntFm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
    //                        }
    //                        if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntTm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
    //                        }
    //                        schedPdeDao.SaveSchedulePde(schedPde);

    //                    }
    //                    else if (Convert.ToInt32(lblOAccAss.Text.ToString()) != Convert.ToInt32(lblNewAccAss.Text.ToString()))
    //                    {

    //                        for (int j = 0; j < 2; j++)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                fltAmtBfr = Convert.ToDouble(lblOTotAss.Text);
    //                                fltAmtAfr = 0;
    //                            }
    //                            else
    //                            {
    //                                fltAmtBfr = 0;
    //                                fltAmtAfr = Convert.ToDouble(lblTotalAss.Text);
    //                            }
    //                            schedPde.NumID = Convert.ToDouble(lblSchedAss.Text.ToString());
    //                            if (j == 0)
    //                            {
    //                                intCorrType = 5;
    //                                schedPde.IntRecNo = intMaxRecNo + 1;
    //                            }
    //                            else
    //                            {
    //                                intCorrType = 4;
    //                                schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
    //                            }
    //                            if (j == 0)
    //                            {
    //                                schedPde.NumEmpID = Convert.ToInt32(lblOAccAss.Text);
    //                            }
    //                            else
    //                            {
    //                                schedPde.NumEmpID = Convert.ToInt32(lblNewAccAss.Text);
    //                            }
    //                            schedPde.ChvName = "";
    //                            schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
    //                            schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
    //                            schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
    //                            schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
    //                            schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
    //                            if (j == 0)
    //                            {
    //                                schedPde.FltTotal = -Convert.ToDouble(lblTotalAss.Text);
    //                            }
    //                            else
    //                            {
    //                                schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
    //                            }
    //                            if (ddlGo.SelectedValue == "")
    //                            {
    //                                schedPde.ChvGOId = 0;
    //                            }
    //                            else
    //                            {
    //                                schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                            }
    //                            if (Convert.ToInt16(Session["cnt"]) == 1)
    //                            {
    //                                schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
    //                                //schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
    //                            }
    //                            else
    //                            {
    //                                schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
    //                            }
    //                            if (chkUnIdent.Checked == true)
    //                            {
    //                                schedPde.FlgUnIdentifiedEmp = 1;
    //                            }
    //                            else
    //                            {
    //                                schedPde.FlgUnIdentifiedEmp = 0;
    //                            }
    //                            if (j == 0)
    //                            {
    //                                schedPde.IntModeChange = 4;
    //                            }
    //                            else
    //                            {
    //                                schedPde.IntModeChange = 3;
    //                            }
    //                            schedPde.IntUserId = Convert.ToInt64(Session["intUserId"]);

    //                            schedPde.FlgUnPosted = 0;
    //                            schedPde.IntUnPostedRsn = 0;
    //                            schedPde.ChvRem = "";
    //                            //schedPde.IntChalanId = intChalId;
    //                            schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
    //                            schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
    //                            if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
    //                            {
    //                                schedPde.ChvGOId = 0;
    //                            }
    //                            else
    //                            {
    //                                schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                            }
    //                            if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
    //                            {
    //                                schedPde.IntFm = 0;
    //                            }
    //                            else
    //                            {
    //                                schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
    //                            }
    //                            if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
    //                            {
    //                                schedPde.IntTm = 0;
    //                            }
    //                            else
    //                            {
    //                                schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
    //                            }
    //                            schedPdeDao.SaveSchedulePde(schedPde);
    //                            double dblAmtToCalc;
    //                            dblAmtToCalc = schedPde.FltTotal;
    //                            if (Convert.ToInt32(schedPde.NumEmpID) > 0)
    //                            {
    //                                // SaveCorrectionEntry(schedPde.NumEmpID, intChalId, intYrId, intMth, intDy, dblAmtToCalc, schedPde.NumID, 2, fltAmtBfr, fltAmtAfr, 1);
    //                            }
    //                        }
    //                    }
    //                    else if (Convert.ToInt64(lblOTotAss.Text.ToString()) != Convert.ToInt64(lblTotalAss.Text.ToString()))
    //                    {
    //                        fltAmtBfr = Convert.ToDouble(lblOTotAss.Text);
    //                        fltAmtAfr = Convert.ToDouble(lblTotalAss.Text);

    //                        schedPde.NumID = Convert.ToDouble(lblSchedAss.Text.ToString());
    //                        intCorrType = 3;
    //                        schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
    //                        schedPde.NumEmpID = Convert.ToInt32(lblNewAccAss.Text);
    //                        schedPde.ChvName = "";
    //                        schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
    //                        schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
    //                        schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
    //                        schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
    //                        schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
    //                        schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
    //                        if (ddlGo.SelectedValue == "")
    //                        {
    //                            schedPde.ChvGOId = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                        }
    //                        schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
    //                        //schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
    //                        if (chkUnIdent.Checked == true)
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 1;
    //                        }
    //                        else
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 0;
    //                        }
    //                        schedPde.IntModeChange = 3;
    //                        schedPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                        schedPde.FlgUnPosted = 0;
    //                        schedPde.IntUnPostedRsn = 0;
    //                        schedPde.ChvRem = "";
    //                        //schedPde.IntChalanId = intChalId;
    //                        schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
    //                        schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
    //                        if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
    //                        {
    //                            schedPde.ChvGOId = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                        }
    //                        if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntFm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
    //                        }
    //                        if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntTm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
    //                        }
    //                        schedPdeDao.SaveSchedulePde(schedPde);
    //                        double AmtToCalc = Convert.ToDouble(lblTotalAss.Text) - Convert.ToDouble(lblOTotAss.Text);
    //                        //SaveCorrectionEntry(schedPde.NumEmpID, intChalId, intYrId, intMth, intDy, AmtToCalc, schedPde.NumID, 3, fltAmtBfr, fltAmtAfr, 2);
    //                    }
    //                    else
    //                    {
    //                        schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
    //                        schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
    //                        schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
    //                        if (chkUnIdent.Checked == true)
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 1;
    //                        }
    //                        else
    //                        {
    //                            schedPde.FlgUnIdentifiedEmp = 0;
    //                        }
    //                        schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
    //                        schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
    //                        schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
    //                        schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
    //                        schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
    //                        schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
    //                        //schedPde.IntChalanId = intChalId;
    //                        schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
    //                        schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
    //                        if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
    //                        {
    //                            schedPde.ChvGOId = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                        }
    //                        if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntFm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
    //                        }
    //                        if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
    //                        {
    //                            schedPde.IntTm = 0;
    //                        }
    //                        else
    //                        {
    //                            schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
    //                        }
    //                        schedPdeDao.UpdateSchedulePde(schedPde);
    //                    }

    //                }
    //                else
    //                {
    //                    schedPde.IntRecNo = Convert.ToInt16(lblRecNoAss.Text);
    //                    schedPde.IntSchMainId = Convert.ToInt32(Session["intSchMainId"]);
    //                    schedPde.IntSchMainId = Convert.ToInt32(lblSchedMainAss.Text);
    //                    if (chkUnIdent.Checked == true)
    //                    {
    //                        schedPde.FlgUnIdentifiedEmp = 1;
    //                    }
    //                    else
    //                    {
    //                        schedPde.FlgUnIdentifiedEmp = 0;
    //                    }
    //                    schedPde.FltSubnAmt = Convert.ToDouble(txtSubnAss.Text);
    //                    schedPde.FltRePaymentAmt = Convert.ToDouble(txtRepAss.Text);
    //                    schedPde.FltArearPay = Convert.ToDouble(txtPayAss.Text);
    //                    schedPde.FltArearPFAmt = Convert.ToDouble(txtPfAss.Text);
    //                    schedPde.FltArearDA = Convert.ToDouble(txtDaAss.Text);
    //                    schedPde.FltTotal = Convert.ToDouble(lblTotalAss.Text);
    //                    //schedPde.IntChalanId = intChalId;
    //                    schedPde.IntChalanId = Convert.ToInt32(Session["numChalanIdEdit"]);
    //                    schedPde.IntSlno = Convert.ToInt16(lblSlNoNew.Text);
    //                    if (ddlGo.SelectedValue == "" || ddlGo.SelectedValue == "0")
    //                    {
    //                        schedPde.ChvGOId = 0;
    //                    }
    //                    else
    //                    {
    //                        schedPde.ChvGOId = Convert.ToInt16(ddlGo.SelectedValue);
    //                    }
    //                    if (ddlFm.SelectedValue == "" || ddlFm.SelectedValue == "0")
    //                    {
    //                        schedPde.IntFm = 0;
    //                    }
    //                    else
    //                    {
    //                        schedPde.IntFm = Convert.ToInt16(ddlFm.SelectedValue);
    //                    }
    //                    if (ddlTm.SelectedValue == "" || ddlTm.SelectedValue == "0")
    //                    {
    //                        schedPde.IntTm = 0;
    //                    }
    //                    else
    //                    {
    //                        schedPde.IntTm = Convert.ToInt16(ddlTm.SelectedValue);
    //                    }
    //                    schedPdeDao.UpdateSchedulePde(schedPde);
    //                }

    //            }
    //            else
    //            {
    //                gblObj.MsgBoxOk("Enter amount!", this);
    //            }
    //        }
    //    }
    //}
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvAOApprov.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            DropDownList ddlReasonAss = (DropDownList)gvRw.FindControl("ddlReason");
            Label lblUnPAss = (Label)gvRw.FindControl("lblUnP");
            Label lblEditModeAss = (Label)gvRw.FindControl("lblEditMode");

            if (chkAppAss.Checked == true)
            {
                ddlReasonAss.Enabled = true;
            }
            else
            {
                ddlReasonAss.Enabled = false;
            }


            if (chkAppAss.Checked == true)
            {
                if (Convert.ToInt16(lblUnPAss.Text) != 1)
                {
                    lblEditModeAss.Text = "1";
                }
                else
                {
                    lblEditModeAss.Text = "0";
                }
            }
            else
            {
                if (Convert.ToInt16(lblUnPAss.Text) != 2)
                {
                    lblEditModeAss.Text = "1";
                }
                else
                {
                    lblEditModeAss.Text = "0";
                }
            }

        }
    }

    //private void UpdateChalan()
    //{
    //    chalPde = new ChalanPDE();
    //    chalPDao = new ChalanPDEDao();

    //    //if (Convert.ToDouble(gdvAOApprov.Rows[0].Cells[5].Text) > 0)
    //    if (Convert.ToDouble(gdvAOApprov.FooterRow.Cells[5].Text) > 0)
    //    {
    //        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
    //        {
    //            GridViewRow gvrow = gdvAOApprov.Rows[i];
    //            Label lblEditModeAss = (Label)gvrow.FindControl("lblEditMode");
    //            Label lblChalIdAss = (Label)gvrow.FindControl("lblChalId");
    //            TextBox txtdateAss = (TextBox)gvrow.FindControl("txtdate");
    //            Label lblYrAss = (Label)gvrow.FindControl("lblYr");
    //            Label lblMonthAss = (Label)gvrow.FindControl("lblMonth");
    //            Label lblDayAss = (Label)gvrow.FindControl("lblDay");

    //            CheckBox chkAppAss = (CheckBox)gvrow.FindControl("chkApp");
    //            DropDownList ddlReasonAss = (DropDownList)gvrow.FindControl("ddlReason");

    //            if (Convert.ToInt16(lblEditModeAss.Text) >= 1)
    //            {
    //                if (Convert.ToDouble(Session["flgPrevYear"]) == 1)      //<08-09
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;

    //                    chalPDao.UpdateChalanPde1(chalPde);
    //                }
    //                else if (Convert.ToDouble(Session["flgPrevYear"]) == 2)     //>08-09 Treas
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;
    //                    if (chkAppAss.Checked == true)
    //                    {
    //                        chalPde.FlgUnposted = 2;
    //                    }
    //                    else
    //                    {
    //                        chalPde.FlgUnposted = 1;
    //                    }
    //                    chalPde.IntUnPostedRsn = Convert.ToInt16(ddlReasonAss.SelectedValue);

    //                    chalPDao.UpdateChalanPde1(chalPde);
    //                    chalPDao.UpdateChalanPde2(chalPde);
    //                }
    //                else if (Convert.ToDouble(Session["flgPrevYear"]) == 4)     //>08-09 AG
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;
    //                    chalPDao.UpdateChalanPde1(chalPde);

    //                    //Code to save ChalanAG

    //                    chalPDao.UpdateChalanAG(chalPde);

    //                }
    //                SaveCorrectionEntryChal(Convert.ToInt32(lblChalIdAss.Text), Convert.ToInt16(lblEditModeAss.Text), Convert.ToInt16(lblYrAss.Text), Convert.ToInt16(lblMonthAss.Text), Convert.ToInt16(lblDayAss.Text));
    //            }
    //            //////////////Updated on 27/01/2015///////////////
    //            else
    //            {
    //                if (Convert.ToDouble(Session["flgPrevYear"]) == 1)
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;

    //                    chalPDao.UpdateChalanPde1(chalPde);
    //                }
    //                else if (Convert.ToDouble(Session["flgPrevYear"]) == 2)
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;
    //                    if (chkAppAss.Checked == true)
    //                    {
    //                        chalPde.FlgUnposted = 2;
    //                    }
    //                    else
    //                    {
    //                        chalPde.FlgUnposted = 1;
    //                    }
    //                    chalPde.IntUnPostedRsn = Convert.ToInt16(ddlReasonAss.SelectedValue);

    //                    chalPDao.UpdateChalanPde1(chalPde);
    //                    chalPDao.UpdateChalanPde2(chalPde);
    //                }
    //                else if (Convert.ToDouble(Session["flgPrevYear"]) == 4)     //>08-09 AG
    //                {
    //                    chalPde.NumChalanId = Convert.ToInt32(lblChalIdAss.Text);
    //                    chalPde.DtChalanDate = txtdateAss.Text.ToString();
    //                    chalPde.IntUserId = Convert.ToInt64(Session["intUserId"]);
    //                    chalPde.IntModeChange = 2;
    //                    chalPDao.UpdateChalanPde1(chalPde);

    //                    //Code to save ChalanAG

    //                    chalPDao.UpdateChalanAG(chalPde);

    //                }
    //            }
    //            //////////////Updated on 27/01/2015///////////////
    //            intChalId = Convert.ToInt32(lblChalIdAss.Text.ToString());
    //            intYrId = Convert.ToInt16(lblYrAss.Text.ToString());
    //        }
    //    }
    //}
    //private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr, int mth, int inyDy)
    //{
    //    gendao = new GeneralDAO();
    //    gblObj = new clsGlobalMethods();
    //    chalPDao = new ChalanPDEDao();
    //    corr = new CorrectionEntry();
    //    corrDao = new CorrectionEntryDao();

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
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBf, double fltAmtAfr, int ChngType)
    //{
    //    gendao = new GeneralDAO();
    //    gblObj = new clsGlobalMethods();
    //    corr = new CorrectionEntry();
    //    corrDao = new CorrectionEntryDao();

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
    //    if (Convert.ToInt16(Session["flgChalanEditFrmTreasOrAg"]) == 1)
    //    {
    //        corr.IntChalanType = 1;
    //    }
    //    else
    //    {
    //        corr.IntChalanType = 2;
    //    }
    //    //  corrDao.CreateCorrEntry(corr);
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
    //        arrupd.Add(1);
    //        corrDao.UpdCorrectionEntryTableType(arrupd);
    //    }
    //}
    //private void SaveCorrectionEntry(int intAccNo, int chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBf, double fltAmtAfr, int ChngType)
    //{
    //    gendao = new GeneralDAO();
    //    gblObj = new clsGlobalMethods();
    //    corr = new CorrectionEntry();
    //    corrDao = new CorrectionEntryDao();

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
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        int intCurRw = 0;
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

        Label lblSlNo = (Label)gdr.FindControl("lblSlNo");
        Label lblSlNoNew = (Label)gdr.FindControl("lblSlNoNew");

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
                gblObj.MsgBoxOk("Doesn't exist!", this);
                txtAccNoAss.Text = "";
                lblNameAss.Text = "";
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
        ///////////////////////////////////
        if (Convert.ToInt16(lblSlNoNew.Text) == 0)
        {
            lblSlNoNew.Text = FillSlNo(intCurRw).ToString();
        }

        ////////////////////////////////////
    }
    private int FillSlNo(int rwNo)
    {
        int rtn = 0;
        schedPdeDao = new SchedulePDEDao();
        DataSet dsSched = new DataSet();
        ArrayList arr = new ArrayList();
        int slno = 0;
        if (rwNo > 0)
        {
            GridViewRow gdvp = gdvAOApprovSched.Rows[rwNo - 1];
            Label lblSlNoNewP = (Label)gdvp.FindControl("lblSlNoNew");


            arr.Add(Convert.ToInt32(Session["numChalanIdEdit"]));
            dsSched = schedPdeDao.FindSlnofrmSchedulePDETR104(arr);
            if (dsSched.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsSched.Tables[0].Rows[0].ItemArray[0]) > 0)
            {
                slno = Convert.ToInt16(dsSched.Tables[0].Rows[0].ItemArray[0]);
            }
            else
            {
                rtn = Convert.ToInt16(lblSlNoNewP.Text) + 1;
            }
            if (Convert.ToInt16(lblSlNoNewP.Text) > slno)
            {
                rtn = Convert.ToInt16(lblSlNoNewP.Text) + 1;
            }
            else
            {
                rtn = slno + 1;
            }
        }
        else
        {
            rtn = 1;
        }
        return rtn;
    }
    //private int FindSlNo(int Slno)
    //{
    //    schedPdeDao = new SchedulePDEDao();

    //    int slno = 1;
    //    DataSet dsSched = new DataSet();
    //    ArrayList arr = new ArrayList();
    //    arr.Add(Convert.ToInt32(Session["numChalanIdEdit"]));
    //    arr.Add(Slno);
    //    dsSched = schedPdeDao.FindSlnofrmSchedulePDETR104(arr);
    //    if (dsSched.Tables[0].Rows.Count > 0)
    //    {
    //        slno = Convert.ToInt16(dsSched.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    return slno;
    //}
    //protected void txtdate_TextChanged(object sender, EventArgs e)
    //{
    //    genDAO = new KPEPFGeneralDAO();
    //    gblObj = new clsGlobalMethods();

    //    intCurRwChal = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
    //    ArrayList ar = new ArrayList();
    //    GridViewRow gvr = gdvAOApprov.Rows[intCurRwChal];
    //    Label lblYrAss = (Label)gvr.FindControl("lblYr");
    //    Label lblMonthAss = (Label)gvr.FindControl("lblMonth");
    //    Label lblDayAss = (Label)gvr.FindControl("lblDay");
    //    Label lblEditModeAss = (Label)gvr.FindControl("lblEditMode");

    //    TextBox txtdateAss = (TextBox)gvr.FindControl("txtdate");
    //    DateTime dtm = new DateTime();
    //    if (gblObj.isValidDate(txtdateAss, this) == true)
    //    {
    //        dtm = Convert.ToDateTime(txtdateAss.Text);

    //        ar.Add(txtdateAss.Text);
    //        if (genDAO.gFunFindYearIdFromDate(ar) != Convert.ToInt16(lblYrAss.Text))
    //        {
    //            gblObj.MsgBoxOk("Invalid date", this);
    //        }
    //        else
    //        {
    //            int monthId = dtm.Month;
    //            if (monthId != Convert.ToInt16(lblMonthAss.Text))
    //            {
    //                gblObj.MsgBoxOk("Invalid date", this);
    //            }
    //            else
    //            {
    //                //gblObj.MsgBoxOk("Valid date", this);
    //            }
    //        }
    //        if (dtm.Day <= 4 && Convert.ToInt16(lblDayAss.Text) > 4)
    //        {
    //            lblEditModeAss.Text = "1";
    //        }
    //        else if (dtm.Day > 4 && Convert.ToInt16(lblDayAss.Text) <= 4)
    //        {
    //            lblEditModeAss.Text = "2";
    //        }
    //        else
    //        {
    //            lblEditModeAss.Text = "0";
    //        }
    //    }
    //    else
    //    {
          
    //        gblObj.MsgBoxOk("Invalid date!", this);
    //        txtdateAss.Text = "";
    //    }
    //}
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
    private void CalcNewTotal(int intCurRwSched,GridView gdv)
    {
        GridViewRow gvr = gdv.Rows[intCurRwSched];
        TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
        TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
        TextBox txtPfAss = (TextBox)gvr.FindControl("txtPf");
        TextBox txtDaAss = (TextBox)gvr.FindControl("txtDa");
        TextBox txtPayAss = (TextBox)gvr.FindControl("txtPay");

        Label lblTotAss = (Label)gvr.FindControl("lblTotal");
        Label lblNewTotAss = (Label)gvr.FindControl("lblNewTot");


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
        lblTotAss.Text = Convert.ToString(Convert.ToDouble(txtSubnAss.Text) + Convert.ToDouble(txtRepAss.Text) + Convert.ToDouble(txtPfAss.Text) + Convert.ToDouble(txtDaAss.Text) + Convert.ToDouble(txtPayAss.Text));
    }


    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["flgPageBack"]) == 1)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/AnnStatement.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/RemittancePDE.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/RemittancePDE01.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 5)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/TransferEntryPDE.aspx";
    //    }
    //    else if (Convert.ToInt16(Session["flgPageBack"]) == 6)
    //    {
    //        btnBack.PostBackUrl = "~/Contents/CardGen.aspx";
    //    }
    //}
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        aoRecorrDAO = new AORecorrectionDAO();
        genDAO = new KPEPFGeneralDAO();
        if (txtCnt.Text.Trim() != "")
        {

            //////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddlGo");
            arDdl.Add("ddlFm");
            arDdl.Add("ddlTm");
            //////Store Ddls in an array//////////

            //////Store Ds to fill Ddls in an array//////////
            //DataSet dsGO = new DataSet();
            //dsGO = genDAO.GetGO();
            ArrayList arDdlDs = new ArrayList();
            DataSet dsGO = new DataSet();
            dsGO = genDAO.GetGO();
            arDdlDs.Add(dsGO);

            DataSet dsFm = new DataSet();
            dsFm = genDAO.GetMonth();
            arDdlDs.Add(dsFm);

            DataSet dsTm = new DataSet();
            dsTm = genDAO.GetMonth();
            arDdlDs.Add(dsTm);
            ////Store Ds to fill Ddls in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store Ds to fill Ddls in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsSched = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToDouble(Session["numChalanIdEdit"]));
            dsSched = aoRecorrDAO.Schedule4RowCnt(ar);
            ////Ds to fill Grid//////////
            gblObj.SetGridRowsWithData(dsSched, Convert.ToInt16(txtCnt.Text), gdvAOApprovSched, arDdl, arCols, arDdlDs);
            FillFooterTotals();



            ////////Store Ddls in an array//////////
            //ArrayList arDdl = new ArrayList();
            //arDdl.Add("ddlGo");
            ////////Store Ddls in an array//////////

            ////////Store Ds to fill Ddls in an array//////////
            ////DataSet dsGO = new DataSet();
            ////dsGO = genDAO.GetGO();
            //ArrayList arDdlDs = new ArrayList();
            //DataSet dsGO = new DataSet();
            //dsGO = genDAO.GetGO();
            //arDdlDs.Add(dsGO);
            //////Store Ds to fill Ddls in an array//////////
            //ArrayList arCols = new ArrayList();
            //SetArrCols(arCols);
            //////Store Ds to fill Ddls in an array//////////

            //////Ds to fill Grid//////////
            //DataSet dsSched = new DataSet();
            //ArrayList ar = new ArrayList();
            //ar.Add(Convert.ToDouble(Session["numChalanIdEdit"]));
            //dsSched = aoRecorrDAO.Schedule4RowCnt(ar);


            //////Ds to fill Grid//////////

            //gblObj.SetGridRowsWithData(dsSched, Convert.ToInt16(txtCnt.Text), gdvAOApprovSched, arDdl, arCols, arDdlDs);
            //FillFooterTotals();
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
        arCols.Add("lblSlNoNew");
    }
        
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        {
            btnBack.PostBackUrl = "~/Contents/AnnStatementLat.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 3)
        {
            btnBack.PostBackUrl = "~/Contents/RemittancePDEPrev.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 4)
        {
            btnBack.PostBackUrl = "~/Contents/RemittancePDE01.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 5)
        {
            btnBack.PostBackUrl = "~/Contents/TransferEntryPDE.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 6)
        {
            btnBack.PostBackUrl = "~/Contents/CardGen.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 7)
        {
            btnBack.PostBackUrl = "~/Contents/DaerPde.aspx";
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblSchedAss = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblSched");
        Label lblTotalAss = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblTotal");
        Label lblNewAccAss = (Label)gdvAOApprovSched.Rows[rowIndex].FindControl("lblNewAcc");

        if (lblSchedAss.Text.ToString() != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt64(lblSchedAss.Text));
            try
            {
                schedPdeDao = new SchedulePDEDao();
                schedPdeDao.UpdScheduleTR104Mode(arrin);
                saveCorrectionEntry(rowIndex, Convert.ToInt64(lblSchedAss.Text),1);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }
            fltAmtBfr = Convert.ToDouble(lblTotalAss.Text);
            fltAmtAfr = 0;
           
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);
        FillGridSched();
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {


    }
    protected void ddlFm_SelectedIndexChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvAOApprovSched.Rows[intCurRwSched];
        DropDownList ddlFm = (DropDownList)gvr.FindControl("ddlFm");
        Label lblFMO = (Label)gvr.FindControl("lblFMO");
        Label lblFMN = (Label)gvr.FindControl("lblFMN");
        lblFMN.Text = ddlFm.SelectedValue.ToString();

        Label lblEditModeS = (Label)gvr.FindControl("lblEditModeS");
        if (Convert.ToInt16(lblFMO.Text) != Convert.ToInt16(lblFMN.Text))
        {
            lblEditModeS.Text = "1";
        }
        else
        {
            lblEditModeS.Text = "0";
        }
        
        
    }
    protected void ddlTm_SelectedIndexChanged(object sender, EventArgs e)
    {
        intCurRwSched = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
        GridViewRow gvr = gdvAOApprovSched.Rows[intCurRwSched];
        DropDownList ddlTm = (DropDownList)gvr.FindControl("ddlTm");
        Label lblTMO = (Label)gvr.FindControl("lblTMO");
        Label lblTMN = (Label)gvr.FindControl("lblTMN");
        lblTMN.Text = ddlTm.SelectedValue.ToString();

        Label lblEditModeS = (Label)gvr.FindControl("lblEditModeS");
        if (Convert.ToInt16(lblTMO.Text) != Convert.ToInt16(lblTMN.Text))
        {
            lblEditModeS.Text = "1";
        }
        else
        {
            lblEditModeS.Text = "0";
        }
        
    }
}
