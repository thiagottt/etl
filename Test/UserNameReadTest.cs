using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleETLJob.Operations;
using Rhino.Etl.Core;
using SampleETLJob.DataObjects;

namespace Test
{
    [TestClass]
    [DeploymentItem(@".\SampleData\names.txt", "SampleData")]
    public class UserNameReadTest : BaseTestClass
    {
        [TestMethod]
        public void CanReadFile()
        {
            var userRecords = TestOperation(
                new UserNameRead(@".\SampleData\names.txt")
            );

            AreSameRows(new[] {
                Row.FromObject(new UserNameRecord{ Id = 1, Name = "Bob" }),
                Row.FromObject(new UserNameRecord{ Id = 2, Name = "John" }),
                Row.FromObject(new UserNameRecord{ Id = 3, Name = "Frank" }),
                Row.FromObject(new UserNameRecord{ Id = 4, Name = "Michelle" }),
            }, userRecords);
        }
    }
}
