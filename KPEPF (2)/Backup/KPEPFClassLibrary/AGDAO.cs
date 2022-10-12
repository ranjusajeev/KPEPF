using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;


namespace KPEPFClassLibrary
{
    public  class AGDAO : KPEPFDAOBase
    {
        public DataSet GetTEMonthwiseId(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TEMonthWise_S2", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTreasuryCrAmt(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TreasuryDetailsD_S3", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetYear()
        {
            DataSet dsYr = new DataSet();
            dsYr = Fetch("G_Year_S11", CommandType.StoredProcedure);
            return dsYr;
        }
        public DataSet GetTreasuryDtAmt(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithDrawCons_S7", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetAGDtAmt(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_WithDrawCons_S6", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTreasuryD(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TreasuryD_S4", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTreasuryDPDE(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TreasuryDetailsD_S8", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetAGId(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGEntries_S2", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTE()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_TEType_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet SaveAGEntryPDEDt(ArrayList arrIn)
        {
            try
            {
                DataSet dswith = new DataSet();
                dswith = Fetch("AP_WithDrawCons_I3", CommandType.StoredProcedure, arrIn);
                return dswith;
            }
            catch (Exception ex)
            {
                throw new Exception("Check the Error!" + ex.Message);
            }
        }
        public DataSet SaveTEMonthWise(ArrayList arrIn)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Fetch("AP_TEMonthWise_I", CommandType.StoredProcedure, arrIn);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("Check the Error!" + ex.Message);
            }
        }
        public int SaveAGEntry(ArrayList arrIn)
        {
            try
            {
                Fetch("TreasuryD_U", CommandType.StoredProcedure, arrIn);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Check the Error!" + ex.Message);
            }
        }
        public DataSet SaveAGEntryPDE(ArrayList arrIn)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Fetch("AP_TreasuryDetailsD_U", CommandType.StoredProcedure, arrIn);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Check the Error!" + ex.Message);
            }
        }
        public void SaveAGTEEntry(ArrayList arrIn)
        {
            try
            {
              
                 Fetch("AGEntries_I", CommandType.StoredProcedure, arrIn);
               
            }
            catch (Exception ex)
            {
                throw new Exception("Check the Error!" + ex.Message);
            }
        }
        
        public DataSet GetTreasury()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Treasury_S2", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet FillTEAmtPDE(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TEMonthWise_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet FillTEAmt1415(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGEntries_S4", CommandType.StoredProcedure, arr);
            return ds;
        }
        

      public DataSet FillTEAmt(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGEntries_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetAppStatus(ArrayList ar)
        {
            DataSet dsS = new DataSet();
            dsS = Fetch("ApprovalPDE_AG_S2", CommandType.StoredProcedure,ar);
            return dsS;
        }
        public DataSet GetAppStatusCurr(ArrayList ar)
        {
            DataSet dsS = new DataSet();
            dsS = Fetch("AGEntries_S5", CommandType.StoredProcedure, ar);
            return dsS;
        }
    }
}
