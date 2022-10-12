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
public partial class Contents_InboxService : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
    Approval appObj = new Approval();
    ApprovalDAO appDao = new ApprovalDAO();
    SubnChangeDAO subnDao = new SubnChangeDAO();
    EmployeeDAO empd = new EmployeeDAO();
    TA2NRADAO TaToNraDao = new TA2NRADAO();
    GeneralDAO gen = new GeneralDAO();
    ClosureDAO clsrD = new ClosureDAO();

    static int intUserType = 0, intLBTypeId = 0, intLBId = 0, intUserId = 0, TrnTypeAss = 0, intDistIdIs = 0;
    long intAccNo = 0;
    GridView gdv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            //{
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //}

            InitialSettings();
            if (Convert.ToInt16(Session["intTrnType"]) == 7)             //Subn change
            {
                FillInboxTA(gdvInboxSc);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 8)        //Ta 2 Nra 
            {
                FillInboxTA(gdvInboxTaC);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 9)        //Closure
            {
                FillInboxTA(gdvInboxClosure);
            }
        }
    }
    private void SetRdAppOptionForClerk()
    {
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
        TrnTypeAss = Convert.ToInt16(Session["intTrnType"]);
        DataSet ds = new DataSet();
        //SetRejectedDisble4DEO();
        SetTrnTypeDP();
        FillDistrictPnl();
        SetGridAndCaption();
        SetRdbSelectionBackFrmTrnPage();           //For Approval and Rejected By
        SetRdbAmtSelectionBackFrmTrnPage();        //Amt category radio button
        SetRdAppOptionForClerk();
        if (Convert.ToInt16(Session["intTrnType"]) == 2)
        {
            rdAmtTp.Items[0].Selected = true;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 3)
        {
            rdAmtTp.Items[1].Selected = true;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            rdAmtTp.Items[2].Selected = true;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4)
        {
            rdAmtTp.Items[0].Enabled = false;
            rdAmtTp.Items[1].Selected = true;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            rdAmtTp.Items[0].Enabled = false;
            rdAmtTp.Items[2].Selected = true;
        }
        //}

        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)        //Ta
        {
            FillInboxTA(gdvInboxTA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)        //Nra 
        {
            FillInboxTA(gdvInboxNra);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8 || Convert.ToInt16(Session["intTrnType"]) == 81)        //Ta 2 Nra 
        {
            rdAmtTp.Visible = false;
            FillInboxTA(gdvInboxTaC);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)        //Subn change
        {
            rdAmtTp.Visible = false;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 9)        //Closure
        {
            rdAmtTp.Visible = false;
            //FillInboxTA(gdvInboxTA);
        }
    }

    private void SetRejectedDisble4DEO()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            rlist.Items[1].Enabled = false;
            rlist.Items[0].Selected = true;
        }
    }
    protected void chkReturned_CheckedChanged(object sender, EventArgs e)
    {
        SetGrid();
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow gvRw = gdv.Rows[i];
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
    private void SetTrnTypeDP()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 8)
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 2)
            {
                Session["intTrnType"] = 31;
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 4)
            {
                Session["intTrnType"] = 41;
            }
        }
    }
    private void SetRdbAmtSelectionBackFrmTrnPage()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) <= 4)
        {
            rdAmtTp.Visible = true;
            rdAmtTp.Items[0].Enabled = true;
            rdAmtTp.Items[1].Enabled = true;
            rdAmtTp.Items[2].Enabled = true;
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            rdAmtTp.Visible = true;
            rdAmtTp.Items[0].Enabled = false ;
            rdAmtTp.Items[1].Enabled = true;
            rdAmtTp.Items[2].Enabled = true;
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 7) 
        {
            rdAmtTp.Visible = false ;
            if (Convert.ToInt16(Session["intTrnType"]) == 2)
            {
                Session["intTrnType"] = 3;
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 4)
            {
                Session["intTrnType"] = 4;
            }
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 8)
        {
            rdAmtTp.Visible = false ;
            if (Convert.ToInt16(Session["intTrnType"]) == 2)
            {
                Session["intTrnType"] = 31;
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 4)
            {
                Session["intTrnType"] = 41;
            }
        }
    }
    private void SetRdbSelectionBackFrmTrnPage()
    {
        //if (gblObj.IntAppFlgInbox != 1 && gblObj.IntAppFlgInbox != 2)
        if (Convert.ToInt16(Session["intUserTypeId"]) == 1)
        {
            rdApp.Enabled = true;
            if (Convert.ToInt16(Session["IntAppFlgInbox"]) != 1 && Convert.ToInt16(Session["IntAppFlgInbox"]) != 2)
            {
                Session["IntAppFlgInbox"] = 1;
                rdApp.Items[0].Selected = true;
                rdApp.Items[1].Selected = false;
            }
            else if (Convert.ToInt16(Session["IntAppFlgInbox"]) == 1)
            {
                rdApp.Items[0].Selected = true;
                rdApp.Items[1].Selected = false;
            }
            else if (Convert.ToInt16(Session["IntAppFlgInbox"]) == 2)
            {
                rdApp.Items[1].Selected = true;
                rdApp.Items[0].Selected = false;
            }
        }
        else
        {
            rdApp.Enabled = false;
        }
    }
    private void SetGridAndCaption()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            gdvInboxTA.Visible = true;
            gdvInboxSc.Visible = false;
            gdvInboxNra.Visible = false;
            gdvInboxTaC.Visible = false;
            gdvInboxClosure.Visible = false;
            lblHead.Text = "Inbox-Temporary Advance";
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
            gdvInboxTA.Visible = false;
            gdvInboxSc.Visible = true;
            gdvInboxNra.Visible = false;
            gdvInboxTaC.Visible = false;
            gdvInboxClosure.Visible = false;
            lblHead.Text = "Inbox-Subscription Change";
            rdAmtTp.Visible = false;
            if ((Convert.ToInt32(Session["intUserTypeId"]) == 1) && Convert.ToInt32(Session["intLBTypeId"]) == 5)
            {
                gdvInboxSc.Columns[9].Visible = false;
                gdvInboxSc.Columns[10].Visible = false;

            }
            else
            {
                gdvInboxSc.Columns[9].Visible = true;
                gdvInboxSc.Columns[10].Visible = true;

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
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            gdvInboxTA.Visible = false;
            gdvInboxSc.Visible = false;
            gdvInboxNra.Visible = true;
            gdvInboxTaC.Visible = false;
            gdvInboxClosure.Visible = false;
            lblHead.Text = "Inbox-Non Refundable Advance";
            rdAmtTp.Items[0].Enabled = false;
            rdAmtTp.Items[1].Text = "Amount <= 200000";
            rdAmtTp.Items.Remove("Amount<75000");
            rdAmtTp.Items[1].Selected = true;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8 || Convert.ToInt16(Session["intTrnType"]) == 81)
        {
            gdvInboxTA.Visible = false;
            gdvInboxSc.Visible = false;
            gdvInboxNra.Visible = false;
            gdvInboxTaC.Visible = true ;
            gdvInboxClosure.Visible = false;
            lblHead.Text = "Inbox-TA to NRA Conversion";
            rdAmtTp.Visible = false;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 9)
        {
            gdvInboxTA.Visible = false;
            gdvInboxSc.Visible = false;
            gdvInboxNra.Visible = false;
            gdvInboxTaC.Visible = false;
            gdvInboxClosure.Visible = true ;
            lblHead.Text = "Inbox-Closure";
            rdAmtTp.Visible = false;
        }
    }
    private void FillDistrictPnl()
    {
        DataSet ds = new DataSet();
        //if (Convert.ToInt32(Session["intUserTypeId"]) >= 5)
        if ((Convert.ToInt32(Session["intUserTypeId"]) == 1 || Convert.ToInt32(Session["intUserTypeId"]) == 2 || Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 6 || Convert.ToInt32(Session["intUserTypeId"]) == 7 || Convert.ToInt32(Session["intUserTypeId"]) == 8) && Convert.ToInt32(Session["intLBTypeId"]) == 7)
        {
            if (intDistIdIs == 0)
            {

                ds = gen.GetDistrict();
                gblObj.FillCombo(ddlDistrict, ds, 1);
                ddlDistrict.SelectedValue = "1";
            }
            else
            {
                ds = gen.GetDistrict();
                gblObj.FillCombo(ddlDistrict, ds, 1);
                ddlDistrict.SelectedValue = intDistIdIs.ToString();
            }
            pnlAo.Visible = true;
        }
        else
        {
            pnlAo.Visible = false;
        }

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
    private void FillInboxTA(GridView gdv)
    {
        //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        //gblObj.SetAppFlagsInSession(ds);
        DataSet dsInBx = new DataSet();
        ArrayList arrInBx = new ArrayList();
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
        if(Convert.ToInt32(Session["intLBTypeId"])!=7)
        {
            arrInBx.Add(1);     //Not using
        }
        else
        {
            arrInBx.Add(Convert.ToInt16(ddlDistrict.SelectedValue));
        }

        //Dataset fill
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            dsInBx = TAReqDao.InboxTA(arrInBx);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)        //SubnChange
        {
            dsInBx = subnDao.InboxSunbnChange(arrInBx);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8)        //Ta 2 Nra conversion
        {
            dsInBx = TaToNraDao.InboxTaToNra(arrInBx);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 9)        //Closure
        {
            dsInBx = clsrD.GetClosureDetails(arrInBx);
        }
        //Dataset fill

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
                txtNumTrnId.Text = dsInBx.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblEmpIdAss = (Label)gvRw.FindControl("lblEmpId");
                lblEmpIdAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblTrnTypeAss = (Label)gvRw.FindControl("lblTrnType");
                lblTrnTypeAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                txtRsnAss.Text = dsInBx.Tables[0].Rows[i].ItemArray[11].ToString();

                if (dsInBx.Tables[0].Rows[i].ItemArray[11].ToString() != "" )
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
            ar.Add("dtmDateOfRequest");
            ar.Add("chvPF_No");
            ar.Add("chvName");
            ar.Add("fltAmtAdmissible");
            ar.Add("numWithRequestID");
            ar.Add("chvEngLBName");
            ar.Add("flgApproval");
            //ar.Add("numEmpId");
            //ar.GetRange("SlNo", "chvEmployeeName", "chvDesignation", "dtmRequest", "chvFileNo", "intNominees", "numTrnId");
            gblObj.SetGridDefault(gdv, ar);
            gdv.Enabled = false;
            btnOK.Enabled = false;
        }
        rlist.Items[0].Text = Session["strOptCaption"].ToString();
        //if (intUserType == 1)
        //{
        //    rlist.Enabled = false;
        //}

        //SetOptCaption////////////
        rlist.Items[0].Text = Session["strOptCaption"].ToString() ;
        //SetOptCaption////////////
        SetRejectedDisble4DEO();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            UpdateFlagApproval(gdvInboxTA);
            FillInboxTA(gdvInboxTA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
           
            UpdateFlagApproval(gdvInboxSc);
            FillInboxTA(gdvInboxSc);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            UpdateFlagApproval(gdvInboxNra);
            FillInboxTA(gdvInboxNra);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8) 
        {
            UpdateFlagApproval(gdvInboxTaC);
            FillInboxTA(gdvInboxTaC);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 81)
        {
            if (Convert.ToInt32(Session["intUserTypeId"]) == 8)
            {
                UpdateFlagApproval(gdvInboxTaC);
                FillInboxTA(gdvInboxTaC);
            }
        }
        
    }
    private void UpdateEmpMaster()
    {
        for (int j = 0; j < gdvInboxSc.Rows.Count; j++)
        {
            GridViewRow gdvrw = gdvInboxSc.Rows[j];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblEmpIdAss = (Label)gdvrw.FindControl("lblEmpId");

            ArrayList ar = new ArrayList();
            DataSet dsE = new DataSet();
            if (chkAppAss.Checked == true)
            {
                ar.Add(Convert.ToInt64(lblEmpIdAss.Text));
                ar.Add(Convert.ToDouble(gdvInboxSc.Rows[j].Cells[4].Text));
                empd.UpdateEmpCurrDetServicesSC(ar);
            }
        }
    }
    private void UpdateFlagApproval(GridView gdv)
    {
        int flg = 1;
      
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            CheckBox chkReturnedAss = (CheckBox)gdvrw.FindControl("chkReturned");
            Label txtNumTrnIdAss = (Label)gdvrw.FindControl("txtNumTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
            TextBox txtRsnAss = (TextBox)gdvrw.FindControl("txtRsn");
            if (chkAppAss.Checked == true)
            {
                appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
                appObj.NumTrnID = Convert.ToInt64(txtNumTrnIdAss.Text);
                appObj.IntUserId = intUserId;
                /////////////////SetChvRem/////////////////////
                if (chkReturnedAss.Checked == false)
                {
                    appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]); //Session["intFlgApp"];
                    appObj.ChvRem = "";
                   
                }
                else
                {
                    if (Convert.ToInt16(Session["intTrnType"]) != 7)
                    {
                        if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6 || Convert.ToInt16(Session["intUserTypeId"]) == 8)
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
                                gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 2, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));
                            }
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 2 || Convert.ToInt16(Session["intUserTypeId"]) == 5)
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 1 && Convert.ToInt16(Session["intLBTypeId"]) == 5)
                        {
                            flg = 0;
                            gblObj.MsgBoxOk("Can't do dis", this);
                        }
                        else
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                        }
                        appObj.ChvRem = txtRsnAss.Text;
                    }
                    else
                    {
                        if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 5)
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
                                gblObj.SaveToReturnedFiles(Convert.ToInt64(txtNumTrnIdAss.Text.ToString()), 2, TrnLBTp, Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intUserId"]));
                            }
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 2)
                        {
                            if (txtRsnAss.Text.ToString() == "" || txtRsnAss.Text.ToString() == null)
                            {
                                flg = 0;
                                gblObj.MsgBoxOk("Enter reason", this);
                            }
                            else
                            {
                                appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                            }
                            
                        }
                        else if (Convert.ToInt16(Session["intUserTypeId"]) == 1 && Convert.ToInt16(Session["intLBTypeId"]) == 5)
                        {
                            flg = 0;
                            gblObj.MsgBoxOk("Can't do dis", this);
                        }
                        else
                        {
                            appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                        }
                        appObj.ChvRem = txtRsnAss.Text;

                    }
                    
                }
                //////////////////SetChvRem////////////////////
                if (flg == 1)
                {
                    appDao.CreateApproval(appObj);
                    if (Convert.ToInt16(Session["intTrnType"]) != 7)
                    {
                        if (chkReturnedAss.Checked == true)
                        {
                            if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 6)
                            {
                                gblObj.MsgBoxOk("Returned", this);
                            }
                            else
                            {
                                gblObj.MsgBoxOk("Suggest for Return", this);
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 4)
                            {
                                UpdateEmpMaster();
                                gblObj.MsgBoxOk("Approved ", this);
                            }
                           
                        }
                    }
                    else
                    {
                        if (chkReturnedAss.Checked == true)
                        {
                            if (Convert.ToInt16(Session["intUserTypeId"]) == 3 || Convert.ToInt16(Session["intUserTypeId"]) == 4 || Convert.ToInt16(Session["intUserTypeId"]) == 5)
                            {
                                gblObj.MsgBoxOk("Returned", this);
                            }
                            else
                            {
                                gblObj.MsgBoxOk("Suggest for Return", this);
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 4)
                            {
                                UpdateEmpMaster();
                                gblObj.MsgBoxOk("Approved ", this);
                            }
                            else
                            {
                                gblObj.MsgBoxOk("Forwarded ", this);
                            }
                        }
                    }
                }
            }
        }
        //gblObj.MsgBoxOk("Forwarded", this);
        FillInboxTA(gdv);
    }
    //private int FindTrnLBTp(Int64 intId)
    //{
    //    int i;
    //    ArrayList ar = new ArrayList();
    //    DataSet ds = new DataSet();
    //    ar.Add(intId);
    //    ds = appDao.GetTrnLBType(ar);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        i = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    else
    //    {
    //        i = 0;
    //    }
    //    return i;
    //}
    //private void SaveToReturnedFiles(Int64 numTrnId,int TrnLBTp,int RejLBTp,int RejUserTp)
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add(numTrnId);
    //    ar.Add(TrnLBTp);
    //    ar.Add(RejLBTp);
    //    ar.Add(RejUserTp);
    //    appDao.SaveReturnedFiles(ar);
    //}
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        
        //CheckBox chkAll = (CheckBox)gdvInboxTA.HeaderRow.FindControl("Allchk");
        //for (int i = 0; i < gdvInboxTA.Rows.Count; i++)
        //{
        //    GridViewRow gdvRw = gdvInboxTA.Rows[i];
        //    CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
        //    if (chkAll.Checked == true)
        //    {
        //        chkAppAss.Checked = true;
        //    }
        //    else
        //    {
        //        chkAppAss.Checked = false;
        //    }
        //}
        GridView gdv = gdvInboxTA;
        if (Convert.ToInt16(Session["intTrnType"]) == 2)
        {
            gdv = gdvInboxTA;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4)
        {
            gdv = gdvInboxNra;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
            gdv = gdvInboxSc;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8)
        {
            gdv = gdvInboxTaC;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 9)
        {
            gdv = gdvInboxClosure;
        }
        CheckBox chkAll = (CheckBox)gdv.HeaderRow.FindControl("Allchk");
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdv.Rows[i];
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
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //if (rdApp.Items[0].Selected == true)
        //{
        //    //gblObj.IntAppFlgInbox = 1;
        //    Session["IntAppFlgInbox"] = 1;
        //    if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        //    {
        //        gdv.Columns[10].Visible = false;
        //    }
        //    else 
        //    {
        //        gdv.Columns[9].Visible = false;
        //    }
        //}
        //else
        //{
        //    //gblObj.IntAppFlgInbox = 2;
        //    Session["IntAppFlgInbox"] = 2;
        //    if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        //    {
        //        gdv.Columns[10].Visible = true ;
        //    }
        //    else
        //    {
        //        gdv.Columns[9].Visible = true ;
        //    }
        //}

        SetGrid();
        if (rdApp.Items[0].Selected == true)
        {
            Session["IntAppFlgInbox"] = 1;
        }
        else
        {
            Session["IntAppFlgInbox"] = 2;
        }
        DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            FillInboxTA(gdvInboxTA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
            FillInboxTA(gdvInboxSc);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            FillInboxTA(gdvInboxNra);
        }
    }
    protected void rdAmtTp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Assign trnType as it came from menu page........
        Session["intTrnType"] = TrnTypeAss;
        //Assign trnType as it came from menu page........
        if (rdAmtTp.Items[0].Selected == true)
        {
            Session["intTrnType"] = 2;
        }
        else if (rdAmtTp.Items[1].Selected == true)
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
            {
                Session["intTrnType"] = 3;
            }
            else
            {
                Session["intTrnType"] = 4;
            }
        }
        else if (rdAmtTp.Items[2].Selected == true)
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
            {
                Session["intTrnType"] = 31;
            }
            else
            {
                Session["intTrnType"] = 41;
            }
        }

        DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            FillInboxTA(gdvInboxTA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
            FillInboxTA(gdvInboxSc);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            FillInboxTA(gdvInboxNra);
        }
        //SetRejectedDisble4DEO();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex > 0)
        {
            intDistIdIs = Convert.ToInt16(ddlDistrict.SelectedValue);
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)        //Ta
            {
                FillInboxTA(gdvInboxTA);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)        //Nra 
            {
                FillInboxTA(gdvInboxNra);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 8)        //Ta 2 Nra 
            {
                FillInboxTA(gdvInboxTaC);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 7)        //Subn change
            {
                FillInboxTA(gdvInboxSc);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 9)        //Closure
            {
                //FillInboxTA(gdvInboxTA);
            }
        }
    }
    protected void ddlLb_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlLb.SelectedIndex > 0)
        //{
        //    Convert.ToInt32(Session["intLBID"]) = Convert.ToInt16(ddlLb.SelectedValue);

        //    if (Convert.ToInt16(Session["intTrnType"]) == 8)        //Ta 2 Nra 
        //    {
        //        FillInboxTA(gdvInboxTaC);
        //    }
        //    else if (Convert.ToInt16(Session["intTrnType"]) == 9)        //Closure
        //    {
        //        //FillInboxTA(gdvInboxTA);
        //    }
        //}
    }
    protected void gdvInboxNra_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    private void SetGrid()
    {
        //GridView gdv = gdvInboxTA;
        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
        {
            gdv = gdvInboxTA;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
        {
            gdv = gdvInboxNra;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 7)
        {
            gdv = gdvInboxSc;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 8 || Convert.ToInt16(Session["intTrnType"]) == 81)
        {
            gdv = gdvInboxTaC;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 9)
        {
            gdv = gdvInboxClosure;
        }
    }
    private void SetRsnEnblDsbl(int enbl)
    {
        SetGrid();

        if (enbl == 1)          // Select approve option
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
            {
                gdv.Columns[10].Visible = false;
            }
            else
            {
                gdv.Columns[9].Visible = false;
            }
        }
        else                   // Select return option     
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
            {
                gdv.Columns[10].Visible = true;
            }
            else
            {
                gdv.Columns[9].Visible = true;
            }
            
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
                if (chkAppAss.Checked == true)
                {
                    TextBox txtRsnAss = (TextBox)gvRw.FindControl("txtRsn");
                    txtRsnAss.ReadOnly = false;
                    txtRsnAss.Enabled = true;
                }
            }
        }
    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        SetGrid();
        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gdv.Rows[i];
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
        //        chkReturnedAss.Checked = false;
        //        txtRsnAss.ReadOnly = true;
        //    }
        //}
    }
    protected void gdvInboxTA_SelectedIndexChanged(object sender, EventArgs e)
    {
        //intCurRw = Convert.ToInt16(gdvInboxTA.SelectedRow.Cells[6]);
    }
}
