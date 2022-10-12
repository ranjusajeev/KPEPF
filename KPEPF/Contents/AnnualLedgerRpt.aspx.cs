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

public partial class Contents_AnnualLedgerRpt : System.Web.UI.Page
{
    KPEPFGeneralDAO gendao = new KPEPFGeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCombo();
        }


    }
    private void FillCombo()
    {
        DataSet ds = new DataSet();
        ds = gendao.GetYear();
        gblObj.FillCombo(ddlYear, ds, 1);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYearIDRec"] = int.Parse(ddlYear.SelectedValue.ToString());
            DataSet dsT1 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsT1 = recd.GetReclT1(rec);


            System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
          
            strHTML.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");
            strHTML.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML.Append("CREDIT");
            strHTML.Append("</thead>");
            //strHTML.Append("<table border=1 style=border-width:1px; font-family:Verdana;font-size:large; width=600px;>");
            strHTML.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "After 4" + "</th><th>" + "Total" + "</th><th>" + " Withdrawal");
            if (dsT1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsT1.Tables[0].Rows.Count; i++)
                {
                    strHTML.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsT1.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT1.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT1.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT1.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
                    strHTML.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsT1.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                    strHTML.Append("</tr>");
                }

            }
            //else
            //{
            //    gblObj.MsgBoxOk("No Data Exist",this);
            //}
            strHTML.Append("</table>");
            lblShow1.Text = strHTML.ToString();
        
            DataSet dsAg1 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsAg1 = recd.GetReclAg1(rec);

            System.Text.StringBuilder strHTML2 = new System.Text.StringBuilder();
            strHTML2.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");

            strHTML2.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML2.Append("CREDIT AG");
            strHTML2.Append("</thead>");


            strHTML2.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "Before 2008" + "</th><th>" + "Total" + "</th><th>" + "Debit");
            
         if (dsT1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsT1.Tables[0].Rows.Count; i++)
                {
                    strHTML2.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML2.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsAg1.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML2.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg1.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML2.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg1.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML2.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg1.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                    strHTML2.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsAg1.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                    strHTML2.Append("</tr>");
                }

            }           
            strHTML2.Append("</table>");
            lblShow2.Text = strHTML2.ToString();

            /////////////////////////Credit Suspence account and Other PF////
            DataSet dsT2 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsT2 = recd.GetReclT2(rec);
       

            System.Text.StringBuilder strHTML3 = new System.Text.StringBuilder();
            strHTML3.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");

            strHTML3.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML3.Append("Credit Suspence account and Other PF");
            strHTML3.Append("</thead>");


            strHTML3.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "After 4" + "</th><th>" + "Total" + "</th><th>" + "Debit");

            if (dsT2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsT2.Tables[0].Rows.Count; i++)
                {
                    strHTML3.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML3.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsT2.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML3.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT2.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML3.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT2.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                    strHTML3.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT2.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                    strHTML3.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsT2.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML3.Append("</tr>");
                }

            }
            //else
            //{
            //    gblObj.MsgBoxOk("No Data Exist",this);
            //}
            strHTML3.Append("</table>");
            lblShow3.Text = strHTML3.ToString();

            /////////////////////////Credit suspence account and other PF _AG////
            DataSet dsAg2 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsAg2 = recd.GetReclAg2(rec);

            System.Text.StringBuilder strHTML4 = new System.Text.StringBuilder();
            strHTML4.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");

            strHTML4.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML4.Append("Credit Suspence account and Other PF - AG");
            strHTML4.Append("</thead>");


            strHTML4.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "After 4" + "</th><th>" + "Total" + "</th><th>" + "Debit");

            if (dsAg2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAg2.Tables[0].Rows.Count; i++)
                {
                    strHTML4.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML4.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsAg2.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML4.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg2.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML4.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg2.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                    strHTML4.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg2.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                    strHTML4.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsAg2.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML4.Append("</tr>");
                }

            }
            //else
            //{
            //    gblObj.MsgBoxOk("No Data Exist",this);
            //}
            strHTML4.Append("</table>");
            lblShow4.Text = strHTML4.ToString();

            /////////////////////////Credit Missing Schedule////
            DataSet dsT3 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsT3 = recd.GetReclT3(rec);

            System.Text.StringBuilder strHTML5 = new System.Text.StringBuilder();
            strHTML5.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");

            strHTML5.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML5.Append("Credit Missing Schedule");
            strHTML5.Append("</thead>");


            strHTML5.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "After 4" + "</th><th>" + "Total" + "</th><th>" + "Debit");

            if (dsT3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsT3.Tables[0].Rows.Count; i++)
                {
                    strHTML5.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML5.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsT3.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML5.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT3.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML5.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT3.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                    strHTML5.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsT3.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML5.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsT3.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                    strHTML5.Append("</tr>");
                }

            }
            //else
            //{
            //    gblObj.MsgBoxOk("No Data Exist",this);
            //}
            strHTML5.Append("</table>");
            lblShow5.Text = strHTML5.ToString();

            /////////////////////////Credit Missing Schedule- AG////
            DataSet dsAg3 = new DataSet();
            rec.IntYearId = Convert.ToInt16(Session["intYearIDRec"]);
            dsAg3 = recd.GetReclAg3(rec);

            System.Text.StringBuilder strHTML6 = new System.Text.StringBuilder();
            strHTML6.Append("<table width='80%' style='border-width:thin;font-family:Verdana;font-size:small;border-collapse:collapse' border='1'>");

            strHTML6.Append("<thead font-family:Arial;font-size:LARGE;  font-weight: bold;>");
            strHTML6.Append("Credit Missing Schedule - AG");
            strHTML6.Append("</thead>");


            strHTML6.Append("<th>" + "Month" + "</th><th>" + "Before 4" + "</th><th>" + "After 4" + "</th><th>" + "Total" + "</th><th>" + "Debit");

            if (dsAg3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAg3.Tables[0].Rows.Count; i++)
                {
                    strHTML6.Append("<tr>");
                    //strHTML.Append("<td>" + (i + 1) + "</td>");height=15px; width=35px;
                    strHTML6.Append("<td align=center; width='20%' style='border:1 solid gray;'>" + dsAg3.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                    strHTML6.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg3.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
                    strHTML6.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg3.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                    strHTML6.Append("<td align=left; width='20%' style='border:1 solid gray;'>" + dsAg3.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                    strHTML6.Append("<td align=left; width='20%' style='border:1 solid gray;' >" + dsAg3.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                    strHTML6.Append("</tr>");
                }

            }
            //else
            //{
            //    gblObj.MsgBoxOk("No Data Exist",this);
            //}
            strHTML6.Append("</table>");
            lblShow6.Text = strHTML6.ToString();
        }
    }
   
}
