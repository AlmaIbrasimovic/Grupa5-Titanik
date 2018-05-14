using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.AzureKlase
{
    public class AgencijaAzure
    {
        public String id { get; set; }
        public String naziv { get; set; }
        public String idKartica { get; set; }
        public String telefon { get; set; }
        public String grad { get; set; }
        public String lokacija { get; set; }
        public String sifra { get; set; }
        public String email { get; set; }

        public AgencijaAzure() { }
        public AgencijaAzure(String _id, String _naziv, String _idKartica, String _telefon, String _grad, String _lokacija, String _sifra,String _email)
        {
            id = _id;
            naziv = _naziv;
            idKartica = _idKartica;
            telefon = _telefon;
            grad = _grad;
            lokacija = _lokacija;
            sifra = _sifra;
            email = _email;
        }

        public void UcitajAgencije()
        {
            try
            {

                string query = "SELECT * FROM AgencijaAzure;";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection c = new SqlConnection(s.konekcija))
                {
                    c.Open();
                    if (c.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand sc = c.CreateCommand();
                        sc.CommandText = query;
                        SqlDataReader reader = sc.ExecuteReader();
                        while (reader.Read())
                        { int index = -1;
                            for(int i = 0; i < Globalna.nasaAgencija.Kartice.Count; i++)
                            {
                                if (Globalna.nasaAgencija.Kartice[i].ToString() == reader.GetString(2))
                                {
                                    index = i;
                                    break;
                                }
                            }
                            //id ne cita
                            Agencija a = new Agencija( reader.GetString(1), Globalna.nasaAgencija.Kartice[index], reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(5), reader.GetString(7));
                            Globalna.nasaAgencija.Agencije.Add(a);
                        }
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);

            }

        }

        public int dodajAgenciju(Agencija a)
        {
            try
            {
                String query = "insert into AgencijaAzure values (@id,@naziv,@idKartica,@telefon,@grad,@lokacija,@sifra,@email)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter idS = new SqlParameter();
                    idS.Value = a.Id;
                    idS.ParameterName = "id";
                    cmd.Parameters.Add(idS);

                    SqlParameter nazivS = new SqlParameter();
                    nazivS.Value = a.NazivAgencije;
                    nazivS.ParameterName = "naziv";
                    cmd.Parameters.Add(nazivS);

                    SqlParameter idKarticeS = new SqlParameter();
                    idKarticeS.Value = a.PodaciOBankovnomRacunu.Id;
                    idKarticeS.ParameterName = "idKartica";
                    cmd.Parameters.Add(idKarticeS);

                    SqlParameter brojS = new SqlParameter();
                    brojS.Value = a.KontaktTelefon;
                    brojS.ParameterName = "telefon";
                    cmd.Parameters.Add(brojS);

                    SqlParameter gradS = new SqlParameter();
                    gradS.Value = a.Grad;
                    gradS.ParameterName = "grad";
                    cmd.Parameters.Add(gradS);

                    SqlParameter lokacijaS = new SqlParameter();
                    lokacijaS.Value = a.Lokacija;
                    lokacijaS.ParameterName = "lokacija";
                    cmd.Parameters.Add(lokacijaS);

                    SqlParameter sifraS = new SqlParameter();
                    sifraS.Value = a.Sifra;
                    sifraS.ParameterName = "sifra";
                    cmd.Parameters.Add(sifraS);

                    SqlParameter emailS = new SqlParameter();
                    emailS.Value = a.EmailAdresa;
                    emailS.ParameterName = "email";
                    cmd.Parameters.Add(emailS);

                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    return r;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }

        }
            

    }
}