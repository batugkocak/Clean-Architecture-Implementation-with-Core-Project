using Core.CrossCuttingConcerns.Serilog;
using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using Microsoft.Extensions.Configuration;
using NpgsqlTypes;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;

public class PostgreSQLLogger : LoggerServiceBase
{
    public PostgreSQLLogger(IConfiguration configuration)
    {
        PostgreSQLConfiguration logConfiguration =
            configuration.GetSection("PostgreSQLConfiguration").Get<PostgreSQLConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);
        
        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
            {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
            {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
            {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
            {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
            {"machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
        };
        

            Logger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(logConfiguration.ConnectionString, logConfiguration.TableName, columnWriters, needAutoCreateTable: logConfiguration.AutoCreateSqlTable)
            .CreateLogger();
        
    }
}