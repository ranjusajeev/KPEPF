using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class LedgerMDao:KPEPFDAOBase 
    {
        public DataSet AnnStmnt(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S3", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet AnnStmntVerification(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S11", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet CreditCardPart(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S6", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void SaveLedgerM(ArrayList arr)
        {
            try
            {
                Save("LedgerMonthly_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreditCard(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S8", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet CreditCardBulk(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S9", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetWithDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Bill_S41", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetAgDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGEntries_S7", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetAgDetBt(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGEntries_S8", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetAgDetPrev(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_TEMonthWise_S4", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetWithDetPrev(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_Withdrawal_S8", CommandType.StoredProcedure, ar);
            return ds;
        }

        public DataSet AnnStmntCons(ArrayList ar)
        {
            DataSet ds = new DataSet();
            //ds = Fetch("LedgerYearly_S9", CommandType.StoredProcedure, ar);
            ds = Fetch("ScheduleTR104_S14", CommandType.StoredProcedure, ar);
            return ds;
        }
    }
}
