using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FileHelpers;

using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;
using Rhino.Etl.Core;
using SampleETLJob.DataObjects;
using System.IO;

namespace SampleETLJob.Operations
{
    public class UserNameRead : AbstractOperation
    {
        public UserNameRead(string filePath)
        {
            this.filePath = filePath;
        }

        string filePath = null;

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            using (FileEngine file = FluentFile.For<UserNameRecord>().From(filePath))
            {
                foreach (object obj in file)
                {
                    yield return Row.FromObject(obj);
                }
            }
        }
    }
}
