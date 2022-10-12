using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class MonthlySubnDAO : KPEPFDAOBase
    {
        //public DataSet FillGrid(ArrayList ArrIn)
        //{            
        //    DataSet ds = new DataSet();
        //    ds = Fetch("L_EmployeeDet_S1", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        //public DataSet FillGrid_Emp(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("L_EmployeeDet_S2", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
  
        public DataSet FillMonthTrn(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MonthlyTransactions_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FillMonthTrnEntry(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MonthlyTransactions_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ScheduleAmtTotal(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S4", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        //public DataSet FillSchedule(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("ScheduleTR104_S1", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public DataSet GetYearDetail(ArrayList arr)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Year_S5", CommandType.StoredProcedure, arr);
            return ds;
        }
        public DataSet MatchEmp(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MonthlyTransactions_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        

    }
}
