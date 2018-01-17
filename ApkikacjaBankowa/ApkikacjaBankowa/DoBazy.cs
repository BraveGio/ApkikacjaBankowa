using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
using System.Xml;

namespace ApkikacjaBankowa
{
    public class DoBazy
    {
        public string id;
        public int wartoscId;

        string connectionstring =
            " Data Source=abd.wwsi.edu.pl;Initial Catalog = jippZ507; User ID = jippakita; Password=qazwsx123456";

        public void logowanie(string login, string haslo)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand data = new SqlCommand("logowanie1", con);
                data.Parameters.AddWithValue("@login", login);
                data.Parameters.AddWithValue("@haslo", haslo);
                SqlParameter outputppar = new SqlParameter();
                outputppar.ParameterName = "@id";
                outputppar.SqlDbType = System.Data.SqlDbType.Int;
                outputppar.Direction = System.Data.ParameterDirection.Output;
                data.Parameters.Add(outputppar);
                data.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                data.ExecuteNonQuery();
                id = outputppar.Value.ToString();
                wartoscId = Convert.ToInt32(id);
                con.Close();
            }
        }
        public string[] odczytstanów(int id)
        {

        string[] dane= new string[3];
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand stany = new SqlCommand("stany", con);
                stany.Parameters.AddWithValue("@id", id);
                SqlParameter saldo = new SqlParameter();
                saldo.ParameterName = "@saldo";
                saldo.SqlDbType = System.Data.SqlDbType.Money;
                saldo.Direction = System.Data.ParameterDirection.Output;
                stany.Parameters.Add(saldo);
                SqlParameter dostepne = new SqlParameter();
                dostepne.ParameterName = "@dostepne";
                dostepne.SqlDbType = System.Data.SqlDbType.Money;
                dostepne.Direction = System.Data.ParameterDirection.Output;
                stany.Parameters.Add(dostepne);
                SqlParameter zablokowane = new SqlParameter();
                zablokowane.ParameterName = "@zablokowane";
                zablokowane.SqlDbType = System.Data.SqlDbType.Money;
                zablokowane.Direction = System.Data.ParameterDirection.Output;
                stany.Parameters.Add(zablokowane);
                stany.CommandType = System.Data.CommandType.StoredProcedure;
             con.Open();
                stany.ExecuteReader();
                dane[0] = saldo.Value.ToString();
                dane[1] = dostepne.Value.ToString();
                dane[2] = zablokowane.Value.ToString();
            con.Close();
                
            }
            return dane;
    }

        public List<Operacja> lista5operacji(int id)
        {

            List<Operacja> listaop =new List<Operacja>();
            SqlCommand piecoperSqlCommand =new SqlCommand("Select * from [JiPPakita].[operacje]("+id+")");
            piecoperSqlCommand.CommandType = CommandType.Text;
            SqlDataReader dane=piecoperSqlCommand.ExecuteReader();
            int i = 0;
            while (dane.Read())
            {
                Operacja operacja=new Operacja(i,dane[0].ToString(),dane[1].ToString());
                listaop.Add(operacja);
                i++;
            }
            dane.Close();
            return listaop;
            
        }

}

   

        

    }

