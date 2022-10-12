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
using System.Collections.Generic;
using KPEPFClassLibrary;
public partial class Contents_StChange : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    Chalan ch;
    ChalanDAO chDao;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["intTreasuryId"]) > 0)
            {
                Session["intTrearyId"] = Convert.ToInt32(Request.QueryString["intTreasuryId"]);
                FillDT();
                ddlDT.SelectedValue = Convert.ToInt16(Session["IntTreIdRemi"]).ToString();
                //SetRadioBtn();
                FillGrid1();
                if (Convert.ToInt16(Session["flg"]) > 0)
                {
                    FillGrid2(Convert.ToInt16(Session["flg"]));
                }
                SetColorChange(Convert.ToInt32(Request.QueryString["SlNo"]));
                SetRadioBtn();
            }
            else if (Convert.ToInt32(Request.QueryString["intOrderId"]) > 0)
            {
                Session["intOrderId"] = Convert.ToInt32(Request.QueryString["intOrderId"]);
                FillTxtsGO(Convert.ToInt16(Session["intOrderId"]));
                FillGridGO();
            }
            else if (Convert.ToInt32(Request.QueryString["intTreasuryIdA"]) > 0)    //GO
            {
                Session["intTrearyIdA"] = Convert.ToInt32(Request.QueryString["intTreasuryIdA"]);
                FillDT();
                FillDTType();
                FillTxts(Convert.ToInt16(Session["intTrearyIdA"]));
                ddlDTA.SelectedValue = Convert.ToInt16(Session["IntTreIdRemiA"]).ToString();
                //SetRadioBtn();
                FillGrid3();
                SetColorChangeA(Convert.ToInt32(Request.QueryString["SlNo"]));
            }
            else
            {
                FillDT();
                SetGridDefault();
                SetGridDefault2();
                //Session["flg"] = 2;
                SetRadioBtn();
                FillDTType();
                FillDistUpd();
            }
        }

    }
    private void FillDTType()
    {
        GenDao = new KPEPFGeneralDAO();
        DataSet ds2 = new DataSet();
        ds2 = GenDao.GetTType();
        gblObj.FillCombo(ddlTTypeA, ds2, 1);
    }
    private void FillDistUpd()
    {
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();
        DataSet ds = new DataSet();
        ds = GenDao.GetDistrict();
        gblObj.FillCombo(ddlDistUpd, ds, 1);

        DataSet dsy = new DataSet();
        dsy = GenDao.GetYearOnLine();
        gblObj.FillCombo(ddlYearUpd, dsy, 1);

        DataSet dsM = new DataSet();
        dsM = gen.GetMonth();
        gblObj.FillCombo(ddlMonthUpd, dsM, 1);
    }
    private void FillTxts(int TreasId)
    {
        gen = new GeneralDAO();
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(TreasId);
        ds = gen.GetTreasuryFromId(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtTNameA.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtCodeA.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtId.Text = TreasId.ToString();
            ddlTTypeA.SelectedValue = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        }
    }
    private void FillTxtsGO(int intOrderId)
    {
        GenDao = new KPEPFGeneralDAO();
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(intOrderId);
        ds = GenDao.GetGOTxts(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtGo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtOrderDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtEffectDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txtWith.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            txtGoId.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    private void SetRadioBtn()
    {
        if (Convert.ToInt16(Session["flg"]) == 1)
        {
            rdChecked.Items[1].Selected = true;
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)
        {
            rdChecked.Items[0].Selected = true;
        }
    }
    private void FillDT()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
       
        DataSet dsTreas = new DataSet();
     
        dsTreas = gen.GetDisTreasuryFull();
        gblObj.FillCombo(ddlDT, dsTreas, 1);
        gblObj.FillCombo(ddlDTA, dsTreas, 1);

        //ddlTTypeA
    }
    protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDT.SelectedIndex > 0)
        {
            Session["IntTreIdRemi"] = Convert.ToInt32(ddlDT.SelectedValue);
        }
        else
        {
            Session["IntTreIdRemi"] = 0;
        }
        FillGrid1();
        //FillGrid2(3); 
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvTreasuryName");
        //ar.Add("intTreasEntriesID");
        ar.Add("intTreasuryId");
        gblObj.SetGridDefault(gdvChalanS, ar);
       
    }
    private void SetGridDefaultGO()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvOrderNo");
        ar.Add("dtmDateOfOrder");
        ar.Add("DateOfEffect");
        ar.Add("DueDateForWith");
        ar.Add("intOrderId");
        
        gblObj.SetGridDefault(gdvGo, ar);

    }
    private void SetGridDefault2()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("intId");
        ar.Add("flgTreas");
        
        gblObj.SetGridDefault(gdvChalanLB, ar);

    }
    private void FillGrid1()
    {
        DataSet ds2 = new DataSet();
        gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();
        GenDao = new KPEPFGeneralDAO();

        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["IntTreIdRemi"]));
      
        
        ds2 = GenDao.getsubTreasury(arr);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvChalanS.DataSource = ds2;
            gdvChalanS.DataBind();
        }
        else
        {
            SetGridDefault();
        }
    }
    private void FillGrid2(int tp)
    {
        DataSet ds2 = new DataSet();
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        ArrayList arr = new ArrayList();
        //ArrayList arDist = new ArrayList();
        
        arr.Add(Convert.ToInt32(Session["intTrearyId"]));
        //arDist.Add(Convert.ToInt32(Session["IntTreIdRemi"]));

        if (tp == 1)
        {
            ds2 = gen.GetLBTreasWiseMapped(arr);
            
        }
        else if (tp == 2)
        {
            ds2 = gen.GetLBTreasWise(arr);
        }
        //else
        //{
        //    ds2 = gen.GetLBTreasWiseAll(arDist);
        //}

        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvChalanLB.DataSource = ds2;
            gdvChalanLB.DataBind();
            for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
            {
                GridViewRow gvr = gdvChalanLB.Rows[i];
                CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
                if (ds2.Tables[0].Rows[i].ItemArray[3].ToString() == "1")
                {
                    chkApp.Checked = true;
                }
                else
                {
                    chkApp.Checked = false ;
                }
            }
        }
        else
        {
            SetGridDefault2();
        }
    }
    protected void rdChecked_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        Session["flg"] = rdChecked.SelectedValue;
        int dd = Convert.ToInt16(Session["flg"]);
        if (Convert.ToInt32(Request.QueryString["intTreasuryId"]) > 0)
        {
            if (Convert.ToInt16(Session["flg"]) == 1)           //Show all
            {
                FillGrid2(1);
            }
            else if (Convert.ToInt16(Session["flg"]) == 2)       // Only checked    
            {
                FillGrid2(2);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Select Subtreasury!!!", this);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        ArrayList ar1 = new ArrayList();
        ar1.Add(Convert.ToInt64(Session["intTrearyId"]));
        gen.UpdateLBTreasuryNull(ar1);

        for (int i = 0; i < gdvChalanLB.Rows.Count; i++)
        {
            ArrayList ar = new ArrayList();
            GridViewRow gvr = gdvChalanLB.Rows[i];
            Label lblId = (Label)gvr.FindControl("lblId");
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            
            if (chkApp.Checked == true)
            {
                ar.Add(Convert.ToInt64(lblId.Text));
                ar.Add(Convert.ToInt64(Session["intTrearyId"]));
                gen.UpdateLBTreasury(ar);
            }
        }
        gblObj.MsgBoxOk("Saved!", this);
        FillGrid2(2);
    }
    private void SetColorChange(int rw)
    {
        gdvChalanS.Rows[rw - 1].BackColor = System.Drawing.Color.Bisque;
    }
    private void SetColorChangeA(int rw)
    {
        gdvTAdd.Rows[rw - 1].BackColor = System.Drawing.Color.Bisque;
    }
    protected void ddlDTA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDTA.SelectedIndex > 0)
        {
            Session["IntTreIdRemiA"] = Convert.ToInt32(ddlDTA.SelectedValue);
            FillGrid3();
            ClearTexts();
        }
        else
        {
            Session["IntTreIdRemiA"] = 0;
        }
    }
    private void ClearTexts()
    {
        txtTNameA.Text = "";
        txtCodeA.Text = "";
    }
    protected void btnSaveA_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        ArrayList arr = new ArrayList();

        //if (Convert.ToInt16(txtId.Text) > 0 && Convert.ToInt16(Session["IntTreIdRemiA"]) > 0 && txtTNameA.Text.ToString() != "")
        if (Convert.ToInt16(Session["IntTreIdRemiA"]) > 0 && txtTNameA.Text.ToString() != "")
        {
            arr.Add(Convert.ToInt16(txtId.Text));
            arr.Add(Convert.ToInt16(Session["IntTreIdRemiA"]));
            arr.Add(txtCodeA.Text.ToString());
            arr.Add(txtTNameA.Text.ToString());
            gen.AddTreasury(arr);
            gblObj.MsgBoxOk("Added!", this);
            FillGrid3();
        }
    }
    private void FillGrid3()
    {
        DataSet ds3 = new DataSet();
        gblObj = new clsGlobalMethods();
        ChalanDAO chDao = new ChalanDAO();
        GenDao = new KPEPFGeneralDAO();

        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["IntTreIdRemiA"]));
        ds3 = GenDao.getsubTreasury(arr);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            gdvTAdd.DataSource = ds3;
            gdvTAdd.DataBind();
        }
        else
        {
            SetGridDefault3();
        }
    }
    private void SetGridDefault3()
    {
        gblObj = new clsGlobalMethods();

        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvTreasuryName");
        //ar.Add("intTreasEntriesID");
        ar.Add("intTreasuryId");
        gblObj.SetGridDefault(gdvTAdd, ar);

    }
    protected void btnDelT_Click(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        for (int i = 0; i < gdvChalanS.Rows.Count; i++)
        {
            ArrayList arr = new ArrayList();
            GridViewRow gvr = gdvChalanS.Rows[i];
            CheckBox chkAppT = (CheckBox)gvr.FindControl("chkAppT");
            Label lblTId = (Label)gvr.FindControl("lblTId");
            if (chkAppT.Checked == true)
            {
                arr.Add(Convert.ToInt16(lblTId.Text));
                gen.DelTreasury(arr);
            }
        }
        FillGrid1();
    }
    protected void btnGOAdd_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        ArrayList arr = new ArrayList();
        string dt = "";
        if (txtGo.Text.ToString() != "" && txtEffectDate.Text.ToString() != "" && txtOrderDate.Text.ToString() != "")
        {
            arr.Add(Convert.ToInt16(txtGoId.Text));
            arr.Add(txtGo.Text.ToString());
            arr.Add(txtOrderDate.Text.ToString());
            arr.Add(txtEffectDate.Text.ToString());
            if (txtWith.Text.ToString() != "")
            {
                arr.Add(txtWith.Text.ToString());
            }
            else
            {
                dt = "01/01/2016";
                arr.Add(dt);
                //arr.Add(DateTime.Now.ToShortDateString());
            }
            arr.Add(1);
            GenDao.CreateGO(arr);
            gblObj.MsgBoxOk("Added!", this);
            FillGridGO();
        }
    }
    private void FillGridGO()
    {
        DataSet ds2 = new DataSet();
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();

        ds2 = GenDao.GetGOAll();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvGo.DataSource = ds2;
            gdvGo.DataBind();
        }
        else
        {
            //SetGridDefault();
        }
    }
    protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShowAll.Checked == true)
        {
            FillGridGO();
        }
        else
        {
            SetGridDefaultGO();
        }
    }
    private void ClearTxtsGo()
    {
        txtGo.Text = "";
        txtOrderDate.Text = "";
        txtEffectDate.Text = "";
        txtWith.Text = "";
        txtGoId.Text = "0";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearTxtsGo();
    }
    protected void btnUpdC_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        ArrayList arlb = new ArrayList();
        DataSet ds = new DataSet();
        gen = new GeneralDAO();
        gblObj = new clsGlobalMethods();
        ar.Add(Convert.ToInt16(ddlTreasUpd.SelectedValue));
        ar.Add(Convert.ToInt16(ddlLbUpd.SelectedValue));
        ar.Add(Convert.ToInt16(ddlYearUpd.SelectedValue));
        ar.Add(Convert.ToInt16(ddlMonthUpd.SelectedValue));
        if (chkAll.Checked == true)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        gen.UpdLBTreasYrWise(ar);

        ////////////////
        arlb.Add(Convert.ToInt16(ddlLbUpd.SelectedValue));
        arlb.Add(Convert.ToInt16(ddlTreasUpd.SelectedValue));
        gen.UpdateLBTreasury(arlb);
        /////////////////

        gblObj.MsgBoxOk("Updated!", this);
    }
    protected void ddlDistUpd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistUpd.SelectedValue) > 0)
        {
            Session["IntDistUpd"] = Convert.ToInt16(ddlDistUpd.SelectedValue);
            FillLb();
            FillTreas();
        }
        else
        {
            Session["IntDistUpd"] = 0;
        }
    }
    private void FillLb()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(Convert.ToInt16(Session["IntDistUpd"]));
        dsL = gen.GetLBGp(arL);
        gblObj.FillCombo(ddlLbUpd, dsL, 1);
    }
    private void FillTreas()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        DataSet dsL = new DataSet();
        ArrayList arL = new ArrayList();
        arL.Add(Convert.ToInt16(Session["IntDistUpd"]));
        dsL = gen.GetTreasury(arL);
        gblObj.FillCombo(ddlTreasUpd, dsL, 1);
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked == true)
        {
            ddlYearUpd.Enabled = false;
        }
        else
        {
            ddlYearUpd.Enabled = true;
        }
    }
}