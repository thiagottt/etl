using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleETLJob.Operations;
using Rhino.Etl.Core;
using SampleETLJob.DataObjects;
using System.IO;
using Rhino.Etl.Core.Operations;

namespace Test
{
    [TestClass]
    public class UserFullWriteTest : BaseTestClass
    {
        public class GenerateTestData : AbstractOperation
        {
            public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
            {
                yield return Row.FromObject(new UserFullRecord { Id = 1, Name = "Jim1", Address = "1215 Smith St." });
                yield return Row.FromObject(new UserFullRecord { Id = 2, Name = "Jim2", Address = "1216 Smith St." });
            }
        }

        [TestMethod]
        public void CanWriteFile()
        {
            string filePath = @".\writetest.txt";
            var userRecords = TestOperation(
                new GenerateTestData(),
                new UserFullWrite(filePath)
            );

            Assert.IsTrue(File.Exists(filePath));

            string expectedOutput = @"Id	Name	Address
1	Jim1	1215 Smith St.
2	Jim2	1216 Smith St.
";

            Assert.AreEqual(expectedOutput, File.ReadAllText(filePath));
        }
    }
}
