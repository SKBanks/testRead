using System;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_QuestDialogData_ScriptableObject", menuName = "ScriptableObjects/Quest/OkDialogDataScriptableObject", order = 1)]
    [Serializable]
    public class OkDialogDataScriptableObject : DialogDataScriptableObject {
        public ChoiceScriptableObject OkButtonChoice;
    }
}