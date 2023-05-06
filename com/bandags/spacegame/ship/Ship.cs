using System;
using com.bandags.spacegame.data.Serialization;
using UnityEngine;
using com.bandags.spacegame.input;
using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.ship {
    [Serializable]
    public class Ship : MonoBehaviour, IShip {
        public Rigidbody2D Rigidbody2D;
        public ShipSelectionMenu ShipSelectionMenu;
        public ShipType ShipType {
            get => _shipData.ShipType;
            set => _shipData.ShipType = value;
        }
        public FactionType FactionType {
            get => _shipData.FactionType;
            set => _shipData.FactionType = value;
        }

        [field: SerializeReference] public IOutfitManager OutfitManager;
        [field: SerializeReference] public IHelm Helm;
        [field: SerializeReference] public ISensors Sensors;
        [field: SerializeReference] public ITactical Tactical;
        [field: SerializeReference] public ICargo Cargo;

        [field: SerializeReference] private ShipData _shipData;
        
        private void Awake() {
            OutfitManager = new OutfitManager();
            Cargo = new Cargo(OutfitManager);
            Helm = new Helm(this);
            Sensors = new Sensors();
            Tactical = new Tactical(this);
        }

        public void Select() {
            ShipSelectionMenu.ShowMenu(GameEngine.Instance.CurrentPlayer.CurrentShip);
        }

        public void UnSelect() {
            ShipSelectionMenu.HideMenu();
        }

        public SelectableType GetSelectableType() {
            return SelectableType.Ship;
        }

        public string GetSelectableName() {
            return name;
        }

        /// <summary>
        /// Checks if this ship is allowed to attack the target ship
        /// </summary>
        /// <param name="targetShip"></param>
        /// <returns>true if this ship is allowed to attack the target ship</returns>
        public bool CanAttackShip(Ship targetShip) {
            if (targetShip == null) return false;
            return IsHostile(targetShip.FactionType);
        }

        public bool CanBoardShip(Ship targetShip) {
            //todo: implement this
            return true;
        }

        public void Attack(Ship targetShip) {
            Sensors.HostileTarget = targetShip;
            Helm.HelmAI.AttackShip(Sensors.HostileTarget);
            Tactical.TacticalAI.AttackTarget(Sensors.HostileTarget, Helm.HelmAI);
        }

        public void Land(Planet targetPlanet) {
            Helm.HelmAI.LandOnPlanet(targetPlanet);
        }

        public void MoveToPosition(Vector3 position) {
            Helm.HelmAI.GoToPosition(position);
            Debug.Log("[" + gameObject.name + "] Moving to position <" + position + ">");
        }
        
        public void MoveAndStopAtPosition(Vector3 position) {
            Helm.HelmAI.GoToPositionAndStop(position);
            Debug.Log("[" + gameObject.name + "] Moving and Stopping at position <" + position + ">");
        }

        public void BoardShip(Ship targetShip) {
            Debug.Log("[" + gameObject.name + "] Preparing to board <" + targetShip.name + ">");
        }

        public void HailShip(Ship targetShip) {
            Debug.Log("Greetings " + targetShip.name + ", it is I, " + gameObject.name +
                      "!  So nice to see you around these parts again.");
        }

        public void HailPlanet(Planet targetPlanet) {
            Debug.Log("Greetings " + targetPlanet.name + ", it is I, " + gameObject.name +
                      "!  Your planet is all the talk of the galaxy!");
        }

        public void TakeDamage(int amount, IShip source) {
            Debug.Log("Ouch.  Captain we just took " + amount + " damage to our hull.  It looks like " +
                      source.GetName() + " has attacked us!");
        }

        public string GetName() {
            return name;
        }

        private void UpdateAllOutfits() {
            Helm.UpdateOutfits();
            Sensors.UpdateOutfits();
            Tactical.UpdateOutfits();
        }

        public ShipData Serialize() {
            _shipData.OutfitManagerData = OutfitManager.Serialize();
            _shipData.Position = transform.position;
            return _shipData;
        }

        public void Deserialize(ShipData data) {
            _shipData = data;
            transform.position = _shipData.Position;
            Tactical.HardpointManager.CreateHardpoints(_shipData.LargeHardpoints, _shipData.MediumHardpoints, _shipData.SmallHardpoints);
            OutfitManager.Deserialize(_shipData.OutfitManagerData, this);
            UpdateAllOutfits();
        }

        public FactionType GetFactionType() => FactionType;

        /// <summary>
        /// Gets the hostile of this ship state based on the faction type provided
        /// </summary>
        /// <param name="factionType"></param>
        /// <returns>true if faction is of opposing type</returns>
        public bool IsHostile(FactionType factionType) {
            return (FactionType == FactionType.Empire && factionType == FactionType.Rebel) || (FactionType == FactionType.Rebel && factionType == FactionType.Empire);
        }
    }
}