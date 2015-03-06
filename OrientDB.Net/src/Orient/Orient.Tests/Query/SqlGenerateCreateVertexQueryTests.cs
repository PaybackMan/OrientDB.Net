﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orient.Client;

namespace Orient.Tests.Query
{
    [TestClass]
    public class SqlGenerateCreateVertexQueryTests
    {
        [TestMethod]
        public void ShouldGenerateCreateVertexQuery()
        {
            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex("TestVertexClass")
                .ToString();

            string query =
                "CREATE VERTEX TestVertexClass";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateCreateVertexFromDocumentQuery()
        {
            ODocument document = new ODocument();
            document.OClassName = "TestVertexClass";
            document
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex(document)
                .ToString();

            string query =
                "CREATE VERTEX TestVertexClass " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateCreateVertexFromObjectQuery()
        {
            TestProfileClass profile = new TestProfileClass();
            profile.Name = "Johny";
            profile.Surname = "Bravo";

            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex(profile)
                .ToString();

            string query =
                "CREATE VERTEX TestProfileClass " +
                "SET Name = 'Johny', " +
                "Surname = 'Bravo'";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateCreateVertexClusterQuery()
        {
            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex("TestVertexClass")
                .Cluster("TestCluster")
                .ToString();

            string query =
                "CREATE VERTEX TestVertexClass " +
                "CLUSTER TestCluster";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateCreateVertexClusterSetQuery()
        {
            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex("TestVertexClass")
                .Cluster("TestCluster")
                .Set("foo", "foo string value")
                .Set("bar", 12345)
                .ToString();

            string query =
                "CREATE VERTEX TestVertexClass " +
                "CLUSTER TestCluster " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateCreateVertexClusterSetFromDocumentQuery()
        {
            ODocument document = new ODocument();
            document.OClassName = "TestVertexClass";
            document
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlCreateVertexViaSql()
                .Vertex("TestVertexClass")
                .Cluster("TestCluster")
                .Set(document)
                .ToString();

            string query =
                "CREATE VERTEX TestVertexClass " +
                "CLUSTER TestCluster " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }
    }
}
