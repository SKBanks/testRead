namespace com.bandags.spacegame.ship {
    public class Hardpoint : IHardpoint {
        public IWeaponOutfit Weapon { get; set; }
        public HardpointSize Size { get; internal set; }
        public Ship Target { get; private set; }

        public void FireWeapon() {
            if (Weapon.NotReady()) return;
            Weapon.Fire();
        }

        public void SetTarget(Ship ship) {
            Target = ship;
        }

        public void SetWeapon(IWeaponOutfit weaponOutfit) {
            Weapon = weaponOutfit;
        }
    }
}