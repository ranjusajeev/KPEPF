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

public partial class Contents_InboxSub : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    Approval appObj = new Approval();
    ApprovalDAO appDao = new ApprovalDAO();
    SubnChangeDAO subnDao = new SubnChangeDAO();
    EmployeeDAO empd = new EmployeeDAO();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
            FillInboxTA(gdvInboxSc);
        }
    }
    private void FillInboxTA(GridView gdv)
    {
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
        arrInBx.Add(1);     //Not using
        dsInBx = subnDao.InboxSunbnChange(arrInBx);

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
            ar.Add("dtmDateOfRequest");
            ar.Add("chvPF_No");
            ar.Add("chvName");
            ar.Add("fltAmtAdmissible");
            ar.Add("numWithRequestID");
            ar.Add("chvEngLBName");
            ar.Add("flgApproval");
            gblObj.SetGridDefault(gdv, ar);
            gdv.Enabled = false;
            btnOK.Enabled = false;
        }
    }
    private void InitialSettings()
    {
        DataSet ds = new DataSet();
        //SetRdbSelectionBackFrmTrnPage();           //For Approval and Rejected By
        SetRdAppOptionForClerk();
    }
    //private void SetRdbSelectionBackFrmTrnPage()
    //{
    //    SetRdAppOptionForClerk();
    //    //if (Convert.ToInt16(Session["intUserTypeId"]) == 1)
    //    //{
    //    //    rdApp.Enabled = true;
    //    //    if (Convert.ToInt16(Session["IntAppFlgInbox"]) != 1 && Convert.ToInt16(Session["IntAppFlgInbox"]) != 2)
    //    //    {
    //    //        Session["IntAppFlgInbox"] = 1;
    //    //        rdApp.Items[0].Selected = true;
    //    //        rdApp.Items[1].Selected = false;
    //    //    }
    //    //    else if (Convert.ToInt16(Session["IntAppFlgInbox"]) == 1)
    //    //    {
    //    //        rdApp.Items[0].Selected = true;
    //    //        rdApp.Items[1].Selected = false;
    //    //    }
    //    //    else if (Convert.ToInt16(Session["IntAppFlgInbox"]) == 2)
    //    //    {
    //    //        rdApp.Items[1].Selected = true;
    //    //        rdApp.Items[0].Selected = false;
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    rdApp.Enabled = false;
    //    //}
    //}
    private void SetRdAppOptionForClerk()
    {
        //// Rejection list is only for Clerk ////
        //if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
        //{
        //    btnOK.Text = "Approve";
        //}
        //else
        //{
        //    rdApp.Enabled = false;
        //}

        //// Rejection privillege is only for H Authority of that office ////
        if (Convert.ToInt32(Session["intUserTypeId"]) == 3 || Convert.ToInt32(Session["intUserTypeId"]) == 4 || Convert.ToInt32(Session["intUserTypeId"]) == 5)
        {
            btnOK.Text = "Approve";
           
        }
       
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            rdApp.Items[1].Enabled = true;
            gdvInboxSc.Columns[9].Visible = false;
            gdvInboxSc.Columns[10].Visible = false;      
        }
        else
        {
            rdApp.Items[1].Enabled = false;
            gdvInboxSc.Columns[10].Visible = true;
            gdvInboxSc.Columns[9].Visible = true;

        }
    }
    protected void chkReturned_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvInboxSc.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvInboxSc.Rows[i];
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
    protected void btnOK_Click(object sender, EventArgs e)
    {
        UpdateFlagApproval(gdvInboxSc);
        FillInboxTA(gdvInboxSc);
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
                appObj.IntUserId = Convert.ToInt64(Session["intUserId"]);
                /////////////////SetChvRem/////////////////////
                if (chkReturnedAss.Checked == false)
                {
                    appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]); //Session["intFlgApp"];
                    appObj.ChvRem = "";

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
                //////////////////SetChvRem////////////////////
                if (flg == 1)
                {
                    appDao.CreateApproval(appObj);
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
                    //}
                }
            }
        }
        FillInboxTA(gdv);
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
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {
        GridView gdv = gdvInboxSc;
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
        if (rdApp.Items[0].Selected == true)
        {
            Session["IntAppFlgInbox"] = 1;
        }
        else
        {
            Session["IntAppFlgInbox"] = 2;
        }
        DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        FillInboxTA(gdvInboxSc);
    }

}
