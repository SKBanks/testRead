using System;
using UnityEngine;

namespace com.bandags.spacegame.planet {
    [Serializable]
    public class Commodity : ISerialize<CommodityData> {
        public CommodityType CommodityType => _commodityData.CommodityType;
        public int Price => _commodityData.Price;

        [field:SerializeReference] private CommodityData _commodityData;

        public CommodityData Serialize() {
            return _commodityData;
        }

        public void Deserialize(CommodityData data) {
            _commodityData = data;
        }
    }
}