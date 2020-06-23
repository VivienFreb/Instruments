using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace musique.Models
{
    public class Data
    {
        public static string GetClasse()
        {
            string connection = ConfigurationManager.ConnectionStrings["Musique"].ConnectionString;
            MySqlConnection connect = new MySqlConnection(connection);

            connect.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT idClasse, NomClasse FROM classe", connect);

            MySqlDataReader data = cmd.ExecuteReader();

            string classe = "";

            while (data.Read())
            {
                classe += "<option value=\"" + data["idClasse"] + "\">" + " " + data["NomClasse"] + "</option>";
            }

            connect.Close();

            return classe;
        }
        public static string GetType(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Musique"].ConnectionString;

            MySqlConnection connect = new MySqlConnection(connection);

            connect.Open();

            MySqlCommand film = new MySqlCommand("SELECT CodeType, NomType FROM type WHERE idClasse =" + id, connect);
            MySqlDataReader data = film.ExecuteReader();

            string movie = "";

            while (data.Read())
            {
                movie += "<option value=\"" + data["CodeType"] + "\">" + data["NomType"];
            }

            connect.Close();

            return movie;

        }

        public static string GetInstruments()
        {
            string connection = ConfigurationManager.ConnectionStrings["Musique"].ConnectionString;
            MySqlConnection connect = new MySqlConnection(connection);

            connect.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT instrument.NumInstrument, instrument.DateAchat, instrument.PrixAchat, instrument.Marque," +
                " instrument.Modele, instrument.Couleur, instrument.NumSerie, instrument.Utilisation, instrument.idClasse, instrument.CodeType," +
                " classe.NomClasse, type.NomType" +
                " FROM instrument" + 
                " INNER JOIN type ON (type.CodeType = instrument.CodeType)" +
                " INNER JOIN classe ON (classe.idClasse = type.idClasse)", connect);

            MySqlDataReader data = cmd.ExecuteReader();

            string instrument = "";

            while (data.Read())
            {
                instrument += "<tr><td>" + data["NumSerie"] + "</td><td>" + data["Marque"] + "</td><td>" + data["Modele"] + "</td><td>" + data["Couleur"] + "</td><td>" + Convert.ToDateTime(data["DateAchat"]).ToShortDateString() + "</td><td>" + data["PrixAchat"] + "</td><td>" + data["NomClasse"] + "</td><td>" + data["NomType"] + "</td>";
            }

            connect.Close();

            return instrument;
        }

        public static string Validation()
        {
            string connection = ConfigurationManager.ConnectionStrings["Musique"].ConnectionString;
            MySqlConnection connect = new MySqlConnection(connection);

            connect.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT instrument.NumInstrument, instrument.DateAchat, instrument.PrixAchat, instrument.Marque," +
                " instrument.Modele, instrument.Couleur, instrument.NumSerie, instrument.Utilisation, instrument.idClasse, instrument.CodeType," +
                " classe.NomClasse, type.NomType" +
                " FROM instrument" +
                " INNER JOIN type ON (type.CodeType = instrument.CodeType)" +
                " INNER JOIN classe ON (classe.idClasse = type.idClasse)", connect);

            MySqlDataReader data = cmd.ExecuteReader();

            string validation = "";

            while (data.Read())
            {
                validation += "<tr><td>" + data["NumSerie"] + "</td><td>" + data["Marque"] + "</td><td>" + data["Modele"] + "</td><td>" + data["Couleur"] + "</td><td>" + Convert.ToDateTime(data["DateAchat"]).ToShortDateString() + "</td><td>" + data["PrixAchat"] + "</td><td>" + data["NomClasse"] + "</td><td>" + data["NomType"] + "</td>";
            }

            connect.Close();

            return validation;
        }
    }
}