using System;
using System.Data.SqlClient;

namespace Playoff.Classes {
    public static class Baza {
        //varijabla za login
        static SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();

        //vrsimo login na bazu podataka (pri pokretanju applikacije, ovaj user je ogranicen sa mogucnostima koje moze raditi)
        public static void LogNaBazu() {
            cb.DataSource = "playoff.database.windows.net";
            cb.UserID = "APP";
            cb.Password = "Playoff1";
            cb.InitialCatalog = "PlayOff";
        }

        //registracije korisnika na bazu podataka
        public static void RegistrujKorisnika(string user, string password, string ime, string prezime, DateTime rodjen, string drzava, string grad, int dostupnost) {
            string komanda = "Exec dbo.Registruj " + "'" + user + "','" + password + "','" + ime + "','" + prezime + "'," + "'" + rodjen.Year.ToString() + "-" + rodjen.Month.ToString() + "-" + rodjen.Day.ToString() + "','" + drzava + "','" + grad + "'," + dostupnost;
            IzvrsiKomandu(komanda,false);
        }

        //trazi password za korisnika koji se treba logovat da se može provjerit
        public static string DajPassword(string username) {
            string komanda = "Select dbo.uzmi_password('" + username + "')";
            return IzvrsiKomandu(komanda,true);
        }

        //izvršavanje komande koja mi treba
        static string IzvrsiKomandu(string komanda,bool param) {
            using(var connection = new SqlConnection(cb.ConnectionString)) {
                connection.Open();
                return Submit_Tsql_NonQuery(connection, komanda,param);
            }
        }

        //Pomocna funkcija za slanje onog sto treba bazi
        static string Submit_Tsql_NonQuery(SqlConnection connection, string tsqlSourceCode, bool param) {
            using(var command = new SqlCommand(tsqlSourceCode, connection)) {
                if(param) return command.ExecuteScalar().ToString();
                int rowsAffected = command.ExecuteNonQuery();
                return "";
            }
        }
    }
}