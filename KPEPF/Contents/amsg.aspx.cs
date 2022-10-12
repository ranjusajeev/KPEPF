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
using System.Web.Mail;


public partial class Contents_amsg : System.Web.UI.Page
{
    clsGlobalMethods gblObj=new clsGlobalMethods();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void OnConfirm(object sender, EventArgs e)
    {
        //string str = "";
        //string MobileNo = "9447961630";
        //int intId = 0;
        //str = "<?xml version='1.0' encoding='UTF-8'?>";
        //str = str + "<SMS>";
        //str = str + "<Application>SthapanaPF</Application>";
        //str = str + "<Sub>CreditCard</Sub>";
        //str = str + "<Login>SthapanaPF_CreditCard</Login>";
        //str = str + "<pwd>dp816dUD</pwd>";
        //str = str + "<RecID>" + intId + "</RecID>";
        //str = str + "<DeptOrLB>IT Mission</DeptOrLB>";
        //str = str + "<Message>" + Session["strLBName"] + "</Message>";
        //str = str + "<MobNo>" + MobileNo + "</MobNo>";
        //str = str + "<LBID>" + Convert.ToInt32(Session["intLBID"]) + "</LBID>";
        //str = str + "</SMS>";
        //SentSMS1(str);
    }
    //public bool SentSMS1(string s)
    //{
    //    try
    //    {
    //        SthapanaPFSms.SevanaeSMS a1 = new SthapanaPFSms.SevanaeSMS();
    //        a1.Url = ConfigurationManager.AppSettings["SthapanaPFSms.smsCall_loc"].ToString();
    //        string res = a1.ws_sms(s);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        //return false;
    //        throw new Exception("Check the Error!" + ex.Message);
    //        return false;
    //    }
    //}
    public void CreateString()
    {
        string str = "";
        string MobileNo = "9447961630";
        int intId = 0;
        str = "<?xml version='1.0' encoding='UTF-8'?>";
        str = str + "<SMS>";
        str = str + "<Application>SthapanaPF</Application>";
        str = str + "<Sub>CreditCard</Sub>";
        str = str + "<Login>SthapanaPF_CreditCard</Login>";
        str = str + "<pwd>dp816dUD</pwd>";
        str = str + "<RecID>" + intId + "</RecID>";
        str = str + "<DeptOrLB>IT Mission</DeptOrLB>";
        str = str + "<Message>" + Session["strLBName"] + "</Message>";
        str = str + "<MobNo>" + MobileNo + "</MobNo>";
        str = str + "<LBID>" + Convert.ToInt32(Session["intLBID"]) + "</LBID>";
        str = str + "</SMS>";
        //SentSMS1(str);
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        CreateString();
    }
}
