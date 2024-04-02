using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ABC_Car_Traders.Classes
{
    internal class DatabaseManager
    {
        public static string GetConnectionString()
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pcs\\source\\repos\\ABC-Car-Traders\\ABC-Car-Traders\\CarDB.mdf;Integrated Security=True";
        }
    }
}
