using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule
{
    public class PotionShopInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemType _itemToBuy;
        
        private IEntityBehaviourFactory _entityBehaviourFactory;
        
        [Inject]
        public void InjectDependencies(IEntityBehaviourFactory entityBehaviourFactory) =>
            _entityBehaviourFactory = entityBehaviourFactory;

        public void Interact(IEntity entity) {
            BuyItemEntityBehaviourFromMarket buyItemEntityBehaviourFromMarket = _entityBehaviourFactory.GetEntityBehaviour<BuyItemEntityBehaviourFromMarket>();
            buyItemEntityBehaviourFromMarket.SetItemToBuy(_itemToBuy);
            buyItemEntityBehaviourFromMarket.SetMarketTransform(transform);
            
            entity.SetBehaviour(buyItemEntityBehaviourFromMarket);
        }
    }
}