using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class ChalanDAO : KPEPFDAOBase 
    {
        public DataSet CreateChalan(Chalan chalan)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);
            ArrIn.Add(chalan.IntTreasuryId);
            ArrIn.Add(chalan.IntLBId);
            ArrIn.Add(chalan.IntChalanNo);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.FltChalanAmt);
            ArrIn.Add(chalan.YearId);
            ArrIn.Add(chalan.MonthId);
            ArrIn.Add(chalan.PerYearId);
            ArrIn.Add(chalan.PerMonthId);
            ArrIn.Add(chalan.ChvRemarks);
            ArrIn.Add(chalan.IntUserId);
          
            ArrIn.Add(chalan.FlgUnposted);
            ArrIn.Add(chalan.IntUnPostedRsn);
            ArrIn.Add(chalan.IntSlNo);
            //ArrIn.Add(chalan.ChvBankName);
            //ArrIn.Add(chalan.DtmDDTreasury);
            //ArrIn.Add(chalan.IntUnPostedRsn);
            //ArrIn.Add(chalan.IntModeChange);
            ArrIn.Add(chalan.FlgSource);
           
            ArrIn.Add(chalan.IntDay);
            ArrIn.Add(chalan.IntSthapnaBillID);
            ArrIn.Add(chalan.FlgAmtMismatch);
            ArrIn.Add(chalan.FlgChalanType);
            ArrIn.Add(chalan.tENo);
            ArrIn.Add(chalan.IntTreasuryDAGID);
            try
            {
                ds = Fetch("Chalan_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public DataSet  ChalanExists(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ChalanExistsMth(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S24", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet SelectChalanIDWise(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S27", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillCrPlus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ChalanAG_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet APChalanAGDel(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_ChalanAG_D1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillCrPlusPDEBind(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_ChalanAG_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillCrPlusBind(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ChalanAG_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillCrPlusPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_ChalanAG_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

        public DataSet Chalandelete(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ChalanAG_D2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet InboxChalan(ArrayList ArrIn)
        {
            DataSet dsInbx = new DataSet();
            dsInbx = Fetch("Chalan_S2 ", CommandType.StoredProcedure, ArrIn); //TB_ChalanDetails_TRN_S4
            return dsInbx;
        }
        public DataSet InboxChalanDir(ArrayList ArrIn)
        {
            DataSet dsInbx = new DataSet();
            dsInbx = Fetch("Chalan_S33 ", CommandType.StoredProcedure, ArrIn); //TB_ChalanDetails_TRN_S4
            return dsInbx;
        }
        public DataSet InboxChalanAcc(ArrayList ArrIn)
        {
            DataSet dsInbx = new DataSet();
            dsInbx = Fetch("Chalan_S30 ", CommandType.StoredProcedure, ArrIn); //TB_ChalanDetails_TRN_S4
            return dsInbx;
        }
        public DataSet GetChalanFrmChalId(ArrayList ArrIn)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("Chalan_S3", CommandType.StoredProcedure, ArrIn);
            return dsChal;
        }
        public DataSet GetChalanFrmChalIdNew(ArrayList ArrIn)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("Chalan_S20", CommandType.StoredProcedure, ArrIn);
            return dsChal;
        }
        public DataSet UpdateChalan(Chalan chalan)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId  );
            ArrIn.Add(chalan.IntChalanNo);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.FltChalanAmt);
            ArrIn.Add(chalan.IntUserId);
            try
            {
                ds = Fetch("Chalan_U", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetChalanSearch(ArrayList arr,int type)
        {
            DataSet dsChalS = new DataSet();
            if (type == 1)
            {
                dsChalS = Fetch("Chalan_S9", CommandType.StoredProcedure, arr);
            }
            else if (type == 2)
            {
                dsChalS = Fetch("Chalan_S7", CommandType.StoredProcedure, arr);
            }
            else if (type == 3)
            {
                dsChalS = Fetch("Chalan_S8", CommandType.StoredProcedure, arr);
            }
            return dsChalS;
        }
        public DataSet GetChalanSearchOTP(ArrayList arr, int type)
        {
            DataSet dsChalS = new DataSet();
            dsChalS = Fetch("TB_ChalanDetails_TRN_S14", CommandType.StoredProcedure, arr);
            return dsChalS;
        }
        public DataSet ChalanRemittance(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S12", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet ChalanRemittanceOnline(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S21", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet RemitanceDeputation(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S14", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet RemitanceTreasury(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S15", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet Fillreason(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_L_MisclassificationReason_Cmb ", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet Updatchalan(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_U ", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        //public DataSet UpdateChalan(Chalan chalan)
        //{
        //    DataSet ds = new DataSet();
        //    ArrayList ArrIn = new ArrayList();
        //    ArrIn.Add(chalan.NumChalanId);
        //    ArrIn.Add(chalan.IntChalanNo);
        //    ArrIn.Add(chalan.DtChalanDate);
        //    ArrIn.Add(chalan.FltChalanAmt);
        //    ArrIn.Add(chalan.IntUserId);
        //    try
        //    {
        //        ds = Fetch("Chalan_U", CommandType.StoredProcedure, ArrIn);
        //        return ds;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public DataSet ChalanOtherRemittance(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S17", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet SaveChalanToTreasuryD(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TreasuryD_I", CommandType.StoredProcedure, arr);
            return ds;
                        
        }
        //public void UpdateTreasuryD(ArrayList arr)
        //{
        //    try
        //    {
        //        Save("TreasuryD_U2", CommandType.StoredProcedure, arr);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error" + E.Message);
        //    }
        //}
        public void UpdateTreasuryDMiss(ArrayList arr)
        {
            try
            {
                Save("TreasuryD_U3", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet OtherChalan(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ChalanOther_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet GetAmtLBTot(ArrayList ArIn)
        {
            DataSet dsn = new DataSet();
            dsn = Fetch("TreasuryD_S7", CommandType.StoredProcedure, ArIn);//Chalan_S1
            return dsn;
        }
        public void UpdateChalTreasId(ArrayList arr)
        {
            try
            {
                Save("Chalan_U2", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SaveOtherChalan(ArrayList arr)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("ChalanOther_I", CommandType.StoredProcedure, arr);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet RemitanceNonLB(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S19", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet Remitancechlntextfill(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S32", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet CreateExtraChalan(Chalan chalan)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);
            ArrIn.Add(chalan.IntTreasuryId);
            ArrIn.Add(chalan.IntLBId);
            ArrIn.Add(chalan.IntChalanNo);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.FltChalanAmt);
            ArrIn.Add(chalan.YearId);
            ArrIn.Add(chalan.MonthId);
            ArrIn.Add(chalan.PerYearId);
            ArrIn.Add(chalan.PerMonthId);
            ArrIn.Add(chalan.ChvRemarks);
            ArrIn.Add(chalan.IntUserId);
            ArrIn.Add(chalan.FlgUnposted);
            ArrIn.Add(chalan.IntUnPostedRsn);
            ArrIn.Add(chalan.IntSlNo);
            //ArrIn.Add(chalan.ChvBankName);
            //ArrIn.Add(chalan.DtmDDTreasury);
            //ArrIn.Add(chalan.IntModeChange);
            ArrIn.Add(chalan.FlgSource);

            ArrIn.Add(chalan.IntDay);
            ArrIn.Add(chalan.IntSthapnaBillID);
            ArrIn.Add(chalan.FlgAmtMismatch);
            ArrIn.Add(chalan.FlgChalanType);
            ArrIn.Add(chalan.IntTreasuryDAGID);
            ArrIn.Add(chalan.tENo);
            try
            {
                ds = Fetch("Chalan_I1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreateChalanPDE(Chalan chalan)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);

            ArrIn.Add(chalan.IntLBId);
            ArrIn.Add(chalan.IntChalanNo);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.FltChalanAmt);
            ArrIn.Add(chalan.YearId);
            ArrIn.Add(chalan.IntModeChange);
            ArrIn.Add(chalan.IntUserId);

            try
            {
                ds = Fetch("TB_ChalanDetails_TRN_I2", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet ChalannonLBValid(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S18", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void UpdateChalanMode(ArrayList arr)
        {
            try
            {
                Save("Chalan_D", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet ChalanRemittancePDE01(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetails_TRN_S6", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
       
        public DataSet FetchGrpId(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ChalanDetailsTrn_SGrp", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void UpdateChalanAmt(Chalan chalan)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.FltChalanAmt);

            try
            {
                Save("Chalan_U3", CommandType.StoredProcedure, ArrIn);

            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetSTreasuryDet(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("Chalan_S23", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public DataSet GetChalanAll(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("ChalanOther_S2", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public DataSet GetChalanPart(ArrayList ar)
        {
            DataSet dsChal = new DataSet();
            dsChal = Fetch("ChalanOther_S3", CommandType.StoredProcedure, ar);
            return dsChal;
        }
        public void DeleteChalanExtra(ArrayList arr)
        {
            try
            {
                Save("Chalan_D1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetAGRpt(ArrayList arA,int yr)
        {
            DataSet dsAGR = new DataSet();
            if (yr == 1)
            {
                dsAGR = Fetch("AP_TreasuryDetailsLB_S14", CommandType.StoredProcedure, arA);
            }
            else
            {
                dsAGR = Fetch("TB_ToAG_S1", CommandType.StoredProcedure, arA);
            }
            return dsAGR;
        }

        public void SaveTb_ToAg(ArrayList arr)
        {
            try
            {
                Save("TB_ToAG_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet SelfChalanExistsMth(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S25", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet ChalanStatus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S28", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet ChalanStatusNotEntered(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S29", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }

        public DataSet FindSlnofrmScheduleTR104(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Chalan_S31", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet RecPrint1(ArrayList ar,int flgYear)
        {
            DataSet ds = new DataSet();
            if (flgYear == 2)
            {
                ds = Fetch("Chalan_S34", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            else
            {
                ds = Fetch("Chalan_S38", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            return ds;
        }
        public DataSet RecPrint2(ArrayList ar,int flgYear)
        {
            DataSet ds = new DataSet();
            if (flgYear == 2)
            {
                ds = Fetch("Chalan_S35", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            else
            {
                ds = Fetch("Chalan_S39", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            return ds;
        }
        public DataSet RecPrint3(ArrayList ar, int flgYear)
        {
            DataSet ds = new DataSet();
            if (flgYear == 2)
            {
                ds = Fetch("Chalan_S37", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            else
            {
                ds = Fetch("Chalan_S40", CommandType.StoredProcedure, ar);//Chalan_S1
            }
            return ds;
        }
    }
}
