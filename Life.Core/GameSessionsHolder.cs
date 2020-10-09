using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core
{
    class GameSessionsHolder
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly List<GameSession> _sessions;
        public GameSessionsHolder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _sessions = new List<GameSession>();
        }

        public void CreateNewSession()
        {
            
        }
    }
}
