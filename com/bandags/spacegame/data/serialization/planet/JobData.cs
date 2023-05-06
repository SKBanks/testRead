using System;
using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.data.serialization.planet {
    [Serializable]
    public class JobData {
        public JobType JobType;
        public string JobDescription;
        public int CargoAmount;
        public CargoType CargoType;
        public PlanetType TargetPlanet;
        public SystemType TargetSystem;
        public int RewardAmount;
    }
}