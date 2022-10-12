using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class SubnChange
    {
        #region Fields
        private double subnChangeId;
        private double numEmpId;
        private int intYearId;
        private int intMonthId;
        private double fltOldSubnAmt;
        private double fltProposedSubnAmt;
        private double fltNewSubnAmt;
        private int flgChangeType;
        private long intUserId;
        private string dtApp;
        #endregion
        #region Property
        public double SubnChangeId
        {
            get
            {
                return this.subnChangeId;
            }
            set
            {
                subnChangeId = value;
            }
        }
        public double NumEmpId
        {
            get
            {
                return this.numEmpId;
            }
            set
            {
                numEmpId = value;
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

        public double FltOldSubnAmt
        {
            get
            {
                return this.fltOldSubnAmt;
            }
            set
            {
                fltOldSubnAmt = value;
            }
        }
        public double FltProposedSubnAmt
        {
            get
            {
                return this.fltProposedSubnAmt;
            }
            set
            {
                fltProposedSubnAmt = value;
            }
        }
        public double FltNewSubnAmt
        {
            get
            {
                return this.fltNewSubnAmt;
            }
            set
            {
                fltNewSubnAmt = value;
            }
        }



        public int FlgChangeType
        {
            get
            {
                return this.flgChangeType;
            }
            set
            {
                flgChangeType = value;
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
        public string DtApp
        {
            get
            {
                return this.dtApp;
            }
            set
            {
                dtApp = value;
            }
        }
        #endregion
    }
}
