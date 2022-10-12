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

public partial class Contents_ReclCalc : System.Web.UI.Page
{
    GeneralDAO gend = new GeneralDAO();
    Recl rec = new Recl();
    ReclDao recd = new ReclDao();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intMaxYearIdPde"] = gend.GetCCYearIdPDE();
            Session["intMaxYearId"] = gend.GetCCYearId();
            fillYear();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Save to AP_RecLevl3New (yr, Mth, Posted, Misclassifd, Missing)
        //Session["intMaxYearId"] = gend.GetCCYearId();
        //Session["intMaxYearIdPde"] = gend.GetCCYearIdPDE();
        //if (Convert.ToInt16(Session["intMaxYearIdPde"]) <= 23)
        //{
            for (int i = 18; i <= Convert.ToInt16(Session["intMaxYearIdPde"]); i++)
            {
                SaveRecLevl3New(i);

                rec.IntYearId = i;
                recd.UpdRecLevl3NewP(rec);      // Treas Posted        AP_RecLevl3New_PostedTreas
                recd.UpdRecLevl3NewPAg(rec);    // AG Posted           AP_RecLevl3New_PostedAG

                recd.UpdRecLevl3NewUP1(rec);    // Treas MissClass     AP_RecLevl3New_UnPostedTreas
                recd.UpdRecLevl3NewUP1Ag(rec);  // AG MissClass        AP_RecLevl3New_UnPostedAG

                recd.UpdRecLevl3NewUP2(rec);    // Treas Miss Sched    AP_RecLevl3New_UnPosted2Treas
                recd.UpdRecLevl3NewUP2Ag(rec);  // AG Miss Sched       AP_RecLevl3New_UnPosted2AG
            }
        //}
        //else
        //{
        //    for (int i = 50; i <= Convert.ToInt16(Session["intMaxYearId"]); i++)
        //    {
        //        SaveRecLevl3New(i);

        //        rec.IntYearId = i;
        //        recd.UpdRecLevl3NewP(rec);
        //        recd.UpdRecLevl3NewPAg(rec);

        //        recd.UpdRecLevl3NewUP1(rec);
        //        recd.UpdRecLevl3NewUP1Ag(rec);

