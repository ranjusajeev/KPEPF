<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        clsGlobalMethods gblObj = new clsGlobalMethods();
        Session["intUserId"] = 0;
        Session["intUserTypeId"] = 0;
        Session["strUserName"] = "";
        
        Session["intLBID"] = 0;
        Session["intLBTypeId"] = 0;
        Session["strLBName"] = "";
        Session["intDistId"] = 0;

        Session["intDTreasuryID"] = 0;
        Session["intTreasuryID"] = 0;
        Session["intMenuItem"] = 0;
        Session["NumServiceTrnID"] = 0;
        Session["intTrnTypeStage"] = 0;
        gblObj.IntAppFlgInbox = 0;

//////////On changing to Session////////////////
        Session["intYearIdApp"] = 0;
        Session["intMonthIdApp"] = 0;
//////////On changing to Session////////////////

        Session["flgPageBack"] = 0;
        Session["flgPageBackW"] = 0;
        
        Session["intYearIdBillEdit"] = 0;
        Session["intMonthIdBillEdit"] = 0;
        Session["intDistIdBillEdit"] = 0;
        //RemittqncePDE 08//
        Session["intSTreasDetId"] = 0;
        Session["flgPageBack"] = 0;
        Session["IntYearRem1"] = 0;
        Session["IntMonthRem1"] = 0;
        Session["IntDistRem1"] = 0;
        Session["IntDTRem1"] = 0;
        //RemittqncePDE 08//

        Session["numChalanIdEdit"] = 0;
        Session["intYearIdRem01"] = 0; 
        Session["intMonthIdRem01"] = 0;
        Session["intDistIdRem01"] = 0;
        Session["intYearIdBillEdit"] = 0;

        Session["intTrnType"] = 0;
        Session["intTrnTypeStage"] = 0;
        Session["flgPageBackFrmAG"] = 0;
        Session["flgFilterMode"] = 0;
        Session["NumEmpId"] = 0;
        Session["intYearAnnStmnt"] = 0;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
