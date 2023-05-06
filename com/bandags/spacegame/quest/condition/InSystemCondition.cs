using com.bandags.spacegame.system;

namespace com.bandags.spacegame.quest.condition {
    public class InSystemCondition : IQuestCondition {
        private readonly SystemType _targetSystemType;
        
        public InSystemCondition(SystemType targetSystemType) {
            _targetSystemType = targetSystemType;
        }

        public bool ConditionsMet() {
            return GameEngine.Instance.CurrentPlayer.CurrentPlayerState.CurrentSystem == _targetSystemType;
        }
    }
}