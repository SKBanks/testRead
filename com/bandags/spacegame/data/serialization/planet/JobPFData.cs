using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.scriptableObjects;
using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.data.serialization {
    [Serializable]
    public class JobPFData : PlanetFeatureData {
        public List<JobType> JobTypes;

        public static JobPFData CreateFromScriptableObject(JobPlanetFeatureScriptableObject jobPlanetFeatureScriptableObject) {
            return new JobPFData {
                PlanetFeatureType = PlanetFeatureType.Jobs,
                JobTypes = jobPlanetFeatureScriptableObject.AvailableJobs
            };
        }
    }
}