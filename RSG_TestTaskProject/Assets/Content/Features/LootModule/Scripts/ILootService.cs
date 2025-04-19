using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public interface ILootService {
        bool CanCollectLoot(Loot loot, IStorage storage);
        void CollectLoot(Loot loot, IStorage storage);
    }
}