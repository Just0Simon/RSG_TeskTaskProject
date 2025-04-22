using System;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.ShopModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours
{
    public class BuyItemEntityBehaviourFromMarket : IEntityBehaviour
    {
        private EntityContext _entityContext;
        private ItemType _itemToBuy;
        private ITradeValidator _tradeValidator;
        private IItemBuyer _itemBuyer;
        private Transform _marketTransform;
        private IPlayerBalanceService _playerBalanceService;
        
        public event Action OnBehaviorEnd;

        private bool _haveBoughtItem;

        public BuyItemEntityBehaviourFromMarket(ITradeValidator tradeValidator, IItemBuyer itemBuyer, IPlayerBalanceService playerBalanceService)
        {
            _tradeValidator = tradeValidator;
            _itemBuyer = itemBuyer;
            _playerBalanceService = playerBalanceService;
        }
        
        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;
        
        public void SetItemToBuy(ItemType itemToBuy)
        {
            _itemToBuy = itemToBuy;
        }

        public void SetMarketTransform(Transform marketTransform)
        {
            _marketTransform = marketTransform;
        }
        
        public void Start() =>
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;

        public void Process() {
            if(IsNearTheTarget())
                BuyItems();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_marketTransform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityContext.EntityDamageable.Position, _marketTransform.position) <= _entityContext.EntityData.InteractDistance;

        private void BuyItems()
        {
            TryBuyItem();
            
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }

        private void TryBuyItem()
        {
            if(_haveBoughtItem)
                return;
            
            if (_tradeValidator.CanBuyItem(_itemToBuy, _playerBalanceService) is false)
                return;
            
            _itemBuyer.BuyItem(_itemToBuy, _entityContext.Storage, _playerBalanceService);
            _haveBoughtItem = true;
        }
    }
}