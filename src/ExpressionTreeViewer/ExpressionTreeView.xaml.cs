using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpressionTreeViewer
{
	/// <summary>
	/// Interaction logic for ExpressionTreeView.xaml
	/// </summary>
	public partial class ExpressionTreeView : UserControl
	{
		public ExpressionTreeView(ExpressionTreeNodeModel expression)
		{
			InitializeComponent();
			expression.IsSelected = true;
			ExprTreeView.ItemsSource = new[] { expression };
		
		}
	}
}
