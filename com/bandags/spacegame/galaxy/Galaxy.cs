using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.galaxy { 
    [Serializable]
    public class Galaxy : ISerialize<GalaxyData> {
        public SystemLayer ActiveSystem;
        
        private readonly Dictionary<SystemType, SystemLayerData> _systemData;
        public readonly GalaxyStartingData GalaxyStartingData;
        
        public int SystemLayerOffset;

        public Galaxy(List<SystemScriptableObject> systemStartingData, List<ShipScriptableObject> shipScriptableObjects, List<OutfitScriptableObject> outfitStartingData) {
            GalaxyStartingData = new GalaxyStartingData(systemStartingData, shipScriptableObjects, outfitStartingData);
            _systemData = new Dictionary<SystemType, SystemLayerData>();
        }

        public void ActivateNewSystem(SystemLayer systemLayer) {
            ActiveSystem?.OnDeactivate();
            ActiveSystem = systemLayer;
            ActiveSystem.OnActivate();
        }

        public void SaveSystemData(SystemLayer systemLayer) {
            _systemData[systemLayer.SystemLayerData.SystemType] = systemLayer.SystemLayerData;
        }

        public SystemLayerData GetSystemDataByType(SystemType systemType) {
            return _systemData.ContainsKey(systemType) ? _systemData[systemType] : CreateSystemData(systemType);
        }

        public List<SystemLayerData> GetAllSystemData() {
            return _systemData.Values.ToList();
        }

        private SystemLayerData CreateSystemData(SystemType systemType) {
            var systemData = SystemLayerData.CreateFromScriptableObject(GalaxyStartingData.GetSystemByType(systemType));
            _systemData.Add(systemType, systemData);
            return systemData;
        }
        
        public GalaxyData Serialize() {
            return new GalaxyData {
                ActiveSystemLayer = ActiveSystem.Serialize(),
                SystemsData = _systemData.Values.ToList()
            };
        }

        public void Deserialize(GalaxyData data) {
            data.SystemsData.ForEach(systemsData => {
                _systemData.Add(systemsData.SystemType, systemsData);
            });
            
            GalaxyStartingData._systemStartingData.ForEach(systemData => {
                if (_systemData.ContainsKey(systemData.SystemType)) return;
                CreateSystemData(systemData.SystemType);
            });
            
            var systemLayer = GameEngine.Instance.Factory.SystemFactory.CreateSystemLayer(SystemLayerOffset, GetSystemDataByType(data.ActiveSystemLayer.SystemType));
            systemLayer.Deserialize(data.ActiveSystemLayer);
            ActivateNewSystem(systemLayer);
        }
    }
}