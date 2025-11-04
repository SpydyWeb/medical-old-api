using System;
using System.Linq;
using System.Linq.Expressions;
using WorkflowCore.Interface;

namespace WorkflowCore.Models
{
	public class MemberMapParameter : IStepParameter
	{
		private readonly LambdaExpression _source;

		private readonly LambdaExpression _target;

		public MemberMapParameter(LambdaExpression source, LambdaExpression target)
		{
			if (target.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new NotSupportedException();
			}
			_source = source;
			_target = target;
		}

		private void Assign(object sourceObject, LambdaExpression sourceExpr, object targetObject, LambdaExpression targetExpr, IStepExecutionContext context)
		{
			object obj = null;
			obj = sourceExpr.Parameters.Count switch
			{
				1 => sourceExpr.Compile().DynamicInvoke(sourceObject), 
				2 => sourceExpr.Compile().DynamicInvoke(sourceObject, context), 
				_ => throw new ArgumentException(), 
			};
			if (obj == null)
			{
				Expression.Lambda(Expression.Assign(targetExpr.Body, Expression.Default(targetExpr.ReturnType)), targetExpr.Parameters.Single()).Compile().DynamicInvoke(targetObject);
			}
			else
			{
				UnaryExpression right = Expression.Convert(Expression.Constant(obj), targetExpr.ReturnType);
				Expression.Lambda(Expression.Assign(targetExpr.Body, right), targetExpr.Parameters.Single()).Compile().DynamicInvoke(targetObject);
			}
		}

		public void AssignInput(object data, IStepBody body, IStepExecutionContext context)
		{
			Assign(data, _source, body, _target, context);
		}

		public void AssignOutput(object data, IStepBody body, IStepExecutionContext context)
		{
			Assign(body, _source, data, _target, context);
		}
	}
}
