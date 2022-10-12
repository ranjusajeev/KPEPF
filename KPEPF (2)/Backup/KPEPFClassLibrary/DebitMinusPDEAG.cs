using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
  public  class DebitMinusPDEAG
    {
        #region fields
            private int intId;
            private int intRelMonthWiseId;
            private string  chvTEId;
            private string dtmVchrDate;
            private int intVchrNo;
            private string chvAccNo;
            private string chvName;
            private decimal  fltAmount;
            private string chvRemarks;
            private int flgUnPosted;
            private int intUnPostdReason;
            private int intModeChg;
            private int intBillWsId;
            private int intDistId;
            private int intDTreasId;
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
      public int IntRelMonthWiseId
      {
          get
          {
              return this.intRelMonthWiseId;
          }
          set
          {
              intRelMonthWiseId = value;
          }
      }

      public string ChvTEId
      {
          get
          {
              return this.chvTEId;
          }
          set
          {
              chvTEId = value;
          }
      }
      public string DtmVchrDate
      {
          get
          {
              return this.dtmVchrDate;
          }
          set
          {
              dtmVchrDate = value;
          }
      }
      public int IntVchrNo
      {
          get
          {
              return this.intVchrNo;
          }
          set
          {
              intVchrNo = value;
          }
      }
      public string ChvAccNo
      {
          get
          {
              return this.chvAccNo;
          }
          set
          {
              chvAccNo = value;
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
      public decimal FltAmount
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
      public string ChvRemarks
      {
          get
          {
              return this.chvRemarks;
          }
          set
          {
              chvRemarks = value;
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
      public int IntUnPostdReason
      {
          get
          {
              return this.intUnPostdReason;
          }
          set
          {
              intUnPostdReason = value;
          }
      }
      public int IntModeChg
      {
          get
          {
              return this.intModeChg;
          }
          set
          {
              intModeChg = value;
          }
      }
      public int IntBillWsId
      {
          get
          {
              return this.intBillWsId;
          }
          set
          {
              intBillWsId = value;
          }
      }
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
      public int IntDTreasId
      {
          get
          {
              return this.intDTreasId;
          }
          set
          {
              intDTreasId = value;
          }
      }
        #endregion

    }
}
