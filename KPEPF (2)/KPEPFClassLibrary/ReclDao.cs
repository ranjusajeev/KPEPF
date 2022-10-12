using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class ReclDao : KPEPFDAOBase
    {
        public DataSet GetReclT1(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("TB_LedgerDet_TRN_S2", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetReclT150(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("LedgerMonthly_S6", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetReclAg1(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("TB_LedgerDet_TRN_S3", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetReclAg150(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("LedgerMonthly_S7", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetReclT2(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("AP_RecLevl3New_S3", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetReclAg2(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("AP_RecLevl3New_S4", CommandType.StoredProcedure, ar);
            return dsR;
        }

        public DataSet GetReclT3(Recl rec)
        {
            DataSet dsR3 = new DataSet();
            ArrayList ar3 = new ArrayList();
            ar3.Add(rec.IntYearId);
            dsR3 = Fetch("AP_RecLevl3New_S5", CommandType.StoredProcedure, ar3);
            return dsR3;
        }
        public DataSet GetReclAg3(Recl rec)
        {
            DataSet dsR4 = new DataSet();
            ArrayList ar4 = new ArrayList();
            ar4.Add(rec.IntYearId);
            dsR4 = Fetch("AP_RecLevl3New_S6", CommandType.StoredProcedure, ar4);
            return dsR4;
        }
        public DataSet GetReclOB(Recl rec)
        {
            DataSet dsR4 = new DataSet();
            ArrayList ar4 = new ArrayList();
            ar4.Add(rec.IntYearId);
            ar4.Add(rec.IntSource);
            dsR4 = Fetch("AP_LedgerYearlyNew_S1", CommandType.StoredProcedure, ar4);
            return dsR4;
        }
        public DataSet GetReclLedgerData(Recl rec)
        {
            DataSet dsR4 = new DataSet();
            ArrayList ar4 = new ArrayList();
            ar4.Add(rec.IntYearId);
            ar4.Add(rec.IntSource);
            dsR4 = Fetch("AP_LedgerYearlyNew_S2", CommandType.StoredProcedure, ar4);
            return dsR4;
        }
        public void SaveRecLevl3New(Recl rec)
        {
            ArrayList arr = new ArrayList();
            arr.Add(rec.IntYearId);
            arr.Add(rec.IntMonthId);
            arr.Add(rec.IntSource);
            try
            {
                Save("AP_RecLevl3New_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveRecLevl3CurrNullVal(Recl rec)
        {
            ArrayList arr = new ArrayList();
            arr.Add(rec.IntYearId);
            arr.Add(rec.IntMonthId);
            arr.Add(1);
            try
            {
                Save("AP_RecLevl3Curr_I1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveRecLevl3Curr(Recl rec)
        {
            ArrayList arr = new ArrayList();
            arr.Add(rec.IntYearId);
            arr.Add(rec.IntMonthId);

            try
            {
                Save("AP_RecLevl3Curr_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveRecLevl3CurrT(Recl rec)
        {
            ArrayList arr = new ArrayList();
            arr.Add(rec.IntYearId);
            arr.Add(rec.IntMonthId);

            try
            {
                Save("AP_RecLevl3Curr_U_PT", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdRecLevl3NewP(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_PostedTreas", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdRecLevl3NewUP1(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_UnPostedTreas", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdRecLevl3NewUP2(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_UnPosted2Treas", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }



        public void UpdRecLevl3NewPAg(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_PostedAG", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdRecLevl3NewUP1Ag(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_UnPostedAG", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdRecLevl3NewUP2Ag(Recl rec)
        {
            ArrayList arr1 = new ArrayList();
            arr1.Add(rec.IntYearId);
            try
            {
                Save("AP_RecLevl3New_UnPosted2AG", CommandType.StoredProcedure, arr1);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        //------------------
        public DataSet GetAGData()
        {
            DataSet dsR4 = new DataSet();
            dsR4 = Fetch("RecIndividualMain_AG", CommandType.StoredProcedure);
            return dsR4;
        }
        public DataSet GetAGDataSplit(ArrayList ar)
        {
            DataSet dsR4 = new DataSet();
            dsR4 = Fetch("AP_TreasuryDetailsD_S7", CommandType.StoredProcedure, ar);
            return dsR4;
        }
        public DataSet GetPfoData(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntTrnType);
            dsR = Fetch("AP_RecLevl3_S1", CommandType.StoredProcedure,ar);
            return dsR;
        }
        public DataSet GetPfoDataMonthWise(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("AP_RecLevl3_S2", CommandType.StoredProcedure,ar);
            return dsR;
        }

        public DataSet GetTreasuryDataMonthWise(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("AP_RecLevl3_S3", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseNew(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            dsR = Fetch("RecCurr_S5", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseNewDt(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            dsR = Fetch("RecCurr_S5Dt", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseNewNew(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("RecCurr_S5New", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseUnP(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("AP_RecLevl3_S4", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseUnPNew(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            dsR = Fetch("RecCurr_S6", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetTreasuryDataMonthWiseUnPNewNew(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntMonthId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("RecCurr_S6New", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetUnPTrace1(Recl rect1)
        {
            DataSet dst1 = new DataSet();
            ArrayList art1 = new ArrayList();
            art1.Add(rect1.IntYearId);
            art1.Add(rect1.IntMonthId);
            art1.Add(rect1.IntDTId);
            dst1 = Fetch("AP_TreasuryDetailsLB_S5", CommandType.StoredProcedure, art1);
            return dst1;
        }
        public DataSet GetUnPTrace1New(Recl rect1)
        {
            DataSet dst1 = new DataSet();
            ArrayList art1 = new ArrayList();
            art1.Add(rect1.IntYearId);
            art1.Add(rect1.IntMonthId);
            art1.Add(rect1.IntDTId);
            art1.Add(rect1.IntTrnType);
            dst1 = Fetch("Chalan_S46", CommandType.StoredProcedure, art1);
            return dst1;
        }
        public DataSet GetUnPTrace1NewDt(Recl rect1)
        {
            DataSet dst1 = new DataSet();
            ArrayList art1 = new ArrayList();
            art1.Add(rect1.IntYearId);
            art1.Add(rect1.IntMonthId);
            art1.Add(rect1.IntDTId);
            art1.Add(rect1.IntTrnType);
            dst1 = Fetch("Bill_S42", CommandType.StoredProcedure, art1);
            return dst1;
        }
        public DataSet GetUnPTrace2(Recl rect1)
        {
            DataSet dst1 = new DataSet();
            ArrayList art1 = new ArrayList();
            art1.Add(rect1.IntYearId);
            art1.Add(rect1.IntMonthId);
            art1.Add(rect1.IntDTId);
            dst1 = Fetch("AP_TreasuryDetailsLB_S4", CommandType.StoredProcedure, art1);
            return dst1;
        }
        public DataSet GetUnPTrace3(Recl rect1)
        {
            DataSet dst1 = new DataSet();
            ArrayList art1 = new ArrayList();
            art1.Add(rect1.IntYearId);
            art1.Add(rect1.IntMonthId);
            art1.Add(rect1.IntDTId);
            dst1 = Fetch("AP_TreasuryDetailsLB_S6", CommandType.StoredProcedure, art1);
            return dst1;
        }


        public DataSet GetLedgerFromAG( ArrayList ar)
        {
            DataSet dsR4 = new DataSet();
            dsR4 = Fetch("AP_LedgerYearly_S3", CommandType.StoredProcedure,ar);
            return dsR4;
        }
        public DataSet GetLedgerFromAGTxts(Recl rec)
        {
            ArrayList arat = new ArrayList();
            arat.Add(rec.IntYearId);
            arat.Add(rec.IntSource);
            DataSet dsagt = new DataSet();
            dsagt = Fetch("AP_LedgerYearly_S1", CommandType.StoredProcedure, arat);
            return dsagt;
        }
        public void SaveLedgerYearly(Recl rec)
        {
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntSource);
            ar.Add(rec.FltOB);
            ar.Add(rec.FltCr);
            ar.Add(rec.FltDt);
            ar.Add(rec.FltInt);
            ar.Add(rec.FltCB);
            try
            {
                Save("AP_LedgerYearly_I", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveLedgerYearlyPFO()
        {
            ArrayList ar = new ArrayList();
            try
            {
                Save("AP_LedgerYearly_I2", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        ////////// Save to RecLvl3 ////////////
        public void SaveAP_RecLevl31(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevl3_I1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl32(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTP_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl33(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTUnP_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl34(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTUnP_U2", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl35(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTUnP_U3", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl36(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGP_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl37(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGUnP_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl38(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGUnP_U2", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }



        public void SaveAP_RecLevl3Dt1(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevl3Dt_I1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl3Dt2(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTPDt_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl3Dt3(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTUnPDt_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl3Dt4(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlTUnPDt_U2", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public void SaveAP_RecLevl3Dt5(ArrayList ar)
        //{
        //    try
        //    {
        //        Save("AP_RecLevlTUnP_U3", CommandType.StoredProcedure, ar);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public void SaveAP_RecLevl3Dt6(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGPDt_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl3Dt7(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGUnPDt_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveAP_RecLevl3Dt8(ArrayList ar)
        {
            try
            {
                Save("AP_RecLevlAGUnPDt_U2", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        ////////// Save to RecLvl3 ////////////
        public DataSet GetAGDataSplitCurr(ArrayList ar)
        {
            DataSet dsR4 = new DataSet();
            dsR4 = Fetch("RecCurr_S2", CommandType.StoredProcedure, ar);
            return dsR4;
        }
        public DataSet GetPfoDataCurr(ArrayList ar)
        {
            DataSet dsR = new DataSet();
            dsR = Fetch("RecCurr_S3", CommandType.StoredProcedure,ar);
            return dsR;
        }
        public DataSet GetAGDataCurr()
        {
            DataSet dsR4 = new DataSet();
            dsR4 = Fetch("RecCurr_S1", CommandType.StoredProcedure);
            return dsR4;
        }
        public DataSet GetPfoDataMonthWiseCurr(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            dsR = Fetch("RecCurr_S4", CommandType.StoredProcedure, ar);
            return dsR;
        }
        public DataSet GetPfoDataMonthWiseCurrNew(Recl rec)
        {
            DataSet dsR = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rec.IntYearId);
            ar.Add(rec.IntTrnType);
            dsR = Fetch("RecCurr_S4New", CommandType.StoredProcedure, ar);
            return dsR;
        }

        public void RefreshCr(ArrayList ar)
        {
            try
            {
                Save("RecCurr_I", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void delRecCurrTrn(ArrayList ar)
        {
            try
            {
                Save("RecCurr_D", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdCredit(ArrayList ar)
        {
            try
            {
                Save("RecCurr_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        
    }
}
