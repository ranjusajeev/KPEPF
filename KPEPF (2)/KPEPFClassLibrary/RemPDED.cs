using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class RemPDED
    {
        #region fields
        private int intYearID;
        private int intMonthId;
        private int intDTId;
        private int intSource;
        private DateTime dtmIntimation;
        private double fltNetAmount;
        private string strParticulars;
        #endregion
        #region Property

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



        public int IntSource
        {
            get
            {
                return this.intSource;
            }
            set
            {
                intSource = value;
            }
        }
        public DateTime DtmIntimation
        {
            get
            {
                return this.dtmIntimation;
            }
            set
            {
                dtmIntimation = value;
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
        #endregion
    }
}
