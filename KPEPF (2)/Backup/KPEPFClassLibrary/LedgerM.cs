using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class LedgerM
    {
        #region fields
        //private int[] intAccNo = new int[35];
        private int[] intDayId = new int[35];
        private int[] intMId = new int[35];
        private DateTime[] dtChalDate = new DateTime[35];
        private int[] intChalNo = new int[35];
        private double[] dblMsAmt = new double[35];
        private double[] dblRfAmt = new double[35];
        private double[] dblPfAmt = new double[35];
        private double[] dblDAAmt = new double[35];
        private double[] dblPayAmt = new double[35];
        private double[] dblWithAmt = new double[35];
        private double[] dblTotRemMwise = new double[35];
        private double[] dblAmtForInt = new double[35];
        private int[] intLBId = new int[35];
        private int[] intTreasury = new int[35];
        private int[] intLoanType = new int[35];
        private int[] intLoanNo = new int[35];
        private DateTime[] dtmLoanDate = new DateTime[35];
        private int[] intArrearNo = new int[35];
        private DateTime[] dtmArrearDate = new DateTime[35];
        private int[] flgRemTorAG = new int[35];
        private int[] flgWithTorAG = new int[35];
        private int[] flgRemTorAGRem1 = new int[35];
        private int[] flgWithTorAGWith1 = new int[35];
        private int[] flgRemTorAGRem2 = new int[35];
        private int[] flgWithTorAGWith2 = new int[35];

        private double[] dbl4Amt = new double[35];
        private double[] dbl5Amt = new double[35];
        private float[] numChalanId = new float[35];
        private float[] numWithdrawId = new float[35];

        private float[] intAGEntryId = new float[35];
        private float[] intAGEntryIdWith = new float[35];

        #endregion

        #region properties

        public float[] IntAGEntryId
        {
            get
            {
                return this.intAGEntryId;
            }
            set
            {
                intAGEntryId = value;
            }
        }
        public float[] IntAGEntryIdWith
        {
            get
            {
                return this.intAGEntryIdWith;
            }
            set
            {
                intAGEntryIdWith = value;
            }
        }


        public float[] NumWithdrawId
        {
            get
            {
                return this.numWithdrawId;
            }
            set
            {
                numWithdrawId = value;
            }
        }
        public float[] NumChalanId
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
        public double[] Dbl4Amt
        {
            get
            {
                return this.dbl4Amt;
            }
            set
            {
                dbl4Amt = value;
            }
        }
        public double[] Dbl5Amt
        {
            get
            {
                return this.dbl5Amt;
            }
            set
            {
                dbl5Amt = value;
            }
        }



        //public int[] IntAccNo
        //{
        //    get
        //    {
        //        return this.intAccNo;
        //    }
        //    set
        //    {
        //        intAccNo = value;
        //    }
        //}
        public int[] IntDayId
        {
            get
            {
                return this.intDayId;
            }
            set
            {
                intDayId = value;
            }
        }
        public int[] IntMId
        {
            get
            {
                return this.intMId;
            }
            set
            {
                intMId = value;
            }
        }
        public DateTime[] DtChalDate
        {
            get
            {
                return this.dtChalDate;
            }
            set
            {
                dtChalDate = value;
            }
        }
        public int[] IntChalNo
        {
            get
            {
                return this.intChalNo;
            }
            set
            {
                intChalNo = value;
            }
        }
        public double[] DblMsAmt
        {
            get
            {
                return this.dblMsAmt;
            }
            set
            {
                dblMsAmt = value;
            }
        }
        public double[] DblRfAmt
        {
            get
            {
                return this.dblRfAmt;
            }
            set
            {
                dblRfAmt = value;
            }
        }
        public double[] DblPfAmt
        {
            get
            {
                return this.dblPfAmt;
            }
            set
            {
                dblPfAmt = value;
            }
        }
        public double[] DblDAAmt
        {
            get
            {
                return this.dblDAAmt;
            }
            set
            {
                dblDAAmt = value;
            }
        }
        public double[] DblPayAmt
        {
            get
            {
                return this.dblPayAmt;
            }
            set
            {
                dblPayAmt = value;
            }
        }
        public double[] DblWithAmt
        {
            get
            {
                return this.dblWithAmt;
            }
            set
            {
                dblWithAmt = value;
            }
        }
        public double[] DblTotRemMwise
        {
            get
            {
                return this.dblTotRemMwise;
            }
            set
            {
                dblTotRemMwise = value;
            }
        }
        public double[] DblAmtForInt
        {
            get
            {
                return this.dblAmtForInt;
            }
            set
            {
                dblAmtForInt = value;
            }
        }
        public int[] IntLBId
        {
            get
            {
                return this.intLBId;
            }
            set
            {
                intLBId = value;
            }
        }
        public int[] IntTreasury
        {
            get
            {
                return this.intTreasury;
            }
            set
            {
                intTreasury = value;
            }
        }
        public int[] IntLoanType
        {
            get
            {
                return this.intLoanType;
            }
            set
            {
                intLoanType = value;
            }
        }
        public int[] IntLoanNo
        {
            get
            {
                return this.intLoanNo;
            }
            set
            {
                intLoanNo = value;
            }
        }
        public DateTime[] DtmLoanDate
        {
            get
            {
                return this.dtmLoanDate;
            }
            set
            {
                dtmLoanDate = value;
            }
        }
        public int[] IntArrearNo
        {
            get
            {
                return this.intArrearNo;
            }
            set
            {
                intArrearNo = value;
            }
        }
        public DateTime[] DtmArrearDate
        {
            get
            {
                return this.dtmArrearDate;
            }
            set
            {
                dtmArrearDate = value;
            }
        }
        public int[] FlgRemTorAG
        {
            get
            {
                return this.flgRemTorAG;
            }
            set
            {
                flgRemTorAG = value;
            }
        }
        public int[] FlgWithTorAG
        {
            get
            {
                return this.flgWithTorAG;
            }
            set
            {
                flgWithTorAG = value;
            }
        }

        public int[] FlgRemTorAGRem1
        {
            get
            {
                return this.flgRemTorAGRem1;
            }
            set
            {
                flgRemTorAGRem1 = value;
            }
        }
        public int[] FlgWithTorAGWith1
        {
            get
            {
                return this.flgWithTorAGWith1;
            }
            set
            {
                flgWithTorAGWith1 = value;
            }
        }
        public int[] FlgRemTorAGRem2
        {
            get
            {
                return this.flgRemTorAGRem2;
            }
            set
            {
                flgRemTorAGRem2 = value;
            }
        }
        public int[] FlgWithTorAGWith2
        {
            get
            {
                return this.flgWithTorAGWith2;
            }
            set
            {
                flgWithTorAGWith2 = value;
            }
        }


        #endregion
    }
}
