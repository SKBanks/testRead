using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_QuestDialogData_ScriptableObject", menuName = "ScriptableObjects/Quest/MultiChoiceDialogDataScriptableObject", order = 1)]
    [Serializable]
    public class MultiChoiceDialogDataScriptableObject : DialogDataScriptableObject {
        public List<ChoiceScriptableObject> Choices;
    }
}