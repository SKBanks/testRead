using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.scriptableObjects;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_ScriptableObject", menuName = "ScriptableObjects/PlanetScriptableObject", order = 1)]
    [Serializable]
    public class PlanetScriptableObject : ScriptableObject {
        public PlanetType PlanetType;
        public SystemType SystemType;
        public Vector3 Position;
        public Vector3 Scale;
        public bool Visited;

        public string Description;
        public Sprite PlanetImage;
        public List<PlanetFeatureType> PlanetFeaturesList;
        public List<PlanetFeatureScriptableObject> PlanetFeatures;
    }
}

