using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Interfaces
{
    public interface ISettingsView
    {
        bool IsLoading { get; }
        Engine Engine { get; set; }
        void ChangeDetected();
    }
}
