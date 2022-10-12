using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KPEPFClassLibrary;
using System.Web.UI.HtmlControls;

public partial class Contents_AdvanceProc : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest withRq = new WithdrawalRequest();
    WithdrawalRequestDAO withRqDAO = new WithdrawalRequestDAO();
    Approval appObj = new Approval();
    ApprovalDAO appDao = new ApprovalDAO();
    static GridView gdv = new GridView();
    static int intUserType = 0, intLBTypeId = 0, intLBId = 0, intUserId = 0;
    static long intAccNo = 0, numBillId = 0;
    static int flag = 0;
    ArrayList arRpt = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.GetStatusMapping3(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {

        //GridView gdv = gvSanction;
        //if (Convert.ToInt16(Session["intTrnType"]) == 10)
        //{
        //    gdv = gvSanction;
        //}
        //else if (Convert.ToInt16(Session["intTrnType"]) == 11)
        //{
        //    gdv = gvBill;
        //}
        //else if (Convert.ToInt16(Session["intTrnType"]) == 14)
        //{
        //    gdv = gvAcqutt;
        //}

        //CheckBox chkAllAss = (CheckBox)gdv.HeaderRow.FindControl("chkAll");
        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{
        //    GridViewRow gdvRw = gdv.Rows[i];
        //    CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
        //    if (chkAllAss.Checked == true)
        //    {
        //        chkAppAss.Checked = true;
        //    }
        //    else
        //    {
        //        chkAppAss.Checked = false;
        //    }
        //}

        CheckBox chkAllAss = (CheckBox)gdv.HeaderRow.FindControl("chkAll");
        if (chkAllAss.Checked == true)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gdvRw = gdv.Rows[i];
                CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
                chkAppAss.Checked = true;
            }
        }
        else
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gdvRw = gdv.Rows[i];
                CheckBox chkAppAss = (CheckBox)gdvRw.FindControl("chkApp");
                chkAppAss.Checked = false;
            }
        }
    }
    //private void SetAppFlagsInSession(DataSet dss)
    //{
    //    if (Convert.ToInt16(dss.Tables[0].Rows.Count) > 0)
    //    {
    //        Session["intFlgApp"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[0]);
    //        Session["intFlgRej"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[1]);
    //        Session["intFlgAppInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[2]);
    //        Session["intFlgRejInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[3]);
    //        Session["strOptCaption"] = dss.Tables[0].Rows[0].ItemArray[4].ToString();
    //        Session["strMsg"] = dss.Tables[0].Rows[0].ItemArray[5].ToString();
    //    }
    //}
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 10)
        {
            gdv = gvSanction;
            gvSanction.Visible = true;
            gvBill.Visible = false;
            gvAcqutt.Visible = false;
            lblHead.Text = "Sanction Order";
            rdPrcess.Visible = false;
            if (Convert.ToInt32(Session["intUserTypeId"]) == 4)
            {
                Session["intTrnType"] = 2;
                rdPrcess.Visible = false;
            }
            if (Convert.ToInt32(Session["intUserTypeId"]) == 5)
            {
                Session["intTrnType"] = 2;
                rdPrcess.Visible = false;
            }

            else if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
            {
                Session["intTrnType"] = 3;
                rdPrcess.Visible = true;
                rdPrcess.Items[1].Selected = true;
                rdPrcess.Items[0].Enabled = false;
            }
            DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.SetAppFlagsInSession(ds);
            FillSanction(gvSanction);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 11)
        {
            gdv = gvBill;
            gvSanction.Visible = false;
            gvBill.Visible = true;
            gvAcqutt.Visible = false;
            lblHead.Text = "Bill Generation";
            rdPrcess.Visible = true;
            Session["intTrnType"] = 2;
            DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.SetAppFlagsInSession(ds);
            FillSanction(gvBill);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 14)
        {
            gdv = gvAcqutt;
            gvSanction.Visible = false;
            gvBill.Visible = false;
            gvAcqutt.Visible = true;
            lblHead.Text = "Acquittance Generation";
            rdPrcess.Visible = true;
            Session["intTrnType"] = 2;
            DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.SetAppFlagsInSession(ds);
            FillSanction(gvAcqutt);
        }

    }
    //private void SetStageForAo()
    //{
    //    if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
    //    {
    //        Convert.ToInt16(Session["intTrnTypeStage"]) = 2;
    //    }
    //}
    //public void FillLB()
    //{
    //    DataSet ds = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(Convert.ToInt32(Session["intDistId"].ToString()));
    //    ds = gen.GetLB(arrIn);
    //    gblObj.FillCombo(ddlLBName, ds, 1);

    //}
    //protected void ddlLBName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    gblObj.GetStatusMapping(intUserType, intLBTypeId, Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]));
    //    if (Convert.ToInt16(Session["intTrnTypeStage"]) == 2)
    //    {
    //        FillSanction(gvSanction);
    //    }
    //    else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 3)
    //    {
    //        FillSanction(gvBill);
    //    }
    //    else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 4)
    //    {
    //        FillSanction(gvAcqutt);
    //    }
    //}
    private void FillSanction(GridView gdv)
    {
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["intFlgAppInbx"]);
        //arrIn.Add(ddlLBName.SelectedValue);
        arrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        ds = withRqDAO.GetSanctionDet(arrIn);
        gdv.DataSource = ds;
        gdv.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label lblTrnTypeAss = (Label)gvRw.FindControl("lblTrnType");
                lblTrnTypeAss.Text = ds.Tables[0].Rows[i].ItemArray[8].ToString();

                Label lblTrnIdAss = (Label)gvRw.FindControl("lblTrnId");
                lblTrnIdAss.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblEmpIdAss = (Label)gvRw.FindControl("lblEmpId");
                lblEmpIdAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();

                //Label lblBillIdAss = (Label)gvRw.FindControl("lblBillId");
                //lblBillIdAss.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();
            }
            gdv.FooterRow.Cells[5].Text = gblObj.FindGridTotal(gdv, 5).ToString();
            gdv.Enabled = true;
        }
        else
        {
            SetGridDefault(gdv);
            gdv.Enabled = false;
        }
    }
    private void SetGridDefault(GridView gdv)
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmDateOfRequest");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("chvFileNo");
        ar.Add("fltAmtAdmissible");
        gblObj.SetGridDefault(gdv, ar);
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Set IntTrnType for diff advances//
        if (rdPrcess.Items[0].Selected == true)
        {
            Session["intTrnType"] = 2;
        }
        else if (rdPrcess.Items[1].Selected == true)
        {
            Session["intTrnType"] = 3;
        }
        else if (rdPrcess.Items[2].Selected == true)
        {
            Session["intTrnType"] = 31;
        }
        else if (rdPrcess.Items[3].Selected == true)
        {
            Session["intTrnType"] = 4;
        }
        else if (rdPrcess.Items[4].Selected == true)
        {
            Session["intTrnType"] = 41;
        }
        //Set IntTrnType for diff advances//

        //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        if (Convert.ToInt16(Session["intTrnTypeStage"]) == 2)
        {
            FillSanction(gvSanction);
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 3)
        {
            FillSanction(gvBill);
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 5)
        {
            FillSanction(gvAcqutt);
        }
    }
    private void FillBillIdInSanction()
    {
        for (int i = 0; i < gvBill.Rows.Count; i++)
        {
            GridViewRow gvrwA = gvBill.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvrwA.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gvrwA.FindControl("lblTrnId");
            Label lblTrnTypeAss = (Label)gvrwA.FindControl("lblTrnType");
            Label lblEmpIdAss = (Label)gvrwA.FindControl("lblEmpId");

            if (chkAppAss.Checked == true)
            {
                ////////////////////////////
                ArrayList arA = new ArrayList();
                arA.Add(Convert.ToInt16(lblTrnIdAss.Text));
                arA.Add(gblObj.NumBillID);
                withRqDAO.UpdateSanctionOrder(arA);
                ///////////////////////////

                ///////////////////////////
            }
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnTypeStage"]) == 2)
        {
            UpdateFlagApproval(gvSanction);
            CreateSanctionOrder();
            FillSanction(gvSanction);
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 3)
        {
            UpdateFlagApproval(gvBill);
            CreateBill();
            FillBillIdInSanction();
            Response.Redirect("Reportviewer.aspx?ReportID=2");
            FillSanction(gvBill);
            
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 5)
        {
            if (CheckDate(gvAcqutt) == true)
            {
                //if(gblObj.CheckDate3(ref,
                
                //if (validateWithdate(gvAcqutt) == true)
                //{
                    UpdateFlagApproval(gvAcqutt);
                    //CreateAcquittance();
                    SaveToWithdrawals(gvAcqutt);
                    UpdateEmpCurrDet(gvAcqutt);
                    FillSanction(gvAcqutt);
                //}
                //else
                //{
                //    gblObj.MsgBoxOk(" date of withdrawal Must greater than bill date", this);
                //}

            }
            else
            {
                gblObj.MsgBoxOk("Enter date of withdrawal", this);
            }
        }
        gblObj.MsgBoxOk("Updated!", this);
    }
    private Boolean validateWithdate(GridView gdv)
    {
        Boolean flg = true;
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            TextBox txtwithDate = (TextBox)gdvrw.FindControl("txtDtW");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
            if (chkAppAss.Checked == true)
            {
                if (txtwithDate.Text != "")
                {
                    DataSet ds = new DataSet();
                    ArrayList ArrIn = new ArrayList();
                    ArrIn.Add(lblTrnIdAss.Text);
                    ds = withRqDAO.GetBillDate(ArrIn);
                    if (gblObj.CheckDate3(ds.Tables[0].Rows[0].ItemArray[0].ToString(), txtwithDate.Text.ToString(), DateTime.Now.ToString()) == true)
                    {
                        flg = true;
                    }
                    else
                    {
                        flg = false;
                    }
                }
            }
            else
            {
                flg = true; ;
            }
        }
        return flg;
    }
    private Boolean CheckDate(GridView gdv)
    {
        Boolean flg = true;
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            TextBox txtwithDate = (TextBox)gdvrw.FindControl("txtDtW");
            Label  lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
           

            if (chkAppAss.Checked == true)
            {
                if (txtwithDate.Text == "")
                {
                    flg = false;
                }
                else
                {
                    flg = true;
                }
            }
            else
            {
                flg = true;
            }
        }

        return flg;
    }
    private void SaveToWithdrawals(GridView gdv)
    {
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
            TextBox txtwithDate = (TextBox)gdvrw.FindControl("txtDtW");

            if (chkAppAss.Checked == true)
            {
                DataSet ds = new DataSet();
                ArrayList arrIn = new ArrayList();
                arrIn.Add(Convert.ToInt32(lblTrnIdAss.Text));
                ds = withRqDAO.GetWithdrawalAcqutDet(arrIn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arE = new ArrayList();
                    arE.Add(Convert.ToInt32(lblTrnIdAss.Text));
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[2].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[3].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[4].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[5].ToString());
                    arE.Add(Convert.ToInt32(Session["intUserId"]));
                    arE.Add(txtwithDate.Text);
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[7].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[8].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[9].ToString());
                    arE.Add(ds.Tables[0].Rows[0].ItemArray[10].ToString());
                    withRqDAO.CreateWithdrawal(arE);
                }

            }
        }



    }
    private void UpdateEmpCurrDet(GridView gdv)
    {
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
            TextBox txtwithDate = (TextBox)gdvrw.FindControl("txtDtW");

            if (chkAppAss.Checked == true)
            {
                DataSet ds = new DataSet();
                ArrayList arrIn = new ArrayList();
                arrIn.Add(Convert.ToInt32(lblTrnIdAss.Text));
                ds = withRqDAO.GetWithdrawalAcqutDet4EmpMSTUpd(arrIn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList arE = new ArrayList();

                    arE.Add(Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[1]));
                    if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[6].ToString()) == 2)
                    {
                        flag = 2;
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[6].ToString()) == 4)
                    {
                        flag = 3;
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[6].ToString()) == 8)
                    {
                        flag = 4;
                    }
                    arE.Add(flag);
                    arE.Add(Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[2]));
                    arE.Add(Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[3]));
                    arE.Add(txtwithDate.Text.ToString());
                    arE.Add(Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[4]));
                    arE.Add(Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[5]));
                    empDoa.UpdateEmpCurrDetServices(arE);

                }

            }
        }


    }
    //private void CreateAcquittance()
    //{
    //    //Update Bill id in Sanction order tbl.
    //    //Insert into Pfo_Withdrawal tbl.
    //    //Update L_EmployeeCurrDet Advance details

       
    //    for (int i = 0; i < gvAcqutt.Rows.Count; i++)
    //    {
    //        GridViewRow gvrwA = gvAcqutt.Rows[i];
    //        CheckBox chkAppAss = (CheckBox)gvrwA.FindControl("chkApp");
    //        Label lblTrnIdAss = (Label)gvrwA.FindControl("lblTrnId");
    //        Label lblTrnTypeAss = (Label)gvrwA.FindControl("lblTrnType");
    //        Label lblEmpIdAss = (Label)gvrwA.FindControl("lblEmpId");

    //        if (chkAppAss.Checked == true)
    //        {
    //            ////////////////////////////
    //            ArrayList arA = new ArrayList();
    //            arA.Add(Convert.ToInt16(lblTrnIdAss.Text));
    //            arA.Add(gblObj.NumBillID);
    //            withRqDAO.UpdateSanctionOrder(arA);
    //            ///////////////////////////

    //            ///////////////////////////
    //        }
    //    }
    //}
    //private void CreateSanctionOrder()
    //{
    //    for (int i = 0; i < gvSanction.Rows.Count; i++)
    //    {
    //        ArrayList arr = new ArrayList();
    //        GridViewRow gdvrw = gvSanction.Rows[i];
    //        CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
    //        Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
    //        Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
    //        Label lblEmpIdAss = (Label)gdvrw.FindControl("lblEmpId");

    //        if (chkAppAss.Checked == true)
    //        {
    //            arr.Add(Convert.ToInt16(lblTrnIdAss.Text));
    //            arr.Add("Order");
    //            arr.Add(Convert.ToInt64(lblEmpIdAss.Text));
    //            arr.Add(Convert.ToInt16(lblTrnTypeAss.Text));
    //            arr.Add(Convert.ToInt16(Convert.ToInt32(Session["intUserId"])));
    //            withRqDAO.CreateSanctionOrder(arr);
    //        }
    //    }
    //}
    private void CreateSanctionOrder()
    {
        ArrayList arRpt = new ArrayList();
        for (int i = 0; i < gvSanction.Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            GridViewRow gdvrw = gvSanction.Rows[i];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");
            Label lblEmpIdAss = (Label)gdvrw.FindControl("lblEmpId");

            if (chkAppAss.Checked == true)
            {
                arr.Add(Convert.ToInt64(lblTrnIdAss.Text));
                arr.Add("Order");
                arr.Add(Convert.ToInt64(lblEmpIdAss.Text));
                arr.Add(Convert.ToInt16(lblTrnTypeAss.Text));
                arr.Add(Convert.ToInt16(Convert.ToInt32(Session["intUserId"])));
                withRqDAO.CreateSanctionOrder(arr);
                Session["NumServiceTrnID"] = Convert.ToInt64(lblTrnIdAss.Text);

                arRpt.Add(lblTrnIdAss.Text.ToString().Trim());
                string arry = String.Join(",", ((string[])arRpt.ToArray(typeof(String))));
                Response.Redirect("Reportviewer.aspx?ReportID=1&sorder=" + arry);
            }
        }
    }

    private void CreateBill()
    {
        DataSet dsB = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add("BillNo");
        arr.Add(DateTime.Now.ToShortDateString());
        arr.Add(FindGridTotalChecked());
        arr.Add(Convert.ToInt32(Session["intUserId"]));
        arr.Add(Convert.ToInt32(Session["intDTreasuryID"]));
        arr.Add(1);
        arr.Add(DBNull.Value);
        arr.Add("");    //Remarks
        arr.Add(1);     //Source
        arr.Add(1);  //count
        arr.Add(1);  //FlgBillType

        dsB = withRqDAO.CreateBill(arr);
        if (dsB.Tables[0].Rows.Count > 0)
        {
            gblObj.NumBillID = Convert.ToInt64(dsB.Tables[0].Rows[0].ItemArray[0]);
        }
        //arRpt.Add(gblObj.NumBillID);
        //string arry = String.Join(",", ((string[])arRpt.ToArray(typeof(String))));
        //Response.Redirect("Reportviewer.aspx?ReportID=2");
    }

    private double FindGridTotalChecked()
    {
        double totAmt = 0;
        for (int i = 0; i < gvBill.Rows.Count; i++)
        {
            GridViewRow gdvrw = gvBill.Rows[i];
            CheckBox chkAss = (CheckBox)gdvrw.FindControl("chkApp");

            if (chkAss.Checked == true)
            {
                if (gvBill.Rows[i].Cells[5].Text != "&nbsp;" && gvBill.Rows[i].Cells[5].Text != "")
                {
                    totAmt = totAmt + Convert.ToDouble(gvBill.Rows[i].Cells[5].Text);
                }
            }
        }
        return totAmt;
    }
    private void UpdateFlagApproval(GridView gdv)
    {
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("lblTrnId");
            Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");

            if (chkAppAss.Checked == true)
            {
                //// Approval flag 
                appObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]) ;
                appObj.NumTrnID = Convert.ToInt64(lblTrnIdAss.Text);
                appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                appObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
                appObj.ChvRem="";
                appDao.CreateApproval(appObj);

                //////////Clear from Returned files/////////////////////
                if (Convert.ToInt16(Session["intTrnTypeStage"]) == 4)
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        gblObj.MsgBoxOk("Under processing!", this);
        if (Convert.ToInt16(Session["intTrnTypeStage"]) == 2)
        {
            gblObj.MsgBoxOk("Print out Sanction Order", this);
            //string arry = String.Join(",", ((string[])arRpt.ToArray(typeof(String))));
            //Response.Redirect("Reportviewer.aspx?ReportID=1&sorder=" + arry);
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 2)
        {
            gblObj.MsgBoxOk("Print out Sanction Bill", this);
        }
        else if (Convert.ToInt16(Session["intTrnTypeStage"]) == 3)
        {
            gblObj.MsgBoxOk("Print out Acquittance", this);
        }
    }
    protected void txtDtW_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvAcqutt.Rows.Count; i++)
        {
            GridViewRow gvRw = gvAcqutt.Rows[i];
            TextBox txtDtWAss = (TextBox)gvRw.FindControl("txtDtW");
            if (txtDtWAss.Text != "")
            {
                if (Convert.ToDateTime(txtDtWAss.Text).Date > DateTime.Now.Date)
                {
                    txtDtWAss.Text = "";
                    break;
                }
            }
        }
    }
}
