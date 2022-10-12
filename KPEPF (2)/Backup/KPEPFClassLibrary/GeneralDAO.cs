using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class GeneralDAO :KPEPFDAOBase 
    {
        public DataSet CheckLogin(string UserName, string Pwd)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserName);
            arrIn.Add(Pwd);
            ds = Fetch("L_User_S1", CommandType.StoredProcedure, arrIn);
            return ds;
        }

        public DataSet GetYear()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S1", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearPDE()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S4", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearPDENew()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S4", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearRem()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S8", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetMonth()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Month_S1", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetMonthSup()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Month_S6", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetDisTreasury(ArrayList ar)
        {
            DataSet dsT = new DataSet();
            dsT = Fetch("G_TreasuryD_S1", CommandType.StoredProcedure, ar);
            return dsT;
        }
        public DataSet GetDisTreasuryWith(ArrayList ar)
        {
            DataSet dsT = new DataSet();
            dsT = Fetch("G_TreasuryD_S3", CommandType.StoredProcedure, ar);
            return dsT;
        }
        public DataSet GetDisTreasuryWithOutDistId()
        {
            DataSet dsT = new DataSet();
            dsT = Fetch("G_TreasuryD_S4", CommandType.StoredProcedure);
            return dsT;
        }
        public string GetDisTreasuryFromId(ArrayList ar)
        {
            string str = "";
            DataSet dsDT = new DataSet();
            dsDT = Fetch("G_TreasuryD_S2", CommandType.StoredProcedure, ar);
            if (dsDT.Tables[0].Rows.Count > 0)
            {
                str = dsDT.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return str;
        }
        public DataSet GetTreasury(ArrayList ar)
        {
            DataSet dsT = new DataSet();
            dsT = Fetch("G_Treasury_S1", CommandType.StoredProcedure, ar);
            return dsT;
        }
        public DataSet GetLocalSettings(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_LocalSettings_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet CCard(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_RptCreditCard", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet CCardNew(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_RptCreditCard_New", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet CCardLat(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("LedgerMonthly_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet Interest(ArrayList arrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InterestRate_S4", CommandType.StoredProcedure, arrIn);
            return ds;
        } 
        public DataSet GetInterestMthCnt(ArrayList arrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InterestRate_S5", CommandType.StoredProcedure, arrIn);
            return ds;
        }
        public DataSet GetMessage(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("M_Msg_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetDistrict()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_District_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetInstType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_LBType_MST_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetMxIdFromTB_Yeardetail4ABCDRpt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MaxYear", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet Getyr4ABCDRpt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S7", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetEmpLBWise(int LBId)
        {
            DataSet dsEmp = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(LBId);
            dsEmp = Fetch("L_EmployeeCurrDet_S1", CommandType.StoredProcedure, arr);
            return dsEmp;
        }
        public DataSet GetEmpAccWise(int flg, double EmpId, string Nam)
        {
            DataSet dsEmp = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(flg);
            arr.Add(EmpId);
            arr.Add(Nam);
            dsEmp = Fetch("L_EmployeeCurrDet_S2", CommandType.StoredProcedure, arr);
            return dsEmp;
        }
        public DataSet GetEmpAccWiseSetEmp(int flg, double EmpId, string Nam)
        {
            DataSet dsEmp = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(flg);
            arr.Add(EmpId);
            arr.Add(Nam);
            dsEmp = Fetch("L_EmployeeCurrDet_S5", CommandType.StoredProcedure, arr);
            return dsEmp;
        }
        public DataSet GetEmployeeDetBasicDet(ArrayList ArrIn)
        {

            DataSet ds = new DataSet();

            ds = Fetch("L_EmployeeDetBasicDet_S", CommandType.StoredProcedure, ArrIn);

            return ds;

        }

        public DataSet InsTransferIn(ArrayList arr)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("TransferIn_I", CommandType.StoredProcedure, arr);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public void UpdateEmpCurLB(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U2", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public void UpdateEmpCurLBNull(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U3", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet InsTempEmp(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("TempEmp_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet DelTempEmp(int LBId)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(LBId);
            try
            {
                ds = Fetch("TempEmp_D", CommandType.StoredProcedure, ar);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        //-------------------Local body------------------------------
        public DataSet GetLB(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S2", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetLBDistwise(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S6", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetLBFromTreasury(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S8", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetLBGp(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S3", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetLB4Mst(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S4", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public void UpdLocalBody(ArrayList arr)
        {
            Save("L_Institution_U", CommandType.StoredProcedure, arr);
        }
        //-----------------------------------------------------------
        public DataSet CheckDuplicateInwardNo(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetServiceTrnIdFromFileNo(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetServiceTrnIdFromFileNo2(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("SanctionOder_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetBillIdFromBill(ArrayList ArrIn)
        {
            DataSet dsb = new DataSet();
            dsb = Fetch("Bill_S1", CommandType.StoredProcedure, ArrIn);
            return dsb;
        }
        public DataSet GetChalansFrmChalan(ArrayList ArrIn)
        {
            DataSet dsb = new DataSet();
            dsb = Fetch("Chalan_S4", CommandType.StoredProcedure, ArrIn);
            return dsb;
        }
        public DataSet GetServiceDetFromExplicitTbls(int TrnType, ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            if (TrnType == 5)
            {
                ds = Fetch("ServiceTransaction_S3", CommandType.StoredProcedure, ArrIn);
            }
            else
            {
                ds = Fetch("ServiceTransaction_S8", CommandType.StoredProcedure, ArrIn);
            }
            return ds;
        }
        public DataSet GetServiceDetFromExplicitTblsEmpNameWse(int TrnType, string Nam)
        {
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Nam);
            if (TrnType == 5)
            {
                ds = Fetch("ServiceTransaction_S4", CommandType.StoredProcedure, arr);
            }
            else
            {
                ds = Fetch("ServiceTransaction_S9", CommandType.StoredProcedure, arr);
            }
            return ds;
        }
        public DataSet getCurrentLB(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("CCard_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void FillLBHistory()
        {
            ArrayList ar = new ArrayList();
            Save("EmpLBHistory_I", CommandType.StoredProcedure,ar);
        }
        public DataSet getTransaction()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_TransactionType_S1", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet ValidateEligibility(ArrayList ArrIn)
        {
            DataSet dsV = new DataSet();
            dsV = Fetch("ServiceTransaction_S6", CommandType.StoredProcedure, ArrIn);
            return dsV;
        }
        public DataSet FindCount(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("Approval_S1", CommandType.StoredProcedure, ar);
            return dsC;
        }
        public DataSet FindCountMS(ArrayList ar)
        {
            DataSet dsC = new DataSet();
            dsC = Fetch("Approval_S2", CommandType.StoredProcedure, ar);
            return dsC;
        }
        public DataSet MatchLB(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getPendingFiles(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Approval_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getRetrnFiles(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ReturnedFiles_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ClearRetrnFiles(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ReturnedFiles_D", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getAppFilesForRej(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Approval_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public string GetDistrictFromId(ArrayList ArrInDist)
        {
            string str = "";
            DataSet dsDist = new DataSet();
            dsDist = Fetch("G_District_S2", CommandType.StoredProcedure, ArrInDist);
            if (dsDist.Tables[0].Rows.Count > 0)
            {
                str = dsDist.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return str;
        }
        public string GetDistrictPrfxFromId(ArrayList ArrInDistP)
        {
            string str = "";
            DataSet dsDistP = new DataSet();
            dsDistP = Fetch("G_District_S2", CommandType.StoredProcedure, ArrInDistP);
            if (dsDistP.Tables[0].Rows.Count > 0)
            {
                str = dsDistP.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            return str;
        }
        public string GetYearFromId(ArrayList ArrInDist)
        {
            string str = "";
            DataSet dsDist = new DataSet();
            dsDist = Fetch("G_Year_S10", CommandType.StoredProcedure, ArrInDist);
            if (dsDist.Tables[0].Rows.Count > 0)
            {
                str = dsDist.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return str;
        }
        public string GetYearFromIdPde(ArrayList ArrInDist)
        {
            string str = "";
            DataSet dsDist = new DataSet();
            dsDist = Fetch("G_Year_S13", CommandType.StoredProcedure, ArrInDist);
            if (dsDist.Tables[0].Rows.Count > 0)
            {
                str = dsDist.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return str;
        }
        public string GetMonthFromId(ArrayList ArrInDist)
        {
            string str = "";
            DataSet dsDist = new DataSet();
            dsDist = Fetch("G_Month_S3", CommandType.StoredProcedure, ArrInDist);
            if (dsDist.Tables[0].Rows.Count > 0)
            {
                str = dsDist.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return str;
        }
        public int GetCCYearId()
        {
            int intCCYrId;
            DataSet dsCCYrId = new DataSet();
            dsCCYrId = Fetch("CorrectionEntryYear_S1", CommandType.StoredProcedure);
            if (dsCCYrId.Tables[0].Rows.Count > 0)
            {
                intCCYrId = Convert.ToInt16(dsCCYrId.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                intCCYrId = 0;
            }
            return intCCYrId;
        }
        public int GetCCYearIdPDE()
        {
            int intCCYrIdPde;
            DataSet dsCCYrId = new DataSet();
            dsCCYrId = Fetch("CorrectionEntryYear_S1", CommandType.StoredProcedure);
            if (dsCCYrId.Tables[0].Rows.Count > 0)
            {
                intCCYrIdPde = Convert.ToInt16(dsCCYrId.Tables[0].Rows[0].ItemArray[1].ToString());
            }
            else
            {
                intCCYrIdPde = 0;
            }
            return intCCYrIdPde;
        }
        public int NoOfTimesIntRtChgd(int yr)
        {
            int intCnt = 0;
            DataSet dsCnt = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(yr);
            dsCnt = Fetch("L_InterestRate_S1", CommandType.StoredProcedure, ar);
            if (dsCnt.Tables[0].Rows.Count > 0)
            {
                intCnt = Convert.ToInt16(dsCnt.Tables[0].Rows[0].ItemArray[0]);
            }
            return intCnt;
        }
        public int GetMonthIdFromID(int MthId)
        {
            int Mid = 0;
            if (MthId == 4)
                Mid = 1;
            else if (MthId == 5)
                Mid = 2;
            else if (MthId == 6)
                Mid = 3;
            else if (MthId == 7)
                Mid = 4;
            else if (MthId == 8)
                Mid = 5;
            else if (MthId == 9)
                Mid = 6;
            else if (MthId == 10)
                Mid = 7;
            else if (MthId == 11)
                Mid = 8;
            else if (MthId == 12)
                Mid = 9;
            else if (MthId == 1)
                Mid = 10;
            else if (MthId == 2)
                Mid = 11;
            else if (MthId == 3)
                Mid = 12;
            return Mid;
        }
        public int FindNoOfMonths(int yr, int SlNo)
        {
            int intCntM = 0;
            DataSet dsCntM = new DataSet();
            ArrayList arM = new ArrayList();
            arM.Add(yr);
            arM.Add(SlNo);
            dsCntM = Fetch("L_InterestRate_S3", CommandType.StoredProcedure, arM);
            if (dsCntM.Tables[0].Rows.Count > 0)
            {
                intCntM = Convert.ToInt16(dsCntM.Tables[0].Rows[0].ItemArray[0]);
            }
            return intCntM;
        }
        public DataSet GetMisClassRsn(ArrayList ArrInRsn)
        {
            DataSet dsRsn = new DataSet();
            dsRsn = Fetch("L_Reason_S1", CommandType.StoredProcedure, ArrInRsn);
            return dsRsn;
        }
        public int GetBalanceMonth(int mid,int dy)
        {
            int balMth = 0;
            ArrayList ar = new ArrayList();
            ar.Add(mid);
            DataSet dsM = new DataSet();
            dsM = Fetch("G_Month_S5", CommandType.StoredProcedure, ar);
            if (dsM.Tables[0].Rows.Count > 0)
            {
                balMth = Convert.ToInt16(dsM.Tables[0].Rows[0].ItemArray[0]);
            }
            if (dy > 4)
            {
                balMth = balMth - 1;
            }
            return balMth;
        }
        public int GetBalanceMonthWith(int mid)
        {
            int balMth = 0;
            ArrayList ar = new ArrayList();
            ar.Add(mid);
            DataSet dsM = new DataSet();
            dsM = Fetch("G_Month_S5", CommandType.StoredProcedure, ar);
            if (dsM.Tables[0].Rows.Count > 0)
            {
                balMth = Convert.ToInt16(dsM.Tables[0].Rows[0].ItemArray[0]);
            }
            return balMth;
        }


        public DataSet GetMasterMenu(ArrayList ArrInRolID)
        {
            DataSet dsRsn = new DataSet();
            dsRsn = Fetch("Sp_SelectMasterMenu", CommandType.StoredProcedure, ArrInRolID);
            return dsRsn;
        }
        public DataSet GetSubMenu(ArrayList ArrInRolID)
        {
            DataSet dsRsn = new DataSet();
            dsRsn = Fetch("Sp_SelectSubMenu", CommandType.StoredProcedure, ArrInRolID);
            return dsRsn;
        }
        public DataSet GetMasterMenuSessionVals(ArrayList arr)
        {
            DataSet dsSess = new DataSet();
            dsSess = Fetch("TB_MstMenu_S1", CommandType.StoredProcedure, arr);
            return dsSess;
        }
        public DataSet GetLBFromId(Int16 lbID)
        {
            ArrayList ar = new ArrayList();
            ar.Add(lbID);
            DataSet dsLb = new DataSet();
            dsLb = Fetch("TB_LocalBody_MST_S", CommandType.StoredProcedure, ar);
            //if (dsLb.Tables[0].Rows.Count > 0)
            //{
            //    strLb = dsLb.Tables[0].Rows[0].ItemArray[2].ToString();
            //}
            return dsLb;
        }
        public DataSet GetDistIdfromTreasId(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("G_TreasuryDist_S1", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetLBIdFromSulekha(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S7", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetDDP_LBId(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("TB_LocalBody_MST_S10", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetReplicates(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("Replicates_S1", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetReplicatesCol(ArrayList arr)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("Replicates_S2", CommandType.StoredProcedure, arr);
            return dsLB;
        }
        public DataSet GetCorrTest()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestAdd", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestWth()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestAddWith1", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestWth08()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestAddWith2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestU()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpd", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestUWth()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpdWth1", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestUWth08()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpdWth2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestDWth()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestWthD", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestDWth08()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestWthD2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestD()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestD", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestSched(ArrayList ar)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestSched", CommandType.StoredProcedure, ar);
            return dsLB;
        }

        public DataSet GetCorrTestU2()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpd2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestD2()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestD2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestSched2(ArrayList ar)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestSched2", CommandType.StoredProcedure, ar);
            return dsLB;
        }
        public DataSet GetCorrTest2()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestAdd2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestUpd2()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpd2", CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet GetCorrTestUpd3()
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTestUpd3", CommandType.StoredProcedure);
            return dsLB;
        }


        public DataSet FillPfo(string spname)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch(spname, CommandType.StoredProcedure);
            return dsLB;
        }
        public DataSet FillPfo2(ArrayList ar)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTest_AgPfo2", CommandType.StoredProcedure,ar);
            return dsLB;
        }
        public DataSet FillSite2(ArrayList ar)
        {
            DataSet dsLB = new DataSet();
            dsLB = Fetch("CorrEntryTest_AgSite2", CommandType.StoredProcedure, ar);
            return dsLB;
        }
        public DataSet GetSched(ArrayList arr)
        {
            DataSet dsSess = new DataSet();
            dsSess = Fetch("TB_ChalanDetails_TRN_S15", CommandType.StoredProcedure, arr);
            return dsSess;
        }
    }
}
