using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class WithdrawalRequestDAO : KPEPFDAOBase
    {
        public void CreateTARequest(WithdrawalRequest WithDraReq)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(WithDraReq.IntYearId);
            ArrIn.Add(WithDraReq.IntMonthId);
            ArrIn.Add(WithDraReq.ChvFileNo);
            ArrIn.Add(WithDraReq.NumEmpId);
            ArrIn.Add(WithDraReq.IntTrnTypeID);
            ArrIn.Add(WithDraReq.FltAmtProposed);
            ArrIn.Add(WithDraReq.FltAmtAdmissible);
            ArrIn.Add(WithDraReq.IntNoOfInstProposed);
            ArrIn.Add(WithDraReq.IntPurposeID);
            ArrIn.Add(WithDraReq.DtmDateOfRequest);
            ArrIn.Add(WithDraReq.IntUesrID);
            ArrIn.Add(WithDraReq.IntDesigID);
            ArrIn.Add(WithDraReq.FltInstAmount);
            ArrIn.Add(WithDraReq.NumWithRequestID);
            ArrIn.Add(WithDraReq.FltOutstandingAmount);
            try
            {
                Fetch("WithdrawalRequest_I", CommandType.StoredProcedure, ArrIn);

            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet CheckTAReqExist(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

        public DataSet InboxTA(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet InboxTA_Cnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetTADetails(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetBillDate(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetLastApprovedTA(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Approval_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetBillId(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("SanctionOder_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetReqStatus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Approval_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void CreateSanctionOrder(ArrayList ArrIn)
        {
            try
            {
                Save("SanctionOder_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void CreateAuthorisation(ArrayList ArrIn)
        {

            try
            {
                Save("Authorisation_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public void CreateWithdrawal(ArrayList ArrIn)
        //{
        //    try
        //    {
        //        Save("Pfo_Withdrawal_I1", CommandType.StoredProcedure, ArrIn);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public void CreateWithdrawal(ArrayList ArrIn)
        {
            try
            {
                Save("Withdrawals_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreateBill(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("Bill_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public void UpdateVoucher(ArrayList ArrIn)
        //{
        //    try
        //    {
        //        Save("Voucher_U", CommandType.StoredProcedure, ArrIn);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        //public void UpdateWithdrawal_Acquittance(ArrayList ArrIn)
        //{
        //    try
        //    {
        //        Save("Withdrawals_U1", CommandType.StoredProcedure, ArrIn);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public void UpdateBill(ArrayList ArrIn)
        {
            try
            {
                Save("Bill_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public void UpdateSanctionOrder(ArrayList ArrIn)
        {
            try
            {
                Save("SanctionOder_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        //public void UpdateWithdrawalReq(ArrayList ArrIn)
        //{
        //    try
        //    {
        //        Save("WithdrawalRequest_U", CommandType.StoredProcedure, ArrIn);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}

        public DataSet GetSanctionDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

        //public DataSet GetAcquittenceDet(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("Withdrawals_S7", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        //public DataSet GetAuthorisationDet(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("Authorisation_S", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        //public DataSet GetWithdrawReqStatus(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("WithdrawalRequest_S3", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public void UpdateEmpCurrentDetails_TA(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateEmpCurrentDetails_NRA(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U2", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetWithdrawalAcqutDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetWithdrawalAcqutDet4EmpMSTUpd(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetBillDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetAttatchmentDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Images_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getSearchList(string strSql)
        {

            DataSet ds = new DataSet();

            ds = Fetch(strSql, CommandType.Text);

            return ds;

        }

    }
}
