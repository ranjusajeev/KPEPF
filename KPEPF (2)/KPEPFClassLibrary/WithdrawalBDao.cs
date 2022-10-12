
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class WithdrawalBDao : KPEPFDAOBase
    {
        public DataSet GetWithBills(WithdrawalB wth)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(wth.IntWithdrawConId);
            ds = Fetch("AP_WithBillDetails_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet getBillsNotMapped(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tr_Bill_Pde_S3", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet getBillstMapped(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tr_Bill_Pde_S2", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetWithBillsAll(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tr_Bill_Pde_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void updTr_Bill_Pde(ArrayList ArrIn)
        {
            try
            {
                Save("Tr_Bill_Pde_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet GetWithBill(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithBillDetails_S8", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet InsBillPDE(WithdrawalB wth)
        {
            DataSet dsAPW = new DataSet();
            ArrayList ArIn1 = new ArrayList();
            ArIn1.Add(wth.IntBillWiseId);
            ArIn1.Add(wth.IntWithdrawConId);
            ArIn1.Add(wth.DtmBillDate);
            ArIn1.Add(wth.IntBillNo);
            ArIn1.Add(wth.FltNetAmt);
            ArIn1.Add(wth.IntSlNo);
            ArIn1.Add(wth.IntModeChgId);
            ArIn1.Add(wth.FlgUnPosted);
            ArIn1.Add(wth.IntUnPostedReason);


            //ArIn1.Add(withdr.IntVoucherAGID);
            try
            {
                dsAPW = Fetch("AP_WithBillDetails_I", CommandType.StoredProcedure, ArIn1);
                return dsAPW;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetWithEmpDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_Withdrawal_S2", CommandType.StoredProcedure, ar);
            return ds;
        }

        public DataSet DeleteBillDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithBillDetails_D", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet DeleteWthCons(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithDrawCons_D", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetBillDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithBillDetails_S7", CommandType.StoredProcedure, ar);
            return ds;
        }
        //////////////////////////////////
        public void SaveTreasuryDEntries(ArrayList ArrIn)
        {

            try
            {
                Save("TreasuryDEntriesW_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet DelTreasuryDEntries(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntriesW_D", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetTreasuryDetDataTxts(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntriesW_S3", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetTreasuryDetDataTxtsPrev(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("AP_WithDrawCons_S8", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetTreasuryDetData(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntriesW_S2", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetAmtLBTot(ArrayList ArIn)
        {
            DataSet dsn = new DataSet();
            dsn = Fetch("TreasuryD_S7", CommandType.StoredProcedure, ArIn);//Chalan_S1
            return dsn;
        }
        public DataSet GetTreasuryDetDataNw(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntriesW_S4", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        //public DataSet DelTreasuryDEntries(ArrayList ar)
        //{
        //    DataSet dsChaln = new DataSet();
        //    dsChaln = Fetch("TreasuryDEntriesW_D", CommandType.StoredProcedure, ar);
        //    return dsChaln;
        //}
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
        public void UpdateBill_C(ArrayList arr)
        {
            try
            {
                Save("Tr_Bill_C_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

    }
}
