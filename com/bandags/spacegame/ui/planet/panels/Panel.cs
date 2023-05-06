using com.bandags.spacegame.planet;
using UnityEngine;

namespace com.bandags.spacegame.ui.planet.panels {
    public abstract class Panel : MonoBehaviour, IPanel {
        public abstract PlanetFeatureType PlanetFeatureTypeType { get; }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}