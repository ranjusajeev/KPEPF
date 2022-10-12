using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
namespace KPEPFClassLibrary
{
    public class ABCDDao : KPEPFDAOBase 
    {
        public void SaveABCD(ABCD ab)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(ab.IntID );
            ArrIn.Add(ab.IntaccNo );
            ArrIn.Add(ab.IntYearId );
       // ArrIn.Add(ab.IntMonthId );
            ArrIn.Add(ab.TotalCr );
            ArrIn.Add(ab.TotlAB);
            ArrIn.Add(ab.grndTotal12 );
            ArrIn.Add(ab.totalWith );
            ArrIn.Add(ab.arrearDA );
            ArrIn.Add(ab.NetBalance );
            ArrIn.Add(ab.grndTotal45 );
       //    ArrIn.Add(ab.ChvGO );
        //  ArrIn.Add(ab.DtmGODate );
           
            try
            {
                Save("ABCD_I ", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public void SaveABCDArrear(ABCD ab)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(ab.IntID);
            ArrIn.Add(ab.IntaccNo);
            ArrIn.Add(ab.IntYearId);
            ArrIn.Add(ab.IntMonthId);
            ArrIn.Add(ab.IntArrearDA);
            ArrIn.Add(ab.ChvGO);
            ArrIn.Add(ab.DtmGODate);

            try
            {
                Save("ABCDArrear_I ", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet GetYear()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S6", CommandType.StoredProcedure);
            return ds;
        }
        
            public DataSet GetMonth()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Month_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetABCDDet(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ABCD_Rpt_FormD ", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet GetABCDArrearDet(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ABCDArrear_S1 ", CommandType.StoredProcedure, arr);
            return ds;
        }
    }
}
