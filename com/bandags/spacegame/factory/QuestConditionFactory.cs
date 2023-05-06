using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.quest.condition;

namespace com.bandags.spacegame.factory {
    public class QuestConditionFactory : IQuestConditionFactory {
        public IQuestCondition CreateQuestCondition(QuestConditionScriptableObject questConditionScriptableObject) {
            switch (questConditionScriptableObject.QuestConditionType) {
                case QuestConditionType.OnPlanet:
                    return CreateOnPlanetCondition(questConditionScriptableObject as OnPlanetQuestConditionScriptableObject);
                case QuestConditionType.InSystem:
                    return CreateInSystemCondition(questConditionScriptableObject as InSystemConditionScriptableObject);
                case QuestConditionType.HasShip:
                    return CreateHasShipCondition();
                case QuestConditionType.HasCredits:
                    return CreateHasCreditsCondition(questConditionScriptableObject as HasCreditConditionScriptableObject);
                case QuestConditionType.None:
                default:
                    return new NullQuestCondition();
            }
        }

        private static IQuestCondition CreateOnPlanetCondition(OnPlanetQuestConditionScriptableObject onPlanetQuestConditionScriptableObject) {
            return new OnPlanetQuestCondition(onPlanetQuestConditionScriptableObject.TargetPlanet);
        }
        
        private static IQuestCondition CreateInSystemCondition(InSystemConditionScriptableObject inSystemConditionScriptableObject) {
            return new InSystemCondition(inSystemConditionScriptableObject.TargetSystem);
        }
        
        private static IQuestCondition CreateHasShipCondition() {
            return null;
        }
        
        private IQuestCondition CreateHasCreditsCondition(HasCreditConditionScriptableObject hasCreditConditionScriptableObject) {
            return new HasCreditsCondition(hasCreditConditionScriptableObject.TargetAmount);
        }
    }
}