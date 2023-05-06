using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_ShipGroupCollection_ScriptableObject", menuName = "ScriptableObjects/ShipGroupCollectionScriptableObject", order = 1)]
    [Serializable]
    public class ShipGroupCollectionScriptableObject : ScriptableObject {
        public List<ShipGroupScriptableObject> ShipGroupOptions;
    }
}