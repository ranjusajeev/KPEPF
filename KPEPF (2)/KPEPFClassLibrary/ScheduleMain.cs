using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public  class ScheduleMain
    {
        #region fields

        private int intSchMainId;
	    private int intBundId;
		private int intsubBundId;
		private int intLbId;
        private int intGroupId;
		private int intChalanId;
		private int intSchedId;
		private int flgMs;
		private int flgRf;
		private int flgPf;
		private int flgDa;
		private int flgPay;
		private float  fltVerticalSum_Ms;
		private float fltVerticalSum_Rf;
		private float fltVerticalSum_Pf;
		private float fltVerticalSum_Da;
		private float fltVerticalSum_Pay;
		private float fltTotalSum;
		private int flgAmtMismatch;
		private int intModeOfChgId;
		private long   intUserId;
		private string dtmDateOfUpdation;
		private string  chvRemarks;
        #endregion

         #region properties

        public int IntSchMainId
        {
            get
            {
                return this.intSchMainId;
            }
            set
            {
                intSchMainId = value;
            }
        }
        public int IntBundId
        {
            get
            {
                return this.intBundId;
            }
            set
            {
                intBundId = value;
            }
        }
        public int IntsubBundId
        {
            get
            {
                return this.intsubBundId;
            }
            set
            {
                intsubBundId = value;
            }
        }
        public int IntLbId
        {
            get
            {
                return this.intLbId;
            }
            set
            {
                intLbId = value;
            }
        }
        public int IntGroupId
        {
            get
            {
                return this.intGroupId;
            }
            set
            {
                intGroupId = value;
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
        public int IntSchedId
        {
            get
            {
                return this.intSchedId;
            }
            set
            {
                intSchedId = value;
            }
        }
        public int FlgMs
        {
            get
            {
                return this.flgMs;
            }
            set
            {
                flgMs = value;
            }
        }
        public int FlgRf
        {
            get
            {
                return this.flgRf;
            }
            set
            {
                flgRf = value;
            }
        }
        public int FlgPf
        {
            get
            {
                return this.flgPf;
            }
            set
            {
                flgPf = value;
            }
        }
        public int FlgDa
        {
            get
            {
                return this.flgDa;
            }
            set
            {
                flgDa = value;
            }
        }
        public int FlgPay
        {
            get
            {
                return this.flgPay;
            }
            set
            {
                flgPay = value;
            }
        }
        public float  FltVerticalSum_Ms
        {
            get
            {
                return this.fltVerticalSum_Ms;
            }
            set
            {
                fltVerticalSum_Ms = value;
            }
        }
        public float FltVerticalSum_Rf
        {
            get
            {
                return this.fltVerticalSum_Rf;
            }
            set
            {
                fltVerticalSum_Rf = value;
            }
        }
        public float FltVerticalSum_Pf
        {
            get
            {
                return this.fltVerticalSum_Pf;
            }
            set
            {
                fltVerticalSum_Pf = value;
            }
        }
        public float FltVerticalSum_Da
        {
            get
            {
                return this.fltVerticalSum_Da;
            }
            set
            {
                fltVerticalSum_Da = value;
            }
        }
        public float FltVerticalSum_Pay
        {
            get
            {
                return this.fltVerticalSum_Pay;
            }
            set
            {
                fltVerticalSum_Pay = value;
            }
        }
        public float FltTotalSum
        {
            get
            {
                return this.fltTotalSum;
            }
            set
            {
                fltTotalSum = value;
            }
        }
        public int  FlgAmtMismatch
        {
            get
            {
                return this.flgAmtMismatch;
            }
            set
            {
                flgAmtMismatch = value;
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

        public string  DtmDateOfUpdation
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
         #endregion  



    }
}
