using System;
using System.Windows;

namespace ExpressionTreeViewer
{
	public class WindowWithoutIcon : Window
	{
		public WindowWithoutIcon()
		{
			//base.InitializeComponent();
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			IconHelper.RemoveIcon(this);
		}
	}
}