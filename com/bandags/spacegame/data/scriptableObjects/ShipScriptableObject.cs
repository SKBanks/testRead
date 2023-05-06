using System;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_ScriptableObject", menuName = "ScriptableObjects/ShipScriptableObject", order = 1)]
    [Serializable]
    public class ShipScriptableObject : ScriptableObject {
        public ShipType ShipType;
        public FactionType FactionType;
        public GameObject Prefab;
        public Vector3 Position;
        public OutfitManagerScriptableObject OutfitManager;

        //Hardpoints
        public int LargeHardpoints;
        public int MediumHardpoints;
        public int SmallHardpoints;
    }
}