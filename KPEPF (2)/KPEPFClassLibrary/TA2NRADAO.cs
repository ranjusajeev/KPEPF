using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;


namespace KPEPFClassLibrary
{
    public class TA2NRADAO : KPEPFDAOBase 
    {
        public void CreateTA2NRAConRequest(TA2NRACon Ta2Nra)
        {
            ArrayList vArr = new ArrayList();
            //vArr.Add(Ta2Nra.NumTrnId);
            vArr.Add(Ta2Nra.NumSerTrnId);
            vArr.Add(Ta2Nra.NumEmpId);
            vArr.Add(Ta2Nra.NumWithdrawalID);
            vArr.Add(Ta2Nra.FltAmtConverted);
            vArr.Add(Ta2Nra.IntRsnId);
     
            try
            {
                Save("TA2NRACon_I",CommandType.StoredProcedure, vArr);
            }
            catch (Exception  Err)
            {
                throw new Exception ("Check the Error" + Err.Message);
            }
       }
        public DataSet InboxTaToNra(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TA2NRACon_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillTaToNra(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TA2NRACon_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

    }
}
