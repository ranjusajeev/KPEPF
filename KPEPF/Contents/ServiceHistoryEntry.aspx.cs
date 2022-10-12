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

public partial class Contents_ServiceHistoryEntry : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Employee emp = new Employee();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO Kgen = new KPEPFGeneralDAO();
    WithdrawalRequest TAReq = new WithdrawalRequest();
    WithdrawalRequestDAO TAReqDao = new WithdrawalRequestDAO();
    ApprovalDAO apprDao = new ApprovalDAO();
    static int intDistId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlService.Visible = true;
            InitialSettings();
            FillGrid1();
        }
    }
    private void InitialSettings()
    {
        DataSet ds = new DataSet();
        emp.NumEmpID = Convert.ToInt64(Session["NumEmpId"]); 
        ds = empDoa.GetEmployeeBasicDet(emp);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblLB.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lblLB.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            //lblDesig.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        }
        setGridDefalt();
        FillGridCombo(0);
    }
    private void FillGrid1()
    {
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        //DataTable dtService = new DataTable();
        DataTable dtService = gblObj.SetInitialRow(gdvService);
        ViewState["Service"] = dtService;
        DataRow dr = dtService.Rows[0];
        //dr = dtService.NewRow();
        dr["SlNo"] = 1;
        FillGridCombo(0);
        arr.Add(Session["NumEmpId"]);
        ds = Kgen.GetServiceHistory(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dtService = gblObj.SetGridTableRows(gdvService, ds.Tables[0].Rows.Count);
            //ViewState["Service"] = dtService;
            int j = 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdvService.Rows[i];
                FillGridCombo(i);
                DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
                ddldist.SelectedValue = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                dtService.Rows[i]["Column1"] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
                ddlLBType.SelectedValue = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                DropDownList ddlDesig = (DropDownList)gvr.FindControl("ddlDesig");
                ddlDesig.SelectedValue = ds.Tables[0].Rows[i].ItemArray[8].ToString();

                dtService.Rows[i]["Column2"] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                FillLB(i);
                DropDownList ddlLBName = (DropDownList)gvr.FindControl("ddlLBName");
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[5].ToString()) > 0)
                {
                    ddlLBName.SelectedValue = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    dtService.Rows[i]["Column3"] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                }
                else
                {
                    ddlLBName.Visible = false;
                    TextBox txtLBName = (TextBox)gvr.FindControl("txtLBName");
                    txtLBName.Visible = true;
                    txtLBName.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                }
                TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
                txtFrom.Text = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                dtService.Rows[i]["Column4"] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
                txtTo.Text = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                TextBox txtRemark = (TextBox)gvr.FindControl("txtRemark");
                txtRemark.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                dtService.Rows[i]["Column5"] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                dtService.Rows[i]["Column6"] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                dtService.Rows[i]["Column7"] = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[12]) == 1)
                {
                    setDisableControls();
                }
                //if (i > 0)
                //{
                //    dtService.Rows.Add(dr);
                //}
                dr = null;
                if (j < Convert.ToInt16(ds.Tables[0].Rows.Count))
                {
                    dr = dtService.Rows[i + 1];
                    j = j + 1;
                    dr["SlNo"] = j;
                }
            }
            ViewState["Service"] = dtService;
        }
        //else
        //{
        //    dtService = gblObj.SetInitialRow(gdvService);
        //    ViewState["Service"] = dtService;
        //}
    }
    private void setDisableControls()
    {
        for (int i = 0; i < gdvService.Rows.Count; i++)
        {
            GridViewRow gvr = gdvService.Rows[i];
            DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
            ddldist.Enabled = false;
            DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
            ddlLBType.Enabled = false;
            DropDownList ddlLBName = (DropDownList)gvr.FindControl("ddlLBName");
            ddlLBName.Enabled = false;
            TextBox txtLBName = (TextBox)gvr.FindControl("txtLBName");
            txtLBName.Enabled = false;
            TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
            txtFrom.Enabled = false;
            TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
            txtTo.Enabled = false;
            DropDownList ddlDesig = (DropDownList)gvr.FindControl("ddlDesig");
            ddlDesig.Enabled = false;
            TextBox txtRemark = (TextBox)gvr.FindControl("txtRemark");
            txtRemark.Enabled = false;
            Button btnAdd = (Button)gvr.FindControl("btnAdd");
            btnAdd.Enabled = false;
            Button btnDel = (Button)gvr.FindControl("btnDel");
            btnDel.Enabled = false;
        }
        Button2.Enabled = false;
    }
    private void setGridDefalt()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SlNo");
        gblObj.SetGridDefault(gdvService, arr);
    }
    private void FillGridCombo(int index)
    {
        DataSet ds = new DataSet();
        ds = gen.GetInstType();
        DataSet ds1 = new DataSet();
        ds1 = Kgen.GetDesignationGp();
        DataSet ds2 = new DataSet();
        ds2 = gen.GetDistrict();
        //for (int i = 0; i < gdvService.Rows.Count; i++)
        //{
        GridViewRow gvr = gdvService.Rows[index];
        DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
        gblObj.FillCombo(ddlLBType, ds, 1);
        DropDownList ddlDesig = (DropDownList)gvr.FindControl("ddlDesig");
        gblObj.FillCombo(ddlDesig, ds1, 1);
        DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
        gblObj.FillCombo(ddldist, ds2, 1);
        //}
    }
    protected void ddlLBType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        FillLB(index);
    }
    private void FillLB(int index)
    {
        DataSet ds = new DataSet();
        GridViewRow gvr = gdvService.Rows[index];
        DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
        DropDownList ddlLBName = (DropDownList)gvr.FindControl("ddlLBName");
        DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
        ArrayList arr = new ArrayList();
        if (Convert.ToInt16(ddldist.SelectedValue) < 0)
        {
            arr.Add(1);
        }
        else
        {
            arr.Add(Convert.ToInt16(ddldist.SelectedValue));
        }
        //arr.Add(intDistId);
        if (Convert.ToInt16(ddlLBType.SelectedValue) < 0)
        {
            arr.Add(5);
        }
        else
        {
            arr.Add(Convert.ToInt16(ddlLBType.SelectedValue));
        }
        ds = gen.GetLB(arr);
        gblObj.FillCombo(ddlLBName, ds, 1);
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = ((sender as DropDownList).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvService.Rows[index];
        DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
        intDistId = Convert.ToInt16(ddldist.SelectedValue);
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        if (checkRowinGrid() == 0)
        {
            SaveServiceHistory();
            gblObj.MsgBoxOk("Saved Successfully", this);
            //SetViewState();
            //pnlbasic.Visible = true;
           // pnlService.Visible = false;
        }
        else
        {
            gblObj.MsgBoxOk("Enter All Details", this);
        }
    }
    private int checkRowinGrid()
    {
        int flag = 0;
        for (int i = 0; i < gdvService.Rows.Count; i++)
        {
            GridViewRow gvr = gdvService.Rows[i];
            DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
            if (Convert.ToInt16(ddldist.SelectedValue) <= 0)
            {
                flag = 1;
                break;
            }
        }
        return flag;
    }
    private void SaveServiceHistory()
    {
        for (int i = 0; i < gdvService.Rows.Count; i++)
        {
            GridViewRow gvr = gdvService.Rows[i];
            ArrayList arr = new ArrayList();
            arr.Add(i + 1);
            arr.Add(Session["NumEmpId"]);
            DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
            if (ddldist.SelectedValue == "")
            {
                gblObj.MsgBoxOk("Select Distrist in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(Convert.ToInt16(ddldist.SelectedValue));
            }
            DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
            if (ddlLBType.SelectedValue == "")
            {
                gblObj.MsgBoxOk("Select LB Type in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(Convert.ToInt16(ddlLBType.SelectedValue));
            }
            DropDownList ddlLBName = (DropDownList)gvr.FindControl("ddlLBName");
            if (ddlLBName.SelectedValue == "")
            {
                gblObj.MsgBoxOk("Select LB Name in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(Convert.ToInt16(ddlLBName.SelectedValue));
            }
            TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
            if (txtFrom.Text == "")
            {
                gblObj.MsgBoxOk("Select From Date in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(txtFrom.Text);
            }
            TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
            if (txtTo.Text == "")
            {
                gblObj.MsgBoxOk("Select To Date in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(txtTo.Text);
            }
            DropDownList ddlDesig = (DropDownList)gvr.FindControl("ddlDesig");
            if (ddlDesig.SelectedValue == "")
            {
                gblObj.MsgBoxOk("Select Designation in " + i + 1 + "th Row", this);
            }
            else
            {
                arr.Add(Convert.ToInt16(ddlDesig.SelectedValue));
            }
            TextBox txtRemark = (TextBox)gvr.FindControl("txtRemark");
            if (txtRemark.Text == "")
            {
                arr.Add("");
            }
            else
            {
                arr.Add(txtRemark.Text.ToString());
            }
            arr.Add(Convert.ToInt64(Session["intUserId"]));
            arr.Add(0);
            arr.Add(1);
            Kgen.SaveServiceHistory(arr);
        }
    }
    //private int checkRow()
    //{
    //    int flag = 0;
    //if (ViewState["Service"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["Service"];
    //        //int index = ((sender as Button).Parent.Parent as GridViewRow).RowIndex;
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            if (dt.Rows[i]["Column1"].ToString() == "")
    //            {
    //                flag = 1;
    //                break;
    //            }
    //        }
    //    }
    //    return flag;
    //}
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (checkRowinGrid() == 0)
        {
            SaveServiceHistory();
            FillGrid1();
            AddNewRow();
        }
        else
        {
            gblObj.MsgBoxOk("Enter all Details in Current Row", this);
        }

        //if (ViewState["Service"] != null)
        //{
        //    DataTable dt = (DataTable)ViewState["Service"];
        //    int count = gdvService.Rows.Count;
        //    ArrayList arrIN = new ArrayList();
        //    arrIN.Add("ddldist");
        //    arrIN.Add("ddlLBType");
        //    arrIN.Add("ddlLBName");
        //    arrIN.Add("txtLBName");
        //    arrIN.Add("txtFrom");
        //    arrIN.Add("txtTo");
        //    arrIN.Add("ddlDesig");
        //    arrIN.Add("btnAdd");
        //    dt = gblObj.AddNewRowToGrid(dt, gdvService, arrIN);
        //    ViewState["SpecTable"] = dt;
        //    DropDownList ddldist = (DropDownList)gdvService.Rows[count].FindControl("ddldist");
        //    DropDownList ddlLBType = (DropDownList)gdvService.Rows[count].FindControl("ddlLBType");
        //    DropDownList ddlLBName = (DropDownList)gdvService.Rows[count].FindControl("ddlLBName");
        //    DropDownList ddlDesig = (DropDownList)gdvService.Rows[count].FindControl("ddlDesig");
        //    gblObj.setFocus(ddldist, this);
        //    //}
        //    FillGridCombo();
        //    //FillLB(dt.Rows.Count-1);
        //    for (int i = 0; i < dt.Rows.Count - 1; i++)
        //    {
        //        DropDownList Ddldist = (DropDownList)gdvService.Rows[i].FindControl("ddldist");
        //        Ddldist.SelectedValue = dt.Rows[i].ItemArray[1].ToString();
        //        DropDownList DdlLBType = (DropDownList)gdvService.Rows[i].FindControl("ddlLBType");
        //        DdlLBType.SelectedValue = dt.Rows[i].ItemArray[2].ToString();
        //        DropDownList DdlLBName = (DropDownList)gdvService.Rows[i].FindControl("ddlLBName");
        //        DdlLBName.SelectedValue = dt.Rows[i].ItemArray[3].ToString();
        //        DropDownList DdlDesig = (DropDownList)gdvService.Rows[i].FindControl("ddlDesig");
        //        DdlDesig.SelectedValue = dt.Rows[i].ItemArray[6].ToString();

        //    }
        //}
    }
    private void AddNewRow()
    {
        int rowIndex = 0;

        if (ViewState["Service"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["Service"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList ddldist = (DropDownList)gdvService.Rows[rowIndex].Cells[1].FindControl("ddldist");
                    DropDownList ddlLBType = (DropDownList)gdvService.Rows[rowIndex].Cells[2].FindControl("ddlLBType");
                    DropDownList ddlLBName = (DropDownList)gdvService.Rows[rowIndex].Cells[3].FindControl("ddlLBName");
                    TextBox txtFrom = (TextBox)gdvService.Rows[rowIndex].Cells[4].FindControl("txtFrom");
                    TextBox txtTo = (TextBox)gdvService.Rows[rowIndex].Cells[5].FindControl("txtTo");
                    DropDownList ddlDesig = (DropDownList)gdvService.Rows[rowIndex].Cells[6].FindControl("ddlDesig");
                    TextBox txtRemark = (TextBox)gdvService.Rows[rowIndex].Cells[7].FindControl("txtRemark");
                    Button btnAdd = (Button)gdvService.Rows[rowIndex].Cells[8].FindControl("btnAdd");
                    Button btnDel = (Button)gdvService.Rows[rowIndex].Cells[9].FindControl("btnDel");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SlNo"] = i + 1;
                    FillGridCombo(i - 1);
                    if (dtCurrentTable.Rows[i - 1]["Column1"].ToString() != "")
                    {
                        ddldist.SelectedValue = dtCurrentTable.Rows[i - 1]["Column1"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column1"] = ddldist.SelectedValue;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column2"].ToString() != "")
                    {
                        ddlLBType.SelectedValue = dtCurrentTable.Rows[i - 1]["Column2"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column2"] = ddlLBType.SelectedValue;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column3"].ToString() != "")
                    {
                        FillLB(i - 1);
                        ddlLBName.SelectedValue = dtCurrentTable.Rows[i - 1]["Column3"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column3"] = ddlLBName.SelectedValue;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column4"].ToString() != "")
                    {
                        txtFrom.Text = dtCurrentTable.Rows[i - 1]["Column4"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column4"] = txtFrom.Text;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column5"].ToString() != "")
                    {
                        txtTo.Text = dtCurrentTable.Rows[i - 1]["Column5"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column5"] = txtTo.Text;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column6"].ToString() != "")
                    {
                        ddlDesig.SelectedValue = dtCurrentTable.Rows[i - 1]["Column6"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column6"] = ddlDesig.SelectedValue;
                    }
                    if (dtCurrentTable.Rows[i - 1]["Column7"].ToString() != "")
                    {
                        txtRemark.Text = dtCurrentTable.Rows[i - 1]["Column7"].ToString();
                    }
                    else
                    {
                        dtCurrentTable.Rows[i - 1]["Column7"] = txtRemark.Text;
                    }

                    //dtCurrentTable.Rows[i - 1]["Column1"] = ddldist.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["Column2"] = ddlLBType.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["Column3"] = ddlLBName.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["Column4"] = txtFrom.Text;
                    //dtCurrentTable.Rows[i - 1]["Column5"] = txtTo.Text;
                    //dtCurrentTable.Rows[i - 1]["Column6"] = ddlDesig.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["Column7"] = btnAdd;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["Service"] = dtCurrentTable;

                gdvService.DataSource = dtCurrentTable;
                gdvService.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["Service"] != null)
        {
            DataTable dt = (DataTable)ViewState["Service"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList ddldist = (DropDownList)gdvService.Rows[rowIndex].Cells[1].FindControl("ddldist");
                    DropDownList ddlLBType = (DropDownList)gdvService.Rows[rowIndex].Cells[2].FindControl("ddlLBType");
                    DropDownList ddlLBName = (DropDownList)gdvService.Rows[rowIndex].Cells[3].FindControl("ddlLBName");
                    TextBox txtFrom = (TextBox)gdvService.Rows[rowIndex].Cells[4].FindControl("txtFrom");
                    TextBox txtTo = (TextBox)gdvService.Rows[rowIndex].Cells[5].FindControl("txtTo");
                    DropDownList ddlDesig = (DropDownList)gdvService.Rows[rowIndex].Cells[6].FindControl("ddlDesig");
                    TextBox txtRemark = (TextBox)gdvService.Rows[rowIndex].Cells[7].FindControl("txtRemark");
                    Button btnAdd = (Button)gdvService.Rows[rowIndex].Cells[8].FindControl("btnAdd");
                    Button btnDel = (Button)gdvService.Rows[rowIndex].Cells[9].FindControl("btnDel");
                    FillGridCombo(i);
                    string test = dt.Rows[i]["Column1"].ToString();
                    if (dt.Rows[i]["Column1"].ToString() != "")
                    {
                        if (Convert.ToInt16(dt.Rows[i]["Column2"].ToString()) > 0)
                        {
                            ddldist.SelectedValue = dt.Rows[i]["Column1"].ToString();
                        }
                    }
                    else
                    {
                        ddldist.SelectedIndex = 0;
                    }
                    if (dt.Rows[i]["Column2"].ToString() != "")
                    {
                        if (Convert.ToInt16(dt.Rows[i]["Column2"].ToString()) > 0)
                        {
                            ddlLBType.SelectedValue = dt.Rows[i]["Column2"].ToString();
                            FillLB(i);
                            if (dt.Rows[i]["Column3"].ToString() != "")
                            {
                                if (Convert.ToInt16(dt.Rows[i]["Column3"].ToString()) > 0)
                                {
                                    ddlLBName.SelectedValue = dt.Rows[i]["Column3"].ToString();
                                }
                            }
                            else
                            {
                                ddlLBName.SelectedIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        ddlLBType.SelectedIndex = 0;
                    }
                    if (dt.Rows[i]["Column1"].ToString() != "")
                    {
                        if (Convert.ToInt16(dt.Rows[i]["Column6"].ToString()) > 0)
                        {
                            ddlDesig.SelectedValue = dt.Rows[i]["Column6"].ToString();
                        }
                    }
                    else
                    {
                        ddlDesig.SelectedIndex = 0;
                    }
                    txtFrom.Text = dt.Rows[i]["Column4"].ToString();
                    txtTo.Text = dt.Rows[i]["Column5"].ToString();
                    txtRemark.Text = dt.Rows[i]["Column7"].ToString();
                    //ddlDesig.SelectedValue = dt.Rows[i]["Column6"].ToString();
                    rowIndex++;
                }

            }
        }
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        if (ViewState["Service"] != null)
        {
            int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
            if (index > 0)
            {
                GridViewRow gvrp = gdvService.Rows[index - 1];
                TextBox txtTo = (TextBox)gvrp.FindControl("txtTo");
                GridViewRow gvrc = gdvService.Rows[index];
                TextBox txtFrom = (TextBox)gvrc.FindControl("txtFrom");
                if (checkDate(txtTo, txtFrom) == false)
                {
                    gblObj.MsgBoxOk("Entered Date is Invalid", this);
                    txtFrom.Text = "";
                }
            }
        }
    }
    private bool checkDate(TextBox txt1, TextBox txt2)
    {
        DateTime dt1 = Convert.ToDateTime(txt1.Text);
        DateTime dt2 = Convert.ToDateTime(txt2.Text);
        if (dt1 > dt2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        if (ViewState["Service"] != null)
        {
            int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
            GridViewRow gvr = gdvService.Rows[index];
            TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
            TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
            if (checkDate(txtFrom, txtTo) == false)
            {
                gblObj.MsgBoxOk("Entered Date is Invalid", this);
                txtTo.Text = "";
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int index = ((sender as Button).Parent.Parent as GridViewRow).RowIndex;
        Deleterow(index);
    }
    private void Deleterow(int index)
    {
        if (ViewState["Service"] != null)
        {
            ArrayList arr = new ArrayList();
            DataSet ds = new DataSet();
            GridViewRow gvr = gdvService.Rows[index];
            TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
            TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
            if (txtFrom.Text != "")
            {
                if (txtTo.Text != "")
                {
                    arr.Add(Convert.ToInt32(Session["NumEmpId"]));
                    arr.Add(txtFrom.Text);
                    arr.Add(txtTo.Text);
                    ds = Kgen.GetServiceDetails(arr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Kgen.Deleterow(arr);
                        UpdateServiceHistory(index);
                        FillGrid1();
                    }
                }
            }
            else
            {
                DataTable dt = (DataTable)ViewState["Service"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == index)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
                ViewState["Service"] = dt;
                gdvService.DataSource = dt;
                gdvService.DataBind();
                SetPreviousData();
            }
        }
    }
    private void UpdateServiceHistory(int index)
    {
        GridViewRow gvr = gdvService.Rows[index];
        ArrayList arr = new ArrayList();
        arr.Add(index + 1);
        arr.Add(Session["NumEmpId"]);
        DropDownList ddldist = (DropDownList)gvr.FindControl("ddldist");
        arr.Add(Convert.ToInt16(ddldist.SelectedValue));
        DropDownList ddlLBType = (DropDownList)gvr.FindControl("ddlLBType");
        arr.Add(Convert.ToInt16(ddlLBType.SelectedValue));
        DropDownList ddlLBName = (DropDownList)gvr.FindControl("ddlLBName");
        arr.Add(Convert.ToInt16(ddlLBName.SelectedValue));
        TextBox txtFrom = (TextBox)gvr.FindControl("txtFrom");
        arr.Add(txtFrom.Text);
        TextBox txtTo = (TextBox)gvr.FindControl("txtTo");
        arr.Add(txtTo.Text);
        DropDownList ddlDesig = (DropDownList)gvr.FindControl("ddlDesig");
        arr.Add(Convert.ToInt16(ddlDesig.SelectedValue));
        TextBox txtRemark = (TextBox)gvr.FindControl("txtRemark");
        arr.Add(txtRemark.Text);
        arr.Add(Convert.ToInt64(Session["intUserId"]));
        arr.Add(0);
        arr.Add(2);
        Kgen.SaveServiceHistory(arr);
    }
    private void DisableCtrls()
    {
    }
    private void EnableCtrls()
    {
    }
}
