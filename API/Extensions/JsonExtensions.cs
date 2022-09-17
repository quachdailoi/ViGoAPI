using API.Models.DTO;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Extensions
{
    public static class JsonExtensions
    {
        public static string JsonValue(string column, string path)
        {
            throw new NotSupportedException();    
        }
    }
    public static class JsonExpressionTranslator
    {
        public static Expression Translate(IReadOnlyCollection<Expression> expressions)
        {
            var items = expressions.ToArray();
            return new JsonExpression(items[0], items[1]);
        }
    }

    public class JsonExpression : Expression
    {
        public Expression Column { get; private set; }
        public Expression Path { get; private set; }

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type => typeof(string);

        public JsonExpression(Expression column, Expression path)
        {
            Column = column;
            Path = path;
        }

        //protected override Expression Accept(ExpressionVisitor visitor)
        //{
        //    if(visitor is QuerySqlGenerator specificVisitor)
        //    {
        //        string sql = $"{Column.ToString().Trim('"')}";
        //        specificVisitor.GetType().GetMethod("VisitSqlFragment").Invoke(specificVisitor, new Array { new SqlFragmentExpression(sql) });
        //    }
        //}

        public override string ToString()
        {
            return base.ToString();
        }

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            return base.VisitChildren(visitor);
        }
    }
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null)
        {
        }
        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "dd-MM-yyyy";
        }
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return DateOnly.ParseExact(value!, serializationFormat);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(serializationFormat));
        }
    }
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null)
        {
        }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader,
                                Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.ParseExact(value!, serializationFormat);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value,
                                            JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public static class JsonConverterExtensions
    {
        public static void AddJsonConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new DateOnlyConverter());
            options.Converters.Add(new TimeOnlyConverter());
        }
    }
}
