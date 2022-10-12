using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using KPEPFClassLibrary;

namespace KPEPFClassLibrary
{
    public class WithdrwalDAO : KPEPFDAOBase
    {
        public DataSet  SaveWithdrawals(Withdrawals wth)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(wth.NumWithdrawalID);
            ArrIn.Add(wth.NumEmpID);
            ArrIn.Add(wth.IntTrnTypeID);
            ArrIn.Add(wth.FltAllottedAmt);
            ArrIn.Add(wth.FltConsolidatedAmt);
            ArrIn.Add(wth.IntUserId);
            ArrIn.Add(wth.DtmWithdrawalEmp);
            ArrIn.Add(wth.NumBillID);
            ArrIn.Add(wth.FlgBillType);

            ArrIn.Add(wth.intYearID);
            ArrIn.Add(wth.FlgUnPosted);
            ArrIn.Add(wth.IntUnPostedRsn);
            ArrIn.Add(wth.IntModeChange);
            ArrIn.Add(wth.IntDrawnId);
            ArrIn.Add(wth.IntDesigId);
            ArrIn.Add(wth.IntLBId);
            ArrIn.Add(wth.ChvOrderNo);
            ArrIn.Add(wth.DtmDateOfOrder);
            ArrIn.Add(wth.IntObjAdv);
            ArrIn.Add(wth.ChvOdrNoDtOfPrevTA);
            ArrIn.Add(wth.FltAmtPrevTA);
            ArrIn.Add(wth.FltBalancePrevTA);
            ArrIn.Add(wth.IntNoOfInstalment);
            ArrIn.Add(wth.FltAmtInstalment);



            try
            {
                ds = Fetch("Withdrawals_I2", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetBillsCon(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S6", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet CheckAvail(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S5", CommandType.StoredProcedure, arr);
            return ds;
        }

        public DataSet GetBillNo(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S10", CommandType.StoredProcedure, arr);
            return ds;
        }
        
        public DataSet WithdrawalTreasury(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S8", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetBills(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S9", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetBillsextra(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S11", CommandType.StoredProcedure, arr);
            return ds;
        }
        public void SaveExtraBill(ArrayList arr)
        {
            try
            {
                Save("Bill_I1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public DataSet FillEmpGrid(ArrayList arr)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("Withdrawals_S3", CommandType.StoredProcedure, arr);
        //    return ds;
        //}
        public DataSet GetYearDetail(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S5", CommandType.StoredProcedure, arr);
            return ds;
        }

        public DataSet GetAmtLBTot(ArrayList ArIn)
        {
            DataSet dsn = new DataSet();
            dsn = Fetch("TreasuryD_S7", CommandType.StoredProcedure, ArIn);//Chalan_S1
            return dsn;
        }
        public int UpdateBill(ArrayList arr)
        {
            int r;
            try
            {
                Save("Bill_U1", CommandType.StoredProcedure, arr);
                r = 1;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
                r = 0;
            }
            return r;
        }
        public long SaveBillToTreasury(ArrayList arr)
        {
            long n;
            try
            {
               n= Save("TreasuryD_I", CommandType.StoredProcedure, arr);
               return n;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetExtraBill(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetOtherBill(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BillOther_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public long  SaveBillDetail(ArrayList arr)
        {
            long n;
            try
            {
                n=Save("Withdrawals_I1", CommandType.StoredProcedure, arr);
                return n;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        
        public void  SaveBillOthers(ArrayList arr)
        {
            try
            {
                Save ("BillOther_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public void DeleteOtherBill(ArrayList arr)
        //{
        //    try
        //    {
        //        Fetch("BillOther_U1", CommandType.StoredProcedure, arr);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}

        public void UpdWithdrawalMode(ArrayList arin)
        {
            try
            {
                Save("Withdrawals_D", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }


        public DataSet GetWithdrawaEmp(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S9", CommandType.StoredProcedure, arr);
            return ds;
        }
        public void UpdateBillTreasId(ArrayList arr)
        {
            try
            {
                Save("Bill_U3", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateTreasuryDMiss(ArrayList arr)
        {
            try
            {
                Save("TreasuryD_U3", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public void DeleteBillExtra(ArrayList arr)
        //{
        //    try
        //    {
        //        Save("Bill_D", CommandType.StoredProcedure, arr);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public DataSet GetSTreasuryDetWith(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("Bill_S12", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public DataSet GetBillAll(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("BillOther_S2", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public DataSet GetBillPart(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("BillOther_S3", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public void UpdateBillModeCurr(ArrayList arr)
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
        public DataSet GetYrFrmBill(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S14", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetWithdrawaEmpSing(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S12", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet getEmpDupl(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S13", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet getEmpBillwise(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S11", CommandType.StoredProcedure, arr);
            return ds;
        }
    }
}
