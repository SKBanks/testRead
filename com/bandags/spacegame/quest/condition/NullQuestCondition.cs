namespace com.bandags.spacegame.quest {
    public class NullQuestCondition : IQuestCondition {
        /// <summary>
        /// Always returns true
        /// </summary>
        /// <returns>true</returns>
        public bool ConditionsMet() {
            return true;
        }
    }
}