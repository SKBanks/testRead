using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.ui.planet.panels {
    public interface IPanel {
        PlanetFeatureType PlanetFeatureTypeType { get; }
        void Show();
        void Hide();
    }
}