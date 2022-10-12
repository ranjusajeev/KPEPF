using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
  public  class AOApprovalDAO : KPEPFDAOBase
    {
      public DataSet GetAOGridWith(ArrayList arr)
      {
          DataSet  ds = new DataSet();
          ds = Fetch("Bill_S5", CommandType.StoredProcedure, arr);
          return ds;
      }
      public DataSet GetReason(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("AP_L_MisclassificationReason_Cmb ", CommandType.StoredProcedure, arr);
          return ds;
      }
      public DataSet FillBillGrid(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("Withdrawals_S3", CommandType.StoredProcedure, arr);
          return ds;
      }
      public DataSet FillChalanGrid(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("ScheduleTR104_S1", CommandType.StoredProcedure, arr);
          return ds;
      }
      public DataSet GetAOGridRem(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("Chalan_S13", CommandType.StoredProcedure, arr);
          return ds;
      }

      public DataSet GetTreasuryD(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("TreasuryD_S1", CommandType.StoredProcedure, arr);
          return ds;
      }
      public DataSet GetApprovalCurr(ArrayList arr)
      {
          DataSet ds = new DataSet();
          ds = Fetch("TreasuryD_S5", CommandType.StoredProcedure, arr);
          return ds;
      }
      public void UpdateflagApp(ArrayList arr)
      {
          try
          {
              Save("TreasuryD_U1", CommandType.StoredProcedure, arr);
          }
          catch (Exception E)
          {
              throw new Exception("Check the Error" + E.Message);
          }
      }

    }
}
