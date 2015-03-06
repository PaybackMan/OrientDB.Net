using Orient.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshare.Hogweed.Db.Tests;

namespace OrientDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DbRunner.StartOrientDb(@"C:\OrientDB", @"C:\Program Files\Java\jre1.8.0_31");
            OClient.CreateDatabasePool(
                "127.0.0.1",
                2424,
                "DFI",
                ODatabaseType.Graph,
                "root",
                "root",
                10,
                "tdb"
            );

            using (ODatabase db = new ODatabase("tdb"))
            {
                var result = db.Query("traverse all() from interface");
            }
        }
    }
}
