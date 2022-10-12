using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KPEPFClassLibrary;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Summary description for clsGlobalMethods
/// </summary>
public class clsGlobalMethods
{
    GeneralDAO genDao = new GeneralDAO();
    EmployeeDAO empDoa = new EmployeeDAO();
    KPEPFGeneralDAO genDaoKP = new KPEPFGeneralDAO();
    private static int intUserId = 0;
    public int IntUserId { get { return intUserId; } set { intUserId = value; } }
    private static int intUserTypeId = 0;
    public int IntUserTypeId { get { return intUserTypeId; } set { intUserTypeId = value; } }
    private static string strUserName = "";
    public string StrUserName { get { return strUserName; } set { strUserName = value; } }
    private static string strUser = "";
    public string StrUser { get { return strUser; } set { strUser = value; } }
    private static int intFlgLogin = 0;
    public int IntFlgLogin { get { return intFlgLogin; } set { intFlgLogin = value; } }

    private static int intLBId = 0;
    public int IntLBId { get { return intLBId; } set { intLBId = value; } }
    private static int intLBTypeId = 0;
    public int IntLBTypeId { get { return intLBTypeId; } set { intLBTypeId = value; } }
    private static string strLBName = "";
    public string StrLBName { get { return strLBName; } set { strLBName = value; } }
    private static int intDistId = 0;
    public int IntDistId { get { return intDistId; } set { intDistId = value; } }
    private static int intDistIdDirUser = 0;
    public int IntDistIdDirUser { get { return intDistIdDirUser; } set { intDistIdDirUser = value; } }

    private static int intTreasuryID = 0;
    public int IntTreasuryID { get { return intTreasuryID; } set { intTreasuryID = value; } }
    private static int intDTreasuryID = 0;
    public int IntDTreasuryID { get { return intDTreasuryID; } set { intDTreasuryID = value; } }
    //private static int intInstId = 0;
    //public int IntInstId { get { return intInstId; } set { intInstId = value; } }

    //---------------Set Emp---------------
    private static string strNameEmp;
    public string StrNameEmp { get { return strNameEmp; } set { strNameEmp = value; } }
    private static double numEmpId;
    public double NumEmpId { get { return numEmpId; } set { numEmpId = value; } }
    //-------------------------------------
    //-------------------AG----------------

    private static int gintTEMonthWiseId = 0;
    public int GintTEMonthWiseId { get { return gintTEMonthWiseId; } set { gintTEMonthWiseId = value; } }

    //---------------------------------------
    //---------------TrnType---------------
    private static int intTrnType;
    public int IntTrnType { get { return intTrnType; } set { intTrnType = value; } }

    private static int intOldTrnType;
    public int IntOldTrnType { get { return intOldTrnType; } set { intOldTrnType = value; } }

    private static int intTrnTypeStage;
    public int IntTrnTypeStage { get { return intTrnTypeStage; } set { intTrnTypeStage = value; } }

    private static int intEditFlg;
    public int IntEditFlg { get { return intEditFlg; } set { intEditFlg = value; } }
    //-------------------------------------

    //---------------Master page---------------
    private static int intMenuItem;         //To identify the source of file (View or feom Inbox)
    public int IntMenuItem { get { return intMenuItem; } set { intMenuItem = value; } }
    //-------------------------------------

    //---------------Approval flag---------------
    private static int intFlgApp;
    public int IntFlgApp { get { return intFlgApp; } set { intFlgApp = value; } }
    private static int intFlgRej;
    public int IntFlgRej { get { return intFlgRej; } set { intFlgRej = value; } }
    private static int intFlgAppInbx;
    public int IntFlgAppInbx { get { return intFlgAppInbx; } set { intFlgAppInbx = value; } }
    private static int intFlgRejInbx;
    public int IntFlgRejInbx { get { return intFlgRejInbx; } set { intFlgRejInbx = value; } }
    private static string strOptCaption;
    public string StrOptCaption { get { return strOptCaption; } set { strOptCaption = value; } }
    private static string strMsg;
    public string StrMsg { get { return strMsg; } set { strMsg = value; } }


    private static int intFlgOrg;
    public int IntFlgOrg { get { return intFlgOrg; } set { intFlgOrg = value; } }
    private static string strFileNo;
    public string StrFileNo { get { return strFileNo; } set { strFileNo = value; } }


    private static int intAppFlgInbox;      //1- when Approved opt is selected and 2 for rej
    public int IntAppFlgInbox { get { return intAppFlgInbox; } set { intAppFlgInbox = value; } }
    //-------------------------------------

    //---------------Service Trns---------------
    private static long numServiceTrnID = 0;
    public long NumServiceTrnID { get { return numServiceTrnID; } set { numServiceTrnID = value; } }

    private static long numBillID = 0;
    public long NumBillID { get { return numBillID; } set { numBillID = value; } }

    private static long numChalanID = 0;
    public long NumChalanID { get { return numChalanID; } set { numChalanID = value; } }
    //-------------------------------------
    //----------------TE------------------
    private static int intId = 0;
    public int IntId { get { return intId; } set { intId = value; } }
    //--------------Membership---------------
    private static int intGender = 0;
    public int IntGender { get { return intGender; } set { intGender = value; } }

    private static int intMarStatus = 0;
    public int IntMarStatus { get { return intMarStatus; } set { intMarStatus = value; } }
    //--------------Membership-----------

    //--------------SearchChalBill---------------
    private static int flgChalBill = 0;
    public int FlgChalBill { get { return flgChalBill; } set { flgChalBill = value; } }

    private static int flgFilterMode = 0;
    public int FlgFilterMode { get { return flgFilterMode; } set { flgFilterMode = value; } }

    private static string strChalDt = "";
    public string StrChalDt { get { return strChalDt; } set { strChalDt = value; } }

    private static int intChalNo = 0;
    public int IntChalNo { get { return intChalNo; } set { intChalNo = value; } }
    //-------------SearchChalBill-----------

    //--------------YearMonth---------------
    private static int intYear = 0;
    public int IntYear { get { return intYear; } set { intYear = value; } }

    private static int intMonth = 0;
    public int IntMonth { get { return intMonth; } set { intMonth = value; } }
    //--------------YearMonth-----------

    //-------------yr4ABCD------------
    private static int intYearABCD1 = 0;
    public int IntYearABCD1 { get { return intYearABCD1; } set { intYearABCD1 = value; } }

    private static int intYearABCD = 0;
    public int IntYearABCD { get { return intYearABCD; } set { intYearABCD = value; } }
    //-------------yr4ABCD------------







    //--------------Withdrwals---------------
    private static int intDistWit = 0;
    public int IntDistWit { get { return intDistWit; } set { intDistWit = value; } }
    private static int intBillNo = 0;
    public int IntBillNo { get { return intBillNo; } set { intBillNo = value; } }
    private static int intYearIdWit = 0;
    public int IntYearIdWit { get { return intYearIdWit; } set { intYearIdWit = value; } }
    private static int intMonthIdWit = 0;
    public int IntMonthIdWit { get { return intMonthIdWit; } set { intMonthIdWit = value; } }
    private static int intTreIdWit = 0;
    public int IntTreIdWit { get { return intTreIdWit; } set { intTreIdWit = value; } }
    private static int flgBillType = 0;
    public int FlgBillType { get { return flgBillType; } set { flgBillType = value; } }
    private static string dtIntiWith = " ";
    public string DtIntiWith { get { return dtIntiWith; } set { dtIntiWith = value; } }
    private static int intiAmtWith = 0;
    public int IntiAmtWith { get { return intiAmtWith; } set { intiAmtWith = value; } }
    private static string strWith = " ";
    public string StrWith { get { return strWith; } set { strWith = value; } }
    private static int flgAppRejWith = 0;
    public int FlgAppRejWith { get { return flgAppRejWith; } set { flgAppRejWith = value; } }
    private static long intTreasuryDId = 0;
    public long IntTreasuryDId { get { return intTreasuryDId; } set { intTreasuryDId = value; } }
    //--------------Withdssrwals---------------

    //--------------AOApproval---------------
    private static int flgAppRejAo = 0;
    public int FlgAppRejAo { get { return flgAppRejAo; } set { flgAppRejAo = value; } }

    private static int intYearIdAo = 0;
    public int IntYearIdAo { get { return intYearIdAo; } set { intYearIdAo = value; } }

    private static int intMonthIdAo = 0;
    public int IntMonthIdAo { get { return intMonthIdAo; } set { intMonthIdAo = value; } }

    private static int intTreIdAO = 0;
    public int IntTreIdAO { get { return intTreIdAO; } set { intTreIdAO = value; } }

    private static int intDistAO = 0;
    public int IntDistAO { get { return intDistAO; } set { intDistAO = value; } }

    private static int flgRemWithAO = 0;
    public int FlgRemWithAO { get { return flgRemWithAO; } set { flgRemWithAO = value; } }
    //--------------AOApproval---------------


    //--------------AOView---------------
    private static int intChalanAO = 0;
    public int IntChalanAO { get { return intChalanAO; } set { intChalanAO = value; } }
    private static int intBillAO = 0;
    public int IntBillAO { get { return intBillAO; } set { intBillAO = value; } }
    //--------------AOView---------------


    //--------------Remittance---------------
    private static int intYearIdRemi = 0;
    public int IntYearIdRemi { get { return intYearIdRemi; } set { intYearIdRemi = value; } }
    private static int intMonthIdRemi = 0;
    public int IntMonthIdRemi { get { return intMonthIdRemi; } set { intMonthIdRemi = value; } }
    private static int intTreIdRemi = 0;
    public int IntTreIdRemi { get { return intTreIdRemi; } set { intTreIdRemi = value; } }
    private static int flgChalanType = 0;
    public int FlgChalanType { get { return flgChalanType; } set { flgChalanType = value; } }
    private static int intDistRemi = 0;
    public int IntDistRemi { get { return intDistRemi; } set { intDistRemi = value; } }
    private static string strIntimation = " ";
    public string StrIntimation { get { return strIntimation; } set { strIntimation = value; } }
    private static int intIntAmt = 0;
    public int IntIntAmt { get { return intIntAmt; } set { intIntAmt = value; } }
    private static string strRem = " ";
    public string StrRem { get { return strRem; } set { strRem = value; } }
    private static int otherInst = 0;
    public int OtherInst { get { return otherInst; } set { otherInst = value; } }
    //--------------Remittance---------------


    /////////////////////18/03/2013/////////////////////////
    //private static string flgMsg;
    //public string FlgMsg { get { return flgMsg; } set { flgMsg = value; } }
    //private static double sertrnid = 0;
    //public double SerTrnId { get { return sertrnid; } set { sertrnid = value; } }
    //private static string strRptName;
    //public string StrRptName { get { return strRptName; } set { strRptName = value; } }

    //private static string strRptFileName;
    //public string StrRptFileName { get { return strRptFileName; } set { strRptFileName = value; } }

    //private static int intParamCnt;
    //public int IntParamCnt { get { return intParamCnt; } set { intParamCnt = value; } }

    //private static string strRptParamArr;
    //public string StrRptParamArr { get { return strRptParamArr; } set { strRptParamArr = value; } }

    //private static int intMsgInw;
    //public int IntMsgInw { get { return intMsgInw; } set { intMsgInw = value; } }


    //private static int intMsgEmp;
    //public int IntMsgEmp { get { return intMsgEmp; } set { intMsgEmp = value; } }


    //private static int intInwrdNo;
    //public int IntInwrdNo { get { return intInwrdNo; } set { intInwrdNo = value; } }

    //private static int intMsg1;
    //public int IntMsg1 { get { return intMsg1; } set { intMsg1 = value; } }
    //private static int intMsg2;
    //public int IntMsg2 { get { return intMsg2; } set { intMsg2 = value; } }

    //private static Label lblCurSubnAmt;
    //public Label LblCurSubnAmt { get { return lblCurSubnAmt; } set { lblCurSubnAmt = value; } }

    //private static int intInvldAccNo;
    //public int IntInvldAccNo { get { return intInvldAccNo; } set { intInvldAccNo = value; } }

    //private static double fltsubnAmt;
    //public double FltSubnAmt { get { return fltsubnAmt; } set { fltsubnAmt = value; } }

    //private static double fltOrgTAAmt;
    //public double FltOrgTAAmt { get { return fltOrgTAAmt; } set { fltOrgTAAmt = value; } }

    //private static double fltPndingAmt;
    //public double FltPndingAmt { get { return fltPndingAmt; } set { fltPndingAmt = value; } }


    //private static int fltInstPnding;
    //public int FltInstPnding { get { return fltInstPnding; } set { fltInstPnding = value; } }

    ////private static double fltPndingAmt;
    ////public double FltPndingAmt { get { return fltPndingAmt; } set { fltPndingAmt = value; } }

    //private static double fltPFCresdit;
    //public double FltPFCresdit { get { return fltPFCresdit; } set { fltPFCresdit = value; } }
    //private static double fltMaxAdmsblTA;
    //public double FltMaxAdmsblTA { get { return fltMaxAdmsblTA; } set { fltMaxAdmsblTA = value; } }

