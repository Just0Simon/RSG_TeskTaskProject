using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts {
    public class LootSpawner : AbstractMonoLootSpawner
    {
        [SerializeField] private List<Loot> _lootToSpawn;
        private DiContainer _diContainer;

        [Inject]
        public void InjectDependencies(DiContainer diContainer) =>
            _diContainer = diContainer;

        public override void SpawnLoot() {
            foreach (Loot loot in _lootToSpawn)
                _diContainer.InstantiatePrefab(loot.gameObject, transform.position, Quaternion.identity, null);
        }
    }
}