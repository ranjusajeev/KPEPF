using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
   public  class balancetrans
   {
       # region fields
        private int intID;
        private int intAGEntryId;
        private string  chvTEId;
        private decimal fltAmt;
        private string chvFrmAccNo;
         private int intToAccNo;
       private int intFrmAccNo;
       private string chvToAccNo;
        private string chvRemarks;
        private int intModeChg;
        private int intYearId;
       private int intMonthId;

       #endregion
       #region Property
       public int IntID
       {
           get
           {
               return this.intID;
           }
           set
           {
               intID = value;
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
       public decimal FltAmt
       {
           get
           {
               return this.fltAmt;
           }
           set
           {
               fltAmt = value;
           }
       }
       public string ChvFrmAccNo
       {
           get
           {
               return this.chvFrmAccNo;
           }
           set
           {
               chvFrmAccNo = value;
           }
       }
       public int IntToAccNo
       {
           get
           {
               return this.intToAccNo;
           }
           set
           {
               intToAccNo = value;
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
       public int IntYearId
       {
           get
           {
               return this.intYearId;
           }
           set
           {
               intYearId = value;
           }
       }
       public int IntMonthId
       {
           get
           {
               return this.intMonthId;
           }
           set
           {
               intMonthId = value;
           }
       }
       public int IntFrmAccNo
       {
           get
           {
               return this.intFrmAccNo;
           }
           set
           {
               intFrmAccNo = value;
           }
       }
       public string ChvToAccNo
       {
           get
           {
               return this.chvToAccNo;
           }
           set
           {
               chvToAccNo = value;
           }
       }
       #endregion
   }
}
