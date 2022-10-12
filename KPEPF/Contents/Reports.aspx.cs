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
using System.Diagnostics;

public partial class Reports_Reports : System.Web.UI.Page
{
   // private crReportDocument = new CrystalReport1 ();
    //public static String pdfPath; 
    ReportDocument rptDoc = new ReportDocument();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        //* Mahesh*//
        int intNoParam;
        string strParam;
        string[] strSplitArrin = new string[10];
        string reportname;

        reportname = Session["rptName"].ToString();//Request.QueryString["rptName"];
        if (Request.QueryString["noParams"] != null)
        {
            intNoParam = int.Parse(Request.QueryString["noParams"].ToString());
            strParam = Session["ParameterArray"].ToString();
            rptDoc.Load(Request.PhysicalApplicationPath + "Content\\Reports\\" + reportname);
            rptDoc.SetDatabaseLogon("KPEPFUN", "aiafae");
            if (strParam.Length > 0)
            {
                strSplitArrin = strParam.Split(',');
                strParam.Split('.');
                if (intNoParam > 0)
                {
                    for (int i = 0; i < intNoParam; i++)
                    {
                        rptDoc.SetParameterValue(i, strSplitArrin[i]);
                    }
                }
            }
            CrystalReportViewer1.DisplayGroupTree = false;
            CrystalReportViewer1.ReportSource = rptDoc;

            //* Mahesh*//
            //ReportDocument rptDoc = new ReportDocument();
            //ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //string strParam = "";
            //string reportname;
            //int intNoParam;
            //string[] strSplitArrin = new string[10];

            //reportname = "TASanctionOrder.rpt";//Session["rptName"].ToString();
            ////strParam = Session["ParameterArray"].ToString();
            //intNoParam = Convert.ToInt32(Session["ParamCount"].ToString());
            //rptDoc.Load(Request.PhysicalApplicationPath + "Reports\\" + reportname);
            //crConnectionInfo.ServerName = "IKMPC207";
            //crConnectionInfo.DatabaseName = "KPEPF_Online";
            //crConnectionInfo.UserID = "KPEPFUN";
            //crConnectionInfo.Password = "aiafae";

            ////rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Request.PhysicalApplicationPath + "Reports\\" + reportname);
            ////string popupscript = "<script language='javascript'>" + "window.open('Export/Personnel.pdf');</script>";
            ////Page.ClientScript.RegisterStartupScript(this.GetType(), "PopUpWindow", popupscript, false);

            ////string @paramater1 = "17";
            //rptDoc.SetParameterValue("@numWithRequestID", Request.Params["parameter1"]);
            //rptDoc.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "~/Reports/" + reportname);

            ////rptDoc.SetDatabaseLogon(crConnectionInfo.UserID, crConnectionInfo.Password, crConnectionInfo.ServerName, crConnectionInfo.DatabaseName);
            //rptDoc.SetDatabaseLogon(crConnectionInfo.UserID, crConnectionInfo.Password);
            //if (strParam.Length > 0)
            //{
            //    strSplitArrin = strParam.Split(',');
            //    strParam.Split('.');
            //    if (intNoParam > 0)
            //    {
            //        for (int i = 0; i < intNoParam; i++)
            //        {
            //            rptDoc.SetParameterValue(i, strSplitArrin[i]);
            //        }
            //    }
            //}
            CrystalReportViewer1.ReportSource = rptDoc;
            PageMargins myMargins = rptDoc.PrintOptions.PageMargins;
            rptDoc.PrintOptions.ApplyPageMargins(myMargins);
            rptDoc.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "report.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex = null;
            }

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {       
        Response.Redirect("~/Contents/Menu.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //rptDoc.PrintToPrinter(1, false, 1, 2);
        rptDoc.PrintToPrinter(Convert.ToInt16(txtNoCopy.Text), false, 1, Convert.ToInt16(txtNoPages.Text));        
    }
    //private void CreateCrystalReport()
    //{
    //    string strParam = Session["ParameterArray"].ToString();

    //    ReportDocument rd = new ReportDocument();
    //    rd.SetParameterValue("@numWithRequestID", strParam);
    //    /*export to pdf*/
    //    ExportOptions expo = rd.ExportOptions;
    //    expo.ExportDestinationType = ExportDestinationType.DiskFile;
    //    expo.ExportFormatType = ExportFormatType.PortableDocFormat;
    //    expo.DestinationOptions = new DiskFileDestinationOptions();

    //    string fileName = "TASanctionOrder.rpt";
    //    string filePath = @"~/Reports/" + fileName;

    //    rd.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(filePath + ".pdf"));
    //    Session["reportDocument"] = rd;
    //    string script = "<script language='javascript'> window.open('OpenFile.aspx?action=401&filepath=" + filePath + "&filename=" + fileName + "');</script>";
    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupCP", script, false);
    //}
}
