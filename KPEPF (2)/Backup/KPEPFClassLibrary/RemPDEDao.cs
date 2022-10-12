using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class RemPDEDao : KPEPFDAOBase
    {
        public DataSet GetConsTreasuryPDE(RemPDE rem)
        {
            DataSet dsConsTreasPde = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rem.IntYearID);
            ar.Add(rem.IntMonthId);
            ar.Add(rem.IntDTId);
            ar.Add(1);
            dsConsTreasPde = Fetch("AP_TreasuryDetailsD_S1", CommandType.StoredProcedure, ar);
            return dsConsTreasPde;
        }
        public DataSet GetSTreasuryDetPDE(RemPDE rem)
        {
            DataSet dsChalPde = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rem.IntYearID);
            ar.Add(rem.IntMonthId);
            ar.Add(rem.IntDTId);
            ar.Add(1);
            dsChalPde = Fetch("AP_TreasuryDetailsS_S1", CommandType.StoredProcedure, ar);
            return dsChalPde;
        }
        public DataSet GetChalanPDE(RemPDE rem)
        {
            DataSet dsChalPde = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rem.IntSTreasuryDetId);
            dsChalPde = Fetch("AP_TreasuryDetailsLB_S1", CommandType.StoredProcedure, ar);
            return dsChalPde;
        }
        public DataSet GetChalanPDEAll(RemPDE rem)
        {
            DataSet dsChalPdeAll = new DataSet();
            ArrayList arAll = new ArrayList();
            arAll.Add(rem.IntYearID);
            arAll.Add(rem.IntMonthId);
            arAll.Add(rem.IntDTId);
            dsChalPdeAll = Fetch("AP_TreasuryDetailsLB_S2", CommandType.StoredProcedure, arAll);
            return dsChalPdeAll;
        }
        public DataSet GetSchedulePDE(RemPDE rem)
        {
            DataSet dsSchedPde = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(rem.IntChalanID);

            dsSchedPde = Fetch("Tb_ScheduleTR104_S2", CommandType.StoredProcedure, ar);
            return dsSchedPde;
        }
        
    }
}
