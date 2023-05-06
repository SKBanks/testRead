using System;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    [Serializable]
    public class Tactical : ITactical {
        [field: SerializeReference] public IHardpointManager HardpointManager { get; private set; }
        [field: SerializeReference] public ITacticalProperties TacticalProperties { get; private set; }
        public ITacticalAI TacticalAI { get; private set; }
        private IOutfitManager _outfitManager;
        public Tactical(Ship ship) {
            _outfitManager = ship.OutfitManager;
            HardpointManager = new HardpointManager();
            TacticalProperties = new TacticalProperties();
            TacticalAI = new TacticalAI(ship);
        }

        public void UpdateOutfits() {
            TacticalProperties.UpdateOutfits(_outfitManager);
        }
    }
}