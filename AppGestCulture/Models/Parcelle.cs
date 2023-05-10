using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.Models;
public class Parcelle
{
    [PrimaryKey, AutoIncrement]
    private int Id_parc { get; set; }

    private float Surface { get; set; }

    private float Rendement_prev { get; set; }

    private float Rendement_reel { get; set; }

}