namespace com.bandags.spacegame.quest {
    /// <summary>
    /// Sets the conditions required for various phases of the quest lifecycle
    /// </summary>
    public interface IQuestCondition {
        bool ConditionsMet();
    }
}