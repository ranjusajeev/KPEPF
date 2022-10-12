using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Approval
    {
        #region fields       
        private int intTrnTypeID;
        //private decimal numTrnID;
        private float numTrnID;
        private int flgApproval;
        private long intUserId;
        private string chvRem;
        #endregion
        #region Property
       
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
        public float NumTrnID
        {
            get
            {
                return this.numTrnID;
            }
            set
            {
                numTrnID = value;
            }
        }
        public int FlgApproval
        {
            get
            {
                return this.flgApproval;
            }
            set
            {
                flgApproval = value;
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
        public string  ChvRem
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
        #endregion
    }
}
