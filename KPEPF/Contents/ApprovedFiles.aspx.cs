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

public partial class Contents_ApprovedFiles : System.Web.UI.Page
{
    MembershipDAO MemDAO = new MembershipDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();

    static int intTrnType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            //{
                gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //}
            InitialSettings();
        }
    }
    protected void gdvSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void FillDist()
    {
        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
    }
    private void InitialSettings()
    {
        ////Fill combo///////////
        DataSet dsT = new DataSet();
        dsT = gen.getTransaction();
        gblObj.FillCombo(ddlSer, dsT, 1);
        ////Fill combo///////////
        if (Convert.ToInt16(Session["intTrnType"]) == 50)
        {
            pnlAppFiles.Visible = true;
            pnlUpds.Visible = false;
            pnlPndng.Visible = false;
            lblHead.Text = "Fresh Accounts";
            //Label1.Visible = false;
            //ddlSer.Visible = false;
            //SetAppFilesDefault();
            FillAppFiles();
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 51)
        {
            pnlAppFiles.Visible = false;
            pnlUpds.Visible = true;
            pnlPndng.Visible = false;
            lblHead.Text = "Returned Files";
            if (Convert.ToInt16(Session["intLBTypeId"]) == 7)
            {
                pnlDist.Visible = true;
                FillDist();
            }
            else
            {
                pnlDist.Visible = false;
            }
            FillRetrnFiles();
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 52)
        {
            pnlAppFiles.Visible = false;
            pnlUpds.Visible = false;
            pnlPndng.Visible = true;
            lblHead.Text = "Pending Files";
            //Label1.Visible = false;
            //ddlSer.Visible = false;
            //SetPndngFilesDefault();
            //gdvPndng.Columns[3].HeaderText = "Chalan No.";
            //gdvPndng.Columns[4].HeaderText = "Chalan Date";
            FillPndngFiles();
        }
    }
    private void FillAppFiles()
    {
        SetAppFilesDefault();
        ArrayList arr = new ArrayList();
        //arr.Add(Convert.ToInt32(Session["intLBID"].ToString()));
        arr.Add(Convert.ToInt32(Convert.ToInt32(Session["intUserId"])));
        DataSet ds = new DataSet();
        ds = MemDAO.Displayapprovedfiles(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvSearch.DataSource = ds;
            gdvSearch.DataBind();
        }
        else
        {
            SetAppFilesDefault();
        }
    }
    private void FillRetrnFiles()
    {
        SetUpdsDefault();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["intLBId"]));
        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        DataSet ds = new DataSet();
        ds = gen.getRetrnFiles(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvUpds.DataSource = ds;
            gdvUpds.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvUpds.Rows[i];
                Label lblSlNoAss = (Label)gvRw.FindControl("lblSlNo");
                lblSlNoAss.Text = Convert.ToString(i + 1);
            }
        }
        else
        {
            SetUpdsDefault();
        }
    }
    private void FillPndngFiles()
    {
        SetPndngFilesDefault();
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt32(Session["intLBId"]));
        //ar.Add(intTrnType);
        ds = gen.getPendingFiles(ar);
        if (ds.Tables[ 0].Rows.Count > 0)
        {
            gdvPndng.DataSource = ds;
            gdvPndng.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvPndng.Rows[i];
                Label lblSlNoAss = (Label)gvRw.FindControl("lblSlNo");
                lblSlNoAss.Text = Convert.ToString(i + 1);
            }
        }
        else
        {
            SetPndngFilesDefault();
        }
    }
    private void SetAppFilesDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("numEmpId");
        ar.Add("chvName");
        ar.Add("chvEngDistName");
        ar.Add("chvEngLBName");
        ar.Add("dtmDOJ");
        gblObj.SetGridDefault(gdvSearch, ar);
    }
    private void SetUpdsDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("TrnType");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("dtmEntry");
        //ar.Add("dtmApproval");
        ar.Add("chvEngLBName");
        ar.Add("RtndBy");
        ar.Add("chvRem");
        gblObj.SetGridDefault(gdvUpds, ar);
    }
    private void SetPndngFilesDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("TrnType");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("dtmEntry");
        ar.Add("dtmApproval");
        ar.Add("chvEngLBName");
        ar.Add("Seat");

        gblObj.SetGridDefault(gdvPndng, ar);
    }
    protected void ddlSer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSer.SelectedIndex > 0)
        {
            intTrnType = Convert.ToInt16(ddlSer.SelectedValue);

            if (Convert.ToInt16(Session["intTrnType"]) == 51)
            {
                FillRetrnFiles();
            }
            else if (Convert.ToInt16(Session["intTrnType"]) == 52)
            {
                FillPndngFiles();
            }
        }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDist.SelectedIndex > 0)
        {
            Session["intDistR"] = Convert.ToInt16(ddlDist.SelectedValue);
            FillRetrnFilesDir();
        }
        else
        {
            Session["intDistR"] = 0;
        }
    }
    private void FillRetrnFilesDir()
    {
        SetUpdsDefault();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intDistR"]));
        arr.Add(1);
        DataSet ds = new DataSet();
        ds = gen.getRetrnFilesDir(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvUpds.DataSource = ds;
            gdvUpds.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvUpds.Rows[i];
                Label lblSlNoAss = (Label)gvRw.FindControl("lblSlNo");
                lblSlNoAss.Text = Convert.ToString(i + 1);
            }
        }
        else
        {
            SetUpdsDefault();
        }
    }
}
