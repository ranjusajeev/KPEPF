using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class AnnIntDAO : KPEPFDAOBase
    {
        public void CreateAnnInt(AnnInt an)

        {
            ArrayList arr = new ArrayList();
            arr.Add(an.IntAGEntryId);
            arr.Add(an.IntYearId);
            arr.Add(an.FltAmount);
            arr.Add(an.Rem);
            arr.Add(an.TENo);
            try
            {
                Save("AnnualInterest_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetAnnInt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AnnualInterest_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }

        public void CreateAnnIntPDE(AnnInt an)
        {
            ArrayList arr = new ArrayList();
            
            arr.Add(an.IntYearId);
            arr.Add(an.IntSlNo);
            arr.Add(an.FltAmount);
            arr.Add(an.Rem);
            arr.Add(an.TENo);
            try
            {
                Save("AP_AnnualInterest_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetAnnIntPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_AnnualInterest_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
    }
}
