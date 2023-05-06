namespace com.bandags.spacegame.ship {
    public interface IHardpoint {
        IWeaponOutfit Weapon { get; set; }
        HardpointSize Size { get; }
        Ship Target { get; }
        void FireWeapon();
        void SetTarget(Ship ship);
        void SetWeapon(IWeaponOutfit weaponOutfit);
    }
}