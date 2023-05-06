using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.bandags.spacegame.ui.map {
    public class MapSystem : MonoBehaviour, ISelectable {
        public SystemLayerData SystemLayerData;
        public Image Image;
        public TextMeshProUGUI TextNameText;
        public MapDataManager MapDataManager;
        
        public void Select() {
            MapDataManager.SelectSystem(this);
            Image.color = Color.yellow;
            TextNameText.color = Color.yellow;
            Debug.Log($"clicked: {SystemLayerData.SystemType}");
        }

        public void UnSelect() {
            Image.color = Color.white;
            TextNameText.color = Color.white;
        }

        public SelectableType GetSelectableType() {
            return SelectableType.MapPlanet;
        }

        public string GetSelectableName() {
            return name;
        }
    }
}