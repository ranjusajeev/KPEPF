using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class KPEPFGeneralDAO : KPEPFDAOBase
    {
        #region Methods
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
            dsYr = Fetch("G_Year_S6", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearOnLine()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S16", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearOnLineBlockPrev()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S160", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearOnLineNew()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S18", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearOnLineNdPDE()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S17", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetYearPDEOnly()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S15", CommandType.StoredProcedure);
            return dsYr;
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
        

        public DataSet GetMonth()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Month_S1", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetTreasury(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Treasury_S1", CommandType.StoredProcedure,ar);
            return ds;
        }
        public DataSet GetTransactionType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_TransactionType_S2", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetDistWiseTreasury(ArrayList ArrIN)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Treasury_S2", CommandType.StoredProcedure, ArrIN);
            return ds;
        }
        public DataSet GetInstitutionType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InstitutionType_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetInstitutionType1()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InstitutionType_S3", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetInstitutionType_User()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InstitutionType_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetAllInstitution(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_LocalBody_MST_S2", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetDistrict()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_District_S", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet getBlock(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_LocalBody_MST_S15", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetInstitution_DDE(ArrayList ArrIn)
        {
            DataSet dsSch = new DataSet();
            dsSch = Fetch("L_Institution_S2", CommandType.StoredProcedure, ArrIn);
            return dsSch;
        }
        //public DataSet GetInstitution_HO(ArrayList ArrIn)
        //{
        //    DataSet dsSch = new DataSet();
        //    dsSch = Fetch("L_Institution_S3", CommandType.StoredProcedure, ArrIn);
        //    return dsSch;
        //}
        public DataSet GetInstitution(ArrayList ArrIn)
        {
            DataSet dsSch = new DataSet();
            dsSch = Fetch("L_Institution_S1", CommandType.StoredProcedure, ArrIn);
            return dsSch;
        }
        public DataSet GetTType()
        {
            DataSet dst = new DataSet();
            dst = Fetch("G_TreasuryType_Si", CommandType.StoredProcedure);
            return dst;
        }
        public DataSet GetTreasuryM(ArrayList ar)
        {
            DataSet dsTr = new DataSet();
            dsTr = Fetch("G_Treasury_S4", CommandType.StoredProcedure, ar);
            return dsTr;
        }
        public DataSet GetSchool(ArrayList ArrIn)
        {
            DataSet dsSch = new DataSet();
            dsSch = Fetch("L_Institution_S3", CommandType.StoredProcedure, ArrIn);
            return dsSch;
        }
        public DataSet GetInbox(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetInbox_Search(ArrayList ArrIn, string Qry)
        {
            DataSet ds = new DataSet();
            ds = Fetch(Qry, CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet InboxCnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet InboxCnt_Membership(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetSchool_Schedule(ArrayList ArrIn)
        {
            DataSet dsSch = new DataSet();
            dsSch = Fetch("L_Institution_S5", CommandType.StoredProcedure, ArrIn);
            return dsSch;
        }

        //public DataSet GetSchoolHoId(ArrayList ArrIn)
        //{
        //    DataSet dsSch = new DataSet();
        //    dsSch = Fetch("L_Institution_S4", CommandType.StoredProcedure, ArrIn);
        //    return dsSch;
        //}
        public DataSet GetGO()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_GovOrder_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetGOAll()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_GovOrder_S2", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetGOTxts(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_GovOrder_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet CreateGO(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("G_GovOrder_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet DeleteGO(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("G_GovOrder_D", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet CheckMonth(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Month_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public int getMonthIdCalYear(int mnth)
        {
            ArrayList arm = new ArrayList();
            arm.Add(mnth);
            DataSet ds = new DataSet();
            Int16 mth = 0;
            ds = Fetch("G_Month_S2", CommandType.StoredProcedure, arm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mth = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);
            }
            return mth;
        }
        public DataSet GetLoanPurpose(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_LoanPurpose_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

        public DataSet GetLocalSettings(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_LocalSettings_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetEmployeeDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetStatusID()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Settings_S", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetStatusMapping(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_StatusMapping_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetStatusMappingAdvanceProcess(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_StatusMapping_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetBillType(ArrayList arr)
        {
            DataSet dsBillType = new DataSet();
            dsBillType = Fetch("M_BillType_S", CommandType.StoredProcedure, arr);
            return dsBillType;
        }

        public DataSet GetBillTypeEntry(ArrayList arr)
        {
            DataSet dsBillType = new DataSet();
            dsBillType = Fetch("M_BillType_S1", CommandType.StoredProcedure, arr);
            return dsBillType;
        }

        //public DataSet GetInBox(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("MembershipRequest_S2", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public DataSet GetStageID(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_StageLimit_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetProcess(ArrayList ArrIn)
        {
            DataSet dsPro = new DataSet();
            dsPro = Fetch("L_ProcessCategory_S1", CommandType.StoredProcedure, ArrIn);
            return dsPro;
        }
        public DataSet CreateServiceTransaction(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("ServiceTransaction_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet CheckDuplicateInwardNo(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetQuitRsn()
        {
            DataSet dsQtRsn = new DataSet();
            dsQtRsn = Fetch("L_ClosureReason_S1", CommandType.StoredProcedure);
            return dsQtRsn;
        }
        public int gFunFindYearIdFromDate(ArrayList ArrIn)
        {
            int intYrId;
            DataSet dsYrId = new DataSet();
            dsYrId = Fetch("G_Year_S3", CommandType.StoredProcedure, ArrIn);
            if (dsYrId.Tables[0].Rows.Count > 0)
            {
                intYrId = Convert.ToInt16(dsYrId.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                intYrId = 0;
            }
            return intYrId;
        }

        public DataSet GetTAConvrsnDetails(ArrayList Arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TA2NRACon_S1", CommandType.StoredProcedure, Arr);
            return ds;
        }
        public string gFunFindYearFromDate(ArrayList ArrIn)
        {
            string strYr;
            DataSet dsYrId = new DataSet();
            dsYrId = Fetch("G_Year_S3", CommandType.StoredProcedure, ArrIn);
            if (dsYrId.Tables[0].Rows.Count > 0)
            {
                strYr = dsYrId.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            else
            {
                strYr = "";
            }
            return strYr;
        }
        public void TA2NRAConRequest(ArrayList ArrIn)
        {
            try
            {
                Save("TA2NRACon_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception Err)
            {
                throw new Exception("Check the Error" + Err.Message);
            }
        }
        public DataSet TA2NRAGetWithdrawalId(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        //public DataSet GetTAConvrsnDetails(ArrayList Arr)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("TA2NRACon_S1", CommandType.StoredProcedure, Arr);
        //    return ds;
        //}
        public DataSet UpdateServiceTransaction(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("ServiceTransaction_U", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet GetfileNmValues(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetLabel(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_Label_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        //public DataSet GetMessage(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("L_MessageBox_S1", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public DataSet GetMessage(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("M_Msg_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ValidateEligibility(ArrayList ArrIn)
        {
            DataSet dsV = new DataSet();
            dsV = Fetch("ServiceTransaction_S6", CommandType.StoredProcedure, ArrIn);
            return dsV;
        }
        public DataSet GetReportType()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_ReportType_S", CommandType.StoredProcedure);
            return dsYr;
        }
        //public DataSet GetInstName(string Code)
        //{
        //    ArrayList ArrIn = new ArrayList();
        //    DataSet ds = new DataSet();
        //    ArrIn.Add(Code);
        //    ds = Fetch("L_Institution_S4", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public DataSet GetInstitutionTypeLvl(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_InstitutionType_S2", CommandType.StoredProcedure, Ar);
            return ds;
        }
        public DataSet GetAEODEO(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_Institution_S7", CommandType.StoredProcedure, Ar);
            return ds;
        }


        ////////////////////////////////////////////

        public DataSet GetLB(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_Institution_S10", CommandType.StoredProcedure, Ar);
            return ds;
        }
        public DataSet GetLBIns(ArrayList ArrIn)
        {

            DataSet dsSch = new DataSet();

            dsSch = Fetch("L_Institution_S3", CommandType.StoredProcedure, ArrIn);

            return dsSch;

        }

        public DataSet BulkProcess(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S3", CommandType.StoredProcedure, Ar);
            return ds;
        }
        public double BulkProcessTotal(ArrayList Ar)
        {
            double tot = 0;
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S4", CommandType.StoredProcedure, Ar);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                tot = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0]);
            }

            return tot;
        }
        public DataSet UtilisedListbyAllot(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S5", CommandType.StoredProcedure, Ar);
            return ds;
        }
        public double UtilisedListbyAllotTotal(ArrayList Ar)
        {
            double tot = 0;
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S6", CommandType.StoredProcedure, Ar);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                tot = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[0]);
            }

            return tot;
        }
        public DataSet GetVoucher(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Voucher_S1", CommandType.StoredProcedure, Ar);
            return ds;
        }
        public Boolean ExistsFile(string FileNo)
        {
            Boolean flg;
            ArrayList Arr = new ArrayList();
            DataSet ds = new DataSet();
            Arr.Add(FileNo);
            ds = Fetch("ServiceTransaction_S7", CommandType.StoredProcedure, Arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }
        public DataSet GetAllotmentDet(int LB)
        {
            ArrayList Arr = new ArrayList();
            DataSet ds = new DataSet();
            Arr.Add(LB);
            ds = Fetch("AllotmentRequest_S4", CommandType.StoredProcedure, Arr);
            return ds;
        }
        public DataSet UpdateChalan_DUADate(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("Chalan_U1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet GetInstitutionDistWise(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_Institution_S11", CommandType.StoredProcedure, Ar);
            return ds;
        }

        public DataSet GetDesignationGp()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Designation_S1", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEmployeeType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeType_S", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEmployeeDetByintPfNo(ArrayList Ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S31", CommandType.StoredProcedure, Ar);
            return ds;
        }
        #endregion
        public DataSet UpdateEmpCurLB(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("L_EmployeeCurrDet_U4", CommandType.StoredProcedure, ArrIn);
                return ds;
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
        public DataSet DelTempEmp()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("TempEmp_D", CommandType.StoredProcedure);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet InsTransferIn(ArrayList arr)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("TransferIn_I",CommandType.StoredProcedure,arr);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public DataSet GetLoadDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeCurrDet_RptLoanDet", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetFileStatus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_RptFlStat", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetFlgClosed(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S10", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public int gFunFindPDEYearIdFromDate(ArrayList ArrIn)
        {
            int intYrId;
            DataSet dsYrId = new DataSet();
            dsYrId = Fetch("G_Year_S12", CommandType.StoredProcedure, ArrIn);
            if (dsYrId.Tables[0].Rows.Count > 0)
            {
                intYrId = Convert.ToInt16(dsYrId.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                intYrId = 0;
            }
            return intYrId;
        }
        public int gFunFindPDEYearIdFromDateOnline(ArrayList ArrIn)
        {
            int intYrId;
            DataSet dsYrId = new DataSet();
            dsYrId = Fetch("G_Year_S12", CommandType.StoredProcedure, ArrIn);
            if (dsYrId.Tables[0].Rows.Count > 0)
            {
                intYrId = Convert.ToInt16(dsYrId.Tables[0].Rows[0].ItemArray[2].ToString());
            }
            else
            {
                intYrId = 0;
            }
            return intYrId;
        }
        public DataSet GetClosureReason()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_ClosureReason_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetEnableStatus(ArrayList ArrIn1)
        {
            DataSet dsE = new DataSet();
            dsE = Fetch("G_StatusMappingOrg_S1", CommandType.StoredProcedure, ArrIn1);
            return dsE;
        }
        public DataSet GetEnableStatusChalan(ArrayList ArrIn1)
        {
            DataSet dsE = new DataSet();
            dsE = Fetch("G_StatusMappingOrg_S2", CommandType.StoredProcedure, ArrIn1);
            return dsE;
        }
        public DataSet GetEnableStatusChalanSelf(ArrayList ArrIn1)
        {
            DataSet dsE = new DataSet();
            dsE = Fetch("G_StatusMappingOrg_S3", CommandType.StoredProcedure, ArrIn1);
            return dsE;
        }
        public DataSet GetEnableStatusMembership(ArrayList ArrIn1)
        {
            DataSet dsE = new DataSet();
            dsE = Fetch("G_StatusMappingOrg_S4", CommandType.StoredProcedure, ArrIn1);
            return dsE;
        }
        public int FindYearIdFromDate(ArrayList ArrIn)
        {
            int intYrId;
            DataSet dsYrId = new DataSet();
            dsYrId = Fetch("G_Year_S3", CommandType.StoredProcedure, ArrIn);
            if (dsYrId.Tables[0].Rows.Count > 0)
            {
                intYrId = Convert.ToInt16(dsYrId.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                intYrId = 0;
            }
            return intYrId;
        }
        public DataSet GetPDEYrId(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S14", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet getReason(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_Reason_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet getFileNo(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceTransaction_S5", CommandType.StoredProcedure,ar);
            return ds;
        }
        public DataSet GetEmployeeDetBasicDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetBasicDet_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        //public DataSet ValidateEligibility(ArrayList ArrIn)
        //{
        //    DataSet dsV = new DataSet();
        //    dsV = Fetch("ServiceTransaction_S6", CommandType.StoredProcedure, ArrIn);
        //    return dsV;
        //}
        public DataSet GetTADetails(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("WithdrawalRequest_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getBank()
        {
            ArrayList ArrIn = new ArrayList();
            DataSet ds = new DataSet();
            ds = Fetch("Bank_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet getBankBranch(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("BankBranch_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void SaveUser(ArrayList ArrIn)
        {
            try
            {
                Save("L_User_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception Err)
            {
                throw new Exception("Check the Error" + Err.Message);
            }
        }
        
        public DataSet getsubTreasury(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Treasury_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetEntryDetail(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TreasuryD_S2", CommandType.StoredProcedure, arr);
            return ds;
        }
        public void SaveServiceHistory(ArrayList ArrIn)
        {
             try
            {
                Save("ServiceHisEditLB_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception Err)
            {
                throw new Exception("Check the Error" + Err.Message);
            }
        }
        public DataSet GetServiceHistory(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceHisEditLB_S1   ", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetServiceDetails(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ServiceHisEditLB_S2", CommandType.StoredProcedure, arr);
            return ds;
        }
        public void Deleterow(ArrayList arr)
        {
            try
            {
                Fetch("ServiceHisEditLB_D", CommandType.StoredProcedure, arr);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
        }
        public DataSet GetCCardParticulars(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_YearDetail_S2",CommandType.StoredProcedure,arr);
            return ds;
        }
        
        public DataSet GetCCardAmount(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_LedgerDet_TRN_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        
        public DataSet GetCCParticulars(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S4", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetPreWithdrawal(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Withdrawals_S6", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetDate(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S9", CommandType.StoredProcedure, arr);
            return ds;
        }
        public String GetDateAsString(int yr, int mth)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            string dt = "";
            ar.Add(yr);
            ar.Add(mth);
            ds = Fetch("G_Year_S9", CommandType.StoredProcedure, ar);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return dt;
        }
        public DataSet Getaa(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("aa", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet getFromWhom(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_L_DrawnBy_Cmb", CommandType.StoredProcedure, arr);
            return ds;
        }
    }
}
