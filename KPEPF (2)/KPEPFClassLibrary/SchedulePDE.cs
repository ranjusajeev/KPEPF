using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class SchedulePDE
    {
        #region fields
        private double numID;
        private int numEmpID;
        private string chvName;
        private double fltSubnAmt;
        private double fltRePaymentAmt;
        private double fltArearPFAmt;
        private double fltArearDA;
        private double fltArearPay;
        private int chvGOId;
        private double fltTotal;

        private int flgUnIdentifiedEmp;

        private int intNoOfInst;
        private int flgUnPosted;
        private int intUnPostedRsn;
        private int intModeChange;
        private string chvRem;
        private int intSchMainId;
        private long intUserId;
        private int intRecNo;
        private int flgUpd;

        private int intChalanId;
        private int intSlno;

        private int intFm;
        private int intTm;

        #endregion
        #region properties
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
        public int IntSlno
        {
            get
            {
                return this.intSlno;
            }
            set
            {
                intSlno = value;
            }
        }
        public double NumID
        {
            get
            {
                return this.numID;
            }
            set
            {
                numID = value;
            }
        }
        
        public int NumEmpID
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
        public string ChvName
        {
            get
            {
                return this.chvName;
            }
            set
            {
                chvName = value;
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
        public int ChvGOId
        {
            get
            {
                return this.chvGOId;
            }
            set
            {
                chvGOId = value;
            }
        }
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
        public int IntRecNo
        {
            get
            {
                return this.intRecNo;
            }
            set
            {
                intRecNo = value;
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
