using com.bandags.spacegame.planet;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Panels.Trading {
    public class CommodityUI : MonoBehaviour {
        private Commodity _commodity;
        public Text NameText;
        public Text PriceText;
        public Text CargoText;

        private int purchaseMultiplier;
        public Text BuyButtonText;
        public Text SellButtonText;

        public static CommodityUI CreateCommodity(Commodity commodity) {
            var commodityGO = Instantiate (Resources.Load ("Commodity") as GameObject);
            var commodityUI = commodityGO.GetComponent<CommodityUI>();
            commodityUI._commodity = commodity;
            commodityUI.NameText.text = commodity.CommodityType.ToString();
            commodityUI.PriceText.text = commodity.Price.ToString();
            commodityUI.CargoText.text = "";
            return commodityUI;
        }

        public void SetPurchaseMultiplier(int multiplierValue) {
            purchaseMultiplier = multiplierValue;
            BuyButtonText.text = $"x{purchaseMultiplier}";
            SellButtonText.text = $"x{purchaseMultiplier}";
        }

        public void BuyButtonClicked() {
            var cost = purchaseMultiplier * _commodity.Price;
            Debug.Log($"You bought {purchaseMultiplier} units of {_commodity.CommodityType} @ ${_commodity.Price} a unit for a total cost of ${cost}");
            //Verify user has enough space to buy (Otherwise reduce buy count to max available space)
            //Verify user has enough money to buy (Otherwise reduce buy count to max can afford)
            //Add Commodity to user inventory (based on buy count)
            //Remove money from user (based on buy count)
        }

        public void SellButtonClicked() {
            var profit = purchaseMultiplier * _commodity.Price;
            Debug.Log($"You sold {purchaseMultiplier} units of {_commodity.CommodityType} @ ${_commodity.Price} a unit for a total profit of ${profit}");
            //Verify has that much to sell (Otherwise reduce sell count to max available to sell)
            //Remove Commodity to user inventory (based on sell count)
            //Add money to user (based on buy count)
        }
    }
}