    //public static int intDesigId;
    //public int IntDesigId { get { return intDesigId; } set { intDesigId = value; } }

    //public static string dtmRtrmnt;
    //public string DtmRtrmnt { get { return dtmRtrmnt; } set { dtmRtrmnt = value; } }

    //private static int flgClosed;
    //public int FlgClosed { get { return flgClosed; } set { flgClosed = value; } }
    //private static int intInstTypeId = 0;
    //public int IntInstTypeId { get { return intInstTypeId; } set { intInstTypeId = value; } }

    /////////////////////18/03/2013/////////////////////////

    Approval appObj = new Approval();
    ApprovalDAO appDobj = new ApprovalDAO();
    KPEPFGeneralDAO GenDAOObj = new KPEPFGeneralDAO();

    public string DisplayMsg(int TrnTypeId, int TypeId, int ValidRegId)
    {
        string msg = "0";
        DataSet dsMsg = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(TrnTypeId);
        ArrIn.Add(TypeId);
        ArrIn.Add(ValidRegId);
        dsMsg = genDao.GetMessage(ArrIn);
        if (dsMsg.Tables[0].Rows.Count > 0)
        {
            msg = dsMsg.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        return msg;
    }
    public void FillCombo(DropDownList cmb, DataSet ds, int selectedCol)
    {
        if (cmb != null)
        {
            cmb.Items.Clear();
            cmb.Items.Add(new ListItem("<Select an Item>", "0"));
            for (int rw = 0; rw < ds.Tables[0].Rows.Count; rw++)
            {
                cmb.Items.Add(new ListItem(ds.Tables[0].Rows[rw].ItemArray[selectedCol].ToString(), ds.Tables[0].Rows[rw].ItemArray[0].ToString()));
            }
        }
    }
    public void FillComboDirect(DropDownList cmb, DataTable dt, int selectedCol)
    {
        if (cmb != null)
        {
            cmb.Items.Clear();
            cmb.Items.Add(new ListItem("<Select an Item>", "0"));
            for (int rw = 0; rw < dt.Rows.Count; rw++)
            {
                cmb.Items.Add(new ListItem(dt.Rows[rw].ItemArray[selectedCol].ToString(), dt.Rows[rw].ItemArray[0].ToString()));
            }
        }
    }
    public void SetMsgBox(int intFlg, string strMsg)
    {
        if (intFlg == 1)
        {

        }
    }
    public void MergeCells(GridView gdv, GridViewRow gvr, int cntCol, int mrgStCol, int mrgEndCol, string mrgText)
    {
        if (gvr.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            TableCell cell = new TableCell();
            for (int i = 0; i < mrgStCol - 1; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);
            }
            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol - mrgStCol + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText;
            row.Cells.Add(cell);
            gdv.Controls[0].Controls.AddAt(0, row);

            for (int i = mrgEndCol; i < cntCol; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                //cell.Text = "dd";
                row.Cells.Add(cell);
            }
        }
    }
    public void MergeCellsTest(GridView gdv, GridViewRow gvr, int cntCol, int mrgStCol, int mrgEndCol, string mrgText, GridViewRowEventArgs e1)
    {
        if (gvr.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell = new TableCell();

            cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = gdv.Columns[0].HeaderText;
            cell.RowSpan = 2;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.ColumnSpan = 3;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = "Poested";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.ColumnSpan = 3;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = "Un Poested";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = gdv.Columns[7].HeaderText;
            cell.RowSpan = 2;
            row.Cells.Add(cell);

            gdv.Controls[0].Controls.AddAt(0, row);

            if (e1.Row.RowType == DataControlRowType.Header)
            {
                e1.Row.Cells[0].Visible = false;
                e1.Row.Cells[7].Visible = false;
            }

        }

    }
    public void Setdd(GridViewRowEventArgs e1)
    {
        if (e1.Row.RowType == DataControlRowType.Header)
        {
            e1.Row.Cells[0].Visible = false;
            e1.Row.Cells[7].Visible = false;
        }
    }
    public void SetBlankRow(GridView gdv)
    {
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();
        dt.Rows.Add(dr);

        DataColumn dcol = new DataColumn("SlNo", typeof(System.Int32));
        dcol.AutoIncrement = true;
        dt.Columns.Add(dcol);
        for (int i = 0; i < 1; i++)
        {
            dr = dt.NewRow();
            dr["SlNo"] = "1";
            dt.Rows.Add(dr);
        }

        gdv.DataSource = dt;
        gdv.DataBind();
        gdv.Visible = true;
    }
    public void SetRowsCnt(GridView gdv, int cnt)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        DataColumn dcol = new DataColumn("SlNo", typeof(System.Int32));
        dcol.AutoIncrement = true;
        dt.Columns.Add(dcol);

        for (int i = 0; i < cnt; i++)
        {
            dr = dt.NewRow();
            dr["SlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
        gdv.Visible = true;
    }
    //public void SetRowsCntBind(GridView gdv, int cnt, string chvCol)
    //{
    //    DataTable dt = new DataTable();
    //    DataRow dr;
    //    DataColumn dcol = new DataColumn("SlNo", typeof(System.Int32));
    //    DataColumn dcol2 = new DataColumn(chvCol, typeof(System.Int32));
    //    dcol.AutoIncrement = true;
    //    dt.Columns.Add(dcol);
    //    dt.Columns.Add(dcol2);
    //    for (int i = 0; i < cnt; i++)
    //    {
    //        dr = dt.NewRow();
    //        dr["SlNo"] = i + 1;
    //        dr[chvCol] = i + 1;
    //        dt.Rows.Add(dr);
    //    }
    //    gdv.DataSource = dt;
    //    gdv.DataBind();
    //    gdv.Visible = true;
    //}
    public void SetRowsCntInBxM(GridView gdv, int cnt)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        DataColumn dcol1 = new DataColumn("SlNo", typeof(System.Int32));
        DataColumn dcol2 = new DataColumn("chvEmployeeName", typeof(System.Int32));
        DataColumn dcol3 = new DataColumn("chvDesignation", typeof(System.Int32));
        DataColumn dcol4 = new DataColumn("dtmRequest", typeof(System.Int32));
        DataColumn dcol5 = new DataColumn("chvFileNo", typeof(System.Int32));
        DataColumn dcol6 = new DataColumn("intNominees", typeof(System.Int32));
        DataColumn dcol7 = new DataColumn("numTrnId", typeof(System.Int32));
        dcol1.AutoIncrement = true;
        dcol2.AutoIncrement = true;
        dcol3.AutoIncrement = true;
        dcol4.AutoIncrement = true;
        dcol5.AutoIncrement = true;
        dcol6.AutoIncrement = true;
        dcol7.AutoIncrement = true;

        dt.Columns.Add(dcol1);
        dt.Columns.Add(dcol2);
        dt.Columns.Add(dcol3);
        dt.Columns.Add(dcol4);
        dt.Columns.Add(dcol5);
        dt.Columns.Add(dcol6);
        dt.Columns.Add(dcol7);

        for (int i = 0; i < cnt; i++)
        {
            dr = dt.NewRow();
            dr["SlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
        gdv.Enabled = false;
    }
    public void SetGridDefault(GridView gdv, ArrayList arr)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        for (int j = 0; j < arr.Count; j++)
        {
            DataColumn dcol = new DataColumn(arr[j].ToString(), typeof(System.Int32));
            dcol.AutoIncrement = true;
            dt.Columns.Add(dcol);
        }
        for (int i = 0; i < 1; i++)
        {
            dr = dt.NewRow();
            dr[arr[0].ToString()] = i + 1;
            //dr["intSlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
        gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
    }
    public void SetGridDefaultCnt(GridView gdv, ArrayList arr, int cnt)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        for (int j = 0; j < arr.Count; j++)
        {
            DataColumn dcol = new DataColumn(arr[j].ToString(), typeof(System.Int32));
            if (j == 0)
            {
                dcol.AutoIncrement = true; 
            }
            //else
            //{
            //    dcol = 0;
            //}
            dt.Columns.Add(dcol);
        }
        for (int i = 0; i < cnt; i++)
        {
            dr = dt.NewRow();
            dr[arr[0].ToString()] = i + 1;
            //dr["intSlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
    }
    public void FillGridSlNo(GridView gdv)
    {
        if (gdv.Rows.Count > 0)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                gdv.Rows[i].Cells[0].Text = (i + 1).ToString();
            }
        }
    }
    public void MergeCellsMltpl(GridView gdv, GridViewRow gvr, int cntCol, int mrgStCol1, int mrgEndCol1, int mrgStCol2, int mrgEndCol2, string mrgText1, string mrgText2)
    {
        if (gvr.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell = new TableCell();
            //Row merge on start
            for (int i = 0; i < mrgStCol1 - 1; i++)
            {
                cell = new TableCell();
                cell.ColumnSpan = 1;
                cell.RowSpan = 2;
                cell.Text = gdv.Columns[i].HeaderText;
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);
            }

            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol1 - mrgStCol1 + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText1;
            row.Cells.Add(cell);
            //gdv.Controls[0].Controls.AddAt(0, row);

            //Row merge on middle
            for (int i = mrgEndCol1; i < mrgStCol2 - 1; i++)
            {
                cell = new TableCell();
                cell.ColumnSpan = 1;
                cell.RowSpan = 2;
                cell.Text = gdv.Columns[i].HeaderText;
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);
            }

            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol2 - mrgStCol2 + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText2;
            row.Cells.Add(cell);
            //gdv.Controls[0].Controls.AddAt(0, row);

            //Row merge on end
            for (int i = mrgEndCol2; i <= cntCol; i++)
            {
                cell = new TableCell();
                cell.ColumnSpan = 1;
                cell.RowSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = gdv.Columns[i].HeaderText;
                row.Cells.Add(cell);
            }
            gdv.Controls[0].Controls.AddAt(0, row);
            //for (int j = 0; j < gdv.Columns.Count - 1; j++)
            //{
            //    //GridViewRow currentRow = gdv.HeaderRow;
            //    //string ss = currentRow.Cells[0].TemplateControl.ID;
            //    //string ss = currentRow.Cells[0].Text.ToString();
            //    string ss = gdv.Columns[0].HeaderText;
            //    GridViewRow gdvRw3 = gdv.Rows[0];

