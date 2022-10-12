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
using System.Collections.Generic;
using KPEPFClassLibrary;


public partial class Contents_EmpAdd : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    //KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    GeneralDAO gen;
    Employee emp;
    EmployeeDAO empDao;

    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (!IsPostBack)
        {
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            InitialSettings();
            FillCmbs();
        }
    }
    private void InitialSettings()
    {
        if (Convert.ToInt16(Session["intTrnType"]) == 34)
        {
            pnlEntry.Visible = true;
            SetGridDefault(1);
            fillGridCmbsAdd(gvNominee);
            pnlEntryU.Visible = false;
        }
        else
        {
            pnlEntry.Visible = false;
            pnlEntryU.Visible = true;
            SetGridDefault(2);
            fillGridCmbsAdd(gvNomineeU);
        }
    }
    private void fillGridCmbsAdd(GridView gdv)
    {
        gen = new GeneralDAO();
        DataSet dsRelation = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(3);
        dsRelation = gen.GetRelationship(ArrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlRel = (DropDownList)grdVwRow.FindControl("ddlRel");
            gblObj.FillCombo(ddlRel, dsRelation, 1);
        }
    }
    //private void fillGridCmbs()
    //{
    //    gen = new GeneralDAO();
    //    DataSet dsRelation = new DataSet();
    //    ArrayList ArrIn = new ArrayList();
    //    ArrIn.Add(3);
    //    dsRelation = gen.GetRelationship(ArrIn);
    //    for (int i = 0; i < gvNomineeU.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gvNomineeU.Rows[i];
    //        DropDownList ddlRel = (DropDownList)grdVwRow.FindControl("ddlRelU");
    //        gblObj.FillCombo(ddlRel, dsRelation, 1);
    //    }
    //}
    private void FillCmbs()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        DataSet ds = new DataSet();
        ds = gen.GetDistrict();
        if (Convert.ToInt16(Session["intTrnType"]) == 34)
        {
            gblObj.FillCombo(ddlDistCurr, ds, 1);
        }
        else
        {
            gblObj.FillCombo(ddlDistCurrU, ds, 1);
        }
        DataSet dsd = new DataSet();
        dsd = gen.GetDistrict();
        if (Convert.ToInt16(Session["intTrnType"]) == 34)
        {
            gblObj.FillCombo(ddlDist, dsd, 1);
        }
        else
        {
            gblObj.FillCombo(ddlDistU, ds, 1);
        }


    }
    private void ClrCtrls()
    {
        FillInst();
        if (Convert.ToInt16(Session["intTrnType"]) == 34)
        {
            txtAccNo.Text = "";
            ddlDistCurr.SelectedIndex = 0;
            txtAccNo.Text = "";
            txtName.Text = "";
            if (Convert.ToInt32(Session["IntLbEmp"]) > 0)
            {
                ddlLb.SelectedIndex = 0;
            }
        }
        else
        {
            txtAccNoU.Text = "";
            txtNameU.Text = "";
            ddlDistU.SelectedIndex = 0;
            ddlDistCurrU.SelectedIndex = 0;
            ddlLbU.SelectedIndex = 0;
            txtAccNoU.Text = "";

            txtwefU.Text = "";
            txtAdnU.Text = "";
            txtDesU.Text = "";
        }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        ClrCtrls();
        btnSave.Enabled = true;
        ArrayList ar = new ArrayList();
        //if (Convert.ToInt16(ddlDist.SelectedValue) > 0)
        //{
        //    Session["IntDistEmpOrg"] = Convert.ToInt16(ddlDist.SelectedValue);
        //}
        //else
        //{
        //    Session["IntDistEmpOrg"] = 0;
        //}
        ar.Add(Convert.ToInt16(ddlDist.SelectedValue));
        LblPr.Text = gen.GetDistrictPrfxFromId(ar);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (MandatoryField() == true)
        {
            SaveToEmpMst();
            //saveNom();
            saveNominee(gvNominee, 1);
            gblObj.MsgBoxOk("Saved", this);
            btnSave.Enabled = false;
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
    }
    //private Boolean ChkShareU()
    //{
    //    Boolean fg = true;
    //    int shr = 0;
    //    for (int i = 0; i < gvNomineeU.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gvNomineeU.Rows[i];
    //        TextBox txtNomineShareAss = (TextBox)(gvr.FindControl("txtNomineShare"));
    //        if (txtNomineShareAss.Text != "")
    //        {
    //            shr = shr + Convert.ToInt16(txtNomineShareAss.Text);
    //        }
    //        else
    //        {
    //            shr = 0;
    //            fg = false;
    //            gblObj.MsgBoxOk("Enter share!", this);
    //        }
    //    }
    //    if (shr != 100)
    //    {
    //        fg = false;
    //        gblObj.MsgBoxOk("Share is not valid!", this);
    //    }
    //    else
    //    {
    //        fg = true;
    //    }
    //    return fg;
    //}
    private Boolean ChkShare(GridView gdv)
    {
        Boolean fg = true;
        int shr = 0;
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow gvr = gdv.Rows[i];
            TextBox txtNomineShareAss = (TextBox)(gvr.FindControl("txtNomineShare"));
            if (txtNomineShareAss.Text != "")
            {
                shr = shr + Convert.ToInt16(txtNomineShareAss.Text);
            }
            else
            {
                shr = 0;
                fg = false;
                gblObj.MsgBoxOk("Enter share!", this);
            }
        }
        if (shr != 100)
        {
            fg = false;
            gblObj.MsgBoxOk("Share is not valid!", this);
        }
        else
        {
            fg = true;
        }
        return fg;
    }
    private void saveNominee(GridView gdv, int flg)
    {
        empDao = new EmployeeDAO();
        if (ChkShare(gdv) == true)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                ArrayList arr = new ArrayList();
                GridViewRow gvr = gdv.Rows[i];
                TextBox txtNomineName = (TextBox)gvr.FindControl("txtNomineName");
                DropDownList ddlRel = (DropDownList)gvr.FindControl("ddlRel");
                TextBox txtNomineAge = (TextBox)gvr.FindControl("txtNomineAge");
                TextBox txtNomineShare = (TextBox)gvr.FindControl("txtNomineShare");
                Label lblNomId = (Label)gvr.FindControl("lblNomId");
                if (flg == 1)
                {
                    arr.Add(Convert.ToInt32(txtAccNo.Text));
                }
                else
                {
                    arr.Add(Convert.ToInt32(txtAccNoU.Text));
                }
                arr.Add(i + 1);
                arr.Add(txtNomineName.Text.ToString());

                if (ddlRel.SelectedIndex > 0)
                {
                    arr.Add(Convert.ToInt16(ddlRel.SelectedValue));
                }
                else
                {
                    arr.Add(0);
                }
                arr.Add(Convert.ToInt16(txtNomineAge.Text));
                arr.Add(Convert.ToInt16(txtNomineShare.Text));
                arr.Add(1);
                if (lblNomId.Text != "" && lblNomId.Text != null)
                {
                    arr.Add(Convert.ToInt32(lblNomId.Text));
                }
                else
                {
                    arr.Add(0);
                }
                empDao.saveNomineeDet(arr);
            }
        }
    }
    private void saveNomU()
    {
        empDao = new EmployeeDAO();
        if (ChkShare(gvNomineeU) == true)
        {
            for (int i = 0; i < gvNomineeU.Rows.Count; i++)
            {
                ArrayList arr = new ArrayList();
                GridViewRow gvr = gvNomineeU.Rows[i];
                TextBox txtNomineName = (TextBox)gvr.FindControl("txtNomineName");
                DropDownList ddlRel = (DropDownList)gvr.FindControl("ddlRel");
                TextBox txtNomineAge = (TextBox)gvr.FindControl("txtNomineAge");
                TextBox txtNomineShare = (TextBox)gvr.FindControl("txtNomineShare");
                Label lblNomId = (Label)gvr.FindControl("lblNomId");

                arr.Add(Convert.ToInt32(txtAccNoU.Text));
                arr.Add(i + 1);
                arr.Add(txtNomineName.Text.ToString());

                if (ddlRel.SelectedIndex > 0)
                {
                    arr.Add(Convert.ToInt16(ddlRel.SelectedValue));
                }
                else
                {
                    arr.Add(0);
                }
                arr.Add(Convert.ToInt16(txtNomineAge.Text));
                arr.Add(Convert.ToInt16(txtNomineShare.Text));
                arr.Add(1);
                if (lblNomId.Text != "" && lblNomId.Text != null)
                {
                    arr.Add(Convert.ToInt32(lblNomId.Text));
                }
                else
                {
                    arr.Add(0);
                }
                empDao.saveNomineeDet(arr);
            }
        }
    }
    private void saveNom()
    {
        empDao = new EmployeeDAO();

        if (ChkShare(gvNominee) == true)
        {
            for (int i = 0; i < gvNominee.Rows.Count; i++)
            {
                ArrayList arr = new ArrayList();
                GridViewRow gvr = gvNominee.Rows[i];
                TextBox txtNomineName = (TextBox)gvr.FindControl("txtNomineName");
                DropDownList ddlRel = (DropDownList)gvr.FindControl("ddlRel");
                TextBox txtNomineAge = (TextBox)gvr.FindControl("txtNomineAge");
                TextBox txtNomineShare = (TextBox)gvr.FindControl("txtNomineShare");
                Label lblNomId = (Label)gvr.FindControl("lblNomId");

                arr.Add(Convert.ToInt32(txtAccNo.Text));
                arr.Add(i + 1);
                arr.Add(txtNomineName.Text.ToString());

                if (ddlRel.SelectedIndex > 0)
                {
                    arr.Add(Convert.ToInt16(ddlRel.SelectedValue));
                }
                else
                {
                    arr.Add(0);
                }
                arr.Add(Convert.ToInt16(txtNomineAge.Text));
                arr.Add(Convert.ToInt16(txtNomineShare.Text));
                arr.Add(1);
                arr.Add(Convert.ToInt32(lblNomId.Text));
                empDao.saveNomineeDet(arr);
            }
        }
    }
    private void UpdEmpMst()
    {
        emp = new Employee();
        empDao = new EmployeeDAO();

        emp.NumEmpID = Convert.ToInt32(txtAccNoU.Text);
        emp.StrEmpName = txtNameU.Text.ToString();
        emp.IntPFNo = Convert.ToInt32(txtAccNoU.Text);
        emp.IntJoinDist = Convert.ToInt16(ddlDistU.SelectedValue);
        emp.IntCurrLB = Convert.ToInt16(ddlLbU.SelectedValue);
        //String f = txtwefU.Text.ToString();
        //emp.ChvWEFrom = txtwefU.Text.ToString().Remove(0, 3);
        emp.ChvWEFrom = txtwefU.Text.ToString();
        emp.DtmDOJP = txtAdnU.Text.ToString();
        emp.DtmDOJS = txtDesU.Text.ToString();
        empDao.UpdEmployeeExisting(emp);
    }
    private void SaveToEmpMst()
    {
        emp = new Employee();
        empDao = new EmployeeDAO();

        emp.NumEmpID = Convert.ToInt32(txtAccNo.Text);
        emp.StrEmpName = txtName.Text.ToString();
        emp.IntPFNo = Convert.ToInt32(txtAccNo.Text);
        emp.IntJoinDist = Convert.ToInt16(ddlDist.SelectedValue);
        emp.IntCurrLB = Convert.ToInt16(ddlLb.SelectedValue);
        emp.ChvWEFrom = txtwef.Text.ToString();
        emp.DtmDOJP = txtAdn.Text.ToString();
        emp.DtmDOJS = txtDes.Text.ToString();
        empDao.AddEmployeeExisting(emp);
    }
    private Boolean MandatoryField()
    {
        Boolean flgSel = false;
        if ((txtAccNo.Text == null || txtAccNo.Text == "0"))
        {
            flgSel = false;
        }
        else if (ddlDist.SelectedIndex == 0 || ddlDistCurr.SelectedIndex == 0 || ddlLb.SelectedIndex == 0)
        {
            flgSel = false;
        }
        else if (txtName.Text == "" || txtName.Text == null)
        {
            flgSel = false;
        }
        else if (txtDes.Text.ToString() == "" || txtAdn.Text.ToString() == "" || txtwef.Text.ToString() == "")
        {
            flgSel = false;
        }
        else
        {
            flgSel = true;
        }
        return flgSel;
    }
    private Boolean MandatoryFieldU()
    {
        Boolean flgSelU = false;
        if ((txtAccNoU.Text == null || txtAccNoU.Text == "0"))
        {
            flgSelU = false;
        }
        else if (ddlDistU.SelectedIndex == 0 || ddlDistCurrU.SelectedIndex == 0 || ddlLbU.SelectedIndex == 0)
        {
            flgSelU = false;
        }
        else if (txtNameU.Text == "" || txtNameU.Text == null)
        {
            flgSelU = false;
        }
        else if (txtDesU.Text.ToString() == "" || txtAdnU.Text.ToString() == "" || txtwefU.Text.ToString() == "")
        {
            flgSelU = false;
        }
        else
        {
            flgSelU = true;
        }
        return flgSelU;
    }
    protected void ddlDistCurr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistCurr.SelectedValue) > 0)
        {
            FillInst();
        }
    }
    private void FillInst()
    {
        gblObj = new clsGlobalMethods();
        gen = new GeneralDAO();
        DataSet dslb = new DataSet();
        ArrayList arrlb = new ArrayList();

        if (Convert.ToInt16(Session["intTrnType"]) == 34)
        {
            arrlb.Add(Convert.ToInt16(ddlDistCurr.SelectedValue));
            //arrlb.Add(5);
            dslb = gen.GetLBDistwise(arrlb);
            gblObj.FillCombo(ddlLb, dslb, 1);
        }
        else
        {
            arrlb.Add(Convert.ToInt16(ddlDistCurrU.SelectedValue));
            //arrlb.Add(5);
            dslb = gen.GetLBDistwise(arrlb);
            gblObj.FillCombo(ddlLbU, dslb, 1);
        }
    }
    protected void txtAccNo_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccNo.Text) > 0)
        {
            FillNameAccNo(txtAccNo);
        }

    }
    private void FillNameAccNo(TextBox txt)
    {
        gblObj = new clsGlobalMethods();
        emp = new Employee();
        empDao = new EmployeeDAO();

        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(txt.Text);
        Session["NumEmpIdAddNew"] = emp.NumEmpID;
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 34)
            {
                gblObj.MsgBoxOk("Employee already exists", this);
                btnSave.Enabled = false;
            }
            else
            {
                txtName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
                ddlDistU.SelectedValue = dsN.Tables[0].Rows[0].ItemArray[4].ToString();
                Session["IntDistEmpOrgU"] = Convert.ToInt16(ddlDistU.SelectedValue);

                ddlDistCurrU.SelectedValue = dsN.Tables[0].Rows[0].ItemArray[6].ToString();
                Session["IntDistEmpU"] = Convert.ToInt16(ddlDistCurrU.SelectedValue);
                if (Convert.ToInt32(Session["IntDistEmpU"]) > 0)
                {
                    FillInst();
                    ddlLbU.SelectedValue = dsN.Tables[0].Rows[0].ItemArray[5].ToString();
                }

                LblPrU.Text = dsN.Tables[0].Rows[0].ItemArray[7].ToString();
                txtNameU.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
                txtAdnU.Text = dsN.Tables[0].Rows[0].ItemArray[13].ToString();
                txtwefU.Text = dsN.Tables[0].Rows[0].ItemArray[14].ToString();
                //txtwefU.Text = "01/"+ dsN.Tables[0].Rows[0].ItemArray[14].ToString();
                txtDesU.Text = dsN.Tables[0].Rows[0].ItemArray[16].ToString();
                btnSave.Enabled = true;
            }
        }
        else
        {
            gblObj.MsgBoxOk("Not added!!!", this);

        }
    }
    protected void ddlDistU_SelectedIndexChanged(object sender, EventArgs e)
    {
        gen = new GeneralDAO();
        btnSaveU.Enabled = true;
        ArrayList ar = new ArrayList();
        if (Convert.ToInt16(ddlDistU.SelectedValue) > 0)
        {
            Session["IntDistEmpOrgU"] = Convert.ToInt32(ddlDistU.SelectedValue);
        }
        else
        {
            Session["IntDistEmpOrgU"] = 0;
        }
        ar.Add(Convert.ToInt16(Session["IntDistEmpOrgU"]));
        LblPrU.Text = gen.GetDistrictPrfxFromId(ar);

    }
    protected void txtAccNoU_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccNoU.Text) > 0)
        {
            FillNameAccNo(txtAccNoU);
            fillNomDet();
        }
        //ClrCtrls();
    }
    private void fillNomDet()
    {
        DataSet dsNom = new DataSet();
        ArrayList arrNom = new ArrayList();
        arrNom.Add(Convert.ToInt32(txtAccNoU.Text));
        dsNom = empDao.getNomDet(arrNom);
        if (dsNom.Tables[0].Rows.Count > 0)
        {
            gvNomineeU.DataSource = dsNom;
            gvNomineeU.DataBind();
            fillGridCmbsAdd(gvNomineeU);
            for (int i = 0; i < dsNom.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdvrow = gvNomineeU.Rows[i];
                TextBox txtname = (TextBox)gdvrow.FindControl("txtNomineName");
                txtname.Text = dsNom.Tables[0].Rows[i].ItemArray[3].ToString();

                DropDownList ddlRelU = (DropDownList)gdvrow.FindControl("ddlRel");
                ddlRelU.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtNomineAgeU = (TextBox)gdvrow.FindControl("txtNomineAge");
                txtNomineAgeU.Text = dsNom.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtNomineShareU = (TextBox)gdvrow.FindControl("txtNomineShare");
                txtNomineShareU.Text = dsNom.Tables[0].Rows[i].ItemArray[6].ToString();

                Label lblNomId = (Label)gdvrow.FindControl("lblNomId");
                lblNomId.Text = dsNom.Tables[0].Rows[i].ItemArray[0].ToString();
            }
        }
        else
        {
            SetGridDefault(2);
            fillGridCmbsAdd(gvNomineeU);
            //ClrCtrls();
        }
    }
    protected void ddlDistCurrU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlDistCurrU.SelectedValue) > 0)
        {
            Session["IntDistEmpU"] = Convert.ToInt32(ddlDistCurrU.SelectedValue);
        }
        else
        {
            Session["IntDistEmpU"] = 0;
        }
        FillInst();
    }
    protected void ddlLbU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlLbU.SelectedValue) > 0)
        {
            Session["IntLbEmpU"] = Convert.ToInt32(ddlLbU.SelectedValue);
        }
        else
        {
            Session["IntLbEmpU"] = 0;
        }
    }
    protected void btnSaveU_Click(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (MandatoryFieldU() == true)
        {
            UpdEmpMst();
            //saveNomU();
            saveNominee(gvNomineeU, 2);
            gblObj.MsgBoxOk("Updated", this);
            FillNameAccNo(txtAccNoU);
            fillNomDet();
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details!", this);
        }
    }
    protected void txtAdn_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtAdn, this) == true)
        {
            if (txtDes.Text.ToString() != "" && txtAdn.Text.ToString() != "" && txtwef.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDes.Text.ToString(), txtAdn.Text.ToString(), txtwef.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtAdn.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtAdn.Text = "";
        }
    }
    protected void txtAdnU_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtAdnU, this) == true)
        {
            if (txtDesU.Text.ToString() != "" && txtAdnU.Text.ToString() != "" && txtwefU.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDesU.Text.ToString(), txtAdnU.Text.ToString(), txtwefU.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtAdnU.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtAdnU.Text = "";
        }
    }
    private void SetGridDefault(int flgtp)
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvNomineeName");
        ar.Add("intAge");
        ar.Add("fltShare");
        ar.Add("numNomineeID");
        if (flgtp == 1)
        {
            gblObj.SetGridDefault(gvNominee, ar);
        }
        else
        {
            gblObj.SetGridDefault(gvNomineeU, ar);
        }
    }
    protected void txtDesU_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtDesU, this) == true)
        {
            if (txtDesU.Text.ToString() != "" && txtAdnU.Text.ToString() != "" && txtwefU.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDesU.Text.ToString(), txtAdnU.Text.ToString(), txtwefU.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtDesU.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtDesU.Text = "";
        }
    }
    private List<Control> creategdFloorControl()
    {
        List<Control> myControls = new List<Control>();
        myControls.Add(new TextBox());
        myControls.Add(new DropDownList());
        myControls.Add(new TextBox());
        myControls.Add(new TextBox());
        myControls.Add(new Label());
        return myControls;
    }

    private ArrayList creategdFloorControlId()
    {
        ArrayList arrControlid = new ArrayList();
        arrControlid.Add("txtNomineName");
        arrControlid.Add("ddlRel");
        arrControlid.Add("txtNomineAge");
        arrControlid.Add("txtNomineShare");
        arrControlid.Add("lblNomId");
        return arrControlid;
    }
    private ArrayList getDataTablegdFloor()
    {
        ArrayList arrControlid = new ArrayList();
        arrControlid.Add("chvNomineeName");
        arrControlid.Add("intRelation");
        arrControlid.Add("intAge");
        arrControlid.Add("fltShare");
        arrControlid.Add("numNomineeID");
        return arrControlid;
    }
    //private void fillGridCmbsU()
    //{
    //    gen = new GeneralDAO();
    //    DataSet dsRelation = new DataSet();
    //    ArrayList ArrIn = new ArrayList();
    //    ArrIn.Add(3);
    //    dsRelation = gen.GetRelationship(ArrIn);
    //    for (int i = 0; i < gvNominee.Rows.Count; i++)
    //    {
    //        GridViewRow grdVwRow = gvNominee.Rows[i];
    //        DropDownList ddlRel = (DropDownList)grdVwRow.FindControl("ddlRel");
    //        gblObj.FillCombo(ddlRel, dsRelation, 1);
    //    }
    //}
    private void fillDropDownGridExistsFloor(GridView gdv, DataSet ds)
    {

        gen = new GeneralDAO();
        DataSet dsRelation = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(3);
        dsRelation = gen.GetRelationship(ArrIn);
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gdv.Rows[i];
            DropDownList ddlRel = (DropDownList)grdVwRow.FindControl("ddlRel");
            gblObj.FillCombo(ddlRel, dsRelation, 1);
        }
        foreach (GridViewRow gdRow in gdv.Rows)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropDownList ddlRel = (DropDownList)gdRow.FindControl("ddlRel");
                    ddlRel.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][1].ToString();
                }
            }
        }
    }
    //private void fillDropDownGridExistsFloorU(GridView gdView, DataSet ds)
    //{
    //    fillGridCmbsU();
    //    foreach (GridViewRow gdRow in gdView.Rows)
    //    {
    //        if (ds.Tables.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                DropDownList ddlRel = (DropDownList)gdRow.FindControl("ddlRelU");
    //                ddlRel.SelectedValue = ds.Tables[0].Rows[gdRow.RowIndex][1].ToString();
    //            }
    //        }
    //    }
    //}
    protected void btnAddRow_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gvNominee);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gvNominee);
            DataSet ds = new DataSet();
            gvNominee.DataSource = dtgdRow;
            gvNominee.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gvNominee, ds);
        }



        //gblObj = new clsGlobalMethods();
        //gen = new GeneralDAO();
        //empDao = new EmployeeDAO();

        //saveNom();
        ////Store Ddls in an array//////////
        //ArrayList arDdlwtht = new ArrayList();
        //arDdlwtht.Add("ddlRel");
        ////Store Ddls in an array//////////

        ////Store Ds to fill Ddls in an array//////////
        //ArrayList arDdlDswt = new ArrayList();
        //DataSet dsRelation = new DataSet();
        //ArrayList ArrIn = new ArrayList();
        //ArrIn.Add(3);
        //dsRelation = gen.GetRelationship(ArrIn);
        //arDdlDswt.Add(dsRelation);
        ////Store Ds to fill Ddls in an array//////////

        ////Store Cols in an array//////////
        //ArrayList arColswt = new ArrayList();
        //SetArrColsWt(arColswt);
        ////Store Cols in an array//////////

        ////Ds to fill Grid//////////
        //DataSet dsNom = new DataSet();
        //ArrayList arrNom = new ArrayList();
        //arrNom.Add(Convert.ToInt32(txtAccNo.Text));
        //dsNom = empDao.getNomDet(arrNom);
        ////Ds to fill Grid//////////

        ////Arr to store Boubd field and Hyperlinks navigation fields//////////
        //ArrayList arHpwt = new ArrayList();
        //arHpwt.Add("SlNo");
        ////Arr to store Boubd field and Hyperlinks navigation fields//////////

        //gblObj.SetGridRowsWithDataNew(dsNom, 1, gvNominee, arDdlwtht, arColswt, arDdlDswt, arHpwt);

    }
    protected void btnAddRowU_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        List<Control> myControls = creategdFloorControl();
        ArrayList arrControlid = creategdFloorControlId();
        ArrayList arrDT = getDataTablegdFloor();
        bool chkLastRow = gblObj.checkLastRowStatus(myControls, arrControlid, gvNomineeU);
        if (chkLastRow)
        {
            DataTable dtgdRow = gblObj.AddNewRow(myControls, arrControlid, arrDT, gvNomineeU);
            DataSet ds = new DataSet();
            gvNomineeU.DataSource = dtgdRow;
            gvNomineeU.DataBind();
            ds.Tables.Add(dtgdRow);
            fillDropDownGridExistsFloor(gvNomineeU, ds);
        }
    }
    protected void btnDeleteU_Click(object sender, ImageClickEventArgs e)
    {
        gblObj = new clsGlobalMethods();
        empDao = new EmployeeDAO();
        int rowIndex = ((sender as ImageButton).Parent.Parent as GridViewRow).RowIndex;
        Label lblNomId = (Label)gvNomineeU.Rows[rowIndex].FindControl("lblNomId");

        if (txtAccNoU.Text != "")
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt64(lblNomId.Text));
            empDao.delNomDet(arrin);
            fillNomDet();
        }
        gblObj.MsgBoxOk("Row Deleted   !", this);
    }

    protected void txtwefU_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtwefU, this) == true)
        {
            if (txtDesU.Text.ToString() != "" && txtAdnU.Text.ToString() != "" && txtwefU.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDesU.Text.ToString(), txtAdnU.Text.ToString(), txtwefU.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtwefU.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtwefU.Text = "";
        }
    }
    protected void txtwef_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtwef, this) == true)
        {
            if (txtDes.Text.ToString() != "" && txtAdn.Text.ToString() != "" && txtwef.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDes.Text.ToString(), txtAdn.Text.ToString(), txtwef.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtwef.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtwef.Text = "";
        }
    }
    protected void txtDes_TextChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (gblObj.isValidDate(txtDes, this) == true)
        {
            if (txtDes.Text.ToString() != "" && txtAdn.Text.ToString() != "" && txtwef.Text.ToString() != "")
            {
                if (gblObj.CheckDate3(txtDes.Text.ToString(), txtAdn.Text.ToString(), txtwef.Text.ToString()) == false)
                {
                    gblObj.MsgBoxOk("Invalid Date", this);
                    txtDes.Text = "";

                }
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid Date", this);
            txtDes.Text = "";
        }
    }
}
