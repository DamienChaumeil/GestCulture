using SQLite;

namespace AppGestCulture;

public class Constants
{
    public const string DatabaseFilename = "database.db3";

    public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

    public static string TechnicienMatricule = "root";

    public static string TechnicienMdp = "root";


    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;   
}