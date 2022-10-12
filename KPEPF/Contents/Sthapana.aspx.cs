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

public partial class Contents_Sthapana : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO genDao = new GeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();

    static int intFlg;
    static long  NumEmpId;
    static int intCurRw = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            intFlg = 1;
            FillGdv();
            FillCntEmp();
        }
    }
    private void FillCntEmp()
    {
        txtCntEmp.Text = Session["intCntEmp"].ToString();
        lblPndng.Text = Convert.ToString(Convert.ToInt16(txtCntEmp.Text.ToString()) - 10);
        if (Convert.ToInt16(txtCntEmp.Text.ToString()) > 0)
        {
            ddlCorrType.Enabled = true;
            btnUpd.Enabled = true;
        }
        else
        {
            ddlCorrType.Enabled = false;
            btnUpd.Enabled = false;
        }
    }
    private void FillGdv()
    {
        DataSet ds = new DataSet();
        ds = genDao.GetEmpLBWise(Convert.ToInt32(Session["intLBID"]),2); //gblObj.IntInstId
        gdvEmp.DataSource = ds;
        gdvEmp.DataBind();
        Session["intCntEmp"] = Convert.ToInt16(ds.Tables[0].Rows.Count);
    }
    protected void btnUpd_Click(object sender, EventArgs e)
    {
        //Update in Sthapana the unique id from PF


        //Also update corrected emps in PF (ie current posting LB)

        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(Session["intLBID"]));
        genDao.UpdateEmpCurLBNull(ArrIn1);

        for (int i = 1; i <= gdvEmp.Rows.Count; i++)
        {
            GridViewRow gdvRw1 = gdvEmp.Rows[i - 1];
            CheckBox chkEmpAss = (CheckBox)gdvRw1.FindControl("chkEmp");
            Label lblEmpId = (Label)gdvRw1.FindControl("lblEmpId");
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt16(lblEmpId.Text.ToString()));
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            ArrIn.Add(1);
            genDao.UpdateEmpCurLB(ArrIn);
        }
    }
    protected void gdvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSearch.PageIndex = e.NewPageIndex;
        FillGdvSearch();
    }
    private void FillGdvSearch()
    {
        DataSet ds = new DataSet();
        if (intFlg == 1)
        {
            ds = genDao.GetEmpAccWise(intFlg, NumEmpId, "");
        }
        else
        {
            ds = genDao.GetEmpAccWise(intFlg, 0, gblObj.StrNameEmp);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvSearch.Visible = true;
            gdvSearch.DataSource = ds;
            gdvSearch.DataBind();
            SetSlNoLBSearch(ds);   //lblEmpId2
        }
        else
        {
            MsgBox1.Visible = true;
            MsgBox1.lblMsgAssgn.Text = gblObj.DisplayMsg(100, 1, 9);
        }
    }
    private void SetSlNoLBSearch(DataSet ds1)
    {
        //for (int i = 1; i < gdvSearch.Rows.Count + 1; i++)
        //{
        //    GridViewRow gdvRw = gdvSearch.Rows[i - 1];
        //    Label lblEmpIdAss = (Label)gdvRw.FindControl("lblEmpId");
        //    Label lblLBAss = (Label)gdvRw.FindControl("lblLBId");
        //    //gdvRw.Cells[0].Text = i.ToString();
        //    lblEmpIdAss.Text = ds1.Tables[0].Rows[i - 1].ItemArray[0].ToString();
        //    lblLBAss.Text = ds1.Tables[0].Rows[i - 1].ItemArray[4].ToString();
        //}
    }
    protected void AddMergedCells(GridViewRow gdvRw, TableCell objtablecell, int colspan, string celltext, string backcolor)
    {
        objtablecell = new TableCell();
        objtablecell.Text = celltext;
        objtablecell.ColumnSpan = colspan;
        objtablecell.Style.Add("background-color", backcolor);
        objtablecell.HorizontalAlign = HorizontalAlign.Center;
        gdvRw.Cells.Add(objtablecell);
    }
    protected void ddlCorrType_SelectedIndexChanged(object sender, EventArgs e)
    {
        intFlg = Convert.ToInt16(ddlCorrType.SelectedValue);
        if (intFlg == 2)
        {
            gdvSearchName.Visible = false;
            gdvSearch.Visible = true;
            gblObj.SetBlankRow(gdvSearch);
        }
        else
        {
            gdvSearchName.Visible = true;
            gdvSearch.Visible = false;
            gblObj.SetBlankRow(gdvSearchName);
        }

    }
    protected void txtAccNoP_TextChanged(object sender, EventArgs e)
        {
        DataSet dsEmp = new DataSet();
        intCurRw = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        GridViewRow gdvRw = gdvSearch.Rows[intCurRw];
        TextBox txtAccNoAss = (TextBox)gdvRw.FindControl("txtAccNoP");
        Label txtNameAss = (Label)gdvRw.FindControl("txtNameP");
        Label lblAccNoSAss = (Label)gdvRw.FindControl("lblAccNoS");
        Label lblNameSAss = (Label)gdvRw.FindControl("lblNameS");
        NumEmpId = Convert.ToInt64(txtAccNoAss.Text);
        emp.NumEmpID = NumEmpId;
        dsEmp = empDao.GetEmployeeDetails(emp, 1);
        //if (dsEmp.Tables[0].Rows.Count > 0)
        //{
        //    txtNameAss.Text = dsEmp.Tables[0].Rows[0].ItemArray[1].ToString();
        //}
        if (dsEmp.Tables[0].Rows.Count > 0)
        {
            txtAccNoAss.Text = dsEmp.Tables[0].Rows[0].ItemArray[0].ToString();
            txtNameAss.Text = dsEmp.Tables[0].Rows[0].ItemArray[1].ToString();
            lblAccNoSAss.Text = dsEmp.Tables[0].Rows[0].ItemArray[3].ToString();
        }

            //Sthapana data
            //DataSet dsSthapanaEmp = new DataSet();
            //localhost.Service GetName = new localhost.Service();
            //dsSthapanaEmp = GetName.GetNameFromAccNo(Convert.ToInt16(txtAccNoAss.Text));
            //if (dsSthapanaEmp != null)
            //{
            //    if (dsSthapanaEmp.Tables[0].Rows.Count > 0)
            //    {
            //        lblAccNoSAss.Text = dsSthapanaEmp.Tables[0].Rows[0].ItemArray[1].ToString();
            //        lblNameSAss.Text = dsSthapanaEmp.Tables[0].Rows[0].ItemArray[0].ToString();
            //    }
            //    else
            //    {
            //        lblAccNoSAss.Text = "";
            //        lblNameSAss.Text = "";
            //    }
            //}

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        //Add to left grid.....
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            GridViewRow gdvRw1 = gdvSearch.Rows[i];
            TextBox txtEmpIdAss = (TextBox)gdvRw1.FindControl("txtAccNoP");
            emp.NumEmpID = Convert.ToInt64(txtEmpIdAss.Text);
            emp.IntCurrLB = Convert.ToInt32(Session["intLBID"]);
            empDao.UpdateEmpLB(emp);
            FillGdv();
        }
    }
    protected void txtNameP2_TextChanged(object sender, EventArgs e)
    {
        DataSet dsEmp2 = new DataSet();
        for (int i = 1; i < gdvSearchName.Rows.Count + 1; i++)
        {
            GridViewRow gdvRw = gdvSearchName.Rows[i - 1];
            TextBox txtNameP2Ass = (TextBox)gdvRw.FindControl("txtNameP2");
            Label lblAccNoP2Ass = (Label)gdvRw.FindControl("lblAccNoP2");
            Label lblNameS2Ass = (Label)gdvRw.FindControl("lblNameS2");
            Label lblAccNoS2Ass = (Label)gdvRw.FindControl("lblAccNoS2");
            //NumEmpId = Convert.ToDouble(txtNameP2Ass.Text);
            emp.StrEmpName = txtNameP2Ass.Text.ToString();
            dsEmp2 = empDao.GetEmployeeDetails(emp, 2);
            if (dsEmp2.Tables[0].Rows.Count > 0)
            {
                lblAccNoP2Ass.Text = dsEmp2.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            ////Sthapana data
            //DataSet dsSthapanaEmp = new DataSet();
            //localhost.Service GetName = new localhost.Service();
            //dsSthapanaEmp = GetName.GetNameFromAccNo(Convert.ToInt16(txtAccNoAss.Text));
            
            //if (dsSthapanaEmp.Tables[0].Rows.Count > 0)
            //{
            //    lblAccNoSAss.Text = dsSthapanaEmp.Tables[0].Rows[0].ItemArray[1].ToString();
            //    lblNameSAss.Text = dsSthapanaEmp.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
            //else
            //{
            //    lblAccNoSAss.Text = "";
            //    lblNameSAss.Text = "";
            //}
        }
    }
    protected void lnkAdd2_Click(object sender, EventArgs e)
    {
        //Add to left grid.....
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            GridViewRow gdvRw1 = gdvSearch.Rows[i];
            TextBox txtEmpIdAss = (TextBox)gdvRw1.FindControl("txtAccNoP");
            emp.NumEmpID = Convert.ToInt64(txtEmpIdAss.Text);
            emp.IntCurrLB = Convert.ToInt32(Session["intLBID"]);
            empDao.UpdateEmpLB(emp);
            FillGdv();
        }
    }
    protected void gdvSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCells(gdvSearch, gvr, 7, 1, 2, 3, 4, "PF", "Sthapana", e);
    }
    protected void gdvSearchName_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        gblObj.MergeCells(gdvSearchName, gvr, 7, 1, 2, 3, 4, "PF", "Sthapana", e);
    }
    protected void txtCntEmp_TextChanged(object sender, EventArgs e)
    {
        if (txtCntEmp.Text.ToString() != "")
        {
            if (Convert.ToInt16(txtCntEmp.Text.ToString()) > 0)
            {
                ddlCorrType.Enabled = true;
                btnUpd.Enabled = true;

                ArrayList ArrIn = new ArrayList();
                ArrIn.Add(Convert.ToInt32(Session["intLBId"].ToString()));
                ArrIn.Add(Convert.ToInt16(txtCntEmp.Text.ToString()));
                genDao.UpdLocalBody(ArrIn);
            }
            else
            {
                ddlCorrType.Enabled = false;
                btnUpd.Enabled = false;
            }
        }
        else
        {
            ddlCorrType.Enabled = false;
            btnUpd.Enabled = false;
        }
    }
}
