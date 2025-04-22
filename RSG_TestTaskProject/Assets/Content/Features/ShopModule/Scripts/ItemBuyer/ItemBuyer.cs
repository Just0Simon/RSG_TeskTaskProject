using System.Collections.Generic;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public class ItemBuyer : IItemBuyer
    {
        private readonly ItemsConfiguration _itemsConfiguration;
        private readonly IItemFactory _itemFactory;
        private readonly ITradeLogger _logger;

        public ItemBuyer(ItemsConfiguration itemsConfiguration, IItemFactory itemFactory, ITradeLogger logger)
        {
            _itemsConfiguration = itemsConfiguration;
            _itemFactory = itemFactory;
            _logger = logger;
        }
        
        public Item BuyItem(ItemType itemType, IStorage storage, IPlayerBalanceService playerBalanceService)
        {
            var itemConfig = _itemsConfiguration.GetItemConfiguration(itemType);
            var item = _itemFactory.GetItem(itemType);

            storage.AddItem(item);
            playerBalanceService.Remove(item.BuyPrice);
            _logger.LogBuy(itemType, itemConfig.BuyPrice);
            return item;
        }

        public IEnumerable<Item> BuyItems(IEnumerable<ItemType> itemTypes, IStorage storage, IPlayerBalanceService playerBalanceService)
        {
            foreach (var itemType in itemTypes)
            {
                yield return BuyItem(itemType, storage, playerBalanceService);
            }
        }
    }
}