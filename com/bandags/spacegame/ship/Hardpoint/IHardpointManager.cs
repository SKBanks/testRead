using UnityEngine;

namespace com.bandags.spacegame.ship {
    public interface IHardpointManager { 
        Vector3 HardpointCounts { get; }
        void CreateHardpoints(int largeHardpoints, int mediumHardpoints, int smallHardpoints);
        bool AddWeaponToHardpoint(IWeaponOutfit weaponOutfit);
        void FireWeapons(Ship target);
        int GetMaxWeaponRange();
    }
}