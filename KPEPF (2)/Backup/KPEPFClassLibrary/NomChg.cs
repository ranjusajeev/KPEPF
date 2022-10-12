using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class NomChg
    {
        #region fields
        private double numTrnID;
        private double numEmpID;
        private int intNomineeSlNo;
        private string chvNomineeName;
        private int intRelation;
        private int intAge;
        private double fltShare;
        private int intStatus;
        private string chvRepName;
        private int intReplacerRelation;
        private int intReplacerAge;
        private int intSlNo;
        private int flgNomChange;
        #endregion

        #region properties
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
        public int IntNomineeSlNo
        {
            get
            {
                return this.intNomineeSlNo;
            }
            set
            {
                intNomineeSlNo = value;
            }
        }
        public string ChvNomineeName
        {
            get
            {
                return this.chvNomineeName;
            }
            set
            {
                chvNomineeName = value;
            }
        }
        public int IntRelation
        {
            get
            {
                return this.intRelation;
            }
            set
            {
                intRelation = value;
            }
        }
        public int IntAge
        {
            get
            {
                return this.intAge;
            }
            set
            {
                intAge = value;
            }
        }
        public double FltShare
        {
            get
            {
                return this.fltShare;
            }
            set
            {
                fltShare = value;
            }
        }
        public int IntStatus
        {
            get
            {
                return this.intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        public string ChvRepName
        {
            get
            {
                return this.chvRepName;
            }
            set
            {
                chvRepName = value;
            }
        }


        public int IntReplacerRelation
        {
            get
            {
                return this.intReplacerRelation;
            }
            set
            {
                intReplacerRelation = value;
            }
        }
        public int IntReplacerAge
        {
            get
            {
                return this.intReplacerAge;
            }
            set
            {
                intReplacerAge = value;
            }
        }
        public int IntSlNo
        {
            get
            {
                return this.intSlNo;
            }
            set
            {
                intSlNo = value;
            }
        }
        public int FlgNomChange
        {
            get
            {
                return this.flgNomChange;
            }
            set
            {
                flgNomChange = value;
            }
        }
        
        #endregion

    }
}
