namespace com.bandags.spacegame.factory {
    public class Factory : IFactory {
        public IShipFactory ShipFactory { get; }
        public IPlanetFactory PlanetFactory { get; }
        public ISystemFactory SystemFactory { get; }
        public IDialogFactory DialogFactory { get; }
        public IQuestFactory QuestFactory { get; }
        public Factory() {
            ShipFactory = new ShipFactory();
            PlanetFactory = new PlanetFactory();
            SystemFactory = new SystemLayerFactory();
            var questRewardFactory = new QuestRewardFactory();
            DialogFactory = new DialogFactory(questRewardFactory);
            var questConditionFactory = new QuestConditionFactory();
            QuestFactory = new QuestFactory(DialogFactory, questConditionFactory);
        }
    }
}