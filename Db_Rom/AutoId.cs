using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Db_Rom
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AutoId : Attribute
    {
        public bool SetAutoId { get; set; }
    }
}
