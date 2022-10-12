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
        public void SaveTreasurySNew(ArrayList ar)
        {
            try
            {
                Save("AP_TreasuryDetailsS_I2", CommandType.StoredProcedure, ar);
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
            //ArrIn.Add(rems.IntSlNo);
            ArrIn.Add(rems.IntTreasuryId);
            ArrIn.Add(rems.IntSTreasuryDetId);
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
        public DataSet GetTreasuryDetData(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntries_S2", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetTreasuryDetDataExists(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntries_S2", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet GetTreasuryDetDataNw(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntries_S4", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
        public DataSet DelTreasuryDEntries(ArrayList ar)
        {
            DataSet dsChaln = new DataSet();
            dsChaln = Fetch("TreasuryDEntries_D", CommandType.StoredProcedure, ar);
            return dsChaln;
        }
     
    }
}
