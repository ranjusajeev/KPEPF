using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using KPEPFClassLibrary;
namespace KPEPFClassLibrary
{
    public class AORecorrectionDAO:KPEPFDAOBase 
    {
        public void UpdateApprovalPDE(AORecorrection recorr)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            ArrIn.Add(recorr.IntDistID);
            ArrIn.Add(recorr.IntType);
            ArrIn.Add(recorr.FlgApp);
            try
            {
                Save("ApprovalPDE_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDE(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            ArrIn.Add(recorr.IntType);
            try
            {
                ds = Fetch("ApprovalPDE_S1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk1(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntDistID);
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            try
            {
                ds = Fetch("ApprovalPDE_S2", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk1Curr(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntDistTID);
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            try
            {
                ds = Fetch("TreasuryD_S6", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk1With(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntDistID);
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            try
            {
                ds = Fetch("ApprovalPDE_S6", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk1WithCurr(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntDistTID);
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            try
            {
                ds = Fetch("Withdrawals_S8", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDEWithFlg(AORecorrection recorr)
        {
            DataSet dsA = new DataSet();
            ArrayList ArIn = new ArrayList();
            ArIn.Add(recorr.IntYearID);
            ArIn.Add(recorr.IntMonthID);
            ArIn.Add(recorr.IntDistID);
            ArIn.Add(recorr.IntType);
            try
            {
                dsA = Fetch("ApprovalPDE_S7", CommandType.StoredProcedure, ArIn);
                return dsA;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk2(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.FlgYearPrev);
            ArrIn.Add(recorr.NumChalanId);
            try
            {
                ds = Fetch("ApprovalPDE_S3", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk2Curr(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.NumChalanId);
            try
            {
                ds = Fetch("Chalan_S22", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk3(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.NumChalanId);
            ArrIn.Add(recorr.FlgYearPrev);
            
            try
            {
                ds = Fetch("ApprovalPDE_S4", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet Schedule4RowCnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tb_ScheduleTR104_S6", CommandType.StoredProcedure, ArrIn); // ScheduleTR104_S1
            return ds;
        }
        //public DataSet SelectApprovalPDELnk3Curr(AORecorrection recorr)
        //{
        //    DataSet ds = new DataSet();
        //    ArrayList ArrIn = new ArrayList();
        //    ArrIn.Add(recorr.NumChalanId);
        //    ArrIn.Add(recorr.FlgYearPrev);

        //    try
        //    {
        //        ds = Fetch("ApprovalPDE_S4", CommandType.StoredProcedure, ArrIn);
        //        return ds;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        //////////////////////// AG ///////////////////////
        public void UpdateApprovalPDEAG(AORecorrection recorr)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            ArrIn.Add(recorr.FlgApp);
            try
            {
                Save("ApprovalPDE_AG_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDEAG(AORecorrection recorr)
        {
            DataSet dsA = new DataSet();
            ArrayList ArrInA = new ArrayList();
            ArrInA.Add(recorr.IntYearID);
            try
            {
                dsA = Fetch("ApprovalPDEAG_S1", CommandType.StoredProcedure, ArrInA);
                return dsA;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //////////////////////// AG ///////////////////////

        //////////////////////// Current ///////////////////////
        public DataSet GetApprovalCurr(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TreasuryD_S5", CommandType.StoredProcedure, arr);
            return ds;
        }
        public void UpdateflagApp(ArrayList arr)
        {
            try
            {
                Save("TreasuryD_U1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }


        public DataSet SelectApprovalCurrAG(AORecorrection recorr)
        {
            DataSet dsA = new DataSet();
            ArrayList ArrInA = new ArrayList();
            ArrInA.Add(recorr.IntYearID);
            try
            {
                dsA = Fetch("AGEntries_S3", CommandType.StoredProcedure, ArrInA);
                return dsA;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //////////////////////// Current ///////////////////////
        public void UpdateflagAppAGCurr(AORecorrection recorr)
        {
            ArrayList ar = new ArrayList();
            ar.Add(recorr.IntYearID);
            ar.Add(recorr.IntMonthID);
            ar.Add(recorr.FlgApp);
            try
            {
                Save("AGEntries_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CheckApp4CardGen()
        {
            DataSet dsC = new DataSet();
            try
            {
                dsC = Fetch("ApprovalPDE_S8", CommandType.StoredProcedure);
                return dsC;
            }
                
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SelectApprovalPDELnk1WithCNT(AORecorrection recorr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(recorr.IntDistID);
            ArrIn.Add(recorr.IntYearID);
            ArrIn.Add(recorr.IntMonthID);
            try
            {
                ds = Fetch("ApprovalPDE_S10", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
