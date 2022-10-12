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

public partial class Contents_SearchEmp : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();

    static int intFlg = 1;
    static double NumEmpId;
    static string empName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Convert.ToInt16(Session["intMenuItem"]) == 2)
            //{
            //    pnlAccNo.Visible = true;
            //    pnlLb.Visible = false;
            //}
            //else
            //{
            //    pnlAccNo.Visible = false;
            //    pnlLb.Visible = true;
            //    FillDist();
            //}
            SetGridDefault();
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (txtValue.Text.ToString() != "")
        {
            NumEmpId = Convert.ToDouble(txtValue.Text.ToString());
            FillGdvSearch(1);
        }
    }
    private void FillGdvSearch(int intFlg)
    {
        DataSet ds = new DataSet();
        if (intFlg == 1)
        {
            ds = gen.GetEmpAccWise(intFlg, NumEmpId, "");
        }
        else
        {
            ds = gen.GetEmpAccWise(intFlg, 0, empName);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvSearch.Visible = true;
            gdvSearch.DataSource = ds;
            gdvSearch.DataBind();
        }
        else
        {
            SetGridDefault();
            gblObj.MsgBoxOk("No such Employee",this);
        }
    }
    protected void rdView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdView.Items[0].Selected == true)
        {
            txtValue.Visible = true;
            btnFind.Visible = true;
            txtValue1.Visible = false ;
            btnFind1.Visible = false ;
            a.Visible = true;
            b.Visible = false;
        }
        else
        {
            txtValue.Visible = false;
            btnFind.Visible = false;
            txtValue1.Visible = true;
            btnFind1.Visible = true;
            a.Visible = false;
            b.Visible = true;
        }
        SetGridDefault();
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("chvEngDistName");
        ar.Add("chvLBNameEnglish");
        ar.Add("DistJoin");
        ar.Add("chvLBNameJoin");
        ar.Add("Status");
        ar.Add("BfrStatus");
        ar.Add("fltOB");
        gblObj.SetGridDefault(gdvSearch, ar);
    }
    protected void btnFind1_Click(object sender, EventArgs e)
    {
        if (txtValue1.Text.ToString() != "")
        {
            empName = txtValue1.Text.ToString();
            FillGdvSearch(2);
        }
    }
}
