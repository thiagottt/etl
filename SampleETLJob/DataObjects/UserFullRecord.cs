using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleETLJob.DataObjects
{
    using FileHelpers;

    [DelimitedRecord("\t"), IgnoreFirst]
    public class UserFullRecord
    {
        public int Id;
        public string Name;
        public string Address;
    }
}
