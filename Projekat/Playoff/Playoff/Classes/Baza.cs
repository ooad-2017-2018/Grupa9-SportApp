using System;
using System.Data.SqlClient;

namespace Playoff {

    public class Baza {
        //varijable za login
        var cb = new SqlConnectionStringBuilder();

        //vrsimo login na bazu podataka (pri pokretanju applikacije, ovaj user je ogranicen sa mogucnostima koje moze raditi)
        public static void LogNaBazu(){ 
            cb.DataSource = "playoff.database.windows.net";
            cb.UserID = "APP";
            cb.Password = "Playoff1";
            cb.InitialCatalog = "PlayOff"; 
        }


      //registracije korisnika na bazu podataka
        public static void RegistrujKorisnika( string user ,string  password , string ime , string prezime , DateTime rodjen , string drzava , string grad , int dostupnost) {
               string komanda = "Exec dbo.Registruj " + "'"+user+ "','"+password +"','"+ ime+"','"+prezime+ "'," +"Convert(datetime,"+ "'"+rodjen.Year.ToString() + "-"+ rodjen.Month.ToString() +"-"+rodjen.Day.ToString()+ "'),'"+drzava+"','"+grad+"',"+dostupnost;
               IzvrsiKomandu(komanda);
        }

        //trazi password za korisnika koji se treba logovat da se može provjerit
        public static string DajPassword(string username) {
            string komanda = "Select dbo.uzmi_password('" +username+"')";
            return IzvrsiKomandu(komanda);
        }

        //izvršavanje komande koja mi treba
        string IzvrsiKomandu(string komanda) {
            using (var connection = new SqlConnection(cb.ConnectionString)) {
                connection.Open();
                return Submit_Tsql_NonQuery(connection, komanda);
            }
        }

        //Pomocna funkcija za slanje onog sto treba bazi
        string Submit_Tsql_NonQuery(SqlConnection connection, string tsqlSourceCode, string parameterName = null, string parameterValue = null) {

         using (var command = new SqlCommand(tsqlSourceCode, connection)) {
                string str = "";
                if (parameterName != null) {
                    command.Parameters.Add(parameterName, System.Data.SqlDbType.Varchar).Direction = System.Data.ParameterDirection.ReturnValue;
                    
                }
                int rowsAffected = command.ExecuteNonQuery();
                if (parameterName != null) str = command.Parameters[parameterName].Value.ToString();
                return str;
           }
        }
}
}

