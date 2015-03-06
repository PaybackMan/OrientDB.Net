﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orient.Client;

namespace Orient.Tests.Serialization
{
    [TestClass]
    public class RecordSerializationTests
    {
        [TestMethod]
        public void ShouldNotSerializeFieldsWithAtCharacter()
        {
            string recordString = "TestClass@foo:true";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("@ClassId", 123)
                .SetField("@Foo", "bar")
                .SetField("@ORID", new ORID(8, 0))
                .SetField<bool>("foo", true);

            string serializedRecord = document.Serialize();

            Assert.AreEqual(serializedRecord, recordString);
        }

        [TestMethod]
        public void ShouldSerializeNull()
        {
            string recordString = "TestClass@null:,embedded:(null:)";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField<object>("null", null)
                .SetField<object>("embedded.null", null);

            string serializedRecord = document.Serialize();

            Assert.AreEqual(serializedRecord, recordString);
        }

        [TestMethod]
        public void ShouldSerializeBoolean()
        {
            string recordString = "TestClass@isTrue:true,isFalse:false,embedded:(isTrue:true,isFalse:false),array:[true,false]";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("isTrue", true)
                .SetField("isFalse", false)
                .SetField("embedded.isTrue", true)
                .SetField("embedded.isFalse", false)
                .SetField<List<bool>>("array", new List<bool> { true, false });

            string serializedRecord = document.Serialize();

            Assert.AreEqual(serializedRecord, recordString);
        }

        [TestMethod]
        public void ShouldSerializeNumbers()
        {
            string recordString = "TestClass@ByteNumber:123b,ShortNumber:1234s,IntNumber:123456,LongNumber:12345678901l,FloatNumber:3.14f,DoubleNumber:3.14d,DecimalNumber:1234567.8901c,embedded:(ByteNumber:123b,ShortNumber:1234s,IntNumber:123456,LongNumber:12345678901l,FloatNumber:3.14f,DoubleNumber:3.14d,DecimalNumber:1234567.8901c)";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("ByteNumber", byte.Parse("123"))
                .SetField("ShortNumber", short.Parse("1234"))
                .SetField("IntNumber", 123456)
                .SetField("LongNumber", 12345678901)
                .SetField("FloatNumber", 3.14f)
                .SetField("DoubleNumber", 3.14)
                .SetField("DecimalNumber", new Decimal(1234567.8901))
                .SetField("embedded.ByteNumber", byte.Parse("123"))
                .SetField("embedded.ShortNumber", short.Parse("1234"))
                .SetField("embedded.IntNumber", 123456)
                .SetField("embedded.LongNumber", 12345678901)
                .SetField("embedded.FloatNumber", 3.14f)
                .SetField("embedded.DoubleNumber", 3.14)
                .SetField("embedded.DecimalNumber", new Decimal(1234567.8901));

            string serializedRecord = document.Serialize();

            Assert.AreEqual(serializedRecord, recordString);
        }

        [TestMethod]
        public void ShouldSerializeDateTime()
        {
            DateTime dateTime = DateTime.Now;

            // get Unix time version
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            string timeString = ((long)((DateTime)dateTime - unixEpoch).TotalMilliseconds).ToString();

            string recordString = "TestClass@DateTime:" + timeString + "t,embedded:(DateTime:" + timeString + "t)";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("DateTime", dateTime)
                .SetField("embedded.DateTime", dateTime);

            string serializedRecord = document.Serialize();

            Assert.AreEqual(serializedRecord, recordString);
        }

        [TestMethod]
        public void ShouldSerializeStrings()
        {
            string recordString = "TestClass@String:\"Bra\\" + "\"vo \\\\ asdf\",Array:[\"foo\",\"bar\"],embedded:(String:\"Bra\\" + "\"vo \\\\ asdf\",Array:[\"foo\",\"bar\"])";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("String", "Bra\"vo \\ asdf")
                .SetField("Array", new List<string> { "foo", "bar" })
                .SetField("embedded.String", "Bra\"vo \\ asdf")
                .SetField("embedded.Array", new List<string> { "foo", "bar" });

            string serializedString = document.Serialize();

            Assert.AreEqual(serializedString, recordString);
        }

        [TestMethod]
        public void ShouldSerializeORIDs()
        {
            string recordString = "TestClass@Single:#8:0,Array:[#8:1,#8:2],embedded:(Single:#9:0,Array:[#9:1,#9:2])";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("Single", new ORID(8, 0))
                .SetField("Array", new List<ORID> { new ORID(8, 1), new ORID(8, 2) })
                .SetField("embedded.Single", new ORID(9, 0))
                .SetField("embedded.Array", new List<ORID> { new ORID(9, 1), new ORID(9, 2) });

            string serializedString = document.Serialize();

            Assert.AreEqual(serializedString, recordString);
        }

        [TestMethod]
        public void ShouldSerializeListOfORIDs()
        {
            string recordString = "TestClass@Single:#8:0,Array:[#8:1,#8:2],embedded:(Array:[#9:1,#9:2])";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("Single", new ORID(8, 0))
                .SetField("Array", new List<ORID> { new ORID(8, 1), new ORID(8, 2) })
                .SetField("embedded.Array", new List<ORID> { new ORID(9, 1), new ORID(9, 2) });

            string serializedString = document.Serialize();

            Assert.AreEqual(serializedString, recordString);
        }

        [TestMethod]
        public void ShouldSerializeSetOfORIDs()
        {
            string recordString = "TestClass@Single:#8:0,Set:<#8:1,#8:2>,embedded:(Set:<#9:1,#9:2>)";

            ODocument document = new ODocument()
                .SetField("@OClassName", "TestClass")
                .SetField("Single", new ORID(8, 0))
                .SetField("Set", new HashSet<ORID> { new ORID(8, 1), new ORID(8, 2) })
                .SetField("embedded.Set", new HashSet<ORID> { new ORID(9, 1), new ORID(9, 2) });

            string serializedString = document.Serialize();

            Assert.AreEqual(serializedString, recordString);
        }
    }
}
