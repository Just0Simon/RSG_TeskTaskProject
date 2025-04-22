using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.ShopModule.Scripts
{
    [CreateAssetMenu(menuName = "Configuration/Shop/" + nameof(BlackListItemsConfiguration),
        fileName = nameof(BlackListItemsConfiguration), order = 0)]
    public class BlackListItemsConfiguration : ScriptableObject
    {
        [field: SerializeField]
        public List<ItemType> BlackListItems { get; private set; } = new List<ItemType>();
    }
}