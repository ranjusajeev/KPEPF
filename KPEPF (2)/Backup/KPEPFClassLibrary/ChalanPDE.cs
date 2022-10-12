using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class ChalanPDE
    {
        #region fields
        private int numChalanId;
        private int intTreasuryId;
        private int intLBId;
        private int intChalanNo;
        private string dtChalanDate;
        private decimal fltChalanAmt;
        private int yearId;
        private int monthId;
        private int perYearId;
        private int perMonthId;

        private long intUserId;
        private int flgUnposted;

        private int intUnPostedRsn;
        private int intModeChange;
        private int flgSource;
        private int intDay;

        private double dblChalanRefId;
        private double dblChalanAGRefId;

        #endregion

        #region Property

        public int NumChalanId
        {
            get
            {
                return this.numChalanId;
            }
            set
            {
                numChalanId = value;
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
        public string DtChalanDate
        {
            get
            {
                return this.dtChalanDate;
            }
            set
            {
                dtChalanDate = value;
            }
        }
        public decimal FltChalanAmt
        {
            get
            {
                return this.fltChalanAmt;
            }
            set
            {
                fltChalanAmt = value;
            }
        }
        public int YearId
        {
            get
            {
                return this.yearId;
            }
            set
            {
                yearId = value;
            }
        }
        public int MonthId
        {
            get
            {
                return this.monthId;
            }
            set
            {
                monthId = value;
            }
        }
        public int PerYearId
        {
            get
            {
                return this.perYearId;
            }
            set
            {
                perYearId = value;
            }
        }
        public int PerMonthId
        {
            get
            {
                return this.perMonthId;
            }
            set
            {
                perMonthId = value;
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
        public int FlgUnposted
        {
            get
            {
                return this.flgUnposted;
            }
            set
            {
                flgUnposted = value;
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


        public int IntModeChange
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
        public int FlgSource
        {
            get
            {
                return this.flgSource;
            }
            set
            {
                flgSource = value;
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
        //public int NumChalanId
        //{
        //    get
        //    {
        //        return this.numChalanId;
        //    }
        //    set
        //    {
        //        numChalanId = value;
        //    }
        //}
        public double DblChalanRefId
        {
            get
            {
                return this.dblChalanRefId;
            }
            set
            {
                dblChalanRefId = value;
            }
        }
        public double DblChalanAGRefId
        {
            get
            {
                return this.dblChalanAGRefId;
            }
            set
            {
                dblChalanAGRefId = value;
            }
        }
    }

    #endregion  
}
