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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using KPEPFClassLibrary;

public partial class Pages_Reportviewer : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{
    //clsGlobalMethods gblObj = new clsGlobalMethods();
    //ReportDocument rpt = new ReportDocument();
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Response.CacheControl = "no-cache";
    //    Response.Expires = 0;
    //    Response.Clear();
    //    if (!Page.IsPostBack)
    //    {
    //        string callBackReference = Page.ClientScript.GetCallbackEventReference(this.Page, "arg", "LogOutUser", "");
    //        string logOutUserCallBackScript = "function LogOutUserCallBack(arg, context) { " + callBackReference + "; }";
    //        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "LogOutUserCallBack", logOutUserCallBackScript, true);
    //    }

    //}
    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt32(Request.QueryString.Get(0)) == 1)
    //    {

    //        rpt.Load(Request.PhysicalApplicationPath + "//Reports//TASanctionOrder.rpt");
    //        rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
    //        rpt.SetParameterValue(0, Session["NumServiceTrnID"]);
    //    }
    //    else if (Convert.ToInt32(Request.QueryString.Get(0)) == 2)
    //    {

    //        rpt.Load(Request.PhysicalApplicationPath + "//Reports//Bill.rpt");
    //        rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
    //        rpt.SetParameterValue(0, gblObj.NumBillID);
    //    }
    //    else if (Convert.ToInt32(Request.QueryString.Get(0)) == 3)
    //    {

    //        rpt.Load(Request.PhysicalApplicationPath + "//Reports//Chalan.rpt");
    //        rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
    //        rpt.SetParameterValue(0, gblObj.NumChalanID);
    //    }
    //    rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Report");
    //    CRViewer.DisplayGroupTree = false;
    //    CRViewer.ReportSource = rpt;

    //}
    //protected void Page_UnLoad(object sender, EventArgs e)
    //{
    //    rpt.Close();
    //    rpt.Dispose();
    //    rpt = null;
    //    GC.Collect();
    //    GC.WaitForPendingFinalizers();
    //}

    //#region ICallbackEventHandler Members

    //public string GetCallbackResult()
    //{
    //    throw new Exception("The method or operation is not implemented.");
    //}

    //public void RaiseCallbackEvent(string eventArgument)
    //{
    //    throw new Exception("The method or operation is not implemented.");
    //}

    //#endregion
    //protected void CRViewer_Unload(object sender, EventArgs e)
    //{
    //    if (rpt.IsLoaded)
    //    {
    //        rpt.Close();
    //        rpt.Dispose();
    //    }
    //    CRViewer.Dispose();
    //}

    clsGlobalMethods gblObj = new clsGlobalMethods();
    ReportDocument rpt = new ReportDocument();
    GeneralDAO gen = new GeneralDAO();
    CorrectionEntry crr = new CorrectionEntry();
    CorrectionEntryDao crrD = new CorrectionEntryDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.Expires = 0;
        Response.Clear();
        if (!Page.IsPostBack)
        {
            string callBackReference = Page.ClientScript.GetCallbackEventReference(this.Page, "arg", "LogOutUser", "");
            string logOutUserCallBackScript = "function LogOutUserCallBack(arg, context) { " + callBackReference + "; }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "LogOutUserCallBack", logOutUserCallBackScript, true);
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString.Get(0)) == 1)
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//TASanctionOrder.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            //string file = Request.QueryString["sorder"].ToString();
            //string[] files = Request["sorder"].ToString().Split(',');
            rpt.SetParameterValue(0, Session["NumServiceTrnID"]);
        }

        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 2)      //Bill
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//Bill.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, gblObj.NumBillID);
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 3)      //Chalan
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//Chalan.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Session["NumChalanID"]);
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 4)
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//ABCDfinal.rpt"); //ABCD
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0,Session["NumEmpId"]);
            rpt.SetParameterValue(1, gblObj.IntYearABCD);
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 5)          //UtilizationCertificate
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//UtilizationCertificate.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Session["NumEmpId"]);
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 6)          //ABCD_FormD  
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//formd.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Session["NumEmpId"]);
            rpt.SetParameterValue(1, gblObj.IntYear);
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 7)      //Card particulars
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//CardParticulars.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["NumEmpId"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 26)      //Emp Dist wise
        {
            if (Convert.ToInt16(Session["empRptType"]) == 1 || Convert.ToInt16(Session["empRptType"]) == 0)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//EmployeeDist.rpt");
                rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
                rpt.SetParameterValue(0, Convert.ToInt16(Session["intDistEmp1"]));
                rpt.SetParameterValue(1, Convert.ToInt16(Session["empRptType"]));
            }
            else if (Convert.ToInt16(Session["empRptType"]) == 3)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//EmpWithOB.rpt");
                rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
                rpt.SetParameterValue(0, Convert.ToInt16(Session["intDistEmp1"]));
            }
            if (Convert.ToInt16(Session["empRptType"]) == 4)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//EmpWithoutOB.rpt");
                rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
                rpt.SetParameterValue(0, Convert.ToInt16(Session["intDistEmp1"]));
            }
            if (Convert.ToInt16(Session["empRptType"]) == 5)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//EmployeeCons.rpt");
                rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            }
            
        }

        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 27)      //Suspns acc
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//Suspense.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["intDistOPF"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["intYearOPF"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 28)      //Other PF acc
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//OtherPFAcc.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["intDistOPF"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["intYearOPF"]));
        }


        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 29)      //App Status report
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//AppStatus.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["intYearIdAppR"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["intMonthIdAppR"]));
            rpt.SetParameterValue(2, Convert.ToInt64(Session["intTrnTpAppR"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 30)      //App Status report AG
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//AppStatusAG.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["intYearIdAppR"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 31)      //Corr entry
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//CorrEntry.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["intAccNoCorr"]));
        }

        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 10)      //RptToAG
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//RptToAG.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["numAgRpt1"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["numAgRpt2"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 11)      //RptToAG With
        {

            rpt.Load(Request.PhysicalApplicationPath + "//Reports//RptToAgWith.rpt");
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt64(Session["numAgRpt1"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["numAgRpt2"]));
        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 8)      //Ledger
        {
            //int y = Convert.ToInt16(Session["intYearIdLedger"]);
            if (Convert.ToInt16(Session["intYearIdLedger"]) == 47)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//Ledger1.rpt");
            }
            else if (Convert.ToInt16(Session["intYearIdLedger"]) <= 49)
            {
                rpt.Load(Request.PhysicalApplicationPath + "//Reports//Ledger.rpt");
            }
            else
            {
                if (CorrectionOccured() == true)
                {
                    rpt.Load(Request.PhysicalApplicationPath + "//Reports//LedgerC.rpt");
                }
                else
                {
                    // Ranjitha on 02112020

                    // rpt.Load(Request.PhysicalApplicationPath + "//Reports//Ledger50.rpt");
                    rpt.Load(Request.PhysicalApplicationPath + "//Reports//LedgerC.rpt");
                   
                }
            }
            rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
            rpt.SetParameterValue(0, Convert.ToInt32(Session["numEmpIdLedger"]));
            rpt.SetParameterValue(1, Convert.ToInt64(Session["intYearIdLedger"]));

        }
        else if (Convert.ToInt32(Request.QueryString.Get(0)) == 9)      //Ledger ___Correction Report
        {
            rpt.Load(Request.PhysicalApplicationPath + "//Reports//CorrRpt.rpt");
            rpt.SetParameterValue(0, Convert.ToInt32(Session["numEmpIdLedger"]));
        }
        else if (Convert.ToInt16(Request.QueryString.Get(0)) == 55)
        {
            rpt.Load(Request.PhysicalApplicationPath + "//Reports//RejList.rpt");
            rpt.SetParameterValue(0, Convert.ToInt16(Session["intTrnTpAppR"]));
        }
        rpt.SetDatabaseLogon("KPEPFUN", "aiafae");
       // rpt.SetDatabaseLogon("sa", "");
        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Report");

        CRViewer.DisplayGroupTree = false;
        CRViewer.ReportSource = rpt;
    }
    private Boolean CorrectionOccured()
    {
        //Session["numEmpIdLedger"]
        DataSet ds = new DataSet();
        Boolean flg = true;
        crr.IntAccNo = Convert.ToInt32(Session["numEmpIdLedger"]);
        ds = crrD.CheckCorrectionEntry4CardGen(crr);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    flg = true;
        //}
        //else
        //{
        //    flg = false;
        //}
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) > 0)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private Boolean FindYearCalc()
    {
        Boolean flg = true;
        int yr;
        yr = gen.GetCCYearId();

        if (yr == Convert.ToInt16(Session["intYearIdLedger"]))
        {
            flg = true;
        }
        else
        {
            flg = false;
        }

        return flg;
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        rpt.Close();
        rpt.Dispose();
        rpt = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    #region ICallbackEventHandler Members

    public string GetCallbackResult()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
    protected void CRViewer_Unload(object sender, EventArgs e)
    {
        if (rpt.IsLoaded)
        {
            rpt.Close();
            rpt.Dispose();
        }
        CRViewer.Dispose();
    }
}
