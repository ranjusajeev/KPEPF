using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
   public  class BalancetransDAO : KPEPFDAOBase
    {
        public DataSet CreateBalanceTransCr(balancetrans bal)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(bal.IntID);
            ArrIn.Add(bal.IntAGEntryId );
            ArrIn.Add(bal.ChvTEId );
            ArrIn.Add(bal.FltAmt);
            ArrIn.Add(bal.ChvFrmAccNo );
            ArrIn.Add(bal.IntToAccNo );
            ArrIn.Add(bal.ChvRemarks );
            ArrIn.Add(bal.IntModeChg );
            ArrIn.Add(bal.IntYearId );
            ArrIn.Add(bal.IntMonthId );
           
            try
            {
                ds = Fetch("BalanceTransferCr_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
       public DataSet FillBalancetransDt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferDt_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet DeleteBalancetransDt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferDt_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransDtCnt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferDt_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransDtPDE(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AP_BalanceTransfer_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransDtPDEForCnt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AP_BalanceTransfer_S5", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransCr(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferCr_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransCrBind(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AP_BalanceTransfer_S4 ", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransCrRowCnt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferCr_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillBalancetransCrPDE(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AP_BalanceTransfer_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet CreateBalanceTransDt(balancetrans bal)
       {
           DataSet ds = new DataSet();
           ArrayList ArrIn = new ArrayList();
           ArrIn.Add(bal.IntID);
           ArrIn.Add(bal.IntAGEntryId);
           ArrIn.Add(bal.ChvTEId);
           ArrIn.Add(bal.FltAmt);
           ArrIn.Add(bal.IntFrmAccNo );
           ArrIn.Add(bal.ChvToAccNo);
           ArrIn.Add(bal.ChvRemarks);
           ArrIn.Add(bal.IntModeChg);
           ArrIn.Add(bal.IntYearId);
           ArrIn.Add(bal.IntMonthId);

           try
           {
               ds = Fetch("BalanceTransferDt_I", CommandType.StoredProcedure, ArrIn);
               return ds;
           }
           catch (Exception E)
           {
               throw new Exception("Check the Error" + E.Message);
           }
       }
       public void DeleteBalancetransCr(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferCr_D", CommandType.StoredProcedure, ArrIn);
       }
       public DataSet getEditStatus(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferCr_S4", CommandType.StoredProcedure, ArrIn);
           return ds;
       }
       public DataSet getEditStatusDt(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("AGBalanceTransferDt_S4", CommandType.StoredProcedure, ArrIn);
           return ds;
       }

    }
}
