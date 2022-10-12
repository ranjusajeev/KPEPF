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
using System.Web.UI.HtmlControls;
using KPEPFClassLibrary;

public partial class Contents_ServiceDet : System.Web.UI.Page
     
{

    clsGlobalMethods gblObj;
    Employee emp;
    EmployeeDAO empDao;

    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
       
        if (!IsPostBack)
        {
            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            if (Request.QueryString["intPF_No"] == null)
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            InitialSettings();
            FillGrid();
            if (Convert.ToInt32(Request.QueryString["intPF_No"]) > 0)
            {
                Session["numEmpIdSerDet"] = Convert.ToInt32(Request.QueryString["intPF_No"]);
                if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
                {
                    FillMemDetails();
                }
                else
                {
                    FillMemDetailsTrn();
                    txtDOB.Focus();
                }
                SetControls();
            }
        }
    }
    private void InitialSettings()
    {
      
    }
    //private double ChalanLBId()
    //{
    //    double lb = 0;
    //    DataSet dsLB = new DataSet();
    //    ArrayList arrLB = new ArrayList();
    //    arrLB.Add(intaccno);
    //    dsLB = empDao.GetEmpLBDetails(arrLB);
    //    if (dsLB.Tables[0].Rows.Count > 0)
    //    {
    //        lb = Convert.ToDouble(dsLB.Tables[0].Rows[0].ItemArray[10]);
    //    }
    //    return lb;
    //}
    private void SetControls()
    {
        empDao = new EmployeeDAO();

        if (Convert.ToInt16(Session["intUserTypeId"]) == 1)
        {
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt32(Session["intLBID"]));
            ds = empDao.GetapprvalFlg(arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int flag;
                flag = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

                if ((flag == 100) || (flag == 0) || (flag == 3 && (Convert.ToInt32(Session["intLBTypeId"]) == 7)))
                {
                    EnbleControls();
                }
                else
                {
                    DisableControls();
                }
            }
        }
        else
        {
            DisableControls();
        }
    }
    public void EnbleControls()
    {
        txtAcc.ReadOnly = false;
        txtDOB.ReadOnly = false;
        txtDOJ.ReadOnly = false;
        btnAddClose.Enabled = true;
    }
    public void DisableControls()
    {
        txtAcc.ReadOnly = true;
        txtDOB.ReadOnly = true;
        txtDOJ.ReadOnly = true;
        btnAddClose.Enabled = false;
    }
    private void FillMemDetails()
    {
        empDao = new EmployeeDAO();
        
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        //ar.Add(Session["NumServiceTrnIDNomP"]);
        //ds = MemDAO.DisplayMemDet(ar);
        ar.Add(Convert.ToInt32(Session["numEmpIdSerDet"]));

        ds = empDao.GetEmpDetails(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAcc.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lblEmp1.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);
            txtDOJ.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);
            lblDOR1.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[4]);
            //Session["numEmpIdSerDet"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }
    private void FillMemDetailsTrn()
    {
        empDao = new EmployeeDAO();
        
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        //ar.Add(Session["NumServiceTrnIDNomP"]);
        //ds = MemDAO.DisplayMemDet(ar);
        ar.Add(Convert.ToInt32(Session["numEmpIdSerDet"]));

        ds = empDao.GetEmpDetailsTrn(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAcc.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lblEmp1.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);
            txtDOJ.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);
            lblDOR1.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[4]);
        }
    }
   
    public void FillGrid()
    {
        empDao = new EmployeeDAO();

        if (Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            SetReqListDefault();
        }
        else
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            DataSet ds = new DataSet();
            ds = empDao.GetServiceDet(ArrIn);
            gdvMemReqList.DataSource = ds;
            gdvMemReqList.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvRw = gdvMemReqList.Rows[i];
                Label lblSlNoAss = (Label)gvRw.FindControl("lblSlNo");
                CheckBox chkApp = (CheckBox)gvRw.FindControl("chkApp");
                
                lblSlNoAss.Text = Convert.ToString(i + 1);
                if (Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[5]) == 1)
                {
                    chkApp.Checked = true;
                }
                else
                {
                    chkApp.Checked = false;
                }
            }
        }
    }
    private void SetReqListDefault()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("intSlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("intPF_No");
        ar.Add("numMembershipReqID");
        ar.Add("flgApproval");
        gblObj.SetGridDefault(gdvMemReqList, ar);
    }
    protected void gdvMemReqList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddClose_Click(object sender, EventArgs e)
    {

        if (CheckMandatory(txtDOB, txtDOJ) == true)
        {
            SaveEmpDtsTrn();
            UpdateApprvl();
        }

        FillMemDetailsTrn();
        FillGrid();
        //DateTime previousDate = DateTime.Now.AddMonths(-1);
        //DateTime d = Convert.ToDateTime("12/12/2002");
        //d = d.AddDays(-1);
        //gblObj.MsgBoxOk(d.ToString(), this);

    }
    private Boolean CheckMandatory( TextBox DBDt, TextBox SrDt)
    {
        gblObj = new clsGlobalMethods();
        
        Boolean flg = true;
        if (DBDt.Text.ToString() == "" || DBDt.Text.ToString() == "0"
            || SrDt.Text.ToString() == "" || SrDt.Text.ToString() == "0")
        {
            gblObj.MsgBoxOk("Enter all details!", this);
            flg = false;
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void SaveEmpDtsTrn()
    {
        //gblObj = new clsGlobalMethods();
        //emp = new Employee();
        //empDao = new EmployeeDAO();

        //if (CheckAge() == true)
        //{
        //    if (CheckDoj() == true)
        //    {
        //        if (txtAcc.Text == "")
        //        {
        //            emp.NumEmpID = 0;
        //        }
        //        else
        //        {
        //            emp.NumEmpID = Convert.ToInt32(Session["numEmpIdSerDet"]);
        //        }
        //        if (txtDOB.Text == "")
        //        {
        //            emp.DtmDOB = "";
        //        }
        //        else
        //        {
        //            emp.DtmDOB = txtDOB.Text;
                    
        //        }

        //        if (txtDOJ.Text == "")
        //        {
        //            emp.DtmDOJS = "";
        //        }
        //        else
        //        {
        //            emp.DtmDOJS = txtDOJ.Text;
        //        }
        //        emp.IntCurrLB = Convert.ToInt32(Session["intLBID"]);
        //        if (chkCont.Checked == true)
        //        {
        //            emp.FlgCont = 2;
        //        }
        //        else
        //        {
        //            emp.FlgCont = 1;
        //        }
        //        empDao.UpdEmployeeBasicDetTrn(emp);
        //    }
        //    else
        //    {
        //        gblObj.MsgBoxOk("Check date!", this);
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Check date!", this);
        //}
        //gblObj.MsgBoxOk("Saved!", this);
        ////FillMemDetails();
        //FillMemDetailsTrn();

        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empDao = new EmployeeDAO();

        if (CheckAge() == true)
        {
            if (CheckDoj() == true)
            {
                if (txtAcc.Text == "")
                {
                    emp.NumEmpID = 0;
                }
                else
                {
                    emp.NumEmpID = Convert.ToInt32(Session["numEmpIdSerDet"]);
                }
                if (txtDOB.Text == "")
                {
                    emp.DtmDOB = "";
                }
                else
                {
                    emp.DtmDOB = txtDOB.Text;

                }

                if (txtDOJ.Text == "")
                {
                    emp.DtmDOJS = "";
                }
                else
                {
                    emp.DtmDOJS = txtDOJ.Text;
                }
                emp.IntCurrLB = Convert.ToInt32(Session["intLBID"]);
                if (chkCont.Checked == true)
                {
                    emp.FlgCont = 2;
                }
                else
                {
                    emp.FlgCont = 1;
                }
                //////////////////////
                DateTime dob1;
                if (Convert.ToDateTime(emp.DtmDOB).Day == 1)
                {
                    dob1 = Convert.ToDateTime(emp.DtmDOB).AddDays(-10);

                }
                else
                {
                    dob1 = Convert.ToDateTime(emp.DtmDOB);

                }
                /////////////////////
                empDao.UpdEmployeeBasicDetTrn(emp, dob1);
            }
            else
            {
                gblObj.MsgBoxOk("Check date!", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Check date!", this);
        }
        gblObj.MsgBoxOk("Saved!", this);
        //FillMemDetails();
        FillMemDetailsTrn();
    }
    private void SaveEmpDts()
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empDao = new EmployeeDAO();

        if (CheckAge() == true)
        {
            if (CheckDoj() == true)
            {
                if (txtAcc.Text == "")
                {
                    emp.NumEmpID = 0;
                }
                else
                {
                    emp.NumEmpID = Convert.ToInt32(Session["numEmpIdSerDet"]);
                }
                if (txtDOB.Text == "")
                {
                    emp.DtmDOB = "";
                }
                else
                {
                    emp.DtmDOB = txtDOB.Text;
                }

                if (txtDOJ.Text == "")
                {
                    emp.DtmDOJS = "";
                }
                else
                {
                    emp.DtmDOJS = txtDOJ.Text;
                }
                empDao.UpdEmployeeBasicDet(emp);
            }
            else
            {
                gblObj.MsgBoxOk("Check date!", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Check date!", this);
        }
        gblObj.MsgBoxOk("Saved successfully!", this);
        //FillMemDetails();
        FillMemDetailsTrn();
    }
    private bool CheckAge()
    {
        gblObj = new clsGlobalMethods();
        
        DateTime Dob = new DateTime();
        DateTime TDay = new DateTime();
        int Yr;
        TDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        Dob = Convert.ToDateTime(txtDOB.Text);
        Yr = TDay.Year - Dob.Year;
        if (Yr < 18)
        {
            gblObj.MsgBoxOk("Age of employee should be with in 18 and 56", this);
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckDoj()
    {
        gblObj = new clsGlobalMethods();
        
        DateTime Doj = new DateTime();
        DateTime Dob = new DateTime();
        int Yr;
        Dob = Convert.ToDateTime(txtDOB.Text);
        Doj = Convert.ToDateTime(txtDOJ.Text);
        Yr = Doj.Year - Dob.Year;
        if (Yr < 18)
        {
            gblObj.MsgBoxOk("Invalid date!", this);
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void chkDo_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnapprve_Click(object sender, EventArgs e)
    {

    }
    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (gblObj.isValidDate(txtDOB, this) == true)
        {
            if(gblObj.CheckDate2(txtDOB.Text.ToString(),DateTime.Now.ToString())==true )
            {
                if (CheckAge() == true )
                {
                    
                }
                else
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtDOB.Text = "";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtDOB.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtDOB.Text = "";
        }
    }
    protected void txtDOJ_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        
        if (gblObj.isValidDate(txtDOJ, this) == true)
        {
            if (gblObj.CheckDate2(txtDOJ.Text.ToString(), DateTime.Now.ToString()) == true)
            {
                if (CheckDoj() == true )
                {
                   
                }
                else
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtDOJ.Text = "";
                }
            }
            else
            {
                gblObj.MsgBoxOk("Invalid Date", this);
                txtDOJ.Text = "";
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtDOJ.Text = ""; 
        }
    }
    private void UpdateApprvl()
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empDao = new EmployeeDAO();

        DataSet ds = new DataSet();
        emp.IntCurrLB = Convert.ToInt32(Session["intLBID"]);
        emp.IntflgApp = Convert.ToInt32(Session["intFlgApp"]);
        emp.IntUserId = Convert.ToInt32(Session["intUserId"]);
        empDao.UpdEmployeeapprvalflg(emp);
        gblObj.MsgBoxOk("Saved!", this);
    }

}
