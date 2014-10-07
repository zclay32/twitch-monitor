namespace TwitchMonitor.UI.Controls
{
    partial class ServerListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiServerListDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uiServerListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiServerListDataGridView
            // 
            this.uiServerListDataGridView.AllowUserToAddRows = false;
            this.uiServerListDataGridView.AllowUserToDeleteRows = false;
            this.uiServerListDataGridView.AllowUserToResizeRows = false;
            this.uiServerListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiServerListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiServerListDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.uiServerListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiServerListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uiServerListDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiServerListDataGridView.MultiSelect = false;
            this.uiServerListDataGridView.Name = "uiServerListDataGridView";
            this.uiServerListDataGridView.ReadOnly = true;
            this.uiServerListDataGridView.RowHeadersVisible = false;
            this.uiServerListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiServerListDataGridView.Size = new System.Drawing.Size(509, 351);
            this.uiServerListDataGridView.TabIndex = 5;
            this.uiServerListDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.uiServerListDataGridView_CellPainting);
            this.uiServerListDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.uiServerListDataGridView_RowsAdded);
            this.uiServerListDataGridView.SelectionChanged += new System.EventHandler(this.uiServerListDataGridView_SelectionChanged);
            // 
            // ServerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiServerListDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ServerListControl";
            this.Size = new System.Drawing.Size(509, 351);
            this.Load += new System.EventHandler(this.ServerListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiServerListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uiServerListDataGridView;
    }
}
