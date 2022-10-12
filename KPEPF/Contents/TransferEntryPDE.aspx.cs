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
public partial class Contents_TransferEntryPDE : System.Web.UI.Page
{
    public int mnthId;
    public int yrId;
    public int RelMnthID;
    int corrType = 0;
    KPEPFGeneralDAO genDAO;
    GeneralDAO gendao;
    clsGlobalMethods gblobj;
    TEDAO teDAO;
    ChalanPDEAG chlAG;
    ChalanPDEAGDAO ChalAGDao;
    ChalanDAO chDao;
    Missing ms;
    MissingDAO msDao;
    balancetrans bl;
    BalancetransDAO blDAO;
    BalanTrPDE blPDE;
    BalanceTransPDEDao blPDEDao;
    Employee emp;
    EmployeeDAO empD;

    SchedulePDEDao schedDao;
    CorrectionEntry cor;
    CorrectionEntryDao cord;
    AnnInt ann;
    AnnIntDAO annD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Convert.ToDouble(Session["numChalanIdEdit"])> 0)
            if (Convert.ToDouble(Session["flgPageBack"]) == 5)
            {
                ViewGrid();
                //ShowCRPlus();
                SetGridDefault();
                ShowWithoutDocs();
                ShowBalanceTransCr();
                SetEnable();
                FillHeadLbls();
                //lblTot.Text = "Credit Plus  " + Session["dblAmtCrPlus"].ToString();
                //lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text));
                SetlnkAnnInt();

            }
            else
            {
                InitialSettings();
            }
            //FillAnnInt();
            lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));

        }
    }
    private void SetlnkAnnInt()
    {
        if (Convert.ToInt16(Session["IntMonthAG"]) == 13 && Convert.ToInt16(Session["flgAppAg"]) == 2)
        {
            lnkAnnInt.Visible = true;
        }
        else
        {
            lnkAnnInt.Visible = false;
        }
    }
    private void SetEnable()
    {
        if (Convert.ToInt16(Session["flgAppAg"]) == 2)
        {
            SetCtrlsEnable();
            //btnOkWithouDocs.Enabled = true;
        }
        else
        {
            SetCtrlsDisable();
        }
    }
    private void SetCtrlsEnable()
    {
        SetWithOutGridEnable();
        SetWithDocsGridEnable();
        SetBTEnable();
        //SetCntTextsEnable();
    }
    private void SetCtrlsDisable()
    {
        SetWithOutGridDisable();
        SetWithDocsGridDisable();
        SetBTDisable();
    }
    private void SetBTEnable()
    {
        txtCntBT.Enabled = true;
        btnOkbal.Enabled = true;
        for (int i = 0; i < gdvBT.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvBT.Rows[i];
            TextBox txtTeNoCPBT = (TextBox)gdvrow.FindControl("txtTeNoCPBT");
            txtTeNoCPBT.ReadOnly = false ;
            txtTeNoCPBT.Enabled = true;

            TextBox txtFrmAcCPBT = (TextBox)gdvrow.FindControl("txtFrmAcCPBT");
            txtFrmAcCPBT.ReadOnly = false ;
            txtFrmAcCPBT.Enabled = true ;

            TextBox txtName = (TextBox)gdvrow.FindControl("txtName");
            txtName.ReadOnly = false ;
            txtName.Enabled = true ;

            TextBox txtToaccCPBT = (TextBox)gdvrow.FindControl("txtToaccCPBT");
            txtToaccCPBT.ReadOnly = false ;
            txtToaccCPBT.Enabled = true ;

            TextBox txttoName = (TextBox)gdvrow.FindControl("txttoName");
            txttoName.ReadOnly = false ;
            txttoName.Enabled = true ;


            TextBox txtAmtCPBT = (TextBox)gdvrow.FindControl("txtAmtCPBT");
            txtAmtCPBT.ReadOnly = false ;
            txtAmtCPBT.Enabled = true ;

            TextBox txtRmkCPBT = (TextBox)gdvrow.FindControl("txtRmkCPBT");
            txtRmkCPBT.ReadOnly = false ;
            txtRmkCPBT.Enabled = true ;

            ImageButton btndeleteBal = (ImageButton)gdvrow.FindControl("btndeleteBal");
            btndeleteBal.Enabled = true;

        }
        btnOkbal.Enabled = true;
    }

    private void SetBTDisable()
    {
        txtCntBT.Enabled = false;
        btnOkbal.Enabled = false;
        for (int i = 0; i < gdvBT.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvBT.Rows[i];
            TextBox txtTeNoCPBT = (TextBox)gdvrow.FindControl("txtTeNoCPBT");
            txtTeNoCPBT.ReadOnly = true;
            txtTeNoCPBT.Enabled = false;

            TextBox txtFrmAcCPBT = (TextBox)gdvrow.FindControl("txtFrmAcCPBT");
            txtFrmAcCPBT.ReadOnly = true;
            txtFrmAcCPBT.Enabled = false;

            TextBox txtName = (TextBox)gdvrow.FindControl("txtName");
            txtName.ReadOnly = true;
            txtName.Enabled = false;

            TextBox txtToaccCPBT = (TextBox)gdvrow.FindControl("txtToaccCPBT");
            txtToaccCPBT.ReadOnly = true;
            txtToaccCPBT.Enabled = false;

            TextBox txttoName = (TextBox)gdvrow.FindControl("txttoName");
            txttoName.ReadOnly = true;
            txttoName.Enabled = false;


            TextBox txtAmtCPBT = (TextBox)gdvrow.FindControl("txtAmtCPBT");
            txtAmtCPBT.ReadOnly = true;
            txtAmtCPBT.Enabled = false;

            TextBox txtRmkCPBT = (TextBox)gdvrow.FindControl("txtRmkCPBT");
            txtRmkCPBT.ReadOnly = true;
            txtRmkCPBT.Enabled = false;

            ImageButton btndeleteBal = (ImageButton)gdvrow.FindControl("btndeleteBal");
            btndeleteBal.Enabled = false;
        }
        btnOkbal.Enabled = false;
    }

    private void SetWithOutGridEnable()
    {
        txtCntWthout.Enabled = true;
        btnOkWithouDocs.Enabled = true;
        for (int i = 0; i < gdvCPWO.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPWO.Rows[i];

            TextBox txtteCPWO = (TextBox)gdvrow.FindControl("txtteCPWO");
            txtteCPWO.ReadOnly = false ;
            txtteCPWO.Enabled = true ;

            TextBox txtChlnCPWO = (TextBox)gdvrow.FindControl("txtChlnCPWO");
            txtChlnCPWO.ReadOnly = false ;
            txtChlnCPWO.Enabled = true ;

            TextBox txtChlnDateCPWO = (TextBox)gdvrow.FindControl("txtChlnDateCPWO");
            txtChlnDateCPWO.ReadOnly = false ;
            txtChlnDateCPWO.Enabled = true ;

            TextBox txtAmtCPWO = (TextBox)gdvrow.FindControl("txtAmtCPWO");
            txtAmtCPWO.ReadOnly = false ;
            txtAmtCPWO.Enabled = true ;

            DropDownList ddlTreasuryCPWO = (DropDownList)gdvrow.FindControl("ddlTreasuryCPWO");
            ddlTreasuryCPWO.Enabled = true ;

            DropDownList ddlLB = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLB.Enabled = true ;

            TextBox txtRemCPWO = (TextBox)gdvrow.FindControl("txtRemCPWO");
            txtRemCPWO.ReadOnly = false ;
            txtRemCPWO.Enabled = true ;

            CheckBox chkCollect = (CheckBox)gdvrow.FindControl("chkCollect");
            chkCollect.Enabled = true ;

            ImageButton btnAddFloorNew = (ImageButton)gdvrow.FindControl("btnAddFloorNew");
            btnAddFloorNew.Enabled = true;

            ImageButton btndelete = (ImageButton)gdvrow.FindControl("btndelete");
            btndelete.Enabled = true;
        }
        btnOkWithouDocs.Enabled = true;
    }

    private void SetWithOutGridDisable()
    {
        txtCntWthout.Enabled = false;
        btnOkWithouDocs.Enabled = false;
        for (int i = 0; i < gdvCPWO.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPWO.Rows[i];

            TextBox txtteCPWO = (TextBox)gdvrow.FindControl("txtteCPWO");
            txtteCPWO.ReadOnly = true;
            txtteCPWO.Enabled = false;

            TextBox txtChlnCPWO = (TextBox)gdvrow.FindControl("txtChlnCPWO");
            txtChlnCPWO.ReadOnly = true;
            txtChlnCPWO.Enabled = false;

            TextBox txtChlnDateCPWO = (TextBox)gdvrow.FindControl("txtChlnDateCPWO");
            txtChlnDateCPWO.ReadOnly = true;
            txtChlnDateCPWO.Enabled = false;

            TextBox txtAmtCPWO = (TextBox)gdvrow.FindControl("txtAmtCPWO");
            txtAmtCPWO.ReadOnly = true;
            txtAmtCPWO.Enabled = false;

            DropDownList ddlTreasuryCPWO = (DropDownList)gdvrow.FindControl("ddlTreasuryCPWO");
            ddlTreasuryCPWO.Enabled = false;

            DropDownList ddlLB = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLB.Enabled = false;

            TextBox txtRemCPWO = (TextBox)gdvrow.FindControl("txtRemCPWO");
            txtRemCPWO.ReadOnly = true;
            txtRemCPWO.Enabled = false;

            CheckBox chkCollect = (CheckBox)gdvrow.FindControl("chkCollect");
            chkCollect.Enabled = false;

            ImageButton btnAddFloorNew = (ImageButton)gdvrow.FindControl("btnAddFloorNew");
            btnAddFloorNew.Enabled = false;

            ImageButton btndelete = (ImageButton)gdvrow.FindControl("btndelete");
            btndelete.Enabled = false;
        }
        btnOkWithouDocs.Enabled = false;
    }

    private void SetWithDocsGridDisable()
    {
        txtCnt.Enabled = false;
        btnwithdocs.Enabled = false;
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = true;
            txtTeCPWAss.Enabled = false;

            TextBox txtchnoAss = (TextBox)gdvrow.FindControl("txtchno");
            txtchnoAss.ReadOnly = true;
            txtchnoAss.Enabled = false;

            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = true;
            txtChlnDtCPWAss.Enabled = false;

            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = true;
            txtChlAmtCPWAss.Enabled = false;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = false;

            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = false;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = false;

            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chkUnpostCPW");
            chkUnpostCPWAss.Enabled = false;
            
            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = false;

            ImageButton btndeleteWth = (ImageButton)gdvrow.FindControl("btndeleteWth");
            btndeleteWth.Enabled = false;
        }
    }
    private void SetWithDocsGridEnable()
    {
        txtCnt.Enabled = true;
        btnwithdocs.Enabled = true;
        for (int i = 0; i < gdvCPW.Rows.Count; i++)
        {
            GridViewRow gdvrow = gdvCPW.Rows[i];
            TextBox txtTeCPWAss = (TextBox)gdvrow.FindControl("txtTeCPW");
            txtTeCPWAss.ReadOnly = false ;
            txtTeCPWAss.Enabled = true;

            TextBox txtChlnDtCPWAss = (TextBox)gdvrow.FindControl("txtChlnDtCPW");
            txtChlnDtCPWAss.ReadOnly = false;
            txtChlnDtCPWAss.Enabled = true;

            TextBox txtChlAmtCPWAss = (TextBox)gdvrow.FindControl("txtChlAmtCPW");
            txtChlAmtCPWAss.ReadOnly = false;
            txtChlAmtCPWAss.Enabled = true;

            DropDownList ddlTreCPWOAss = (DropDownList)gdvrow.FindControl("ddlTreCPWO");
            ddlTreCPWOAss.Enabled = true ;

            DropDownList ddlDistAss = (DropDownList)gdvrow.FindControl("ddlDist");
            ddlDistAss.Enabled = true;

            DropDownList ddlLBAss = (DropDownList)gdvrow.FindControl("ddlLB");
            ddlLBAss.Enabled = true;

            CheckBox chkUnpostCPWAss = (CheckBox)gdvrow.FindControl("chkUnpostCPW");
            chkUnpostCPWAss.Enabled = true;

            DropDownList ddlreasonAss = (DropDownList)gdvrow.FindControl("ddlreason");
            ddlreasonAss.Enabled = true;

            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = false;

            Button Button1ass = (Button)gdvrow.FindControl("Button1");
            Button1ass.Enabled = true;

            ImageButton btndeleteWth = (ImageButton)gdvrow.FindControl("btndeleteWth");
            btndeleteWth.Enabled = true;
            

            //Label txtRelMnthWiseIdWAss = (Label)gdvrow.FindControl("lblRelMnthwseIdWith");           
            //txtRelMnthWiseIdWAss.Enabled = true;

            //Label txtChalanAGIdAss = (Label)gdvrow.FindControl("lblChalanAGIdWith");           
            //txtChalanAGIdAss.Enabled = true;

            //Label RelMnthAss = (Label)gdvrow.FindControl("RelMnth");
            //RelMnthAss.Enabled = true;

            //Label RelYearIdAss = (Label)gdvrow.FindControl("RelYearId");          
            //RelYearIdAss.Enabled = true;

            //Label txtChalIdAss = (Label)gdvrow.FindControl("lblChalIdWith");           
            //txtChalIdAss.Enabled = true;
        }
    }
    private void ViewGrid()
    {
        SetGridDefault();
        SetGridDefaultBT();
        SetGridDefaultWOD();
    }
    private void SetGridDefault()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("intChalanNo");
        ar.Add("numChalanId");
        ar.Add("intGroupId");
        ar.Add("flgPrevYear");
        ar.Add("flgApproval");
        gblobj.SetGridDefault(gdvCPW, ar);
    }
    private void SetGridDefaultBT()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar2 = new ArrayList();
        ar2.Add("SlNo");
        gblobj.SetGridDefault(gdvBT, ar2);
    }
    private void SetGridDefaultWOD()
    {
        gblobj = new clsGlobalMethods();
        ArrayList ar1 = new ArrayList();
        ar1.Add("SlNo");
        ar1.Add("chvTEId");
        ar1.Add("intChalNo");
        ar1.Add("dtmChalDt");
        ar1.Add("fltAmt");
        ar1.Add("chvDetails");
        ar1.Add("intId");
        ar1.Add("intTERelMonthWiseId");
        gblobj.SetGridDefault(gdvCPWO, ar1);
    }
    public void fillGridcombos(GridView gdv)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);
        }
        DataSet dsdist = new DataSet();
        dsdist = teDAO.GetDist();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlDistAss = (DropDownList)grdVwRow.FindControl("ddlDist");
            gblobj.FillCombo(ddlDistAss, dsdist, 1);
        }
        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {

            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);

        }
        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);


        }
        DataSet dsM = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(1);
        dsM = gendao.GetMisClassRsn(arrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlreasonAs = (DropDownList)grdVwRow.FindControl("ddlreason");
            gblobj.FillCombo(ddlreasonAs, dsM, 1);


        }

    }
    public void fillGridcombosBT(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);

        }
    }
    public void fillGridcomboswithoutDocs(GridView gdv)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        DataSet dstreas = new DataSet();
        dstreas = teDAO.GetTreasury();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlTreCPWOAss = (DropDownList)grdVwRow.FindControl("ddlTreasuryCPWO");
            gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);

        }

        DataSet dslb = new DataSet();
        dslb = teDAO.GetLB();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {

            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlLBAss = (DropDownList)grdVwRow.FindControl("ddlLB");
            gblobj.FillCombo(ddlLBAss, dslb, 1);

        }
        DataSet dsstatus = new DataSet();
        dsstatus = teDAO.GetStatus();

        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlStatus = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblobj.FillCombo(ddlStatus, dsstatus, 1);
        }
    }
    //public void fillCombo()
    //{
    //}
    private void InitialSettings()
    {
        Session["flgPageBack"] = 5;
        //lblTot.Text = "Credit Plus";
        ViewGrid();
        SetGridDefault();
        ShowWithoutDocs();
        ShowBalanceTransCr();
        SetEnable();

        FillHeadLbls();
        SetlnkAnnInt();
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

        lblTot.Text = Session["dblAmtCrPlus"].ToString();
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));

        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    public void Savechalan()
    {

    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];

        DropDownList ddlDistAss = (DropDownList)gvr.FindControl("ddlDist");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
        DropDownList ddlTreCPWOAss = (DropDownList)gvr.FindControl("ddlTreCPWO");

        if (Convert.ToInt16(ddlDistAss.SelectedValue) > 0)
        {
            Session["intDist"] = Convert.ToInt16(ddlDistAss.SelectedValue);
        }
        else
        {
            Session["intDist"] = 0;
        }

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intDist"]));
        ar.Add(5);
        DataSet dslb = new DataSet();
        dslb = gendao.GetLB(ar);
        gblobj.FillCombo(ddlLBAss, dslb, 1);

        ArrayList art = new ArrayList();
        art.Add(Convert.ToInt16(Session["intDist"]));
        DataSet dst = new DataSet();
        dst = gendao.GetTreasury(art);
        gblobj.FillCombo(ddlTreCPWOAss, dst, 1);

    }
    private int FindSlNo()
    {
        int slno = 1;
        return slno;
    }
    public void ShowCRPlus()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        chDao = new ChalanDAO();

        ChalAGDao = new ChalanPDEAGDAO();
        DataSet dscrplus = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));

        dscrplus = chDao.FillCrPlusPDE(arr);
        if (dscrplus.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dscrplus.Tables[0].Rows.Count.ToString();
            gdvCPW.DataSource = dscrplus;
            gdvCPW.DataBind();
          
            int Att = 30;//Page Size
            for (int i = 0; i < gdvCPW.Rows.Count; i++)
            {
                int p = gdvCPW.PageIndex * Att + i;
                if (p >= Att)
                {
                    p = p;
                }
                else
                {
                    p = i;
                }
                GridViewRow gdv = gdvCPW.Rows[i];
                TextBox txtTeCPWAss = (TextBox)gdv.FindControl("txtTeCPW");
                txtTeCPWAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[0].ToString();           

                TextBox txtChNoCPWAss = (TextBox)gdv.FindControl("txtchno");          
                txtChNoCPWAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[2].ToString();

                TextBox txtChlnDtCPWAss = (TextBox)gdv.FindControl("txtChlnDtCPW");
                txtChlnDtCPWAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[1].ToString();

                TextBox txtChlAmtCPWAss = (TextBox)gdv.FindControl("txtChlAmtCPW");
                txtChlAmtCPWAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[3].ToString();


                ////Dist/////
                DropDownList ddlDistAss = (DropDownList)gdv.FindControl("ddlDist");
                DataSet dsdist = new DataSet();
                dsdist = teDAO.GetDist();
                gblobj.FillCombo(ddlDistAss, dsdist, 1);
                ddlDistAss.SelectedValue = dscrplus.Tables[0].Rows[p].ItemArray[16].ToString();
                ////Dist/////

                ////DT/////
                DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
                ArrayList arDist = new ArrayList();
                DataSet dstreas = new DataSet();
                arDist.Add(Convert.ToInt16(ddlDistAss.SelectedValue));
                dstreas = gendao.GetTreasury(arDist);
                gblobj.FillCombo(ddlTreCPWOAss, dstreas, 1);
                ddlTreCPWOAss.SelectedValue = dscrplus.Tables[0].Rows[p].ItemArray[4].ToString();

                ////DT/////

                ////Lb/////
                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                DataSet dslb = new DataSet();
                dslb = gendao.GetLBGp(arDist);
                gblobj.FillCombo(ddlLBAss, dslb, 1);
                ddlLBAss.SelectedValue = dscrplus.Tables[0].Rows[p].ItemArray[14].ToString();
                ////Lb/////

                ////Reason/////
                DropDownList ddlreasonAss = (DropDownList)gdv.FindControl("ddlreason");
                DataSet dsM = new DataSet();
                ArrayList arrIn = new ArrayList();
                arrIn.Add(1);
                dsM = gendao.GetMisClassRsn(arrIn);
                gblobj.FillCombo(ddlreasonAss, dsM, 1);
                ddlreasonAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[9].ToString();
                ////Reason/////       

                CheckBox chkUnpostCPW = (CheckBox)gdv.FindControl("chkUnpostCPW");
                if (Convert.ToInt32(dscrplus.Tables[0].Rows[p].ItemArray[8]) == 1)
                {
                    chkUnpostCPW.Checked = false;
                    ddlreasonAss.Enabled = false;
                }
                else
                {
                    chkUnpostCPW.Checked = true;
                    ddlreasonAss.SelectedValue = dscrplus.Tables[0].Rows[i].ItemArray[9].ToString();
                    ddlreasonAss.Enabled = true;
                }
                     
                Label txtRelMnthWiseIdWAss = (Label)gdv.FindControl("lblRelMnthwseIdWith");
                txtRelMnthWiseIdWAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[10].ToString();

                Label txtChalanAGIdAss = (Label)gdv.FindControl("lblChalanAGIdWith");
                txtChalanAGIdAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[6].ToString();

                DropDownList ddlStatus = (DropDownList)gdv.FindControl("ddlStatus");
                ddlStatus.SelectedValue = dscrplus.Tables[0].Rows[p].ItemArray[5].ToString();

                Label lblGrpId = (Label)gdv.FindControl("lblGrpId");
                lblGrpId.Text = dscrplus.Tables[0].Rows[p].ItemArray[23].ToString();

                Label lblDy = (Label)gdv.FindControl("lblDy");
                lblDy.Text = Convert.ToDateTime(dscrplus.Tables[0].Rows[p].ItemArray[1]).Day.ToString();

                if (Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[8]) == 2 && Convert.ToInt16(dscrplus.Tables[0].Rows[i].ItemArray[9]) == 8)
                {
                    gdv.Cells[11].Enabled = false;
                }
                Label lblChalIdWithAss = (Label)gdv.FindControl("lblChalIdWith");
                lblChalIdWithAss.Text = dscrplus.Tables[0].Rows[p].ItemArray[22].ToString();

                Label oldYear = (Label)gdv.FindControl("lblYearId");
                Label oldMnth = (Label)gdv.FindControl("lblMnth");
                //TextBox oldDay = (TextBox)gdv.FindControl("RelDay");
                Label oldDay = (Label)gdv.FindControl("lblDay");
                oldYear.Text = dscrplus.Tables[0].Rows[p].ItemArray[26].ToString();
                oldMnth.Text = dscrplus.Tables[0].Rows[p].ItemArray[24].ToString();
                oldDay.Text = dscrplus.Tables[0].Rows[p].ItemArray[25].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
            if (Convert.ToDouble(gdvCPW.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWCP.Text = gdvCPW.FooterRow.Cells[4].Text.ToString();
                //ArrayList ar = new ArrayList();
                DataSet dsS = new DataSet();
                //ar.Add(Convert.ToInt16(Session["IntYearAG"]));
                //ar.Add(Convert.ToInt16(Session["IntMonthAG"]));
                dsS = ChalAGDao.GetScheduleTotal(arr);
                if (dsS.Tables[0].Rows.Count > 0)
                {
                    lblAmtSch.Text = dsS.Tables[0].Rows[0].ItemArray[2].ToString();
                }
            }
            else
            {
                lblAmtWCP.Text = "0";
            }
        }
        else
        {
            lblAmtWCP.Text = "0";
            fillGridcombos(gdvCPW);
        }
        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    public void fillLB()
    {

    }
    protected void ddlLB_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnwithdocs_Click(object sender, EventArgs e)
    {
        SaveWithDocs();
        //ShowCRPlus();
        lblTot.Text = Session["dblAmtCrPlus"].ToString();
        lblAmtWCP.Text = Convert.ToString(gdvCPW.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));

        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        chkShow.Checked = true;
        //txtCnt.Enabled = false;
        //txtCnt.Text = "0";
    }
    private Boolean lFunEditable(Int32 chId,int trid,int lbid,int chno,string chdt,double amt,string teno,CheckBox chk)
    {
        ChalAGDao = new ChalanPDEAGDAO();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(chId);
        ar.Add(trid);
        ar.Add(lbid);
        ar.Add(chno);
        ar.Add(chdt);
        ar.Add(amt);
        ar.Add(teno);
        if (chk.Checked == true)
        {
            ar.Add(2);
        }
        else
        {
            ar.Add(1);
        }
        ds = ChalAGDao.getEditable(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public void SaveWithDocs()
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();
        int cnt = 0;
        if (Convert.ToDouble(gdvCPW.FooterRow.Cells[4].Text) > 0)
        {
            for (int i = 0; i < gdvCPW.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvCPW.Rows[i];
                TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
                Label RelMnthAss = (Label)gdvrw.FindControl("lblMnth");
                Label RelYearIdAss = (Label)gdvrw.FindControl("lblYearId");
                TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
                DropDownList ddlTreCPWOAss = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
                DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatus");
                Label txtRelMnthWiseIdWAss = (Label)gdvrw.FindControl("lblRelMnthwseIdWith");
                DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
                TextBox txtTeCPWAss = (TextBox)gdvrw.FindControl("txtTeCPW");
                Label txtRelMnthWise = (Label)gdvrw.FindControl("lblRelMnthwseIdWith");
                Label lblChalanAGIdWithAss = (Label)gdvrw.FindControl("lblChalanAGIdWith");
                TextBox txtChno = (TextBox)gdvrw.FindControl("txtchno");
                CheckBox chkUnpostCPW = (CheckBox)gdvrw.FindControl("chkUnpostCPW");
                if (MandatoryFldsWithDocs(i) == true)
                {
                    if (lFunEditable(Convert.ToInt32(lblChalanAGIdWithAss.Text), Convert.ToInt16(ddlTreCPWOAss.Text), Convert.ToInt16(ddlLBAss.Text), Convert.ToInt32(txtChno.Text), txtChlnDtCPWAss.Text.ToString(), Convert.ToDouble(txtChlAmtCPWAss.Text), txtTeCPWAss.Text.ToString(), chkUnpostCPW) == false)
                    {
                        DataSet ds = new DataSet();
                        ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
                        
                        if (txtChlnDtCPWAss.Text == "")
                        {
                            ms.DtmChalanBilllDt = "";
                        }
                        else
                        {
                            ms.DtmChalanBilllDt = txtChlnDtCPWAss.Text.ToString();
                            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
                            mnthId = billDate.Month;

                            ArrayList ardt = new ArrayList();
                            ardt.Add(txtChlnDtCPWAss.Text.ToString());
                            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
                            //RelMnthAss.Text = mnthId.ToString();
                            ms.IntRelMonthId = mnthId;
                            //RelYearIdAss.Text = yrId.ToString();
                            ms.IntRelYearId = yrId;
                        }
                        
                        if (txtChlAmtCPWAss.Text == "")
                        {
                            ms.FltAmtPDE = 0;
                        }
                        else
                        {
                            ms.FltAmtPDE = Convert.ToDecimal(txtChlAmtCPWAss.Text);
                        }
                        ms.IntTrnType = 1;
                        
                        if (ddlTreCPWOAss.SelectedIndex > 0)
                        {
                            ms.IntTreaId = Convert.ToInt32(ddlTreCPWOAss.SelectedValue);
                        }
                        else
                        {
                            ms.IntTreaId = 0;
                        }
                        

                        if (ddlStatusAss.SelectedIndex > 0)
                        {
                            ms.IntModeChg = Convert.ToInt32(ddlStatusAss.SelectedValue);
                        }
                        else
                        {
                            ms.IntModeChg = 2;
                        }
                        
                        if (txtRelMnthWiseIdWAss.Text == "")
                        {
                            ms.IntRelMonthWiseId = 0;
                        }
                        else
                        {
                            ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdWAss.Text);
                        }
                        
                        if (ddlLBAss.SelectedIndex > 0)
                        {
                            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
                        }
                        else
                        {
                            ms.lBId = 0;
                        }
                        
                        if (txtTeCPWAss.Text == "")
                        {
                            ms.ChvTEIdPDE = "";
                        }
                        else
                        {
                            ms.ChvTEIdPDE = txtTeCPWAss.Text.ToString();
                        }
                        ds = msDao.TERelMonthWiseUpd(ms);
                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

                            
                            txtRelMnthWise.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                            RelMnthID = ms.IntRelMonthWiseId;
                        }
                        SaveChalanAG(i);
                    }
                }
                else
                {
                    cnt = cnt + 1;
                }
            }
        }
        if (cnt > 0)
        {
            gblobj.MsgBoxOk("Enter all details!", this);
        }
        else
        {
            gblobj.MsgBoxOk("Saved successfully", this);
            ShowCRPlus();
        }
    }
    private void SaveChalanAGCollect(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        chlAG = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();
        GridViewRow gvr = gdvCPWO.Rows[j];

        chlAG.IntChalanAGID = 0;
        chlAG.IntTERelMonthWiseID = RelMnthID;
        DropDownList ddlTreasuryCPWOAss = (DropDownList)gvr.FindControl("ddlTreasuryCPWO");
        if (ddlTreasuryCPWOAss.SelectedIndex > 0)
        {
            chlAG.IntTreasID = Convert.ToInt32(ddlTreasuryCPWOAss.SelectedValue);
        }
        else
        {
            chlAG.IntTreasID = 0;
        }
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            chlAG.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            chlAG.IntLBID = 0;
        }
        TextBox txtChlnCPWOAss = (TextBox)gvr.FindControl("txtChlnCPWO");
        chlAG.IntChalanNo = Convert.ToInt16(txtChlnCPWOAss.Text);

        TextBox txtChlnDateCPWOAss = (TextBox)gvr.FindControl("txtChlnDateCPWO");
        if (txtChlnDateCPWOAss.Text == "")
        {
            chlAG.DtmChalanDt = "";
        }
        else
        {
            chlAG.DtmChalanDt = txtChlnDateCPWOAss.Text.ToString();
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateCPWOAss.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
            //TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            //RelYearIdAss.Text = yrId.ToString();
            chlAG.IntYearID = yrId;
        }
        TextBox txtAmtCPWOAss = (TextBox)gvr.FindControl("txtAmtCPWO");
        if (txtAmtCPWOAss.Text == "")
        {
            chlAG.FltChalanAmt = 0;
        }
        else
        {
            chlAG.FltChalanAmt = Convert.ToDecimal(txtAmtCPWOAss.Text);
        }
        chlAG.IntModeOfChgID = 2;
        chlAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        TextBox txtteCPWOAss = (TextBox)gvr.FindControl("txtteCPWO");
        if (txtteCPWOAss.Text == "")
        {
            chlAG.ChvTENo = "";
        }
        else
        {
            chlAG.ChvTENo = txtteCPWOAss.Text.ToString();
        }
        CheckBox chkUnpostCPW = (CheckBox)gvr.FindControl("chkUnpostCPW");
        chlAG.FlgUnPosted = 1;
        chlAG.IntReasonID = 0;
        chlAG.IntMissingID = 0;
        DataSet ds = new DataSet();
        ds = ChalAGDao.CreateChalanAG(chlAG);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Session["intChalanAGId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        //gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void SaveChalanTrn(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        chlAG = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();
        GridViewRow gdvrw = gdvCPWO.Rows[j];
        chlAG.ChalanId = 0;
        DropDownList ddlTreasuryCPWO = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
        Label lblDy = (Label)gdvrw.FindControl("lblDy");
        if (ddlTreasuryCPWO.SelectedIndex > 0)
        {
            chlAG.IntTreasID = Convert.ToInt32(ddlTreasuryCPWO.SelectedValue);
        }
        else
        {
            chlAG.IntTreasID = 0;
        }
        TextBox txtChlnCPWO = (TextBox)gdvrw.FindControl("txtChlnCPWO");
        chlAG.IntChalanNo = Convert.ToInt16(txtChlnCPWO.Text);
        TextBox txtChlnDateCPWO = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
        if (txtChlnDateCPWO.Text == "")
        {
            chlAG.DtmChalanDt = "";
        }
        else
        {
            chlAG.DtmChalanDt = txtChlnDateCPWO.Text.ToString();

            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateCPWO.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);
            chlAG.IntYearID = yrId;
        }
        TextBox txtAmtCPWO = (TextBox)gdvrw.FindControl("txtAmtCPWO");
        if (txtAmtCPWO.Text == "")
        {
            chlAG.FltChalanAmt = 0;
        }
        else
        {
            chlAG.FltChalanAmt = Convert.ToDecimal(txtAmtCPWO.Text);
        }
        chlAG.IntModeOfChgID = 2;
        chlAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        chlAG.IntChalanAGID = Convert.ToInt32(Session["intChalanAGId"]); 
        DropDownList ddlLB = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLB.SelectedIndex > 0)
        {
            chlAG.IntLBID = Convert.ToInt32(ddlLB.SelectedValue);
        }
        else
        {
            chlAG.IntLBID = 0;
        }
        DataSet dschl = new DataSet();

        dschl = ChalAGDao.SaveChalandetailsAG(chlAG);

    }
    private void SaveCorrectionEntryChal(int chalId, int intEditMode, int yr1, int mth1, int inyDy1, int yr2, int mth2, int inyDy2)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        schedDao = new SchedulePDEDao();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        int cntEmp = 0;
        ArrayList ar = new ArrayList();
        DataSet dsChal = new DataSet();
        ar.Add(chalId);
        ar.Add(1);
        dsChal = schedDao.GetSchedDet4CorrEntryAg(ar);
        cntEmp = dsChal.Tables[0].Rows.Count;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        for (int i = 0; i <= cntEmp - 1; i++)
        {
            int accNo = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[0]);
            double amt = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);
            //double dblCalcAmt = gblobj.CalculateAmtToCalc(yr, amt);
            double dblCalcAmt = gblobj.CalculateAmtToCalc(yr2, amt);
            //double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpd(yr, Convert.ToInt16(Session["intCCYearId"]), mth, inyDy, amt, intEditMode);
            double dblAmtAdjusted = gblobj.CalculateAdjAmtDtUpdLat(yr1, yr2, Convert.ToInt16(Session["intCCYearId"]), mth1, mth2, inyDy1,inyDy2, amt, intEditMode);
            cor.IntAccNo = accNo;
            cor.IntYearID = yr2;
            cor.IntMonthID = mth2;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltAmountBefore = Convert.ToDouble(dsChal.Tables[0].Rows[i].ItemArray[1]);

            cor.FltAmountAfter = Math.Round(dblCalcAmt);
            cor.FltCalcAmount = dblAmtAdjusted;

            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = chalId;
            cor.IntSchedId = Convert.ToInt32(dsChal.Tables[0].Rows[i].ItemArray[2]);
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = 1; //Edit Chal Date
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }

        //if intEditMode == 1 then Add interest of 1 month and if intEditMode = 2 then subtract interest of 1 month//
    }
    private void SaveChalanAG(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        chlAG = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();
        GridViewRow gdvrw = gdvCPW.Rows[j];
        //Label lblSchMnId = (Label)gdvrw.FindControl("lblSchMnId");
        //Label lblGrpId = (Label)gdvrw.FindControl("lblGrpId");
        Label lblChalanAGIdWithAss = (Label)gdvrw.FindControl("lblChalanAGIdWith");
        DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        TextBox txtChno = (TextBox)gdvrw.FindControl("txtchno");
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        Label RelYearIdAss = (Label)gdvrw.FindControl("lblYearId");
        TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
        DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatus");
        TextBox txtTeCPWAss = (TextBox)gdvrw.FindControl("txtTeCPW");
        CheckBox chkUnpostCPW = (CheckBox)gdvrw.FindControl("chkUnpostCPW");
        DropDownList ddlreasonAss = (DropDownList)gdvrw.FindControl("ddlreason");
        Label lblChalanAGIdWithAss1 = (Label)gdvrw.FindControl("lblChalanAGIdWith");
        if (lblChalanAGIdWithAss.Text == "")
        {
            chlAG.IntChalanAGID = 0;
        }
        else
        {
            chlAG.IntChalanAGID = Convert.ToInt32(lblChalanAGIdWithAss.Text);
        }
        chlAG.IntTERelMonthWiseID = RelMnthID;
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntTreasID = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
        }
        else
        {
            chlAG.IntTreasID = 0;
        }
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            chlAG.IntLBID = 0;
        }
        if (txtChno.Text == "")
        {
            chlAG.IntChalanNo = 0;
        }
        else
        {
            chlAG.IntChalanNo = Convert.ToInt32(txtChno.Text);
        }
        if (txtChlnDtCPWAss.Text == "")
        {
            chlAG.DtmChalanDt = "";
        }
        else
        {
            chlAG.DtmChalanDt = txtChlnDtCPWAss.Text.ToString();
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDtCPWAss.Text.ToString());
            yrId = genDAO.gFunFindPDEYearIdFromDate(ardt);

            //RelYearIdAss.Text = yrId.ToString();
            chlAG.IntYearID = yrId;
        }
        if (txtChlAmtCPWAss.Text == "")
        {
            chlAG.FltChalanAmt = 0;
        }
        else
        {
            chlAG.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
        }
        if (ddlStatusAss.SelectedIndex > 0)
        {
            chlAG.IntModeOfChgID = Convert.ToInt32(ddlStatusAss.SelectedValue);
        }
        else
        {
            chlAG.IntModeOfChgID = 2;
        }
        chlAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        if (txtTeCPWAss.Text == "")
        {
            chlAG.ChvTENo = "";
        }
        else
        {
            chlAG.ChvTENo = txtTeCPWAss.Text.ToString();
        }
        if (chkUnpostCPW.Checked == true)
        {
            chlAG.FlgUnPosted = 2;
        }
        else
        {
            chlAG.FlgUnPosted = 1;
        }
        if (ddlreasonAss.SelectedIndex > 0)
        {
            chlAG.IntReasonID = Convert.ToInt32(ddlreasonAss.SelectedValue);
        }
        else
        {
            chlAG.IntReasonID = 0;
        }
        chlAG.IntMissingID = 0;
        chlAG.IntMissingID = 1;
        DataSet ds = new DataSet();
        ds = ChalAGDao.CreateChalanAG(chlAG);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblChalanAGIdWithAss1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            SaveChalan(j, Convert.ToInt32(lblChalanAGIdWithAss.Text));
            //SaveScheduleMain(Convert.ToInt32(lblSchMnId.Text), chlAG.IntLBID, Convert.ToInt32(Session["intGroupId"]), chlAG.FltChalanAmt);
        }
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void SaveChalan(int j, int intchalaAGId)
    {
        genDAO = new KPEPFGeneralDAO();
        chlAG = new ChalanPDEAG();
        ChalAGDao = new ChalanPDEAGDAO();
        GridViewRow gdvrw = gdvCPW.Rows[j];
        Label lblChalIdWithAss = (Label)gdvrw.FindControl("lblChalIdWith");
        TextBox txtchno = (TextBox)gdvrw.FindControl("txtchno");
        Label lblEditId = (Label)gdvrw.FindControl("lblEditId");
        //Label lblDy = (Label)gdvrw.FindControl("lblDy");
        ArrayList ardt = new ArrayList();
        if (lblChalIdWithAss.Text == "")
        {
            chlAG.ChalanId = 0;
        }
        else
        {
            chlAG.ChalanId = Convert.ToInt32(lblChalIdWithAss.Text);
        }
        DropDownList ddlTreCPWOass = (DropDownList)gdvrw.FindControl("ddlTreCPWO");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntTreasID = Convert.ToInt32(ddlTreCPWOass.SelectedValue);
        }
        else
        {
            chlAG.IntTreasID = 0;
        }
        chlAG.IntChalanNo = Convert.ToInt32(txtchno.Text);
        TextBox txtChlnDtCPWAss = (TextBox)gdvrw.FindControl("txtChlnDtCPW");
        if (txtChlnDtCPWAss.Text == "")
        {
            chlAG.DtmChalanDt = "";
        }
        else
        {
            chlAG.DtmChalanDt = txtChlnDtCPWAss.Text.ToString();          
            ardt.Add(txtChlnDtCPWAss.Text.ToString());
            chlAG.IntYearID = genDAO.gFunFindPDEYearIdFromDate(ardt);
        }
        TextBox txtChlAmtCPWAss = (TextBox)gdvrw.FindControl("txtChlAmtCPW");
        if (txtChlAmtCPWAss.Text == "")
        {
            chlAG.FltChalanAmt = 0;
        }
        else
        {
            chlAG.FltChalanAmt = Convert.ToDecimal(txtChlAmtCPWAss.Text);
        }
        chlAG.IntModeOfChgID = 2;
        chlAG.IntUserId = Convert.ToInt32(Session["intUserId"]);
        chlAG.IntChalanAGID = intchalaAGId;
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlTreCPWOass.SelectedIndex > 0)
        {
            chlAG.IntLBID = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            chlAG.IntLBID = 0;
        }
        DataSet dschl = new DataSet();
        dschl = ChalAGDao.SaveChalandetailsAG(chlAG);

        ////////////// Correction  ////////////////
        if (Convert.ToInt16(lblEditId.Text) > 0)
        {
            Label oldYear = (Label)gdvrw.FindControl("lblYearId");
            Label oldMnth = (Label)gdvrw.FindControl("lblMnth");
            //TextBox oldDay = (TextBox)gdvrw.FindControl("RelDay");
            Label oldDay = (Label)gdvrw.FindControl("lblDay");

            int yr1 = Convert.ToInt16(oldYear.Text);
            int mth1 = Convert.ToInt16(oldMnth.Text);
            int intDy1 = Convert.ToInt16(oldDay.Text);

            int yr2 = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
            int mth2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Month;
            int intDy2 = Convert.ToDateTime(txtChlnDtCPWAss.Text).Day;

            SaveCorrectionEntryChal(Convert.ToInt32(lblChalIdWithAss.Text), Convert.ToInt16(lblEditId.Text), yr1, mth1, intDy1, yr2, mth2, intDy2);
        }
        ////////////// Correction  ////////////////
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ViewState["Withdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withdoc"];
            int count = gdvCPW.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtTeCPW");
            arrIN.Add("txtChNoCPW");
            arrIN.Add("txtChlnDtCPW");
            arrIN.Add("txtChlAmtCPW");
            arrIN.Add("ddlTreCPWO");
            arrIN.Add("ddlDist");
            arrIN.Add("ddlLB");
            arrIN.Add("chkUnpostCPW");
            arrIN.Add("ddlStusCPW");
            arrIN.Add("Button1");
            dt = gblobj.AddNewRowToGrid(dt, gdvCPW, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvCPW.Rows[count].FindControl("ddlTreCPWO");
            DropDownList drpnewDist = (DropDownList)gdvCPW.Rows[count].FindControl("ddlDist");
            DropDownList drpnewLB = (DropDownList)gdvCPW.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            //}
            fillGridcombos(gdvCPW);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvCPW.Rows[i].FindControl("ddlTreCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();
                DropDownList drpDist = (DropDownList)gdvCPW.Rows[i].FindControl("ddlDist");
                drpDist.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
                DropDownList drpLB = (DropDownList)gdvCPW.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[7].ToString();
            }
        }
    }
    protected void gdvCPW_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBckCP_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGstatementsPDE.aspx");
    }
    protected void btnClsCP_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");
    }
    protected void btnOkWithouDocs_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        int cnt = 0;
        if (Convert.ToDouble(gdvCPWO.FooterRow.Cells[4].Text) > 0)
        {
            for (int i = 0; i < gdvCPWO.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvCPWO.Rows[i];
                CheckBox chkCollect = (CheckBox)gdvrw.FindControl("chkCollect");
                if (chkCollect.Checked == true)
                {
                    if (MandatoryFlds(i) == true)
                    {
                        UpdateMissing(i, 2);
                        SaveChalanAGCollect(i);     // AP_ChalanAG
                        SaveChalanTrn(i);           // TB_ChalanDetails_TRN
                        gblobj.MsgBoxOk("Updated!", this);
                    }
                    else
                    {
                        gblobj.MsgBoxOk("Enter all details!", this);
                    }
                }
                else
                {
                    UpdateMissing(i, 1);
                }
            }
        }
        lblTot.Text = Session["dblAmtCrPlus"].ToString();
        lblAmtWOCP.Text = Convert.ToString(gdvCPWO.FooterRow.Cells[4].Text);
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));

        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
        ShowWithoutDocs();
        ShowCRPlus();
    }
    private Boolean MandatoryFldsWithDocs(int i)
    {
        Boolean flg;
        GridViewRow gdv = gdvCPW.Rows[i];
        TextBox txtChNoCPWAss = (TextBox)gdv.FindControl("txtchno");
        TextBox txtChlnDtCPWAss = (TextBox)gdv.FindControl("txtChlnDtCPW");
        TextBox txtChlAmtCPWAss = (TextBox)gdv.FindControl("txtChlAmtCPW");
        DropDownList ddlTreCPWOAss = (DropDownList)gdv.FindControl("ddlTreCPWO");
        DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
        TextBox txtTeCPW = (TextBox)gdv.FindControl("txtTeCPW");


        //if (txtChlnDtCPWAss.Text == null || txtChlnDtCPWAss.Text == "" || Convert.ToInt32(txtChNoCPWAss.Text) >= 9999)
        if (txtChlnDtCPWAss.Text == null || txtChlnDtCPWAss.Text == "" || txtChNoCPWAss.Text == null || txtChNoCPWAss.Text == "" || txtTeCPW.Text == null || txtTeCPW.Text == "")
        {
            flg = false;
        }
        else if (txtChlAmtCPWAss.Text == null || txtChlAmtCPWAss.Text == "")
        {
            flg = false;
        }
        else if (Convert.ToInt32(ddlTreCPWOAss.SelectedValue) == 0)
        {
            flg = false;
        }       
        else if (Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    public void UpdateMissing(int i, int flgMissingPDE)
    {
        genDAO = new KPEPFGeneralDAO();
        ms = new Missing();
        msDao = new MissingDAO();

        GridViewRow gdvrw = gdvCPWO.Rows[i];
        DataSet ds = new DataSet();
        ms.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
        TextBox txtChlnDateCPWOass = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
        if (txtChlnDateCPWOass.Text.ToString() == "" || txtChlnDateCPWOass.Text == null || txtChlnDateCPWOass.Text == "0")
        {
            ms.DtmChalanBilllDt = "";
        }
        else
        {
            ms.DtmChalanBilllDt = txtChlnDateCPWOass.Text.ToString();
            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDt.ToString());
            mnthId = billDate.Month;
            ms.IntRelMonthId = mnthId;
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateCPWOass.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);
            ms.IntRelYearId = yrId;
        }
        TextBox txtAmtCPWOAss = (TextBox)gdvrw.FindControl("txtAmtCPWO");
        if (txtAmtCPWOAss.Text == "")
        {
            ms.FltAmtPDE = 0;
        }
        else
        {
            ms.FltAmtPDE = Convert.ToDecimal(txtAmtCPWOAss.Text);
        }
        ms.IntTrnType = 1;
        DropDownList ddlTreasuryCPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
        if (ddlTreasuryCPWOAss.SelectedIndex > 0)
        {
            ms.IntTreaId = Convert.ToInt32(ddlTreasuryCPWOAss.SelectedValue);
        }
        else
        {
            ms.IntTreaId = 0;
        }
        ms.IntModeChg = 2;
        Label txtRelMnthWiseIdAss = (Label)gdvrw.FindControl("lblRelMnthwseId");
        if (txtRelMnthWiseIdAss.Text == "")
        {
            ms.IntRelMonthWiseId = 0;
        }
        else
        {
            ms.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthWiseIdAss.Text);
        }
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.lBId = 0;
        }
        TextBox txtteCPWOAss = (TextBox)gdvrw.FindControl("txtteCPWO");
        if (txtteCPWOAss.Text == "")
        {
            ms.ChvTEIdPDE = "";
        }
        else
        {
            ms.ChvTEIdPDE = txtteCPWOAss.Text.ToString();
        }
        ds = msDao.TERelMonthWiseUpd(ms);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            ms.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            Label txtRelMnthWiseIdAss1 = (Label)gdvrw.FindControl("lblRelMnthwseId");
            txtRelMnthWiseIdAss1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            RelMnthID = ms.IntRelMonthWiseId;
        }
        UpdTEPlusMissing(i, flgMissingPDE);
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void UpdTEPlusMissing(int j, int flgMissingPDE)
    {
        genDAO = new KPEPFGeneralDAO();
        ms = new Missing();
        msDao = new MissingDAO();

        GridViewRow gdvrw = gdvCPWO.Rows[j];
        Label lblintIdWthtAss = (Label)gdvrw.FindControl("lblintIdWtht");
        if (lblintIdWthtAss.Text == "")
        {
            ms.IntId = 0;
        }
        else
        {
            ms.IntId = Convert.ToInt32(lblintIdWthtAss.Text);
        }

        TextBox txtteCPWOAss = (TextBox)gdvrw.FindControl("txtteCPWO");
        if (txtteCPWOAss.Text == "")
        {
            ms.ChvTEIdPDE = "";
        }
        else
        {
            ms.ChvTEIdPDE = txtteCPWOAss.Text.ToString();
        }
        TextBox txtAmtCPWOAss = (TextBox)gdvrw.FindControl("txtAmtCPWO");
        if (txtAmtCPWOAss.Text == "")
        {
            ms.FltAmtPDE = 0;
        }
        else
        {
            ms.FltAmtPDE = Convert.ToDecimal(txtAmtCPWOAss.Text);
        }

        TextBox txtRemCPWOAss = (TextBox)gdvrw.FindControl("txtRemCPWO");
        if (txtRemCPWOAss.Text == "")
        {
            ms.ChvRemarksPDE = "";
        }
        else
        {

            ms.ChvRemarksPDE = txtRemCPWOAss.Text.ToString();
        }
        ms.IntRelMonthWiseId = RelMnthID;
        ms.IntTrnType = 1;
        ms.FlgMissingPDE = flgMissingPDE;
        TextBox txtChlnCPWOAss = (TextBox)gdvrw.FindControl("txtChlnCPWO");
        if (txtChlnCPWOAss.Text == "")
        {
            ms.IntChalNo  = 0;
        }
        else
        {
            ms.IntChalNo =Convert.ToInt32(txtChlnCPWOAss.Text);
        }
        TextBox txtChlnDateCPWOass = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
        if (txtChlnDateCPWOass.Text == "")
        {
            ms.DtmChalanBilllDtPDE = "";
        }
        else
        {
            ms.DtmChalanBilllDtPDE = txtChlnDateCPWOass.Text.ToString();
            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDtPDE.ToString());
            mnthId = billDate.Month;
            ms.IntRelMonthId = mnthId;
            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateCPWOass.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);
            ms.IntRelYearId = yrId;
        }
        DropDownList ddlTreasuryCPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
        if (ddlTreasuryCPWOAss.SelectedIndex > 0)
        {
            ms.IntTreaId = Convert.ToInt32(ddlTreasuryCPWOAss.SelectedValue);
        }
        else
        {
            ms.IntTreaId = 0;
        }
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.lBId = 0;
        }
        ms.IntRelMonthId = yrId;
        ms.IntRelYearId = mnthId;
        DataSet ds = new DataSet();
        ds = msDao.CreateTEPlusMissingPDE(ms);
    }

    private void SaveTEMiss(int j)
    {
        genDAO = new KPEPFGeneralDAO();
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        msDao = new MissingDAO();

        GridViewRow gdvrw = gdvCPWO.Rows[j];
        TextBox txtintIdAss = (TextBox)gdvrw.FindControl("txtintId");
        if (txtintIdAss.Text == "")
        {
            ms.IntId = 0;
        }
        else
        {
            ms.IntId = Convert.ToInt32(txtintIdAss.Text);
        }

        TextBox txtteCPWOAss = (TextBox)gdvrw.FindControl("txtteCPWO");
        if (txtteCPWOAss.Text == "")
        {
            ms.ChvTEIdPDE = "";
        }
        else
        {
            ms.ChvTEIdPDE = txtteCPWOAss.Text.ToString();
        }
        TextBox txtAmtCPWOAss = (TextBox)gdvrw.FindControl("txtAmtCPWO");
        if (txtAmtCPWOAss.Text == "")
        {
            ms.FltAmtPDE = 0;
        }
        else
        {
            ms.FltAmtPDE = Convert.ToDecimal(txtAmtCPWOAss.Text);
        }

        TextBox txtRemCPWOAss = (TextBox)gdvrw.FindControl("txtRemCPWO");
        if (txtRemCPWOAss.Text == "")
        {
            ms.ChvRemarksPDE = "";
        }
        else
        {

            ms.ChvRemarksPDE = txtRemCPWOAss.Text.ToString();
        }
        ms.IntRelMonthWiseId = RelMnthID;
        ms.IntTrnType = 1;
        CheckBox chkCollect = (CheckBox)gdvrw.FindControl("chkCollect");
        if (chkCollect.Checked == true)
        {
            ms.FlgMissingPDE = 2;
            if (MandatoryFlds(j) == true)
            {
                SaveChalanAGCollect(j);
            }
            else
            {
                gblobj.MsgBoxOk("Enter all details!", this);
            }
        }
        else
        {
            ms.FlgMissingPDE = 1;
        }
        TextBox txtChlnCPWOAss = (TextBox)gdvrw.FindControl("txtChlnCPWO");
        if (txtChlnCPWOAss.Text == "")
        {
            ms.ChvChalanBillNoPDE = "";
        }
        else
        {
            ms.ChvChalanBillNoPDE = txtChlnCPWOAss.Text.ToString();
        }
        TextBox txtChlnDateCPWOass = (TextBox)gdvrw.FindControl("txtChlnDateCPWO");
        if (txtChlnDateCPWOass.Text == "")
        {
            ms.DtmChalanBilllDtPDE = "";
        }
        else
        {
            ms.DtmChalanBilllDtPDE = txtChlnDateCPWOass.Text.ToString();


            DateTime billDate = Convert.ToDateTime(ms.DtmChalanBilllDtPDE.ToString());
            mnthId = billDate.Month;
            //TextBox RelMnthAss = (TextBox)gdvrw.FindControl("RelMnth");
            //RelMnthAss.Text = mnthId.ToString();

            ms.IntRelMonthId = mnthId;
            //Convert.ToInt32(RelMnthAss.Text);

            ArrayList ardt = new ArrayList();
            ardt.Add(txtChlnDateCPWOass.Text.ToString());
            yrId = genDAO.gFunFindYearIdFromDate(ardt);

            ms.IntRelYearId = yrId;

            //TextBox RelYearIdAss = (TextBox)gdvrw.FindControl("RelYearId");
            //RelYearIdAss.Text = yrId.ToString();
        }
        DropDownList ddlTreasuryCPWOAss = (DropDownList)gdvrw.FindControl("ddlTreasuryCPWO");
        if (ddlTreasuryCPWOAss.SelectedIndex > 0)
        {
            ms.IntTreaId = Convert.ToInt32(ddlTreasuryCPWOAss.SelectedValue);
        }
        else
        {
            ms.IntTreaId = 0;
        }
        DropDownList ddlLBAss = (DropDownList)gdvrw.FindControl("ddlLB");
        if (ddlLBAss.SelectedIndex > 0)
        {
            ms.lBId = Convert.ToInt32(ddlLBAss.SelectedValue);
        }
        else
        {
            ms.lBId = 0;
        }


        ms.IntRelMonthId = yrId;
        ms.IntRelYearId = mnthId;
        DataSet ds = new DataSet();
        ds = msDao.CreateTEPlusMissingPDE(ms);
    }
    private Boolean MandatoryFlds(int i)
    {
        Boolean flg = true;
        GridViewRow gvr = gdvCPWO.Rows[i];
        TextBox txtChlnDateCPWOAss = (TextBox)gvr.FindControl("txtChlnDateCPWO");
        TextBox txtAmtCPWOAss = (TextBox)gvr.FindControl("txtAmtCPWO");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");
        DropDownList ddlSubTrCMAss = (DropDownList)gvr.FindControl("ddlTreasuryCPWO");
        TextBox txtChlnCPWO = (TextBox)gvr.FindControl("txtChlnCPWO");
        TextBox txtteCPWO = (TextBox)gvr.FindControl("txtteCPWO");

        //if (txtChlnDateCPWOAss.Text == null || txtChlnDateCPWOAss.Text == "" || Convert.ToInt32(txtChlnCPWO.Text) >= 9999)
        if (txtChlnDateCPWOAss.Text == null || txtChlnDateCPWOAss.Text == "" || txtChlnCPWO.Text == null || txtChlnCPWO.Text == "" || Convert.ToInt32(txtChlnCPWO.Text) == 0 || txtteCPWO.Text == null || txtteCPWO.Text == "")
        {
            flg = false;
        }
        else if (txtAmtCPWOAss.Text == null || txtAmtCPWOAss.Text == "")
        {
            flg = false;
        }
        else if (ddlLBAss.SelectedValue == "" || ddlLBAss.SelectedValue == null || Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
        //else if (Convert.ToInt32(ddlLBAss.SelectedValue) == 0)
        {
            flg = false;
        }
        //else if (ddlSubTrCMAss.SelectedValue == "" || ddlSubTrCMAss.SelectedValue == null )
        else if (Convert.ToInt32(ddlSubTrCMAss.SelectedValue) == 0)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    public void ShowWithoutDocs()
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        msDao = new MissingDAO();

        SetGridDefaultWOD();
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(1);
        ds = msDao.FillCrWithoutDocsPDE(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntWthout.Text = ds.Tables[0].Rows.Count.ToString();
            gdvCPWO.DataSource = ds;
            gdvCPWO.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCPWO.Rows[i];
                TextBox txtTeNoCMAss = (TextBox)gdv.FindControl("txtteCPWO");
                txtTeNoCMAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtChNCMAss = (TextBox)gdv.FindControl("txtChlnCPWO");
                txtChNCMAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtChDtCMAss = (TextBox)gdv.FindControl("txtChlnDateCPWO");
                txtChDtCMAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmtCMAss = (TextBox)gdv.FindControl("txtAmtCPWO");
                txtAmtCMAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                ////Treas////////
                DropDownList ddlSubTrCMAss = (DropDownList)gdv.FindControl("ddlTreasuryCPWO");
                DataSet dstreas = new DataSet();
                dstreas = teDAO.GetTreasury();
                gblobj.FillCombo(ddlSubTrCMAss, dstreas, 1);
                ddlSubTrCMAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                ////Treas////////

                ////Lb////////
                DropDownList ddlLBAss = (DropDownList)gdv.FindControl("ddlLB");
                ArrayList arlb = new ArrayList();
                ArrayList arL = new ArrayList();
                DataSet dslb = new DataSet();
                DataSet dsTId = new DataSet();
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[4]) > 0)
                {
                    arlb.Add(Convert.ToInt16(ddlSubTrCMAss.SelectedValue));
                }
                else
                {
                    arlb.Add(0);
                }
                dsTId = gendao.GetDistIdfromTreasId(arlb);

                if (dsTId.Tables[0].Rows.Count > 0)
                {
                    Session["IntDistIdTEPde"] = Convert.ToInt16(dsTId.Tables[0].Rows[0].ItemArray[0].ToString());
                    arL.Add(Convert.ToInt32(Session["IntDistIdTEPde"]));
                    dslb = gendao.GetLBGp(arL);
                    gblobj.FillCombo(ddlLBAss, dslb, 1);
                    ddlLBAss.SelectedValue = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                }            

                TextBox txtremCMAss = (TextBox)gdv.FindControl("txtRemCPWO");
                txtremCMAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();


                Label lblintIdWtht = (Label)gdv.FindControl("lblintIdWtht");
                lblintIdWtht.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                //gblobj.IntId = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[6]);

                Label  txtRelMnthWiseIdAss = (Label)gdv.FindControl("lblRelMnthwseId");
                txtRelMnthWiseIdAss.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
            if (Convert.ToDouble(gdvCPWO.FooterRow.Cells[4].Text) > 0)
            {
                lblAmtWOCP.Text = gdvCPWO.FooterRow.Cells[4].Text.ToString();
            }
            else
            {
                lblAmtWOCP.Text = "0";
            }
        }

        else
        {
            fillGridcomboswithoutDocs(gdvCPWO);
            lblAmtWOCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
    }
    protected void btnOkbal_Click(object sender, EventArgs e)
    {      
        SaveBalanceCrPDE();
        ShowBalanceTransCr();
        lblTot.Text = Session["dblAmtCrPlus"].ToString();
        lblAmtBTCP.Text = gdvBT.FooterRow.Cells[6].Text.ToString();
        lblTotE.Text = Convert.ToString(Convert.ToDouble(lblAmtWOCP.Text) + Convert.ToDouble(lblAmtWCP.Text) + Convert.ToDouble(lblAmtBTCP.Text) + Convert.ToDouble(txtAnnIntAmt.Text));

        lblBal.Text = Convert.ToString(Convert.ToDouble(lblTot.Text) - Convert.ToDouble(lblTotE.Text));
    }
    private Boolean CheckMandatory(TextBox txt1, TextBox txt2)
    {
        Boolean flg = true;
        if (txt1.Text == "" || txt1.Text == null || txt2.Text == "" || txt2.Text == null)
        {
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    public void SaveBalanceCrPDE()
    {
        genDAO = new KPEPFGeneralDAO();
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();
        gblobj = new clsGlobalMethods();
        gdvBT.Columns[10].Visible = true;
        if (Convert.ToDouble(gdvBT.FooterRow.Cells[6].Text) > 0)
        {
            for (int i = 0; i < gdvBT.Rows.Count; i++)
            {
                GridViewRow gdvrw = gdvBT.Rows[i];
                TextBox txtAmtCPBTAss = (TextBox)gdvrw.FindControl("txtAmtCPBT");
                DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatus");
                Label lblRelMnthwseIdBalAss = (Label)gdvrw.FindControl("lblRelMnthwseIdBal");
                TextBox txtTeNoCPBTAss = (TextBox)gdvrw.FindControl("txtTeNoCPBT");
                Label lblRelMnthwseIdBalAss1 = (Label)gdvrw.FindControl("lblRelMnthwseIdBal");

                TextBox txtFrmAcCPBT = (TextBox)gdvrw.FindControl("txtFrmAcCPBT");
                TextBox txtToaccCPBT = (TextBox)gdvrw.FindControl("txtToaccCPBT");
                //Label lblintAccno = (Label)gdvrw.FindControl("lblintAccno");
                //Label txtintIdAss = (Label)gdvrw.FindControl("lblintId");
                if (CheckMandatory(txtFrmAcCPBT, txtToaccCPBT) == true)
                {
                    //if (lFunEditMode(Convert.ToInt32(txtintIdAss.Text), Convert.ToDouble(txtAmtCPBTAss.Text), Convert.ToInt32(lblintAccno.Text)) == false)
                    //{
                        DataSet ds = new DataSet();
                        blPDE.IntTEMonthWiseId = Convert.ToInt32(Session["GintTEMonthWiseId"]);
                        ArrayList aryr = new ArrayList();
                        aryr.Add(Convert.ToInt16(Session["IntYearAG"]));
                        DataSet dsyr = new DataSet();
                        dsyr = genDAO.GetPDEYrId(aryr);
                        if (dsyr.Tables[0].Rows.Count >= 0)
                        {
                            blPDE.IntRelYearId = Convert.ToInt16(dsyr.Tables[0].Rows[0].ItemArray[0].ToString());
                        }
                        blPDE.IntRelMonthId = Convert.ToInt16(Session["IntMonthAG"]);
                        if (txtAmtCPBTAss.Text == "")
                        {
                            blPDE.FltAmtPDE = 0;
                        }
                        else
                        {
                            blPDE.FltAmtPDE = Convert.ToDecimal(txtAmtCPBTAss.Text);
                        }
                        blPDE.IntTrnType = 5;
                        blPDE.IntTreasId = 0;
                        if (ddlStatusAss.SelectedIndex > 0)
                        {
                            blPDE.IntModeChgPDE = Convert.ToInt32(ddlStatusAss.SelectedValue);
                        }
                        else
                        {
                            blPDE.IntModeChgPDE = 2;
                        }
                        if (lblRelMnthwseIdBalAss.Text == "")
                        {
                            blPDE.IntRelMonthWiseId = 0;
                        }
                        else
                        {
                            blPDE.IntRelMonthWiseId = Convert.ToInt32(lblRelMnthwseIdBalAss.Text.ToString());
                        }
                        blPDE.IntLBId = 0;
                        if (txtTeNoCPBTAss.Text == "")
                        {
                            blPDE.ChvTEIdPDE = "";
                        }
                        else
                        {
                            blPDE.ChvTEIdPDE = txtTeNoCPBTAss.Text;
                        }
                        ds = blPDEDao.CreateBalanceTransRel(blPDE);
                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            blPDE.IntRelMonthWiseId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                            lblRelMnthwseIdBalAss1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                        }
                        lSubSaveBalTransfer(i);
                    //}
                }
                else
                {
                    gblobj.MsgBoxOk("Enter all details!!!", this);
                }
            }
        }
        gdvBT.Columns[10].Visible = false;
    }
    private Boolean lFunEditMode(Int32 intBtID,double amt,Int32 acc)
    {
        blPDEDao = new BalanceTransPDEDao();
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intBtID);
        ar.Add(amt);
        ar.Add(acc);
        ds = blPDEDao.getEditStatus(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public void lSubSaveBalTransfer(int j)
    {
        gblobj = new clsGlobalMethods();
        blPDE = new BalanTrPDE();
        blPDEDao = new BalanceTransPDEDao();

        GridViewRow gdvrw = gdvBT.Rows[j];
        Label txtintIdAss = (Label)gdvrw.FindControl("lblintId");
        if (txtintIdAss.Text == "")
        {
            blPDE.IntIDPDE = 0;
        }
        else
        {
            blPDE.IntIDPDE = Convert.ToInt32(txtintIdAss.Text);
        }
        Label txtRelMnthIDbalAss = (Label)gdvrw.FindControl("lblRelMnthwseIdBal");
        if (txtRelMnthIDbalAss.Text == "")
        {
            blPDE.IntRelMonthWiseId = 0;
        }
        else
        {
            blPDE.IntRelMonthWiseId = Convert.ToInt32(txtRelMnthIDbalAss.Text);
        }
        TextBox txtTeNoCPBTAss = (TextBox)gdvrw.FindControl("txtTeNoCPBT");
        if (txtTeNoCPBTAss.Text == "")
        {
            blPDE.ChvTEIdPDE = "";
        }
        else
        {
            blPDE.ChvTEIdPDE = txtTeNoCPBTAss.Text.ToString();
        }
        TextBox txtFrmAcCPBTAss = (TextBox)gdvrw.FindControl("txtFrmAcCPBT");
        if (txtTeNoCPBTAss.Text == "")
        {
            blPDE.ChvFrmAccNoPDE = "";
        }
        else
        {
            blPDE.ChvFrmAccNoPDE = txtFrmAcCPBTAss.Text.ToString();
        }
        Label txtintAccnoAs = (Label)gdvrw.FindControl("lblintAccno");
        if (txtintAccnoAs.Text == "")
        {
            blPDE.IntToAccNoPDE = 0;
        }
        else
        {
            blPDE.IntToAccNoPDE = Convert.ToInt32(txtintAccnoAs.Text);

        }
        blPDE.ChvToAccNoPDE = "";
        blPDE.IntFrmAccNoPDE = 0;
        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");
        if (txtAmtCPBT.Text == "")
        {
            blPDE.FltAmtPDE = 0;
        }
        else
        {
            blPDE.FltAmtPDE = Convert.ToDecimal(txtAmtCPBT.Text);
        }
        TextBox txtRmkCPBT = (TextBox)gdvrw.FindControl("txtRmkCPBT");
        if (txtRmkCPBT.Text == "")
        {
            blPDE.ChvRemarksPDE = "";
        }
        else
        {
            blPDE.ChvRemarksPDE = txtRmkCPBT.Text.ToString();
        }
        DropDownList ddlStatusAss = (DropDownList)gdvrw.FindControl("ddlStatus");
        if (ddlStatusAss.SelectedIndex > 0)
        {
            blPDE.IntModeChgPDE = Convert.ToInt32(ddlStatusAss.SelectedValue);
        }
        else
        {
            blPDE.IntModeChgPDE = 2;
        }
        blPDE.IntFlag = 5;

        //////////////saveCorrectionEntryBT//////////////////////
        Label lbloldAcc = (Label)gdvrw.FindControl("lbloldAcc");
        Label lbloldAmt = (Label)gdvrw.FindControl("lbloldAmt");

        int amtO = Convert.ToInt32(lbloldAmt.Text);
        int amtN = Convert.ToInt32(txtAmtCPBT.Text);
        int accO = Convert.ToInt32(lbloldAcc.Text);
        int accN = Convert.ToInt32(txtintAccnoAs.Text);
        if (lFunEditMode(Convert.ToInt32(txtintIdAss.Text), Convert.ToDouble(txtAmtCPBT.Text), Convert.ToInt32(txtintAccnoAs.Text)) == false)
        {
            saveCorrectionEntryBT(Convert.ToInt32(txtintIdAss.Text), amtO, amtN, accO, accN, 0);
        }
        //////////////saveCorrectionEntryBT//////////////////////


        DataSet ds = new DataSet();
        ds = blPDEDao.CreateBalanceTransCr(blPDE);    
        //////////////////// fill .////////////////          
        gblobj.MsgBoxOk("Saved successfully", this);
    }
    private void findCorrType(Double amto, Double amtn, int acco, int accn, int intDel)
    {
        if (intDel == 1)
        {
            corrType = 12;
        }
        else
        {
            if (acco == 0)          // new acc no  (From local master)
            {
                corrType = 13;
            }
            else if (acco != accn)  // acc no change  (From local master)
            {
                corrType = 10;
            }
            else if (amto != amtn)  // amt change  (From local master)
            {
                corrType = 11;
            }
        }
    }
    //private int getCorrTp(int rw)
    //{
    //    int tp = 0;

    //    return tp;
    //}
    public void SaveBalanceCr()
    {
        gblobj = new clsGlobalMethods();
        ms = new Missing();
        bl = new balancetrans();
        blDAO = new BalancetransDAO();

        for (int i = 0; i < gdvBT.Rows.Count; i++)
        {
            GridViewRow gdvrw = gdvBT.Rows[i];
            DataSet ds = new DataSet();

            Label txtintIdAss = (Label)gdvrw.FindControl("lblintId");
            //tranEntry.IntId = gblobj.IntId;

            if (txtintIdAss.Text == "")
            {
                bl.IntID = 0;
            }
            else
            {
                bl.IntID = Convert.ToInt32(txtintIdAss.Text.ToString());
            }
            ms.IntAGEntryId = Convert.ToInt32(Session["IntAGId"]);
            TextBox txtTeNoCPBTAss = (TextBox)gdvrw.FindControl("txtTeNoCPBT");
            if (txtTeNoCPBTAss.Text == "")
            {
                bl.ChvTEId = "";
            }
            else
            {
                bl.ChvTEId = txtTeNoCPBTAss.Text;
            }
            TextBox txtAmtCPBTAss = (TextBox)gdvrw.FindControl("txtAmtCPBT");
            if (txtAmtCPBTAss.Text == "")
            {
                bl.FltAmt = 0;
            }
            else
            {
                bl.FltAmt = Convert.ToDecimal(txtAmtCPBTAss.Text);
            }
            TextBox txtFrmAcCPBTAss = (TextBox)gdvrw.FindControl("txtFrmAcCPBT");
            if (txtFrmAcCPBTAss.Text == "")
            {
                bl.ChvFrmAccNo = "";
            }
            else
            {
                bl.ChvFrmAccNo = txtFrmAcCPBTAss.Text.ToString();
            }
            TextBox txtToaccCPBTAss = (TextBox)gdvrw.FindControl("txtToaccCPBT");
            if (txtToaccCPBTAss.Text == "")
            {
                bl.IntToAccNo = 0;
            }
            else
            {
                bl.IntToAccNo = Convert.ToInt32(txtToaccCPBTAss.Text);
            }
            TextBox txtRmkCPBTAss = (TextBox)gdvrw.FindControl("txtRmkCPBT");
            if (txtRmkCPBTAss.Text == "")
            {
                bl.ChvRemarks = "";
            }
            else
            {
                bl.ChvRemarks = txtRmkCPBTAss.Text.ToString();
            }
            bl.IntModeChg = 1;
            bl.IntYearId = gblobj.IntYear;
            bl.IntMonthId = gblobj.IntMonth;
            ds = blDAO.CreateBalanceTransCr(bl);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                //chalanId = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0]);
                // gblobj.IntId  = Convert.ToInt32 (ds.Tables[0].Rows[0].ItemArray[0]);
            }
        }
        gblobj.MsgBoxOk("Saved successfully", this);

    }
    public void ShowBalanceTransCr()
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();

        //DataTable dtBTdoc = gblobj.SetInitialRow(gdvBT);
        //ViewState["BT"] = dtBTdoc;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();


        arr.Add(Convert.ToInt16(Session["IntYearAG"]));
        arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
        arr.Add(5);

        ds = blDAO.FillBalancetransCrPDE(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCntBT.Text = ds.Tables[0].Rows.Count.ToString();
            gdvBT.DataSource = ds;
            gdvBT.DataBind();
            //dtBTdoc = gblobj.SetGridTableRows(gdvBT, ds.Tables[0].Rows.Count);
            //ViewState["BT"] = dtBTdoc;


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvBT.Rows[i];
                TextBox txtTeNoCPBTAss = (TextBox)gdv.FindControl("txtTeNoCPBT");
                txtTeNoCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtFrmAcCPBTAss = (TextBox)gdv.FindControl("txtFrmAcCPBT");
                txtFrmAcCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();

                Label txtintAccnoAssg = (Label)gdv.FindControl("lblintAccno");
                txtintAccnoAssg.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();


                TextBox txtToaccCPBTAss = (TextBox)gdv.FindControl("txtToaccCPBT");
                txtToaccCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txttoNameF = (TextBox)gdv.FindControl("txttoName");
                txttoNameF.Text = ds.Tables[0].Rows[i].ItemArray[10].ToString();



                TextBox txtAmtCPBTass = (TextBox)gdv.FindControl("txtAmtCPBT");
                txtAmtCPBTass.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();


                TextBox txtRmkCPBTAss = (TextBox)gdv.FindControl("txtRmkCPBT");
                txtRmkCPBTAss.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();


                Label txtintIdAss = (Label)gdv.FindControl("lblintId");
                txtintIdAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                Label lblRelMnthwseIdBalAss = (Label)gdv.FindControl("lblRelMnthwseIdBal");
                lblRelMnthwseIdBalAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                DropDownList ddlStatus = (DropDownList)gdv.FindControl("ddlStatus");
                ddlStatus.SelectedValue = ds.Tables[0].Rows[i].ItemArray[11].ToString();


                Label lbloldAcc = (Label)gdv.FindControl("lbloldAcc");
                lbloldAcc.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                Label lbloldAmt = (Label)gdv.FindControl("lbloldAmt");
                lbloldAmt.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                Label lbleditMode = (Label)gdv.FindControl("lbleditMode");
                lbleditMode.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
            gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
            
        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
        if (Convert.ToDouble(gdvBT.FooterRow.Cells[6].Text) > 0)
        {
            lblAmtBTCP.Text = gdvBT.FooterRow.Cells[6].Text.ToString();
        }
        else
        {
            lblAmtBTCP.Text = "0";
        }
        gdvBT.Columns[10].Visible=false;

    }
    protected void Btnwithout_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ViewState["Withoutdoc"] != null)
        {
            DataTable dt = (DataTable)ViewState["Withoutdoc"];
            int count = gdvCPWO.Rows.Count;
            //DropDownList drp1 = (DropDownList)gdvCPW.Rows[count - 1].Cells[5].FindControl("ddlTreCPWO");
            //DropDownList drp2 = (DropDownList)gdvCPW.Rows[count - 1].Cells[6].FindControl("ddlDist");
            //DropDownList drp3 = (DropDownList)gdvCPW.Rows[count - 1].Cells[7].FindControl("ddlLB");
            //if (drp1.SelectedIndex == 0)
            //{
            //   // ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Data');", true);
            //    objClass.setFocus(drp1, this);
            //}
            //else
            //{
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtteCPWO");
            arrIN.Add("txtChlnCPWO");
            arrIN.Add("txtChlnDateCPWO");
            arrIN.Add("txtAmtCPWO");
            arrIN.Add("ddlTreasuryCPWO");
            arrIN.Add("ddlLB");
            arrIN.Add("txtRemCPWO");
            //  arrIN.Add("ddlStusCPW");
            arrIN.Add("txtintId");
            arrIN.Add("Btnwithout");
            arrIN.Add("RelMnth");
            arrIN.Add(" RelYearId");
            dt = gblobj.AddNewRowToGrid(dt, gdvCPWO, arrIN);
            ViewState["SpecTable"] = dt;
            DropDownList drpnewtreas = (DropDownList)gdvCPWO.Rows[count].FindControl("ddlTreasuryCPWO");

            DropDownList drpnewLB = (DropDownList)gdvCPWO.Rows[count].FindControl("ddlLB");
            gblobj.setFocus(drpnewtreas, this);
            //}
            //fillGridcomboswithoutDocs(gdvCPWO);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drptr = (DropDownList)gdvCPWO.Rows[i].FindControl("ddlTreasuryCPWO");
                drptr.SelectedValue = dt.Rows[i].ItemArray[5].ToString();

                DropDownList drpLB = (DropDownList)gdvCPWO.Rows[i].FindControl("ddlLB");
                drpLB.SelectedValue = dt.Rows[i].ItemArray[6].ToString();
            }
        }
    }
    protected void BtnBT_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        if (ViewState["BT"] != null)
        {
            DataTable dt = (DataTable)ViewState["BT"];
            int count = gdvBT.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("txtTeNoCPBT");
            arrIN.Add("txtFrmAcCPBT");
            arrIN.Add("txtToaccCPBT");
            arrIN.Add("txtAmtCPBT");
            arrIN.Add("txtRmkCPBT");
            arrIN.Add("ddlStutCPBT");
            arrIN.Add("txtintId");
            //  arrIN.Add("ddlStusCPW");
            arrIN.Add("BtnBT");

            dt = gblobj.AddNewRowToGrid(dt, gdvBT, arrIN);
            ViewState["BT"] = dt;
        }
    }
    protected void txtChlnDateCPWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPWO.Rows[index];
        TextBox txtChlnDateCPWO = (TextBox)gvr.FindControl("txtChlnDateCPWO");
        if (gblobj.isValidDate(txtChlnDateCPWO, this) == true)
        {
            string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));

            if (gblobj.CheckChalanDateAg(txtChlnDateCPWO, dt) == false)
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtChlnDateCPWO.Text = "";
        }
    }
    protected void txtChlnDtCPW_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        genDAO = new KPEPFGeneralDAO();
        ArrayList ardt = new ArrayList();
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPW.Rows[index];
        TextBox txtChlnDtCPW = (TextBox)gvr.FindControl("txtChlnDtCPW");
        Label lblEditId = (Label)gvr.FindControl("lblEditId");
        Label lblDy = (Label)gvr.FindControl("lblDy");
        DateTime dtm = new DateTime();

        Label oldYear = (Label)gvr.FindControl("lblYearId");
        Label oldMnth = (Label)gvr.FindControl("lblMnth");
        Label oldDay = (Label)gvr.FindControl("lblDay");

        if (gblobj.isValidDate(txtChlnDtCPW, this) == true)
        {
            if (gblobj.CheckDateInBetween(txtChlnDtCPW, gblobj.GenerateStartDate("2001-02", 4)) == true)
            {
                string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));
                if (gblobj.CheckChalanDateAg(txtChlnDtCPW, dt) == false)
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                }
                else
                {
                    if (Convert.ToInt16(oldYear.Text) > 0)
                    {
                        dtm = Convert.ToDateTime(txtChlnDtCPW.Text);
                        ardt.Add(txtChlnDtCPW.Text);
                        int yrnw = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);
                        int mthnw = dtm.Month;
                        int dynw = dtm.Day;
                        if (yrnw < Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "1";
                        }
                        else if (yrnw > Convert.ToInt16(oldYear.Text))
                        {
                            lblEditId.Text = "2";
                        }
                        else
                        {
                            if (genDAO.getMonthIdCalYear(mthnw) < genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "1";
                            }
                            else if (genDAO.getMonthIdCalYear(mthnw) > genDAO.getMonthIdCalYear(Convert.ToInt16(oldMnth.Text)))
                            {
                                lblEditId.Text = "2";
                            }
                            else
                            {
                                if (dynw <= 4 && Convert.ToInt16(oldDay.Text) > 4)
                                {
                                    lblEditId.Text = "1";
                                }
                                else
                                {
                                    if (dynw > 4 && Convert.ToInt16(oldDay.Text) <= 4)
                                    {
                                        lblEditId.Text = "2";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lblEditId.Text = "0";
                    }
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtChlnDtCPW.Text = "";
        }


        //gblobj = new clsGlobalMethods();
        //genDAO = new KPEPFGeneralDAO();
        //int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        //GridViewRow gvr = gdvCPW.Rows[index];
        //TextBox txtChlnDtCPW = (TextBox)gvr.FindControl("txtChlnDtCPW");
        //Label lblEditId = (Label)gvr.FindControl("lblEditId");
        //Label lblDy = (Label)gvr.FindControl("lblDy");
        //DateTime dtm = new DateTime();

        //if (gblobj.isValidDate(txtChlnDtCPW, this) == true)
        //{
        //    if (gblobj.CheckDateInBetween(txtChlnDtCPW, gblobj.GenerateStartDate("2001-02", 4)) == true)
        //    {
        //        string dt = genDAO.GetDateAsString(Convert.ToInt16(Session["IntMonthAG"]), Convert.ToInt16(Session["IntYearAG"]));
        //        if (gblobj.CheckChalanDateAg(txtChlnDtCPW, dt) == false)
        //        {
        //            gblobj.MsgBoxOk("Invalid Date", this);
        //        }
        //        else
        //        {
        //            dtm = Convert.ToDateTime(txtChlnDtCPW.Text);
        //            int monthId = dtm.Month;
        //            if (Convert.ToInt16(lblDy.Text) != 0)
        //            {
        //                if (dtm.Day <= 4 && Convert.ToInt16(lblDy.Text) > 4)
        //                {
        //                    lblEditId.Text = "1";
        //                }
        //                else if (dtm.Day > 4 && Convert.ToInt16(lblDy.Text) <= 4)
        //                {
        //                    lblEditId.Text = "2";
        //                }
        //                else
        //                {
        //                    lblEditId.Text = "0";
        //                }
        //            }
        //            else
        //            {
        //                lblEditId.Text = "0";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        gblobj.MsgBoxOk("Invalid Date", this);
        //    }
        //}
        //else
        //{
        //    gblobj.MsgBoxOk("Invalid Date", this);
        //    txtChlnDtCPW.Text = "";
        //}
    }
    
    protected void txtFrmAcCPBT_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtToaccCPBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        int intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        DataSet dsName = new DataSet();
        GridViewRow gdr = gdvBT.Rows[intCurRw];

        TextBox txtFromACcAss = (TextBox)gdr.FindControl("txtToaccCPBT");
        Label lblAccNoAss = (Label)gdr.FindControl("lblintAccno");
        TextBox txtfrmName = (TextBox)gdr.FindControl("txttoName");

        if (gblobj.CheckNumericOnly(txtFromACcAss.Text.ToString(), this) == true)
        {
            emp.NumEmpID = Convert.ToDouble(txtFromACcAss.Text.ToString());
            dsName = empD.GetEmployeeDetails(emp, 1);
            if (dsName.Tables[0].Rows.Count > 0)
            {
                txtFromACcAss.Text = dsName.Tables[0].Rows[0].ItemArray[0].ToString();
                txtfrmName.Text = dsName.Tables[0].Rows[0].ItemArray[1].ToString();
                lblAccNoAss.Text = dsName.Tables[0].Rows[0].ItemArray[3].ToString();
            }
            else
            {
                txtFromACcAss.Text = "";
                txtfrmName.Text = "";
                lblAccNoAss.Text = "";
            }
        }
    }
    protected void btnAddFloorNew_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblobj.checkLastRowStatus(myControls, arrControlid, gdvCPWO);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblobj.AddNewRow(myControls, arrControlid, arrDT, gdvCPWO);
            DataSet ds = new DataSet();
            gdvCPWO.DataSource = dtgdRow;
            gdvCPWO.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gdvCPWO, ds);
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
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox()); 
        return myControls;
    }
    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
      //  arrControlid.Add("ddFloorArea");
        arrControlid.Add("txtintId");     
       
        arrControlid.Add("txtChlnCPWO");
        arrControlid.Add("txtChlnDateCPWO");
        arrControlid.Add("txtAmtCPWO");
        arrControlid.Add("ddlTreasuryCPWO");
        arrControlid.Add("ddlLB");     
        arrControlid.Add("txtRemCPWO");
        arrControlid.Add("txtteCPWO"); 
       
       return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();

        arrControlid.Add("intId");
       
        arrControlid.Add("intChalNo");
        arrControlid.Add("dtmChalDt");
        arrControlid.Add("fltAmt");
        arrControlid.Add("intTreasID");
        arrControlid.Add("intLBID");
        arrControlid.Add("chvDetails");
        arrControlid.Add("chvTEId");
       
        return arrControlid;
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs i)
    {
        gblobj = new clsGlobalMethods();
        msDao = new MissingDAO();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label txtintId = (Label)gdvCPWO.Rows[rowIndex].FindControl("lblintIdWtht");
        ArrayList arrin = new ArrayList();
        arrin.Add(Convert.ToInt32(txtintId.Text));
        try
        {
            msDao.UpdateTEPlusMissing(arrin);
        }
        catch (Exception ex)
        {
            Session["ERROR"] = ex.ToString();
            Response.Redirect("Error.aspx");
        }
        ShowWithoutDocs();
        gblobj.MsgBoxOk("Row Deleted   !", this);
        FillHeadLbls();
    }
    private void deleteUnsavedDbMinus()
    {
        gblobj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        DataTable dtgdRow = gblobj.deleteRows(myControls, arrControlid, arrDT, gdvCPWO);
        if (dtgdRow.Rows.Count > 0)
        {
            DataSet ds = new DataSet();
            gdvCPWO.DataSource = dtgdRow;
            gdvCPWO.DataBind();
            ds.Tables.Add(dtgdRow);
            // fillDropDownGridExistsFloor(gdvCM, ds);
        }
        else
        {
            ShowWithoutDocs();
        }
    }
    private void fillDropDownGridExistsFloor(GridView gdView, DataSet ds)
    {
     

       // fillGridcomboswithoutDocs(gdvCPWO);
        foreach (GridViewRow gdRow in gdView.Rows)
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arrin = new ArrayList();
                    arrin.Add(Session["intLBID"].ToString());
                    DropDownList ddlTreasuryCPWOAss = (DropDownList)gdRow.FindControl("ddlTreasuryCPWO");
                    DropDownList ddlLBAss = (DropDownList)gdRow.FindControl("ddlLB");

                    ddlTreasuryCPWOAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[5].ToString();
                    ddlLBAss.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex].ItemArray[7].ToString();


                }
            }
        }
    }

    protected void txtAmtCPBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
    }
    protected void txtChlAmtCPW_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvCPW, 4, "txtChlAmtCPW", 1);
    }
    protected void txtAmtCPWO_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
    }
    private void FillLbDtWise(int TresId, DropDownList ddlLBAss)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();

        ArrayList arL = new ArrayList();
        DataSet dsL = new DataSet();

        ar.Add(TresId);
        ds = gendao.GetDistIdfromTreasId(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["IntDistIdTECurr"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            arL.Add(Convert.ToInt32(Session["IntDistIdTECurr"]));
            dsL = gendao.GetLBGp(arL);
            gblobj.FillCombo(ddlLBAss, dsL, 1);
        }
    }
    protected void ddlTreasuryCPWO_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvCPWO.Rows[index];
        DropDownList ddlTreasuryCPWO = (DropDownList)gvr.FindControl("ddlTreasuryCPWO");
        DropDownList ddlLBAss = (DropDownList)gvr.FindControl("ddlLB");

        if (Convert.ToInt16(ddlTreasuryCPWO.SelectedValue) > 0)
        {
            Session["IntTreIdTECurr"] = Convert.ToInt16(ddlTreasuryCPWO.SelectedValue);
            FillLbDtWise(Convert.ToInt16(Session["IntTreIdTECurr"]), ddlLBAss);
        }
        else
        {
            Session["IntTreIdTECurr"] = 0;
        }
    }
    protected void chkUnpostCPW_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvCPW.Rows[index];

        CheckBox chkUnpostCPW = (CheckBox)gdvr.FindControl("chkUnpostCPW");
        DropDownList ddlReason = (DropDownList)gdvr.FindControl("ddlreason");
        if (chkUnpostCPW.Checked == true)
        {
            ddlReason.Enabled = true;
        }
        else
        {
            ddlReason.Enabled = false;
        }
    }
    protected void gdvEmpDist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {        
        gdvCPW.PageIndex = e.NewPageIndex;
      
        ShowCRPlus();
        SetEnable();
        lblPgNo.Visible = true;
        lblPgNo.Text = gdvCPW.PageIndex + 1 + " of " + gdvCPW.PageCount;
    }
    protected void lnkAnnInt_Click(object sender, EventArgs e)
    {
        clearAnnInt();
        FillAnnInt();
        mdlConfirm.Show();
    }
    private void clearAnnInt()
    {
        txtAnnIntAmt.Text = "0";
        txtTENo.Text = "0";
        txtAnnIntRem.Text = "0";

    }
    private void FillAnnInt()
    {
        annD = new AnnIntDAO();
        ArrayList ar = new ArrayList();
        DataSet dsAnn = new DataSet();
        ar.Add(Convert.ToInt16(Session["IntYearAG"]));
        dsAnn = annD.GetAnnIntPDE(ar);
        if (dsAnn.Tables[0].Rows.Count > 0)
        {
            txtAnnIntAmt.Text = dsAnn.Tables[0].Rows[0].ItemArray[4].ToString();
            txtTENo.Text = dsAnn.Tables[0].Rows[0].ItemArray[6].ToString();
            txtAnnIntRem.Text = dsAnn.Tables[0].Rows[0].ItemArray[5].ToString();
        }
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        ann = new AnnInt();
        annD = new AnnIntDAO();
        
        ann.IntYearId = Convert.ToInt16(Session["IntYearAG"]);
        ann.IntSlNo = 1;
        ann.FltAmount = Convert.ToInt64(txtAnnIntAmt.Text);
        ann.Rem = txtAnnIntRem.Text.ToString();
        ann.TENo = Convert.ToInt32(txtTENo.Text);
        annD.CreateAnnIntPDE(ann);
        gblobj.MsgBoxOk("Saved!", this);
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        mdlConfirm.Hide();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void txtCntWthout_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        msDao = new MissingDAO();

        if (txtCntWthout.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdlwtht = new ArrayList();
            arDdlwtht.Add("ddlTreasuryCPWO");

            arDdlwtht.Add("ddlLB");

            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDswt = new ArrayList();

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDswt.Add(dstreas);


            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDswt.Add(dslb);

            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arColswt = new ArrayList();
            SetArrColsWt(arColswt);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();

            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            arr.Add(1);
            ds = msDao.FillCrWithoutDocsPDEBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHpwt = new ArrayList();
            arHpwt.Add("SlNo");

            //Arr to store Boubd field and Hyperlinks navigation fields//////////

            //gblobj.SetGridRowsWithData(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs);

            gblobj.SetGridRowsWithDataNew(ds, Convert.ToInt16(txtCntWthout.Text), gdvCPWO, arDdlwtht, arColswt, arDdlDswt, arHpwt);
            gblobj.SetFooterTotalsTempField(gdvCPWO, 4, "txtAmtCPWO", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCPWO, 1);
        }
    }
    private void SetArrColsWt(ArrayList arColswt)
    {
        arColswt.Add("txtteCPWO");
        arColswt.Add("txtChlnCPWO");
        arColswt.Add("txtChlnDateCPWO");
        arColswt.Add("txtAmtCPWO");
        arColswt.Add("ddlTreasuryCPWO");
        arColswt.Add("ddlLB");
        arColswt.Add("txtRemCPWO");
        arColswt.Add("lblintIdWtht");
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        teDAO = new TEDAO();
        chDao = new ChalanDAO();

        if (txtCnt.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();

            arDdl.Add("ddlDist");
            arDdl.Add("ddlTreCPWO");
            arDdl.Add("ddlLB");
            //arDdl.Add("ddlStatus");
            arDdl.Add("ddlreason");
            //Store Ddls in an array//////////

            //Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();


            DataSet dsdist = new DataSet();
            dsdist = teDAO.GetDist();
            arDdlDs.Add(dsdist);

            DataSet dstreas = new DataSet();
            dstreas = teDAO.GetTreasury();
            arDdlDs.Add(dstreas);

            DataSet dslb = new DataSet();
            dslb = teDAO.GetLB();
            arDdlDs.Add(dslb);

            DataSet dsM = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(1);
            dsM = gendao.GetMisClassRsn(arrIn);
            arDdlDs.Add(dsM);
            //Store Ds to fill Ddls in an array//////////

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dscrplus = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            dscrplus = chDao.FillCrPlusPDEBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");
            arHp.Add("numChalanId");
            arHp.Add("flgApproval");
            arHp.Add("flgPrevYear");
            arHp.Add("intGroupId");

            //gblobj.SetGridRowsWithDataNewWithNoData(Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs, arHp);

            gblobj.SetGridRowsWithDataNew(dscrplus, Convert.ToInt16(txtCnt.Text), gdvCPW, arDdl, arCols, arDdlDs, arHp);
        }
        else
        {
            gblobj.SetRowsCnt(gdvCPW, 1);
        }

    }

    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtTeCPW");
        arCols.Add("txtchno");
        arCols.Add("txtChlnDtCPW");
        arCols.Add("txtChlAmtCPW");
        arCols.Add("ddlDist");
        arCols.Add("ddlTreCPWO");
        arCols.Add("ddlLB");
        arCols.Add("chkUnpostCPW");
        arCols.Add("ddlreason");
     //   arCols.Add("ddlStatus");
        arCols.Add("lblRelMnthwseIdWith");
        arCols.Add("lblChalanAGIdWith");
        arCols.Add("lblMnth");
        arCols.Add("lblYearId");
        arCols.Add("lblDay");
    }
    protected void btnDeleteWth_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        chDao = new ChalanDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label txtintId = (Label)gdvCPW.Rows[rowIndex].FindControl("lblChalanAGIdWith");
        TextBox txtChlnDtCPW = (TextBox)gdvCPW.Rows[rowIndex].FindControl("txtChlnDtCPW");
        //CorrectionEntryForDel(Convert.ToInt32(txtintId.Text), txtChlnDtCPW.Text.ToString()); //Corr Entry

        Label lblChalIdWith = (Label)gdvCPW.Rows[rowIndex].FindControl("lblChalIdWith");
        CorrectionEntryForDel(Convert.ToInt32(lblChalIdWith.Text), txtChlnDtCPW.Text.ToString()); //Corr Entry

        ArrayList arrin = new ArrayList();
        arrin.Add(Convert.ToInt32(txtintId.Text));
        chDao.APChalanAGDel(arrin);
        ShowCRPlus();
        gblobj.MsgBoxOk("Row Deleted   !", this);

        FillHeadLbls();
    }
    private void CorrectionEntryForDel(float numChalId, string chalDt)
    {
        schedDao = new SchedulePDEDao();
        genDAO = new KPEPFGeneralDAO();
        double amt;
        int NumID;
        int NumEmpID;
        double fltAmtBfr;
        double fltAmtAfr;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numChalId);
        ar.Add(1);
        ds = schedDao.GetSchedDet4CorrEntryAg(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NumEmpID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                amt = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtBfr = Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                fltAmtAfr = 0;
                amt = fltAmtAfr - fltAmtBfr;
                NumID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                // chlId = Convert.ToInt32(txtchlnId.Text);
                ////yr mnth day///////
                DateTime dt;
                dt = Convert.ToDateTime(chalDt);

                int intMth = dt.Month;
                int intDy = dt.Day;

                ArrayList ardt = new ArrayList();
                ardt.Add(chalDt);
                int intYrId = genDAO.gFunFindPDEYearIdFromDateOnline(ardt);

                /////////////////////
                SaveCorrectionEntry(NumEmpID, numChalId, intYrId, intMth, intDy, Convert.ToDouble(amt), NumID, 8, fltAmtBfr, fltAmtAfr, 4);
                //schedPdeDao.DelTR104PDEMode(ar);
            }
        }
    }
    private void saveCorrectionEntryBT(float schedId, double amtO, double amtN, Int32 accO, Int32 accN, int intDel)
    {

        genDAO = new KPEPFGeneralDAO();
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();
        int yr;
        int mth;
        int intDy;
        Double amtCalc = 0;
        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        yr = Convert.ToInt16(Session["IntYearAG"]); 
        mth = Convert.ToInt16(Session["IntMonthAG"]);
        intDy = 1;

        findCorrType(amtO, amtN, accO, accN, intDel);
        if (corrType == 10)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    cor.IntAccNo = accO;
                    amtCalc = -amtN;
                    cor.FltAmountBefore = amtO;
                    cor.FltAmountAfter = 0;
                }
                else
                {
                    cor.IntAccNo = accN;
                    amtCalc = amtN;
                    cor.FltAmountBefore = 0;
                    cor.FltAmountAfter = amtN;
                }
                double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
                cor.IntYearID = yr;
                cor.IntMonthID = mth;
                cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);

                cor.FltCalcAmount = dblAmtAdjusted;
                cor.FlgCorrected = 1;      //Just added not incorporated in CCard
                cor.IntChalanId = schedId;
                cor.IntSchedId = schedId;
                cor.FlgType = 1;           //Remittance
                cor.FltRoundingAmt = 0;
                cor.IntCorrectionType = corrType;
                cor.IntChalanType = 4;
                cor.IntTblTp = 1;
                cord.CreateCorrEntryCalcTblTp(cor);
            }
        }
        else
        {
            if (corrType == 13)
            {
                amtCalc = amtN;
                cor.FltAmountBefore = 0;
                cor.FltAmountAfter = amtN;
            }
            else if (corrType == 12)
            {
                amtCalc = -amtN;
                cor.FltAmountBefore = amtN;
                cor.FltAmountAfter = 0;
            }
            else
            {
                amtCalc = amtN - amtO;
                cor.FltAmountBefore = amtO;
                cor.FltAmountAfter = amtN;
            }
            double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amtCalc);
            ///// Save to CorrEntry/////////
            cor.IntAccNo = accN;
            cor.IntYearID = yr;
            cor.IntMonthID = mth;
            cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
            cor.FltCalcAmount = dblAmtAdjusted;
            cor.FlgCorrected = 1;      //Just added not incorporated in CCard
            cor.IntChalanId = schedId;
            cor.IntSchedId = schedId;
            cor.FlgType = 1;           //Remittance
            cor.FltRoundingAmt = 0;
            cor.IntCorrectionType = corrType;
            cor.IntChalanType = 4;
            cor.IntTblTp = 1;
            cord.CreateCorrEntryCalcTblTp(cor);
        }
    }
    private void SaveCorrectionEntry(int intAccNo, float chalId, int yr, int mth, int intDy, double amt, double intSchedId, int intCorrTp, double fltAmtBfr, double fltAmtAfr, int ChalType)
    {
        gendao = new GeneralDAO();
        gblobj = new clsGlobalMethods();
        cor = new CorrectionEntry();
        cord = new CorrectionEntryDao();

        Session["intCCYearId"] = gendao.GetCCYearId() + 1;
        double dblAmtAdjusted = gblobj.CalculateAdjAmt(yr, Convert.ToInt16(Session["intCCYearId"]), mth, intDy, amt);
        ///// Save to CorrEntry/////////
        cor.IntAccNo = intAccNo;
        cor.IntYearID = yr;
        cor.IntMonthID = mth;
        cor.IntYearIDCorrected = Convert.ToInt16(Session["intCCYearId"]);
        cor.FltAmountBefore = fltAmtBfr;
        cor.FltAmountAfter = fltAmtAfr;
        cor.FltCalcAmount = dblAmtAdjusted;
        cor.FlgCorrected = 1;      //Just added not incorporated in CCard
        cor.IntChalanId = chalId;
        cor.IntSchedId = intSchedId;
        cor.FlgType = 1;           //Remittance
        cor.FltRoundingAmt = 0;
        cor.IntCorrectionType = intCorrTp; //Edit Chal Date
        cor.IntChalanType = ChalType;
        cor.IntTblTp = 1;
        cord.CreateCorrEntryCalcTblTp(cor);
    }
    protected void txtCntBT_TextChanged(object sender, EventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blDAO = new BalancetransDAO();

        if (txtCntBT.Text.Trim() != "")
        {
            //Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();          
            ArrayList arDdlDs = new ArrayList();
                      

            //Store Cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrColsBT(arCols);
            //Store Cols in an array//////////

            //Ds to fill Grid//////////
            DataSet dsbt = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["IntYearAG"]));
            arr.Add(Convert.ToInt16(Session["IntMonthAG"]));
            dsbt = blDAO.FillBalancetransCrBind(arr);
            //Ds to fill Grid//////////

            //Arr to store Boubd field and Hyperlinks navigation fields//////////
            ArrayList arHp = new ArrayList();
            arHp.Add("SlNo");        

            gblobj.SetGridRowsWithDataNew(dsbt, Convert.ToInt16(txtCntBT.Text), gdvBT, arDdl, arCols, arDdlDs, arHp);
            gblobj.SetFooterTotalsTempField(gdvBT, 6, "txtAmtCPBT", 1);
        }
        else
        {
            gblobj.SetRowsCnt(gdvBT, 1);
        }
    }
    private void SetArrColsBT(ArrayList arCols)
    {
        arCols.Add("txtTeNoCPBT");
        arCols.Add("txtFrmAcCPBT");
      //  arCols.Add("txtName");
        arCols.Add("txtToaccCPBT");
        arCols.Add("txttoName");
        arCols.Add("txtAmtCPBT");
        arCols.Add("txtRmkCPBT");
        arCols.Add("lblintAccno");
        arCols.Add("ddlStatus");
        arCols.Add("lblintId");
        arCols.Add("lblRelMnthwseIdBal");
    }
    protected void btndeleteBal_Click(object sender, ImageClickEventArgs e)
    {
        gblobj = new clsGlobalMethods();
        blPDEDao = new BalanceTransPDEDao();

        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvrw = gdvBT.Rows[rowIndex];
        Label lblintIdbalAss = (Label)gdvrw.FindControl("lblintId");
        Label lblintId = (Label)gdvrw.FindControl("lblintId");
        Label lblintAccno = (Label)gdvrw.FindControl("lblintAccno");
        TextBox txtAmtCPBT = (TextBox)gdvrw.FindControl("txtAmtCPBT");

        //SaveCorrectionEntry(Convert.ToInt32(lblintAccno.Text), Convert.ToInt32(lblintId.Text), Convert.ToInt16(Session["IntYearAG"]), Convert.ToInt16(Session["IntMonthAG"]), 1, Convert.ToDouble(txtAmtCPBT.Text), Convert.ToInt32(lblintId.Text), 12, Convert.ToDouble(txtAmtCPBT.Text), 0, 5); //Corr Entry
        //////////////saveCorrectionEntryBT//////////////////////
        Label lbloldAcc = (Label)gdvrw.FindControl("lbloldAcc");
        Label lbloldAmt = (Label)gdvrw.FindControl("lbloldAmt");

        int amtO = Convert.ToInt32(lbloldAmt.Text);
        int amtN = Convert.ToInt32(txtAmtCPBT.Text);
        int accO = Convert.ToInt32(lbloldAcc.Text);
        int accN = Convert.ToInt32(lblintAccno.Text);
        saveCorrectionEntryBT(Convert.ToInt32(lblintId.Text), amtO, amtN, accO, accN, 1);
        //////////////saveCorrectionEntryBT//////////////////////

        ArrayList arrin = new ArrayList();
        if (lblintIdbalAss.Text != "")
        {
            arrin.Add(Convert.ToInt32(lblintIdbalAss.Text));
            try
            {
                blPDEDao.DeleteBalancetransCrPDE(arrin);
            }
            catch (Exception ex)
            {
                Session["ERROR"] = ex.ToString();
                Response.Redirect("Error.aspx");
            }

            gblobj.MsgBoxOk("Row Deleted   !", this);
        }
        else
        {
            gblobj.MsgBoxOk("No data !", this);
        }
        ShowBalanceTransCr();
        FillHeadLbls();
    }
    protected void gdvBT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {
            ShowCRPlus();
            FillHeadLbls();
            SetlnkAnnInt();
            txtCnt.Enabled = false;
        }
        else
        {
            SetGridDefault();
            if (Convert.ToInt16(Session["flgAppAg"]) == 2)
            {
                txtCnt.Enabled = true;
            }
        }
        SetEnable();
    }

}