            //    //if (gdv.Columns[j].HeaderText == previousRow.Cells[j].Text)
            //    //{
            //    gdvRw3.Cells[0].RowSpan = 2;
            //        //if (previousRow.Cells[j].RowSpan < 2)
            //        //    currentRow.Cells[j].RowSpan = 2;
            //        //else
            //        //    currentRow.Cells[j].RowSpan = previousRow.Cells[j].RowSpan + 1;
            //        //previousRow.Cells[j].Visible = false;
            //    //}
            //}
        }
    }
    public void GridView_Row_Merger(GridView gridView)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow currentRow = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

            for (int i = 0; i <= currentRow.Cells.Count; i++)
            {
                if (currentRow.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    if (previousRow.Cells[i].RowSpan < 2)
                        currentRow.Cells[i].RowSpan = 2;
                    else
                        currentRow.Cells[i].RowSpan = previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
            }
        }

    }
    //public void MergeCells(GridView HeaderGrid, GridViewRow gvr, int cntCol, int mrgStCol1, int mrgEndCol1, int mrgStCol2, int mrgEndCol2, string mrgText1, string mrgText2, GridViewRowEventArgs e1)
    //{
    //    if (gvr.RowType == DataControlRowType.Header)
    //    {
    //        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
    //        TableCell cell = new TableCell();
    //        for (int i = 0; i < mrgStCol1; i++)
    //        {
    //            cell = new TableCell();
    //            cell.HorizontalAlign = HorizontalAlign.Center;
    //            cell.Text = HeaderGrid.Columns[i].HeaderText;
    //            cell.RowSpan = 2;
    //            row.Cells.Add(cell);
    //            e1.Row.Cells[i].Visible = false;

    //        }
    //        cell = new TableCell();
    //        cell.ColumnSpan = mrgEndCol1 - mrgStCol1 + 1;
    //        cell.HorizontalAlign = HorizontalAlign.Center;
    //        cell.Text = mrgText1;
    //        row.Cells.Add(cell);

    //        for (int i = mrgEndCol1; i < mrgStCol2 ; i++)
    //        {
    //            cell = new TableCell();
    //            cell.HorizontalAlign = HorizontalAlign.Center;
    //            cell.Text = HeaderGrid.Columns[i].HeaderText;
    //            cell.RowSpan = 2;
    //            row.Cells.Add(cell);
    //            e1.Row.Cells[i].Visible = false;
    //        }

    //        cell = new TableCell();
    //        cell.ColumnSpan = mrgEndCol2 - mrgStCol2 + 1;
    //        cell.HorizontalAlign = HorizontalAlign.Center;
    //        cell.Text = mrgText2;
    //        row.Cells.Add(cell);

    //        //for (int i = mrgEndCol2 ; i <= cntCol; i++)
    //        //{
    //        //    cell = new TableCell();
    //        //    cell.HorizontalAlign = HorizontalAlign.Center;
    //        //    cell.Text = HeaderGrid.Columns[i].HeaderText;
    //        //    cell.RowSpan = 2;
    //        //    row.Cells.Add(cell);
    //        //    e1.Row.Cells[i].Visible = false;
    //        //}

    //        HeaderGrid.Controls[0].Controls.AddAt(0, row);
    //    }
    //}
    public void MergeCells(GridView HeaderGrid, GridViewRow gvr, int cntCol, int mrgStCol1, int mrgEndCol1, int mrgStCol2, int mrgEndCol2, string mrgText1, string mrgText2, GridViewRowEventArgs e1)
    {
        if (gvr.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell = new TableCell();
            for (int i = 0; i < mrgStCol1; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = HeaderGrid.Columns[i].HeaderText;
                cell.RowSpan = 2;
                row.Cells.Add(cell);
                e1.Row.Cells[i].Visible = false;

            }
            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol1 - mrgStCol1 + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText1;
            row.Cells.Add(cell);

            for (int i = mrgEndCol1; i < mrgStCol2 - 1; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = HeaderGrid.Columns[i].HeaderText;
                cell.RowSpan = 2;
                row.Cells.Add(cell);
                e1.Row.Cells[i].Visible = false;
            }

            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol2 - mrgStCol2 + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText2;
            row.Cells.Add(cell);

            for (int i = mrgEndCol2 + 1; i <= cntCol; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = HeaderGrid.Columns[i].HeaderText;
                cell.RowSpan = 2;
                row.Cells.Add(cell);
                e1.Row.Cells[i].Visible = false;
            }

            HeaderGrid.Controls[0].Controls.AddAt(0, row);

            //if (e1.Row.RowType == DataControlRowType.Header)
            //{
            //    e1.Row.Cells[0].Visible = false;
            //    e1.Row.Cells[cntCol].Visible = false;
            //}
        }
    }
    public void MergeCellsSingle(GridView HeaderGrid, GridViewRow gvr, int cntCol, int mrgStCol1, int mrgEndCol1, string mrgText1,  GridViewRowEventArgs e1)
    {
        if (gvr.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell = new TableCell();
            for (int i = 0; i < mrgStCol1; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = HeaderGrid.Columns[i].HeaderText;
                cell.RowSpan = 2;
                row.Cells.Add(cell);
                e1.Row.Cells[i].Visible = false;

            }
            cell = new TableCell();
            cell.ColumnSpan = mrgEndCol1 - mrgStCol1 + 1;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = mrgText1;
            row.Cells.Add(cell);

            for (int i = mrgEndCol1+1; i <= cntCol; i++)
            {
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = HeaderGrid.Columns[i].HeaderText;
                cell.RowSpan = 2;
                row.Cells.Add(cell);
                e1.Row.Cells[i].Visible = false;
            }

            //cell = new TableCell();
            //cell.ColumnSpan = mrgEndCol2 - mrgStCol2 + 1;
            //cell.HorizontalAlign = HorizontalAlign.Center;
            //cell.Text = mrgText2;
            //row.Cells.Add(cell);

            //for (int i = mrgEndCol2 + 1; i <= cntCol; i++)
            //{
            //    cell = new TableCell();
            //    cell.HorizontalAlign = HorizontalAlign.Center;
            //    cell.Text = HeaderGrid.Columns[i].HeaderText;
            //    cell.RowSpan = 2;
            //    row.Cells.Add(cell);
            //    e1.Row.Cells[i].Visible = false;
            //}

            HeaderGrid.Controls[0].Controls.AddAt(0, row);
        }
    }
    public DataSet GetStatusMapping1(int UserTypeId, int intLBTypeId, int IntTrnType, int StageId, int k, int s, int h)
    {
        if (Convert.ToInt16(HttpContext.Current.Session["intTrnType"]) == 0)
        {
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
        }
        if (Convert.ToInt16(HttpContext.Current.Session["intTrnTypeStage"]) == 0)
        {
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
        }
        if (Convert.ToInt16(HttpContext.Current.Session["intMenuItem"]) == 0)
        {
            HttpContext.Current.Session["intMenuItem"] = Convert.ToInt16(h);
        }

        ArrayList ArrIn = new ArrayList();
        DataSet ds = new DataSet();
        ArrIn.Add(UserTypeId);
        ArrIn.Add(intLBTypeId);
        ArrIn.Add(k);
        ArrIn.Add(s);
        ds = genDaoKP.GetStatusMapping(ArrIn);
        return ds;
    }
    public void GetSessionValsByCheck(int k, int s, int h)
    {
        //if (Convert.ToInt16(HttpContext.Current.Session["intTrnType"]) == 0)
        //{
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
        //}
        //if (Convert.ToInt16(HttpContext.Current.Session["intTrnTypeStage"]) == 0)
        //{
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
        //}
        //if (Convert.ToInt16(HttpContext.Current.Session["intMenuItem"]) == 0)
        //{
            HttpContext.Current.Session["intMenuItem"] = Convert.ToInt16(h);
        //}
    }
    public void GetStatusMapping2(int UserTypeId, int intLBTypeId, int k, int s, int h)
    {
        ArrayList ArrIn = new ArrayList();
        DataSet ds = new DataSet();
        ArrIn.Add(UserTypeId);
        ArrIn.Add(intLBTypeId);
        ArrIn.Add(k);
        ArrIn.Add(s);
        ds = genDaoKP.GetStatusMapping(ArrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session["intFlgApp"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
            HttpContext.Current.Session["intFlgRej"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1]);
            HttpContext.Current.Session["intFlgAppInbx"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2]);
            HttpContext.Current.Session["intFlgRejInbx"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]);
            HttpContext.Current.Session["strOptCaption"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            HttpContext.Current.Session["strMsg"] = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
            HttpContext.Current.Session["intMenuItem"] = Convert.ToInt16(h);
        }
    }
    public void GetStatusMapping3(int UserTypeId, int intLBTypeId, int k, int s, int h)
    {
        ArrayList ArrIn = new ArrayList();
        DataSet ds = new DataSet();
        ArrIn.Add(UserTypeId);
        ArrIn.Add(intLBTypeId);
        ArrIn.Add(h);
        ArrIn.Add(s);
        ds = genDaoKP.GetStatusMapping(ArrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session["intFlgApp"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
            HttpContext.Current.Session["intFlgRej"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1]);
            HttpContext.Current.Session["intFlgAppInbx"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2]);
            HttpContext.Current.Session["intFlgRejInbx"] = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]);
            HttpContext.Current.Session["strOptCaption"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            HttpContext.Current.Session["strMsg"] = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
            HttpContext.Current.Session["intMenuItem"] = Convert.ToInt16(h);
        }
    }

    public void GetSessionVals(int k, int s, int h)
    {
        if (k != 0)
        {
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
        }
        if (s != 0)
        {
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
        }
        if (h != 0)
        {
            HttpContext.Current.Session["intMenuItem"] = Convert.ToInt16(h);
        }
    }
    public void SetAppFlagsInSession(DataSet dss)
    {
        if (dss.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session["intFlgApp"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[0]);
            HttpContext.Current.Session["intFlgRej"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[1]);
            HttpContext.Current.Session["intFlgAppInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[2]);
            HttpContext.Current.Session["intFlgRejInbx"] = Convert.ToInt16(dss.Tables[0].Rows[0].ItemArray[3]);
            HttpContext.Current.Session["strOptCaption"] = dss.Tables[0].Rows[0].ItemArray[4].ToString();
            HttpContext.Current.Session["strMsg"] = dss.Tables[0].Rows[0].ItemArray[5].ToString();
        }
    }
    //public void  GetStatusMapping(int UserTypeId, int intLBTypeId, int IntTrnType, int StageId,int iu)
    //{
    //    ArrayList ArrIn = new ArrayList();
    //    DataSet ds = new DataSet();
    //    ArrIn.Add(UserTypeId);
    //    ArrIn.Add(intLBTypeId);
    //    ArrIn.Add(IntTrnType);
    //    ArrIn.Add(StageId);
    //    ds = genDaoKP.GetStatusMapping(ArrIn);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        IntFlgApp = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
    //        IntFlgRej = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1]);
    //        IntFlgAppInbx = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2]);
    //        IntFlgRejInbx = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[3]);
    //        StrOptCaption = ds.Tables[0].Rows[0].ItemArray[4].ToString();
    //        StrMsg = ds.Tables[0].Rows[0].ItemArray[5].ToString();
    //    }
    //}
    public void MsgBoxOk(string msg, Page strPg)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("alert('");
        sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
        sb.Append("');");
        ScriptManager.RegisterStartupScript(strPg.Page, strPg.GetType(), "showalert", sb.ToString(), true);
    }

    public int MsgBoxOkCancel(string msg, Page strPg)
    {
        MsgBoxYesNo(msg, strPg);
        int flg = 0;
        string confirmValue = strPg.Request.Form["confirm_value"];
        //if (confirmValue.Length > 3)
        //{
        //    string[] confirmValue1 = confirmValue.Split(",");
        //}
        if (confirmValue == "Yes")
        {
            flg = 1;
        }
        else
        {
            flg = 2;
        }
        return flg;
    }
    public void MsgBoxYesNo(string msg, Page strPg)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("alert('");
        sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
        sb.Append("');");
        ScriptManager.RegisterStartupScript(strPg.Page, strPg.GetType(), "showyesno", sb.ToString(), true);

    }
    public void SetFooterTotalsMltpl(GridView gdv, int StcolNo, int EndcolNo)
    {
        if (gdv.Rows.Count > 0)
        {
            gdv.FooterRow.Cells[0].Text = "Total";
            for (int i = StcolNo; i <= EndcolNo; i++)
            {
                gdv.FooterRow.Cells[i].Text = FindGridTotal(gdv, i).ToString();
                gdv.FooterRow.Font.Bold = true;
                gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
                gdv.FooterRow.ForeColor = System.Drawing.Color.White;
                gdv.FooterRow.Cells[i].HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
    public void SetFooterTotals(GridView gdv, int colNo)
    {
        if (gdv.Rows.Count > 0)
        {
            gdv.FooterRow.Cells[0].Text = "Total";
            gdv.FooterRow.Cells[colNo].Text = FindGridTotal(gdv, colNo).ToString();
            gdv.FooterRow.Font.Bold = true;
            gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
            gdv.FooterRow.ForeColor = System.Drawing.Color.White;
            gdv.FooterRow.Cells[colNo].HorizontalAlign = HorizontalAlign.Right;
            gdv.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    public void SetFooterTotalsTempField(GridView gdv, int colNo, string strCol, int intCtrlTp)
    {
        if (gdv.Rows.Count > 0)
        {
            gdv.FooterRow.Cells[0].Text = "Total";
            gdv.FooterRow.Cells[colNo].Text = FindGridTotalTempField(gdv, colNo, strCol, intCtrlTp).ToString();
            gdv.FooterRow.Font.Bold = true;
            gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
            gdv.FooterRow.ForeColor = System.Drawing.Color.White;
            gdv.FooterRow.Cells[colNo].HorizontalAlign = HorizontalAlign.Right;
            gdv.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
   
    public void SetFooterTotalsTempFieldMltpl(GridView gdv, int colStNo, int colEndNo, ArrayList arStrCol, int intCtrlTp)
    {
        if (gdv.Rows.Count > 0)
        {
            for (int i = colStNo; i <= colEndNo; i++)
            {
                string strCol = arStrCol[i -colStNo].ToString();
                
                gdv.FooterRow.Cells[0].Text = "Total";
                gdv.FooterRow.Cells[i].Text = FindGridTotalTempField(gdv, i, strCol, intCtrlTp).ToString();
                gdv.FooterRow.Font.Bold = true;
                gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
                gdv.FooterRow.ForeColor = System.Drawing.Color.White;
                gdv.FooterRow.Cells[i].HorizontalAlign = HorizontalAlign.Right;
                gdv.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }
    }
    public void SetFooterTotalsGray(GridView gdv, int colNo)
    {
        if (gdv.Rows.Count > 0)
        {
            gdv.FooterRow.Cells[0].Text = "Total";
            gdv.FooterRow.Cells[colNo].Text = FindGridTotal(gdv, colNo).ToString();
            gdv.FooterRow.Font.Bold = true;
            gdv.FooterStyle.BackColor = System.Drawing.Color.Gray;
            gdv.FooterRow.ForeColor = System.Drawing.Color.White;
            gdv.FooterRow.Cells[colNo].HorizontalAlign = HorizontalAlign.Right;
            gdv.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    public void SetFooterTotalsTempFieldGray(GridView gdv, int colNo, string strCol, int intCtrlTp)
    {
        if (gdv.Rows.Count > 0)
        {
            gdv.FooterRow.Cells[0].Text = "Total";
            gdv.FooterRow.Cells[colNo].Text = FindGridTotalTempField(gdv, colNo, strCol, intCtrlTp).ToString();
            gdv.FooterRow.Font.Bold = true;
            //gdv.FooterStyle.BackColor = System.Drawing.Color.DodgerBlue;
            //#507CD1
            gdv.FooterStyle.BackColor = System.Drawing.Color.Gray;
            gdv.FooterRow.ForeColor = System.Drawing.Color.White;
            gdv.FooterRow.Cells[colNo].HorizontalAlign = HorizontalAlign.Right;
            gdv.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    public double FindGridTotal(GridView gdv, int colNo)
    {
        double totAmt = 0;
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            if (gdv.Rows[i].Cells[colNo].Text != "&nbsp;" && gdv.Rows[i].Cells[colNo].Text != "")
            {
                totAmt = totAmt + Convert.ToDouble(gdv.Rows[i].Cells[colNo].Text);
            }
        }
        return totAmt;
    }
    public void  HeighlightRow(GridView gdv, int rwNo,int colNo)
    {
        //for (int i = 0; i < gdv.Rows.Count; i++)
        //{

        //}
        gdv.Rows[rwNo].Cells[colNo].ForeColor = System.Drawing.Color.Red;
        gdv.Rows[rwNo].Cells[colNo].Font.Bold = true;
    }
    public double FindGridTotalTempField(GridView gdv, int colNo, string strCol, int intCtrlTp)
    {
        double totAmt = 0;
        for (int i = 0; i < gdv.Rows.Count; i++)
        {
            GridViewRow gvr = gdv.Rows[i];
            if (intCtrlTp == 1)
            {
                TextBox txt1 = (TextBox)gvr.FindControl(strCol);
                if (txt1.Text != "&nbsp;" && txt1.Text != "")
                {
                    totAmt = totAmt + Convert.ToDouble(txt1.Text);
                }
            }
            else
            {
                Label txt1 = (Label)gvr.FindControl(strCol);
                if (txt1.Text != "&nbsp;" && txt1.Text != "")
                {
                    totAmt = totAmt + Convert.ToDouble(txt1.Text);
                }
            }
        }
        return totAmt;
    }

    public void CreateServiceTransaction(double NumTrnID, string fileNo, double intaccno, int lbId, string appDt, int inwdNo)
    {
        DataSet ds = new DataSet();
        ArrayList ArrIn = new ArrayList();
        ArrIn.Add(NumTrnID);
        ArrIn.Add(fileNo);
        ArrIn.Add(intaccno);
        ArrIn.Add(lbId);
        ArrIn.Add(intTrnType);
        ArrIn.Add(appDt);
        ArrIn.Add(intUserId);
        ArrIn.Add(inwdNo);
        ds = genDaoKP.CreateServiceTransaction(ArrIn);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            numServiceTrnID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }

    //////////////////////////////18/03/2013//////////////////////

    //public Boolean ValidateFieldsTA(DropDownList ddl, TextBox Ta2, TextBox Ta3, Label lbl)
    //{
    //    lbl.Visible = false;
    //    bool Valid;
    //    Valid = false;
    //    if (Convert.ToInt16(ddl.SelectedItem.Value.ToString()) <= 0)
    //    {
    //        SetMsgBox(24, lbl);
    //    }
    //    else if (Ta2.Text.Trim() == "")
    //    {
    //        SetMsgBox(23, lbl);
    //    }
    //    else if (Ta2.Text.Trim() != "")
    //        if (Convert.ToDouble(Ta2.Text) > FltMaxAdmsblTA)
    //        {
    //            SetMsgBox(21, lbl);
    //        }
    //        else if (Ta3.Text.Trim() == "")
    //        {
    //            SetMsgBox(23, lbl);
    //        }
    //        else if (Ta3.Text.Trim() != "")
    //        {
    //            if (Convert.ToInt16(Ta3.Text) < 12 || Convert.ToInt16(Ta3.Text) > 36)
    //            {
    //                SetMsgBox(25, lbl);
    //            }
    //            else
    //            {
    //                Valid = true;
    //            }
    //        }
    //        else
    //        {
    //            SetMsgBox(100, lbl);
    //            Valid = true;
    //        }
    //    return Valid;

    //}


    //public Boolean ValidateBasicDet(int inwrd, string empid, Label LblMsg, Button btn)
    //{
    //    Boolean valid;
    //    valid = true;
    //    //btn.Enabled = true;
    //    if (inwrd == 0)
    //    {
    //        LblMsg.Visible = true;
    //        //LblMsg.Text = "Enter inward No. ";
    //        flgMsg = "Enter inward No. ";
    //        valid = false;
    //        //btn.Enabled = false;
    //        //SetMsgBox(1, flgMsg);
    //    }
    //    else if (empid == "")
    //    {
    //        LblMsg.Visible = true;
    //        //LblMsg.Text = "Enter the Account No. ";
    //        flgMsg = "Enter the Account No. ";
    //        valid = false;
    //        //btn.Enabled = false;
    //    }
    //    else
    //    {
    //        LblMsg.Visible = false;
    //        LblMsg.Text = "";
    //        valid = true;
    //        //btn.Enabled = true;
    //    }

    //    return valid;
    //}


    //public string SetMsgBox(int flgType, Label lbl)
    //{

    //    lbl.Visible = true;
    //    if (flgType == 101)
    //    {
    //        lbl.Text = "Enter inward no. and account no.";
    //    }
    //    else if (flgType == 102)
    //    {
    //        lbl.Text = "Enter inward no.";
    //    }
    //    else if (flgType == 103)
    //    {
    //        lbl.Text = "Invalid account no.";
    //    }
    //    else if (flgType == 104)
    //    {
    //        lbl.Text = "Duplicate inward no.";
    //    }
    //    else if (flgType == 21)
    //    {
    //        lbl.Text = "Entered amount exeeds eligible amount.";
    //    }
    //    else if (flgType == 22)
    //    {
    //        lbl.Text = "Number of instalments should be between 12 and 36";
    //    }
    //    else if (flgType == 23)
    //    {
    //        lbl.Text = "Enter amount";
    //    }
    //    else if (flgType == 24)
    //    {
    //        lbl.Text = "Select reason";
    //    }
    //    else if (flgType == 25)
    //    {
    //        lbl.Text = "Number of instalments should be between 12 and 36";
    //    }
    //    else if (flgType == 26)
    //    {
    //        lbl.Text = "Employee is not eligible for TA since the calculated PF credit is nil";
    //    }
    //    else if (flgType == 27)
    //    {
    //        lbl.Text = "Employee is not eligible for TA since the minimum gap of 6 months after the date of the previous loan was cashed";
    //    }
    //    else if (flgType == 28)
    //    {
    //        lbl.Text = "Employee is not eligible for TA since the retirement date is within one year";
    //    }
    //    else if (flgType == 29)
    //    {
    //        lbl.Text = "You do not have the right to process the request of employees belongs to another School";
    //    }
    //    else if (flgType == 61)
    //    {
    //        lbl.Text = "Can only twice in a year!";
    //    }
    //    else if (flgType == 62)
    //    {
    //        lbl.Text = "Can only twice in a year!";
    //    }
    //    else if (flgType == 200)
    //    {
    //        lbl.Text = "Successfuly saved";


    //    }
    //    else if (flgType == 201)
    //    {
    //        lbl.Text = "Approved";
    //    }
    //    else if (flgType == 202)
    //    {
    //        lbl.Text = "Rejected";
    //    }
    //    else if (flgType == 100)
    //    {
    //        lbl.Text = "";
    //    }
    //    return lbl.Text;
    //}
    //public void ClearGlobalsSerDet()
    //{
    //    sertrnid = 0;

    //    strRptName = "";
    //    strRptParamArr = "";
    //    intParamCnt = 0;
    //    intMsgEmp = 0;
    //    intMsgInw = 0;

    //}

    /////////////////////18/03/2013/////////////////////

    public long CreateServiceTransaction(ArrayList ArrIn)
    {
        DataSet ds = new DataSet();
        ds = GenDAOObj.CreateServiceTransaction(ArrIn);
        if (ds.Tables[0].Rows.Count > 0)
        {
            numServiceTrnID = Convert.ToInt64(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }
        return numServiceTrnID;
    }
    public void UppdApproval(int TrnType, long SerTrnId, int flgApp, int intUserId, string chvRem)
    {
        appObj.IntTrnTypeID = TrnType;
        appObj.NumTrnID = SerTrnId;
        appObj.FlgApproval = flgApp;
        appObj.IntUserId = intUserId;
        appObj.ChvRem = chvRem;
        appDobj.CreateApproval(appObj);
    }
    public void UppdApprovalTrnType(int OldTrnType, int NewTrnType, long SerTrnId, int intUserId)
    {
        ArrayList ar = new ArrayList();
        ar.Add(OldTrnType);
        ar.Add(NewTrnType);
        ar.Add(SerTrnId);
        ar.Add(intUserId);
        appDobj.UpdateApproval(ar);
    }
    public void FillFileNo(TextBox txtInwNo, Label txtFileNo, string strFileNo, Page strPg, int intLB)
    {
        txtFileNo.Text = "";
        //txtAppDate.Text = "";
        if (txtInwNo.Text != "")
        {
            ArrayList ArrIn = new ArrayList();
            DataSet ds = new DataSet();
            ArrIn.Add(Convert.ToInt16(intLB));
            ArrIn.Add(Convert.ToInt32(txtInwNo.Text));
            ds = genDao.CheckDuplicateInwardNo(ArrIn);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MsgBoxOk("Duplicate inward No.", strPg);
                txtInwNo.Text = "";
                txtFileNo.Text = "";
            }
            else
            {
                txtFileNo.Text = strFileNo + "/" + txtInwNo.Text + "/" + intLB + "/" + DateTime.Now.Year.ToString();
            }
        }
        else
        {
            MsgBoxOk("Enter inward No.", strPg);
        }
    }
    public void FillFileNo(TextBox txtInwNo, Label txtFileNo, string strFileNo, Page strPg)
    {
        txtFileNo.Text = "";
        //txtAppDate.Text = "";
        if (txtInwNo.Text != "")
        {
            ArrayList ArrIn = new ArrayList();
            DataSet ds = new DataSet();
            ArrIn.Add(Convert.ToInt16(IntLBId));
            ArrIn.Add(Convert.ToInt16(txtInwNo.Text));
            ds = genDao.CheckDuplicateInwardNo(ArrIn);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MsgBoxOk("Duplicate inward No.", strPg);
                txtInwNo.Text = "";
                txtFileNo.Text = "";
            }
            else
            {
                //txtFileNo.Text = strFileNo + "/" + txtInwNo.Text + "/" + intLBId + "/" + DateTime.Now.Year.ToString();

                txtFileNo.Text = strFileNo + "/" + txtInwNo.Text + "/" + HttpContext.Current.Session["intLBID"].ToString() + "/" + DateTime.Now.Year.ToString();
            }
        }
        else
        {
            MsgBoxOk("Enter inward No.", strPg);
        }
    }
    public Boolean CheckDate3(string dt1, string dt2, string dt3)
    {
        Boolean flg = true;
        DateTime Dtdt1;
        DateTime Dtdt2;
        DateTime Dtdt3;

        Dtdt1 = Convert.ToDateTime(dt1);
        Dtdt2 = Convert.ToDateTime(dt2);
        Dtdt3 = Convert.ToDateTime(dt3);
        if (Dtdt1 < Dtdt2 && Dtdt2 < Dtdt3)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public Boolean CheckDate2(string dt1, string dt2)
    {
        Boolean flg = true;
        DateTime Dtdt1;
        DateTime Dtdt2;

        Dtdt1 = Convert.ToDateTime(dt1);
        Dtdt2 = Convert.ToDateTime(dt2);
        if (Dtdt1 <= Dtdt2)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    public string GenerateStartDate(string yr, int mth)
    {
        //string strDt;
        //string yrP = "";
        ////yrP = substring - before("1999/04/01", "2");
        
        //yrP = yr.Substring(0, 4);
        //strDt = "01/" + mth + "/" + yrP;

        //return strDt;

        string strDt;
        string yrP = "";
        //yrP = substring - before("1999/04/01", "2");
        if (mth < 4)
        {
            yrP = "20" + yr.Substring(5, 2);
        }
        else
        {
            yrP = yr.Substring(0, 4);
        }
        strDt = "01/" + mth + "/" + yrP;

        return strDt;
    }
    public Boolean CheckChalanDate(TextBox txt, DropDownList ddlY, DropDownList ddlM)
    {

        Boolean flg = true;
        if (txt.Text.ToString() != "")
        {
            string dt1 = txt.Text.ToString();
            string dt2 = DateTime.Now.ToString();
            if (CheckDate2(dt1, dt2) == false)
            {
                flg = false;
            }
            else
            {
                if (CheckDate2(GenerateStartDate(Convert.ToString(ddlY.SelectedItem), Convert.ToInt16(ddlM.SelectedValue)), dt1) == false)
                {
                    flg = false;
                }
                else
                {
                    flg = true;
                }
            }
            if (flg == false)
            {
                txt.Text = "";
            }
        }
        else
        {
            flg = false;
        }
        return flg;

    }
    public Boolean CheckChalanDateAg(TextBox txt, string strDt)
    {
        Boolean flg = true;
        string dt1 = txt.Text.ToString();
        string dt2 = strDt.ToString();
        string dt3 = DateTime.Now.ToString();
        if (CheckDate2(dt1, dt2) == true)
        {
            if (CheckDate2(dt1, dt3) == true)
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
        if (flg == false)
        {
            txt.Text = "";
        }
        return flg;
    }

    public Boolean CheckChalanDate(TextBox txt, int yr, int mth)
    {
        Boolean flg = false;
        if (txt.Text.ToString() != "")
        {
            DateTime dt1 = Convert.ToDateTime(txt.Text);
            ArrayList ar = new ArrayList();
            ar.Add(dt1);
            int yrDt = genDaoKP.gFunFindYearIdFromDate(ar);
            int mthDt = dt1.Month;
            if (yrDt >= yr && mthDt >= mth) //// Validation changed from == to >= as per the direction from AO,KPEPF
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
    public Boolean CheckWithDate(DateTime dt1, int yr, int mth)
    {
        Boolean flg = false;
        if (dt1.ToString() != "")
        {
            //DateTime dt1 = Convert.ToDateTime(txt.Text);
            ArrayList ar = new ArrayList();
            ar.Add(dt1);
            int yrDt = genDaoKP.gFunFindYearIdFromDate(ar);
            int mthDt = dt1.Month;
            if (yrDt <= yr || mthDt <= mth)
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
    public Boolean CheckDateInBetween(TextBox txt, string strDt)
    {
        Boolean flg = true;
        string dt1 = txt.Text.ToString();
        string dt2 = strDt.ToString();
        string dt3 = DateTime.Now.ToString();
        if (CheckDate2(dt2, dt1) == true)
        {
            if (CheckDate2(dt1, dt3) == true)
            {
                flg = true;
            }
            else
            {
                flg = false ;
            }
        }
        else
        {
            flg = false;
        }
        if (flg == false)
        {
            txt.Text = "";
        }
        return flg;
    }
    public Boolean CheckAppDate(TextBox txt,Page pg)
    {
        Boolean flg = true;
        string dt1 = txt.Text.ToString();
        string dt2 = DateTime.Now.ToString();
        if (isValidDate(txt, pg) == true)
        {
            if (CheckDate2(dt1, dt2) == false)
            {
                flg = false;
            }
            else
            {
                if (CheckDate2("01/04/2014",Convert.ToString(txt.Text)) == false)
                {
                    flg = false;
                    txt.Text = "";
                }
                else
                {
                    flg = true;
                }
            }
            if (flg == false)
            {
                txt.Text = "";
            }
        }
        else
        {
            flg = false;
            txt.Text = "";
        }
        return flg;
    }
    public Boolean isValidDate(TextBox txt, Page strPg)
    {
        //bool Success;
        //try
        //{
        //    DateTime dtParse = DateTime.Parse(txt.Text);
        //    Success = true; // If this line is reached, no exception was thrown
        //}
        //catch (FormatException e)
        //{
        //    string s = e.Message;
        //    Success = false; // If this line is reached, an exception was thrown
        //    MsgBoxOk("Invalid Date!", strPg);
        //}
        //return Success;

        bool Success;
        try
        {
            DateTime dtParse = DateTime.Parse(txt.Text);
            Success = true; // If this line is reached, no exception was thrown
        }
        catch (FormatException e)
        {
            string s = e.Message;
            Success = false; // If this line is reached, an exception was thrown
            MsgBoxOk("Invalid Date!", strPg);
        }
        return Success;
    }
    public bool WhetherLBMatch(double numEmpId, int intLBID)
    {
        bool flg = false;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(numEmpId);
        ar.Add(intLBID);
        ds = empDoa.WhetherMatchLB(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
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
    public void SaveToReturnedFiles(Int64 numTrnId, int intType, int TrnLBTp, int RejLBTp, int RejUserTp, int RejUserId)
    {
        ArrayList ar = new ArrayList();
        ar.Add(numTrnId);
        ar.Add(intType);
        ar.Add(TrnLBTp);
        ar.Add(RejLBTp);
        ar.Add(RejUserTp);
        ar.Add(RejUserId);
        appDobj.SaveReturnedFiles(ar);
    }
    public int FindTrnLBTp(Int64 intId)
    {
        int i;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intId);
        ds = appDobj.GetTrnLBType(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            i = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            i = 0;
        }
        return i;
    }
    public int FindTrnLBTpForMS(Int64 intId)
    {
        int i;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intId);
        ds = appDobj.GetTrnLBTypeForMS(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            i = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
        }
        else
        {
            i = 0;
        }
        return i;
    }


    public int FindTrnDist(Int64 intId)
    {
        int i;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intId);
        ds = appDobj.GetTrnLBType(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            i = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[1]);
        }
        else
        {
            i = 0;
        }
        return i;
    }
    public int FindTrnLB(Int64 intId)
    {
        int i;
        ArrayList ar = new ArrayList();
        DataSet ds = new DataSet();
        ar.Add(intId);
        ds = appDobj.GetTrnLBType(ar);
        if (ds.Tables[0].Rows.Count > 0)
        {
            i = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[2]);
        }
        else
        {
            i = 0;
        }
        return i;
    }
    public void ClearReturnedFiles(ArrayList ar)
    {
        DataSet ds = new DataSet();
        ds = genDao.ClearRetrnFiles(ar);
    }
    public void UpdateArrearToCredit()
    {
        ArrayList arr = new ArrayList();
        arr.Add(numEmpId);
        empDoa.UpdateArrearToCredit(arr);
    }
    public bool checkLastRowStatus(List<Control> myControls, ArrayList arrControlid, GridView gdView)
    {
        bool chkLast = true;
        int rowCount = gdView.Rows.Count - 1;
        int controlid = 0;
        foreach (Control control in myControls)
        {

            if (control is TextBox)
            {
                TextBox txt = (TextBox)gdView.Rows[rowCount].FindControl(arrControlid[controlid].ToString());
                if (txt.Text.ToString().Trim() == "")
                {
                    chkLast = false;
                }
                else
                {
                    chkLast = true;
                }
            }
            else if (control is DropDownList)
            {
                DropDownList ddlDummy = (DropDownList)gdView.Rows[rowCount].FindControl(arrControlid[controlid].ToString());
                if (ddlDummy.SelectedValue.ToString() == "")
                {
                    chkLast = false;
                }
                else
                {
                    chkLast = true;
                }
            }
            else if (control is Label )
            {
                Label lbl = (Label)gdView.Rows[rowCount].FindControl(arrControlid[controlid].ToString());
                if (lbl.Text.ToString() == "")
                {
                    chkLast = false;
                }
                else
                {
                    chkLast = true;
                }
            }
            controlid += 1;
        }
        return chkLast;
    }
    public DataTable SetInitialRow(GridView gv)
    {
        int columnCount;
        columnCount = gv.Columns.Count - 1;
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SlNo", typeof(string)));
        for (int i = 1; i <= columnCount; i++)
        {
            dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
        }
        dr = dt.NewRow();
        dr["SlNo"] = 1;
        for (int i = 1; i < columnCount; i++)
        {
            dr["Column" + i] = string.Empty;
        }
        dt.Rows.Add(dr);
        gv.DataSource = dt;
        gv.DataBind();
        return dt;
    }
    public DataTable AddNewRowToGrid(DataTable dt, GridView gv, ArrayList arrIN)
    {
        int rowIndex = 0;
        DataTable dtCurrentTable = dt;
        DataRow drCurrentRow = null;
        if (dtCurrentTable.Rows.Count > 0)
        {
            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["SlNo"] = i;
                for (int j = 1; j < dt.Columns.Count - 1; j++)
                {
                    if (arrIN[j - 1].ToString().Substring(0, 3) == "txt")
                    {
                        TextBox box1 = (TextBox)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                        if (box1.Text == "")
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = DBNull.Value;
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = box1.Text;
                        }
                    }
                    else if (arrIN[j - 1].ToString().Substring(0, 3) == "ddl")
                    {
                        DropDownList drop = (DropDownList)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                        dtCurrentTable.Rows[i - 1]["Column" + j] = drop.SelectedValue;
                    }
                    else if (arrIN[j - 1].ToString().Substring(0, 3) == "lbl")
                    {
                        Label lbl = (Label)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                        if (lbl.Text == "")
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = DBNull.Value;
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = lbl.Text;
                        }
                    }
                    else if (arrIN[j - 1].ToString().Substring(0, 3) == "chk")
                    {
                        CheckBox chk = (CheckBox)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                        if (chk.Checked == true)
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = true;
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["Column" + j] = false;
                        }
                    }
                }
                rowIndex++;
            }
            dtCurrentTable.Rows.Add(drCurrentRow);
            gv.DataSource = dtCurrentTable;
            gv.DataBind();
            rowIndex = 0;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i <= dtCurrentTable.Rows.Count - 1; i++)
                {
                    gv.Rows[i].Cells[0].Text = (i + 1).ToString();
                    for (int j = 1; j < dtCurrentTable.Columns.Count - 1; j++)
                    {
                        if (arrIN[j - 1].ToString().Substring(0, 3) == "txt")
                        {
                            TextBox box = (TextBox)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                            box.Text = dtCurrentTable.Rows[i]["Column" + j].ToString();
                        }
                        else if (arrIN[j - 1].ToString().Substring(0, 3) == "ddl")
                        {
                            DropDownList drop = (DropDownList)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                            drop.SelectedValue = dtCurrentTable.Rows[i]["Column" + j].ToString();
                        }
                        else if (arrIN[j - 1].ToString().Substring(0, 3) == "lbl")
                        {
                            Label lbl = (Label)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                            lbl.Text = dtCurrentTable.Rows[i]["Column" + j].ToString();
                        }
                        else if (arrIN[j - 1].ToString().Substring(0, 3) == "chk")
                        {
                            CheckBox chk = (CheckBox)gv.Rows[rowIndex].Cells[j - 1].FindControl(arrIN[j - 1].ToString());
                            if (dtCurrentTable.Rows[i]["Column" + j].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtCurrentTable.Rows[i]["Column" + j]) == true)
                                {
                                    chk.Checked = true;
                                }
                                else if (Convert.ToBoolean(dtCurrentTable.Rows[i]["Column" + j]) == false)
                                {
                                    chk.Checked = false;
                                }
                            }
                        }
                    }
                    rowIndex++;
                }
            }
        }
        return dtCurrentTable;
    }
    public void setFocus(Control ctrl, Page pg)
    {
        ScriptManager sm = ScriptManager.GetCurrent(pg);
        sm.SetFocus(ctrl);
    }
    public DataTable SetGridTableRows(GridView gdv, int cnt)
    {
        int columnCount;
        columnCount = gdv.Columns.Count - 1;
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SlNo", typeof(string)));
        for (int i = 1; i <= columnCount; i++)
        {
            dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
        }
        for (int i = 0; i < cnt; i++)
        {
            dr = dt.NewRow();
            dr["SlNo"] = i + 1;
            for (int j = 1; j < columnCount; j++)
            {
                dr["Column" + j] = string.Empty;
            }
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
        return dt;
    }
    //public bool SentSMS(string s)
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
    public double RateOfInterest(int yrId)
    {
        double dblIntRate = 0;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(yrId);
        ds = genDao.Interest(arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dblIntRate = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1]);
        }
        return dblIntRate;
    }
    //public double RateOfInterestPart(int yrId,int slno)
    //{
    //    double dblIntRate = 0;
    //    DataSet ds = new DataSet();
    //    ds = genDao.GetDet4MltplRt(yrId, slno);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        dblIntRate = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1]);
    //    }
    //    return dblIntRate;
    //}
    public double CalculateAmtToCalc(int yrIdSt, double amt)
    {
        //  Dim intBalMth As Integer
        //  Dim fltAmtToSave As Double
        //  intBalMth = Abs(intOldBalMonths - intNewBalMonths)
        //  dblIntRt = gFunInterestRate(gintYearId, con)
        //  fltAmtToSave = Round(OrgAmt * intBalMth * dblIntRt / 1200)
        //  lFunFindFltAmt = fltAmtToSave

        double dblIntRate = 0;
        double dblAmtToCalc = 0;
        dblIntRate = RateOfInterest(yrIdSt);
        dblAmtToCalc = amt * dblIntRate / 1200;
        return dblAmtToCalc;
    }
    public double CalculateAmtToCalcMltplMth(int yrIdSt, double amt, int cntMth)
    {
        //  Dim intBalMth As Integer
        //  Dim fltAmtToSave As Double
        //  intBalMth = Abs(intOldBalMonths - intNewBalMonths)
        //  dblIntRt = gFunInterestRate(gintYearId, con)
        //  fltAmtToSave = Round(OrgAmt * intBalMth * dblIntRt / 1200)
        //  lFunFindFltAmt = fltAmtToSave

        double dblIntRate = 0;
        double dblAmtToCalc = 0;
        dblIntRate = RateOfInterest(yrIdSt);
        dblAmtToCalc = amt * dblIntRate / 1200;
        return dblAmtToCalc;
    }
    public double CalculateAdjAmt3(int yrIdSt, int yrIdEnd, int mthSt, int dySt, double amt)
    {
        int balMonth = 0;
        int cntIntChgd = 0;
        double CalcAmt = amt;
        double dblIntRate = 0;
        int mthCal = 0;
        for (int i = yrIdSt; i <= yrIdEnd; i++)
        {
            cntIntChgd = genDao.NoOfTimesIntRtChgd(i);
            if (cntIntChgd == 1)
            {
                dblIntRate = RateOfInterest(i);
                if (i == yrIdSt)
                {
                    balMonth = genDao.GetBalanceMonth(mthSt, dySt);
                    CalcAmt = Math.Round(CalcAmt + (CalcAmt * balMonth * dblIntRate / 1200));
                }
                else
                {
                    CalcAmt = Math.Round(CalcAmt + (CalcAmt * dblIntRate / 100));
                }
            }
            else
            {
                if (i == yrIdSt)
                {
                    mthCal = getMonthCal(mthSt, dySt);
                }
                else
                {
                    mthCal = 1;
                }
                //CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRtStYr3(i, CalcAmt, mthCal));                 // to check
                CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRtStYr3(i, CalcAmt, mthCal));                 // to check
            }
        }
        return CalcAmt;
    }
    private int getMonthCal(int mthSt, int dySt)
    {
        int monthOrg = 0;
        ArrayList arm = new ArrayList();
        DataSet dsm = new DataSet();
        arm.Add(mthSt);
        //arm.Add(dySt);
        dsm = genDaoKP.CheckMonth(arm);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            monthOrg = Convert.ToInt16(dsm.Tables[0].Rows[0].ItemArray[0]);
        }
        if (dySt > 4)
        {
            monthOrg = monthOrg + 1;
        }
        return monthOrg;
    }
    public double CalcAmtForMltplRtStYr3(int yr, double amt, int mthCal)
    {
        double dblPartAmt = 0;
        double dblTotAmt = 0;
        int balMth = 0;

        DataSet dsRt = new DataSet();
        dsRt = genDao.FindNoOfMonthsNew(yr);
        if (dsRt.Tables[0].Rows.Count > 0)
        {
            int chgCnt = dsRt.Tables[0].Rows.Count;
            for (int j = 0; j < chgCnt; j++)
            {
                balMth = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[5]) - mthCal + 1;
                if (balMth > 0)
                {
                    dblPartAmt = Math.Round(amt * balMth * Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]) / 1200);
                    //dblPartAmt = amt * balMth * Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]) / 1200;
                    dblTotAmt = dblTotAmt + dblPartAmt;
                    mthCal = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[5]) + 1;
                }
            }
        }
        return dblTotAmt;
    }
    public double CalculateAdjAmtDtUpd(int yrIdSt, int yrIdEnd, int mthSt, int dySt, double amt, int intEditMode)
    {
        double CalcAmt = 0;
        double CalcAmt1 = 0;
        double CalcAmt2 = 0;
        CalcAmt1 = CalculateAdjAmt(yrIdSt, yrIdEnd, mthSt, 1, amt);
        CalcAmt2 = CalculateAdjAmt(yrIdSt, yrIdEnd, mthSt, 5, amt);
        if (intEditMode == 1)
        {       
            CalcAmt = CalcAmt1 - CalcAmt2;
        }
        else if (intEditMode == 2)
        {
            CalcAmt = CalcAmt2 - CalcAmt1;
        }
        return CalcAmt;
    }
    public double CalculateAdjAmtDtUpdLat(int yrIdSt1, int yrIdSt2, int yrIdEnd, int mth1, int mth2, int dy1, int dy2, double amt, int intEditMode)
    {
        double CalcAmt = 0;
        double CalcAmt1 = 0;
        double CalcAmt2 = 0;
        CalcAmt1 = CalculateAdjAmt(yrIdSt1, yrIdEnd, mth1, dy1, amt);
        CalcAmt2 = CalculateAdjAmt(yrIdSt2, yrIdEnd, mth2, dy2, amt);
        //if (intEditMode == 2)
        //{
        //    CalcAmt = CalcAmt1 - CalcAmt2;
        //}
        //else if (intEditMode == 1)
        //{
        //    CalcAmt = CalcAmt2 - CalcAmt1;
        //}
        CalcAmt = CalcAmt2 - CalcAmt1;
        return CalcAmt;
    }
    public double CalculateAdjAmt(int yrIdSt, int yrIdEnd, int mthSt, int dySt, double amt)
    {
        int balMonth = 0;
        int cntIntChgd = 0;
        double CalcAmt = amt;
        double dblIntRate = 0;
        for (int i = yrIdSt; i <= yrIdEnd; i++)
        {
            cntIntChgd = genDao.NoOfTimesIntRtChgd(i);
            if (cntIntChgd == 1)
            {
                dblIntRate = RateOfInterest(i);
                if (i == yrIdSt)
                {
                    balMonth = genDao.GetBalanceMonth(mthSt, dySt);
                    CalcAmt = Math.Round(CalcAmt + (CalcAmt * balMonth * dblIntRate / 1200));
                }
                else
                {
                    CalcAmt = Math.Round(CalcAmt + (CalcAmt * dblIntRate / 100));
                }
            }
            else
            {
                if (i == yrIdSt)
                {
                    balMonth = genDao.GetBalanceMonth(mthSt, dySt);
                    CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRtStYr(i, CalcAmt, balMonth));                 // to check
                }
                else
                {
                    CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRt(i, CalcAmt));
                   // CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRt(i, CalcAmt));
                }
            }
        }
        return CalcAmt;
    }
    public double CalcAmtForMltplRtStYr(int yr, double amt, int balMth)
    {
        int cntMthPart = 0;
        double RtInt = 0;
        double dblPartAmt = 0;
        double dblTotAmt = 0;
        int balMthRange = 0;

        DataSet dsRt = new DataSet();
        dsRt = genDao.FindNoOfMonthsNew(yr);
        balMthRange = Convert.ToInt16(dsRt.Tables[0].Rows[1].ItemArray[5]) - Convert.ToInt16(dsRt.Tables[0].Rows[1].ItemArray[4]) + 1;

        if (balMth <= balMthRange)
        {
            dblPartAmt = Math.Round(amt * balMth * Convert.ToDouble(dsRt.Tables[0].Rows[1].ItemArray[1]) / 1200);
            dblTotAmt = dblTotAmt + dblPartAmt;
        }
        else
        {
            for (int i = 1; i <= 2; i++)
            {
                if (i == 1)
                {
                    cntMthPart = balMth - balMthRange;
                    RtInt = Convert.ToDouble(dsRt.Tables[0].Rows[0].ItemArray[1]);
                }
                else
                {
                    cntMthPart = Convert.ToInt16(dsRt.Tables[0].Rows[1].ItemArray[0]);
                    RtInt = Convert.ToDouble(dsRt.Tables[0].Rows[1].ItemArray[1]);
                }
                dblPartAmt = amt * cntMthPart * RtInt / 1200;
                dblTotAmt = Math.Round(dblTotAmt + dblPartAmt);
            }
        }
        return dblTotAmt;
    }
    public double CalcAmtForMltplRt(int yr, double amt)
    {
        int cntMthPart = 0;
        double RtInt = 0;
        double dblPartAmt = 0;
        double dblTotAmt = 0;
        DataSet dsRt = new DataSet();
        dsRt = genDao.FindNoOfMonthsNew(yr);
        if (dsRt.Tables[0].Rows.Count > 0)
        {
            int chgCnt = dsRt.Tables[0].Rows.Count ;
            for (int j = 0; j < chgCnt; j++)
            {
                cntMthPart = Convert.ToInt16(dsRt.Tables[0].Rows[j].ItemArray[0]);
                RtInt = Convert.ToDouble(dsRt.Tables[0].Rows[j].ItemArray[1]);
                dblPartAmt = amt * cntMthPart * RtInt / 1200;
               // dblTotAmt = dblTotAmt + dblPartAmt;
                dblTotAmt = dblTotAmt + Math.Round(dblPartAmt);
            }
        }
        return dblTotAmt;
        
    }

    //public double CalculateAdjAmt(int yrIdSt, int yrIdEnd, int mthSt, int dySt, double amt)
    //{
    //    int balMonth = 0;
    //    int cntIntChgd = 0;
    //    double CalcAmt = amt;
    //    double dblIntRate = 0;
    //    for (int i = yrIdSt; i <= yrIdEnd; i++)
    //    {
    //        cntIntChgd = genDao.NoOfTimesIntRtChgd(i);
    //        if (cntIntChgd == 1)
    //        {
    //            dblIntRate = RateOfInterest(i);
    //            if (i == yrIdSt)
    //            {
    //                balMonth = genDao.GetBalanceMonth(mthSt, dySt);
    //                CalcAmt = Math.Round(CalcAmt + (CalcAmt * balMonth * dblIntRate / 1200));
    //            }
    //            else
    //            {
    //                CalcAmt = Math.Round(CalcAmt + (CalcAmt * dblIntRate / 100));
    //            }
    //        }
    //        else
    //        {
    //            CalcAmt = Math.Round(CalcAmt + CalcAmtForMltplRt(i, CalcAmt));
    //        }
    //    }
    //    return CalcAmt;
    //}
    //public double CalcAmtForMltplRt(int yr, double amt)
    //{
    //    int cntMthPart = 0;
    //    double RtInt = 0;
    //    double dblPartAmt = 0;
    //    double dblTotAmt = 0;

    //    for (int i = 1; i <= 2; i++)
    //    {
    //        DataSet ds = new DataSet();
    //        ArrayList arr = new ArrayList();
    //        arr.Add(yr);
    //        arr.Add(i);
    //        ds = genDao.GetInterestMthCnt(arr);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            cntMthPart = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
    //            RtInt = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[1]);
    //            dblPartAmt = Math.Round(amt * cntMthPart * RtInt / 1200);
    //            dblTotAmt = dblTotAmt + dblPartAmt;
    //        }
    //    }
    //    return dblTotAmt;
    //}
    public Boolean CheckNumericOnly(string str, Page strPg)
    {
        Boolean bl;
        int result;
        if (int.TryParse(str.ToString(), out result))
        {
            bl = true;
        }
        else
        {
            bl = false;
            //MsgBoxOk("Enter Numeric Value", strPg);
        }
        return bl;
    }
    public DataTable FirstGridViewRow(ArrayList arrin, GridView gdView, int id)
    {
        DataTable dtgdRow = new DataTable();
        DataRow dr = null;
        for (int i = 0; i < arrin.Count; i++)
        {
            dtgdRow.Columns.Add(new DataColumn(arrin[i].ToString(), typeof(string)));
        }
        dr = dtgdRow.NewRow();
        for (int i = 0; i < arrin.Count; i++)
        {
            if (i == (arrin.Count - 1))
            {
                dr[arrin[i].ToString()] = string.Empty;
            }
            else
            {
                dr[arrin[i].ToString()] = string.Empty;
            }
        }
        dtgdRow.Rows.Add(dr);
        return dtgdRow;
    }
    public DataTable AddNewRow(List<Control> myControls, ArrayList arrControlid, ArrayList arrDT, GridView gdView)
    {
        DataTable dtgdRow = createDataTableStructre(arrDT);
        int id = 0;

        foreach (GridViewRow gvRow in gdView.Rows)
        {
            DataRow dr = null;
            dr = dtgdRow.NewRow();
            int i = 0;
            foreach (Control control in myControls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = txt.Text.ToString();
                }
                else if (control is Label)
                {
                    Label lbl = (Label)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = lbl.Text.ToString();
                    //id = lbl.Text.ToString();
                }
                else if (control is DropDownList)
                {
                    DropDownList ddl = (DropDownList)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = ddl.SelectedValue.ToString();
                    //id = lbl.Text.ToString();
                }
                else if (control is CheckBox)
                {
                    CheckBox chk = (CheckBox)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = chk.Checked;
                   //id = lbl.Text.ToString();
                }
                i += 1;
                id = i;
            }
            dtgdRow.Rows.Add(dr);
        }
        int sl = id + 1;
        DataTable dtblank = FirstGridViewRow(arrDT, gdView, sl);
        dtgdRow.Merge(dtblank);
        return dtgdRow;
    }
    private DataTable createDataTableStructre(ArrayList arrin)
    {
        DataTable dtgdRow = new DataTable();
        for (int i = 0; i < arrin.Count; i++)
        {
            dtgdRow.Columns.Add(new DataColumn(arrin[i].ToString(), typeof(string)));
        }
        return dtgdRow;
    }



    public DataTable deleteRows(List<Control> myControls, ArrayList arrControlid, ArrayList arrDT, GridView gdView)
    {
        DataTable dtgdRow = createDataTableStructre(arrDT);
        DataTable dtgdRownew = createDataTableStructre(arrDT);
        string id = "";
        foreach (GridViewRow gvRow in gdView.Rows)
        {
            DataRow dr = null;
            dr = dtgdRow.NewRow();
            int i = 0;
            foreach (Control control in myControls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = txt.Text.ToString();
                }
                else if (control is Label)
                {
                    Label lbl = (Label)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = lbl.Text.ToString();
                    id = lbl.Text.ToString();
                }
                else if (control is DropDownList)
                {
                    DropDownList ddl = (DropDownList)gvRow.FindControl(arrControlid[i].ToString());
                    dr[arrDT[i].ToString()] = ddl.SelectedValue.ToString();
                    //id = lbl.Text.ToString();
                }
                i += 1;
            }
            dtgdRow.Rows.Add(dr);
        }
        //foreach (DataRow dtr in dtgdRow.Rows)
        //{
        //    if (dtr[headdel] != slid)
        //    {
        //        //dtgdRownew.Rows.Add(dtr.ItemArray);
        //        dtgdRownew.ImportRow(dtr);
        //    }
        //}
        return dtgdRownew;
    }
    //public void CheckValidMonth(int yrid, int mid, Page strPg,TextBox txtAmt)
    //{
    //    //int intCalMthId;
    //    //int intCalMthIdToDay;
    //    //ArrayList ar = new ArrayList();
    //    //ar.Add(DateTime.Now.ToString());
    //    //int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
    //    //int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
    //    //intCalMthId = FindCalMthId(mid);
    //    //intCalMthIdToDay = FindCalMthId(mth);
    //    //if (yrid == yr)
    //    //{
    //    //    if (intCalMthId > intCalMthIdToDay)
    //    //    {
    //    //        MsgBoxOk("Invalid month", strPg);
    //    //        txtAmt.Enabled = false;
    //    //        txtAmt.ReadOnly = true;
    //    //    }
    //    //    else
    //    //    {
    //    //        txtAmt.Enabled = true;
    //    //        txtAmt.ReadOnly = false;
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    MsgBoxOk("Invalid month", strPg);
    //    //    txtAmt.Enabled = false;
    //    //    txtAmt.ReadOnly = true;
    //    //}


    //    int intCalMthId;
    //    int intCalMthIdToDay;
    //    ArrayList ar = new ArrayList();
    //    ar.Add(DateTime.Now.ToString());
    //    int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
    //    int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
    //    intCalMthId = FindCalMthId(mid);
    //    intCalMthIdToDay = FindCalMthId(mth);
    //    if (yrid < yr)
    //    {
    //        ddl.Enabled = true;
    //        btn.Enabled = true;
    //    }
    //    else if (yrid == yr)
    //    {
    //        if (intCalMthId <= intCalMthIdToDay)
    //        {
    //            ddl.Enabled = true;
    //            btn.Enabled = true;
    //        }
    //        else
    //        {
    //            MsgBoxOk("Invalid month", strPg);
    //            ddl.Enabled = false;
    //            btn.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        MsgBoxOk("Invalid month", strPg);
    //        ddl.Enabled = false;
    //    }
    //}
    public void CheckValidMonth(int yrid, int mid, Page strPg, TextBox txtAmt)
    {
        //int intCalMthId;
        //int intCalMthIdToDay;
        //ArrayList ar = new ArrayList();
        //ar.Add(DateTime.Now.ToString());
        //int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        //int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        //intCalMthId = FindCalMthId(mid);
        //intCalMthIdToDay = FindCalMthId(mth);
        //if (yrid == yr)
        //{
        //    if (intCalMthId > intCalMthIdToDay)
        //    {
        //        MsgBoxOk("Invalid month", strPg);
        //        txtAmt.Enabled = false;
        //        txtAmt.ReadOnly = true;
        //    }
        //    else
        //    {
        //        txtAmt.Enabled = true;
        //        txtAmt.ReadOnly = false;
        //    }
        //}
        //else
        //{
        //    MsgBoxOk("Invalid month", strPg);
        //    txtAmt.Enabled = false;
        //    txtAmt.ReadOnly = true;

        //}
        int intCalMthId;
        int intCalMthIdToDay;
        ArrayList ar = new ArrayList();
        ar.Add(DateTime.Now.ToString());
        int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        intCalMthId = FindCalMthId(mid);
        intCalMthIdToDay = FindCalMthId(mth);

        if (yrid < yr)
        {
            //if (intCalMthId <= intCalMthIdToDay)
            //{
            txtAmt.Enabled = true;
            txtAmt.ReadOnly = false;
            //}
            //else
            //{
            //    MsgBoxOk("Invalid month", strPg);
            //    ddl.Enabled = false;
            //    btn.Enabled = false;
            //}
        }
        else if (yrid == yr)
        {
            if (intCalMthId <= intCalMthIdToDay)
            {
                txtAmt.Enabled = true;
                txtAmt.ReadOnly = false;
            }
            else
            {
                MsgBoxOk("Invalid month", strPg);
                txtAmt.Enabled = false;
                txtAmt.ReadOnly = true;
            }
        }
        else
        {
            MsgBoxOk("Invalid month", strPg);
            txtAmt.Enabled = false;
            txtAmt.ReadOnly = true;
        }

    }
    public Boolean  CheckValidMonthDdl(int yrid, int mid, Page strPg, DropDownList ddl, Button btn)
    {
        //int intCalMthId;
        //int intCalMthIdToDay;
        //ArrayList ar = new ArrayList();
        //ar.Add(DateTime.Now.ToString());
        //int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        //int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        //intCalMthId = FindCalMthId(mid);
        //intCalMthIdToDay = FindCalMthId(mth);
        //if (yrid == yr)
        //{
        //    if (intCalMthId > intCalMthIdToDay)
        //    {
        //        MsgBoxOk("Invalid month", strPg);
        //        ddl.Enabled = false;
        //        btn.Enabled = false;
        //    }
        //    else
        //    {
        //        ddl.Enabled = true;
        //        btn.Enabled = true;
        //    }
        //}
        //else
        //{
        //    MsgBoxOk("Invalid month", strPg);
        //    ddl.Enabled = false;
        //}

        Boolean flg;
        int intCalMthId;
        int intCalMthIdToDay;
        ArrayList ar = new ArrayList();
        ar.Add(DateTime.Now.ToString());
        int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        intCalMthId = FindCalMthId(mid);
        intCalMthIdToDay = FindCalMthId(mth);
        if (yrid < yr)
        {
            ddl.Enabled = true;
            btn.Enabled = true;
            flg = true;
        }
        else if (yrid == yr)
        {
            if (intCalMthId <= intCalMthIdToDay)
            {
                ddl.Enabled = true;
                btn.Enabled = true;
                flg = true;
            }
            else
            {
                MsgBoxOk("Invalid month", strPg);
                ddl.Enabled = false;
                btn.Enabled = false;
                flg = false;
            }
        }
        else
        {
            MsgBoxOk("Invalid month", strPg);
            ddl.Enabled = false;
            flg = false;
        }
        return flg;
    }
    public void CheckValidMonthCtrl(int yrid, int mid, Page strPg, DropDownList ddl, Button btn)
    {
        int intCalMthId;
        int intCalMthIdToDay;
        ArrayList ar = new ArrayList();
        ar.Add(DateTime.Now.ToString());
        int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        intCalMthId = FindCalMthId(mid);
        intCalMthIdToDay = FindCalMthId(mth);
        if (yrid == yr)
        {
            if (intCalMthId > intCalMthIdToDay)
            {
                MsgBoxOk("Invalid month", strPg);
                ddl.Enabled = false;
                btn.Enabled = false;
            }
            else
            {
                ddl.Enabled = true;
                btn.Enabled = true;
            }
        }
        else
        {
            MsgBoxOk("Invalid month", strPg);
            ddl.Enabled = false;
        }
    }
    //public void CheckValidMonthCtrl(int yrid, int mid, Page strPg, string strCtrl)
    //{
    //    int intCalMthId;
    //    int intCalMthIdToDay;
    //    ArrayList ar = new ArrayList();
    //    ar.Add(DateTime.Now.ToString());
    //    int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
    //    int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
    //    intCalMthId = FindCalMthId(mid);
    //    intCalMthIdToDay = FindCalMthId(mth);
    //    if (yrid == yr)
    //    {
    //        if (intCalMthId > intCalMthIdToDay)
    //        {
    //            MsgBoxOk("Invalid month", strPg);
    //            if (strCtrl.Substring(0, 3) == "txt")
    //            {
    //                TextBox txt = (TextBox)strCtrl;
    //                txt.Enabled = false;
    //                txt.ReadOnly = true;
    //            }
    //            else if (strCtrl.Substring(0, 3) == "ddl")
    //            {
    //                DropDownList ddl = (DropDownList)strCtrl;
    //                ddl.Enabled = false;
    //            }
    //        }
    //        else
    //        {
    //            if (strCtrl.Substring(0, 3) == "txt")
    //            {
    //                TextBox txt = (TextBox)strCtrl;
    //                txt.Enabled = true;
    //                txt.ReadOnly = false;
    //            }
    //            else if (strCtrl.Substring(0, 3) == "ddl")
    //            {
    //                DropDownList ddl = (DropDownList)strCtrl;
    //                ddl.Enabled = true;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        MsgBoxOk("Invalid month", strPg);
    //        if (strCtrl.Substring(0, 3) == "txt")
    //        {
    //            TextBox txt = (TextBox)strCtrl;
    //            txt.Enabled = false;
    //            txt.ReadOnly = true;
    //        }
    //        else if (strCtrl.Substring(0, 3) == "ddl")
    //        {
    //            DropDownList ddl = (DropDownList)strCtrl;
    //            ddl.Enabled = false;
    //        }
    //    }
    //}
    private int FindCalMthId(int intmid)
    {
        int intmCal = 0;
        if (intmid == 4)
            intmCal = 1;
        else if(intmid == 5)
            intmCal = 2;
        else if (intmid == 6)
            intmCal = 3;
        else if (intmid == 7)
            intmCal = 4;
        else if (intmid == 8)
            intmCal = 5;
        else if (intmid == 9)
            intmCal = 6;
        else if (intmid == 10)
            intmCal = 7;
        else if (intmid == 11)
            intmCal = 8;
        else if (intmid == 12)
            intmCal = 9;
        else if (intmid == 1)
            intmCal = 10;
        else if (intmid == 2)
            intmCal = 11;
        else if (intmid == 3)
            intmCal = 12;
        return intmCal;
    }
    public Boolean CheckValidMonth(int yrid, int mid)
    {
        //int intCalMthId;
        //int intCalMthIdToDay;
        //Boolean bl = true;
        //ArrayList ar = new ArrayList();
        //ar.Add(DateTime.Now.ToString());
        //int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        //int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        //intCalMthId = FindCalMthId(mid);
        //intCalMthIdToDay = FindCalMthId(mth);
        //if (yrid == yr)
        //{
        //    if (intCalMthId > intCalMthIdToDay)
        //    {
        //        bl = false;
        //    }
        //    else
        //    {
        //        bl = true;
        //    }
        //}
        //else
        //{
        //    bl = false;
        //}
        //return bl;


        int intCalMthId;
        int intCalMthIdToDay;
        Boolean bl = true;
        ArrayList ar = new ArrayList();
        ar.Add(DateTime.Now.ToString());
        int yr = genDaoKP.gFunFindPDEYearIdFromDateOnline(ar);
        int mth = Convert.ToInt16(DateTime.Now.Month.ToString());
        intCalMthId = FindCalMthId(mid);
        intCalMthIdToDay = FindCalMthId(mth);
        if (yrid < yr)
        {
            bl = true ;
        }
        else if (yrid == yr)
        {
            if (intCalMthId <= intCalMthIdToDay)
            {
                bl = true ;
            }
            else
            {
               
                bl = false;
            }
        }
        else
        {
            
            bl = false;
        }
        return bl;
        ///////////////////////////////////////
        //if (yrid < yr)
        //{
        //    ddl.Enabled = true;
        //    btn.Enabled = true;
        //}
        //else if (yrid == yr)
        //{
        //    if (intCalMthId <= intCalMthIdToDay)
        //    {
        //        ddl.Enabled = true;
        //        btn.Enabled = true;
        //    }
        //    else
        //    {
        //        MsgBoxOk("Invalid month", strPg);
        //        ddl.Enabled = false;
        //        btn.Enabled = false;
        //    }
        //}
        //else
        //{
        //    MsgBoxOk("Invalid month", strPg);
        //    ddl.Enabled = false;
        //}
    }
    public void SetGridGrey(GridView gdv)
    {
        gdv.RowStyle.BackColor = System.Drawing.Color.Gainsboro;
        gdv.CellPadding = 2;
        gdv.CellSpacing = 5;
        gdv.HeaderRow.BackColor = System.Drawing.Color.Gray;
        gdv.AlternatingRowStyle.BackColor = System.Drawing.Color.White;
        gdv.FooterRow.BackColor = System.Drawing.Color.Gray;
    }
    public void SetTrnType(int k,int s)
    {
        if (Convert.ToInt16(HttpContext.Current.Session["intTrnType"]) == 0)
        {
            HttpContext.Current.Session["intTrnType"] = Convert.ToInt16(k);
        }
        if (Convert.ToInt16(HttpContext.Current.Session["intTrnTypeStage"]) == 0)
        {
            HttpContext.Current.Session["intTrnTypeStage"] = Convert.ToInt16(s);
        }
        //HttpContext.Current.Session["intLBID"] = 3;
    }
    //public void SetGridRowsWithDataOld(DataSet ds, int cnt, GridView gdv, ArrayList arddl, ArrayList arCol)
    //{
    //    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count <= cnt)
    //    {
    //        SetRowsCnt(gdv, cnt);
    //        for (int i = 0; i < gdv.Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdv.Rows[i];
    //            for (int j = 0; j < arddl.Count; j++)
    //            {
    //                FillGridCmb(gvr, arddl[j].ToString());
    //            }
    //            if (i < ds.Tables[0].Rows.Count)
    //            {
    //                FillGridHavingData(gvr, ds, i, arCol);
    //            }
    //        }
    //        FillGridSlNo(gdv);
    //        //FillFooterTotals();
    //    }
    //    else
    //    {
    //        SetRowsCnt(gdv, ds.Tables[0].Rows.Count);
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            GridViewRow gvr = gdv.Rows[i];
    //            for (int j = 0; j < arddl.Count; j++)
    //            {
    //                FillGridCmb(gvr, arddl[j].ToString());
    //            }
    //            if (i < ds.Tables[0].Rows.Count)
    //            {
    //                FillGridHavingData(gvr, ds, i, arCol);
    //            }
    //        }
    //        FillGridSlNo(gdv);
    //    }
    //}
    public void SetGridRowsWithData(DataSet ds, int cnt, GridView gdv, ArrayList arddl, ArrayList arCol, ArrayList arDdlDs)
    {
        if (ds.Tables[0].Rows.Count >= 0 && ds.Tables[0].Rows.Count <= cnt)
        {
            SetRowsCnt(gdv, cnt);
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                for (int j = 0; j < arddl.Count; j++)
                {
                    DataSet dsd = (DataSet)arDdlDs[j];
                    FillGridCmb(gvr, arddl[j].ToString(),dsd);
                }
                if (i < ds.Tables[0].Rows.Count)
                {
                    FillGridHavingData(gvr, ds, i, arCol);
                }
            }
            FillGridSlNo(gdv);
            //FillFooterTotals();
        }
        else
        {
            SetRowsCnt(gdv, ds.Tables[0].Rows.Count);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                for (int j = 0; j < arddl.Count; j++)
                {
                    DataSet dsd = (DataSet)arDdlDs[j];
                    FillGridCmb(gvr, arddl[j].ToString(),dsd);
                }
                if (i < ds.Tables[0].Rows.Count)
                {
                    FillGridHavingData(gvr, ds, i, arCol);
                }
            }
            FillGridSlNo(gdv);
        }
    }
    public void SetRowsCntBind(GridView gdv, int cnt, ArrayList arrBndCol)
    {
        //DataTable dt = new DataTable();
        //DataRow dr;
        //DataColumn dcol = new DataColumn("SlNo", typeof(System.Int32));
        //dcol.AutoIncrement = true;
        //dt.Columns.Add(dcol);

        //for (int i = 0; i < cnt; i++)
        //{
        //    dr = dt.NewRow();
        //    dr["SlNo"] = i + 1;
        //    dt.Rows.Add(dr);
        //}
        //gdv.DataSource = dt;
        //gdv.DataBind();
        //gdv.Visible = true;
        
        
        DataTable dt = new DataTable();
        DataRow dr;
        //for (int j = 0; j < arrBndCol.Count; j++)
        //{
        //    DataColumn Colm = new DataColumn(arrBndCol[j], typeof(System.Int32));

        //}
        //DataColumn dcol2 = new DataColumn(chvCol, typeof(System.Int32));
        //dcol.AutoIncrement = true;
        //dt.Columns.Add(dcol);
        //dt.Columns.Add(dcol2);

        //for (int i = 0; i < cnt; i++)
        //{
        //    for (int j = 0; j < arrBndCol.Count; j++)
        //    {
        //        DataColumn Colm = new DataColumn(arrBndCol[j], typeof(System.Int32));
        //        Colm.AutoIncrement = true;
        //        dt.Columns.Add(Colm);

        //        dr = dt.NewRow();
        //        dr[arrBndCol[j].ToString()] = i + 1;
        //        dt.Rows.Add(dr);
        //    }
        //}
        gdv.DataSource = dt;
        gdv.DataBind();
        gdv.Visible = true;
    }
    public void SetGridRowsWithDataNew(DataSet ds, int cnt, GridView gdv, ArrayList arddl, ArrayList arCol, ArrayList arDdlDs, ArrayList arBndCols)
    {
        if (ds.Tables[0].Rows.Count >= 0 && ds.Tables[0].Rows.Count <= cnt)
        {
            SetGridDefaultCnt(gdv, arBndCols, cnt);
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                for (int j = 0; j < arddl.Count; j++)
                {
                    DataSet dsd = (DataSet)arDdlDs[j];
                    FillGridCmb(gvr, arddl[j].ToString(), dsd);
                }
                if (i < ds.Tables[0].Rows.Count)
                {
                    FillGridHavingData(gvr, ds, i, arCol);
                }
            }
            FillGridSlNo(gdv);
            //FillFooterTotals();
        }
        else
        {
            SetGridDefaultCnt(gdv, arBndCols, ds.Tables[0].Rows.Count);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                for (int j = 0; j < arddl.Count; j++)
                {
                    DataSet dsd = (DataSet)arDdlDs[j];
                    FillGridCmb(gvr, arddl[j].ToString(), dsd);
                }
                if (i < ds.Tables[0].Rows.Count)
                {
                    FillGridHavingData(gvr, ds, i, arCol);
                }
            }
            FillGridSlNo(gdv);
        }
    }
    public void SetGridRowsWithDataNewWithNoData(int cnt, GridView gdv, ArrayList arddl, ArrayList arCol, ArrayList arDdlDs, ArrayList arBndCols)
    {
       

            SetGridDefaultCnt(gdv, arBndCols, cnt);
            for (int i = 0; i < cnt; i++)
            {
                GridViewRow gvr = gdv.Rows[i];
                for (int j = 0; j < arddl.Count; j++)
                {
                    DataSet dsd = (DataSet)arDdlDs[j];
                    FillGridCmb(gvr, arddl[j].ToString(), dsd);
                }

            }
            FillGridSlNo(gdv);
    }
    public void FillGridCmb(GridViewRow gvr, string ddl, DataSet ds1)
    {
        DropDownList ddlGo = (DropDownList)gvr.FindControl(ddl);
        FillCombo(ddlGo, ds1, 1);
    }

    public void FillGridCmbOld(GridViewRow gvr, string ddl)
    {
        DropDownList ddlGo = (DropDownList)gvr.FindControl(ddl);
        DataSet ds1 = genDaoKP.GetGO();
        FillCombo(ddlGo, ds1, 1);
    }
    public void FillGridHavingData(GridViewRow gvr, DataSet dsSched, int i, ArrayList arCol)
    {
        for (int j = 0; j < arCol.Count; j++)
        {
            if (arCol[j].ToString().Substring(0,3) == "lbl")
            {
                Label lblAss = (Label)gvr.FindControl(arCol[j].ToString());
                lblAss.Text = dsSched.Tables[0].Rows[i].ItemArray[j].ToString();
            }
            else if (arCol[j].ToString().Substring(0, 3) == "txt")
            {
                TextBox txtAss = (TextBox)gvr.FindControl(arCol[j].ToString());
                txtAss.Text = dsSched.Tables[0].Rows[i].ItemArray[j].ToString();
            }
            else if (arCol[j].ToString().Substring(0, 3) == "chk")
            {
                CheckBox chkAss = (CheckBox)gvr.FindControl(arCol[j].ToString());
                if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[j]) == 1)
                {
                    chkAss.Checked = true;
                }
                else
                {
                    chkAss.Checked = false;
                }
            }
            else if (arCol[j].ToString().Substring(0, 3) == "chl")
            {
                CheckBox chkAss = (CheckBox)gvr.FindControl(arCol[j].ToString());
                if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[j]) == 2)
                {
                    chkAss.Checked = true;
                }
                else
                {
                    chkAss.Checked = false;
                }
            }
            else if (arCol[j].ToString().Substring(0, 3) == "ddl")
            {
                DropDownList ddlAss = (DropDownList)gvr.FindControl(arCol[j].ToString());
                ddlAss.Text = dsSched.Tables[0].Rows[i].ItemArray[j].ToString();
            }
            //else if (arCol[j].ToString().Substring(0, 3) == "hlnk")
            //{
            //    HyperLinkColumn hlnk = (HyperLinkColumn)gvr.FindControl(arCol[j].ToString());
            //    ddlAss.Text = dsSched.Tables[0].Rows[i].ItemArray[j].ToString();
            //}
        }
        
        //Label lblSlNoAss = (Label)gvr.FindControl("lblSlNo");
        //lblSlNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[11].ToString();

        //TextBox txtAccNoAss = (TextBox)gvr.FindControl("txtAccNo");
        //txtAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[1].ToString();

        //Label lblNameAss = (Label)gvr.FindControl("lblName");
        //lblNameAss.Text = dsSched.Tables[0].Rows[i].ItemArray[2].ToString();

        //CheckBox chkUnIdentAss = (CheckBox)gvr.FindControl("chkUnIdent");
        //if (Convert.ToInt16(dsSched.Tables[0].Rows[i].ItemArray[13]) == 1)
        //{
        //    chkUnIdentAss.Checked = true;
        //}
        //else
        //{
        //    chkUnIdentAss.Checked = false;
        //}
        //TextBox txtSubnAss = (TextBox)gvr.FindControl("txtSubn");
        //txtSubnAss.Text = dsSched.Tables[0].Rows[i].ItemArray[3].ToString();
        //TextBox txtRepAss = (TextBox)gvr.FindControl("txtRep");
        //txtRepAss.Text = dsSched.Tables[0].Rows[i].ItemArray[4].ToString();
        //TextBox txtPfAss = (TextBox)gvr.FindControl("txtPf");
        //txtPfAss.Text = dsSched.Tables[0].Rows[i].ItemArray[5].ToString();
        //TextBox txtDaAss = (TextBox)gvr.FindControl("txtDa");
        //txtDaAss.Text = dsSched.Tables[0].Rows[i].ItemArray[6].ToString();
        //TextBox txtPayAss = (TextBox)gvr.FindControl("txtPay");
        //txtPayAss.Text = dsSched.Tables[0].Rows[i].ItemArray[7].ToString();
        //Label lblTotalAss = (Label)gvr.FindControl("lblTotal");
        //lblTotalAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        ////Label lblSchedMainAss = (Label)gdv.FindControl("lblSchedMain");
        ////lblSchedMainAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

        //Label lblSchedAss = (Label)gvr.FindControl("lblSched");
        //lblSchedAss.Text = dsSched.Tables[0].Rows[i].ItemArray[15].ToString();

        //Label lblAccNoAss = (Label)gvr.FindControl("lblAccNo");
        //lblAccNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

        //Label lblNewAccAss = (Label)gvr.FindControl("lblNewAcc");
        //lblNewAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[17].ToString();

        //Label lblNewTotAss = (Label)gvr.FindControl("lblNewTot");
        //lblNewTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        //Label lblEditModeSAss = (Label)gvr.FindControl("lblEditModeS");
        //lblEditModeSAss.Text = "0";

        ////Label lblRecNoAss = (Label)gdv.FindControl("lblRecNo");
        ////lblRecNoAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();

        //Label lblOTotAss = (Label)gvr.FindControl("lblOTot");
        //lblOTotAss.Text = dsSched.Tables[0].Rows[i].ItemArray[8].ToString();

        //Label lblOAccAss = (Label)gvr.FindControl("lblOAcc");
        //lblOAccAss.Text = dsSched.Tables[0].Rows[i].ItemArray[16].ToString();
    }
    public void SetLBTypesForDirAccts(int intAccFlg)
    {
        if (intAccFlg == 1)
        {
            HttpContext.Current.Session["intLBTypeId"] = 7;
            if (Convert.ToInt16(HttpContext.Current.Session["intUserTypeId"]) == 3)
            {
                HttpContext.Current.Session["intUserTypeId"] = 5;
            }
        }
    }
    public void SetLBTypesForDirAcctsRev(int intAccFlg)
    {
        if (intAccFlg == 1)
        {
            HttpContext.Current.Session["intLBTypeId"] = 5;
            if (Convert.ToInt16(HttpContext.Current.Session["intUserTypeId"]) == 5)
            {
                HttpContext.Current.Session["intUserTypeId"] = 3;
            }
        }
    }
    public void SetColWidthGrid(GridView gdv, GridViewRowEventArgs e, int gridCol, int dsCol)
    {
        // Add on RowDataBound of grid
        int widestData = 0;
        System.Data.DataRowView drv = (System.Data.DataRowView)e.Row.DataItem;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (drv != null)
            {
                if (drv.Row.Table.Rows[0].ItemArray[1].ToString() != "0")
                {

                    String catName = drv[dsCol].ToString();
                    catName = catName + "/";
                    int catNameLen = catName.Length;
                    if (catNameLen > widestData)
                    {
                        widestData = catNameLen;
                        gdv.Columns[gridCol].ItemStyle.Width = widestData * 30;
                        gdv.Columns[gridCol].ItemStyle.Wrap = false;
                    }
                }
            }
        }
    }

    public clsGlobalMethods()
    {
        //
        // TODO: Add constructor logic here
        //

    }
}
