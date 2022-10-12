using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class BillDao : KPEPFDAOBase
    {
        public DataSet CreateDebitPlus(Bill bil)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            
            ArrIn.Add(bil.IntBillNo  );
            ArrIn.Add(bil.DtmBill );
            ArrIn.Add(bil.FltBillAmount);
            ArrIn.Add(bil.IntUserId);
            ArrIn.Add(bil.IntYearId);
            ArrIn.Add(bil.IntMonthId);
            ArrIn.Add(bil.IntTreasuryId );
            ArrIn.Add(bil.FlgUnposted );
            ArrIn.Add(bil.IntUnPostedRsn );
            ArrIn.Add(bil.ChvRem);
            ArrIn.Add(bil.FlgSource );
            ArrIn.Add(bil.FlgBillType);
            ArrIn.Add(bil.IntTreasuryDAGID);
            ArrIn.Add(bil.tENo);
            ArrIn.Add(bil.NumBillID);
            ArrIn.Add(bil.IntDrawnBy);
            ArrIn.Add(bil.IntDay);
           
            try
            {
                ds = Fetch("BillAG_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FillDBPlus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BillAG_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet DeleteDBPlus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BillAG_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillDBPlusRowCnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BillAG_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillDBPlusRowCntDaer(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BillAG_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillDBPlusPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_Withdrawal_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillDBPlusAmt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S10", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void UpdateNillMode(ArrayList arr)
        {
            try
            {
                Save("Bill_D", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet RecPrint3(ArrayList ar,int flg)
        {
            DataSet ds = new DataSet();
            if (flg == 2)
            {
                ds = Fetch("Bill_S34", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            else
            {
                ds = Fetch("Bill_S38", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            return ds;
        }
        public DataSet RecPrint4(ArrayList ar, int flg)
        {
            DataSet ds = new DataSet();
            if (flg == 2)
            {
                ds = Fetch("Bill_S35", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            else
            {
                ds = Fetch("Bill_S40", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            return ds;
        }
        public DataSet getEditableCurr(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S15", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
    }
}
