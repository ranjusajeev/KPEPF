using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class WithdrawalRequest
    {
        #region fields
        private int intYearId;
        private int intMonthId;
        private string chvFileNo;
        private double numEmpID;
        private int intTrnTypeID;
        private double fltAmtProposed;
        private double fltAmtAdmissible;
        private int intNoOfInstProposed;
        private int intPurposeID;
        private string dtmDateOfRequest;
        private int intUesrID;
        private int intDesigID;
        private double fltInstAmount;
        private double numWithRequestID;
        private double fltOutstandingAmount;
        #endregion
        #region Property
        public double NumEmpId
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
        public string ChvFileNo
        {
            get
            {
                return this.chvFileNo;
            }
            set
            {
                chvFileNo = value;
            }
        }
            
        public int IntTrnTypeID
        {
            get
            {
                return this.intTrnTypeID;
            }
            set
            {
                intTrnTypeID = value;
            }
        }
        
        public double FltAmtProposed
        {
            get
            {
                return this.fltAmtProposed;
            }
            set
            {
                fltAmtProposed = value;
            }
        }
        public double FltAmtAdmissible
        {
            get
            {
                return this.fltAmtAdmissible;
            }
            set
            {
                fltAmtAdmissible = value;
            }
        }
        public double FltInstAmount
        {
            get
            {
                return this.fltInstAmount;
            }
            set
            {
                fltInstAmount = value;
            }
        }
         public int IntNoOfInstProposed
        {
            get
            {
                return this.intNoOfInstProposed;
            }
            set
            {
                intNoOfInstProposed = value;
            }
        }
        
        public int IntPurposeID
        {
            get
            {
                return this.intPurposeID;
            }
            set
            {
                intPurposeID = value;
            }
        }
        public string DtmDateOfRequest
        {
            get
            {
                return this.dtmDateOfRequest;
            }
            set
            {
                dtmDateOfRequest = value;
            }
        }
        public int IntUesrID
        {
            get
            {
                return this.intUesrID;
            }
            set
            {
                intUesrID = value;
            }
        }

        public int IntDesigID
        {
            get
            {
                return this.intDesigID;
            }
            set
            {
                intDesigID = value;
            }
        }
        public double NumWithRequestID
        {
            get
            {
                return this.numWithRequestID;
            }
            set
            {
                numWithRequestID = value;
            }
        }
        public double FltOutstandingAmount
        {
            get
            {
                return this.fltOutstandingAmount;
            }
            set
            {
                fltOutstandingAmount = value;
            }
        }
        #endregion
    }
}
