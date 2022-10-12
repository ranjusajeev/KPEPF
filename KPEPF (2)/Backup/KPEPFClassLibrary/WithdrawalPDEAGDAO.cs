using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KPEPFClassLibrary
{
  public   class WithdrawalPDEAGDAO : KPEPFDAOBase
    {
      public DataSet  UpdateWithPde1(WithdrawalPDEAG  withdr)
      {
          DataSet ds = new DataSet();
          ArrayList ArrIn1 = new ArrayList();
          ArrIn1.Add(withdr.IntId);
          ArrIn1.Add(withdr.IntAccNo);
          ArrIn1.Add(withdr.IntDesignation);
          ArrIn1.Add(withdr.FltAdvAmt);
          ArrIn1.Add(withdr.ChvSantionNo);
          ArrIn1.Add(withdr.DtSantion);
          ArrIn1.Add(withdr.IntLoan);
          ArrIn1.Add(withdr.DtWithdraw);
          ArrIn1.Add(withdr.FltConsolidate);
          ArrIn1.Add(withdr.IntNoOfInstalments);
          ArrIn1.Add(withdr.FltInstalmentAmt);
          ArrIn1.Add(withdr.IntYrId);
          ArrIn1.Add(withdr.IntModeOfChgId);
          ArrIn1.Add(withdr.IntUserId);
          ArrIn1.Add(withdr.DtmDateOfUpdation);
          ArrIn1.Add(withdr.IntVoucherAGID);
          ArrIn1.Add(withdr.IntLoanPurpose );
          ArrIn1.Add(withdr.IntDrawnBy);
          ArrIn1.Add(withdr.ChvOdrNoDtOfPrevTA);
          ArrIn1.Add(withdr.FltAmtPrevTA);
          ArrIn1.Add(withdr.FltBalancePrevTA);
          ArrIn1.Add(withdr.FlgUnPosted);
          ArrIn1.Add(withdr.IntUnPostedRsn);
          ArrIn1.Add(withdr.Intmid);
          ArrIn1.Add(withdr.IntDisId);
         
          try
          {
              ds = Fetch("Pfo_Withdrawal_I", CommandType.StoredProcedure, ArrIn1);
              return ds;
            
          }
          catch (Exception E)
          {
              throw new Exception("Check the Error" + E.Message);
          }
      }
      public DataSet SaveVoucherAG(WithdrawalPDEAG withdr)
      {
          DataSet ds = new DataSet();
          ArrayList ArrIn1 = new ArrayList();
          ArrIn1.Add(withdr.IntVoucherID);
          ArrIn1.Add(withdr.IntRelMonthWsID);
          ArrIn1.Add(withdr.ChvTENo);
          ArrIn1.Add(withdr.IntDTreaID);
          ArrIn1.Add(withdr.IntVoucherNo);
          ArrIn1.Add(withdr.DtmVoucherDt);
          ArrIn1.Add(withdr.FltAmount);
          ArrIn1.Add(withdr.FlgUnPosted);
          ArrIn1.Add(withdr.IntReasonID);
          ArrIn1.Add(withdr.IntModeOfChgId);
          ArrIn1.Add(withdr.IntUserId);
          ArrIn1.Add(withdr.IntYearID);
          ArrIn1.Add(withdr.IntDrawnBy);
          
          try
          {
              ds = Fetch("AP_VoucherAG_I", CommandType.StoredProcedure, ArrIn1);
              return ds;
          }
          catch (Exception E)
          {
              throw new Exception("Check the Error" + E.Message);
          }
      }
      public DataSet FillDBPlusPDE(ArrayList ArrIn)
      {
          DataSet ds = new DataSet();
          ds = Fetch("Pfo_Withdrawal_S2", CommandType.StoredProcedure, ArrIn);//Chalan_S1
          return ds;
      }
      public DataSet FillDBPlusPDEAddrw(ArrayList ArrIn)
      {
          DataSet ds = new DataSet();
          ds = Fetch("Pfo_Withdrawal_S5", CommandType.StoredProcedure, ArrIn);//Chalan_S1
          return ds;
      }
      public DataSet Getdesignation()
      {
          DataSet ds = new DataSet();
          ds = Fetch("Sp_Desgnation", CommandType.StoredProcedure);
          return ds;
      }
      public DataSet DeleteVoucher(ArrayList ArrIn)
      {
          DataSet ds = new DataSet();
          ds = Fetch("AP_VoucherAG_D", CommandType.StoredProcedure, ArrIn);//Chalan_S1
          return ds;
      }
      public DataSet GetLoanType()
      {
          DataSet ds = new DataSet();
          ds = Fetch("L_LoanType_S1", CommandType.StoredProcedure);
          return ds;
      }
      public DataSet GetLoanPurpose()
      {
          DataSet ds = new DataSet();
          ds = Fetch("Sel_LoanPurpose", CommandType.StoredProcedure);
          return ds;
      }
      public DataSet GetStatus()
      {
          DataSet ds = new DataSet();
          ds = Fetch("Pfo_CmbModeOfChange", CommandType.StoredProcedure);
          return ds;
      }
      public DataSet GetDrawnBy(ArrayList arr)
      {
          DataSet ds = new DataSet();
          
          ds = Fetch("AP_L_DrawnBy_Cmb", CommandType.StoredProcedure,arr);
          return ds;
      }
      public DataSet GetWithdrawaEmp(WithdrawalPDEAG ag)
      {
          DataSet ds = new DataSet();
          ArrayList ar = new ArrayList();
          ar.Add(ag.IntVoucherAGID);
          ds = Fetch("Pfo_Withdrawal_S3", CommandType.StoredProcedure, ar);
          return ds;
      }
      public DataSet GetBillDetails(WithdrawalPDEAG ag)
      {
          DataSet ds = new DataSet();
          ArrayList ar = new ArrayList();
          ar.Add(ag.IntVoucherAGID);
          ds = Fetch("AP_VoucherAG_S1", CommandType.StoredProcedure, ar);
          return ds;
      }
      public DataSet GetDistId(ArrayList ArrIn)
      {
          DataSet ds = new DataSet();
          ds = Fetch("AP_G_TreasuryD_S4", CommandType.StoredProcedure, ArrIn);
          return ds;
      }
      public DataSet GetEmpWsTotal(ArrayList ArrIn)
      {
          DataSet dsB = new DataSet();
          try
          {
              dsB = Fetch("Pfo_Withdrawal_S4", CommandType.StoredProcedure, ArrIn);
              return dsB;
          }
          catch (Exception E)
          {
              throw new Exception("Check the Error" + E.Message);
          }
      }
      public DataSet GetAGRptW(ArrayList ar,int yr)
      {
          DataSet dsAGR = new DataSet();
          if (yr == 1)
          {
              dsAGR = Fetch("AP_Withdrawal_S9", CommandType.StoredProcedure, ar);
          }
          else
          {
              dsAGR = Fetch("TB_ToAG_S2", CommandType.StoredProcedure, ar);
          }
          return dsAGR;
      }
    }
}
