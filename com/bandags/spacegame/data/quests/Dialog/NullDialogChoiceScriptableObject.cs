using System;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "NullDialogChoice_ScriptableObject", menuName = "ScriptableObjects/Quest/NullDialogChoiceScriptableObject", order = 1)]
    [Serializable]
    public class NullDialogChoiceScriptableObject : ChoiceScriptableObject {
        public override DialogChoiceType DialogChoiceType => DialogChoiceType.Null;
    }
}