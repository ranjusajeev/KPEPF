using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class passbookDAO : KPEPFDAOBase 
    {
        public void SavePassbook(Passbook pass)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(pass.NumEmpId);
            ArrIn.Add(pass.IntYearId);
            ArrIn.Add(pass.IntMonthId );
            ArrIn.Add(pass.DtmEncashmnt);
            ArrIn.Add(pass.IntTreasuryId );
            ArrIn.Add(pass.IntChalanNo );
            ArrIn.Add(pass.DtmChalanDate );
            ArrIn.Add(pass.FltSubn );
            ArrIn.Add(pass.FltRepay );
            ArrIn.Add(pass.FltArrDA );
            ArrIn.Add(pass.ChvGO );
            ArrIn.Add(pass.DtmGODate );
            ArrIn.Add(pass.FltWithdrawal );
            //ArrIn.Add(pass.IntLoanType );
            ArrIn.Add(pass.DtmWithdate);
            ArrIn.Add(pass.InstNo);
            ArrIn.Add(pass.InstAmt);
            ArrIn.Add(pass.IntLoanType);
            ArrIn.Add(pass.ChvRem );
            ArrIn.Add(pass.IntUserId );
            ArrIn.Add(pass.FlgFlag);
            try
            {
                Save("PassBook_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public void PassbookUpd(Passbook pss)
        {
            ArrayList vAryyIn = new ArrayList();
            vAryyIn.Add(pss.NumEmpId);
            vAryyIn.Add(pss.IntYearId);
            try
            {
                Save("PassBook_U", CommandType.StoredProcedure, vAryyIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetYear()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S11", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetMonth()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Month_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetUserDistrict(ArrayList arr)
        {
            DataSet ds = new DataSet();
       
            ds = Fetch("L_UserDistS1", CommandType.StoredProcedure,arr );
            return ds;
        }
        public DataSet GetInboxSec(ArrayList arr)
        {
            DataSet ds = new DataSet();

            ds = Fetch("Passbook_Inbx_S", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTreasury(ArrayList arr)
        {
            DataSet ds = new DataSet();

            ds = Fetch("G_Treasury_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet FillPassbook(ArrayList arr)
        {
            DataSet ds = new DataSet();

            ds = Fetch("PassBook_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetWithType()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_TransactionType_S3", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetEmployeeDetails(Passbook pss)
        {
            ArrayList vArryIn = new ArrayList();

            DataSet dsEmp = new DataSet();
            vArryIn.Add(pss.NumEmpId);
                dsEmp = Fetch("L_EmployeeDet_S3", CommandType.StoredProcedure, vArryIn);
            
            return dsEmp;
        }
        public DataSet GetMaxMonthInChalanDetails(Passbook pss)
        {
            ArrayList vArryIn = new ArrayList();

            DataSet dsEmp = new DataSet();
            vArryIn.Add(pss.NumEmpId);
            vArryIn.Add(pss.IntYearId);
            dsEmp = Fetch("TB_ChalanDetails_TRN_MaxMonth_S", CommandType.StoredProcedure, vArryIn);

            return dsEmp;
        }
        public DataSet GetMonthid(ArrayList arr)
        {
             DataSet dsEmp = new DataSet();
             dsEmp = Fetch("G_Month_S2", CommandType.StoredProcedure, arr);

            return dsEmp;
        }
        public DataSet GetBalanceMonth(ArrayList arr)
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("G_Month_S4", CommandType.StoredProcedure, arr);

            return dsEmp;
        }
        public DataSet GetYearDetail(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S5", CommandType.StoredProcedure, arr);
            return ds;
        }
    }
}
