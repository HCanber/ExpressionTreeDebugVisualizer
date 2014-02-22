using System.Diagnostics;
using System.Linq.Expressions;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(Expression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(BinaryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(BlockExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(ConditionalExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(ConstantExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(DebugInfoExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(DefaultExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(DynamicExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(GotoExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(IndexExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(InvocationExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(LabelExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(LambdaExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(ListInitExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(LoopExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(MemberExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(MemberInitExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(MethodCallExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(NewArrayExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(NewExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(ParameterExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(RuntimeVariablesExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(SwitchExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(TryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(TypeBinaryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource), Target = typeof(UnaryExpression), Description = "Expression Tree Visualizer")]

namespace ExpressionTreeViewer
{
    public class ExpressionTreeVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var treeForm = new TreeForm();
            treeForm.RenderExpression((ExpressionTreeNode)objectProvider.GetObject());
            treeForm.ShowDialog();
        }
    }
}
