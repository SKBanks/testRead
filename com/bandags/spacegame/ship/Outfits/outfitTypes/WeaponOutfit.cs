using com.bandags.spacegame.data;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public abstract class WeaponOutfit : IWeaponOutfit {
        public string Name {
            get => WeaponOutfitData.Name;
            set => WeaponOutfitData.Name = value;
        }
        public int Cost {
            get => WeaponOutfitData.Cost;
            set => WeaponOutfitData.Cost = value;
        }
        public int Value {
            get => WeaponOutfitData.Value;
            set => WeaponOutfitData.Value = value;
        }
        public int OutfitCapacity {
            get => WeaponOutfitData.OutfitCapacity;
            set => WeaponOutfitData.OutfitCapacity = value;
        }
        public OutfitCategory OutfitCategory {
            get => WeaponOutfitData.OutfitCategory;
            protected set => WeaponOutfitData.OutfitCategory = value;
        }
        public OutfitType OutfitType {
            get => WeaponOutfitData.OutfitType;
            protected set => WeaponOutfitData.OutfitType = value;
        }

        public int Damage {
            get => WeaponOutfitData.Damage;
            protected set => WeaponOutfitData.Damage = value;
        }
        public int Range {
            get => WeaponOutfitData.Range;
            protected set => WeaponOutfitData.Range = value;
        }
        public float FireRateInSeconds {
            get => WeaponOutfitData.FireRateInSeconds;
            protected set => WeaponOutfitData.FireRateInSeconds = value;
        }
        public HardpointSize RequiredHardpointSize {
            get => WeaponOutfitData.RequiredHardpointSize;
            protected set => WeaponOutfitData.RequiredHardpointSize = value;
        }
        public WeaponStyle WeaponStyle {
            get => WeaponOutfitData.WeaponStyle;
            protected set => WeaponOutfitData.WeaponStyle = value;
        }
        protected WeaponOutfitData WeaponOutfitData;
        //public Hardpoint Hardpoint { get; set; }
        public Ship Owner { get; internal set; }
        protected float _lastTimeWeaponWasFired;
        
        public abstract void Fire();
        public abstract T Upcast<T>();
        public abstract WeaponOutfitData Serialize();
        public abstract void Deserialize(WeaponOutfitData data);
        
        protected WeaponOutfit(WeaponOutfitData weaponOutfitData, Ship owner) {
            Owner = owner;
            Deserialize(weaponOutfitData);
        }
        
        /// <summary>
        /// Preconditions check before firing a weapon
        /// </summary>
        /// <returns>true if weapon is not ready to fire, false if the weapon can fire</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool NotReady() {
            if (NoTarget()) return true;
            if (IsWeaponReloading()) return true;
            if (IsTargetOutOfRange(Owner.Sensors.HostileTarget.transform.position, Owner.transform.position, Range)) return true;
            if (IsTargetOutOfView(Owner.Sensors.HostileTarget.transform.position, Owner.transform, .95f)) return true;
            return false;
        }
        private bool NoTarget() {
            return Owner.Sensors.HostileTarget == null;
        }

        private bool IsWeaponReloading() {
            return Time.realtimeSinceStartup < _lastTimeWeaponWasFired + FireRateInSeconds;
        }

        private static bool IsTargetOutOfRange(Vector2 targetPosition, Vector2 hardpointPosition, float range) {
            return range < Vector2.Distance(targetPosition, hardpointPosition);
        }
        
        private static bool IsTargetOutOfView(Vector3 targetPosition, Transform hardpointTransform, float view) {
            return !Math.isFacing(hardpointTransform.position, hardpointTransform.up, targetPosition, view);
        }
    }
}