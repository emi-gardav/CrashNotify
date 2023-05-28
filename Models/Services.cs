using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEmergencias.Properties;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace AppEmergencias.Models
{
    public class Services
    {
        string connectionString = "Server=tcp:horarioserver.database.windows.net,1433;Initial Catalog=dBNotify;Persist Security Info=False;User ID=adminemi;Password=administradoremi1#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool Test()
        {            
            try
            {
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string Link()
        {
            return this.connectionString;
        }

        /*public List<Siniestro> ReadSiniestros()
        {
            List<Siniestro> siniestroList = new List<Siniestro>();
            string query = "SELECT ID, Poliza, Latitud, Longitud, Telefono, Emergencia, Activo FROM siniestros";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Siniestro siniestro = new Siniestro();
                        siniestro.ID = reader.GetInt32(0);
                        siniestro.Poliza = reader.GetString(1);
                        siniestro.Latitud = reader.GetFloat(2);
                        siniestro.Longitud = reader.GetFloat(3);
                        siniestro.Telefono = reader.GetString(4);
                        siniestro.Emergencia = reader.GetBoolean(5);
                        siniestro.Activo = reader.GetBoolean(6);
                        siniestroList.Add(siniestro);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
            return siniestroList;
        }

        public Siniestro LoadSiniestro(int ID)
        {
            Siniestro siniestro = new Siniestro();
            string query = "SELECT ID, Poliza, Latitud, Longitud, Telefono, Emergencia, Activo FROM Siniestros WHERE Poliza = @ID";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@ID", ID);
                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    siniestro.ID = reader.GetInt32(0);
                    siniestro.Poliza = reader.GetString(1);
                    siniestro.Latitud = reader.GetFloat(2);
                    siniestro.Longitud = reader.GetFloat(3);
                    siniestro.Telefono = reader.GetString(4);
                    siniestro.Emergencia = reader.GetBoolean(5);
                    siniestro.Activo = reader.GetBoolean(6);
                    reader.Close();
                    return siniestro;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }

        public void CreateSiniestro(float Latitud, float Longitud, string Telefono, bool Emergencia, bool Activo)
        {
            string query = "INSERT INTO siniestros (Latitud, Longitud, Telefono, Emergencia, Activo) VALUES ( @Latitud, @Longitud, @Telefono, @Emergencia, @Activo)";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Latitud", Latitud);
                cmd.Parameters.AddWithValue("@Longitud", Longitud);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Emergencia", Emergencia);
                cmd.Parameters.AddWithValue("@Activo", Activo);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }

        public void UpdateSiniestro(String Poliza, float Latitud, float Longitud, string Telefono, bool Emergencia, bool Activo)
        {
            string query = "UPDATE siniestros SET Latitud = @Latitud, Longitud = @Longitud, Telefono = @Telefono, Emergencia = @Emergencia, Activo = @Activo WHERE Poliza = @Poliza";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Latitud", Latitud);
                cmd.Parameters.AddWithValue("@Longitud", Longitud);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Emergencia", Emergencia);
                cmd.Parameters.AddWithValue("@Activo", Activo);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }

        public void DeleteSiniestro(String Poliza)
        {
            string query = "DELETE FROM siniestros WHERE Poliza = @ID";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@ID", Poliza);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos. " + ex.Message);
                }
            }
        }*/
    }

    /*public class Siniestro
    {
        public int ID { get; set; }
        public String Poliza { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }
        public String Telefono { get; set; }
        public bool? Emergencia { get; set; }
        public bool? Activo { get; set; }
    }*/
}