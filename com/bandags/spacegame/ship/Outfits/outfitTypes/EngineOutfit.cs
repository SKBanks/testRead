using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public class EngineOutfit : IEngineOutfit {
        public string Name {
            get => _EngineOutfitData.Name;
            set => _EngineOutfitData.Name = value;
        }
        public int Cost {
            get => _EngineOutfitData.Cost;
            set => _EngineOutfitData.Cost = value;
        }
        public int Value {
            get => _EngineOutfitData.Value;
            set => _EngineOutfitData.Value = value;
        }
        public int OutfitCapacity {
            get => _EngineOutfitData.OutfitCapacity;
            set => _EngineOutfitData.OutfitCapacity = value;
        }
        public OutfitCategory OutfitCategory => _EngineOutfitData.OutfitCategory;
        public OutfitType OutfitType => _EngineOutfitData.OutfitType;
        public int ThrustForce {
            get => _EngineOutfitData.ThrustForce;
            internal set => _EngineOutfitData.ThrustForce = value;
        }
        public int SteeringForce {
            get => _EngineOutfitData.SteeringForce;
            internal set => _EngineOutfitData.SteeringForce = value;
        }

        private EngineOutfitData _EngineOutfitData { get; set; }
        public EngineOutfit(EngineOutfitData engineOutfitData) {
            Deserialize(engineOutfitData);
        }
        public T Upcast<T>() {
            return (T)(object)this;
        }
        public EngineOutfitData Serialize() {
            return _EngineOutfitData;
        }
        public void Deserialize(EngineOutfitData data) {
            _EngineOutfitData = data;
        }
    }
}