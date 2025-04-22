using UnityEngine;

namespace Content.Features.LootModule.Scripts
{
    public abstract class AbstractMonoLootSpawner : MonoBehaviour, ILootSpawner
    {
        public abstract void SpawnLoot();
    }
}