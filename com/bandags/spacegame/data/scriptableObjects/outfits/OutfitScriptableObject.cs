using System;
using UnityEngine;
using com.bandags.spacegame.ship;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class OutfitScriptableObject : ScriptableObject {
        [field: SerializeReference] public string Name;
        [field: SerializeReference] public int Cost;
        [field: SerializeReference] public int Value;
        [field: SerializeReference] public int OutfitCapacity;
        [field: SerializeReference] public OutfitCategory OutfitCategory;
        [field: SerializeReference] public OutfitType OutfitType;
    }
}