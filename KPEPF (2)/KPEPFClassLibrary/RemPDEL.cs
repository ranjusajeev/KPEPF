using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class RemPDEL
    {
        #region fields
        private int intChalanId;
        private int intSTreasuryDetId;
        private int intLBId;
        private int intTreasuryId;
        private int intChalanType;
        private int intChalanNo;

        private DateTime dtmChalanDate;
        private double fltAmount;
        private int flgUnPosted;
        private int intUnPosingReasonId;
        private int intModeChg;
        private string  fromWhom;
        //private int intSTreasuryDetId;
        #endregion
        #region Property
        public string FromWhom
        {
            get
            {
                return this.fromWhom;
            }
            set
            {
                fromWhom = value;
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
        public int IntChalanType
        {
            get
            {
                return this.intChalanType;
            }
            set
            {
                intChalanType = value;
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
        public DateTime  DtmChalanDate
        {
            get
            {
                return this.dtmChalanDate;
            }
            set
            {
                dtmChalanDate = value;
            }
        }
        public double  FltAmount
        {
            get
            {
                return this.fltAmount;
            }
            set
            {
                fltAmount = value;
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
        public int IntUnPosingReasonId
        {
            get
            {
                return this.intUnPosingReasonId;
            }
            set
            {
                intUnPosingReasonId = value;
            }
        }
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
        //public int IntSTreasuryDetId
        //{
        //    get
        //    {
        //        return this.intSTreasuryDetId;
        //    }
        //    set
        //    {
        //        intSTreasuryDetId = value;
        //    }
        //}
        #endregion
    }
}
