namespace com.bandags.spacegame.factory {
    public interface IFactory {
        IShipFactory ShipFactory { get; }
        IPlanetFactory PlanetFactory { get; }
        ISystemFactory SystemFactory { get; }
        IDialogFactory DialogFactory { get; }
        IQuestFactory QuestFactory { get; }
    }
}