using fpis.Klase;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpis
{
    public class DatabaseService
    {
        
        SqlCommand komanda;
        SqlConnection connection;
        SqlTransaction transakcija;
        public DatabaseService()
        {
            connection = new SqlConnection("Data Source=DESK-vtrajkovic;Initial Catalog=fpis;Integrated Security=True");
            komanda = connection.CreateCommand();
        }
        public List<Klijent> getKlijenti()
        {
            List<Klijent> lista = new List<Klijent>();
            try
            {
                connection.Open();
                komanda.CommandText = "Select * from Klijent";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Klijent k = new Klijent();
                    k.Id = citac.GetInt32(0);
                    k.Email = citac.GetString(2);
                    k.Naziv = citac.GetString(1);

                    lista.Add(k);
                }
                citac.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { if (connection != null) connection.Close(); }
        }

        public List<Izvestaj> getIzvestaji()
        {
            List<Izvestaj> lista = new List<Izvestaj>();
            try
            {
                connection.Open();
                komanda.CommandText = "Select * from Izvestaj i left join Klijent k on i.klijentid = k.id";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Izvestaj i = new Izvestaj();
                    i.Id = citac.GetInt32(0);
                    i.Datum = citac.GetDateTime(1).ToString("yyyy-MM-dd");
                    i.Nalogid = citac.GetInt32(2);
                    i.KlijentId = citac.GetInt32(3);
                    i.Klijent = citac.GetString(5);

                    lista.Add(i);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }
        public List<KlijentFizicko> getKlijentiFizicko()
        {
            List<KlijentFizicko> lista = new List<KlijentFizicko>();
            try
            {
                connection.Open();
                komanda.CommandText = "Select * from KlijentFizicko";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KlijentFizicko kf = new KlijentFizicko();
                    kf.Id = citac.GetInt32(0);
                    kf.Jmbg = citac.GetString(1);
                    kf.ImePrezime = citac.GetString(2);
                    kf.DatumRodj = citac.GetDateTime(3).ToString("yyyy-MM-dd");
                    kf.Drzavljanstvo = citac.GetString(4);
                    kf.Brlk = citac.GetString(5);
                    kf.Email = citac.GetString(6);
                    kf.Adresa = citac.GetString(7);

                    lista.Add(kf);
                }
                citac.Close();


                foreach(KlijentFizicko klif in lista)
                {
                    getRacuni(klif.Id, klif.ListaRacuna);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { if (connection != null) connection.Close(); }
        }

        public bool createRacun(Racun r)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Insert into Racun values('"+r.BrojRacuna+ "','" + r.ZaPlatu + "', '" + r.Tip + "', "+r.KlijentId+")";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void getRacuni(int klijentId, List<Racun> listaRacuna)
        {
            try
            {
                komanda.CommandText = "Select * from Racun where klijentid = "+klijentId+"";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Racun r = new Racun();
                    r.BrojRacuna = citac.GetString(0);
                    r.ZaPlatu = citac.GetString(1);
                    r.Tip = citac.GetString(2);
                    r.KlijentId = citac.GetInt32(3);

                    listaRacuna.Add(r);
                }
                citac.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool updateIzvestaj(Izvestaj i)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Update Izvestaj set datum = cast('"+DateTime.ParseExact(i.Datum, "yyyy-MM-dd", null)+"' as date), nalogid = "+i.Nalogid+", klijentid = "+i.KlijentId+" where id = "+i.Id+"";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        public bool deleteIzvestaj(int i)
        {
            try
            {
                connection.Open();
                //int idKlijenta = vratiKlijenta(i);
                komanda.CommandText = "Delete from Izvestaj where id = " + i + "";
                komanda.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool createIzvestaj(KlasaIzvestajZaUpis i)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Insert into Izvestaj values('" + DateTime.ParseExact(i.Datum, "yyyy-MM-dd", null) + "', '"+Convert.ToInt32(i.Nalogid)+"', "+i.Klijentid+")";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        public int vratiKlijenta(string naziv)
        {
            try
            {
                int idKlijenta = 0;
                komanda.CommandText = "Select id from Klijent where naziv = '"+naziv+"'";
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    idKlijenta = citac.GetInt32(0);
                }
                citac.Close();
                return idKlijenta;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deleteRacun(string brojRacuna)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Delete from Racun where brojRacun = '"+brojRacuna+"'";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if(connection != null) { connection.Close(); }
            }
        }

        public bool updateRacun(Racun r)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Update Racun set zaPlatu ='"+r.ZaPlatu+"', tip = '"+r.Tip+"', klijentid = "+r.KlijentId+" where brojRacun = '"+r.BrojRacuna+"'";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { if (connection != null) connection.Close(); }
        }

        public bool createKlijentFizicko(KlijentFizicko k)
        {
            try
            {
                connection.Open();
                transakcija = connection.BeginTransaction();
                komanda = new SqlCommand("", connection, transakcija);


                try
                {
                    komanda.CommandText = "Insert into KlijentFizicko output INSERTED.ID values('" + k.Jmbg + "', '" + k.ImePrezime + "', '" + Convert.ToDateTime(k.DatumRodj) + "', '"+k.Drzavljanstvo+"','" + k.Brlk + "', '" + k.Email + "', '" + k.Adresa + "')";
                    
                    int idKlijenta = (int)komanda.ExecuteScalar();
                    foreach (Racun r in k.ListaRacuna)
                    {
                        komanda.CommandText = "Insert into Racun values('"+r.BrojRacuna+ "', '"+r.ZaPlatu+ "', '"+r.Tip+"', "+idKlijenta+")";
                        komanda.ExecuteNonQuery();
                    }
                    transakcija.Commit();
                }
                catch (Exception ex)
                {
                    transakcija.Rollback();
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }
        public bool updateKlijentFizicko(KlijentFizicko k)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Update KlijentFizicko set jmbg = '"+k.Jmbg+ "', imePrezime = '"+k.ImePrezime+ "', datumRodjenja = '"+Convert.ToDateTime( k.DatumRodj)+ "', drzavljanstvo = '"+k.Drzavljanstvo+ "', brojLK = '"+k.Brlk+ "', email = '"+k.Email+ "', adresa = '"+k.Adresa+"' where id = "+k.Id+"";
                komanda.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteKlijentFizicko(int id)
        {
            try
            {
                connection.Open();
                komanda.CommandText = "Delete from Racun where klijentid = "+id+"";
                komanda.ExecuteNonQuery();

                komanda.CommandText = "Delete from KlijentFizicko where id = "+id+"";
                komanda.ExecuteNonQuery();

                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }
    }
}

