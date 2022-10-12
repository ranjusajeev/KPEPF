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
using System.IO;
using KPEPFClassLibrary;


public partial class Contents_AppForms : System.Web.UI.Page
{
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gendao.getTransaction();
            gblObj.FillCombo(ddlAppForm, ds, 1);
        }
    }
    protected void ddlAppForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string AppName = ddlAppForm.SelectedItem.Text;
        //string strFileName = AppName + ".pdf";
        //string FlPath = Request.PhysicalApplicationPath + "AppForms/" + strFileName;
        //String frame = "<iframe  Width='100%' id ='iframeApp' scrolling='auto' runat='server'   frameborder='1' src='" + FlPath + "' height='600'></iframe>";
        //APP.InnerHtml = frame;

        string AppName = ddlAppForm.SelectedItem.Text;
        string strFileName = AppName + ".pdf";

        String frame = "<iframe  Width='100%' id ='iframeApp' scrolling='auto' runat='server'   frameborder='1' src='../AppForms/" + strFileName + "' height='600'></iframe>";
        APP.InnerHtml = frame;

    }
}
