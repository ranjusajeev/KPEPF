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

public partial class Contents_AoApprovalAG : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    AORecorrection aoRecorr = new AORecorrection();
    AORecorrectionDAO aoRecorrDAO = new AORecorrectionDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));

            Initialsettings();
            if (Convert.ToInt16(Session["intYearIdAppAG"]) > 0 && Convert.ToInt16(Session["intMonthIdAppAG"]) > 0)
            {
                FillOnBack();
            }
            else
            {
                Session["intTrnType"] = 43;
            }
        }
    }
    private void FillOnBack()
    {
        ddlYear.SelectedValue = Convert.ToInt16(Session["intYearIdAppAG"]).ToString();
        FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
    }
    private void Initialsettings()
    {

        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetYear();
        gblObj.FillCombo(ddlYear, ds2, 1);

        SetGridDefault();
        SetButtonCap();
    }
    private void SetButtonCap()
    {
        if (Convert.ToInt16(Session["intTrnTypeStage"]) == 1)
        {
            btnOK.Text = "Approve";
            lblHead.Text = "AO Approval";
        }
        else
        {
            btnOK.Text = "Recorrect";
            lblHead.Text = "AO Recorrection";
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvMonth");
        ar.Add("Status");
        ar.Add("intYearId");
        ar.Add("intMonthId");
        gblObj.SetGridDefault(gdvAOApprov, ar);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIdAppAG"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdAppAG"] = 0;
        }
        //if (Convert.ToInt16(Session["intYearIdAppAG"]) >= 50)
        //{
        //    gblObj.MsgBoxOk("Select year <2013-14", this);
        //}
        if (Convert.ToInt16(Session["intYearIdAppAG"]) > 0)
        {
            FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        }
    }
    private void FillGrid(int flgApp)
    {
        DataSet dsApp = new DataSet();
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdAppAG"]);

        dsApp = aoRecorrDAO.SelectApprovalPDEAG(aoRecorr);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsApp;
            gdvAOApprov.DataBind();
            for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvAOApprov.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
                Label lblMonthAss = (Label)gvRw.FindControl("lblMonth");
                if (flgApp == 1)
                {
                    if (dsApp.Tables[0].Rows[i].ItemArray[4].ToString() == "1")
                    {
                        chkAppAss.Checked = true;
                        chkAppAss.Enabled = false;
                    }
                    else
                    {
                        chkAppAss.Enabled = true;
                        chkAppAss.Checked = false;
                    }
                }
                else
                {
                    if (dsApp.Tables[0].Rows[i].ItemArray[4].ToString() == "2")
                    {
                        chkAppAss.Checked = true;
                        chkAppAss.Enabled = false;
                    }
                    else
                    {
                        chkAppAss.Enabled = true;
                        chkAppAss.Checked = false;
                    }
                }
                lblMonthAss.Text = dsApp.Tables[0].Rows[i].ItemArray[2].ToString();
            }
        }
        else
        {
            SetGridDefault();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvAOApprov.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            Label lblMonthAss = (Label)gvRw.FindControl("lblMonth");
            if (chkAppAss.Checked == true)
            {

                aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdAppAG"]);
                aoRecorr.IntMonthID = Convert.ToInt16(lblMonthAss.Text);
                aoRecorr.FlgApp = Convert.ToInt16(Session["intTrnTypeStage"]);
            }
            aoRecorrDAO.UpdateApprovalPDEAG(aoRecorr);
            gblObj.MsgBoxOk("Updated!", this);
        }
        FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
    }
}
