using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using KPEPFClassLibrary;

namespace KPEPFClassLibrary
{
    public class LedgerYDao:KPEPFDAOBase
    {
        public DataSet GetYearlyDet(ArrayList ar)
        {
            DataSet dsY = new DataSet();
            dsY = Fetch("TB_YearDetail_S1", CommandType.StoredProcedure, ar);
            return dsY;
        }
        public DataSet GetYearlyDetLat(ArrayList ar)
        {
            DataSet dsY = new DataSet();
            dsY = Fetch("LedgerYearly_S2", CommandType.StoredProcedure, ar);
            return dsY;
        }
        public void UpdateYearDet4GenerateCard(ArrayList ar)
        {
            Fetch("TB_YearDetail_U1", CommandType.StoredProcedure,ar);
        }
       
        public void DelLedgerYearly(ArrayList ar)
        {
            Fetch("LedgerYearly_D", CommandType.StoredProcedure, ar);
        }
        public void DelLedgerYearlyBulk(ArrayList ar)
        {
            Fetch("LedgerYearly_D1", CommandType.StoredProcedure, ar);
        }
        public void DelLedgerYearlySingle(ArrayList ar)
        {
            Fetch("LedgerYearly_D2", CommandType.StoredProcedure, ar);
        }
        public void DelLedgerYearlySingleYr(ArrayList ar)
        {
            Fetch("LedgerYearly_D3", CommandType.StoredProcedure, ar);
        }
        public void DelLedgerYearlySingleYrwise(ArrayList ar)
        {
            Fetch("LedgerYearly_D4", CommandType.StoredProcedure, ar);
        }
        public DataSet GetOB(ArrayList ar)
        {
            DataSet dsY = new DataSet();
            dsY = Fetch("TB_YearDetail_S4", CommandType.StoredProcedure, ar);
            return dsY;
        } 

        public void SaveLedgerY(ArrayList arr)
        {
            try
            {
                Save("LedgerYearly_I", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveLedgerYg(ArrayList arr)
        {
            try
            {
                Save("LedgerYearly_I2", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveLedgerYPartial(ArrayList arr)
        {
            try
            {
                Save("LedgerYearly_I1", CommandType.StoredProcedure, arr);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetYearlyDetNew(ArrayList ar)
        {
            DataSet dsY = new DataSet();
            dsY = Fetch("LedgerYearly_S3", CommandType.StoredProcedure, ar);
            return dsY;
        }
        public void updCalGrp(ArrayList ar)
        {
            Fetch("calcGrp_U1", CommandType.StoredProcedure, ar);
        }
        public void UpdateYearDet4GenerateCardNew(ArrayList ar)
        {
            Fetch("LedgerYearly_U1", CommandType.StoredProcedure, ar);
        }
        //Ranjitha


        public void UpdateYearDet4GenerateCardNew_EmpCC(ArrayList ar)
        {
            Fetch("LedgerYearly_U3", CommandType.StoredProcedure, ar);
        }

        //End
        public void updateYearDetForCorrectionAmount(ArrayList ar)
        {
            Fetch("LedgerYearly_U2", CommandType.StoredProcedure, ar);
        }
        public void UpdateYearDet4GenerateCardNewSingle(ArrayList ar)
        {
            Fetch("LedgerYearly_U2", CommandType.StoredProcedure, ar);
        }
    }
}
