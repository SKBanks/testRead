using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.serialization;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.data.serialization.planet;
using UnityEngine;
using com.bandags.spacegame.input;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.planet {
    [Serializable]
    public class Planet : MonoBehaviour, IPlanet, ISerialize<PlanetData> {
        public PlanetType PlanetType {
            get => _planetData.PlanetType;
            set => _planetData.PlanetType = value;
        }
        public SystemType SystemType {
            get => _planetData.SystemType;
            set => _planetData.SystemType = value;
        }
        public bool Visited {
            get => _planetData.Visited;
            set => _planetData.Visited = value;
        }
        
        [SerializeField] private PlanetData _planetData;

        public void Select() { }
        public void UnSelect() { }
        public SelectableType GetSelectableType() {
            return SelectableType.Planet;
        }
        public string GetSelectableName() {
            return name;
        }
        public PlanetData Serialize() {
            return _planetData;
        }
        public void Deserialize(PlanetData planetData) {
            _planetData = planetData;
            name = _planetData.PlanetType.ToString();
            
            var planetFeatureData = new List<PlanetFeatureData> { 
                new PlanetDetailsPFData() //Add Common Panels
            };

            //Add Panel Data From Starting Data
            var systemStartingData = GameEngine.Instance.Galaxy.GalaxyStartingData.GetSystemByType(planetData.SystemType);
            systemStartingData.Planets.ForEach(planet => {
                if (planet.PlanetType != planetData.PlanetType) return;
                planet.PlanetFeatures.ForEach(planetFeature => {
                    planetFeatureData.Add(PlanetFeatureData.CreateFromScriptableObject(planetFeature));
                });
            });
            _planetData.PlanetFeatures = planetFeatureData;
        }
    }
}