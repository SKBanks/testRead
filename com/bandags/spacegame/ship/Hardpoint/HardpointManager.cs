using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public class HardpointManager : IHardpointManager {
        private readonly List<IHardpoint> _hardpoints;
        public Vector3 HardpointCounts { get; private set; }

        public HardpointManager() {
            _hardpoints = new List<IHardpoint>();
        }

        public bool AddWeaponToHardpoint(IWeaponOutfit weaponOutfit) {
            var freeHardpoint = GetFreeHardpointBySize(weaponOutfit.RequiredHardpointSize);
            if (freeHardpoint == null) return false;
            freeHardpoint.SetWeapon(weaponOutfit);
            return true;
        }

        public void FireWeapons(Ship target) {
            foreach (var hardpoint in _hardpoints.Where(hardpoint => hardpoint.Weapon != null)) {
                hardpoint.SetTarget(target);
                hardpoint.FireWeapon();
            }
        }

        public int GetMaxWeaponRange() {
            return GetActiveHardpoints().Sum(hardpoint => hardpoint.Weapon.Range);
        }
        
        public void CreateHardpoints(int largeHardpoints, int mediumHardpoints, int smallHardpoints) {
            HardpointCounts = new Vector3(largeHardpoints, mediumHardpoints, smallHardpoints);
            CreateAndAddHardpoints(largeHardpoints, HardpointSize.Large);
            CreateAndAddHardpoints(mediumHardpoints, HardpointSize.Medium);
            CreateAndAddHardpoints(smallHardpoints, HardpointSize.Small);
        }

        private void CreateAndAddHardpoints(int count, HardpointSize size) {
            for (var x = 0; x < count; x++) {
                _hardpoints.Add(new Hardpoint { Size = size });
            }
        }

        private IHardpoint GetFreeHardpointBySize(HardpointSize hardpointSize) {
            return _hardpoints.Find(hardpoint => hardpoint.Size == hardpointSize && hardpoint.Weapon == null);
        }

        private IEnumerable<IHardpoint> GetActiveHardpoints() {
            return _hardpoints.Where(hardpoint => hardpoint.Weapon != null);
        }
    }
}