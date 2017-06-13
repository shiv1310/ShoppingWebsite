using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingHeart.BussinessLayer
{
    public class ShoppingCart
    {
        public string CategoryName;
        public int CategoryID;
        public int ProductID;
        public int CustomerID;

        public string ProductName;
        public string ProductImage;
        public string ProductDescription;
        public int ProductPrice;
        public int TotalProducts;

        public string CustomerName;
        public string CustomerEmailID;
        public string CustomerAddress;
        public string CustomerPhoneNo;
        public int TotalPrice;
        public string ProductList;
        public string PaymentMethod;

        public string OrderStatus;
        public string OrderNo;

        public int StockType;
        public int Flag;


        public void AddNewProduct()
        {
            SqlParameter[] parameter = new SqlParameter[6];
            parameter[0] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameter[2] = DataLayer.DataAccess.AddParameter("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameter[3] = DataLayer.DataAccess.AddParameter("@ProductImage", ProductImage, System.Data.SqlDbType.VarChar, 500);
            parameter[1] = DataLayer.DataAccess.AddParameter("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameter[4] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameter[5] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllProduct", parameter);
 
        }
        public void AddNewCategory()
        {
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = DataLayer.DataAccess.AddParameter("@CategoryName",CategoryName,System.Data.SqlDbType.VarChar,200);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewCategory", parameter);

        }

        public int UpdateNewProduct()
        {/*
            SqlParameter[] parameter = new SqlParameter[6];
            parameter[0] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameter[2] = DataLayer.DataAccess.AddParameter("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameter[3] = DataLayer.DataAccess.AddParameter("@ProductImage", ProductImage, System.Data.SqlDbType.VarChar, 500);
            parameter[1] = DataLayer.DataAccess.AddParameter("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameter[4] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameter[5] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_UpdateProduct", parameter);*/

        String cs1 = System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ToString();
        SqlConnection con = new SqlConnection(cs1);
        SqlCommand cmd = new SqlCommand();
        SqlParameter sp1 = new SqlParameter("@Name", SqlDbType.VarChar);
        sp1.Value=ProductName;
        SqlParameter sp2 = new SqlParameter("@ProductID", SqlDbType.Int);
        sp2.Value = ProductID;
        SqlParameter sp3 = new SqlParameter("@Description", SqlDbType.VarChar);
        sp3.Value = ProductDescription;
        SqlParameter sp4 = new SqlParameter("@Price", SqlDbType.Int);
        sp4.Value = ProductPrice;
        SqlParameter sp5 = new SqlParameter("@Image", SqlDbType.VarChar);
        sp5.Value = ProductImage;
        SqlParameter sp6 = new SqlParameter("@CategoryID", SqlDbType.Int);
        sp6.Value = CategoryID;
        SqlParameter sp7 = new SqlParameter("@TotalProducts", SqlDbType.VarChar);
        sp7.Value = TotalProducts;
        cmd.Parameters.Add(sp1);
        cmd.Parameters.Add(sp2);
        cmd.Parameters.Add(sp3);
        cmd.Parameters.Add(sp4);
        cmd.Parameters.Add(sp5);
        cmd.Parameters.Add(sp6);
        cmd.Parameters.Add(sp7);
        cmd.Connection = con;
        cmd.CommandText = "update Products_new set Name=@Name, Description=@Description, Price=@Price, Image=@Image,CategoryID=@CategoryID,TotalProducts=@TotalProducts where ProductID=@ProductID ";
        con.Open();
        int a = cmd.ExecuteNonQuery();
        con.Close();
        return a;
        }
        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllCategory",parameters);
            return dt;

        }
        public DataTable GetAllProducts()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 20);
            DataTable dt= DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetProducts",parameters);
            return dt;
        }

        internal DataTable SaveCustomerDetails()
        {
            SqlParameter[] parameter = new SqlParameter[7];
            parameter[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameter[1] = DataLayer.DataAccess.AddParameter("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameter[2] = DataLayer.DataAccess.AddParameter("@CustomerPhoneNo", CustomerPhoneNo, System.Data.SqlDbType.VarChar, 10);
            parameter[3] = DataLayer.DataAccess.AddParameter("@CustomerAddress", CustomerAddress, System.Data.SqlDbType.VarChar, 500);
            parameter[4] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            parameter[5] = DataLayer.DataAccess.AddParameter("@TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 100);
            parameter[6] = DataLayer.DataAccess.AddParameter("@PaymentMethod", PaymentMethod, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerDetails", parameter);
            return dt; 
        }
       

        internal void SaveCustomerProducts()
        {
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = DataLayer.DataAccess.AddParameter("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 20);
            parameter[1] = DataLayer.DataAccess.AddParameter("@ProductID", ProductID, System.Data.SqlDbType.Int, 20);
            parameter[2] = DataLayer.DataAccess.AddParameter("@TotalProduct",TotalProducts, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerProducts", parameter);
             
        }
    }
}