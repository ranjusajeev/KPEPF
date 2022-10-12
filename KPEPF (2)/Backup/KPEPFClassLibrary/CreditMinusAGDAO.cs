using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class CreditMinusAGDAO : KPEPFDAOBase
    {
        public DataSet CreateCreditMinus(CreditMinusAG crminus)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(crminus.IntId);
            ArrIn.Add(crminus.IntRelMonthWiseId);
            ArrIn.Add(crminus.ChvTEId);
            ArrIn.Add(crminus.DtmChalDate);
            ArrIn.Add(crminus.IntChalNo);
            ArrIn.Add(crminus.ChvAccNo);
            ArrIn.Add(crminus.ChvName);
            ArrIn.Add(crminus.FltAmount);
            ArrIn.Add(crminus.ChvRemarks);
            ArrIn.Add(crminus.IntModeChg);
            ArrIn.Add(crminus.IntChalanId);
            ArrIn.Add(crminus.IntTreasId);
            ArrIn.Add(crminus.IntChalanAGID);

            try
            {
                ds = Fetch("AP_CreditMinus_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FillCrWithoutDocs(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AGCreditDebitMissing_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void  UpdCreditMinusModeofChnge(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_CreditMinus_D", CommandType.StoredProcedure, ArrIn);
            
        }
        public DataSet FillChalanId(CreditMinusAG crminus)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(crminus.IntChalNo);
            ArrIn.Add(crminus.DtmChalDate);
            ArrIn.Add(crminus.IntTreasId);
            ds = Fetch("AP_TreasuryDetailsLB_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet FillChalanIdfrmAG(CreditMinusAG crminus)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(crminus.IntChalNo);
            ArrIn.Add(crminus.DtmChalDate);
            ArrIn.Add(crminus.IntTreasId);
            ds = Fetch("AP_ChalanAG_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
    }
}
