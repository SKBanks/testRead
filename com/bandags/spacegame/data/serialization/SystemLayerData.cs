using System;
using System.Collections.Generic;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class SystemLayerData {
        public string Name;
        public SystemType SystemType;
        public List<PlanetData> Planets;
        public List<SystemType> Neighbors;
        public ShipGroupCollectionScriptableObject ShipGroupCollection;
        public Vector3 MapPosition;

        public static SystemLayerData CreateFromScriptableObject(SystemScriptableObject systemScriptableObject) {
            return new SystemLayerData {
                Name = systemScriptableObject.Name,
                SystemType = systemScriptableObject.SystemType,
                Planets = GetPlanetDataFromScriptableObject(systemScriptableObject.Planets),
                Neighbors = systemScriptableObject.Neighbors,
                ShipGroupCollection = systemScriptableObject.ShipGroupCollection,
                MapPosition = systemScriptableObject.MapPosition
            };
        }
        private static List<PlanetData> GetPlanetDataFromScriptableObject(List<PlanetScriptableObject> planetScriptableObjects) {
            var list = new List<PlanetData>();
            planetScriptableObjects.ForEach(planetScriptableObject => {
                list.Add(PlanetData.CreateFromScriptableObject(planetScriptableObject));
            });
            return list;
        }
        
    }
}