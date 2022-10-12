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

public partial class Contents_NomineePDE : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDAOObj = new KPEPFGeneralDAO();
    KPEPFClassLibrary.Membership Mem = new KPEPFClassLibrary.Membership();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    MembershipDAO MemDAO = new MembershipDAO();
    Approval approvalObj = new Approval();
    ApprovalDAO approvalDAOObj = new ApprovalDAO();
    NomineePDEDao nomDao = new NomineePDEDao();

    static DataSet dsRel;
    static int AddressTypeToSave = 0;
    //static double ServiceTrnID = 0;
    //double ServiceTrnID = 0;
    static int share = 0;
    static int intaccno = 0, intCurRow = 0, intSlNo = 0, intSlNoRep = 0, flgEnable = 0, intNomOldCnt = 0;
    static long lngNomId;
    static int intBankId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //gblObj.SetAppFlagsInSession(ds);
            if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            InitialSettings();
            FillGridCombos();
            GetMembershipReqList();

            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                Session["NumServiceTrnIDNomP"] = Convert.ToInt64(Request.QueryString["MemReqID"]);
                if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) > 0)
                {
                    intaccno = Convert.ToInt32(Request.QueryString["numEmpId"]);
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    Session["intTrnType"] = 13;
                    btnSec.PostBackUrl = "~/Contents/InboxMembership.aspx";
                    FillMemDetails(1);
                    FillNomineeDet();
                    FillWitnessDet();
                    SetControls();

                    gdvMemReqList.Enabled = false;
                }
                else
                {
                    SetReqListDefault();
                }
            }
            else
            {
                Session["IntAppFlgInboxNomP"] = 0;
                if (Convert.ToInt64(Request.QueryString["numMembershipReqID"]) > 0)
                {
                    Session["NumServiceTrnIDNomP"] = Convert.ToInt64(Request.QueryString["numMembershipReqID"]);
                    intaccno = Convert.ToInt32(Request.QueryString["intPF_No"]);
                    FillMemDetails(1);
                    FillNomineeDet();
                    FillWitnessDet();
                    SetControls();
                }
                else if (Convert.ToInt64(Request.QueryString["intPF_No"]) > 0)
                {
                    Session["NumServiceTrnIDNomP"] = 0;
                    intaccno = Convert.ToInt32(Request.QueryString["intPF_No"]);
                    FillMemDetails(2);

                    SetGridsBlankRws();
                    FillGridCombos();
                }
                else
                {
                    Session["NumServiceTrnIDNomP"] = 0;
                    SetGridsBlankRws();
                    //FillGridCombos();
                }
            }
            SetSubDateTxt();
        }
    }
    //private void SetAppFlagsInSession(DataSet dss)
    //{
    //    if (Convert.ToInt16(dss.Tables[0].Rows.Count) > 0)
    //    {
    //        Session["intFlgApp"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[0]);
    //        Session["intFlgRej"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[1]);
    //        Session["intFlgAppInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[2]);
    //        Session["intFlgRejInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[3]);
    //        Session["strOptCaption"] = dss.Tables[0].Rows[0].ItemArray[4].ToString();
    //        Session["strMsg"] = dss.Tables[0].Rows[0].ItemArray[5].ToString();
    //    }
    //}
    private void InitialSettings()
    {
        //FillBank//////////////
        DataSet ds = new DataSet();
        ds = GenDAOObj.getBank();
        gblObj.FillCombo(ddlBank, ds, 1);

        DataSet dsD = new DataSet();
        dsD = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistBank, dsD, 1);
        //FillBank//////////////
    }
    private void SetSubDateTxt()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) != 6)
        {
            txtSubDate.ReadOnly = true;
            txtSubDate.Enabled = false;
        }
        else
        {
            txtSubDate.ReadOnly = false;
            txtSubDate.Enabled = true ;
        }
    }
    protected void gdvMemReqList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string intRw = "";
        intRw = gdvMemReqList.SelectedRow.Cells[0].ToString();

    }
    public void GetMembershipReqList()
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 5 || Convert.ToInt32(Session["intUserTypeId"]) == 6)
        {
            SetReqListDefault();
        }
        else
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            DataSet ds = new DataSet();
            ds = nomDao.GetNomPdeList(ArrIn);
            gdvMemReqList.DataSource = ds;
            gdvMemReqList.DataBind();
        }
    }
    private void SetReqListDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("intSlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("intPF_No");
        ar.Add("numMembershipReqID");
        ar.Add("flgApproval");
        gblObj.SetGridDefault(gdvMemReqList, ar);
    }
    private void FillMemDetails(int flgFull)
    {
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        //ar.Add(Session["NumServiceTrnIDNomP"]);
        //ds = MemDAO.DisplayMemDet(ar);
        ar.Add(intaccno);
        ar.Add(flgFull);
        ds = nomDao.GetMemDetails(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (flgFull == 1)
            {
                txtAcc.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                lblAdd.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString() + ", " + ds.Tables[0].Rows[0].ItemArray[4].ToString() + ", " + ds.Tables[0].Rows[0].ItemArray[5].ToString();

                txtWardNo.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[3]);
                txtDoorNo1.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[4]);
                txtBldgNm.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[5]);
                txtRANo.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[29]);
                txtLocalPlace.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[6]);
                txtMainPlace.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[7]);
                txtStreet.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[30]);
                //ddlpost.SelectedValue = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[9]);
                ddlDist.SelectedValue = ds.Tables[0].Rows[0].ItemArray[10].ToString();

                DataSet dspost = new DataSet();
                ArrayList ArrIn1 = new ArrayList();
                ArrIn1.Add(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[10]));

                dspost = MemDAO.GetPostoffice(ArrIn1);
                gblObj.FillCombo(ddlpost, dspost, 1);

                ddlpost.SelectedValue = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            
                txtstate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[31]);

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
                //rdPension.SelectedValue = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                txtCnt.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                intNomOldCnt = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[20].ToString());

                txtAadhar.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();

                ddlBank.SelectedValue = ds.Tables[0].Rows[0].ItemArray[25].ToString();
                intBankId = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[25].ToString());
                ddlDistBank.SelectedValue = ds.Tables[0].Rows[0].ItemArray[28].ToString();
                FillBranch(Convert.ToInt16(ddlBank.SelectedValue.ToString()), Convert.ToInt16(ddlDistBank.SelectedValue.ToString()));
                ddlBranch.SelectedValue = ds.Tables[0].Rows[0].ItemArray[26].ToString();

                txtBankAccNo.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
            }
            else
            {
                txtAcc.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtCnt.Text = "0";
            }
        }
    }
    private void FillNomineeDet()
    {
        DataSet dsNom = new DataSet();
        ArrayList arNom = new ArrayList();
        //arNom.Add(ServiceTrnID);
        arNom.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
        //arNom.Add(AddressTypeToSave);
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

    private void FillWitnessDet()
    {
        DataSet dsW = new DataSet();
        ArrayList arW = new ArrayList();
        //arW.Add(ServiceTrnID);
        arW.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
        arW.Add(5);         //AddressTypeToSave
        dsW = MemDAO.DisplayWitness(arW);
        if (dsW.Tables[0].Rows.Count > 0)
        {
            gvWitness.DataSource = dsW;
            gvWitness.DataBind();
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
    private void SetGridsBlankRws()
    {
        gblObj.SetRowsCnt(gvNominee, 1);
        SetNomGridDisable();
        gblObj.SetRowsCnt(gvWitness, 2);
        txtCnt.Text = "0";
    }
    public void FillGridCombos()
    {
        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
        gblObj.FillCombo(ddlDistNom, ds, 1);
        //Districts/////////////

        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(Session["intLBID"]));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpost, dspost, 1);

       


        //Status nd Relation/////
        DataSet dsStatus = new DataSet();
        dsStatus = MemDAO.FillNomineeStatus();

        //Nom relation////////////////
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

        //Nom relation////////////////

        ////Replacer relation////////////////
        //ArrayList ArrInR = new ArrayList();
        //ArrInR.Add(10);
        //DataSet dsRelationR = new DataSet();
        //dsRelationR = MemDAO.GetRelationship(ArrInR);
        ////Replacer relation////////////////


        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gvNominee.Rows[i];
            DropDownList ddlStatusAssgn = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblObj.FillCombo(ddlStatusAssgn, dsStatus, 1);

            DropDownList ddNomineRelationshipAss = (DropDownList)grdVwRow.FindControl("ddNomineRelationship");
            gblObj.FillCombo(ddNomineRelationshipAss, dsRelation, 1);

            DropDownList ddNomineRelRepAss = (DropDownList)grdVwRow.FindControl("ddlRelRep");
            gblObj.FillCombo(ddNomineRelRepAss, dsRelation, 1);

        }

        //Designation/////////////
        DataSet dsDesig = new DataSet();
        dsDesig = MemDAO.GetDesignation();
        gblObj.FillCombo(ddlDesig, dsDesig, 1);
        //Designation////////////

    }
    protected void gvNominee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Details of Nominee";
            HeaderCell.ColumnSpan = 7;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Details of person referred to in col. 6 of Nomination";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvNominee.Controls[0].Controls.AddAt(0, HeaderGridRow);
            // FillGridCombos();  //////////////////////////////////


        }
    }
    //private void FillMembershipDet()
    //{
    //    DataSet ds = new DataSet();
    //    ArrayList ar1 = new ArrayList();

    //    //ar1.Add(ServiceTrnID);
    //    ar1.Add(Session["NumServiceTrnIDNomP"]);
    //    ds = MemDAO.DisplayMemDet(ar1);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        txtEmpName.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);
    //        txtWardNo.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[3]);
    //        txtDoorNo1.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[4]);
    //        txtBldgNm.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[5]);
    //        txtLocalPlace.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[6]);
    //        txtMainPlace.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[7]);
    //        txtPostoffice.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[8]);
    //        txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[9]);
    //        ddlDist.SelectedValue = ds.Tables[0].Rows[0].ItemArray[10].ToString();
    //        ddlDesig.SelectedValue = ds.Tables[0].Rows[0].ItemArray[11].ToString();
    //        rdGender.SelectedValue = ds.Tables[0].Rows[0].ItemArray[12].ToString();
    //        txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[13]);
    //        txtDOJ.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[22]);
    //        txtBP.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[14]);
    //        //txtSub.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[15]);
    //        if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[16].ToString()) > 0)
    //        {
    //            chkFund.Checked = true;
    //            ddlFund.SelectedValue = ds.Tables[0].Rows[0].ItemArray[16].ToString();
    //        }
    //        else
    //        {
    //            chkFund.Checked = false;
    //        }
    //        txtSubDate.Text = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[19]);
    //        if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[17]) == 1)
    //        {
    //            chkMarried.Checked = true;
    //        }
    //        else
    //        {
    //            chkMarried.Checked = false;
    //        }
    //        //rdPension.SelectedValue = ds.Tables[0].Rows[0].ItemArray[18].ToString();
    //        txtCnt.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
    //    }
    //}
    private void FillAddress(int intSlNo, int intSlNoRep)
    {
        DataSet dsNAdd = new DataSet();
        ArrayList arrNA = new ArrayList();
        //arrNA.Add(ServiceTrnID);
        arrNA.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
        arrNA.Add(AddressTypeToSave);
        arrNA.Add(intSlNo);
        arrNA.Add(intSlNoRep);
        dsNAdd = MemDAO.GetAddress(arrNA);
        if (dsNAdd.Tables[0].Rows.Count > 0)
        {
            txtWardNoNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[0]);
            txtDoorNo1Nom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[1]);
            txtRANoNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[2]);
            txtBldgNmNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[3]);
            txtLocalPlaceNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[4]);
            txtMainPlaceNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[5]);
            txtStreetNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[12]);
            
            txtPincodeNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[7]);
            ddlDistNom.SelectedValue = dsNAdd.Tables[0].Rows[0].ItemArray[9].ToString();

            DataSet dspost = new DataSet();
            ArrayList ArrIn1 = new ArrayList();
            ArrIn1.Add(Convert.ToInt32(dsNAdd.Tables[0].Rows[0].ItemArray[9]));

            dspost = MemDAO.GetPostoffice(ArrIn1);
            gblObj.FillCombo(ddlpostNom, dspost, 1);
            ddlpostNom.SelectedValue = dsNAdd.Tables[0].Rows[0].ItemArray[6].ToString();

            txtstateNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[11]);

        }
        else
        {
            ClearAddress();
        }
    }
    private void FillDdlNomGrid()
    {
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
    protected void btnNomineAddress_Click(object sender, EventArgs e)
    {
        int CurrRw = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        intSlNo = Convert.ToInt16(gvNominee.Rows[CurrRw].Cells[0].Text.ToString());
        AddressTypeToSave = 2;
        pnlAddress.Visible = true;
        //if (ServiceTrnID > 0)
        if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) > 0)
        {
            FillAddress(intSlNo, 1);
        }
    }
    protected void btnAddRep_Click(object sender, EventArgs e)
    {
        int CurrRw = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        intSlNo = Convert.ToInt16(gvNominee.Rows[CurrRw].Cells[0].Text.ToString());
        AddressTypeToSave = 3;
        pnlAddress.Visible = true;
        SetAddressCtrlsEnble();
        //if (ServiceTrnID > 0)
        if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) > 0)
        {
            FillAddress(intSlNo, 1);
        }      
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();
        if (Convert.ToInt16(Session["IntAppFlgInboxNomP"]) == 1)
        {
            Session["intFlgOrg"] = Convert.ToInt16(Session["intFlgAppInbx"]);
        }
        else if (Convert.ToInt16(Session["IntAppFlgInboxNomP"]) == 2)
        {
            Session["intFlgOrg"] = Convert.ToInt16(Session["intFlgRejInbx"]);
        }
        else
        {
            Session["intFlgOrg"] = Convert.ToInt16(Request.QueryString["flgApproval"]);
        }
        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //arr.Add(Convert.ToInt16(Session["intTrnType"]));
        arr.Add(Convert.ToInt64(Session["NumServiceTrnIDNomP"]));
        arr.Add(Session["intFlgOrg"]);
        dsE = GenDAOObj.GetEnableStatus(arr);
        if (dsE.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsE.Tables[0].Rows[0].ItemArray[0]) == true)
            {
                EnbleControls();
                flgEnable = 0;
            }
            else
            {
                DisableControls();
                flgEnable = 1;
            }
        }
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
    //private void FillRelation()
    //{
    //    ArrayList ArrIn = new ArrayList();
    //    if (chkMarried.Checked == false)
    //    {
    //        ArrIn.Add(0);
    //    }
    //    else
    //    {
    //        if (rdGender.SelectedValue == "1")
    //        {
    //            ArrIn.Add(1);
    //        }
    //        else
    //        {
    //            ArrIn.Add(2);
    //        }
    //    }
    //    dsRel = GetRelation(ArrIn);



    //    //ArrayList ArrInR = new ArrayList();
    //    //ArrInR.Add(10);
    //    //DataSet dsR = new DataSet();
    //    //dsR = GetRelation(ArrInR);

    //    for (int i = 0; i < gvNominee.Rows.Count; i++)
    //    {
    //        GridViewRow gvnomi = gvNominee.Rows[i];
    //        DropDownList ddNomineRelationship = (DropDownList)(gvnomi.FindControl("ddNomineRelationship"));
    //        gblObj.FillCombo( ddNomineRelationship,dsRel,1);

    //        //DropDownList ddlRelRepAss = (DropDownList)(gvnomi.FindControl("ddlRelRep"));
    //        //gblObj.FillCombo(ddlRelRepAss, dsR, 1);

    //    }
    //}
    private bool CheckAge()
    {
        DateTime Dob = new DateTime();
        DateTime TDay = new DateTime();
        int Yr;
        TDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        Dob = Convert.ToDateTime(txtDOB.Text);
        Yr = TDay.Year - Dob.Year;
        if (Yr < 18 || Yr > 56)
        {
            gblObj.MsgBoxOk("Age of employee should with in 18 and 55",this);
            return false;
        }
        else
        {
            return true;
        }
    }
    public long SaveNomineeDetails(int i)
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        GridViewRow gvrownominee = gvNominee.Rows[i - 1];

        TextBox txtNomineeName = (TextBox)(gvrownominee.FindControl("txtNomineName"));
        DropDownList ddlRelation = (DropDownList)(gvrownominee.FindControl("ddNomineRelationship"));
        TextBox txtAge = (TextBox)(gvrownominee.FindControl("txtNomineAge"));
        TextBox txtShare = (TextBox)(gvrownominee.FindControl("txtNomineShare"));

        DropDownList ddlRelRepAss = (DropDownList)(gvrownominee.FindControl("ddlRelRep"));
        TextBox txtAgeRepAss = (TextBox)(gvrownominee.FindControl("txtAgeRep"));
        TextBox txtRepNameAss = (TextBox)(gvrownominee.FindControl("txtNameRep"));

        DropDownList ddlStatusAss = (DropDownList)(gvrownominee.FindControl("ddlStatus"));
        //Mem.NumMembershipReqID = Convert.ToInt32(ServiceTrnID);
        Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnIDNomP"]);

        Mem.IntNomineeSlNo = i; //+ 1;
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
        Mem.NumEmpId = intaccno;

        lngNomId = MemDAO.CreateNomineeDetails(Mem);
        return lngNomId;
    }
    public void SaveMembershipAddress()
    {
        //Mem.NumMembershipReqID = Convert.ToInt32(ServiceTrnID);
        Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnIDNomP"]);
        if (Mem.NumMembershipReqID != 0)
        {
            Mem.IntAddressTypeID = 1;
            Mem.IntSlNo = 1;
            Mem.IntSlNoRep = 1;
            if (txtEmpName.Text == "")
            {
                Mem.ChvName = "";
            }
            else
            {
                Mem.ChvName = txtEmpName.Text;
            }
            if (txtWardNo.Text == "")
            {
                Mem.IntWardNo = 0;
            }
            else
            {
                Mem.IntWardNo = Convert.ToInt32(txtWardNo.Text.ToString());
            }
            //Mem.IntDoorNo = 0;
           
            if (txtDoorNo1.Text == "")
            {
                Mem.IntDoorNo = "0";
            }
            else
            {
                Mem.IntDoorNo = txtDoorNo1.Text.ToString();
            }
            if (txtRANo.Text == "")
            {
                Mem.rANo  = "";
            }
            else
            {
                Mem.rANo = txtRANo.Text;
            }
            if (txtBldgNm.Text == "")
            {
                Mem.ChvBldgName = "";
            }
            else
            {
                Mem.ChvBldgName = txtBldgNm.Text;
            }
            if (txtLocalPlace.Text == "")
            {
                Mem.ChvLocalPlace = "";
            }
            else
            {
                Mem.ChvLocalPlace = txtLocalPlace.Text;
            }
            if (txtMainPlace.Text == "")
            {
                Mem.ChvMainPlace = "";
            }
            else
            {
                Mem.ChvMainPlace = txtMainPlace.Text;
            }
            if (txtStreet .Text == "")
            {
                Mem.streetName = "";
            }
            else
            {
                Mem.streetName = txtStreet.Text;
            }
            if (txtPincode.Text == "")
            {
                Mem.IntPincode = 0;
            }
            else
            {
                Mem.IntPincode = Convert.ToInt32(txtPincode.Text.ToString());
            }
            if (ddlDist.SelectedValue != "")
            {
                Mem.IntDistrict = Convert.ToInt32(ddlDist.SelectedValue);
            }
            else
            {
                Mem.IntDistrict = 0;
            }
            if (ddlpost.SelectedValue != "")
            {
                Mem.IntPO = Convert.ToInt32(ddlpost.SelectedValue);
            }
            else
            {
                Mem.IntPO = 0;
            }
            Mem.IntState = 1;
            MemDAO.MembershipAddress1(Mem);
        }
    }
    public void SaveMembershipRequest()
    {
        if (Request.QueryString["MEMREqID"] != null)
        {
            //Mem.NumMembershipReqID = Convert.ToInt32(ServiceTrnID);
            Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnIDNomP"]);
        }
        else
        {
            //Mem.NumMembershipReqID = ServiceTrnID;
            Mem.NumMembershipReqID = Convert.ToDouble(Session["NumServiceTrnIDNomP"]);
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
        //if (rdGender.SelectedIndex > 0)
        //{
        //    Mem.IntGender = Convert.ToInt16(rdGender.SelectedValue);
        //}
        //else
        //{
        //    Mem.IntGender = 0;
        //}
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
        //if (rdPension.SelectedValue == "1")
        //{
        //    Mem.FlgPensionable = 1;
        //}
        //else
        //{
        //    Mem.FlgPensionable = 2;
        //}
        if (txtCnt.Text == "")
        {
            Mem.IntNominees = 0;
        }
        else
        {
            Mem.IntNominees = Convert.ToInt16(txtCnt.Text);
        }
        Mem.IntUesrID = Convert.ToInt32(Session["intUserId"]);
        Mem.DtmDateOfRequest = DateTime.Now.ToShortDateString();
        Mem.ChvFileNo = "";
        Mem.NumEmpId = intaccno;

        //Mem.IntAadhaar = Convert.ToInt64(txtAadhar.Text.ToString());
        //Mem.ChvPFNo = txtPhone.Text.ToString();
        //Mem.IntBankType = Convert.ToInt16(ddlBank.SelectedValue.ToString());
        //Mem.IntBankBranch = Convert.ToInt16(ddlBranch.SelectedValue.ToString());

        //Mem.ChvBankAccNo = txtBankAccNo.Text.ToString();
        if (txtAadhar.Text == "")
        {
            Mem.IntAadhaar = 0;
        }
        else
        {
            Mem.IntAadhaar = Convert.ToInt64(txtAadhar.Text.ToString());
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
            Mem.IntBankType = Convert.ToInt16(ddlBank.SelectedValue.ToString());
        }
        else
        {
            Mem.IntBankType = 0;
        }

        if (ddlBranch.SelectedIndex > 0)
        {
            Mem.IntBankBranch = Convert.ToInt16(ddlBranch.SelectedValue.ToString());
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
        double amt;
        amt = (Convert.ToDouble(txtBP.Text) * 6 / 100);
        if (Convert.ToDouble(txtSub.Text) < amt || (Convert.ToDouble(txtSub.Text) > (Convert.ToDouble(txtBP.Text))))
        {
            gblObj.MsgBoxOk("Minimum Subscription amount should be 6% of basic pay and Maximum Subscription amount Basic pay itself", this);
            return false;
        }
        else
        {
            return true;
        }

    }
    public bool ValidateAddress()
    {
        bool Valid;
        Valid = true;
        if (txtWardNo.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the ward in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtDoorNo1.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the door no. in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtLocalPlace.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the local place in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtMainPlace.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the main place in the address part of the employee ", this);
            Valid = false;
        }
        else if (ddlDist.SelectedIndex == 0)
        {
            gblObj.MsgBoxOk("Select the district in the address part of the employee", this);
            Valid = false;
        }
        else
        {
            Valid = true;
        }
        return Valid;
    }
    public bool ValidateAddressNom()
    {
        bool Valid;
        Valid = true;
        if (txtWardNoNom.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the ward in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtDoorNo1Nom.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the door no. in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtLocalPlaceNom.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the local place in the address part of the employee ", this);
            Valid = false;
        }
        else if (txtMainPlaceNom.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the main place in the address part of the employee ", this);
            Valid = false;
        }
        else if (ddlDistNom.SelectedIndex == 0)
        {
            gblObj.MsgBoxOk("Select the district in the address part of the employee", this);
            Valid = false;
        }
        else
        {
            Valid = true;
        }
        return Valid;
    }
    public bool ValidateFields()
    {
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
        else if (txtBP.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the basic pay ", this);
            Valid = false;
        }
        else if (txtSub.Text.Trim() == "")
        {
            gblObj.MsgBoxOk("Enter the subscription ", this);
            Valid = false;
        }
        else if (rdGender.SelectedValue == "")
        {
            gblObj.MsgBoxOk("Select the gender ", this);
            Valid = false;
        }
        //else if (rdPension.SelectedValue == "")
        //{
        //    gblObj.MsgBoxOk("Select whether employee is pensionable or not ", this);
        //    Valid = false;
        //}
        //else
        //{
        //    Valid = true;
        //}

        return Valid;
    }
    private void CreateServiceTransaction()
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        if (Request.QueryString["MEMREqID"] != null)
        {
            //ArrIn.Add(Convert.ToInt32(ServiceTrnID));
            ArrIn.Add(Convert.ToInt32(Session["NumServiceTrnIDNomP"]));
        }
        else
        {
            //if (ServiceTrnID == 0)
            if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) == 0)
            {
                ArrIn.Add(0);
            }
            else
            {
                //ArrIn.Add(Convert.ToInt32(ServiceTrnID));
                ArrIn.Add(Convert.ToInt32(Session["NumServiceTrnIDNomP"]));
            }
        }

        //ArrIn.Add(FileNo.Text.Trim());
        ArrIn.Add("");
        ArrIn.Add(intaccno);
        ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
        ArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
        //ArrIn.Add(txtAppDate.Text);
        ArrIn.Add("");
        ArrIn.Add(Convert.ToInt64(Session["intUserId"]));
        //ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
        ArrIn.Add(0);
        ds = GenDAOObj.CreateServiceTransaction(ArrIn);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            //ServiceTrnID = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            Session["NumServiceTrnIDNomP"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    public void Approval(int flgApp)
    {
        if (Convert.ToInt16(Session["intMenuItem"]) == 3)        //Not Through Inbox
        {
            approvalObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
            approvalObj.NumTrnID = Convert.ToInt32(Session["NumServiceTrnIDNomP"]);
            approvalObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
            approvalObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
            approvalObj.ChvRem  = "";
            approvalDAOObj.CreateApproval(approvalObj);
        }
    }
    public DataSet GetRelation(ArrayList ArrIn)
    {
        DataSet ds = new DataSet();
        ds = MemDAO.GetRelationship(ArrIn);
        return ds;
    }
    private void ClearAddress()
    {
        txtWardNoNom.Text = "";
        txtDoorNo1Nom.Text = "";
        txtRANoNom.Text = "";
        txtBldgNmNom.Text = "";
        txtLocalPlaceNom.Text = "";
        txtMainPlaceNom.Text = "";
        txtPincodeNom.Text = "";
        txtStreetNom.Text = "";
        txtstateNom.Text = "";
        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistNom, ds, 1);
        ddlDistNom.SelectedValue = "0";

        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(ddlDistNom.SelectedValue));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpostNom, dspost, 1);
        ddlpostNom.SelectedValue = "0";

    }
    private void FillSameAddress(int addType)
    {
        DataSet dsAdd = new DataSet();
        ArrayList arrAddn = new ArrayList();
        //arrAddn.Add(ServiceTrnID);
        arrAddn.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
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
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(ddlDistNom.SelectedItem.Value);

            dspost = MemDAO.GetPostoffice(ArrIn);
            gblObj.FillCombo(ddlpostNom , dspost, 1);
            ddlpostNom.SelectedValue = dsAdd.Tables[0].Rows[0].ItemArray[6].ToString();
            txtstateNom.Text = dsAdd.Tables[0].Rows[0].ItemArray[12].ToString();
        }
    }
    protected void chkFund_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFund.Checked)
        {
            ddlFund.Enabled = true;
            FillOtherFunds();
        }
        else
        {
            ddlFund.SelectedIndex = 0;
            ddlFund.Enabled = false;
        }
    }
    public void FillOtherFunds()
    {
        DataSet ds = new DataSet();
        ds = MemDAO.GetOtherFund();
        gblObj.FillCombo(ddlFund, ds, 1);
    }
    private void FillDdlReplcrGrid()
    {
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

        ////Fill grid
        //for (int i = 0; i < gvReplace.Rows.Count; i++)
        //{
        //    GridViewRow grdVwRow = gvReplace.Rows[i];

        //    DropDownList ddReplaceRelationshipAss = (DropDownList)grdVwRow.FindControl("ddReplaceRelationship");
        //    gblObj.FillCombo(ddReplaceRelationshipAss, dsRelation, 1);
        //}
    }
    protected void txtNomineShare_TextChanged(object sender, EventArgs e)
    {
        int tShare = 0;
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gvRw = gvNominee.Rows[i];
            TextBox txtNomineShareAss = (TextBox)(gvRw.FindControl("txtNomineShare"));
            if (txtNomineShareAss.Text == "")
            {
                txtNomineShareAss.Text = "0";
            }
            tShare = tShare + int.Parse(txtNomineShareAss.Text.ToString());
            if (tShare > 100)
            {
                gblObj.MsgBoxOk("Share is not valid!", this);
                txtNomineShareAss.Text = "";
            }
        }
    }
    //private Boolean ChkShare()
    //{
    //    Boolean fg = true;
    //    int shr = 0;
    //    for (int i = 0; i < gvNominee.Rows.Count; i++)
    //    {
    //        GridViewRow gvr = gvNominee.Rows[i];
    //        TextBox txtNomineShareAss = (TextBox)(gvr.FindControl("txtNomineShare"));
    //        shr = shr + Convert.ToInt16(txtNomineShareAss.Text);
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
    private Boolean ChkShare()
    {
        Boolean fg = true;
        int shr = 0;
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow gvr = gvNominee.Rows[i];
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
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        if (txtCnt.Text.Trim() != "")
        {
            gblObj.SetRowsCnt(gvNominee, Convert.ToInt16(txtCnt.Text.ToString()));
            SetNomGridEnable();
            FillDdlNomGrid();
            DataSet dsNom = new DataSet();
            ArrayList arNom = new ArrayList();
            //arNom.Add(ServiceTrnID);
            arNom.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
            dsNom = MemDAO.DisplayNominiDet(arNom);
            if (dsNom.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNom.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt16(txtCnt.Text.ToString()) > i)
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

                        TextBox txtnameR = (TextBox)gdvrow.FindControl("txtNameRep");
                        txtnameR.Text = dsNom.Tables[0].Rows[i].ItemArray[10].ToString();

                        DropDownList ddlRelRepR = (DropDownList)gdvrow.FindControl("ddlRelRep");
                        ddlRelRepR.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[8].ToString();

                        TextBox txtAgeRepR = (TextBox)gdvrow.FindControl("txtAgeRep");
                        txtAgeRepR.Text = dsNom.Tables[0].Rows[i].ItemArray[9].ToString();
                    }
                }
            }
            gblObj.FillGridSlNo(gvNominee);
            CreateServiceTransaction();
            Approval(Convert.ToInt16(Session["intFlgApp"]));
            SaveMembershipAddress();
            SaveMembershipRequest();
        }
        else
        {
            gblObj.SetRowsCnt(gvNominee, 1);
            SetNomGridDisable();
        }

    }
    //protected void txtNomineReplace_TextChanged(object sender, EventArgs e)
    //{
    //    pnlReplacer.Visible = true;

    //    pnlReplacer.Style.Add(HtmlTextWriterStyle.Left, "213px");
    //    pnlReplacer.Style.Add(HtmlTextWriterStyle.Top, "200px");
    //    pnlReplacer.Style.Add(HtmlTextWriterStyle.ZIndex, "100");
    //    pnlReplacer.Style.Add(HtmlTextWriterStyle.Position, "absolute");
    //}
    protected void gvNominee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
    }
    protected void btnWitnessAddress_Click(object sender, EventArgs e)
    {
        pnlAddress.Visible = true;
        chkDo.Visible = false;
        //chkDo.Checked = false;
        int CurrRw = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        intSlNo = Convert.ToInt16(gvWitness.Rows[CurrRw].Cells[0].Text.ToString());
        AddressTypeToSave = 5;

        if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) > 0)
        {
            ClearAndEditable();
            FillAddress(intSlNo, 1);
        }
        if (flgEnable == 0)
        {
            SetAddressCtrlsEnble();
        }
        else
        {
            SetAddressCtrlsDisble();
        }
    }
    public void GetDesignation()
    {
        DataSet ds = new DataSet();
        ds = MemDAO.GetDesignation();
        gblObj.FillCombo(ddlDesig, ds, 1);
    }
    public void SetNomGrid()
    {
        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDist, ds, 1);
        gblObj.FillCombo(ddlDistNom, ds, 1);
        GetDesignation();
    }
    protected void btnAddressOK_Click(object sender, EventArgs e)   //Nom Address
    {
        if (ValidateAddressNom() == true)
        {
            SaveAddress(AddressTypeToSave, intSlNo - 1, 1);
            pnlAddress.Visible = false;
        }
        else
        {
            pnlAddress.Visible = true;
        }
        chkDo.Visible = true;
        //pnlAddress.Visible = false;
        chkDo.Checked = false;
    }
    protected void chkDo_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDo.Checked == true)
        {
            FillAddNdNonEditable();
          
        }
        else
        {
            ClearAndEditable();
        }
    }
    public void ClearAndEditable()
    {
        ClearAddress();
        chkDo.Checked = false;
        //pnlAddress.Enabled = false;
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
    public void FillAddNdNonEditable()
    {

        FillSameAddress(1);
        //pnlAddress.Enabled = false;
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
        ////////////////////////////
    }
    private void SaveAddress(int addType, int i, int intSlNoRep)
    {
        //if (ServiceTrnID > 0)
        if (Convert.ToDouble(Session["NumServiceTrnIDNomP"]) > 0)
        {
            if (addType == 2)       //Nominee
            {
                GridViewRow gvrownomineeadd = gvNominee.Rows[i];
                TextBox txtName = (TextBox)(gvrownomineeadd.FindControl("txtNomineName"));
                Mem.ChvName = txtName.Text;
            }
            else if (addType == 3)  //Replacer
            {
                GridViewRow gvrownomineeaddRep = gvNominee.Rows[i];
                TextBox txtNameRepAss = (TextBox)(gvrownomineeaddRep.FindControl("txtNameRep"));
                Mem.ChvName = txtNameRepAss.Text;
            }
            else if (addType == 5)  //Witness
            {
                GridViewRow gvrWadd = gvWitness.Rows[i];
                TextBox txtWitnessNameAss = (TextBox)(gvrWadd.FindControl("txtWitnessName"));
                Mem.ChvName = txtWitnessNameAss.Text;
            }
            //Mem.NumMembershipReqID = Convert.ToInt32(ServiceTrnID);
            Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnIDNomP"]);
            Mem.IntAddressTypeID = AddressTypeToSave;
            Mem.IntSlNo = i + 1;
            Mem.IntSlNoRep = intSlNoRep;
            Mem.IntWardNo = Convert.ToInt32(txtWardNoNom.Text.ToString());
            Mem.IntDoorNo = txtDoorNo1Nom.Text.ToString();
            Mem.rANo  = txtRANoNom.Text;
            Mem.ChvBldgName = txtBldgNmNom.Text;
            Mem.ChvLocalPlace = txtLocalPlaceNom.Text;
            Mem.ChvMainPlace = txtMainPlaceNom.Text;
            Mem.streetName  = txtStreetNom.Text;
            Mem.IntPincode = Convert.ToInt32(txtPincodeNom.Text.ToString());
            if (ddlDistNom.SelectedValue != "")
            {
                Mem.IntDistrict = Convert.ToInt32(ddlDistNom.Text);
            }
            else
            {
                Mem.IntDistrict = 0;
            }
            if (ddlpostNom.SelectedValue != "")
            {
                Mem.IntPO = Convert.ToInt32(ddlpostNom.Text);
            }
            else
            {
                Mem.IntPO = 0;
            }
            Mem.IntState = 1;
            MemDAO.MembershipAddress1(Mem);
        }
    }
    protected void btnAddressClose_Click(object sender, EventArgs e)
    {
        pnlAddress.Visible = false;
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        //SaveReplacerDet();
        //pnlReplacer.Visible = false;
    }
    //protected void txtrplCnt_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtrplCnt.Text.Trim() != "")
    //    {
    //        gblObj.SetRowsCnt(gvReplace, Convert.ToInt16(txtrplCnt.Text.ToString()));
    //        SetReplcrGridEnable();
    //        FillDdlReplcrGrid();
    //        DataSet dsRep = new DataSet();
    //        ArrayList arRep = new ArrayList();
    //        arRep.Add(lngNomId);
    //        arRep.Add(1);
    //        dsRep = MemDAO.DisplayReplacer(arRep);
    //        if (dsRep.Tables[0].Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
    //            {
    //                if (Convert.ToInt16(txtrplCnt.Text) > i)
    //                {
    //                    GridViewRow gdvrow = gvReplace.Rows[i];
    //                    TextBox txtname = (TextBox)gdvrow.FindControl("txtReplaceName");
    //                    txtname.Text = dsRep.Tables[0].Rows[i].ItemArray[0].ToString();
    //                    DropDownList ddlRltn = (DropDownList)gdvrow.FindControl("ddReplaceRelationship");
    //                    ddlRltn.SelectedValue = dsRep.Tables[0].Rows[i].ItemArray[2].ToString();
    //                    TextBox txtAge = (TextBox)gdvrow.FindControl("txtReplaceAge");
    //                    txtAge.Text = dsRep.Tables[0].Rows[i].ItemArray[3].ToString();
    //                }
    //            }
    //        }
    //        gblObj.FillGridSlNo(gvNominee);
    //    }
    //    else
    //    {
    //        gblObj.SetRowsCnt(gvNominee, 1);
    //        SetReplcrGridDisable();
    //    }
    //}
    public void DisableControls()
    {
        //txtInwNo.ReadOnly = true;
        txtWardNo.ReadOnly = true;
        txtDoorNo1.ReadOnly = true;
        txtRANo.ReadOnly = true; 
        txtBldgNm.ReadOnly = true;
        txtLocalPlace.ReadOnly = true;
        txtMainPlace.ReadOnly = true;
        txtPincode.ReadOnly = true;
        txtStreet.ReadOnly = true;
        ddlDist.Enabled = false;
        ddlpost.Enabled = false; 
        ddlDesig.Enabled = false;
        rdGender.Enabled = false;
        txtDOB.ReadOnly = true;
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
        btnFinal.Enabled = false;

        txtAadhar.ReadOnly = true;
        txtPhone.ReadOnly = true;
        ddlBank.Enabled = false;
        ddlDistBank.Enabled = false;
        ddlBranch.Enabled = false;
        txtBankAccNo.ReadOnly = true;
    }
    private void SetAddressCtrlsDisble()
    {
        chkDo.Enabled = false;
        
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
    }
    public void SetGridReadWrite(GridView gdv)
    {
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdv.Rows[i];
            TextBox txtDescr = (TextBox)gdvRw.FindControl("txtDescr");
            txtDescr.ReadOnly = false;
            RadioButtonList rbtL = (RadioButtonList)gdvRw.FindControl("chkYn");
            rbtL.Enabled = true;
            Button btn = (Button)gdvRw.FindControl("btnChild");
            btn.Enabled = true;
            TextBox txtRem = (TextBox)gdvRw.FindControl("txtRem");
            txtRem.ReadOnly = false;
        }
    }
    private void SetCtrolsDisable()
    {
        //foreach (Control c in Wizard1.Controls)
        //{
        //    foreach (Control ctrl in c.Controls)
        //    {
        //        if (ctrl is TextBox)
        //        {
        //            ((TextBox)ctrl).ReadOnly = true ;
        //        }
        //        if (ctrl is DropDownList)
        //        {
        //            ((DropDownList)ctrl).Enabled = false;
        //        }
        //    }
        //}

        //HtmlForm form = (HtmlForm)this.FindControl("form1");
        //foreach (Control ctrl in form.Controls)
        //{
        //    if (ctrl is TextBox)
        //        ((TextBox)ctrl).ReadOnly = true;
        //    else if (ctrl is DropDownList)
        //        ((DropDownList)ctrl).Enabled = false;
        //}

        HtmlForm form = (HtmlForm)this.FindControl("form1");
        foreach (Control ctrl in form.Controls)
        {
            if (ctrl is Wizard)
            {
                foreach (Control ctrlW in ctrl.Controls)
                {
                    if (ctrlW is TextBox)
                        ((TextBox)ctrlW).ReadOnly = true;
                    else if (ctrlW is DropDownList)
                        ((DropDownList)ctrlW).Enabled = false;
                }
            }
        }
    }
    public void EnbleControls()
    {
        //txtInwNo.ReadOnly = true;
        txtWardNo.ReadOnly = false;
        txtDoorNo1.ReadOnly = false;
        txtRANo.ReadOnly = false;
        txtBldgNm.ReadOnly = false;
        txtLocalPlace.ReadOnly = false;
        txtMainPlace.ReadOnly = false;
        txtPincode.ReadOnly = false;
        txtStreet .ReadOnly = false;
        ddlDist.Enabled = true;
        ddlpost.Enabled = true;
        ddlDesig.Enabled = true;
        rdGender.Enabled = true;
        txtDOB.ReadOnly = false;
        txtBP.ReadOnly = false;
        txtSub.ReadOnly = false;
        //ddlFund.Enabled = true;
        chkMarried.Enabled = true;
        //rdPension.Enabled = true;
        txtSubDate.Enabled = true;
        txtCnt.ReadOnly = false;
        SetNomGridEnable();
        //SetReplcrGridEnable();        Add along with Code 4 filling data...... as it s nt filled by dis time.....
        SetWitnessGridEnable();
        SetAddressCtrlsEnble();
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
        chkDo.Enabled = true;
        
        txtWardNoNom.ReadOnly = false;
        txtDoorNo1Nom.ReadOnly = false;
        txtRANoNom.ReadOnly = false;
        txtBldgNmNom.ReadOnly = false;
        txtLocalPlaceNom.ReadOnly = false;
        txtMainPlaceNom.ReadOnly = false;
        txtPincodeNom.ReadOnly = false;
        txtStreetNom .ReadOnly = false;
        ddlDistNom.Enabled = true;
        ddlpostNom.Enabled = true;
    }
    private void PopupStr(string yr, string accno)
    {
        ////string message = "Order Placed Successfully.";
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.onload=function(){");
        //sb.Append("window.open('MsgBx.aspx?yrid=");
        //sb.Append(yr);
        //sb.Append("&accno=");
        //sb.Append(accno);
        //sb.Append("','ftfgh','left=20,top=20,width=1000,height=400,status=yes,toolbar=0,resizable=1,scrollbars=1')}");
        //sb.Append("</script>");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "asd", sb.ToString());
    }
    private void MsgBoxYesNo(string message)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("return confirm('");
        sb.Append(message);
        sb.Append("');");
        ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
    }
    protected void btnAddress_Click(object sender, EventArgs e)
    {
        pnlAddressM.Visible = true;
    }
    protected void btnAddClose_Click(object sender, EventArgs e)
    {
        if (ValidateAddress() == true)
        {
            SaveMembershipAddress();
            pnlAddressM.Visible = false;
        }
    }

    protected void btnSaveNominee_Click(object sender, EventArgs e)
    {
        if (intNomOldCnt <= Convert.ToInt16(txtCnt.Text))
        {
            if (ChkShare() == true)
            {
                for (int j = 0; j < gvNominee.Rows.Count; j++)
                {
                    intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
                    lngNomId = SaveNomineeDetails(intSlNo);
                }
            }
        }
        else
        {
            for (int j = 0; j < gvNominee.Rows.Count; j++)
            {
                intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
                lngNomId = SaveNomineeDetails(intSlNo);
            }
            for (int k = intNomOldCnt; k > Convert.ToInt16(txtCnt.Text); k--)
            {
                Mem.NumMembershipReqID = Convert.ToDouble(Session["NumServiceTrnIDNomP"]);
                Mem.IntSlNo = k;
                MemDAO.DeleteNominee(Mem);
            }
        }
       
    }
    private Boolean ValidateShare()
    {
        Boolean flg = false ;
        return flg;
    }
    protected void btnFinal_Click(object sender, EventArgs e)
    {
        if (ValidateFields() == true)
        {
            if (CheckSubscriptionAmt() == true)
            {
                if (CheckAge() == true)
                {
                    if (CheckDoj() == true)
                    {
                        if (ChkShare() == true)
                        {
                            if (ChkAllColsInNomGrid() == true)
                            {
                                CreateServiceTransaction();
                                Approval(Convert.ToInt16(Session["intFlgApp"]));
                                SaveMembershipAddress();
                                SaveMembershipRequest();
                                for (int i = 0; i < gvNominee.Rows.Count; i++)
                                {
                                    SaveNomineeDetails(i + 1);
                                }
                                SaveWitnessDet();
                                gblObj.MsgBoxOk("Saved successfully!", this);
                            }
                            else
                            {
                                gblObj.MsgBoxOk("Enter all details!", this);
                            }
                        }
                    }
                }
            }
        }
    }
    private bool CheckDoj()
    {
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
    private void SaveWitnessDet()
    {
        for (int j = 0; j < gvWitness.Rows.Count; j++)
        {
            ArrayList ar = new ArrayList();

            GridViewRow gdvrow = gvWitness.Rows[j];
            TextBox txtWname = (TextBox)gdvrow.FindControl("txtWitnessName");
            //ar.Add(txtWname);
            ar.Add(Convert.ToDouble(Session["NumServiceTrnIDNomP"]));
            ar.Add(5);
            ar.Add(j + 1);
            ar.Add(txtWname.Text.ToString());
            MemDAO.UpdAddress(ar);
        }
    }
    protected void chkMarried_CheckedChanged(object sender, EventArgs e)
    {
        //FillRelation();
    }
    protected void txtSub_TextChanged(object sender, EventArgs e)
    {
        if (CheckSubscriptionAmt() == false)
        {
            txtSub.Text = "";
        }
    }
    protected void rdGender_SelectedIndexChanged(object sender, EventArgs e)
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
        if (ddlBank.SelectedIndex > 0)
        {
            intBankId = Convert.ToInt16(ddlBank.SelectedValue);
        }
        else
        {
            intBankId = 0;
        }
    }
    private void FillBranch(int BankId, int DistId)
    {
        ArrayList ar = new ArrayList();
        ar.Add(BankId);
        ar.Add(DistId);
        DataSet dsB = new DataSet();
        dsB = GenDAOObj.getBankBranch(ar);
        gblObj.FillCombo(ddlBranch, dsB, 1);
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        if (intBankId > 0 && intDist > 0)
        {
            FillBranch(intBankId, intDist);
        }
    }
    protected void ddlDistNom_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(ddlDistNom.SelectedValue));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpostNom, dspost, 1);
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspost = new DataSet();
        ArrayList ArrIn1 = new ArrayList();
        ArrIn1.Add(Convert.ToInt32(ddlDist.SelectedValue));

        dspost = MemDAO.GetPostoffice(ArrIn1);
        gblObj.FillCombo(ddlpost, dspost, 1);
    }
}

