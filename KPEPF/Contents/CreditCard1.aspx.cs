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
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KPEPFClassLibrary;


public partial class Contents_CreditCard1 : System.Web.UI.Page
{
    clsGlobalMethods gblObj = new clsGlobalMethods();
    GeneralDAO gen = new GeneralDAO();
    Employee emp = new Employee();
    EmployeeDAO empDao = new EmployeeDAO();
    LedgerYDao ldgrDao = new LedgerYDao();
    CorrectionEntry crr = new CorrectionEntry();
    CorrectionEntryDao crrD = new CorrectionEntryDao();
    static string accno = "";
    static string ename = "";
    static int flgEmp = 0;
    static int flgTrn = 0;
    static int tt = 0;
    static int balmnth;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gen.GetYearRem();
            gblObj.FillCombo(ddlYear, ds, 1);
            //gblObj.GetSessionValsByCheck(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            gblObj.GetSessionVals(Convert.ToInt16(Request.QueryString["k"]), Convert.ToInt16(Request.QueryString["s"]), Convert.ToInt16(Request.QueryString["h"]));
            if (Convert.ToInt16(Session["intTrnType"]) == 40)
            {
                lblHead.Text = "Credit Card";
                btnLedger.Text = "Credit Card";
                btnGen.Visible = false;
            }
            else
            {
                lblHead.Text = "Ledger";
                btnLedger.Text = "Ledger";
                btnGen.Visible = true;
            }
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlYear.SelectedValue) > 0)
        {
            Session["intYearIdLedger"] = int.Parse(ddlYear.SelectedValue.ToString());
            tt = int.Parse(ddlYear.SelectedIndex.ToString());
            iframePDE.Visible = true;
        }
        else
        {
            Session["intYearIdLedger"] = 0;
            iframePDE.Visible = false ;
            PDE.InnerHtml = "";
        }
       
        //if (tctAccNo.Text.ToString() != "")
        //{
        //    tt = int.Parse(ddlYear.SelectedIndex.ToString());
        //    Session["intYearIdLedger"] = int.Parse(ddlYear.SelectedValue.ToString());
        //    if (Convert.ToInt16(Session["intTrnType"]) == 40)
        //    {
        //        FillCard();
        //    }
        //    else
        //    {
        //        Response.Redirect("Reportviewer.aspx?ReportID=8");
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter Acc. No.!", this);
        //}
    }
    protected void FillCard()
    {
        Session["intYrCal"] = gen.GetCCYearId();
        ArrayList arrIn = new ArrayList();
        DataSet ds = new DataSet();
        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());

        //int flgEmp = ChkEmp();
        //int flgTrn = ChkTrn();
        //////////////////ChkEmp/////////////
        DataSet dsEmp = new DataSet();
        emp.NumEmpID = int.Parse(tctAccNo.Text.ToString());
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
        if (int.Parse(ddlYear.SelectedValue) >= 50)
        {
            dsTrn = ldgrDao.GetYearlyDetLat(arE);
        }
        else
        {
            dsTrn = ldgrDao.GetYearlyDet(arE);
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
            string FlPathL = Request.PhysicalApplicationPath + "Ledger/" + strFileName;
            if (Convert.ToInt16(Session["intYearIdLedger"]) >= 50)
            {
                if (Convert.ToInt32(Session["intYrCal"]) == Convert.ToInt32(ddlYear.SelectedValue))
                {
                    if (CorrectionExists(int.Parse(tctAccNo.Text.ToString())) == true)
                    {
                        GeneratePDFCorrEntry(FlPath, strFileName);
                    }

                    else
                    {
                        GeneratePDF(FlPath, strFileName, 2);
                    }
                }
                else  //if( Convert.ToInt32(ddlYear.SelectedValue) == 50)

                {
                    if (CorrectionExistsPrev(int.Parse(tctAccNo.Text.ToString()), Convert.ToInt16(Session["intYearIdLedger"])) == true)
                    {
                        GeneratePDFCorrEntry(FlPath, strFileName);
                    }

                    else
                    {
                        GeneratePDF(FlPath, strFileName, 2);
                    }
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
    private Boolean CorrectionExistsPrev(Int32 empID,int yr)
    {
        Boolean flg = true;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(empID);
        crr.IntAccNo = empID;
        crr.IntYearID = yr;
        dsCg = crrD.CheckCorrectionEntry4CardGenPrev(crr);
        if (dsCg.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(dsCg.Tables[0].Rows[0].ItemArray[0]) != 0)
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

    private Boolean CorrectionExists(Int32 empID)
    {
        Boolean flg = true;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(empID);
        ar.Add(Convert.ToInt16(Session["intYearIdLedger"]));
        //dsCg = crrD.CheckCorrectionEntry4CardGen(crr);
        dsCg = crrD.CheckCorrectionEntry4CardGenLat(ar);
        if (dsCg.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToDouble(dsCg.Tables[0].Rows[0].ItemArray[0]) != 0)
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
    private string strGenerateFileName()
    {
        string accno = tctAccNo.Text.ToString();
        string yrid = ddlYear.SelectedValue.ToString();
        string flnm = accno + "_" + yrid + ".pdf";
        return flnm;
    }
    private void GeneratePDF(string FlPath, string strFileName,int flg)
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
            //if (Convert.ToInt16(ddlYear.SelectedValue) == 49)
            //{
            //    docTab1.Add(head2);
            //}
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
            ////tab1.BorderColor = new Color(0, 0, 0);
            //Fill Tables****************

            //Yearly data**********************
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            //if (ds3.Tables[0].Rows.Count != 0)
            //{
            //    if (Convert.ToInt16(ds3.Tables[0].Rows[0].ItemArray[0]) == 1)
            //    {
            //        Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[1].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            //        Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[1].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
                 
            //        docTab1.Add(Name);
            //        docTab1.Add(Namea);
            //        docTab1.Add(Acc);
            //    }
            //    else if (Convert.ToInt16(ds3.Tables[0].Rows[0].ItemArray[0]) == 2)
            //    {
            //        Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            //        Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase IntRt1 = new Phrase("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"
            //            + ds3.Tables[0].Rows[0].ItemArray[2].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

            //        docTab1.Add(Name);
            //        docTab1.Add(Namea);
            //        docTab1.Add(Acc);
            //        docTab1.Add(IntRt1);
            //    }
            //    else
            //    {
            //        Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            //        Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[1].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase IntRt1 = new Phrase("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"
            //            + ds3.Tables[0].Rows[0].ItemArray[2].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));
            //        Phrase IntRt2 = new Phrase("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"
            //             + ds3.Tables[0].Rows[0].ItemArray[3].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

            //        docTab1.Add(Name);
            //        docTab1.Add(Namea);
            //        docTab1.Add(Acc);
            //        docTab1.Add(IntRt1);
            //        docTab1.Add(IntRt2);
            //    }
            //}
            //}
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
            ////iTextSharp.text.Table nested = new iTextSharp.text.Table(2);
            ////Cell header = new Cell(new Phrase("Subscription"));
            ////header.Rowspan = 2;
            ////nested.AddCell(header);
            ////Cell subheadera = new Cell(new Phrase("Subscription Amount"));
            ////nested.AddCell(subheadera);
            ////Cell subheaderb = new Cell(new Phrase("Arrear Subscripion"));
            ////nested.AddCell(subheaderb);
            //////nested.AddCell("Subscription Amount");
            //////nested.AddCell("Arrear Subscripion");
            ////Cell nesthousing = new Cell(nested);
            //////nesthousing.Padding = 0f;
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

            docTab1.Add(new Phrase(new Chunk("\n The closing balance indicated is subject to variation on account of missing Credits/Debits if any noticed and accounted for later due to various means." , FontFactory.GetFont(FontFactory.TIMES, 10, Font.NORMAL, new Color(0, 0, 0)))));


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
                genPDFNonTrn(Convert.ToInt32(tctAccNo.Text), Convert.ToInt16(ddlYear.SelectedValue),FlPath,strFileName);
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


                //Correction row************
                Cell YrltDetCell1cr1 = new Cell(new Chunk("  Corrected amount  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell13.Border = 0;
                tab2.AddCell(YrltDetCell1cr1);
                Cell YrltDetCell1cr2 = new Cell(new Chunk(" " + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + " ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0))));
                YrltDetCell1cr2.Border = 0;
                YrltDetCell1cr2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tab2.AddCell(YrltDetCell1cr2);
                //Correction row************


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

            //if (ds3.Tables[0].Rows.Count != 0)
            //{
            //    //Name & Acc No
            //    //int Rate =int.Parse( ds3.Tables[0].Rows[0].ItemArray[0].ToString());
            //    //string strEmpName = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
            //    //string strAccNo = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            //    Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
            //    Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
            //    Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

            //    docTab1.Add(Name);
            //    docTab1.Add(Namea);
            //    docTab1.Add(Acc);
            //}
            //}

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
            ////iTextSharp.text.Table nested = new iTextSharp.text.Table(2);
            ////Cell header = new Cell(new Phrase("Subscription"));
            ////header.Rowspan = 2;
            ////nested.AddCell(header);
            ////Cell subheadera = new Cell(new Phrase("Subscription Amount"));
            ////nested.AddCell(subheadera);
            ////Cell subheaderb = new Cell(new Phrase("Arrear Subscripion"));
            ////nested.AddCell(subheaderb);
            //////nested.AddCell("Subscription Amount");
            //////nested.AddCell("Arrear Subscripion");
            ////Cell nesthousing = new Cell(nested);
            //////nesthousing.Padding = 0f;
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

    private void GeneratePDFLedger(string FlPath, string strFileName)
    {
        Document docTab1 = new Document();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        ArrayList arrIn1 = new ArrayList();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(tctAccNo.Text.ToString());
        arrIn.Add(ddlYear.SelectedValue.ToString());
        ds1 = gen.CCard(arrIn);
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

            Phrase footPhraseImg = new Phrase("Remarks:-   Complaints regarding missing credits and unfinalised opening balance should be forwarded to the Accounts Officer, KPEPF,Panchayat Directorate (Annexe), Swaraj Bhavan(6th floor), Nanthancode, Kowdiar P.O,Tvpm Phone:- 0471-2723043  Email :- aokpepf@lsgkerala.in  within 15 days along with the following documents.\n 1.	Treasury remittance certificate and schedule/attested copies of chalan and schedule and concerned pages of the Payment Register and PF Register.  \n 2.  Service details \n 3.  Statement regarding missing credits.(Statement from last credit card in the case of unfinalised opening balance)\n\t\t\t\t\tKPEPF details of all Subscribers being updated on the websit\t\t http://www.lsgkerala.gov.in/kpepf \n\nPage:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
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
            docTab1.Add(new Phrase(new Chunk("\n")));
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
            ////tab1.BorderColor = new Color(0, 0, 0);
            //Fill Tables****************

            //Yearly data**********************
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            if (ds3.Tables[0].Rows.Count != 0)
            {
                //Name & Acc No
                //int Rate =int.Parse( ds3.Tables[0].Rows[0].ItemArray[0].ToString());
                //string strEmpName = ds2.Tables[0].Rows[0].ItemArray[1].ToString();
                //string strAccNo = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
                Phrase Name = new Phrase("Name Shri./Smt. ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 0)));
                Phrase Namea = new Phrase(new Chunk(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD, new Color(0, 0, 0))));
                Phrase Acc = new Phrase("         \t\t\t\t\t\t\tAccount Number : " + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "    \t\t\t\t\t\t\tRate of Interest : " + ds3.Tables[0].Rows[0].ItemArray[0].ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, new Color(0, 0, 0)));

                docTab1.Add(Name);
                docTab1.Add(Namea);
                docTab1.Add(Acc);
            }
            //}

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
            ////iTextSharp.text.Table nested = new iTextSharp.text.Table(2);
            ////Cell header = new Cell(new Phrase("Subscription"));
            ////header.Rowspan = 2;
            ////nested.AddCell(header);
            ////Cell subheadera = new Cell(new Phrase("Subscription Amount"));
            ////nested.AddCell(subheadera);
            ////Cell subheaderb = new Cell(new Phrase("Arrear Subscripion"));
            ////nested.AddCell(subheaderb);
            //////nested.AddCell("Subscription Amount");
            //////nested.AddCell("Arrear Subscripion");
            ////Cell nesthousing = new Cell(nested);
            //////nesthousing.Padding = 0f;
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
            dst = gen.GetYearPDE();
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
            String frame = "<iframe  Width='100%' id ='iframePDE' scrolling='auto' runat='server'   frameborder='1' src='../Ledger/" + strFileName + "' height='600'></iframe>";
            PDE.InnerHtml = frame;
            //Response.Redirect("../PDF/" + strFileName);
        }else
        {
            gblObj.MsgBoxOk("No data!", this);
        }
    }

    protected void tctAccNo_TextChanged(object sender, EventArgs e)
    {

        ddlYear.SelectedIndex = 0;
        iframePDE.Visible = false;
        PDE.InnerHtml = "";
        if (Convert.ToInt32(tctAccNo.Text) > 0)
        {
            Session["intCnt"] = 0;
            Session["numEmpIdLedger"] = Convert.ToInt32(tctAccNo.Text);
            DataSet dsN = new DataSet();
            FillNameAccNo();
        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.!", this);
        }
        //if (CorrectionExists(int.Parse(tctAccNo.Text.ToString())) == true)
        //{
        //    if (ApprovalStatus(int.Parse(tctAccNo.Text.ToString())) == true)
        //    {
                //btnGen.Enabled = true;
                //btnLedger.Enabled = true;
            //}
            //else
            //{
            //    btnGen.Enabled = false;
            //    btnLedger.Enabled = false;
            //    gblObj.MsgBoxOk("Approve all Corrections and Generate Card!", this);
            //}
        //}
        //else
        //{
        //    btnGen.Enabled = false;
        //}



        //ddlYear.SelectedIndex = 0;
        //iframePDE.Visible = false;
        //PDE.InnerHtml = "";
        //if (Convert.ToInt32(tctAccNo.Text) > 0)
        //{
        //    Session["intCnt"] = 0;
        //    Session["numEmpIdLedger"] = Convert.ToInt32(tctAccNo.Text);
        //    DataSet dsN = new DataSet();
        //    FillNameAccNo();
        //}
        ////if (Convert.ToInt16(Session["intTrnType"]) == 41)
        ////{
        //    if (CorrectionExists(int.Parse(tctAccNo.Text.ToString())) == true)
        //    {
        //        if (ApprovalStatus(int.Parse(tctAccNo.Text.ToString())) == true)
        //        {
        //            btnGen.Enabled = true;
        //            btnLedger.Enabled = true;
        //        }
        //        else
        //        {
        //            btnGen.Enabled = false;
        //            btnLedger.Enabled = false;
        //            gblObj.MsgBoxOk("Approve all Corrections and Generate Card!", this);
        //        }
        //    }
        //    else
        //    {
        //        btnGen.Enabled = false;
        //    }
        ////}
    }
    private Boolean ApprovalStatus(Int32 empID)
    {
        Boolean flg = true;
        DataSet dsCg = new DataSet();
        ArrayList ar = new ArrayList();
        ar.Add(empID);
        crr.IntAccNo = empID;
        dsCg = crrD.GetCorrectionEntry4CardGen(crr);
        if (dsCg.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsCg.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt16(dsCg.Tables[0].Rows[i].ItemArray[7].ToString()) == 2)
                {
                    Session["intCnt"] = Convert.ToInt16(Session["intCnt"]) + 1;
                }
                else
                {
                    if (Convert.ToInt16(dsCg.Tables[0].Rows[i].ItemArray[12].ToString()) != 2)
                    {
                        Session["intCnt"] = Convert.ToInt16(Session["intCnt"]) + 1;
                    }
                }

            }
        }
        else
        {
            Session["intCnt"] = Convert.ToInt16(Session["intCnt"]) + 1;
        }
        if (Convert.ToInt16(Session["intCnt"]) == 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
    private void FillNameAccNo()
    {
        DataSet dsN = new DataSet();
        emp.NumEmpID = Convert.ToInt32(tctAccNo.Text);
        dsN = empDao.GetEmployeeDetails(emp, 1);
        if (dsN.Tables[0].Rows.Count > 0)
        {
            lblClosed.Text = dsN.Tables[0].Rows[0].ItemArray[9].ToString();
            //lblAccNo.Text = dsN.Tables[0].Rows[0].ItemArray[0].ToString();
            //lblName.Text = dsN.Tables[0].Rows[0].ItemArray[1].ToString();
            //lblDistName.Text = dsN.Tables[0].Rows[0].ItemArray[8].ToString();
        }
        //else
        //{
        //    lblClosed.Text = "";
        //}
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    //private void SetGridDefault()
    //{
    //    ArrayList ar = new ArrayList();
    //    ar.Add("");
    //    gblObj.SetGridDefault(gdvCorr, ar);
    //}
    protected void btnGen_Click(object sender, EventArgs e)
    {
        gblObj.SetBlankRow(gdvCorr);

        lsubFillgrid();
        Save_C_CorrectionEntry();
      //  Response.Redirect("Reportviewer.aspx?ReportID=9");
    }
    private void Save_C_CorrectionEntry()
    {
        ArrayList ard = new ArrayList();
        ard.Add(Convert.ToInt32(Session["numEmpIdLedger"]));
        crrD.DelCorrEntryChild(ard);
        for (int j = 0; j < gdvCorr.Rows.Count; j++)
        {
            ArrayList arr = new ArrayList();

            GridViewRow gvr = gdvCorr.Rows[j];
            TextBox txtYr = (TextBox)gvr.FindControl("txtYr");        //chv year
            TextBox txtchlDt = (TextBox)gvr.FindControl("txtchlDt");        //chalan dt
            TextBox txtAm = (TextBox)gvr.FindControl("txtAm");        //org amt
            TextBox txtRt = (TextBox)gvr.FindControl("txtRt");        //rt of interest

            TextBox lblCalcAss = (TextBox)gvr.FindControl("txtcal");
            TextBox lblTotalAss = (TextBox)gvr.FindControl("txttotl");
            TextBox lblHdnIntAmtAss = (TextBox)gvr.FindControl("txtintamt");

            arr.Add(Convert.ToInt32(Session["numEmpIdLedger"]));     //acc no
            arr.Add(txtYr.Text.ToString());     //chv year
            if (txtchlDt.Text != "&nbsp;" && txtchlDt.Text != "")
            {
                arr.Add(txtchlDt.Text.ToString());     //chalan dt
            }
            else
            {
                arr.Add(DBNull.Value);     //chalan dt
            }
            arr.Add(Convert.ToDouble(txtAm.Text));     //org amt
            arr.Add(Convert.ToDouble(txtRt.Text));     //rt of interest
            arr.Add(Convert.ToDouble(lblHdnIntAmtAss.Text));     //interest amt
            arr.Add(Convert.ToDouble(lblTotalAss.Text));     //total
            arr.Add(lblCalcAss.Text.ToString());     //chv calc
            arr.Add(j + 1);
            crrD.SaveCorrEntryChild(arr);

        }
    }
    public void lsubFillgrid()
    {
        DataSet dsfill = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(tctAccNo.Text));

        dsfill = crrD.FillCorrectionEntry(arr);
        if (dsfill.Tables[0].Rows.Count > 0)
        {

            gdvCorr.DataSource = dsfill;
            gdvCorr.DataBind();
            for (int i = 0; i < dsfill.Tables[0].Rows.Count; i++)
            {
                GridViewRow gdv = gdvCorr.Rows[i];
                TextBox txtYrAss = (TextBox)gdv.FindControl("txtYr");
                txtYrAss.Text = dsfill.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtchlDtAss = (TextBox)gdv.FindControl("txtchlDt");
                txtchlDtAss.Text = dsfill.Tables[0].Rows[i].ItemArray[3].ToString();

                TextBox txtAmAss = (TextBox)gdv.FindControl("txtAm");
                txtAmAss.Text = dsfill.Tables[0].Rows[i].ItemArray[4].ToString();

                TextBox txtRtAss = (TextBox)gdv.FindControl("txtRt");
                txtRtAss.Text = dsfill.Tables[0].Rows[i].ItemArray[1].ToString();

                //TextBox txtcalAss = (TextBox)gdv.FindControl("txtcal");
                //txtcalAss.Text = dsfill.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtSlno = (TextBox)gdv.FindControl("txtSlno");
                txtSlno.Text = dsfill.Tables[0].Rows[i].ItemArray[9].ToString();

                TextBox txtBalMth = (TextBox)gdv.FindControl("txtBalMth");
                txtBalMth.Text = dsfill.Tables[0].Rows[i].ItemArray[10].ToString();

                TextBox txtmnthIdAss = (TextBox)gdv.FindControl("txtmnthId");
                txtmnthIdAss.Text = dsfill.Tables[0].Rows[i].ItemArray[5].ToString();

                TextBox txtbalmnthAss = (TextBox)gdv.FindControl("txtbalmnth");
                //txtbalmnthAss.Text = dsfill.Tables[0].Rows[i].ItemArray[0].ToString();

                TextBox txtyrIdAss = (TextBox)gdv.FindControl("txtyrId");
                txtyrIdAss.Text = dsfill.Tables[0].Rows[i].ItemArray[7].ToString();

                TextBox txttypeAss = (TextBox)gdv.FindControl("txttype");
                txttypeAss.Text = dsfill.Tables[0].Rows[i].ItemArray[8].ToString();

                TextBox txtyrtype = (TextBox)gdv.FindControl("txtyrtype");
                txtyrtype.Text = dsfill.Tables[0].Rows[i].ItemArray[11].ToString();

                TextBox txtuid = (TextBox)gdv.FindControl("txtuid");
                txtuid.Text = dsfill.Tables[0].Rows[i].ItemArray[12].ToString();
                

                //// counting bal month to calc interest   ///////////
                if (Convert.ToInt32(txtAmAss.Text) != 0)
                {
                    if (Convert.ToInt16(txtyrtype.Text) == 1)
                    {
                        if (Convert.ToInt32(txttypeAss.Text) == 1)
                        {
                            balmnth = CalculateBalMonthsWithDay(Convert.ToInt32(txtmnthIdAss.Text), Convert.ToDateTime(txtchlDtAss.Text).Day);
                            txtbalmnthAss.Text = balmnth.ToString();
                        }
                        else if (Convert.ToInt32(txttypeAss.Text) == 2)
                        {
                            balmnth = CalculateBalMonths(Convert.ToInt32(txtmnthIdAss.Text));
                            txtbalmnthAss.Text = balmnth.ToString();
                        }
                        else
                        {
                            txtbalmnthAss.Text = "12";
                        }
                    }
                    else if (Convert.ToInt16(txtyrtype.Text) == 2)
                    {
                        DataSet dsmthcnt = new DataSet();
                        ArrayList arrmthcnt = new ArrayList();

                        if (Convert.ToInt32(txttypeAss.Text) == 1)
                        {
                            arrmthcnt.Add(Convert.ToInt32(txtyrIdAss.Text));
                            arrmthcnt.Add(Convert.ToInt32(txtmnthIdAss.Text));
                            if (Convert.ToDateTime(txtchlDtAss.Text).Day <= 4)
                            {
                                arrmthcnt.Add(1);
                            }
                            else
                            {
                                arrmthcnt.Add(2);
                            }
                            dsmthcnt = crrD.CalculateBalMonthsWithDayMltpl(arrmthcnt);
                            if (dsmthcnt.Tables[0].Rows.Count > 0)
                            {
                                txtbalmnthAss.Text = dsmthcnt.Tables[0].Rows[0].ItemArray[0].ToString();
                            }
                        }
                    }
                    //else
                    //{
                    //    txtbalmnthAss.Text = "12";
                    //}
                }
                
            }
            
            lSubFillInterestAmt1();
        }
    }
    public void lSubFillInterestAmt1()
    {
        Double tot4mltplYear = 0;
        Double baseAmtMltplYr = 0;
        Double grpTotal = 0;

        for (int i = 0; i < gdvCorr.Rows.Count; i++)
        {
            GridViewRow gdv3 = gdvCorr.Rows[i];
            TextBox txtAmtCurr = (TextBox)gdv3.FindControl("txtAm");  //txtAmAss
            TextBox txtintamt = (TextBox)gdv3.FindControl("txtintamt");
            TextBox txttotal = (TextBox)gdv3.FindControl("txttotl");

            TextBox txtRt = (TextBox)gdv3.FindControl("txtRt");
            TextBox txtbalmnthTrn = (TextBox)gdv3.FindControl("txtbalmnth");
            TextBox txtyrId = (TextBox)gdv3.FindControl("txtyrId");
            TextBox txtbalmnth = (TextBox)gdv3.FindControl("txtBalMth");
            TextBox txtuid = (TextBox)gdv3.FindControl("txtuid");
            TextBox txtcal = (TextBox)gdv3.FindControl("txtcal");
            TextBox txtyrtype = (TextBox)gdv3.FindControl("txtyrtype");
            TextBox txtSlno = (TextBox)gdv3.FindControl("txtSlno");

            //// for text of calc ////////////
            TextBox txtcalAss = (TextBox)gdv3.FindControl("txtcal");
            //// for text of calc ////////////
            if (i < gdvCorr.Rows.Count - 1 && i > 0)
            {
                GridViewRow gdvpr = gdvCorr.Rows[i - 1];
                GridViewRow gdvnxt = gdvCorr.Rows[i + 1];

                TextBox txtuidnxt = (TextBox)gdvnxt.FindControl("txtuid");
                TextBox txtuidpr = (TextBox)gdvpr.FindControl("txtuid");
                TextBox txttotalpr = (TextBox)gdvpr.FindControl("txttotl");
                TextBox txtyrIdpr = (TextBox)gdvpr.FindControl("txtyrId");
                TextBox txtyrIdnxt = (TextBox)gdvnxt.FindControl("txtyrId");

                if (Convert.ToInt16(txtyrtype.Text) == 1)       // single rt
                {
                    if (Convert.ToDouble(txtAmtCurr.Text) == 0)
                    {
                        txtintamt.Text = Convert.ToString(Convert.ToDouble(txttotalpr.Text) * Convert.ToDouble(txtRt.Text) / 100);
                        txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text)));

                        txtcalAss.Text = txttotalpr.Text + "*" + txtRt.Text + "/100";
                    }
                    else
                    {
                        if (Convert.ToInt16(txtyrId.Text) != Convert.ToInt16(txtyrIdpr.Text))
                        {
                            txtintamt.Text = Convert.ToString((Convert.ToDouble(txtAmtCurr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnthTrn.Text) / 1200));
                            txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txtintamt.Text) + (Convert.ToDouble(txttotalpr.Text) * Convert.ToDouble(txtRt.Text) / 100)));
                            double a = Convert.ToDouble(txttotalpr.Text);
                            double b = Convert.ToDouble(txtAmtCurr.Text);
                            double c = Convert.ToDouble(txtintamt.Text);
                            double d = Convert.ToDouble(txttotalpr.Text) * Convert.ToDouble(txtRt.Text) / 100;

                            txtcalAss.Text = "(" + txtAmtCurr.Text + "*" + txtRt.Text + "*" + txtbalmnthTrn.Text + "/1200) +(" + txttotalpr.Text + "*" + txtRt.Text + "/100)";
                        }
                        else
                        {
                            txtintamt.Text = Convert.ToString(Convert.ToDouble(txtAmtCurr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnthTrn.Text) / 1200);
                            txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txtintamt.Text)));

                            txtcalAss.Text = txtAmtCurr.Text + "*" + txtRt.Text + "*" + txtbalmnthTrn.Text + "/1200";
                        }
                    }
                }
                else                                            // mltpl rt          
                {
                    if (Convert.ToDouble(txtAmtCurr.Text) == 0)
                    {
                        if (Convert.ToInt16(txtSlno.Text) == 1)
                        {
                            baseAmtMltplYr = Convert.ToDouble(txttotalpr.Text);
                            txtintamt.Text = Convert.ToString(Convert.ToDouble(txttotalpr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200);
                            txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text)));

                            txtcalAss.Text = txttotalpr.Text + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200";
                        }
                        else
                        {
                            if (Convert.ToInt16(txtyrId.Text) != Convert.ToInt16(txtyrIdnxt.Text))       // last row for mltpl year without curr
                            {
                                txtintamt.Text = Convert.ToString(baseAmtMltplYr * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200);
                                txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text) + (Convert.ToDouble(txtAmtCurr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnthTrn.Text) / 1200)));
                                tot4mltplYear = tot4mltplYear + Convert.ToDouble(txttotal.Text);

                                txtcalAss.Text = "("+ baseAmtMltplYr + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200)" + "+ (" + txtAmtCurr.Text + "*" + txtRt.Text + "*" + txtbalmnthTrn.Text + "/1200)" ;
                            }
                            else
                            {
                                txtintamt.Text = Convert.ToString(baseAmtMltplYr * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200);
                                txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text)));
                                //tot4mltplYear = tot4mltplYear + Convert.ToDouble(txttotal.Text);
                                // baseAmtMltplYr = baseAmtMltplYr + Convert.ToDouble(txtAmtCurr.Text);

                                txtcalAss.Text = txttotalpr.Text + "+" + baseAmtMltplYr + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200";
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt16(txtSlno.Text) == 1)
                        {
                            baseAmtMltplYr = Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txttotalpr.Text);
                            txtintamt.Text = Convert.ToString(Convert.ToDouble(txtAmtCurr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnthTrn.Text) / 1200 + (Convert.ToDouble(txttotalpr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200));
                            txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text)));

                            txtcalAss.Text = txttotalpr.Text + "+" + txtAmtCurr.Text + "+ (" + txtAmtCurr.Text + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200) + (" + txttotalpr.Text + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200)";
                        }
                        else
                        {
                            if (Convert.ToInt16(txtyrId.Text) != Convert.ToInt16(txtyrIdnxt.Text))    // last row for mltpl year with curr
                            {
                                txtintamt.Text = Convert.ToString(baseAmtMltplYr * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200);
                                tot4mltplYear = tot4mltplYear + Convert.ToDouble(txttotal.Text);
                                //txttotal.Text = Convert.ToString(Math.Round(tot4mltplYear + Convert.ToDouble(txtintamt.Text)));
                                txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txttotalpr.Text) + Convert.ToDouble(txtintamt.Text)));

                                txtcalAss.Text = txttotalpr.Text + "+" + txtAmtCurr.Text + "+ (" + baseAmtMltplYr + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200)";
                            }
                            else
                            {
                                txtintamt.Text = Convert.ToString(baseAmtMltplYr * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnth.Text) / 1200 + (Convert.ToDouble(txtAmtCurr.Text) * Convert.ToDouble(txtRt.Text) * Convert.ToDouble(txtbalmnthTrn.Text) / 1200));
                                txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtAmtCurr.Text) + Convert.ToDouble(txtintamt.Text) + Convert.ToDouble(txttotalpr.Text)));
                                tot4mltplYear = tot4mltplYear + Convert.ToDouble(txttotal.Text);
                                baseAmtMltplYr = baseAmtMltplYr + Convert.ToDouble(txtAmtCurr.Text);

                                txtcalAss.Text = txttotalpr.Text + "+" + txtAmtCurr.Text + "+ (" + baseAmtMltplYr + "*" + txtRt.Text + "*" + txtbalmnth.Text + "/1200) + (" + txtAmtCurr.Text + "*" + txtRt.Text + "*" + txtbalmnthTrn.Text + "/1200)";
                            }
                        }
                    }
                }
            }
        }
    }
    public  double  FindAmtToCalc(int j, GridView gdv) 
    {
        double calc = 0;
         GridViewRow gdv4 = gdvCorr.Rows[j];
         GridViewRow gdvm1 = gdvCorr.Rows[j - 1];
         GridViewRow gdvm2 = gdvCorr.Rows[j - 2];
        TextBox txtRtAss = (TextBox)gdv4.FindControl("txtRt");
        TextBox txttotlAss1 = (TextBox)gdvm1.FindControl("txttotl");
        TextBox txttotlAss2 = (TextBox)gdvm2.FindControl("txttotl");
        if (Convert.ToDouble(txtRtAss.Text) == 8)
        {
            calc = Convert.ToDouble(txttotlAss1.Text);
        }
        else 
        {
            calc = Convert.ToDouble(txttotlAss2.Text);
        }

        return calc;
    }

  
    public int CalculateBalMonthsWithDay(int Mthid, int intDay)
    {
        int Mno = 0;
        if (intDay <= 4)
        {
            if (Mthid == 1)
            {
                Mno = 3;
            }
            else if (Mthid == 2)
            {
                Mno = 2;
            }
            else if (Mthid == 3)
            {
                Mno = 1;
            }
            else if (Mthid == 4)
            {
                Mno = 12;
            }
            else if (Mthid == 5)
            {
                Mno = 11;
            }
            else if (Mthid == 6)
            {
                Mno = 10;
            }
            else if (Mthid == 7)
            {
                Mno = 9;
            }
            else if (Mthid == 8)
            {
                Mno = 8;
            }
            else if (Mthid == 9)
            {
                Mno = 7;
            }
            else if (Mthid == 10)
            {
                Mno = 6;
            }
            else if (Mthid == 11)
            {
                Mno = 5;
            }
            else if (Mthid == 12)
            {
                Mno = 4;
            }
           
        }
        else
        {
            if (Mthid == 1)
                Mno = 2;
            else if (Mthid == 2)
                Mno = 1;
            else if (Mthid == 3)
                Mno = 0;
            else if (Mthid == 4)
                Mno = 11;
            else if (Mthid == 5)
                Mno = 10;
            else if (Mthid == 6)
                Mno = 9;
            else if (Mthid == 7)
                Mno = 8;
            else if (Mthid == 8)
                Mno = 7;
            else if (Mthid == 9)
                Mno = 6;
            else if (Mthid == 10)
                Mno = 5;
            else if (Mthid == 11)
                Mno = 4;
            else if (Mthid == 12)
                Mno = 3;
            
        }
        return Mno;
        
    }
    public int CalculateBalMonths(int Mthid)
    {
        int Mno = 0;

        if (Mthid == 1)
            Mno = 3;
        else if (Mthid == 2)
            Mno = 2;
        else if (Mthid == 3)
            Mno = 1;
        else if (Mthid == 4)
            Mno = 12;
        else if (Mthid == 5)
            Mno = 11;
        else if (Mthid == 6)
            Mno = 10;
        else if (Mthid == 7)
            Mno = 9;
        else if (Mthid == 8)
            Mno = 8;
        else if (Mthid == 9)
            Mno = 7;
        else if (Mthid == 10)
            Mno = 6;
        else if (Mthid == 11)
            Mno = 5;
        else if (Mthid == 12)
            Mno = 4;
        return Mno;
    }

    protected void btnLedger_Click(object sender, EventArgs e)
    {
        if (tctAccNo.Text.ToString() != "")
        {
            if (Convert.ToInt16(Session["intTrnType"]) == 40)
            {
                FillCard();
            }
            else
            {
                Response.Redirect("Reportviewer.aspx?ReportID=8");
            }
        }
        else
        {
            gblObj.MsgBoxOk("Enter Acc. No.!", this);
        }



        //if (tctAccNo.Text.ToString() != "")
        //{
        //    if (ApprovalStatus() == true)
        //    {
        //        if (Convert.ToInt16(Session["intTrnType"]) == 40)
        //        {
        //            FillCard();
        //        }
        //        else
        //        {
        //            Response.Redirect("Reportviewer.aspx?ReportID=8");
        //        }
        //    }
        //    else
        //    {
        //        gblObj.MsgBoxOk("Approve all corrections",this);
        //    }
        //}
        //else
        //{
        //    gblObj.MsgBoxOk("Enter Acc. No.!", this);
        //}

    }
    //private Boolean CorrectionAllApproved()
    //{
    //    Boolean flg = true;
    //    DataSet dsCg = new DataSet();
    //    crr.IntAccNo = Convert.ToInt32(tctAccNo.Text);
    //    dsCg = crrD.GetCorrectionEntry4CardGen(crr);
    //    if (dsCg.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dsCg.Tables[0].Rows.Count; i++)
    //        {
    //            if (Convert.ToInt16(dsCg.Tables[0].Rows[i].ItemArray[7]) == 2)
    //            {
    //                Session["intCnt"] = Convert.ToInt16(Session["intCnt"]) + 1;
    //            }
    //        }
    //    }
    //    if (Convert.ToInt16(Session["intCnt"]) > 0)
    //    {
    //        flg = false;
    //    }
    //    else
    //    {
    //        flg = true;
    //    }
    //    return flg;
    //}
}





