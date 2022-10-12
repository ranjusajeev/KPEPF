using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class RemPDEDDao : KPEPFDAOBase  
    {
        public void SaveTreasuryD(RemPDED remd)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(remd.IntYearID);
            ArrIn.Add(remd.IntMonthId);
            ArrIn.Add(remd.IntDTId);
            ArrIn.Add(remd.IntSource);
            //ArrIn.Add(remd.DtmIntimation);
            ArrIn.Add(remd.FltNetAmount);
            ArrIn.Add(remd.StrParticulars);

            try
            {
                Save("AP_TreasuryDetailsD_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
    }
}
