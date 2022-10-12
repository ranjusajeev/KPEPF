using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
namespace KPEPFClassLibrary
{
    public class EmployeeDAO:KPEPFDAOBase 
    {
        public DataSet GetEmployee()
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetEmployeeDist(ArrayList vArryIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S2", CommandType.StoredProcedure,vArryIn );
            return ds;
        }
        public DataSet GetEmployeeBasicDet(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeCurrDet_S3", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet UpdEmployeeBasicDet(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            vArryIn.Add(emp.DtmDOB);
            vArryIn.Add(emp.DtmDOJS);
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_U3", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet UpdEmployeeapprvalflg(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.IntCurrLB);
            vArryIn.Add(emp.IntflgApp);
            vArryIn.Add(emp.IntUserId);
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetTrnApp_I", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet UpdEmployeeBasicDetTrn(Employee emp,DateTime d)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            vArryIn.Add(emp.DtmDOB);
            vArryIn.Add(emp.DtmDOJS);
            vArryIn.Add(emp.IntCurrLB);
            vArryIn.Add(emp.FlgCont);
            vArryIn.Add(d);
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetTrn_I", CommandType.StoredProcedure, vArryIn);
            return ds;
        }
        public DataSet GetEmployeeDetails(Employee emp,int flgType)
        {
            ArrayList vArryIn = new ArrayList();
            
            DataSet dsEmp = new DataSet();
            if (flgType == 1)
            {
                vArryIn.Add(emp.NumEmpID);
                dsEmp = Fetch("L_EmployeeDet_S3", CommandType.StoredProcedure, vArryIn);
            }
            else
            {
                vArryIn.Add(emp.StrEmpName);
                dsEmp = Fetch("L_EmployeeDet_S4", CommandType.StoredProcedure, vArryIn);
            }
            return dsEmp;
        }
        //public DataSet GetEmployeePin(Employee emp)
        //{
        //    ArrayList ar = new ArrayList();
        //    ar.Add(emp.NumEmpID);
        //    DataSet ds = new DataSet();
        //    ds = Fetch("L_EmployeeDetTrn_S4", CommandType.StoredProcedure, ar);
        //    return ds;
        //}
        public DataSet GetEmpDetails(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S15", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetapprvalFlg(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetTrnApp_s", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetEmpLBDetails(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetTrn_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetEmpDetailsTrn(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDetTrn_S", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void UpdateEmpLB(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            vArryIn.Add(emp.IntCurrLB);
            DataSet dsEmp = new DataSet();
            Save("L_EmployeeCurrDet_U1", CommandType.StoredProcedure, vArryIn);
        }
        //public DataSet GetEmployeeName(ArrayList vArryIn)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("L_EmployeeDet_S3", CommandType.StoredProcedure, vArryIn);
        //    return ds;
        //}
        public DataSet GetMaxAccNo()
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("L_EmployeeDet_S5", CommandType.StoredProcedure);
            return dsNo;
        }
        public DataSet GetConsolidatedTA(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("WithdrawalRequest_S6", CommandType.StoredProcedure, arr);
            return dsNo;
        }
        public void AddEmployee(Employee emp)
        {
            ArrayList arrE = new ArrayList();
            arrE.Add(emp.NumEmpID);
            arrE.Add(emp.StrEmpName);
            arrE.Add(emp.IntGender);
            arrE.Add(emp.DtmDOB);
            arrE.Add(emp.DtmSubStartDate);
            arrE.Add(emp.IntPFNo);
            arrE.Add(emp.IntJoinDist);
            arrE.Add(emp.IntJoinLB);
            arrE.Add(emp.IntCurrentDesigId);
            arrE.Add(emp.FltBasicPay);
            arrE.Add(emp.IntJoinLB);
            arrE.Add(emp.FltSubscription);
            arrE.Add(emp.DtmDOJS);
            arrE.Add(emp.DtmSubStartDate);
            arrE.Add(emp.IntAadhaar);
            arrE.Add(emp.ChvPhone);
            arrE.Add(emp.IntBankType);
            arrE.Add(emp.IntBankBranch);
            arrE.Add(emp.ChvBankAccNo);
            Save("L_EmployeeDet_I", CommandType.StoredProcedure, arrE);
        }
        public void AddEmployeeExisting(Employee emp)
        {
            ArrayList arrE = new ArrayList();
            arrE.Add(emp.NumEmpID);
            arrE.Add(emp.StrEmpName);
            arrE.Add(emp.IntPFNo);
            arrE.Add(emp.IntJoinDist);
            arrE.Add(emp.IntCurrLB);           
            arrE.Add(emp.ChvWEFrom);
            arrE.Add(emp.DtmDOJP);
            arrE.Add(emp.DtmDOJS);
            Save("L_EmployeeDet_I1", CommandType.StoredProcedure, arrE);
        }
        public void UpdEmployeeExisting(Employee emp)
        {
            ArrayList arrE = new ArrayList();
            arrE.Add(emp.NumEmpID);
            arrE.Add(emp.StrEmpName);
            arrE.Add(emp.IntPFNo);
            arrE.Add(emp.IntJoinDist);
            arrE.Add(emp.IntCurrLB);
            arrE.Add(emp.ChvWEFrom);
            arrE.Add(emp.DtmDOJP);
            arrE.Add(emp.DtmDOJS);
            Save("L_EmployeeDet_U1", CommandType.StoredProcedure, arrE);
        }
        public void UpdateEmpNomFlg(ArrayList arIn)
        {
            //DataSet dsEmpU = new DataSet();
            Save("L_EmployeeDet_U", CommandType.StoredProcedure, arIn);
        }
        public void UpdateEmpServices(Employee emp)
        {
            ArrayList vArryIn = new ArrayList();
            vArryIn.Add(emp.NumEmpID);
            vArryIn.Add(emp.IntCurrLB);
            DataSet dsEmp = new DataSet();
            Save("L_EmployeeCurrDet_U1", CommandType.StoredProcedure, vArryIn);
        }
        public void UpdateEmpPfServices(ArrayList vArryIn)
        {
            Save("L_EmployeeCurrDet_U4", CommandType.StoredProcedure, vArryIn);
        }
        public DataSet CheckNomPDEEntry(ArrayList arr)
        {
            DataSet dsN = new DataSet();
            dsN = Fetch("L_EmployeeDet_S8", CommandType.StoredProcedure,arr);
            return dsN;
        }
        //public void UpdateEmpPfServices(ArrayList vArryIn)
        //{
        //    Save("L_EmployeeCurrDet_U4", CommandType.StoredProcedure, vArryIn);
        //}
        public void UpdateEmpCurrDetServices(ArrayList arIn)
        {
            Save("L_EmployeeCurrDet_U4", CommandType.StoredProcedure, arIn);
        }
        public void UpdateEmpCurrDetServicesSC(ArrayList arIn)
        {
            Save("L_EmployeeCurrDet_U5", CommandType.StoredProcedure, arIn);
        }
        public DataSet GetSerHistory(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("EmpLBHistory_S1", CommandType.StoredProcedure,arr);
            return dsNo;
        }
        public DataSet GetSerHistoryFrmLedger(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("TB_LedgerDet_TRN_S4", CommandType.StoredProcedure, arr);
            return dsNo;
        }
        public DataSet getMissingRem(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("Chalan_S47", CommandType.StoredProcedure, arr);
            return dsNo;
        }
        public DataSet getMissingWith(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("Withdrawals_S16", CommandType.StoredProcedure, arr);
            return dsNo;
        }


        public DataSet getMissingRemCons()
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("Chalan_S48", CommandType.StoredProcedure);
            return dsNo;
        }
        public DataSet getMissingWithCons()
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("Bill_S43", CommandType.StoredProcedure);
            return dsNo;
        }


