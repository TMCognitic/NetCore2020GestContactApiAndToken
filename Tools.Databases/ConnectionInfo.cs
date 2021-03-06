﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Databases
{
    public class ConnectionInfo : IConnectionInfo
    {
        public string ConnectionString
        {
            get;
            private set;
        }

        public ConnectionInfo(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
