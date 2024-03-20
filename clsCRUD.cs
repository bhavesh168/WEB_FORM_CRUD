using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB_FORM_CRUD
{
    public class clsCRUD
    {
        string conn_STR = ConfigurationManager.ConnectionStrings["CON_STR"].ConnectionString;

        public void InsertRecord(string FirstName, string LastName, string MobileNo)
        {
            string Query = "INSERT INTO CRUD(FirstName,LastName,MobileNo) VALUES (@FirstName,@LastName,@MobileNo);";
            using (SqlConnection conn = new SqlConnection(conn_STR))
            {
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@MobileNo", MobileNo);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conn_STR))
            {
                string Query = "SELECT * FROM CRUD ORDER BY ID DESC";

                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    conn.Close();
                }
            }

                return dt;
        }

        public void UpdateRecord(int ID,string FirstName, string LastName, string MobileNo)
        {
            string Query = "UPDATE CRUD SET FirstName = @FirstName, LastName = @LastName, MobileNo = @MobileNo WHERE ID = @ID;";
            using (SqlConnection conn = new SqlConnection(conn_STR))
            {
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public DataTable GetDataByID(int ID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conn_STR))
            {
                string Query = "SELECT * FROM CRUD WHERE ID = @ID ";

                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    conn.Close();
                }
            }

            return dt;
        }

        public void DeleteRecord(int ID)
        {
            string Query = "DELETE FROM CRUD WHERE ID = @ID;";
            using (SqlConnection conn = new SqlConnection(conn_STR))
            {
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}