        public DataSet WhetherMatchLB(ArrayList arr)
        {
            DataSet dsNo = new DataSet();
            dsNo = Fetch("L_EmployeeCurrDet_S4", CommandType.StoredProcedure, arr);
            return dsNo;
        }
        public void UpdateArrearToCredit(ArrayList arin)
        {
            try
            {
                Save("L_EmployeeCurrDet_U7", CommandType.StoredProcedure, arin);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateSthapanaId(ArrayList arSthap)
        {
            try
            {
                Save("L_EmployeeDet_U2", CommandType.StoredProcedure, arSthap);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetTotEmp4Calc()
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDet_S14", CommandType.StoredProcedure);
            return dsTEmp;
        }
        public DataSet GetLBToApp(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDet_App_S1", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        public DataSet CheckPin(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDet_S16", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        //public DataSet CheckPinDob(ArrayList ar)
        //{
        //    DataSet dsTEmp = new DataSet();
        //    dsTEmp = Fetch("L_EmployeeDet_S16", CommandType.StoredProcedure, ar);
        //    return dsTEmp;
        //}
        //public DataSet CheckPinDob(ArrayList ar)
        //{
        //    DataSet dsTEmp = new DataSet();
        //    dsTEmp = Fetch("L_EmployeeDet_S16", CommandType.StoredProcedure, ar);
        //    return dsTEmp;
        //}
        public DataSet GetAppListofEmp(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDetTrn_S3", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        public DataSet GetServiceDet(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDetTrn_S3", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        public DataSet GetServiceDetRpt(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDet_App_S3", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        public DataSet GetLBToAppDir(ArrayList ar)
        {
            DataSet dsTEmp = new DataSet();
            dsTEmp = Fetch("L_EmployeeDet_App_S2", CommandType.StoredProcedure, ar);
            return dsTEmp;
        }
        public DataSet GetEmp4BulcCalc()
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("L_EmployeeDet_S18", CommandType.StoredProcedure);
            return dsEmp;
        }
        public DataSet GetEmp4BulcCalcGroup()
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("L_EmployeeDet_S18", CommandType.StoredProcedure);
            return dsEmp;
        }
        public void UpdateL_Employee_Temp(ArrayList vArryIn)
        {
            Save("L_Employee_Temp_U", CommandType.StoredProcedure, vArryIn);
        }
        public void Select_Employee_Temp()
        {
            Fetch("L_Employee_Temp_I", CommandType.StoredProcedure);
        }
        
        public void UpdateEmpDoR(ArrayList vArryIn, int flgtp)
        {
            if (flgtp == 1)
            {
                Save("L_EmployeeDet_U4", CommandType.StoredProcedure, vArryIn);
            }
            else
            {
                Save("L_EmployeeDet_U5", CommandType.StoredProcedure, vArryIn);
            }
        }
        public DataSet FillAccYearWise(ArrayList vArryIn)
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("L_EmployeeDet_S20", CommandType.StoredProcedure, vArryIn);
            return dsEmp;
        }
        public void saveNomineeDet(ArrayList arr)
        {
            try
            {
                Save("NomineeDet_I", CommandType.StoredProcedure, arr);          
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet getNomDet(ArrayList vArryIn)
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("NomineeDet_S1", CommandType.StoredProcedure, vArryIn);
            return dsEmp;
        }
        public DataSet delNomDet(ArrayList vArryIn)
        {
            DataSet dsEmp = new DataSet();
            dsEmp = Fetch("NomineeDet_D", CommandType.StoredProcedure, vArryIn);
            return dsEmp;
        }
    }
}
