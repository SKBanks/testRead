using System;
using com.bandags.spacegame.data.scriptableObjects;
using com.bandags.spacegame.data.serialization.planet;
using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.data.serialization {
    [Serializable]
    public class PlanetFeatureData {
        public PlanetFeatureType PlanetFeatureType;
        
        public static PlanetFeatureData CreateFromScriptableObject(PlanetFeatureScriptableObject planetFeatureScriptableObject) {
            switch (planetFeatureScriptableObject.PlanetFeatureType) {
                case PlanetFeatureType.Trade:
                    break;
                case PlanetFeatureType.Jobs:
                    return JobPFData.CreateFromScriptableObject(planetFeatureScriptableObject as JobPlanetFeatureScriptableObject);
                case PlanetFeatureType.Shipyard:
                    break;
                case PlanetFeatureType.Outfitter:
                    break;
                case PlanetFeatureType.PlanetDetails:
                    return new PlanetDetailsPFData();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}