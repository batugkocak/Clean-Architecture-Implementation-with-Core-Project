namespace Core.Persistence.Dynamic;

public class Filter
{
    public string Field { get; set; } 

    public string? Value { get; set; } 

    public string? Operator { get; set; } // =, !=, >, <, >=, <=, LIKE, IN

    public string? Logic { get; set; } // AND, OR

    public IEnumerable<Filter> Filters { get; set; }

    public Filter()
    {
        Field = string.Empty;

        Operator = string.Empty;
    }

    public Filter(string field, string value, string @operator)
    {
        Field = field;

        Value = value;

        Operator = @operator;
    }
}