namespace TwitchMonitor.UI
{
    partial class DiceRollDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiInstantRollButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiOutputLabel = new System.Windows.Forms.Label();
            this.uiWheelSpinButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.uiOutputLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiWheelSpinButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiInstantRollButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiInstantRollButton
            // 
            this.uiInstantRollButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiInstantRollButton.Location = new System.Drawing.Point(20, 47);
            this.uiInstantRollButton.Margin = new System.Windows.Forms.Padding(10);
            this.uiInstantRollButton.Name = "uiInstantRollButton";
            this.uiInstantRollButton.Size = new System.Drawing.Size(232, 30);
            this.uiInstantRollButton.TabIndex = 1;
            this.uiInstantRollButton.Text = "INSTANT WINNER";
            this.uiInstantRollButton.UseVisualStyleBackColor = true;
            this.uiInstantRollButton.Click += new System.EventHandler(this.uiRollButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(519, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Roll the dice to pick a random subscriber!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiOutputLabel
            // 
            this.uiOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOutputLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiOutputLabel, 4);
            this.uiOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOutputLabel.Location = new System.Drawing.Point(3, 87);
            this.uiOutputLabel.Name = "uiOutputLabel";
            this.uiOutputLabel.Padding = new System.Windows.Forms.Padding(10);
            this.uiOutputLabel.Size = new System.Drawing.Size(519, 60);
            this.uiOutputLabel.TabIndex = 3;
            this.uiOutputLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uiWheelSpinButton
            // 
            this.uiWheelSpinButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiWheelSpinButton.Location = new System.Drawing.Point(272, 47);
            this.uiWheelSpinButton.Margin = new System.Windows.Forms.Padding(10);
            this.uiWheelSpinButton.Name = "uiWheelSpinButton";
            this.uiWheelSpinButton.Size = new System.Drawing.Size(232, 30);
            this.uiWheelSpinButton.TabIndex = 4;
            this.uiWheelSpinButton.Text = "WHEEL SPIN";
            this.uiWheelSpinButton.UseVisualStyleBackColor = true;
            this.uiWheelSpinButton.Click += new System.EventHandler(this.uiWheelSpinButton_Click);
            // 
            // DiceRollDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 147);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DiceRollDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Twitch Monitor - Dice Roll";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uiInstantRollButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiOutputLabel;
        private System.Windows.Forms.Button uiWheelSpinButton;
    }
}