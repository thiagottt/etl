using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleETLJob.DataObjects
{
    using FileHelpers;

    [DelimitedRecord("\t"), IgnoreFirst]
    public class UserAddressRecord
    {
        public int Id;
        public string Address;
    }
}
