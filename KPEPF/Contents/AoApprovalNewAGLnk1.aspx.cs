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

public partial class Contents_AoApprovalNewAGLnk1 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    AOApproval aoapp = new AOApproval();
    AOApprovalDAO aoappDAO = new AOApprovalDAO();
    AGDAO agDAO = new AGDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intMonthIdAppAG"] = Convert.ToInt16(Request.QueryString["intMonthId"]);
            FillLbls();
            if (Convert.ToInt16(Session["intYearIdAppAG"]) >= 50)
            {
                gdvAOApprov.Visible = false;
                gdvAOApprov1415.Visible = true;
                FillGrid1415();
            }
            else
            {
                gdvAOApprov.Visible = true;
                gdvAOApprov1415.Visible = false;
                FillGrid();
            }
        }
    }
    private void FillLbls()
    {
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
        lblYear.Text = gen.GetYearFromId(ar);

        ArrayList arm = new ArrayList();
        arm.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
        lblMonth.Text = gen.GetMonthFromId(arm);
    }
    private void FillGrid()
    {
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
        arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
        ds = agDAO.GetTreasuryD(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov.DataSource = ds;
            gdvAOApprov.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvAOApprov.Rows[i];
                Label lblTIdAss = (Label)gvr.FindControl("lblTId");
                lblTIdAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
        }
        FillTreasuryCrAmt(ds.Tables[0].Rows.Count);
        FillAGCrAmt(ds.Tables[0].Rows.Count);
        FillTreasuryDbAmt(ds.Tables[0].Rows.Count);
        FillAgDbAmt(ds.Tables[0].Rows.Count);

        gblObj.SetFooterTotalsTempField(gdvAOApprov, 2,"lblCrT",2);
        gblObj.SetFooterTotalsTempField(gdvAOApprov, 3, "lblCrAG", 2);
        gblObj.SetFooterTotalsTempField(gdvAOApprov, 4, "lblDtT", 2);
        gblObj.SetFooterTotalsTempField(gdvAOApprov, 5, "lblDtAG", 2);
        FillTE(gdvAOApprov);
        //FillAGAmt(ds.Tables[0].Rows.Count);
    }
    private void FillGrid1415()
    {
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
        arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
        ds = agDAO.GetTreasuryD(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAOApprov1415.DataSource = ds;
            gdvAOApprov1415.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvAOApprov1415.Rows[i];
                Label lblTIdAss = (Label)gvr.FindControl("lblTId");
                lblTIdAss.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
        }
        //FillTreasuryCrAmt(ds.Tables[0].Rows.Count);
        //FillAGCrAmt(ds.Tables[0].Rows.Count);
        //FillTreasuryDbAmt(ds.Tables[0].Rows.Count);
        //FillAgDbAmt(ds.Tables[0].Rows.Count);

        
        gblObj.SetFooterTotals(gdvAOApprov1415, 2);
        gblObj.SetFooterTotals(gdvAOApprov1415, 3);
        gblObj.SetFooterTotals(gdvAOApprov1415, 4);
        gblObj.SetFooterTotals(gdvAOApprov1415, 5);
        FillTE(gdvAOApprov1415);
        //FillAGAmt(ds.Tables[0].Rows.Count);
    }
    private void FillTE(GridView gdv)         //For Fill Transfer Entry Grid
    {
        DataSet ds1 = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
        arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
        arr.Add(8);
        if (Convert.ToInt16(Session["intYearIdAppAG"]) < 50)
        {
            ds1 = agDAO.FillTEAmtPDE(arr);         //Fill Existing Data
        }
        else
        {
            ds1 = agDAO.FillTEAmt1415(arr);        
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Session["IntAGId"] = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0]);

            txtcrplus.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            txtcrMinus.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            txtDbplus.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            txtDbMinus.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            //txtdaer.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            //txtdaerDb.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            lblNetCr.Text = Convert.ToString(Convert.ToDouble(gdv.FooterRow.Cells[3].Text) + Convert.ToDouble(txtcrplus.Text) - Convert.ToDouble(txtcrMinus.Text));
            lblNetDt.Text = Convert.ToString(Convert.ToDouble(gdv.FooterRow.Cells[5].Text) + Convert.ToDouble(txtDbplus.Text) - Convert.ToDouble(txtDbMinus.Text));
        }
    }

    protected void gdvAOApprov_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //GridView HeaderGrid = (GridView)sender;
            //GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //TableCell HeaderCell = new TableCell();
            //HeaderCell.Text = "SL No";
            //HeaderCell.RowSpan = 2;
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderGridRow.Cells.Add(HeaderCell);
            //TableCell HeaderCell1 = new TableCell();
            //HeaderCell1.Text = "Treasury";
            //HeaderCell1.RowSpan = 2;
            //HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
            //HeaderGridRow.Cells.Add(HeaderCell1);
            //TableCell HeaderCell2 = new TableCell();
            //HeaderCell2.Text = "Credit Amount";
            //HeaderCell2.ColumnSpan = 2;
            //HeaderCell2.RowSpan = 2;
            //HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            //HeaderGridRow.Cells.Add(HeaderCell2);
            //TableCell HeaderCell3 = new TableCell();
            //HeaderCell3.Text = "Debit Amount";
            //HeaderCell3.RowSpan = 2;
            //HeaderCell3.ColumnSpan = 2;
            //HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
            //HeaderGridRow.Cells.Add(HeaderCell3);
            //TableCell HeaderCell4 = new TableCell();
            //HeaderCell4.Text = "Remark";
            //HeaderCell4.RowSpan = 2;
            //HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
            //HeaderGridRow.Cells.Add(HeaderCell4);
            //gdvAgStmt.Controls[0].Controls.AddAt(0, HeaderGridRow);
            //gdvAgStmt.Controls[0].Controls.AddAt(1, HeaderGridRow1);
        }
    }
    private void FillTreasuryCrAmt(int cnt)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < cnt; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAOApprov.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
            arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
            arr.Add(1);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                Label lblCrTAss = (Label)gdv.FindControl("lblCrT");
                lblCrTAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();

            }
        }
    }
    private void FillAGCrAmt(int cnt)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < cnt; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(gdvAOApprov.DataKeys[i]["intDTreasuryID"].ToString()));
            arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
            arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
            arr.Add(2);
            dsTreasCr = agDAO.GetTreasuryCrAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                Label lblCrAGAss = (Label)gdv.FindControl("lblCrAG");
                lblCrAGAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[1].ToString();

            }
        }

    }
    private void FillTreasuryDbAmt(int cnt)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < cnt; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
            arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
            arr.Add(Convert.ToInt16(gdvAOApprov.DataKeys[i]["intDTreasuryID"].ToString()));
            dsTreasCr = agDAO.GetTreasuryDtAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                Label lblDtTAss = (Label)gdv.FindControl("lblDtT");
                lblDtTAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
    }
    private void FillAgDbAmt(int cnt)
    {
        DataSet dsTreasCr = new DataSet();
        for (int i = 0; i < cnt; i++)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt16(Session["intYearIdAppAG"]));
            arr.Add(Convert.ToInt16(Session["intMonthIdAppAG"]));
            arr.Add(Convert.ToInt16(gdvAOApprov.DataKeys[i]["intDTreasuryID"].ToString()));
            dsTreasCr = agDAO.GetAGDtAmt(arr);
            if (dsTreasCr.Tables[0].Rows.Count > 0)
            {
                GridViewRow gdv = gdvAOApprov.Rows[i];
                Label lblDtAGAss = (Label)gdv.FindControl("lblDtAG");
                lblDtAGAss.Text = dsTreasCr.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    //protected void btnBack_Click1(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["intYearIdAppAG"]) >= 50)
    //    {
    //        Response.Redirect("AoApprovalAGCurr.aspx");
    //    }
    //    else
    //    {
    //        Response.Redirect("AoApprovalAG.aspx");
    //    }
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intYearIdAppAG"]) >= 50)
        {
            Response.Redirect("AoApprovalAGCurr.aspx");
        }
        else
        {
            Response.Redirect("AoApprovalAG.aspx");
        }
    }
}
