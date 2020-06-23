using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MySql.Data.MySqlClient;
using musique.Models;
using System.IO;

namespace musique.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Test()
        {
            string connection = ConfigurationManager.ConnectionStrings["Musique"].ConnectionString;
            MySqlConnection connect = new MySqlConnection(connection);

            connect.Open();

            string marque = Request.Form["Marque"].ToString(); // Marque
            string modele = Request.Form["Modele"].ToString(); // Modele
            string codeType = Request.Form["type"].ToString(); //idType
            string utilisation = Request.Form["Utilisation"].ToString(); // Preter ou non
            DateTime dateHA = Convert.ToDateTime(Request.Form["DateAchat"]); // Date Achat
            int an = dateHA.Year;
            int mois = dateHA.Month;
            int jour = dateHA.Day;
            string couleur = Request.Form["Couleur"].ToString(); // Couleur
            string numSerie = Request.Form["NumSerie"].ToString(); // Numero de serie
            string prixHA = Request.Form["PrixAchat"].ToString(); // Prix d'achat

            ViewData["marque"] = marque;
            ViewData["modele"] = modele;
            ViewData["codetype"] = codeType;
            ViewData["dateachat"] = dateHA.ToShortDateString();
            ViewData["prixachat"] = prixHA;
            ViewData["couleur"] = couleur;
            ViewData["numserie"] = numSerie;

            if (utilisation == "1")
                ViewData["utilisation"] = "Oui";
            else
                ViewData["utilisation"] = "Non";


            MySqlCommand cmd = new MySqlCommand("SELECT idClasse FROM type WHERE CodeType=" + codeType, connect);
            MySqlDataReader lire = cmd.ExecuteReader();
            lire.Read();
            string idClasse = lire["idClasse"].ToString();
            connect.Close();
            connect.Open();

            cmd = new MySqlCommand("INSERT INTO instrument (DateAchat, PrixAchat, Marque, Modele, Couleur, NumSerie, Utilisation, idClasse, " +
            "CodeType) VALUES ('" + an + "-" + mois + "-" + jour + "', " + Convert.ToDouble(prixHA) + ", '" + marque + "', '" + modele + "', '" + couleur + "', '" + numSerie + "', " + utilisation + ", " + Convert.ToInt32(idClasse) + "," + Convert.ToInt32(codeType) + ")", connect);

            cmd.ExecuteReader();

            return View("Test");
        }    
    }
}