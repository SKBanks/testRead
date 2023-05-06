using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_CargoOutfit_ScriptableObject", menuName = "ScriptableObjects/CargoOutfitScriptableObject", order = 1)]
    [Serializable]
    public class CargoOutfitScriptableObject : HullOutfitScriptableObject {
        public int CargoCapacity;
    }
}