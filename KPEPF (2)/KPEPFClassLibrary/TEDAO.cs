using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary

{
    public class TEDAO : KPEPFDAOBase
    {
        public DataSet GetTrntype(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_L_TransactionType_S1", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetTreasury()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Treasury_S2", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetDist()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_District_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetStatus()
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_CmbModeOfChange", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetLB()
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_LocalBody_MST_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet CreateCreditMinus(TE crminus)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(crminus.IntId );
            ArrIn.Add(crminus.IntAGEntryId );
            ArrIn.Add(crminus.ChvTEId );
            ArrIn.Add(crminus.FlgType );
            ArrIn.Add(crminus.DtmChalBillDate );
            ArrIn.Add(crminus.IntChalBillNo );
            ArrIn.Add(crminus.FltAmount );
            ArrIn.Add(crminus.ChvAccNoAndName );
            ArrIn.Add(crminus.ChvRemarks );
            ArrIn.Add(crminus.IntModeChg );
            ArrIn.Add(crminus.IntDTreasId );
            ArrIn.Add(crminus.PerYearId);
            ArrIn.Add(crminus.PerMnthId);
            
            try
            {
                ds = Fetch("AGCreditDebitMinus_1", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FillCrMinus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGCreditDebitMinus_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillCrMinusPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_CreditMinus_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillCrMinusPDEForCnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_CreditMinus_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        
        public DataSet FillDbMinusPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_DebitMinus_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillCrMinus4AddRw(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGCreditDebitMinus_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void DelCrMinus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGCreditDebitMinus_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
        }
    }
}
