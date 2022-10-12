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


public partial class Contents_InboxMonthlyTrn : System.Web.UI.Page
{

    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    ChalanDAO chalDao;
    Approval appObj;
    ApprovalDAO appDao;
    GeneralDAO gen;
    ScheduleDAO schDao;

    static DataSet dsInBx = new DataSet();
    static int intDistIdMs = 0;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            gblObj = new clsGlobalMethods();

            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
            rlist.Items[0].Text = Session["strOptCaption"].ToString();
            if (Convert.ToInt16(Session["flgAcc"]) == 1)
            {
                FillInboxAcc(gdvInboxMembership);
            }
            else if (Convert.ToInt16(Session["intLBTypeId"]) != 7)
            {
                FillInbox(gdvInboxMembership);
            }
            else if (Convert.ToInt16(Session["intLBTypeId"]) == 7)
            {
                if (Convert.ToInt64(Session["NumChalanID"]) > 0)
                {
                    FillCmbs();
                    SetCmbs();
                    FillInboxDir(gdvInboxMembership);
                }
            }
        }
    }
    private void SetCmbs()
    {
        ddlYear.SelectedValue = Convert.ToInt16(Session["intYearMs"]).ToString();
        ddlMth.SelectedValue = Convert.ToInt16(Session["intMthMs"]).ToString();
        ddlDistrict.SelectedValue = Convert.ToInt16(Session["intDistIdMs"]).ToString();
        FillDT();
        ddlDt.SelectedValue = Convert.ToInt16(Session["intDtMs"]).ToString();
    }
    private void FillCmbs()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDistrict, ds, 1);

        DataSet dsyr = new DataSet();
        dsyr = GenDao.GetYearOnLine();
        gblObj.FillCombo(ddlYear, dsyr, 1);

        DataSet dsmnth = new DataSet();
        dsmnth = gen.GetMonth();
        gblObj.FillCombo(ddlMth, dsmnth, 1);

    }
    private void FillDT()
    {
        clsGlobalMethods gblObj = new clsGlobalMethods();
        GeneralDAO gen = new GeneralDAO();

        DataSet dsTreas = new DataSet();
        ArrayList arrd = new ArrayList();
        arrd.Add(Convert.ToInt16(Session["intDistIdMs"]));
        dsTreas = gen.GetDisTreasury(arrd);
        gblObj.FillCombo(ddlDt, dsTreas, 1);
    }
    private void SetAppFlagsInSession(DataSet dss)
    {
        if (Convert.ToInt16(dss.Tables[0].Rows.Count) > 0)
        {
            Session["intFlgApp"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[0]);
            Session["intFlgRej"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[1]);
            Session["intFlgAppInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[2]);
            Session["intFlgRejInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[3]);
            Session["strOptCaption"] = dss.Tables[0].Rows[0].ItemArray[4].ToString();
            Session["strMsg"] = dss.Tables[0].Rows[0].ItemArray[5].ToString();
        }
    }
    //private void SetRdAppOptionForClerk()
    //{
    //    //// Rejection list is only for Clerk ////
    //    //if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
    //    //{
    //    //    rdApp.Enabled = true;
    //    //}
    //    //else
    //    //{
    //    //    rdApp.Enabled = false;
    //    //}

    //    //// Rejection privillege is only for H Authority of that office ////
    //    if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 4 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
    //    {
    //        rlist.Enabled = true;
    //    }
    //    else
    //    {
    //        rlist.Enabled = false;
    //    }
    //    if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
    //    {
    //        //gdvInboxMembership.Columns[10].Visible = false;
    //        rdApp.Items[1].Enabled = true;
    //    }
    //         else
    //    {
    //        //gdvInboxMembership.Columns[10].Visible = true;
    //        rdApp.Items[1].Enabled = false;
    //    }
        
    //}\
    private void SetRdAppOptionForClerk()
    {
        //// Rejection list is only for Clerk ////
        if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            btnOK.Text = "Approve";
        }

        //// Rejection privillege is only for H Authority of that office ////
        if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 4 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            rlist.Enabled = true;
        }
        else
        {
            rlist.Enabled = false;
        }
        if ((Convert.ToInt32(Session["intUserTypeId"]) == 1) && Convert.ToInt32(Session["intLBTypeId"]) == 5)
        {
            //gdvInboxMembership.Columns[10].Visible = false;
            //gdvInboxMembership.Columns[11].Visible = false;           

            gdvInboxMembership.Columns[10].Visible = false;
        }
        else
        {
            gdvInboxMembership.Columns[10].Visible = true;
            gdvInboxMembership.Columns[11].Visible = true;

        }
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            rdApp.Items[1].Enabled = true;
        }
        else
        {
            rdApp.Items[1].Enabled = false;
        }
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        
        DataSet ds = new DataSet();
        SetRdAppOptionForClerk();

        FillDistrictPnl();
        //Set rejected opt as itself even after back from trn page
        if (gblObj.IntAppFlgInbox != 1 && gblObj.IntAppFlgInbox != 2)
        {
            gblObj.IntAppFlgInbox = 1;
            rdApp.Items[0].Selected = true;
            rdApp.Items[1].Selected = false;
        }
        else if (gblObj.IntAppFlgInbox == 1)
        {
            rdApp.Items[0].Selected = true;
            rdApp.Items[1].Selected = false;
        }
        else if (gblObj.IntAppFlgInbox == 2)
        {
            rdApp.Items[1].Selected = true;
            rdApp.Items[0].Selected = false;
        }
        //Set rejected opt as itself even after back from trn page

        // Set caption for return 
        if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6)
        {
            gdvInboxMembership.Columns[10].HeaderText = "Return";
        }
        else
        {
            gdvInboxMembership.Columns[10].HeaderText = "Suggest for Return";
        }
        // Set caption for return 
    }
    private void FillDistrictPnl()
    {
        //gblObj = new clsGlobalMethods();
        //gen = new GeneralDAO();

        //DataSet ds = new DataSet();
        //if (Convert.ToInt32(Session["intLBTypeId"]) == 7)
        //{
        //    if (Convert.ToInt16(Session["flgAcc"]) != 1)
        //    {
        //        if (intDistIdMs == 0)
        //        {
        //            ds = gen.GetDistrict();
        //            gblObj.FillCombo(ddlDistrict, ds, 1);
        //            ddlDistrict.SelectedValue = "1";
        //        }
        //        else
        //        {
        //            ds = gen.GetDistrict();
        //            gblObj.FillCombo(ddlDistrict, ds, 1);
        //            ddlDistrict.SelectedValue = Convert.ToInt32(intDistIdMs).ToString();
        //        }
        //        pnlAo.Visible = true;
        //    }
        //    else
        //    {
        //        pnlAo.Visible = false;
        //    }
        //}
        //else
        //{
        //    pnlAo.Visible = false;
        //}

        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        if (Convert.ToInt32(Session["intLBTypeId"]) == 7)
        {
            if (Convert.ToInt16(Session["flgAcc"]) != 1)
            {
                if (intDistIdMs == 0)
                {
                    //ds = gen.GetDistrict();
                    //gblObj.FillCombo(ddlDistrict, ds, 1);
                    //ddlDistrict.SelectedValue = "1";
                    FillCmbs();

                }
                else
                {
                    ds = gen.GetDistrict();
                    gblObj.FillCombo(ddlDistrict, ds, 1);
                    ddlDistrict.SelectedValue = Convert.ToInt32(intDistIdMs).ToString();
                }
                pnlAo.Visible = true;
            }
            else
            {
                pnlAo.Visible = false;
            }
        }
        else
        {
            pnlAo.Visible = false;
        }
    }
    private void FillInboxAcc(GridView gdv)
    {
        gblObj = new clsGlobalMethods();
        chalDao = new ChalanDAO();

        ArrayList arrInBx = new ArrayList();
        DataSet dsInBx = new DataSet();
        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Session["intFlgAppInbx"]);
        }
        else
        {
            arrInBx.Add(Session["intFlgRejInbx"]);
        }
       

        dsInBx = chalDao.InboxChalanAcc(arrInBx);
        if (dsInBx.Tables[0].Rows.Count > 0)
        {
            btnOK.Enabled = true;
            gdv.Enabled = true;
            gdv.DataSource = dsInBx;
            gdv.DataBind();
            for (int i = 0; i < dsInBx.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label txtNumTrnId = (Label)gvRw.FindControl("txtNumTrnId");
                CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");

                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[11].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                {
                    chkReturnedAss.Checked = true;
                    txtRsnAss.ReadOnly = false;
                }
                else
                {
                    chkReturnedAss.Checked = false;
                    txtRsnAss.ReadOnly = true;
                }
            }
        }
        else
        {
            ArrayList ar = new ArrayList();
            ar.Add("SlNo");
            ar.Add("chvYear");
            ar.Add("chvMonth");
            ar.Add("ChalNoDt");
            ar.Add("SchAmt");
            ar.Add("fltChalanAmt");
            ar.Add("chvInst");
            ar.Add("chvTreasuryName");
            ar.Add("numEmpId");
            ar.Add("numChalanId");
            ar.Add("flgApproval");
            gblObj.SetGridDefault(gdvInboxMembership, ar);
            gdvInboxMembership.Enabled = false;
        }
        rlist.Items[0].Text = Session["strOptCaption"].ToString();
    }

    private void FillInbox(GridView gdv)
    {
        gblObj = new clsGlobalMethods();
        chalDao = new ChalanDAO();

        ArrayList arrInBx = new ArrayList();
        DataSet dsInBx = new DataSet();
        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Session["intFlgAppInbx"]);
        }
        else
        {
            arrInBx.Add(Session["intFlgRejInbx"]);
        }
        arrInBx.Add(Convert.ToInt16(Session["intTrnType"]));
        arrInBx.Add(Convert.ToInt32(Session["intLBId"]));
        if (Convert.ToInt32(Session["intLBTypeId"]) != 7)
        {
            arrInBx.Add(1);     //Not using
        }
        else
        {
            //arrInBx.Add(Convert.ToInt16(Session["intDistIdMs"]));
            if (Convert.ToInt16(Session["flgAcc"]) == 1)
            {
                arrInBx.Add(1);     //Not using
            }
            else
            {
                arrInBx.Add(Convert.ToInt16(Session["intDistIdMs"]));
            }
        }

        dsInBx = chalDao.InboxChalan(arrInBx);
        if (dsInBx.Tables[0].Rows.Count > 0)
        {
            btnOK.Enabled = true;
            gdv.Enabled = true;
            gdv.DataSource = dsInBx;
            gdv.DataBind();
            for (int i = 0; i < dsInBx.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label txtNumTrnId = (Label)gvRw.FindControl("txtNumTrnId");
                CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");

                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[11].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                {
                    chkReturnedAss.Checked = true;
                    txtRsnAss.ReadOnly = false;
                    //txtRsnAss.Visible = true;
                }
                else
                {
                    chkReturnedAss.Checked = false;
                    txtRsnAss.ReadOnly = true;
                    //txtRsnAss.Visible = false;
                }
            }
        }
        else
        {
            ArrayList ar = new ArrayList();
            ar.Add("SlNo");
            ar.Add("chvYear");
            ar.Add("chvMonth");
            ar.Add("ChalNoDt");
            ar.Add("SchAmt");
            ar.Add("fltChalanAmt");
            ar.Add("chvInst");
            ar.Add("chvTreasuryName");
            ar.Add("numEmpId");
            ar.Add("numChalanId");
            ar.Add("flgApproval");
            //ar.GetRange("SlNo", "chvEmployeeName", "chvDesignation", "dtmRequest", "chvFileNo", "intNominees", "numTrnId");
            gblObj.SetGridDefault(gdvInboxMembership, ar);
            gdvInboxMembership.Enabled = false;
        }
        rlist.Items[0].Text = Session["strOptCaption"].ToString();
        //SetRejectedDisble4DEO();

    }
    private void FillInboxDir(GridView gdv)
    {
        gblObj = new clsGlobalMethods();
        chalDao = new ChalanDAO();

        ArrayList arrInBx = new ArrayList();
        DataSet dsInBx = new DataSet();
        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Session["intFlgAppInbx"]);
        }
        else
        {
            arrInBx.Add(Session["intFlgRejInbx"]);
        }
        arrInBx.Add(Convert.ToInt16(Session["intTrnType"]));

        arrInBx.Add(Convert.ToInt32(Session["intYearMs"]));
        arrInBx.Add(Convert.ToInt16(Session["intMthMs"]));
        arrInBx.Add(Convert.ToInt16(Session["intDtMs"]));
        dsInBx = chalDao.InboxChalanDir(arrInBx);
        if (dsInBx.Tables[0].Rows.Count > 0)
        {
            btnOK.Enabled = true;
            gdv.Enabled = true;
            gdv.DataSource = dsInBx;
            gdv.DataBind();
            for (int i = 0; i < dsInBx.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label txtNumTrnId = (Label)gvRw.FindControl("txtNumTrnId");
                CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");

                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[11].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[11].ToString() != "")
                {
                    chkReturnedAss.Checked = true;
                    txtRsnAss.ReadOnly = false;
                }
                else
                {
                    chkReturnedAss.Checked = false;
                    txtRsnAss.ReadOnly = true;
                }
            }
        }
        else
        {
            ArrayList ar = new ArrayList();
            ar.Add("SlNo");
            ar.Add("chvYear");
            ar.Add("chvMonth");
            ar.Add("ChalNoDt");
            ar.Add("SchAmt");
            ar.Add("fltChalanAmt");
            ar.Add("chvInst");
            ar.Add("chvTreasuryName");
            ar.Add("numEmpId");
            ar.Add("numChalanId");
            ar.Add("flgApproval");
            gblObj.SetGridDefault(gdvInboxMembership, ar);
            gdvInboxMembership.Enabled = false;
        }
        rlist.Items[0].Text = Session["strOptCaption"].ToString();
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        
        SetRdAppOptionForClerk();
        if (rdApp.Items[0].Selected == true)
        {
            gblObj.IntAppFlgInbox = 1;
           
        }
        else
        {
            gblObj.IntAppFlgInbox = 2;
            
        }
        
        
        //if (rdApp.Items[0].Selected == true)
        //{
        //    gblObj.IntAppFlgInbox = 1;
        //}
        //else
        //{
        //    gblObj.IntAppFlgInbox = 2;
        //}

        //FillInbox(gdvInboxMembership);

        if (Convert.ToInt16(Session["flgAcc"]) == 1)
        {
            FillInboxAcc(gdvInboxMembership);
        }
        else if (Convert.ToInt16(Session["intLBTypeId"]) != 7)
        {
            FillInbox(gdvInboxMembership);
        }
    }
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gdvInboxMembership.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdvInboxMembership.Rows[i];
            CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
            if (chkAll.Checked == true)
            {
                chkAppAss.Checked = true;
            }
            else
            {
                chkAppAss.Checked = false;
            }
        }
    }
    protected void rlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rlist.Items[0].Selected == true)
        //{
        //    SetRsnEnblDsbl(1);
        //}
        //else
        //{
        //    SetRsnEnblDsbl(2);
        //}
    }
    private void SetRsnEnblDsbl(int enbl)
    {
        //if (enbl == 1)          // Select approve option
        //{
        //    gdvInboxMembership.Columns[10].Visible = false;
        //}
        //else                   // Select return option     
        //{
        //    gdvInboxMembership.Columns[10].Visible = true;
        //    for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        //    {
        //        GridViewRow gvRw = gdvInboxMembership.Rows[i];
        //        CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
        //        if (chkAppAss.Checked == true)
        //        {
        //            TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
        //            txtRsnAss.ReadOnly = false;
        //            txtRsnAss.Enabled = true;
        //        }
        //    }
        //}
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        /// changed for solving Session expiring issue ////////
        if (Convert.ToInt16(Session["intFlgApp"]) == 0 && Convert.ToInt16(Session["intLBTypeId"]) != 5)
        {
            gblObj.MsgBoxOk("Session Expired!!!", this);
        }
        else
        {
            UpdateFlagApproval();
            if (Convert.ToInt16(Session["flgAcc"]) == 1)
            {
                FillInboxAcc(gdvInboxMembership);
            }
            else if (Convert.ToInt16(Session["intLBTypeId"]) != 7)
            {
                FillInbox(gdvInboxMembership);
            }
            else
            {
                FillInboxDir(gdvInboxMembership);
            }
        }
        //UpdateFlagApproval();
        //if (Convert.ToInt16(Session["flgAcc"]) == 1)
        //{
        //    FillInboxAcc(gdvInboxMembership);
        //}
        //else if (Convert.ToInt16(Session["intLBTypeId"]) != 7)
        //{
        //    FillInbox(gdvInboxMembership);
        //}
        //else
        //{
        //    FillInboxDir(gdvInboxMembership);
        //}

        /// changed for solving Session expiring issue ////////
    }
    private void UpdateFlagApproval()
    {
        gblObj = new clsGlobalMethods();
        appObj = new Approval();
        appDao = new ApprovalDAO();

        int flg = 1;

        for (int k = 0; k < gdvInboxMembership.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdvInboxMembership.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            CheckBox chkReturnedAss = (CheckBox)gdvrw.FindControl("chkReturned");
            Label txtNumTrnIdAss = (Label)gdvrw.FindControl("txtNumTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
            TextBox txtRsnAss = (TextBox)gdvrw.FindControl("txtRsn");
            if (Convert.ToInt64(txtNumTrnIdAss.Text) > 0)
            {
                if (chkAppAss.Checked == true)
                {
                    //appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
                    appObj.IntTrnTypeID = 1;
                    appObj.NumTrnID = Convert.ToInt64(txtNumTrnIdAss.Text);
                    appObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
                    /////////////////SetChvRem/////////////////////
                    if (chkReturnedAss.Checked == false)
                    {
                        appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]); //Session["intFlgApp"];
                        appObj.ChvRem = "";
                    }
                    else
                    {
                        if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6)
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgRej"]); //Session["intFlgRej"];
                            if (txtRsnAss.Text.ToString() == "" || txtRsnAss.Text.ToString() == null)
                            {
                                flg = 0;
                                gblObj.MsgBoxOk("Enter reason", this);
                            }
                            else
                            {
                                int TrnLBTp = gblObj.FindTrnLBTpForMS(Convert.ToInt64(txtNumTrnIdAss.Text));
                                gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 1, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));
                            }
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 2 || Convert.ToInt16(Session["intUserTypeId"]) == 5)
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                            if (txtRsnAss.Text.ToString() == "" || txtRsnAss.Text.ToString() == null)
                            {
                                flg = 0;
                                gblObj.MsgBoxOk("Enter reason", this);
                            }
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 1 && Convert.ToInt16(Session["intLBTypeId"]) == 5)
                        {
                            flg = 0;
                            gblObj.MsgBoxOk("You haven't the privilege to do this", this);
                        }
                        else
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                        }
                        appObj.ChvRem = txtRsnAss.Text;
                    }
                    //////////////////SetChvRem////////////////////
                    //if (flg == 1)
                    //{
                    //    appDao.CreateApproval(appObj); 
                    //    gblObj.MsgBoxOk("Forwarded", this);

                    //}
                    if (flg == 1)
                    {
                        appDao.CreateApproval(appObj);
                        if (chkReturnedAss.Checked == true)
                        {
                            if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6)
                            {
                                gblObj.MsgBoxOk("Returned", this);
                            }
                            gblObj.MsgBoxOk("Suggest for Return", this);
                        }
                        if (Convert.ToInt16(Session["intUserTypeId"]) == 6)
                        {
                            gblObj.MsgBoxOk("Approved", this);
                        }
                        else
                        {
                            gblObj.MsgBoxOk("Forwarded", this);
                        }
                    }
                }

                //FillInbox(gdvInboxMembership);
                //PostToLedger//////////////////////////
                if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
                {
                    Int64 chId = Convert.ToInt64(txtNumTrnIdAss.Text);
                    //PostToLedger(chId);  //PostToLedger
                    //UpdEmpDet(chId);
                    UpdEmpCurDet(chId);
                    AddToArrearChd(chId);

                    //////////Clear from Returned files/////////////////////
                    if (chkReturnedAss.Checked == false)
                    {
                        ArrayList ar = new ArrayList();
                        ar.Add(appObj.NumTrnID);
                        ar.Add(1);
                        gblObj.ClearReturnedFiles(ar);
                    }
                    //////////Clear from Returned files/////////////////////
                }
            }
        }
        //FillInbox(gdvInboxMembership);
        //PostToLedger//////////////////////////
    }

    //private void MsgBoxOk(string msg)
    //{
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //    sb.Append("alert('");
    //    sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
    //    sb.Append("');");
    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
    //}

    //private void PostToLedger(Int64 chalId)
    //{
    //    SaveMonthly();
    //    SaveYearly();
    //}
    private void UpdEmpDet(Int64 chalId)
    {

    }
    private void UpdEmpCurDet(Int64 chalId)
    {
        schDao = new ScheduleDAO();

        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(chalId);
        ds = schDao.CheckScheduleExist(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ArrayList arr = new ArrayList();
                arr.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[12]));
                arr.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[4]) + Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[5]) + Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[6]));
                arr.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[2]) + Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[3]));
                schDao.UpdArrearToEmpCurrDet(arr);
            }
        }
    }
    private void SaveMonthly()
    {
        //ArrayList ar = new ArrayList();
    }
    private void SaveYearly()
    {

    }
    private void AddToArrearChd(Int64 chalId)
    {
        schDao = new ScheduleDAO();
        
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        ArrayList arChd = new ArrayList();
        arr.Add(chalId);
        ds = schDao.GetArrearDet(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for(int i = 0;i < ds.Tables[0].Rows.Count;i ++)
            {
                if (Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[2]) > 0)
                {
                    arChd.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[1]));
                    arChd.Add(Convert.ToInt32(Session["intLBID"]));
                    arChd.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[2]));
                    arChd.Add(Convert.ToInt64(ds.Tables[0].Rows[i].ItemArray[3]));
                    arChd.Add(1);
                    schDao.UpdArrearDet(arChd);
                    arChd.Clear();
                }
            }
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlDistrict.SelectedIndex > 0)
        //{
        //     intDistIdMs = Convert.ToInt16(ddlDistrict.SelectedValue);
        //    //DataSet dsl = new DataSet();
        //    //ArrayList ar = new ArrayList();
        //    //ar.Add(Convert.ToInt32(Session["intDistId"]));
        //    //dsl = gen.GetLB(ar);
        //    //gblObj.FillCombo(ddlLb, dsl, 1);

        //    FillInbox(gdvInboxMembership);
        //}

        if (Convert.ToInt16(ddlDistrict.SelectedValue) > 0)
        {
            Session["intDistIdMs"] = Convert.ToInt16(ddlDistrict.SelectedValue);
            //if (Convert.ToInt16(Session["flgAcc"]) == 1)
            //{
            //    FillInboxAcc(gdvInboxMembership);
            //}
            //else
            //{
            //    FillInbox(gdvInboxMembership);
            //}
            FillDT();
        }
        else
        {
            Session["intDistIdMs"] = 0;
        }

    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gdvInboxMembership.Rows[i];
        //    CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
        //    TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
        //    if (chkAppAss.Checked == true && rlist.Items[1].Selected == true)
        //    {
        //        txtRsnAss.ReadOnly = false;
        //    }
        //    else
        //    {
        //        txtRsnAss.ReadOnly = true;
        //    }
        //}
    }
    protected void chkReturned_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvInboxMembership.Rows[i];
            CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");
            TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
            if (chkReturnedAss.Checked == true)
            {
                txtRsnAss.ReadOnly = false;
                txtRsnAss.Enabled = true;
            }
            else
            {
                txtRsnAss.ReadOnly = true;
                txtRsnAss.Enabled = false;
            }
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedIndex) > 0)
        {
            Session["intYearMs"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearMs"] = 0;
        }
        ddlDt.SelectedValue = "0";
    }
    protected void ddlMth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMth.SelectedIndex) > 0)
        {
            Session["intMthMs"] = Convert.ToInt16(ddlMth.SelectedValue);
        }
        else
        {
            Session["intMthMs"] = 0;
        }
        ddlDt.SelectedValue = "0";
    }
    protected void ddlDt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDt.SelectedIndex) > 0)
        {
            Session["intDtMs"] = Convert.ToInt16(ddlDt.SelectedValue);
            FillInboxDir(gdvInboxMembership);
        }
        else
        {
            Session["intDtMs"] = 0;
        }

        //if (Convert.ToInt16(Session["flgAcc"]) == 1)
        //{
        //    FillInboxAcc(gdvInboxMembership);
        //}
        //else
        //{
        //    FillInbox(gdvInboxMembership);
        //}
    }
}
