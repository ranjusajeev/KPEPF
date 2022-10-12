using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
  public   class TE
    {
        #region fields

        private int intId;
        private int intAGEntryId;
        private string chvTEId;
        private int flgType;
        private string dtmChalBillDate;
        private int intChalBillNo;
        private decimal fltAmount;
        private string chvAccNoAndName;
        private string chvRemarks;
        private int intModeChg;
        private int intDTreasId;
        private int perYearId;
        private int perMnthId;
      
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
      public int IntAGEntryId
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
      public int FlgType
      {
          get
          {
              return this.flgType;
          }
          set
          {
              flgType = value;
          }
      }
      public string DtmChalBillDate
      {
          get
          {
              return this.dtmChalBillDate;
          }
          set
          {
              dtmChalBillDate = value;
          }
      }
      public int IntChalBillNo
      {
          get
          {
              return this.intChalBillNo;
          }
          set
          {
              intChalBillNo = value;
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
      public string ChvAccNoAndName
      {
          get
          {
              return this.chvAccNoAndName;
          }
          set
          {
              chvAccNoAndName = value;
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
     
      public int PerYearId
      {
          get
          {
              return this.perYearId;
          }
          set
          {
              perYearId = value;
          }
      }
      public int PerMnthId
      {
          get
          {
              return this.perMnthId;
          }
          set
          {
              perMnthId = value;
          }
      }
      #endregion
  }
}
