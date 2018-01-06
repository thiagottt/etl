using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Etl.Core;
using SampleETLJob.Operations;
using Rhino.Etl.Core.Operations;
using Rhino.Etl.Core.Pipelines;

namespace SampleETLJob
{
    public class MainProcess : EtlProcess
    {
        protected override void Initialize()
        {
            Register(new JoinUserRecords()
                .Left(new UserNameRead(Settings.Default.NamesFile))
                .Right(new UserAddressRead(Settings.Default.AddressesFile))
            );

            Register(new UserFullWrite(Settings.Default.OutputFile));
        }

        protected override void PostProcessing()
        {
            base.PostProcessing();

            //enumerate errors and throw first one
            //event fired after op completes never fires on error 
            //so this is only chance I know for generic exception throwing, 
            //otherwise they get ignored
            foreach (var error in GetAllErrors())
                throw error;
        }
    }
}
