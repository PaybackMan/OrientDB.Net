using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshare.Hogweed.Db.Tests;

namespace Orient.Tests
{
    [TestClass]
    public class AssemblySetup
    {
        [AssemblyInitialize()]
        public static void Setup(TestContext context)
        {
            //var dbDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\..\orient.server"));
            //DbRunner.StartOrientDb(dbDir, @"C:\Program Files\Java\jre7");
            DbRunner.StartOrientDb(@"C:\OrientDB", @"C:\Program Files\Java\jre1.8.0_31");
        }

        [AssemblyCleanup()]
        public static void TearDown()
        {
            DbRunner.StopOrientDb();
        }
    }
}
