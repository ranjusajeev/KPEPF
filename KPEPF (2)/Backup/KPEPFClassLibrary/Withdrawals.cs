using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Withdrawals
    {
        #region Variables
        private int intBillNo;
        private string dtmBill;
        private double fltBillAmount;
        public int intYearID;
        public int intMonthID;





         private double  numWithdrawalID;
         private double numWithRequestID;
         private double numEmpID;
         private int intTrnTypeID;
         private float fltAllottedAmt;
         private float fltConsolidatedAmt;
         private int  intNoOfInstalment;
         private long  intUserId;
        
         private DateTime  dtmWithdrawalEmp;
         private double numBillID;
         private string  chvVoucherNo;
         private DateTime dtmVoucher;
         private int flgUnPosted;
         private int intUnPostedRsn;
         private int flgTreasuryRec;
         private int intModeChange;
         private string  chvRem;
        
         private int flgBillType;
         private DateTime  dtSanction;
         private int  intOvbjectOfAdvance;
         private int  intDrawnId;	
         private int  intDesigId;	
         private int  intLBId;	
         private string  chvOrderNo;
         private DateTime  dtmDateOfOrder;
         private string chvOdrNoDtOfPrevTA;
         private int  intObjAdv;
        private double fltAmtPrevTA;
        private double fltBalancePrevTA;
         private float fltAmtInstalment;


        #endregion


        #region Property
        public int IntBillNo 
        {
            get
            {
                return this.intBillNo; 
            }
            set
            {
              intBillNo=value;
            }
        }
        public string DtmBill
        {
            get
            {
                return this.dtmBill;
            }
            set
            {
                dtmBill = value;
            }
        }
        public double FltBillAmount
        {
            get
            {
                return this.fltBillAmount;
            }
            set
            {
                fltBillAmount = value;
            }
        }
        public int YearId
        {
            get
            {
                return this.intYearID;
            }
            set
            {
                intYearID = value;
            }
        }
        public int MonthId
        {
            get
            {
                return this.intMonthID;
            }
            set
            {
                intMonthID = value;
            }
        }







        public double NumWithdrawalID
        {
            get
            {
                return this.numWithdrawalID;
            }
            set
            {
                numWithdrawalID = value;
            }
        }
         public double NumWithRequestID
        {
            get
            {
                return this.numWithRequestID;
            }
            set
            {
                numWithRequestID = value;
            }
        }
        public double NumEmpID
        {
            get
            {
                return this.numEmpID;
            }
            set
            {
                numEmpID = value;
            }
        }
        public int IntTrnTypeID
        {
            get
            {
                return this.intTrnTypeID;
            }
            set
            {
                intTrnTypeID = value;
            }
        }
        public float  FltAllottedAmt
        {
            get
            {
                return this.fltAllottedAmt;
            }
            set
            {
                fltAllottedAmt = value;
            }
        }
        public float  FltConsolidatedAmt
        {
            get
            {
                return this.fltConsolidatedAmt;
            }
            set
            {
                fltConsolidatedAmt = value;
            }
        }
        public int  IntNoOfInstalment
        {
            get
            {
                return this.intNoOfInstalment;
            }
            set
            {
                intNoOfInstalment = value;
            }
        }
        public long IntUserId
        {
            get
            {
                return this.intUserId;
            }
            set
            {
                intUserId = value;
            }
        }
         public DateTime  DtmWithdrawalEmp
        {
            get
            {
                return this.dtmWithdrawalEmp;
            }
            set
            {
                dtmWithdrawalEmp = value;
            }
        }
        public double NumBillID
        {
            get
            {
                return this.numBillID;
            }
            set
            {
                numBillID = value;
            }
        }
          public string  ChvVoucherNo
        {
            get
            {
                return this.chvVoucherNo;
            }
            set
            {
                chvVoucherNo = value;
            }
        }
         public DateTime  DtmVoucher
        {
            get
            {
                return this.dtmVoucher;
            }
            set
            {
                dtmVoucher = value;
            }
        }
         public int  FlgUnPosted
        {
            get
            {
                return this.flgUnPosted;
            }
            set
            {
                flgUnPosted = value;
            }
        }
         public int  IntUnPostedRsn
        {
            get
            {
                return this.intUnPostedRsn;
            }
            set
            {
                intUnPostedRsn = value;
            }
        }
         public int  FlgTreasuryRec
        {
            get
            {
                return this.flgTreasuryRec;
            }
            set
            {
                flgTreasuryRec = value;
            }
        }
          public int  IntModeChange
        {
            get
            {
                return this.intModeChange;
            }
            set
            {
                intModeChange = value;
            }
        }
         public string  ChvRem
        {
            get
            {
                return this.chvRem;
            }
            set
            {
                chvRem = value;
            }
        }
         public int  FlgBillType
        {
            get
            {
                return this.flgBillType;
            }
            set
            {
                flgBillType = value;
            }
        }
        public DateTime  DtSanction
        {
            get
            {
                return this.dtSanction;
            }
            set
            {
                dtSanction = value;
            }
        }
         public int  IntOvbjectOfAdvance
        {
            get
            {
                return this.intOvbjectOfAdvance;
            }
            set
            {
                intOvbjectOfAdvance = value;
            }
        }
       

        public int IntDrawnId
        {
            get
            {
                return this.intDrawnId;
            }
            set
            {
                intDrawnId = value;
            }
        }
         public int IntDesigId
        {
            get
            {
                return this.intDesigId;
            }
            set
            {
                intDesigId = value;
            }
        }
         public int IntLBId
        {
            get
            {
                return this.intLBId;
            }
            set
            {
                intLBId = value;
            }
        }
          public string ChvOrderNo
        {
            get
            {
                return this.chvOrderNo;
            }
            set
            {
                chvOrderNo = value;
            }
        }
          public DateTime DtmDateOfOrder
        {
            get
            {
                return this.dtmDateOfOrder;
            }
            set
            {
                dtmDateOfOrder = value;
            }
        }
        public string ChvOdrNoDtOfPrevTA
        {
            get
            {
                return this.chvOdrNoDtOfPrevTA;
            }
            set
            {
                chvOdrNoDtOfPrevTA = value;
            }
        }
         public  int IntObjAdv
        {
            get
            {
                return this.intObjAdv;
            }
            set
            {
                intObjAdv = value;
            }
        }
        public  double  FltAmtPrevTA
        {
            get
            {
                return this.fltAmtPrevTA;
            }
            set
            {
                fltAmtPrevTA = value;
            }
        }
        public double FltBalancePrevTA
        {
            get
            {
                return this.fltBalancePrevTA;
            }
            set
            {
                fltBalancePrevTA = value;
            }
        }
         public  float FltAmtInstalment
        {
            get
            {
                return this.fltAmtInstalment;
            }
            set
            {
                fltAmtInstalment = value;
            }
        }
         
        #endregion

    }
}
