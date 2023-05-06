using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class PlanetData {
        public PlanetType PlanetType;
        public SystemType SystemType;
        public Vector3 Position;
        public Vector3 Scale;
        public bool Visited;

        public string Description;
        public Sprite PlanetImage;
        public List<PlanetFeatureData> PlanetFeatures;
        
        public static PlanetData CreateFromScriptableObject(PlanetScriptableObject planetScriptableObject) {
            return new PlanetData {
                PlanetType = planetScriptableObject.PlanetType,
                SystemType = planetScriptableObject.SystemType,
                Position =  planetScriptableObject.Position,
                Scale = planetScriptableObject.Scale,
                Visited =  planetScriptableObject.Visited,
                Description = planetScriptableObject.Description,
                PlanetImage = planetScriptableObject.PlanetImage
            };
        }
    }
}