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

public partial class Contents_Replicates : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj;
    DataSet dsc = new DataSet();

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
            gblObj = new clsGlobalMethods();
            DataSet dsyr = new DataSet();
            dsyr = GenDao.GetYearOnLine();
            gblObj.FillCombo(ddlYear, dsyr, 1);
            gblObj.FillCombo(ddlYear2, dsyr, 1);

            DataSet dsmnth = new DataSet();
            dsmnth = gen.GetMonth();
            gblObj.FillCombo(ddlMonth, dsmnth, 1);
            gblObj.FillCombo(ddlMonth2, dsmnth, 1);

            if (Convert.ToInt32(Request.QueryString["numBillId"]) > 0)
            {
                Session["numBillId"] = Convert.ToInt32(Request.QueryString["numBillId"]);
                Session["fltAmt"] = Convert.ToInt32(Request.QueryString["fltAmt"]);

                ddlYear2.SelectedValue = Session["IntYearId2"].ToString();
                ddlMonth2.SelectedValue = Session["IntMonthId2"].ToString();
                fillBill();
                fillWithDet();
            }
        }
    }
    protected void ddlSer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlSer.SelectedValue) > 0)
        {
            Session["intTbl"] = Convert.ToInt32(ddlSer.SelectedValue);
            if (Convert.ToInt32(Session["intTbl"]) == 1 || Convert.ToInt32(Session["intTbl"]) == 8)
            {
                ddlYear.Visible = true;
                ddlMonth.Visible = true;
                txtNo.Visible = false;
                txtDt.Visible = false;
                ddlDtr.Visible = false;
                Label1.Visible = false;
                lblNo.Visible = false;
                pnl1.Visible = false;
                pnl2.Visible = false;
                pnl3.Visible = false;
                btnShow.Visible = false;
            }
            else if (Convert.ToInt32(Session["intTbl"]) == 2 )
            {
                ddlYear.Visible = false;
                ddlMonth.Visible = false;
                FillDtCmb();

                txtNo.Visible = true;
                txtDt.Visible = true;
                ddlDtr.Visible = true;
                Label1.Visible = true;
                lblNo.Visible = true;
                pnl1.Visible = true;
                pnl2.Visible = true;
                pnl3.Visible = true;
                btnShow.Visible = true;
            }
            else
            {
                ddlYear.Visible = false ;
                ddlMonth.Visible = false ;
                txtNo.Visible = false;
                txtDt.Visible = false;
                ddlDtr.Visible = false;
                Label1.Visible = false;
                lblNo.Visible = false;
                pnl1.Visible = false;
                pnl2.Visible = false;
                pnl3.Visible = false;
                btnShow.Visible = false;
            }
        }
        else
        {
            Session["intTbl"] = 0;
        }
        //showData();
        //FillDdlCol();
    }
    private void FillDtCmb()
    {
        gblObj = new clsGlobalMethods();
        DataSet dst = new DataSet();
        AGDAO agd = new AGDAO();
        dst = agd.GetTreasury();
        gblObj.FillCombo(ddlDtr, dst, 1);
    }
    private void FillDdlCol()
    {
        gblObj = new clsGlobalMethods();
        gblObj.FillCombo(ddlCol, dsc, 1);
    }
    private void showData()
    {
        StringBuilder strHTML = new StringBuilder();
        
        lblShow.Text = "";
        
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intTbl"]));
        dsc = gen.GetReplicatesCol(ar);
        
        //DataSet ds = new DataSet();
        //ds = gen.GetReplicates(ar);

        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intTbl"]));
        if (Convert.ToInt16(Session["intTbl"]) == 1)
        {
            arr.Add(Convert.ToInt16(Session["IntYearId"]));
            arr.Add(Convert.ToInt16(Session["IntMonthId"]));
        }
        else
        {
            arr.Add(0);
            arr.Add(0);
        }
        DataSet ds = new DataSet();
        ds = gen.GetReplicates(arr);

        //System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        strHTML.Append("<tr>");
        //strHTML.Append("<td  border-style:solid;>" + "SLNO" + "</td><td>" + "NAME" + "</td><td>" + "No Of Records");
        if (dsc.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<td >" + dsc.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            }
        }
        

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    strHTML.Append("<td>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML.Append("</tr>");
            }
        }


        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();

    }
    protected void ddlCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        gblObj.MsgBoxOk("ss", this);
    }
    protected void btnPort_Click(object sender, EventArgs e)
    {
        lblShow.Visible = false;
        StringBuilder strHTML = new StringBuilder();

        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intTbl"]));
        dsc = gen.GetReplicatesCol(ar);

        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intTbl"]));
        if (Convert.ToInt16(Session["intTbl"]) == 1 || Convert.ToInt16(Session["intTbl"]) == 2 || Convert.ToInt16(Session["intTbl"]) == 8)
        {
            arr.Add(Convert.ToInt16(Session["IntYearId"]));
            arr.Add(Convert.ToInt16(Session["IntMonthId"]));
        }
        else
        {
            arr.Add(0);
            arr.Add(0);
        }
        DataSet ds = new DataSet();
        ds = gen.GetReplicates(arr);

        strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        strHTML.Append("<tr>");
        if (dsc.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<td >" + dsc.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            }
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    strHTML.Append("<td>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML.Append("</tr>");
            }
        }


        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Type", "application/vnd.ms-excel"); 
        Response.AddHeader("Content-Type", "application/vnd.ms-OpenDocument Spreadsheet"); 
        if (Convert.ToInt16(Session["intTbl"]) == 1)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://chalan.xlsx");
        } 
        else if (Convert.ToInt16(Session["intTbl"]) == 2)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://schedule.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 3)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://corrEntry.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 4)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://empMst.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 5)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://empTrn.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 6)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://empApp.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 7)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://lBody.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 8)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://Approval.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 9)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://Withdrawals.xlsx");
        }
        else if (Convert.ToInt16(Session["intTbl"]) == 10)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=c://Bill.xlsx");
        }
        Response.Write(strHTML.ToString());
        //this.EnableViewState = false;
        Response.Flush();
        Response.End();
    }
    protected void btnText_Click(object sender, EventArgs e)
    {
        showData();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["IntYearId"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["IntYearId"] = 0;
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth.SelectedValue) > 0)
        {
            Session["IntMonthId"] = Convert.ToInt16(ddlMonth.SelectedValue);
           
        }
        else
        {
            Session["IntMonthId"] = 0;
        }
    }
    private void showDataNoNdDt()
    {
        ArrayList arc = new ArrayList();
        arc.Add(Convert.ToInt16(2));
        DataSet dsc = new DataSet();
        dsc = gen.GetReplicatesCol(arc);

        ArrayList arc2 = new ArrayList();
        arc2.Add(Convert.ToInt16(1));
        DataSet dsc2 = new DataSet();
        dsc2 = gen.GetReplicatesCol(arc2);

        ArrayList arc3 = new ArrayList();
        arc3.Add(Convert.ToInt16(8));
        DataSet dsc3 = new DataSet();
        dsc3 = gen.GetReplicatesCol(arc3);

        StringBuilder strHTML = new StringBuilder();
        lblShow.Text = "";

        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(txtNo.Text));
        ar.Add(Convert.ToString(txtDt.Text));
        ar.Add(Convert.ToInt16(ddlDtr.SelectedValue));

        ds1 = gen.GetReplicatesSched(ar);

        strHTML.Append("<table border=1 style=border-style:Solid;border-width:1px; width=900px;>");
        strHTML.Append("<tr>");
        if (dsc.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<td >" + dsc.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            }
        }


        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                for (int j = 0; j < ds1.Tables[0].Columns.Count; j++)
                {
                    strHTML.Append("<td>" + ds1.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML.Append("</tr>");
            }
        }

        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();




        StringBuilder strHTML2 = new StringBuilder();
        lblShow2.Text = "";

        ds2 = gen.GetReplicatesSched2(ar);
        strHTML2.Append("<table border=1 style=border-style:Solid;border-width:1px; width=900px;>");
        strHTML2.Append("<tr>");
        if (dsc2.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc2.Tables[0].Rows.Count; i++)
            {
                strHTML2.Append("<td >" + dsc2.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            }
        }


        if (ds2.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                strHTML2.Append("<tr>");
                for (int j = 0; j < ds2.Tables[0].Columns.Count; j++)
                {
                    strHTML2.Append("<td>" + ds2.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML2.Append("</tr>");
            }
        }

        strHTML2.Append("</table>");
        lblShow2.Text = strHTML2.ToString();
        



        StringBuilder strHTML3 = new StringBuilder();
        lblShow3.Text = "";

        ds3 = gen.GetReplicatesSched3(ar);
        strHTML3.Append("<table border=1 style=border-style:Solid;border-width:1px; width=900px;>");
        strHTML3.Append("<tr>");
        if (dsc3.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsc3.Tables[0].Rows.Count; i++)
            {
                strHTML3.Append("<td >" + dsc3.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            }
        }


        if (ds3.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                strHTML3.Append("<tr>");
                for (int j = 0; j < ds3.Tables[0].Columns.Count; j++)
                {
                    strHTML3.Append("<td>" + ds3.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                strHTML3.Append("</tr>");
            }
        }

        strHTML3.Append("</table>");
        lblShow3.Text = strHTML3.ToString();

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

        showDataNoNdDt();

        //StringBuilder strHTML = new StringBuilder();
        //StringBuilder strHTML2 = new StringBuilder();
        //StringBuilder strHTML3 = new StringBuilder();
        //DataSet ds = new DataSet();
        //DataSet ds2 = new DataSet();
        //DataSet ds3 = new DataSet();
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt16(txtNo.Text));
        //ar.Add(Convert.ToString(txtDt.Text));
        //ar.Add(Convert.ToInt16(ddlDtr.SelectedValue));

        //ds = gen.GetReplicatesSched(ar);
        //strHTML.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML.Append("<tr>");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML.Append("<td >" + "</td>");
        //    }
        //}

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML.Append("<tr>");
        //        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
        //        {
        //            strHTML.Append("<td>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
        //        }
        //        strHTML.Append("</tr>");
        //    }
        //}


        //ds2 = gen.GetReplicatesSched2(ar);
        //strHTML2.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML2.Append("<tr>");
        //strHTML2.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML2.Append("<tr>");
        //if (ds2.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML2.Append("<td >" + ds2.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
        //    }
        //}

        //if (ds2.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML2.Append("<tr>");
        //        for (int j = 0; j < ds2.Tables[0].Columns.Count; j++)
        //        {
        //            strHTML2.Append("<td>" + ds2.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
        //        }
        //        strHTML2.Append("</tr>");
        //    }
        //}



        //ds3 = gen.GetReplicatesSched3(ar);
        //strHTML3.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML3.Append("<tr>");
        //strHTML3.Append("<table border=1 style=border-style:Solid;border-width:3px; width=400px;>");
        //strHTML3.Append("<tr>");
        //if (ds3.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML3.Append("<td >" + ds3.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
        //    }
        //}

        //if (ds3.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML3.Append("<tr>");
        //        for (int j = 0; j < ds3.Tables[0].Columns.Count; j++)
        //        {
        //            strHTML3.Append("<td>" + ds3.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
        //        }
        //        strHTML3.Append("</tr>");
        //    }
        //}

        //Response.Clear();
        //Response.ClearHeaders();
        ////Response.AddHeader("Content-Type", "application/vnd.ms-excel");
        //Response.AddHeader("Content-Type", "application/vnd.ms-OpenDocument Spreadsheet");
        //Response.AppendHeader("Content-Disposition", "attachment; filename=c://schedule.xlsx");

        //Response.Write(strHTML.ToString());
        //Response.Write(strHTML2.ToString());
        //Response.Write(strHTML3.ToString());
        ////this.EnableViewState = false;
        //Response.Flush();
        //Response.End();
    }
    protected void txtVal_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnFind_Click(object sender, EventArgs e)
    {

    }
    protected void chkFilter_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFilter.Checked == true)
        {
            ddlCol.Visible = true;
            txtVal.Visible = true;
            btnVal.Visible = true;
        }
        else
        {
            ddlCol.Visible = false;
            txtVal.Visible = false;
            btnVal.Visible = false;
        }
    }

    protected void ddlMonth2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlMonth2.SelectedValue) > 0)
        {
            Session["IntMonthId2"] = Convert.ToInt16(ddlMonth2.SelectedValue);
        }
        else
        {
            Session["IntMonthId2"] = 0;
        }
        fillBill();
    }
    private void fillWithDet()
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt32(Session["numBillId"]));
        ds = gen.getWithDet(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvLBA.DataSource = ds;
            gdvLBA.DataBind();
            for (int i = 0; i < gdvLBA.Rows.Count; i++)
            {
                GridViewRow gvr = gdvLBA.Rows[i];
                Label lblId = (Label)gvr.FindControl("lblId2");
                lblId.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            }
        }
        else
        {
            setGridDefault2();
        }
        gblObj.SetFooterTotalsGray(gdvLBA, 1);
    }
    private void setGridDefault1()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("numBillId");
        ar.Add("chvBillNo");
        ar.Add("dtmBill");
        ar.Add("fltBillAmount");
        ar.Add("slno");
        ar.Add("chvTreasuryName");
        gblObj.SetGridDefault(gdvAdd, ar);
    }
    private void setGridDefault2()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("numBillId");
        ar.Add("chvPF_No");
        ar.Add("amt");
        ar.Add("modeChg");
        ar.Add("numWithdrawalID");
        gblObj.SetGridDefault(gdvLBA, ar);
    }
    private void fillBill()
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(Session["IntYearId2"]));
        ar.Add(Convert.ToInt16(Session["IntMonthId2"]));
        ds = gen.getBillDet(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAdd.DataSource = ds;
            gdvAdd.DataBind();
        }
        else
        {
            setGridDefault1();
        }
    }
    protected void chkApp_CheckedChanged(object sender, EventArgs e)
    {
        int index = ((sender as CheckBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gdvLBA.Rows[index];
        CheckBox chkApp = (CheckBox)gdvr.FindControl("chkApp");
        fillTotals();
        if (Convert.ToDouble(gdvLBA.FooterRow.Cells[1].Text) == Convert.ToDouble(Session["fltAmt"]))
        {
            lblTot2.Text = "OOO  KKKKK";
        }
        else
        {
            lblTot2.Text = "Amount mismatch";
        }
    }
    private void fillTotals()
    {
        double totAmt = 0;
        for (int i = 0; i < gdvLBA.Rows.Count; i++)
        {
            GridViewRow gvr = gdvLBA.Rows[i];
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            if (gdvLBA.Rows[i].Cells[1].Text != "&nbsp;" && gdvLBA.Rows[i].Cells[1].Text != "" && chkApp.Checked == true)
            {
                totAmt = totAmt + Convert.ToDouble(gdvLBA.Rows[i].Cells[1].Text);
            }
        }
        gdvLBA.FooterRow.Cells[1].Text = totAmt.ToString();
    }
    protected void btnSaveA_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        //if (Convert.ToDouble(gdvLBA.FooterRow.Cells[1].Text) == Convert.ToDouble(Session["fltAmt"]))
        //{
        //    gblObj.MsgBoxOk("Amount mismatch!!", this);
        //}lblTot2
        updWithSetMode3();
        gblObj.MsgBoxOk("Updated!!", this);
    }
    private void updWithSetMode3()
    {
        
        for (int i = 0; i < gdvLBA.Rows.Count; i++)
        {
            GridViewRow gvr = gdvLBA.Rows[i];
            Label lblId = (Label)gvr.FindControl("lblId2");
            CheckBox chkApp = (CheckBox)gvr.FindControl("chkApp");
            if (chkApp.Checked == true)
            {
                ArrayList arr = new ArrayList();
                arr.Add(Convert.ToInt32(lblId.Text));
                gen.updWithModeOfChange(arr);
            }
        }

        fillBill();
    }
    protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear2.SelectedValue) > 0)
        {
            Session["IntYearId2"] = Convert.ToInt16(ddlYear2.SelectedValue);
        }
        else
        {
            Session["IntYearId2"] = 0;
        }
    }
}
