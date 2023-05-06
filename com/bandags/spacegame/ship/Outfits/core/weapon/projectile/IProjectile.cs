using UnityEngine;

namespace com.bandags.spacegame.ship {
    

    public interface IProjectile {
        IProjectileData ProjectileData { get; }
        void Setup(IProjectileData projectileData, Ship owner);
        void SetTarget(GameObject target, Vector3 startingPosition, Ship owner);
        void Reset();
    }
}