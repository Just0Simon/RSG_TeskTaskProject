using UnityEngine;

namespace Content.Features.StorageModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Inventory/" + nameof(WeightStorageConfiguration),
        fileName = nameof(WeightStorageConfiguration), order = 0)]
    public class WeightStorageConfiguration : ScriptableObject
    {
        [field: SerializeField]
        public float MaxWeight { get; private set; } = 1;
    }
}