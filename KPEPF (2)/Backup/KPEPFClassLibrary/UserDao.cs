using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
    public class UserDao : KPEPFDAOBase
    {
        //public void CreateUser(User newuser)
        //{
        //    //KMPECPFDAOBase suser = new KMPECPFDAOBase();

        //    ArrayList VarryIn = new ArrayList();
        //    VarryIn.Add(newuser.ChvPauNo);
        //    VarryIn.Add(newuser.IntDesigId);
        //    VarryIn.Add(newuser.IntUserTypeId);
        //    VarryIn.Add(newuser.ChvUser);
        //    VarryIn.Add(newuser.ChvPassword);
        //    //VarryIn.Add(newuser.IntLBId);
        //    Save("M_User_I", CommandType.StoredProcedure, VarryIn);
        //}
        //public DataSet CheckUser(ArrayList varyin)
        //{
        //    DataSet ds = new DataSet();
        //    ds = Fetch("M_User_S1", CommandType.StoredProcedure, varyin);
        //    return ds;
        //}
        //public DataSet FillSeat()
        //{
        //    DataSet dsLb = new DataSet();
        //    dsLb = Fetch("M_Seat_S1", CommandType.StoredProcedure);
        //    return dsLb;
        //}

        //public DataSet GetUserAccnts(int intLBId)
        //{
        //    DataSet dsUsrAcnts = new DataSet();
        //    ArrayList VaryIn = new ArrayList();
        //    VaryIn.Add(intLBId);
        //    dsUsrAcnts = Fetch("M_User_S2", CommandType.StoredProcedure, VaryIn);
        //    return dsUsrAcnts;
        //}
        public DataSet GetUserType(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_UserType_S1", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetUserDet(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S4", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void CreateUser(ArrayList ar)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("L_User_I", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CheckOldPwd(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S6", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet GetUserName(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S7", CommandType.StoredProcedure, ar);
            return ds;
        }
        public void DisableUser(ArrayList ar)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Fetch("L_User_U1", CommandType.StoredProcedure, ar);
            }
            catch (Exception E)
            {
                throw new Exception("Check the Error" + E.Message);
            }
        }
        public DataSet CheckValidity(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S8", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet CheckDupUserName(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S9", CommandType.StoredProcedure, ar);
            return ds;
        }
        public DataSet CheckDirTvmUser(ArrayList ar)
        {
            DataSet ds = new DataSet();
            ds = Fetch("L_User_S10", CommandType.StoredProcedure, ar);
            return ds;
        }
    }
}
