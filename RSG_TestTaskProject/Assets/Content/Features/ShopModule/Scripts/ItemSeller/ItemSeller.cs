using System.Collections.Generic;
using System.Linq;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public class ItemSeller : IItemSeller
    {
        private readonly ItemsConfiguration _itemsConfiguration;
        private readonly ITradeLogger _logger;

        public ItemSeller(ItemsConfiguration itemsConfiguration, ITradeLogger logger)
        {
            _itemsConfiguration = itemsConfiguration;
            _logger = logger;
        }
        
        public int SellItem(Item item, IStorage storage)
        {
            var itemConfig = _itemsConfiguration.GetItemConfiguration(item.ItemType);
            storage.RemoveItem(item);

            _logger.LogSell(item.ItemType, itemConfig.SellPrice);
            return itemConfig.SellPrice;
        }

        public int SellItems(List<Item> items, IStorage storage)
        {
            storage.RemoveItems(items);

            return items.Sum(item => item.SellPrice);
        }
    }
}