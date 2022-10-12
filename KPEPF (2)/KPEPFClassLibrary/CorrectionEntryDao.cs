using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class CorrectionEntryDao : KPEPFDAOBase 
    {
        public DataSet CreateCorrEntry(CorrectionEntry corr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(corr.IntAccNo);
            ArrIn.Add(corr.IntYearID);
            ArrIn.Add(corr.IntMonthID);
            ArrIn.Add(corr.IntYearIDCorrected);
            ArrIn.Add(corr.FltAmountBefore);
            ArrIn.Add(corr.FltAmountAfter);
            ArrIn.Add(corr.FltCalcAmount);
            ArrIn.Add(corr.FlgCorrected);
            ArrIn.Add(corr.IntChalanId);
            ArrIn.Add(corr.IntSchedId);
            ArrIn.Add(corr.FlgType);
            ArrIn.Add(corr.FltRoundingAmt);
            ArrIn.Add(corr.IntCorrectionType);
            //ArrIn.Add(corr.StrFrmChalDt);
            //ArrIn.Add(corr.StrToChalDt);
            ArrIn.Add(corr.IntChalanType);

            try
            {
                ds = Fetch("CorrectionEntry_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreateCorrEntryCalc(CorrectionEntry corr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(corr.IntAccNo);
            ArrIn.Add(corr.IntYearID);
            ArrIn.Add(corr.IntMonthID);
            ArrIn.Add(corr.IntYearIDCorrected);
            ArrIn.Add(corr.FltAmountBefore);
            ArrIn.Add(corr.FltAmountAfter);
            ArrIn.Add(corr.FltCalcAmount);
            ArrIn.Add(corr.FlgCorrected);
            ArrIn.Add(corr.IntChalanId);
            ArrIn.Add(corr.IntSchedId);
            ArrIn.Add(corr.FlgType);
            ArrIn.Add(corr.FltRoundingAmt);
            ArrIn.Add(corr.IntCorrectionType);
            //ArrIn.Add(corr.StrFrmChalDt);
            //ArrIn.Add(corr.StrToChalDt);
            ArrIn.Add(corr.IntChalanType);

            try
            {
                ds = Fetch("CorrectionEntry_I1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreateCorrEntryCalcTblTp(CorrectionEntry corr)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(corr.IntAccNo);
            ArrIn.Add(corr.IntYearID);
            ArrIn.Add(corr.IntMonthID);
            ArrIn.Add(corr.IntYearIDCorrected);
            ArrIn.Add(corr.FltAmountBefore);
            ArrIn.Add(corr.FltAmountAfter);
            ArrIn.Add(corr.FltCalcAmount);
            ArrIn.Add(corr.FlgCorrected);
            ArrIn.Add(corr.IntChalanId);
            ArrIn.Add(corr.IntSchedId);
            ArrIn.Add(corr.FlgType);
            ArrIn.Add(corr.FltRoundingAmt);
            ArrIn.Add(corr.IntCorrectionType);
            //ArrIn.Add(corr.StrFrmChalDt);
            //ArrIn.Add(corr.StrToChalDt);
            ArrIn.Add(corr.IntChalanType);
            ArrIn.Add(corr.IntTblTp);
            try
            {
                ds = Fetch("CorrectionEntry_I2", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetCorrectionEntryDet(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S1", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet GetMltplSingleCalc()
        {

            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S8", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetCorrectionEntryDetNw(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S10", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet GetCorrectionEntryDetNwLat(ArrayList ar)
        {
            DataSet ds = new DataSet();
            //ds = Fetch("TB_LedgerDet_TRN_S7", CommandType.StoredProcedure, ar);
            ds = Fetch("TB_LedgerDet_TRN_S7_Lat", CommandType.StoredProcedure, ar);
            return ds;
        }

        //Ranjitha on 02112020

        public DataSet GetAdminSettings()
        {
            DataSet ds = new DataSet();
            ds = Fetch("AdminSettings_S", CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetCorrectionEntryDetNwLat_New(ArrayList ar)
        {
            DataSet ds = new DataSet();
            //ds = Fetch("TB_LedgerDet_TRN_S7", CommandType.StoredProcedure, ar);
            ds = Fetch("TB_LedgerDet_TRN_S7_Lat_New", CommandType.StoredProcedure, ar);
            return ds;
        }

        public DataSet GetCorrectionEntryCorr_YearWise(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S9_YearWise", CommandType.StoredProcedure, ar);
            return ds;
        }

        //end
        public DataSet GetCorrectionEntryDetNwLatVar(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S100", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetCorrectionEntryCorr(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S9", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetCorrectionEntryCnt(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("CorrectionEntry_S2", CommandType.StoredProcedure,ar);
            return dsC;
        }
        public DataSet GetCorrectionEntry4Calc(CorrectionEntry cor)
        {
            ArrayList ar = new ArrayList();
            ar.Add(cor.IntAccNo);
            DataSet dsC4 = new DataSet();
            dsC4 = Fetch("CorrectionEntry_S3", CommandType.StoredProcedure, ar);
            return dsC4;
        }
        public void DelCorrEntryChild(ArrayList ard)
        {
            try
            {
                Fetch("C_CorrectionEntry_D", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SaveCorrEntryChild(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("C_CorrectionEntry_I", CommandType.StoredProcedure, ar);
            return dsC;
        }
        public DataSet FillCorrectionEntry(ArrayList ar)
        {
            DataSet dsC = new DataSet();
           // dsC = Fetch("CorrectionTemp_S1Curr11", CommandType.StoredProcedure, ar);
            dsC = Fetch("CorrectionTempCurr_S1", CommandType.StoredProcedure, ar);          
            return dsC;
        }
        public DataSet CalculateBalMonthsWithDayMltpl(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("G_MonthMltplRt_S1", CommandType.StoredProcedure, ar);
            return dsC;
        }
        public DataSet GetCorrectionEntry4CardGen(CorrectionEntry cor)
        {
            ArrayList ar = new ArrayList();
            ar.Add(cor.IntAccNo);
            DataSet dsCg = new DataSet();
            dsCg = Fetch("CorrectionEntry_S4", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet CheckCorrectionEntry4CardGen(CorrectionEntry cor)
        {
            ArrayList ar = new ArrayList();
            ar.Add(cor.IntAccNo);
            DataSet dsCg = new DataSet();
            dsCg = Fetch("CorrectionEntry_S6", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet CheckCorrectionEntry4CardGenLat(ArrayList ar)
        {
            DataSet dsCg = new DataSet();
            dsCg = Fetch("LedgerYearly_S8", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet CheckCorrectionEntry4PC(ArrayList ar)
        {
            DataSet dspc = new DataSet();
            dspc = Fetch("CorrectionEntry_S8", CommandType.StoredProcedure, ar);
            return dspc;
        }
        public DataSet CheckCorrectionEntry4CardGenPrev(CorrectionEntry cor)
        {
            ArrayList ar = new ArrayList();
            ar.Add(cor.IntAccNo);
            ar.Add(cor.IntYearID);
            DataSet dsCg = new DataSet();
            dsCg = Fetch("LedgerYearly_S5", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet GetData4PCardn(ArrayList ar)
        {
            DataSet dsCg = new DataSet();
            dsCg = Fetch("L_EmployeeDet_S17", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet GetData4HTML(ArrayList ar)
        {
            DataSet dsCg = new DataSet();
            dsCg = Fetch("C_CorrectionEntry_S1", CommandType.StoredProcedure, ar);
            return dsCg;
        }
        public DataSet UpdCorrectionEntryTableType(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("CorrectionEntry_U1", CommandType.StoredProcedure, ar);
            return dsC;
        }
        //public DataSet UpdWithdrawalsMode4()
        //{
        //    DataSet dsC = new DataSet();
        //    dsC = Fetch("Withdrawals_U1", CommandType.StoredProcedure);
        //    return dsC;
        //}
        public DataSet GetCorrectionEntryDet51(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S7", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void DelCorrEntry(ArrayList ard)
        {
            try
            {
                Fetch("CorrectionEntry_D", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void DelCorrEntryBulk(ArrayList ard)
        {
            try
            {
                Fetch("CorrectionEntry_D2", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void DelCorrEntrySingle(ArrayList ard)
        {
            try
            {
                Fetch("CorrectionEntry_D1", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void CorrectionCalcInsert(ArrayList ard)
        {
            try
            {
                Fetch("CorrectionCalc_I", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet getCorrDetFromTemp()
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionCalc_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet checkCorrCount(ArrayList ard)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionCalc_S2", CommandType.StoredProcedure, ard);
            return ds;
        }
        public void CorrectionCalcUpd(ArrayList ard)
        {
            try
            {
                Fetch("CorrectionCalc_U", CommandType.StoredProcedure, ard);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void DelCorrectionCalc()
        {
            try
            {
                Fetch("CorrectionCalc_D", CommandType.StoredProcedure);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
