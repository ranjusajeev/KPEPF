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

public partial class Contents_Membership : System.Web.UI.Page
{
    clsGlobalMethods gblObj;
    KPEPFGeneralDAO GenDAOObj;
    KPEPFClassLibrary.Membership Mem;
    //Employee emp;
    //EmployeeDAO empDao;
    MembershipDAO MemDAO;
    Approval approvalObj;
    ApprovalDAO approvalDAOObj;
    NomineePDEDao nomDao;

    static DataSet dsRel;
    static ArrayList arAddress = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        if (!IsPostBack)
        {
            InitialSettings();
            FillGridCombos();
            gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["MemReqID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    Session["intTrnType"] = 5;
                    btnSec.PostBackUrl = "~/Contents/InboxMembership.aspx";
                    FillMemDetails(3);
                    FillNomineeDet();
                    FillWitnessDet();
                    SetControls();
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through view
            {
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    btnSec.Visible = true;
                    btnSec.Text = "Back to View";
                    Session["intTrnType"] = 5;
                    btnSec.PostBackUrl = "~/Contents/View.aspx";
                    FillMemDetails(3);
                    FillNomineeDet();
                    FillWitnessDet();
                    SetControls();
                }
            }
            //else
            //{
            //    Session["IntAppFlgInboxMem"] = 0;
            //    if (Convert.ToInt64(Request.QueryString["numMembershipReqID"]) > 0)
            //    {
            //        Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numMembershipReqID"]);    //Has no acc no at the time of membership........
            //        FillMemDetails(3);
            //        FillNomineeDet();
            //        FillWitnessDet();
            //        SetControls();
            //    }
            //    else if (Convert.ToInt64(Request.QueryString["intPF_No"]) > 0)
            //    {
            //        Session["NumServiceTrnID"] = 0;
            //        intaccno = Convert.ToInt32(Request.QueryString["intPF_No"]);
            //        FillMemDetails(2);

            //        SetGridsBlankRws();
            //    }
            //    else
            //    {
            //        Session["NumServiceTrnID"] = 0;
            //        SetGridsBlankRws();
            //    }
            //}
            //SetSubDateTxt();
        }
    }
    private void FillAddressCmbs()
    {
        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistNom, ds, 1);
    }
    private double RequestLBId()
    {
        approvalDAOObj = new ApprovalDAO();

        double lb = 0;
        DataSet dsLB = new DataSet();
        ArrayList arrLB = new ArrayList();
        arrLB.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        dsLB = approvalDAOObj.GetTrnLBType(arrLB);
        if (dsLB.Tables[0].Rows.Count > 0)
        {
            lb = Convert.ToDouble(dsLB.Tables[0].Rows[0].ItemArray[2]);
        }
        return lb;
    }
    private void SetControls()
    {
        GenDAOObj = new KPEPFGeneralDAO();

        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();

        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //arr.Add(Convert.ToInt16(Session["intTrnType"]));
        arr.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        arr.Add(Convert.ToInt16(Session["IntFlgOrg"]));
        arr.Add(Convert.ToInt16(Session["intTrnType"]));
        dsE = GenDAOObj.GetEnableStatusMembership(arr);
        if (dsE.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsE.Tables[0].Rows[0].ItemArray[0]) == true)
            {
                if (Convert.ToInt16(Session["intLBID"]) == RequestLBId())
                {
                    EnbleControls();
                }
                else
                {
                    DisableControls();
                }
            }
            else
            {
                DisableControls();
            }
        }

    }
    //private void SetControls()
    //{
    //    GenDAOObj = new KPEPFGeneralDAO();
        
    //    DataSet dsE = new DataSet();
    //    ArrayList arr = new ArrayList();
    //    if (Convert.ToInt16(Session["IntAppFlgInboxMem"]) == 1)
    //    {
    //        Session["intFlgOrg"] = Convert.ToInt16(Session["intFlgAppInbx"]);
    //    }
    //    else if (Convert.ToInt16(Session["IntAppFlgInboxMem"]) == 2)
    //    {
    //        Session["intFlgOrg"] = Convert.ToInt16(Session["intFlgRejInbx"]);
    //    }
    //    else
    //    {
    //        //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
    //    }
    //    arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
    //    arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
    //    //arr.Add(Convert.ToInt16(Session["intTrnType"]));
    //    arr.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
    //    arr.Add(Convert.ToInt16(Session["intFlgOrg"]));
    //    dsE = GenDAOObj.GetEnableStatus(arr);
    //    if (dsE.Tables[0].Rows.Count > 0)
    //    {
    //        if (Convert.ToBoolean(dsE.Tables[0].Rows[0].ItemArray[0]) == true)
    //        {
    //            EnbleControls();
    //            //flgEnable = 0;
    //        }
    //        else
    //        {
    //            DisableControls();
    //            //flgEnable = 1;
    //        }
    //    }
    //}
    public void DisableControls()
    {
        SetAddCtrlsDisable();
        btnSaveNominee.Enabled = false;
        ddlDesig.Enabled = false;
        rdGender.Enabled = false;
        txtDOB.ReadOnly = true;
        txtDOB.Enabled = false;
        txtBP.ReadOnly = true;
        txtSub.ReadOnly = true;
        //ddlFund.Enabled = false;
        chkMarried.Enabled = false;
        //rdPension.Enabled = false;
        txtSubDate.Enabled = false;
        txtCnt.ReadOnly = true;
        SetNomGridDisable();
        //SetReplcrGridDisable();       Add along with Code 4 filling data...... as it s nt filled by dis time.....
        SetWitnessGridDisable();
        SetAddressCtrlsDisble();

        txtEmpName.ReadOnly = true;
        txtAppDate.ReadOnly = true;
        txtAppDate.Enabled = false;
        txtDOJ.ReadOnly = true;
        txtDOJ.Enabled = false;
        btnFinal.Enabled = false;

        txtAadhar.ReadOnly = true;
        txtPhone.ReadOnly = true;
        ddlBank.Enabled = false;
        ddlDistBank.Enabled = false;
        ddlBranch.Enabled = false;
        txtBankAccNo.ReadOnly = true;
    }
    private void SetNomGridDisable()
    {
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gdvrow = gvNominee.Rows[i];
            TextBox txtNomineNameAss = (TextBox)gdvrow.FindControl("txtNomineName");
            txtNomineNameAss.ReadOnly = true;
            DropDownList ddNomineRelationshipAss = (DropDownList)gdvrow.FindControl("ddNomineRelationship");
            ddNomineRelationshipAss.Enabled = false;
            TextBox txtNomineAgeAss = (TextBox)gdvrow.FindControl("txtNomineAge");
            txtNomineAgeAss.ReadOnly = true;
            TextBox txtNomineShareAss = (TextBox)gdvrow.FindControl("txtNomineShare");
            txtNomineShareAss.ReadOnly = true;
            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = false;

            TextBox txtNameRepAss = (TextBox)gdvrow.FindControl("txtNameRep");
            txtNameRepAss.ReadOnly = true;
            DropDownList ddlRelRepAss = (DropDownList)gdvrow.FindControl("ddlRelRep");
            ddlRelRepAss.Enabled = false;
            TextBox txtAgeRepAss = (TextBox)gdvrow.FindControl("txtAgeRep");
            txtAgeRepAss.ReadOnly = true;
        }
    }
    private void SetNomGridEnable()
    {
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gdvrow = gvNominee.Rows[i];
            TextBox txtNomineNameAss = (TextBox)gdvrow.FindControl("txtNomineName");
            txtNomineNameAss.ReadOnly = false;
            DropDownList ddNomineRelationshipAss = (DropDownList)gdvrow.FindControl("ddNomineRelationship");
            ddNomineRelationshipAss.Enabled = true;
            TextBox txtNomineAgeAss = (TextBox)gdvrow.FindControl("txtNomineAge");
            txtNomineAgeAss.ReadOnly = false;
            TextBox txtNomineShareAss = (TextBox)gdvrow.FindControl("txtNomineShare");
            txtNomineShareAss.ReadOnly = false;
            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = true;

            TextBox txtNameRepAss = (TextBox)gdvrow.FindControl("txtNameRep");
            txtNameRepAss.ReadOnly = false;
            DropDownList ddlRelRepAss = (DropDownList)gdvrow.FindControl("ddlRelRep");
            ddlRelRepAss.Enabled = true;
            TextBox txtAgeRepAss = (TextBox)gdvrow.FindControl("txtAgeRep");
            txtAgeRepAss.ReadOnly = false;
        }
    }
    private void SetWitnessGridEnable()
    {
        for (int i = 0; i < gvWitness.Rows.Count; i++)
        {
            GridViewRow gdvrow = gvWitness.Rows[i];
            TextBox txtWitnessNameAss = (TextBox)gdvrow.FindControl("txtWitnessName");
            txtWitnessNameAss.ReadOnly = false;
        }
    }
    private void SetWitnessGridDisable()
    {
        for (int i = 0; i < gvWitness.Rows.Count; i++)
        {
            GridViewRow gdvrow = gvWitness.Rows[i];
            TextBox txtWitnessNameAss = (TextBox)gdvrow.FindControl("txtWitnessName");
            txtWitnessNameAss.ReadOnly = true;
        }
    }
    private void FillRelation()
    {
        gblObj = new clsGlobalMethods();
        
        ArrayList ArrIn = new ArrayList();
        if (chkMarried.Checked == false)
        {
            ArrIn.Add(0);
        }
        else
        {
            if (rdGender.SelectedValue == "1")
            {
                ArrIn.Add(1);
            }
            else
            {
                ArrIn.Add(2);
            }
        }
        dsRel = GetRelation(ArrIn);
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gvnomi = gvNominee.Rows[i];
            DropDownList ddNomineRelationship = (DropDownList)(gvnomi.FindControl("ddNomineRelationship"));
            gblObj.FillCombo(ddNomineRelationship, dsRel, 1);
        }
    }
    private bool CheckAge()
    {
        gblObj = new clsGlobalMethods();
        
        DateTime Dob = new DateTime();
        DateTime TDay = new DateTime();
        int Yr;
        TDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        Dob = Convert.ToDateTime(txtDOB.Text);
        Yr = TDay.Year - Dob.Year;
        if (Yr < 18 || Yr > 56)
        {
            gblObj.MsgBoxOk("Age of employee should be with in 18 and 56", this);
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckDoj()
    {
        gblObj = new clsGlobalMethods();
        
        DateTime Doj = new DateTime();
        DateTime Dob = new DateTime();
        int Yr;
        Dob = Convert.ToDateTime(txtDOB.Text);
        Doj = Convert.ToDateTime(txtDOJ.Text);
        Yr = Doj.Year - Dob.Year;
        if (Yr < 18 || Yr > 37)
        {
            gblObj.MsgBoxOk("Invaid date!", this);
            return false;
        }
        else
        {
            return true;
        }
    }
    //public long SaveNomineeDetails(int i)
    //{
    //    Mem = new KPEPFClassLibrary.Membership();
    //    MemDAO = new MembershipDAO();
    //    DataSet ds = new DataSet();
    //    ArrayList ArrIn = new ArrayList();
    //    GridViewRow gvrownominee = gvNominee.Rows[i - 1];

    //    TextBox txtNomineeName = (TextBox)(gvrownominee.FindControl("txtNomineName"));
    //    DropDownList ddlRelation = (DropDownList)(gvrownominee.FindControl("ddNomineRelationship"));
    //    TextBox txtAge = (TextBox)(gvrownominee.FindControl("txtNomineAge"));
    //    TextBox txtShare = (TextBox)(gvrownominee.FindControl("txtNomineShare"));

    //    DropDownList ddlRelRepAss = (DropDownList)(gvrownominee.FindControl("ddlRelRep"));
    //    TextBox txtAgeRepAss = (TextBox)(gvrownominee.FindControl("txtAgeRep"));
    //    TextBox txtRepNameAss = (TextBox)(gvrownominee.FindControl("txtNameRep"));

    //    DropDownList ddlStatusAss = (DropDownList)(gvrownominee.FindControl("ddlStatus"));

    //    //if(txtAge.Text.ToString() != "" && txtShare.Text.ToString() != "")
    //    //{
    //    Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);

    //    Mem.IntNomineeSlNo = i; //+ 1;
    //    if (txtNomineeName.Text == "")
    //    {
    //        Mem.ChvNomineeName = "";
    //    }
    //    else
    //    {
    //        Mem.ChvNomineeName = txtNomineeName.Text;
    //    }
    //    if (ddlRelation.SelectedIndex > 0)
    //    {
    //        Mem.IntRelation = Convert.ToInt16(ddlRelation.SelectedValue);
    //    }
    //    else
    //    {
    //        Mem.IntRelation = 0;
    //    }
    //    if (txtAge.Text == "")
    //    {
    //        Mem.IntAge = 0;
    //    }
    //    else
    //    {
    //        Mem.IntAge = Convert.ToInt16(txtAge.Text);
    //    }
    //    if (txtShare.Text == "")
    //    {
    //        Mem.FltShare = 0;
    //    }
    //    else
    //    {
    //        Mem.FltShare = Convert.ToDouble(txtShare.Text);
    //    }
    //    if (ddlStatusAss.SelectedIndex > 0)
    //    {
    //        Mem.IntStatus = Convert.ToInt16(ddlStatusAss.SelectedValue);
    //    }
    //    else
    //    {
    //        Mem.IntStatus = 0;
    //    }

    //    if (ddlRelRepAss.SelectedIndex > 0)
    //    {
    //        Mem.IntReplacerRelation = Convert.ToInt16(ddlRelRepAss.SelectedValue);
    //    }
    //    else
    //    {
    //        Mem.IntReplacerRelation = 0;
    //    }
    //    if (txtAgeRepAss.Text == "")
    //    {
    //        Mem.IntReplacerAge = 0;
    //    }
    //    else
    //    {
    //        Mem.IntReplacerAge = Convert.ToInt16(txtAgeRepAss.Text);
    //    }

    //    if (txtRepNameAss.Text == "")
    //    {
    //        Mem.ChvRepName = "";
    //    }
    //    else
    //    {
    //        Mem.ChvRepName = txtRepNameAss.Text;
    //    }
    //    //Mem.NumEmpId = intaccno;

    //    //lngNomId = MemDAO.CreateNomineeDetails(Mem);


    //    //return lngNomId;
    //    return 215;
    //}
    public void SaveMembershipAddress(int tpAdd, int IntSlNo, int IntSlNoRep)
    {
        Mem = new KPEPFClassLibrary.Membership();
        MemDAO = new MembershipDAO();
        if (Convert.ToInt64(Session["NumServiceTrnID"]) != 0)
        {

            Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
            Mem.IntAddressTypeID = tpAdd;
            Mem.IntSlNo = IntSlNo;
            Mem.IntSlNoRep = IntSlNoRep;

            ////// Name ///////////////////
            if (tpAdd == 1)
            {
                if (txtEmpName.Text == "")
                {
                    Mem.ChvName = "";
                }
                else
                {
                    Mem.ChvName = txtEmpName.Text;
                }
            }
            //else if (tpAdd == 5)
            //{
            //    if (gvWitness.Rows[0].Controls[1].ToString() == "")
            //    {
            //        Mem.ChvName = "";
            //    }
            //    else
            //    {
            //        Mem.ChvName = gvWitness.Rows[0].Controls[1].ToString();
            //    }
            //}
            else
            {
                Mem.ChvName = "";
            }
            ////// Name ///////////////////


            if (txtWardNoNom.Text == "")
            {
                Mem.IntWardNo = 0;
            }
            else
            {
                Mem.IntWardNo = Convert.ToInt32(txtWardNoNom.Text.ToString());
            }

            if (txtDoorNo1Nom.Text == "")
            {
                Mem.IntDoorNo = "0";
            }
            else
            {
                Mem.IntDoorNo = txtDoorNo1Nom.Text.ToString();
            }

            if (txtRANoNom.Text == "")
            {
                Mem.rANo = "";
            }
            else
            {
                Mem.rANo = txtRANoNom.Text;
            }
            if (txtBldgNmNom.Text == "")
            {
                Mem.ChvBldgName = "";
            }
            else
            {
                Mem.ChvBldgName = txtBldgNmNom.Text;
            }
            if (txtLocalPlaceNom.Text == "")
            {
                Mem.ChvLocalPlace = "";
            }
            else
            {
                Mem.ChvLocalPlace = txtLocalPlaceNom.Text;
            }
            if (txtMainPlaceNom.Text == "")
            {
                Mem.ChvMainPlace = "";
            }
            else
            {
                Mem.ChvMainPlace = txtMainPlaceNom.Text;
            }
            if (txtStreetNom.Text == "")
            {
                Mem.streetName = "";
            }
            else
            {
                Mem.streetName = txtStreetNom.Text;
            }
            if (txtPincodeNom.Text == "")
            {
                Mem.IntPincode = 0;
            }
            else
            {
                Mem.IntPincode = Convert.ToInt32(txtPincodeNom.Text.ToString());
            }
            if (ddlDistNom.SelectedValue != "")
            {
                Mem.IntDistrict = Convert.ToInt32(ddlDistNom.SelectedValue);
            }
            else
            {
                Mem.IntDistrict = 0;
            }
            if (ddlpostNom.SelectedValue != "")
            {
                Mem.IntPO = Convert.ToInt32(ddlpostNom.SelectedValue);
            }
            else
            {
                Mem.IntPO = 0;
            }
            Mem.IntState = 1;
            if (chkDo.Checked == true)
            {
                Mem.IntAddMem = 2;
            }
            else
            {
                Mem.IntAddMem = 1;
            }
            MemDAO.MembershipAddress1(Mem);
        }
        else
        {
            Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
            Mem.IntAddressTypeID = tpAdd;
            Mem.IntSlNo = IntSlNo;
            Mem.IntSlNoRep = IntSlNoRep;
            if (txtEmpName.Text == "")
            {
                Mem.ChvName = "";
            }
            else
            {
                Mem.ChvName = txtEmpName.Text;
            }
            Mem.IntWardNo = Convert.ToInt16(arAddress[0]);
            Mem.IntDoorNo = arAddress[1].ToString();
            Mem.rANo = arAddress[3].ToString();
            Mem.ChvBldgName = arAddress[2].ToString();
            Mem.ChvLocalPlace = arAddress[4].ToString();
            Mem.ChvMainPlace = arAddress[5].ToString();
            Mem.streetName = arAddress[6].ToString();
            Mem.IntPincode = Convert.ToInt32(arAddress[8]);
            Mem.IntDistrict = Convert.ToInt16(arAddress[7]);
            Mem.IntPO = Convert.ToInt32(arAddress[9]);
            Mem.IntState = 1;
            Mem.IntAddMem = 1;
            MemDAO.MembershipAddress1(Mem);
        }

        //arAddress
        //Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
        //if (Mem.NumMembershipReqID != 0)
        //{
        //    Mem.IntAddressTypeID = 1;
        //    Mem.IntSlNo = 1;
        //    Mem.IntSlNoRep = 1;
        //    if (txtEmpName.Text == "")
        //    {
        //        Mem.ChvName = "";
        //    }
        //    else
        //    {
        //        Mem.ChvName = txtEmpName.Text;
        //    }
        //    if (txtWardNoNom.Text == "")
        //    {
        //        Mem.IntWardNo = 0;
        //    }
        //    else
        //    {
        //        Mem.IntWardNo = Convert.ToInt32(txtWardNoNom.Text.ToString());
        //    }

        //    if (txtDoorNo1Nom.Text == "")
        //    {
        //        Mem.IntDoorNo = 0;
        //    }
        //    else
        //    {
        //        Mem.IntDoorNo = Convert.ToInt32(txtDoorNo1Nom.Text.ToString());
        //    }

        //    if (txtRANoNom.Text == "")
        //    {
        //        Mem.rANo = "";
        //    }
        //    else
        //    {
        //        Mem.rANo = txtRANoNom.Text;
        //    }
        //    if (txtBldgNmNom.Text == "")
        //    {
        //        Mem.ChvBldgName = "";
        //    }
        //    else
        //    {
        //        Mem.ChvBldgName = txtBldgNmNom.Text;
        //    }
        //    if (txtLocalPlaceNom.Text == "")
        //    {
        //        Mem.ChvLocalPlace = "";
        //    }
        //    else
        //    {
        //        Mem.ChvLocalPlace = txtLocalPlaceNom.Text;
        //    }
        //    if (txtMainPlaceNom.Text == "")
        //    {
        //        Mem.ChvMainPlace = "";
        //    }
        //    else
        //    {
        //        Mem.ChvMainPlace = txtMainPlaceNom.Text;
        //    }
        //    if (txtStreetNom.Text == "")
        //    {
        //        Mem.streetName = "";
        //    }
        //    else
        //    {
        //        Mem.streetName = txtStreetNom.Text;
        //    }
        //    if (txtPincodeNom.Text == "")
        //    {
        //        Mem.IntPincode = 0;
        //    }
        //    else
        //    {
        //        Mem.IntPincode = Convert.ToInt32(txtPincodeNom.Text.ToString());
        //    }
        //    if (ddlDistNom.SelectedValue != "")
        //    {
        //        Mem.IntDistrict = Convert.ToInt32(ddlDistNom.SelectedValue);
        //    }
        //    else
        //    {
        //        Mem.IntDistrict = 0;
        //    }
        //    if (ddlpostNom.SelectedValue != "")
        //    {
        //        Mem.IntPO = Convert.ToInt32(ddlpostNom.SelectedValue);
        //    }
        //    else
        //    {
        //        Mem.IntPO = 0;
        //    }
        //    Mem.IntState = 1;
        //    MemDAO.MembershipAddress1(Mem);
        //}
        //else
        //{
        //    DataTable dt = new DataTable();
        //    //dt.Columns.AddRange(new DataColumn[11] { new DataColumn("c1"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2") });
        //    dt.Columns.Add(new DataColumn("c1", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c2", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c3", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c4", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c5", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c6", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c7", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c8", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c9", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c10", typeof(string)));
        //    dt.Columns.Add(new DataColumn("c11", typeof(string)));

        //    dt.Rows.Add(txtWardNoNom.Text.ToString(), txtDoorNo1Nom.Text.ToString(), txtBldgNmNom.Text.ToString(), txtRANoNom.Text.ToString(), txtLocalPlaceNom.Text.ToString(), txtMainPlaceNom.Text.ToString(), txtStreetNom.Text.ToString(), ddlDistNom.SelectedValue, txtPincodeNom.Text.ToString(), ddlpostNom.SelectedValue, txtstateNom.Text.ToString());
        //    //ArrayList arAddress = new ArrayList();
        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        arAddress.Add(dt.Rows[0][i]);
        //    }
            
        //}
    }
    public void SaveMembershipRequest()
    {
        Mem = new KPEPFClassLibrary.Membership();
        MemDAO = new MembershipDAO();

        if (Request.QueryString["MEMREqID"] != null)
        {
            Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
        }
        else
        {
            Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
        }
        if (Convert.ToInt32(Session["intLBID"]) != null)
        {
            Mem.IntInstID = Convert.ToInt32(Session["intLBID"]);
        }
        else
        {
            Mem.IntInstID = 0;
        }
        if (txtEmpName.Text == "")
        {
            Mem.ChvEmployeeName = "";
        }
        else
        {
            Mem.ChvEmployeeName = txtEmpName.Text;
        }
        if (ddlDesig.SelectedIndex > 0)
        {
            Mem.IntDesigID = Convert.ToInt32(ddlDesig.SelectedValue);
        }
        else
        {
            Mem.IntDesigID = 0;
        }
        if (rdGender.SelectedValue == "1")
        {
            Mem.IntGender = 1;
        }
        else
        {
            Mem.IntGender = 2;
        }
        if (txtDOB.Text == "")
        {
            Mem.DtmDOB = "";
        }
        else
        {
            Mem.DtmDOB = txtDOB.Text;
        }

        if (txtDOJ.Text == "")
        {
            Mem.DtmDOJ = "";
        }
        else
        {
            Mem.DtmDOJ = txtDOJ.Text;
        }

        if (txtBP.Text == "")
        {
            Mem.FltBasicPay = 0;
        }
        else
        {
            Mem.FltBasicPay = Convert.ToDouble(txtBP.Text);
        }
        if (txtSub.Text == "")
        {
            Mem.FltSubscription = 0;
        }
        else
        {
            Mem.FltSubscription = Convert.ToDouble(txtSub.Text);
        }
        if (txtSubDate.Text == "")
        {
            Mem.DtmSubStartDate = "";
        }
        else
        {
            Mem.DtmSubStartDate = txtSubDate.Text;
        }
        if (ddlFund.SelectedIndex > 0)
        {
            Mem.IntOtherFund = Convert.ToInt16(ddlFund.SelectedValue);
        }
        else
        {
            Mem.IntOtherFund = 0;
        }
        if (chkMarried.Checked == true)
        {
            Mem.FlgMarried = 1;
        }
        else
        {
            Mem.FlgMarried = 0;
        }
        if (rdPension.SelectedValue == "1")
        {
            Mem.FlgPensionable = 1;
        }
        else
        {
            Mem.FlgPensionable = 2;
        }
        if (txtCnt.Text == "")
        {
            Mem.IntNominees = 0;
        }
        else
        {
            Mem.IntNominees = Convert.ToInt16(txtCnt.Text);
        }
        Mem.IntUesrID = Convert.ToInt32(Session["intUserId"]);
        Mem.DtmDateOfRequest = txtAppDate.Text;
        //Mem.ChvFileNo = FileNo.Text.Trim();
        //Mem.NumEmpId = intaccno;

        if (txtAadhar.Text == "")
        {
            Mem.IntAadhaar = 0;
        }
        else
        {
            Mem.IntAadhaar = Convert.ToInt64(txtAadhar.Text);
        }

        if (txtPhone.Text == "")
        {
            Mem.ChvPFNo = "";
        }
        else
        {
            Mem.ChvPFNo = txtPhone.Text.ToString();
        }


        if (ddlBank.SelectedIndex > 0)
        {
            Mem.IntBankType = Convert.ToInt16(ddlBank.SelectedValue);
        }
        else
        {
            Mem.IntBankType = 0;
        }

        if (ddlBranch.SelectedIndex > 0)
        {
            Mem.IntBankBranch = Convert.ToInt16(ddlBranch.SelectedValue);
        }
        else
        {
            Mem.IntBankBranch = 0;
        }
        if (txtBankAccNo.Text == "")
        {
            Mem.ChvBankAccNo = "";
        }
        else
        {
            Mem.ChvBankAccNo = txtBankAccNo.Text.ToString();
        }

        MemDAO.CreateMembership(Mem);
    }
    private bool CheckSubscriptionAmt()
    {
        gblObj = new clsGlobalMethods();
        
        double amt;
        if (txtBP.Text != "" || txtBP.Text != null)
        {
            amt = (Convert.ToDouble(txtBP.Text) * 6 / 100);
            if (Convert.ToDouble(txtSub.Text) < amt || (Convert.ToDouble(txtSub.Text) >= (Convert.ToDouble(txtBP.Text))))
            {
                gblObj.MsgBoxOk("Minimum Subscription amount should be 6% of basic pay and Maximum Subscription amount Basic pay itself", this);
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    public bool ValidateAddress()
    {
        bool Valid;
        Valid = true;
        if (txtWardNoNom.Text.Trim() == "")
        {
            Valid = false;
        }
        else if (txtDoorNo1Nom.Text.Trim() == "")
        {
            Valid = false;
        }
        else if (txtLocalPlaceNom.Text.Trim() == "")
        {
            Valid = false;
        }
        else if (txtMainPlaceNom.Text.Trim() == "")
        {
            Valid = false;
        }
        else if (ddlDistNom.SelectedIndex == 0)
        {
            Valid = false;
        }
        else
        {
            Valid = true;
        }
        return Valid;
    }
    //public bool ValidateAddressNom()
    //{
    //    gblObj = new clsGlobalMethods();
        
    //    bool Valid;
    //    Valid = true;
    //    //if (txtWardNoNom.Text.Trim() == "")
    //    //{
    //    //    gblObj.MsgBoxOk("Enter the ward in the address part of the employee ", this);
    //    //    Valid = false;
    //    //}
    //    //else if (txtDoorNo1Nom.Text.Trim() == "")
    //    //{
    //    //    gblObj.MsgBoxOk("Enter the door no. in the address part of the employee ", this);
    //    //    Valid = false;
    //    //}
    //    //else if (txtLocalPlaceNom.Text.Trim() == "")
    //    //{
    //    //    gblObj.MsgBoxOk("Enter the local place in the address part of the employee ", this);
    //    //    Valid = false;
    //    //}
    //    //else if (txtMainPlaceNom.Text.Trim() == "")
    //    //{
    //    //    gblObj.MsgBoxOk("Enter the main place in the address part of the employee ", this);
    //    //    Valid = false;
    //    //}
    //    //else if (ddlDistNom.SelectedIndex == 0)
    //    //{
    //    //    gblObj.MsgBoxOk("Select the district in the address part of the employee", this);
    //    //    Valid = false;
    //    //}
    //    //else
    //    //{
    //    //    Valid = true;
    //    //}
    //    return Valid;
    //}
    public bool ValidateFields()
    {
        gblObj = new clsGlobalMethods();
        
        bool Valid;
        Valid = true;


        if (txtEmpName.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the name of employee ", this);
            Valid = false;
        }
        else if (ddlDesig.SelectedIndex == 0)
        {
            gblObj.MsgBoxOk("Select the designation of the employee", this);
            Valid = false;
        }
        else if (txtDOB.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the date of birth ", this);
            Valid = false;
        }
        else if (txtDOB.Text.Trim() != "")
        {
            if (gblObj.isValidDate(txtDOB, this) == false)
            {
                Valid = false;
            }
        }


        else if (txtBP.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the basic pay ", this);
            Valid = false;
        }
        else if (txtSub.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter subscription amount", this);
            Valid = false;
        }
        else if (rdGender.SelectedValue == "")
        {
            gblObj.MsgBoxOk("Select the gender ", this);
            Valid = false;
        }
        else if (txtPhone.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter Mobile No. ", this);
            Valid = false;
        }

        return Valid;
    }
    private void CreateServiceTransaction()
    {
        GenDAOObj = new KPEPFGeneralDAO();
        
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        if (Request.QueryString["MEMREqID"] != null)
        {
            ArrIn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        }
        else
        {
            if (Convert.ToInt64(Session["NumServiceTrnID"]) == 0)
            {
                ArrIn.Add(0);
            }
            else
            {
                ArrIn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
            }
        }

        ArrIn.Add("");

        ArrIn.Add(122);
        ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
        ArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        ArrIn.Add(txtAppDate.Text);
        ArrIn.Add(Convert.ToInt64(Session["intUserId"]));
        //if (txtInwNo.Text.ToString() != "")
        //{
        //    ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
        //}
        //else
        //{
        //    ArrIn.Add(0);
        //}
        ds = GenDAOObj.CreateServiceTransaction(ArrIn);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    
    public void Approval(int flgApp)
    {
        approvalObj = new Approval();
        approvalDAOObj = new ApprovalDAO();
        if (Convert.ToInt16(Session["intMenuItem"]) == 3)        //Normal DE
        {
            approvalObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
            approvalObj.NumTrnID = Convert.ToInt64(Session["NumServiceTrnID"]);
            approvalObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
            approvalObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
            approvalObj.ChvRem = "";
            approvalDAOObj.CreateApproval(approvalObj);
        }
    }
    public DataSet GetRelation(ArrayList ArrIn)
    {
        MemDAO = new MembershipDAO();
        
        DataSet ds = new DataSet();
        ds = MemDAO.GetRelationship(ArrIn);
        return ds;
    }
    private void ClearAddress()
    {
        gblObj = new clsGlobalMethods();
        GenDAOObj = new KPEPFGeneralDAO();
        MemDAO = new MembershipDAO();

        txtWardNoNom.Text = "";
        txtDoorNo1Nom.Text = "";
        txtRANoNom.Text = "";
        txtBldgNmNom.Text = "";
        txtLocalPlaceNom.Text = "";
        txtMainPlaceNom.Text = "";
        txtPincodeNom.Text = "";
        txtStreetNom.Text = "";

        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistNom, ds, 1);
        ddlDistNom.SelectedValue = "0";
        txtstateNom.Text = "";

        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(ddlDistNom.SelectedValue));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpostNom, dspost, 1);
        ddlpostNom.SelectedValue = "0";
    }
    private void SetAddressCtrlsDisble()
    {
        //chkDo.Enabled = false;

        //txtWardNoNom.ReadOnly = true;
        //txtDoorNo1Nom.ReadOnly = true;
        //txtRANoNom.ReadOnly = true;
        //txtBldgNmNom.ReadOnly = true;
        //txtLocalPlaceNom.ReadOnly = true;
        //txtMainPlaceNom.ReadOnly = true;
        //txtPincodeNom.ReadOnly = true;
        //txtStreetNom.ReadOnly = true;
        //ddlDistNom.Enabled = false;
        //ddlpostNom.Enabled = false;
        //txtstateNom.ReadOnly = true;
    }
    public void EnbleControls()
    {
        SetAddCtrlsEnable();
        btnSaveNominee.Enabled = true;
        ddlDesig.Enabled = true;
        rdGender.Enabled = true;
        txtDOB.ReadOnly = false;
        txtDOB.Enabled = true;
        txtBP.ReadOnly = false;
        txtSub.ReadOnly = false;

        chkMarried.Enabled = true;

        txtSubDate.Enabled = true;
        txtCnt.ReadOnly = false;
        SetNomGridEnable();
        //SetReplcrGridEnable();        Add along with Code 4 filling data...... as it s nt filled by dis time.....
        SetWitnessGridEnable();
        SetAddressCtrlsEnble();

        txtEmpName.ReadOnly = false;
        txtAppDate.ReadOnly = false;
        txtAppDate.Enabled = true;

        txtDOJ.ReadOnly = false;
        txtDOJ.Enabled = true;
        btnFinal.Enabled = true;

        txtAadhar.ReadOnly = false;
        txtPhone.ReadOnly = false;
        ddlBank.Enabled = true;
        ddlDistBank.Enabled = true;
        ddlBranch.Enabled = true;
        txtBankAccNo.ReadOnly = false;
    }
    private void SetAddressCtrlsEnble()
    {
        //chkDo.Enabled = true;

        //txtWardNoNom.ReadOnly = false;
        //txtDoorNo1Nom.ReadOnly = false;
        //txtRANoNom.ReadOnly = false;
        //txtBldgNmNom.ReadOnly = false;
        //txtLocalPlaceNom.ReadOnly = false;
        //txtMainPlaceNom.ReadOnly = false;
        //txtPincodeNom.ReadOnly = false;
        //txtStreetNom.ReadOnly = false;
        //ddlDistNom.Enabled = true;
        //ddlpostNom.Enabled = true;
        //txtstateNom.ReadOnly = false;
    }
    private void FillWitnessDet()
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();

        DataSet dsW = new DataSet();
        ArrayList arW = new ArrayList();
        //arW.Add(ServiceTrnID);
        arW.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        arW.Add(5);         //AddressTypeToSave
        dsW = MemDAO.DisplayWitness(arW);
        if (dsW.Tables[0].Rows.Count > 0)
        {
            gvWitness.DataSource = dsW;
            gvWitness.DataBind();
            //for (int i = 0; i < dsW.Tables[0].Rows.Count; i++)
            for (int i = 0; i < dsW.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdvrow = gvWitness.Rows[i];
                TextBox txtWitnessNameAss = (TextBox)gdvrow.FindControl("txtWitnessName");
                txtWitnessNameAss.Text = dsW.Tables[0].Rows[i].ItemArray[1].ToString();
            }
        }
        else
        {
            gblObj.SetRowsCnt(gvWitness, 2);
        }
    }
    private void FillDdlNomGrid()
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();

        //Status
        DataSet dsStatus = new DataSet();
        dsStatus = MemDAO.FillNomineeStatus();


        // Relation
        ArrayList ArrIn = new ArrayList();
        if (chkMarried.Checked == false)
        {
            ArrIn.Add(0);
        }
        else
        {
            if (rdGender.SelectedValue == "1")
            {
                ArrIn.Add(1);
            }
            else
            {
                ArrIn.Add(2);
            }
        }
        DataSet dsRelation = new DataSet();
        dsRelation = MemDAO.GetRelationship(ArrIn);

        ArrayList ArrInr = new ArrayList();
        ArrInr.Add(10);
        DataSet dsRelationr = new DataSet();
        dsRelationr = MemDAO.GetRelationship(ArrInr);

        //Fill grid
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gvNominee.Rows[i];
            DropDownList ddlStatusAssgn = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblObj.FillCombo(ddlStatusAssgn, dsStatus, 1);

            DropDownList ddNomineRelationshipAss = (DropDownList)grdVwRow.FindControl("ddNomineRelationship");
            gblObj.FillCombo(ddNomineRelationshipAss, dsRelation, 1);
            DropDownList ddReplacerAss = (DropDownList)grdVwRow.FindControl("ddlRelRep");
            gblObj.FillCombo(ddReplacerAss, dsRelationr, 1);
        }
    }
    private void FillNomineeDet()
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();

        DataSet dsNom = new DataSet();
        ArrayList arNom = new ArrayList();
        arNom.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        dsNom = MemDAO.DisplayNominiDet(arNom);
        if (dsNom.Tables[0].Rows.Count > 0)
        {
            gvNominee.DataSource = dsNom;
            gvNominee.DataBind();
            FillDdlNomGrid();
            for (int i = 0; i < dsNom.Tables[0].Rows.Count; i++)
            {

                GridViewRow gdvrow = gvNominee.Rows[i];
                TextBox txtname = (TextBox)gdvrow.FindControl("txtNomineName");
                txtname.Text = dsNom.Tables[0].Rows[i].ItemArray[1].ToString();

                DropDownList ddlRltn = (DropDownList)gdvrow.FindControl("ddNomineRelationship");
                ddlRltn.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[2].ToString();

                TextBox txtAge = (TextBox)gdvrow.FindControl("txtNomineAge");
                txtAge.Text = dsNom.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtShare = (TextBox)gdvrow.FindControl("txtNomineShare");
                txtShare.Text = dsNom.Tables[0].Rows[i].ItemArray[4].ToString();

                DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
                ddlStatusAss.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[5].ToString();

                Label lblNomIdAss = (Label)gdvrow.FindControl("lblNomId");
                lblNomIdAss.Text = dsNom.Tables[0].Rows[i].ItemArray[6].ToString();

                DropDownList ddlRelRepAss = (DropDownList)gdvrow.FindControl("ddlRelRep");
                ddlRelRepAss.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[8].ToString();

                TextBox txtAgeRepAss = (TextBox)gdvrow.FindControl("txtAgeRep");
                txtAgeRepAss.Text = dsNom.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRepnameAss = (TextBox)gdvrow.FindControl("txtNameRep");
                txtRepnameAss.Text = dsNom.Tables[0].Rows[i].ItemArray[10].ToString();
                //Address


            }
        }
        else
        {
            gblObj.SetRowsCnt(gvNominee, 1);
        }
    }
    private void InitialSettings()
    {
        gblObj = new clsGlobalMethods();
        GenDAOObj = new KPEPFGeneralDAO();
        MemDAO = new MembershipDAO();
        //Set Subn Date//
        if (Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            lblSubdt.Visible = true;
            txtSubDate.Visible = true;
        }
        else
        {
            lblSubdt.Visible = true;
            txtSubDate.Visible = true;
        }
        //Set Subn Date//

        //FillBank//////////////
        DataSet dsDesig = new DataSet();
        dsDesig = MemDAO.GetDesignation();
        gblObj.FillCombo(ddlDesig, dsDesig, 1);

        DataSet ds = new DataSet();
        ds = GenDAOObj.getBank();
        gblObj.FillCombo(ddlBank, ds, 1);

        DataSet dsD = new DataSet();
        dsD = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistBank, dsD, 1);
        //FillBank//////////////

        SetGridDefaultNom();
        SetGridDefaultWit();
        FillAddressCmbs();
    }
    private void SetGridDefaultNom()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefault(gvNominee, ar);
    }
    private void SetGridDefaultWit()
    {
        gblObj = new clsGlobalMethods();
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        gblObj.SetGridDefaultCnt(gvWitness, ar,2);
    }
    public void FillGridCombos()
    {
        gblObj = new clsGlobalMethods();
        GenDAOObj = new KPEPFGeneralDAO();
        MemDAO = new MembershipDAO();

        //DataSet ds = new DataSet();
        //ds = GenDAOObj.GetDistrict();
        //gblObj.FillCombo(ddlDist, ds, 1);
        //gblObj.FillCombo(ddlDistNom, ds, 1);
        ////Districts/////////////

        ////Status nd Relation/////
        //DataSet dsStatus = new DataSet();
        //dsStatus = MemDAO.FillNomineeStatus();

        //ArrayList ArrIn = new ArrayList();
        //if (chkMarried.Checked == false)
        //{
        //    ArrIn.Add(0);
        //}
        //else
        //{
        //    if (rdGender.SelectedValue == "1")
        //    {
        //        ArrIn.Add(1);
        //    }
        //    else
        //    {
        //        ArrIn.Add(2);
        //    }
        //}
        //DataSet dsRelation = new DataSet();
        //dsRelation = MemDAO.GetRelationship(ArrIn);

        //for (int i = 0; i < gvNominee.Rows.Count; i++)
        //{
        //    GridViewRow grdVwRow = gvNominee.Rows[i];
        //    DropDownList ddlStatusAssgn = (DropDownList)grdVwRow.FindControl("ddlStatus");
        //    gblObj.FillCombo(ddlStatusAssgn, dsStatus, 1);

        //    DropDownList ddNomineRelationshipAss = (DropDownList)grdVwRow.FindControl("ddNomineRelationship");
        //    gblObj.FillCombo(ddNomineRelationshipAss, dsRelation, 1);

        //    DropDownList ddNomineRelRepAss = (DropDownList)grdVwRow.FindControl("ddlRelRep");
        //    gblObj.FillCombo(ddNomineRelRepAss, dsRelation, 1);

        //}

        ////Designation/////////////
        //DataSet dsDesig = new DataSet();
        //dsDesig = MemDAO.GetDesignation();
        //gblObj.FillCombo(ddlDesig, dsDesig, 1);
        ////Designation////////////

    }
    private void FillMemDetails(int flgFull)
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();
        nomDao = new NomineePDEDao();

        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        ar.Add(flgFull);
        ds = nomDao.GetMemDetails(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (flgFull == 3)
            {
                //txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                //FileNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                //gblObj.StrFileNo = FileNo.Text.ToString();
                txtAppDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                lblAdd.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString() + ", " + ds.Tables[0].Rows[0].ItemArray[4].ToString() + ", " + ds.Tables[0].Rows[0].ItemArray[5].ToString();
                ddlDesig.SelectedValue = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                rdGender.SelectedValue = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[13]);
                txtDOJ.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[22]);
                txtBP.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[14]);
                txtSub.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[15]);
                FillOtherFunds();
                if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[16].ToString()) > 0)
                {
                    chkFund.Checked = true;
                    ddlFund.SelectedValue = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                }
                else
                {
                    chkFund.Checked = false;
                }
                //txtSubDate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[19]);
                if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[17]) == 1)
                {
                    chkMarried.Checked = true;
                }
                else
                {
                    chkMarried.Checked = false;
                }
                rdPension.SelectedValue = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                txtCnt.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                //intNomOldCnt = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[20].ToString());

                txtAadhar.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();

                ddlBank.SelectedValue = ds.Tables[0].Rows[0].ItemArray[25].ToString();
                //intBankId = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[25].ToString());
                ddlDistBank.SelectedValue = ds.Tables[0].Rows[0].ItemArray[28].ToString();
                FillBranch(Convert.ToInt16(ddlBank.SelectedValue.ToString()), Convert.ToInt16(ddlDistBank.SelectedValue.ToString()));
                ddlBranch.SelectedValue = ds.Tables[0].Rows[0].ItemArray[26].ToString();

                txtBankAccNo.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();

            }
            else
            {
                //txtAcc.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtCnt.Text = "0";
            }
        }
    }
    private void FillBranch(int BankId, int DistId)
    {
        gblObj = new clsGlobalMethods();
        GenDAOObj = new KPEPFGeneralDAO();

        ArrayList ar = new ArrayList();
        ar.Add(BankId);
        ar.Add(DistId);
        DataSet dsB = new DataSet();
        dsB = GenDAOObj.getBankBranch(ar);
        gblObj.FillCombo(ddlBranch, dsB, 1);
    }
    public void FillOtherFunds()
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();

        DataSet ds = new DataSet();
        ds = MemDAO.GetOtherFund();
        gblObj.FillCombo(ddlFund, ds, 1);
    }
    private Boolean ChkShare(int rw)
    {
        Boolean fg = true;
        int shr = 0;
        //for (int i = 0; i < gvNominee.Rows.Count; i++)
        //{
            GridViewRow gvr = gvNominee.Rows[rw];
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
        //}
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
    private bool ChkAllColsInNomGrid()
    {
        Boolean fg = true;
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gvr = gvNominee.Rows[i];
            TextBox txtAge = (TextBox)(gvr.FindControl("txtNomineAge"));
            TextBox txtShare = (TextBox)(gvr.FindControl("txtNomineShare"));
            if (txtAge.Text.ToString() != "")
            {
                if (txtShare.Text.ToString() != "")
                {
                    fg = true;
                }
                else
                {
                    fg = false;
                }
            }
            else
            {
                fg = false;
            }
        }

        return fg;
    }
    private Boolean ChkWitnessAdd()
    {
        Boolean fg = true;
        if (Convert.ToString(txtPincodeNom.Text) == "")
        {
            fg = false;
        }
        else
        {
            fg = true;
            if (gvWitness.Rows.Count == 2)
            {
                fg = true;
            }
            else
            {
                fg = false;
            }
        }
        return fg;
    }
    private void SaveWitnessDet()
    {
        for (int j = 0; j < gvWitness.Rows.Count; j++)
        {
            ArrayList ar = new ArrayList();

            GridViewRow gdvrow = gvWitness.Rows[j];
            TextBox txtWname = (TextBox)gdvrow.FindControl("txtWitnessName");
            //ar.Add(txtWname);
            ar.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
            ar.Add(5);
            ar.Add(j + 1);
            ar.Add(txtWname.Text.ToString());
            MemDAO.UpdAddress(ar);
        }
    }
    protected void btnFinal_Click(object sender, EventArgs e)
    {
        if (ValidateFields() == true)
        {
            if (ChkAllColsInNomGrid() == true)
            {
                if (ChkWitnessAdd() == true)
                {
                    CreateServiceTransaction();
                    Approval(Convert.ToInt16(Session["intFlgApp"]));
                    //SaveMembershipAddress(Convert.ToInt16(Session["intAddTp"]), 1, 1);
                    SaveMembershipRequest();
                    SaveNomineeDetails();
                    SaveWitnessDet();
                    gblObj.MsgBoxOk("Saved successfully!", this);
                }
                else
                {
                    gblObj.MsgBoxOk("Enter 2 Witness!", this);
                }
            }
            else
            {
                gblObj.MsgBoxOk("Enter all details!", this);
            }

        }
    }
    protected void btnAddressOK_Click(object sender, EventArgs e)
    {
        if  (ValidateAddress() == true)
        {
            if (Convert.ToInt16(Session["intAddTp"]) == 1)
            {
                if (Convert.ToInt64(Session["NumServiceTrnID"]) == 0)
                {
                    AssignToArray();
                    mdlConfirm.Show();
                }
                else
                {
                    SaveMembershipAddress(1, 1, 1);
                }
            }
            else
            {
                SaveMembershipAddress(Convert.ToInt16(Session["intAddTp"]), Convert.ToInt16(Session["rowNo"]) + 1, 1);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter all details.", this);
            mdlConfirm.Visible = true;
        }
    }
    private void AssignToArray()
    {
        DataTable dt = new DataTable();
        //dt.Columns.AddRange(new DataColumn[11] { new DataColumn("c1"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2"), new DataColumn("c2") });
        dt.Columns.Add(new DataColumn("c1", typeof(string)));
        dt.Columns.Add(new DataColumn("c2", typeof(string)));
        dt.Columns.Add(new DataColumn("c3", typeof(string)));
        dt.Columns.Add(new DataColumn("c4", typeof(string)));
        dt.Columns.Add(new DataColumn("c5", typeof(string)));
        dt.Columns.Add(new DataColumn("c6", typeof(string)));
        dt.Columns.Add(new DataColumn("c7", typeof(string)));
        dt.Columns.Add(new DataColumn("c8", typeof(string)));
        dt.Columns.Add(new DataColumn("c9", typeof(string)));
        dt.Columns.Add(new DataColumn("c10", typeof(string)));
        dt.Columns.Add(new DataColumn("c11", typeof(string)));

        dt.Rows.Add(txtWardNoNom.Text.ToString(), txtDoorNo1Nom.Text.ToString(), txtBldgNmNom.Text.ToString(), txtRANoNom.Text.ToString(), txtLocalPlaceNom.Text.ToString(), txtMainPlaceNom.Text.ToString(), txtStreetNom.Text.ToString(), ddlDistNom.SelectedValue, txtPincodeNom.Text.ToString(), ddlpostNom.SelectedValue, txtstateNom.Text.ToString());
        //ArrayList arAddress = new ArrayList();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            arAddress.Add(dt.Rows[0][i]);
        }
            
    }
    protected void chkDo_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDo.Checked == true)
        {
            FillSameAddress(1);
            SetAddCtrlsDisable();
        }
        else
        {
            SetAddCtrlsEnable();
        }
        mdlConfirm.Show();
    }
    private void SetAddCtrlsDisable()
    {
        //FillSameAddress(1);
        txtWardNoNom.ReadOnly = true;
        txtDoorNo1Nom.ReadOnly = true;
        txtRANoNom.ReadOnly = true;
        txtBldgNmNom.ReadOnly = true;
        txtLocalPlaceNom.ReadOnly = true;
        txtMainPlaceNom.ReadOnly = true;
        txtPincodeNom.ReadOnly = true;
        txtStreetNom.ReadOnly = true;
        ddlDistNom.Enabled = false;
        ddlpostNom.Enabled = false;
        txtstateNom.ReadOnly = true;
    }
    private void SetAddCtrlsEnable()
    {
        ClearAddress();
        chkDo.Checked = false;
        txtWardNoNom.ReadOnly = false;
        txtDoorNo1Nom.ReadOnly = false;
        txtRANoNom.ReadOnly = false;
        txtBldgNmNom.ReadOnly = false;
        txtLocalPlaceNom.ReadOnly = false;
        txtMainPlaceNom.ReadOnly = false;
        txtPincodeNom.ReadOnly = false;
        txtStreetNom.ReadOnly = false;
        ddlDistNom.Enabled = true;
        ddlpostNom.Enabled = true;
        txtstateNom.ReadOnly = false;
    }
    private void FillSameAddress(int addType)
    {
        MemDAO = new MembershipDAO();
        gblObj = new clsGlobalMethods();
        GenDAOObj = new KPEPFGeneralDAO();

        DataSet dsAdd = new DataSet();
        ArrayList arrAddn = new ArrayList();
        //arrAddn.Add(ServiceTrnID);
        arrAddn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        arrAddn.Add(addType);
        arrAddn.Add(1);
        arrAddn.Add(1);
        dsAdd = MemDAO.GetAddress(arrAddn);

        if (dsAdd.Tables[0].Rows.Count > 0)
        {
            txtWardNoNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[0].ToString();
            txtDoorNo1Nom.Text = dsAdd.Tables[0].Rows[0].ItemArray[1].ToString();
            txtRANoNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[2].ToString();
            txtBldgNmNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[3].ToString();
            txtLocalPlaceNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[4].ToString();
            txtMainPlaceNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[5].ToString();
            txtPincodeNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[7].ToString();
            txtStreetNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[12].ToString();
            //FillDist cmb
            DataSet ds = new DataSet();
            ds = GenDAOObj.GetDistrict();
            gblObj.FillCombo(ddlDistNom, ds, 1);
            ddlDistNom.SelectedValue = dsAdd.Tables[0].Rows[0].ItemArray[9].ToString();

            DataSet dspost = new DataSet();
            ArrayList ArrIn1 = new ArrayList();
            ArrIn1.Add(Convert.ToInt32(dsAdd.Tables[0].Rows[0].ItemArray[9]));

            dspost = MemDAO.GetPostoffice(ArrIn1);
            gblObj.FillCombo(ddlpostNom, dspost, 1);

            ddlpostNom.SelectedValue = dsAdd.Tables[0].Rows[0].ItemArray[6].ToString();
            txtstateNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[11].ToString();

        }
    }
    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        if (CheckAge() == false)
        {
            txtDOB.Text = "";
            //gblObj.MsgBoxOk("Invalid DOB", this);
        }
    }
    protected void txtSub_TextChanged(object sender, EventArgs e)
    {
        if (CheckSubscriptionAmt() == false)
        {
            txtSub.Text = "";
        }
    }
    protected void chkMarried_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void txtAadhar_TextChanged(object sender, EventArgs e)
    {
        if (txtAadhar.Text.Length < 12)
        {
            gblObj.MsgBoxOk("Invalid Aadhaar No.!", this);
            txtAadhar.Text = "";
        }
    }
    protected void txtPhone_TextChanged(object sender, EventArgs e)
    {
        if (txtPhone.Text.Length < 10)
        {
            gblObj.MsgBoxOk("Invalid Phone No.!", this);
            txtPhone.Text = "";
        }
    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenDAOObj = new KPEPFGeneralDAO();
        if (ddlBank.SelectedIndex > 0)
        {
            Session["intBankId"] = Convert.ToInt16(ddlBank.SelectedValue);

            DataSet dsD = new DataSet();
            dsD = GenDAOObj.GetDistrict();
            gblObj.FillCombo(ddlDistBank, dsD, 1);
            ddlBranch.SelectedIndex = -1;
        }
        else
        {
            Session["intBankId"] = 0;
        }
    }
    protected void txtNomineShare_TextChanged(object sender, EventArgs e)
    {
        int rowIndex = ((sender as TextBox).Parent.Parent as GridViewRow).RowIndex;
        GridViewRow gdvr = gvNominee.Rows[rowIndex];
        TextBox txtNomineShare = (TextBox)gdvr.FindControl("txtNomineShare");
        if (ChkShare(rowIndex) == false)
        {
            txtNomineShare.Text = "0";
        }
        //gblObj = new clsGlobalMethods();
        
        //int tShare = 0;
        //for (int i = 0; i < gvNominee.Rows.Count; i++)
        //{
        //    GridViewRow gvRw = gvNominee.Rows[i];
        //    TextBox txtNomineShareAss = (TextBox)(gvRw.FindControl("txtNomineShare"));
        //    if (txtNomineShareAss.Text == "")
        //    {
        //        txtNomineShareAss.Text = "0";
        //    }
        //    tShare = tShare + int.Parse(txtNomineShareAss.Text.ToString());
        //    if (tShare > 100)
        //    {
        //        gblObj.MsgBoxOk("Share is not valid!", this);
        //        txtNomineShareAss.Text = "";
        //    }
        //}
    }
    protected void ddlDistBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intDist = 0;
        if (ddlDistBank.SelectedIndex > 0)
        {
            intDist = Convert.ToInt16(ddlDistBank.SelectedValue);
        }
        else
        {
            intDist = 0;
        }
        if (Convert.ToInt16(Session["intBankId"]) > 0 && intDist > 0)
        {
            FillBranch(Convert.ToInt16(Session["intBankId"]), intDist);
        }

    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        KPEPFClassLibrary.MembershipDAO memD = new KPEPFClassLibrary.MembershipDAO();

        CreateServiceTransaction();
        Approval(Convert.ToInt16(Session["intFlgApp"]));
        SaveMembershipRequest();
        SaveMembershipAddress(1, 1, 1);

        if (txtCnt.Text.Trim() != "")
        {
            ////Store Ddls in an array//////////
            ArrayList arDdl = new ArrayList();
            arDdl.Add("ddNomineRelationship");
            arDdl.Add("ddlStatus");
            arDdl.Add("ddlRelRep");
            ////Store Ddls in an array//////////

            ////Store Ds to fill Ddls in an array//////////
            ArrayList arDdlDs = new ArrayList();

            DataSet dsRelAll = new DataSet();
            dsRelAll = memD.GetRelationshipAll();
            arDdlDs.Add(dsRelAll);

            DataSet dsStat = new DataSet();
            dsStat = memD.FillNomineeStatus();
            arDdlDs.Add(dsStat);

            //DataSet dsRelAll1 = new DataSet();
            //dsRelAll1 = memD.GetRelationshipAll();
            arDdlDs.Add(dsRelAll);
            ////Store Ds to fill Ddls in an array//////////

            ////Store cols in an array//////////
            ArrayList arCols = new ArrayList();
            SetArrCols(arCols);
            ////Store cols in an array//////////

            ////Ds to fill Grid//////////
            DataSet dsNom = new DataSet();
            ArrayList arNom = new ArrayList();
            arNom.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
            dsNom = memD.DisplayNominiDet(arNom);
            ////Ds to fill Grid//////////

            gblObj.SetGridRowsWithData(dsNom, Convert.ToInt16(txtCnt.Text), gvNominee, arDdl, arCols, arDdlDs);
        }
        else
        {
            SetGridDefaultNom();
        }
    }
    private void SetArrCols(ArrayList arCols)
    {
        arCols.Add("txtNomineName");
        arCols.Add("btnNomineAddress");
        arCols.Add("ddNomineRelationship");
        arCols.Add("txtNomineAge");
        arCols.Add("txtNomineShare");
        arCols.Add("ddlStatus");
        arCols.Add("lblNomId");
        arCols.Add("txtNameRep");
        arCols.Add("btnAddRep");
        arCols.Add("ddlRelRep");
        arCols.Add("txtAgeRep");
    }
    protected void btnNomineAddress_Click(object sender, EventArgs e)
    {
        Session["rowNo"]= ((sender as Button).Parent.Parent as GridViewRow).RowIndex;
        Session["intAddTp"] = 2;
        ClearAddress();
        mdlConfirm.Show();
        FillAddressNom(Convert.ToInt16(Session["intAddTp"]), Convert.ToInt16(Session["rowNo"]) + 1);
    }
    private void FillAddressNom(int addType, int slno)
    {
        MemDAO = new MembershipDAO();
        GenDAOObj = new KPEPFGeneralDAO();

        DataSet dsAdd = new DataSet();
        ArrayList arrAddn = new ArrayList();
        arrAddn.Add(Convert.ToInt64(Session["NumServiceTrnID"]));
        arrAddn.Add(addType);
        arrAddn.Add(slno);
        arrAddn.Add(1);
        dsAdd = MemDAO.GetAddress(arrAddn);

        if (dsAdd.Tables[0].Rows.Count > 0)
        {
            txtWardNoNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[0].ToString();
            txtDoorNo1Nom.Text = dsAdd.Tables[0].Rows[0].ItemArray[1].ToString();
            txtRANoNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[2].ToString();
            txtBldgNmNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[3].ToString();
            txtLocalPlaceNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[4].ToString();
            txtMainPlaceNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[5].ToString();
            txtPincodeNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[7].ToString();
            txtStreetNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[12].ToString();
            //FillDist cmb
            DataSet ds = new DataSet();
            ds = GenDAOObj.GetDistrict();
            gblObj.FillCombo(ddlDistNom, ds, 1);
            ddlDistNom.SelectedValue = dsAdd.Tables[0].Rows[0].ItemArray[9].ToString();

            DataSet dspost = new DataSet();
            ArrayList ArrIn1 = new ArrayList();
            ArrIn1.Add(Convert.ToInt32(dsAdd.Tables[0].Rows[0].ItemArray[9]));

            dspost = MemDAO.GetPostoffice(ArrIn1);
            gblObj.FillCombo(ddlpostNom, dspost, 1);

            ddlpostNom.SelectedValue = dsAdd.Tables[0].Rows[0].ItemArray[6].ToString();
            txtstateNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[11].ToString();
            if (Convert.ToInt16(dsAdd.Tables[0].Rows[0].ItemArray[13]) == 2)
            {
                chkDo.Checked = true;
            }
            else
            {
                chkDo.Checked = false;
            }
            if (addType == 1)
            {
                chkDo.Enabled = false;
            }
            else
            {
                chkDo.Enabled = true;
            }
        }
    }
    protected void btnAddRep_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).Parent.Parent as GridViewRow).RowIndex;
        Session["intAddTp"] = 3;
        ClearAddress();
        mdlConfirm.Show();
        FillAddressNom(Convert.ToInt16(Session["intAddTp"]), rowIndex + 1);
    }
    protected void btnWitnessAddress_Click(object sender, EventArgs e)
    {
        Session["rowNo"] = ((sender as Button).Parent.Parent as GridViewRow).RowIndex;
        Session["intAddTp"] = 5;
        ClearAddress();
        mdlConfirm.Show();
        FillAddressNom(Convert.ToInt16(Session["intAddTp"]), Convert.ToInt16(Session["rowNo"]) + 1);
    }
    protected void ddlpostNom_SelectedIndexChanged(object sender, EventArgs e)
    {
        MemDAO = new MembershipDAO();

        //txtPincodeNom
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        if (ddlpostNom.SelectedIndex > 0)
        {
            ar.Add(Convert.ToInt16(ddlpostNom.SelectedValue));
            ds = MemDAO.GetPinCode(ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPincodeNom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txtstateNom.Text = "Kerala";
            }
        }
        mdlConfirm.Show();
    }
    //protected void ddlpost_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    ArrayList ar = new ArrayList();
    //    if (ddlpost.SelectedIndex > 0)
    //    {
    //        ar.Add(Convert.ToInt16(ddlpost.SelectedValue));
    //        ds = MemDAO.GetPinCode(ar);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            txtPincode.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
    //            txtstate.Text = "Kerala";
    //        }
    //    }
    //}
    protected void ddlDistNom_SelectedIndexChanged(object sender, EventArgs e)
    {
        gblObj = new clsGlobalMethods();
        MemDAO = new MembershipDAO();

        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(ddlDistNom.SelectedValue));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpostNom, dspost, 1);
        mdlConfirm.Show();
    }
    //protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet dspost = new DataSet();
    //    ArrayList ArrIn1 = new ArrayList();
    //    ArrIn1.Add(Convert.ToInt32(ddlDist.SelectedValue));

    //    dspost = MemDAO.GetPostoffice(ArrIn1);
    //    gblObj.FillCombo(ddlpost, dspost, 1);


    //}
    public void  SaveNomineeDetails()
    {
        Mem = new KPEPFClassLibrary.Membership();
        MemDAO = new MembershipDAO();
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();


        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gvrownominee = gvNominee.Rows[i];

            TextBox txtNomineeName = (TextBox)(gvrownominee.FindControl("txtNomineName"));
            DropDownList ddlRelation = (DropDownList)(gvrownominee.FindControl("ddNomineRelationship"));
            TextBox txtAge = (TextBox)(gvrownominee.FindControl("txtNomineAge"));
            TextBox txtShare = (TextBox)(gvrownominee.FindControl("txtNomineShare"));

            DropDownList ddlRelRepAss = (DropDownList)(gvrownominee.FindControl("ddlRelRep"));
            TextBox txtAgeRepAss = (TextBox)(gvrownominee.FindControl("txtAgeRep"));
            TextBox txtRepNameAss = (TextBox)(gvrownominee.FindControl("txtNameRep"));

            DropDownList ddlStatusAss = (DropDownList)(gvrownominee.FindControl("ddlStatus"));

            Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);

            Mem.IntNomineeSlNo = i+ 1;
            if (txtNomineeName.Text == "")
            {
                Mem.ChvNomineeName = "";
            }
            else
            {
                Mem.ChvNomineeName = txtNomineeName.Text;
            }
            if (ddlRelation.SelectedIndex > 0)
            {
                Mem.IntRelation = Convert.ToInt16(ddlRelation.SelectedValue);
            }
            else
            {
                Mem.IntRelation = 0;
            }
            if (txtAge.Text == "")
            {
                Mem.IntAge = 0;
            }
            else
            {
                Mem.IntAge = Convert.ToInt16(txtAge.Text);
            }
            if (txtShare.Text == "")
            {
                Mem.FltShare = 0;
            }
            else
            {
                Mem.FltShare = Convert.ToDouble(txtShare.Text);
            }
            if (ddlStatusAss.SelectedIndex > 0)
            {
                Mem.IntStatus = Convert.ToInt16(ddlStatusAss.SelectedValue);
            }
            else
            {
                Mem.IntStatus = 0;
            }

            if (ddlRelRepAss.SelectedIndex > 0)
            {
                Mem.IntReplacerRelation = Convert.ToInt16(ddlRelRepAss.SelectedValue);
            }
            else
            {
                Mem.IntReplacerRelation = 0;
            }
            if (txtAgeRepAss.Text == "")
            {
                Mem.IntReplacerAge = 0;
            }
            else
            {
                Mem.IntReplacerAge = Convert.ToInt16(txtAgeRepAss.Text);
            }

            if (txtRepNameAss.Text == "")
            {
                Mem.ChvRepName = "";
            }
            else
            {
                Mem.ChvRepName = txtRepNameAss.Text;
            }
            MemDAO.CreateNomineeDetails(Mem);
        }
    }
    protected void btnSaveNominee_Click(object sender, EventArgs e)
    {
        SaveNomineeDetails();

        //if (intNomOldCnt <= Convert.ToInt16(txtCnt.Text))
        //{
        //    if (ChkShare() == true)
        //    {
        //        for (int j = 0; j < gvNominee.Rows.Count; j++)
        //        {
        //            intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
        //            lngNomId = SaveNomineeDetails(intSlNo);
        //        }
        //    }
        //}
        //else
        //{
        //    for (int j = 0; j < gvNominee.Rows.Count; j++)
        //    {
        //        intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
        //        lngNomId = SaveNomineeDetails(intSlNo);
        //    }
        //    for (int k = intNomOldCnt; k > Convert.ToInt16(txtCnt.Text); k--)
        //    {
        //        Mem.NumMembershipReqID = Convert.ToInt64(Session["NumServiceTrnID"]);
        //        Mem.IntSlNo = k;
        //        MemDAO.DeleteNominee(Mem);
        //    }
        //}
        //gblObj.MsgBoxOk("Saved", this);
    }
    protected void ddlFund_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtAppDate_TextChanged(object sender, EventArgs e)
    {
        if (gblObj.CheckAppDate(txtAppDate, this) == false)
        {
            gblObj.MsgBoxOk("Invalid Date", this);
        }
    }
    protected void txtDOJ_TextChanged(object sender, EventArgs e)
    {
        if (CheckDoj() == false)
        {
            txtDOJ.Text = "";
            //gblObj.MsgBoxOk("Invalid DOJ", this);
        }
    }
    protected void rdGender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chkFund_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddress_Click(object sender, EventArgs e)
    {
        Session["intAddTp"] = 1;
        mdlConfirm.Show();
        FillAddressNom(1,1);
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        mdlConfirm.Hide();
    }
}