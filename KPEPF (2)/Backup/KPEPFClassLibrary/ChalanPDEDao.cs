using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class ChalanPDEDao : KPEPFDAOBase 
    {
        public void UpdateChalanPde1(ChalanPDE chalan)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.IntUserId);
            ArrIn.Add(chalan.IntModeChange);
            ArrIn.Add(1);
            ArrIn.Add(1);
            try
            {
                Save("TB_ChalanDetails_TRN_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateChalanPde2(ChalanPDE chalan)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.NumChalanId);
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.IntModeChange);
            ArrIn.Add(chalan.FlgUnposted);
            ArrIn.Add(chalan.IntUnPostedRsn);
            try
            {
                Save("AP_TreasuryDetailsLB_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        
        public DataSet FindCntEmpInChalan(ArrayList ar)
        {
            int cnt = 0;
            DataSet dsCnt = new DataSet();
            dsCnt = Fetch("TB_ChalanDetails_TRN_S5", CommandType.StoredProcedure, ar);
            return dsCnt;
        }
        public void UpdateChalanAG(ChalanPDE chalan)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(chalan.DtChalanDate);
            ArrIn.Add(chalan.NumChalanId);
            try
            {
                Save("AP_ChalanAG_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
