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

public partial class Contents_WithdrawalsCurr : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    GeneralDAO gen = new GeneralDAO();
    WithdrawalBDao wthd = new WithdrawalBDao();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["flgPageBackW"] = 4;
            if (Convert.ToInt32(Request.QueryString["intTreasEntriesID"]) > 0 && Convert.ToInt32(Request.QueryString["SlNo"]) > 0)
            {
                Session["intTreasEntriesID"] = Convert.ToInt32(Request.QueryString["intTreasEntriesID"]);
                SetLbls();
                FillCons();
                FillGrid1();

                //if (Convert.ToInt16(Session["flgChk"]) == 1)
                //{
                //    FillGrid2(3);
                //}
                //else
                //{
                //    FillGrid2(2);
                //}
                SetCtrls();
                SetColorChange(Convert.ToInt32(Request.QueryString["SlNo"]));

                if (Convert.ToInt16(Session["flg"]) == 1)
                {
                    FillGrid2(1);
                }
                else if (Convert.ToInt16(Session["flg"]) == 2)
                {
                    FillGrid2(2);
                }
                else
                {
                    FillGrid2(3);
                }
              //  SetSaveBtn();
            }
            else if (Request.QueryString["intTreasEntriesID"] != null)
            {
                Session["intTreasEntriesID"] = Convert.ToInt32(Request.QueryString["intTreasEntriesID"]);
               
                FillWithTxts();
                FillGrid1();
                SetGridDefault2();
                SetCtrls();
            }
            else if (Convert.ToInt32(Session["numTreasuryDIdWith"]) > 0)
            {
                SetLbls();
                FillCons();
                FillGrid1();
                SetGridDefault2();
                SetCtrls();
            }
            else
            {
                //InitialSettings();
                Session["SessionClear"] = 1;
                //Session["intSTreasDetId"] = 0; 
            }
        }
    }
    private void FillWithTxts()
    {
        mdlConfirm.Show();
        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        dsRem = wthd.GetTreasuryDetDataTxts(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            //lblSlNo.Text = Session["intSlno"].ToString();
            txtAccDt.Text = dsRem.Tables[0].Rows[0].ItemArray[1].ToString();
            txtTrnDt.Text = dsRem.Tables[0].Rows[0].ItemArray[2].ToString();
            txtAccAmt.Text = dsRem.Tables[0].Rows[0].ItemArray[3].ToString();
            
        }
    }
    private void SetCtrlsDisable()
    {
        btnSave.Enabled = false;
        txtAccDt.Enabled = false;
        txtTrnDt.Enabled = false;
        txtAccAmt.Enabled = false;
        btnNewChal.Enabled = false;
        lnkChal.Enabled = false;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    TextBox txtAmtAss = (TextBox)gdvrow.FindControl("txtAmt");

        //    txtAccDateAss.ReadOnly = true;
        //    txtAccDateAss.Enabled = false;
        //    txtTrnDateAss.ReadOnly = true;
        //    txtTrnDateAss.Enabled = false;
        //    txtAmtAss.ReadOnly = true;
        //}
    }
    private void SetCtrlsEnable()
    {
        //btnSave.Enabled = true;
        txtAccDt.Enabled = true;
        txtTrnDt.Enabled = true;
        txtAccAmt.Enabled = true;
        btnNewChal.Enabled = true;
        lnkChal.Enabled = true;
        //for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        //{
        //    GridViewRow gdvrow = gdvChalanS.Rows[i];
        //    TextBox txtAccDateAss = (TextBox)gdvrow.FindControl("txtAccDate");
        //    TextBox txtTrnDateAss = (TextBox)gdvrow.FindControl("txtTrnDate");
        //    txtAccDateAss.ReadOnly = false;
        //    txtTrnDateAss.ReadOnly = false;
        //}
    }
    private void SetCtrls()
    {
        if (Convert.ToInt16(Session["flgAppWithOnline"]) == 2 || Convert.ToInt16(Session["flgAppWithOnline"]) == 0 || Convert.ToInt16(Session["flgAppWithOnline"]) == 10)
        {
            
            SetCtrlsEnable();
        }
        else
        {
            SetCtrlsDisable();
        }
        if (Convert.ToInt16(Session["flg"]) == 1)
        {
            rdChecked.Items[0].Selected = true;
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)
        {
            rdChecked.Items[1].Selected = true;
        }
        else
        {
            rdChecked.Items[2].Selected = true;
        }
    }
    private void SetColorChange(int rw)
    {
        gdvChalanS.Rows[rw - 1].BackColor = System.Drawing.Color.HotPink;
        
    }
    private void FillGrid1()
    {

        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        dsRem = wthd.GetTreasuryDetData(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsRem;
            gdvChalanS.DataBind();
            gblObj.SetFooterTotalsGray(gdvChalanS, 3);
        }
        else
        {
            SetGridDefault1();
        }

    }
    //private void FillGrid2All(int tp)
    //{
    //    DataSet dsWithE = new DataSet();
    //    ArrayList are = new ArrayList();
    //    ArrayList ar1 = new ArrayList();
    //    are.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
    //    are.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
    //    are.Add(tp);
    //    dsWithE = wthd.GetBillPart(are);

    //    if (dsWithE.Tables[0].Rows.Count > 0)
    //    {
    //        gdvChalanLB.DataSource = dsWithE;
    //        gdvChalanLB.DataBind();
    //        gblObj.SetFooterTotals(gdvChalanLB, 2);

    //        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdvChalanLB.Rows[i];
    //            CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");

    //            Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
    //            lblChalIdC.Text = dsWithE.Tables[0].Rows[i].ItemArray[2].ToString();

    //            Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
    //            lblChalTp.Text = dsWithE.Tables[0].Rows[i].ItemArray[3].ToString();

    //            if (dsWithE.Tables[0].Rows[i].ItemArray[3].ToString() == "9")
    //            {
    //                gdvChalanLB.Rows[i].Cells[1].Enabled = false;
    //            }
    //            if (dsWithE.Tables[0].Rows[i].ItemArray[4].ToString() == "2")
    //            {
    //                chkAppAss.Checked = true;
    //            }
    //            else
    //            {
    //                chkAppAss.Checked = false;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        SetGridDefault2();
    //    }
    //}
    private void FillGrid2(int tp)
    {
        DataSet dsWithE = new DataSet();
        ArrayList are = new ArrayList();
        ArrayList ar1 = new ArrayList();
        are.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        are.Add(Convert.ToInt32(Session["intTreasEntriesID"]));
        are.Add(tp);
        dsWithE = wthd.GetBillPart(are);

        if (dsWithE.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = dsWithE;
            gdvChalanLB.DataBind();
            gblObj.SetFooterTotals(gdvChalanLB, 2);
            gblObj.SetFooterTotals(gdvChalanLB, 5);

            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvr.FindControl("chkApp");

                Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
                lblChalIdC.Text = dsWithE.Tables[0].Rows[i].ItemArray[2].ToString();

                Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
                lblChalTp.Text = dsWithE.Tables[0].Rows[i].ItemArray[3].ToString();

                if (dsWithE.Tables[0].Rows[i].ItemArray[3].ToString() == "9")
                {
                    gdvChalanLB.Rows[i].Cells[1].Enabled = false;
                }
                if (dsWithE.Tables[0].Rows[i].ItemArray[4].ToString() == "2")
                {
                    chkAppAss.Checked = true;
                }
                else
                {
                    chkAppAss.Checked = false;
                }

                ///// Misclassified /////////////
                if (dsWithE.Tables[0].Rows[i].ItemArray[3].ToString() == "9")
                {
                    gvr.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.White;
                }
                ///// Misclassified /////////////


                ///// amt mismatch /////////////
                if (dsWithE.Tables[0].Rows[i].ItemArray[1].ToString() != dsWithE.Tables[0].Rows[i].ItemArray[5].ToString())
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Green;
                    gvr.Cells[5].Font.Bold = true;
                }
                else
                {
                    gvr.Cells[5].ForeColor = System.Drawing.Color.Black;
                    gvr.Cells[5].Font.Bold = false;
                }
                ///// amt mismatch /////////////



                //if (tp == 1)
                //{
                //    if (dsWithE.Tables[0].Rows[i].ItemArray[4].ToString() == "2")
                //    {
                //        chkAppAss.Checked = true;
                //    }
                //    else
                //    {
                //        chkAppAss.Checked = false;
                //    }
                //}
                //else if (tp == 2)
                //{
                //    chkAppAss.Checked = true;
                //}
                //else
                //{
                //    if (dsWithE.Tables[0].Rows[i].ItemArray[4].ToString() == "2")
                //    {
                //        chkAppAss.Checked = true;
                //    }
                //    else
                //    {
                //        chkAppAss.Checked = false;
                //    }
                //}
            }
        }
        else
        {
            SetGridDefault2();
        }
    }
    private void SetGridDefault1()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("dtmAccDate");
        ar.Add("dtmTrnDate");
        ar.Add("fltChalanAmt");
        ar.Add("fltAmt");
        ar.Add("intTreasEntriesID");
        gblObj.SetGridDefault(gdvChalanS, ar);
    }
    private void SetGridDefault2()
    {
        ArrayList ar = new ArrayList();
        ar.Add("dtBillDate");
        ar.Add("fltBillAmount");
        ar.Add("numBillID");
        ar.Add("amtW");
        gblObj.SetGridDefault(gdvChalanLB, ar);
    }
    private void InitialSettings()
    {
        SetLbls();
        SetGridDefault1();
        SetGridDefault2();
    }
    private void SetLbls()
    {
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt64(Session["IntYearIdWit"]));
        YearVal.Text = gen.GetYearFromId(ar1);

        ArrayList ar2 = new ArrayList();
        ar2.Add(Convert.ToInt64(Session["IntMonthIdWit"]));
        Label2Val.Text = gen.GetMonthFromId(ar2);

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntTreIdWit"]));
        Label4Val.Text = gen.GetDisTreasuryFromId(ar);
    }
    private void FillCons()
    {
        DataSet dsCons = new DataSet();
        ArrayList ar = new ArrayList();

        ar.Add(Convert.ToInt64(Session["numTreasuryDIdWith"]));
        ar.Add(2);
        dsCons = wthd.GetAmtLBTot(ar);
        if (dsCons.Tables[0].Rows.Count > 0)
        {
            txtInt.Text = dsCons.Tables[0].Rows[0].ItemArray[3].ToString();
            txtAmt.Text = dsCons.Tables[0].Rows[0].ItemArray[2].ToString();
            txtRem.Text = dsCons.Tables[0].Rows[0].ItemArray[4].ToString();
            Session["flgAppWth"] = Convert.ToInt16(dsCons.Tables[0].Rows[0].ItemArray[5]);

            lblAmtBk.Text = dsCons.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {

    }
    //protected void btnSave3_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
    //    {
    //        ArrayList ar = new ArrayList();
    //        DataSet ds = new DataSet();
    //        GridViewRow gvr = gdvChalanLB.Rows[i];
    //        Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
    //        Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
    //        CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
    //        ar.Add(Convert.ToInt64(lblChalIdC.Text));
    //        if (chkApp.Checked == true)
    //        {
    //            ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
    //        }
    //        else
    //        {
    //            ar.Add(0);
    //        }
    //        ar.Add(Convert.ToInt16(lblChalTp.Text));
    //        chld.UpdateChalan_C(ar);
    //    }
    //    gblObj.MsgBoxOk("Saved!", this);
    //    FillChalanSNew();

    //    //for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
    //    //{
    //    //    ArrayList ar = new ArrayList();
    //    //    DataSet ds = new DataSet();
    //    //    GridViewRow gvr = gdvChalanLB.Rows[i];
    //    //    Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
    //    //    Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
    //    //    CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
    //    //    if (chkApp.Checked == true)
    //    //    {
    //    //        ar.Add(Convert.ToInt64(lblChalIdC.Text));
    //    //        ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
    //    //        ar.Add(Convert.ToInt64(lblChalTp.Text));
    //    //        chld.UpdateChalan_C(ar);
    //    //    }
    //    //}
    //    //gblObj.MsgBoxOk("Saved!", this);
    //    //FillChalanSNew();
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            GridViewRow gvr = gdvChalanLB.Rows[i];
            Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
            Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            ar.Add(Convert.ToInt64(lblChalIdC.Text));
            
            if (chkApp.Checked == true)
            {        
                ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));                     
            }
            else
            {
                ar.Add(0);
            }
            ar.Add(Convert.ToInt64(lblChalTp.Text));
            wthd.UpdateBill_C(ar);
        }
        FillGrid1New();
        gblObj.MsgBoxOk("Saved!", this);

    }
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
    //    {
    //        ArrayList ar = new ArrayList();
    //        DataSet ds = new DataSet();
    //        GridViewRow gvr = gdvChalanLB.Rows[i];
    //        Label lblChalIdC = (Label)gvr.FindControl("lblChalIdC");
    //        Label lblChalTp = (Label)gvr.FindControl("lblChalTp");
    //        CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
    //        if (chkApp.Checked == true)
    //        {
    //            ar.Add(Convert.ToInt64(lblChalIdC.Text));
    //            ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
    //            ar.Add(Convert.ToInt64(lblChalTp.Text));
    //            wthd.UpdateBill_C(ar);
    //        }
    //    }
    //    FillGrid1New();
    //    gblObj.MsgBoxOk("Saved!", this);
        
    //}
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    btnBack.PostBackUrl = "~/Contents/WithdrawalsEntry.aspx";
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnBack.PostBackUrl = "~/Contents/WithdrawalsEntry.aspx";
    }
    protected void lnkChal_Click(object sender, EventArgs e)
    {
        clearnewchalan();
        SetGridDefault2();
        mdlConfirm.Show();
    }
    public void clearnewchalan()
    {
        Session["intSlno"] = 0;
        txtAccDt.Text = "";
        txtTrnDt.Text = "";
        txtAccAmt.Text = "";
        Session["intTreasEntriesID"] = 0;
        //chkShow.Checked = false;
    }
    protected void btnNewChal_Click(object sender, EventArgs e)
    {
        if (CheckMandatoryAccDate() == true)
        {
            SaveAccDate();
            FillGrid1New();
            gblObj.MsgBoxOk("Saved successfully!!!", this);

        }
        else
        {
            gblObj.MsgBoxOk("Check  Consolidated grid!", this);
        }
    }
    private void FillGrid1New()
    {
        DataSet dsRem = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        dsRem = wthd.GetTreasuryDetData(ar);
        if (dsRem.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = dsRem;
            gdvChalanS.DataBind();
            gblObj.SetFooterTotals(gdvChalanS, 3);
        }
        else
        {
            SetGridDefault1();
        }
    }
    private void SaveAccDate()
    {
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["numTreasuryDIdWith"]));
        arr.Add(Convert.ToDateTime(txtAccDt.Text));


        arr.Add(Convert.ToDateTime(txtTrnDt.Text));
        arr.Add(Convert.ToDouble(txtAccAmt.Text));

        arr.Add(Convert.ToInt64(Session["intUserId"]));
        arr.Add(Convert.ToInt32(Session["intTreasEntriesId"]));

        wthd.SaveTreasuryDEntries(arr);
    }
    private Boolean CheckMandatoryAccDate()
    {
        gblObj = new clsGlobalMethods();

        Boolean flg = true;
        if (txtAccDt.Text.ToString() == "" || txtAccDt.Text.ToString() == null)
        {
            gblObj.MsgBoxOk("Must Select Accounting Date", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        if (txtTrnDt.Text.ToString() == "" || txtTrnDt.Text.ToString() == null)
        {
            gblObj.MsgBoxOk("Must Select Transaction Date", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    protected void btnDell_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        DataSet dsyr = new DataSet();
        if (Convert.ToInt64(Session["intTreasEntriesID"]) > 0)
        {
            ar.Add(Convert.ToInt64(Session["intTreasEntriesID"]));
            ar.Add(Convert.ToInt64(Session["intUserId"]));
            wthd.DelTreasuryDEntries(ar);
            gblObj.MsgBoxOk("Deleted ", this);
            //FillWithTxts();
            FillGrid1();
            FillGrid2(1);
        }
        else
        {
            gblObj.MsgBoxOk("Select data... ", this);
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {

    }
    protected void txtAccDt_TextChanged(object sender, EventArgs e)
    {
        //mdlConfirm.Show();
        if (gblObj.isValidDate(txtAccDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtAccDt, Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                txtAccDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date!!!", this);
        }

        mdlConfirm.Show();
    }
    protected void txtTrnDt_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.isValidDate(txtTrnDt, this) == true)
        {
            if (gblObj.CheckChalanDate(txtTrnDt, Convert.ToInt16(Session["IntYearIdWit"]), Convert.ToInt16(Session["IntMonthIdWit"])) == false)
            {
                gblObj.MsgBoxOk("Invalid Date!!!", this);
                txtTrnDt.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date!!!", this);
        }

        mdlConfirm.Show();
    }
    private void SetSaveBtn()
    {
        if (Convert.ToInt16(Session["flg"]) == 3 && Convert.ToInt32(Session["intTreasEntriesID"]) > 0)
        {
            btnSave.Enabled = true;
        }
        else
        {
            btnSave.Enabled = false;
        }
    }
    protected void rdChecked_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["flg"] = rdChecked.SelectedValue;
        //SetSaveBtn();
        if (Convert.ToInt16(Session["flg"]) == 1)           //Show all
        {
            FillGrid2(1);
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)       // Only checked    
        {
            if (Convert.ToInt32(Session["intTreasEntriesID"]) == 0)

            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillGrid2(2);
            }
        }
        else                                                // Only checked    
        {
            if (Convert.ToInt32(Session["intTreasEntriesID"]) == 0)
            {
                gblObj.MsgBoxOk("Select an item!!", this);
            }
            else
            {
                FillGrid2(3);
            }
        }
    }
}
