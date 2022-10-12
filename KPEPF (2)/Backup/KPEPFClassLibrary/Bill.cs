using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
   public  class Bill
   {
   # region fields
     private double numBillID;
     private int intBillNo;
     private string  chvBillNo;
     private string  dtmBill;
     private decimal  fltBillAmount;
     private long intUserId;
     private int intYearId;
     private int intMonthId;
     private int intTreasuryId;
     private decimal  flgUnposted;
     private int intUnPostedRsn;
     private decimal  flgTreasuryRec;
     private string  chvRem;
     private decimal  flgSource;
     private int intCnt;
     private decimal  flgBillType;
     private int intTreasuryDAGID;
     private int TENo;
     private int intDrawnBy;
     private int intDay;
       
  #endregion
       #region Property


       public  double NumBillID
       {
           get
           {
               return this.numBillID;
           }
           set
           {
               numBillID = value;
           }
       }
       public int IntBillNo
       {
           get
           {
               return this.intBillNo;
           }
           set
           {
               intBillNo = value;
           }
       }
       public string ChvBillNo
       {
           get
           {
               return this.chvBillNo;
           }
           set
           {
               chvBillNo = value;
           }
       }
       public string DtmBill
       {
           get
           {
               return this.dtmBill;
           }
           set
           {
               dtmBill = value;
           }
       }
       public decimal FltBillAmount
       {
           get
           {
               return this.fltBillAmount;
           }
           set
           {
               fltBillAmount = value;
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
       public int IntTreasuryId
       {
           get
           {
               return this.intTreasuryId;
           }
           set
           {
               intTreasuryId = value;
           }
       }
       public decimal FlgUnposted
       {
           get
           {
               return this.flgUnposted;
           }
           set
           {
               flgUnposted = value;
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
       public decimal FlgTreasuryRec
       {
           get
           {
               return this.flgTreasuryRec;
           }
           set
           {
               flgTreasuryRec = value;
           }
       }
       public string ChvRem
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
       public decimal FlgSource
       {
           get
           {
               return this.flgSource;
           }
           set
           {
               flgSource = value;
           }
       }
       public int IntCnt
       {
           get
           {
               return this.intCnt;
           }
           set
           {
               intCnt = value;
           }
       }
       public decimal FlgBillType
       {
           get
           {
               return this.flgBillType;
           }
           set
           {
               flgBillType = value;
           }
       }
       public int IntTreasuryDAGID
       {
           get
           {
               return this.intTreasuryDAGID;
           }
           set
           {
               intTreasuryDAGID = value;
           }
       }
       public int tENo
       {
           get
           {
               return this.TENo;
           }
           set
           {
               TENo = value;
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
       public int IntDay
       {
           get
           {
               return this.intDay;
           }
           set
           {
               intDay = value;
           }
       }
       #endregion
   }

}
