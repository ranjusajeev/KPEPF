using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
   public  class Passbook
   {
       #region fields
         private double numEmpId;
         private int intYearId;
         private int intMonthId;
         
         private string dtmEncashmnt;
         private int intTreasuryId;
         private int intChalanNo;
         private string dtmChalanDate;
         private double fltSubn;
         private double fltRepay;
         private double fltArrDA;
         private string chvGO;
         private string dtmGODate;
         private double  fltWithdrawal;
         private int intLoanType;
         private string dtmWithdate;
         private int instNo;
         private int instAmt;
         private string chvRem;
         private long intUserId;
         private string dtmEntry;
         private int flgFlag;

       #endregion
  #region properties
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

       public string DtmEncashmnt
       {
           get
           {
               return this.dtmEncashmnt;
           }
           set
           {
               dtmEncashmnt = value;
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
       public int IntChalanNo
       {
           get
           {
               return this.intChalanNo;
           }
           set
           {
               intChalanNo = value;
           }
       }
       public string DtmChalanDate
       {
           get
           {
               return this.dtmChalanDate;
           }
           set
           {
               dtmChalanDate = value;
           }
       }
       public double FltSubn
       {
           get
           {
               return this.fltSubn;
           }
           set
           {
               fltSubn = value;
           }
       }
       public double FltRepay
       {
           get
           {
               return this.fltRepay;
           }
           set
           {
               fltRepay = value;
           }
       }
       public double FltArrDA
       {
           get
           {
               return this.fltArrDA;
           }
           set
           {
               fltArrDA = value;
           }
       }
       public string ChvGO
       {
           get
           {
               return this.chvGO;
           }
           set
           {
               chvGO = value;
           }
       }
       public string DtmGODate
       {
           get
           {
               return this.dtmGODate;
           }
           set
           {
               dtmGODate = value;
           }
       }
       public  double  FltWithdrawal
       {
           get
           {
               return this.fltWithdrawal;
           }
           set
           {
                 fltWithdrawal = value;
           }
       }
       public int IntLoanType
       {
           get
           {
               return this.intLoanType;
           }
           set
           {
               intLoanType = value;
           }
       }

       public string DtmWithdate
       {
           get
           {
               return this.dtmWithdate;
           }
           set
           {
               dtmWithdate = value;
           }
       }
       public int InstNo
       {
           get
           {
               return this.instNo;
           }
           set
           {
               instNo = value;
           }
       }
       public int InstAmt
       {
           get
           {
               return this.instAmt;
           }
           set
           {
               instAmt = value;
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
       public int FlgFlag
       {
           get
           {
               return this.flgFlag;
           }
           set
           {
               flgFlag = value;
           }
       }
    
#endregion
     }
}
