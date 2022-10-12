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
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Net;
using System.IO;
using KPEPFClassLibrary;


public partial class Contents_MasterPage : System.Web.UI.MasterPage
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    UserDao usrD = new UserDao();
    KPEPFDAOBase objCommon = new KPEPFDAOBase();
    static int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string currentPageFileName = new FileInfo(this.Request.Url.LocalPath).Name;

        if (!IsPostBack)
        {
            KPEPFDAOBase.ConnectionString = ConfigurationManager.AppSettings["ConString"].ToString();
            ArrayList arrin = new ArrayList();
            ArrayList ars = new ArrayList();
            string str1 = "";
            DataSet ds = new DataSet();
            arrin.Clear();

            ///////////////////////////
            gblObj.SetLBTypesForDirAcctsRev(Convert.ToInt16(Session["flgAcc"]));
            ///////////////////

            arrin.Add(Convert.ToInt16(Session["intUserTypeId"]));     //User Type
            arrin.Add(Convert.ToInt16(Session["intLBTypeId"]));       //LB type 
            //lblUser.Text = Session["UserName"].ToString() + '-' + Session["UserDesig"].ToString();

            ds = gen.GetMasterMenu(arrin);
            str1 = str1 + "<div id='cssmenu'>";
            str1 = str1 + " <ul class='active' > ";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str1 = str1 + " <li class='has-sub' ><a href='" + ds.Tables[0].Rows[i][3].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "' >" + ds.Tables[0].Rows[i][2].ToString() + "</a>";
                arrin.Clear();
                arrin.Add(ds.Tables[0].Rows[i][0]);     //Menu Id
                arrin.Add(Convert.ToInt16(Session["intUserTypeId"]));                           //User Type
                arrin.Add(Convert.ToInt16(Session["intLBTypeId"]));                           //LB type 
                DataSet ds1 = new DataSet();
                ds1 = gen.GetSubMenu(arrin);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    str1 = str1 + "<ul class='has-sub' >";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {

                        //str1 = str1 + "<li  class='has-sub' ><a href='" + ds1.Tables[0].Rows[j][2].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "'> " + ds1.Tables[0].Rows[j][1].ToString() + "</a>";
                        str1 = str1 + "<li  class='has-sub' ><a href='" + ds1.Tables[0].Rows[j][2].ToString() + "?k=" + Convert.ToInt16(ds1.Tables[0].Rows[j][3]) + "&s=" + Convert.ToInt16(ds1.Tables[0].Rows[j][4]) + "&h=" + Convert.ToInt16(ds1.Tables[0].Rows[j][5]) + "' id='hLink" + Convert.ToString(i + 1) + "'> " + ds1.Tables[0].Rows[j][1].ToString() + "</a>";


                        ars.Clear();
                        ars.Add(ds1.Tables[0].Rows[j][0]);     //Menu Id
                        ars.Add(Convert.ToInt16(Session["intUserTypeId"]));                           //User Type
                        ars.Add(Convert.ToInt16(Session["intLBTypeId"]));                             //LB type 
                        DataSet ds2 = new DataSet();
                        ds2 = gen.GetSubMenu(ars);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            str1 = str1 + "<ul class='has-sub' >";
                            for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                            {

                                str1 = str1 + "<li  class='has-sub' ><a href='" + ds2.Tables[0].Rows[k][2].ToString() + "?k=" + Convert.ToInt16(ds2.Tables[0].Rows[k][3]) + "&s=" + Convert.ToInt16(ds2.Tables[0].Rows[k][4]) + "&h=" + Convert.ToInt16(ds2.Tables[0].Rows[k][5]) + "' id='hLink" + Convert.ToString(i + 1) + "'> " + ds2.Tables[0].Rows[k][1].ToString() + "</a>";
                                str1 = str1 + "</li>";
                            }

                            str1 = str1 + "</ul>";
                        }
                        str1 = str1 + "</li>";
                        //k = Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString());
                    }

                    str1 = str1 + "</ul>";
                    str1 = str1 + "</li>";
                }

            }
            str1 = str1 + "</ul>";
            str1 = str1 + "</div>";
            kpepf.InnerHtml = str1;

            /////////////////////////////////////////////////////
            if (Convert.ToInt16(Session["intUserTypeId"]) != 0)
            {
                lblUserType.Text = Session["strUserType"].ToString();
                lblUSerName.Text = Session["strUserName"].ToString();
                lblLB.Text = Session["strLBName"].ToString();

            }
            ////////////////////////////////////////////////////    

        }
        else
        {
            ClearSessions();
        }
    }
    private void ClearSessions()
    {
        //Session["IntYearRem1"] = 0;
    }
    private bool DirTvmUser()
    {
        bool flg = true;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(Convert.ToInt32(Session["intUserId"]));
        ds = usrD.CheckDirTvmUser(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) == 1)
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
    private void ResetGlobals()
    {
        Session["NumServiceTrnID"] = 0;
        Session["intTrnType"] = 0;
        Session["intFlgApp"] = 0;
        Session["intFlgRej"] = 0;
        Session["intFlgAppInbx"] = 0;
        Session["intFlgRejInbx"] = 0;
        gblObj.IntFlgOrg = 0;
        Session["intTrnTypeStage"] = 0;
        gblObj.IntAppFlgInbox = 0;
        gblObj.StrFileNo = "";
        gblObj.FlgChalBill = 0;
        gblObj.FlgFilterMode = 0;
        gblObj.StrChalDt = "";
        gblObj.IntChalNo = 0;
        gblObj.NumChalanID = 0;
        Session["NumEmpId"] = 0;
        gblObj.IntFlgLogin = 10;

        gblObj.IntYearIdAo = 0;
        gblObj.IntMonthIdAo = 0;
        gblObj.IntDistAO = 0;
        gblObj.FlgRemWithAO = 0;
        gblObj.FlgAppRejAo = 0;

        //////////On changing to Session////////////////
        Session["intYearIdApp"] = 0;
        Session["intMonthIdApp"] = 0;
        //////////On changing to Session////////////////

    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
        //{
        //    Page.ClientTarget = "uplevel";
        //}
        if (Request.UserAgent.Contains("AppleWebKit"))
            Request.Browser.Adapters.Clear();
    }
    private void SetSessions()
    {
        Session["intYearIdApp"] = 0;
        Session["intDTreasuryId"] = 0;
        Session["intMonthIdApp"] = 0;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["intUserId"] = "0";
        Session["intUserTypeId"] = "0";
        Session["strUserName"] = "";
        Session["intLBIDComm"] = "0";
        Session["intLBTypeId"] = "0";
        Session["intDistId"] = "0";
        Response.Redirect("Login.aspx");
        
    }
    protected void btnAbout_Click(object sender, EventArgs e)
    {
        Response.Redirect("AboutN.aspx");
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected override void AddedControl(Control control, int index)
    {
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
        {
            this.Page.ClientTarget = "uplevel";
        }
        base.AddedControl(control, index);
    }
}
