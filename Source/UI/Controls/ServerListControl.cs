using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.UI.Controls
{
    public partial class ServerListControl : UserControl
    {
        private Engine engine;
        private bool sorted;
        private BindingSource bindingSource;

        public ServerListControl()
        {
            InitializeComponent();
            this.sorted = false;
            this.bindingSource = new BindingSource();
        }

        public void Initialize(Engine engine)
        {
            this.engine = engine;
            this.bindingSource.DataSource = this.engine.ServerPings.ServerListTable.DefaultView;
            this.uiServerListDataGridView.DataSource = this.bindingSource;
        }

        public void UpdateDataSource()
        {
            this.bindingSource.DataSource = this.engine.ServerPings.ServerListTable.DefaultView;
        }

        public void PauseUpdating()
        {
        }

        public void ResumeUpdating()
        {
        }

        private void uiServerListDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                int ping;
                if (e != null && e.ColumnIndex == 2 && e.Value != null && int.TryParse(e.Value.ToString(), out ping))
                {
                    if (ping <= 30)
                    {
                        e.CellStyle.BackColor = Color.Aquamarine;
                    }
                    else if (ping <= 100)
                    {
                        e.CellStyle.BackColor = Color.GreenYellow;
                    }
                    else if (ping <= 200)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception) { /* Ignore any exceptions thrown. */ }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiServerListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.uiServerListDataGridView.ClearSelection();
        }

        private void uiServerListDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!this.sorted)
            {
                try
                {
                    this.uiServerListDataGridView.Sort(this.uiServerListDataGridView.Columns[2], ListSortDirection.Ascending);
                }
                catch (Exception)
                {
                }

                this.sorted = true;
            }
        }

        private void ServerListControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.uiServerListDataGridView.Columns.Count > 0)
                {
                    this.uiServerListDataGridView.Columns[0].Width = 50;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
