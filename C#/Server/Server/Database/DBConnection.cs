using System;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.IO;

namespace MudServer.Database
{
    class DBConnection
    {
        private static string dbPath = "file.dat";
        private static string connString = "Data Source=" + dbPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;";
        
        public static SQLiteConnection ConnectDB()
        {
            SQLiteConnection conn = null;

            try
            {
                if (!File.Exists(dbPath))
                {
                    /*SQLiteConnection.CreateFile(...) works, whereas File.Create(...) does not*/
                    SQLiteConnection.CreateFile(dbPath);
                }
                conn = new SQLiteConnection(connString);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe);
                conn = null;
            }
            catch (SQLiteException se)
            {
                Console.WriteLine(se);
                conn = null;
            }

            return conn;
        }
    }
}
