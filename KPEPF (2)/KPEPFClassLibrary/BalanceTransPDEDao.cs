using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class BalanceTransPDEDao : KPEPFDAOBase
    {
         public DataSet CreateBalanceTransRel(BalanTrPDE  bal)
        {
             DataSet ds = new DataSet();
             ArrayList ArrIn = new ArrayList();
             ArrIn.Add(bal.IntTEMonthWiseId);
             ArrIn.Add(bal.IntRelYearId );
             ArrIn.Add(bal.IntRelMonthId );
             ArrIn.Add(bal.FltAmtPDE);
             ArrIn.Add(bal.IntTrnType);
             ArrIn.Add(bal.IntTreasId);
             ArrIn.Add(bal.IntModeChgPDE);
             ArrIn.Add(bal.IntRelMonthWiseId);
             ArrIn.Add(bal.IntLBId);
             ArrIn.Add(bal.ChvTEIdPDE);
             try
             {
                 ds = Fetch("AP_TERelMonthWise_I", CommandType.StoredProcedure, ArrIn);
                 return ds;
             }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CreateBalanceTransCr(BalanTrPDE  bal)
        {
            DataSet ds = new DataSet();
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(bal.IntIDPDE);
            ArrIn.Add(bal.IntRelMonthWiseId);
            ArrIn.Add(bal.ChvTEIdPDE);
            ArrIn.Add(bal.ChvFrmAccNoPDE);
            ArrIn.Add(bal.IntToAccNoPDE );
            ArrIn.Add(bal.IntFrmAccNoPDE);
            ArrIn.Add(bal.ChvToAccNoPDE);
            
            ArrIn.Add(bal.FltAmtPDE);
            ArrIn.Add(bal.ChvRemarksPDE);
            ArrIn.Add(bal.IntModeChgPDE);
            ArrIn.Add(bal.IntFlag);

            try
            {
                ds = Fetch("AP_BalanceTransfer_I", CommandType.StoredProcedure, ArrIn);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet FillName(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Pfo_SelEmpName", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void DeleteBalancetransCrPDE(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_BalanceTransfer_D", CommandType.StoredProcedure, ArrIn);
        }

        public DataSet getEditStatus(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_BalanceTransfer_S6", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public DataSet getEditStatusDt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AP_BalanceTransfer_S7", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
    }
}
