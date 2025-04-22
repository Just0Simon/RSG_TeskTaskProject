using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts
{
    public interface ILoot
    {
        public UnityEngine.Vector3 Position { get; }
        public IEnumerable<ItemType> GetItemsInLoot();
        public void DestroyLoot();
    }
}