using System.Collections.Generic;
using DefaultNamespace.UI.Panels.Trading;
using UnityEngine;

namespace DefaultNamespace {
    public class TradingPanel : MonoBehaviour {
        private readonly List<CommodityUI> _commodities = new List<CommodityUI>();

        public Transform CommoditiesParent;

        public void AddCommodity(CommodityUI commodity) {
            commodity.transform.SetParent(CommoditiesParent);
            _commodities.Add(commodity);
        }

        public void ResetCommodities() {
            foreach (Transform child in CommoditiesParent.transform) {
                Destroy(child.gameObject);
            }
            _commodities.Clear();
        }
        
        public void PurchaseMultiplier1Clicked() {
            foreach (var commodityUI in _commodities) {
                commodityUI.SetPurchaseMultiplier(1);
            }
        }
        
        public void PurchaseMultiplier5Clicked() {
            foreach (var commodityUI in _commodities) {
                commodityUI.SetPurchaseMultiplier(5);
            }
        } 
        
        public void PurchaseMultiplier25Clicked() {
            foreach (var commodityUI in _commodities) {
                commodityUI.SetPurchaseMultiplier(25);
            }
        } 
    }
}