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

public partial class Contents_InboxMembership : System.Web.UI.Page
{

    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    MembershipDAO memDao;
    //KPEPFClassLibrary.Membership Mem;
    Approval appObj;
    ApprovalDAO appDao;
    Employee emp;
    EmployeeDAO empDao;
    NomineePDEDao mnPde;
    GeneralDAO gen;

    static int intUserType = 0, intLBTypeId = 0, intLBId = 0, intUserId = 0, intDistIdMem = 0;
    static long intAccNo = 0;
    static DataSet dsInBx = new DataSet();
    GridView gdv;
    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (!IsPostBack)
        {
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();

            //////////// chgd on 25/10/2016 //////////////////
            //if (Convert.ToInt16(Session["intTrnType"]) == 5)
            //{
            //    FillInbox(gdvInboxMembership);
            //}
            //else if (Convert.ToInt16(Session["intTrnType"]) == 13)
            //{
            //    FillInbox(gdvInboxMembershipPDE);
            //}
            //else 
            //{
            //    FillInbox(gdvInboxNomChg);
            //}

            if (Convert.ToInt16(Session["intTrnType"]) == 5)
            {
                //FillInbox(gdvInboxMembership);

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
                    SetGridDefault();
                }
                //else if (Convert.ToInt16(Session["intLBTypeId"]) == 7)
                //{
                //    if (Convert.ToInt64(Session["NumChalanID"]) > 0)
                //    {
                //        FillCmbs();
                //        SetCmbs();
                //        FillInboxDir(gdvInboxMembership);
                //    }
                //}
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 13)
            {
                FillInbox(gdvInboxMembershipPDE);
            }
            else
            {
                FillInbox(gdvInboxNomChg);
            }
            
