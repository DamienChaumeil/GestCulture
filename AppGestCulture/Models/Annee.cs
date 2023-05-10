using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.Models;
public class Annee
{
    [PrimaryKey]
    public DateOnly Annee_culture { get; set; }

}

