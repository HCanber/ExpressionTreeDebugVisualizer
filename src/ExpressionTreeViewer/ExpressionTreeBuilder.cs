﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeViewer
{
	public static class ExpressionTreeBuilder
	{
		public static ExpressionTreeNodeModel GetExpressionTreeNodeModel(Expression expression, string prefix = null)
		{
			ExpressionTreeNodeModel node = null;
			if(expression is BinaryExpression)
			{
				var expr = expression as BinaryExpression;
				node = new ExpressionTreeNodeModel(expression, "BinaryExpression", value: expr.NodeType.ToString());
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Left, "Left"));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Right, "Right"));
			}
			else if(expression is BlockExpression)
			{
				var expr = expression as BlockExpression;
				node = new ExpressionTreeNodeModel(expression, "BlockExpression", nodesDescription: "Expressions:");
				expr.Expressions.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
			}
			else if(expression is ConditionalExpression)
			{
				var expr = expression as ConditionalExpression;
				node = new ExpressionTreeNodeModel(expression, "ConditionalExpression", value: expr.NodeType.ToString());
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Test, "Test"));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.IfTrue, "IfTrue"));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.IfFalse, "IfFalse"));
			}
			else if(expression is ConstantExpression)
			{
				var expr = expression as ConstantExpression;
				var value = expr.Value;
				string valueStr;
				if(value == null) valueStr = "<null>";
				else if(value is string) valueStr = "\"" + value + "\"";
				else valueStr = value.ToString();
				node = new ExpressionTreeNodeModel(expression, "ConstantExpression", value: string.Format("[{0}]: {1}", GetTypeName(expr.Type), valueStr));
			}
			else if(expression is DebugInfoExpression)
			{
				var expr = expression as DebugInfoExpression;
				node = new ExpressionTreeNodeModel(expression, "DebugInfoExpression");
			}
			else if(expression is DefaultExpression)
			{
				var expr = expression as DefaultExpression;
				node = new ExpressionTreeNodeModel(expression, "DefaultExpression", value: "default(" + GetTypeName(expr.Type) + ")");
			}
			else if(expression is DynamicExpression)
			{
				var expr = expression as DynamicExpression;
				node = new ExpressionTreeNodeModel(expression, "DynamicExpression", nodesDescription: "Arguments", value: GetTypeName(expr.DelegateType));
				expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
			}
			else if(expression is GotoExpression)
			{
				var expr = expression as GotoExpression;
				node = new ExpressionTreeNodeModel(expression, "GotoExpression", value: string.Format("{0}: {1}", expr.Kind, expr.Target));
			}
			else if(expression is IndexExpression)
			{
				var expr = expression as IndexExpression;
				node = new ExpressionTreeNodeModel(expression, "IndexExpression", nodesDescription: "Arguments", value: expr.Indexer.Name);
				expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
			}
			else if(expression is InvocationExpression)
			{
				var expr = expression as InvocationExpression;
				node = new ExpressionTreeNodeModel(expression, "InvocationExpression", nodesDescription: "Arguments");
				expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Expression, "Expression"));
			}
			else if(expression is LabelExpression)
			{
				var expr = expression as LabelExpression;
				node = new ExpressionTreeNodeModel(expression, "LabelExpression", value: string.Format("{0}:", expr.Target));
			}
			else if(expression is LambdaExpression)
			{
				var expr = expression as LambdaExpression;
				node = new ExpressionTreeNodeModel(expression, "LambdaExpression", nodesDescription: "Body", value: GetTypeName(expr.ReturnType));

				var n = new ExpressionTreeNodeModel(null, "Parameters");
				n.Nodes.AddRange(expr.Parameters.Select(t => GetExpressionTreeNodeModel(t)));

				node.Nodes.Add(n);
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Body));
			}
			else if(expression is ListInitExpression)
			{
				var expr = expression as ListInitExpression;
				node = new ExpressionTreeNodeModel(expression, "ListInitExpression");
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.NewExpression));
			}
			else if(expression is LoopExpression)
			{
				var expr = expression as LoopExpression;
				node = new ExpressionTreeNodeModel(expression, "LoopExpression", nodesDescription: "Body");
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Body));
			}
			else if(expression is MemberExpression)
			{
				var expr = expression as MemberExpression;
				node = new ExpressionTreeNodeModel(expression, "MemberExpression", value: string.Format("{0}: {1}", GetTypeName(expr.Type), expr.Member.Name));
			}
			else if(expression is MemberInitExpression)
			{
				var expr = expression as MemberInitExpression;
				node = new ExpressionTreeNodeModel(expression, "MemberInitExpression", value: GetTypeName(expr.NewExpression.Type));
				expr.Bindings.ToList().ForEach(b => node.Nodes.Add(new ExpressionTreeNodeModel(null, "MemberBinding", b.ToString())));
			}
			else if(expression is MethodCallExpression)
			{
				var expr = expression as MethodCallExpression;
				node = new ExpressionTreeNodeModel(expression, "MethodCallExpression", nodesDescription: "Arguments", value: expr.Method.Name);
				expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
			}
			else if(expression is NewArrayExpression)
			{
				var expr = expression as NewArrayExpression;
				node = new ExpressionTreeNodeModel(expression, "NewArrayExpression", value: GetTypeName(expr.Type));
				expr.Expressions.ToList().ForEach(b => node.Nodes.Add(new ExpressionTreeNodeModel(expression, "xxxxx")));
			}
			else if(expression is NewExpression)
			{
				var expr = expression as NewExpression;
				node = new ExpressionTreeNodeModel(expression, "NewExpression", nodesDescription: "Arguments");
				for(int i = 0; i < expr.Arguments.Count; i++)
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Arguments[i], expr.Members[i].Name));
			}
			else if(expression is ParameterExpression)
			{
				var expr = expression as ParameterExpression;
				node = new ExpressionTreeNodeModel(expression, "ParameterExpression", value: string.Format("{0} {1}", GetTypeName(expr.Type), expr.Name));
			}
			else if(expression is RuntimeVariablesExpression)
			{
				var expr = expression as RuntimeVariablesExpression;
				node = new ExpressionTreeNodeModel(expression, "RuntimeVariablesExpression", nodesDescription: "Variables");
				node.Nodes.AddRange(expr.Variables.Select(e => GetExpressionTreeNodeModel(expr)));
			}
			else if(expression is SwitchExpression)
			{
				var expr = expression as SwitchExpression;
				node = new ExpressionTreeNodeModel(expression, "SwitchExpression");
				node.Nodes.AddRange(expr.Cases.Select((c, i) =>
				{
					var n = new ExpressionTreeNodeModel(null, "Case");
					n.Nodes.AddRange(c.TestValues.Select(t => GetExpressionTreeNodeModel(t, "Value")));
					n.Nodes.Add(GetExpressionTreeNodeModel(c.Body, "Body"));
					return n;
				}));
			}
			else if(expression is TryExpression)
			{
				var expr = expression as TryExpression;
				node = new ExpressionTreeNodeModel(expression, "TryExpression");
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Body, "Try"));
				node.Nodes.AddRange(expr.Handlers.Select((c, i) =>
				{
					var n = new ExpressionTreeNodeModel(null, "Catch");
					n.Nodes.Add(GetExpressionTreeNodeModel(c.Filter, "Filter"));
					n.Nodes.Add(GetExpressionTreeNodeModel(c.Body, "Body"));
					return n;
				}));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Finally, "Finally"));
			}
			else if(expression is TypeBinaryExpression)
			{
				var expr = expression as TypeBinaryExpression;
				node = new ExpressionTreeNodeModel(expression, "TypeBinaryExpression", nodesDescription: "Operand", value: GetSimpleExpression(expr.Expression, "operand") + " is " + GetTypeName(expr.TypeOperand));
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Expression));
			}
			else if(expression is UnaryExpression)
			{
				var expr = expression as UnaryExpression;
				node = new ExpressionTreeNodeModel(expression, "UnaryExpression", nodesDescription: "Operand", value: expr.NodeType.ToString());
				node.Nodes.Add(GetExpressionTreeNodeModel(expr.Operand));
			}
			else
				node = new ExpressionTreeNodeModel(expression, string.Format("Unknown Node [{0}-{1}]", expression.GetType().Name, expression.NodeType), value: expression.ToString());
			if(prefix != null)
				node.Prefix = prefix;
			node.ExpressionString = expression.ToString();
			return node;
		}

		private static string GetSimpleExpression(Expression expression, string defaultValue)
		{
			if(expression is ConstantExpression)
			{
				var expr = expression as ConstantExpression;
				var value = expr.Value;
				string valueStr;
				if(value == null) valueStr = "<null>";
				else if(value is string) valueStr = "\"" + value + "\"";
				else valueStr = value.ToString();
				return valueStr;
			}
			if(expression is DefaultExpression)
			{
				var expr = expression as DefaultExpression;
				return "default(" + expr.Type.Name + ")";
			}
			if(expression is ParameterExpression)
			{
				var expr = expression as ParameterExpression;
				return expr.Name;
			}
			return defaultValue;
		}

		public static string GetTypeName(Type type)
		{
			if(type == typeof(byte)) return "byte";
			if(type == typeof(sbyte)) return "sbyte";
			if(type == typeof(short)) return "short";
			if(type == typeof(ushort)) return "ushort";
			if(type == typeof(int)) return "int";
			if(type == typeof(uint)) return "uint";
			if(type == typeof(long)) return "long";
			if(type == typeof(ulong)) return "ulong";
			if(type == typeof(float)) return "float";
			if(type == typeof(double)) return "double";
			if(type == typeof(decimal)) return "decimal";
			if(type == typeof(char)) return "char";
			if(type == typeof(string)) return "string";
			if(type == typeof(bool)) return "bool";
			if(type == typeof(object)) return "object";
			if(type == typeof(void)) return "void";
			if(type.IsGenericType)
			{
				var genTypeDef = type.GetGenericTypeDefinition();
				var genTypeName =
					(typeof(List<>).IsAssignableFrom(genTypeDef)) ? "List" :
					(typeof(Dictionary<,>).IsAssignableFrom(genTypeDef)) ? "Dictionary" :
					(typeof(IEnumerable<>).IsAssignableFrom(genTypeDef)) ? "IEnumerable" :
					(genTypeDef.FullName.StartsWith("System.Func")) ? "Func" :
					(genTypeDef.FullName.StartsWith("System.Predicate")) ? "Predicate" :
					(genTypeDef.FullName.StartsWith("System.Action")) ? "Action" :
					(genTypeDef.Namespace == "System.Collections.Generic") ? genTypeDef.Name :
					(genTypeDef.FullName.StartsWith("System.Tuple") && genTypeDef.GetInterfaces().Any(i => i.FullName == "System.ITuple")) ? "Tuple" :
					genTypeDef.Name;

				var genArgs = string.Join(", ", type.GetGenericArguments().Select(GetTypeName));
				return genTypeName + '<' + genArgs + '>';
			}
			if(type.IsArray)
			{
				var elementType = GetTypeName(type.GetElementType());
				var ranks = string.Join("", Enumerable.Repeat("[]", type.GetArrayRank()));
				return elementType + ranks;
			}
			if(type.Namespace == "System.Collections") return type.Name;
			if(type.Namespace == "System") return type.Name;

			return type.FullName;
		}
	}
}