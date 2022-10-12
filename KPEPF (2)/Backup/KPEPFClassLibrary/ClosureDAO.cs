using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class ClosureDAO : KPEPFDAOBase  
    {
        public DataSet CreateClosure(Closure clsr)
        {
            DataSet ds = new DataSet();
            ArrayList vArr = new ArrayList();
            vArr.Add(clsr.NumTrnID);
            vArr.Add(clsr.NumEmpID);
            vArr.Add(clsr.IntRsnID);
            vArr.Add(clsr.DtmLastSalary);
            vArr.Add(clsr.DtmLastChalan);
            vArr.Add(clsr.DtmQuitting);
            vArr.Add(clsr.IntQuittingLB);
         
            try
            {
                Save("Closure_I", CommandType.StoredProcedure, vArr);
                return ds;
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!!!" + E.Message);
            }
        }
        public DataSet GetClosureDetails(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Closure_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetClosureDetailsInbx(ArrayList ArIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Closure_S2", CommandType.StoredProcedure, ArIn);
            return ds;
        }
        public DataSet GetRetemntDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("LedgerMonthly_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetRetemntDetMrchFun()
        {
            DataSet dsRtrMrch = new DataSet();
            dsRtrMrch = Fetch("G_Year_S4", CommandType.StoredProcedure);
            return dsRtrMrch;
        }
        public DataSet GetRetemntDetMrch(ArrayList ArrIn)
        {
            DataSet dsRtrMrch = new DataSet();
            dsRtrMrch = Fetch("G_Year_S4", CommandType.StoredProcedure, ArrIn);
            return dsRtrMrch;
        }
        //public DataSet GetClosureSchedule(ArrayList ArrIn)
        //{
        //    DataSet dsSched = new DataSet();
        //    dsSched = Fetch("ServiceTransaction_S2", CommandType.StoredProcedure, ArrIn);
        //    return dsSched;
        //}

        public void UpdateEmployeeClsr(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeDet_U1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
