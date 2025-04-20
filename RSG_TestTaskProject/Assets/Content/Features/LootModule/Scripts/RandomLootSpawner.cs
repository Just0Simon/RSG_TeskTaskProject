using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts
{
    public class RandomLootSpawner : AbstractMonoLootSpawner
    {
        private const float MIN_CHANCE = 0f;
        private const float MAX_CHANCE = 1f;
        
        [SerializeField] private List<RandomLoot> _lootToSpawn;
        
        private DiContainer _diContainer;

        [Inject]
        public void InjectDependencies(DiContainer diContainer) =>
            _diContainer = diContainer;

        public override void SpawnLoot() {
            foreach (Loot loot in GetRandomLoot())
                _diContainer.InstantiatePrefab(loot.gameObject, transform.position, Quaternion.identity, null);
        }

        private IEnumerable<Loot> GetRandomLoot()
        {
            float chance = GenerateLootChance();

            foreach (var randomLoot in _lootToSpawn)
            {
                if(randomLoot.Chance >= chance)
                    yield return randomLoot.Loot;
            }
        }
        
        private float GenerateLootChance() =>
            Random.Range(MIN_CHANCE, MAX_CHANCE);
    }
}