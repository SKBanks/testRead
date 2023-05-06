using System;

namespace com.bandags.spacegame.ship {
    [Serializable]
    public class Helm : IHelm {
        public HelmProperties Properties { get; }
        public IHelmAI HelmAI { get; }
        
        private Ship _ship;
        public Helm(Ship ship) {
            _ship = ship;
            Properties = new HelmProperties(_ship);
            HelmAI = new HelmAI(ship);
        }
        public void UpdateOutfits() {
            var thrustForce = 0;
            var steeringForce = 0;
            _ship.OutfitManager.GetOutfits<IEngineOutfit>().ForEach(outfit => {
                thrustForce += outfit.ThrustForce;
                steeringForce += outfit.SteeringForce;
            });
            Properties.SetBaseValues(thrustForce, steeringForce, 289, 100);//Todo: fix cargo hardcode, fix baseMass hardcode
        }
    }
}