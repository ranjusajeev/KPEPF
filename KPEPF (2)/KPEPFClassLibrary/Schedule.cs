using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Schedule
    {
        #region fields
        private double numScheduleID;
        private double numChalanID;
        private double numEmpID;
        private double fltSubnAmt;
        private double fltRePaymentAmt;
        private double fltArearPFAmt;
        private double fltArearDA;
        private double fltArearPay;
        private double fltTotal;
        private int intGOId;
        private int flgUnIdentifiedEmp;
        private int intNoOfInst;
        private int flgUnPosted;
        private int intUnPostedRsn;
        private int intModeChange;
        private string chvRem;
        private int intSlNo;
        private int flgUpd;

        private int intFm;
        private int intTm;
        #endregion
        #region properties
        public double NumScheduleID
        {
            get
            {
                return this.numScheduleID;
            }
            set
            {
                numScheduleID = value;
            }
        }
        public double NumChalanID
        {
            get
            {
                return this.numChalanID;
            }
            set
            {
                numChalanID = value;
            }
        }
        public double NumEmpID
        {
            get
            {
                return this.numEmpID;
            }
            set
            {
                numEmpID = value;
            }
        }
        public double FltSubnAmt
        {
            get
            {
                return this.fltSubnAmt;
            }
            set
            {
                fltSubnAmt = value;
            }
        }
        public double FltRePaymentAmt
        {
            get
            {
                return this.fltRePaymentAmt;
            }
            set
            {
                fltRePaymentAmt = value;
            }
        }
        public double FltArearPFAmt
        {
            get
            {
                return this.fltArearPFAmt;
            }
            set
            {
                fltArearPFAmt = value;
            }
        }
        public double FltArearDA
        {
            get
            {
                return this.fltArearDA;
            }
            set
            {
                fltArearDA = value;
            }
        }
        public double FltArearPay
        {
            get
            {
                return this.fltArearPay;
            }
            set
            {
                fltArearPay = value;
            }
        }

        public double FltTotal
        {
            get
            {
                return this.fltTotal;
            }
            set
            {
                fltTotal = value;
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
        public int FlgUnIdentifiedEmp
        {
            get
            {
                return this.flgUnIdentifiedEmp;
            }
            set
            {
                flgUnIdentifiedEmp = value;
            }
        }
        public int IntNoOfInst
        {
            get
            {
                return this.intNoOfInst;
            }
            set
            {
                intNoOfInst = value;
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
        public string ChvRem
        {
            get
            {
                return this.chvRem;
            }
            set
            {
                chvRem = value;
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
        public int FlgUpd
        {
            get
            {
                return this.flgUpd;
            }
            set
            {
                flgUpd = value;
            }
        }
        public int IntFm
        {
            get
            {
                return this.intFm;
            }
            set
            {
                intFm = value;
            }
        }
        public int IntTm
        {
            get
            {
                return this.intTm;
            }
            set
            {
                intTm = value;
            }
        }
        #endregion  
    }
}