        //        recd.UpdRecLevl3NewUP2(rec);
        //        recd.UpdRecLevl3NewUP2Ag(rec);
        //    }
        //}
        gblObj.MsgBoxOk("Completed!", this);
        //btnOK.Enabled = false;
    }
    private void SaveRecLevl3New(int yr)
    {
        rec.IntYearId = yr;

        for (int j = 1; j <= 13; j++)
        {
            rec.IntMonthId = j;
            for (int k = 1; k <= 2; k++)
            {
                rec.IntSource = k;
                recd.SaveRecLevl3New(rec);
            }
        }
    }
    private void SaveRecLevl3CurrAGP(int yr)
    {
        rec.IntYearId = yr;

        for (int j = 1; j <= 13; j++)
        {
            rec.IntMonthId = j;
            for (int k = 1; k <= 2; k++)
            {
                rec.IntSource = k;
                recd.SaveRecLevl3Curr(rec);
            }
        }
    }
    private void SaveRecLevl3CurrTP(int yr)
    {
        rec.IntYearId = yr;

        for (int j = 1; j <= 13; j++)
        {
            rec.IntMonthId = j;
            for (int k = 1; k <= 2; k++)
            {
                rec.IntSource = k;
                recd.SaveRecLevl3CurrT(rec);
            }
        }
    }
    protected void btnOK1_Click(object sender, EventArgs e)
    {
        // Save to AP_RecLevl3 Credit (yr, Mth, Dt, Splits of Unposted AG)
        //Session["intMaxYearId"] = gend.GetCCYearId();
        for (int i = 18; i <= Convert.ToInt16(Session["intMaxYearIdPde"]); i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                ArrayList ar = new ArrayList();
                ar.Add(i);
                ar.Add(j);
                recd.SaveAP_RecLevl31(ar);      // Save to AP_RecLevl3  blank values
                recd.SaveAP_RecLevl32(ar);      // Save to AP_RecLevl3 
                recd.SaveAP_RecLevl33(ar);
                recd.SaveAP_RecLevl34(ar);
                recd.SaveAP_RecLevl35(ar);
                recd.SaveAP_RecLevl36(ar);
                recd.SaveAP_RecLevl37(ar);
                recd.SaveAP_RecLevl38(ar);
            }
        }
        gblObj.MsgBoxOk("Completed!", this);
        //btnOk1.Enabled = false;
    }
    protected void btnOK2_Click(object sender, EventArgs e)
    {
        // Save to AP_RecLevl3 Dedit (yr, Mth, Dt, Splits of Unposted AG)
        //Session["intMaxYearId"] = gend.GetCCYearId();
        for (int i = 18; i <= Convert.ToInt16(Session["intMaxYearIdPde"]); i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                ArrayList ar = new ArrayList();
                ar.Add(i);
                ar.Add(j);
                recd.SaveAP_RecLevl3Dt1(ar);
                recd.SaveAP_RecLevl3Dt2(ar);
                recd.SaveAP_RecLevl3Dt3(ar);
                recd.SaveAP_RecLevl3Dt4(ar);
                //recd.SaveAP_RecLevl3Dt5(ar);
                recd.SaveAP_RecLevl3Dt6(ar);
                recd.SaveAP_RecLevl3Dt7(ar);
                recd.SaveAP_RecLevl3Dt8(ar);
            }
        }
        //btnOk2.Enabled = false;
        gblObj.MsgBoxOk("Completed!", this);
    }
    protected void btnLat_Click(object sender, EventArgs e)
    {
        
        for (int i = 50; i <= Convert.ToInt16(Session["intMaxYearId"]); i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                rec.IntYearId = i;
                rec.IntMonthId = j;

                recd.SaveRecLevl3CurrNullVal(rec);     // Save with 0 value
                SaveRecLevl3CurrAGP(i);                // Upd AG vals
                SaveRecLevl3CurrTP(i);                // Upd AG vals

                //recd.UpdRecLevl3NewP(rec);
                //recd.UpdRecLevl3NewPAg(rec);

                //recd.UpdRecLevl3NewUP1(rec);
                //recd.UpdRecLevl3NewUP1Ag(rec);

                //recd.UpdRecLevl3NewUP2(rec);
                //recd.UpdRecLevl3NewUP2Ag(rec);
            }
        }
        gblObj.MsgBoxOk("Ok", this);
    }
    private void fillYear()
    {
        KPEPFGeneralDAO kgen = new KPEPFGeneralDAO();
        DataSet dsyr = new DataSet();
        dsyr = kgen.GetYearOnLine();
        gblObj.FillCombo(ddlYear, dsyr, 1);
    }
    protected void btnCurrMthCr_Click(object sender, EventArgs e)
    {

    }
    protected void btnCurrMthDt_Click(object sender, EventArgs e)
    {

    }
    protected void btnCrT_Click(object sender, EventArgs e)
    {
        // Credit Treasury ////////////////
        DataSet ds = new DataSet();
        
        for (int i = 1; i <= 13; i++)
        {
            rec.IntYearId = Convert.ToInt16(Session["intYear"]);
            rec.IntMonthId = i;
            ds =  recd.GetTreasuryDataMonthWiseNew(rec);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(Convert.ToInt16(ds.Tables[0].Rows[j].ItemArray[0]));
                    ar.Add(i);
                    ar.Add(Convert.ToInt16(ds.Tables[0].Rows[j].ItemArray[2]));
                    ar.Add(1);
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[4]));            //Pt
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[14]));           //ut1
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[15]));           //ut2
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[16]));           //ut3    
                    ar.Add(0);                                                              //ut4
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[7]));            //PAg
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[5]));            //ua1
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[17]));            //ua2
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[9]));            //ua3
                    ar.Add(0);                                                              //ut4
                    ar.Add(0);                                                              //ut5
                    ar.Add(0);                                                              //ut6


                    recd.UpdCredit(ar);
                }
            }
            
        }
        gblObj.MsgBoxOk("Updated!!!", this);
    }
    protected void btnCrAg_Click(object sender, EventArgs e)
    {
        // Credit AG ////////////////

    }
    protected void btnDtT_Click(object sender, EventArgs e)
    {
        // Debit Treasury ////////////////
        DataSet ds = new DataSet();

        for (int i = 1; i <= 13; i++)
        {
            rec.IntYearId = Convert.ToInt16(Session["intYear"]);
            rec.IntMonthId = i;
            ds = recd.GetTreasuryDataMonthWiseNewDt(rec);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(Convert.ToInt16(ds.Tables[0].Rows[j].ItemArray[0]));
                    ar.Add(i);
                    ar.Add(Convert.ToInt16(ds.Tables[0].Rows[j].ItemArray[2]));
                    ar.Add(2);
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[4]));            //Pt
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[7]));           //ut1
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[5]));           //ut2
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[6]));           //ut3    
                    ar.Add(0);                                                              //ut4
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[8]));            //PAg
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[10]));            //ua1
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[11]));            //ua2
                    ar.Add(Convert.ToDouble(ds.Tables[0].Rows[j].ItemArray[9]));            //ua3
                    ar.Add(0);                                                              //ut4
                    ar.Add(0);                                                              //ut5
                    ar.Add(0);                                                              //ut6
                    recd.UpdCredit(ar);
                }
            }
        }
        gblObj.MsgBoxOk("Updated!!!", this);
    }

    protected void btnRefreshCr_Click(object sender, EventArgs e)
    {
        refreshTrn(1);
        refreshTrn(2);
        gblObj.MsgBoxOk("added Cr!!!", this);
    }
    protected void btnRefreshDt_Click(object sender, EventArgs e)
    {
        refreshTrn(2);
        gblObj.MsgBoxOk("added Dt!!!", this);
    }
    
    private void refreshTrn(int tp)
    {
        ArrayList ar = new ArrayList();
        ArrayList arDel = new ArrayList();
        arDel.Add(tp);
        recd.delRecCurrTrn(arDel);

        DataSet dsT = new DataSet();
        dsT = gend.GetDisTreasuryFullNew();
        for (int i = 50; i <= 53; i++)
        {
            for (int j = 1; j <= 13; j++)
            {

                for (int k = 0; k < dsT.Tables[0].Rows.Count; k++)
                {
                    ar.Add(i);
                    ar.Add(j);
                    ar.Add(Convert.ToInt16(dsT.Tables[0].Rows[k].ItemArray[0]));
                    ar.Add(tp);
                    recd.RefreshCr(ar);
                    ar.Clear();
                }
            }
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedIndex > 0)
        {
            Session["intYear"] = Convert.ToInt16(ddlYear.SelectedValue);
        }
        else
        {
            Session["intYear"] = 0;
        }
    }
}
