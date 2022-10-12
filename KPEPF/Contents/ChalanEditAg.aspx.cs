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

public partial class Contents_ChalanEditAg : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblObj;
    ChalanDAO chaldao;
    Chalan chal;
    Schedule sch;
    ScheduleDAO schDao;
    Employee emp;
    EmployeeDAO empD;

    static int intMth = 0;
    static int intDy = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            double dd = Convert.ToDouble(Session["numChalanIdOnline"]);
            btnBack.Text = "Back to Ann. Statement ";
            //if (Convert.ToDouble(Session["NumEmpIdAnnStmnt"]) == 0)
            //{
            //    Response.Redirect("AnnStatement.aspx");
            //}
            FillGrid();
            FillGridSched();
            //SetLbls();
        }
    }
    private void FillLB(GridViewRow gvr, string ddl)
    {
        gblObj = new clsGlobalMethods();
        gendao = new GeneralDAO();
        
        ArrayList ar = new ArrayList();
        DataSet dslb = new DataSet();
        ar.Add(Convert.ToDouble(Session["numChalanIdOnline"]));
        dslb = gendao.GetLBChalwise(ar);

        DropDownList ddlLB = (DropDownList)gvr.FindControl(ddl);
        gblObj.FillCombo(ddlLB, dslb, 1);
    }

    private void FillGridSched()
    {
        chal = new Chalan();
        schDao = new ScheduleDAO();

        DataSet dsSched = new DataSet();
        ArrayList ar = new ArrayList();

        chal.NumChalanId = Convert.ToInt64(Session["numChalanIdEdit"]);
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

        ar.Add(Convert.ToDouble(Session["numChalanIdEdit"]));
        dsChal = chaldao.ChalanRemittanceOnline(ar);
        if (dsChal.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsChal;
            gdvAOApprov.DataBind();

            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];

                Label lblChalIdAss = (Label)gdv.FindControl("lblChalId");
                lblChalIdAss.Text = dsChal.Tables[0].Rows[i].ItemArray[0].ToString();

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

                DropDownList ddlLb = (DropDownList)gdv.FindControl("ddlLb");
                FillLB(gdv,"ddlLb");
                ddlLb.SelectedValue = dsChal.Tables[0].Rows[i].ItemArray[15].ToString();
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
                    lblType.Text = lblType.Text.ToString() + "  _  " + FindTEDet(Convert.ToInt64(Session["numChalanIdEdit"]), Convert.ToInt16(Session["intYrId"]));
                }
            }
            gblObj.SetFooterTotalsTempField(gdvAOApprov, 5, "txtAmt", 1);
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
        dsC = chaldao.FindChalanTEDetAg(arC);
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //btnBack.PostBackUrl = "~/Contents/AnnStatement.aspx";
        if (Convert.ToInt16(Session["flgPageBack"]) == 1)
        {
            btnBack.PostBackUrl = "~/Contents/ChalBillSearch.aspx";
        }
        else if (Convert.ToInt16(Session["flgPageBack"]) == 2)
        {
            btnBack.PostBackUrl = "~/Contents/AnnStatementLat.aspx";
        }
    }
}

