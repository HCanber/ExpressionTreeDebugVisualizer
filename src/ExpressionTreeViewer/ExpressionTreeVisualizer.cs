using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using Expression = System.Linq.Expressions.Expression;

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
			var model = (ExpressionTreeNodeModel)objectProvider.GetObject();
			var expressionTreeView = new ExpressionTreeView(model);
			var win = new WindowWithoutIcon
			{
				Title = "Expression Tree Visualizer",
				Width = 600,
				Height = 700,
				WindowStartupLocation = WindowStartupLocation.Manual,
				WindowStyle = WindowStyle.ToolWindow,
				Content = expressionTreeView
			};
			win.PreviewKeyUp += (sender, e) => { if(e.Key == System.Windows.Input.Key.Escape) win.Close(); };
			win.ShowDialog();
		}

	}
}
