﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingHeart.DataLayer
{
    public class DataAccess
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();
            }
        }

        public static SqlParameter AddParameter(string parameterName, object value, SqlDbType DbType, int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.Value = value.ToString();
            param.Size = size;
            param.SqlDbType = DbType;
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public static DataTable ExecuteDTByProcedure(string ProcedureName, SqlParameter[] Params)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString());
            SqlCommand cmd= new SqlCommand();
            cmd.CommandText = ProcedureName;
            cmd.Connection = con;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            try
            {
                adopter.Fill(dTable);
            }
            catch (Exception ex)
            {
            }
            finally 
            {   //disposing the objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Dispose();
            }
            return dTable;
 
        }
    }
}