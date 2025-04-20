using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public interface ILootService {
        bool CanCollectLoot(ILoot loot, IStorage storage);
        void CollectLoot(ILoot loot, IStorage storage);
    }
}