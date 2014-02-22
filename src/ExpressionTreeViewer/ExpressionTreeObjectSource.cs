using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace ExpressionTreeViewer
{
	public class ExpressionTreeObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, System.IO.Stream outgoingData)
		{
			var expression = (Expression)target;
			var model = ExpressionTreeBuilder.GetExpressionTreeNodeModel(expression);
			Serialize(outgoingData, model);
		}
	}
}
