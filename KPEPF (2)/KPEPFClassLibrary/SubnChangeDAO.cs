using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class SubnChangeDAO : KPEPFDAOBase 
    {
        public void CreateSubnChange(SubnChange sbnChg)
        {
            ArrayList vArr = new ArrayList();
            vArr.Add(sbnChg.SubnChangeId);
            vArr.Add(sbnChg.NumEmpId);
            vArr.Add(sbnChg.IntYearId);
            vArr.Add(sbnChg.IntMonthId);
            vArr.Add(sbnChg.FltOldSubnAmt);
            vArr.Add(sbnChg.FltProposedSubnAmt);
            vArr.Add(sbnChg.FltNewSubnAmt);
            vArr.Add(sbnChg.FlgChangeType);
            vArr.Add(sbnChg.IntUserId);
            vArr.Add(sbnChg.DtApp);
            try
            {
                 Fetch("SubnChange_I", CommandType.StoredProcedure, vArr);
            }
            catch(Exception E)
            {
                throw new Exception("Check the Error!!!" + E.Message);
            }
        }
        public DataSet GetSubnChgDetails(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            //ArrIn.Add(
            ds = Fetch("SubnChange_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        //public DataSet SubnChangeInbox(ArrayList arrIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("SubnChange_Inbox", CommandType.StoredProcedure, arrIn);
        //    return ds;
        //}
        public DataSet InboxSunbnChange(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("SubnChange_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void UpdateEmployee(ArrayList ArrIn)
        {
            try
            {
                Save("L_EmployeeCurrDet_U3", CommandType.StoredProcedure, ArrIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        //public DataSet ValidateEligibility(ArrayList ArrIn)
        //{
        //    DataSet dsV = new DataSet();
        //    dsV = Fetch("ServiceTransaction_S6", CommandType.StoredProcedure, ArrIn);
        //    return dsV;
        //}
    }
}
