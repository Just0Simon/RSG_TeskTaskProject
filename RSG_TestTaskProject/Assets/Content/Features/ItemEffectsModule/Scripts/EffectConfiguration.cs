using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public abstract class EffectConfiguration : ScriptableObject
    {
        [field: SerializeField]
        public bool ConsumeItem { get; private set; }
        public abstract EffectType EffectType { get; }
        public abstract IEffect GetEffect(IEffectsFactory factory);
    }
}