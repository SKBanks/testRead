namespace com.bandags.spacegame.quest.condition {
    public class HasCreditsCondition : IQuestCondition {
        private readonly int creditAmount;

        public HasCreditsCondition(int creditAmount) {
            this.creditAmount = creditAmount;
        }
        public bool ConditionsMet() {
            return GameEngine.Instance.CurrentPlayer.CurrentPlayerState.Credit >= creditAmount;
        }
    }
}