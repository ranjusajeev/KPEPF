using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Closure
    {
        #region Fields
        private double numTrnID;
        private int intTrnTypeID;
        private string chvFileNo;
		private double numEmpID;
        private long intUserId;
        private int intLBID;
		private int  intRsnID;
        private string dtmEntry;
        private string dtmDateOfRequest;
        private string  intInwardNo;
		private string dtmLastChalan;
		private string dtmQuitting;
        private int intQuittingLB;
        private int intStageID;
        private double numClosureID;
        private string dtmLastSalary;
       
        #endregion
        #region property

       
        public string DtmLastSalary
        {
            get
            {
                return this.dtmLastSalary;
            }
            set
            {
                dtmLastSalary = value;
            }
        }
        public double NumClosureID
        {
            get
            {
                return this.numClosureID;
            }
            set
            {
                numClosureID = value;
            }
        }

        public double NumTrnID
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
        	
        public double NumEmpID
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
        public int  IntLBID
        {
            get
            {
                return this.intLBID;
            }
            set
            {
                intLBID = value;
            }
        }
        public string  DtmEntry
        {
            get
            {
                return this.dtmEntry;
            }
            set
            {
                dtmEntry = value;
            }
        }
        
        	
        public int IntRsnID
        {
            get
            {
                return this.intRsnID;
            }
            set
            {
                intRsnID = value;
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
        public string DtmLastChalan
        {
            get
            {
                return this.dtmLastChalan;
            }
            set
            {
                dtmLastChalan = value;
            }
        }
        public string DtmQuitting
        {
            get
            {
                return this.dtmQuitting;
            }
            set
            {
                dtmQuitting = value;
            }
        }
        public int IntQuittingLB
        {
            get
            {
                return this.intQuittingLB;
            }
            set
            {
                intQuittingLB = value;
            }
        }
        public string  IntInwardNo
        {
            get
            {
                return this.intInwardNo;
            }
            set
            {
                intInwardNo = value;
            }
        }
       

        public int IntStageID
        {
            get
            {
                return this.intStageID;
            }
            set
            {
                intStageID = value;
            }
        }
        
        
        #endregion
    }
}
