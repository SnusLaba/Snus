using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SnusData.Attributes;
using System.Collections;

namespace EntityFramework_lb2.Managers
{
    public static class FilterManager
    {
        public static Expression<Func<T, bool>> GetFilterPredicate<T>(Object obj)
        {
            var objPropInfo = obj.GetType().GetProperties();

            var tPropInfo = typeof(T).GetProperties();
            var tAttributes = tPropInfo.Where(x => x.GetCustomAttributes(true).Any(y => y is FilterAttribute))
                                        .SelectMany(x => x.GetCustomAttributes(true).Where(y => y is FilterAttribute), (propInfo, filter) => new {propInfo, filter = (filter as FilterAttribute)});

            var xPar = Expression.Parameter(typeof(T));
            Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T, bool>>(Expression.Constant(true), xPar);
            Type typePred = predicate.GetType();

            foreach (var prop in objPropInfo)
            {
                var attribute = tAttributes.FirstOrDefault(y => y.filter.PropName == prop.Name);
                if (attribute == null)
                    continue;

                Expression<Func<T, bool>> lambda = null;
                var propAttr = Expression.PropertyOrField(xPar, attribute.propInfo.Name);
                var rightExpObj = prop.GetValue(obj);
                var rightExpConst = Expression.Constant(prop.GetValue(obj));
                if (rightExpConst == null || rightExpConst.Value == null || rightExpConst.Value.ToString() == "" || rightExpConst.Value.ToString() == "-1")
                    continue;
                switch(attribute.filter.Flag)
                {
                    case FilterFlag.ContainsFilterIn:
                        {                 
                            Expression toString = null;
                            if (propAttr.Type != typeof(string))
                            {
                                toString = ExpToString(propAttr);
                            }
                            else
                            {
                                toString = propAttr;
                            }
                            var contain = Expression.Call(toString, "Contains", null, rightExpConst);
                            lambda = Expression.Lambda<Func<T, bool>>(contain, xPar);
                            break;
                        }
                    case FilterFlag.Equal:
                        {
                            if (propAttr.Type == rightExpConst.Type)
                                lambda = Expression.Lambda<Func<T, bool>>(Expression.Equal(propAttr, rightExpConst), xPar);
                            else if (propAttr.Type.IsValueType)
                            {
                                Expression propAttrStr = ExpToString(propAttr);
                                Expression rightExpStr = ExpToString(rightExpConst);
                                lambda = Expression.Lambda<Func<T, bool>>(Expression.Equal(propAttrStr, rightExpStr), xPar);
                            }
                            break;
                        }
                    case FilterFlag.IntervalStart:
                        {
                            if (propAttr.Type == rightExpConst.Type)
                            {
                                lambda = Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(propAttr, rightExpConst), xPar);
                            }
                            break;
                        }
                    case FilterFlag.IntervalEnd:
                        {
                            if (propAttr.Type == rightExpConst.Type)
                                lambda = Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(propAttr, rightExpConst), xPar);
                            break;
                        }
                    case FilterFlag.Down:
                        {
                            var expr = GetFilterPredicate<SnusData.Entitys.Type>(rightExpObj);
                            var body = expr.Body;
                            var a = Expression.Lambda<Func<T, bool>>(body, xPar);

                            break;
                        }
                }
                if (lambda != null)
                {
                    if(!propAttr.Type.IsValueType)
                    {
                        predicate.And(Expression.Lambda<Func<T, bool>>(Expression.IsFalse(Expression.Equal(propAttr, Expression.Constant(null))), xPar));
                    }
                    predicate = predicate.And(lambda);
                }
            }
            return predicate;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            InvocationExpression invocationExpression = Expression.Invoke((Expression)exp2, Enumerable.Cast<Expression>((IEnumerable)exp1.Parameters));
            return Expression.Lambda<Func<T, bool>>((Expression)Expression.AndAlso(exp1.Body, (Expression)invocationExpression), (IEnumerable<ParameterExpression>)exp1.Parameters);
        }

        public static Expression ExpToString(Expression instance)
        {
            if(instance.Type.IsValueType && instance.Type != typeof(string))
                return Expression.Call(instance, "ToString", null, null);
            return instance;
        }

        public static bool TryCast<T>(this object obj, out T result)
        {
            if (obj is T)
            {
                result = (T)obj;
                return true;
            }

            result = default(T);
            return false;
        }
    }

    
}
