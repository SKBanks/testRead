using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [Serializable]
    [CreateAssetMenu(fileName = "_ShipGroup_ScriptableObject", menuName = "ScriptableObjects/ShipGroupScriptableObject", order = 1)]
    public class ShipGroupScriptableObject : ScriptableObject {
        public List<ShipScriptableObject> ShipsInGroup;
    }
}