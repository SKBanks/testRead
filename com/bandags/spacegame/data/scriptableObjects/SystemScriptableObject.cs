using System;
using System.Collections.Generic;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_ScriptableObject", menuName = "ScriptableObjects/SystemScriptableObject", order = 1)]
    [Serializable]
    public class SystemScriptableObject : ScriptableObject {
        public string Name;
        public SystemType SystemType;
        public List<PlanetScriptableObject> Planets;
        public List<SystemType> Neighbors;
        public ShipGroupCollectionScriptableObject ShipGroupCollection;
        public Vector3 MapPosition;
    }
}

