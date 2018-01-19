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

        string connectionstring = " Data Source=abd.wwsi.edu.pl;Initial Catalog = jippZ507; User ID = jippakita; Password=qazwsx123456";

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


            var dane = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand("stany", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dane.Add(reader["saldo"].ToString());
                            dane.Add(reader["zablokowane"].ToString());
                            dane.Add(reader["dostepne"].ToString());
                        }
                    }
                    connection.Close();
                }
            }
            return dane.ToArray();
        }

        public List<Operacja> lista5operacji(int id)
        {
            List<Operacja> listaop =new List<Operacja>();
            using (SqlConnection connection=new SqlConnection(connectionstring))
            {
                SqlCommand piecoperSqlCommand =new SqlCommand("Select * from [JiPPakita].[operacje]("+id+")",connection);
            piecoperSqlCommand.CommandType = CommandType.Text;
                connection.Open();
            SqlDataReader dane=piecoperSqlCommand.ExecuteReader();
            int i = 0;
            while (dane.Read())
            {
                Operacja operacja=new Operacja(i,dane[0].ToString(),dane[1].ToString());
                listaop.Add(operacja);
                i++;
            }
            dane.Close();
            }
            return listaop;
        }
       }
    }

