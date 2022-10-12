using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class WithdrawalPDEDAO : KPEPFDAOBase
    {
        public DataSet UpdateWithPde(WithdrawalPDE withdr)
        {
            DataSet dsW = new DataSet();
            ArrayList ArrIn1 = new ArrayList();
            ArrIn1.Add(withdr.IntId);
            ArrIn1.Add(withdr.IntAccNo);
            ArrIn1.Add(withdr.FlgUnidentified);
            ArrIn1.Add(withdr.FltAdvAmt);
            ArrIn1.Add(withdr.IntLoan);
            ArrIn1.Add(withdr.ChvSantionNo);
            ArrIn1.Add(withdr.DtWithdraw);
            ArrIn1.Add(withdr.FltConsolidate);
            ArrIn1.Add(withdr.IntNoOfInstalments);
            ArrIn1.Add(withdr.FltInstalmentAmt);
            ArrIn1.Add(withdr.Intmid);
            ArrIn1.Add(withdr.IntYrId);
            ArrIn1.Add(withdr.IntUserId);

            ArrIn1.Add(withdr.FlgUnPosted);
            //ArrIn1.Add(withdr.IntDrawnBy);
            ArrIn1.Add(withdr.IntUnPostedRsn);
            ArrIn1.Add(withdr.IntDisId);
            ArrIn1.Add(withdr.IntModeOfChgId);
            ArrIn1.Add(withdr.DtSantion);
            //ArrIn1.Add(withdr.NumWithdrawReqId);
            //ArrIn1.Add(withdr.IntVoucherAGID);
            ArrIn1.Add(withdr.IntWithdrawalRefId);
            try
            {
                dsW = Fetch("Pfo_Withdrawal_I3", CommandType.StoredProcedure, ArrIn1);
                return dsW;
                //Save("Pfo_Withdrawal_I3", CommandType.StoredProcedure, ArrIn1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet UpdateWithPde1(WithdrawalPDE withdr)
        {
            DataSet dsAPW = new DataSet();
            ArrayList ArIn1 = new ArrayList();
            ArIn1.Add(withdr.IntIdAPWith);
            ArIn1.Add(withdr.IntAccNo);
            ArIn1.Add(withdr.DtSantion);
            ArIn1.Add(withdr.FltAdvAmt);
            ArIn1.Add(withdr.IntLoan);
            ArIn1.Add(withdr.FlgUnPosted );
            ArIn1.Add(withdr.IntUnPostedRsn);
            ArIn1.Add(withdr.IntSourceId);
            ArIn1.Add(withdr.IntModeOfChgId);
            ArIn1.Add(withdr.IntBillId);
            ArIn1.Add(withdr.IntLBId);
            ArIn1.Add(withdr.IntSlNo);

            //ArIn1.Add(withdr.IntVoucherAGID);
            try
            {
                dsAPW = Fetch("AP_Withdrawal_I", CommandType.StoredProcedure, ArIn1);
                return dsAPW;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetLoanType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_LoanType_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetWithdrawaEmp(WithdrawalPDE wth)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(wth.IntBillId);
            ds = Fetch("AP_Withdrawal_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
             public DataSet GetWithdrawaEmpCnt(WithdrawalPDE wth)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(wth.IntBillId);
            ds = Fetch("AP_Withdrawal_S10", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void UpdateVoucherMode(ArrayList arr)
        {
            try
            {
                Save("Pfo_Withdrawal_D", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateWithdrawalMode(ArrayList arr)
        {
            try
            {
                Save("AP_Withdrawal_D", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet Getdrawnby()
        {
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(2);
            ds = Fetch("AP_L_DrawnBy_Cmb", CommandType.StoredProcedure, arr);
            return ds;
        }
    }
}
