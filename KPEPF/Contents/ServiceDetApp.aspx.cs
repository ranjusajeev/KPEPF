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

public partial class Contents_ServiceDetApp : System.Web.UI.Page
{
    //clsGlobalMethods gblObj = new clsGlobalMethods();
    //GeneralDAO gen = new GeneralDAO();
    //Employee emp = new Employee();
    //EmployeeDAO empD = new EmployeeDAO();

    clsGlobalMethods gblObj;
    GeneralDAO gen;
    Employee emp;
    EmployeeDAO empD;

    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();

        if (!IsPostBack == true)
        {
            //if (Convert.ToInt16(Request.QueryString["k"]) > 0)
            //{
            gblObj.SetLBTypesForDirAccts(Convert.ToInt16(Session["flgAcc"]));
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //}
            InitialSettings();


            if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
            {
                FillGrid();
            }
            else
            {
                FillGridDir();
            }
            if (Convert.ToInt32(Request.QueryString["intId"]) > 0)
            {
                gdvlist.Visible = true;
                filllistGrid();
            }
            //else
            //{
            //    FillCmb();
            //    SetGridDefault();
            //    gdvlist.Visible = false;
            //}
        }
    }
    private void InitialSettings()
    {
        SetRdAppOptionForClerk();
        //Set rejected opt as itself even after back from trn page
        rdApp.Items[0].Selected = true;
        if (Convert.ToInt32(Session["flgInbx"]) == 100)
        {
            rdApp.Items[0].Selected = false;
            rdApp.Items[1].Selected = true;
        }
       
        //Set rejected opt as itself even after back from trn page

        if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
        {
            ddlDist.Visible = false;
            Label3.Visible = false;
            SetGridDefault();
           // FillGrid();
        }
        else
        {
            Label3.Visible = true;
            ddlDist.Visible = true;
            FillCmb();
          //  FillGridDir();
        }
        
    }
    private void SetRdAppOptionForClerk()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            rdApp.Items[1].Enabled = true;
            gdvchRem.Columns[4].Visible = false;
        }
        else
        {
            gdvchRem.Columns[4].Visible = true;
            rdApp.Items[1].Enabled = false;
            rdApp.Items[0].Selected = true;
        }
      
    }
    private void FillCmb()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        gdvlist.Visible = false;
        if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        {
            Session["intDistSerApp"] = Convert.ToInt32(ddlDist.SelectedValue);
        }
        else
        {
            Session["intDistSerApp"] = 0;
        }
        if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
        {
            FillGrid();
        }
        else
        {
            FillGridDir();
        }
      
    }
    private void filllistGrid()
    {
        empD = new EmployeeDAO();
        
        if (Convert.ToInt32(Request.QueryString["intId"]) > 0)
        {
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt32(Request.QueryString["intId"]));
            DataSet dslist = new DataSet();
            dslist = empD.GetAppListofEmp(ar);
            SetGridDefaultlist();
            if (dslist.Tables[0].Rows.Count > 0)
            {
                gdvlist.DataSource = dslist;
                gdvlist.DataBind();
                for (int i = 0; i < gdvlist.Rows.Count; i++)
                {
                    GridViewRow grdVwRow = gdvlist.Rows[i];
                    Label lblSlNo = (Label)grdVwRow.FindControl("lblSlNo");
                    lblSlNo.Text = Convert.ToString(i + 1);
                }

            }
        }
        else
        {
            SetGridDefaultlist();
        }
    }
    private void fillemp(int lb)
    {
        emp = new Employee();
        empD = new EmployeeDAO();

        ArrayList ar = new ArrayList();
        ar.Add(lb);
        DataSet dslist = new DataSet();
        dslist = empD.GetAppListofEmp(ar);   
        
        SetGridDefaultlist();
        if (dslist.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < dslist.Tables[0].Rows.Count; j++)
            {
                emp.NumEmpID =Convert.ToInt32(dslist.Tables[0].Rows[j].ItemArray[3].ToString());
                emp.DtmDOB = dslist.Tables[0].Rows[j].ItemArray[6].ToString();
                emp.DtmDOJS = dslist.Tables[0].Rows[j].ItemArray[7].ToString();
                if (Convert.ToInt32(dslist.Tables[0].Rows[j].ItemArray[5]) == 1)
                {
                    empD.UpdEmployeeBasicDet(emp);
                }
          
            }
        }
    }
    private void FillGridDir()
    {
        empD = new EmployeeDAO();

        ArrayList ar = new ArrayList();
        if (rdApp.Items[0].Selected == true)
        {
            ar.Add(Convert.ToInt16(Session["intFlgAppInbx"]));
        }
        else
        {
            ar.Add(Convert.ToInt16(Session["intFlgRejInbx"]));
        }
            ar.Add(Convert.ToInt16(Session["intDistSerApp"]));
            ar.Add(0);
       

        DataSet ds2 = new DataSet();
        ds2 = empD.GetLBToAppDir(ar);

        SetGridDefault();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvchRem.DataSource = ds2;
            gdvchRem.DataBind();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                GridViewRow grdVwRow = gdvchRem.Rows[i];
                Label lblId = (Label)grdVwRow.FindControl("lblId");
                lblId.Text = ds2.Tables[0].Rows[i].ItemArray[2].ToString();

                //CheckBox chkApp = (CheckBox)grdVwRow.FindControl("chkApp");
                //if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6]) == 2)
                //{
                //    chkApp.Checked = true;

                //}
                //else
                //{
                //    chkApp.Checked = false;
                //}
                Session["flgInbx"] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
            }
        }
        else
        {
            SetGridDefault();
        }
    }
    private void FillGrid()
    {
        empD = new EmployeeDAO();

        ArrayList ar = new ArrayList();
        if (rdApp.Items[0].Selected == true)
        {
            ar.Add(Convert.ToInt16(Session["intFlgAppInbx"]));
        }
        else
        {
            ar.Add(Convert.ToInt16(Session["intFlgRejInbx"]));
        }


        //if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
         
        ar.Add(Convert.ToInt16(Session["intLBID"]));
        ar.Add(1);       
     

        DataSet ds2 = new DataSet();
        ds2 = empD.GetLBToApp(ar);

        SetGridDefault();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gdvchRem.DataSource = ds2;
            gdvchRem.DataBind();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                GridViewRow grdVwRow = gdvchRem.Rows[i];
                Label lblId = (Label)grdVwRow.FindControl("lblId");
                lblId.Text = ds2.Tables[0].Rows[i].ItemArray[2].ToString();

                //CheckBox chkApp = (CheckBox)grdVwRow.FindControl("chkApp");
                //if (Convert.ToInt16(ds2.Tables[0].Rows[i].ItemArray[6]) == 2)
                //{
                //    chkApp.Checked = true;

                //}
                //else
                //{
                //    chkApp.Checked = false;
                //}
                Session["flgInbx"] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
            }
        }
    }
    private void SetGridDefault()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvEngLBName");
        ar.Add("intId");

        gblObj.SetGridDefault(gdvchRem, ar);
    }
    private void SetGridDefaultlist()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ar = new ArrayList();
        ar.Add("intSlNo");
        ar.Add("numEmpId");
        ar.Add("chvName");
        ar.Add("dtmDateOfBirth");
        ar.Add("DojName");
        ar.Add("DoRName");

        gblObj.SetGridDefault(gdvlist, ar);
    }
    protected void chkV_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Allchk_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnLBSave_Click(object sender, EventArgs e)
    {
        UpdateFlag();
        if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
        {
            FillGrid();
        }
        else
        {
            FillGridDir();
        }

    }
    private void UpdateFlag()
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empD = new EmployeeDAO();

        for (int i = 0; i < gdvchRem.Rows.Count; i++)
        {
            ArrayList arn = new ArrayList();
            GridViewRow gvr = gdvchRem.Rows[i];
            Label lblId = (Label)gvr.FindControl("lblId");           
            CheckBox chkVAss = (CheckBox)gvr.FindControl("chkV");
            CheckBox chkRejAss = (CheckBox)gvr.FindControl("chkRej");
            if (chkRejAss.Checked == true)
            {
                emp.IntCurrLB = Convert.ToInt16(lblId.Text);
                emp.IntflgApp = Convert.ToInt16(Session["intFlgRej"]);
                emp.IntUserId = Convert.ToInt64(Session["intUserId"]);
                empD.UpdEmployeeapprvalflg(emp);
                gblObj.MsgBoxOk("Returned", this);
            }            
            if (chkVAss.Checked == true)
            {
                emp.IntCurrLB = Convert.ToInt16(lblId.Text);
                emp.IntflgApp = Convert.ToInt16(Session["intFlgApp"]);
                emp.IntUserId  = Convert.ToInt64(Session["intUserId"]);
                empD.UpdEmployeeapprvalflg(emp);
                if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
                {
                    DataSet ds = new DataSet();
                    ArrayList arr = new ArrayList();
                    arr.Add(lblId.Text);
                    ds = empD.GetapprvalFlg(arr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString()) == 20)
                        {
                            fillemp(Convert.ToInt32(lblId.Text));
                            gblObj.MsgBoxOk("Approved", this);
                        }
                    }

                }
                else
                {
                    gblObj.MsgBoxOk("Forwarded", this);
                }

            }
        }
    }
    private void SaveEmpDts(int i)
    {
        gblObj = new clsGlobalMethods();
       
        gblObj.MsgBoxOk("Saved successfully!", this);
      
    }
    protected void rdApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridDefault();
        if ((Convert.ToInt32(Session["intLBTypeId"]) == 5) || (Convert.ToInt32(Session["intLBTypeId"]) == 6) || (Convert.ToInt32(Session["intLBTypeId"]) == 1) || (Convert.ToInt16(Session["flgAcc"]) == 1))
        {
            FillGrid();
        }
        else
        {
            FillGridDir();
        }
        gdvlist.Visible = false;
        
    }
    protected void gdvchRem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
