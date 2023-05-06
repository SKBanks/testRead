using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.ui.planet;
using TMPro;
using UnityEngine;

namespace com.bandags.spacegame.planet {
    public class PlanetSceneData : MonoBehaviour {
        public TextMeshProUGUI TitleText;
        public PlanetData PlanetData;
        public PlanetPanelManager PlanetPanelManager;
        
        public GameObject PanelButtonParent;
        private PanelButtonHandler _panelButtonHandler;

        private void Awake() {
            _panelButtonHandler = new PanelButtonHandler(PanelButtonParent);
        }

        public void LoadPlanet(PlanetType planetType) {
            PlanetData = GameEngine.Instance.Galaxy.ActiveSystem.GetPlanetByType(planetType).Serialize();
            TitleText.SetText(PlanetData.PlanetType.ToString().Replace("\\n", "\n"));
            PlanetPanelManager.LoadPanels(PlanetData);
            _panelButtonHandler.GenerateButtonMenu2(PlanetData.PlanetFeatures, PlanetPanelManager);
        }
    }
}