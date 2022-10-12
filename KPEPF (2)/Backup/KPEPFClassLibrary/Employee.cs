using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class Employee
    {
        #region BasicDet
        private double numEmpID;
        private Boolean intEmpTypeId;
        private string strEmpName;
        private string strMalName;
        private Boolean intGender;
        private string dtmDOB;
        private string dtmDOR;
        private string dtmDOJS;
        private string dtmDOJP;
        private string strPFNo;
        private long intPFNo;
        private int intOtherFund;
        private Boolean flgMarried;
        private Boolean flgPensionable;
        private int intNominees;
        private long numSthapanaID;
        private int intJoinDist;
        private int intJoinLB;
        private int flgClosed;

        private double intAadhaar;
        private string chvPhone;
        private int intBankType;
        private int intBankBranch;
        private string chvBankAccNo;

        private int intflgApp;

        private long intUserId;
        private int mDOR;
        private int flgCont;
        private string chvWEFrom;
        #endregion

        #region CurrentDet
        public Boolean flgSuspension;
        private string strCurrentName;
        public int intCurrentDesigId;
        public long  fltBasicPay;
        public int intCurrLB;
        public long  fltSubscription;
        public long fltCurrentPFCredit;
        public long fltCurrentTAAmt;
        public long fltCurrentTAConsolidated;
        private string dtmCurrentLoanStartDate;
        public int intCurrentNoOfInstalments;
        public long fltCurrentAmtofInstalments;
        public long fltCurrentLoanOutStanding;
        public long fltPFCreditArrear;
        private string dtmCurrentArrearUpdationDate;
        public int flgArearUpdated;
        public int flgCurrLbFlg;
        public string dtmSubStartDate;
        #endregion

        #region propertyBasicDet
        public int FlgCont
        {
            get
            {
                return this.flgCont;
            }
            set
            {
                flgCont = value;
            }
        }
        public int MDOR
        {
            get
            {
                return this.mDOR;
            }
            set
            {
                mDOR = value;
            }
        }
        public double  NumEmpID
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
        public Boolean IntEmpTypeId
        {
            get
            {
                return this.intEmpTypeId;
            }
            set
            {
                intEmpTypeId = value;
            }
        }
        public string StrEmpName
        {
            get
            {
                return this.strEmpName;
            }
            set
            {
                strEmpName = value;
            }
        }
        public string StrMalName
        {
            get
            {
                return this.strMalName;
            }
            set
            {
                strMalName = value;
            }
        }
        public Boolean IntGender
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
        public string DtmDOR
        {
            get
            {
                return this.dtmDOR;
            }
            set
            {
                dtmDOR = value;
            }
        }
        public string DtmDOJS
        {
            get
            {
                return this.dtmDOJS;
            }
            set
            {
                dtmDOJS = value;
            }
        }
        public string DtmDOJP
        {
            get
            {
                return this.dtmDOJP;
            }
            set
            {
                dtmDOJP = value;
            }
        }

        public string StrPFNo
        {
            get
            {
                return this.strPFNo;
            }
            set
            {
                strPFNo = value;
            }
        }
        public long  IntPFNo
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
        public Boolean  FlgMarried
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
        public Boolean FlgPensionable
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
        public long NumSthapanaID
        {
            get
            {
                return this.numSthapanaID;
            }
            set
            {
                numSthapanaID = value;
            }
        }
        public int IntJoinDist
        {
            get
            {
                return this.intJoinDist;
            }
            set
            {
                intJoinDist = value;
            }
        }
        public int IntJoinLB
        {
            get
            {
                return this.intJoinLB;
            }
            set
            {
                intJoinLB = value;
            }
        }
        public int FlgClosed
        {
            get
            {
                return this.flgClosed;
            }
            set
            {
                flgClosed = value;
            }
        }



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
        public int IntflgApp
        {
            get
            {
                return this.intflgApp;
            }
            set
            {
                intflgApp = value;
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
        public string ChvWEFrom
        {
            get
            {
                return this.chvWEFrom;
            }
            set
            {
                chvWEFrom = value;
            }
        }
        #endregion
 
        #region propertyCurrDet
        public string StrCurrentName
        {
            get
            {
                return this.strCurrentName;
            }
            set
            {
                strCurrentName = value;
            }
        }
        public int IntCurrentDesigId
        {
            get
            {
                return this.intCurrentDesigId;
            }
            set
            {
                intCurrentDesigId = value;
            }
        }
        public long FltBasicPay
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
        public int IntCurrLB
        {
            get
            {
                return this.intCurrLB;
            }
            set
            {
                intCurrLB = value;
            }
        }
        public long FltSubscription
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
        public long FltCurrentPFCredit
        {
            get
            {
                return this.fltCurrentPFCredit;
            }
            set
            {
                fltCurrentPFCredit = value;
            }
        }
        public long FltCurrentTAAmt
        {
            get
            {
                return this.fltCurrentTAAmt;
            }
            set
            {
                fltCurrentTAAmt = value;
            }
        }
        public long FltCurrentTAConsolidated
        {
            get
            {
                return this.fltCurrentTAConsolidated;
            }
            set
            {
                fltCurrentTAConsolidated = value;
            }
        }
        public string DtmCurrentLoanStartDate
        {
            get
            {
                return this.dtmCurrentLoanStartDate;
            }
            set
            {
                dtmCurrentLoanStartDate = value;
            }
        }
        public int IntCurrentNoOfInstalments
        {
            get
            {
                return this.intCurrentNoOfInstalments;
            }
            set
            {
                intCurrentNoOfInstalments = value;
            }
        }
        public long FltCurrentAmtofInstalments
        {
            get
            {
                return this.fltCurrentAmtofInstalments;
            }
            set
            {
                fltCurrentAmtofInstalments = value;
            }
        }
        public long FltCurrentLoanOutStanding
        {
            get
            {
                return this.fltCurrentLoanOutStanding;
            }
            set
            {
                fltCurrentLoanOutStanding = value;
            }
        }
        public long FltPFCreditArrear
        {
            get
            {
                return this.fltPFCreditArrear;
            }
            set
            {
                fltPFCreditArrear = value;
            }
        }
        public string  DtmCurrentArrearUpdationDate
        {
            get
            {
                return this.dtmCurrentArrearUpdationDate;
            }
            set
            {
                dtmCurrentArrearUpdationDate = value;
            }
        }
        public int FlgArearUpdated
        {
            get
            {
                return this.flgArearUpdated;
            }
            set
            {
                flgArearUpdated = value;
            }
        }
        public int FlgCurrLbFlg
        {
            get
            {
                return this.flgCurrLbFlg;
            }
            set
            {
                flgCurrLbFlg = value;
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
        #endregion
    }
}
