using System;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [Serializable]
    public abstract class ChoiceScriptableObject : ScriptableObject {
        public abstract DialogChoiceType DialogChoiceType { get; }
        public string ChoiceButtonText;
    }
}