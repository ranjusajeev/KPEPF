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
using System.Data.Sql;
using System.Data.SqlClient;
using KPEPFClassLibrary;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Security.Cryptography;


public partial class Contents_Login : System.Web.UI.Page
{
    static int cntHit = 0;
    GeneralDAO genDao = new GeneralDAO();
    clsGlobalMethods gblObj = new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void LocalSettings()
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(Convert.ToInt32(Convert.ToInt32(Session["intLBID"])));
        ds = genDao.GetLocalSettings(ArrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[1].ToString() != null)
            {
                Session["Spark"] = Convert.ToBoolean(ds.Tables[0].Rows[0].ItemArray[1].ToString());
            }
            else
            {
                Session["Spark"] = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() != null)
            {
                Session["File"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            }
            else
            {
                Session["File"] = "...";
            }
        }
        else
        {
            Session["File"] = "...";
            Session["Spark"] = true;
        }
    }


    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    Session["flgAcc"] = 0;
    //    String data;
    //    LoginReference.Service objService = new LoginReference.Service();
    //    string webUrlString = ConfigurationManager.AppSettings["LoginReference.Service"].ToString();
    //    string Password = txtPwd.Text.ToString();
    //    objService.Url = webUrlString;

    //    data = objService.CheckUserLogin(txtUser.Text.ToString(), Password, "106", "2");
    //    if (data != "")
    //    {
    //        DataSet ds = new DataSet();
    //        StringReader theReader = new StringReader(data);
    //        ds.ReadXml(theReader);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) == 1)
    //            {
    //                Session["intUserId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[2]);
    //                Session["intUserTypeId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[17]);
    //                Session["strUserName"] = ds.Tables[0].Rows[0].ItemArray[8].ToString();
    //                Session["intLBIDComm"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[3]);
    //                Session["intLBTypeId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[4]);
    //                Session["intDistId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[23]);
    //                AssignUserTypeForOtherLBs(Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[10]));     // Assign UserTypeId and LBTypeId
    //                MatchLB();      // Find LBId from KPEPF DB (for those in Sulekha DB) to save in local tables.......
    //                //if ((Convert.ToInt16(Session["intLBTypeId"]) == 3 || Convert.ToInt16(Session["intLBTypeId"]) == 4) && Convert.ToInt32(Session["munGrpId"]) > 0)

    //                if ((Convert.ToInt16(Session["intLBTypeId"]) == 3 || Convert.ToInt16(Session["intLBTypeId"]) == 4) && Convert.ToInt32(Session["munGrpId"]) > 0)
    //                {
    //                    AssignLoginToMunStaff();   // To get login provision for converted Municipalities (From Gps)
    //                }

    //                //dsOth = genDao.GetLBFromId(Convert.ToInt16(Session["intLBIDComm"]));

    //                //Session["intTreasuryID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[4]);
    //                //Session["intDTreasuryID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[6]);
    //                Session["intCntEmp"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[12]);
    //                Session["strUserType"] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
    //                //Session["strTreasury"] = dsOth.Tables[0].Rows[0].ItemArray[5];
    //                Session["File"] = "D";
    //                //Session["intDistId"] = Convert.ToInt16(dsOth.Tables[0].Rows[0].ItemArray[3]);
    //                Session["strUser"] = ds.Tables[0].Rows[0].ItemArray[21].ToString();
    //                Session["intDistDirUser"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[15]);
    //                Session["intFlgLogin"] = 1;// Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8]);

    //                //Session["intLBID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[3]);

    //                //***********Session For Withdrawal*****************
    //                Session["IntYearIdWit"] = 0;
    //                Session["IntMonthIdWit"] = 0;
    //                Session["IntTreIdWit"] = 0;
    //                Session["IntDistWit"] = 0;
    //                //***********Session For Withdrawal*****************

    //                //***********Session For Remittance*****************
    //                Session["IntYearIdRemi"] = 0;
    //                Session["IntMonthIdRemi"] = 0;
    //                Session["IntTreIdRemi"] = 0;
    //                Session["IntDistRemi"] = 0;
    //                Session["intDistId"] = 0;
    //                //gblObj.IntYear = 0;
    //                //gblObj.IntMonth = 0;


    //                Session["intYearIdRem01"] = 0;
    //                Session["intMonthIdRem01"] = 0;
    //                Session["intDistIdRem01"] = 0;
    //                //***********Session For Remittance*****************

    //                //***********Session For TA*****************
    //                Session["IntInward"] = 0;
    //                Session["CharDate"] = 0;
    //                Session["flgSevice"] = 0;
    //                Session[""] = 0;
    //                //gblObj.StrFileNo = "";
    //                //***********Session For TA*****************

    //                //***********Session For TA*****************
    //                Session["intYearIdApp"] = 0;
    //                Session["intMonthIdApp"] = 0;
    //                //***********Session For TA*****************


    //                //***********Session AG *****************
    //                Session["intYearGCurr"] = 0;
    //                Session["intMonthAGCurr"] = 0;
    //                Session["flgPageBackFrmAG"] = 0;

    //                Session["IntYearAG"] = 0;
    //                Session["IntMonthAG"] = 0;
    //                Session["flgPageBackFrmTE"] = 0;
    //                Session["numChalanIdEdit"] = 0;

    //                Session["dblAmtCrPlus"] = 0;
    //                Session["dblAmtDtPlus"] = 0;
    //                Session["dblAmtCrMinus"] = 0;
    //                Session["dblAmtDtMinus"] = 0;

    //                Session["dblAmtDaerPlus"] = 0;
    //                Session["dblAmtDaerMns"] = 0;
    //                Session["numChalanIdEdit"] = 0;

    //                //***********Session G Curr*****************

    //                //***********Session Card generate*****************
    //                Session["intAccNo"] = 0;
    //                Session["intCnt"] = 0;
    //                //***********Session Card generate*****************

    //                //***********Session Ann statement***************** 
    //                Session["NumEmpIdAnnStmnt"] = 0;
    //                Session["intYearAnnStmnt"] = 0;
    //                //***********Session Ann statement*****************

    //                //***********Session Approval by AO*****************
    //                //Session["intDTreasuryId"] = 0;
    //                //***********Session Approval by AO*****************

    //                //***********Session Search*****************
    //                Session["flgFilterMode"] = 0;
    //                //***********Session Search*****************

    //                //***********Session Rem01*****************
    //                Session["numChalanIdEdit"] = 0;
    //                Session["NumChalanID"] = 0;
    //                Session["intSTreasDetId"] = 0;
    //                //***********Session Rem01*****************

    //                //***********Session Service Trn*****************
    //                Session["NumServiceTrnID"] = 0;
    //                Session["intMenuItem"] = 0;
    //                //***********Session Service Trn*****************
    //                Session["flgPageBackW"] = 0;
    //                cntHit = 0;

    //                //Response.Redirect("MainPage.aspx");
    //            }
    //            else
    //            {
    //                Session["flgLogin"] = 0;
    //                gblObj.MsgBoxOk("Invalid User/Password", this);
    //            }
    //        }
    //        else
    //        {
    //            Session["flgLogin"] = 0;
    //            gblObj.MsgBoxOk("Invalid User/Password", this);
    //        }
    //        if (Convert.ToInt16(Session["flgLogin"]) == 1 || Convert.ToInt16(Session["flgLogin"]) == 3)
    //        {
    //            Response.Redirect("MainPage.aspx");
    //        }
    //        else
    //        {
    //            gblObj.MsgBoxOk("Invalid User/Password", this);
    //        }
    //    }
    //    cntHit = cntHit + 1;

    //}  



    protected void btnLogin_Click(object sender, EventArgs e)
    {
        cntHit = cntHit + 1;
        DataSet ds = new DataSet();
        ds = genDao.CheckLogin(txtUser.Text.Trim(), txtPwd.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["intUserId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            Session["intUserTypeId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);
            Session["strUserName"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            Session["intLBID"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[3]);
            Session["intLBTypeId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[4]);
            Session["strLBName"] = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            Session["intTreasuryID"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[5]);
            Session["intDTreasuryID"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[6]);
            Session["intCntEmp"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[12]);
            Session["strUserType"] = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            Session["strTreasury"] = ds.Tables[0].Rows[0].ItemArray[14];
            Session["File"] = "D";
            Session["intDistId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[13]);
            Session["strUser"] = ds.Tables[0].Rows[0].ItemArray[9];
            Session["intDistDirUser"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[15]);
            Session["intFlgLogin"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8]);
            AssignUserTypeForOtherLBs(Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1]));     // Assign Dir Users
            if (Convert.ToInt16(Session["intLBTypeId"]) == 3)
            {
                AssignLoginToMunStaff();
            }

            //***********Session For Withdrawal*****************
            Session["IntYearIdWit"] = 0;
            Session["IntMonthIdWit"] = 0;
            Session["IntTreIdWit"] = 0;
            Session["IntDistWit"] = 0;
            //***********Session For Withdrawal*****************

            //***********Session For Remittance*****************
            Session["IntYearIdRemi"] = 0;
            Session["IntMonthIdRemi"] = 0;
            Session["IntTreIdRemi"] = 0;
            Session["IntDistRemi"] = 0;
            Session["intDistId"] = 0;

            Session["IntYearRem1"] = 0;
            Session["IntMonthRem1"] = 0;
            Session["IntDistRem1"] = 0;
            Session["IntDTRem1"] = 0;

            Session["intYearIdRem01"] = 0;
            Session["intMonthIdRem01"] = 0;
            Session["intDistIdRem01"] = 0;
            //***********Session For Remittance*****************

            //***********Session For TA*****************
            Session["IntInward"] = 0;
            Session["CharDate"] = 0;
            Session["flgSevice"] = 0;
            Session[""] = 0;
            //***********Session For TA*****************

            //***********Session For TA*****************
            Session["intYearIdApp"] = 0;
            Session["intMonthIdApp"] = 0;
            //***********Session For TA*****************


            //***********Session AG Curr*****************
            Session["intYearGCurr"] = 0;
            Session["intMonthAGCurr"] = 0;

            Session["flgPageBackFrmAG"] = 0;
            Session["dblAmtDaerPlus"] = 0;
            Session["dblAmtDaerMns"] = 0;
            Session["numChalanIdEdit"] = 0;
            //***********Session G Curr*****************

            //***********Session Card generate*****************
            Session["intAccNo"] = 0;
            Session["intCnt"] = 0;
            //***********Session Card generate*****************

            //***********Session Ann statement*****************
            Session["NumEmpIdAnnStmnt"] = 0;
            Session["intYearAnnStmnt"] = 0;
            //***********Session Ann statement*****************

            //***********Session Search*****************
            Session["flgFilterMode"] = 0;
            //***********Session Search*****************


            //***********Session Service Trn*****************
            Session["NumServiceTrnID"] = 0;
            Session["intMenuItem"] = 0;
            Session["numChalanIdEdit"] = 0;
            //***********Session Service Trn*****************

            Session["NumChalanID"] = 0;
            Session["intSTreasDetId"] = 0;
            Session["flgPageBackW"] = 0;

            cntHit = 0;
            if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8]) == 0)
            {
                Session["intTrnType"] = 101;
                Response.Redirect("ChangePwd.aspx");
            }
            else
            {
                Response.Redirect("MainPage.aspx");
            }
        }
        else
        {
            gblObj.MsgBoxOk("Invalid User/Password", this);
        }
    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    Session["flgAcc"] = 0;
    //    String data;
    //    LoginReference.Service objService = new LoginReference.Service();
    //    string webUrlString = ConfigurationManager.AppSettings["LoginReference.Service"].ToString();
    //    string Password = txtPwd.Text.ToString();
    //    objService.Url = webUrlString;

    //    data = objService.CheckUserLogin(txtUser.Text.ToString(), Password, "106", "2");
    //    if (data != "")
    //    {
    //        DataSet ds = new DataSet();
    //        StringReader theReader = new StringReader(data);
    //        ds.ReadXml(theReader);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]) == 1)
    //            {
    //                Session["intUserId"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[2]);
    //                Session["intUserTypeId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[17]);
    //                Session["strUserName"] = ds.Tables[0].Rows[0].ItemArray[8].ToString();
    //                Session["intLBIDComm"] = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[3]);
    //                Session["intLBTypeId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[4]);
    //                Session["intDistId"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[23]);
    //                AssignUserTypeForOtherLBs(Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[10]));     // Assign UserTypeId and LBTypeId
    //                MatchLB();      // Find LBId from KPEPF DB (for those in Sulekha DB) to save in local tables.......
    //                if ((Convert.ToInt16(Session["intLBTypeId"]) == 3 || Convert.ToInt16(Session["intLBTypeId"]) == 4) && Convert.ToInt32(Session["munGrpId"]) > 0)

    //                if ((Convert.ToInt16(Session["intLBTypeId"]) == 3 || Convert.ToInt16(Session["intLBTypeId"]) == 4) && Convert.ToInt32(Session["munGrpId"]) > 0)
    //                {
    //                    AssignLoginToMunStaff();   // To get login provision for converted Municipalities (From Gps)
    //                }

    //              //  dsOth = genDao.GetLBFromId(Convert.ToInt16(Session["intLBIDComm"]));

    //              //  Session["intTreasuryID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[4]);
    //              //  Session["intDTreasuryID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[6]);
    //                Session["intCntEmp"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[12]);
    //                Session["strUserType"] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
    //              //  Session["strTreasury"] = dsOth.Tables[0].Rows[0].ItemArray[5];
    //                Session["File"] = "D";
    //               // Session["intDistId"] = Convert.ToInt16(dsOth.Tables[0].Rows[0].ItemArray[3]);
    //                Session["strUser"] = ds.Tables[0].Rows[0].ItemArray[21].ToString();
    //                Session["intDistDirUser"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[15]);
    //                Session["intFlgLogin"] = 1;// Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[8]);

    //            //    Session["intLBID"] = Convert.ToInt32(dsOth.Tables[0].Rows[0].ItemArray[3]);

    //            //    ***********Session For Withdrawal*****************
    //                Session["IntYearIdWit"] = 0;
    //                Session["IntMonthIdWit"] = 0;
    //                Session["IntTreIdWit"] = 0;
    //                Session["IntDistWit"] = 0;
    //             //   ***********Session For Withdrawal*****************

    //              //  ***********Session For Remittance*****************
    //                Session["IntYearIdRemi"] = 0;
    //                Session["IntMonthIdRemi"] = 0;
    //                Session["IntTreIdRemi"] = 0;
    //                Session["IntDistRemi"] = 0;
    //                Session["intDistId"] = 0;
    //                gblObj.IntYear = 0;
    //                gblObj.IntMonth = 0;


    //                Session["intYearIdRem01"] = 0;
    //                Session["intMonthIdRem01"] = 0;
    //                Session["intDistIdRem01"] = 0;
    //             //   ***********Session For Remittance*****************

    //              //  ***********Session For TA*****************
    //                Session["IntInward"] = 0;
    //                Session["CharDate"] = 0;
    //                Session["flgSevice"] = 0;
    //                Session[""] = 0;
    //                gblObj.StrFileNo = "";
    //              //  ***********Session For TA*****************

    //            //    ***********Session For TA*****************
    //                Session["intYearIdApp"] = 0;
    //                Session["intMonthIdApp"] = 0;
    //            //    ***********Session For TA*****************


    //             //   ***********Session AG *****************
    //                Session["intYearGCurr"] = 0;
    //                Session["intMonthAGCurr"] = 0;
    //                Session["flgPageBackFrmAG"] = 0;

    //                Session["IntYearAG"] = 0;
    //                Session["IntMonthAG"] = 0;
    //                Session["flgPageBackFrmTE"] = 0;
    //                Session["numChalanIdEdit"] = 0;

    //                Session["dblAmtCrPlus"] = 0;
    //                Session["dblAmtDtPlus"] = 0;
    //                Session["dblAmtCrMinus"] = 0;
    //                Session["dblAmtDtMinus"] = 0;

    //                Session["dblAmtDaerPlus"] = 0;
    //                Session["dblAmtDaerMns"] = 0;
    //                Session["numChalanIdEdit"] = 0;

    //              //  ***********Session G Curr*****************

    //              //  ***********Session Card generate*****************
    //                Session["intAccNo"] = 0;
    //                Session["intCnt"] = 0;
    //             //   ***********Session Card generate*****************

    //             //   ***********Session Ann statement***************** 
    //                Session["NumEmpIdAnnStmnt"] = 0;
    //                Session["intYearAnnStmnt"] = 0;
    //              //  ***********Session Ann statement*****************

    //             //   ***********Session Approval by AO*****************
    //                Session["intDTreasuryId"] = 0;
    //             //   ***********Session Approval by AO*****************

    //             //   ***********Session Search*****************
    //                Session["flgFilterMode"] = 0;
    //            //    ***********Session Search*****************

    //             //   ***********Session Rem01*****************
    //                Session["numChalanIdEdit"] = 0;
    //                Session["NumChalanID"] = 0;
    //                Session["intSTreasDetId"] = 0;
    //            //    ***********Session Rem01*****************

    //              //  ***********Session Service Trn*****************
    //                Session["NumServiceTrnID"] = 0;
    //                Session["intMenuItem"] = 0;
    //             //   ***********Session Service Trn*****************
    //                Session["flgPageBackW"] = 0;
    //                cntHit = 0;

    //                Response.Redirect("MainPage.aspx");
    //            }
    //            else
    //            {
    //                Session["flgLogin"] = 0;
    //                gblObj.MsgBoxOk("Invalid User/Password", this);
    //            }
    //        }
    //        else
    //        {
    //            Session["flgLogin"] = 0;
    //            gblObj.MsgBoxOk("Invalid User/Password", this);
    //        }
    //        if (Convert.ToInt16(Session["flgLogin"]) == 1 || Convert.ToInt16(Session["flgLogin"]) == 3)
    //        {
    //            Response.Redirect("MainPage.aspx");
    //        }
    //        else
    //        {
    //            gblObj.MsgBoxOk("Invalid User/Password", this);
    //        }
    //    }
    //    cntHit = cntHit + 1;

    //}  

    private void MatchLB()
    {
        DataSet dsLb = new DataSet();
        ArrayList ar = new ArrayList();
        if (Convert.ToInt32(Session["intLBTypeId"]) == 5)
        {
            Session["intLBTypeId"] = 7;
        }
        if (Convert.ToInt16(Session["intLBIDComm"]) == 5000)
        {
            ar.Add(Convert.ToInt32(Session["intDistId"]));
            ar.Add(Convert.ToInt32(Session["intLBTypeId"]));
            dsLb = genDao.GetDDP_LBId(ar);
        }
        else
        {
            ar.Add(Convert.ToInt32(Session["intLBIDComm"]));
            dsLb = genDao.GetLBIdFromSulekha(ar);
        }
        if (Convert.ToInt16(dsLb.Tables[0].Rows.Count) > 0)
        {
            Session["intLBID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[0]);
            Session["strLBName"] = dsLb.Tables[0].Rows[0].ItemArray[2].ToString();
            if (Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[1]) == 3 || Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[1]) == 4)
            {
                Session["intLBTypeId"] = 5;
            }
            else
            {
                Session["intLBTypeId"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[1]);
            }

            Session["intTreasuryID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[4]);
            Session["intDTreasuryID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[6]);
            Session["intCntEmp"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[12]);
            Session["strTreasury"] = dsLb.Tables[0].Rows[0].ItemArray[5];
            Session["strDTreasury"] = dsLb.Tables[0].Rows[0].ItemArray[7];
            Session["File"] = "D";
            Session["intDistId"] = Convert.ToInt16(dsLb.Tables[0].Rows[0].ItemArray[3]);
            Session["munGrpId"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[8]);
            Session["flgLogin"] = Convert.ToInt16(dsLb.Tables[0].Rows[0].ItemArray[9]);
        }
        
        else
        {
            Session["flgLogin"] = 0;
        }
        if (Convert.ToInt32(Session["intUserTypeId"]) == 40)
        {
            Session["flgLogin"] = 1;
        }


        //////////////////// Block Dir Users /////////////////////
        //if (Convert.ToInt64(Session["intUserId"]) == 44440 || Convert.ToInt64(Session["intUserId"]) == 46346)
        //{
        //    Session["flgLogin"] = 1;
        //}
        //else if (Convert.ToInt16(dsLb.Tables[0].Rows[0].ItemArray[0]) == 1550)
        //{
        //    Session["flgLogin"] = 0;
        //}
        ////else if (Convert.ToInt64(Session["intUserId"]) != 44440)
        ////{
        ////    Session["flgLogin"] = 0;
        ////}

        //////////////////// Block Dir Users /////////////////////

        //else
        //{
        //    Session["intLBID"] = 0;
        //}

        //DataSet dsLb = new DataSet();
        //ArrayList ar = new ArrayList();
        //if (Convert.ToInt32(Session["intLBTypeId"]) == 5)
        //{
        //    Session["intLBTypeId"] = 7;
        //}
        //if (Convert.ToInt16(Session["intLBIDComm"]) == 5000)
        //{
        //    ar.Add(Convert.ToInt32(Session["intDistId"]));
        //    ar.Add(Convert.ToInt32(Session["intLBTypeId"]));
        //    dsLb = genDao.GetDDP_LBId(ar);
        //}
        //else
        //{
        //    ar.Add(Convert.ToInt32(Session["intLBIDComm"]));
        //    dsLb = genDao.GetLBIdFromSulekha(ar);
        //}
        //if (Convert.ToInt16(dsLb.Tables[0].Rows.Count) > 0)
        //{
        //    Session["intLBID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[0]);
        //    Session["strLBName"] = dsLb.Tables[0].Rows[0].ItemArray[2].ToString();
        //    Session["intLBTypeId"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[1]);

        //    Session["intTreasuryID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[4]);
        //    Session["intDTreasuryID"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[6]);
        //    Session["intCntEmp"] = 1;// Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[12]);
        //    Session["strTreasury"] = dsLb.Tables[0].Rows[0].ItemArray[5];
        //    Session["strDTreasury"] = dsLb.Tables[0].Rows[0].ItemArray[7];
        //    Session["File"] = "D";
        //    Session["intDistId"] = Convert.ToInt16(dsLb.Tables[0].Rows[0].ItemArray[3]);
        //    Session["munGrpId"] = Convert.ToInt32(dsLb.Tables[0].Rows[0].ItemArray[8]);
        //}
        ////else
        ////{
        ////    Session["intLBID"] = 0;
        ////}
    }
    private void AssignLoginToMunStaff()
    {
        Session["intLBTypeId"] = 5;
    }
    private void AssignUserTypeForOtherLBs(int userType)
    {
        if (userType == 45)         //DP SC
        {
            Session["intUserTypeId"] = 1;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 46)    //DP JS
        {
            Session["intUserTypeId"] = 2;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 47)    //DP SS
        {
            Session["intUserTypeId"] = 5;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 48)    //DP AO
        {
            Session["intUserTypeId"] = 6;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 49)    //DP Addl. Dir
        {
            Session["intUserTypeId"] = 7;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 5)    //DP  Dir
        {
            Session["intUserTypeId"] = 8;
            Session["intLBTypeId"] = 7;
        }
        else if (userType == 10)    //DDP DDP
        {
            Session["intUserTypeId"] = 4;
            Session["intLBTypeId"] = 6;
        }

        //else if (userType == 43 || userType == 55)    //DDP Clerk
        else if (userType == 43)    //DDP Clerk
        {
            Session["intUserTypeId"] = 1;
            Session["intLBTypeId"] = 6;
        }
        else if (userType == 44)    //DDP JS
        {
            Session["intUserTypeId"] = 2;
            Session["intLBTypeId"] = 6;
        }



        ///////////////////////////
        else if (userType == 58)    //DP SC Accnts
        {
            Session["intUserTypeId"] = 1;
            Session["intLBTypeId"] = 5;
            Session["flgAcc"] = 1;
        }
        else if (userType == 59)    //DP JS Accnts
        {
            Session["intUserTypeId"] = 2;
            Session["intLBTypeId"] = 5;
            Session["flgAcc"] = 1;
        }
        else if (userType == 60)    //DP SS Accnts
        {
            Session["intUserTypeId"] = 3;
            Session["intLBTypeId"] = 5;
            Session["flgAcc"] = 1;
        }

        else if (userType == 40)    //DP SS Accnts
        {
            Session["intUserTypeId"] = 40;
            Session["intLBTypeId"] = 6;
        }
        ///////////////////////////////
    }
    protected void btnCCard_Click(object sender, EventArgs e)
    {
        // Do your server-side stuff here getting the new window arguments.
        string windowArgs = "";

        string newWindowUrl = "CreditCard.aspx?WindowArgs=" + windowArgs;
        string javaScript =
         "<script type='text/javascript'>\n" +
         "<!--\n" +
         "window.open('" + newWindowUrl + "');\n" +
         "top=0, left=0, width=500, height=500" +
         "// -->\n" +
         "</script>\n";
        this.RegisterStartupScript("", javaScript);

    }
    protected void btnAppForms_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AppForms.aspx");

        string windowArgs = "";

        string newWindowUrl = "AppForms.aspx?WindowArgs=" + windowArgs;
        string javaScript =
         "<script type='text/javascript'>\n" +
         "<!--\n" +
         "window.open('" + newWindowUrl + "');\n" +
         "top=0, left=0, width=500, height=500" +
         "// -->\n" +
         "</script>\n";
        this.RegisterStartupScript("", javaScript);
    }
}
