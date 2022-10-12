using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class WithdrawalCDao : KPEPFDAOBase  
    {
        public DataSet GetWithCons(WithdrawalC wth)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(wth.IntYearId);
            ar.Add(wth.IntMonthId);
            ar.Add(wth.IntDTId);
            ar.Add(wth.IntSourceId);
            ds = Fetch("AP_WithDrawCons_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet  SaveWithdrawCons(WithdrawalC wthc)
        {
            ArrayList ar = new ArrayList();
            DataSet ds = new DataSet();
            ar.Add(wthc.IntWithdrawConId);
            ar.Add(wthc.IntYearId);
            ar.Add(wthc.IntMonthId);
            ar.Add(wthc.IntDTId);
            ar.Add(wthc.IntSourceId);
            //ar.Add(wthc.DtAccDate);
            ar.Add(wthc.DtTrnDate);
            ar.Add(wthc.FltTAdvAmt);
            //ar.Add(wthc.IntSlNo);
            ar.Add(3);
        
             try
            {
                ds = Fetch("AP_WithdrawCons_I1", CommandType.StoredProcedure, ar );
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
       
        public DataSet FillConsAmt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_Withdrawal_S6", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillBillPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S13", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillConsAmtToGPF(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_ClosureDetails_TRN_S4", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillConsAmtToKPEPF(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_BalanceTransfer_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet SelWithConDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithDrawCons_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        } 
    }
}
