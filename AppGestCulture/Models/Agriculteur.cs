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
    private int Id_agri { get; set; }

    private string Nom { get; set; }

    private string Prenom { get; set; }

}
