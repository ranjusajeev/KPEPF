using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class OB
    {
        #region fields
        private int intDistId;
        private int intAccNo;
        private float fltAmount;
        private int intMoC;
        private long intUserId;
        #endregion

        #region fields
        public int IntDistId
        {
            get
            {
                return this.intDistId;
            }
            set
            {
                intDistId = value;
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
        public float FltAmount
        {
            get
            {
                return this.fltAmount;
            }
            set
            {
                fltAmount = value;
            }
        }
        public int IntMoC
        {
            get
            {
                return this.intMoC;
            }
            set
            {
                intMoC = value;
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
        #endregion
    }
}
