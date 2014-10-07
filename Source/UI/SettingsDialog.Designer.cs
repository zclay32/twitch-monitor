namespace TwitchMonitor
{
    partial class SettingsDialog
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
            this.uiOkButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiActiveSettingsPanel = new System.Windows.Forms.Panel();
            this.uiSettingsTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // uiOkButton
            // 
            this.uiOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOkButton.Location = new System.Drawing.Point(599, 491);
            this.uiOkButton.Name = "uiOkButton";
            this.uiOkButton.Size = new System.Drawing.Size(75, 23);
            this.uiOkButton.TabIndex = 20;
            this.uiOkButton.Text = "OK";
            this.uiOkButton.UseVisualStyleBackColor = true;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(680, 491);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 24;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiActiveSettingsPanel
            // 
            this.uiActiveSettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiActiveSettingsPanel.Location = new System.Drawing.Point(192, 13);
            this.uiActiveSettingsPanel.Name = "uiActiveSettingsPanel";
            this.uiActiveSettingsPanel.Size = new System.Drawing.Size(563, 473);
            this.uiActiveSettingsPanel.TabIndex = 35;
            // 
            // uiSettingsTreeView
            // 
            this.uiSettingsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.uiSettingsTreeView.FullRowSelect = true;
            this.uiSettingsTreeView.HideSelection = false;
            this.uiSettingsTreeView.Location = new System.Drawing.Point(12, 13);
            this.uiSettingsTreeView.Name = "uiSettingsTreeView";
            this.uiSettingsTreeView.Size = new System.Drawing.Size(174, 473);
            this.uiSettingsTreeView.TabIndex = 36;
            this.uiSettingsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.uiSettingsTreeView_AfterSelect);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 526);
            this.Controls.Add(this.uiSettingsTreeView);
            this.Controls.Add(this.uiActiveSettingsPanel);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiOkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Twitch Monitor Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiOkButton;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.Panel uiActiveSettingsPanel;
        private System.Windows.Forms.TreeView uiSettingsTreeView;
    }
}