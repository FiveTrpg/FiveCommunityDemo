using Gaming.API.Domain.Lobby.Events;
using System;
using System.Collections.Generic;

namespace Gaming.API.Domain.Lobby
{
    public class Lobby
    {
        public event Action<PlayerEntered> OnPlayerEntered;
        public event Action<PlayerLeaved> OnPlayerLeaved;
        public event Action<PlayerSetted> OnPlayerSetted;
        public event Action<PlayerStanded> OnPlayerStanded;
        public event Action<TablePlaced> OnTablePlaced;
        public event Action<TableRemoved> OnTableRemoved;

        public List<Player> Players { get; set; }
    }
}
