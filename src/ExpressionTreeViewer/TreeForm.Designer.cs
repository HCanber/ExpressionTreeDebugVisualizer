namespace ExpressionTreeViewer
{
    partial class TreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.expressionTreeView = new System.Windows.Forms.TreeView();
            this.expressionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // expressionTreeView
            // 
            this.expressionTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTreeView.Location = new System.Drawing.Point(17, 16);
            this.expressionTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.expressionTreeView.Name = "expressionTreeView";
            this.expressionTreeView.Size = new System.Drawing.Size(945, 660);
            this.expressionTreeView.TabIndex = 0;
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTextBox.Location = new System.Drawing.Point(17, 683);
            this.expressionTextBox.Multiline = true;
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.ReadOnly = true;
            this.expressionTextBox.Size = new System.Drawing.Size(945, 130);
            this.expressionTextBox.TabIndex = 1;
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 834);
            this.Controls.Add(this.expressionTextBox);
            this.Controls.Add(this.expressionTreeView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TreeForm";
            this.Text = "Expression Tree Visulizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView expressionTreeView;
        private System.Windows.Forms.TextBox expressionTextBox;
    }
}

