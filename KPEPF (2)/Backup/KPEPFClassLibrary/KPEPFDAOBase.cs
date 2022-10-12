using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;
namespace KPEPFClassLibrary
{
    public class KPEPFDAOBase
    {

        public SqlConnection con1 = new SqlConnection();
        public static string connectionString;
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }

        }

        public KPEPFDAOBase()
        {

            //if (con1.State == ConnectionState.Open)
            //{
            //    con1.Close();
            //    System.GC.Collect();
            //}
            //connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConString"].ToString();
            //con1 = new SqlConnection(ConnectionString);
            //con1.Open();
        }
        ~KPEPFDAOBase()
        {


        }

        private  SqlConnection OpenConnection()
        {
            //SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            //System.GC.Collect();   
            connectionString = ConfigurationSettings.AppSettings["ConString"].ToString();
            con1 = new SqlConnection(ConnectionString);
            con1.Open();
            return con1;
        }

        private SqlCommand CreateCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = OpenConnection();//con1;
            return cmd;
        }
        protected long Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        {
            int recAffected = 0;
            //SqlConnection con = new SqlConnection(connectionString);
            SqlCommand sqlCmd = CreateCommand();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                recAffected = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
            return recAffected;
        }
        protected void Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN, DataSet ds)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd = CreateCommand();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
        }
        protected void Save(string sqlQuery, CommandType cmdtype, DataSet ds)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd = CreateCommand();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
        }
        protected int Edit(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        {
            int recAffected = 0;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;

                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                recAffected = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ edit " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
            return recAffected;
        }
        protected DataSet Fetch(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = CreateCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;

                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
        }
        protected DataSet Fetch(string sqlQuery, CommandType cmdtype)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = CreateCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
        }
        protected void Delete(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        {
            SqlCommand sqlCmd = CreateCommand();
            try
            {
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con1.Close();
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data.SqlClient;
//using System.Collections;
//using System.Data;

//namespace KASPFClassLibrary
//{
//    public class KASPFDAOBase
//    {
//        //private int flgDBType;
//        public SqlConnection con1 = new SqlConnection();
//        public static string connectionString;
//       // public string connectionString;
//        public static string ConnectionString
//        {
//            get
//            {
//                return connectionString;
//            }
//            set
//            {
//                connectionString = value;
//            }

//        }
//        public KASPFDAOBase()
//        {
//            //if (con1.State == ConnectionState.Open)
//            //{
//            //    con1.Close();
//            //    System.GC.Collect();
//            //}
//            //connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConStringKASPF"].ToString();
//            //con1 = new SqlConnection(ConnectionString);
//            //con1.Open(); 
//            //**************************************************************
            
            
//            if(con1.State==ConnectionState.Open )
//            {
//                con1.Close();
//                System.GC.Collect();  
//            }
//            if (ConnectionString != null)
//            {
//            con1 = new SqlConnection(ConnectionString);  
//            con1.Open();
//            }
//        }
//        public void  SetConn(int flgDBType)
//        {
//            if (flgDBType == 1)
//                connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConStringKPEPF"].ToString();
//            else if (flgDBType == 2)
//                connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConStringKASPF"].ToString();
//            else if (flgDBType == 3)
//                connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConStringKMPECPF"].ToString();
//            else
//                connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConStringKPEPF"].ToString();
//        }
//        ~KASPFDAOBase()
//        {
            
                
//        }

//        //private static SqlConnection OpenConnection()
//        //{
//        //    SqlConnection con = new SqlConnection(connectionString);
//        //    con.Open();
//        //    System.GC.Collect();   
//        //    return con;
//        //}

//        private SqlCommand CreateCommand()
//        {
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = con1;
//            return cmd;
//        }

//        protected int Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
//        {
//            int recAffected = 0;
//            //SqlConnection con = new SqlConnection(connectionString);
//            SqlCommand sqlCmd = CreateCommand();
//          try
//            {
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;
//                SqlCommandBuilder.DeriveParameters(sqlCmd);
//                for (int i = 0; i < arrIN.Count; i++)
//                {
//                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
//                }
//                recAffected = sqlCmd.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ save " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
//            }
//            return recAffected;
//        }

//        protected void Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN, DataSet ds)
//        {
           
//            SqlDataAdapter da = new SqlDataAdapter();
//            SqlCommand sqlCmd = CreateCommand(); 
//            try
//            {
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;
//                SqlCommandBuilder.DeriveParameters(sqlCmd);
//                for (int i = 0; i < arrIN.Count; i++)
//                {
//                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
//                }
//                da.SelectCommand = sqlCmd;
//                da.Fill(ds, "Rec");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ save " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
//            }
//        }

//        protected void Save(string sqlQuery, CommandType cmdtype, DataSet ds)
//        {
            
//            SqlDataAdapter da = new SqlDataAdapter();
//            SqlCommand sqlCmd = CreateCommand(); 
//            try
//            {
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;
//                da.SelectCommand = sqlCmd;
//                da.Fill(ds, "Rec");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ save " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
               
//            }
//        }

//        protected int Edit(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
//        {
//            int recAffected = 0;
//            SqlCommand sqlCmd = new SqlCommand();
//            try
//            {
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;

//                SqlCommandBuilder.DeriveParameters(sqlCmd);
//                for (int i = 0; i < arrIN.Count; i++)
//                {
//                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
//                }
//                recAffected = sqlCmd.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ edit " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
               
//            }
//            return recAffected;
//        }

//        protected DataSet Fetch(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
//        {

//            SqlDataAdapter da = new SqlDataAdapter();
//            DataSet ds = new DataSet();
//            SqlCommand sqlCmd = CreateCommand(); 
//            ArrayList arrList = new ArrayList();
//            try
//            {
                
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;

//                SqlCommandBuilder.DeriveParameters(sqlCmd);
//                for (int i = 0; i < arrIN.Count; i++)
//                {
//                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
//                }
//                da.SelectCommand = sqlCmd;
//                da.Fill(ds, "Rec");
//                return ds;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ fetch " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
                
//            }
//        }
//        protected DataSet Fetch(string sqlQuery, CommandType cmdtype)
//        {
//            SqlDataAdapter da = new SqlDataAdapter();
//            DataSet ds = new DataSet();
//            SqlCommand sqlCmd = CreateCommand(); 
//            ArrayList arrList = new ArrayList();
//            try
//            {
//                sqlCmd.CommandText = sqlQuery;
//                sqlCmd.CommandType = cmdtype;
//                da.SelectCommand = sqlCmd;
//                da.Fill(ds, "Rec");
//                return ds;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured @ fetch " + ex.Message);
//            }
//            finally
//            {
//                sqlCmd.Dispose();
//            }
//        }
//    }
//}
