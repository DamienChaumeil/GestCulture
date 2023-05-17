using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.Models;

public class Espece
{
    [PrimaryKey, AutoIncrement]
    public int Id_espece { get; set; }
    public string Nom { get; set; }
}
