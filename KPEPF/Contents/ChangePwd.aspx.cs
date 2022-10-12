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

public partial class Contents_ChangePwd : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    MembershipDAO MemDAO = new MembershipDAO();
    UserDao usrD = new UserDao();

    static int intUsrId = 0, intDistIdCp, intDistIdCp2 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialSettings();
        }
    }
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 102)
        {
            pnlChange.Visible = false;
            pnlDisableUser.Visible = true;
            FillDistrict1();
            //FillUserType1();
            FillInstType1();
        }
        else
        {
            pnlChange.Visible = true;
            pnlDisableUser.Visible = false ;

            FillDistrict();
            FillDesig();
            //FillUserType();
            SetPanel();
        }
    }
    private void SetPanel()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 101)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(Convert.ToInt32(Session["intUserId"]));
            ds = usrD.GetUserDet(ar);
            ddlDist.SelectedValue = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            ddlDist.Enabled = false;

            FillInstType();
            ddlInstType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[4].ToString();

            fillInst();
            ddlInst.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            ddlInstType.Enabled = false;
            ddlInst.Enabled = false;
            ddlUserType.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            ddlUserType.Enabled = false;
            txtFullName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtFullName.ReadOnly = true;
            ddlDesig.SelectedValue = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            txtUser.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            txtUser.ReadOnly = true;
            txtOldPwd.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            Label9.Text = "New Password";
            lblHead.Text = "Change Password";
        }
        else
        {
            Label9.Text = "Password";
            Label8.Visible = false;
            txtOldPwd.Visible = false;
            //Label2.Visible = true;
            //ddlInstType.Visible = true;
            FillInstType();
            lblHead.Text = "Create User";
        }
    }
    private void FillInstType()
    {
        DataSet ds = new DataSet();
        ds = gen.GetInstType();
        gblObj.FillCombo(ddlInstType, ds, 1);
    }
    private void FillDistrict()
    {
        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
    }

    private void FillInstType1()
    {
        DataSet ds = new DataSet();
        ds = gen.GetInstType();
        gblObj.FillCombo(ddlInstType1, ds, 1);
    }
    private void FillDistrict1()
    {
        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        gblObj.FillCombo(ddlDist1, ds, 1);
    }
    private void FillDesig()
    {
        DataSet dsDesig = new DataSet();
        dsDesig = MemDAO.GetDesignation();
        gblObj.FillCombo(ddlDesig, dsDesig, 1);
    }
    private void FillUserType()
    {
        DataSet dsu = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(ddlInstType.SelectedValue));
        dsu = usrD.GetUserType(ar);
        gblObj.FillCombo(ddlUserType, dsu, 1);
    }
    private void FillUserType1()
    {
        DataSet dsu = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(ddlInstType1.SelectedValue));
        dsu = usrD.GetUserType(ar);
        gblObj.FillCombo(ddlUserType1, dsu, 1);
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fillInst();
        if (ddlDist.SelectedIndex > 0)
        {
            intDistIdCp = Convert.ToInt16(ddlDist.SelectedValue);
            Session["intDistId"] = Convert.ToInt16(ddlDist.SelectedValue);
        }
    }
    protected void ddlInstType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstType.SelectedIndex > 0)
        {
            FillUserType();
            fillInst();
        }
    }
    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedIndex > 0)
        {
            Session["intUserTypeIdChgPwd"] = Convert.ToInt16(ddlUserType.SelectedValue);
            //if (CheckValidity() == true)
            //{

            //}
            //else
            //{
            //    gblObj.MsgBoxOk("Disable existing user and then add new user!", this);
            //}
        }
    }
    protected void ddlDesig_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 101)       //Chang pswd
        {
            if (chkOldPwd() == true)
            {
                ArrayList arr = new ArrayList();
                arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
                arr.Add(txtUser.Text.ToString());
                arr.Add(txtNewPwd.Text.ToString());
                arr.Add(Convert.ToInt16(ddlInst.SelectedValue));
                arr.Add(txtFullName.Text.ToString());
                arr.Add(Convert.ToInt16(ddlDesig.SelectedValue));
                arr.Add(1);     //flgLogin
                arr.Add(0);     //flgStatus
                arr.Add(1);     //InstType
                arr.Add(intDistIdCp);
                usrD.CreateUser(arr);

                gblObj.MsgBoxOk("Password Changed!", this);
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                gblObj.MsgBoxOk("Incorrect Old password", this);
            }
        }
        else                //Create user
        {
            if (CheckValidity() == true)
            {
                if (CheckUserNameDup() == false)
                {
                    ArrayList arr = new ArrayList();
                    arr.Add(Convert.ToInt32(Session["intUserTypeIdChgPwd"]));
                    arr.Add(txtUser.Text.ToString());
                    arr.Add(txtNewPwd.Text.ToString());
                    arr.Add(Convert.ToInt16(ddlInst.SelectedValue));
                    arr.Add(txtFullName.Text.ToString());
                    arr.Add(Convert.ToInt16(ddlDesig.SelectedValue));
                    arr.Add(0);     //flgLogin
                    arr.Add(0);     //flgStatus
                    arr.Add(Convert.ToInt16(ddlInstType.SelectedValue));     //InstType
                    arr.Add(intDistIdCp);
                    usrD.CreateUser(arr);
                    gblObj.MsgBoxOk("User Created!", this);
                    ClearCtrls();
                }
                else
                {
                    gblObj.MsgBoxOk("Duplicate User name!", this);
                }
            }
            else
            {
                gblObj.MsgBoxOk("User already exists!", this);
            }
        }
    }
    private void ClearCtrls()
    {
        ddlDist.SelectedIndex = -1;
        ddlInstType.SelectedIndex = -1;
        ddlInst.SelectedIndex = -1;
        ddlUserType.SelectedIndex = -1;
        txtFullName.Text = "";
        ddlDesig.SelectedIndex = -1;
        txtUser.Text = "";
        txtOldPwd.Text = "";
        txtNewPwd.Text = "";
        txtConPwd.Text = "";
    }
    private bool CheckUserNameDup()
    {
        bool flg = true;
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(txtUser.Text.ToString());
        ds = usrD.CheckDupUserName(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
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
    private bool chkOldPwd()
    {
        bool flg = true;
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(Session["strUser"]);
        arr.Add(txtOldPwd.Text.ToString());
        ds = usrD.CheckOldPwd(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private void fillInst()
    {
        if (ddlDist.SelectedIndex > 0)
        {
            intDistIdCp = Convert.ToInt16(ddlDist.SelectedValue);
            DataSet ds1 = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt32(Session["intDistId"]));
            arr.Add(Convert.ToInt16(ddlInstType.SelectedValue));
            ds1 = gen.GetLB(arr);
            gblObj.FillCombo(ddlInst, ds1, 1);

        }
    }
    private void fillInst1()
    {
        if (ddlDist1.SelectedIndex > 0)
        {
            intDistIdCp = Convert.ToInt16(ddlDist1.SelectedValue);
            DataSet ds1 = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt32(Session["intDistId"]));
            arr.Add(Convert.ToInt16(ddlInstType1.SelectedValue));
            ds1 = gen.GetLB(arr);
            gblObj.FillCombo(ddlInst1, ds1, 1);

        }
    }
    protected void ddlDist1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDist1.SelectedIndex > 0)
        {
            intDistIdCp2 = Convert.ToInt16(ddlDist1.SelectedValue);
        }
    }
    protected void ddlInstType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstType1.SelectedIndex > 0)
        {
            FillUserType1();
            fillInst1();
        }
    }
    protected void ddlInst1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlUserType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillUserName();
    }
    private void FillUserName()
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt16(ddlInst1.SelectedValue));
        ar.Add(Convert.ToInt16(ddlUserType1.SelectedValue));
        ds = usrD.GetUserName(ar);
        if (Convert.ToInt16(ds.Tables[0].Rows.Count) > 0)
        {
            txtUser1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtFullName1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            intUsrId = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2].ToString());
        }
    }
    protected void btnOk1_Click(object sender, EventArgs e)
    {
        
        ArrayList arr = new ArrayList();
        
        arr.Add(intUsrId);
        usrD.DisableUser(arr);
        gblObj.MsgBoxOk("User Canceled!", this);


    }
    private bool CheckValidity()
    {
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        bool flg = true;
        ar.Add(Convert.ToInt16(ddlUserType.SelectedValue));
        ar.Add(Convert.ToInt16(ddlDist.SelectedValue));
        ar.Add(Convert.ToInt16(ddlInst.SelectedValue));
        ds = usrD.CheckValidity(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) > 0)
            {
                flg = false;
            }
            else
            {
                flg = true ;
            }
        }
        return flg;
    }
}
