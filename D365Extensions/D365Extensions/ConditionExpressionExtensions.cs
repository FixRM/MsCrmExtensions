﻿using D365Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>
    /// Strongly typed version of ConditionExpression
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConditionExpression<T> where T : Entity
    {
        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        /// </summary>
        public ConditionExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        /// class.
        /// </summary>
        /// <param name="entityName">The logical name of the entity in the condition expression.</param>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        /// <param name="values">The array of attribute values.</param>
        public ConditionExpression(string entityName, Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator, params object[] values)
        {
            EntityName = entityName;
            AttributeName = attributeName;
            Operator = conditionOperator;
            if (values != null)
            {
                Values = new List<object>(values);
            }
        }

        /// </summary>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        public ConditionExpression(Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator) : this(null, attributeName, conditionOperator, new object[0])
        {
        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        //  class setting the attribute name, condition operator and an array of value objects.
        /// </summary>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        /// <param name="values">The array of attribute values.</param>
        public ConditionExpression(Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator, params object[] values) : this(null, attributeName, conditionOperator, values)
        {

        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        /// class setting the attribute name, condition operator and value object.
        /// </summary>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        /// <param name="value">The attribute value</param>
        public ConditionExpression(Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator, object value) : this(null, attributeName, conditionOperator, new object[] { value })
        {

        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        /// class.
        /// </summary>
        /// <param name="entityName">The logical name of the entity in the condition expression.</param>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        public ConditionExpression(string entityName, Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator) : this(entityName, attributeName, conditionOperator, new object[0])
        {

        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.Query.ConditionExpression
        /// class.
        /// </summary>
        /// <param name="entityName">The logical name of the entity in the condition expression.</param>
        /// <param name="attributeName">The logical name of the attribute in the condition expression.</param>
        /// <param name="conditionOperator">The condition operator.</param>
        /// <param name="value">The attribute value.</param>
        public ConditionExpression(string entityName, Expression<Func<T, object>> attributeName, ConditionOperator conditionOperator, object value) : this(entityName, attributeName, conditionOperator, new object[] { value })
        {

        }

        /// <summary>
        /// Gets or sets the entity name for the condition.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the logical name of the attribute in the condition expression.
        /// </summary>
        public Expression<Func<T, object>> AttributeName { get; set; }

        /// <summary>
        /// Gets or sets the condition operator.
        /// </summary>
        public ConditionOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the values for the attribute.
        /// </summary>
        public List<object> Values { get; }

        /// <summary>
        /// Converts ConditionExpression<T> to ConditionExpression
        /// </summary>
        /// <param name="t"></param>
        public static implicit operator ConditionExpression(ConditionExpression<T> t)
        {
            return new ConditionExpression(t.EntityName,
                ProperyExpression.GetName(t.AttributeName),
                t.Operator,
                t.Values.ToArray());
        }
    }
}