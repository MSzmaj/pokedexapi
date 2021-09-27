using System;
using System.Linq.Expressions;
using PokedexApi.Common.Common;

namespace PokedexApi.Common.Extensions {
    public static class StringExtensions {
        
        public static Expression<Func<T, bool>> CompareUsingOperator<T> (this string comparisonOperator, int value, Expression<Func<T, int>> target) {
            var left = target.Body;
            var right = Expression.Constant(value);
            Expression condition;
            switch (comparisonOperator) {
                case Constants.LessThan: 
                    condition = Expression.LessThan(left, right);
                    break;
                case Constants.LessThanEqual: 
                    condition = Expression.LessThanOrEqual(left, right);
                    break;
                case Constants.GreaterThan:
                    condition = Expression.GreaterThan(left, right);
                    break;
                case Constants.GreaterThanEqual: 
                    condition = Expression.GreaterThanOrEqual(left, right);
                    break;
                case Constants.EqualTo:
                    condition = Expression.Equal(left, right);
                    break;
                default:
                    throw new InvalidOperationException($"{comparisonOperator} isn't valid");
            }

            return Expression.Lambda<Func<T, bool>>(condition, target.Parameters);
        }
    }
}