using System;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.player {
    [Serializable]
    public class PlayerState : ISerialize<PlayerStateData> {
        public SystemType CurrentSystem {
            get => _playerStateData.CurrentSystem;
            set => _playerStateData.CurrentSystem = value;
        }
        public PlanetType CurrentPlanet {
            get => _playerStateData.CurrentPlanet;
            set => _playerStateData.CurrentPlanet = value;
        }
        public int Credit {
            get => _playerStateData.Credit;
            set => _playerStateData.Credit = value;
        }
        [field: SerializeReference] private PlayerStateData _playerStateData;
        
        public PlayerStateData Serialize() {
            return _playerStateData;
        }
        public void Deserialize(PlayerStateData data) {
            _playerStateData = data;
        }
    }
}