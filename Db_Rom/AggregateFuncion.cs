using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Rom
{

    public enum AggregateTypes
    {
        AVG = 0,
        SUM = 1,
        MAX = 2,
        MIN = 3,
        COUNT = 4,
    }

    public class AggregateFuncion
    {
        public AggregateTypes AggregateType { get; set; }

        public string Column { get; set; }

        public string ColumnAlias { get; set; }
    }
}
