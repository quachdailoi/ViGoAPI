using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

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
}
