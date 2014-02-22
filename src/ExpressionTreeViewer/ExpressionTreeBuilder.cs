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
					node = new ExpressionTreeNodeModel(expression, "BinaryExpression", value: expr.NodeType);
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Left, "Left"));
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Right, "Right"));
				}
				if(expression is BlockExpression)
				{
					var expr = expression as BlockExpression;
					node = new ExpressionTreeNodeModel(expression, "BlockExpression", nodesDescription: "Expressions:");
					expr.Expressions.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
				}
				if(expression is ConditionalExpression)
				{
					var expr = expression as ConditionalExpression;
					node = new ExpressionTreeNodeModel(expression, "ConditionalExpression", value: expr.NodeType);
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Test, "Test"));
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.IfTrue, "IfTrue"));
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.IfFalse, "IfFalse"));
				}
				if(expression is ConstantExpression)
				{
					var expr = expression as ConstantExpression;
					node = new ExpressionTreeNodeModel(expression, "ConstantExpression", value: string.Format("[{0}]: {1}", expr.Type.Name, expr.Value));
				}
				if(expression is DebugInfoExpression)
				{
					var expr = expression as DebugInfoExpression;
					node = new ExpressionTreeNodeModel(expression, "DebugInfoExpression");
				}
				if(expression is DefaultExpression)
				{
					var expr = expression as DefaultExpression;
					node = new ExpressionTreeNodeModel(expression, "DefaultExpression", value: expr.Type.Name);
				}
				if(expression is DynamicExpression)
				{
					var expr = expression as DynamicExpression;
					node = new ExpressionTreeNodeModel(expression, "DynamicExpression", nodesDescription: "Arguments", value: expr.DelegateType.Name);
					expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
				}
				if(expression is GotoExpression)
				{
					var expr = expression as GotoExpression;
					node = new ExpressionTreeNodeModel(expression, "GotoExpression", value: string.Format("{0}: {1}", expr.Kind, expr.Target));
				}
				if(expression is IndexExpression)
				{
					var expr = expression as IndexExpression;
					node = new ExpressionTreeNodeModel(expression, "IndexExpression", nodesDescription: "Arguments", value: expr.Indexer.Name);
					expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
				}
				if(expression is InvocationExpression)
				{
					var expr = expression as InvocationExpression;
					node = new ExpressionTreeNodeModel(expression, "InvocationExpression", nodesDescription: "Arguments", value: expr.Expression);
					expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Expression, "Expression"));
				}
				if(expression is LabelExpression)
				{
					var expr = expression as LabelExpression;
					node = new ExpressionTreeNodeModel(expression, "LabelExpression", value: string.Format("{0}:", expr.Target));
				}
				if(expression is LambdaExpression)
				{
					var expr = expression as LambdaExpression;
					node = new ExpressionTreeNodeModel(expression, "LambdaExpression", nodesDescription: "Body", value: expr.ReturnType);
					
						var n = new ExpressionTreeNodeModel(null, "Parameters");
						n.Nodes.AddRange(expr.Parameters.Select(t => GetExpressionTreeNodeModel(t)));

						node.Nodes.Add(n);
						node.Nodes.Add(GetExpressionTreeNodeModel(expr.Body));
				}
				if(expression is ListInitExpression)
				{
					var expr = expression as ListInitExpression;
					node = new ExpressionTreeNodeModel(expression, "ListInitExpression");
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.NewExpression));
				}
				if(expression is LoopExpression)
				{
					var expr = expression as LoopExpression;
					node = new ExpressionTreeNodeModel(expression, "LoopExpression", nodesDescription: "Body");
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Body));
				}
				if(expression is MemberExpression)
				{
					var expr = expression as MemberExpression;
					node = new ExpressionTreeNodeModel(expression, "MemberExpression", value: string.Format("{0}: {1}", expr.Type.Name, expr.Member.Name));
				}
				if(expression is MemberInitExpression)
				{
					var expr = expression as MemberInitExpression;
					node = new ExpressionTreeNodeModel(expression, "MemberInitExpression", value: expr.NewExpression.Type);
					expr.Bindings.ToList().ForEach(b => node.Nodes.Add(new ExpressionTreeNodeModel(expression,"xxxxx",b.ToString())));
				}
				if(expression is MethodCallExpression)
				{
					var expr = expression as MethodCallExpression;
					node = new ExpressionTreeNodeModel(expression, "MethodCallExpression", nodesDescription: "Arguments", value: expr.Method.Name);
					expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNodeModel(a)));
				}
				if(expression is NewArrayExpression)
				{
					var expr = expression as NewArrayExpression;
					node = new ExpressionTreeNodeModel(expression, "NewArrayExpression", value: expr.Type);
					expr.Expressions.ToList().ForEach(b => node.Nodes.Add(new ExpressionTreeNodeModel(expression,"xxxxx")));
				}
				if(expression is NewExpression)
				{
					var expr = expression as NewExpression;
					node = new ExpressionTreeNodeModel(expression, "NewExpression", nodesDescription: "Arguments");
					for(int i = 0; i < expr.Arguments.Count; i++)
						node.Nodes.Add(GetExpressionTreeNodeModel(expr.Arguments[i], expr.Members[i].Name));
				}
				if(expression is ParameterExpression)
				{
					var expr = expression as ParameterExpression;
					node = new ExpressionTreeNodeModel(expression, "ParameterExpression", value: string.Format("{0} {1}", expr.Type, expr.Name));
				}
				if(expression is RuntimeVariablesExpression)
				{
					var expr = expression as RuntimeVariablesExpression;
					node = new ExpressionTreeNodeModel(expression, "RuntimeVariablesExpression", nodesDescription:"Variables");
					node.Nodes.AddRange(expr.Variables.Select(e => GetExpressionTreeNodeModel(expr)));
				}
				if(expression is SwitchExpression)
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
				if(expression is TryExpression)
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
				if(expression is TypeBinaryExpression)
				{
					var expr = expression as TypeBinaryExpression;
					node = new ExpressionTreeNodeModel(expression, "TypeBinaryExpression",nodesDescription:"Operand",value:expr.TypeOperand);
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Expression));
				}
				if(expression is UnaryExpression)
				{
					var expr = expression as UnaryExpression;
					node = new ExpressionTreeNodeModel(expression, "UnaryExpression",nodesDescription:"Operand",value:expr.NodeType);
					node.Nodes.Add(GetExpressionTreeNodeModel(expr.Operand));
				}
				if(node == null)
					node = new ExpressionTreeNodeModel(expression,string.Format("Unknown Node [{0}-{1}]", expression.GetType().Name, expression.NodeType),value:expression.ToString());
				if(prefix != null)
					node.Prefix = prefix;
				node.ExpressionString = expression.ToString();
				return node;
			}
		}
}