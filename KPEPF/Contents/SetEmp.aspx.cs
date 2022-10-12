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

public partial class Contents_SetEmp : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO genDao = new GeneralDAO();

    static int intFlg;
    static double NumEmpId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            ViewGrid();
            intFlg = 1;
            FillGdv(2);
            FillGdvSearchDefault();
        }
    }
    private void FillGdvSearchDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("chvLBNameEnglish");
        ar.Add("numEmpId");
        ar.Add("intCurrentPostingLBId");
        gblObj.SetGridDefault(gdvSearch, ar);

            
    }
    private void ViewGrid()
    {
        SetGridDefault();
    }
    private void FillGdv(int flgStat)
    {
        DataSet ds = new DataSet();
        ds = genDao.GetEmpLBWise(Convert.ToInt32(Session["intLBID"]), flgStat); //gblObj.IntInstId
        gdvEmp.DataSource = ds;
        gdvEmp.DataBind();
        SetSlNoEmp(ds);
    }
    private void InsTransferIn()
    {
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            DateTime CurrDet = DateTime.Now.Date;
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            GridViewRow gdvrw = gdvSearch.Rows[i];
            CheckBox chkSel = (CheckBox)gdvrw.FindControl("chkSel");
            TextBox txtOrderNo = (TextBox)gdvrw.FindControl("txtOrdrNo");
            if (chkSel.Checked == true)
            {
                if (intFlg == 1)
                {
                    ds = genDao.GetEmpAccWise(intFlg, NumEmpId, "");
                }
                else
                {
                    ds = genDao.GetEmpAccWise(intFlg, 0, gblObj.StrNameEmp);
                }

                int Empid = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                int FromLBid = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[4]);

                arr.Add(Empid);
                arr.Add(Convert.ToInt32(Session["intUserId"]));
                arr.Add(CurrDet);//curr date
                arr.Add(FromLBid);
                arr.Add(txtOrderNo.Text.ToString());
                genDao.InsTransferIn(arr);
            }
        }
    }
    private void SetSlNoEmp(DataSet ds)
    {
        for (int i = 1; i < gdvEmp.Rows.Count + 1; i++)
        {
            GridViewRow gdvRw = gdvEmp.Rows[i - 1];
            Label lblEmpIdAss = (Label)gdvRw.FindControl("lblEmpId");
            gdvRw.Cells[0].Text = i.ToString();
            lblEmpIdAss.Text = ds.Tables[0].Rows[i - 1].ItemArray[3].ToString();

            CheckBox chk = (CheckBox)gdvRw.FindControl("chkEmp");
            chk.Checked = true;

            Label lblFlgAss = (Label)gdvRw.FindControl("lblFlg");
            lblFlgAss.Text = "1";
        }
    }
    private void SetSlNoLBSearch(DataSet ds1)
    {
          int Att = 10;//Page Size
          for (int i = 0; i < gdvSearch.Rows.Count; i++)
            {
                int p = gdvSearch.PageIndex * Att + i;
                if (p >= Att)
                {
                    p = p;
                }
                else
                {
                    p = i;
                }
        //for (int i = 1; i < gdvSearch.Rows.Count + 1; i++)
        //{
            GridViewRow gdvRw = gdvSearch.Rows[i];
            Label lblEmpIdAss = (Label)gdvRw.FindControl("lblEmpId");
            Label lblLBAss = (Label)gdvRw.FindControl("lblLBId");
            //gdvRw.Cells[0].Text = i.ToString();
            lblEmpIdAss.Text = ds1.Tables[0].Rows[p].ItemArray[0].ToString();
            lblLBAss.Text = ds1.Tables[0].Rows[p].ItemArray[4].ToString();

            //Label lblFlgAss = (Label)gdvRw.FindControl("lblFlg");
            //lblFlgAss.Text = "2";
        }
    }
    protected void optSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtValue.Text = "";
        if (optSearch.Items[0].Selected == true)
        {
            intFlg = 1;
            txtValue.CssClass = "txtNumeric";
            
            txtValue.MaxLength = 5;
        }
        else
        {
            intFlg = 2;
            txtValue.CssClass = "";
            txtValue.MaxLength = 25;
        }
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (txtValue.Text.ToString() != "")
        {
            if (intFlg == 1)
            {
                NumEmpId = Convert.ToDouble(txtValue.Text.ToString());
                FillGdvSearch();
            }
            else
            {
                gblObj.StrNameEmp = txtValue.Text.ToString();
                FillGdvSearch();
            }
        }
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdvSearch.Rows[i];
            CheckBox chkSel = (CheckBox)gdvRw.FindControl("chkSel");
            TextBox txtOrderNo = (TextBox)gdvRw.FindControl("txtOrdrNo");
            txtOrderNo.Enabled = false;
        }

    }
    private void FillGdvSearch()
    {
        //DataSet ds = new DataSet();
        //if (intFlg == 1)
        //{
        //    ds = genDao.GetEmpAccWise(intFlg, NumEmpId, "");
        //}
        //else
        //{
        //    ds = genDao.GetEmpAccWise(intFlg, 0, gblObj.StrNameEmp);
        //}
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) != 77777 && Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) != 88888)
        //    {
        //        if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[12]) != 1)
        //        {
        //            Button1.Visible = true;
        //            gdvSearch.Visible = true;
        //            gdvSearch.DataSource = ds;
        //            gdvSearch.DataBind();
        //            SetSlNoLBSearch(ds);   //lblEmpId2
        //        }
        //        else
        //        {
        //            gblObj.MsgBoxOk("Closed Account!", this);
        //            Button1.Enabled  = false;
        //        }
        //    }
        //    else
        //    {
        //        gblObj.MsgBoxOk("No such employee", this);
        //        Button1.Enabled = false;
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("No such employee", this);
        //    Button1.Enabled = false;
        //}

        DataSet ds = new DataSet();
        if (intFlg == 1)
        {
            ds = genDao.GetEmpAccWiseSetEmp(intFlg, NumEmpId, "");
        }
        else
        {
            ds = genDao.GetEmpAccWiseSetEmp(intFlg, 0, gblObj.StrNameEmp);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {

            Button1.Visible = true;
            gdvSearch.Visible = true;
            gdvSearch.DataSource = ds;
            gdvSearch.DataBind();
            SetSlNoLBSearch(ds);   //lblEmpId2

        }
        else
        {
            gblObj.MsgBoxOk("No such employee / Closed Account !!!", this);
            Button1.Enabled = false;
        }
    }
    private void SetGridDefault()
    {
        ArrayList ar = new ArrayList();
        ar.Add("SlNo");
        ar.Add("chvPF_No");
        ar.Add("chvName");
        ar.Add("chvLBNameEnglish");
        ar.Add("numEmpId");
        ar.Add("intCurrentPostingLBId");
        gblObj.SetGridDefault(gdvSearch, ar);
    }
    protected void btnUpd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvEmp.Rows.Count; i++)
        {
            GridViewRow gdvRw1 = gdvEmp.Rows[i];
            CheckBox chkEmpAss = (CheckBox)gdvRw1.FindControl("chkEmp");
            Label lblEmpId = (Label)gdvRw1.FindControl("lblEmpId");
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Convert.ToInt64(lblEmpId.Text.ToString()));
            ArrIn.Add(Convert.ToInt32(Session["intLBID"]));
            if (chkEmpAss.Checked == true)
            {
                ArrIn.Add(1);
            }
            else
            {
                ArrIn.Add(2);
            }
            genDao.UpdateEmpCurLB(ArrIn);
        }
        genDao.FillLBHistory();
        genDao.DelTempEmp(Convert.ToInt32(Session["intLBID"]));
        FillGdv(2);
        InsTransferIn();
        txtValue.Text = "";
        Button1.Enabled = true;
        btnUpd.Enabled = false;
        MsgBoxOk("Updated");
        FillGdvSearchDefault();
    }
    protected void chkSel_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            GridViewRow gdvRw = gdvSearch.Rows[i];
            CheckBox chkSel = (CheckBox)gdvRw.FindControl("chkSel");
            TextBox txtOrderNo = (TextBox)gdvRw.FindControl("txtOrdrNo");

            if (chkSel.Checked == true)
            {

                txtOrderNo.Enabled = true;

            }
            else
            {
                txtOrderNo.Enabled = false;
                txtOrderNo.Text = "";
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gdvSearch.Rows.Count; i++)
        {
            GridViewRow gdvRw1 = gdvSearch.Rows[i];
            CheckBox chkSelAss = (CheckBox)gdvRw1.FindControl("chkSel");
            TextBox txtOrderNo = (TextBox)gdvRw1.FindControl("txtOrdrNo");
            Label lblEmpIdAss = (Label)gdvRw1.FindControl("lblEmpId");
            Label lblLbIdAss = (Label)gdvRw1.FindControl("lblLbId");
            if (chkSelAss.Checked == true)
            {
                if (txtOrderNo.Text != "")
                {
                    ArrayList ArrIn = new ArrayList();
                    ArrIn.Add(Convert.ToInt32(lblEmpIdAss.Text));
                    ArrIn.Add(gdvSearch.Rows[i].Cells[1].Text.ToString());
                    ArrIn.Add(gdvSearch.Rows[i].Cells[2].Text.ToString());
                    ArrIn.Add(Convert.ToInt16(Session["intLBID"]));
                    genDao.InsTempEmp(ArrIn);
                    FillGdv(1);
                }
                else
                {
                    MsgBoxOk("Enter order no.");
                }
            }
        }
        txtValue.Text = "";
        btnUpd.Enabled = true;
        Button1.Enabled = false;
    }
    protected void Hchk_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow gdvRw2 = gdvEmp.HeaderRow;
        CheckBox chkHdrAss = (CheckBox)gdvRw2.FindControl("Hchk");
        for (int i = 0; i < gdvEmp.Rows.Count; i++)
        {
            GridViewRow gdvRw3 = gdvEmp.Rows[i];
            CheckBox chkEmpAss = (CheckBox)gdvRw3.FindControl("chkEmp");
            if (chkHdrAss.Checked == true)
            {
                chkEmpAss.Checked = true;
            }
            else
            {
                chkEmpAss.Checked = false;
            }
        }

    }

    //protected void gdvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gdvSearch.PageIndex = e.NewPageIndex;
    //    FillGdvSearch();

    //}

    private void MsgBoxOk(string msg)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("alert('");
        sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
        sb.Append("');");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
    }
    protected void gdvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSearch.PageIndex = e.NewPageIndex;
        FillGdvSearch();
    }

    protected void txtValue_TextChanged(object sender, EventArgs e)
    {

    }
}
