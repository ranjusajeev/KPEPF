using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KPEPFClassLibrary
{
    public class WithdrawalPDE
    {
    #region fields
        private int intId;
        private int intBillId;
        private int intDisId;
        private int intAccNo;
        private int flgUnidentified;
        private int intDesignation;
        private float fltAdvAmt;
        private string  chvSantionNo;
        private DateTime dtSantion;
        private int intLoan;
        private DateTime dtWithdraw;

        private int intRecNo;
        private float fltConsolidate;
        private int intNoOfInstalments;
        private float fltInstalmentAmt;
        private int intmid;
        private int intYrId;
        private int intModeOfChgId;
        private long intUserId;
        private DateTime dtmDateOfUpdation;
        private double intWithdrawalRefId;

        private string chvOdrNoDtOfPrevTA;
        private int flgUnPosted;
        private float fltAmtPrevTA;
        private float fltBalancePrevTA;
        private int intDrawnBy;
        private int intLoanPurpose;
        private int intUnPostedRsn;
        private int intVoucherAGID;
        private double numWithdrawReqId;
        private int intLBId;
        private int intSourceId;
        private int intSlNo;

        private int intIdAPWith;

    #endregion
        #region Property
        public int IntIdAPWith
        {
            get
            {
                return this.intIdAPWith;
            }
            set
            {
                intIdAPWith = value;
            }
        }
        public int IntBillId
        {
            get
            {
                return this.intBillId;
            }
            set
            {
                intBillId = value;
            }
        }
        public int IntSourceId
        {
            get
            {
                return this.intSourceId;
            }
            set
            {
                intSourceId = value;
            }
        }
        public int IntId
        {
            get
            {
                return this.intId;
            }
            set
            {
                intId = value;
            }
        }
        public int IntDisId
        {
            get
            {
                return this.intDisId;
            }
            set
            {
                intDisId = value;
            }
        }
        public int IntAccNo
        {
            get
            {
                return this.intAccNo;
            }
            set
            {
                intAccNo = value;
            }
        }
        public int FlgUnidentified
        {
            get
            {
                return this.flgUnidentified;
            }
            set
            {
                flgUnidentified = value;
            }
        }
        public int IntDesignation
        {
            get
            {
                return this.intDesignation;
            }
            set
            {
                intDesignation = value;
            }
        }
        public float  FltAdvAmt
        {
            get
            {
                return this.fltAdvAmt;
            }
            set
            {
                fltAdvAmt = value;
            }
        }
        public string ChvSantionNo
        {
            get
            {
                return this.chvSantionNo;
            }
            set
            {
                chvSantionNo = value;
            }
        }
        public DateTime DtSantion
        {
            get
            {
                return this.dtSantion;
            }
            set
            {
                dtSantion = value;
            }
        }
        public int IntLoan
        {
            get
            {
                return this.intLoan;
            }
            set
            {
                intLoan = value;
            }
        }
        public DateTime  DtWithdraw
        {
            get
            {
                return this.dtWithdraw;
            }
            set
            {
                dtWithdraw = value;
            }
        }
        public int IntRecNo
        {
            get
            {
                return this.intRecNo;
            }
            set
            {
                intRecNo = value;
            }
        }
        public float  FltConsolidate
        {
            get
            {
                return this.fltConsolidate;
            }
            set
            {
                fltConsolidate = value;
            }
        }
        public int IntNoOfInstalments
        {
            get
            {
                return this.intNoOfInstalments;
            }
            set
            {
                intNoOfInstalments = value;
            }
        }
        public float  FltInstalmentAmt
        {
            get
            {
                return this.fltInstalmentAmt;
            }
            set
            {
                fltInstalmentAmt = value;
            }
        }
        public int Intmid
        {
            get
            {
                return this.intmid;
            }
            set
            {
                intmid = value;
            }
        }
        public int IntYrId
        {
            get
            {
                return this.intYrId;
            }
            set
            {
                intYrId = value;
            }
        }
        public int IntModeOfChgId
        {
            get
            {
                return this.intModeOfChgId;
            }
            set
            {
                intModeOfChgId = value;
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
        public DateTime  DtmDateOfUpdation
        {
            get
            {
                return this.dtmDateOfUpdation;
            }
            set
            {
                dtmDateOfUpdation = value;
            }
        }
        public double IntWithdrawalRefId
        {
            get
            {
                return this.intWithdrawalRefId;
            }
            set
            {
                intWithdrawalRefId = value;
            }
        }
        public string  ChvOdrNoDtOfPrevTA
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
        public int FlgUnPosted
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
        public float  FltAmtPrevTA
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
        public float FltBalancePrevTA
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
        public int IntDrawnBy
        {
            get
            {
                return this.intDrawnBy;
            }
            set
            {
                intDrawnBy = value;
            }
        }
        public int IntLoanPurpose
        {
            get
            {
                return this.intLoanPurpose;
            }
            set
            {
                intLoanPurpose = value;
            }
        }
        public int IntUnPostedRsn
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
        public int  IntVoucherAGID
        {
            get
            {
                return this.intVoucherAGID;
            }
            set
            {
                intVoucherAGID = value;
            }
        }
        public double  NumWithdrawReqId
        {
            get
            {
                return this.numWithdrawReqId;
            }
            set
            {
                numWithdrawReqId = value;
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
        public int IntSlNo
        {
            get
            {
                return this.intSlNo;
            }
            set
            {
                intSlNo = value;
            }
        }
        #endregion
    }
}
