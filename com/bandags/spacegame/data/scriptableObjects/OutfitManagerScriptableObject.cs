using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "OutfitManager_ScriptableObject", menuName = "ScriptableObjects/Ship/OutfitManagerScriptableObject", order = 1)]
    [Serializable]
    public class OutfitManagerScriptableObject : ScriptableObject {
        public List<OutfitScriptableObject> AllOutfits;
    }
}