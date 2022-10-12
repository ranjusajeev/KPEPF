using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Membership
    {
        #region fields
        private double numMembershipReqID;
        //private decimal numTrnID;
        private int intInstID;
        private string chvEmployeeName;
        private int intDesigID;
        private int intGender;
        private string dtmDOB;
        private double fltBasicPay;
        private double fltSubscription;
        private string dtmSubStartDate;
        private int intOtherFund;
        private int flgMarried;
        private int flgPensionable;
        private int intNominees;
        private string chvPFNo;
        private long intPFNo;
        private double numEmpId;
        private string dtmDateOfRequest;
        private int intUesrID;
        private string dtmEntry;
        private string chvFileNo;
        private string dtmDOJ;

        private double intAadhaar;
        private string chvPhone;
        private int intBankType;
        private int intBankBranch;
        private string chvBankAccNo;
        #endregion
        #region address
       
        private int intAddressTypeID;
        private int intSlNo;
        private int intSlNoRep;
        private string chvName;
        private int intWardNo;
        private int intDoorNo;
        private string RANo;
        private string chvBldgName;
        private string chvLocalPlace;
        private string chvMainPlace;
        private string StreetName;
        private int intPincode;
        private int intDistrict;  
        private int intPO;
        private int intState;

        #endregion
        #region Nominee
        private double   numNomineeID;
         private int intNomineeSlNo;
        private string chvNomineeName;
         private int intRelation;
         private int intAge;
         private double   fltShare;
         private int intStatus;
         private int intReplacerRelation;
         private int intReplacerAge;
        private string chvRepName;
         //private int intReplacerSlNo;
         //private int intReplacerType;

#endregion

        #region fields
       
    private int intTrnTypeID;
    
  
    private long intUserId;
    private int intLBID;
   
   
    private int intInwardNo;
    private int intStageID;


#endregion
        #region properties
        public double IntAadhaar
        {
            get
            {
                return this.intAadhaar;
            }
            set
            {
                intAadhaar = value;
            }
        }
        public string ChvPhone
        {
            get
            {
                return this.chvPhone;
            }
            set
            {
                chvPhone = value;
            }
        }
        public int IntBankType
        {
            get
            {
                return this.intBankType;
            }
            set
            {
                intBankType = value;
            }
        }
        public int IntBankBranch
        {
            get
            {
                return this.intBankBranch;
            }
            set
            {
                intBankBranch = value;
            }
        }
        public string ChvBankAccNo
        {
            get
            {
                return this.chvBankAccNo;
            }
            set
            {
                chvBankAccNo = value;
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
        public int IntLBID
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
        public string DtmEntry
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
        public int IntInwardNo
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
        #region properties
        public double NumNomineeID
        {
            get
            {
                return this.numNomineeID;
            }
            set
            {
                numNomineeID = value;
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
        public double  FltShare
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
        //public int IntReplacerType
        //{
        //    get
        //    {
        //        return this.intReplacerType;
        //    }
        //    set
        //    {
        //        intReplacerType = value;
        //    }
        //}
        //public int IntReplacerSlNo
        //{
        //    get
        //    {
        //        return this.intReplacerSlNo;
        //    }
        //    set
        //    {
        //        intReplacerSlNo = value;
        //    }
        //}
        
     
#endregion
         #region properties
         public int IntAddressTypeID
        {
            get
            {
                return this.intAddressTypeID;
            }
            set
            {
                intAddressTypeID = value;
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
        public int IntSlNoRep
        {
            get
            {
                return this.intSlNoRep;
            }
            set
            {
                intSlNoRep = value;
            }
        }
        public string ChvName
        {
            get
            {
                return this.chvName;
            }
            set
            {
                chvName = value;
            }
        }
        public int IntWardNo
        {
            get
            {
                return this.intWardNo;
            }
            set
            {
                intWardNo = value;
            }
        }
        public int IntDoorNo
        {
            get
            {
                return this.intDoorNo;
            }
            set
            {
                intDoorNo = value;
            }
        }
        public string rANo
        {
            get
            {
                return this.RANo;
            }
            set
            {
                RANo = value;
            }
        }
        public string ChvBldgName
        {
            get
            {
                return this.chvBldgName;
            }
            set
            {
                chvBldgName = value;
            }
        }
        public string ChvLocalPlace
        {
            get
            {
                return this.chvLocalPlace;
            }
            set
            {
                chvLocalPlace = value;
            }
        }
        public string ChvMainPlace
        {
            get
            {
                return this.chvMainPlace;
            }
            set
            {
                chvMainPlace = value;
            }
        }
        public string streetName
        {
            get
            {
                return this.StreetName;
            }
            set
            {
                StreetName = value;
            }
        }
        public int IntPincode
        {
            get
            {
                return this.intPincode;
            }
            set
            {
                intPincode = value;
            }
        }
        public int IntDistrict
        {
            get
            {
                return this.intDistrict;
            }
            set
            {
                intDistrict = value;
            }
        }
        public int IntPO
        {
            get
            {
                return this.intPO;
            }
            set
            {
                intPO = value;
            }
        }
        public int IntState
        {
            get
            {
                return this.intState;
            }
            set
            {
                intState = value;
            }
        }
#endregion
        #region properties
        public double NumMembershipReqID
        {
            get
            {
                return this.numMembershipReqID;
            }
            set
            {
                numMembershipReqID = value;
            }
        }
        public int IntInstID
        {
            get
            {
                return this.intInstID;
            }
            set
            {
                intInstID = value;
            }
        }
        public string  ChvEmployeeName
        {
            get
            {
                return this.chvEmployeeName;
            }
            set
            {
                chvEmployeeName = value;
            }
        }
        public int IntDesigID
        {
            get
            {
                return this.intDesigID;
            }
            set
            {
                intDesigID = value;
            }
        }
        public int IntGender
        {
            get
            {
                return this.intGender;
            }
            set
            {
                intGender = value;
            }
        }
        public string DtmDOB
        {
            get
            {
                return this.dtmDOB;
            }
            set
            {
                dtmDOB = value;
            }
        }
        public double   FltBasicPay
        {
            get
            {
                return this.fltBasicPay;
            }
            set
            {
                fltBasicPay = value;
            }
        }
        public double FltSubscription
        {
            get
            {
                return this.fltSubscription;
            }
            set
            {
                fltSubscription = value;
            }
        }
        public string DtmSubStartDate
        {
            get
            {
                return this.dtmSubStartDate;
            }
            set
            {
                dtmSubStartDate = value;
            }
        }
        public int IntOtherFund
        {
            get
            {
                return this.intOtherFund;
            }
            set
            {
                intOtherFund = value;
            }
        }
        public int FlgMarried
        {
            get
            {
                return this.flgMarried;
            }
            set
            {
                flgMarried = value;
            }
        }
        public int FlgPensionable
        {
            get
            {
                return this.flgPensionable;
            }
            set
            {
              flgPensionable = value;
            }
        }
        public int IntNominees
        {
            get
            {
                return this.intNominees;
            }
            set
            {
                intNominees = value;
            }
        }
        public string ChvPFNo
        {
            get
            {
                return this.chvPFNo;
            }
            set
            {
                chvPFNo = value;
            }
        }
        public long IntPFNo
        {
            get
            {
                return this.intPFNo;
            }
            set
            {
                intPFNo = value;
            }
        }
        
       
        public int  IntUesrID
        {
            get
            {
                return this.intUesrID;
            }
            set
            {
                intUesrID = value;
            }
        }
        public string DtmDOJ
        {
            get
            {
                return this.dtmDOJ;
            }
            set
            {
                dtmDOJ = value;
            }
        }
 
        #endregion
    }
}
      

