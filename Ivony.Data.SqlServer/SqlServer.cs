﻿using Ivony.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivony.Data.Common;
using System.IO;

namespace Ivony.Data
{

  /// <summary>
  /// 提供 SQL Server 数据库访问支持
  /// </summary>
  public static class SqlServerDb
  {


    /// <summary>
    /// 通过指定的连接字符串并创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor SqlServer( this DbEnv environment, string connectionString, SqlDbConfiguration configuration = null )
    {
      return new SqlDbExecutor( environment, connectionString );
    }



    /// <summary>
    /// 通过指定的连接字符串构建器创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="builder">连接字符串构建器</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor SqlServer( this SqlConnectionStringBuilder builder, DbEnv environment )
    {
      return SqlServer( environment, builder.ConnectionString );
    }



    /// <summary>
    /// 通过指定的用户名和密码登陆 SQL Server 数据库，以创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="dataSource">数据库服务器实例名称</param>
    /// <param name="initialCatalog">数据库名称</param>
    /// <param name="userID">登录数据库的用户名</param>
    /// <param name="password">登录数据库的密码</param>
    /// <param name="pooling">是否启用连接池（默认启用）</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor SqlServer( this DbEnv environment, string dataSource, string initialCatalog, string userID, string password, bool pooling = true )
    {
      var builder = new SqlConnectionStringBuilder()
      {
        DataSource = dataSource,
        InitialCatalog = initialCatalog,
        IntegratedSecurity = false,
        UserID = userID,
        Password = password,
        Pooling = pooling
      };

      return SqlServer( environment, builder.ConnectionString );
    }


    /// <summary>
    /// 通过集成身份验证登陆 SQL Server 数据库，以创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="dataSource">数据库服务器实例名称</param>
    /// <param name="initialCatalog">数据库名称</param>
    /// <param name="pooling">是否启用连接池（默认启用）</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor SqlServer( this DbEnv environment, string dataSource, string initialCatalog, bool pooling = true, SqlDbConfiguration configuration = null )
    {
      var builder = new SqlConnectionStringBuilder()
      {
        DataSource = dataSource,
        InitialCatalog = initialCatalog,
        IntegratedSecurity = true,
        Pooling = pooling
      };

      return SqlServer( environment, builder.ConnectionString );
    }






    static SqlServerDb()
    {
      LocalDBInstanceName = "v11.0";
      ExpressInstanceName = "SQLEXPRESS";
    }


    internal static string LocalDBInstanceName { get; set; }

    internal static string ExpressInstanceName { get; set; }
  }
}
