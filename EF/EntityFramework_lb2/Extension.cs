using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_lb2
{
    public static class Extension
    {
        public static List<T2> ToModelList<T1, T2>(this IList<T1> enumer, Func<T1, T2> converDelegate)
        {
            var list = new List<T2>();
            foreach(var item in enumer)
            {
                list.Add(converDelegate(item));
            }
            return list;
        }

        //public static Expression<TDelegate> And<TDelegate>(this Expression<TDelegate> left, Expression<TDelegate> right)
        //{
        //    //var parameter = Expression.Parameter(left.Type, "x");

        //    return Expression.Lambda<TDelegate>(
        //            Expression.AndAlso(
        //                left.Body, 
        //                new ExpressionParameterReplacer(left.Parameters, right.Parameters).Visit(right.Body)),
        //                left.Parameters[0]
        //            );
          
        //}

        public static bool DecimalTryParce(string text)
        {
            decimal res;
            return Decimal.TryParse(text, out res);
        }
        public static bool IntTryParce(string text)
        {
            int res;
            return int.TryParse(text, out res);
        }
        public static int Parce(this string a, int defaultVal)
        {
            int res;
            if(int.TryParse(a, out res))
            {
                return res;
            }
            return defaultVal;
        }
        private class ExpressionParameterReplacer : ExpressionVisitor
        {
            public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
                ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
                for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                    ParameterReplacements.Add(fromParameters[i], toParameters[i]);
            }

            private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;
                if (ParameterReplacements.TryGetValue(node, out replacement))
                    node = replacement;
                return base.VisitParameter(node);
            }
        }
        
    }
    
}
