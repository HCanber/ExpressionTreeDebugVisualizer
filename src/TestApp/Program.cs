using System;
using System.Linq;
using System.Linq.Expressions;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TestApp
{
	class Program
	{
		[STAThread]
		static void Main()
		{
			var languages = new[] { "C#", "J#", "VB", "Delphi", "F#", "COBOL", "Python" };
			var queryable = languages.AsQueryable().Where(l => l.EndsWith("#") && l != "j#")
					.Take(3).Select(l => new { Name = l, IsSelected = true });

			var expression = queryable.Expression;

			new VisualizerDevelopmentHost(expression, typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource)).ShowVisualizer();
		}
	}
}
