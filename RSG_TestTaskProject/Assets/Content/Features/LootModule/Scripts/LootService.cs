using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public class LootService : ILootService {
        private IItemFactory _itemFactory;

        public LootService(IItemFactory itemFactory) =>
            _itemFactory = itemFactory;

        public bool CanCollectLoot(ILoot loot, IStorage storage)
        {
            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                if (storage.CanAddItem(_itemFactory.GetItem(itemType)) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public void CollectLoot(ILoot loot, IStorage storage) {
            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                storage.AddItem(_itemFactory.GetItem(itemType));
            }
        }
    }
}