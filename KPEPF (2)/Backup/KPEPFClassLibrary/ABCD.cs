using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
   public  class ABCD
   {
       #region fields
        private int intID;
        private int intaccNo;
        private int  intYearId;
        private int intMonthId;
        private double totalCr;
        private double  totlAB;
        private double GrndTotal12;
        private double TotalWith;
        private double ArrearDA;
        private double netBalance;
        private double GrndTotal45;
        private string  chvGO;
        private string  dtmGODate;
       private double intArrearDA;

       #endregion
       #region properties
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
    public int IntaccNo
       {
           get
           {
               return this.intaccNo;
           }
           set
           {
               intaccNo = value;
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
       public double TotalCr
       {
           get
           {
               return this.totalCr;
           }
           set
           {
               totalCr = value;
           }
       }
       public double TotlAB
       {
           get
           {
               return this.totlAB;
           }
           set
           {
               totlAB = value;
           }
       }
       public double grndTotal12
       {
           get
           {
               return this.GrndTotal12;
           }
           set
           {
               GrndTotal12 = value;
           }
       }
       public double totalWith
       {
           get
           {
               return this.TotalWith;
           }
           set
           {
               TotalWith = value;
           }
       }
       public double arrearDA
       {
           get
           {
               return this.ArrearDA;
           }
           set
           {
               ArrearDA = value;
           }
       }
       public double NetBalance
       {
           get
           {
               return this.netBalance;
           }
           set
           {
               netBalance = value;
           }
       }
       public double grndTotal45
       {
           get
           {
               return this.GrndTotal45;
           }
           set
           {
               GrndTotal45 = value;
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
       public double IntArrearDA
       {
           get
           {
               return this.intArrearDA;
           }
           set
           {
               intArrearDA = value;
           }
       }
#endregion
   }
}
