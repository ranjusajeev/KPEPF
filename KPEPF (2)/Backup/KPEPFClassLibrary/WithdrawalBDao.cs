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
        public DataSet GetWithBillsAll(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithBillDetails_S4", CommandType.StoredProcedure, ar);
            return ds;
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
    }
}
