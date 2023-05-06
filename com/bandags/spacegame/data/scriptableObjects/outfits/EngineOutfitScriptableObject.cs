using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "_EngineOutfit_ScriptableObject", menuName = "ScriptableObjects/EngineOutfitScriptableObject", order = 1)]
    [Serializable]
    public class EngineOutfitScriptableObject : OutfitScriptableObject {
        [field: SerializeReference] public int ThrustForce;
        [field: SerializeReference] public int SteeringForce;
    }
}