using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class SchedulePDEDao : KPEPFDAOBase 
    {
        public void SaveSchedulePde(SchedulePDE schedule)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schedule.IntRecNo);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.ChvName);
            ArrIn.Add(schedule.FltSubnAmt);
            ArrIn.Add(schedule.FltRePaymentAmt);
            ArrIn.Add(schedule.FltArearPFAmt);
            ArrIn.Add(schedule.FltArearDA);
            ArrIn.Add(schedule.FltArearPay);
            ArrIn.Add(schedule.FltTotal);
            ArrIn.Add(schedule.ChvGOId);
            ArrIn.Add(schedule.IntSchMainId);
            ArrIn.Add(schedule.FlgUnIdentifiedEmp);
            ArrIn.Add(schedule.IntModeChange);
            ArrIn.Add(schedule.IntUserId);

            ArrIn.Add(schedule.FlgUnPosted);
            ArrIn.Add(schedule.IntUnPostedRsn);
            ArrIn.Add(schedule.ChvRem);
            ArrIn.Add(schedule.IntChalanId);
            ArrIn.Add(schedule.IntSlno);
            ArrIn.Add(schedule.ChvGOId);
            ArrIn.Add(schedule.IntFm);
            ArrIn.Add(schedule.IntTm);
            try
            {
                Save("TB_ScheduleTR104_I", CommandType.StoredProcedure, ArrIn);
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
        public DataSet ScheduleList_Cnt(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S5", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet CheckScheduleExist(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("ScheduleTR104_S1", CommandType.StoredProcedure, ArrIn); // ScheduleTR104_S1
            return ds;
        }
        
        public DataSet ScheduleMainSave(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ScheduleTR104Main_I1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ScheduleMainSavePDE01(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ScheduleTR104Main_I2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet ScheduleMainSavePDE01Ag(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("TB_ScheduleTR104Main_I3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void UpdScheduleTR104PDEMode(ArrayList arin)    //not using
        {
            try
            {
                Save("TB_ScheduleTR104_D", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
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
        public void UpdateSchedulePde(SchedulePDE schedule)
        {
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schedule.IntRecNo);
            ArrIn.Add(schedule.IntSchMainId);
            ArrIn.Add(schedule.FlgUnIdentifiedEmp);
            ArrIn.Add(schedule.FltSubnAmt);
            ArrIn.Add(schedule.FltRePaymentAmt);

            ArrIn.Add(schedule.FltArearPFAmt);
            ArrIn.Add(schedule.FltArearDA);

            ArrIn.Add(schedule.FltArearPay);
            ArrIn.Add(schedule.FltTotal);
            ArrIn.Add(schedule.IntChalanId);
            ArrIn.Add(schedule.IntSlno);
            ArrIn.Add(schedule.ChvGOId);
            ArrIn.Add(schedule.IntFm);
            ArrIn.Add(schedule.IntTm);
            try
            {
                Save("TB_ScheduleTR104_U", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public void DelTR104PDEMode(ArrayList arin)
        {
            try
            {
                Save("TB_ScheduleTR104_D2", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public DataSet GetSchedDet4CorrEntry(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tb_ScheduleTR104_S7", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetSchedDet4CorrEntryCorr(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tb_ScheduleTR104_S12", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void delScheduleTR104(ArrayList arr)
        {
            try
            {
                Save("Tb_ScheduleTR104_D4", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public void UpdScheduleTR104Mode(ArrayList arr)
        {
            try
            {
                Save("TB_ScheduleTR104_D1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }
        public DataSet FindSlnofrmSchedulePDETR104(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tb_ScheduleTR104_S11", CommandType.StoredProcedure, ArrIn);//Chalan_S1
            return ds;
        }
        public void UpdScheduleTR104ModeChalanIdWise(ArrayList arr)
        {
            try
            {
                Save("TB_ScheduleTR104_D3", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }

        }


        public float SaveSchedulePdeCorr(SchedulePDE schedule)
        {
            DataSet dsSched = new DataSet();
            float schedId = 0;
            ArrayList ArrIn = new ArrayList();
            ArrIn.Add(schedule.IntRecNo);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.NumEmpID);
            ArrIn.Add(schedule.ChvName);
            ArrIn.Add(schedule.FltSubnAmt);
            ArrIn.Add(schedule.FltRePaymentAmt);
            ArrIn.Add(schedule.FltArearPFAmt);
            ArrIn.Add(schedule.FltArearDA);
            ArrIn.Add(schedule.FltArearPay);
            ArrIn.Add(schedule.FltTotal);
            ArrIn.Add(schedule.ChvGOId);
            ArrIn.Add(schedule.IntSchMainId);
            ArrIn.Add(schedule.FlgUnIdentifiedEmp);
            ArrIn.Add(schedule.IntModeChange);
            ArrIn.Add(schedule.IntUserId);

            ArrIn.Add(schedule.FlgUnPosted);
            ArrIn.Add(schedule.IntUnPostedRsn);
            ArrIn.Add(schedule.ChvRem);
            ArrIn.Add(schedule.IntChalanId);
            ArrIn.Add(schedule.IntSlno);
            ArrIn.Add(schedule.ChvGOId);
            ArrIn.Add(schedule.IntFm);
            ArrIn.Add(schedule.IntTm);
            try
            {
                dsSched = Fetch("TB_ScheduleTR104_I", CommandType.StoredProcedure, ArrIn);
                if (dsSched.Tables[0].Rows.Count > 0)
                {
                    schedId = Convert.ToInt64(dsSched.Tables[0].Rows[0].ItemArray[0]);
                }
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
            return schedId;
        }
        public DataSet GetSchedDet4CorrEntryAg(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Tb_ScheduleTR104_S13", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
    }
}
