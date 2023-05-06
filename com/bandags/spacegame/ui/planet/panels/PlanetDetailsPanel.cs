using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using TMPro;
using UnityEngine.UI;

namespace com.bandags.spacegame.ui.planet.panels {
    public class PlanetDetailsPanel : Panel {
        public override PlanetFeatureType PlanetFeatureTypeType => PlanetFeatureType.PlanetDetails;
        public TextMeshProUGUI DescriptionText;
        public Image Image;

        public void LoadPlanetDetails(PlanetData planetData) {
            DescriptionText.SetText(planetData.Description.Replace("\\n", "\n"));
            Image.sprite = planetData.PlanetImage;
        }
    }
}