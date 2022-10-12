using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class OBDao : KPEPFDAOBase
    {
        public DataSet GetOb(OB ob)
        {
            DataSet dsO = new DataSet();
            ArrayList ar = new ArrayList();
            ar.Add(ob.IntDistId);
            dsO = Fetch("Pfo_ClosingBalance_S1", CommandType.StoredProcedure, ar);
            return dsO;
        }
        //public DataSet GetObSingle(OB ob)
        //{
        //    DataSet dsO = new DataSet();
        //    ArrayList ar = new ArrayList();
        //    ar.Add(ob.IntDistId);
        //    dsO = Fetch("Pfo_ClosingBalance_S1", CommandType.StoredProcedure, ar);
        //    return dsO;
        //}
        public DataSet GetObSingle(OB ob)
        {
            DataSet dsO1 = new DataSet();
            ArrayList ar1 = new ArrayList();
            ar1.Add(ob.IntAccNo);
            dsO1 = Fetch("Pfo_ClosingBalance_S2", CommandType.StoredProcedure, ar1);
            return dsO1;
        }
        public void SaveOb(OB ob)
        {
            ArrayList arr = new ArrayList();
            arr.Add(ob.IntAccNo);
            arr.Add(ob.FltAmount);
            arr.Add(ob.IntDistId);
            arr.Add(ob.IntUserId);
            arr.Add(ob.IntMoC);
            try
            {
                Save("Pfo_InsClosingBalance_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
