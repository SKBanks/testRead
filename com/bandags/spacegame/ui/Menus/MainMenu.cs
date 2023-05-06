using UnityEngine;
using UnityEngine.UI;

namespace com.bandags.spacegame.ui {
    public class MainMenu : MonoBehaviour {
        private const string CurrentPlayerProfileKey = "CurrentPlayer";
        public Button CreatePlayerButton;
        public Button LoadPlayerButton;
        public Button EnterShipButton;
        public Canvas Canvas;

        public void CreatePlayerButtonClicked() {
            Debug.Log("Create New Player Profile");
            Debug.Log("Not Implemented");
        }

        public void LoadPlayerProfileButtonClicked() {
            /*Debug.Log("Restore Static Save Data");
            const string galaxyData = "{\"SystemsData\":[{\"Name\":\"Sol\",\"SystemType\":0,\"Planets\":[0,1]}],\"ActiveSystem\":{\"SystemData\":{\"Name\":\"Sol\",\"SystemType\":0,\"Planets\":[0,1]},\"Planets\":[{\"Name\":\"Earth\",\"PlanetType\":0,\"Position\":{\"x\":-60.0,\"y\":-20.0,\"z\":0.10000000149011612},\"Scale\":{\"x\":50.0,\"y\":50.0,\"z\":1.0}},{\"Name\":\"Mars\",\"PlanetType\":1,\"Position\":{\"x\":-180.0,\"y\":-20.0,\"z\":0.10000000149011612},\"Scale\":{\"x\":80.0,\"y\":80.0,\"z\":1.0}}]}}";
            const string playerData = "{\"CurrentShip\":{\"Position\":{\"x\":-181.7685546875,\"y\":-19.260000228881837,\"z\":0.0},\"IsDisabled\":false,\"ShipType\":1,\"OutfitManager\":{\"_EngineOutfits\":[{\"Name\":\"Basic Engine\",\"Cost\":500,\"Value\":500,\"OutfitType\":0,\"ThrustForce\":261000,\"SteeringForce\":21600}],\"_HullOutfits\":[{\"Name\":\"Basic Hull\",\"Cost\":600,\"Value\":600,\"OutfitType\":1,\"HullStrength\":500,\"Mass\":500}],\"_ShieldOutfits\":[{\"Name\":\"Basic Shield\",\"Cost\":1500,\"Value\":1500,\"OutfitType\":2,\"ShieldStrength\":1200}],\"_WeaponOutfits\":[{\"Name\":\"\",\"Cost\":0,\"Value\":0,\"OutfitType\":3,\"SProjectileData\":{\"Range\":75,\"FireRateInSeconds\":0.20000000298023225,\"Damage\":75,\"ProjectileType\":0,\"ProjectileCount\":10}}]}},\"Name\":\"TestPilot1\"}";
            PlayerPrefs.SetString(FileSystemPaths.GALAXY_DATA_PATH, galaxyData);
            PlayerPrefs.SetString(FileSystemPaths.PLAYER_DATA_PATH, playerData);
            PlayerPrefs.Save();*/
        }

        public void EnterShipButtonClicked() {
            Debug.Log("Load Game");
            GameEngine.Instance.GameSceneManager.LoadSystem();
        }

        public void SettingsButtonClicked() {
            Debug.Log("Load Options Menu");
        }
    }
}