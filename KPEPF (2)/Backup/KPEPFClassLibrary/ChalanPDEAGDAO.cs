using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class ChalanPDEAGDAO : KPEPFDAOBase 
    {
        public DataSet CreateChalanAG(ChalanPDEAG  chalanAG)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalanAG.IntChalanAGID);
            ArrIn.Add(chalanAG.IntTERelMonthWiseID);
            ArrIn.Add(chalanAG.IntTreasID);
            ArrIn.Add(chalanAG.IntLBID);
            ArrIn.Add(chalanAG.IntChalanNo);
            ArrIn.Add(chalanAG.DtmChalanDt);
            ArrIn.Add(chalanAG.FltChalanAmt);
            ArrIn.Add(chalanAG.IntYearID);
            ArrIn.Add(chalanAG.IntModeOfChgID);
            ArrIn.Add(chalanAG.IntUserId);
            ArrIn.Add(chalanAG.ChvTENo);
            ArrIn.Add(chalanAG.FlgUnPosted);
            ArrIn.Add(chalanAG.IntReasonID);
            ArrIn.Add(chalanAG.IntMissingID);
            ArrIn.Add(chalanAG.IntChalanType);
            try
            {
                ds = Fetch("AP_ChalanAG_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
       public DataSet SaveChalandetailsAG(ChalanPDEAG  chalanAG)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalanAG.ChalanId);
            ArrIn.Add(chalanAG.IntTreasID);
            ArrIn.Add(chalanAG.IntChalanNo);
            ArrIn.Add(chalanAG.DtmChalanDt);
            ArrIn.Add(chalanAG.FltChalanAmt);
            ArrIn.Add(chalanAG.IntYearID);
            ArrIn.Add(chalanAG.IntModeOfChgID);
            ArrIn.Add(chalanAG.IntUserId);
            ArrIn.Add(chalanAG.IntChalanAGID);
            ArrIn.Add(chalanAG.IntLBID);
         
            try
            {
                ds = Fetch("TB_ChalanDetails_TRN_I1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetScheduleTotal(ArrayList ArrInS)
        {
            DataSet dsS = new DataSet();
            try
            {
                dsS = Fetch("Tb_ScheduleTR104_S5", CommandType.StoredProcedure, ArrInS);
                return dsS;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet RemitancechlntextfillPDE2001(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_S13", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet RemitancechlntextfillPDE01(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_S11", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet SaveChalandetailsPDE01(ChalanPDEAG chalanAG)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalanAG.ChalanId);
            ArrIn.Add(chalanAG.IntTreasID);
            ArrIn.Add(chalanAG.IntChalanNo);
            ArrIn.Add(chalanAG.DtmChalanDt);
            ArrIn.Add(chalanAG.FltChalanAmt);
            ArrIn.Add(chalanAG.IntYearID);
            ArrIn.Add(chalanAG.IntModeOfChgID);
            ArrIn.Add(chalanAG.IntUserId);
            ArrIn.Add(chalanAG.IntChalanAGID);
            ArrIn.Add(chalanAG.IntLBID);
            ArrIn.Add(chalanAG.IntGroupId);

            try
            {
                ds = Fetch("TB_ChalanDetails_TRN_I4", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public DataSet RemitancechlntextfillPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_S12", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet DeleteChalan01(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet DeleteChalanPDE01(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_D1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet DeleteChalanPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TreasuryDetailsLB_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet SaveChalandetails(ChalanPDEAG chalanAG)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalanAG.ChalanId);
            ArrIn.Add(chalanAG.IntTreasID);
            ArrIn.Add(chalanAG.IntChalanNo);
            ArrIn.Add(chalanAG.DtmChalanDt);
            ArrIn.Add(chalanAG.FltChalanAmt);
            ArrIn.Add(chalanAG.IntYearID);
            ArrIn.Add(chalanAG.IntModeOfChgID);
            ArrIn.Add(chalanAG.IntUserId);
            ArrIn.Add(chalanAG.IntChalanAGID);
            ArrIn.Add(chalanAG.IntLBID);
            ArrIn.Add(chalanAG.IntGroupId);

            try
            {
                ds = Fetch("TB_ChalanDetails_TRN_I3", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FillCrPlusDaer(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_ChalanAG_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillCrPlusDaerAddCol(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_ChalanAG_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void DeleteChalanAG(ArrayList ArrInS)
        {
            DataSet dsS = new DataSet();
            try
            {
                dsS = Fetch("AP_ChalanAG_D", CommandType.StoredProcedure, ArrInS);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
