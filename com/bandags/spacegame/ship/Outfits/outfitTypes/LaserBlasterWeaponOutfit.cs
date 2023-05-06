using System.Collections.Generic;
using com.bandags.spacegame.data;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public class LaserBlasterWeaponOutfit : WeaponOutfit {
        private List<IProjectile> _projectiles;
        private int projectileCount;
        private int projectileIterator;
        public override void Fire() {
            var projectile = _projectiles[projectileIterator];
            projectile.SetTarget(Owner.Sensors.HostileTarget.gameObject, Owner.transform.position + (Owner.transform.up.normalized * 6), Owner);
            _lastTimeWeaponWasFired = Time.realtimeSinceStartup;
            projectileIterator++;
            if (projectileIterator == projectileCount) {
                projectileIterator = 0;
            }

            //FireRateInSeconds = 90000;
        }

        public override T Upcast<T>() {
            return (T)(object)this;
        }

        public override WeaponOutfitData Serialize() {
            return WeaponOutfitData;
        }

        public override void Deserialize(WeaponOutfitData data) {
            WeaponOutfitData = data;
            projectileCount = 10;
            
            _projectiles = new List<IProjectile>(projectileCount);
            for (var x = 0; x < projectileCount; x++) {
                var projectile = Instantiation.InstantiatePrefab<Projectile>("vfx_Projectile_BulletGreen_Mobile");
                projectile.Setup(new ProjectileData {
                    Damage = Damage,
                    Range = Range,
                    ProjectileCount = projectileCount,
                    ProjectileType = ProjectileType.GreenBullet,
                    FireRateInSeconds = FireRateInSeconds
                }, Owner);
                projectile.transform.SetParent(Owner.transform);
                _projectiles.Add(projectile);
            }
        }

        public LaserBlasterWeaponOutfit(WeaponOutfitData weaponOutfitData, Ship owner) : base(weaponOutfitData, owner) { }
    }
}