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

public partial class Contents_AoApprovalNewCurr : System.Web.UI.Page
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
            if (Convert.ToInt16(Session["intDTreasuryId"]) > 0 && Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intMonthIdApp"]) > 0)
            {
                FillOnBack();
            }
            else
            {
                Session["intTrnType"] = 38;
            }
            //Session["intYearIdApp"] = 0;
            //Session["intMonthIdApp"] = 0;
        }
    }
    private void FillOnBack()
    {
        ddlYear.SelectedValue = Session["intYearIdApp"].ToString();
        ddlMonth.SelectedValue = Session["intMonthIdApp"].ToString();
        //if (Convert.ToInt16(Session["intTrnType"]) == 38)
        if (Convert.ToInt16(Session["intTrnType"]) == 38 || Convert.ToInt16(Session["intTrnType"]) == 0)
        {
            rdTrn.Items[0].Selected = true;
        }
        else
        {
            rdTrn.Items[1].Selected = true;
        }
        FillGrid(Convert.ToInt16(Session["intTrnType"]));
    }
    private void Initialsettings()
    {
        DataSet ds2 = new DataSet();
        ds2 = genDAO.GetYearOnLine();
        gblObj.FillCombo(ddlYear, ds2, 1);

        DataSet ds1 = new DataSet();
        ds1 = genDAO.GetMonth();
        gblObj.FillCombo(ddlMonth, ds1, 1);

        SetGridDefault();
        SetButtonCap();

        //Session["intTrnTypeApp"] = 1;

        //Session["
        //if (gblObj.IntTreIdAO > 0)
        //{
        //    FillOnBack();
        //}
        //else
        //{
        //    SelectionRadio();
        //}

        //if (Convert.ToInt16(gblObj.IntTreIdAO) > 0)
        //{
        //    ddlYear.SelectedValue = gblObj.IntYearIdAo.ToString();
        //    ddlMonth.SelectedValue = gblObj.IntMonthIdAo.ToString();
        //    ddlDistrict.SelectedValue = gblObj.IntDistAO.ToString();
        //    FillDTreasury();
        //    ddlDistricttre.SelectedValue = gblObj.IntTreIdAO.ToString();
        //    FillGridView();
        //}
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
        rdTrn.Items[0].Value = "1";
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvTreasuryName");
        ar.Add("Status");
        ar.Add("intDTreasuryId");
        ar.Add("intYearId");
        ar.Add("intMonthId");
        gblObj.SetGridDefault(gdvAOApprov, ar);
    }
    protected void rdTrn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdTrn.Items[0].Selected == true)
        {
            Session["intTrnType"] = 38;
            //Session["intTrnTypeApp"] = 1;
        }
        else
        {
            Session["intTrnType"] = 39;
            //Session["intTrnTypeApp"] = 2;
        }
        if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intYearIdApp"]) > 0)
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
        if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intMonthIdApp"]) > 0)
        {
            FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
        }
    }
    //private void FillGrid(int intTrnTypeStage)
    //{
    //    DataSet dsApp = new DataSet();
    //    ArrayList ar=new ArrayList();
    //    ar.Add(Convert.ToInt16(Session["intYearIdApp"]));
    //    ar.Add(Convert.ToInt16(Session["intMonthIdApp"]));

    //    if (Convert.ToInt16(Session["intTrnType"]) == 38)
    //    {
    //        ar.Add(1);
    //    }
    //    else
    //    {
    //        ar.Add(2);
    //    }

    //    dsApp = aoRecorrDAO.GetApprovalCurr(ar); 
    //    if (dsApp.Tables[0].Rows.Count > 0)
    //    {
    //        gdvAOApprov.DataSource = dsApp;
    //        gdvAOApprov.DataBind();
    //        for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
    //        {
    //            GridViewRow gvRw = gdvAOApprov.Rows[i];
    //            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
    //            Label lblDistAss = (Label)gvRw.FindControl("lblDist");
    //            if (intTrnTypeStage == 1)       //Approval
    //            {
    //                if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "1")
    //                {
    //                    chkAppAss.Checked = true;
    //                    chkAppAss.Enabled = false;
    //                }
    //                else
    //                {
    //                    chkAppAss.Enabled = true;
    //                    chkAppAss.Checked = false;
    //                }
    //            }                           //Recorrection
    //            else
    //            {
    //                if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "2" || dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "0")
    //                {
    //                    chkAppAss.Checked = true;
    //                    chkAppAss.Enabled = false;
    //                }
    //                else
    //                {
    //                    chkAppAss.Enabled = true;
    //                    chkAppAss.Checked = false;
    //                }
    //            }
    //            lblDistAss.Text = dsApp.Tables[0].Rows[i].ItemArray[1].ToString();
    //        }
    //    }
    //    else
    //    {
    //        SetGridDefault();
    //    }
    //}
    private void FillGrid(int intTrnTypeStage)
    {
        DataSet dsApp = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdApp"]));
        ar.Add(Convert.ToInt16(Session["intMonthIdApp"]));

        if (Convert.ToInt16(Session["intTrnType"]) == 38)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }

        //if (rdTrn.Items[0].Selected == true)
        //{
        //    ar.Add(1);
        //}
        //else
        //{
        //    ar.Add(2);
        //}
        dsApp = aoRecorrDAO.GetApprovalCurr(ar);
        if (dsApp.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = dsApp;
            gdvAOApprov.DataBind();
            for (int i = 0; i < dsApp.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvAOApprov.Rows[i];
                CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
                Label lblDistAss = (Label)gvRw.FindControl("lblDist");
                if (intTrnTypeStage == 1)       //Approval
                {
                    if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "1")
                    {
                        chkAppAss.Checked = true;
                        chkAppAss.Enabled = false;
                    }
                    else
                    {
                        if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "10" || dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "2")
                        {
                            chkAppAss.Enabled = true;
                            chkAppAss.Checked = false;
                        }
                        else
                        {
                            chkAppAss.Enabled = false;
                            chkAppAss.Checked = false;
                        }
                    }
                }                           //Recorrection
                else
                {
                    if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "2" || dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "0")
                    {
                        chkAppAss.Checked = false;
                        chkAppAss.Enabled = false;
                    }
                    else
                    {
                        if (dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "10" || dsApp.Tables[0].Rows[i].ItemArray[2].ToString() == "2")
                        {
                            chkAppAss.Enabled = false;
                            chkAppAss.Checked = false;
                        }
                        else
                        {
                            chkAppAss.Enabled = true;
                            chkAppAss.Checked = false;
                        }
                    }
                }
                lblDistAss.Text = dsApp.Tables[0].Rows[i].ItemArray[1].ToString();
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
        if (gblObj.CheckValidMonth(Convert.ToInt16(Session["intYearIdApp"]), Convert.ToInt16(Session["intMonthIdApp"])) == true)
        {
            gdvAOApprov.Enabled = true;
            if (Convert.ToInt16(Session["intYearIdApp"]) > 0 && Convert.ToInt16(Session["intMonthIdApp"]) > 0)
            {
                FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid month", this);
            gdvAOApprov.Enabled = false;
        }
    }
    //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    protected void btnOK_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvAOApprov.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt16(Session["intYearIdApp"]));
            ar.Add(Convert.ToInt16(Session["intMonthIdApp"]));
            GridViewRow gvRw = gdvAOApprov.Rows[i];
            CheckBox chkAppAss = (CheckBox)gvRw.FindControl("chkApp");
            Label lblDistAss = (Label)gvRw.FindControl("lblDist");
            if (chkAppAss.Checked == true)
            {
                ar.Add(Convert.ToInt16(lblDistAss.Text));
                if (rdTrn.Items[0].Selected == true)
                {
                    ar.Add(1);
                }
                else
                {
                    ar.Add(2);
                }
                ar.Add(Convert.ToInt16(Session["intTrnTypeStage"]));
                ar.Add(1);
                aoRecorrDAO.UpdateflagApp(ar);
            }
        }
        gblObj.MsgBoxOk("Updated", this);
        FillGrid(Convert.ToInt16(Session["intTrnTypeStage"]));
    }
}

