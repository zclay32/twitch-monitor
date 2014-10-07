using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TwitchMonitor.Core.Types
{
    public class ServerPingsDataTable : DataTable
    {
        public static readonly string ColumnId = "Id";
        public static readonly string ColumnName = "Name";
        public static readonly string ColumnPing = "Ping";

        public ServerPingsDataTable()
            : base()
        {
            this.Columns.Add(ColumnId, typeof(int));
            this.Columns.Add(ColumnName);
            this.Columns.Add(ColumnPing, typeof(long));
        }

        public void AddNewIngest(IngestJson ingest)
        {
            DataRow row = this.NewRow();
            row[ColumnId] = ingest.Id;
            row[ColumnName] = ingest.Name;
            row[ColumnPing] = 0;
            this.Rows.Add(row);
        }

        public void UpdatePingTime(string name, long ping)
        {
            foreach (DataRow row in this.Rows)
            {
                if (row[ColumnName].Equals(name))
                {
                    row[ColumnPing] = ping;
                    break;
                }
            }
        }
    }
}
