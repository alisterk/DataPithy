﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.Data.MySqlClient
{
  public class MySqlDbConfiguration
  {

    public MySqlDbConfiguration() { }

    public TimeSpan? QueryExecutingTimeout { get; set; }
  }
}
