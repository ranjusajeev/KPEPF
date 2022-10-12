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

public partial class Contents_NomChg : System.Web.UI.Page
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
    NomChg nmChg = new NomChg();
    GeneralDAO gen = new GeneralDAO();

    static DataSet dsRel;
    static int AddressTypeToSave = 0;
    //static double ServiceTrnID = 0;
    //double ServiceTrnID = 0;
    static int share = 0;
    static int intCurRow = 0, intSlNo = 0, intSlNoRep = 0, flgEnable = 0, intNomOldCnt = 0, intUpd = 0;
    static double intaccno = 0;
    static long lngNomId;
    static int flgTbl = 0;
    public string confirmValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (confirmValue == "Yes")
        //{
        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);

        //    //   this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
        //}
        //else
        //{
        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);

        //    //   this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        //}
       // System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);
      //  string confirmValue = Request.Form["confirm_value"];
        //Add to NomTemp on request time itself
        //Trace each changes in temp tbl and on final approval all changes will b copied to Nominee tbl...
        //after insert into History ....

        if (!IsPostBack)
        {
            //DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            //gblObj.SetAppFlagsInSession(ds);
            if (Convert.ToInt16(Session["intTrnType"]) != Convert.ToInt16(Request.QueryString["k"]))
            {
                gblObj.GetStatusMapping2(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            }
            FillGridCombos();
            GetMembershipReqList();

            if (Convert.ToInt16(Session["intMenuItem"]) == 6)        //Through Inbox
            {
                gdvMemReqList.Enabled = false;
                //Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["MemReqID"]);
                Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["MemReqID"]);
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    intaccno = Convert.ToInt32(Request.QueryString["numEmpId"]);
                    btnSec.Visible = true;
                    btnSec.Text = "Back to inbox";
                    Session["intTrnType"] = 6;
                    btnSec.PostBackUrl = "~/Contents/InboxMembership.aspx";
                    FillNameAccNo();
                    FillInwrdNo();
                    FillNomineeDetFrmReq();
                    SetControls();
                }
                else
                {
                    SetReqListDefault();
                }
            }
            else if (Convert.ToInt16(Session["intMenuItem"]) == 1)        //Through View
            {
                gdvMemReqList.Enabled = false;
                if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
                {
                    intaccno = Convert.ToInt64(Session["NumEmpId"]);
                    btnSec.Visible = true;
                    btnSec.Text = "Back to View";
                    Session["intTrnType"] = 6;
                    btnSec.PostBackUrl = "~/Contents/View.aspx";
                    FillNameAccNo();
                    FillInwrdNo();
                    FillNomineeDetFrmReq();
                    SetControls();
                }
                else
                {
                    SetReqListDefault();
                }
            }
            else
            {
                gblObj.IntAppFlgInbox = 0;
                if (Convert.ToInt64(Request.QueryString["numMembershipReqID"]) > 0 && Convert.ToInt64(Request.QueryString["intTrnTypeID"]) == 6)
                {
                    flgTbl = 2;
                    //Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numMembershipReqID"]);
                    Session["NumServiceTrnID"] = Convert.ToInt64(Request.QueryString["numMembershipReqID"]);
                    intaccno = Convert.ToInt32(Request.QueryString["intPF_No"]);
                    FillNameAccNo();
                    FillInwrdNo();
                    FillNomineeDetFrmReq();
                    SetControls();
                }
                else if (Convert.ToInt64(Request.QueryString["intPF_No"]) > 0)
                {
                    flgTbl = 1;
                    intaccno = Convert.ToInt32(Request.QueryString["intPF_No"]);
                    if (EnteredPDE() == true)
                    {
                        Session["NumServiceTrnID"] = 0;
                        FillNameAccNo();
                        FillNomineeDetFrmNominee();
                        FillNomineeTemp();      //Add from Nom to temp tbl
                        FillNomineeAddress();   //Add from main Add tbl to nom chnge add tbl
                    }
                    else
                    {
                        Session["NumServiceTrnID"] = 0;
                        SetGridsBlankRws();
                        SetCtrlsDisable();
                        
                        gblObj.MsgBoxOk("You have no nominees to change!", this);
                    }
                }
                else
                {
                    Session["NumServiceTrnID"] = 0;
                    SetGridsBlankRws();
                    //FillGridCombos();
                }
            }
            //SetSubDateTxt();
        }
    }
    private void SetCtrlsDisable()
    {
        txtInwNo.Enabled = false;
        txtAppDate.Enabled = false;
        txtAppDate.ReadOnly = true;
        txtCnt.Enabled = false;
        SetNomGridDisable();
    }
    private void FillNomineeTemp()
    {
        ArrayList ar = new ArrayList();
        ar.Add(intaccno);
        MemDAO.SaveToNomTemp(ar);
    }
    private void FillNomineeAddress()
    {
        ArrayList arA = new ArrayList();
        arA.Add(intaccno);
        MemDAO.SaveNomineeAddress(arA);
    }
    private Boolean EnteredPDE()
    {
        Boolean flg = true;
        ArrayList ar = new ArrayList();
        ar.Add(intaccno);
        DataSet ds = new DataSet();
        ds = empDao.CheckNomPDEEntry(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "2")
            {
                flg = true;
                gblObj.IntGender = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                gblObj.IntMarStatus = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2].ToString());
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
    private void FillInwrdNo()
    {
        ArrayList arl = new ArrayList();
        DataSet ds = new DataSet();
        arl.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
        ds = GenDAOObj.getFileNo(arl);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtInwNo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            FileNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            gblObj.StrFileNo = FileNo.Text.ToString();
            txtAppDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = intaccno;
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            txtAcc.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            txtEmpName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    private void SetControls()
    {
        DataSet dsE = new DataSet();
        ArrayList arr = new ArrayList();
        if (gblObj.IntAppFlgInbox == 1)
        {
            gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgAppInbx"]);
        }
        else if (gblObj.IntAppFlgInbox == 2)
        {
            gblObj.IntFlgOrg = Convert.ToInt16(Session["intFlgRejInbx"]);
        }
        else
        {
            //gblObj.IntFlgOrg = Convert.ToInt16(Request.QueryString["flgApproval"]);
        }
        arr.Add(Convert.ToInt32(Session["intUserTypeId"]));
        arr.Add(Convert.ToInt32(Session["intLBTypeId"]));
        arr.Add(Convert.ToInt16(Session["intTrnType"]));
        arr.Add(gblObj.IntFlgOrg);
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
    public void DisableControls()
    {
        txtCnt.ReadOnly = true;
        SetNomGridDisable();
        //SetReplcrGridDisable();       Add along with Code 4 filling data...... as it s nt filled by dis time.....
        //SetWitnessGridDisable();
        SetAddressCtrlsDisble();
        txtInwNo.ReadOnly = true;
        txtAppDate.Enabled = false;
        txtAppDate.ReadOnly = true;
        btnFinal.Enabled = false;
    }
    public void EnbleControls()
    {
        txtCnt.ReadOnly = false;
        SetNomGridEnable();
        //SetReplcrGridDisable();       Add along with Code 4 filling data...... as it s nt filled by dis time.....
        //SetWitnessGridDisable();
        //SetAddressCtrlsDisble();
        SetAddressCtrlsEnable();
        txtInwNo.ReadOnly = true;
        txtAppDate.Enabled = true;
        txtAppDate.ReadOnly = false;
        btnFinal.Enabled = true;
    }
    //private void SetWitnessGridDisable()
    //{
    //    for (int i = 0; i < gvWitness.Rows.Count; i++)
    //    {
    //        GridViewRow gdvrow = gvWitness.Rows[i];
    //        TextBox txtWitnessNameAss = (TextBox)gdvrow.FindControl("txtWitnessName");
    //        txtWitnessNameAss.ReadOnly = true;
    //    }
    //}
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
        txtstateNom.ReadOnly = true;
    }
    private void SetAddressCtrlsEnable()
    {
        chkDo.Enabled = true;

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
    private void SetGridsBlankRws()
    {
        //gblObj.SetRowsCnt(gvNominee, 1);
        SetNomCount(1);
        SetNomGridDisable();
        txtCnt.Text = "0";
    }
    private void SetNomCount(int RowCnt)
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("numEmpId");
        ar.Add("intNomineeSlNo");
        gblObj.SetGridDefaultCnt(gvNominee, ar, RowCnt);
        FillTxtUpd();
    }
    private void FillTxtUpd()
    {
        if (txtCnt.Text.Trim() != "")
        {
            if (intNomOldCnt < Convert.ToInt16(txtCnt.Text))
            {
                int diff = Convert.ToInt16(txtCnt.Text) - intNomOldCnt;
                for (int i = intNomOldCnt; i < gvNominee.Rows.Count; i++)
                {
                    GridViewRow gvr = gvNominee.Rows[i];
                    TextBox txtUpdIdAss = (TextBox)gvr.FindControl("txtUpdId");
                    txtUpdIdAss.Text = "2";
                }
            }
        }
    }
    private void FillNomineeDetFrmReq()
    {
        ArrayList arr = new ArrayList();
        DataSet dsN = new DataSet();
        arr.Add(intaccno);
        dsN = nomDao.GetNomChg(arr);
        FillNomineeDet(dsN);
    }
    private void FillDdlNomGrid()
    {
        //Status
        DataSet dsStatus = new DataSet();
        dsStatus = MemDAO.FillNomineeStatus();


        // Relation
        //ArrayList ArrIn = new ArrayList();
        //ArrIn.Add(10);  //No filetering
        //DataSet dsRelation = new DataSet();
        //dsRelation = MemDAO.GetRelationship(ArrIn);

        ArrayList ArrIn = new ArrayList();
        if (gblObj.IntMarStatus == 1)
        {
            ArrIn.Add(0);
        }
        else
        {
            if (gblObj.IntGender == 1)
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

        //Fill grid
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            GridViewRow grdVwRow = gvNominee.Rows[i];
            DropDownList ddlStatusAssgn = (DropDownList)grdVwRow.FindControl("ddlStatus");
            gblObj.FillCombo(ddlStatusAssgn, dsStatus, 1);

            DropDownList ddNomineRelationshipAss = (DropDownList)grdVwRow.FindControl("ddNomineRelationship");
            gblObj.FillCombo(ddNomineRelationshipAss, dsRelation, 1);
            DropDownList ddReplacerAss = (DropDownList)grdVwRow.FindControl("ddlRelRep");
            gblObj.FillCombo(ddReplacerAss, dsRelation, 1);
        }
    }
    private void FillNomineeDet(DataSet dsNom)
    {
        //ArrayList arr = new ArrayList();
        //DataSet dsNom = new DataSet();
        //arr.Add(intaccno);
        //dsNom = nomDao.GetNomChgEmpIdWs(arr);
        if (dsNom.Tables[0].Rows.Count > 0)
        {
            txtCnt.Text = dsNom.Tables[0].Rows.Count.ToString();
            intNomOldCnt = Convert.ToInt16(txtCnt.Text);
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

                //Label lblNomIdAss = (Label)gdvrow.FindControl("lblNomId");
                //lblNomIdAss.Text = dsNom.Tables[0].Rows[i].ItemArray[6].ToString();

                DropDownList ddlRelRepAss = (DropDownList)gdvrow.FindControl("ddlRelRep");
                ddlRelRepAss.SelectedValue = dsNom.Tables[0].Rows[i].ItemArray[8].ToString();

                TextBox txtAgeRepAss = (TextBox)gdvrow.FindControl("txtAgeRep");
                txtAgeRepAss.Text = dsNom.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtRepnameAss = (TextBox)gdvrow.FindControl("txtNameRep");
                txtRepnameAss.Text = dsNom.Tables[0].Rows[i].ItemArray[10].ToString();

                TextBox txtUpdIdAss = (TextBox)gdvrow.FindControl("txtUpdId");
                txtUpdIdAss.Text = dsNom.Tables[0].Rows[i].ItemArray[13].ToString();
                //Address
            }
        }
        else
        {
            //gblObj.SetRowsCnt(gvNominee, 1);
            SetNomCount(1);
        }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);
        string confirmValue = Request.Form["confirm_value"];
      //  if (confirmValue == "Yes")
      //  {
     //       System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);

         //   this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
      //  }
    //    else
     //   {
      //      System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "Confirm();", true);

         //   this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
   //     }
       //int statDel = 0;
        //Session["NumEmpId"] = Convert.ToInt64(gvNominee.DataKeys[e.RowIndex].Values[0].ToString());
        //intSlNo = Convert.ToInt16(gvNominee.DataKeys[e.RowIndex].Values[1].ToString());
        ////int statDel = Convert.ToInt16(gvNominee.DataKeys[e.RowIndex].Values[1].ToString());

        //GridViewRow gr = gvNominee.Rows[e.RowIndex];
        //TextBox txtUpdIdAss = (TextBox)gr.FindControl("txtUpdId");
        //if (txtUpdIdAss.Text == "2")
        //{
        //    statDel = 2;
        //}
        //if (txtUpdIdAss.Text == "1")
        //{
        //    statDel = 4;
        //}
            
        //DeleteFromTemp(statDel);
        //FillNomineeDetFrmNomineeTemp();
    }
    private void DeleteFromTemp(int statDel)
    {
        ArrayList ar = new ArrayList();
        ar.Add(Session["NumEmpId"]);
        ar.Add(intSlNo);
        ar.Add(statDel);
        MemDAO.DeleteFromTemp(ar);
        //MemDAO.SaveHISAndDel(ar);
    }

    private void FillNomineeDetFrmNominee()
    {
        ArrayList arr = new ArrayList();
        DataSet dsNom = new DataSet();
        arr.Add(intaccno);
        dsNom = nomDao.GetNomChgEmpIdWs(arr);
        FillNomineeDet(dsNom);
    }
    private void FillNomineeDetFrmNomineeTemp()
    {
        ArrayList arrT = new ArrayList();
        DataSet dsNomT = new DataSet();
        arrT.Add(intaccno);
        dsNomT = nomDao.GetNomChgEmpIdWsTemp(arrT);
        FillNomineeDet(dsNomT);
    }
    public void FillGridCombos()
    {
        DataSet ds = new DataSet();
        ds = GenDAOObj.GetDistrict();
        gblObj.FillCombo(ddlDistNom, ds, 1);
        //Districts/////////////

        //Status nd Relation/////
        DataSet dsStatus = new DataSet();
        dsStatus = MemDAO.FillNomineeStatus();

        ArrayList ArrIn = new ArrayList();
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
        ArrIn.Add(10);      //10-Fill all relations
        DataSet dsRelation = new DataSet();
        dsRelation = MemDAO.GetRelationship(ArrIn);

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
            //ArrayList ar = new ArrayList();
            //ar.Add("intSlNo");
            //ar.Add("chvPF_No");
            //ar.Add("chvName");
            //ar.Add("intPF_No");
            //ar.Add("numMembershipReqID");
            //ar.Add("flgApproval");
            //gblObj.SetGridDefault(gdvMemReqList,ar);
        }
        else
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            DataSet ds = new DataSet();
            ds = nomDao.GetNomChgPdeList(ArrIn);
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

    protected void btnAddressOK_Click(object sender, EventArgs e)   //Nom Address
    {
        if (Validatefields() == true)
        {
            if (ValidateAddressNom() == true)
            {
                //gblObj.CreateServiceTransaction()
               // gblObj.CreateServiceTransaction(Convert.ToInt32(Session["NumServiceTrnID"]), FileNo.Text.Trim(), intaccno, Convert.ToInt16(Session["intLBID"]), txtAppDate.Text, Convert.ToInt16(txtInwNo.Text));
                CreateServiceTransaction();
                CreateNomChgReq(intSlNo - 1);
                SaveAddress(AddressTypeToSave, intSlNo - 1, 1);
                pnlAddress.Visible = false;
            }
            else
            {
                pnlAddress.Visible = true;
            }
            chkDo.Visible = true;
            chkDo.Checked = false;
        }
        //else
        //{
        //    gblObj.MsgBoxOk("Enter Inward No.",this);
        //}
    }
    private Boolean Validatefields()
    {
        Boolean flg = true;
        if (txtInwNo.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Enter Inward No.", this);
        }
        else if (txtAppDate.Text == "")
        {
            flg = false;
            gblObj.MsgBoxOk("Select Date of Request", this);
        }
        else
        {
            flg = true;
        }
        return flg;
    }
    private void CreateNomChgReq(int i)
    {

        GridViewRow gvrownominee = gvNominee.Rows[i];
        TextBox txtNomName = (TextBox)(gvrownominee.FindControl("txtNomineName"));

        DropDownList ddlRelation = (DropDownList)(gvrownominee.FindControl("ddNomineRelationship"));

        TextBox txtAge = (TextBox)(gvrownominee.FindControl("txtNomineAge"));
        TextBox txtShare = (TextBox)(gvrownominee.FindControl("txtNomineShare"));

        DropDownList ddlRelRepAss = (DropDownList)(gvrownominee.FindControl("ddlRelRep"));
        TextBox txtAgeRepAss = (TextBox)(gvrownominee.FindControl("txtAgeRep"));
        TextBox txtRepNameAss = (TextBox)(gvrownominee.FindControl("txtNameRep"));
        TextBox txtUpdIdAss = (TextBox)(gvrownominee.FindControl("txtUpdId"));
        DropDownList ddlStatusAss = (DropDownList)(gvrownominee.FindControl("ddlStatus"));

        nmChg.NumTrnID = Convert.ToInt32(Session["NumServiceTrnID"]);
        nmChg.NumEmpID = intaccno;
        nmChg.IntNomineeSlNo = Convert.ToInt16(gvNominee.Rows[i].Cells[0].Text.ToString());
        //int intSlNoNom = Convert.ToInt16(gvNominee.Rows[i].Cells[0].Text.ToString());
        nmChg.ChvNomineeName = txtNomName.Text.ToString();
        nmChg.IntRelation = Convert.ToInt16(ddlRelation.SelectedValue);
        if (txtAge.Text.Trim() == "")
        {
            nmChg.IntAge = 0;
        }
        else
        {
            nmChg.IntAge = Convert.ToInt16(txtAge.Text);
        }
        if (txtShare.Text.Trim() == "")
        {
            nmChg.FltShare = 0;
        }
        else
        {
            nmChg.FltShare = Convert.ToInt16(txtShare.Text);
        }
        //nmChg.FltShare = Convert.ToDouble(txtShare.Text);
        nmChg.IntStatus = Convert.ToInt16(ddlStatusAss.SelectedValue);
        nmChg.ChvRepName = txtRepNameAss.Text;
        nmChg.IntReplacerRelation = Convert.ToInt16(ddlRelRepAss.SelectedValue);
        if (txtAgeRepAss.Text.Trim() == "")
        {
            nmChg.IntReplacerAge = 0;
        }
        else
        {
            nmChg.IntReplacerAge = Convert.ToInt16(txtAgeRepAss.Text);
        }
        //nmChg.IntReplacerAge = Convert.ToInt16(txtAgeRepAss.Text);
        nmChg.IntSlNo = FindOrderOfChangeNom();
        nmChg.FlgNomChange = Convert.ToInt16(txtUpdIdAss.Text);
        nomDao.CreateNomChg(nmChg);
        nomDao.UpdateNomTemp(nmChg);
    }
    private int FindOrderOfChangeNom()
    {
        int ordr = 0;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intaccno);
        ds = nomDao.GetSlNo(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ordr = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            ordr = 0;
        }
        return ordr;
    }
    private void SaveAddress(int addType, int i, int intSlNoRep)
    {
        //if (ServiceTrnID > 0)
        if (Convert.ToInt32(Session["NumServiceTrnID"])> 0)
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
            Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnID"]);
            Mem.IntAddressTypeID = AddressTypeToSave;
            Mem.IntSlNo = i + 1;
            Mem.IntSlNoRep = intSlNoRep;
            Mem.IntWardNo = Convert.ToInt32(txtWardNoNom.Text.ToString());
            Mem.IntDoorNo = txtDoorNo1Nom.Text.ToString();
            Mem.rANo = txtRANoNom.Text;
            Mem.ChvBldgName = txtBldgNmNom.Text;
            Mem.ChvLocalPlace = txtLocalPlaceNom.Text;
            Mem.ChvMainPlace = txtMainPlaceNom.Text;
            Mem.streetName = txtStreetNom.Text;
            Mem.IntPincode = Convert.ToInt32(txtPincodeNom.Text.ToString());
            if (ddlDistNom.SelectedValue != "")
            {
                Mem.IntDistrict = Convert.ToInt32(ddlDistNom.Text);
            }
            else
            {
                Mem.IntDistrict = 0;
            }
            Mem.NumEmpId = intaccno;
            if (ddlpostNom.SelectedValue != "")
            {
                Mem.IntPO  = Convert.ToInt32(ddlpostNom.Text);
            }
            else
            {
                Mem.IntPO = 0;
            }
            Mem.IntState = 1;
            nomDao.CreateAddressNomChg(Mem);
        }
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
                gblObj.MsgBoxOk("Invalid data!", this);
                txtNomineShareAss.Text = "";
            }
        }
    }
    protected void txtCnt_TextChanged(object sender, EventArgs e)
    {
        if (txtCnt.Text.Trim() != "")
        {
            if (intNomOldCnt > Convert.ToInt16(txtCnt.Text))
            {
                gblObj.MsgBoxOk("If you want to delete, use the delete button!", this);
            }
            else
            {
                //gblObj.SetRowsCnt(gvNominee, Convert.ToInt16(txtCnt.Text.ToString()));
                SetNomCount(Convert.ToInt16(txtCnt.Text));
                SetNomGridEnable();
                FillDdlNomGrid();
                DataSet dsNom = new DataSet();
                ArrayList arNom = new ArrayList();
                //arNom.Add(Session["NumServiceTrnID"]);
                arNom.Add(intaccno);

                dsNom = nomDao.GetNomChg(arNom);
                if (dsNom.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsNom.Tables[0].Rows.Count; i++)
                    {
                        //if (Convert.ToInt16(txtCnt.Text.ToString()) > i)
                        //{
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

                        TextBox txtUpdIdAss = (TextBox)gdvrow.FindControl("txtUpdId");
                        txtUpdIdAss.Text = dsNom.Tables[0].Rows[i].ItemArray[13].ToString();
                        //}
                    }
                }
                gblObj.FillGridSlNo(gvNominee);
                CreateServiceTransaction();
                Approval(Convert.ToInt16(Session["intFlgApp"]));
                SaveMembershipAddress();
            }
        }
        else
        {
            //gblObj.SetRowsCnt(gvNominee, 1);
            SetNomCount(Convert.ToInt16(txtCnt.Text));
            SetNomGridDisable();
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
            txtNomineNameAss.Enabled = true;
            DropDownList ddNomineRelationshipAss = (DropDownList)gdvrow.FindControl("ddNomineRelationship");
            ddNomineRelationshipAss.Enabled = true;
            TextBox txtNomineAgeAss = (TextBox)gdvrow.FindControl("txtNomineAge");
            txtNomineAgeAss.ReadOnly = false;
            txtNomineAgeAss.Enabled = true;
            TextBox txtNomineShareAss = (TextBox)gdvrow.FindControl("txtNomineShare");
            txtNomineShareAss.ReadOnly = false;
            txtNomineShareAss.Enabled = true;
            DropDownList ddlStatusAss = (DropDownList)gdvrow.FindControl("ddlStatus");
            ddlStatusAss.Enabled = true;

            TextBox txtNameRepAss = (TextBox)gdvrow.FindControl("txtNameRep");
            txtNameRepAss.ReadOnly = false;
            txtNameRepAss.Enabled = true;
            DropDownList ddlRelRepAss = (DropDownList)gdvrow.FindControl("ddlRelRep");
            ddlRelRepAss.Enabled = true;
            TextBox txtAgeRepAss = (TextBox)gdvrow.FindControl("txtAgeRep");
            txtAgeRepAss.ReadOnly = false;
            txtAgeRepAss.Enabled = true;
        }
    }

    protected void gvNominee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
    }
    protected void btnSaveNominee_Click(object sender, EventArgs e)
    {
        //if (intNomOldCnt <= Convert.ToInt16(txtCnt.Text))
        //{
        //    for (int j = 0; j < gvNominee.Rows.Count; j++)
        //    {
        //        intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
        //    }
        //}
        //else
        //{
        //    for (int j = 0; j < gvNominee.Rows.Count; j++)
        //    {
        //        intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
        //        //lngNomId = SaveNomineeDetails(intSlNo);
        //    }
        //    for (int k = intNomOldCnt; k > Convert.ToInt16(txtCnt.Text); k--)
        //    {
        //        Mem.NumMembershipReqID = Session["NumServiceTrnID"];
        //        Mem.IntSlNo = k;
        //        MemDAO.DeleteNominee(Mem);
        //    }
        //}
    }
    protected void btnNomineAddress_Click(object sender, EventArgs e)
    {
        int CurrRw = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        intSlNo = Convert.ToInt16(gvNominee.Rows[CurrRw].Cells[0].Text.ToString());
        AddressTypeToSave = 2;
        pnlAddress.Visible = true;
        intUpd = FindUpdId(CurrRw);
        if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0 && intUpd == 1)
        {
            FillAddressNomChg(intSlNo, 2);
        }
        else
        {
            FillAddressNomChg(intSlNo, 1);
        }
    }
    private int FindUpdId(int CurRw)
    {
        int rtnVal = 0;
        GridViewRow gr = gvNominee.Rows[CurRw];
        TextBox txtUpdIdAss = (TextBox)gr.FindControl("txtUpdId");
        rtnVal = Convert.ToInt16(txtUpdIdAss.Text);
        return rtnVal;
    }
    protected void btnAddRep_Click(object sender, EventArgs e)
    {
        int CurrRw = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        intSlNo = Convert.ToInt16(gvNominee.Rows[CurrRw].Cells[0].Text.ToString());
        AddressTypeToSave = 3;
        pnlAddress.Visible = true;
        SetAddressCtrlsEnable();
        //if (Session["NumServiceTrnID"] > 0)
        //{
        //    //FillAddressNomChg(intSlNo,2);
        //    FillAddressNomChg(intSlNo, flgTbl);
        //}
        //else 
        //{
        //    //FillAddressNomChg(intSlNo,1);
        //    FillAddressNomChg(intSlNo, flgTbl);
        //}
        FillAddressNomChg(intSlNo, flgTbl);
    }

    private void FillAddressNomChg(int intSlNo, int flgTbl)
    {
        DataSet dsNAdd = new DataSet();
        ArrayList arrNA = new ArrayList();

        if (flgTbl == 2)
        {
            arrNA.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
            arrNA.Add(AddressTypeToSave);
            arrNA.Add(intSlNo);
            dsNAdd = nomDao.GetAddressNomChg(arrNA);
        }
        else
        {
            arrNA.Add(intaccno);
            arrNA.Add(AddressTypeToSave);
            arrNA.Add(intSlNo);
            dsNAdd = nomDao.GetAddressNom(arrNA);
        }
        if (dsNAdd.Tables[0].Rows.Count > 0)
        {
            txtWardNoNom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[0]);
            txtDoorNo1Nom.Text = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[1]);
            txtRANoNom.Text  = Convert.ToString(dsNAdd.Tables[0].Rows[0].ItemArray[2]);
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

    protected void chkDo_CheckedChanged(object sender, EventArgs e)
    {
        int r = intUpd;
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
    private void ClearAddress()
    {
        txtWardNoNom.Text = "";
        txtDoorNo1Nom.Text = "";
        txtRANoNom.Text = "";
        txtBldgNmNom.Text = "";
        txtLocalPlaceNom.Text = "";
        txtMainPlaceNom.Text = "";
        txtPincodeNom.Text = "";
        txtstateNom.Text = "";
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
    private void FillSameAddress(int addType, int intUpdId)
    {
        DataSet dsAdd = new DataSet();
        ArrayList arrAddn = new ArrayList();

        if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0 && intUpdId != 2)
        {
            arrAddn.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
            arrAddn.Add(addType);
            arrAddn.Add(1);
            arrAddn.Add(1);
            dsAdd = MemDAO.GetAddress(arrAddn);
        }
        else
        {
            arrAddn.Add(intaccno);
            arrAddn.Add(addType);
            arrAddn.Add(1);
            dsAdd = nomDao.GetAddressNom(arrAddn);
        }
        //nomDao.GetAddressNom();
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
    //private void FindTrnIdFromNomPDE()
    //{

    //}
    private void FillAddNdNonEditable()
    {

        FillSameAddress(1,intUpd);
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
        ////////////////////////////
    }

    protected void btnFinal_Click(object sender, EventArgs e)
    {
        if (Validatefields() == true)
        {
            CreateServiceTransaction();
            Approval(Convert.ToInt16(Session["intFlgApp"]));
            SaveNomChgRequest();        //Save NomChgRequest and NomTemp

            //SaveNomineeTemp();

            gblObj.MsgBoxOk("Saved successfully!", this);
            //}
        }
    }
    private void SaveNomChgRequest()
    {
        for (int i = 0; i < gvNominee.Rows.Count; i++)
        {
            CreateNomChgReq(i);
        }
    }
    public void SetNomCnt()
    {
        if (intNomOldCnt <= Convert.ToInt16(txtCnt.Text))
        {
            for (int j = 0; j < gvNominee.Rows.Count; j++)
            {
                intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
            }
        }
        else
        {
            for (int j = 0; j < gvNominee.Rows.Count; j++)
            {
                intSlNo = Convert.ToInt16(gvNominee.Rows[j].Cells[0].Text.ToString());
            }
            for (int k = intNomOldCnt; k > Convert.ToInt16(txtCnt.Text); k--)
            {
                Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnID"]);
                Mem.IntSlNo = k;
                MemDAO.DeleteNominee(Mem);
            }
        }
    }
    public void SaveMembershipAddress()
    {
        ////Mem.NumMembershipReqID = Convert.ToInt32(ServiceTrnID);
        //Mem.NumMembershipReqID = Convert.ToInt32(Session["NumServiceTrnID"]);
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
        //    if (txtWardNo.Text == "")
        //    {
        //        Mem.IntWardNo = 0;
        //    }
        //    else
        //    {
        //        Mem.IntWardNo = Convert.ToInt32(txtWardNo.Text.ToString());
        //    }
        //    Mem.IntDoorNo = 0;
        //    if (txtDoorNo1.Text == "")
        //    {
        //        Mem.ChvDoorNo1 = "";
        //    }
        //    else
        //    {
        //        Mem.ChvDoorNo1 = txtDoorNo1.Text;
        //    }
        //    if (txtBldgNm.Text == "")
        //    {
        //        Mem.ChvBldgName = "";
        //    }
        //    else
        //    {
        //        Mem.ChvBldgName = txtBldgNm.Text;
        //    }
        //    if (txtLocalPlace.Text == "")
        //    {
        //        Mem.ChvLocalPlace = "";
        //    }
        //    else
        //    {
        //        Mem.ChvLocalPlace = txtLocalPlace.Text;
        //    }
        //    if (txtMainPlace.Text == "")
        //    {
        //        Mem.ChvMainPlace = "";
        //    }
        //    else
        //    {
        //        Mem.ChvMainPlace = txtMainPlace.Text;
        //    }
        //    if (txtPostoffice.Text == "")
        //    {
        //        Mem.ChvPostoffice = "";
        //    }
        //    else
        //    {
        //        Mem.ChvPostoffice = txtPostoffice.Text;
        //    }
        //    if (txtPincode.Text == "")
        //    {
        //        Mem.IntPincode = 0;
        //    }
        //    else
        //    {
        //        Mem.IntPincode = Convert.ToInt32(txtPincode.Text.ToString());
        //    }
        //    if (ddlDist.SelectedValue != "")
        //    {
        //        Mem.IntDistrict = Convert.ToInt32(ddlDist.SelectedValue);
        //    }
        //    else
        //    {
        //        Mem.IntDistrict = 0;
        //    }
        //    MemDAO.MembershipAddress1(Mem);
        //}
    }

    //public bool ValidateFields()
    //{
    //    bool Valid;
    //    Valid = true;


    //    if (txtEmpName.Text.Trim() == "")
    //    {
    //        gblObj.MsgBoxOk("Enter the name of employee ", this);
    //        Valid = false;
    //    }
    //    else if (ddlDesig.SelectedIndex == 0)
    //    {
    //        gblObj.MsgBoxOk("Select the designation of the employee", this);
    //        Valid = false;
    //    }
    //    else if (txtDOB.Text.Trim() == "")
    //    {
    //        gblObj.MsgBoxOk("Enter the date of birth ", this);
    //        Valid = false;
    //    }
    //    else if (txtBP.Text.Trim() == "")
    //    {
    //        gblObj.MsgBoxOk("Enter the basic pay ", this);
    //        Valid = false;
    //    }
    //    else if (txtSub.Text.Trim() == "")
    //    {
    //        gblObj.MsgBoxOk("Enter the subscription ", this);
    //        Valid = false;
    //    }
    //    else if (rdGender.SelectedValue == "")
    //    {
    //        gblObj.MsgBoxOk("Select the gender ", this);
    //        Valid = false;
    //    }
    //    else if (rdPension.SelectedValue == "")
    //    {
    //        gblObj.MsgBoxOk("Select whether employee is pensionable or not ", this);
    //        Valid = false;
    //    }
    //    else
    //    {
    //        Valid = true;
    //    }

    //    return Valid;
    //}
    private void CreateServiceTransaction()
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        if (Request.QueryString["MEMREqID"] != null)
        {
            //ArrIn.Add(Convert.ToInt32(ServiceTrnID));Convert.ToInt64(Session["NumServiceTrnID"])
            ArrIn.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
        }
        else
        {
            //if (ServiceTrnID == 0)
            if (Convert.ToInt64(Session["NumServiceTrnID"]) == 0)
            {
                ArrIn.Add(0);
            }
            else
            {
                //ArrIn.Add(Convert.ToInt32(ServiceTrnID));
                ArrIn.Add(Convert.ToInt32(Session["NumServiceTrnID"]));
            }
        }
        if (txtInwNo.Text == null || txtInwNo.Text.Trim() == "")
        {
            txtInwNo.Text = "0";
            gblObj.MsgBoxOk("Enter Inward No.", this);
        }
        else
        {
            ArrIn.Add(FileNo.Text.Trim());
            //ArrIn.Add("");
            ArrIn.Add(intaccno);
            ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
            ArrIn.Add(Convert.ToInt16(Session["intTrnType"]));
            ArrIn.Add(txtAppDate.Text);
            //ArrIn.Add("");
            ArrIn.Add(Convert.ToInt64(Session["intUserId"]));
            ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
            //ArrIn.Add(0);
            ds = GenDAOObj.CreateServiceTransaction(ArrIn);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                //ServiceTrnID = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                Session["NumServiceTrnID"] = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
        }
    }
    public void Approval(int flgApp)
    {
        if (Convert.ToInt16(Session["intMenuItem"]) == 3)        //Through Inbox
        {
            approvalObj.IntTrnTypeID = Convert.ToInt16(Session["intTrnType"]);
            approvalObj.NumTrnID = Convert.ToInt32(Session["NumServiceTrnID"]);
            approvalObj.FlgApproval = Convert.ToInt16(Session["intFlgApp"]);
            approvalObj.IntUserId = Convert.ToInt32(Session["intUserId"]);
            approvalObj.ChvRem = "";
            approvalDAOObj.CreateApproval(approvalObj);
        }
    }

    protected void txtInwNo_TextChanged(object sender, EventArgs e)
    {
        gblObj.FillFileNo(txtInwNo, FileNo, Session["File"].ToString(), this);
    }


    protected void txtAppDate_TextChanged(object sender, EventArgs e)
    {
        if (txtAppDate.Text != "")
        {
            if (Convert.ToDateTime(txtAppDate.Text).Date > DateTime.Now.Date)
            {
                txtAppDate.Text = "";
            }
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
    protected void txtWardNoNom_TextChanged(object sender, EventArgs e)
    {

    }
}
