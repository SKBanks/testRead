using System.Collections.Generic;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.system;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public class SystemLayerFactory : ISystemFactory {
        public SystemLayer CreateSystemLayer(int systemOffset, SystemLayerData systemLayerStartingData) {
            var systemLayer = Instantiation.InstantiatePrefab<SystemLayer>("SystemLayer");
            systemLayer.SystemLayerData = systemLayerStartingData;
            systemLayer.SystemOffset = systemOffset * 50;   //Todo: Should this go away now that we no longer load multiple systems?
            systemLayer.transform.position = new Vector3(systemLayer.transform.position.x, systemLayer.transform.position.y, systemLayer.SystemOffset);
            systemLayer.Planets = new List<Planet>();

            systemLayerStartingData.Planets.ForEach(planetData => {
                systemLayer.Planets.Add(GameEngine.Instance.Factory.PlanetFactory.CreatePlanet(planetData, systemLayer.ParentGameObjects.Planets.transform));
            });

            systemLayer.Ships = new List<Ship>();
            systemLayer.SystemBrain = new SystemBrain(systemLayer);
            return systemLayer;
        }
    }
}