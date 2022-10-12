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

public partial class Contents_Treasurrecosile : System.Web.UI.Page
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
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 16)
        {
            SetTrnTypeId();
            //Convert.ToInt16(Session["intTrnType"]) = 2;
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.GetStatusMapping3(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            Session["intTrnType"] = 2;
            FillSanction(gvTreasury);
        }
    }
    private void FillSanction(GridView gdv)
    {
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["intFlgAppInbx"]);
        //arrIn.Add(ddlLBName.SelectedValue);
        arrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        ds = withRqDAO.GetBillDet(arrIn);
        gdv.DataSource = ds;
        gdv.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label lblTrnTypeAss = (Label)gvRw.FindControl("lblTrnType");
                lblTrnTypeAss.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblTrnIdAss = (Label)gvRw.FindControl("lblTrnId");
                lblTrnIdAss.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();

                Label lblEmpIdAss = (Label)gvRw.FindControl("lblEmpId");
                lblEmpIdAss.Text = ds.Tables[0].Rows[i].ItemArray[8].ToString();
              // DataSet dsid =new DataSet();
               // ArrayList arr = new ArrayList();
               // arr.Add(lblTrnIdAss.Text);
               // dsid = withRqDAO.GetBillId (arr);
               // if (dsid.Tables[0].Rows.Count > 0)
               //{
               //    for (int j = 0; j < dsid.Tables[0].Rows.Count; j++)
               //    {
                       Label lblBillIdAss = (Label)gvRw.FindControl("lblBillId");
                       lblBillIdAss.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
               //    }
               //}
            }
            gdv.FooterRow.Cells[1].Text = "Total";
            gdv.FooterRow.Cells[2].Text = gblObj.FindGridTotal(gdv, 2).ToString();
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
        ar.Add("dtmBill");
        ar.Add("fltBillAmount");
        ar.Add("chvName");
        ar.Add("chvFileNo");
        ar.Add("fltAmtAdmissible");
        gblObj.SetGridDefault(gdv, ar);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnTypeStage"]) == 4)
        {
            UpdateFlagApproval(gvTreasury );
            UpdateBill(gvTreasury);
        }
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
                appObj.IntTrnTypeID =Convert.ToInt16(Session["intTrnType"]) ;
                appObj.NumTrnID = Convert.ToInt64(lblTrnIdAss.Text);
                appObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
                appObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
                appObj.ChvRem = "";
                appDao.CreateApproval(appObj);
            }
        }
       
    }
    private void UpdateBill(GridView gdv)
    {
        DataSet dsbill = new DataSet();
        ArrayList arr = new ArrayList();
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblBillIdAss = (Label)gdvrw.FindControl("lblBillId");
            TextBox txtRemAss = (TextBox)gdvrw.FindControl("txtRem");
            if (chkAppAss.Checked == true)
            {
                arr.Add(Convert.ToInt64(lblBillIdAss.Text));
                arr.Add(txtRemAss.Text);
                withRqDAO.UpdateBill(arr);
            }
        }
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Set IntTrnType for diff advances//
        SetTrnTypeId();
        DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        FillSanction(gvTreasury);
    }
    private void SetTrnTypeId()
    {
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
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        GridView gdv = gvTreasury;
        CheckBox chkAll1 = (CheckBox)gdv.HeaderRow.FindControl("chkAll");
        for (int i = 0; i < gvTreasury.Rows.Count; i++)
        {
            GridViewRow gvr = gvTreasury.Rows[i];
            CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp");
            if (chkAll1.Checked == true)
            {
                ChkApp1.Checked = true;
            }
            else
            {
                ChkApp1.Checked = false;
            }
        }
    }
}
