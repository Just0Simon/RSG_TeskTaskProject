using Content.Features.ItemEffectsModule.Scripts;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    public class Item : IMarketItem, IWeightItem {
        public ItemType ItemType { get; private set; }
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int SellPrice { get; private set; }
        public int BuyPrice { get; private set; }
        public float Weight { get; private set; }
        public EffectType EffectType { get; private set; }

        public Item(ItemType itemType, string name, Sprite icon, int sellPrice, float weight, EffectType effectType) {
            ItemType = itemType;
            Name = name;
            Icon = icon;
            SellPrice = sellPrice;
            Weight = weight;
            EffectType = effectType;
        }
    
        public Item(ItemConfiguration itemConfiguration) {
            ItemType = itemConfiguration.ItemType;
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            SellPrice = itemConfiguration.SellPrice;
            BuyPrice = itemConfiguration.BuyPrice;
            Weight = itemConfiguration.Weight;
            EffectType = itemConfiguration.EffectType;
        }
    }
}