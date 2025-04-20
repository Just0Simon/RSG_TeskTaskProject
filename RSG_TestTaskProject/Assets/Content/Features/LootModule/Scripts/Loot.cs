using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.LootModule.Scripts {
    public class Loot : MonoBehaviour, ILoot {
        [SerializeField] private List<ItemType> _itemsInLoot;

        public Vector3 Position => transform.position;

        public IEnumerable<ItemType> GetItemsInLoot() =>
            _itemsInLoot;

        public void DestroyLoot() =>
            Destroy(gameObject);
    }
}