

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
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KPEPFClassLibrary;

public partial class Contents_CreditCardNew : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    LedgerYDao ldgrDao = new LedgerYDao();
    LedgerMDao ldgrDaom = new LedgerMDao();
    UserDao usrD = new UserDao();
    static string accno = "";
    static string ename = "";
    static int flgEmp = 0;
    static int flgTrn = 0;
    static int tt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gen.GetYearRem();
            gblObj.FillCombo(ddlYear, ds, 1);
            //if (Convert.ToInt16(Session["intUserTypeId"]) == 10)
            //{
            //    if (ChekFlgLogin() == 1)
            //    {
            //        tctAccNo.Text = Session["strUser"].ToString();
            //        FillNameAccNo();
            //    }
            //    else
            //    {
            //        gblObj.MsgBoxOk("Change Password", this);
            //        Response.Redirect("ChangePwd.aspx");
            //    }
            //}
            //else
            //{
            //    ddlYear.Enabled = false;
            //}
            FillNameAccNo();
        }
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(Session["NumEmpId"]);
        tctAccNo.Text = Session["NumEmpId"].ToString();
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    private int ChekFlgLogin()
    {
        int i;
        DataSet ds = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(Convert.ToInt16(Convert.ToInt32(Session["intUserId"])));
        ds = usrD.GetUserDet(ar);
        if (ds.Tables[0].Rows[0].ItemArray[8].ToString() == "1")
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        return i;
    }
    
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //String frame = "<iframe  Width='100%' id ='iframeMain' scrolling='auto' runat='server'   frameborder='0' src='ChangePassword.aspx' height='300'></iframe>";
        // OB = ddlYear.SelectedItem[2];
        // CB = ddlYear.SelectedItem[3];

        ArrayList ar = new ArrayList();
        tt = int.Parse(ddlYear.SelectedIndex.ToString());
        FillCard();

        //int yr = Convert.ToInt16(ddlYear.SelectedValue);

        //Session["intCCYear"] = gen.GetCCYearId();
        //if (yr == Convert.ToInt16(Session["intCCYear"]))
        //{
        //    gdvAnnStmnt.Visible = true;
        //    ar.Add(yr + 1);
        //    lblyrann.Text = gen.GetYearFromId(ar);
        //    FillGrid(yr + 1);
        //}
        //else
        //{
        //    gdvAnnStmnt.Visible = false;
        //    Label21.Visible = false;
        //    lblyrann.Visible = false;
        //}
        
    }

    private Boolean CorrectionExists(Int32 empID)
    {
        CorrectionEntry crr = new CorrectionEntry();
        CorrectionEntryDao crrD = new CorrectionEntryDao();
        Boolean flg = true;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(empID);
        crr.IntAccNo = empID;
        dsCg = crrD.CheckCorrectionEntry4CardGen(crr);
        if (dsCg.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt16(dsCg.Tables[0].Rows[0].ItemArray[0]) > 0)
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

    protected void FillCard()
    {
        ArrayList arrIn = new ArrayList();
        DataSet ds = new DataSet();

        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());

        //int flgEmp = ChkEmp();
        //int flgTrn = ChkTrn();
        //////////////////ChkEmp/////////////
        DataSet dsEmp = new DataSet();
        emp.NumEmpID = Convert.ToInt32(Session["NumEmpId"]);
        dsEmp = empDao.GetEmployeeDetails(emp, 1);
        if (dsEmp.Tables[0].Rows.Count > 0)
        {
            accno = dsEmp.Tables[0].Rows[0].ItemArray[0].ToString();
            ename = dsEmp.Tables[0].Rows[0].ItemArray[1].ToString();
            flgEmp = 0;
        }
        else
        {
            flgEmp = 1;
        }
        //////////////////ChkEmp/////////////

        //////////////////ChkTrn/////////////
        DataSet dsTrn = new DataSet();
        ArrayList arE = new ArrayList();
        arE.Add(int.Parse(tctAccNo.Text.ToString()));
        arE.Add(int.Parse(ddlYear.SelectedValue));
        if (int.Parse(ddlYear.SelectedValue) < 50)
        {
            dsTrn = ldgrDao.GetYearlyDet(arE);
        }
        else
        {
            dsTrn = ldgrDao.GetYearlyDetNew(arE);
        }
        if (dsTrn.Tables[0].Rows.Count > 0)
        {
            //flgTrn = Convert.ToInt16(dsTrn.Tables[0].Rows[0].ItemArray[9]);
            flgTrn = 0;
        }
        else
        {
            flgTrn = 1;
        }
        //////////////////ChkTrn/////////////
        if (flgEmp == 0 && flgTrn == 0)
        {
            //ds = gen.CCard(arrIn);
            string strFileName = strGenerateFileName();
            string RptHead = "Directate of Panchayath";
            string FlPath = Request.PhysicalApplicationPath + "PDF/" + strFileName;
            //GeneratePDF(FlPath, strFileName);

            Session["intYearIdLedger"] = gen.GetCCYearId();
            //if (int.Parse(ddlYear.SelectedValue) == Convert.ToInt16(Session["intYearIdLedger"]))
            if (Convert.ToInt16(int.Parse(ddlYear.SelectedValue)) >= 50)
            {
                if (CorrectionExists(Convert.ToInt32(Session["NumEmpId"])) == true)
                {
                    GeneratePDFCorrEntry(FlPath, strFileName);
                }
                else
                {
                    GeneratePDF(FlPath, strFileName,2);
                }
            }
            else
            {
                GeneratePDF(FlPath, strFileName,1);
            }

        }
        else if (flgEmp == 0 && flgTrn == 1)
        {
            gblObj.MsgBoxOk("No transactions for this year.", this);
        }
        else
        {
            gblObj.MsgBoxOk("No such Account no.", this);
        }
    }
    private string strGenerateFileName()
    {
        string accno = tctAccNo.Text.ToString();
        string yrid = ddlYear.SelectedValue.ToString();
        string flnm = accno + "_" + yrid + ".pdf";
        return flnm;
    }

    private void GeneratePDF(string FlPath, string strFileName, int flg)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());
        if (flg == 1)
        {
            ds1 = gen.CCard(arrIn);
        }
        else
        {
            ds1 = gen.CCardNew(arrIn);
        }
        if (Convert.ToInt16(ds1.Tables[0].Rows.Count) > 0)
        {
            arrIn1.Add(ddlYear.SelectedValue.ToString());
            //ds3 = gen.Interest(arrIn1);
            ds3 = gen.InterestMltpl(arrIn1);
            float subscrip = 0, refund = 0, BF = 0, arrDA = 0, Inter = 0, Tot = 0, OB = 0, total = 0, withdrawal = 0, ToArrSub = 0;
            //PdfWriter.GetInstance(docTab1, new FileStream(Request.PhysicalApplicationPath + "/b1.pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(docTab1, new FileStream(FlPath, FileMode.Create));

            //********* Head Print date ************
            string date;
            date = DateTime.Today.Date.ToString().Substring(0, 10);
            Phrase headphraseprint = new Phrase("Printed on " + date, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter headprint = new HeaderFooter(headphraseprint, false);
            headprint.Border = Rectangle.NO_BORDER;
            headprint.Alignment = Element.ALIGN_RIGHT;
            docTab1.Header = headprint;

            //******* Foot Page number ************

            Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Swaraj Bhavan(6th floor), Nanthancode, Kowdiar P.O,Tvpm Phone:- 0471-2723043  Email :- aokpepf@lsgkerala.in along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the website\t\t http://www.lsgkerala.gov.in/kpepf \n 4. Subscribers attention is also drawn to Rule 27 of KPEPF Rules 1976 for compliance. \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
            footer.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            footer.Alignment = Element.ALIGN_LEFT;
            docTab1.Footer = footer;
            docTab1.Open();


            ////for (int cnt = intStYr; cnt <= intEndYr; cnt++)
            ////{

            ////    strYear = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            int numEmpId = int.Parse(tctAccNo.Text.ToString());
            //for (int cnt = 1; cnt <= 11; cnt++)
            //{
            Font[] fonts = new Font[1];
            fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD);
            //ds2 = gen.GetEmpAccWise(1,numEmpId,"");
            //Header****    ******************
            //Paragraph head = new Paragraph(new Chunk("Kerala Municipal Pensionable Employees Central Provident Fund \n", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head = new Paragraph(new Chunk("Directorate of Panchayats Thiruvananthapuram\n", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, new Color(0, 0, 0))));
            head.Alignment = Element.ALIGN_CENTER;
            docTab1.Add(head);


            Paragraph head1 = new Paragraph(new Chunk("KPEPF Credit Card for the year " + ddlYear.SelectedItem.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head2 = new Paragraph(new Chunk("[Revised]\n", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL, new Color(0, 0, 0))));
            head1.Alignment = Element.ALIGN_CENTER;
            head2.Alignment = Element.ALIGN_RIGHT;
            docTab1.Add(head1);

            //First Table definision****************
            iTextSharp.text.Table tab1 = new iTextSharp.text.Table(8);
            tab1.BorderWidth = 1;
            if (ds3.Tables[0].Rows.Count != 0)
            {
                Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                Phrase IntRt1 = new Phrase("Rate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                docTab1.Add(Name);
                docTab1.Add(Namea);
                docTab1.Add(Acc);
                docTab1.Add(IntRt1);
            }
            //Sub Head

            Cell cellSubHead1 = new Cell(new Chunk("Month", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead1.Rowspan = 2;
            cellSubHead1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellSubHead1.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead1.Border = 1;
            cellSubHead1.Border = Rectangle.UNDEFINED;
            //cellSubHead1.Border = Cell.RIGHT_BORDER;
            cellSubHead1.Width = 1;
            Cell cellSubHead2 = new Cell(new Chunk("Date of Remittance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead2.Width = 20;
            cellSubHead2.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.Border = 1;
            cellSubHead2.Border = Rectangle.UNDEFINED;
            //cellSubHead2.Border = Rectangle.RIGHT_BORDER;
            cellSubHead2.Rowspan = 2;
            Cell cellMani = new Cell(new Chunk("Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellMani.Colspan = 2;
            cellMani.HorizontalAlignment = Element.ALIGN_CENTER;
            cellMani.Border = 1;
            cellMani.Border = Rectangle.UNDEFINED;
            //cellMani.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead5 = new Cell(new Chunk("Refund of Advance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead5.Rowspan = 2;
            cellSubHead5.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.Border = 1;
            cellSubHead5.Border = Rectangle.UNDEFINED;
            //cellSubHead5.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead6 = new Cell(new Chunk("Arrear DA/Pay", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead6.Rowspan = 2;
            cellSubHead6.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.Border = 1;
            cellSubHead6.Border = Rectangle.UNDEFINED;
            //cellSubHead6.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead7 = new Cell(new Chunk("Total", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead7.Rowspan = 2;
            cellSubHead7.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.Border = 1;
            cellSubHead7.Border = Rectangle.UNDEFINED;
            //cellSubHead7.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead8 = new Cell(new Chunk("Withdrawals", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead8.Rowspan = 2;
            cellSubHead8.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.Border = 1;
            cellSubHead8.Border = Rectangle.UNDEFINED;
            //cellSubHead8.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead3 = new Cell(new Chunk("Subscription Amount", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead3.Border = 1;
            cellSubHead3.Border = Rectangle.UNDEFINED;
            //cellSubHead3.Border = Rectangle.RIGHT_BORDER;
            cellSubHead3.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead3.VerticalAlignment = Element.ALIGN_CENTER;
            Cell cellSubHead4 = new Cell(new Chunk("Arrear Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead4.Border = 1;
            cellSubHead4.Border = Rectangle.UNDEFINED;
            //cellSubHead4.Border = Rectangle.RIGHT_BORDER;
            cellSubHead4.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead4.VerticalAlignment = Element.ALIGN_CENTER;
            //tab1.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
            float[] headerwidths = { 12, 14, 14, 14, 12, 12, 12, 12 };
            tab1.Widths = headerwidths;
            tab1.WidthPercentage = 100;
            tab1.AddCell(cellSubHead1);
            tab1.AddCell(cellSubHead2);
            tab1.AddCell(cellMani);
            ////tab1.AddCell(nesthousing);
            tab1.AddCell(cellSubHead5);
            tab1.AddCell(cellSubHead6);
            tab1.AddCell(cellSubHead7);
            tab1.AddCell(cellSubHead8);
            tab1.AddCell(cellSubHead3);
            tab1.AddCell(cellSubHead4);

            tab1.Padding = 1;

            //Monthly data*************
            //ds1 = ledgerdao.GetRptMonthWs(intEmpId, cnt);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                tab1.DefaultHorizontalAlignment = Element.ALIGN_MIDDLE;
                int l = int.Parse(ds1.Tables[0].Rows.Count.ToString());
                for (int i = 0; i < l; i++)
                {
                    Cell cellRw1 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[0].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw1.Border = 1;
                    //cellRw1.Height = 100;
                    cellRw1.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[1].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw2.Border = 1;
                    cellRw2.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[2].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw3.Border = 1;
                    cellRw3.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw4 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[4].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw4.Border = 1;
                    cellRw4.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw5 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[3].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw5.Border = 1;
                    cellRw5.Border = Rectangle.RIGHT_BORDER;
                    float arrear = float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString());
                    Cell cellRw6 = new Cell(new Chunk(" " + arrear + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw6.Border = 1;
                    cellRw6.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw7 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[7].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw7.Border = 1;
                    cellRw7.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw8 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[12].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw8.Border = 1;
                    cellRw8.Border = Rectangle.RIGHT_BORDER;
                    cellRw3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw4.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw5.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw6.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw7.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw8.HorizontalAlignment = Element.ALIGN_RIGHT;

                    tab1.AddCell(cellRw1);
                    tab1.AddCell(cellRw2);
                    tab1.AddCell(cellRw3);
                    tab1.AddCell(cellRw4);
                    tab1.AddCell(cellRw5);
                    tab1.AddCell(cellRw6);
                    tab1.AddCell(cellRw7);
                    tab1.AddCell(cellRw8);


                    subscrip += float.Parse(ds1.Tables[0].Rows[i].ItemArray[2].ToString());
                    ToArrSub += float.Parse(ds1.Tables[0].Rows[i].ItemArray[4].ToString());
                    BF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[11].ToString());
                    Inter += float.Parse(ds1.Tables[0].Rows[i].ItemArray[10].ToString());
                    Tot += float.Parse(ds1.Tables[0].Rows[i].ItemArray[9].ToString());
                    OB += float.Parse(ds1.Tables[0].Rows[i].ItemArray[8].ToString());
                    refund += float.Parse(ds1.Tables[0].Rows[i].ItemArray[3].ToString());
                    //arrPF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString());
                    arrDA += (float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString()));
                    //arrPay += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                    total += float.Parse(ds1.Tables[0].Rows[i].ItemArray[7].ToString());
                    withdrawal += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                }
            }
            Cell cellTotNA = new Cell(" ");
            cellTotNA.Border = 0;
            ////////////
            //Cell cellTot1 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot1 = new Cell(new Chunk("Total ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            cellTot1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellTot1.Border = 1;
            cellTot1.Border = Rectangle.TOP_BORDER;
            Cell cellTot2 = new Cell(" ");
            cellTot2.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot2.Border = 1;
            cellTot2.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot1);
            tab1.AddCell(cellTot2);
            if (subscrip > 0)
            {
                Cell cellTot3 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
                cellTot3.Border = 1;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            else
            {
                Cell cellTot3 = new Cell(new Chunk(" "));
                cellTot3.Border = 3;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            /////////////////
            Cell cellTot4 = new Cell(new Chunk(" " + ToArrSub, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot4.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot4.Border = 1;
            cellTot4.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot4);
            Cell cellTot5 = new Cell(new Chunk(" " + refund, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot5.Border = 1;
            cellTot5.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot6 = new Cell(new Chunk(" " + arrPF, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot6 = new Cell(new Chunk(" " + arrDA, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot6.Border = 1;
            cellTot6.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot5 = new Cell(new Chunk(" " + arrPay, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot7 = new Cell(new Chunk(" " + total, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot7.Border = 1;
            cellTot7.Border = Rectangle.TOP_BORDER;
            Cell cellTot8 = new Cell(new Chunk(" " + withdrawal, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot8.Border = 1;
            cellTot8.Border = Rectangle.TOP_BORDER;
            //tab1.AddCell(cellTot3);
            cellTot5.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot6.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot7.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot8.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab1.AddCell(cellTot5);
            tab1.AddCell(cellTot6);
            tab1.AddCell(cellTot7);
            tab1.AddCell(cellTot8);
            docTab1.Add(tab1);
            //Second Table definision****************
            iTextSharp.text.Table tab2 = new iTextSharp.text.Table(2);
            tab2.BorderWidth = 1;
            float[] subtabwidths = { 30, 15 };
            tab2.Widths = subtabwidths;
            tab2.WidthPercentage = 45;
            tab2.Alignment = Element.ALIGN_RIGHT;
            tab2.BorderColor = new Color(0, 0, 0);

            //strYear = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
            //First row************
            DataSet dst = new DataSet();
            dst = gen.GetYearRem();
            Cell YrltDetCell1 = new Cell(new Chunk("  Balance From " + ds1.Tables[0].Rows[0].ItemArray[20].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell1.Border = 0;
            tab2.AddCell(YrltDetCell1);
            Cell YrltDetCell3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell3.Border = 0;
            tab2.AddCell(YrltDetCell3);

            //Second row************
            Cell YrltDetCell4 = new Cell(new Chunk("  Deposits and Refunds ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            //YrltDetCell4.Border = Rectangle.NO_BORDER;
            YrltDetCell4.Border = 0;
            tab2.AddCell(YrltDetCell4);
            Cell YrltDetCell6 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[9].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell6.Border = 0;
            tab2.AddCell(YrltDetCell6);

            //Third row************
            Cell YrltDetCell7 = new Cell(new Chunk("  Interest for " + ds1.Tables[0].Rows[0].ItemArray[19].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell7.Border = 0;
            tab2.AddCell(YrltDetCell7);
            Cell YrltDetCell9 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell9.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell9.Border = 0;
            tab2.AddCell(YrltDetCell9);

            //Fourth row************
            Cell YrltDetCell10 = new Cell(new Chunk("  Total Rupees ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell10.Border = 0;
            tab2.AddCell(YrltDetCell10);
            Cell YrltDetCell12 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[15].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell12.Border = 0;
            YrltDetCell12.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell12);

            //Fifth row************
            Cell YrltDetCell13 = new Cell(new Chunk("  Deduct Withdrawals ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell13.Border = 0;
            tab2.AddCell(YrltDetCell13);
            Cell YrltDetCell15 = new Cell(new Chunk(" " + withdrawal + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell15.Border = 0;
            YrltDetCell15.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell15);

            //Sixth row************

            Cell YrltDetCell16 = new Cell(new Chunk("  Balance on " + dst.Tables[0].Rows[tt - 1].ItemArray[3].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell16.Border = 0;
            tab2.AddCell(YrltDetCell16);
            Cell YrltDetCell18 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell18.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell18.Border = 0;
            tab2.AddCell(YrltDetCell18);
            tab2.Padding = 0;
            docTab1.Add(tab2);
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(int.Parse(tctAccNo.Text.ToString()));
            ds = gen.getCurrentLB(arr);

            docTab1.Add(new Phrase(new Chunk("District : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[25].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            //docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[0].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            //docTab1.Add(new Phrase(new Chunk("\n Closing Balance in words: Rupees One Lakhs Thirteen Thousand Six Hundred Eighty-Seven Only", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n NB:-This is a computer generated document and hence requires no signature", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Place: Thiruvananthapuram", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Date: " + date, FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            //string Ack;
            //Phrase Ack1 = new Phrase(" Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Corporation Golden Jubilee Building, opposite SMV school, Near Over bridge,Thampanoor-1 Phone:- 0471-2461043  Email :- aokpepf@lsgkerala.in  within 15 days along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            //HeaderFooter headprint1 = new HeaderFooter(Ack1, false);
            //headprint1.BorderWidthTop = Rectangle.TOP_BORDER;
            //headprint1.Alignment = Element.ALIGN_RIGHT;
            //docTab1.Footer = headprint1;

            docTab1.Add(new Phrase(new Chunk("\n The closing balance indicated is subject to variation on account of missing Credits/Debits if any noticed and accounted for later due to various means.", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));


            subscrip = 0;
            refund = 0;
            arrDA = 0;
            total = 0;
            withdrawal = 0;
            docTab1.NewPage();
            docTab1.Close();
            String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../PDF/" + strFileName + "' height='600'></iframe>";
            PDE.InnerHtml = frame;
            //Response.Redirect("../PDF/" + strFileName);
        }
        else
        {
            //gblObj.MsgBoxOk("No data!", this);
            if (flgTrn == 0)
            {
                genPDFNonTrn(Convert.ToInt32(tctAccNo.Text), Convert.ToInt16(ddlYear.SelectedValue), FlPath, strFileName);
            }
            else
            {
                gblObj.MsgBoxOk("No data!", this);
            }
        }
    }
    private void genPDFNonTrn(int acc, int yr, string FlPath, string strFileName)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());
        ds1 = gen.CCardNonTrn(arrIn);
        if (Convert.ToInt16(ds1.Tables[0].Rows.Count) > 0)
        {
            arrIn1.Add(ddlYear.SelectedValue.ToString());
            ds3 = gen.InterestMltpl(arrIn1);

            //PdfWriter.GetInstance(docTab1, new FileStream(Request.PhysicalApplicationPath + "/b1.pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(docTab1, new FileStream(FlPath, FileMode.Create));

            //********* Head Print date ************
            string date;
            date = DateTime.Today.Date.ToString().Substring(0, 10);
            Phrase headphraseprint = new Phrase("Printed on " + date, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter headprint = new HeaderFooter(headphraseprint, false);
            headprint.Border = Rectangle.NO_BORDER;
            headprint.Alignment = Element.ALIGN_RIGHT;
            docTab1.Header = headprint;

            //******* Foot Page number ************

            Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Swaraj Bhavan(6th floor), Nanthancode, Kowdiar P.O,Tvpm Phone:- 0471-2723043  Email :- aokpepf@lsgkerala.in along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the website\t\t http://www.lsgkerala.gov.in/kpepf \n 4. Subscribers attention is also drawn to Rule 27 of KPEPF Rules 1976 for compliance. \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
            footer.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            footer.Alignment = Element.ALIGN_LEFT;
            docTab1.Footer = footer;
            docTab1.Open();
            int numEmpId = int.Parse(tctAccNo.Text.ToString());
            Font[] fonts = new Font[1];
            fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD);
            //Header****    ******************
            //Paragraph head = new Paragraph(new Chunk("Kerala Municipal Pensionable Employees Central Provident Fund \n", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head = new Paragraph(new Chunk("Directorate of Panchayats Thiruvananthapuram\n", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, new Color(0, 0, 0))));
            head.Alignment = Element.ALIGN_CENTER;
            docTab1.Add(head);

            Paragraph head1 = new Paragraph(new Chunk("KPEPF Credit Card for the year " + ddlYear.SelectedItem.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head2 = new Paragraph(new Chunk("[Revised]\n", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL, new Color(0, 0, 0))));
            head1.Alignment = Element.ALIGN_CENTER;
            head2.Alignment = Element.ALIGN_RIGHT;
            docTab1.Add(head1);
            iTextSharp.text.Table tab1 = new iTextSharp.text.Table(8);
            tab1.BorderWidth = 1;
            if (ds1.Tables[0].Rows.Count != 0)
            {
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                    Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[6].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                    Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                    Phrase IntRt1 = new Phrase("Rate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                    docTab1.Add(Name);
                    docTab1.Add(Namea);
                    docTab1.Add(Acc);
                    docTab1.Add(IntRt1);
                }
                //Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                //Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[6].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                ////Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds1.Tables[0].Rows[0].ItemArray[9].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
                //Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
                //docTab1.Add(Name);
                //docTab1.Add(Namea);
                //docTab1.Add(Acc);

                docTab1.Add(Chunk.NEWLINE);
                docTab1.Add(Chunk.NEWLINE);
                docTab1.Add(Chunk.NEWLINE);
                docTab1.Add(Chunk.NEWLINE);

                //Second Table definision****************
                iTextSharp.text.Table tab2 = new iTextSharp.text.Table(2);
                tab2.BorderWidth = 1;
                float[] subtabwidths = { 30, 15 };
                tab2.Widths = subtabwidths;
                tab2.WidthPercentage = 45;
                tab2.Alignment = Element.ALIGN_RIGHT;
                tab2.BorderColor = new Color(0, 0, 0);
                Cell YrltDetCell1 = new Cell(new Chunk("  Balance From " + ds1.Tables[0].Rows[0].ItemArray[8].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell1.Border = 0;
                tab2.AddCell(YrltDetCell1);
                Cell YrltDetCell3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[0].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                YrltDetCell3.Border = 0;
                tab2.AddCell(YrltDetCell3);

                //Second row************
                Cell YrltDetCell4 = new Cell(new Chunk("  Deposits and Refunds ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                //YrltDetCell4.Border = Rectangle.NO_BORDER;
                YrltDetCell4.Border = 0;
                tab2.AddCell(YrltDetCell4);
                Cell YrltDetCell6 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
                YrltDetCell6.Border = 0;
                tab2.AddCell(YrltDetCell6);

                //Third row************
                Cell YrltDetCell7 = new Cell(new Chunk("  Interest for " + ds1.Tables[0].Rows[0].ItemArray[7].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell7.Border = 0;
                tab2.AddCell(YrltDetCell7);
                Cell YrltDetCell9 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell9.HorizontalAlignment = Element.ALIGN_RIGHT;
                YrltDetCell9.Border = 0;
                tab2.AddCell(YrltDetCell9);

                //Fourth row************
                Cell YrltDetCell10 = new Cell(new Chunk("  Total Rupees ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell10.Border = 0;
                tab2.AddCell(YrltDetCell10);
                Cell YrltDetCell12 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell12.Border = 0;
                YrltDetCell12.HorizontalAlignment = Element.ALIGN_RIGHT;
                tab2.AddCell(YrltDetCell12);

                //Fifth row************
                Cell YrltDetCell13 = new Cell(new Chunk("  Deduct Withdrawals ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell13.Border = 0;
                tab2.AddCell(YrltDetCell13);
                Cell YrltDetCell15 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell15.Border = 0;
                YrltDetCell15.HorizontalAlignment = Element.ALIGN_RIGHT;
                tab2.AddCell(YrltDetCell15);

                //Sixth row************

                Cell YrltDetCell16 = new Cell(new Chunk("  Balance on " + ds1.Tables[0].Rows[0].ItemArray[7].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell16.Border = 0;
                tab2.AddCell(YrltDetCell16);
                Cell YrltDetCell18 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell18.HorizontalAlignment = Element.ALIGN_RIGHT;
                YrltDetCell18.Border = 0;
                tab2.AddCell(YrltDetCell18);
                tab2.Padding = 0;
                docTab1.Add(tab2);



                //docTab1.Add(new Phrase(new Chunk("\n Closing Balance in words: Rupees One Lakhs Thirteen Thousand Six Hundred Eighty-Seven Only", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
                docTab1.Add(new Phrase(new Chunk("\n NB:-This is a computer generated document and hence requires no signature", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
                docTab1.Add(new Phrase(new Chunk("\n Place: Thiruvananthapuram", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
                docTab1.Add(new Phrase(new Chunk("\n Date: " + date, FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

                docTab1.Add(new Phrase(new Chunk("\n The closing balance indicated is subject to variation on account of missing Credits/Debits if any noticed and accounted for later due to various means.", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
                docTab1.NewPage();
                docTab1.Close();
                String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../PDF/" + strFileName + "' height='600'></iframe>";
                PDE.InnerHtml = frame;

            }
        }
    }
    private void GeneratePDFCorrEntry(string FlPath, string strFileName)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());
        ds1 = gen.CCardNew(arrIn);
        if (Convert.ToInt16(ds1.Tables[0].Rows.Count) > 0)
        {
            arrIn1.Add(ddlYear.SelectedValue.ToString());
            ds3 = gen.InterestMltpl(arrIn1);
            float subscrip = 0, refund = 0, BF = 0, arrDA = 0, Inter = 0, Tot = 0, OB = 0, total = 0, withdrawal = 0, ToArrSub = 0;
            //PdfWriter.GetInstance(docTab1, new FileStream(Request.PhysicalApplicationPath + "/b1.pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(docTab1, new FileStream(FlPath, FileMode.Create));

            //********* Head Print date ************
            string date;
            date = DateTime.Today.Date.ToString().Substring(0, 10);
            Phrase headphraseprint = new Phrase("Printed on " + date, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter headprint = new HeaderFooter(headphraseprint, false);
            headprint.Border = Rectangle.NO_BORDER;
            headprint.Alignment = Element.ALIGN_RIGHT;
            docTab1.Header = headprint;

            //******* Foot Page number ************

            Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Swaraj Bhavan(6th floor), Nanthancode, Kowdiar P.O,Tvpm Phone:- 0471-2723043  Email :- aokpepf@lsgkerala.in along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the website\t\t http://www.lsgkerala.gov.in/kpepf \n 4. Subscribers attention is also drawn to Rule 27 of KPEPF Rules 1976 for compliance. \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
            footer.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            footer.Alignment = Element.ALIGN_LEFT;
            docTab1.Footer = footer;
            docTab1.Open();


            ////for (int cnt = intStYr; cnt <= intEndYr; cnt++)
            ////{

            ////    strYear = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            int numEmpId = int.Parse(tctAccNo.Text.ToString());
            //for (int cnt = 1; cnt <= 11; cnt++)
            //{
            Font[] fonts = new Font[1];
            fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 10, iTextSharp.text.Font.BOLD);
            //ds2 = gen.GetEmpAccWise(1,numEmpId,"");
            //Header****    ******************
            //Paragraph head = new Paragraph(new Chunk("Kerala Municipal Pensionable Employees Central Provident Fund \n", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head = new Paragraph(new Chunk("Directorate of Panchayats Thiruvananthapuram\n", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD, new Color(0, 0, 0))));
            head.Alignment = Element.ALIGN_CENTER;
            docTab1.Add(head);


            Paragraph head1 = new Paragraph(new Chunk("KPEPF Credit Card for the year " + ddlYear.SelectedItem.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Paragraph head2 = new Paragraph(new Chunk("[Revised]\n", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL, new Color(0, 0, 0))));
            head1.Alignment = Element.ALIGN_CENTER;
            head2.Alignment = Element.ALIGN_RIGHT;
            docTab1.Add(head1);
            docTab1.Add(head2);
            //docTab1.Add(new Phrase(new Chunk("\n")));
            //*****************************

            //First Table definision****************
            iTextSharp.text.Table tab1 = new iTextSharp.text.Table(8);
            //PdfContentByte cb = writer.DirectContent;
            //cb.SetLineDash(1.0f); // Make a bit thicker than 1.0 default
            //cb.MoveTo(20, docTab1.Top - 40f);
            //cb.LineTo(400, docTab1.Top - 40f);
            //cb.SetColorStroke(new Color(255, 0, 0));
            //cb.Stroke();
            //tab1.DefaultCellBorder = Rectangle.BOX();
            //tab1.Border = Rectangle.NO_BORDER;
            tab1.BorderWidth = 1;
            if (ds3.Tables[0].Rows.Count != 0)
            {
                Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                Phrase IntRt1 = new Phrase("Rate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                docTab1.Add(Name);
                docTab1.Add(Namea);
                docTab1.Add(Acc);
                docTab1.Add(IntRt1);
            }

            //Sub Head

            Cell cellSubHead1 = new Cell(new Chunk("Month", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead1.Rowspan = 2;
            cellSubHead1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellSubHead1.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead1.Border = 1;
            cellSubHead1.Border = Rectangle.UNDEFINED;
            //cellSubHead1.Border = Cell.RIGHT_BORDER;
            cellSubHead1.Width = 1;
            Cell cellSubHead2 = new Cell(new Chunk("Date of Remittance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead2.Width = 20;
            cellSubHead2.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead2.Border = 1;
            cellSubHead2.Border = Rectangle.UNDEFINED;
            //cellSubHead2.Border = Rectangle.RIGHT_BORDER;
            cellSubHead2.Rowspan = 2;
            Cell cellMani = new Cell(new Chunk("Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellMani.Colspan = 2;
            cellMani.HorizontalAlignment = Element.ALIGN_CENTER;
            cellMani.Border = 1;
            cellMani.Border = Rectangle.UNDEFINED;
            //cellMani.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead5 = new Cell(new Chunk("Refund of Advance", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead5.Rowspan = 2;
            cellSubHead5.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead5.Border = 1;
            cellSubHead5.Border = Rectangle.UNDEFINED;
            //cellSubHead5.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead6 = new Cell(new Chunk("Arrear DA/Pay", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead6.Rowspan = 2;
            cellSubHead6.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead6.Border = 1;
            cellSubHead6.Border = Rectangle.UNDEFINED;
            //cellSubHead6.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead7 = new Cell(new Chunk("Total", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead7.Rowspan = 2;
            cellSubHead7.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead7.Border = 1;
            cellSubHead7.Border = Rectangle.UNDEFINED;
            //cellSubHead7.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead8 = new Cell(new Chunk("Withdrawals", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead8.Rowspan = 2;
            cellSubHead8.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.VerticalAlignment = Element.ALIGN_CENTER;
            cellSubHead8.Border = 1;
            cellSubHead8.Border = Rectangle.UNDEFINED;
            //cellSubHead8.Border = Rectangle.RIGHT_BORDER;
            Cell cellSubHead3 = new Cell(new Chunk("Subscription Amount", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead3.Border = 1;
            cellSubHead3.Border = Rectangle.UNDEFINED;
            //cellSubHead3.Border = Rectangle.RIGHT_BORDER;
            cellSubHead3.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead3.VerticalAlignment = Element.ALIGN_CENTER;
            Cell cellSubHead4 = new Cell(new Chunk("Arrear Subscription", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            cellSubHead4.Border = 1;
            cellSubHead4.Border = Rectangle.UNDEFINED;
            //cellSubHead4.Border = Rectangle.RIGHT_BORDER;
            cellSubHead4.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSubHead4.VerticalAlignment = Element.ALIGN_CENTER;
            //tab1.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
            float[] headerwidths = { 12, 14, 14, 14, 12, 12, 12, 12 };
            tab1.Widths = headerwidths;
            tab1.WidthPercentage = 100;
            tab1.AddCell(cellSubHead1);
            tab1.AddCell(cellSubHead2);
            tab1.AddCell(cellMani);
            ////tab1.AddCell(nesthousing);
            tab1.AddCell(cellSubHead5);
            tab1.AddCell(cellSubHead6);
            tab1.AddCell(cellSubHead7);
            tab1.AddCell(cellSubHead8);
            tab1.AddCell(cellSubHead3);
            tab1.AddCell(cellSubHead4);

            tab1.Padding = 1;

            //Monthly data*************
            //ds1 = ledgerdao.GetRptMonthWs(intEmpId, cnt);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                tab1.DefaultHorizontalAlignment = Element.ALIGN_MIDDLE;
                int l = int.Parse(ds1.Tables[0].Rows.Count.ToString());
                for (int i = 0; i < l; i++)
                {
                    Cell cellRw1 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[0].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw1.Border = 1;
                    //cellRw1.Height = 100;
                    cellRw1.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[1].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw2.Border = 1;
                    cellRw2.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[2].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw3.Border = 1;
                    cellRw3.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw4 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[4].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw4.Border = 1;
                    cellRw4.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw5 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[3].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw5.Border = 1;
                    cellRw5.Border = Rectangle.RIGHT_BORDER;
                    float arrear = float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString());
                    Cell cellRw6 = new Cell(new Chunk(" " + arrear + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw6.Border = 1;
                    cellRw6.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw7 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[7].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw7.Border = 1;
                    cellRw7.Border = Rectangle.RIGHT_BORDER;
                    Cell cellRw8 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[i].ItemArray[12].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                    cellRw8.Border = 1;
                    cellRw8.Border = Rectangle.RIGHT_BORDER;
                    cellRw3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw4.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw5.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw6.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw7.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellRw8.HorizontalAlignment = Element.ALIGN_RIGHT;

                    tab1.AddCell(cellRw1);
                    tab1.AddCell(cellRw2);
                    tab1.AddCell(cellRw3);
                    tab1.AddCell(cellRw4);
                    tab1.AddCell(cellRw5);
                    tab1.AddCell(cellRw6);
                    tab1.AddCell(cellRw7);
                    tab1.AddCell(cellRw8);


                    subscrip += float.Parse(ds1.Tables[0].Rows[i].ItemArray[2].ToString());
                    ToArrSub += float.Parse(ds1.Tables[0].Rows[i].ItemArray[4].ToString());
                    BF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[11].ToString());
                    Inter += float.Parse(ds1.Tables[0].Rows[i].ItemArray[10].ToString());
                    Tot += float.Parse(ds1.Tables[0].Rows[i].ItemArray[9].ToString());
                    OB += float.Parse(ds1.Tables[0].Rows[i].ItemArray[8].ToString());
                    refund += float.Parse(ds1.Tables[0].Rows[i].ItemArray[3].ToString());
                    //arrPF += float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString());
                    arrDA += (float.Parse(ds1.Tables[0].Rows[i].ItemArray[5].ToString()) + float.Parse(ds1.Tables[0].Rows[i].ItemArray[6].ToString()));
                    //arrPay += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                    total += float.Parse(ds1.Tables[0].Rows[i].ItemArray[7].ToString());
                    withdrawal += float.Parse(ds1.Tables[0].Rows[i].ItemArray[12].ToString());
                }
            }
            Cell cellTotNA = new Cell(" ");
            cellTotNA.Border = 0;
            ////////////
            //Cell cellTot1 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot1 = new Cell(new Chunk("Total ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            cellTot1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellTot1.Border = 1;
            cellTot1.Border = Rectangle.TOP_BORDER;
            Cell cellTot2 = new Cell(" ");
            cellTot2.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot2.Border = 1;
            cellTot2.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot1);
            tab1.AddCell(cellTot2);
            if (subscrip > 0)
            {
                Cell cellTot3 = new Cell(new Chunk(" " + subscrip, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
                cellTot3.Border = 1;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            else
            {
                Cell cellTot3 = new Cell(new Chunk(" "));
                cellTot3.Border = 3;
                cellTot3.Border = Rectangle.TOP_BORDER;
                tab1.AddCell(cellTot3);
                cellTot3.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            /////////////////
            Cell cellTot4 = new Cell(new Chunk(" " + ToArrSub, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot4.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot4.Border = 1;
            cellTot4.Border = Rectangle.TOP_BORDER;
            tab1.AddCell(cellTot4);
            Cell cellTot5 = new Cell(new Chunk(" " + refund, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot5.Border = 1;
            cellTot5.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot6 = new Cell(new Chunk(" " + arrPF, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot6 = new Cell(new Chunk(" " + arrDA, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot6.Border = 1;
            cellTot6.Border = Rectangle.TOP_BORDER;
            ////Cell cellTot5 = new Cell(new Chunk(" " + arrPay, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            Cell cellTot7 = new Cell(new Chunk(" " + total, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot7.Border = 1;
            cellTot7.Border = Rectangle.TOP_BORDER;
            Cell cellTot8 = new Cell(new Chunk(" " + withdrawal, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD, new Color(0, 0, 0))));
            cellTot8.Border = 1;
            cellTot8.Border = Rectangle.TOP_BORDER;
            //tab1.AddCell(cellTot3);
            cellTot5.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot6.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot7.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellTot8.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab1.AddCell(cellTot5);
            tab1.AddCell(cellTot6);
            tab1.AddCell(cellTot7);
            tab1.AddCell(cellTot8);
            docTab1.Add(tab1);
            //Second Table definision****************
            iTextSharp.text.Table tab2 = new iTextSharp.text.Table(2);
            tab2.BorderWidth = 1;
            float[] subtabwidths = { 30, 15 };
            tab2.Widths = subtabwidths;
            tab2.WidthPercentage = 45;
            tab2.Alignment = Element.ALIGN_RIGHT;
            tab2.BorderColor = new Color(0, 0, 0);

            //strYear = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
            //First row************
            DataSet dst = new DataSet();
            //dst = gen.GetYearPDE();
            dst = gen.GetYearRem();
            Cell YrltDetCell1 = new Cell(new Chunk("  Balance From " + ds1.Tables[0].Rows[0].ItemArray[20].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell1.Border = 0;
            tab2.AddCell(YrltDetCell1);
            Cell YrltDetCell3 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell3.Border = 0;
            tab2.AddCell(YrltDetCell3);

            //Second row************
            Cell YrltDetCell4 = new Cell(new Chunk("  Deposits and Refunds ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            //YrltDetCell4.Border = Rectangle.NO_BORDER;
            YrltDetCell4.Border = 0;
            tab2.AddCell(YrltDetCell4);
            Cell YrltDetCell6 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[9].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell6.Border = 0;
            tab2.AddCell(YrltDetCell6);

            //Third row************
            Cell YrltDetCell7 = new Cell(new Chunk("  Interest for " + ds1.Tables[0].Rows[0].ItemArray[19].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell7.Border = 0;
            tab2.AddCell(YrltDetCell7);
            Cell YrltDetCell9 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell9.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell9.Border = 0;
            tab2.AddCell(YrltDetCell9);

            //Fourth row************
            Cell YrltDetCell10 = new Cell(new Chunk("  Total Rupees ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell10.Border = 0;
            tab2.AddCell(YrltDetCell10);
            Cell YrltDetCell12 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[15].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell12.Border = 0;
            YrltDetCell12.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell12);

            //Fifth row************
            Cell YrltDetCell13 = new Cell(new Chunk("  Deduct Withdrawals ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell13.Border = 0;
            tab2.AddCell(YrltDetCell13);
            Cell YrltDetCell15 = new Cell(new Chunk(" " + withdrawal + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell15.Border = 0;
            YrltDetCell15.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(YrltDetCell15);



            //Correction entry row************
            Cell CorrE1 = new Cell(new Chunk("  Corrected amount ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            CorrE1.Border = 0;
            tab2.AddCell(CorrE1);
            Cell CorrE2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[28].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            CorrE2.Border = 0;
            CorrE2.HorizontalAlignment = Element.ALIGN_RIGHT;
            tab2.AddCell(CorrE2);


            //Sixth row************
            Cell YrltDetCell16 = new Cell(new Chunk("  Balance on " + dst.Tables[0].Rows[tt - 1].ItemArray[3].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell16.Border = 0;
            tab2.AddCell(YrltDetCell16);
            Cell YrltDetCell18 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
            YrltDetCell18.HorizontalAlignment = Element.ALIGN_RIGHT;
            YrltDetCell18.Border = 0;
            tab2.AddCell(YrltDetCell18);
            tab2.Padding = 1;
            docTab1.Add(tab2);

            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(int.Parse(tctAccNo.Text.ToString()));
            ds = gen.getCurrentLB(arr);

            docTab1.Add(new Phrase(new Chunk("District : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[25].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            //docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[0].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            docTab1.Add(new Phrase(new Chunk("\n Office : " + ds1.Tables[0].Rows[ds1.Tables[0].Rows.Count - 1].ItemArray[13].ToString(), FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            //docTab1.Add(new Phrase(new Chunk("\n Closing Balance in words: Rupees One Lakhs Thirteen Thousand Six Hundred Eighty-Seven Only", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n NB:-This is a computer generated document and hence requires no signature", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Place: Thiruvananthapuram", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            docTab1.Add(new Phrase(new Chunk("\n Date: " + date, FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));
            //string Ack;
            //Phrase Ack1 = new Phrase(" Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Corporation Golden Jubilee Building, opposite SMV school, Near Over bridge,Thampanoor-1 Phone:- 0471-2461043  Email :- aokpepf@lsgkerala.in  within 15 days along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            //HeaderFooter headprint1 = new HeaderFooter(Ack1, false);
            //headprint1.BorderWidthTop = Rectangle.TOP_BORDER;
            //headprint1.Alignment = Element.ALIGN_RIGHT;
            //docTab1.Footer = headprint1;
            docTab1.Add(new Phrase(new Chunk("\n The closing balance indicated is subject to variation on account of missing Credits/Debits if any noticed and accounted for later due to various means.", FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));

            subscrip = 0;
            refund = 0;
            arrDA = 0;
            total = 0;
            withdrawal = 0;
            docTab1.NewPage();
            docTab1.Close();
            String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../PDF/" + strFileName + "' height='600'></iframe>";
            PDE.InnerHtml = frame;
            //Response.Redirect("../PDF/" + strFileName);
        }
        else
        {
            gblObj.MsgBoxOk("No data!", this);
        }
    }
    //protected void btnStmnt_Click(object sender, EventArgs e)
    //{
    //    //iframePDE.Visible = false;
    //    gdvAnnStmnt.Visible = true;
    //    FillGrid();
    //}

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["flg"] = 3;
        Session["flgcs"] = 1;
        btnBack.PostBackUrl = "~/Contents/CreditCardPin2.aspx";
    }
}
