using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tools.Databases
{
    public interface IConnectionInfo
    {
        string ConnectionString { get; }
    }
}
