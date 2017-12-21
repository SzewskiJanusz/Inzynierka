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
        public static DataTable DoQuery(String a)
        {
            string constr = "Data Source=OLEK\\SQLEXPRESS2016;" +
                "Initial Catalog=InzynierkaDB;" +
                "Persist Security Info=True;" +
                "User ID=sa";

            DataTable result = new DataTable(); // deklaracja i utworzenie instancji obiektu DataTable o nazwie dt
            SqlDataReader dr; // deklaracja obiektu SqlDataReader o nazwie dr
            SqlCommand sqlc; // Deklaracja obiektu SqlCOmmand
            sqlc = new SqlCommand(a);
            sqlc.Connection = new SqlConnection(constr);
            sqlc.Connection.Open();
            dr = sqlc.ExecuteReader(); //wykonanie zapytanie i utworzenie wskaznika dr
            result.Load(dr); //zaladowanie danych do obiektu DataTAble
            sqlc.Connection.Close();
            return result;
        }

        public static DataTable GetStates()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Janusz\Desktop\STUDIA\Inzynierka\Inzynierka_aplikacja\Inzynierka_aplikacja\SupportLocalDB\Wojewodztwa.mdf;Integrated Security=True";

            DataTable result = new DataTable(); // deklaracja i utworzenie instancji obiektu DataTable o nazwie dt
            SqlDataReader dr; // deklaracja obiektu SqlDataReader o nazwie dr
            SqlCommand sqlc; // Deklaracja obiektu SqlCOmmand
            sqlc = new SqlCommand("SELECT nazwa FROM Wojewodztwo");
            sqlc.Connection = new SqlConnection(constr);
            sqlc.Connection.Open();
            dr = sqlc.ExecuteReader(); //wykonanie zapytanie i utworzenie wskaznika dr
            result.Load(dr); //zaladowanie danych do obiektu DataTAble
            sqlc.Connection.Close();
            return result;
        }
    }
}
