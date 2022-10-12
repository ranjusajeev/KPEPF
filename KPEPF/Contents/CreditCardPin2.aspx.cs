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
public partial class Contents_CreditCardPin2 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    EmployeeDAO empD = new EmployeeDAO();
    GeneralDAO gen = new GeneralDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt16(Request.QueryString["flg"]) == 1)
            {
                Session["flg"] = 1;             
                pnl.Visible = true;
                pnlCardCons.Visible = false;
                Label1.Text = "Credit Card";
            }
            else
            {
                pnl.Visible = false;
                pnlCardCons.Visible = true;
                Label1.Text = "Credit Card Consolidation";
                FillGrid();
            }
            if (Convert.ToInt16(Session["flgcs"]) == 1)
            {
                pnl.Visible = true;
                pnlCardCons.Visible = false;
                Label1.Text = "Credit Card";
                if (Convert.ToInt16(Session["flg"]) == 3)
                {
                    txtUser.Text = Session["NumEmpId"].ToString();
                }
                else
                {
                    txtUser.Text = "";
                }
            }
        }
    }
    private void FillGrid()
    {
        DataSet dsg = new DataSet();
        dsg = gen.getCardCons();
        if (dsg.Tables[0].Rows.Count > 0)
        {
            gdvCardCons.DataSource = dsg;
            gdvCardCons.DataBind();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        
        if (txtUser.Text.ToString() != "" && txtUser.Text.ToString() != null && txtPin.Text.ToString() != "" && txtPin.Text.ToString() != null)
        {
            ar.Add(Convert.ToInt32(txtUser.Text));
            ar.Add(Convert.ToDouble(txtPin.Text));
            ds = empD.CheckPin(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["NumEmpId"] = Convert.ToInt32(txtUser.Text.ToString());
                Response.Redirect("CreditCardNew.aspx");
            }
            else
            {
                gblObj.MsgBoxOk("Invalid User/Password!!!", this);
            }
        }
        
    }
    protected void txtUser_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtUser.Text) > 0)
        {
            //Session["intCnt"] = 0;
            //Session["numEmpIdLedgerPin"] = Convert.ToInt32(txtUser1.Text);
            //DataSet dsN = new DataSet();
            FillNameAccNo();
        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.!", this);
        }
    }
    private void FillNameAccNo()
    {
        Employee emp = new Employee();
        EmployeeDAO empDao = new EmployeeDAO();
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txtUser.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsN.Tables[0].Rows[0].ItemArray[2]) == 1)
            {
                lblClosed.Text = dsN.Tables[0].Rows[0].ItemArray[9].ToString();
                txtPin.Enabled = false;
                btnLogin.Enabled = false;
            }
            else
            {
                lblClosed.Text = "...";
                txtPin.Enabled = true;
                btnLogin.Enabled = true;
            }
        }
        //else
        //{
        //    lblClosed.Text = "";
        //}
    }
    protected void btnLogin2_Click(object sender, EventArgs e)
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();

        if (txtUser.Text.ToString() != "" && txtUser.Text.ToString() != null && txtPin.Text.ToString() != "" && txtPin.Text.ToString() != null)
        {
            ar.Add(Convert.ToInt32(txtUser.Text));
            ar.Add(Convert.ToDouble(txtPin.Text));
            ds = empD.CheckPin(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["NumEmpId"] = Convert.ToInt32(txtUser.Text.ToString());
                Response.Redirect("CreditCardNew2.aspx");
            }
            else
            {
                gblObj.MsgBoxOk("Invalid User/Password!!!", this);
            }
        }
    }
}
