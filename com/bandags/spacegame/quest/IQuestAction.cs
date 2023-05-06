using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest {
    public interface IQuestAction {
        void Execute();
        PlayerQuest PlayerQuest { get; set; }
    }
}