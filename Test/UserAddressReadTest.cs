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
    [DeploymentItem(@".\SampleData\addresses.txt", "SampleData")]
    public class UserAddressReadTest : BaseTestClass
    {
        [TestMethod]
        public void CanReadFile()
        {
            var userRecords = TestOperation(
                new UserAddressRead(@".\SampleData\addresses.txt")
            );

            AreSameRows(new[] {
                Row.FromObject(new UserAddressRecord{ Id = 1, Address = "123 Main St." }),
                Row.FromObject(new UserAddressRecord{ Id = 2, Address = "42 Everywhich way" }),
                Row.FromObject(new UserAddressRecord{ Id = 3, Address = "1 Microsoft way" }),
                Row.FromObject(new UserAddressRecord{ Id = 4, Address = "1892 Columbo" }),
            }, userRecords);
        }
    }
}
