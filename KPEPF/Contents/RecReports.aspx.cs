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
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;

public partial class Contents_RecReports : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDao;
    GeneralDAO gen;
    ChalanDAO chd;
    BillDao bld;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCmbs(1);
            Session["flg"] = 1;
        }

    }
    private void FillCmbs(int tp)
    {
        gblObj = new clsGlobalMethods();
        GenDao = new KPEPFGeneralDAO();
        gen = new GeneralDAO();

        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        if (tp == 1)
        {
            gblObj.FillCombo(ddlDistrictn1, ds, 1);
        }
        else if (tp == 3)
        {
            gblObj.FillCombo(ddlDistrictn3, ds, 1);
        }
        else if (tp == 5)
        {
            gblObj.FillCombo(ddlDistrictn5, ds, 1);
        }
        else if (tp == 7)
        {
            gblObj.FillCombo(ddlDistrictn7, ds, 1);
        }
        DataSet dsyr = new DataSet();
        dsyr = GenDao.GetYearOnLineNdPDE();

        if (tp == 1)
        {
            gblObj.FillCombo(ddlYearn1, dsyr, 1);
        }
        else if (tp == 2)
        {
            gblObj.FillCombo(ddlYearn2, dsyr, 1);
        }
        else if (tp == 3)
        {
            gblObj.FillCombo(ddlYearn3, dsyr, 1);
        }
        else if (tp == 4)
        {
            gblObj.FillCombo(ddlYearn4, dsyr, 1);
        }
        else if (tp == 5)
        {
            gblObj.FillCombo(ddlYearn5, dsyr, 1);
        }
        else if (tp == 6)
        {
            gblObj.FillCombo(ddlYearn6, dsyr, 1);
        }
        else if (tp == 7)
        {
            gblObj.FillCombo(ddlYearn7, dsyr, 1);
        }
        else if (tp == 8)
        {
            gblObj.FillCombo(ddlYearn8, dsyr, 1);
        }
        DataSet dsmnth = new DataSet();
        dsmnth = gen.GetMonth();

        if (tp == 1)
        {
            gblObj.FillCombo(ddlMonthn1, dsmnth, 1);
        }
        else if (tp == 2)
        {
            gblObj.FillCombo(ddlMonthn2, dsmnth, 1);
        }
        else if (tp == 3)
        {
            gblObj.FillCombo(ddlMonthn3, dsmnth, 1);
        }
        else if (tp == 4)
        {
            gblObj.FillCombo(ddlMonthn4, dsmnth, 1);
        }
        else if (tp == 5)
        {
            gblObj.FillCombo(ddlMonthn5, dsmnth, 1);
        }
        else if (tp == 6)
        {
            gblObj.FillCombo(ddlMonthn6, dsmnth, 1);
        }
        else if (tp == 7)
        {
            gblObj.FillCombo(ddlMonthn7, dsmnth, 1);
        }
        else if (tp == 8)
        {
            gblObj.FillCombo(ddlMonthn8, dsmnth, 1);
        }
    }

    private void FillDT(int tp)
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();

        DataSet dsTreas = new DataSet();
        ArrayList arrd = new ArrayList();
        if (tp == 1)
        {
            arrd.Add(Convert.ToInt16(Session["IntDistRep1"]));
        }
        else if (tp == 3)
        {
            arrd.Add(Convert.ToInt16(Session["IntDistRep3"]));
        }
        else if (tp == 5)
        {
            arrd.Add(Convert.ToInt16(Session["IntDistRep5"]));
        }
        dsTreas = gen.GetDisTreasury(arrd);
        if (tp == 1)
        {
            gblObj.FillCombo(ddlTreasn1, dsTreas, 1);
        }
        else if (tp == 3)
        {
            gblObj.FillCombo(ddlTreasn3, dsTreas, 1);
        }
        else if (tp == 5)
        {
            gblObj.FillCombo(ddlTreasn5, dsTreas, 1);
        }
    }
    //protected void ddlTreas_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTreas.SelectedIndex > 0)
    //    {
    //        Session["IntTreIdRep1"] = Convert.ToInt32(ddlTreas.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntTreIdRep1"] = 0;
    //    }
    //    if (Convert.ToInt16(Session["IntYearIdRep1"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep1"]) > 0 && Convert.ToInt16(Session["IntDistRep1"]) > 0 && Convert.ToInt16(Session["IntTreIdRep1"]) > 0)
    //    {
    //        //FillGrid();
    //    }
    //    lblShow.Text = "";
    //}
    //protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["IntYearIdRep"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep"]) > 0 && Convert.ToInt16(Session["IntDistRep"]) > 0 && Convert.ToInt16(Session["IntTreIdRep"]) > 0)
    //    {
    //        //FillGrid();
    //    }
    //    lblShow.Text = "";
    //}
    protected void rdRpt_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblShow.Text = "";
        Session["flg"] = rdRpt.SelectedValue;
        if (Convert.ToInt16(Session["flg"]) == 1)           //Chalan_T
        {
            FillCmbs(1);
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)        //Chalan_A
        {
            FillCmbs(2);
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }

        else if (Convert.ToInt16(Session["flg"]) == 3)        //Chalan_T _C
        {
            FillCmbs(3);
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = true;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;            
        }
        else if (Convert.ToInt16(Session["flg"]) == 4)       //Chalan_A _C
        {
            FillCmbs(4);
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = true;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }
        else if (Convert.ToInt16(Session["flg"]) == 5)       //Bill_T
        {
            FillCmbs(5);
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = true;
            pnl6.Visible = false;
        }
        else if (Convert.ToInt16(Session["flg"]) == 6)         //Bill_A
        {
            FillCmbs(6);
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = true;
        }
        else if (Convert.ToInt16(Session["flg"]) == 7)      //Bill_T _C
        {
            FillCmbs(7);
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }
        else if (Convert.ToInt16(Session["flg"]) == 8)      //Bill_A _C
        {
            FillCmbs(8);
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }
        else if (Convert.ToInt16(Session["flg"]) == 9)      //OB _C
        {
            FillCmbs(8);
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }
    }
    //protected void ddlYear3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear3.SelectedIndex > 0)
    //    {
    //        Session["IntYearIdRep3"] = Convert.ToInt16(ddlYear3.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearIdRep3"] = 0;
    //    }
    //    //ddlMonth.SelectedValue = "0";
    //    //ddlDistrict.SelectedValue = "0";
    //    ddlTreas3.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlMonth3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMonth3.SelectedIndex > 0)
    //    {
    //        Session["IntMonthIdRep3"] = Convert.ToInt16(ddlMonth3.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntMonthIdRep3"] = 0;
    //    }
    //    ddlTreas3.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlDistrict3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlDistrict3.SelectedIndex > 0)
    //    {
    //        Session["IntDistRep3"] = Convert.ToInt32(ddlDistrict3.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntDistRep3"] = 0;
    //    }
    //    //ddlTreas.SelectedValue = "0";
    //    FillDT(3);
    //    lblShow.Text = "";
    //}
    //protected void ddlTreas3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTreas3.SelectedIndex > 0)
    //    {
    //        Session["IntTreIdRep3"] = Convert.ToInt32(ddlTreas3.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntTreIdRep3"] = 0;
    //    }
    //    if (Convert.ToInt16(Session["IntYearIdRep3"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep3"]) > 0 && Convert.ToInt16(Session["IntDistRep3"]) > 0 && Convert.ToInt16(Session["IntTreIdRep3"]) > 0)
    //    {
    //        //FillGrid3();
    //    }
    //    lblShow.Text = "";
    //}

    //protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear2.SelectedIndex > 0)
    //    {
    //        Session["IntYearIdRep2"] = Convert.ToInt16(ddlYear2.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearIdRep2"] = 0;
    //    }
    //    ddlMonth2.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlMonth2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMonth2.SelectedIndex > 0)
    //    {
    //        Session["IntMonthIdRep2"] = Convert.ToInt16(ddlMonth2.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntMonthIdRep2"] = 0;
    //    }
    //    if (Convert.ToInt16(Session["IntYearIdRep2"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep2"]) > 0)
    //    {
    //        //FillGrid2();
    //    }
    //    lblShow.Text = "";
    //}
    //protected void ddlYear4_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear4.SelectedIndex > 0)
    //    {
    //        Session["IntYearIdRep4"] = Convert.ToInt16(ddlYear4.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearIdRep4"] = 0;
    //    }
    //    ddlMonth4.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlMonth4_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMonth4.SelectedIndex > 0)
    //    {
    //        Session["IntMonthIdRep4"] = Convert.ToInt16(ddlMonth4.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntMonthIdRep4"] = 0;
    //    }
    //    if (Convert.ToInt16(Session["IntYearIdRep4"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep4"]) > 0)
    //    {
    //        //FillGrid4();
    //    }
    //    lblShow.Text = "";
    //}
    //protected void ddlYear5_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYear5.SelectedIndex > 0)
    //    {
    //        Session["IntYearIdRep5"] = Convert.ToInt16(ddlYear5.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearIdRep5"] = 0;
    //    }
    //    ddlTreas5.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlMonth5_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlMonth5.SelectedIndex > 0)
    //    {
    //        Session["IntMonthIdRep5"] = Convert.ToInt16(ddlMonth5.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntMonthIdRep5"] = 0;
    //    }
    //    ddlTreas5.SelectedValue = "0";
    //    lblShow.Text = "";
    //}
    //protected void ddlTreas5_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTreas5.SelectedIndex > 0)
    //    {
    //        Session["IntTreIdRep5"] = Convert.ToInt32(ddlTreas5.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntTreIdRep5"] = 0;
    //    }
    //    if (Convert.ToInt16(Session["IntYearIdRep5"]) > 0 && Convert.ToInt16(Session["IntMonthIdRep5"]) > 0 && Convert.ToInt16(Session["IntDistRep5"]) > 0 && Convert.ToInt16(Session["IntTreIdRep5"]) > 0)
    //    {
    //        //FillGrid5();
    //    }
    //    lblShow.Text = "";
    //}
    //protected void ddlDistrict5_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlDistrict5.SelectedIndex > 0)
    //    {
    //        Session["IntDistRep5"] = Convert.ToInt32(ddlDistrict5.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntDistRep5"] = 0;
    //    }
    //    //ddlTreas.SelectedValue = "0";
    //    FillDT(5);
    //    lblShow.Text = "";
    //}
   
    private string strGenerateFileName(int yrid)
    {
        string flnm = "rec1" + yrid + ".pdf";
        return flnm;
    }
    private void PrintRep1()
    {
        gblObj = new clsGlobalMethods();
        chd = new ChalanDAO();
        DataSet dsChal = new DataSet();

        System.Text.StringBuilder strHTML = new System.Text.StringBuilder();

        strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        strHTML.Append("Chalan Treasury");
        strHTML.Append("</thead>");
        //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
        strHTML.Append("<th>" + "Sl No" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt.");


        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearIdRep1"]));
        ar.Add(Convert.ToInt16(Session["IntMonthIdRep1"]));
        ar.Add(Convert.ToInt16(Session["IntTreIdRep1"]));
        if (rdCategory.Items[0].Selected == true)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        //ar.Add(1);

        if (Convert.ToInt16(Session["IntYearIdRep1"]) < 50)
        {
            dsChal = chd.RecPrint1(ar, 1);
        }
        else
        {
            dsChal = chd.RecPrint1(ar, 2);
        }


        if (dsChal.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsChal.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                strHTML.Append("<td>" + (i + 1) + "</td>");
                //strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChal.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChal.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChal.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsChal.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsChal.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            gblObj.MsgBoxOk("No Data Exist", this);
        }
        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblShow.Text = "";

        if (Convert.ToInt16(Session["flg"]) == 1)
        {
            PrintRep1();
        }
        else if (Convert.ToInt16(Session["flg"]) == 2)
        {
            PrintRep2();
        }
        else if (Convert.ToInt16(Session["flg"]) == 3)
        {
            PrintRep3(1);
        }
        else if (Convert.ToInt16(Session["flg"]) == 4)
        {
            PrintRep3(2);
        }
        else if (Convert.ToInt16(Session["flg"]) == 5)
        {
            PrintRep5();
        }
        else if (Convert.ToInt16(Session["flg"]) == 6)
        {
            PrintRep6();
        }
        else if (Convert.ToInt16(Session["flg"]) == 7)
        {
            PrintRep7();
        }
        else if (Convert.ToInt16(Session["flg"]) == 8)
        {
            PrintRep8();
        }
    }
    //private void PrintRep6()
    //{
    //    gblObj = new clsGlobalMethods();
    //    bld = new BillDao();
    //    DataSet dsBill = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    ar.Add(Convert.ToInt16(Session["IntYearIdRep5"]));
    //    ar.Add(Convert.ToInt16(Session["IntMonthIdRep5"]));
    //    ar.Add(1);

    //    if (Convert.ToInt16(Session["IntYearIdRep5"]) < 50)
    //    {
    //        dsBill = bld.RecPrint3(ar, 1);
    //    }
    //    else
    //    {
    //        dsBill = bld.RecPrint3(ar, 2);
    //    }
    //    System.Text.StringBuilder strHTML = new System.Text.StringBuilder();

    //    strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
    //    strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
    //    strHTML.Append("Chalan Treasury");
    //    strHTML.Append("</thead>");
    //    //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
    //    strHTML.Append("<th>" + "Sl No" + "</th><th>" + "VCHR No." + "</th><th>" + "VCHR Date" + "</th><th>" + " VCHR Amt." + "</th><th>" + " Bill Amt.");
    //    if (dsBill.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dsBill.Tables[0].Rows.Count; i++)
    //        {
    //            strHTML.Append("<tr>");
    //            strHTML.Append("<td>" + (i + 1) + "</td>");
    //            //strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
    //            strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
    //            strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
    //            strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
    //            strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBill.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
    //            strHTML.Append("</tr>");
    //        }
    //    }
    //    else
    //    {
    //        gblObj.MsgBoxOk("No Data Exist", this);
    //    }
    //    strHTML.Append("</table>");
    //    lblShow.Text = strHTML.ToString();
    //}

    private void PrintRep3(int tp)
    {
        gblObj = new clsGlobalMethods();
        chd = new ChalanDAO();
        DataSet dsCh5 = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearIdRep3"]));
        ar.Add(Convert.ToInt16(Session["IntMonthIdRep3"]));
        ar.Add(Convert.ToInt16(Session["IntTreIdRep3"]));
        if (rdCategory3.Items[0].Selected == true)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        if (tp == 1)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        
        if (Convert.ToInt16(Session["IntYearIdRep3"]) < 50)
        {
            dsCh5 = chd.RecPrint3(ar, 1);
        }
        else
        {
            dsCh5 = chd.RecPrint3(ar, 2);
        }
        System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        strHTML.Append("<table width='95%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        strHTML.Append("Chalan Treasury");
        strHTML.Append("</thead>");
        //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
        strHTML.Append("<th>" + "Sl No" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt." + "</th><th>" + " Corr. Amt.");
        if (dsCh5.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCh5.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                strHTML.Append("<td>" + (i + 1) + "</td>");
                //strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                strHTML.Append("<td align=left; width='10%' style='border:1 solid gray;'>" + dsCh5.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsCh5.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsCh5.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsCh5.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsCh5.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsCh5.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            gblObj.MsgBoxOk("No Data Exist", this);
        }
        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();
    }

    private void PrintRep6()
    {
        gblObj = new clsGlobalMethods();
        bld = new BillDao();
        DataSet dsBillag = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearIdRep6"]));
        ar.Add(Convert.ToInt16(Session["IntMonthIdRep6"]));
        if (Convert.ToInt16(Session["IntYearIdRep6"]) < 50)
        {
            dsBillag = bld.RecPrint4(ar,1);
        }
        else
        {
            dsBillag = bld.RecPrint4(ar,2);
        }

        System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        strHTML.Append("Chalan Treasury");
        strHTML.Append("</thead>");
        strHTML.Append("<th>" + "Sl No" + "</th><th>" + "TE Month" + "</th><th>" + "TE No:" + "</th><th>" + "Treasury" + "</th><th>" + "Bill No." + "</th><th>" + "Bill Date" + "</th><th>" + " Bill Amt." + "</th><th>" + " Withdrawal Amt.");
        //strHTML.Append("<th>" + "Sl No" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt.");
        if (dsBillag.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsBillag.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                strHTML.Append("<td>" + (i + 1) + "</td>");

                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");

                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            gblObj.MsgBoxOk("No Data Exist", this);
        }
        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();
    }
    private void PrintRep7()
    {
        //gblObj = new clsGlobalMethods();
        //bld = new BillDao();
        //DataSet dsBillag = new DataSet();
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt16(Session["IntYearIdRep6"]));
        //ar.Add(Convert.ToInt16(Session["IntMonthIdRep6"]));
        //if (Convert.ToInt16(Session["IntYearIdRep6"]) < 50)
        //{
        //    dsBillag = bld.RecPrint4(ar, 1);
        //}
        //else
        //{
        //    dsBillag = bld.RecPrint4(ar, 2);
        //}

        //System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        //strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        //strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        //strHTML.Append("Chalan Treasury");
        //strHTML.Append("</thead>");
        //strHTML.Append("<th>" + "Sl No" + "</th><th>" + "TE Month" + "</th><th>" + "TE No:" + "</th><th>" + "Treasury" + "</th><th>" + "Bill No." + "</th><th>" + "Bill Date" + "</th><th>" + " Bill Amt." + "</th><th>" + " Withdrawal Amt.");
        ////strHTML.Append("<th>" + "Sl No" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt.");
        //if (dsBillag.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dsBillag.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML.Append("<tr>");
        //        strHTML.Append("<td>" + (i + 1) + "</td>");

        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");

        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
        //        strHTML.Append("</tr>");
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("No Data Exist", this);
        //}
        //strHTML.Append("</table>");
        //lblShow.Text = strHTML.ToString();
    }
    private void PrintRep8()
    {
        //gblObj = new clsGlobalMethods();
        //bld = new BillDao();
        //DataSet dsBillag = new DataSet();
        //ArrayList ar = new ArrayList();
        //ar.Add(Convert.ToInt16(Session["IntYearIdRep6"]));
        //ar.Add(Convert.ToInt16(Session["IntMonthIdRep6"]));
        //if (Convert.ToInt16(Session["IntYearIdRep6"]) < 50)
        //{
        //    dsBillag = bld.RecPrint4(ar, 1);
        //}
        //else
        //{
        //    dsBillag = bld.RecPrint4(ar, 2);
        //}

        //System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        //strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        //strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        //strHTML.Append("Chalan Treasury");
        //strHTML.Append("</thead>");
        //strHTML.Append("<th>" + "Sl No" + "</th><th>" + "TE Month" + "</th><th>" + "TE No:" + "</th><th>" + "Treasury" + "</th><th>" + "Bill No." + "</th><th>" + "Bill Date" + "</th><th>" + " Bill Amt." + "</th><th>" + " Withdrawal Amt.");
        ////strHTML.Append("<th>" + "Sl No" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt.");
        //if (dsBillag.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dsBillag.Tables[0].Rows.Count; i++)
        //    {
        //        strHTML.Append("<tr>");
        //        strHTML.Append("<td>" + (i + 1) + "</td>");

        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");

        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBillag.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
        //        strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBillag.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
        //        strHTML.Append("</tr>");
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("No Data Exist", this);
        //}
        //strHTML.Append("</table>");
        //lblShow.Text = strHTML.ToString();
    }
    private void PrintRep5()
    {
        gblObj = new clsGlobalMethods();
        bld = new BillDao();
        DataSet dsBill = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearIdRep5"]));
        ar.Add(Convert.ToInt16(Session["IntMonthIdRep5"]));
        ar.Add(Convert.ToInt16(Session["IntTreIdRep5"]));
        ar.Add(1);
        
        if (Convert.ToInt16(Session["IntYearIdRep5"]) < 50)
        {
            dsBill = bld.RecPrint3(ar,1);
        }
        else
        {
            dsBill = bld.RecPrint3(ar, 2);
        }
        System.Text.StringBuilder strHTML = new System.Text.StringBuilder();

        strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        strHTML.Append("Chalan Treasury");
        strHTML.Append("</thead>");
        //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
        strHTML.Append("<th>" + "Sl No" + "</th><th>" + "VCHR No." + "</th><th>" + "VCHR Date" + "</th><th>" + " VCHR Amt." + "</th><th>" + " Bill Amt.");
        if (dsBill.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsBill.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                strHTML.Append("<td>" + (i + 1) + "</td>");
                //strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsBill.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsBill.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            gblObj.MsgBoxOk("No Data Exist", this);
        }
        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();
    }

    private void PrintRep2()
    {
        gblObj = new clsGlobalMethods();
        chd = new ChalanDAO();
        DataSet dsChA = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Session["IntYearIdRep2"]));
        ar.Add(Convert.ToInt16(Session["IntMonthIdRep2"]));
        if (rdCategoryA.Items[0].Selected == true)
        {
            ar.Add(1);
        }
        else
        {
            ar.Add(2);
        }
        if (Convert.ToInt16(Session["IntYearIdRep2"]) < 50)
        {
            dsChA = chd.RecPrint2(ar,1);
        }
        else
        {
            dsChA = chd.RecPrint2(ar, 2);
        }

        System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
        strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
        strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
        strHTML.Append("Chalan AG");
        strHTML.Append("</thead>");
        //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
        strHTML.Append("<th>" + "Sl No" + "</th><th>" + "TE Month" + "</th><th>" + "TE No:" + "</th><th>" + "Treasury" + "</th><th>" + "Localbody" + "</th><th>" + "Chalan No." + "</th><th>" + "Chalan Date" + "</th><th>" + " Chalan Amt." + "</th><th>" + " Schedule Amt.");
        if (dsChA.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsChA.Tables[0].Rows.Count; i++)
            {
                strHTML.Append("<tr>");
                strHTML.Append("<td >" + (i + 1) + "</td>");
                //strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");

                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");

                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsChA.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsChA.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsChA.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            gblObj.MsgBoxOk("No Data Exist", this);
        }
        strHTML.Append("</table>");
        lblShow.Text = strHTML.ToString();
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    pnlPerson.RenderControl(hw);
    //    StringReader sr = new StringReader(sw.ToString());
    //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
    //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.Write(pdfDoc);
    //    Response.End();

    //}

    //protected void ddlYearccag_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlYearccag.SelectedIndex > 0)
    //    {
    //        Session["IntYearIdRep2"] = Convert.ToInt16(ddlYearccag.SelectedValue);
    //    }
    //    else
    //    {
    //        Session["IntYearIdRep2"] = 0;
    //    }
    //    ddlMonthccag.SelectedValue = "0";
    //    lblShow.Text = "";
    //}

    protected void ddlYearn1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn1.SelectedIndex > 0)
        {
            Session["IntYearIdRep1"] = Convert.ToInt16(ddlYearn1.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep1"] = 0;
        }
        ddlTreasn1.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlMonthn1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn1.SelectedIndex > 0)
        {
            Session["IntMonthIdRep1"] = Convert.ToInt16(ddlMonthn1.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep1"] = 0;
        }
        ddlTreasn1.SelectedValue = "0";
        lblShow.Text = "";
    }

    protected void ddlDistrictn1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrictn1.SelectedIndex > 0)
        {
            Session["IntDistRep1"] = Convert.ToInt32(ddlDistrictn1.SelectedValue);
        }
        else
        {
            Session["IntDistRep1"] = 0;
        }
        FillDT(1);
        lblShow.Text = "";
    }

    protected void ddlYearn2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn2.SelectedIndex > 0)
        {
            Session["IntYearIdRep2"] = Convert.ToInt16(ddlYearn2.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep2"] = 0;
        }
        lblShow.Text = "";
    }
    protected void ddlMonthn2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn2.SelectedIndex > 0)
        {
            Session["IntMonthIdRep2"] = Convert.ToInt16(ddlMonthn2.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep2"] = 0;
        }
        lblShow.Text = "";
    }
    protected void ddlYearn3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn3.SelectedIndex > 0)
        {
            Session["IntYearIdRep3"] = Convert.ToInt16(ddlYearn3.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep3"] = 0;
        }
        ddlTreasn3.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlMonthn3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn3.SelectedIndex > 0)
        {
            Session["IntMonthIdRep3"] = Convert.ToInt16(ddlMonthn3.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep3"] = 0;
        }
        ddlTreasn3.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlDistrictn3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrictn3.SelectedIndex > 0)
        {
            Session["IntDistRep3"] = Convert.ToInt32(ddlDistrictn3.SelectedValue);
        }
        else
        {
            Session["IntDistRep3"] = 0;
        }
        FillDT(3);
        lblShow.Text = "";
    }
    protected void ddlTreasn3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTreasn3.SelectedIndex > 0)
        {
            Session["IntTreIdRep3"] = Convert.ToInt32(ddlTreasn3.SelectedValue);
        }
        else
        {
            Session["IntTreIdRep3"] = 0;
        }
        lblShow.Text = "";
    }
    protected void ddlYearn4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn4.SelectedIndex > 0)
        {
            Session["IntYearIdRep4"] = Convert.ToInt16(ddlYearn4.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep4"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlMonthn4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn4.SelectedIndex > 0)
        {
            Session["IntMonthIdRep4"] = Convert.ToInt16(ddlMonthn4.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep4"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlYearn5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn5.SelectedIndex > 0)
        {
            Session["IntYearIdRep5"] = Convert.ToInt16(ddlYearn5.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep5"] = 0;
        }
        ddlTreasn5.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlMonthn5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn5.SelectedIndex > 0)
        {
            Session["IntMonthIdRep5"] = Convert.ToInt16(ddlMonthn5.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep5"] = 0;
        }
        ddlTreasn5.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlDistrictn5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrictn5.SelectedIndex > 0)
        {
            Session["IntDistRep5"] = Convert.ToInt32(ddlDistrictn5.SelectedValue);
        }
        else
        {
            Session["IntDistRep5"] = 0;
        }
        FillDT(5);
        lblShow.Text = "";
    }
    protected void ddlTreasn5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTreasn5.SelectedIndex > 0)
        {
            Session["IntTreIdRep5"] = Convert.ToInt32(ddlTreasn5.SelectedValue);
        }
        else
        {
            Session["IntTreIdRep5"] = 0;
        }
        lblShow.Text = "";
    }
    protected void ddlYearn6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn6.SelectedIndex > 0)
        {
            Session["IntYearIdRep6"] = Convert.ToInt16(ddlYearn6.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep6"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlMonthn6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn6.SelectedIndex > 0)
        {
            Session["IntMonthIdRep6"] = Convert.ToInt16(ddlMonthn6.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep6"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlTreasn1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTreasn1.SelectedIndex > 0)
        {
            Session["IntTreIdRep1"] = Convert.ToInt32(ddlTreasn1.SelectedValue);
        }
        else
        {
            Session["IntTreIdRep1"] = 0;
        }
        lblShow.Text = "";
    }
    protected void rdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblShow.Text = "";
    }
    protected void rdCategoryA_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblShow.Text = "";
    }

    protected void ddlYearn7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn7.SelectedIndex > 0)
        {
            Session["IntYearIdRep7"] = Convert.ToInt16(ddlYearn7.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep7"] = 0;
        }
        ddlTreasn7.SelectedValue = "0";
        lblShow.Text = "";
    }
    protected void ddlYearn8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYearn8.SelectedIndex > 0)
        {
            Session["IntYearIdRep8"] = Convert.ToInt16(ddlYearn8.SelectedValue);
        }
        else
        {
            Session["IntYearIdRep8"] = 0;
        }
        lblShow.Text = "";
    }
    protected void ddlMonthn7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn7.SelectedIndex > 0)
        {
            Session["IntMonthIdRep7"] = Convert.ToInt16(ddlMonthn7.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep7"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlMonthn8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonthn8.SelectedIndex > 0)
        {
            Session["IntMonthIdRep8"] = Convert.ToInt16(ddlMonthn8.SelectedValue);
        }
        else
        {
            Session["IntMonthIdRep8"] = 0;
        }

        lblShow.Text = "";
    }
    protected void ddlDistrictn7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrictn7.SelectedIndex > 0)
        {
            Session["IntDistRep7"] = Convert.ToInt32(ddlDistrictn7.SelectedValue);
        }
        else
        {
            Session["IntDistRep7"] = 0;
        }
        FillDT(7);
        lblShow.Text = "";
    }
    protected void ddlTreasn7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTreasn7.SelectedIndex > 0)
        {
            Session["IntTreIdRep7"] = Convert.ToInt32(ddlTreasn7.SelectedValue);
        }
        else
        {
            Session["IntTreIdRep7"] = 0;
        }
        lblShow.Text = "";
    }
}
