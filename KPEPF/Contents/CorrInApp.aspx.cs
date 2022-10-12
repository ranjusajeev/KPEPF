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

public partial class Contents_CorrInApp : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    ApprovalDAO appD = new ApprovalDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();

        }
    }
    private void InitialSettings()
    {
        DataSet ds = new DataSet();
        ds = gen.getTransaction();
        gblObj.FillCombo(ddlSer, ds, 1);
        SetCtrlsUserWise();
        if (ddlSer.SelectedIndex == 0)
        {
            ddlSer.SelectedValue = Convert.ToInt16(Session["intTrnType"]).ToString();
            if (Convert.ToInt16(Session["intTrnType"]) == 1)
            {
                FillGrid(gdvInboxMS);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 2 ||Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
            {
                FillGrid(gdvInboxTA);
            }
        }
    }
    private void SetCtrlsUserWise()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 4)
        {
            ddlSer.Items[1].Enabled = false;     //MS
            ddlSer.Items[2].Enabled = true;     //TA
            ddlSer.Items[3].Enabled = false;    //NRA
            ddlSer.Items[4].Enabled = false;    //Membership
            ddlSer.Items[5].Enabled = false;    //Nom change
            ddlSer.Items[6].Enabled = false;    //TA to NRA conversion
            ddlSer.Items[7].Enabled = false;    //Closure
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            ddlSer.Items[1].Enabled = true;     //MS
            ddlSer.Items[2].Enabled = false;     //TA
            ddlSer.Items[3].Enabled = false;    //NRA
            ddlSer.Items[4].Enabled = true;    //Membership
            ddlSer.Items[5].Enabled = true;    //Nom change
            ddlSer.Items[6].Enabled = false;    //TA to NRA conversion
            ddlSer.Items[7].Enabled = false;    //Closure
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 7 || Convert.ToInt32(Session["intUserTypeId"]) == 8)
        {
            ddlSer.Items[1].Enabled = false;     //MS
            ddlSer.Items[2].Enabled = true;     //TA
            ddlSer.Items[3].Enabled = true;    //NRA
            ddlSer.Items[4].Enabled = false;    //Membership
            ddlSer.Items[5].Enabled = false;    //Nom change
            ddlSer.Items[6].Enabled = false;    //TA to NRA conversion
            ddlSer.Items[7].Enabled = false;    //Closure
        }
    }
    protected void ddlSer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSer.SelectedIndex > 0)
        {
            Session["intTrnType"] = Convert.ToInt16(ddlSer.SelectedValue);
            if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31)
            {
                FillGrid(gdvInboxTA);
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 1)
            {
                FillGrid(gdvInboxMS);
            }
        }
    }
    private void FillGrid(GridView gdv)
    {
        SetGridDefault(gdv);
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(ddlSer.SelectedValue));
        ds = gen.getAppFilesForRej(ar);
        gdv.DataSource = ds;
        gdv.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdv.Rows[i];
                Label txtNumTrnIdAss = (Label)gvRw.FindControl("txtNumTrnId");
                txtNumTrnIdAss.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            }
        }
    }
    private void SetGridDefault(GridView gdv)
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("dtmDateOfRequest");
        ar.Add("chvEngLBName");
        ar.Add("numTrnID");
        gblObj.SetGridDefault(gdv, ar);

    }
    //protected void Allchk_CheckedChanged(object sender, EventArgs e)
    //{

    //}
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 2)
        {
            UpdateApproval(gdvInboxTA);
            FillGrid(gdvInboxTA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 4)
        {
            UpdateApproval(gdvInboxNRA);
            FillGrid(gdvInboxNRA);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 1)
        {
            UpdateApproval(gdvInboxMS);
            FillGrid(gdvInboxMS);
        }
    }
    private void UpdateApproval(GridView gdv)
    {
        for (int k = 0; k < gdv.Rows.Count; k++)
        {
            GridViewRow gdvrw = gdv.Rows[k];
            CheckBox chkAppAss = (CheckBox)gdvrw.FindControl("chkApp");
            Label lblTrnIdAss = (Label)gdvrw.FindControl("txtNumTrnId");
            //Label lblTrnTypeAss = (Label)gdvrw.FindControl("lblTrnType");

            if (chkAppAss.Checked == true)
            {
                ArrayList ar = new ArrayList();
                ar.Add(Convert.ToInt64(lblTrnIdAss.Text.Trim()));
                ar.Add(Convert.ToInt16(Session["intTrnType"]));
                appD.UpdateFlgForRejection(ar);

                //Add to Table RejAfterApproval
                ArrayList arr = new ArrayList();
                arr.Add(Convert.ToInt64(lblTrnIdAss.Text.Trim()));
                arr.Add(Convert.ToInt16(Session["intTrnType"]));
                arr.Add(1);
                arr.Add(Convert.ToInt32(Session["intUserId"]));
                arr.Add("ss");
                appD.SaveRejAfterApproval(arr);
                //Add to Table RejAfterApproval
            }
        }
    }
}
