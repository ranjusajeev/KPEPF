using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
  public  class WithdrawalPDEAG
  {
      #region fields
         private int  intId;
         private int intDisId;
         private int intBookNo;
         private int intPageNo;
         private int flgIllegbleRec;
         private int intAccNo;
         private int flgUnidentified;
         private int intEmpcode;
         private string  chvEmployeeName;
         private int intDesignation;
         private decimal fltAdvAmt;
         private string chvSantionNo;
         private string dtSantion;
         private int intLoan;
         private string dtWithdraw;
         private int intRecNo;
         private decimal fltConsolidate;
         private int intNoOfInstalments;
         private float  fltInstalmentAmt;
         private int flgNewAccNo;
         private int intmid;
         private int intYrId;
         private int  intModeOfChgId;
         private long intUserId;
         private string dtmDateOfUpdation;
         private int intWithdrawalRefId;
         private string  chvOdrNoDtOfPrevTA;
         private int flgUnPosted;
         private float  fltAmtPrevTA;
         private float   fltBalancePrevTA;
         private int intDrawnBy;
         private int intLoanPurpose;
         private int  intUnPostedRsn;
         private int intVoucherAGID;
      private decimal numWithdrawReqId;

         private int intVoucherID;
         private int intRelMonthWsID;
         private string  chvTENo;
         private int intDTreaID;
         private int intVoucherNo;
         private string   dtmVoucherDt;
         private decimal   fltAmount;
        // private int  flgUnPosted;
         private int intReasonID;
         private int intYearID;
         private int intModeOfChgID;
         //private long intUserId;
         private string   dtmEntry;
        // private int intDrawnBy;





#endregion
       #region Property
      public int IntId
        {
            get
            {
                return this.intId;
            }
            set
            {
                intId = value;
            }
        }
      public int IntDisId
      {
          get
          {
              return this.intDisId;
          }
          set
          {
              intDisId = value;
          }
      }
      public int IntBookNo
      {
          get
          {
              return this.intBookNo;
          }
          set
          {
              intBookNo = value;
          }
      }
      public int IntPageNo
      {
          get
          {
              return this.intPageNo;
          }
          set
          {
              intPageNo = value;
          }
      }
      public int FlgIllegbleRec
      {
          get
          {
              return this.flgIllegbleRec;
          }
          set
          {
              flgIllegbleRec = value;
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
      public int FlgUnidentified
      {
          get
          {
              return this.flgUnidentified;
          }
          set
          {
              flgUnidentified = value;
          }
      }
      public int IntEmpcode
      {
          get
          {
              return this.intEmpcode;
          }
          set
          {
              intEmpcode = value;
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
      public int IntDesignation
      {
          get
          {
              return this.intDesignation;
          }
          set
          {
              intDesignation = value;
          }
      }
      public decimal FltAdvAmt
      {
          get
          {
              return this.fltAdvAmt;
          }
          set
          {
              fltAdvAmt = value;
          }
      }
      public string  ChvSantionNo
      {
          get
          {
              return this.chvSantionNo;
          }
          set
          {
              chvSantionNo = value;
          }
      }
      public string DtSantion
      {
          get
          {
              return this.dtSantion;
          }
          set
          {
              dtSantion = value;
          }
      }
      public int IntLoan
      {
          get
          {
              return this.intLoan;
          }
          set
          {
              intLoan = value;
          }
      }
      public string DtWithdraw
      {
          get
          {
              return this.dtWithdraw;
          }
          set
          {
              dtWithdraw = value;
          }
      }
      public int IntRecNo
      {
          get
          {
              return this.intRecNo;
          }
          set
          {
              intRecNo = value;
          }
      }
      public decimal  FltConsolidate
      {
          get
          {
              return this.fltConsolidate;
          }
          set
          {
              fltConsolidate = value;
          }
      }
      public int IntNoOfInstalments
      {
          get
          {
              return this.intNoOfInstalments;
          }
          set
          {
              intNoOfInstalments = value;
          }
      }
      public float  FltInstalmentAmt
      {
          get
          {
              return this.fltInstalmentAmt;
          }
          set
          {
              fltInstalmentAmt = value;
          }
      }
      public int FlgNewAccNo
      {
          get
          {
              return this.flgNewAccNo;
          }
          set
          {
              flgNewAccNo = value;
          }
      }
      public int Intmid
      {
          get
          {
              return this.intmid;
          }
          set
          {
              intmid = value;
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
      public int IntModeOfChgId
      {
          get
          {
              return this.intModeOfChgId;
          }
          set
          {
              intModeOfChgId = value;
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
      public string DtmDateOfUpdation
      {
          get
          {
              return this.dtmDateOfUpdation;
          }
          set
          {
              dtmDateOfUpdation = value;
          }
      }
      public int IntWithdrawalRefId
      {
          get
          {
              return this.intWithdrawalRefId;
          }
          set
          {
              intWithdrawalRefId = value;
          }
      }
      public string  ChvOdrNoDtOfPrevTA
      {
          get
          {
              return this.chvOdrNoDtOfPrevTA;
          }
          set
          {
              chvOdrNoDtOfPrevTA = value;
          }
      }
      public int FlgUnPosted
      {
          get
          {
              return this.flgUnPosted;
          }
          set
          {
              flgUnPosted = value;
          }
      }
      public float  FltAmtPrevTA
      {
          get
          {
              return this.fltAmtPrevTA;
          }
          set
          {
              fltAmtPrevTA = value;
          }
      }
      public float  FltBalancePrevTA
      {
          get
          {
              return this.fltBalancePrevTA;
          }
          set
          {
              fltBalancePrevTA = value;
          }
      }
      public int IntDrawnBy
      {
          get
          {
              return this.intDrawnBy;
          }
          set
          {
              intDrawnBy = value;
          }
      }
      public int IntLoanPurpose
      {
          get
          {
              return this.intLoanPurpose;
          }
          set
          {
              intLoanPurpose = value;
          }
      }
      public int IntUnPostedRsn
      {
          get
          {
              return this.intUnPostedRsn;
          }
          set
          {
              intUnPostedRsn = value;
          }
      }
      public int IntVoucherAGID
      {
          get
          {
              return this.intVoucherAGID;
          }
          set
          {
              intVoucherAGID = value;
          }
      }
      public decimal  NumWithdrawReqId
      {
          get
          {
              return this.numWithdrawReqId;
          }
          set
          {
              numWithdrawReqId = value;
          }
      }

      public int IntVoucherID
      {
          get
          {
              return this.intVoucherID;
          }
          set
          {
              intVoucherID = value;
          }
      }
      public int IntRelMonthWsID
      {
          get
          {
              return this.intRelMonthWsID;
          }
          set
          {
              intRelMonthWsID = value;
          }
      }
      public string  ChvTENo
      {
          get
          {
              return this.chvTENo;
          }
          set
          {
              chvTENo = value;
          }
      }
      public int IntDTreaID
      {
          get
          {
              return this.intDTreaID;
          }
          set
          {
              intDTreaID = value;
          }
      }
      public int IntVoucherNo
      {
          get
          {
              return this.intVoucherNo;
          }
          set
          {
              intVoucherNo = value;
          }
      }
      public string  DtmVoucherDt
      {
          get
          {
              return this.dtmVoucherDt;
          }
          set
          {
              dtmVoucherDt = value;
          }
      }
      public decimal   FltAmount
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
      //public int FlgUnPosted
      //{
      //    get
      //    {
      //        return this.flgUnPosted;
      //    }
      //    set
      //    {
      //        flgUnPosted = value;
      //    }
      //}
      public int IntReasonID
      {
          get
          {
              return this.intReasonID;
          }
          set
          {
              intReasonID = value;
          }
      }
      public int IntYearID
      {
          get
          {
              return this.intYearID;
          }
          set
          {
              intYearID = value;
          }
      }
      public int IntModeOfChgID
      {
          get
          {
              return this.intModeOfChgID;
          }
          set
          {
              intModeOfChgID = value;
          }
      }
      //public long IntUserId
      //{
      //    get
      //    {
      //        return this.intUserID;
      //    }
      //    set
      //    {
      //        intUserID = value;
      //    }
      //}
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
      //public int IntDrawnBy
      //{
      //    get
      //    {
      //        return this.intDrawnBy;
      //    }
      //    set
      //    {
      //        intDrawnBy = value;
      //    }
      //}
      #endregion
  }
}
