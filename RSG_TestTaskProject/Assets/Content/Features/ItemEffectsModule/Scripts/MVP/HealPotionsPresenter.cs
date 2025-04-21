using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.InventoryModule.Scripts;
using Content.Features.ItemEffectsModule.Scripts.Input;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class HealPotionsPresenter : ConcreteItemTypePresenter, IDisposable
    {
        private readonly IActiveItemsInputListener _activeItemsInputListener;
        private readonly HealPotionsView _healPotionsView;

        private readonly List<Item> _healPotions = new List<Item>();
        
        public HealPotionsPresenter(IInventoryModelProvider inventoryModelProvider, IActiveItemsInputListener activeItemsInputListener, HealPotionsView healPotionsView) : base(ItemType.Potion, inventoryModelProvider)
        {
            _activeItemsInputListener = activeItemsInputListener;
            _healPotionsView = healPotionsView;
            
            _activeItemsInputListener.OnHealActivateActionPerformed += OnHealActivateActionPerformed;
            UpdatePotionsCount();
        }

        public override void AddItem(Item item)
        {
            _healPotions.Add(item);
            UpdatePotionsCount();
        }

        public override void RemoveItem(Item item)
        {
            _healPotions.Remove(item);
            UpdatePotionsCount();
        }

        private void UsePotion()
        {
            if(_healPotions.Count == 0)
                return;
            
            _inventoryModel.RemoveItem(_healPotions[0]);
        }

        private void UpdatePotionsCount()
        {
            _healPotionsView.SetHealPotionsCount(_healPotions.Count);
        }
        
        private void OnHealActivateActionPerformed()
        {
            UsePotion();
        }
        
        public override void Dispose()
        {
            base.Dispose();
            _activeItemsInputListener.OnHealActivateActionPerformed -= OnHealActivateActionPerformed;
        }
    }
}