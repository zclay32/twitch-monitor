using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public enum BotCommandsAccess
    {
        ChannelOwnerOnly,
        AllModerators,
        SelectModerators,
        SelectUsers
    }
}
