using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Discord.Implemented;

namespace DataLibrary.Static_Data
{
    public static class DatabaseManager
    {
        private static readonly DatabaseContext DatabaseContext = new DatabaseContext();

        public static DatabaseContext GetMock()
        {
            return DatabaseContext;
        }
    }
}
