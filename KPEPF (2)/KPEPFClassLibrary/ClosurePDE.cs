using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class ClosurePDE
    {        
        #region Fields
        private int intId;
        private int intDistId;
        private int intAccNo;
        private int intYearId;
        private long intUserId;
        private string chvOrderNoDate;    
        private string dtmMonthYear;
        private double fltAmount;
        private int intSubSlNo;
        private int flgPartPayment;
        private string chvSubSlNo;
        private string chvRemarks;      
        private string dtEntery;
        private int intTCType;

        private string dtmRetired;
        private string dtmInerest;

        #endregion
        #region property

        public string DtmRetired
        {
            get
            {
                return this.dtmRetired;
            }
            set
            {
                dtmRetired = value;
            }
        }
        public string DtmInerest
        {
            get
            {
                return this.dtmInerest;
            }
            set
            {
                dtmInerest = value;
            }
        }


        public  int IntId
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
        public int IntDistId
        {
            get
            {
                return this.intDistId;
            }
            set
            {
                intDistId = value;
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
        public string ChvOrderNoDate
        {
            get
            {
                return this.chvOrderNoDate;
            }
            set
            {
                chvOrderNoDate = value;
            }
        }
        public string DtmMonthYear
        {
            get
            {
                return this.dtmMonthYear;
            }
            set
            {
                dtmMonthYear = value;
            }
        }
        public double FltAmount
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
        public int IntSubSlNo
        {
            get
            {
                return this.intSubSlNo;
            }
            set
            {
                intSubSlNo = value;
            }
        }
        public int FlgPartPayment
        {
            get
            {
                return this.flgPartPayment;
            }
            set
            {
                flgPartPayment = value;
            }
        }
        public string ChvSubSlNo
        {
            get
            {
                return this.chvSubSlNo;
            }
            set
            {
                chvSubSlNo = value;
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
        public string DtEntery
        {
            get
            {
                return this.dtEntery;
            }
            set
            {
                dtEntery = value;
            }
        }
        public int IntTCType
        {
            get
            {
                return this.intTCType;
            }
            set
            {
                intTCType = value;
            }
        }
        #endregion
    }
}
