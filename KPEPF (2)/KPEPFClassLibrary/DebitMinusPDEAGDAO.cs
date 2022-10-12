using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class DebitMinusPDEAGDAO : KPEPFDAOBase
    {
        public DataSet CreateDebitMinus(DebitMinusPDEAG db)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(db.IntId);
            ArrIn.Add(db.IntRelMonthWiseId );
            ArrIn.Add(db.ChvTEId);
            ArrIn.Add(db.DtmVchrDate);
            ArrIn.Add(db.IntVchrNo);
            ArrIn.Add(db.ChvAccNo);
            ArrIn.Add(db.ChvName);
            ArrIn.Add(db.FltAmount);
            ArrIn.Add(db.ChvRemarks);
            ArrIn.Add(db.FlgUnPosted);
            ArrIn.Add(db.IntUnPostdReason);
            ArrIn.Add(db.IntModeChg);
            ArrIn.Add(db.IntBillWsId);
            ArrIn.Add(db.IntDistId);
            ArrIn.Add(db.IntDTreasId);

            try
            {
                ds = Fetch("AP_DebitMinus_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FindBillwiseId(DebitMinusPDEAG  Dbminus)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(Dbminus.IntDTreasId );
            ArrIn.Add(Dbminus.DtmVchrDate );
            ArrIn.Add(Dbminus.IntVchrNo );
            ds = Fetch("AP_WithBillDetails_S5", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void UpdDebitMinusModeofChnge(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_DebitMinus_D", CommandType.StoredProcedure, ArrIn);

        }
    }
}
