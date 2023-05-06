using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using UnityEngine;
using Random = UnityEngine.Random;


namespace com.bandags.spacegame.system {
    [Serializable]
    public class SystemLayer : MonoBehaviour, ISerialize<SystemLayerData> {
        [field: SerializeReference] public SystemLayerGameObjectParents ParentGameObjects;
        public SystemBrain SystemBrain { get; set; }
        public SystemLayerData SystemLayerData { get; set; }
        public int SystemOffset { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Ship> Ships { get; set; }
        public void OnActivate() {
            gameObject.SetActive(true);
            SystemBrain.ResetSystem();
            GameEngine.Instance.MouseInput.Enabled = true;
        }

        public void OnDeactivate() {
            GameEngine.Instance.Galaxy.SaveSystemData(this);
            Destroy(gameObject);
        }

        public void AddShip(Ship ship) {
            Ships.Add(ship);
            ship.transform.SetParent(ParentGameObjects.Ships.transform, false);
        }
        
        public SystemLayerData Serialize() {
            SystemLayerData.Planets.Clear();
            Planets.ForEach(planet => {
                SystemLayerData.Planets.Add(planet.Serialize());
            });
            return SystemLayerData;
        }
        public void Deserialize(SystemLayerData layerData) {
            SystemLayerData = layerData;
            
            SystemLayerData.Planets.ForEach(planetData => {
                Planets.Find(iterator=> iterator.PlanetType == planetData.PlanetType).Deserialize(planetData);
            });
        }

        public Planet GetRandomPlanet() {
            return Planets.Count == 0 ? null : Planets[Random.Range(0, Planets.Count)];
        }

        public Planet GetPlanetByType(PlanetType planetType) {
            return Planets.First(planet => planet.PlanetType == planetType);
        }
    }
}