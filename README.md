# Expression Tree Debug Visualizer for Visual Studio 2013
This project adds a debug visualizer to VS 2013 for Expression trees. The expression is displayed in a treeview.

Based on http://exprtreevisualizer.codeplex.com/.
Updated for Visual Studio 2013 and with WPF window instead of WinForm.


##To install
Copy the dll to any of the following locations:

- %userprofile%\Documents\Visual Studio 2013\Visualizers
- %programfiles(x86)%\Microsoft Visual Studio 12.0\Common7\Packages\Debugger\Visualizers
- %programfiles%\Microsoft Visual Studio 12.0\Common7\Packages\Debugger\Visualizers


##To use
Visualizers are represented in the debugger by a magnifying glass icon. 

![Click magnifying icon](https://raw.github.com/HCanber/ExpressionTreeDebugVisualizer/screenshots/show.png)

When you see the magnifying glass icon in a DataTip, in a debugger variables window, or in the QuickWatch dialog box, next to an Expression, you can click the magnifying glass to show the expression as a tree.

![Visualizing an Expression Tree](https://raw2.github.com/HCanber/ExpressionTreeDebugVisualizer/screenshots/visualizer.png)
