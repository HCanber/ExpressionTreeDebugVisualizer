using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeViewer
{
	[Serializable]
	public class ExpressionTreeNodeModel
	{
		public ExpressionTreeNodeModel(Expression expression,string name,  string nodesDescription = "", object value=null)
		{
			NodeType = expression == null ? null: expression.NodeType.ToString();
			Name = name;
			NodesDescription = nodesDescription;
			Value = value;
			Nodes=new List<ExpressionTreeNodeModel>();
			IsExpanded = true;
		}

		public string NodeType { get; set; }
		public string Name { get; set; }
		public string NodesDescription { get; set; }
		public object Value { get; set; }
		public List<ExpressionTreeNodeModel> Nodes { get; private set; }
		public string ExpressionString { get; set; }
		public string Prefix { get; set; }

		public bool IsSelected { get; set; }
		public bool IsExpanded { get; set; }

		public bool IsPrefixSet { get { return !string.IsNullOrEmpty(Prefix); } }
		public bool IsNodesDescriptionSet { get { return !string.IsNullOrEmpty(NodesDescription); } }
	}
}