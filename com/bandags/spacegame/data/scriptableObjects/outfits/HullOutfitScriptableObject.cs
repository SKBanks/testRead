using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_HullOutfit_ScriptableObject", menuName = "ScriptableObjects/HullOutfitScriptableObject", order = 1)]
    [Serializable]
    public class HullOutfitScriptableObject : OutfitScriptableObject {
        [field: SerializeReference] public int HullStrength;
        [field: SerializeReference] public int Mass;
    }
}