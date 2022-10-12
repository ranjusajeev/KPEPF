using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class ScheduleDAO : KPEPFDAOBase 
    {
        public void SaveSchedule(Schedule schedule)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schedule.NumChalanID);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.FltSubnAmt);
            ArrIn.Add(schedule.FltRePaymentAmt);
            ArrIn.Add(schedule.FltArearPFAmt);
            ArrIn.Add(schedule.FltArearDA);
            ArrIn.Add(schedule.FltArearPay);
            ArrIn.Add(schedule.FltTotal);
            ArrIn.Add(schedule.IntGOId);

            ArrIn.Add(schedule.IntNoOfInst);
            ArrIn.Add(schedule.FlgUnPosted);
            ArrIn.Add(schedule.IntUnPostedRsn);
            ArrIn.Add(schedule.IntModeChange);
            ArrIn.Add(schedule.ChvRem);
            ArrIn.Add(schedule.IntSlNo);
            ArrIn.Add(schedule.NumScheduleID);
            ArrIn.Add(schedule.FlgUnIdentifiedEmp);

            try
            {
                Save("ScheduleTR104_I", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
            
        }
        public void SaveScheduleEntry(Schedule schedule)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schedule.NumChalanID);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.FltSubnAmt);
            ArrIn.Add(schedule.FltRePaymentAmt);
            ArrIn.Add(schedule.FltArearPFAmt);
            ArrIn.Add(schedule.FltArearDA);
            ArrIn.Add(schedule.FltArearPay);
            ArrIn.Add(schedule.FltTotal);
            ArrIn.Add(schedule.IntGOId);

            ArrIn.Add(schedule.IntNoOfInst);
            ArrIn.Add(schedule.FlgUnPosted);
            ArrIn.Add(schedule.IntUnPostedRsn);
            ArrIn.Add(schedule.IntModeChange);
            ArrIn.Add(schedule.ChvRem);


            try
            {
                Save("ScheduleTR104_I1", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet ScheduleList(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet FindSlnofrmScheduleTR104(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S5", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        //public DataSet ScheduleList_Cnt(ArrayList ArrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("ScheduleTR104_S5", CommandType.StoredProcedure, ArrIn);
        //    return ds;
        //}
        public DataSet CheckScheduleExist(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S1", CommandType.StoredProcedure, ArrIn); // ScheduleTR104_S1
            return ds;
        }

        public DataSet CheckScheduleExist4Cnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S7", CommandType.StoredProcedure, ArrIn); // ScheduleTR104_S1
            return ds;
        }
        public DataSet CheckScheduleExistNew(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S4", CommandType.StoredProcedure, ArrIn); // ScheduleTR104_S1
            return ds;
        }
        

        public void UpdateEmpCurrentDetails(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetArrearDet(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void UpdArrearDet(ArrayList arin)
        {
            try
            {
                Save("C_Arrear_I", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdScheduleTR104Mode(ArrayList arin)
        {
            try
            {
                Save("ScheduleTR104_D", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdArrearToEmpCurrDet(ArrayList arin)
        {
            try
            {
                Save("L_EmployeeCurrDet_U6", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        
    }
}
