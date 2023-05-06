using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_ShieldOutfit_ScriptableObject", menuName = "ScriptableObjects/ShieldOutfitScriptableObject", order = 1)]
    [Serializable]
    public class ShieldOutfitScriptableObject : OutfitScriptableObject {
        [field: SerializeReference] public int ShieldStrength;
    }
}