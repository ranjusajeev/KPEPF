using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class WithdrawalB
    {
        #region fields
        private int intBillWiseId;
        private int intWithdrawConId;
        private DateTime  dtmBillDate;
        private int intBillNo;
        private float fltNetAmt;
        private int intModeChgId;
        private int intSlNo;
        private int flgUnPosted;
        private int intUnPostedReason;
        private int intSourceId;


        #endregion

        #region Property

        public int IntBillWiseId
        {
            get
            {
                return this.intBillWiseId;
            }
            set
            {
                intBillWiseId = value;
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
        public DateTime DtmBillDate
        {
            get
            {
                return this.dtmBillDate;
            }
            set
            {
                dtmBillDate = value;
            }
        }
        public int IntBillNo
        {
            get
            {
                return this.intBillNo;
            }
            set
            {
                intBillNo = value;
            }
        }
        public float FltNetAmt
        {
            get
            {
                return this.fltNetAmt;
            }
            set
            {
                fltNetAmt = value;
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
        public int IntModeChgId
        {
            get
            {
                return this.intModeChgId;
            }
            set
            {
                intModeChgId = value;
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
        
        public int IntUnPostedReason
        {
            get
            {
                return this.intUnPostedReason;
            }
            set
            {
                intUnPostedReason = value;
            }
        }

        #endregion
    }
}
