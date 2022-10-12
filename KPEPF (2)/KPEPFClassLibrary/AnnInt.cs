using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class AnnInt
    {
        #region fields
        private int intAGEntryId;
        private int intYearId;
        private double fltAmount;
        private float tENo;
        private string rem;
        private int intSlNo;
        #endregion

        #region Property
        public int IntAGEntryId
        {
            get
            {
                return intAGEntryId;
            }
            set
            {
                intAGEntryId = value;
            }
        }
        public int IntYearId
        {
            get
            {
                return intYearId;
            }
            set
            {
                intYearId = value;
            }
        }
        public double FltAmount
        {
            get
            {
                return fltAmount;
            }
            set
            {
                fltAmount = value;
            }
        }
        public float TENo
        {
            get
            {
                return tENo;
            }
            set
            {
                tENo = value;
            }
        }
        public string Rem
        {
            get
            {
                return rem;
            }
            set
            {
                rem = value;
            }
        }
        public int IntSlNo
        {
            get
            {
                return intSlNo;
            }
            set
            {
                intSlNo = value;
            }
        }
        #endregion
    }
}
