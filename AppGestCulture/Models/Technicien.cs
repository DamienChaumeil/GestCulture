using SQLite;
using System.ComponentModel;

namespace AppGestCulture.Models;

public class Technicien
{
    [PrimaryKey, AutoIncrement]
    public int ID_Tech { get; set; }

    public string Matricule { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    [PasswordPropertyText]
    public string Mdp { get; set; }
}

