using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class RemPDELDao : KPEPFDAOBase  
    {
        public DataSet  SaveTreasuryLB(RemPDEL reml)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(reml.IntChalanId);
            ArrIn.Add(reml.IntSTreasuryDetId);
            ArrIn.Add(reml.IntLBId);
            ArrIn.Add(reml.IntTreasuryId);

            ArrIn.Add(reml.IntChalanType);
            ArrIn.Add(reml.IntChalanNo);
            ArrIn.Add(reml.DtmChalanDate);
            ArrIn.Add(reml.FltAmount);
            ArrIn.Add(reml.FlgUnPosted);
            ArrIn.Add(reml.IntUnPosingReasonId);

            try
            {
                ds = Fetch("AP_TreasuryDetailsLB_I", CommandType.StoredProcedure, ArrIn);
                return ds;
               
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet SaveTreasuryLBPDE(RemPDEL reml)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(reml.IntChalanId);
            ArrIn.Add(reml.IntSTreasuryDetId);
            ArrIn.Add(reml.IntLBId);
            ArrIn.Add(reml.IntTreasuryId);

            ArrIn.Add(reml.IntChalanType);
            ArrIn.Add(reml.IntChalanNo);
            ArrIn.Add(reml.DtmChalanDate);
            ArrIn.Add(reml.FltAmount);
            ArrIn.Add(reml.FlgUnPosted);
            ArrIn.Add(reml.IntUnPosingReasonId);
            ArrIn.Add(reml.IntModeChg);
            ArrIn.Add(reml.FromWhom);
            try
            {
                ds = Fetch("AP_TreasuryDetailsLB_I1", CommandType.StoredProcedure, ArrIn);
                return ds;

            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetChalanPDE(RemPDEL rempl)
        {
            DataSet ds = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rempl.IntChalanId);
            ds = Fetch("AP_TreasuryDetailsLB_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
    }
}
