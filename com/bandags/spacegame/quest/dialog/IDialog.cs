using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest {
    public interface IDialog : IQuestAction {
        DialogType DialogType { get; }
        void CloseDialog();
    }
}