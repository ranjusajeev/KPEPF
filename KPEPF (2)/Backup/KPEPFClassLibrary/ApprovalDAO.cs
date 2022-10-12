using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using KPEPFClassLibrary;
namespace KPEPFClassLibrary
{
    public class ApprovalDAO:KPEPFDAOBase 
    {
        public void CreateApproval(Approval approval)
        {
            ArrayList ArrIn = new ArrayList();  
            ArrIn.Add(approval.IntTrnTypeID);
            ArrIn.Add(approval.NumTrnID);            
            ArrIn.Add(approval.FlgApproval);
            ArrIn.Add(approval.IntUserId);
            ArrIn.Add(approval.ChvRem);
            try
            {
                Save("Approval_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void CreateSuspense(Approval app,int flgSusp,int RsnId)
        {
            ArrayList ArrInSus = new ArrayList();
            ArrInSus.Add(app.IntTrnTypeID);
            ArrInSus.Add(app.NumTrnID);
            ArrInSus.Add(flgSusp);
            ArrInSus.Add(RsnId);
            try
            {
                Save("SuspenseEntry_I", CommandType.StoredProcedure, ArrInSus);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet UpdateApproval(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("Approval_I1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public void  SaveReturnedFiles(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                Save("ReturnedFiles_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet GetTrnLBType(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S10", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetTrnLBTypeForMS(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S10", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void UpdateFlgForRejection(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                Save("Approval_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public void SaveRejAfterApproval(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                Save("RejAfterApproval_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet CheckFlagApp(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TreasuryD_S9", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
    }
}
