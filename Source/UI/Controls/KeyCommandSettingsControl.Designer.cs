namespace TwitchMonitor.UI.Controls
{
    partial class KeyCommandSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiWindowNameLabel = new System.Windows.Forms.Label();
            this.uiRemoveButton = new System.Windows.Forms.Button();
            this.uiEditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiClassNameTextBox = new System.Windows.Forms.TextBox();
            this.uiWindowNameTextBox = new System.Windows.Forms.TextBox();
            this.uiKeyCommandsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.uiWindowDimensionYTextBox = new System.Windows.Forms.TextBox();
            this.uiWindowDimensionXTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiNewKeyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiDescriptionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.uiWindowNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiRemoveButton, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiEditButton, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiClassNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiWindowNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiKeyCommandsListView, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiWindowDimensionYTextBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiWindowDimensionXTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiNewKeyButton, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Enabled = false;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 236);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // uiWindowNameLabel
            // 
            this.uiWindowNameLabel.AutoSize = true;
            this.uiWindowNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiWindowNameLabel.Location = new System.Drawing.Point(3, 0);
            this.uiWindowNameLabel.Name = "uiWindowNameLabel";
            this.uiWindowNameLabel.Size = new System.Drawing.Size(114, 26);
            this.uiWindowNameLabel.TabIndex = 0;
            this.uiWindowNameLabel.Text = "Main Window Name:";
            this.uiWindowNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiRemoveButton
            // 
            this.uiRemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRemoveButton.Location = new System.Drawing.Point(485, 210);
            this.uiRemoveButton.Name = "uiRemoveButton";
            this.uiRemoveButton.Size = new System.Drawing.Size(106, 23);
            this.uiRemoveButton.TabIndex = 10;
            this.uiRemoveButton.Text = "Remove";
            this.uiRemoveButton.UseVisualStyleBackColor = true;
            this.uiRemoveButton.Click += new System.EventHandler(this.uiRemoveButton_Click);
            // 
            // uiEditButton
            // 
            this.uiEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiEditButton.Location = new System.Drawing.Point(374, 210);
            this.uiEditButton.Name = "uiEditButton";
            this.uiEditButton.Size = new System.Drawing.Size(105, 23);
            this.uiEditButton.TabIndex = 11;
            this.uiEditButton.Text = "Edit...";
            this.uiEditButton.UseVisualStyleBackColor = true;
            this.uiEditButton.Click += new System.EventHandler(this.uiEditButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Name (Optional):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiClassNameTextBox
            // 
            this.uiClassNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiClassNameTextBox, 3);
            this.uiClassNameTextBox.Location = new System.Drawing.Point(123, 29);
            this.uiClassNameTextBox.Name = "uiClassNameTextBox";
            this.uiClassNameTextBox.Size = new System.Drawing.Size(134, 20);
            this.uiClassNameTextBox.TabIndex = 7;
            // 
            // uiWindowNameTextBox
            // 
            this.uiWindowNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiWindowNameTextBox, 3);
            this.uiWindowNameTextBox.Location = new System.Drawing.Point(123, 3);
            this.uiWindowNameTextBox.Name = "uiWindowNameTextBox";
            this.uiWindowNameTextBox.Size = new System.Drawing.Size(134, 20);
            this.uiWindowNameTextBox.TabIndex = 6;
            // 
            // uiKeyCommandsListView
            // 
            this.uiKeyCommandsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tableLayoutPanel1.SetColumnSpan(this.uiKeyCommandsListView, 3);
            this.uiKeyCommandsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiKeyCommandsListView.FullRowSelect = true;
            this.uiKeyCommandsListView.HideSelection = false;
            this.uiKeyCommandsListView.Location = new System.Drawing.Point(263, 3);
            this.uiKeyCommandsListView.Name = "uiKeyCommandsListView";
            this.tableLayoutPanel1.SetRowSpan(this.uiKeyCommandsListView, 4);
            this.uiKeyCommandsListView.Size = new System.Drawing.Size(328, 201);
            this.uiKeyCommandsListView.TabIndex = 8;
            this.uiKeyCommandsListView.UseCompatibleStateImageBehavior = false;
            this.uiKeyCommandsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Key";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IRC Command";
            this.columnHeader3.Width = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Window Dimensions:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiWindowDimensionYTextBox
            // 
            this.uiWindowDimensionYTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiWindowDimensionYTextBox.Location = new System.Drawing.Point(203, 55);
            this.uiWindowDimensionYTextBox.Name = "uiWindowDimensionYTextBox";
            this.uiWindowDimensionYTextBox.Size = new System.Drawing.Size(54, 20);
            this.uiWindowDimensionYTextBox.TabIndex = 5;
            // 
            // uiWindowDimensionXTextBox
            // 
            this.uiWindowDimensionXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiWindowDimensionXTextBox.Location = new System.Drawing.Point(123, 55);
            this.uiWindowDimensionXTextBox.Name = "uiWindowDimensionXTextBox";
            this.uiWindowDimensionXTextBox.Size = new System.Drawing.Size(54, 20);
            this.uiWindowDimensionXTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(183, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiNewKeyButton
            // 
            this.uiNewKeyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNewKeyButton.Location = new System.Drawing.Point(263, 210);
            this.uiNewKeyButton.Name = "uiNewKeyButton";
            this.uiNewKeyButton.Size = new System.Drawing.Size(105, 23);
            this.uiNewKeyButton.TabIndex = 9;
            this.uiNewKeyButton.Text = "New...";
            this.uiNewKeyButton.UseVisualStyleBackColor = true;
            this.uiNewKeyButton.Click += new System.EventHandler(this.uiNewKeyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.uiDescriptionLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(604, 280);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Commander Settings";
            // 
            // uiDescriptionLabel
            // 
            this.uiDescriptionLabel.AutoSize = true;
            this.uiDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDescriptionLabel.Location = new System.Drawing.Point(5, 18);
            this.uiDescriptionLabel.Name = "uiDescriptionLabel";
            this.uiDescriptionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiDescriptionLabel.Size = new System.Drawing.Size(85, 18);
            this.uiDescriptionLabel.TabIndex = 13;
            this.uiDescriptionLabel.Text = "Coming Soon!";
            // 
            // KeyCommandSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "KeyCommandSettingsControl";
            this.Size = new System.Drawing.Size(624, 521);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiWindowNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiWindowDimensionXTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiWindowDimensionYTextBox;
        private System.Windows.Forms.TextBox uiWindowNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uiRemoveButton;
        private System.Windows.Forms.Button uiEditButton;
        private System.Windows.Forms.TextBox uiClassNameTextBox;
        private System.Windows.Forms.ListView uiKeyCommandsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button uiNewKeyButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label uiDescriptionLabel;
    }
}
