namespace Core.CrossCuttingConcerns.Serilog.ConfigurationModels;

public class PostgreSQLConfiguration
{
    public string ConnectionString { get; set; }
    public string TableName { get; set; }
    public bool AutoCreateSqlTable { get; set; }

    public PostgreSQLConfiguration()
    {
        ConnectionString = string.Empty;
        TableName = string.Empty;
        AutoCreateSqlTable = false; 
    }

    public PostgreSQLConfiguration(string connectionString, string tableName, bool autoCreateSqlTable)
    {
        ConnectionString = connectionString;
        TableName = tableName;
        AutoCreateSqlTable = autoCreateSqlTable;
    }
}