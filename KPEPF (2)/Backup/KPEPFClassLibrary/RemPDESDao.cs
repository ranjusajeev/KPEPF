using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class RemPDESDao : KPEPFDAOBase  
    {
        public void SaveTreasuryS(RemPDES rems)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(rems.IntDTreasuryDetId);
            ArrIn.Add(rems.IntTreasuryId);
            ArrIn.Add(rems.DtmAccDate);
            ArrIn.Add(rems.DtmTrnDate);

            ArrIn.Add(rems.FltNetAmount);
            ArrIn.Add(rems.FltCashAmount);
            ArrIn.Add(rems.IntSTreasuryDetId);

            try
            {
                Save("AP_TreasuryDetailsS_I1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }

        public void SaveTreasuryDEntries(RemPDES rems)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(rems.IntDTreasuryDetId);
            ArrIn.Add(rems.DtmAccDate);
            ArrIn.Add(rems.DtmTrnDate);

            ArrIn.Add(rems.FltNetAmount);
            ArrIn.Add(rems.IntUserId);
            ArrIn.Add(rems.IntSlNo);

            try
            {
                Save("TreasuryDEntries_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet GetSTreasuryDet4NewChalan(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("AP_TreasuryDetailsS_S2", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
    }
}
