using System;
using System.Collections.Generic;
using com.bandags.spacegame.player;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class QuestData {
        public List<PlayerQuest> ActiveQuests;
        public List<PlayerQuest> CompletedQuests;

        public static QuestData CreateQuestData() {
            return new QuestData {
                ActiveQuests = new List<PlayerQuest>(),
                CompletedQuests = new List<PlayerQuest>()
            };
        }
    }
}