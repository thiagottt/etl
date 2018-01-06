using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleETLJob.Operations;
using Rhino.Etl.Core;
using SampleETLJob.DataObjects;
using Rhino.Etl.Core.Operations;

namespace Test
{
    [TestClass]
    [DeploymentItem(@".\SampleData\names.txt", "SampleData")]
    [DeploymentItem(@".\SampleData\addresses.txt", "SampleData")]
    public class JoinUserRecordsTest : BaseTestClass
    {
        [TestMethod]
        public void CanJoinFiles()
        {
            var userRecords = TestOperation(
                new JoinUserRecords()
                    .Left(new UserNameRead(@".\SampleData\names.txt"))
                    .Right(new UserAddressRead(@".\SampleData\addresses.txt"))
            );

            Assert.AreEqual(4, userRecords.Count);

            //check first row has properties from first rows of both sources
            Assert.AreEqual(1, userRecords[0]["Id"]);
            Assert.AreEqual("Bob", userRecords[0]["Name"]);
            Assert.AreEqual("123 Main St.", userRecords[0]["Address"]);
        }
    }
}
