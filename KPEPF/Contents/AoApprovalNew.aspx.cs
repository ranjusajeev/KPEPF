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
using System.Data;
using KPEPFClassLibrary;


public partial class Contents_AoApprovalNew : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    AORecorrection aoRecorr = new AORecorrection();
    AORecorrectionDAO aoRecorrDAO = new AORecorrectionDAO();
    static string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            Initialsettings();
            if (Convert.ToInt16(Session["intDistIdApp"]) > 0)
            {
                FillOnBack();
            }
            else
            {
                Session["intTrnType"] = 36;
            }
            //Session["intYearIdApp"] = 0;
            //Session["intMonthIdApp"] = 0;
        }
    }
    private void FillOnBack()
    {
        ddlYear.SelectedValue = Session["intYearIdApp"].ToString();
        ddlMonth.SelectedValue = Session["intMonthIdApp"].ToString();
        if (Convert.ToInt16(Session["intTrnType"]) == 36 || Convert.ToInt16(Session["intTrnType"]) == 0)
        {
            rdTrn.Items[0].Selected = true;
            rdTrn.Items[1].Selected = false;
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 37)
        {
            rdTrn.Items[1].Selected = true;
            rdTrn.Items[0].Selected = false;
        }
        FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));

    }
    private void Initialsettings()
    {
        //Session["intTrnType"] = 1;
        //DataSet ds = new DataSet();
        //ds = genDAO.GetDistrict();
        //gblObj.FillCombo(ddlDistrict, ds, 1);

        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetYearPDE();
        gblObj.FillCombo(ddlYear, ds2, 1);

        DataSet ds1 = new DataSet();
        ds1 = genDAO.GetMonth();
        gblObj.FillCombo(ddlMonth, ds1, 1);

        SetGridDefault();
        SetButtonCap();
    }
    private void SetButtonCap()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 36)
        {
            btnOK.Text = "Approve";
            lblHead.Text = "AO Approval";
            str = "Approved";
        }
        else
        {
            btnOK.Text = "Recorrect";
            lblHead.Text = "AO Recorrection";
            str = "Rejected";
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngDistName");
        ar.Add("Status");
        ar.Add("intDistrictId");
        ar.Add("intYearId");
        ar.Add("intMonthId");
        gblObj.SetGridDefault(gdvAOApprov, ar);
    }
    protected void rdTrn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrn.Items[0].Selected == true)
        {
            Session["intTrnType"] = 36;
        }
        else
        {
            Session["intTrnType"] = 37;
        }
        if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intMonthIdApp"]) > 0)
        {
            FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIdApp"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYearIdApp"] = 0;
        }

        if (Convert.ToInt16(Session["intYearIdApp"]) > 49)
        {
            gblObj.MsgBoxOk("Select year <2013-14", this);
            ddlMonth.Enabled = false;
        }
        else
        {
            ddlMonth.Enabled = true;
        }
        if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intMonthIdApp"]) > 0)
        {
            FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        }
    }
    private void FillGrid(int intTrnTypeStage)
    {
        DataSet dsApp = new DataSet();
        aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdApp"]);
        aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdApp"]);
        if (rdTrn.Items[0].Selected == true)
        {
            aoRecorr.IntType = 1;
        }
        else
        {
            aoRecorr.IntType = 2;
        }

        dsApp = aoRecorrDAO.SelectApprovalPDE(aoRecorr);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsApp;
            gdvAOApprov.DataBind();
            for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvAOApprov.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
                Label lblDistAss = (Label)gvRw.FindControl("lblDist");
                if (intTrnTypeStage == 1)
                {
                    if (dsApp.Tables[0].Rows[i].ItemArray[6].ToString() == "1")
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
                    if (dsApp.Tables[0].Rows[i].ItemArray[6].ToString() == "2")
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
                lblDistAss.Text = dsApp.Tables[0].Rows[i].ItemArray[4].ToString();
            }
        }
        else
        {
            SetGridDefault();
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0)
        {
            Session["intMonthIdApp"] = Convert.ToInt16(ddlMonth.SelectedValue);
        }
        else
        {
            Session["intMonthIdApp"] = 0;
        }
        if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intYearIdApp"]) > 0)
        {
            FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        }
    }
    //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    protected void btnOK_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            GridViewRow gvRw = gdvAOApprov.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            Label lblDistAss = (Label)gvRw.FindControl("lblDist");
            if (chkAppAss.Checked == true)
            {

                aoRecorr.IntYearID = Convert.ToInt16(Session["intYearIdApp"]);
                aoRecorr.IntMonthID = Convert.ToInt16(Session["intMonthIdApp"]);
                aoRecorr.IntDistID = Convert.ToInt16(lblDistAss.Text);
                if (rdTrn.Items[0].Selected == true)
                {
                    aoRecorr.IntType = 1;
                }
                else
                {
                    aoRecorr.IntType = 2;
                }
                aoRecorr.FlgApp = Convert.ToInt16(Session["intTrnTypeStage"]);
                aoRecorrDAO.UpdateApprovalPDE(aoRecorr);
            }
            
        }
        FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        gblObj.MsgBoxOk(str, this);
    }
}
