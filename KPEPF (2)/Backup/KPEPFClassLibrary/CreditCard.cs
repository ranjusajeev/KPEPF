using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class CreditCard
    {
        #region fields
        private double  numLedgerId;
        private double numEmpId;
        private int intYrId;
        private int intDay;
        private int intMonthId;
        private DateTime  dtChalDate;
        private float fltMsAmt;
        private float fltRfAmt;
        private float fltArrPFAmt;
        private float fltArrDaAmt;
        private float fltArrPayAmt;
        private float fltWithdrawAmt;
        private float fltMonthlyOB;
        private float fltAmtForInt;
        private int intInstitutionID;
        private string  chvLoanNo;
        private DateTime dtmLoanDate;
        private string chvArrNo;
        private DateTime dtmArrDate;
        private int intPerMnthId;
        private int intPerYrId;
        private int intChalanNo;
        private int intTreasuryId;
        private int tnyWithdrawalType;
        private int intFlgCorr;
        private long intUserId;
        private DateTime dtmDateOfEntry;
        private int intGOId;
        private string chvRemarks;
        private int intLBId;
        private string chvWithDtNo;
        private int intBillId;
        private int intChalanId;


        #endregion

        #region properties
        public double NumLedgerId
        {
            get
            {
                return this.numLedgerId;
            }
            set
            {
                numLedgerId = value;
            }
        }
        public double NumEmpId
        {
            get
            {
                return this.numEmpId;
            }
            set
            {
                numEmpId = value;
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
        public int IntDay
        {
            get
            {
                return this.intDay;
            }
            set
            {
                intDay = value;
            }
        }
        public int IntMonthId
        {
            get
            {
                return this.intMonthId;
            }
            set
            {
                intMonthId = value;
            }
        }
        public DateTime  DtChalDate
        {
            get
            {
                return this.dtChalDate;
            }
            set
            {
                dtChalDate = value;
            }
        }
        public float FltMsAmt
        {
            get
            {
                return this.fltMsAmt;
            }
            set
            {
                fltMsAmt = value;
            }
        }
        public float FltRfAmt
        {
            get
            {
                return this.fltRfAmt;
            }
            set
            {
                fltRfAmt = value;
            }
        }
        public float FltArrPFAmt
        {
            get
            {
                return this.fltArrPFAmt;
            }
            set
            {
                fltArrPFAmt = value;
            }
        }
        public float FltArrDaAmt
        {
            get
            {
                return this.fltArrDaAmt;
            }
            set
            {
                fltArrDaAmt = value;
            }
        }
        public float FltArrPayAmt
        {
            get
            {
                return this.fltArrPayAmt;
            }
            set
            {
                fltArrPayAmt = value;
            }
        }
        public float FltWithdrawAmt
        {
            get
            {
                return this.fltWithdrawAmt;
            }
            set
            {
                fltWithdrawAmt = value;
            }
        }
        public float FltMonthlyOB
        {
            get
            {
                return this.fltMonthlyOB;
            }
            set
            {
                fltMonthlyOB = value;
            }
        }
        public float FltAmtForInt
        {
            get
            {
                return this.fltAmtForInt;
            }
            set
            {
                fltAmtForInt = value;
            }
        }
        public int  IntInstitutionID
        {
            get
            {
                return this.intInstitutionID;
            }
            set
            {
                intInstitutionID = value;
            }
        }
        public string  ChvLoanNo
        {
            get
            {
                return this.chvLoanNo;
            }
            set
            {
                chvLoanNo = value;
            }
        }
        public DateTime DtmLoanDate
        {
            get
            {
                return this.dtmLoanDate;
            }
            set
            {
                dtmLoanDate = value;
            }
        }
        public string  ChvArrNo
        {
            get
            {
                return this.chvArrNo;
            }
            set
            {
                chvArrNo = value;
            }
        }
        public DateTime DtmArrDate
        {
            get
            {
                return this.dtmArrDate;
            }
            set
            {
                dtmArrDate = value;
            }
        }



        public int IntPerMnthId
        {
            get
            {
                return this.intPerMnthId;
            }
            set
            {
                intPerMnthId = value;
            }
        }
        public int IntPerYrId
        {
            get
            {
                return this.intPerYrId;
            }
            set
            {
                intPerYrId = value;
            }
        }
        public int IntChalanNo
        {
            get
            {
                return this.intChalanNo;
            }
            set
            {
                intChalanNo = value;
            }
        }
        public int IntTreasuryId
        {
            get
            {
                return this.intTreasuryId;
            }
            set
            {
                intTreasuryId = value;
            }
        }
        public int TnyWithdrawalType
        {
            get
            {
                return this.tnyWithdrawalType;
            }
            set
            {
                tnyWithdrawalType = value;
            }
        }
        public int IntFlgCorr
        {
            get
            {
                return this.intFlgCorr;
            }
            set
            {
                intFlgCorr = value;
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
        public DateTime DtmDateOfEntry
        {
            get
            {
                return this.dtmDateOfEntry;
            }
            set
            {
                dtmDateOfEntry = value;
            }
        }
        public int IntGOId
        {
            get
            {
                return this.intGOId;
            }
            set
            {
                intGOId = value;
            }
        }
        public string ChvRemarks
        {
            get
            {
                return this.chvRemarks;
            }
            set
            {
                chvRemarks = value;
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
        public string ChvWithDtNo
        {
            get
            {
                return this.chvWithDtNo;
            }
            set
            {
                chvWithDtNo = value;
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
        public int IntChalanId
        {
            get
            {
                return this.intChalanId;
            }
            set
            {
                intChalanId = value;
            }
        }
        
        #endregion
    }
}
