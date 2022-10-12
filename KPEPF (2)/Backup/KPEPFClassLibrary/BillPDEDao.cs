using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class BillPDEDao : KPEPFDAOBase
    {
        public DataSet GetBillPdeDet1(BillPDE bil)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();

            ArrIn.Add(bil.IntBillNo);
            ArrIn.Add(bil.DtmBill);
            ArrIn.Add(bil.IntSearchType);
            ds = Fetch("AP_WithBillDetails_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
           
        }
        public DataSet GetBillPdeDet2(BillPDE bil)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();

            ArrIn.Add(bil.IntYearId);
            ArrIn.Add(bil.IntMonthId);
            ArrIn.Add(bil.IntDTreasuryId);
            ds = Fetch("AP_WithBillDetails_S3", CommandType.StoredProcedure, ArrIn);
            return ds;

        }
    }
}
