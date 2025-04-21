using System;
using Content.Features.ItemEffectsModule.Scripts;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    [Serializable]
    public class ItemConfiguration {
        public ItemType ItemType;
        public string Name;
        public Sprite Icon;
        public int SellPrice;
        public int BuyPrice;
        public float Weight;
        public EffectType EffectType;
    }
}