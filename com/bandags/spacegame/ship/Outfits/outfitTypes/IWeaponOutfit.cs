using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface IWeaponOutfit : IOutfit, ISerialize<WeaponOutfitData> {
        int Damage { get; }
        int Range { get; }
        float FireRateInSeconds { get; }
        //Hardpoint Hardpoint { get; set; }
        HardpointSize RequiredHardpointSize { get; }
        WeaponStyle WeaponStyle { get; }
        Ship Owner { get; }
        void Fire();
        bool NotReady();
    }
}