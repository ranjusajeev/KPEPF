using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
   public  class CreditMinusAG
   {
       #region fields
         private int intId;
         private int intRelMonthWiseId;
         private string  chvTEId;
         private string dtmChalDate;
         private int intChalNo;
         private string chvAccNo;
         private string chvName;
         private decimal  fltAmount;
         private string chvRemarks;
         private int intModeChg;
         private int intChalanId;
         private int intTreasId;
         private int intChalanAGID;
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
       public string DtmChalDate
       {
           get
           {
               return this.dtmChalDate;
           }
           set
           {
               dtmChalDate = value;
           }
       }
       public int IntChalNo
       {
           get
           {
               return this.intChalNo;
           }
           set
           {
               intChalNo = value;
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
       public int IntChalanId
       {
           get
           {
               return this.intChalanId;
           }
           set
           {
               intChalanId = value;
           }
       }
       public int IntTreasId
       {
           get
           {
               return this.intTreasId;
           }
           set
           {
               intTreasId = value;
           }
       }
       public int IntChalanAGID
       {
           get
           {
               return this.intChalanAGID;
           }
           set
           {
               intChalanAGID = value;
           }
       }
       #endregion

   }
}
