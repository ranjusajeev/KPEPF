using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class CorrectionEntry
    {
        #region fields
            private float intID;
            private int intAccNo;
            private int intYearID;
            private int intMonthID;
            private int intYearIDCorrected;
            private double  fltAmountBefore;
            private double fltAmountAfter;
            private double fltCalcAmount;
            private int flgCorrected;
            private float intChalanId;
            private double intSchedId;
            private int flgType;
            private double fltRoundingAmt;
            private int intCorrectionType;
            private string strFrmChalDt;
            private string strToChalDt;
            private int intChalanType;
            private int intTblTp;
        #endregion

        #region Property
            public int IntTblTp
            {
                get
                {
                    return this.intTblTp;
                }
                set
                {
                    intTblTp = value;
                }
            }
        public float IntID
        {
            get
            {
                return this.intID;
            }
            set
            {
                intID = value;
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
        public int IntMonthID
        {
            get
            {
                return this.intMonthID;
            }
            set
            {
                intMonthID = value;
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
        public int IntYearIDCorrected
        {
            get
            {
                return this.intYearIDCorrected;
            }
            set
            {
                intYearIDCorrected = value;
            }
        }
        public double FltAmountBefore
        {
            get
            {
                return this.fltAmountBefore;
            }
            set
            {
                fltAmountBefore = value;
            }
        }
        public double FltAmountAfter
        {
            get
            {
                return this.fltAmountAfter;
            }
            set
            {
                fltAmountAfter = value;
            }
        }
        public double FltCalcAmount
        {
            get
            {
                return this.fltCalcAmount;
            }
            set
            {
                fltCalcAmount = value;
            }
        }
        public int FlgCorrected
        {
            get
            {
                return this.flgCorrected;
            }
            set
            {
                flgCorrected = value;
            }
        }
        public float IntChalanId
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
        public double  IntSchedId
        {
            get
            {
                return this.intSchedId;
            }
            set
            {
                intSchedId = value;
            }
        }
        public int FlgType
        {
            get
            {
                return this.flgType;
            }
            set
            {
                flgType = value;
            }
        }
        public double FltRoundingAmt
        {
            get
            {
                return this.fltRoundingAmt;
            }
            set
            {
                fltRoundingAmt = value;
            }
        }
        public int IntCorrectionType
        {
            get
            {
                return this.intCorrectionType;
            }
            set
            {
                intCorrectionType = value;
            }
        }
        public string StrFrmChalDt
        {
            get
            {
                return this.StrFrmChalDt;
            }
            set
            {
                StrFrmChalDt = value;
            }
        }
        public string StrToChalDt
        {
            get
            {
                return this.strToChalDt;
            }
            set
            {
                strToChalDt = value;
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
        #endregion
    }
}
