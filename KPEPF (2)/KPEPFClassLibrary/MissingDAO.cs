using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;


namespace KPEPFClassLibrary
{
     public class MissingDAO : KPEPFDAOBase
 
    {
        public DataSet CreateCreditMissing(Missing msng)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(msng.IntId);
            ArrIn.Add(msng.IntAGEntryId);
            ArrIn.Add(msng.ChvTEId);
            ArrIn.Add(msng.FlgType);
            ArrIn.Add(msng.ChvChalanBillNo );
            ArrIn.Add(msng.DtmChalanBilllDt );
            ArrIn.Add(msng.FltAmt );
            ArrIn.Add(msng.FlgMissing );
            ArrIn.Add(msng.IntYearId );
            ArrIn.Add(msng.IntMonthId );
            ArrIn.Add(msng.IntLBID );
            ArrIn.Add(msng.IntTreasID );
            ArrIn.Add(msng.ChvRemarks );

            try
            {
                ds = Fetch("AGCreditDebitMissing_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
         public DataSet TERelMonthWiseUpd(Missing msng)
         {
             DataSet ds = new DataSet();
             ArrayList ArrIn = new ArrayList();
             ArrIn.Add(msng.IntTEMonthWiseId);
             ArrIn.Add(msng.IntRelYearId);
             ArrIn.Add(msng.IntRelMonthId);
             ArrIn.Add(msng.FltAmtPDE);
             ArrIn.Add(msng.IntTrnType);
             ArrIn.Add(msng.IntTreaId);
             ArrIn.Add(msng.IntModeChg);
             ArrIn.Add(msng.IntRelMonthWiseId);
             ArrIn.Add(msng.lBId);
             ArrIn.Add(msng.ChvTEIdPDE );
             try
             {
                 ds = Fetch("AP_TERelMonthWise_I", CommandType.StoredProcedure, ArrIn);
                 return ds;
             }
             catch (Exception E)
             {
                 throw new Exception("Check the Error" + E.Message);
             }
         }
        
         public DataSet CreateTEPlusMissingPDE(Missing msng)
         {
             DataSet ds = new DataSet();
             ArrayList ArrIn = new ArrayList();
             ArrIn.Add(msng.IntId);
             ArrIn.Add(msng.ChvTEIdPDE);
             ArrIn.Add(msng.FltAmtPDE);
             ArrIn.Add(msng.ChvRemarksPDE);
             ArrIn.Add(msng.IntRelMonthWiseId);
             ArrIn.Add(msng.IntTrnType);
             ArrIn.Add(msng.FlgMissingPDE);
             ArrIn.Add(msng.IntChalNo);
             ArrIn.Add(msng.DtmChalanBilllDtPDE);
             ArrIn.Add(msng.IntTreaId);
             ArrIn.Add(msng.lBId);
             ArrIn.Add(msng.IntRelYearId);
             ArrIn.Add(msng.IntRelMonthId);
             try
             {
                 ds = Fetch("AP_TEPlusMissing_I", CommandType.StoredProcedure, ArrIn);
                 return ds;
             }
             catch (Exception E)
             {
                 throw new Exception("Check the Error" + E.Message);
             }
         }
         public DataSet UpdateAGdebitcurr(Missing msng)
         {
             DataSet ds = new DataSet();
             ArrayList ArrIn = new ArrayList();
             ArrIn.Add(msng.IntId);
             ArrIn.Add(msng.FlgMissing);
             ds = Fetch("AGCreditDebitMissing_U", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsPDEBind(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AP_TEPlusMissing_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocs(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsBind(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_S4", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet DeleteDebitWithoutDocs(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsRowCnt(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsRowCntNew(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsPDE(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AP_TEPlusMissing_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet FillCrWithoutDocsPDEForCnt(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AP_TEPlusMissing_S4", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet DeleteCrWithoutDocs(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet DeleteDaerWithoutDocs(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public DataSet DeleteOAOWithoutDocs(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AGCreditDebitMissing_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
         public void UpdateTEPlusMissing(ArrayList arr)
         {
             try
             {
                 Save("AP_TEPlusMissing_D", CommandType.StoredProcedure, arr);
             }
             catch (Exception E)
             {
                 throw new Exception("Check the Error" + E.Message);
             }
         }
         public DataSet DeleteDebitWithoutDocsPDE(ArrayList ArrIn)
         {
             DataSet ds = new DataSet();
             ds = Fetch("AP_TEPlusMissing_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
             return ds;
         }
    }
}
