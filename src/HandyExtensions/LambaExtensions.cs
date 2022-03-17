using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HandyExtensions
{
    /// <summary>
    /// Lambda Extensions.
    /// </summary>
    public static class LambdaExtensions
    {
        /// <summary>
        /// Get Member Info from expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="method">The method.</param>
        /// <returns>MemberExpression.</returns>
        /// <exception cref="System.ArgumentNullException">method</exception>
        public static MemberExpression GetMemberInfo<T, TValue>(this Expression<Func<T, TValue>> method)
        {
            if (method is not LambdaExpression lambda)
            {
                throw new ArgumentNullException(nameof(method));
            }

            var memberExpr = lambda.Body.NodeType switch
            {
                ExpressionType.Convert => ((UnaryExpression)lambda.Body).Operand as MemberExpression,
                ExpressionType.MemberAccess => lambda.Body as MemberExpression,
                _ => null
            };

            return memberExpr ?? throw new ArgumentNullException(nameof(method));
        }

        /// <summary>
        /// Gets the property value based on lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="memberLambda">The member lambda.</param>
        /// <returns>System.Nullable&lt;TValue&gt;.</returns>
        public static TValue? GetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> memberLambda)
        {
            var memberSelectorExpression = GetMemberInfo(memberLambda);


            if (memberSelectorExpression.Member is PropertyInfo property)
            {
                var val = property.GetValue(target, null);
                return val != null ? (TValue)val : default;
            }

            return default;
        }

        /// <summary>
        /// Set property value based on lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="memberLambda">The member lambda.</param>
        /// <param name="value">The value.</param>
        public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> memberLambda,
            TValue value)
        {
            var memberSelectorExpression = GetMemberInfo(memberLambda);

            if (memberSelectorExpression.Member is PropertyInfo property)
            {
                property.SetValue(target, value, null);
            }
        }
    }
}
