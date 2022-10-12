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

public partial class Contents_View : System.Web.UI.Page
{
    GeneralDAO gen = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    static string strname;
    clsGlobalMethods gbl = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["intMenuItem"] = 1;
            InitialSettings();
            if (Convert.ToInt16(Session["intTrnType"]) != 10 && Convert.ToInt16(Session["intTrnType"]) != 11 && Convert.ToInt16(Session["intTrnType"]) != 15)
            {
                if (txtFile.Text.ToString() == "")      //To fill txt nd grid on back to view frm page
                {
                    txtFile.Text = gblObj.StrFileNo;
                }
                FindSerTrnId();
                FillTrnDetails();
            }
        }
    }
    private void InitialSettings()
    {
        lblHead.Text = "View a File";
        //rdView.Visible = true ;
        txtEmpId.Visible = false;
        txtEmpName.Visible = false  ;
        txtFile.Visible = true ;
        btnFind.Visible = true ;
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        //if (rdView.Items[0].Selected == true)
        //{
            FindSerTrnId();
            if (Convert.ToInt64(Session["NumServiceTrnID"]) > 0)
            {
                //if (MatchLB(Convert.ToInt64(Session["NumServiceTrnID"])) == true)
                //{
                    FillTrnDetails();
                //}
                //else
                //{
                //    SetGridDefault();
                //    gblObj.MsgBoxOk("This file belongs to another localbody!", this);
                //}
            }
            else
            {
                SetGridDefault();
                gblObj.MsgBoxOk("No such File exists!", this);
            }
        //}
        //else if (rdView.Items[1].Selected == true)
        //{
        //    gblObj.StrNameEmp = txtFile.Text.ToString();
        //    FillTrnDetailsEmpNameWse();
        //}
    }
    private bool MatchLB(Int64 numTrn)
    {
        bool flg = false;
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(numTrn);
        ds = gen.MatchLB(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() == Convert.ToInt32(Session["intLBID"]).ToString())
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
    private void FindSerTrnId()
    {
        DataSet dsSerTrn = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(txtFile.Text.ToString());
        dsSerTrn = gen.GetServiceTrnIdFromFileNo(ArrIn);

        if (dsSerTrn.Tables[0].Rows.Count > 0)
        {
            Session["NumServiceTrnID"] = Convert.ToInt64(dsSerTrn.Tables[0].Rows[0].ItemArray[0]);
            Session["intTrnType"] = Convert.ToInt16(dsSerTrn.Tables[0].Rows[0].ItemArray[1]);
        }
        else
        {
            Session["NumServiceTrnID"] = 0;
            Session["intTrnType"] = 0;
        }
    }
    private void FillTrnDetails()
    {
        DataSet dsSerTrnDet = new DataSet();
        ArrayList ArrInDet1 = new ArrayList();
        ArrInDet1.Add(Session["NumServiceTrnID"]);
        dsSerTrnDet = gen.GetServiceDetFromExplicitTbls(Convert.ToInt16(Session["intTrnType"]), ArrInDet1);
        if (dsSerTrnDet.Tables[0].Rows.Count > 0)
        {
            gdvFile.DataSource = dsSerTrnDet;
            gdvFile.DataBind();
        }
        else
        {
            SetGridDefault();
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("intTrnTypeID");
        ar.Add("numTrnID");
        ar.Add("flgApproval");
        ar.Add("numEmpId");

        ar.Add("chvTrnType");
        ar.Add("AccNo");
        ar.Add("chvName");
        ar.Add("chvStatus");
        gblObj.SetGridDefault(gdvFile, ar);
    }
    private void FillTrnDetailsEmpNameWse()
    {
        DataSet dsSerTrnDetEmp = new DataSet();
        //dsSerTrnDetEmp = gen.GetServiceDetFromExplicitTblsEmpNameWse(Convert.ToInt16(Session["intTrnType"]), gblObj.StrNameEmp);
        dsSerTrnDetEmp = gen.GetServiceDetFromExplicitTblsEmpNameWse(5, gblObj.StrNameEmp);
        if (dsSerTrnDetEmp.Tables[0].Rows.Count > 0)
        {
            gdvFile.DataSource = dsSerTrnDetEmp;
            gdvFile.DataBind();
        }
        else
        {
            SetGridDefault();
        }
    }
    //protected void rdView_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtFile.Text = "";
    //    SetGridDefault();
    //    //if (rdView.Items[0].Selected == true)
    //    //{
    //    //    txtFile.Visible = true;
    //    //}
    //    //else if (rdView.Items[1].Selected == true)
    //    //{
    //    //    txtFile.Visible = true;
    //    //}
    //}
    //protected void rdPrint_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //private void FindSerTrnIdForSanOrder1()
    //{
    //    DataSet dsSerTrn = new DataSet();
    //    ArrayList ArrIn = new ArrayList();
    //    ArrIn.Add(txtEmpId.Text.ToString());
    //    dsSerTrn = gen.GetServiceTrnIdFromFileNo(ArrIn);

    //    if (dsSerTrn.Tables[0].Rows.Count > 0)
    //    {
    //        Convert.ToInt16(Session["intTrnType"]) = Convert.ToInt16(dsSerTrn.Tables[0].Rows[0].ItemArray[1]);
    //        if (Convert.ToInt16(Session["intTrnType"]) == 2 || Convert.ToInt16(Session["intTrnType"]) == 3 || Convert.ToInt16(Session["intTrnType"]) == 31 || Convert.ToInt16(Session["intTrnType"]) == 4 || Convert.ToInt16(Session["intTrnType"]) == 41)
    //        {
    //            Session["NumServiceTrnID"] = Convert.ToInt64(dsSerTrn.Tables[0].Rows[0].ItemArray[0]);
    //            gblObj.IntFlgOrg = Convert.ToInt16(dsSerTrn.Tables[0].Rows[0].ItemArray[2]);
    //            //if (gblObj.IntFlgOrg == 10 || gblObj.IntFlgOrg == 15 || gblObj.IntFlgOrg == 20)
    //            //{

    //            //}
    //            //else
    //            //{
    //            //    gblObj.MsgBoxOk("This file is not processed for Sanction Order!",this);
    //            //}
    //        }
    //        else
    //        {
    //            Session["NumServiceTrnID"] = 0;
    //            gblObj.MsgBoxOk("This file doesn't relate to a Loan!",this );
    //        }
    //    }
    //    else
    //    {
    //        Session["NumServiceTrnID"] = 0;
    //        Convert.ToInt16(Session["intTrnType"]) = 0;
    //        gblObj.MsgBoxOk("No such file exists!",this );
    //    }
    //}
    //private void FindSerTrnIdForSanOrder2()
    //{
    //    DataSet dsSerTrn2 = new DataSet();
    //    ArrayList ArrIn2 = new ArrayList();
    //    ArrIn2.Add(txtEmpId.Text.ToString());
    //    dsSerTrn2 = gen.GetServiceTrnIdFromFileNo2(ArrIn2);

    //    if (dsSerTrn2.Tables[0].Rows.Count > 0)
    //    {
    //        Session["NumServiceTrnID"] = Convert.ToInt64(dsSerTrn2.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    else
    //    {
    //        Session["NumServiceTrnID"] = 0;
    //        gblObj.MsgBoxOk("No such order exists!", this);
    //    }
    //}
    //private Boolean ValidateFlagOrg()
    //{
    //    Boolean flg = true;
    //    if (Convert.ToInt16(Session["intTrnType"]) == 2)
    //    {
    //        if (gblObj.IntFlgOrg == 10 || gblObj.IntFlgOrg == 15 || gblObj.IntFlgOrg == 20)
    //        {
    //            flg = true;
    //        }
    //        else
    //        {
    //            flg = false;
    //        }
    //    }
    //    if (Convert.ToInt16(Session["intTrnType"]) == 3)
    //    {
    //        if (gblObj.IntFlgOrg == 10 || gblObj.IntFlgOrg == 15 || gblObj.IntFlgOrg == 20)
    //        {
    //            flg = true;
    //        }
    //        else
    //        {
    //            flg = false;
    //        }
    //    }
    //    if (Convert.ToInt16(Session["intTrnType"]) == 31)
    //    {

    //    }
    //    if (Convert.ToInt16(Session["intTrnType"]) == 4)
    //    {

    //    }
    //    if (Convert.ToInt16(Session["intTrnType"]) == 41)
    //    {

    //    }
    //    return flg;
    //}
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt16(Session["intTrnType"]) == 10)
    //    {
    //        //if (rdPrint.Items[0].Selected == true)
    //        //{
    //        //    FindSerTrnIdForSanOrder1();
    //        //    if (ValidateFlagOrg() == true)
    //        //    {
    //        //        Response.Redirect("Reportviewer.aspx?ReportID=1");
    //        //    }
    //        //    else
    //        //    {
    //        //        gblObj.MsgBoxOk("This file is not processed for Sanction Order!", this);
    //        //        FillTrnDetails();
    //        //    }
    //        //}
    //        //else if (rdPrint.Items[1].Selected == true)
    //        //{
    //            FindSerTrnIdForSanOrder2();
    //            Response.Redirect("Reportviewer.aspx?ReportID=1");
    //        //}
    //    }
    //    else if (Convert.ToInt16(Session["intTrnType"]) == 11)
    //    {
    //        //if (rdPrint.Items[0].Selected == true)
    //        //{
    //        //    FindSerTrnIdForSanOrder1();
    //        //    if (ValidateFlagOrg() == true)
    //        //    {
    //        //        Response.Redirect("Reportviewer.aspx?ReportID=2");
    //        //    }
    //        //    else
    //        //    {
    //        //        gblObj.MsgBoxOk("This file is not processed for Bill generation!", this);
    //        //        FillTrnDetails();
    //        //    }
    //        //}
    //        //else if (rdPrint.Items[1].Selected == true)
    //        //{
    //            FindSerTrnIdForBill();
    //            Response.Redirect("Reportviewer.aspx?ReportID=2");
    //        //}
    //    }
    //    else if (Convert.ToInt16(Session["intTrnType"]) == 15)
    //    {
    //        //if (rdPrint.Items[0].Selected == true)
    //        //{
    //        //    FindSerTrnIdForSanOrder1();
    //        //    if (ValidateFlagOrg() == true)
    //        //    {
    //        //        Response.Redirect("Reportviewer.aspx?ReportID=2");
    //        //    }
    //        //    else
    //        //    {
    //        //        gblObj.MsgBoxOk("This file is not processed for Bill generation!", this);
    //        //        FillTrnDetails();
    //        //    }
    //        //}
    //        //else if (rdPrint.Items[1].Selected == true)
    //        //{
    //        FindSerTrnIdForChalan();
    //        Response.Redirect("Reportviewer.aspx?ReportID=2");
    //        //}
    //    }
    //}
    //private void FindSerTrnIdForChalan()
    //{
    //    DataSet dsChal = new DataSet();
    //    ArrayList ArrInC = new ArrayList();
    //    ArrInC.Add(txtEmpId.Text.ToString());
    //    dsChal = gen.GetBillIdFromBill(ArrInC);

    //    if (dsChal.Tables[0].Rows.Count > 0)
    //    {
    //        gblObj.NumChalanID = Convert.ToInt64(dsChal.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    else
    //    {
    //        gblObj.NumBillID = 0;
    //        gblObj.MsgBoxOk("No such Bill exists!", this);
    //    }
    //}
    //private void FindSerTrnIdForBill()
    //{
    //    DataSet dsbill = new DataSet();
    //    ArrayList ArrInb = new ArrayList();
    //    ArrInb.Add(txtEmpId.Text.ToString());
    //    dsbill = gen.GetBillIdFromBill(ArrInb);

    //    if (dsbill.Tables[0].Rows.Count > 0)
    //    {
    //        gblObj.NumBillID = Convert.ToInt64(dsbill.Tables[0].Rows[0].ItemArray[0]);
    //    }
    //    else
    //    {
    //        gblObj.NumBillID = 0;
    //        gblObj.MsgBoxOk("No such Bill exists!", this);
    //    }
    //}
}
