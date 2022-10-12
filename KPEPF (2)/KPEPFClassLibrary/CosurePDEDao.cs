using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace KPEPFClassLibrary
{
   public  class closurePDEDao : KPEPFDAOBase  
    {
       public DataSet CreateClosureDetails(ClosurePDE  clsr)
       {
           DataSet ds = new DataSet();
           ArrayList vArr = new ArrayList();
           vArr.Add(clsr.IntDistId);
           vArr.Add(clsr.IntAccNo);
           vArr.Add(clsr.IntYearId);
           vArr.Add(clsr.ChvOrderNoDate);
           vArr.Add(clsr.DtmMonthYear);
           vArr.Add(clsr.FltAmount);
           vArr.Add(clsr.IntSubSlNo);
           vArr.Add(clsr.FlgPartPayment);
           vArr.Add(clsr.IntId);
           vArr.Add(clsr.ChvSubSlNo);
           vArr.Add(clsr.ChvRemarks);
           vArr.Add(clsr.IntTCType);

           vArr.Add(clsr.DtmRetired);
           vArr.Add(clsr.DtmInerest);
           try
           {
               ds = Fetch("Pfo_ClosureDetails_TRN_I", CommandType.StoredProcedure, vArr);
               //return ds;

               //long dd = Save("Pfo_ClosureDetails_TRN_I", CommandType.StoredProcedure, vArr);
           }
           catch (Exception E)
           {
              
               //ScriptManager.RegisterStartupScript(this, GetType(), err, "alert('Check the Error!!!');", true);
               //throw new Exception("Check the Error!!!" + E.Message);
           }
           return ds;
       }
       public DataSet FillClosureDet(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_ClosureDetails_TRN_S1", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillClosureDetAcc(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_ClosureDetails_TRN_S5", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FindSubSlno(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_SelectSubSlNo", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillClosureDetInd(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_ClosureDetails_TRN_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet CheckAccNoDistWise(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_CheckAccNoDistWise", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet CheckDupWithPartPayment(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_CheckDupWithPartPayment", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet FillClosureDetSort(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_ClosureDetails_TRN_S3", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       public DataSet lSubUpdEmp_MST(ClosurePDE clsr)
       {
           DataSet ds = new DataSet();
           ArrayList vArr = new ArrayList();
           vArr.Add(clsr.IntAccNo);
           vArr.Add(1);
           try
           {
               Save("Pfo_UpdEmpMSTFlag", CommandType.StoredProcedure, vArr);
               return ds;
           }
           catch (Exception E)
           {
               throw new Exception("Check the Error!!!" + E.Message);
           }
       }
       public void  DelClosureDetails(ArrayList ar)
       {
           try
           {
               Save("Pfo_ClosureDetails_TRN_D", CommandType.StoredProcedure, ar);
           }
           catch (Exception E)
           {
               throw new Exception("Check the Error!!!" + E.Message);
           }
       }
       public DataSet ClosureDetPrint(ArrayList ArrIn)
       {
           DataSet ds = new DataSet();
           ds = Fetch("Pfo_ClosureDetails_TRN_S7", CommandType.StoredProcedure, ArrIn);//Chalan_S1
           return ds;
       }
       
       //public DataSet FillClosureDetFilter(ArrayList ArrIn)
       //{
       //    DataSet ds = new DataSet();
       //    ds = Fetch("Pfo_ClosureDetails_TRN_S4", CommandType.StoredProcedure, ArrIn);//Chalan_S1
       //    return ds;
       //}
    }
}