            //////////// chgd on 25/10/2016 //////////////////

        }
    }
    private void FillInboxDir(GridView gdv)
    {
        gblObj = new clsGlobalMethods();
        memDao = new MembershipDAO();
        mnPde = new NomineePDEDao();
        DataSet dsInBx = new DataSet();
        ArrayList arrInBx = new ArrayList();

        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgAppInbx"]));
        }
        else
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgRejInbx"]));
        }
        arrInBx.Add(Convert.ToInt16(Session["intTrnType"]));
        arrInBx.Add(Convert.ToInt32(Session["intDistIdMs"]));
        dsInBx = memDao.GetInBoxMemDir(arrInBx);

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
                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[5].ToString();
                CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");
                Label lblEmpIdAss = (Label)gvRw.FindControl("lblEmpId");
                lblEmpIdAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[18].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[18].ToString() != "")
                {
                    chkReturnedAss.Checked = true;
                    txtRsnAss.ReadOnly = false;
                }
                else
                {
                    chkReturnedAss.Checked = false;
                    txtRsnAss.ReadOnly = true;
                }
                gdv.Rows[i].Cells[4].ToolTip = dsInBx.Tables[0].Rows[i].ItemArray[15].ToString();
            }
        }
        else
        {
            SetGridDefault();
        }
        SetRejectedDisble4DEO();
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEmployeeName");
        ar.Add("chvDesignation");
        ar.Add("dtmRequest");
        ar.Add("chvEngLBName");
        ar.Add("intNominees");
        ar.Add("numTrnId");
        ar.Add("numEmpId");
        gblObj.SetGridDefault(gdvInboxMembership, ar);
        gdvInboxMembership.Enabled = false;

    }
    private void SetCmbs()
    {
        ddlDistrict.SelectedValue = Convert.ToInt16(Session["intDistIdMs"]).ToString();
    }
    private void FillCmbs()
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDistrict, ds, 1);

    }
    private void FillInboxAcc(GridView gdv)
    {

        gblObj = new clsGlobalMethods();
        memDao = new MembershipDAO();
        mnPde = new NomineePDEDao();
        DataSet dsInBx = new DataSet();
        ArrayList arrInBx = new ArrayList();

        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgAppInbx"]));
        }
        else
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgRejInbx"]));
        }
        arrInBx.Add(Convert.ToInt16(Session["intTrnType"]));

        dsInBx = memDao.GetInBoxMemAcc(arrInBx);

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
            SetGridDefault();
        }
        rlist.Items[0].Text = Session["strOptCaption"].ToString();
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
    //    if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
    //    {
    //        rdApp.Enabled = true;
    //    }
    //    else
    //    {
    //        rdApp.Enabled = false;
    //    }

    //    //// Rejection privillege is only for H Authority of that office ////
    //    if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 4 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
    //    {
    //        rlist.Enabled = true;
    //    }
    //    else
    //    {
    //        rlist.Enabled = false;
    //    }
    //}
    private void FillInbox(GridView gdv)
    {
        gblObj = new clsGlobalMethods();
        memDao = new MembershipDAO();
        mnPde = new NomineePDEDao();

        ArrayList arrInBx = new ArrayList();
        if (rdApp.Items[0].Selected == true)
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgAppInbx"]));
        }
        else
        {
            arrInBx.Add(Convert.ToInt16(Session["intFlgRejInbx"]));
        }
        arrInBx.Add(Convert.ToInt16(Session["intTrnType"]));
        arrInBx.Add(Convert.ToInt32(Session["intLBId"]));
        if (Convert.ToInt16(Session["intTrnType"]) != 6)
        {
            dsInBx = memDao.GetInBoxMem(arrInBx);
        }
        else
        {
            dsInBx = mnPde.GetInBoxNomChg(arrInBx);
        }
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
                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[5].ToString();
                CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");
                Label lblEmpIdAss = (Label)gvRw.FindControl("lblEmpId");
                lblEmpIdAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[1].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[18].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[18].ToString() != "")
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
            SetGridDefault();
            
        }
        //rlist.Items[0].Text = Session["strOptCaption"].ToString();
        SetRejectedDisble4DEO();
        //if (intUserType == 1)
        //{
        //    rlist.Enabled = false;
        //}
    }
    private void SetRejectedDisble4DEO()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            rlist.Items[1].Enabled = false;
            rlist.Items[0].Selected = true;
        }
    }
    private void SetRdAppOptionForClerk()
    {
        //// Rejection list is only for Clerk ////
        //if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        //{
        //    rdApp.Enabled = true;
        //}
        //else
        //{
        //    rdApp.Enabled = false;
        //}

        //// Rejection privillege is only for H Authority of that office ////
        if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 4 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            rlist.Enabled = true;
        }
        else
        {
            rlist.Enabled = false;
        }
    }
    private void InitialSettings()
    {
        
        DataSet ds = new DataSet();
        intUserType = Convert.ToInt32(Session["intUserTypeId"]);
        intLBId = Convert.ToInt32(Session["intLBID"]);
        intLBTypeId = Convert.ToInt32(Session["intLBTypeId"]);
        intUserId = Convert.ToInt32(Session["intUserId"]);
        SetRdAppOptionForClerk();

        if (Convert.ToInt16(Session["intTrnType"]) == 5)
        {
            gdvInboxMembership.Visible = true;
            gdvInboxMembershipPDE.Visible = false;
            gdvInboxNomChg.Visible = false;
            lblHead.Text = "Inbox Membership";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)
        {
            gdvInboxMembership.Visible = false;
            gdvInboxMembershipPDE.Visible = true;
            gdvInboxNomChg.Visible = false;
            lblHead.Text = "Inbox Nominee_PDE";
        }
        else 
        {
            gdvInboxMembership.Visible = false;
            gdvInboxMembershipPDE.Visible = false;
            gdvInboxNomChg.Visible = true;
            lblHead.Text = "Inbox Nominee change";
        }
        FillDistrictPnl();

        //Set rejected opt as itself even after back from trn page
        if (Convert.ToInt16(Session["intUserTypeId"]) == 1)
        {
            rdApp.Enabled = true ;
            if (Convert.ToInt16(Session["IntAppFlgInboxMem"]) != 1 && Convert.ToInt16(Session["IntAppFlgInboxMem"]) != 2 || Convert.ToInt16(Session["IntAppFlgInboxNomP"]) != 1 && Convert.ToInt16(Session["IntAppFlgInboxNomP"]) != 2 || Convert.ToInt16(Session["IntAppFlgInboxNomC"]) != 1 && Convert.ToInt16(Session["IntAppFlgInboxNomC"]) != 2)
            {
                Session["IntAppFlgInboxMem"] = 1;
                Session["IntAppFlgInboxNomP"] = 1;
                Session["IntAppFlgInboxNomC"] = 1;
                rdApp.Items[0].Selected = true;
                rdApp.Items[1].Selected = false;
                rdApp.Enabled = false;
            }
            else if (Convert.ToInt16(Session["IntAppFlgInboxMem"]) == 1 || Convert.ToInt16(Session["IntAppFlgInboxNomP"]) == 1 || Convert.ToInt16(Session["IntAppFlgInboxNomC"]) == 1)
            {
                rdApp.Items[0].Selected = true;
                rdApp.Items[1].Selected = false;
            }
            else if (Convert.ToInt16(Session["IntAppFlgInboxMem"]) == 2 || Convert.ToInt16(Session["IntAppFlgInboxNomP"]) == 1 || Convert.ToInt16(Session["IntAppFlgInboxNomC"]) == 1)
            {
                rdApp.Items[1].Selected = true;
                rdApp.Items[0].Selected = false;
            }
        }
        else
        {
            rdApp.Enabled = false;
        }
        //Set rejected opt as itself even after back from trn page
    }
    private void FillDistrictPnl()
    {
        //DataSet ds = new DataSet();
        //if ((Convert.ToInt32(Session["intUserTypeId"]) == 1 || Convert.ToInt32(Session["intUserTypeId"]) == 2 || Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 6 || Convert.ToInt32(Session["intUserTypeId"]) == 7 || Convert.ToInt32(Session["intUserTypeId"]) == 8) && Convert.ToInt32(Session["intLBTypeId"]) == 7)
        //{
        //    if (Convert.ToInt32(Session["intDistId"]) == 0)
        //    {

        //        ds = gen.GetDistrict();
        //        gblObj.FillCombo(ddlDistrict, ds, 1);
        //        ddlDistrict.SelectedValue = "1";
        //    }
        //    else
        //    {
        //        ds = gen.GetDistrict();
        //        gblObj.FillCombo(ddlDistrict, ds, 1);
        //        ddlDistrict.SelectedValue = Convert.ToInt32(Session["intDistId"]).ToString();
        //    }
        //    pnlAo.Visible = true;
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
                if (Convert.ToInt16(Session["intDistIdMs"]) == 0)
                {
                    FillCmbs();
                }
                else
                {
                    ds = gen.GetDistrict();
                    gblObj.FillCombo(ddlDistrict, ds, 1);
                    ddlDistrict.SelectedValue = Convert.ToInt32(Session["intDistIdMs"]).ToString();
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
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 5)     //Membership
        {
            UpdateFlagApproval(gdvInboxMembership);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)   //Nom PDE
        {
            UpdateFlagApproval(gdvInboxMembershipPDE);
        }
        else                                //Nom change
        {
            UpdateFlagApproval(gdvInboxNomChg);
        }
        if (Convert.ToInt16(Session["intTrnType"]) == 5)
        {
            FillInbox(gdvInboxMembership);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)
        {
            FillInbox(gdvInboxMembershipPDE);
        }
        else
        {
            FillInbox(gdvInboxNomChg);
        }
    }
    //private void UpdateFlagApproval(GridView gdv)
    //{
    //    int flg = 0;
    //    for (int k = 0; k < gdv.Rows.Count; k++)
    //    {
    //        GridViewRow gdvrw = gdv.Rows[k];
    //        CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
    //        Label txtNumTrnIdAss = (Label)gdvrw.FindControl("txtNumTrnId");
    //        Label lblEmpIdAss = (Label)gdvrw.FindControl("lblEmpId");

    //        CheckBox chkReturnedAss = (CheckBox)gdvrw.FindControl("chkReturned");
    //        TextBox txtRsnAss = (TextBox)gdvrw.FindControl("txtRsn");
    //        if (chkAppAss.Checked == true)
    //        {
    //            appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
    //            appObj.NumTrnID = Convert.ToInt64(txtNumTrnIdAss.Text);
    //            if (rlist.Items[0].Selected == true)
    //            {
    //                appObj.FlgApproval = Session["intFlgApp"];
    //            }
    //            else
    //            {
    //                appObj.FlgApproval = Session["intFlgRej"];
    //            }
    //            appObj.IntUserID = intUserId;
    //            /////////////////SetChvRem/////////////////////

    //            if (chkReturnedAss.Checked == false)
    //            {
    //                appObj.ChvRem = "";
    //                flg = 1;
    //            }
    //            else
    //            {
    //                //appObj.ChvRem = txtRsnAss.Text;
    //                //int TrnLBTp = gblObj.FindTrnLBTpForMS(Convert.ToInt64(txtNumTrnIdAss.Text));
    //                //gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 1, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));

    //                if (txtRsnAss.Text.ToString() == "" || txtRsnAss.Text.ToString() == null)
    //                {
    //                    gblObj.MsgBoxOk("Enter reason", this);
    //                    flg = 0;
    //                }
    //                else
    //                {
    //                    appObj.ChvRem = txtRsnAss.Text;
    //                    int TrnLBTp = gblObj.FindTrnLBTpForMS(Convert.ToInt64(txtNumTrnIdAss.Text));
    //                    gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 1, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));
    //                    flg = 1;
    //                }
    //            }
    //            //////////////////SetChvRem////////////////////
    //            if (flg == 1)
    //            {
    //                appDao.CreateApproval(appObj);
    //            }

    //            if (Convert.ToInt32(Session["intUserTypeId"]) == 6 && rlist.Items[0].Selected == true)
    //            {
    //                if (Convert.ToInt16(Session["intTrnType"]) == 5)
    //                {
    //                    AssignAccountNumber(k);  //UpdBasicDet UpdCurrentDet
    //                    UpdateAddressAndNominee(appObj.NumTrnID); //UpdAddress UpdNominee
    //                    UpdateMembershipRequest(appObj.NumTrnID);
    //                    //gblObj.MsgBoxOk("Alloted No. is " + intAccNo.ToString(), this);
    //                    //SendSMS(k);
    //                    AddToUser(k,Convert.ToInt64(txtNumTrnIdAss.Text.ToString()));
    //                    string str = CreateStringSMS(k);
    //                   // gblObj.SentSMS(str);
    //                }
    //                else if (Convert.ToInt16(Session["intTrnType"]) == 6)
    //                {
    //                    UpdateNominee(k);  //AddNominee History and UpdateNominee
    //                }
    //                else if (Convert.ToInt16(Session["intTrnType"]) == 13)
    //                {
    //                    intAccNo = Convert.ToInt64(lblEmpIdAss.Text.ToString());
    //                    UpdateFlgNomEmpDet();  //Update flg on EmpDet saying dat nom is ok.
    //                }
    //                //////////Clear from Returned files/////////////////////
    //                ArrayList ar = new ArrayList();
    //                ar.Add(appObj.NumTrnID);
    //                ar.Add(2);
    //                gblObj.ClearReturnedFiles(ar);
    //                //////////Clear from Returned files/////////////////////
    //            }
    //        }
    //    }

    //    if (rlist.Items[0].Selected == true)
    //    {
    //        gblObj.MsgBoxOk(Session["strMsg"], this);
    //    }
    //    else
    //    {
    //        gblObj.MsgBoxOk("Returned", this);
    //    }
    //    FillInbox(gdv);
    //}

    private void UpdateFlagApproval(GridView gdv)
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
            if (chkAppAss.Checked == true)
            {
                //appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
                appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
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
            if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
            {

                //////////Clear from Returned files/////////////////////
                ArrayList ar = new ArrayList();
                ar.Add(appObj.NumTrnID);
                ar.Add(1);
                gblObj.ClearReturnedFiles(ar);
                //////////Clear from Returned files/////////////////////
            }
        }


        //int flg = 1;
        //for (int k = 0; k < gdv.Rows.Count; k++)
        //{
        //    GridViewRow gdvrw = gdv.Rows[k];
        //    CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
        //    Label txtNumTrnIdAss = (Label)gdvrw.FindControl("txtNumTrnId");
        //    Label lblEmpIdAss = (Label)gdvrw.FindControl("lblEmpId");
        //    CheckBox chkReturnedAss = (CheckBox)gdvrw.FindControl("chkReturned");
        //    TextBox txtRsnAss = (TextBox)gdvrw.FindControl("txtRsn");
        //    if (chkAppAss.Checked == true)
        //    {
        //        appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
        //        appObj.NumTrnID = Convert.ToInt64(txtNumTrnIdAss.Text);
        //        appObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
        //        /////////////////SetChvRem/////////////////////
        //        if (chkReturnedAss.Checked == false)
        //        {
        //            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]); //Session["intFlgApp"];
        //            appObj.ChvRem = "";
        //        }
        //        else
        //        {
        //            if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6 || Convert.ToInt16(Session["intUserTypeId"]) == 8)
        //            {
        //                appObj.FlgApproval = Convert.ToInt16(Session["intFlgRej"]); //Session["intFlgRej"];
        //                if (txtRsnAss.Text.ToString() == "" || txtRsnAss.Text.ToString() == null)
        //                {
        //                    flg = 0;
        //                    gblObj.MsgBoxOk("Enter reason", this);
        //                }
        //                else
        //                {
        //                    int TrnLBTp = gblObj.FindTrnLBTpForMS(Convert.ToInt64(txtNumTrnIdAss.Text));
        //                    gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 2, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));
        //                }
        //            }
        //            else if (Convert.ToInt16(Session["intUserTypeId"]) == 2 || Convert.ToInt16(Session["intUserTypeId"]) == 5)
        //            {
        //                appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
        //            }
        //            else if (Convert.ToInt16(Session["intUserTypeId"]) == 1 && Convert.ToInt16(Session["intLBTypeId"]) == 5)
        //            {
        //                flg = 0;
        //                gblObj.MsgBoxOk("Can't do dis", this);
        //            }
        //            else
        //            {
        //                appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
        //            }
        //            appObj.ChvRem = txtRsnAss.Text;
        //        }
        //        //////////////////SetChvRem////////////////////
        //        if (flg == 1)
        //        {
        //            appDao.CreateApproval(appObj);
        //        }

        //        if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
        //        {
        //            if (chkReturnedAss.Checked == false)
        //            {
        //                if (Convert.ToInt16(Session["intTrnType"]) == 5)
        //                {
        //                    AssignAccountNumber(k);  //UpdBasicDet UpdCurrentDet
        //                    UpdateAddressAndNominee(appObj.NumTrnID); //UpdAddress UpdNominee
        //                    UpdateMembershipRequest(appObj.NumTrnID);
        //                    AddToUser(k, Convert.ToInt64(txtNumTrnIdAss.Text.ToString()));
        //                    string str = CreateStringSMS(k);
        //                }
        //                else if (Convert.ToInt16(Session["intTrnType"]) == 6)
        //                {
        //                    UpdateNominee(k);  //AddNominee History and UpdateNominee
        //                }
        //                else if (Convert.ToInt16(Session["intTrnType"]) == 13)
        //                {
        //                    intAccNo = Convert.ToInt64(lblEmpIdAss.Text.ToString());
        //                    UpdateFlgNomEmpDet();  //Update flg on EmpDet saying dat nom is ok.
        //                }
        //                //////////Clear from Returned files/////////////////////
        //                ArrayList ar = new ArrayList();
        //                ar.Add(appObj.NumTrnID);
        //                ar.Add(2);
        //                gblObj.ClearReturnedFiles(ar);
        //                //////////Clear from Returned files/////////////////////
        //            }
        //        }
        //    }
        //}
        //gblObj.MsgBoxOk("Forwarded", this);
        //FillInbox(gdv);
    }

    public string CreateStringSMS(int rw)
    {
        string mob = "";
        mob = dsInBx.Tables[0].Rows[rw].ItemArray[20].ToString();
        string str = "";
        //string MobileNo = "9447961630";
        int intId = 0;
        str = "<?xml version='1.0' encoding='UTF-8'?>";
        str = str + "<SMS>";
        str = str + "<Application>SthapanaPF</Application>";
        str = str + "<Sub>CreditCard</Sub>";
        str = str + "<Login>SthapanaPF_CreditCard</Login>";
        str = str + "<pwd>dp816dUD</pwd>";
        str = str + "<RecID>" + intId + "</RecID>";
        str = str + "<DeptOrLB>IT Mission</DeptOrLB>";
        str = str + "<Message>" + Session["strLBName"] + "</Message>";
        str = str + "<MobNo>" + mob + "</MobNo>";
        str = str + "<LBID>" + Convert.ToInt32(Session["intLBID"]) + "</LBID>";
        str = str + "</SMS>";
        return str;
    }
    private void AddToUser(int intRw,Int64 numTrnId)
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();

        ArrayList ar = new ArrayList();
        ar.Add(10);
        ar.Add(intAccNo);
        ar.Add("123");
        ar.Add(gblObj.FindTrnLB(numTrnId));
        HyperLink hCol = (HyperLink)gdvInboxMembership.Rows[intRw].FindControl("HyperLink1");
        ar.Add(hCol.Text);
        ar.Add(1);      //Desig
        ar.Add(0);      //flgLogin  first time 0
        ar.Add(0);      //flgStatus Active
        ar.Add(gblObj.FindTrnLBTp(numTrnId));      //intInstType
        ar.Add(gblObj.FindTrnDist(numTrnId));      //DistId
        GenDao.SaveUser(ar);
    }
    //public bool SendSMS(string s)
    //{
    //    try
    //    {
    //        SthapanaPFSms.SevanaeSMS a1 = new SthapanaPFSms.SevanaeSMS();
    //        a1.Url = ConfigurationManager.AppSettings["SthapanaPFSms.smsCall_loc"].ToString();
    //        string res = a1.ws_sms(s);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}

    private void UpdateNominee(int i)
    {
        memDao = new MembershipDAO();

        ArrayList ar = new ArrayList();
        ar.Add(Session["NumEmpId"]);
        ar.Add(Convert.ToInt32(Session["intUserId"]));
        //ar.Add(intSlNo);
        //ar.Add(statDel);
        memDao.SaveHISAndDel(ar);

    }
    private void UpdateFlgNomEmpDet()
    {
        empDao = new EmployeeDAO();
        
        ArrayList ar = new ArrayList();
        ar.Add(intAccNo);
        empDao.UpdateEmpNomFlg(ar);
    }
    private void UpdateAddressAndNominee(double numTrnId)
    {
        memDao = new MembershipDAO();

        ArrayList ar = new ArrayList();
        ar.Add(numTrnId);
        ar.Add(intAccNo);
        memDao.UpdateEmpIdToNominee(ar);
    }
    private void UpdateMembershipRequest(double numTrnId)
    {
        memDao = new MembershipDAO();
        
        ArrayList ar = new ArrayList();
        ar.Add(numTrnId);
        ar.Add(intAccNo);
        memDao.UpdateEmpIdToMembership(ar);
    }
    private void AssignAccountNumber(int k)
    {
        emp = new Employee();
        empDao = new EmployeeDAO();

        DataSet dsNo = new DataSet();
        dsNo = empDao.GetMaxAccNo();
        if (dsNo.Tables[0].Rows.Count > 0)
        {
            intAccNo = Convert.ToInt64(dsNo.Tables[0].Rows[0].ItemArray[0]);
        }
        emp.NumEmpID = intAccNo;
        emp.StrEmpName = dsInBx.Tables[0].Rows[k].ItemArray[0].ToString();
        emp.IntGender = Convert.ToBoolean(dsInBx.Tables[0].Rows[k].ItemArray[7]);
        emp.DtmDOB = dsInBx.Tables[0].Rows[k].ItemArray[8].ToString();
        emp.DtmDOJS   = dsInBx.Tables[0].Rows[k].ItemArray[16].ToString();
        emp.IntPFNo = intAccNo;
        emp.IntJoinDist = Convert.ToInt32(dsInBx.Tables[0].Rows[k].ItemArray[15]);
        emp.IntJoinLB = Convert.ToInt32(dsInBx.Tables[0].Rows[k].ItemArray[10]);
        emp.IntCurrentDesigId = Convert.ToInt32(dsInBx.Tables[0].Rows[k].ItemArray[14]);
        emp.FltBasicPay = Convert.ToInt64(dsInBx.Tables[0].Rows[k].ItemArray[12]);
        emp.IntCurrLB = Convert.ToInt32(dsInBx.Tables[0].Rows[k].ItemArray[10]);
        emp.FltSubscription = Convert.ToInt64(dsInBx.Tables[0].Rows[k].ItemArray[13]);
        emp.DtmSubStartDate = dsInBx.Tables[0].Rows[k].ItemArray[9].ToString();
        emp.IntAadhaar = Convert.ToInt64(dsInBx.Tables[0].Rows[k].ItemArray[19]);
        emp.ChvPhone = dsInBx.Tables[0].Rows[k].ItemArray[20].ToString();
        emp.IntBankType = Convert.ToInt16(dsInBx.Tables[0].Rows[k].ItemArray[21]);
        emp.IntBankBranch = Convert.ToInt16(dsInBx.Tables[0].Rows[k].ItemArray[22]);
        emp.ChvBankAccNo = dsInBx.Tables[0].Rows[k].ItemArray[21].ToString();
        empDao.AddEmployee(emp);
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGrid();
        //if (rdApp.Items[0].Selected == true)
        //{
        //    gblObj.IntAppFlgInboxMem = 1;
        //    gdv.Columns[10].Visible = false;
        //}
        //else
        //{
        //    gblObj.IntAppFlgInboxMem = 2;
        //    gdv.Columns[10].Visible = true;
        //}
        
        if (Convert.ToInt16(Session["intTrnType"]) == 5)
        {
            FillInbox(gdvInboxMembership);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)
        {
            FillInbox(gdvInboxMembershipPDE);
        }
        else 
        {
            FillInbox(gdvInboxNomChg);
        }
        if (rdApp.Items[0].Selected == true)
        {
            Session["IntAppFlgInboxMem"] = 1;
            Session["IntAppFlgInboxNomP"] = 1;
            Session["IntAppFlgInboxNomC"] = 1;
        }
        else
        {
            Session["IntAppFlgInboxMem"] = 2;
            Session["IntAppFlgInboxNomP"] = 2;
            Session["IntAppFlgInboxNomC"] = 2;
        }
    }
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gdvInboxMembership.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdvInboxMembership.Rows[i];
            CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
            CheckBox chkReturnedAss = (CheckBox)gdvRw.FindControl("chkReturned");
            if (chkAll.Checked == true)
            {
                chkAppAss.Checked = true;
                chkReturnedAss.Enabled = true ;
            }
            else
            {
                chkAppAss.Checked = false;
                chkReturnedAss.Enabled = false;
            }
        }
    }
    protected void AllchkPDE_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gdvInboxMembershipPDE.HeaderRow.FindControl("AllchkPDE");
        for (int i = 0; i < gdvInboxMembershipPDE.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdvInboxMembershipPDE.Rows[i];
            CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
            //CheckBox chkReturnedAss = (CheckBox)gdvRw.FindControl("chkReturned");
            if (chkAll.Checked == true)
            {
                chkAppAss.Checked = true;
                //chkReturnedAss.Enabled = true;
            }
            else
            {
                chkAppAss.Checked = false;
                //chkReturnedAss.Enabled = false;
            }
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistrict.SelectedValue) > 0)
        {
            Session["intDistIdMs"] = Convert.ToInt16(ddlDistrict.SelectedValue);
        }
        else
        {
            Session["intDistIdMs"] = 0;
        }

        if (Convert.ToInt16(Session["intTrnType"]) == 5)        //Membership
        {
            if (Convert.ToInt16(Session["intLBTypeId"]) == 7)
            {
                FillInboxDir(gdvInboxMembership);
            }
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)        //Nominee PDE
        {
            FillInbox(gdvInboxMembershipPDE);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 6)        //Nom change
        {
            FillInbox(gdvInboxNomChg);
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
    protected void chkReturned_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gdvInboxMembership.Rows[i];
        //    CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");
        //    TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
        //    if (chkReturnedAss.Checked == true)
        //    {
        //        txtRsnAss.ReadOnly = false;
        //        txtRsnAss.Enabled = true;
        //    }
        //    else
        //    {
        //        txtRsnAss.ReadOnly = true;
        //        txtRsnAss.Enabled = false;
        //    }
        //}

            int intRw5 = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
            if (Convert.ToInt16(Session["intTrnType"]) == 5)
            {
                GridViewRow gdvRwC = gdvInboxMembership.Rows[intRw5];
                CheckBox chkReturnedAss = (CheckBox)gdvRwC.FindControl("chkReturned");
                TextBox txtRsnAss = (TextBox)gdvRwC.FindControl("txtRsn");
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
            else if (Convert.ToInt16(Session["intTrnType"]) == 6)
            {
                GridViewRow gdvRwC = gdvInboxNomChg.Rows[intRw5];
                CheckBox chkReturnedAss = (CheckBox)gdvRwC.FindControl("chkReturned");
                TextBox txtRsnAss = (TextBox)gdvRwC.FindControl("txtRsn");
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
            else if (Convert.ToInt16(Session["intTrnType"]) == 13)
            {
                GridViewRow gdvRwC = gdvInboxMembershipPDE.Rows[intRw5];
                CheckBox chkReturnedAss = (CheckBox)gdvRwC.FindControl("chkReturned");
                TextBox txtRsnAss = (TextBox)gdvRwC.FindControl("txtRsn");
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
    private void SetGrid()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 5)
        {
            gdv = gdvInboxMembership;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 6)
        {
            gdv = gdvInboxNomChg;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 13)
        {
            gdv = gdvInboxMembershipPDE;
        }
      
    }
    //private void SetRsnEnblDsbl(int enbl)
    //{
    //    SetGrid();

    //    if (enbl == 1)          // Select approve option
    //    {
    //        gdv.Columns[10].Visible = false;
    //    }
    //    else                   // Select return option     
    //    {
    //        gdv.Columns[10].Visible = true;
    //        for (int i = 0; i < gdv.Rows.Count; i++)
    //        {
    //            GridViewRow gvRw = gdv.Rows[i];
    //            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
    //            if (chkAppAss.Checked == true)
    //            {
    //                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
    //                txtRsnAss.ReadOnly = false;
    //                txtRsnAss.Enabled = true;
    //            }
    //        }
    //    }
    //}
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < gdvInboxMembership.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gdvInboxMembership.Rows[i];
        //    CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
        //    TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
        //    CheckBox chkReturnedAss = (CheckBox)gvRw.FindControl("chkReturned");
        //    if (chkAppAss.Checked == true && rlist.Items[1].Selected == true)
        //    {
        //        chkReturnedAss.Enabled = true;
        //        txtRsnAss.ReadOnly = false;
        //    }
        //    else
        //    {
        //        chkReturnedAss.Enabled = false;
        //        txtRsnAss.ReadOnly = true;
        //    }
        //}

        int intRw5 = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
        GridViewRow gdvRwC = gdvInboxMembership.Rows[intRw5];
        CheckBox chkAppAssC = (CheckBox)gdvRwC.FindControl("chkApp");
        CheckBox chkReturnedAss = (CheckBox)gdvRwC.FindControl("chkReturned");
        if (chkAppAssC.Checked == true)
        {
            chkReturnedAss.Checked = false;
            chkReturnedAss.Enabled = true ;
        }
        else
        {
            chkReturnedAss.Checked = false;
            chkReturnedAss.Enabled = false;
        }
    }

}
