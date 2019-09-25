using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEnums.Enums
{
    using System.ComponentModel;

    enum Servers
    {
        None,
        [Description("Microsoft SQL Server")]
        Sql,
        Oracle,
        [Description("MySQL")]
        MySql,
        [Description("PostgreSQL")]
        PostgreSql
    }
}
