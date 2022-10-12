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
        public DataSet GetCorrectionEntryDet(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            DataSet ds = new DataSet();
            ds = Fetch("CorrectionEntry_S1", CommandType.StoredProcedure, vArryIn);
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
            dsC = Fetch("CorrectionTemp_S1", CommandType.StoredProcedure, ar);
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
        public DataSet CheckCorrectionEntry4CardGenPrev(CorrectionEntry cor)
        {
            ArrayList ar = new ArrayList();
            ar.Add(cor.IntAccNo);
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
    }
}
