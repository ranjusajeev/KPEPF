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

public partial class Contents_PassBook : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    Passbook pass = new Passbook();
    passbookDAO passDAO = new passbookDAO();
    GeneralDAO gen = new GeneralDAO();
    public int disID;
    public int countRow;
    public int rowSize;
    int RemTot = 0;
    public int accNo = 0; public int intYrId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
           
            DataSet ds = new DataSet();
            ds=passDAO.GetYear();
            gblObj.FillCombo(ddlyear, ds, 1);
            
            InitialSettings();
            
        }
       
    }
    private void FillGridComb()
    {
        DataSet ds=new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["intUserId"]));
        ds=passDAO.GetUserDistrict(arrIn);
        if(ds.Tables[0].Rows.Count > 0)
        {
            disID=Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            DataSet dsCmb=new DataSet();
            ArrayList arrCmb=new ArrayList();
            arrCmb.Add(disID);
            dsCmb=passDAO.GetTreasury(arrCmb);
              for (int i = 0; i <gdvInboxTA.Rows.Count; i++)
                {
                    GridViewRow grdVwRow = gdvInboxTA.Rows[i];
                    DropDownList ddlTreasAss = (DropDownList)grdVwRow.FindControl("ddlTreas");
                    gblObj.FillCombo(ddlTreasAss, dsCmb, 1);

                    DropDownList ddlGOAss = (DropDownList)grdVwRow.FindControl("ddlGO");
                    DataSet dsGo = new DataSet();
                    dsGo = GenDao.GetGO();
                    gblObj.FillCombo(ddlGOAss, dsGo, 1);

                    DropDownList ddltypeAss = (DropDownList)grdVwRow.FindControl("ddltype");
                    DataSet dstype = new DataSet();
                    dstype=passDAO.GetWithType();
                    gblObj.FillCombo(ddltypeAss, dstype, 1);
                }

        }

    }
    private void InitialSettings()
    {
        DataSet ds = gblObj.GetStatusMapping1(Convert.ToInt32(Session["intUserTypeId"]), Convert.ToInt32(Session["intLBTypeId"]), Convert.ToInt16(Session["intTrnType"]), Convert.ToInt16(Session["intTrnTypeStage"]), Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            pnlSecdetails.Visible = false ;
            pnlDetails.Visible = true;
            pnlpassbook.Visible = true;
            //DataSet ds = new DataSet();
            //ds = passDAO.GetMonth();
            //gdvInboxTA.DataSource  = ds;
            //gdvInboxTA.DataBind();
        }
        else if (Convert.ToInt32(Session["intUserTypeId"]) == 3)
        {
            pnlDetails.Visible = false ;
            pnlpassbook.Visible = false;
            pnlSecdetails.Visible = true;
            DataSet dss = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            dss = passDAO.GetInboxSec(ArrIn);
            gdvInboxSec.DataSource = dss;
            gdvInboxSec.DataBind();
            if (Convert.ToInt32(Request.QueryString["numEmpId"]) > 0)
            {
                rlist.Visible = true;
                pnlpassbook.Visible = true;
                fillgrid();
            }
            else
            {
                ClearGrid();
                rlist.Visible = false;
            }
        }
    }
    protected void txtaccno_TextChanged(object sender, EventArgs e)
    {
          Session["NumEmpId"] = Convert.ToDouble(txtaccno.Text.ToString());
          if (gblObj.WhetherLBMatch(Convert.ToInt64(Session["NumEmpId"]), Convert.ToInt16(Session["intLBId"])) == true)
          {
              ClearGrid();
              pass.NumEmpId = Convert.ToInt32(txtaccno.Text);
              pass.IntYearId = Convert.ToInt16(ddlyear.SelectedItem.Value);
              SetGridRow();

              FillGridComb();
              ArrayList arr = new ArrayList();
              pass.NumEmpId = Convert.ToInt64(Session["NumEmpId"]);
              //Session["NumEmpId"] = pass.NumEmpId;
              DataSet ds = new DataSet();
               ds = passDAO.GetEmployeeDetails(pass);
              if (ds.Tables[0].Rows.Count > 0)
              {
                  lblAcc.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
              }
          }
          else
          {
              gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
              txtaccno.Text = "";
          }
    }
    private void SetGridRow()
    {
       
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        ds = passDAO.GetMaxMonthInChalanDetails(pass);
        if (ds.Tables[0].Rows.Count > 0)
        {
            countRow =Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
        }
       
           rowSize = calculatebalMonth(countRow);
           gdvInboxTA.PageSize = rowSize;
           DataSet dsgrd = new DataSet();
           ArrayList ArrIn = new ArrayList();
           ArrIn.Add(countRow);
           dsgrd = passDAO.GetMonthid(ArrIn);
           DataSet dsfillgrid = new DataSet();
           ArrayList arrblMnth = new ArrayList();
           arrblMnth.Add(Convert.ToInt32(dsgrd.Tables[0].Rows[0].ItemArray[0]));
           dsfillgrid = passDAO.GetBalanceMonth(arrblMnth);
           gdvInboxTA.DataSource = dsfillgrid;
           gdvInboxTA.DataBind();
                       
    }
    private void fillGridMnth()
    {
       
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["intUserTypeId"]) == 1)
        {
            FindHorTotal();
            SavePassBook();
        }
        else  if (Convert.ToInt32(Session["intUserTypeId"]) == 3)
        {
            
                UpdatePassbook();
                ClearGrid();
            
        }
    }
    private void UpdatePassbook()
    {
       
        if (Convert.ToInt32(Request.QueryString["numEmpId"]) > 0 && Convert.ToInt32(Request.QueryString["intYearId"]) > 0)
        {
           
                pass.NumEmpId = Convert.ToInt32(Request.QueryString["numEmpId"]);
                pass.IntYearId = Convert.ToInt32(Request.QueryString["intYearId"]);
                if (rlist.Items[0].Selected == true)
                {
                    pass.FlgFlag = 3;
                }
                else
                {
                    pass.FlgFlag = 100;
                }
                passDAO.PassbookUpd(pass);
                gblObj.MsgBoxOk("Updated  !", this);
        }
    }
    private void SavePassBook()
    {
        if (Convert.ToInt32(txtaccno.Text) > 0 && ddlyear.SelectedValue != "")
        {
            for (int i = 0; i <= gdvInboxTA.Rows.Count-1 ; i++)
            {
                GridViewRow gdv = gdvInboxTA.Rows[i];
                pass.NumEmpId = Convert.ToInt32(txtaccno.Text);
                pass.IntYearId = Convert.ToInt16( ddlyear.SelectedItem.Value) ;
                Label lblMonthIdAssgn = (Label)gdv.FindControl("lblMonthId");
                pass.IntMonthId = Convert.ToInt16(lblMonthIdAssgn.Text);
                TextBox txtdateAss=(TextBox )gdv.FindControl("txtdate");
                if (txtdateAss.Text == "")
                {
                    pass.DtmEncashmnt = "";
                }
                else
                {
                    pass.DtmEncashmnt = txtdateAss.Text;
                }
               
                DropDownList ddlTreasAss = (DropDownList)gdv.FindControl("ddlTreas");
                if (ddlTreasAss.SelectedIndex > 0)
                {
                    pass.IntTreasuryId = Convert.ToInt16(ddlTreasAss.SelectedItem.Value );
                }
                else
                {
                    pass.IntTreasuryId = 0;
                }
                TextBox txtchalanNoAss = (TextBox)gdv.FindControl("txtchalanNo");
                if (txtchalanNoAss.Text == "")
                {
                     pass.IntChalanNo = 0;
                }
                else
                {
                    pass.IntChalanNo = Convert.ToInt16(txtchalanNoAss.Text);
                }
                TextBox txtchalandateAss = (TextBox)gdv.FindControl("txtchalandate");
                if (txtchalandateAss.Text == "")
                {
                    pass.DtmChalanDate  = "" ;
                }
                else
                {
                    pass.DtmChalanDate = txtchalandateAss.Text;
                }
                TextBox txtsubAass = (TextBox)gdv.FindControl("txtsub");
                if (txtsubAass.Text == "")
                {
                    pass.FltSubn = 0;
                }
                else
                {
                    pass.FltSubn = float.Parse(txtsubAass.Text);
                }
                TextBox txtrfamtAss = (TextBox)gdv.FindControl("txtrfamt");

                if (txtrfamtAss.Text == "")
                {
                    pass.FltRepay = 0;
                }
                else
                {
                    pass.FltRepay = float.Parse(txtrfamtAss.Text);
                }
               
                TextBox txtarrAmtAss = (TextBox)gdv.FindControl("txtarrAmt");

                if (txtarrAmtAss.Text == "")
                {
                    pass.FltArrDA = 0;
                }
                else
                {
                    pass.FltArrDA = float.Parse(txtarrAmtAss.Text);
                }
               

                DropDownList ddlGOAss = (DropDownList)gdv.FindControl("ddlGO");
                if (ddlGOAss.SelectedIndex > 0)
                {
                    pass.ChvGO  =ddlGOAss.SelectedValue;
                }
                else
                {
                    pass.ChvGO = "";
                }
                TextBox txtGodateAss = (TextBox)gdv.FindControl("txtGodate");

                if (txtGodateAss.Text == "")
                {
                    pass.DtmGODate = "";
                }
                else
                {
                    pass.DtmGODate = txtGodateAss.Text;
                }
               
                TextBox txttotalAss = (TextBox)gdv.FindControl("txttotal");
                //pass.DtmGODate = txtGodateAss.Text; 
                TextBox txtwithdrawalAss = (TextBox)gdv.FindControl("txtwithdrawal");

                if (txtwithdrawalAss.Text == "")
                {
                    pass.FltWithdrawal = 0;
                }
                else
                {
                    pass.FltWithdrawal = float.Parse(txtwithdrawalAss.Text);
                }
               
                DropDownList ddltypeAss = (DropDownList)gdv.FindControl("ddltype");
                if (ddltypeAss.SelectedIndex > 0)
                {
                    pass.IntLoanType = Convert.ToInt16(ddltypeAss.SelectedItem.Value);

                }
                else
                {
                    pass.IntLoanType = 0;
                }



                TextBox txtwithdateAss = (TextBox)gdv.FindControl("txtwithdate");
                if (txtwithdateAss.Text == "")
                {
                    pass.DtmWithdate  = "";
                }
                else
                {
                    pass.DtmWithdate = txtwithdateAss.Text;
                }

                TextBox txtinstNoAss = (TextBox)gdv.FindControl("txtinstNo");
                if (txtinstNoAss.Text == "")
                {
                    pass.InstNo  = 0;
                }
                else
                {
                    pass.InstNo = int.Parse(txtinstNoAss.Text);
                }


                TextBox txtinstAmtAss = (TextBox)gdv.FindControl("txtinstAmt");
                if (txtinstAmtAss.Text == "")
                {
                    pass.InstAmt  = 0;
                }
                else
                {
                    pass.InstAmt = int.Parse(txtinstAmtAss.Text);
                }
                                
                TextBox txtremAss = (TextBox)gdv.FindControl("txtrem");

                if (txtremAss.Text == "")
                {
                    pass.ChvRem = "";
                }
                else
                {
                    pass.ChvRem  = txtremAss.Text;
                }
                pass.IntUserId = Convert.ToInt32(Convert.ToInt32(Session["intUserId"]));
                pass.FlgFlag = Convert.ToInt32(Session["intFlgApp"]);
                passDAO.SavePassbook(pass);
            }
        }
    }
    private void fillgrid()
    {
        ClearGrid();
        accNo = Convert.ToInt32(Request.QueryString["numEmpId"]);
        intYrId = Convert.ToInt32(Request.QueryString["intYearId"]);
        pass.NumEmpId = accNo;
        pass.IntYearId = intYrId;
        SetGridRow();
        FillGridComb();
           
            DataSet dspass = new DataSet();
            ArrayList ArrIn1 = new ArrayList(0);
            ArrIn1.Add(accNo);
            ArrIn1.Add(intYrId);
            dspass=passDAO.FillPassbook(ArrIn1);
            if (dspass.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dspass.Tables[0].Rows.Count; i++)
                {
                    GridViewRow grdVwRow = gdvInboxTA.Rows[i];

                    TextBox txtdateAss = (TextBox)grdVwRow.FindControl("txtdate");
                    txtdateAss.Text = dspass.Tables[0].Rows[i].ItemArray[3].ToString();

                    DropDownList ddlTreasAss = (DropDownList)grdVwRow.FindControl("ddlTreas");
                    ddlTreasAss.SelectedValue = dspass.Tables[0].Rows[i].ItemArray[4].ToString();

                    TextBox txtchalanNoAss = (TextBox)grdVwRow.FindControl("txtchalanNo");
                    txtchalanNoAss.Text = dspass.Tables[0].Rows[i].ItemArray[5].ToString();

                    TextBox txtchalandateAss = (TextBox)grdVwRow.FindControl("txtchalandate");
                    txtchalandateAss.Text = dspass.Tables[0].Rows[i].ItemArray[6].ToString();

                    TextBox txtsubAss = (TextBox)grdVwRow.FindControl("txtsub");
                    txtsubAss.Text = dspass.Tables[0].Rows[i].ItemArray[7].ToString();

                    TextBox txtrfamtAss = (TextBox)grdVwRow.FindControl("txtrfamt");
                    txtrfamtAss.Text = dspass.Tables[0].Rows[i].ItemArray[8].ToString();

                    TextBox txtarrAmtAss = (TextBox)grdVwRow.FindControl("txtarrAmt");
                    txtarrAmtAss.Text = dspass.Tables[0].Rows[i].ItemArray[9].ToString();


                    DropDownList ddlGOAss = (DropDownList)grdVwRow.FindControl("ddlGO");
                    ddlGOAss.SelectedValue = dspass.Tables[0].Rows[i].ItemArray[10].ToString();

                    TextBox txtGodateAss = (TextBox)grdVwRow.FindControl("txtGodate");
                    txtGodateAss.Text = dspass.Tables[0].Rows[i].ItemArray[11].ToString();

                    TextBox txtwithdrawalAss = (TextBox)grdVwRow.FindControl("txtwithdrawal");
                    txtwithdrawalAss.Text = dspass.Tables[0].Rows[i].ItemArray[12].ToString();

                    DropDownList ddltypeAss = (DropDownList)grdVwRow.FindControl("ddltype");
                    ddltypeAss.SelectedValue = dspass.Tables[0].Rows[i].ItemArray[16].ToString();

                    TextBox txtwithdateAss = (TextBox)grdVwRow.FindControl("txtwithdate");
                    txtwithdateAss.Text = dspass.Tables[0].Rows[i].ItemArray[13].ToString();


                    TextBox txtinstNoAss = (TextBox)grdVwRow.FindControl("txtinstNo");
                    txtinstNoAss.Text = dspass.Tables[0].Rows[i].ItemArray[14].ToString();

                    TextBox txtinstAmtAss = (TextBox)grdVwRow.FindControl("txtinstAmt");
                    txtinstAmtAss.Text = dspass.Tables[0].Rows[i].ItemArray[15].ToString();


                    TextBox txtremAss = (TextBox)grdVwRow.FindControl("txtrem");
                    txtremAss.Text = dspass.Tables[0].Rows[i].ItemArray[17].ToString();
                }
               FindHorTotal();
            }
    }
    private void FindHorTotal()
    {
        Double dblV1;
        Double dblV2;
        Double dblV3;
        Double dblTot;
        double dblMnSn = 0;
        double dblLoanRP = 0;
        double dblArrPF = 0;
        for (int i = 0; i < gdvInboxTA.Rows.Count; i++)
        {
            GridViewRow grdVwRw = gdvInboxTA.Rows[i];
            TextBox txtSubn = (TextBox)grdVwRw.FindControl("txtsub");
            if (txtSubn.Text != "")
            {
                dblV1 = Double.Parse(txtSubn.Text.ToString());
            }
            else
            {
                dblV1 = 0;
            }
            TextBox txtRepay = (TextBox)grdVwRw.FindControl("txtrfamt");
            if (txtRepay.Text != "")
            {
                dblV2 = Double.Parse(txtRepay.Text.ToString());
            }
            else
            {
                dblV2 = 0;
            }
            TextBox txtArrPF = (TextBox)grdVwRw.FindControl("txtarrAmt");
            if (txtArrPF.Text != "")
            {
                dblV3 = Double.Parse(txtArrPF.Text.ToString());
            }
            else
            {
                dblV3 = 0;
            }


            TextBox txtTotal = (TextBox)grdVwRw.FindControl("txttotal");
            dblTot = dblV1 + dblV2 + dblV3 ;
            txtTotal.Text = dblTot.ToString();

            dblMnSn = Convert.ToInt32(dblMnSn) + Convert.ToInt32(dblV1);
            TextBox txtTotMntnSbn = (TextBox)gdvInboxTA.FooterRow.FindControl("txtTotMntnSbn");
            //TextBox txtTotMntnSbn = (TextBox)grdVwRw.FindControl("txtTotMntnSbn");
            txtTotMntnSbn.Text = Convert.ToString(dblMnSn);
            dblLoanRP = Convert.ToInt32(dblLoanRP) + Convert.ToInt32(dblV2);
            TextBox txtTotLoanRp = (TextBox)gdvInboxTA.FooterRow.FindControl("txtTotLoanRp");
            txtTotLoanRp.Text = Convert.ToString(dblLoanRP);
            dblArrPF = Convert.ToInt32(dblArrPF) + Convert.ToInt32(dblV3);
            TextBox txtTotArrPf = (TextBox)gdvInboxTA.FooterRow.FindControl("txtTotArrPf");
            txtTotArrPf.Text = Convert.ToString(dblArrPF);

            TextBox txtTotRem = (TextBox)gdvInboxTA.FooterRow.FindControl("txtTotRem");
            RemTot = Convert.ToInt32(RemTot) + Convert.ToInt32(txtTotal.Text);
            txtTotRem.Text = Convert.ToString(RemTot);
        }
    }
    private Int32 calculatebalMonth(int  Mthid)
    {
        Int32 Mno = 0;
           if(Mthid == 1)
                {
                    Mno= 3;
                }
           if(Mthid == 2)
                {
                    Mno= 2;
                }
           if(Mthid == 3)
                {
                    Mno= 1;
                }
           if(Mthid == 4)
                {
                    Mno= 12;
                }
            if(Mthid == 5)
                {
                    Mno= 11;
                }
             if(Mthid == 6)
                {
                    Mno= 10;
                }
               if(Mthid == 7)
                    {
                        Mno= 9;
                    }
              if(Mthid == 8)
                    {
                        Mno= 8;
                    }
              if(Mthid == 9)
                    {
                        Mno= 7;
                    }
             if(Mthid == 10)
                    {
                        Mno= 6;
                    }
               if(Mthid == 11)
                    {
                        Mno= 5;
                    }
               if(Mthid == 12)
                    {
                        Mno= 4;
                    }
                    return Mno;
    }
    private void ClearGrid()
    {
        fillGridMnth();
    }
    protected void gdvInboxTA_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gdvInboxSec_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
