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
public partial class Contents_DPWithdrawal : System.Web.UI.Page
{
    KPEPFGeneralDAO genDAO = new KPEPFGeneralDAO();
    GeneralDAO gendao = new GeneralDAO();
    clsGlobalMethods gblobj = new clsGlobalMethods();
    AOApproval aoapp = new AOApproval();
    AOApprovalDAO aoappDAO = new AOApprovalDAO();
    AGDAO agDAO = new AGDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialsettings();
        }

    }
    private void Initialsettings()
    {

    }
    protected void btnSaveDW_Click(object sender, EventArgs e)
    {

    }

    protected void txtOrdrDtDW_TextChanged(object sender, EventArgs e)
    {
        int index = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gvr = gdvDebitWith.Rows[index];
        TextBox txtDt = (TextBox)gvr.FindControl("txtOrdrDtDW");

        string dt1 = txtDt.Text.ToString();
        string dt2 = "01/04/2001";
        string dt3 = DateTime.Now.ToString();
        if (gblobj.isValidDate(txtDt, this) == true)
        {
            if (gblobj.CheckDate2(dt2, dt1) == true)
            {
                if (gblobj.CheckDate2(dt1, dt3) == true)
                {
                    ArrayList ar = new ArrayList();
                    ar.Add(txtDt.Text.ToString());
                    Session["IntYearSearchChal"] = genDAO.FindYearIdFromDate(ar);
                }
                else
                {
                    gblobj.MsgBoxOk("Invalid Date", this);
                    txtDt.Text = "";
                }
            }
            else
            {
                gblobj.MsgBoxOk("Invalid Date", this);
                txtDt.Text = "";
            }
        }
        else
        {
            gblobj.MsgBoxOk("Invalid Date", this);
            txtDt.Text = "";
        }
    }
}
