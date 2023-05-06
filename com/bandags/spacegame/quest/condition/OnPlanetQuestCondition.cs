using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.quest.condition {
    public class OnPlanetQuestCondition : IQuestCondition {
        private readonly PlanetType _targetPlanetType;
        public OnPlanetQuestCondition(PlanetType targetTargetPlanetType) {
            _targetPlanetType = targetTargetPlanetType;
        }
        public bool ConditionsMet() {
            return GameEngine.Instance.CurrentPlayer.CurrentPlayerState.CurrentPlanet == _targetPlanetType;
        }
    }
}