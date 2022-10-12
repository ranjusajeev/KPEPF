using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using KPEPFClassLibrary;

namespace KPEPFClassLibrary
{
    public class MembershipDAO : KPEPFDAOBase
    {
        public DataSet GetOtherFund()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_ProvidentFund_S", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetDesignation()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Designation_S1", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetStatus()
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_NomineeStatus_S", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetRelationship(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("G_Relationship_S", CommandType.StoredProcedure,ArrIn);
            return ds;
        }
        public DataSet GetPostoffice(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("PostOffice_S", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public DataSet GetPinCode(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("PostOffice_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public void CreateMembership(Membership Memb)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(Memb.NumMembershipReqID);
            ArryIn.Add(Memb.IntInstID);
            ArryIn.Add(Memb.ChvEmployeeName);
            ArryIn.Add(Memb.IntDesigID);
            ArryIn.Add(Memb.IntGender);
            ArryIn.Add(Memb.DtmDOB);
            ArryIn.Add(Memb.FltBasicPay);
            ArryIn.Add(Memb.FltSubscription);
            ArryIn.Add(Memb.DtmSubStartDate);
            ArryIn.Add(Memb.IntOtherFund);
            ArryIn.Add(Memb.FlgMarried);
            ArryIn.Add(Memb.FlgPensionable);
            ArryIn.Add(Memb.IntNominees);
            ArryIn.Add(Memb.NumEmpId);
            ArryIn.Add(Memb.DtmDateOfRequest);
            ArryIn.Add(Memb.ChvFileNo);
            ArryIn.Add(Memb.NumEmpId);
            ArryIn.Add(Memb.DtmDOJ);
            ArryIn.Add(Memb.IntAadhaar);
            ArryIn.Add(Memb.ChvPFNo);
            ArryIn.Add(Memb.IntBankType);
            ArryIn.Add(Memb.IntBankBranch);
            ArryIn.Add(Memb.ChvBankAccNo);
            try
            {
                Save("MembershipRequest_I", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error!" + E.Message);
            }
        }
        public void MembershipAddress1(Membership memb)
        {
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(memb.NumMembershipReqID);
            ArryIn.Add(memb.IntAddressTypeID );
            ArryIn.Add(memb.IntSlNo );
            ArryIn.Add(memb.IntSlNoRep);
            ArryIn.Add(memb.ChvName );
            ArryIn.Add(memb.IntWardNo );
            ArryIn.Add(memb.IntDoorNo );
            ArryIn.Add(memb.rANo);
            ArryIn.Add(memb.ChvBldgName );
            ArryIn.Add(memb.ChvLocalPlace );
            ArryIn.Add(memb.ChvMainPlace );
            ArryIn.Add(memb.streetName);
            ArryIn.Add(memb.IntPincode );
            ArryIn.Add(memb.IntDistrict );
            ArryIn.Add(memb.IntPO);
            ArryIn.Add(memb.IntState);
            try
            {
                Save("MembershipAddress_I1", CommandType.StoredProcedure, ArryIn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdAddress(ArrayList ar)
        {
            
            try
            {
                Save("MembershipAddress_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void DeleteAddress(ArrayList arr,int intType)
        {
            try
            {
                if (intType == 1)
                {
                    Delete("MembershipAddress_D1", CommandType.StoredProcedure, arr);
                }
                else
                {
                    Delete("MembershipAddress_D2", CommandType.StoredProcedure, arr);
                }
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }

        public DataSet GetAddress(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipAddress_S1", CommandType.StoredProcedure, ArrIn);
            return ds;
        }
        public long CreateNomineeDetails(Membership memb)
        {
            DataSet dsNom = new DataSet();
            long intNomId;
            ArrayList ArryIn = new ArrayList();
            ArryIn.Add(memb.NumMembershipReqID);
            ArryIn.Add(memb.IntNomineeSlNo);
            ArryIn.Add(memb.ChvNomineeName);
            ArryIn.Add(memb.IntRelation );
            ArryIn.Add(memb.IntAge);
            ArryIn.Add(memb.FltShare );
            ArryIn.Add(memb.IntStatus );
            ArryIn.Add(memb.IntReplacerRelation);
            ArryIn.Add(memb.IntReplacerAge);
            ArryIn.Add(memb.ChvRepName);
            ArryIn.Add(memb.NumEmpId);
            try
            {
                //intNomId = Save("Nominee_I", CommandType.StoredProcedure, ArryIn);
                dsNom = Fetch("Nominee_I", CommandType.StoredProcedure, ArryIn);
                if (dsNom.Tables[0].Rows.Count > 0)
                {
                    intNomId = Convert.ToInt64(dsNom.Tables[0].Rows[0].ItemArray[0].ToString());
                }
                else
                {
                    intNomId = 0;
                }
                return intNomId;
            }
                
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        
        public void DeleteNominee(Membership membR)
        {
            ArrayList ArryInDn = new ArrayList();
            ArryInDn.Add(membR.NumMembershipReqID);
            ArryInDn.Add(membR.IntSlNo);
            try
            {
                Fetch("Nominee_D", CommandType.StoredProcedure, ArryInDn);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet GetInBoxMem(ArrayList ArrIn)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipRequest_S2", CommandType.StoredProcedure, ArrIn);
            return ds;
        }

        public DataSet DisplayMemDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipRequest_S1", CommandType.StoredProcedure, ar);
            //ds = Fetch("MembershipRequest_S3", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet DisplayNominiDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Nominee_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        //public DataSet DisplayNominiChgDet(ArrayList ar)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("NomRequest_S3", CommandType.StoredProcedure, ar);
        //    return ds;
        //}
        public DataSet FillNomineeStatus()
        {
            DataSet dsNom = new DataSet();
            dsNom = Fetch("G_NomineeStatus_S1", CommandType.StoredProcedure);
            return dsNom;
        }
        public DataSet DisplayReplacer(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("Replacer_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet DisplayWitness(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("MembershipAddress_S2", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet Displayapprovedfiles(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_EmployeeDet_S9", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void UpdateEmpIdToNominee(ArrayList ar)
        {
            try
            {
                Save("Nominee_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void UpdateEmpIdToMembership(ArrayList ar)
        {
            try
            {
                Save("MembershipRequest_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveHISAndDel(ArrayList ar)
        {
            try
            {
                Save("Nominee_H_I", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveToNomTemp(ArrayList ar)
        {
            try
            {
                Save("NomineeTemp_I", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void SaveNomineeAddress(ArrayList ar)
        {
            try
            {
                Save("AddressNomChg_I1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public void DeleteFromTemp(ArrayList ar)
        {
            try
            {
                Save("NomineeTemp_U", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
    }
}
