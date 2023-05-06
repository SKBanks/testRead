using System.Collections.Generic;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.ui.map {
    public class MapDataManager : MonoBehaviour {
        private List<MapSystem> _mapSystems;
        private MapSystem _selectedMapSystem;
        public void SelectSystem(MapSystem mapSystem) {
            if (_selectedMapSystem != null) {
                _selectedMapSystem.UnSelect();
            }

            _selectedMapSystem = mapSystem;
            GameEngine.Instance.UIManager.SelectedSystemType = _selectedMapSystem.SystemLayerData.SystemType;
        }
        public void LoadSystems(List<SystemLayerData> systemDataList) {
            _selectedMapSystem = null;
            _mapSystems?.ForEach(Destroy);
            _mapSystems = new List<MapSystem>(systemDataList.Count);
            
            systemDataList.ForEach(systemData => {
                _mapSystems.Add(CreatePlanetIcon(systemData, gameObject));
            });
        }
        private MapSystem CreatePlanetIcon(SystemLayerData systemLayerData, GameObject planetParent) {
            var mapSystem = Instantiation.InstantiatePrefab<MapSystem>("Prefabs/Map/MapSystem");
            mapSystem.transform.position = systemLayerData.MapPosition;
            mapSystem.name = systemLayerData.SystemType.ToString();
            mapSystem.SystemLayerData = systemLayerData;
            mapSystem.transform.SetParent(planetParent.transform, false);
            mapSystem.TextNameText.text = mapSystem.name;
            mapSystem.MapDataManager = this;
            return mapSystem;
        }
        private void CreateNeighborhoodJumpLines() {
            //loop through each planet creating a pair between it and all its neighbors without a hyperspace line to this planet
            //draw all pairs
        }
    }
}