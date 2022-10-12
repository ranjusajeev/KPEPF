using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class RemPDE
    {
        #region fields
        private int intChalanID;
        private int intYearID;
        private int intMonthId;
        private int intDTId;
        private int flgApp;
        private int intChalanNo;
        private DateTime dtmChalan;
        private double dblChalanAmt;
        private int flgUnPosted;
        private int flgMisClass;
        private int flgSource;
        private int intSTreasuryDetId;
        #endregion
        #region Property

        public int IntChalanID
        {
            get
            {
                return this.intChalanID;
            }
            set
            {
                intChalanID = value;
            }
        }
        public int IntYearID
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
        public int FlgApp
        {
            get
            {
                return this.flgApp;
            }
            set
            {
                flgApp = value;
            }
        }
        public DateTime DtmChalan
        {
            get
            {
                return this.dtmChalan;
            }
            set
            {
                dtmChalan = value;
            }
        }
        public double DblChalanAmt
        {
            get
            {
                return this.dblChalanAmt;
            }
            set
            {
                dblChalanAmt = value;
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
        public int FlgMisClass
        {
            get
            {
                return this.flgMisClass;
            }
            set
            {
                flgMisClass = value;
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
        public int IntSTreasuryDetId
        {
            get
            {
                return this.intSTreasuryDetId;
            }
            set
            {
                intSTreasuryDetId = value;
            }
        }
        #endregion
    }
}
