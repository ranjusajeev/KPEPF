using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
    public class CreditCardDao : KPEPFDAOBase  
    {
        public DataSet GetCreditCardInSite(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Closure_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetCreditCardVerified(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            if (Convert.ToInt16(ArrIn[1].ToString()) < 44)
            {
                ds = Fetch("Sp_SelectCreditCardIndMonthwiseNew", CommandType.StoredProcedure, ArrIn);
            }
            else
            {
                ds = Fetch("Sp_SelectCreditCardIndMonthwise", CommandType.StoredProcedure, ArrIn);
            }
            return ds;
        }
    }
}
