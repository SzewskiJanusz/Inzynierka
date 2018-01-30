using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Inzynierka_aplikacja
{
    public abstract class SQL
    {
        private const string mainConstr =
            "Data Source=OLEK\\SQLEXPRESS2016;" +
            "Initial Catalog=InzDB;" +
            "User ID=sa";



        public static DataTable DoQuery(String a)
        {
            DataTable result = new DataTable(); // deklaracja i utworzenie instancji obiektu DataTable o nazwie dt
            SqlDataReader dr; // deklaracja obiektu SqlDataReader o nazwie dr
            SqlCommand sqlc; // Deklaracja obiektu SqlCOmmand
            sqlc = new SqlCommand(a);
            sqlc.Connection = new SqlConnection(mainConstr);
            sqlc.Connection.Open();
            dr = sqlc.ExecuteReader(); //wykonanie zapytanie i utworzenie wskaznika dr
            result.Load(dr); //zaladowanie danych do obiektu DataTAble
            sqlc.Connection.Close();
            return result;
        }

        
    }
}
