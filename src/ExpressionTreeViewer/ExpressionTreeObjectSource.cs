using System.Linq.Expressions;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace ExpressionTreeViewer
{
    public class ExpressionTreeObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, System.IO.Stream outgoingData)
        {
            ExpressionTreeNode root = ExpressionTreeBuilder.GetExpressionTreeNode((Expression)target);
            Serialize(outgoingData, root);
        }
    }
}
