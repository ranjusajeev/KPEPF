using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class ChalanPDEAG
    {
        #region fields
        private int intChalanAGID;
        private int intTERelMonthWiseID;
        private int intTreasID;
        private int intLBID;
        private int intChalanNo;
        private string dtmChalanDt;
        private decimal fltChalanAmt;
        private int intYearID;
        private int intModeOfChgID;
        private long intUserId;
        private string dtmEntry;
        private string chvTENo;
        private int flgUnPosted;
        private int intReasonID;
        private int intMissingID;
        private int chalanId;
        private int intGroupId;
        private int intChalanType;
        #endregion
        #region Property

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
        public int IntChalanAGID
        {
            get
            {
                return this.intChalanAGID;
            }
            set
            {
                intChalanAGID = value;
            }
        }
        public int IntTERelMonthWiseID
        {
            get
            {
                return this.intTERelMonthWiseID;
            }
            set
            {
                intTERelMonthWiseID = value;
            }
        }
        public int IntTreasID
        {
            get
            {
                return this.intTreasID;
            }
            set
            {
                intTreasID = value;
            }
        }
        public int IntLBID
        {
            get
            {
                return this.intLBID;
            }
            set
            {
                intLBID = value;
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
        public string DtmChalanDt
        {
            get
            {
                return this.dtmChalanDt;
            }
            set
            {
                dtmChalanDt = value;
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
        public int IntModeOfChgID
        {
            get
            {
                return this.intModeOfChgID;
            }
            set
            {
                intModeOfChgID = value;
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
        public string DtmEntry
        {
            get
            {
                return this.dtmEntry;
            }
            set
            {
                dtmEntry = value;
            }
        }
        public string ChvTENo
        {
            get
            {
                return this.chvTENo;
            }
            set
            {
                chvTENo = value;
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
        public int IntReasonID
        {
            get
            {
                return this.intReasonID;
            }
            set
            {
                intReasonID = value;
            }
        }
        public int IntMissingID
        {
            get
            {
                return this.intMissingID;
            }
            set
            {
                intMissingID = value;
            }
        }

        public int ChalanId
        {
            get
            {
                return this.chalanId;
            }
            set
            {
                chalanId = value;
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
        #endregion
    }
}
