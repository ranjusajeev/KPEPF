using System;
using System.Collections.Generic;
using System.Text;


namespace KPEPFClassLibrary
{
    public class WithdrawalC
    {
        #region fields
        private int intWithdrawConId;
        private int intYearId;
        private int intMonthId;
        private int intDTId;
        private int intSourceId;
        private float fltTAdvAmt;
        private float fltAGAdvAmt;
        private DateTime dtAccDate;
        private DateTime dtTrnDate;
        private int intSlNo;
        private int intModeChg;
        #endregion

        #region Property
        public int IntModeChg
        {
            get
            {
                return this.intModeChg;
            }
            set
            {
                intModeChg = value;
            }
        }
        public int IntWithdrawConId
        {
            get
            {
                return this.intWithdrawConId;
            }
            set
            {
                intWithdrawConId = value;
            }
        }
        public int IntYearId
        {
            get
            {
                return this.intYearId;
            }
            set
            {
                intYearId = value;
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
        public int IntDTId
        {
            get
            {
                return this.intDTId;
            }
            set
            {
                intDTId = value;
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
        public float FltTAdvAmt
        {
            get
            {
                return this.fltTAdvAmt;
            }
            set
            {
                fltTAdvAmt = value;
            }
        }
        public float  FltAGAdvAmt
        {
            get
            {
                return this.fltAGAdvAmt;
            }
            set
            {
                fltAGAdvAmt = value;
            }
        }
        public DateTime DtAccDate
        {
            get
            {
                return this.dtAccDate;
            }
            set
            {
                dtAccDate = value;
            }
        }
        public DateTime DtTrnDate
        {
            get
            {
                return this.dtTrnDate;
            }
            set
            {
                dtTrnDate = value;
            }
        }
        #endregion
    }

}
