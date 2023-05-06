using System;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_DialogChoice_ScriptableObject", menuName = "ScriptableObjects/Quest/DialogChoiceScriptableObject", order = 1)]
    [Serializable]
    public class DialogChoiceScriptableObject : ChoiceScriptableObject {
        public override DialogChoiceType DialogChoiceType => DialogChoiceType.Dialog;
        public ScriptableObject Dialog;
        public DialogType DialogType;        
    }
}