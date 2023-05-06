using System;
using UnityEngine;
using com.bandags.spacegame.ship;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "WeaponOutfit_ScriptableObject", menuName = "ScriptableObjects/WeaponOutfitScriptableObject", order = 1)]
    [Serializable]
    public class WeaponOutfitScriptableObject : OutfitScriptableObject {
        [field: SerializeReference] public int Damage;
        [field: SerializeReference] public int Range;
        [field: SerializeReference] public float FireRateInSeconds;
        [field: SerializeReference] public HardpointSize RequiredHardpointSize;
        [field: SerializeReference] public WeaponStyle WeaponStyle;
    }
}