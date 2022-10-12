

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
using System.Text;

public partial class Contents_Localbody : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Convert.ToInt32(Request.QueryString["intTreasuryId"]) > 0)
            //{
            //    Session["intTreasuryIdMas"] = Convert.ToInt16(Request.QueryString["intTreasuryId"]);
            //    FillTLB();
            //}
            //else
            //{
                gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
                Initialsettings();
            //}
        }
    }
    private void FillTLB()
    {
        ArrayList ar = new ArrayList();
        DataSet dsL = new DataSet();
        ar.Add(Convert.ToInt32(Session["intTreasuryIdMas"]));
        dsL = gen.GetLBTreasWiseMapped(ar);
        if (dsL.Tables[0].Rows.Count > 0)
        {
            gdvTLb.DataSource = dsL;
            gdvTLb.DataBind();
        }
    }
    private void Initialsettings()
    {

        if (Convert.ToInt16(Session["intTrnType"]) == 17)
        {
            lblHead.Text = "Localbody";
            pnlLb.Visible = true;
            pnlT.Visible = false;
            pnlLBAdd.Visible = false;
            pnlQry.Visible = false;
            pnlSp.Visible = false;
            pnlSpParam.Visible = false;

            DataSet ds = new DataSet();
            ds = genDAO.GetDistrict();
            gblObj.FillCombo(ddlDist, ds, 1);

            DataSet ds1 = new DataSet();
            ds1 = genDAO.GetInstitutionType();
            gblObj.FillCombo(ddlLBType, ds1, 1);
            SetGridDefault();
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 18)
        {
            lblHead.Text = "Treasury";
            pnlLb.Visible = false;
            pnlT.Visible = true;
            pnlLBAdd.Visible = false;
            pnlQry.Visible = false;
            pnlSp.Visible = false;
            pnlSpParam.Visible = false;

            DataSet ds = new DataSet();
            ds = genDAO.GetDistrict();
            gblObj.FillCombo(ddlDistT, ds, 1);

            DataSet ds2 = new DataSet();
            ds2 = genDAO.GetTType();
            gblObj.FillCombo(ddlTType, ds2, 1);
            SetGridDefaultT();
            SetGridDefaultTLb();
            if (Convert.ToInt32(Request.QueryString["intTreasuryId"]) > 0)
            {
                Session["intTreasuryIdMas"] = Convert.ToInt16(Request.QueryString["intTreasuryId"]);
                FillTLB();
                ddlDistT.SelectedValue = Session["intDistIdTM"].ToString();
                ddlTType.SelectedValue = Session["intTType"].ToString();
                FillT();
            }

        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 19)
        {
            lblHead.Text = "Add Localbody ";
            pnlLb.Visible = false;
            pnlT.Visible = false;
            pnlLBAdd.Visible = true;
            pnlQry.Visible = false;
            pnlSp.Visible = false;
            pnlSpParam.Visible = false;

            DataSet ds = new DataSet();
            ds = genDAO.GetDistrict();
            gblObj.FillCombo(ddlDistLBAdd, ds, 1);

            DataSet ds2 = new DataSet();
            ds2 = genDAO.GetInstitutionType();
            gblObj.FillCombo(ddlLBTypeLBAdd, ds2, 1);

            SetGridDefaultLBAdd();
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 20)
        {
            lblHead.Text = "Update Localbody";
            pnlLb.Visible = false;
            pnlT.Visible = false;
            pnlLBAdd.Visible = true;
            pnlQry.Visible = false;
            pnlSp.Visible = false;
            pnlSpParam.Visible = false;

            DataSet ds = new DataSet();
            ds = genDAO.GetDistrict();
            gblObj.FillCombo(ddlDistT, ds, 1);

            DataSet ds2 = new DataSet();
            ds2 = genDAO.GetTType();
            gblObj.FillCombo(ddlTType, ds2, 1);
        }
        else if (Convert.ToInt16(Session["intTrnType"]) == 21)
        {
            lblHead.Text = "Result";
            pnlLb.Visible = false;
            pnlT.Visible = false;
            pnlLBAdd.Visible = false;
            pnlQry.Visible = true;
            pnlSp.Visible = true;
            pnlSpParam.Visible = true;
            //DataSet ds = new DataSet();
            //ds = genDAO.GetDistrict();
            //gblObj.FillCombo(ddlDistT, ds, 1);

            //DataSet ds2 = new DataSet();
            //ds2 = genDAO.GetTType();
            //gblObj.FillCombo(ddlTType, ds2, 1);
        }

    }

    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDist.SelectedIndex > 0)
        {
            Session["intDistIdLbM"] = Convert.ToInt16(ddlDist.SelectedValue);
        }
        SetGridDefault();
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("chvLBCode");
        ar.Add("chvTreasuryNameDisp");
        ar.Add("chvTreasuryNameD");
        gblObj.SetGridDefault(gdvLb, ar);
    }
    private void SetGridDefaultLBAdd()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("intDistID");
        ar.Add("chvTreasuryNameDisp");
        ar.Add("chvTreasuryNameD");

        ar.Add("intId");
        ar.Add("intDTreasuryId");
        ar.Add("intTreasuryId");
        ar.Add("intLBTypeID");
        

        gblObj.SetGridDefault(gdvLBAdd, ar);
    }
    private void SetGridDefaultT()
    {
        ArrayList art = new ArrayList();
        art.Add("SlNo");
        art.Add("chvTreasuryNameDisp");
        art.Add("chvTreasuryCode");
        art.Add("chvTreasuryName");
        art.Add("intTreasuryId");
        gblObj.SetGridDefault(gdvT, art);
    }
    private void SetGridDefaultTLb()
    {
        ArrayList art = new ArrayList();
        art.Add("SlNo");
        art.Add("intId");
        art.Add("chvEngLBName");
        gblObj.SetGridDefault(gdvTLb, art);
    }
    private void FillLb()
    {
        SetGridDefault();
        if (ddlDist.SelectedIndex > 0)
        {
            DataSet ds1 = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intDistIdLbM"]));
            arr.Add(Convert.ToInt16(ddlLBType.SelectedValue));
            ds1 = gen.GetLB4Mst(arr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gdvLb.DataSource = ds1;
                gdvLb.DataBind();
            }
        }
    }
    private void FillT()
    {
        SetGridDefaultT();
        if (ddlDistT.SelectedIndex > 0)
        {
            DataSet ds1 = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intDistIdTM"]));
            arr.Add(Convert.ToInt16(ddlTType.SelectedValue));
            ds1 = genDAO.GetTreasuryM(arr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gdvT.DataSource = ds1;
                gdvT.DataBind();
            }
        }
    }
    protected void ddlLBType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLBType.SelectedIndex > 0)
        {
            FillLb();
        }
    }
    protected void ddlDistT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistT.SelectedIndex > 0)
        {
            Session["intDistIdTM"] = Convert.ToInt16(ddlDistT.SelectedValue);
        }
        SetGridDefaultT();
    }
    protected void ddlTType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTType.SelectedIndex > 0)
        {
            Session["intTType"] = Convert.ToInt16(ddlTType.SelectedValue);
            FillT();
        }
    }
    protected void ddlDistLBAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistLBAdd.SelectedIndex > 0)
        {
            Session["intLBIdLBAdd"] = Convert.ToInt16(ddlDistLBAdd.SelectedValue);
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intLBIdLBAdd"]));
            ds = genDAO.GetTreasury(arr);
            gblObj.FillCombo(ddlTLBAdd, ds, 1);
        }
        else
        {
            Session["intLBIdLBAdd"] = 0;
        }
    }
    protected void btnLBAdd_Click(object sender, EventArgs e)
    {
        SaveToLB();
    }
    private void SaveToLB()
    {
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(ddlDistLBAdd.SelectedValue) > 0 && Convert.ToInt16(ddlLBTypeLBAdd.SelectedValue) > 0 && Convert.ToInt16(ddlTLBAdd.SelectedValue) > 0 && txtLBName.Text.ToString() != "")
        {
            ar.Add(txtLBName.Text.ToString());
            ar.Add(Convert.ToInt16(ddlLBTypeLBAdd.SelectedValue));
            ar.Add("code");
            ar.Add(Convert.ToInt16(ddlDistLBAdd.SelectedValue));
            ar.Add(Convert.ToInt16(ddlTLBAdd.SelectedValue));
            gen.AddLocalBody(ar);
            gblObj.MsgBoxOk("Saved!!!!", this);
        }
    }
    protected void ddlLBTypeLBAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLBTypeLBAdd.SelectedIndex > 0)
        {
            FillLBAdd();
        }
    }
    private void FillLBAdd()
    {
        SetGridDefaultLBAdd();
        if (ddlDistLBAdd.SelectedIndex > 0)
        {
            DataSet ds1 = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intLBIdLBAdd"]));
            arr.Add(Convert.ToInt16(ddlLBTypeLBAdd.SelectedValue));
            ds1 = gen.GetLB4Mst(arr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gdvLBAdd.DataSource = ds1;
                gdvLBAdd.DataBind();
            }
        }
    }
    protected void ddlTLBAdd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnQry_Click(object sender, EventArgs e)
    {
        DataSet dsR = new DataSet();
        string strScrip = "";
        strScrip = txtResult.Text.ToString();
        dsR = gen.GetResultFromString(strScrip);
        if (dsR.Tables[0].Rows.Count > 0)
        {
            ShowResult(dsR, GetCols(strScrip));
        }


        //DataSet dsR = new DataSet();
        //string strScrip = "";
        //string strScript = "";
        //strScrip = txtResult.Text.ToString();

        //strScript = "CREATE PROCEDURE GetResult AS BEGIN " + strScrip + " END";
        //// DELETE IF EXISTS /////
        //DropSP();
        //// DELETE IF EXISTS /////
        //dsR = gen.GetResult(strScript);
        //if (dsR.Tables[0].Rows.Count > 0)
        //{
        //    //dsCol = GetCols();
        //    ShowResult(dsR, GetCols(strScrip));
        //}
        //DropSP();

    }
    private DataSet GetCols(string strScrip)
    {
        //string tbl;
        //string tp;
        //int typ;
        //tp = InStr(strScrip, "*");
        ArrayList arc = new ArrayList();
        DataSet dsCol = new DataSet();
        arc.Add(strScrip);
        dsCol = gen.GetResultCol(arc);
        return dsCol;
    }
    private void ShowResult(DataSet dsR, DataSet dsc)
    {
        StringBuilder strHTML = new StringBuilder();

        //lblShow.Text = "";
        strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        strHTML.Append("<tr>");
        if (dsc.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<td >" + dsc.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
               
            }
           
        }
        if (dsR.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsR.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                for (int j = 0; j < dsR.Tables[0].Columns.Count; j++)
                {
                    strHTML.Append("<td>" + dsR.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML.Append("</tr>");
            }
        }

        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();




        //StringBuilder strHTML = new StringBuilder();

        ////lblShow.Text = "";
        //strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML.Append("<tr>");

        //if (dsR.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dsR.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML.Append("<tr>");
        //        for (int j = 0; j < dsR.Tables[0].Columns.Count; j++)
        //        {
        //            strHTML.Append("<td>" + dsR.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
        //        }
        //        strHTML.Append("</tr>");
        //    }
        //}

        //strHTML.Append("</table>");
        //lblShow.Text = strHTML.ToString();

    }
    private void DropSP()
    {
        gen.GetResultDelete();
    }
    private void DropSPUpd()
    {
        gen.GetResultDeleteUpd();
    }
    protected void btnSear_Click(object sender, EventArgs e)
    {
        FillSearch();
    }
    private void FillSearch()
    {
        ArrayList ar = new ArrayList();
        DataSet dsL = new DataSet();
        ar.Add(txtLBName.Text);
        dsL = gen.GetLB4Search(ar);
        if (dsL.Tables[0].Rows.Count > 0)
        {
            gdvLBAdd.DataSource = dsL;
            gdvLBAdd.DataBind();
        }
    }
    
    protected void rdLBSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdLBSearch.SelectedValue == "1")
        {
            btnSear.Enabled = true;
            btnLBAdd.Enabled = false;
            btnLBDel.Enabled = false;
            pnlUpd.Enabled = false;
        }
        else if (rdLBSearch.SelectedValue == "2")
        {
            btnLBAdd.Enabled = true;
            btnSear.Enabled = false;
            btnLBDel.Enabled = false;
            pnlUpd.Enabled = false;
        }
        else if (rdLBSearch.SelectedValue == "3")
        {
            btnLBAdd.Enabled = false;
            btnSear.Enabled = false;
            btnLBDel.Enabled = true;
            pnlUpd.Enabled = false;
        }
        else if (rdLBSearch.SelectedValue == "4")
        {
            btnLBAdd.Enabled = false;
            btnSear.Enabled = false;
            btnLBDel.Enabled = false;
            pnlUpd.Enabled = true;
        }
    }
    protected void btnLBDel_Click(object sender, EventArgs e)
    {

            DeleteRow();

    }
    private void DeleteRow()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(txtLBName.Text)); 
        ar.Add(Convert.ToInt16(txtLBIdn.Text));
        gen.DelLocalBody(ar);
        gblObj.MsgBoxOk("Deleted!!!!", this);
    }
    protected void btnSp_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        DataSet dsSp = new DataSet();
        string strSp = "";
        strSp = txtSp.Text.ToString();
        ar.Add(strSp);
        dsSp = gen.GetSp(ar);
        if (dsSp.Tables[0].Rows.Count > 0)
        {
            ShowResult2(dsSp);
        }
        
    }

    private void ShowResult2(DataSet dsR)
    {
        StringBuilder strHTML = new StringBuilder();
        txtShow.Text = "";
        strHTML.Append(dsR.Tables[0].Rows[0].ItemArray[0].ToString());
        txtShow.Text = strHTML.ToString();

    }
    protected void btnParam_Click(object sender, EventArgs e)
    {
        DataSet dsR = new DataSet();
        string strScrip = "";
        string strScript = "";
        strScrip = "exec "+txtParam.Text.ToString();
        DropSP();
        strScript = "CREATE PROCEDURE GetResult AS " + strScrip;
        dsR = gen.GetResult(strScript);
        if (dsR.Tables[0].Rows.Count > 0)
        {
            ShowResult3(dsR);
        }
        DropSP();
    }
    private void ShowResult3(DataSet dsR)
    {
        StringBuilder strHTML = new StringBuilder();

        //lblShow.Text = "";
        strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        strHTML.Append("<tr>");
        if (dsR.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsR.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                for (int j = 0; j < dsR.Tables[0].Columns.Count; j++)
                {
                    strHTML.Append("<td>" + dsR.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML.Append("</tr>");
            }
        }

        strHTML.Append("</table>");
        lblShow3.Text = strHTML.ToString();
    }
    protected void btnUpd_Click(object sender, EventArgs e)
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Convert.ToInt16(txtUpdId.Text));
        arr.Add(txtUpdName.Text);
        gen.UpdateLBName(arr);
        gblObj.MsgBoxOk("Updated!", this);
    }
    protected void txtUpdId_TextChanged(object sender, EventArgs e)
    {
        DataSet dsLo = new DataSet();
        dsLo = gen.GetLBFromId(Convert.ToInt16(txtUpdId.Text));
        if (dsLo.Tables[0].Rows.Count > 0)
        {
            lblName.Text = dsLo.Tables[0].Rows[0].ItemArray[2].ToString();
        }
        else
        {
            gblObj.MsgBoxOk("No Lb", this);
        }
    }
    protected void btnUpdT_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        string strScrip = "";
        string strScript = "";
        strScrip = txtResult.Text.ToString();

        strScript = "CREATE PROCEDURE GetResultUpd AS BEGIN " + strScrip + " END";
        // DELETE IF EXISTS /////
        DropSPUpd();
        // DELETE IF EXISTS /////
        gen.GetResultUpd(strScript,ar);
        DropSPUpd();
        gblObj.MsgBoxOk("Ok", this);
    }
}
