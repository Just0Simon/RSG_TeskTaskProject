using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Items/" + nameof(ActiveItemsConfiguration),
        fileName = nameof(ActiveItemsConfiguration) + "_Default", order = 0)]
    public class ActiveItemsConfiguration : ScriptableObject
    {
        [field: SerializeField]
        public int MaxActiveItems { get; private set; } = 9;
    }
}