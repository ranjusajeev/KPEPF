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

public partial class Contents_ABCD : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    KPEPFGeneralDAO GenDao = new KPEPFGeneralDAO();
    ABCD abcd=new ABCD ();
    ABCDDao abDAO = new ABCDDao();
    GeneralDAO gen = new GeneralDAO();
    Passbook pass = new Passbook();
    passbookDAO passDAO = new passbookDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            ds = abDAO.GetYear();
            gblObj.FillCombo(ddlyear, ds, 1);

            gblObj.SetInitialRow(gdvArrear);
            FillGridComb();
        }
       

    }
    private void FillGridComb()
    {
        for (int i = 0; i < gdvArrear.Rows.Count; i++)
        {
           GridViewRow grdVwRow = gdvArrear.Rows[i];

           DropDownList ddlGOAss = (DropDownList)grdVwRow.FindControl("ddlGO");
            DataSet dsGo = new DataSet();
            dsGo = GenDao.GetGO();
            gblObj.FillCombo(ddlGOAss, dsGo, 1);

            DropDownList ddlMnthass = (DropDownList)grdVwRow.FindControl("ddlmonth");
            DataSet dsmnth = new DataSet();
            dsmnth = abDAO.GetMonth();
            gblObj.FillCombo(ddlMnthass, dsmnth, 1);

        }

       

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveABCD();
        SaveABCDFormD();
    }
    private void SaveABCDFormD()
    {
        for (int i = 0; i <= gdvArrear.Rows.Count - 1; i++)
        {
            GridViewRow gdv = gdvArrear.Rows[i];
            DropDownList ddlmn = (DropDownList)gdv.FindControl("ddlmonth");
            if (ddlmn.SelectedIndex > 0)
            {
                abcd.IntMonthId = Convert.ToInt16(ddlmn.SelectedItem.Value);
            }
            else
            {
                abcd.IntMonthId = 0;
            }
            DropDownList ddlGOAss = (DropDownList)gdv.FindControl("ddlGO");
            if (ddlGOAss.SelectedIndex > 0)
            {
                abcd.ChvGO = ddlGOAss.SelectedValue;
            }
            else
            {
                abcd.ChvGO = "";
            }
            TextBox txtGodateAss = (TextBox)gdv.FindControl("txtGodate");

            if (txtGodateAss.Text == "")
            {
                abcd.DtmGODate = "";
            }
            else
            {
                abcd.DtmGODate = txtGodateAss.Text;
            }

            TextBox txtarrAmtAss = (TextBox)gdv.FindControl("txtarrAmt");

            if (txtarrAmtAss.Text == "")
            {
                abcd.IntArrearDA = 0;
            }
            else
            {
                abcd.IntArrearDA = double.Parse(txtarrAmtAss.Text);
            }
            abDAO.SaveABCDArrear(abcd);
        }
    
    }
    private void SaveABCD()
    {
        if (Convert.ToInt32(txtaccno.Text) > 0 && ddlyear.SelectedValue != "")
        {
            //for (int i = 0; i <= gdvArrear.Rows.Count - 1; i++)
            //{
                //GridViewRow gdv = gdvArrear.Rows[i];
                abcd.IntaccNo  = Convert.ToInt32(txtaccno.Text);
                abcd.IntYearId = Convert.ToInt16(ddlyear.SelectedItem.Value);

                //DropDownList ddlmn = (DropDownList)gdv.FindControl("ddlmonth");
                //if (ddlmn.SelectedIndex > 0)
                //{
                //   abcd.IntMonthId = Convert.ToInt16(ddlmn.SelectedItem.Value);
                //}
                //else
                //{
                //    abcd.IntMonthId = 0;
                //}


                if (txtttlCR.Text == "")
                {
                    abcd.TotalCr  = 0;
                }
                else
                {
                    abcd.TotalCr = double.Parse(txtttlCR.Text);
                }

                if (txtttlAB.Text == "")
                {
                    abcd.TotlAB  = 0;
                }
                else
                {
                    abcd.TotlAB = double.Parse(txtttlAB.Text);
                }
                if (txtttl12.Text == "")
                {
                    abcd.grndTotal12  = 0;
                }
                else
                {
                    abcd.grndTotal12 = double.Parse(txtttl12.Text);
                }
                if (txtttlwith.Text == "")
                {
                    abcd.totalWith  = 0;
                }
                else
                {
                    abcd.totalWith = double.Parse(txtttlwith.Text);
                }
                if (txtArDAttl.Text == "")
                {
                    abcd.arrearDA  = 0;
                }
                else
                {
                    abcd.arrearDA = double.Parse(txtArDAttl.Text);
                }
                if (txtnetBal.Text == "")
                {
                    abcd.NetBalance  = 0;
                }
                else
                {
                    abcd.NetBalance = double.Parse(txtnetBal.Text);
                }
                if (txtgrndttl.Text == "")
                {
                    abcd.grndTotal45  = 0;
                }
                else
                {
                    abcd.grndTotal45 = double.Parse(txtgrndttl.Text);
                }

                //DropDownList ddlGOAss = (DropDownList)gdv.FindControl("ddlGO");
                //if (ddlGOAss.SelectedIndex > 0)
                //{
                //    abcd.ChvGO  = ddlGOAss.SelectedValue;
                //}
                //else
                //{
                //    abcd.ChvGO = "";
                //}
                //TextBox txtGodateAss = (TextBox)gdv.FindControl("txtGodate");

                //if (txtGodateAss.Text == "")
                //{
                //    abcd.DtmGODate  = "";
                //}
                //else
                //{
                //    abcd.DtmGODate = txtGodateAss.Text;
                //}
                abDAO.SaveABCD(abcd);
            //}
        }
    }
    protected void txtaccno_TextChanged(object sender, EventArgs e)
    {
        Session["NumEmpId"] = Convert.ToDouble(txtaccno.Text.ToString());
              ArrayList arr = new ArrayList();
              pass.NumEmpId = Convert.ToInt64(Session["NumEmpId"]);
              //Session["NumEmpId"] = pass.NumEmpId;
              DataSet ds = new DataSet();

              ds = passDAO.GetEmployeeDetails(pass);
              if (ds.Tables[0].Rows.Count > 0)
              {
                  lblAcc.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
              }
         
          else
          {
              gblObj.MsgBoxOk("Not beleongs to this Localbody!", this);
              txtaccno.Text = "";
          }
          FillDetails();
          FillArrearDetails();
      }
      private void FillArrearDetails()
      {
          DataTable dtArrear = gblObj.SetInitialRow(gdvArrear);
          ViewState["ar"] = dtArrear;
          FillGridComb();
          DataSet ds = new DataSet();
          ArrayList arr = new ArrayList ();
          arr.Add(Session["NumEmpId"]);
          arr.Add(Convert.ToInt16(ddlyear.SelectedItem.Value));
          ds = abDAO.GetABCDArrearDet(arr);
          if (ds.Tables[0].Rows.Count > 0)
          {
              gdvArrear.DataSource = ds;
              gdvArrear.DataBind();

              dtArrear = gblObj.SetGridTableRows(gdvArrear, ds.Tables[0].Rows.Count);
              ViewState["ar"] = dtArrear;
              FillGridComb();

              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  GridViewRow gvr = gdvArrear.Rows[i];
                  DropDownList ddlmonth = (DropDownList)gvr.FindControl("ddlmonth");
                  ddlmonth.SelectedValue = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                  DropDownList ddlGO = (DropDownList)gvr.FindControl("ddlGO");
                  ddlGO.SelectedValue = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                  TextBox txtGodate = (TextBox)gvr.FindControl("txtGodate");
                  txtGodate.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                  TextBox txtarrAmt = (TextBox)gvr.FindControl("txtarrAmt");
                  txtarrAmt.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
              }
          }

      }
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Session["NumEmpId"]);
        arr.Add(Convert.ToInt16(ddlyear.SelectedItem.Value));
        ds = abDAO.GetABCDDet(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtttlCR.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtttlAB.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtttl12.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtttlwith.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtArDAttl.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            txtgrndttl.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            txtnetBal.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gdvInboxTA_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtttlCR_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        if( txtaccno.Text != "")
        {
        Session["NumEmpId"] = Convert.ToInt32(txtaccno.Text);
        gblObj.IntYear = Convert.ToInt16(ddlyear.SelectedItem.Value);
        Response.Redirect("Reportviewer.aspx?ReportID=6");
        }
    }
    protected void txtarrAmt_TextChanged(object sender, EventArgs e)
    {
        FindHorTotal();
    }
    private void FindHorTotal()
    {
        Double dblV1 = 0 ;
        for (int i = 0; i < gdvArrear.Rows.Count; i++)
        {
            GridViewRow grdVwRw = gdvArrear.Rows[i];
            TextBox txtarrAmtAss = (TextBox)grdVwRw.FindControl("txtarrAmt");
            if (txtarrAmtAss.Text != "")
            {
                dblV1 = dblV1 + Double.Parse(txtarrAmtAss.Text.ToString());
            }
            else
            {
                dblV1 = dblV1;
            }

            TextBox txtTotArrPfAss = (TextBox)gdvArrear.FooterRow.FindControl("txtTotArrPf");
            txtTotArrPfAss.Text = dblV1.ToString();
            txtArDAttl.Text = txtTotArrPfAss.Text;
        }

    }
    protected void gdvArrear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["ar"] != null)
        {
            DataTable dt = (DataTable)ViewState["ar"];
            int count = gdvArrear.Rows.Count;
            ArrayList arrIN = new ArrayList();
            arrIN.Add("ddlmonth");
            arrIN.Add("ddlGO");
            arrIN.Add("txtGodate");
            arrIN.Add("txtarrAmt");
            arrIN.Add("Button1");
            dt = gblObj.AddNewRowToGrid(dt, gdvArrear, arrIN);
            ViewState["SpecTable"] = dt;
            FillGridComb();
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                DropDownList drmnth = (DropDownList)gdvArrear.Rows[i].FindControl("ddlmonth");
                drmnth.SelectedValue = dt.Rows[i].ItemArray[1].ToString();

                DropDownList drgO = (DropDownList)gdvArrear.Rows[i].FindControl("ddlGO");
                drgO.SelectedValue = dt.Rows[i].ItemArray[2].ToString();

            }

        }

    }
}
