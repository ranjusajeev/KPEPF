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

public partial class Contents_ConsolWith : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    WithdrwalDAO wthDAO = new WithdrwalDAO();
    Withdrawals with = new Withdrawals();
    protected void Page_Load(object sender, EventArgs e)
    {
        initialsettings();
        
    }
    private void initialsettings()
    {
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Session["IntYearIdWit"]);
        arr.Add(Session["IntMonthIdWit"]);
        arr.Add(Session["IntTreIdWit"]);
        ds = wthDAO.GetBillsCon(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvWith.DataSource = ds;
            gdvWith.DataBind();
        }
        //    DataSet ds1 = new DataSet();
        //    ArrayList arr1 = new ArrayList();
        //    arr1.Add(gblobj.IntYearIdWit);
        //    ds1 = wthDAO.GetYearDetail(arr1);
        //    int intYear;
        //    if(Convert.ToInt32(gblobj.IntMonthIdWit.ToString())>3)
        //       intYear = Convert.ToDateTime(ds1.Tables[0].Rows[0].ItemArray[4].ToString()).Year;
        //    else
        //       intYear = Convert.ToDateTime(ds1.Tables[0].Rows[0].ItemArray[3].ToString()).Year;
        //    DateTime dt = new DateTime(intYear, gblobj.IntMonthIdWit, 01);
        //    DateTime dt4 = new DateTime();
        //    DateTime dt1 = new DateTime();
        //    DateTime dt2 = new DateTime();
        //    DateTime dt3 = new DateTime();
        //    dt1 = dt.AddDays(9);
        //    dt2 = dt1.AddDays(10);
        //    dt3 = dt2.AddDays(10);
        //    double amt1=0;
        //    double amt2=0;
        //    double amt3=0;
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        dt4 = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2].ToString());
        //        dt4 = dt4.Date;
        //        if ((dt <= dt4) && (dt1 >= dt4))
        //        {
        //            amt1 = amt1 + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[3].ToString());
        //        }
        //        else if ((dt1 < dt4) && (dt2>= dt4))
        //        {
        //            amt2 = amt1 + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[3].ToString());
        //        }
        //        else if ((dt2 < dt4) && (dt3 >= dt4))
        //        {
        //            amt3 = amt1 + Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[3].ToString());
        //        }
        //    }
        //    gblobj.SetRowsCnt(gdvWith,3);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        GridViewRow gvr = gdvWith.Rows[i];
        //        if (i == 0)
        //        {
        //            TextBox txtDateass = (TextBox)gvr.FindControl("txtDate");
        //            txtDateass.Text = dt1.ToString("dd/MM/yyyy");
        //            TextBox fltBillAmountass = (TextBox)gvr.FindControl("fltBillAmount");
        //            fltBillAmountass.Text = amt1.ToString();
        //        }
        //        else if (i == 1)
        //        {
        //            TextBox txtDateass1 = (TextBox)gvr.FindControl("txtDate");
        //            txtDateass1.Text = dt2.ToString("dd/MM/yyyy");
        //            TextBox fltBillAmountass1 = (TextBox)gvr.FindControl("fltBillAmount");
        //            fltBillAmountass1.Text = amt2.ToString();
        //        }
        //        else
        //        {
        //            TextBox txtDateass2 = (TextBox)gvr.FindControl("txtDate");
        //            txtDateass2.Text = dt3.ToString("dd/MM/yyyy");
        //            TextBox fltBillAmountass2 = (TextBox)gvr.FindControl("fltBillAmount");
        //            fltBillAmountass2.Text = amt3.ToString();
        //        }
        //    }
        //}

        else
        {
            gblobj.MsgBoxOk("No Data Found", this);
        }

        gblobj.FillGridSlNo(gdvWith);
    }

    //protected void Allchk1_CheckedChanged(object sender, EventArgs e)
    //{
         
    //    GridView gdv = gdvWith;
    //    CheckBox chkAll1 = (CheckBox)gdv.HeaderRow.FindControl("Allchk1");
    //    for (int i = 0; i < gdvWith.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gdvWith.Rows[i];
    //        CheckBox ChkApp1 = (CheckBox)gvr.FindControl("chkApp1");
    //        if (chkAll1.Checked == true)
    //        {
    //            ChkApp1.Checked = true;
    //        }
    //    }

  
    //}
}
