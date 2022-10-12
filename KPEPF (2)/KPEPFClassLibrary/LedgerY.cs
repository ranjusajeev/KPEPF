using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class LedgerY
    {
        #region fields
        private long numEmpID;
        private long amtForInterest;
        private int intAccNo;
        private int  intYrId;
        private double dblOB;
        private double  dblTotAmtForInt;
        private double dblTotWithAmtForInt;
        private double   dblTotRemAmt;
        private double dblTotWithAmt;
        private double dblTotOB;
        private double  dblIntAmt;
        //private double dblTotAmt;   //OB + Tot Rem + Int
        private double    dblIntRate;
        private double   dblCB;
        private double dblRemOBIntAmt;
        private int flgNonTrans;
        private double dblCorrEntryAmt;

        private double dblTotAmtWithBlockSingle;
        private double dblTotAmtWithBlock;
        private double dblTotAmtWithBlockCalc;
        #endregion

        #region properties
        public double DblTotAmtWithBlockSingle
        {
            get
            {
                return this.dblTotAmtWithBlockSingle;
            }
            set
            {
                dblTotAmtWithBlockSingle = value;
            }
        }
        public double DblTotAmtWithBlockCalc
        {
            get
            {
                return this.dblTotAmtWithBlockCalc;
            }
            set
            {
                dblTotAmtWithBlockCalc = value;
            }
        }
        public double DblTotAmtWithBlock
        {
            get
            {
                return this.dblTotAmtWithBlock;
            }
            set
            {
                dblTotAmtWithBlock = value;
            }
        }
        public int FlgNonTrans
        {
            get
            {
                return this.flgNonTrans;
            }
            set
            {
                flgNonTrans = value;
            }
        }
        public double DblCorrEntryAmt
        {
            get
            {
                return this.dblCorrEntryAmt;
            }
            set
            {
                dblCorrEntryAmt = value;
            }
        }



        public long NumEmpID
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
        public long AmtForInterest
        {
            get
            {
                return this.amtForInterest;
            }
            set
            {
                amtForInterest = value;
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
        public int IntYrId
        {
            get
            {
                return this.intYrId;
            }
            set
            {
                intYrId = value;
            }
        }
        public double DblOB
        {
            get
            {
                return this.dblOB;
            }
            set
            {
                dblOB = value;
            }
        }
        public double DblTotOB
        {
            get
            {
                return this.dblTotOB;
            }
            set
            {
                dblTotOB = value;
            }
        }

        public double DblTotAmtForInt
        {
            get
            {
                return this.dblTotAmtForInt;
            }
            set
            {
                dblTotAmtForInt = value;
            }
        }
        public double DblTotWithAmtForInt
        {
            get
            {
                return this.dblTotWithAmtForInt;
            }
            set
            {
                dblTotWithAmtForInt = value;
            }
        }
        public double DblTotRemAmt
        {
            get
            {
                return this.dblTotRemAmt;
            }
            set
            {
                dblTotRemAmt = value;
            }
        }
        public double DblTotWithAmt
        {
            get
            {
                return this.dblTotWithAmt;
            }
            set
            {
                dblTotWithAmt = value;
            }
        }


        public double DblIntRate
        {
            get
            {
                return this.dblIntRate;
            }
            set
            {
                dblIntRate = value;
            }
        }
        public double DblIntAmt
        {
            get
            {
                return this.dblIntAmt;
            }
            set
            {
                dblIntAmt = value;
            }
        }
        
        public double DblCB
        {
            get
            {
                return this.dblCB;
            }
            set
            {
                dblCB = value;
            }
        }
        public double DblRemOBIntAmt
        {
            get
            {
                return this.dblRemOBIntAmt;
            }
            set
            {
                dblRemOBIntAmt = value;
            }
        }
        #endregion
    }
}
