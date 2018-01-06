using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Etl.Core.Operations;
using Rhino.Etl.Core;

namespace SampleETLJob.Operations
{
    public class JoinUserRecords : JoinOperation
    {
        protected override void SetupJoinConditions()
        {
            InnerJoin
                .Left("Id")
                .Right("Id");
        }

        protected override Row MergeRows(Row leftRow, Row rightRow)
        {
            Row row = new Row();
            row.Copy(leftRow);

            //copy over all properties not in the user records
            row["Address"] = rightRow["Address"];

            return row;
        }
    }
}
