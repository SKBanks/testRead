using System;
using System.Collections.Generic;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class GalaxyData {
        public List<SystemLayerData> SystemsData;
        public SystemLayerData ActiveSystemLayer;
    }
}