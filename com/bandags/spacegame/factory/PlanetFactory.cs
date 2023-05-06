using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public class PlanetFactory : IPlanetFactory {
        public Planet CreatePlanet(PlanetData planetData, Transform parentTransform) {
            var planet = Instantiation.InstantiatePrefab<Planet>("Prefabs/Planets/Planet");
            planet.Deserialize(planetData);
            planet.transform.localPosition = planetData.Position;
            planet.transform.localScale = planetData.Scale;
            planet.transform.SetParent(parentTransform, false);
            return planet;
        }
    }
}