using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.Models;

public class Espece
{
    [PrimaryKey]
    public int Id_espece { get; set; }
    public string Nom { get; set; }
}
