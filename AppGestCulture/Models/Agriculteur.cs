using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.Models;


public class Agriculteur
{
    [PrimaryKey, AutoIncrement]
    public int Id_agri { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }
}
