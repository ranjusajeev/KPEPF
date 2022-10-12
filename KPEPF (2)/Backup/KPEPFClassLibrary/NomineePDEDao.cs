using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using KPEPFClassLibrary;

namespace KPEPFClassLibrary
{
    public class NomineePDEDao : KPEPFDAOBase
    {
        public DataSet GetNomPdeList(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S6", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetMemDetails(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipRequest_S3", CommandType.StoredProcedure, ar);
            return ds;
        }
        //public void CreateMembershipDetails(Membership Memb)
        //{
        //    ArrayList ArryIn = new ArrayList();
        //    ArryIn.Add(Memb.numEmpId);
        //    ArryIn.Add(Memb.intInstID);
        //    ArryIn.Add(Memb.chvEmployeeName);
        //    ArryIn.Add(Memb.intDesigID);
        //    ArryIn.Add(Memb.intGender);
        //    ArryIn.Add(Memb.dtmDOB);
        //    ArryIn.Add(Memb.fltBasicPay);
        //    ArryIn.Add(Memb.fltSubscription);
        //    ArryIn.Add(Memb.dtmSubStartDate);
        //    ArryIn.Add(Memb.intOtherFund);
        //    ArryIn.Add(Memb.flgMarried);
        //    ArryIn.Add(Memb.flgPensionable);
        //    ArryIn.Add(Memb.intNominees);
        //    ArryIn.Add(Memb.intUesrID);
        //    try
        //    {
        //        Save("MembershipRequest_I1", CommandType.StoredProcedure, ArryIn);
        //    }
        //    catch (Exception E)
        //    {
        //        throw new Exception("Check the Error!" + E.Message);
        //    }
        //}
        public void CreateNomineeDetailsPDE(Membership memb)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(memb.NumEmpId);
            ArryIn.Add(memb.IntSlNo);
            //ArryIn.Add(memb.ChvNomineeName);
            ArryIn.Add(memb.IntRelation);
            ArryIn.Add(memb.IntAge);
            ArryIn.Add(memb.FltShare);
            ArryIn.Add(memb.IntStatus);
            ArryIn.Add(memb.IntReplacerRelation);
            ArryIn.Add(memb.IntReplacerAge);
            try
            {
                Save("NomineePDE_I", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void CreateNomChg(NomChg nom)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(nom.NumTrnID);
            ArryIn.Add(nom.NumEmpID);
            ArryIn.Add(nom.IntNomineeSlNo);
            ArryIn.Add(nom.ChvNomineeName);
            ArryIn.Add(nom.IntRelation);
            ArryIn.Add(nom.IntAge);
            ArryIn.Add(nom.FltShare);
            ArryIn.Add(nom.IntStatus);
            ArryIn.Add(nom.ChvRepName);
            ArryIn.Add(nom.IntReplacerRelation);
            ArryIn.Add(nom.IntReplacerAge);
            ArryIn.Add(nom.IntSlNo);
            try
            {
                Save("NomRequest_I", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateNomTemp(NomChg nom)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(nom.NumTrnID);
            ArryIn.Add(nom.NumEmpID);
            ArryIn.Add(nom.IntNomineeSlNo);
            ArryIn.Add(nom.ChvNomineeName);
            ArryIn.Add(nom.IntRelation);
            ArryIn.Add(nom.IntAge);
            ArryIn.Add(nom.FltShare);
            ArryIn.Add(nom.IntStatus);
            ArryIn.Add(nom.ChvRepName);
            ArryIn.Add(nom.IntReplacerRelation);
            ArryIn.Add(nom.IntReplacerAge);
            ArryIn.Add(nom.FlgNomChange);
            try
            {
                Save("NomineeTemp_I1", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetSlNo(ArrayList arSl)
        {
            DataSet dsSl = new DataSet();
            dsSl = Fetch("NomRequest_S4", CommandType.StoredProcedure, arSl);
            return dsSl;
        }
        //public DataSet GetNomChg(ArrayList arChg)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("NomRequest_S1", CommandType.StoredProcedure, arChg);
        //    return ds;
        //}
        public DataSet GetNomChg(ArrayList arChg)
        {
            DataSet ds = new DataSet();
            ds = Fetch("NomineeTemp_S1", CommandType.StoredProcedure, arChg);
            return ds;
        }
        //public DataSet GetNomChgTrnWs(ArrayList arChg)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("NomineeTemp_S1", CommandType.StoredProcedure, arChg);
        //    return ds;
        //}
        public DataSet GetNomChgPdeList(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S7", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetNomChgEmpIdWs(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Nominee_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetNomChgEmpIdWsTemp(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("NomineeTemp_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void CreateAddressNomChg(Membership memb)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(memb.NumMembershipReqID);
            ArryIn.Add(memb.IntAddressTypeID);
            ArryIn.Add(memb.IntSlNo);
            ArryIn.Add(memb.IntSlNoRep);
            ArryIn.Add(memb.ChvName);
            ArryIn.Add(memb.IntWardNo);
            ArryIn.Add(memb.IntDoorNo);
            ArryIn.Add(memb.rANo);
            ArryIn.Add(memb.ChvBldgName);
            ArryIn.Add(memb.ChvLocalPlace);
            ArryIn.Add(memb.ChvMainPlace);
            ArryIn.Add(memb.streetName);
            ArryIn.Add(memb.IntPincode);
            ArryIn.Add(memb.IntDistrict);
            ArryIn.Add(memb.NumEmpId);
            ArryIn.Add(memb.IntPO );
            ArryIn.Add(memb.IntState);

            try
            {
                Save("AddressNomChg_I", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public DataSet GetAddressNomChg(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("AddressNomChg_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetAddressNom(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipAddress_S3", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetInwrdDet(ArrayList ArrIn)
        {
            DataSet dsi = new DataSet();
            dsi = Fetch("MembershipAddress_S3", CommandType.StoredProcedure, ArrIn);
            return dsi;
        }
        public DataSet GetInBoxNomChg(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("NomRequest_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
    }
}
