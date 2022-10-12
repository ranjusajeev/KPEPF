using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class  TA2NRACon
    {
        #region Fields
        private double numTrnId;
        private double numSerTrnId;
        private double numEmpId;
        private double numWithdrawalID;
        private double fltAmtConverted;
        private int intRsnId;
        #endregion

        #region Property
        public double NumTrnId
        {
            get
            {
                return this.numTrnId;
            }
            set
            {
                numTrnId = value;
            }
        }

        public double NumSerTrnId
        {
            get
            {
                return this.numSerTrnId;
            }
            set
            {
                numSerTrnId = value;
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


        public double NumWithdrawalID
        {
            get
            {
                return this.numWithdrawalID;
            }
            set
            {
                numWithdrawalID = value;
            }
        }

        public double FltAmtConverted
        {
            get
            {
                return this.fltAmtConverted;
            }
            set
            {
                fltAmtConverted = value;
            }
        }

        public int IntRsnId
        {
            get
            {
                return this.intRsnId;
            }
            set
            {
                intRsnId = value;
            }
        }

        #endregion
    }
}
