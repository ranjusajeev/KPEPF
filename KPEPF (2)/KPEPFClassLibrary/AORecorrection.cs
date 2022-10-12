using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class AORecorrection
    {
        #region fields
        private int intYearID;
        private int intMonthID;
        private int intDistID;
        private int intDistTID;
        private int intType;
        private int flgApp;
        private double numChalanId;
        private int flgYearPrev;
        #endregion

        #region Property
        public double NumChalanId
        {
            get
            {
                return this.numChalanId;
            }
            set
            {
                numChalanId = value;
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
        public int IntDistID
        {
            get
            {
                return this.intDistID;
            }
            set
            {
                intDistID = value;
            }
        }
        public int IntDistTID
        {
            get
            {
                return this.intDistTID;
            }
            set
            {
                intDistTID = value;
            }
        }

        public int IntType
        {
            get
            {
                return this.intType;
            }
            set
            {
                intType = value;
            }
        }
        public int FlgApp
        {
            get
            {
                return this.flgApp;
            }
            set
            {
                flgApp = value;
            }
        }
        public int FlgYearPrev
        {
            get
            {
                return this.flgYearPrev;
            }
            set
            {
                flgYearPrev = value;
            }
        }
        #endregion
    }
}
