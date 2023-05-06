using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_CargoOutfit_ScriptableObject", menuName = "ScriptableObjects/Outfits/CargoContainerOutfit", order = 1)]
    [Serializable]
    public class CargoContainerOutfitScriptableObject : OutfitScriptableObject {
        public string CargoContents;
        public int CargoCapacity;
    }
}