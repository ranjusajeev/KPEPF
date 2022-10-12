using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class RemPDES
    {
        #region fields
        private int intSTreasuryDetId;
        private int intDTreasuryDetId;
        private int intTreasuryId;

        private DateTime dtmAccDate;
        private DateTime dtmTrnDate;
        private double fltCashAmount;
        private double fltNetAmount;
        private string strParticulars;
        private int intSlNo;
        private long intUserId;
        #endregion

        #region Property
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
        public int IntDTreasuryDetId
        {
            get
            {
                return this.intDTreasuryDetId;
            }
            set
            {
                intDTreasuryDetId = value;
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
        public DateTime DtmTrnDate
        {
            get
            {
                return this.dtmTrnDate;
            }
            set
            {
                dtmTrnDate = value;
            }
        }
        public DateTime DtmAccDate
        {
            get
            {
                return this.dtmAccDate;
            }
            set
            {
                dtmAccDate = value;
            }
        }


        public double FltNetAmount
        {
            get
            {
                return this.fltNetAmount;
            }
            set
            {
                fltNetAmount = value;
            }
        }
        public double FltCashAmount
        {
            get
            {
                return this.fltCashAmount;
            }
            set
            {
                fltCashAmount = value;
            }
        }
        public string StrParticulars
        {
            get
            {
                return this.strParticulars;
            }
            set
            {
                strParticulars = value;
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
        #endregion
    }
}
