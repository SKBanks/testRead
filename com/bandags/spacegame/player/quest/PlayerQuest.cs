using System;
using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.player {
    [Serializable]
    public class PlayerQuest {
        public QuestType QuestType;
        public QuestState StartingQuestState;
        public QuestState CompleteQuestState;
    }
}