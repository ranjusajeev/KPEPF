using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class ScheduleMainPDEDao : KPEPFDAOBase 
    {
        public DataSet SaveScheduleMainPde(ScheduleMainPDE schM)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schM.IntSchMainId);
            //ArrIn.Add(schM.IntBundId);
            //ArrIn.Add(schM.IntsubBundId);
            ArrIn.Add(schM.IntLbId);
            ArrIn.Add(schM.IntGroupId);
            //ArrIn.Add(schM.IntChalanId);
            //ArrIn.Add(schM.IntSchedId);
            ArrIn.Add(schM.FlgMs);
            ArrIn.Add(schM.FlgRf);
            ArrIn.Add(schM.FlgPf);
            ArrIn.Add(schM.FlgDa);
            ArrIn.Add(schM.FlgPay);
            ArrIn.Add(schM.FltVerticalSum_Ms);
            ArrIn.Add(schM.FltVerticalSum_Rf);
            ArrIn.Add(schM.FltVerticalSum_Pf);
            ArrIn.Add(schM.FltVerticalSum_Da);
            ArrIn.Add(schM.FltVerticalSum_Pay);
            ArrIn.Add(schM.FltTotalSum);
            //ArrIn.Add(schM.FlgAmtMismatch);
            ArrIn.Add(schM.IntModeOfChgId);
            ArrIn.Add(schM.IntUserId);
            //ArrIn.Add(schM.DtmDateOfUpdation);
            ArrIn.Add(schM.ChvRemarks);

            try
            {
                ds = Fetch("TB_ScheduleTR104Main_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
