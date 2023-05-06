using System.Collections.Generic;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.data {
    public class GalaxyStartingData {
        public readonly List<SystemScriptableObject> _systemStartingData;
        private readonly List<ShipScriptableObject> _shipStartingData;
        private readonly List<OutfitScriptableObject> _outfitStartingData;
        
        public GalaxyStartingData(List<SystemScriptableObject> systemStartingData, List<ShipScriptableObject> shipStartingData, List<OutfitScriptableObject> outfitStartingData) {
            _systemStartingData = systemStartingData;
            _shipStartingData = shipStartingData;
            _outfitStartingData = outfitStartingData;
        }

        public SystemScriptableObject GetSystemByType(SystemType systemType) {
            return _systemStartingData.Find(systemScriptableObject => systemScriptableObject.SystemType == systemType);
        }

        public ShipScriptableObject GetShipByType(ShipType shipType) {
            return _shipStartingData.Find(shipScriptableObject => shipScriptableObject.ShipType == shipType);
        }
        
        public OutfitScriptableObject GetOutfitByType(OutfitType outfitType) {
            return _outfitStartingData.Find(outfitScriptableObject => outfitScriptableObject.OutfitType == outfitType);
        }
    }
}