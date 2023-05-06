using System;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class PlayerStateData {
        public SystemType CurrentSystem;
        public PlanetType CurrentPlanet;
        public int Credit;
    }
}