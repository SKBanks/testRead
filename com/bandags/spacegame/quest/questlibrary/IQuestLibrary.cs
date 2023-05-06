using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest {
    public interface IQuestLibrary {
        void LoadLibrary(List<QuestScriptableObject> questScriptableObjects);
        void FilterLibrary(List<PlayerQuest> availablePlayerQuests, List<PlayerQuest> completedPlayerQuests);
        void CheckForAvailableQuestsToActivate();
        IQuest GetQuestByType(QuestType questType);
    }
}