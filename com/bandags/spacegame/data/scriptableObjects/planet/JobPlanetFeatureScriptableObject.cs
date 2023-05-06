using System;
using System.Collections.Generic;
using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;
using UnityEngine;

namespace com.bandags.spacegame.data.scriptableObjects {
    [CreateAssetMenu(fileName = "_Job_PlanetFeature_ScriptableObject", menuName = "ScriptableObjects/Planets/Features/JobPlanetFeatureSO", order = 1)]
    [Serializable]
    public class JobPlanetFeatureScriptableObject : PlanetFeatureScriptableObject {
        public new PlanetFeatureType PlanetFeatureType => PlanetFeatureType.Jobs;
        public List<JobType> AvailableJobs;
    }
}