using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public interface IPlanetFactory {
        Planet CreatePlanet(PlanetData planetData, Transform parentTransform);
    }
}